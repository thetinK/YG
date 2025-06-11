using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;
using Core;
using UI;
using Utilities;

namespace Network.Servers
{
	public class AttackServerConnector
	{
		private int Atport;

		private Socket listenSocket;

		private System.Timers.Timer 自动连接;

		public AttackServerConnector(int port)
		{
			Atport = port;
			自动连接 = new System.Timers.Timer(5000.0);
			自动连接.Elapsed += 自动连接事件;
			自动连接.AutoReset = true;
			自动连接.Enabled = true;
		}

		private void ConnectCallback(IAsyncResult ar)
		{
			try
			{
				((Socket)ar.AsyncState).EndConnect(ar);
				try
				{
					MainForm.WriteLine(2, "攻击伺服器连接成功 IP " + World.GameServerIP.ToString() + " 端口 " + Atport);
					Thread.Sleep(10);
					byte[] array = Converter.hexStringToByte("AA551A002C0114200C00CF070000A102000024010000000000000000000055AA");
					Send(array, array.Length);
					Thread.Sleep(10);
					byte[] bytes = Encoding.Default.GetBytes("ATport" + new Random(World.GetRandomSeed()).Next(13000, 65535));
					byte[] array2 = Converter.hexStringToByte("AA557200000001006400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005D1201003139322E3136382E302E32353400000035304535343945414142464400000000000000000000000055AA");
					Buffer.BlockCopy(bytes, 0, array2, 10, bytes.Length);
					Send(array2, array2.Length);
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "攻击伺服器ConnectCallback出错：" + ex.Message);
				}
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "攻击伺服器连接出错：" + ex2.Message);
			}
		}

		public void OnSended2(IAsyncResult ar)
		{
			try
			{
				listenSocket.EndSend(ar);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "攻击伺服器发送出错2：" + ex.Message);
			}
		}

		public virtual void Send(byte[] toSendBuff, int len)
		{
			try
			{
				listenSocket.BeginSend(toSendBuff, 0, len, SocketFlags.None, OnSended2, this);
			}
			catch (SocketException ex)
			{
				MainForm.WriteLine(1, "攻击伺服器发送出错SocketException：" + ex.Message);
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "攻击伺服器发送出错Exception：" + ex2.Message);
			}
		}

		public void Sestup(int Port)
		{
			try
			{
				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(World.GameServerIP), Port);
				listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				listenSocket.UseOnlyOverlappedIO = true;
				listenSocket.LingerState.Enabled = false;
				listenSocket.ExclusiveAddressUse = false;
				listenSocket.BeginConnect(remoteEP, ConnectCallback, listenSocket);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "连接攻击伺服器出错    IP  " + World.GameServerIP.ToString() + "  " + ex.Message);
			}
		}

		private void 自动连接事件(object sender, ElapsedEventArgs e)
		{
			if (listenSocket != null && !listenSocket.Connected)
			{
				Sestup(Atport);
			}
		}
	}
}
