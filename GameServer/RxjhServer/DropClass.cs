using System;
using System.Collections.Generic;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class DropClass
	{
		public List<DropShuXClass> DropShuX = new List<DropShuXClass>();

		private int _FLD_LEVEL1;

		private int _FLD_LEVEL2;

		private int _FLD_PID;

		private int _FLD_PP;

		public int FLD_PIDNew;

		public int FLD_MAGICNew0;

		public int FLD_MAGICNew1;

		public int FLD_MAGICNew2;

		public int FLD_MAGICNew3;

		public int FLD_MAGICNew4;

		private int _FLD_MAGIC0;

		private int _FLD_MAGIC1;

		private int _FLD_MAGIC2;

		private int _FLD_MAGIC3;

		private int _FLD_MAGIC4;

		private string _FLD_NAME;

		private int _FLD_NJ;

		private int _FLD_初级附魂;

		private int _FLD_中级附魂;

		private int _FLD_进化;

		private int _FLD_绑定;

		public int _是否开启公告;

		public int _会员掉落;

		private int _数量控制;

		private int _当前数量;

		private int _最大数量;

		private int _ID;

		public int NPCPID;

		public int MAPID;

		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		public int 数量控制
		{
			get
			{
				return _数量控制;
			}
			set
			{
				_数量控制 = value;
			}
		}

		public int 当前数量
		{
			get
			{
				return _当前数量;
			}
			set
			{
				_当前数量 = value;
			}
		}

		public int 最大数量
		{
			get
			{
				return _最大数量;
			}
			set
			{
				_最大数量 = value;
			}
		}

		public int 会员掉落
		{
			get
			{
				return _会员掉落;
			}
			set
			{
				_会员掉落 = value;
			}
		}

		public int 是否开启公告
		{
			get
			{
				return _是否开启公告;
			}
			set
			{
				_是否开启公告 = value;
			}
		}

		public int FLD_LEVEL1
		{
			get
			{
				return _FLD_LEVEL1;
			}
			set
			{
				_FLD_LEVEL1 = value;
			}
		}

		public int FLD_LEVEL2
		{
			get
			{
				return _FLD_LEVEL2;
			}
			set
			{
				_FLD_LEVEL2 = value;
			}
		}

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

		public int FLD_PP
		{
			get
			{
				return _FLD_PP;
			}
			set
			{
				_FLD_PP = value;
			}
		}

		public int FLD_MAGIC0
		{
			get
			{
				return _FLD_MAGIC0;
			}
			set
			{
				_FLD_MAGIC0 = value;
			}
		}

		public int FLD_MAGIC1
		{
			get
			{
				return _FLD_MAGIC1;
			}
			set
			{
				_FLD_MAGIC1 = value;
			}
		}

		public int FLD_MAGIC2
		{
			get
			{
				return _FLD_MAGIC2;
			}
			set
			{
				_FLD_MAGIC2 = value;
			}
		}

		public int FLD_MAGIC3
		{
			get
			{
				return _FLD_MAGIC3;
			}
			set
			{
				_FLD_MAGIC3 = value;
			}
		}

		public int FLD_MAGIC4
		{
			get
			{
				return _FLD_MAGIC4;
			}
			set
			{
				_FLD_MAGIC4 = value;
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

		public int FLD_NJ
		{
			get
			{
				return _FLD_NJ;
			}
			set
			{
				_FLD_NJ = value;
			}
		}

		public int FLD_初级附魂
		{
			get
			{
				return _FLD_初级附魂;
			}
			set
			{
				_FLD_初级附魂 = value;
			}
		}

		public int FLD_中级附魂
		{
			get
			{
				return _FLD_中级附魂;
			}
			set
			{
				_FLD_中级附魂 = value;
			}
		}

		public int FLD_进化
		{
			get
			{
				return _FLD_进化;
			}
			set
			{
				_FLD_进化 = value;
			}
		}

		public int FLD_绑定
		{
			get
			{
				return _FLD_绑定;
			}
			set
			{
				_FLD_绑定 = value;
			}
		}

		public static List<DropClass> GetBossDrop(Players play, int leve, int MID, int NID)
		{
			try
			{
				List<DropClass> list = new List<DropClass>();
				List<DropClass> list2 = new List<DropClass>();
				int num = 0;
				Random random = new Random(DateTime.Now.Millisecond);
				foreach (DropClass item in World.BossDrop)
				{
					if ((item.MAPID != 0 && MID != item.MAPID) || (item.NPCPID != 0 && NID != item.NPCPID) || item.FLD_PP == 0 || item.FLD_LEVEL1 > leve || item.FLD_LEVEL2 < leve)
					{
						continue;
					}
					if (item.会员掉落 == 1)
					{
						if (play.FLD_VIP == 1)
						{
							list.Add(item);
							num += item.FLD_PP;
						}
					}
					else
					{
						list.Add(item);
						num += item.FLD_PP;
					}
				}
				if (list.Count == 0)
				{
					return null;
				}
				int num2 = random.Next(World.BOSS掉落物品数量下限, World.BOSS掉落物品数量上限);
				for (int i = 0; i < num2; i++)
				{
					int num3 = 0;
					int num4 = RNG.Next(1, num);
					foreach (DropClass item2 in list)
					{
						num3 += item2.FLD_PP;
						if (num3 >= num4)
						{
							list2.Add(item2);
							break;
						}
					}
				}
				return (list2.Count == 0) ? null : list2;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "BOSS掉落出错leve[" + leve + "]" + ex.Message);
				return null;
			}
		}

		public static List<DropClass> GetGSDrop(Players play, int leve, int MID, int NID)
		{
			try
			{
				List<DropClass> list = new List<DropClass>();
				List<DropClass> list2 = new List<DropClass>();
				Random random = new Random(DateTime.Now.Millisecond);
				int num = RNG.Next(1, 8000);
				foreach (DropClass drop_G in World.Drop_GS)
				{
					if ((drop_G.MAPID != 0 && MID != drop_G.MAPID) || (drop_G.NPCPID != 0 && NID != drop_G.NPCPID) || drop_G.FLD_PP == 0 || drop_G.FLD_LEVEL1 > leve || drop_G.FLD_LEVEL2 < leve || drop_G.FLD_PP < num)
					{
						continue;
					}
					if (drop_G.会员掉落 == 1)
					{
						if (play.FLD_VIP == 1)
						{
							list.Add(drop_G);
						}
					}
					else
					{
						list.Add(drop_G);
					}
				}
				if (list.Count == 0)
				{
					return null;
				}
				int num2 = random.Next(1, 2);
				int num3 = 0;
				foreach (DropClass item in list)
				{
					if (num3 < num2)
					{
						list2.Add(list[RNG.Next(0, list.Count - 1)]);
						num3++;
						continue;
					}
					break;
				}
				return (list2.Count == 0) ? null : list2;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "高手怪掉落出错leve[" + leve + "]" + ex.Message);
				return null;
			}
		}

		public static DropClass GetDrop(Players play, int leve, int MID, int NID)
		{
			try
			{
				List<DropClass> list = new List<DropClass>();
				int num = RNG.Next(1, 8000);
				foreach (DropClass item in World.Drop)
				{
					if ((item.MAPID != 0 && MID != item.MAPID) || (item.NPCPID != 0 && NID != item.NPCPID) || item.FLD_PP == 0 || item.FLD_LEVEL1 > leve || item.FLD_LEVEL2 < leve || item.FLD_PP < num)
					{
						continue;
					}
					if (item.会员掉落 == 1)
					{
						if (play.FLD_VIP == 1)
						{
							list.Add(item);
						}
					}
					else
					{
						list.Add(item);
					}
				}
				DropClass dropClass;
				if (list.Count == 0)
				{
					dropClass = null;
				}
				else
				{
					dropClass = list[RNG.Next(0, list.Count - 1)];
					if (dropClass.数量控制 == 1)
					{
						if (dropClass.当前数量 >= dropClass.最大数量)
						{
							dropClass = null;
						}
						else
						{
							dropClass.当前数量++;
							RxjhClass.保存普通暴率(dropClass);
						}
					}
				}
				return dropClass;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "普通怪掉落出错leve[" + leve + "]" + ex.Message);
				return null;
			}
		}
	}
}
