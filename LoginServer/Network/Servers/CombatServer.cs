using Network.Clients;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using UI;

namespace Network.Servers
{
	public class CombatServer
	{
		public static ArrayList clients = new ArrayList();

		private IPAddress address;

		private AddressFamily addressFamily;

		private string ip;

		private Socket listenSocket;

		private int port;

		public CombatServer(string i, int pt)
		{
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
				((SockClient)clients[0]).Dispose();
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
					CombatHandler aTPlayerHandler = new CombatHandler(socket, RemoveClient);
					lock (clients.SyncRoot)
					{
						clients.Add(aTPlayerHandler);
					}
					aTPlayerHandler.Start();
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

		public void RemoveClient(BaseSocketClient client)
		{
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
				listenSocket.UseOnlyOverlappedIO = true;
				listenSocket.LingerState.Enabled = false;
				listenSocket.ExclusiveAddressUse = false;
				listenSocket.Bind(new IPEndPoint(IPAddress.Any, port));
				MainForm.WriteLine(3, "开始监听端口:" + port + " 地址:" + address.ToString());
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
