using System;
using System.Timers;
using HPSocket;
using RxjhServer.HelperTools;

namespace RxjhServer.Network
{
	public class NetState : IDisposable
	{
		public PacketEncrypt m_ep;

		public byte[] g_cur_key = new byte[8] { 54, 50, 51, 203, 80, 71, 40, 233 };

		public byte[] g_cur_key2 = new byte[8] { 204, 218, 35, 67, 103, 124, 55, 144 };

		public int Key2 = 2138432278;

		public DateTime 登陆sj = DateTime.Now;

		public DateTime Ljtime = DateTime.Now;

		public bool 在线;

		public bool 换线中;

		public bool 登陆;

		public bool 加密;

		private readonly ClientInfo CInfo;

		public bool 版本验证;

		private Players _Player;

		private bool _挂机;

		public ByteQueue m_Buffer;

		private bool m_Running;

		private System.Timers.Timer 自动断开;

		private bool _假人;

		private string _绑定帐号 = string.Empty;

		private bool bool_1;

		public Players Player
		{
			get
			{
				return _Player;
			}
			set
			{
				_Player = value;
			}
		}

		public string 绑定帐号
		{
			get
			{
				return _绑定帐号;
			}
			set
			{
				_绑定帐号 = value;
			}
		}

		public bool 挂机
		{
			get
			{
				return _挂机;
			}
			set
			{
				_挂机 = value;
			}
		}

		public bool 假人
		{
			get
			{
				return _假人;
			}
			set
			{
				_假人 = value;
			}
		}

		public bool 离线中
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		private ByteQueue mBuffer => m_Buffer;

		public bool Running
		{
			get
			{
				return m_Running;
			}
			set
			{
				m_Running = value;
			}
		}

		public IntPtr ConnId
		{
			get
			{
				return CInfo.ConnId;
			}
			set
			{
				CInfo.ConnId = value;
			}
		}

		public int WorldId
		{
			get
			{
				return CInfo.WorldId;
			}
			set
			{
				CInfo.WorldId = value;
			}
		}

		private void Decrypta(ref byte[] buff)
		{
			byte b = 0;
			for (int i = 0; i < buff.Length - 7; i++)
			{
				byte b2 = buff[5 + i];
				buff[5 + i] = (byte)(buff[5 + i] ^ g_cur_key[i % 8] ^ b);
				b = b2;
			}
		}

		public override string ToString()
		{
			return CInfo.IpAddress;
		}

		public void delWorldIdd()
		{
			try
			{
				World.ConnectionList.Remove(CInfo.WorldId);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "delWorldIdd()出错" + CInfo.WorldId + "|" + ToString() + " " + ex.Message);
			}
		}

		~NetState()
		{
		}

		public NetState(ClientInfo Ci)
		{
			try
			{
				CInfo = Ci;
				Ljtime = DateTime.Now;
				挂机 = false;
				假人 = false;
				m_Buffer = new ByteQueue();
				m_Running = false;
				if (!InList(CInfo.WorldId))
				{
					World.ConnectionList.Add(CInfo.WorldId, this);
				}
				else
				{
					MainForm.WriteLine(3, CInfo.WorldId + " 断开卡号连接 " + CInfo.IpAddress + ":" + CInfo.Port);
					CInfo.Server.Disconnect(CInfo.ConnId);
				}
				m_ep = new PacketEncrypt();
				Player = new Players(this);
				自动断开 = new System.Timers.Timer(World.版本验证时间);
				自动断开.Elapsed += 自动断开事件;
				自动断开.AutoReset = true;
				自动断开.Enabled = true;
				MainForm.WriteLine(3, "连接 连接ID[" + CInfo.ConnId.ToInt32() + "]-全服ID[" + CInfo.WorldId + "]-IP地址[" + CInfo.IpAddress + ":" + CInfo.Port + "]");
			}
			catch (Exception ex)
			{
				CInfo.Server.Disconnect(CInfo.ConnId);
				MainForm.WriteLine(3, CInfo.WorldId + " 初始化客户端连接出错 " + CInfo.IpAddress + ":" + CInfo.Port + "|" + ex.Message);
			}
		}

		private bool InList(int key)
		{
			NetState value;
			return World.ConnectionList.TryGetValue(key, out value);
		}

		private void 自动断开事件(object source, ElapsedEventArgs e)
		{
			if (!版本验证)
			{
				MainForm.WriteLine(1, CInfo.WorldId + " 自动断开事件 " + ToString());
				Dispose(flush: true);
			}
			if (自动断开 != null)
			{
				自动断开.Enabled = false;
				自动断开.Close();
				自动断开.Dispose();
				自动断开 = null;
			}
		}

