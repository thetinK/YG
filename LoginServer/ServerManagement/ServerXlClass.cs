namespace ServerManagement
{
	public class ServerXlClass
	{
		private string _SERVER_NAME;

		private int _ServerId;

		private int _ServerZId;

		private string _SERVER_IP;

		private string _SERVER_PORT;

		public string SERVER_NAME
		{
			get
			{
				return _SERVER_NAME;
			}
			set
			{
				_SERVER_NAME = value;
			}
		}

		public int ServerId
		{
			get
			{
				return _ServerId;
			}
			set
			{
				_ServerId = value;
			}
		}

		public int ServerZId
		{
			get
			{
				return _ServerZId;
			}
			set
			{
				_ServerZId = value;
			}
		}

		public string SERVER_IP
		{
			get
			{
				return _SERVER_IP;
			}
			set
			{
				_SERVER_IP = value;
			}
		}

		public string SERVER_PORT
		{
			get
			{
				return _SERVER_PORT;
			}
			set
			{
				_SERVER_PORT = value;
			}
		}
	}
}
