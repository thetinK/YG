using Core;
using Delegates;
using System;
using System.Net.Sockets;

namespace Network.Clients
{
	public class BaseSocketClient : IDisposable
	{
		public Socket clientSocket;

		private ATRemoveClientDelegate removeFromTheServerList;

		private byte[] dataReceive;

		private bool disposed;

		public BaseSocketClient(Socket from, ATRemoveClientDelegate rftsl)
		{
			dataReceive = new byte[1024 * World.BufferMultiplier];
			disposed = false;
			removeFromTheServerList = rftsl;
			clientSocket = from;
		}

		public void Dispose()
		{
			if (!disposed)
			{
				disposed = true;
				try
				{
					clientSocket.Shutdown(SocketShutdown.Both);
				}
				catch
				{
				}
				if (clientSocket != null)
				{
					clientSocket.Close();
				}
				clientSocket = null;
				if (removeFromTheServerList != null)
				{
					removeFromTheServerList(this);
				}
			}
		}

		public virtual void OnReceiveData(IAsyncResult ar)
		{
			try
			{
				if (disposed)
				{
					return;
				}
				int num = clientSocket.EndReceive(ar);
				if (num <= 0)
				{
					Dispose();
					return;
				}
				byte[] array = World.aaaaaa != 1 ? DataReceived2(dataReceive, num) : ProcessDataReceived(dataReceive, num);
				if (array != null)
				{
					clientSocket.BeginSend(array, 0, array.Length, SocketFlags.None, OnSended, this);
				}
				else
				{
					clientSocket.BeginReceive(dataReceive, 0, dataReceive.Length, SocketFlags.None, OnReceiveData, this);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("{0}", ex.Message);
				Dispose();
			}
		}

		public void OnSended(IAsyncResult ar)
		{
			try
			{
				if (!disposed)
				{
					clientSocket.EndSend(ar);
					clientSocket.BeginReceive((ar.AsyncState as BaseSocketClient).dataReceive, 0, (ar.AsyncState as BaseSocketClient).dataReceive.Length, SocketFlags.None, OnReceiveData, ar.AsyncState);
				}
			}
			catch
			{
			}
		}

		public void OnSended2(IAsyncResult ar)
		{
			try
			{
				if (!disposed)
				{
					clientSocket.EndSend(ar);
				}
			}
			catch (Exception)
			{
			}
		}

		public virtual byte[] ProcessDataReceived(byte[] data, int length)
		{
			return null;
		}

		public virtual byte[] DataReceived2(byte[] data, int length)
		{
			return null;
		}

		public void Start()
		{
			clientSocket.BeginReceive(dataReceive, 0, dataReceive.Length, SocketFlags.None, OnReceiveData, this);
		}
	}
}
