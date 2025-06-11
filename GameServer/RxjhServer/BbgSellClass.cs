namespace RxjhServer
{
	public class BbgSellClass
	{
		private int _Pid;

		private int _NJ;

		private int _Price;

		private int _Type;

		private int _retrun;

		private int _number;

		private string _name;

		private int _Magic1;

		private int _Magic2;

		private int _Magic3;

		private int _Magic4;

		private int _Magic5;

		private int _觉醒;

		private int _进化;

		private int _中级附魂;

		private int _绑定;

		private int _使用天数;

		public int FLD_NJ
		{
			get
			{
				return _NJ;
			}
			set
			{
				_NJ = value;
			}
		}

		public int FLD_中级附魂
		{
			get
			{
				return _中级附魂;
			}
			set
			{
				_中级附魂 = value;
			}
		}

		public int FLD_绑定
		{
			get
			{
				return _绑定;
			}
			set
			{
				_绑定 = value;
			}
		}

		public int 使用天数
		{
			get
			{
				return _使用天数;
			}
			set
			{
				_使用天数 = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public int PID
		{
			get
			{
				return _Pid;
			}
			set
			{
				_Pid = value;
			}
		}

		public int Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}

		public int MAGIC1
		{
			get
			{
				return _Magic1;
			}
			set
			{
				_Magic1 = value;
			}
		}

		public int MAGIC2
		{
			get
			{
				return _Magic2;
			}
			set
			{
				_Magic2 = value;
			}
		}

		public int MAGIC3
		{
			get
			{
				return _Magic3;
			}
			set
			{
				_Magic3 = value;
			}
		}

		public int MAGIC5
		{
			get
			{
				return _Magic5;
			}
			set
			{
				_Magic5 = value;
			}
		}

		public int MAGIC4
		{
			get
			{
				return _Magic4;
			}
			set
			{
				_Magic4 = value;
			}
		}

		public int FLD_觉醒
		{
			get
			{
				return _觉醒;
			}
			set
			{
				_觉醒 = value;
			}
		}

		public int FLD_进化
		{
			get
			{
				return _进化;
			}
			set
			{
				_进化 = value;
			}
		}

		public int Price
		{
			get
			{
				return _Price;
			}
			set
			{
				_Price = value;
			}
		}

		public int number
		{
			get
			{
				return _number;
			}
			set
			{
				_number = value;
			}
		}

		public int retrun
		{
			get
			{
				return _retrun;
			}
			set
			{
				_retrun = value;
			}
		}

		public static BbgSellClass 取物品数据(string A_0)
		{
			foreach (BbgSellClass value in World.百宝阁数据.Values)
			{
				if (value.Name == A_0)
				{
					return value;
				}
			}
			return null;
		}

		public static BbgSellClass GetItem(int A_0)
		{
			BbgSellClass value;
			return (!World.百宝阁数据.TryGetValue(A_0, out value)) ? null : value;
		}

		public static string b1(int A_0)
		{
			BbgSellClass value;
			return (!World.百宝阁数据.TryGetValue(A_0, out value)) ? string.Empty : value.Name;
		}
	}
}
