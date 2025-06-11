namespace RxjhServer
{
	public class 离线队员
	{
		private int _组队id;

		private string _UserName;

		public int 组队id
		{
			get
			{
				return _组队id;
			}
			set
			{
				_组队id = value;
			}
		}

		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				_UserName = value;
			}
		}
	}
}
