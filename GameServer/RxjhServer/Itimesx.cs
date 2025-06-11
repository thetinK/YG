using System;

namespace RxjhServer
{
	public class Itimesx
	{
		private int _数量;

		private int _属性类型;

		private int _气功属性类型;

		private int _属性数量;

		public int 数量
		{
			get
			{
				return _数量;
			}
			set
			{
				_数量 = value;
			}
		}

		public int 属性类型
		{
			get
			{
				return _属性类型;
			}
			set
			{
				_属性类型 = value;
			}
		}

		public int 气功属性类型
		{
			get
			{
				return _气功属性类型;
			}
			set
			{
				_气功属性类型 = value;
			}
		}

		public int 属性数量
		{
			get
			{
				return _属性数量;
			}
			set
			{
				_属性数量 = value;
			}
		}

		public Itimesx(byte[] 属性)
		{
			属性阶段(属性);
		}

		public void 属性阶段(byte[] 属性)
		{
			string text = BitConverter.ToInt32(属性, 0).ToString();
			switch (text.Length)
			{
			case 8:
				数量 = 1;
				属性类型 = int.Parse(text.Substring(0, 1));
				if (属性类型 == 8)
				{
					气功属性类型 = int.Parse(text.Substring(4, 2));
				}
				if (World.是否支持扩展物品属性位数 == 0)
				{
					属性数量 = int.Parse(text.Substring(6, 2));
				}
				else
				{
					属性数量 = int.Parse(text) - int.Parse(text.Substring(0, 1)) * 10000000;
				}
				break;
			case 9:
				数量 = 1;
				属性类型 = int.Parse(text.Substring(0, 2));
				if (World.是否支持扩展物品属性位数 == 0)
				{
					属性数量 = int.Parse(text.Substring(7, 2));
				}
				else
				{
					属性数量 = int.Parse(text) - int.Parse(text.Substring(0, 2)) * 10000000;
				}
				break;
			case 10:
				数量 = 1;
				属性类型 = int.Parse(text.Substring(0, 2));
				if (World.是否支持扩展物品属性位数 == 0)
				{
					属性数量 = int.Parse(text.Substring(7, 2));
				}
				else
				{
					属性数量 = int.Parse(text) - int.Parse(text.Substring(0, 3)) * 10000000;
				}
				break;
			}
		}
	}
}
