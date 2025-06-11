namespace RxjhServer
{
	public class 客户端IP地址
	{
		private string string_3;

		public string 外网IP地址
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}

		public 客户端IP地址(string Wip)
		{
			外网IP地址 = Wip;
		}
	}
}
