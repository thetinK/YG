using Delegates;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UI;

namespace Network.Clients
{
	public class GatewaySocketClient : IDisposable
	{
		public Socket clientSocket;

		private RemoveWGClientDelegate removeFromTheServerList;

		private byte[] dataReceive;

		private bool disposed;

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

		public GatewaySocketClient(Socket from, RemoveWGClientDelegate rftsl)
		{
			dataReceive = new byte[102400];
			disposed = false;
			removeFromTheServerList = rftsl;
			clientSocket = from;
		}

		public void Dispose()
		{
			if (!disposed)
			{
				disposed = true;
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
				byte[] array = ProcessDataReceived(dataReceive, num);
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
					clientSocket.BeginReceive((ar.AsyncState as GatewaySocketClient).dataReceive, 0, (ar.AsyncState as GatewaySocketClient).dataReceive.Length, SocketFlags.None, OnReceiveData, ar.AsyncState);
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

		public virtual void Sendd(string str)
		{
			byte[] bytes = Encoding.Default.GetBytes(str);
			发送(bytes, bytes.Length);
		}

		public virtual void 发送(byte[] toSendBuff, int len)
		{
			try
			{
				byte[] array = new byte[len + 6];
				array[0] = 170;
				array[1] = 102;
				Buffer.BlockCopy(BitConverter.GetBytes(len), 0, array, 2, 4);
				Buffer.BlockCopy(toSendBuff, 0, array, 6, len);
				clientSocket.BeginSend(array, 0, len + 6, SocketFlags.None, OnSended2, this);
			}
			catch (SocketException ex)
			{
				MainForm.WriteLine(1, "帐号服务器 发送出错：" + ex.Message);
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "帐号服务器 发送出错：" + ex2.Message);
			}
		}

		public virtual void Send(byte[] toSendBuff, int len)
		{
			try
			{
				if (!disposed)
				{
					byte[] array = new byte[len];
					Buffer.BlockCopy(toSendBuff, 0, array, 0, len);
					clientSocket.BeginSend(array, 0, len, SocketFlags.None, OnSended2, this);
				}
			}
			catch (Exception)
			{
			}
		}

		public virtual void Send(char[] toSendBuff, int len)
		{
			try
			{
				if (!disposed)
				{
					byte[] array = new byte[len];
					Buffer.BlockCopy(toSendBuff, 0, array, 0, len);
					clientSocket.BeginSend(array, 0, len, SocketFlags.None, OnSended2, this);
				}
			}
			catch (Exception)
			{
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
			}
		}

		public void Start()
		{
			clientSocket.BeginReceive(dataReceive, 0, dataReceive.Length, SocketFlags.None, OnReceiveData, this);
		}
	}
}
