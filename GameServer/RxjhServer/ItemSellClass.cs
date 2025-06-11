namespace RxjhServer
{
	public class ItemSellClass
	{
		private int _ID;

		private int _NJ;

		private int _Reside;

		private int _Type;

		private int _Magic0;

		private int _Magic1;

		private int _Magic2;

		private int _Magic3;

		private int _Magic4;

		private int _Magic5;

		private int _觉醒;

		private int _进化;

		private string _name;

		private int _中级附魂;

		private string _sql;

		private int _DAYS;

		private int _BD;

		public int 中级附魂
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

		public string name
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

		public string sql
		{
			get
			{
				return _sql;
			}
			set
			{
				_sql = value;
			}
		}

		public int NJ
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

		public int DAYS
		{
			get
			{
				return _DAYS;
			}
			set
			{
				_DAYS = value;
			}
		}

		public int BD
		{
			get
			{
				return _BD;
			}
			set
			{
				_BD = value;
			}
		}

		public int Magic0
		{
			get
			{
				return _Magic0;
			}
			set
			{
				_Magic0 = value;
			}
		}

		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		public int Magic4
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

		public int Magic1
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

		public int Magic2
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

		public int Magic5
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

		public int Magic3
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

		public int 觉醒
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

		public int 进化
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

		public int Reside
		{
			get
			{
				return _Reside;
			}
			set
			{
				_Reside = value;
			}
		}

		public static ItemSellClass 取物品数据(int type, int reside)
		{
			foreach (ItemSellClass item in World.套装数据)
			{
				if (item.Type == type && item.Reside == reside)
				{
					return item;
				}
			}
			return null;
		}
	}
}
