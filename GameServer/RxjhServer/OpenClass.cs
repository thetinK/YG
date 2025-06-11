using System.Collections;

namespace RxjhServer
{
	public class OpenClass
	{
		private int _FLD_PID;

		private string _FLD_NAME;

		private int _FLD_PIDX;

		private string _FLD_NAMEX;

		private int _FLD_NUMBER;

		private int _FLD_PP;

		private int _FLD_MAGIC1;

		private int _FLD_MAGIC2;

		private int _FLD_MAGIC3;

		private int _FLD_MAGIC4;

		private int _FLD_MAGIC5;

		private int _FLD_觉醒;

		private int _FLD_进化;

		private int _FLD_中级附魂;

		private int _FLD_BD;

		private int _FLD_DAYS;

		public int _是否开启公告;

		public int FLD_PID
		{
			get
			{
				return _FLD_PID;
			}
			set
			{
				_FLD_PID = value;
			}
		}

		public string FLD_NAME
		{
			get
			{
				return _FLD_NAME;
			}
			set
			{
				_FLD_NAME = value;
			}
		}

		public int FLD_PIDX
		{
			get
			{
				return _FLD_PIDX;
			}
			set
			{
				_FLD_PIDX = value;
			}
		}

		public string FLD_NAMEX
		{
			get
			{
				return _FLD_NAMEX;
			}
			set
			{
				_FLD_NAMEX = value;
			}
		}

		public int FLD_NUMBER
		{
			get
			{
				return _FLD_NUMBER;
			}
			set
			{
				_FLD_NUMBER = value;
			}
		}

		public int FLD_PP
		{
			get
			{
				return _FLD_PP;
			}
			set
			{
				_FLD_PP = value;
			}
		}

		public int FLD_MAGIC1
		{
			get
			{
				return _FLD_MAGIC1;
			}
			set
			{
				_FLD_MAGIC1 = value;
			}
		}

		public int FLD_MAGIC2
		{
			get
			{
				return _FLD_MAGIC2;
			}
			set
			{
				_FLD_MAGIC2 = value;
			}
		}

		public int FLD_MAGIC3
		{
			get
			{
				return _FLD_MAGIC3;
			}
			set
			{
				_FLD_MAGIC3 = value;
			}
		}

		public int FLD_MAGIC4
		{
			get
			{
				return _FLD_MAGIC4;
			}
			set
			{
				_FLD_MAGIC4 = value;
			}
		}

		public int FLD_MAGIC5
		{
			get
			{
				return _FLD_MAGIC5;
			}
			set
			{
				_FLD_MAGIC5 = value;
			}
		}

		public int FLD_觉醒
		{
			get
			{
				return _FLD_觉醒;
			}
			set
			{
				_FLD_觉醒 = value;
			}
		}

		public int FLD_进化
		{
			get
			{
				return _FLD_进化;
			}
			set
			{
				_FLD_进化 = value;
			}
		}

		public int FLD_中级附魂
		{
			get
			{
				return _FLD_中级附魂;
			}
			set
			{
				_FLD_中级附魂 = value;
			}
		}

		public int FLD_BD
		{
			get
			{
				return _FLD_BD;
			}
			set
			{
				_FLD_BD = value;
			}
		}

		public int FLD_DAYS
		{
			get
			{
				return _FLD_DAYS;
			}
			set
			{
				_FLD_DAYS = value;
			}
		}

		public int 是否开启公告
		{
			get
			{
				return _是否开启公告;
			}
			set
			{
				_是否开启公告 = value;
			}
		}

		public static OpenClass 钥匙GetOpen(int Pid)
		{
			ArrayList arrayList = new ArrayList();
			int num = RNG.Next(1, 1300);
			foreach (OpenClass item in World.Open)
			{
				if (item.FLD_PID == Pid && item.FLD_PP >= num)
				{
					arrayList.Add(item);
				}
			}
			if (arrayList.Count == 0)
			{
				return null;
			}
			return (OpenClass)arrayList[RNG.Next(0, arrayList.Count - 1)];
		}

		public static OpenClass 锤子GetOpen(int Pid)
		{
			ArrayList arrayList = new ArrayList();
			int num = RNG.Next(120, 2600);
			foreach (OpenClass item in World.Open)
			{
				if (item.FLD_PID == Pid && item.FLD_PP >= num)
				{
					arrayList.Add(item);
				}
			}
			if (arrayList.Count == 0)
			{
				return null;
			}
			return (OpenClass)arrayList[RNG.Next(0, arrayList.Count - 1)];
		}

		public static OpenClass GetOpen(int Pid, int job, int ZX)
		{
			ArrayList arrayList = new ArrayList();
			if (Pid == 1000000071)
			{
				foreach (ItmeClass value in World.Itme.Values)
				{
					if ((value.FLD_RESIDE2 == 19 || value.FLD_RESIDE2 == 1792) && (value.FLD_RESIDE1 == job || value.FLD_RESIDE1 == 0) && (value.FLD_ZX == 0 || value.FLD_ZX == ZX) && value.FLD_LEVEL != 100 && value.FLD_LEVEL != 104 && value.FLD_LEVEL != 108 && value.FLD_PID != 1000000200 && value.FLD_PID != 1000000213)
					{
						arrayList.Add(new OpenClass
						{
							FLD_PID = 1000000071,
							FLD_PIDX = value.FLD_PID,
							FLD_NAME = "上古宝箱",
							FLD_NAMEX = value.ItmeNAME
						});
					}
				}
			}
			else
			{
				int num = RNG.Next(1, 500);
				foreach (OpenClass item in World.Open)
				{
					if (item.FLD_PID == Pid && item.FLD_PP >= num)
					{
						arrayList.Add(item);
					}
				}
				if (arrayList.Count == 0)
				{
					return null;
				}
			}
			return (OpenClass)arrayList[RNG.Next(0, arrayList.Count - 1)];
		}
	}
}
