using Core;
using Network.Clients;
using Network.Protocol;
using Network.TCP;
using ServerManagement;
using System;
using System.Runtime.InteropServices;
using UI;
using Utilities;

namespace Network.Servers
{
	public class AuthenticationServer
	{
		private delegate void ShowMsg(string msg);

		private AppState appState = AppState.Stoped;

		private TcpServer Server = new TcpServer();

		private Extra<ServerInfo> extra = new Extra<ServerInfo>();

		private ShowMsg AddMsgDelegate;

		public AuthenticationServer(string i, int pt)
		{
			try
			{
				SetAppState(AppState.Starting);
				SetServerState();
				Server.IpAddress = "0.0.0.0";
				Server.Port = (ushort)pt;
				Server.SocketBufferSize = 409600u;
				Server.SendPolicy = SendPolicy.Direct;
				if (Server.Start(0))
				{
					AddMsg(string.Format("开始监听端口 {0}:{1}", "0.0.0.0", pt));
					SetAppState(AppState.Started);
					return;
				}
				SetAppState(AppState.Stoped);
				throw new Exception($"监听端口失败 -> {Server.ErrorMessage}({Server.ErrorCode})");
			}
			catch (Exception ex)
			{
				AddMsg(ex.Message);
			}
		}

		private void SetServerState()
		{
			AddMsgDelegate = AddMsg;
			Server.OnPrepareListen += OnPrepareListen;
			Server.OnAccept += OnAccept;
			Server.OnSend += OnSend;
			Server.OnPointerDataReceive += OnPointerDataReceive;
			Server.OnClose += OnClose;
			Server.OnShutdown += OnShutdown;
			SetAppState(AppState.Stoped);
		}

		public void Dispose()
		{
			try
			{
				if (World.ConnectedServers != null)
				{
					foreach (SockClient value in World.ConnectedServers.Values)
					{
						value.Send("帐号服务器断开连接|" + value.ServerId );
						Server.Disconnect(value.ServerInfo.ConnId);
						value.Dispose();
					}
				}
				if (Server != null)
				{
					Server.Destroy();
					Server = null;
				}
			}
			catch (Exception ex)
			{
				AddMsg("停止账号验证服务出错 " + ex.Message);
			}
		}

		private HandleResult OnShutdown()
		{
			AddMsg("账号验证服务已停止");
			return HandleResult.Ok;
		}

		private HandleResult OnPrepareListen(IntPtr soListen)
		{
			return HandleResult.Ok;
		}

		private HandleResult OnAccept(IntPtr connId, IntPtr pClient)
		{
			try
			{
				string ip = string.Empty;
				ushort port = 0;
				if (Server.GetRemoteAddress(connId, ref ip, ref port))
				{
					ServerInfo serverInfo = InitClientData(connId, ip, port);
					if (serverInfo == null)
					{
						return HandleResult.Error;
					}
					if (extra.Set(connId, serverInfo))
					{
						new SockClient(serverInfo).Start();
						return HandleResult.Ok;
					}
					AddMsg($"账号验证服务器 [{connId},OnAccept] -> SetConnectionExtra(connId, ci) Error");
					return HandleResult.Error;
				}
				AddMsg($"账号验证服务器 [{connId},OnAccept] -> GetRemoteAddress(connId, ref ip, ref port) Error");
				return HandleResult.Error;
			}
			catch (Exception)
			{
				AddMsg($"账号验证服务器 [{connId},OnAccept] -> OnAccept Error");
				return HandleResult.Error;
			}
		}

		private HandleResult OnSend(IntPtr connId, byte[] bytes)
		{
			return HandleResult.Ok;
		}

		private HandleResult OnPointerDataReceive(IntPtr connId, IntPtr pData, int length)
		{
			try
			{
				ServerInfo serverInfo = extra.Get(connId);
				if (serverInfo == null || length <= 0)
				{
					return HandleResult.Error;
				}
				byte[] array = new byte[length];
				Marshal.Copy(pData, array, 0, length);
				serverInfo.Client.ProcessDataReceived(array, length);
				return HandleResult.Ok;
			}
			catch (Exception)
			{
				return HandleResult.Ignore;
			}
		}

		private HandleResult OnClose(IntPtr connId, SocketOperation enOperation, int errorCode)
		{
			try
			{
				if (extra.Remove(connId))
				{
					if (World.ConnectedServers.TryGetValue(connId, out var value))
					{
						value.Logout(connId);
					}
				}
				else
				{
					AddMsg(string.Format(" 服务器断开错误 [{0},OnClose] -> SetConnectionExtra({0}, null) fail", connId));
				}
			}
			catch
			{
			}
			return HandleResult.Ok;
		}

		private ServerInfo InitClientData(IntPtr connId, string ip, ushort port)
		{
			try
			{
				return new ServerInfo
				{
					ConnId = connId,
					IpAddress = ip,
					Port = port,
					Server = Server
				};
			}
			catch
			{
			}
			return null;
		}

		private void SetAppState(AppState state)
		{
			appState = state;
		}

		private void AddMsg(string msg)
		{
			MainForm.WriteLine(3, msg);
		}
	}
}
