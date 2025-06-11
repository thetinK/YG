using System;
using System.Collections;
using System.Timers;

namespace RxjhServer
{
	public class 地面物品类 : IDisposable
	{
		private System.Timers.Timer npcyd;

		public ThreadSafeDictionary<int, Players> PlayList;

		public long id;

		private DateTime _time;

		private 物品类 _物品;

		private byte[] _物品_byte;

		private float _Rxjh_X;

		private float _Rxjh_Y;

		private float _Rxjh_Z;

		private int _Rxjh_Map;

		private Players _物品优先权;

		private int _物品来源;

		private int int_1;

		private int int_2;

		public DateTime time
		{
			get
			{
				return _time;
			}
			set
			{
				_time = value;
			}
		}

		public 物品类 物品
		{
			get
			{
				return _物品;
			}
			set
			{
				_物品 = value;
			}
		}

		public byte[] 物品_byte
		{
			get
			{
				return _物品_byte;
			}
			set
			{
				_物品_byte = value;
			}
		}

		public float Rxjh_X
		{
			get
			{
				return _Rxjh_X;
			}
			set
			{
				_Rxjh_X = value;
			}
		}

		public float Rxjh_Y
		{
			get
			{
				return _Rxjh_Y;
			}
			set
			{
				_Rxjh_Y = value;
			}
		}

		public float Rxjh_Z
		{
			get
			{
				return _Rxjh_Z;
			}
			set
			{
				_Rxjh_Z = value;
			}
		}

		public int Rxjh_Map
		{
			get
			{
				return _Rxjh_Map;
			}
			set
			{
				_Rxjh_Map = value;
			}
		}

		public Players 物品优先权
		{
			get
			{
				return _物品优先权;
			}
			set
			{
				_物品优先权 = value;
			}
		}

		public int 物品来源
		{
			get
			{
				return _物品来源;
			}
			set
			{
				_物品来源 = value;
			}
		}

		public int 怪物PID
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		public int 开启公告
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		public void Dispose()
		{
			try
			{
				if (npcyd != null)
				{
					npcyd.Enabled = false;
					npcyd.Close();
					npcyd.Dispose();
					npcyd = null;
				}
				if (PlayList != null)
				{
					PlayList.Clear();
					PlayList.Dispose();
				}
				PlayList = null;
				物品 = null;
				物品优先权 = null;
			}
			catch (Exception)
			{
			}
		}

		public 地面物品类(byte[] 物品_byte_, float x, float y, float z, int map, Players name, int 物品来源)
		{
			PlayList = new ThreadSafeDictionary<int, Players>();
			物品优先权 = name;
			time = DateTime.Now;
			物品 = new 物品类(物品_byte_);
			物品_byte = 物品_byte_;
			id = BitConverter.ToInt64(物品.得到全局ID(), 0);
			Rxjh_X = x;
			Rxjh_Y = y;
			Rxjh_Z = z;
			Rxjh_Map = map;
			this.物品来源 = 物品来源;
			npcyd = new System.Timers.Timer(10000.0);
			npcyd.Elapsed += npcydtheout2;
			npcyd.Enabled = true;
			npcyd.AutoReset = false;
		}

		public 地面物品类(byte[] 物品_byte_, float x, float y, float z, int map, Players name, int 物品来源, int 怪物PID, int 是否开启公告)
		{
			PlayList = new ThreadSafeDictionary<int, Players>();
			物品优先权 = name;
			time = DateTime.Now;
			物品 = new 物品类(物品_byte_);
			物品_byte = 物品_byte_;
			id = BitConverter.ToInt64(物品.得到全局ID(), 0);
			Rxjh_X = x;
			Rxjh_Y = y;
			Rxjh_Z = z;
			Rxjh_Map = map;
			this.物品来源 = 物品来源;
			this.怪物PID = 怪物PID;
			开启公告 = 是否开启公告;
			npcyd = new System.Timers.Timer(10000.0);
			npcyd.Elapsed += npcydtheout2;
			npcyd.Enabled = true;
			npcyd.AutoReset = false;
		}

		public void npcydtheout()
		{
			try
			{
				if (npcyd != null)
				{
					npcyd.Enabled = false;
					npcyd.Close();
					npcyd.Dispose();
					npcyd = null;
				}
				World.ItemTemp.Remove(id);
				获取范围玩家发送地面消失物品数据包();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "物品消失 出错npcydtheout ：" + BitConverter.ToInt32(物品.得到全局ID(), 0) + " [" + 物品.得到物品名称() + "]" + ex);
			}
			finally
			{
				World.ItemTemp.Remove(id);
				Dispose();
			}
		}

		public void npcydtheout2(object source, ElapsedEventArgs e)
		{
			try
			{
				if (npcyd != null)
				{
					npcyd.Enabled = false;
					npcyd.Close();
					npcyd.Dispose();
					npcyd = null;
				}
				World.ItemTemp.Remove(id);
				获取范围玩家发送地面消失物品数据包();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "物品消失 出错npcydtheout2 ：" + BitConverter.ToInt64(物品.得到全局ID(), 0) + " [" + 物品.得到物品名称() + "]" + ex);
			}
			finally
			{
				World.ItemTemp.Remove(id);
				Dispose();
			}
		}

		public void 获取范围玩家发送地面消失物品数据包()
		{
			try
			{
				if (PlayList == null)
				{
					return;
				}
				try
				{
					Queue queue = Queue.Synchronized(new Queue());
					foreach (Players value in PlayList.Values)
					{
						queue.Enqueue(value);
					}
					while (queue.Count > 0)
					{
						if (World.JlMsg == 1)
						{
							MainForm.WriteLine(0, "获取范围玩家发送地面消失物品数据包");
						}
						((Players)queue.Dequeue()).获取复查范围地面物品();
					}
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "获取范围玩家发送地面消失物品数据包1 出错：" + ex);
				}
				if (PlayList != null)
				{
					PlayList.Clear();
				}
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "获取范围玩家发送地面消失物品数据包3 出错：" + ex2);
			}
		}

		public void 获取范围玩家发送地面增加物品数据包()
		{
			try
			{
				Queue queue = Queue.Synchronized(new Queue());
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (查找范围玩家(400, value))
					{
						queue.Enqueue(value);
					}
				}
				while (queue.Count > 0)
				{
					if (World.JlMsg == 1)
					{
						MainForm.WriteLine(0, "获取范围玩家发送地面增加物品数据包");
					}
					((Players)queue.Dequeue()).获取复查范围地面物品();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "获取范围玩家发送地面增加物品数据包 出错：" + ex);
			}
		}

		public bool 查找范围玩家(int far_, Players Playe)
		{
			if (Playe.人物坐标_地图 != Rxjh_Map)
			{
				return false;
			}
			float num = Playe.人物坐标_X - Rxjh_X;
			float num2 = Playe.人物坐标_Y - Rxjh_Y;
			return (double)(int)Math.Sqrt((double)num * (double)num + (double)num2 * (double)num2) <= (double)far_;
		}

		public static 地面物品类 GetItme(long id)
		{
			地面物品类 value;
			return (!World.ItemTemp.TryGetValue(id, out value)) ? null : value;
		}
	}
}
