using System.Collections;

namespace RxjhServer
{
	public class ConfigClass
	{
		private int _组队;

		private int _交易;

		private int _传音;

		private int _原著衣服;

		private int _查装备;

		private int _宠物经验;

		private int _武勋开关;

		private int _头发开关;

		private int _告白开关;

		private int _搜索开关;

		private int _蔬菜武器开关;

		private int _荣誉排名效果;

		public int 组队
		{
			get
			{
				return _组队;
			}
			set
			{
				_组队 = value;
			}
		}

		public int 交易
		{
			get
			{
				return _交易;
			}
			set
			{
				_交易 = value;
			}
		}

		public int 传音
		{
			get
			{
				return _传音;
			}
			set
			{
				_传音 = value;
			}
		}

		public int 原著衣服
		{
			get
			{
				return _原著衣服;
			}
			set
			{
				_原著衣服 = value;
			}
		}

		public int 查装备
		{
			get
			{
				return _查装备;
			}
			set
			{
				_查装备 = value;
			}
		}

		public int 宠物经验
		{
			get
			{
				return _宠物经验;
			}
			set
			{
				_宠物经验 = value;
			}
		}

		public int 武勋开关
		{
			get
			{
				return _武勋开关;
			}
			set
			{
				_武勋开关 = value;
			}
		}

		public int 头发开关
		{
			get
			{
				return _头发开关;
			}
			set
			{
				_头发开关 = value;
			}
		}

		public int 告白开关
		{
			get
			{
				return _告白开关;
			}
			set
			{
				_告白开关 = value;
			}
		}

		public int 搜索开关
		{
			get
			{
				return _搜索开关;
			}
			set
			{
				_搜索开关 = value;
			}
		}

		public int 蔬菜武器开关
		{
			get
			{
				return _蔬菜武器开关;
			}
			set
			{
				_蔬菜武器开关 = value;
			}
		}

		public int 荣誉排名效果
		{
			get
			{
				return _荣誉排名效果;
			}
			set
			{
				_荣誉排名效果 = value;
			}
		}

		public static int GetConfig(ConfigClass Config, int MID)
		{
			int Flags = 0;
			if (Config.头发开关 == 1)
			{
				SetFlags(ref Flags, 7, value: true);
			}
			else if (Config.头发开关 == 3)
			{
				SetFlags(ref Flags, 7, value: true);
			}
			switch (MID)
			{
			case 41001:
				SetFlags(ref Flags, 4, value: true);
				break;
			case 801:
				SetFlags(ref Flags, 4, value: true);
				break;
			default:
				if (Config.原著衣服 == 1)
				{
					SetFlags(ref Flags, 4, value: true);
				}
				else if (Config.原著衣服 == 2)
				{
					SetFlags(ref Flags, 6, value: true);
				}
				break;
			}
			return Flags;
		}

		public static void SetFlags(ref int Flags, int ItemFlag, bool value)
		{
			BitArray bitArray = new BitArray(new int[1] { Flags });
			bitArray.Set(ItemFlag, value);
			Flags = 0;
			for (int i = 0; i < bitArray.Length; i++)
			{
				if (bitArray.Get(i))
				{
					Flags |= 1 << i;
				}
			}
		}
	}
}
