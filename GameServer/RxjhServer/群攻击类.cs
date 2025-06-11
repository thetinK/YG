namespace RxjhServer
{
	public class 群攻击类
	{
		public int 剩余血量;

		private int _人物ID;

		private int _武功ID;

		private int _攻击力;

		private int _攻击类型;

		private int _总血量;

		public int 人物ID
		{
			get
			{
				return _人物ID;
			}
			set
			{
				_人物ID = value;
			}
		}

		public int 武功ID
		{
			get
			{
				return _武功ID;
			}
			set
			{
				_武功ID = value;
			}
		}

		public int 攻击力
		{
			get
			{
				return _攻击力;
			}
			set
			{
				_攻击力 = value;
			}
		}

		public int 攻击类型
		{
			get
			{
				return _攻击类型;
			}
			set
			{
				_攻击类型 = value;
			}
		}

		public int 总血量
		{
			get
			{
				return _总血量;
			}
			set
			{
				_总血量 = value;
			}
		}

		public 群攻击类(int 人物ID_, int 武功ID_, int 攻击力_, int 攻击类型_)
		{
			人物ID = 人物ID_;
			武功ID = 武功ID_;
			攻击力 = 攻击力_;
			攻击类型 = 攻击类型_;
		}
	}
}
