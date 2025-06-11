namespace RxjhServer
{
	public class AnnouncementClass
	{
		private int _type;

		private string _msg;

		public int type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		public string msg
		{
			get
			{
				return _msg;
			}
			set
			{
				_msg = value;
			}
		}
	}
}
