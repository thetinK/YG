namespace RxjhServer
{
	public class 阶段需要物品类
	{
		private int _怪物ID;

		private int _物品ID;

		private int _物品总数;

		private int _实际需要数量;

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

		public int 物品总数
		{
			get
			{
				return _物品总数;
			}
			set
			{
				_物品总数 = value;
			}
		}

		public int 实际需要数量
		{
			get
			{
				return _实际需要数量;
			}
			set
			{
				_实际需要数量 = value;
			}
		}
	}
}
