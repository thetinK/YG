using Authentication;
using Core;
using ServerManagement;
using System;
using System.Net;
using System.Text;
using Threading.Locking;
using UI;

namespace Network.TCP
{
	public class NetState
	{
		public DateTime LastLoginTime = DateTime.Now;

		public byte[] g_cur_key = new byte[32]
		{
			201, 55, 147, 8, 162, 107, 81, 151, 165, 41,
			136, 17, 184, 111, 78, 144, 233, 247, 211, 225,
			191, 92, 209, 199, 217, 63, 156, 129, 226, 111,
			89, 152
		};

		private IPAddress m_Address;

		public int WorldId;

		public int packconn;

		public Player Player;

		private ClientInfo CI;

		private bool IsRunning;

		private string IsToString;

		public bool Running => IsRunning;

		public override string ToString()
		{
			return IsToString;
		}

		public void addWorldIdd(int worldid)
		{
			try
			{
				if (!World.ConnectLst.TryGetValue(worldid, out var _))
				{
					World.ConnectLst.Add(worldid, this);
				}
			}
			catch
			{
			}
		}

		public void delWorldIdd()
		{
			try
			{
				World.ConnectLst.Remove(WorldId);
			}
			catch
			{
			}
		}

		private static long IpToInt(string ip)
		{
			char[] separator = new char[1] { '.' };
			string[] array = ip.Split(separator);
			return long.Parse(array[0]) << 24 | long.Parse(array[1]) << 16 | long.Parse(array[2]) << 8 | long.Parse(array[3]);
		}

		public NetState(ClientInfo ClientInfo)
		{
			ClientInfo.Client = this;
			CI = ClientInfo;
			LastLoginTime = DateTime.Now;
			IsRunning = false;
			try
			{
				m_Address = new IPAddress((uint)IPAddress.HostToNetworkOrder((int)IpToInt(ClientInfo.IpAddress)));
				IsToString = ClientInfo.IpAddress;
			}
			catch
			{
				m_Address = IPAddress.None;
				IsToString = "(error)";
			}
			WorldId = ClientInfo.WorldId;
			Player = new Player(this);
			using (new Lock(World.ConnectLst, "listLock"))
			{
				if (!InList(ClientInfo.WorldId))
				{
					World.ConnectLst.Add(ClientInfo.WorldId, this);
				}
				else
				{
					Dispose();
				}
			}
		}

		private bool InList(int key)
		{
			NetState value;
			return World.ConnectLst.TryGetValue(key, out value);
		}

		public void Start()
		{
			IsRunning = true;
		}

        public void Send(string message)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                Send(bytes, bytes.Length);
            }
            catch (Exception ex)
            {            
                Console.WriteLine($"Send error: {ex.Message}");
            }
        }

        public unsafe void Send(byte[] toSendBuff, int len)
		{
			try
			{
				fixed (byte* ptr = toSendBuff)
				{
					CI.Server.Send(CI.ConnId, (IntPtr)ptr, toSendBuff.Length);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "Send()_Exception Error" + WorldId + "|" + ToString() + "  " + ex.Message);
				Dispose();
			}
		}

		public void ProcessDataReceived(byte[] data, int length)
		{
			try
			{
				packconn++;
				if (packconn > 1000000)
				{
					packconn = 0;
				}
				byte[] dst = new byte[4];
				Buffer.BlockCopy(data, 0, dst, 0, 2);
				int num = BitConverter.ToInt32(dst, 0);
				int num2 = num;
				if (num2 <= 32778)
				{
					if (num2 == 32768 || num2 == 32778)
					{
						goto IL_0074;
					}
				}
				else if (num2 == 32780 || num2 == 32790)
				{
					goto IL_0074;
				}
				Player.ManagePacket(data, length);
				goto IL_0074;
				IL_0074:
				Player.ManagePacket(data, length);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "ProcessDataReceived() Error" + WorldId + "|" + ToString() + "  " + ex.Message);
				Dispose();
			}
		}

		public void Dispose()
		{
			try
			{
				if (!World.m_Disposed.Contains(this))
				{
					CI.Server.Disconnect(CI.ConnId);
					World.m_Disposed.Enqueue(this);
					m_Address = null;
					IsRunning = false;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "  Dispose(bool  flush) Error" + WorldId + "|" + ToString() + "  " + ex.Message);
			}
		}
	}
}
