namespace RxjhServer
{
	public class 任务获得物品类
	{
		private int _物品ID;

		private int _物品数量;

		private int _是否绑定;

		private int _奖励类型;

		private int _时间;

		public int 物品ID
		{
			get
			{
				return _物品ID;
			}
			set
			{
				_物品ID = value;
			}
		}

		public int 物品数量
		{
			get
			{
				return _物品数量;
			}
			set
			{
				_物品数量 = value;
			}
		}

		public int 是否绑定
		{
			get
			{
				return _是否绑定;
			}
			set
			{
				_是否绑定 = value;
			}
		}

		public int 奖励类型
		{
			get
			{
				return _奖励类型;
			}
			set
			{
				_奖励类型 = value;
			}
		}

		public int 时间
		{
			get
			{
				return _时间;
			}
			set
			{
				_时间 = value;
			}
		}
	}
}
