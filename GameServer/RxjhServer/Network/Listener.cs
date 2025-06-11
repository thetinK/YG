using System;
using System.Collections;
using System.Net;
using HPSocket;
using HPSocket.Tcp;

namespace RxjhServer.Network
{
	public class Listener
	{
		private delegate void ShowMsg(string msg, int type);

		private AppState appState = AppState.Stoped;

		private readonly TcpServer Server = new TcpServer();

		private ShowMsg AddMsgDelegate;

		private bool m_Disposed;

		private void SetServerState()
		{
			AddMsgDelegate = AddMsg;
			Server.OnPrepareListen += OnPrepareListen;
			Server.OnAccept += OnAccept;
			Server.OnSend += OnSend;
			Server.OnReceive += OnReceive;
			Server.OnClose += OnClose;
			Server.OnShutdown += OnShutdown;
			Server.SocketBufferSize = 8192u;
			Server.FreeBufferObjPool = 24576u;
			Server.FreeBufferObjHold = 73728u;
			SetAppState(AppState.Stoped);
		}

		public Listener(ushort port)
		{
			try
			{
				m_Disposed = false;
				SetServerState();
				Start(port);
			}
			catch (Exception ex)
			{
				SetAppState(AppState.Error);
				AddMsg(ex.Message, 1);
			}
		}

		private void Start(ushort port)
		{
			try
			{
				SetAppState(AppState.Starting);
				Server.Address = "0.0.0.0";
				Server.Port = port;
				Server.SendPolicy = ((World.MainServer == 1) ? SendPolicy.Safe : SendPolicy.Direct);
				if (Server.Start())
				{
					World.MainSocket = true;
					World.游戏服务器端口2 = port;
					AddMsg(string.Format("开始监听端口 {0}:{1}", "0.0.0.0", port), 1);
					World.conn.发送("更新服务器端口|" + World.ServerID + "|" + port);
					SetAppState(AppState.Started);
					return;
				}
				SetAppState(AppState.Stoped);
				throw new Exception(string.Format("监听端口失败 -> {0}({1})", Server.ErrorMessage, Server.ErrorCode, 1));
			}
			catch (Exception ex)
			{
				AddMsg(ex.Message, 1);
			}
		}

		public void Stop()
		{
			try
			{
				SetAppState(AppState.Stoping);
				World.MainSocket = false;
				if (!m_Disposed)
				{
					if (Server.Stop())
					{
						SetAppState(AppState.Stoped);
						m_Disposed = true;
					}
					else
					{
						AddMsg("停止通信服务出错", 1);
					}
				}
			}
			catch (Exception ex)
			{
				AddMsg("停止通信服务出错2 " + ex.Message, 1);
			}
		}

		public void Dispose()
		{
			try
			{
				Server.Stop();
				Server.Dispose();
			}
			catch (Exception ex)
			{
				AddMsg("终止通信服务出错 " + ex.Message, 1);
			}
		}

		private HandleResult OnShutdown(IServer sender)
		{
			AddMsg("停止通信组件服务", 3);
			return HandleResult.Ok;
		}

		private void Disconnect(IntPtr connId)
		{
			try
			{
				if (!Server.Disconnect(connId))
				{
					throw new Exception($"断开连接({connId}) 错误");
				}
				AddMsg($"$({connId}) 断开连接", 3);
			}
			catch (Exception ex)
			{
				AddMsg(ex.Message, 1);
			}
		}

		private HandleResult OnPrepareListen(IServer sender, IntPtr listen)
		{
			return HandleResult.Ok;
		}

		private static long IpToInt(string ip)
		{
			char[] separator = new char[1] { '.' };
			string[] array = ip.Split(separator);
			return (long.Parse(array[0]) << 24) | (long.Parse(array[1]) << 16) | (long.Parse(array[2]) << 8) | long.Parse(array[3]);
		}