		public void Start()
		{
			if (Player != null)
			{
				m_Running = true;
				reflashClient();
			}
		}

		private void reflashClient()
		{
			ClientInfo obj = new ClientInfo
			{
				ConnId = CInfo.ConnId,
				IpAddress = CInfo.IpAddress,
				Port = CInfo.Port,
				Server = CInfo.Server,
				WorldId = CInfo.WorldId,
				Client = this
			};
			CInfo.Server.SetExtra(CInfo.ConnId, obj);
		}

		public void SendPak(发包类 pak, int id, int wordid)
		{
			try
			{
				byte[] array = pak.ToArray2(id, wordid);
				byte[] array2 = new byte[array.Length + 15];
				array2[0] = 170;
				array2[1] = 85;
				Buffer.BlockCopy(BitConverter.GetBytes(array.Length + 9), 0, array2, 2, 2);
				Buffer.BlockCopy(array, 0, array2, 4, array.Length);
				array2[array2.Length - 2] = 85;
				array2[array2.Length - 1] = 170;
				Send(array2, array2.Length);
			}
			catch (Exception)
			{
			}
		}

		public void Send多包2(byte[] toSendBuff, int len)
		{
			if (m_Running)
			{
				try
				{
					byte[] array = new byte[BitConverter.ToInt16(toSendBuff, 8) + 5];
					Buffer.BlockCopy(toSendBuff, 4, array, 0, array.Length);
					Send多包加密(array, array.Length, 1);
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "Send()_Send多包" + WorldId + "|" + ex.Message);
				}
			}
		}

		public void Send多包(byte[] toSendBuff, int len)
		{
			int num = BitConverter.ToInt16(toSendBuff, 8);
			byte[] array = new byte[num + 6];
			Buffer.BlockCopy(toSendBuff, 4, array, 0, array.Length);
			Send多包加密(array, array.Length, 1);
		}

		private void Send多包加密(byte[] toSendBuff, int length, int xl)
		{
			try
			{
				byte[] array = new byte[toSendBuff.Length + 15];
				array[0] = 170;
				array[1] = 85;
				Buffer.BlockCopy(BitConverter.GetBytes(toSendBuff.Length + 9), 0, array, 2, 2);
				Buffer.BlockCopy(toSendBuff, 0, array, 4, toSendBuff.Length);
				array[array.Length - 2] = 85;
				array[array.Length - 1] = 170;
				Send(array, array.Length);
			}
			catch (Exception ex)
			{
				logo.FileTxtLog("包数据" + Converter.ToString(toSendBuff));
				MainForm.WriteLine(1, "Send()_Send多包加密发送错误" + WorldId + "|" + ex.Message + $"\r\nlength={length}, xl={xl}, toSendBuff={Converter.ToString(toSendBuff)}\r\n{ex.StackTrace}");
				MainForm.WriteLine(1, "Send()_Send多包加密发送错误" + WorldId + "|" + ex.Message);
			}
		}

		private void Send单包封装发送(byte[] toSendBuff, int length)
		{
			byte[] array = new byte[length + 15];
			array[0] = 170;
			array[1] = 85;
			Buffer.BlockCopy(BitConverter.GetBytes(length + 9), 0, array, 2, 2);
			Buffer.BlockCopy(toSendBuff, 0, array, 5, length);
			array[array.Length - 2] = 85;
			array[array.Length - 1] = 170;
			Send(array, array.Length);
		}

		public void Send单包(byte[] toSendBuff, int len)
		{
			byte[] array = new byte[BitConverter.ToInt16(toSendBuff, 9) + 7];
			Buffer.BlockCopy(toSendBuff, 5, array, 0, array.Length);
			Send单包封装发送(array, array.Length);
		}

		public void Send(byte[] toSendBuff, int len)
		{
			if (!m_Running)
			{
				return;
			}
			try
			{
				ushort num = BitConverter.ToUInt16(toSendBuff, 8);
				ushort num2 = (ushort)(num + 6);
				byte[] array = new byte[num2 + 6];
				for (int i = 0; 4 + i < toSendBuff.Length && i < num2; i++)
				{
					array[4 + i] = toSendBuff[4 + i];
				}
				Buffer.BlockCopy(BitConverter.GetBytes((ushort)21930), 0, array, 0, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(num2), 0, array, 2, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, array, 8, 2);
				Buffer.BlockCopy(BitConverter.GetBytes((ushort)43605), 0, array, array.Length - 2, 2);
				SendFullPakct(CInfo.ConnId, array, array.Length);
			}
			catch (Exception)
			{
				try
				{
					ushort num3 = (ushort)(toSendBuff.Length - 12);
					ushort num4 = (ushort)(num3 + 6);
					byte[] array2 = new byte[num4 + 6];
					for (int j = 0; 4 + j < toSendBuff.Length && j < num4; j++)
					{
						array2[4 + j] = toSendBuff[4 + j];
					}
					Buffer.BlockCopy(BitConverter.GetBytes((ushort)21930), 0, array2, 0, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(num4), 0, array2, 2, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(num3), 0, array2, 8, 2);
					Buffer.BlockCopy(BitConverter.GetBytes((ushort)43605), 0, array2, array2.Length - 2, 2);
					SendFullPakct(CInfo.ConnId, array2, array2.Length);
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "GS存在错包，已取消发送。" + ex.Message + "。");
					MainForm.WriteLine(1, Converter.ToString(toSendBuff) ?? "");
				}
			}
		}

		private void SendFullPakct(IntPtr conneId, byte[] fullPacket, int length)
		{
			byte[] array = new byte[fullPacket.Length + 2];
			Buffer.BlockCopy(fullPacket, 0, array, 0, 6);
			Buffer.BlockCopy(fullPacket, 6, array, 8, fullPacket.Length - 6);
			Buffer.BlockCopy(BitConverter.GetBytes(array.Length - 6), 0, array, 2, 2);
			fullPacket = array;
			length += 2;
			CInfo.Server.Send(conneId, fullPacket, length);
		}

		public void HandleReceive(NetState ns)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "HandleReceive");
			}
			try
			{
				if (mBuffer == null || mBuffer.Length <= 0)
				{
					return;
				}
				ByteQueue byteQueue = new ByteQueue();
				using (new Lock(mBuffer, "HandleReceive"))
				{
					byteQueue.Enqueue(mBuffer.m_Buffer, 0, mBuffer.Length);
					mBuffer.Clear();
				}
				int length = byteQueue.Length;
				while (length > 0 && Running)
				{
					if (World.JlMsg == 1)
					{
						MainForm.WriteLine(0, "HandleReceive");
					}
					if (length <= 4)
					{
						break;
					}
					int num = BitConverter.ToInt16(byteQueue.GetPacketID(), 0);
					if (num <= 0)
					{
						byteQueue.Clear();
						break;
					}
					int num2 = num + 6;
					if (length >= num2)
					{
						byte[] buff = new byte[num2];
						byteQueue.Dequeue(buff, 0, num2);
						length = byteQueue.Length;
						if (170 == buff[0] && 85 == buff[1])
						{
							if (buff[num2 - 2] != 85 || buff[num2 - 1] != 170)
							{
								byteQueue.Clear();
								break;
							}
							if (World.登录器版本切换 == 1)
							{
								Decrypta(ref buff);
							}
							if (World.是否加密 == 1)
							{
								m_ep.Dec(buff);
							}
							if (World.Log == 1)
							{
								string text = Converter.ToString(buff);
								int num3 = BitConverter.ToInt16(buff, 7);
								byte[] array = new byte[4];
								Buffer.BlockCopy(buff, 5, array, 0, 2);
								int num4 = BitConverter.ToInt32(array, 0);
								MainForm.WriteLine(7, num4 + "|" + num3 + "|" + text);
							}
							Player.ManagePacket(buff, buff.Length);
							continue;
						}
						byteQueue.Clear();
						break;
					}
					if (170 != byteQueue.m_Buffer[0] && 85 != byteQueue.m_Buffer[1])
					{
						byteQueue.Clear();
					}
					break;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "HandleReceive()出错" + WorldId + "|" + ToString() + " " + ex);
				CInfo.Server.Disconnect(CInfo.ConnId);
			}
		}

		public void IDout()
		{
			try
			{
				if (Player != null)
				{
					World.conn.发送("用户登出|" + Player.Userid + "|" + World.ServerID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "IDout()出错" + CInfo.WorldId + "|" + ToString() + " " + ex.Message);
			}
		}

		public void Dispose()
		{
			Dispose(flush: true);
		}

		public void Offline()
		{
			if (CInfo.Server.Disconnect(CInfo.ConnId))
			{
				挂机 = true;
				MainForm.WriteLine(3, CInfo.WorldId + " 离线挂机 " + ToString());
			}
			else
			{
				MainForm.WriteLine(3, CInfo.WorldId + " 离线挂机错误 " + ToString());
			}
		}

		public void 离线挂机()
		{
			if (CInfo.Server.Disconnect(CInfo.ConnId))
			{
				假人 = true;
				MainForm.WriteLine(3, CInfo.WorldId + " 离线假人 " + ToString());
			}
			else
			{
				MainForm.WriteLine(3, CInfo.WorldId + " 离线假人错误 " + ToString());
			}
		}

		public void DisposedOffline()
		{
			try
			{
				int num = CInfo.ConnId.ToInt32();
				int worldId = CInfo.WorldId;
				int num2 = 1;
				string text = ToString();
				num2 = 2;
				挂机 = false;
				假人 = false;
				m_Running = false;
				if (m_Buffer != null)
				{
					m_Buffer.Dispose();
					m_Buffer = null;
				}
				num2 = 3;
				if (自动断开 != null)
				{
					num2 = 4;
					自动断开.Enabled = false;
					num2 = 5;
					自动断开.Close();
					num2 = 6;
					自动断开.Dispose();
					num2 = 7;
					自动断开 = null;
					num2 = 8;
				}
				IDout();
				num2 = 9;
				if (Player != null)
				{
					num2 = 10;
					Player.Logout();
					num2 = 11;
					Player.Dispose();
					num2 = 12;
				}
				num2 = 13;
				if (World.AllConnectedPlayers.TryGetValue(CInfo.WorldId, out var _))
				{
					num2 = 14;
					World.AllConnectedPlayers.Remove(CInfo.WorldId);
					num2 = 15;
				}
				Player = null;
				num2 = 16;
				num2 = 17;
				if (World.ConnectionList.TryGetValue(CInfo.WorldId, out var value2))
				{
					num2 = 18;
					World.ConnectionList[CInfo.WorldId] = null;
					num2 = 19;
				}
				delWorldIdd();
				num2 = 20;
				value2 = null;
				MainForm.WriteLine(3, "退出挂机 连接ID[" + num + "]人物全服ID[" + worldId + "] IP地址[" + text + "] ExceStep:" + num2);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, " ProcessDisposedOffline()出错" + CInfo.WorldId + "|" + ToString() + " " + ex.Message);
			}
		}

		private void Dispose(bool flush)
		{
			try
			{
				CInfo.Server.Disconnect(CInfo.ConnId);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, " Dispose(bool flush)出错|" + CInfo.WorldId + "|" + ToString() + " " + ex.Message);
			}
		}

		public void logout(SocketOperation enOperation, int errorCode)
		{
			try
			{
				int num = 1;
				if (!World.ConnectionList.TryGetValue(CInfo.WorldId, out var value))
				{
					return;
				}
				num = 2;
				if (挂机 || 假人)
				{
					return;
				}
				num = 3;
				int num2 = CInfo.ConnId.ToInt32();
				int worldId = CInfo.WorldId;
				string text = ToString() + ":" + CInfo.Port;
				挂机 = false;
				假人 = false;
				m_Running = false;
				num = 4;
				if (m_Buffer != null)
				{
					m_Buffer.Dispose();
					m_Buffer = null;
				}
				num = 5;
				if (自动断开 != null)
				{
					自动断开.Enabled = false;
					自动断开.Close();
					自动断开.Dispose();
					自动断开 = null;
				}
				num = 6;
				if (在线)
				{
					IDout();
					num = 7;
				}
				num = 8;
				if (Player != null)
				{
					num = 9;
					if (!Player.退出中)
					{
						num = 10;
						Player.Logout();
						num = 11;
					}
					num = 12;
					Player.Dispose();
					num = 13;
				}
				num = 14;
				if (World.AllConnectedPlayers.TryGetValue(CInfo.WorldId, out var _))
				{
					num = 15;
					World.AllConnectedPlayers.Remove(CInfo.WorldId);
					num = 16;
				}
				num = 17;
				Player = null;
				World.ConnectionList[CInfo.WorldId] = null;
				delWorldIdd();
				num = 18;
				value = null;
				num = 19;
				MainForm.WriteLine(3, "退出 连接ID[" + num2 + "]人物全服ID[" + worldId + "] IP地址[" + text + "] ExceStep:" + num);
			}
			catch
			{
			}
		}
	}
}
