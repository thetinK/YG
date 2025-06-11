namespace RxjhServer
{
	public class 气功加成属性
	{
		private int _FLD_PID;

		private int _FLD_INDEX;

		private int _FLD_JOB;

		private double _FLD_每点加成比率值1;

		private double _FLD_每点加成比率值2;

		private string _FLD_NAME;

		public int FLD_PID
		{
			get
			{
				return _FLD_PID;
			}
			set
			{
				_FLD_PID = value;
			}
		}

		public int FLD_INDEX
		{
			get
			{
				return _FLD_INDEX;
			}
			set
			{
				_FLD_INDEX = value;
			}
		}

		public int FLD_JOB
		{
			get
			{
				return _FLD_JOB;
			}
			set
			{
				_FLD_JOB = value;
			}
		}

		public string FLD_NAME
		{
			get
			{
				return _FLD_NAME;
			}
			set
			{
				_FLD_NAME = value;
			}
		}

		public double FLD_每点加成比率值1
		{
			get
			{
				return _FLD_每点加成比率值1;
			}
			set
			{
				_FLD_每点加成比率值1 = value;
			}
		}

		public double FLD_每点加成比率值2
		{
			get
			{
				return _FLD_每点加成比率值2;
			}
			set
			{
				_FLD_每点加成比率值2 = value;
			}
		}
	}
}
