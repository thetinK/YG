using Network.Clients;

namespace ServerManagement
{
	public class SevConnClass
	{
		private SockClient _Server;

		private string userid;

		private string _UserIp;

		private string _ServerID;

		private string _WorldID;

		private string _绑定帐号;

		private string _离线挂机;

		public SockClient Server
		{
			get
			{
				return _Server;
			}
			set
			{
				_Server = value;
			}
		}

		public string UserId
		{
			get
			{
				return userid;
			}
			set
			{
				userid = value;
			}
		}

		public string UserIp
		{
			get
			{
				return _UserIp;
			}
			set
			{
				_UserIp = value;
			}
		}

		public string ServerID
		{
			get
			{
				return _ServerID;
			}
			set
			{
				_ServerID = value;
			}
		}

		public string WorldID
		{
			get
			{
				return _WorldID;
			}
			set
			{
				_WorldID = value;
			}
		}

		public string BoundAccount
		{
			get
			{
				return _绑定帐号;
			}
			set
			{
				_绑定帐号 = value;
			}
		}

		public string OfflineAutoFarm
		{
			get
			{
				return _离线挂机;
			}
			set
			{
				_离线挂机 = value;
			}
		}
	}
}
