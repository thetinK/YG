namespace RxjhServer
{
	public class 任务需要物品类
	{
		private int _物品ID;

		private int _物品数量;

		private int _NPCPID;

		private int _难度;

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

		public int NPCPID
		{
			get
			{
				return _NPCPID;
			}
			set
			{
				_NPCPID = value;
			}
		}

		public int 难度
		{
			get
			{
				return _难度;
			}
			set
			{
				_难度 = value;
			}
		}
	}
}
