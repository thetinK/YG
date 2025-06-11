using System;

namespace Security.MultiBoxing
{
	public class RunMoreClass
	{
		private string _PID;

		private int _Number;

		private DateTime _time;

		public string PID
		{
			get
			{
				return _PID;
			}
			set
			{
				_PID = value;
			}
		}

		public int Number
		{
			get
			{
				return _Number;
			}
			set
			{
				_Number = value;
			}
		}

		public DateTime Time
		{
			get
			{
				return _time;
			}
			set
			{
				_time = value;
			}
		}
	}
}
