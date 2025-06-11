using System.Collections.Generic;

namespace RxjhServer
{
	public class 任务阶段类
	{
		private List<任务需要物品类> 需要物品;

		private List<任务获得物品类> 获得物品;

		private int _阶段ID;

		private int _NpcID;

		public List<任务需要物品类> 任务需要物品
		{
			get
			{
				return 需要物品;
			}
			set
			{
				需要物品 = value;
			}
		}

		public List<任务获得物品类> 任务获得物品
		{
			get
			{
				return 获得物品;
			}
			set
			{
				获得物品 = value;
			}
		}

		public int 阶段ID
		{
			get
			{
				return _阶段ID;
			}
			set
			{
				_阶段ID = value;
			}
		}

		public int NpcID
		{
			get
			{
				return _NpcID;
			}
			set
			{
				_NpcID = value;
			}
		}

		public 任务阶段类()
		{
			需要物品 = new List<任务需要物品类>();
			获得物品 = new List<任务获得物品类>();
		}
	}
}
