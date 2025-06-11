using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using RxjhServer.HelperTools;

namespace RxjhServer.bbg
{
	public class SockClienT
	{
		public Socket clientSocket;

		private readonly byte[] dataReceive;

		private bool disposed;

		private readonly MemoryStream ms;

		private readonly RemoveClientDelegateE removeFromTheServerList;

		public bool Disposed => disposed;

		public IPAddress IP
		{
			get
			{
				try
				{
					return disposed ? null : ((IPEndPoint)clientSocket.RemoteEndPoint).Address;
				}
				catch
				{
					Dispose();
				}
				return null;
			}
		}

		public event MessageeDelegaterE OnSockMessage;

		public SockClienT(Socket from, RemoveClientDelegateE rftsl)
		{
			dataReceive = new byte[1500];
			disposed = false;
			ms = new MemoryStream();
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
					removeFromTheServerList?.Invoke(this);
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
			}
		}

		public virtual void OnReceiveData(IAsyncResult ar)
		{
			try
			{
				if (!disposed)
				{
					int num = clientSocket.EndReceive(ar);
					if (num <= 0)
					{
						Dispose();
						return;
					}
					ProcessDataReceived(dataReceive, num);
					Dispose();
				}
			}
			catch (Exception)
			{
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
					clientSocket.BeginReceive((ar.AsyncState as SockClienT).dataReceive, 0, (ar.AsyncState as SockClienT).dataReceive.Length, SocketFlags.None, OnReceiveData, ar.AsyncState);
				}
			}
			catch
			{
				Dispose();
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
				Dispose();
			}
		}

		public virtual void ProcessDataReceived(byte[] data, int length)
		{
		}

		public virtual void Sendd(string str)
		{
			byte[] bytes = Encoding.Default.GetBytes(str);
			Send(bytes, bytes.Length);
		}

		public virtual void Send(string str)
		{
			try
			{
				int t = 0;
				if (!disposed)
				{
					byte[] array = new byte[str.Length];
					Converter.ToBytes(str, array, ref t);
					clientSocket.BeginSend(array, 0, t, SocketFlags.None, OnSended2, this);
				}
			}
			catch (Exception)
			{
				Dispose();
			}
		}

		public virtual void Send(byte[] toSendBuff, int len)
		{
			try
			{
				if (!disposed)
				{
					byte[] array = new byte[len + 6];
					array[0] = 170;
					array[1] = 136;
					Buffer.BlockCopy(BitConverter.GetBytes(len), 0, array, 2, 4);
					Buffer.BlockCopy(toSendBuff, 0, array, 6, len);
					clientSocket.BeginSend(array, 0, array.Length, SocketFlags.None, OnSended2, this);
				}
			}
			catch (Exception)
			{
				Dispose();
			}
		}

		public virtual void Send(byte[] toSendBuff, int offset, int len)
		{
			try
			{
				if (!disposed)
				{
					byte[] array = new byte[len];
					Buffer.BlockCopy(toSendBuff, offset, array, 0, len);
					if (!disposed)
					{
						clientSocket.BeginSend(array, 0, len, SocketFlags.None, OnSended2, this);
					}
				}
			}
			catch (Exception)
			{
				Dispose();
			}
		}

		public void Start()
		{
			clientSocket.BeginReceive(dataReceive, 0, dataReceive.Length, SocketFlags.None, OnReceiveData, this);
		}

		public void RaiseMessageEvent(string Msg)
		{
			this.OnSockMessage?.Invoke(Msg, this);
		}
	}
}
