using System;

namespace RxjhServer
{
	public class 攻击确认类
	{
		private int _人物ID;

		private int _武功ID;

		private bool _攻击状态;

		private int _攻击类型;

		private DateTime _攻击时间;

		private int _攻击间隔;

		public int _攻击者人物ID;

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

		public int 攻击者人物ID
		{
			get
			{
				return _攻击者人物ID;
			}
			set
			{
				_攻击者人物ID = value;
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

		public bool 攻击状态
		{
			get
			{
				return _攻击状态;
			}
			set
			{
				_攻击状态 = value;
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

		public DateTime 攻击时间
		{
			get
			{
				return _攻击时间;
			}
			set
			{
				_攻击时间 = value;
			}
		}

		public int 攻击间隔
		{
			get
			{
				return _攻击间隔;
			}
			set
			{
				_攻击间隔 = value;
			}
		}

		public 攻击确认类()
		{
			攻击者人物ID = 0;
			人物ID = 0;
			武功ID = 0;
			攻击状态 = false;
			攻击类型 = 0;
			攻击间隔 = 0;
			攻击时间 = DateTime.Now;
		}

		public void 初始化(int 攻击者人物ID_, int 人物ID_, int 武功ID_, int 攻击类型_, int 攻击间隔_)
		{
			攻击者人物ID = 攻击者人物ID_;
			人物ID = 人物ID_;
			武功ID = 武功ID_;
			攻击类型 = 攻击类型_;
			攻击间隔 = 攻击间隔_;
			攻击时间 = DateTime.Now;
			攻击状态 = true;
		}
	}
}
