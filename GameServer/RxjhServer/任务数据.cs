namespace RxjhServer
{
	public class 任务数据
	{
		private int _任务ID;

		private int _任务阶段;

		private int _怪物ID;

		private int _任务物品;

		private int _物品爆率;

		private int _需要数量;

		public int 任务ID
		{
			get
			{
				return _任务ID;
			}
			set
			{
				_任务ID = value;
			}
		}

		public int 任务阶段
		{
			get
			{
				return _任务阶段;
			}
			set
			{
				_任务阶段 = value;
			}
		}

		public int 怪物ID
		{
			get
			{
				return _怪物ID;
			}
			set
			{
				_怪物ID = value;
			}
		}

		public int 任务物品
		{
			get
			{
				return _任务物品;
			}
			set
			{
				_任务物品 = value;
			}
		}

		public int 物品爆率
		{
			get
			{
				return _物品爆率;
			}
			set
			{
				_物品爆率 = value;
			}
		}

		public int 需要数量
		{
			get
			{
				return _需要数量;
			}
			set
			{
				_需要数量 = value;
			}
		}
	}
}
