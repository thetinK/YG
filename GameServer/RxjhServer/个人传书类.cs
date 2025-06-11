using System;

namespace RxjhServer
{
	public class 个人传书类
	{
		private int _传书ID;

		private string _传书发送人;

		private string _传书内容;

		private DateTime _传书时间;

		private int _是否已读;

		private int _是否NPC;

		public int 传书ID
		{
			get
			{
				return _传书ID;
			}
			set
			{
				_传书ID = value;
			}
		}

		public string 传书发送人
		{
			get
			{
				return _传书发送人;
			}
			set
			{
				_传书发送人 = value;
			}
		}

		public string 传书内容
		{
			get
			{
				return _传书内容;
			}
			set
			{
				_传书内容 = value;
			}
		}

		public DateTime 传书时间
		{
			get
			{
				return _传书时间;
			}
			set
			{
				_传书时间 = value;
			}
		}

		public int 是否已读
		{
			get
			{
				return _是否已读;
			}
			set
			{
				_是否已读 = value;
			}
		}

		public int 是否NPC
		{
			get
			{
				return _是否NPC;
			}
			set
			{
				_是否NPC = value;
			}
		}
	}
}
