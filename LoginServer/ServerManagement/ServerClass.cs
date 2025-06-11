using System.Collections.Generic;

namespace ServerManagement
{
	public class ServerClass
	{
		public List<ServerXlClass> ServerList = new List<ServerXlClass>();

		private int _ServerCount;

		private string _SERVER_NAME;

		public int ServerCount
		{
			get
			{
				return _ServerCount;
			}
			set
			{
				_ServerCount = value;
			}
		}

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
	}
}
