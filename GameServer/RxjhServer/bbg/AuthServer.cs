using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace RxjhServer.bbg
{
	public class AuthServer
	{
		public static ArrayList clients = new ArrayList();

		private readonly string ip;

		private Socket listenSocket;

		private readonly int port;

		public int totalReceive;

		public int totalSend;

		public event MessageeDelegaterE OnSockMessage;

		public AuthServer(string i, int pt)
		{
			totalSend = 0;
			totalReceive = 0;
			ip = i;
			port = pt;
			Start();
		}

		public void CloseServer()
		{
			listenSocket.Close();
		}

		public void Dispose()
		{
			while (clients.Count > 0)
			{
				((SockClienT)clients[0]).Dispose();
			}
			try
			{
				listenSocket.Shutdown(SocketShutdown.Both);
			}
			catch
			{
			}
			if (listenSocket != null)
			{
				listenSocket.Close();
			}
		}

		public virtual void OnAccept(IAsyncResult ar)
		{
			try
			{
				Socket socket = listenSocket.EndAccept(ar);
				if (socket != null)
				{
					ClientConnection clientConnection = new ClientConnection(socket, RemoveClient);
					clients.Add(clientConnection);
					clientConnection.OnSockMessage += connection1_OnSockMessage;
					clientConnection.Start();
				}
			}
			catch (Exception arg)
			{
				Console.WriteLine("{0}", arg);
			}
			try
			{
				listenSocket.BeginAccept(OnAccept, listenSocket);
			}
			catch
			{
				Dispose();
			}
		}

		public void RemoveClient(SockClienT client)
		{
			using (new Lock(clients, "RemoveClient"))
			{
				clients.Remove(client);
			}
		}

		public bool Start()
		{
			try
			{
				listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				listenSocket.Bind(new IPEndPoint(IPAddress.Any, port));
				MainForm.WriteLine(1, "开始监听百宝端口 " + port + " IP " + ip.ToString());
				listenSocket.Listen(10);
				listenSocket.BeginAccept(OnAccept, listenSocket);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failled to list on port {0}\n{1}", port, ex.Message);
				MainForm.WriteLine(1, "监听百宝端口出错 " + port + " " + ex.Message);
				listenSocket = null;
				return false;
			}
			return true;
		}

		private void connection1_OnSockMessage(object sender, SockClienT client)
		{
			RaiseMessageEvent(sender, client);
		}

		private void RaiseMessageEvent(object Msg, SockClienT client)
		{
			this.OnSockMessage?.Invoke(Msg, client);
		}
	}
}