		private HandleResult OnAccept(IServer sender, IntPtr connId, IntPtr pClient)
		{
			try
			{
				if (Server.GetRemoteAddress(connId, out var ip, out var port))
				{
					if (World.封IP)
					{
						IPAddress iPAddress = new IPAddress((uint)IPAddress.HostToNetworkOrder((int)IpToInt(ip)));
						if (World.BipList.Contains(iPAddress))
						{
							if (World.断开连接)
							{
								Disconnect(connId);
							}
							if (World.关闭连接)
							{
								Stop();
							}
						}
						DateTime value = DateTime.Now;
						int num = 0;
						foreach (NetState value2 in World.ConnectionList.Values)
						{
							if (value2.ToString() == iPAddress.ToString())
							{
								value = value2.Ljtime;
								num++;
							}
						}
						if (num > World.游戏登陆端口最大连接数)
						{
							if ((int)DateTime.Now.Subtract(value).TotalMilliseconds < World.游戏登陆端口最大连接时间数)
							{
								MainForm.WriteLine(1, "到达IP最大连接数" + iPAddress.ToString());
								if (World.加入过滤列表 && !World.BipList.Contains(iPAddress))
								{
									World.BipList.Add(iPAddress);
								}
								Disconnect(connId);
								try
								{
									Queue queue = Queue.Synchronized(new Queue());
									foreach (NetState value3 in World.ConnectionList.Values)
									{
										if (value3.ToString() == iPAddress.ToString())
										{
											queue.Enqueue(value3);
										}
									}
									while (queue.Count > 0)
									{
										((NetState)queue.Dequeue()).Dispose();
									}
								}
								catch
								{
								}
							}
						}
						else
						{
							ClientInfo clientInfo = SetClientData(connId, ip, port);
							if (Server.SetExtra(connId, clientInfo))
							{
								new NetState(clientInfo).Start();
							}
							else
							{
								AddMsg($" > [{connId}, OnAccept] -> SetConnectionExtra(connId, ci) Error", 1);
							}
						}
					}
					else
					{
						ClientInfo clientInfo2 = SetClientData(connId, ip, port);
						if (Server.SetExtra(connId, clientInfo2))
						{
							new NetState(clientInfo2).Start();
						}
						else
						{
							AddMsg($" > [{connId}, OnAccept] -> SetConnectionExtra(connId, ci) Error", 1);
						}
					}
				}
				else
				{
					AddMsg($" > [{connId}, OnAccept] -> GetRemoteAddress(connId, ref ip, ref port) Error", 1);
				}
			}
			catch (Exception)
			{
				AddMsg($" > [{connId}, OnAccept] -> OnAccept Error", 1);
			}
			return HandleResult.Ok;
		}

		private ClientInfo SetClientData(IntPtr connId, string ip, ushort port)
		{
			try
			{
				return new ClientInfo
				{
					ConnId = connId,
					IpAddress = ip,
					Port = port,
					Server = Server,
					WorldId = addWorldIdd()
				};
			}
			catch
			{
			}
			return null;
		}

		private int addWorldIdd()
		{
			for (int i = 300; i < 65500; i++)
			{
				if (!World.ConnectionList.ContainsKey(i))
				{
					return i;
				}
			}
			return 0;
		}

		private HandleResult OnSend(IServer sender, IntPtr connId, byte[] bytes)
		{
			World.SendSpeed += bytes.Length;
			return HandleResult.Ok;
		}

		private HandleResult OnReceive(IServer sender, IntPtr connId, byte[] bytes)
		{
			try
			{
				ClientInfo extra = Server.GetExtra<ClientInfo>(connId);
				if (extra != null)
				{
					int num = bytes.Length;
					if (num <= 0)
					{
						return HandleResult.Error;
					}
					World.ReceiveSpeed += num;
					using (new Lock(extra.Client.m_Buffer, "this.m_Buffer"))
					{
						extra.Client.m_Buffer.Enqueue(bytes, 0, num);
					}
					extra.Client.HandleReceive(extra.Client);
				}
				return HandleResult.Ok;
			}
			catch (Exception)
			{
				return HandleResult.Error;
			}
		}

		public NetState 生成一个假人连接()
		{
			NetState netState3 = null;
			IntPtr connId = new IntPtr(CreateIdService.GetUserConnId());
			int port = RNG.Next(45000, 65000);
			ClientInfo clientInfo2 = SetClientData(connId, "127.0.0.1", (ushort)port);
			netState3 = new NetState(clientInfo2);
			netState3.版本验证 = true;
			netState3.Start();
			return netState3;
		}

		private HandleResult OnClose(IServer sender, IntPtr connId, SocketOperation enOperation, int errorCode)
		{
			int num = 0;
			try
			{
				ClientInfo extra = Server.GetExtra<ClientInfo>(connId);
				if (extra != null)
				{
					num = 1;
					sender.RemoveExtra(connId);
					num = 2;
					extra.Client.logout(enOperation, errorCode);
				}
				if (errorCode == 0)
				{
					AddMsg($"[断开 连接ID:{connId} ExceStep:{num}]", 3);
				}
				else
				{
					AddMsg($"[断开 连接ID:{connId} ExceStep:{num}] -> OP:{enOperation}, CODE:{errorCode}", 3);
				}
				num = 3;
				if (!Server.SetExtra(connId, null))
				{
					num = 4;
					AddMsg($"[断开错误:SetConnectionExtra({connId}, null) fail ExceStep:{num}] -> OP:{enOperation}, CODE:{errorCode}", 3);
				}
			}
			catch (Exception ex)
			{
				AddMsg("断开错误 连接ID:" + connId + " OP:" + enOperation.ToString() + " CODE:" + errorCode + " ExceStep:" + num + " ExceptionMsg:" + ex.Message, 3);
			}
			return HandleResult.Ok;
		}

		private void SetAppState(AppState state)
		{
			appState = state;
			World.SocketState = appState.ToString();
		}

		private void AddMsg(string msg, int type)
		{
			MainForm.WriteLine(type, msg);
		}
	}
}
