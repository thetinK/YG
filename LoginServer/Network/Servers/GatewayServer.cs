using Network.Clients;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using UI;

namespace Network.Servers
{
	public class GatewayServer
	{
		public static ArrayList clients = new ArrayList();

		private IPAddress address;

		private AddressFamily addressFamily;

		private string ip;

		private Socket listenSocket;

		private int port;

		public int totalReceive;

		public int totalSend;

		~GatewayServer()
		{
			Dispose();
		}

		public GatewayServer(string i, int pt)
		{
			totalSend = 0;
			totalReceive = 0;
			ip = i;
			port = pt;
			IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, port);
			addressFamily = iPEndPoint.Address.AddressFamily;
			address = iPEndPoint.Address;
		}

		public void Dispose()
		{
			while (clients.Count > 0)
			{
				((GatewaySocketClient)clients[0]).Dispose();
			}
			try
			{
				listenSocket.Shutdown(SocketShutdown.Both);
			}
			catch (Exception)
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
					GatewayHandler wGHandler = new GatewayHandler(socket, RemoveClient);
					lock (clients.SyncRoot)
					{
						clients.Add(wGHandler);
					}
					wGHandler.Start();
				}
			}
			catch
			{
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

		public void RemoveClient(GatewaySocketClient client)
		{
			(client as GatewayHandler).Logout();
			lock (clients.SyncRoot)
			{
				clients.Remove(client);
			}
		}

		public bool Start()
		{
			try
			{
				listenSocket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
				listenSocket.Bind(new IPEndPoint(IPAddress.Any, port));
				MainForm.WriteLine(3, string.Format("开始监听端口 {0}:{1}", "0.0.0.0", port));
				listenSocket.Listen(1000);
				listenSocket.BeginAccept(OnAccept, listenSocket);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failled to list on port {0}\n{1}", port, ex.Message);
				listenSocket = null;
				return false;
			}
			return true;
		}
	}
}
