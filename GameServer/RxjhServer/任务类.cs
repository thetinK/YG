using System;
using System.Collections.Generic;

namespace RxjhServer
{
	public class 任务类
	{
		private string _任务名;

		private 坐标类 _坐标类;

		private List<任务阶段类> _任务阶段;

		private int _任务ID;

		private int _任务等级;

		private int _NpcID;

		private int _任务阶段数量;

		private int _任务正邪;

		private int _职业;

		private int _任务开关;

		private int _任务类型;

		private byte[] _任务_byte;

		private string _NPCNAME;

		private bool _是否账号每日;

		private int _ZJPID;

		private int _WPPID;

		private int _WPSL;

		private bool _是否组队获得;

		public byte[] 任务_byte
		{
			get
			{
				return _任务_byte;
			}
			set
			{
				_任务_byte = value;
			}
		}

		public int 任务ID
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(_任务_byte, 0, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, _任务_byte, 0, 2);
			}
		}

		public int 任务阶段ID
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(_任务_byte, 2, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, _任务_byte, 2, 2);
			}
		}

		public int 任务开关
		{
			get
			{
				return _任务开关;
			}
			set
			{
				_任务开关 = value;
			}
		}

		public int 任务类型
		{
			get
			{
				return _任务类型;
			}
			set
			{
				_任务类型 = value;
			}
		}

		public int RwID
		{
			get
			{
				return _任务ID;
			}
			set
			{
				_任务ID = value;
			}
		}

		public string 任务名
		{
			get
			{
				return _任务名;
			}
			set
			{
				_任务名 = value;
			}
		}

		public int 任务等级
		{
			get
			{
				return _任务等级;
			}
			set
			{
				_任务等级 = value;
			}
		}

		public int 任务正邪
		{
			get
			{
				return _任务正邪;
			}
			set
			{
				_任务正邪 = value;
			}
		}

		public int 职业
		{
			get
			{
				return _职业;
			}
			set
			{
				_职业 = value;
			}
		}

		public 坐标类 Npc坐标
		{
			get
			{
				return _坐标类;
			}
			set
			{
				_坐标类 = value;
			}
		}

		public int NpcID
		{
			get
			{
				return _NpcID;
			}
			set
			{
				_NpcID = value;
			}
		}

		public string NPCNAME
		{
			get
			{
				return _NPCNAME;
			}
			set
			{
				_NPCNAME = value;
			}
		}

		public int 任务阶段数量
		{
			get
			{
				return _任务阶段数量;
			}
			set
			{
				_任务阶段数量 = value;
			}
		}

		public List<任务阶段类> 任务阶段
		{
			get
			{
				return _任务阶段;
			}
			set
			{
				_任务阶段 = value;
			}
		}

		public bool 是否账号每日
		{
			get
			{
				return _是否账号每日;
			}
			set
			{
				_是否账号每日 = value;
			}
		}

		public int ZJPID
		{
			get
			{
				return _ZJPID;
			}
			set
			{
				_ZJPID = value;
			}
		}

		public int WPPID
		{
			get
			{
				return _WPPID;
			}
			set
			{
				_WPPID = value;
			}
		}

		public int WPSL
		{
			get
			{
				return _WPSL;
			}
			set
			{
				_WPSL = value;
			}
		}

		public bool 是否组队获得
		{
			get
			{
				return _是否组队获得;
			}
			set
			{
				_是否组队获得 = value;
			}
		}

		public 任务类(byte[] byte_0)
		{
			_任务名 = string.Empty;
			_坐标类 = new 坐标类();
			_任务阶段 = new List<任务阶段类>();
			任务_byte = byte_0;
		}

		public 任务类()
		{
			_任务名 = string.Empty;
			_坐标类 = new 坐标类();
			_任务阶段 = new List<任务阶段类>();
			任务_byte = new byte[30];
		}

		public static 任务类 GetRW(int int_8)
		{
			foreach (任务类 value in World.任务list.Values)
			{
				if (value.RwID == int_8)
				{
					return value;
				}
			}
			return null;
		}

		public 任务阶段类 GetRWJD(int rwjd)
		{
			try
			{
				foreach (任务阶段类 item in 任务阶段)
				{
					if (item.阶段ID == rwjd)
					{
						return item;
					}
				}
				return null;
			}
			catch
			{
				return null;
			}
		}
	}
}
