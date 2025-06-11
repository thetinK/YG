namespace RxjhServer
{
	public class 门派排名
	{
		private int _门派正邪;

		private int _门派职业;

		private int _门派荣誉点;

		private int _门派转职;

		private int _门派人物等级;

		private int _门派等级;

		private string _门派人物名;

		private string _门派分区ID;

		private string _门派帮派名;

		public string 门派帮派名
		{
			get
			{
				return _门派帮派名;
			}
			set
			{
				_门派帮派名 = value;
			}
		}

		public int 门派等级
		{
			get
			{
				return _门派等级;
			}
			set
			{
				_门派等级 = value;
			}
		}

		public string 门派分区ID
		{
			get
			{
				return _门派分区ID;
			}
			set
			{
				_门派分区ID = value;
			}
		}

		public int 门派人物等级
		{
			get
			{
				return _门派人物等级;
			}
			set
			{
				_门派人物等级 = value;
			}
		}

		public string 门派人物名
		{
			get
			{
				return _门派人物名;
			}
			set
			{
				_门派人物名 = value;
			}
		}

		public int 门派荣誉点
		{
			get
			{
				return _门派荣誉点;
			}
			set
			{
				_门派荣誉点 = value;
			}
		}

		public int 门派正邪
		{
			get
			{
				return _门派正邪;
			}
			set
			{
				_门派正邪 = value;
			}
		}

		public int 门派职业
		{
			get
			{
				return _门派职业;
			}
			set
			{
				_门派职业 = value;
			}
		}

		public int 门派转职
		{
			get
			{
				return _门派转职;
			}
			set
			{
				_门派转职 = value;
			}
		}
	}
}
