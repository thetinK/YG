namespace RxjhServer
{
	public class NPC传书类
	{
		private int _任务ID;

		private int _任务等级;

		private int _任务NPC;

		private string _任务传书内容;

		private string _NPC名字;

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

		public int 任务等级
		{
			get
			{
				return _任务等级;
			}
			set
			{
				_任务等级 = value;
			}
		}

		public int 任务NPC
		{
			get
			{
				return _任务NPC;
			}
			set
			{
				_任务NPC = value;
			}
		}

		public string NPC名字
		{
			get
			{
				return _NPC名字;
			}
			set
			{
				_NPC名字 = value;
			}
		}

		public string 任务传书内容
		{
			get
			{
				return _任务传书内容;
			}
			set
			{
				_任务传书内容 = value;
			}
		}
	}
}
