namespace RxjhServer
{
	public class 属性
	{
		public double _FLD_加成1;

		public double _FLD_加成2;

		public double FLD_加成1
		{
			get
			{
				return _FLD_加成1;
			}
			set
			{
				_FLD_加成1 = value;
			}
		}

		public double FLD_加成2
		{
			get
			{
				return _FLD_加成2;
			}
			set
			{
				_FLD_加成2 = value;
			}
		}

		public 属性(double 加成1, double 加成2)
		{
			FLD_加成1 = 加成1;
			FLD_加成2 = 加成2;
		}
	}
}
