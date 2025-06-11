namespace RxjhServer
{
	public class ServerList
	{
		private string _服务器IP;

		private int _服务器端口;

		private int _服务器ID;

		public string 服务器IP
		{
			get
			{
				return _服务器IP;
			}
			set
			{
				_服务器IP = value;
			}
		}

		public int 服务器端口
		{
			get
			{
				return _服务器端口;
			}
			set
			{
				_服务器端口 = value;
			}
		}

		public int 服务器ID
		{
			get
			{
				return _服务器ID;
			}
			set
			{
				_服务器ID = value;
			}
		}
	}
}
