using Authentication;

namespace Threading
{
	public class ThreadParameter
	{
		private byte[] _databyte;

		private playerS Playes;

		public byte[] Databyte
		{
			get
			{
				return _databyte;
			}
			set
			{
				_databyte = value;
			}
		}

		public playerS players
		{
			get
			{
				return Playes;
			}
			set
			{
				Playes = value;
			}
		}

		public ThreadParameter(byte[] date)
		{
			Databyte = date;
		}

		public ThreadParameter(byte[] date, playerS play)
		{
			Databyte = date;
			players = play;
		}
	}
}
