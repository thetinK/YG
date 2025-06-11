namespace RxjhServer
{
	public class 狮子吼Class
	{
		private int m_FLD_INDEX;

		private string m_UserName;

		private int m_TxtId;

		private string m_txt;

		public int Index
		{
			get
			{
				return m_FLD_INDEX;
			}
			set
			{
				m_FLD_INDEX = value;
			}
		}

		public string UserName
		{
			get
			{
				return m_UserName;
			}
			set
			{
				m_UserName = value;
			}
		}

		public int TxtId
		{
			get
			{
				return m_TxtId;
			}
			set
			{
				m_TxtId = value;
			}
		}

		public string Txt
		{
			get
			{
				return m_txt;
			}
			set
			{
				m_txt = value;
			}
		}
	}
}
