namespace RxjhServer
{
	public class 等级奖励类
	{
		private int _等级;

		private int _武勋;

		private int _元宝;

		private string _金钱;

		private int _套装;

		private string _单件物品;

		public int 等级
		{
			get
			{
				return _等级;
			}
			set
			{
				_等级 = value;
			}
		}

		public int 武勋
		{
			get
			{
				return _武勋;
			}
			set
			{
				_武勋 = value;
			}
		}

		public int 元宝
		{
			get
			{
				return _元宝;
			}
			set
			{
				_元宝 = value;
			}
		}

		public string 金钱
		{
			get
			{
				return _金钱;
			}
			set
			{
				_金钱 = value;
			}
		}

		public int 套装
		{
			get
			{
				return _套装;
			}
			set
			{
				_套装 = value;
			}
		}

		public string 单件物品
		{
			get
			{
				return _单件物品;
			}
			set
			{
				_单件物品 = value;
			}
		}
	}
}
