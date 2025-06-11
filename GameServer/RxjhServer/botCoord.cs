namespace RxjhServer
{
	public class botCoord
	{
		private string _Name;

		private int _FLD_PID;

		private int _Level;

		private int _Rxjh_HP;

		private double _FLD_AT;

		private double _FLD_DF;

		private int _Rxjh_Exp;

		private int _FLD_AUTO;

		private int _FLD_BOSS;

		private int _FLD_NPC;

		private int _FLD_QUEST;

		private int _FLD_QUESTID;

		private int _FLD_STAGES;

		private int _FLD_QUESTITEM;

		private int _FLD_PP;

		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

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

		public int Level
		{
			get
			{
				return _Level;
			}
			set
			{
				_Level = value;
			}
		}

		public int Rxjh_HP
		{
			get
			{
				return _Rxjh_HP;
			}
			set
			{
				_Rxjh_HP = value;
			}
		}

		public double FLD_AT
		{
			get
			{
				return _FLD_AT;
			}
			set
			{
				_FLD_AT = value;
			}
		}

		public double FLD_DF
		{
			get
			{
				return _FLD_DF;
			}
			set
			{
				_FLD_DF = value;
			}
		}

		public int Rxjh_Exp
		{
			get
			{
				return _Rxjh_Exp;
			}
			set
			{
				_Rxjh_Exp = value;
			}
		}

		public int FLD_AUTO
		{
			get
			{
				return _FLD_AUTO;
			}
			set
			{
				_FLD_AUTO = value;
			}
		}

		public int FLD_BOSS
		{
			get
			{
				return _FLD_BOSS;
			}
			set
			{
				_FLD_BOSS = value;
			}
		}

		public int FLD_NPC
		{
			get
			{
				return _FLD_NPC;
			}
			set
			{
				_FLD_NPC = value;
			}
		}

		public int FLD_QUEST
		{
			get
			{
				return _FLD_QUEST;
			}
			set
			{
				_FLD_QUEST = value;
			}
		}

		public int FLD_QUESTID
		{
			get
			{
				return _FLD_QUESTID;
			}
			set
			{
				_FLD_QUESTID = value;
			}
		}

		public int FLD_STAGES
		{
			get
			{
				return _FLD_STAGES;
			}
			set
			{
				_FLD_STAGES = value;
			}
		}

		public int FLD_QUESTITEM
		{
			get
			{
				return _FLD_QUESTITEM;
			}
			set
			{
				_FLD_QUESTITEM = value;
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

		public static string GetMonSterName(int pid)
		{
			foreach (botCoord value in World.MonSter.Values)
			{
				if (value.FLD_PID == pid)
				{
					return value.Name;
				}
			}
			return "";
		}
	}
}
