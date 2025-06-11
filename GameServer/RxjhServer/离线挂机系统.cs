using System;
using System.Collections.Generic;
using RxjhServer.HelperTools;

namespace RxjhServer
{
	public class 离线挂机系统
	{
		public static void 离线挂机(Players player)
		{
			try
			{
				if ((int)DateTime.Now.Subtract(player.自动存仓库时间).TotalMilliseconds >= World.自动存取时间)
				{
					if (player.是否假人 != 0)
					{
						内挂出售(player);
					}
					player.自动存仓库时间 = DateTime.Now;
					return;
				}
				if ((int)DateTime.Now.Subtract(player.离线挂机打怪时间).TotalMilliseconds >= World.打怪说话时间)
				{
					string 自动说话 = player.自动说话;
					int msgType = 0;
					string userName = player.UserName;
					if (自动说话 != string.Empty)
					{
						player.发送消息(自动说话, msgType, userName);
					}
					else
					{
						自动说话 = World.离线挂机提示内容;
						player.发送消息(自动说话, msgType, userName);
					}
					player.离线挂机打怪时间 = DateTime.Now;
				}
				if (player.人物_HP <= (int)((double)player.人物最大_HP * 0.95))
				{
					int sl = player.人物最大_HP - player.人物_HP;
					player.加血(sl);
					player.吃药效果(1000000102);
					player.更新HP_MP_SP();
				}
				if (player.人物_MP <= (int)((double)player.人物最大_MP * 0.95))
				{
					player.加魔(20000);
					player.吃药效果(1000000104);
					player.更新HP_MP_SP();
				}
				long num = 获取自动拾取物品(player);
				if (num != 0L && World.ItemTemp.ContainsKey(num))
				{
					int num2 = player.得到包裹空位(player);
					if (player.离线挂机打怪模式 != 0 || num2 == -1)
					{
						离线拾取物品包(player, num);
					}
				}
				float num3 = player.人物坐标_X - (float)player.自动挂机坐标X;
				float num4 = player.人物坐标_Y - (float)player.自动挂机坐标Y;
				double num5 = (int)Math.Sqrt((double)num3 * (double)num3 + (double)num4 * (double)num4);
				if ((int)num5 > World.离线挂机打怪范围)
				{
					player.离线挂机当前攻击怪物 = 0;
					离线移动包(player, player.自动挂机坐标X, player.自动挂机坐标Y, (float)num5);
					return;
				}
				if ((long)player.人物_HP <= 0L || player.Player死亡)
				{
					player.移动(player.自动挂机坐标X, player.自动挂机坐标Y, player.人物坐标_Z, player.自动挂机地图);
					player.人物_HP = player.人物最大_HP;
					player.更新HP_MP_SP();
					player.Player死亡 = false;
					return;
				}
				if (player.离线挂机打怪模式 == 1)
				{
					自动吃药(player);
					假人转职(player);
					假人移动(player);
					自动加气动点(player);
				}
				if (player.组队id != 0 && player.Player_Job == 5)
				{
					int 武功ID = 501203;
					if (player.Player_Job_leve >= 6)
					{
						if (!player.追加状态列表.ContainsKey(501501))
						{
							武功ID = 501501;
						}
						else if (!player.追加状态列表.ContainsKey(501502))
						{
							武功ID = 501502;
						}
						else if (!player.追加状态列表.ContainsKey(501601))
						{
							武功ID = 501601;
						}
						else if (!player.追加状态列表.ContainsKey(501602))
						{
							武功ID = 501602;
						}
						else if (!player.追加状态列表.ContainsKey(501603))
						{
							武功ID = 501603;
						}
					}
					else if (!player.追加状态列表.ContainsKey(501301))
					{
						武功ID = 501301;
					}
					else if (!player.追加状态列表.ContainsKey(501303))
					{
						武功ID = 501303;
					}
					else if (!player.追加状态列表.ContainsKey(501401))
					{
						武功ID = 501401;
					}
					else if (!player.追加状态列表.ContainsKey(501402))
					{
						武功ID = 501402;
					}
					else if (!player.追加状态列表.ContainsKey(501403))
					{
						武功ID = 501403;
					}
					player.魔法攻击(武功ID, player.人物全服ID);
					return;
				}
				if (player.组队id != 0 && player.Player_Job == 4 && !player.追加状态列表.ContainsKey(401303))
				{
					int 武功ID2 = 401303;
					if (!player.追加状态列表.ContainsKey(401202))
					{
						武功ID2 = 401202;
					}
					else if (!player.追加状态列表.ContainsKey(401203))
					{
						武功ID2 = 401203;
					}
					else if (!player.追加状态列表.ContainsKey(401301))
					{
						武功ID2 = 401301;
					}
					else if (!player.追加状态列表.ContainsKey(401302))
					{
						武功ID2 = 401302;
					}
					player.魔法攻击(武功ID2, player.人物全服ID);
					return;
				}
				player.离线挂机当前攻击怪物 = 获取自动攻击NPC目标(player, player.自动挂机坐标X, player.自动挂机坐标Y);
				if (player.离线挂机当前攻击怪物 > 10000)
				{
					NpcClass npc = MapClass.GetNpc(player.人物坐标_地图, player.离线挂机当前攻击怪物);
					if (npc != null && !npc.NPC死亡 && npc.Rxjh_HP > 0)
					{
						float num6 = player.人物坐标_X - npc.X;
						float num7 = player.人物坐标_Y - npc.Y;
						double num8 = (int)Math.Sqrt((double)num6 * (double)num6 + (double)num7 * (double)num7);
						if ((int)num8 <= 30)
						{
							离线攻击包(player);
						}
						else
						{
							离线移动包(player, npc.X, npc.Y, (float)num8);
						}
					}
				}
				else
				{
					离线攻击包(player);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "离线自动打怪出错:" + ex.Message);
			}
		}

		public static void 离线拾取物品包(Players player, long dmwpid)
		{
			string hex = "AA5517002C010B000800C676600000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			Buffer.BlockCopy(BitConverter.GetBytes(dmwpid), 0, array, 10, 8);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
			player.捡物品(array, array.Length);
		}

		public static void 离线攻击包(Players player)
		{
			byte[] array = Converter.hexStringToByte("AA551E002E01090018005828B3C300000000AE705F4300007041B82D35440100000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(player.离线挂机当前攻击怪物), 0, array, 10, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(player.离线挂机武功ID), 0, array, 14, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_X), 0, array, 18, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_Z), 0, array, 22, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_Y), 0, array, 26, 4);
			player.攻击(array, array.Length);
		}

		private static void 自动吃药(Players player)
		{
			if (player.得到包裹物品位置(1008000533) != -1)
			{
				自动吃药(player, 1008000533);
			}
			if (player.得到包裹物品位置(1008000524) != -1)
			{
				自动吃药(player, 1008000524);
				自动带装备(player);
			}
			if (player.得到包裹物品位置(1008000522) != -1)
			{
				自动吃药(player, 1008000522);
			}
			if (player.得到包裹物品位置(1008000517) != -1)
			{
				自动吃药(player, 1008000517);
				自动带装备(player);
			}
			if (player.得到包裹物品位置(1008000518) != -1)
			{
				自动吃药(player, 1008000518);
				自动带装备(player);
			}
			if (player.得到包裹物品位置(1008000535) != -1)
			{
				自动吃药(player, 1008000535);
				自动带装备(player);
			}
			if (player.得到包裹物品位置(1008000521) != -1)
			{
				自动吃药(player, 1008000521);
				自动带装备(player);
			}
			if (player.得到包裹物品位置(1008000534) != -1)
			{
				自动吃药(player, 1008000534);
				自动带装备(player);
			}
			if (player.得到包裹物品位置(1008000515) != -1)
			{
				自动吃药(player, 1008000515);
				自动带装备(player);
			}
			if (player.得到包裹物品位置(1008000526) != -1)
			{
				自动吃药(player, 1008000526);
				自动带装备(player);
			}
			if (player.得到包裹物品位置(1008000539) != -1)
			{
				自动吃药(player, 1008000539);
				自动带装备(player);
			}
			if (!player.追加状态列表.ContainsKey(1007000007) && player.得到包裹物品位置(1007000007) != -1)
			{
				自动吃药(player, 1007000007);
			}
			if (!player.追加状态列表.ContainsKey(1008001187) && player.得到包裹物品位置(1008001187) != -1)
			{
				自动吃药(player, 1008001187);
			}
			if (!player.追加状态列表.ContainsKey(1008001478) && player.得到包裹物品位置(1008001479) != -1)
			{
				自动吃药(player, 1008001478);
			}
			if (!player.追加状态列表.ContainsKey(1008000248) && player.得到包裹物品位置(1008000248) != -1)
			{
				自动吃药(player, 1008000248);
			}
			if (!player.追加状态列表.ContainsKey(1008000188) && player.得到包裹物品位置(1008000188) != -1)
			{
				自动吃药(player, 1008000188);
			}
			if (!player.追加状态列表.ContainsKey(1008000194) && player.得到包裹物品位置(1008000194) != -1)
			{
				自动吃药(player, 1008000194);
			}
			if (!player.追加状态列表.ContainsKey(1000000050) && player.得到包裹物品位置(1000000050) != -1)
			{
				自动吃药(player, 1000000050);
			}
			if (!player.追加状态列表.ContainsKey(1008001814) && player.得到包裹物品位置(1008001814) != -1)
			{
				自动吃药(player, 1008001814);
			}
			if (!player.追加状态列表.ContainsKey(1008000232) && player.得到包裹物品位置(1008000232) != -1)
			{
				自动吃药(player, 1008000232);
			}
			if (!player.追加状态列表.ContainsKey(1008000185) && player.得到包裹物品位置(1008000185) != -1)
			{
				自动吃药(player, 1008000185);
			}
			if (!player.追加状态列表.ContainsKey(1008000195) && player.得到包裹物品位置(1008000195) != -1)
			{
				自动吃药(player, 1008000195);
			}
			if (!player.追加状态列表.ContainsKey(1008000197) && player.得到包裹物品位置(1008000197) != -1)
			{
				自动吃药(player, 1008000197);
			}
			if (!player.追加状态列表.ContainsKey(1008000243) && player.得到包裹物品位置(1008000243) != -1)
			{
				自动吃药(player, 1008000243);
			}
			if (!player.追加状态New列表.ContainsKey(2) && !player.追加状态New列表.ContainsKey(5) && player.得到包裹物品位置(1008000213) != -1)
			{
				自动吃药(player, 1008000213);
			}
			if (!player.追加状态New列表.ContainsKey(1) && !player.追加状态New列表.ContainsKey(6) && player.得到包裹物品位置(1008000212) != -1)
			{
				自动吃药(player, 1008000212);
			}
			if (!player.妖花青草 && player.得到包裹物品位置(1008002386) != -1)
			{
				自动吃药(player, 1008002386);
			}
			if (!player.妖花青草 && player.得到包裹物品位置(1008002385) != -1)
			{
				自动吃药(player, 1008002385);
			}
			if (!player.追加状态列表.ContainsKey(1008000363) && !player.追加状态列表.ContainsKey(1008000362) && player.得到包裹物品位置(1008000363) != -1)
			{
				自动吃药(player, 1008000363);
			}
			if (!player.追加状态列表.ContainsKey(1008000362) && !player.追加状态列表.ContainsKey(1008000363) && player.装备栏已穿装备[11].Get物品ID != 0L && player.得到包裹物品位置(1008000362) != -1)
			{
				自动吃药(player, 1008000362);
			}
			if (!player.追加状态列表.ContainsKey(1008001134) && !player.追加状态列表.ContainsKey(1008001135) && player.得到包裹物品位置(1008001134) != -1)
			{
				自动吃药(player, 1008001134);
			}
			if (!player.追加状态列表.ContainsKey(1007000005) && player.得到包裹物品位置(1008000082) != -1)
			{
				自动吃药(player, 1008000082);
			}
			if (player.自动补给药品 == 0 && player.是否假人 != 0)
			{
				player.自动补给药品++;
				player.清理背包();
				player.清理行囊();
			}
			else if (player.自动补给药品 == 1 && player.是否假人 != 0)
			{
				player.自动补给药品++;
				player.AddItemWithProperties(1008000533, player.得到行囊空位数(), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			}
			else if (player.自动补给药品 == 2 && player.是否假人 != 0)
			{
				player.自动补给药品++;
				player.AddItemWithProperties(1008000517, player.得到行囊空位数(), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			}
			else if (player.自动补给药品 == 3 && player.是否假人 != 0)
			{
				player.自动补给药品++;
				player.AddItemWithProperties(1008000532, player.得到行囊空位数(), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
			}
			else if (player.得到包裹物品位置(1008000532) != -1)
			{
				自动吃药(player, 1008000532);
			}
		}

		private static void 假人移动(Players player)
		{
			if (player.Player_Level > 1 && player.Player_Level < 25 && player.人物坐标_地图 != 101)
			{
				假人地图读取(player, 1);
			}
			else if (player.Player_Level > 24 && player.Player_Level < 55 && player.人物坐标_地图 != 201 && player.人物坐标_地图 != 301)
			{
				假人地图读取(player, 2);
			}
			else if (player.Player_Level > 54 && player.Player_Level < 85 && player.人物坐标_地图 != 1001 && player.人物坐标_地图 != 1101)
			{
				假人地图读取(player, 3);
			}
			else if (player.Player_Level > 84 && player.Player_Level < 95 && player.人物坐标_地图 != 2101 && player.人物坐标_地图 != 2201)
			{
				假人地图读取(player, 4);
			}
			else if (player.Player_Level > 94 && player.Player_Level < 110 && player.人物坐标_地图 != 5001)
			{
				假人地图读取(player, 5);
			}
			else if (player.Player_Level > 109 && player.Player_Level < 125 && player.人物坐标_地图 != 6001)
			{
				假人地图读取(player, 6);
			}
			else if (player.Player_Level > 124 && player.Player_Level < 135 && player.人物坐标_地图 != 25100)
			{
				假人地图读取(player, 7);
			}
			else if (player.Player_Level > 134 && player.Player_Level < 150 && player.人物坐标_地图 != 26000)
			{
				假人地图读取(player, 8);
			}
			else if (player.Player_Level > 149 && player.Player_Level < 255 && player.人物坐标_地图 != 26100)
			{
				假人地图读取(player, 9);
			}
		}

		private static void 假人地图读取(Players player, int 几转)
		{
			NpcClass npcClass = null;
			switch (几转)
			{
			case 1:
			{
				int index9 = RNG.Next(1, World.一转地图.Count);
				npcClass = World.一转地图[index9];
				World.一转地图.Remove(npcClass);
				break;
			}
			case 2:
			{
				int index8 = RNG.Next(1, World.二转地图.Count);
				npcClass = World.二转地图[index8];
				World.二转地图.Remove(npcClass);
				break;
			}
			case 3:
			{
				int index7 = RNG.Next(1, World.三转地图.Count);
				npcClass = World.三转地图[index7];
				World.三转地图.Remove(npcClass);
				break;
			}
			case 4:
			{
				int index6 = RNG.Next(1, World.四转地图.Count);
				npcClass = World.四转地图[index6];
				World.四转地图.Remove(npcClass);
				break;
			}
			case 5:
			{
				int index5 = RNG.Next(1, World.五转地图.Count);
				npcClass = World.五转地图[index5];
				World.五转地图.Remove(npcClass);
				break;
			}
			case 6:
			{
				int index4 = RNG.Next(1, World.六转地图.Count);
				npcClass = World.六转地图[index4];
				World.六转地图.Remove(npcClass);
				break;
			}
			case 7:
			{
				int index3 = RNG.Next(1, World.七转地图.Count);
				npcClass = World.七转地图[index3];
				World.七转地图.Remove(npcClass);
				break;
			}
			case 8:
			{
				int index2 = RNG.Next(1, World.八转地图.Count);
				npcClass = World.八转地图[index2];
				World.八转地图.Remove(npcClass);
				break;
			}
			case 9:
			{
				int index = RNG.Next(1, World.九转地图.Count);
				npcClass = World.九转地图[index];
				World.九转地图.Remove(npcClass);
				break;
			}
			}
			if (npcClass != null)
			{
				player.自动挂机坐标X = (int)npcClass.X;
				player.自动挂机坐标Y = (int)npcClass.Y;
				player.自动挂机地图 = npcClass.Rxjh_Map;
				player.移动(npcClass.X, npcClass.Y, 15f, npcClass.Rxjh_Map);
				player.获取复查范围Npc();
				MainForm.WriteLine(1, "切换地图:[" + player.UserName + "]坐标X:" + npcClass.X + " 坐标Y:" + npcClass.Y + " 地图:" + npcClass.Rxjh_Map);
			}
		}

		private static void 假人转职(Players player)
		{
			if (player.Player_Level > 9 && player.Player_Level < 35 && player.Player_Job_leve != 1)
			{
				player.人物转职业(0, 1);
				MainForm.WriteLine(2, "假人自动1转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 34 && player.Player_Level < 60 && player.Player_Job_leve != 2)
			{
				Random random = new Random();
				int num = random.Next(1, 100);
				if (num >= 55)
				{
					player.人物转职业(1, 2);
					MainForm.WriteLine(2, "假人自动2转");
				}
				else
				{
					player.人物转职业(2, 2);
					MainForm.WriteLine(2, "假人自动2转");
				}
				if (player.Player_Job == 5)
				{
					player.学习技能(1, 7);
					player.学习技能(1, 9);
					player.学习技能(1, 11);
					player.学习技能(1, 13);
				}
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 59 && player.Player_Level < 80 && player.Player_Job_leve != 3)
			{
				player.人物转职业(player.Player_Zx, 3);
				if (player.Player_Job == 5)
				{
					player.学习技能(1, 14);
					player.学习技能(1, 15);
				}
				if (player.Player_Job == 4)
				{
					player.学习技能(1, 6);
					player.学习技能(1, 7);
					player.学习技能(1, 9);
					player.学习技能(1, 10);
					player.学习技能(1, 11);
				}
				MainForm.WriteLine(2, "假人自动3转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 79 && player.Player_Level < 100 && player.Player_Job_leve != 4)
			{
				player.人物转职业(player.Player_Zx, 4);
				MainForm.WriteLine(2, "假人自动4转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 99 && player.Player_Level < 115 && player.Player_Job_leve != 5)
			{
				player.人物转职业(player.Player_Zx, 5);
				MainForm.WriteLine(2, "假人自动5转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 114 && player.Player_Level < 120 && player.Player_Job_leve != 6)
			{
				player.人物转职业(player.Player_Zx, 6);
				if (player.Player_Job == 5)
				{
					player.学习技能(1, 17);
					player.学习技能(1, 18);
					player.学习技能(1, 21);
					player.学习技能(1, 22);
					player.学习技能(1, 23);
				}
				学习升天武功(player);
				学习升天气功(player);
				MainForm.WriteLine(2, "假人自动6转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 119 && player.Player_Level < 130 && player.Player_Job_leve != 7)
			{
				player.人物转职业(player.Player_Zx, 7);
				学习升天武功(player);
				学习升天气功(player);
				MainForm.WriteLine(2, "假人自动7转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 129 && player.Player_Level < 140 && player.Player_Job_leve != 8)
			{
				player.人物转职业(player.Player_Zx, 8);
				学习升天武功(player);
				学习升天气功(player);
				MainForm.WriteLine(2, "假人自动8转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 139 && player.Player_Level < 150 && player.Player_Job_leve != 9)
			{
				player.人物转职业(player.Player_Zx, 9);
				学习升天武功(player);
				学习升天气功(player);
				MainForm.WriteLine(2, "假人自动9转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 149 && player.Player_Level < 255 && player.Player_Job_leve != 10)
			{
				player.人物转职业(player.Player_Zx, 10);
				学习升天武功(player);
				学习升天气功(player);
				MainForm.WriteLine(2, "假人自动10转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
		}

		private static void 学习升天武功(Players player)
		{
			switch (player.Player_Job_leve)
			{
			case 6:
				switch (player.Player_Job)
				{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 10:
				case 13:
					player.学习技能(3, 1);
					player.学习技能(3, 2);
					player.武功新[3, 1].武功_等级 = 10;
					player.武功新[3, 2].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天一技能");
					break;
				case 8:
					player.学习技能(1, 10);
					player.学习技能(3, 1);
					player.武功新[1, 10].武功_等级 = 1;
					player.武功新[3, 1].武功_等级 = 1;
					player.学习技能(3, 22);
					player.学习技能(3, 23);
					player.学习技能(3, 24);
					player.武功新[3, 22].武功_等级 = 1;
					player.武功新[3, 23].武功_等级 = 1;
					player.武功新[3, 24].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天一技能");
					break;
				case 9:
					player.学习技能(1, 9);
					player.学习技能(1, 17);
					player.学习技能(3, 13);
					player.学习技能(3, 14);
					player.学习技能(3, 15);
					player.武功新[1, 9].武功_等级 = 1;
					player.武功新[1, 17].武功_等级 = 1;
					player.武功新[3, 13].武功_等级 = 1;
					player.武功新[3, 14].武功_等级 = 1;
					player.武功新[3, 15].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天一技能");
					break;
				case 11:
					player.学习技能(3, 1);
					player.学习技能(3, 2);
					player.学习技能(3, 3);
					player.武功新[3, 1].武功_等级 = 10;
					player.武功新[3, 2].武功_等级 = 10;
					player.武功新[3, 3].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天一技能");
					break;
				case 12:
					player.学习技能(3, 1);
					player.学习技能(3, 2);
					player.学习技能(3, 3);
					player.武功新[3, 1].武功_等级 = 10;
					player.武功新[3, 2].武功_等级 = 10;
					player.武功新[3, 3].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天一技能");
					break;
				}
				break;
			case 7:
				switch (player.Player_Job)
				{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 10:
				case 13:
					player.学习技能(3, 4);
					player.学习技能(3, 5);
					player.武功新[3, 4].武功_等级 = 10;
					player.武功新[3, 5].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天二技能");
					break;
				case 8:
					player.学习技能(3, 5);
					player.学习技能(1, 11);
					player.学习技能(1, 13);
					player.武功新[3, 5].武功_等级 = 10;
					player.武功新[1, 11].武功_等级 = 3;
					player.武功新[1, 13].武功_等级 = 3;
					MainForm.WriteLine(2, "学习升天二技能");
					break;
				case 9:
					player.学习技能(1, 10);
					player.学习技能(1, 12);
					player.学习技能(1, 14);
					player.学习技能(1, 18);
					player.武功新[1, 10].武功_等级 = 1;
					player.武功新[1, 12].武功_等级 = 1;
					player.武功新[1, 14].武功_等级 = 1;
					player.武功新[1, 18].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天二技能");
					break;
				case 11:
					player.学习技能(3, 5);
					player.学习技能(3, 6);
					player.学习技能(3, 7);
					player.武功新[3, 5].武功_等级 = 10;
					player.武功新[3, 6].武功_等级 = 10;
					player.武功新[3, 7].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天二技能");
					break;
				case 12:
					player.学习技能(3, 5);
					player.学习技能(3, 6);
					player.武功新[3, 5].武功_等级 = 10;
					player.武功新[3, 6].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天二技能");
					break;
				}
				break;
			case 8:
				switch (player.Player_Job)
				{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 10:
				case 13:
					player.学习技能(3, 7);
					player.学习技能(3, 8);
					player.武功新[3, 7].武功_等级 = 1;
					player.武功新[3, 8].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天三技能");
					break;
				case 8:
					player.学习技能(3, 9);
					player.学习技能(1, 12);
					player.学习技能(1, 14);
					player.武功新[3, 9].武功_等级 = 10;
					player.武功新[1, 12].武功_等级 = 3;
					player.武功新[1, 14].武功_等级 = 3;
					MainForm.WriteLine(2, "学习升天三技能");
					break;
				case 9:
					player.学习技能(1, 11);
					player.学习技能(1, 13);
					player.学习技能(1, 15);
					player.学习技能(1, 19);
					player.武功新[1, 11].武功_等级 = 1;
					player.武功新[1, 13].武功_等级 = 1;
					player.武功新[1, 15].武功_等级 = 1;
					player.武功新[1, 19].武功_等级 = 1;
					player.学习技能(3, 16);
					player.学习技能(3, 17);
					player.武功新[3, 16].武功_等级 = 10;
					player.武功新[3, 17].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天三技能");
					break;
				case 11:
					player.学习技能(3, 9);
					player.学习技能(3, 10);
					player.学习技能(3, 11);
					player.武功新[3, 9].武功_等级 = 10;
					player.武功新[3, 10].武功_等级 = 10;
					player.武功新[3, 11].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天三技能");
					break;
				case 12:
					player.学习技能(3, 9);
					player.学习技能(3, 10);
					player.武功新[3, 9].武功_等级 = 10;
					player.武功新[3, 10].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天三技能");
					break;
				}
				break;
			case 9:
				switch (player.Player_Job)
				{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 10:
				case 13:
					player.学习技能(3, 10);
					player.学习技能(3, 11);
					player.武功新[3, 10].武功_等级 = 10;
					player.武功新[3, 11].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				case 8:
					player.学习技能(3, 13);
					player.学习技能(1, 15);
					player.学习技能(1, 16);
					player.武功新[3, 13].武功_等级 = 10;
					player.武功新[1, 15].武功_等级 = 3;
					player.武功新[1, 16].武功_等级 = 3;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				case 9:
					player.学习技能(3, 18);
					player.学习技能(3, 19);
					player.武功新[3, 18].武功_等级 = 10;
					player.武功新[3, 19].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				case 11:
					player.学习技能(3, 13);
					player.学习技能(3, 14);
					player.学习技能(3, 15);
					player.武功新[3, 13].武功_等级 = 10;
					player.武功新[3, 14].武功_等级 = 10;
					player.武功新[3, 15].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				case 12:
					player.学习技能(3, 13);
					player.学习技能(3, 14);
					player.武功新[3, 13].武功_等级 = 10;
					player.武功新[3, 14].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				}
				break;
			case 10:
				switch (player.Player_Job)
				{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 10:
				case 13:
					player.学习技能(3, 13);
					player.学习技能(3, 14);
					player.武功新[3, 13].武功_等级 = 10;
					player.武功新[3, 14].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				case 8:
					player.学习技能(3, 17);
					player.学习技能(1, 17);
					player.学习技能(1, 18);
					player.武功新[3, 17].武功_等级 = 10;
					player.武功新[1, 17].武功_等级 = 3;
					player.武功新[1, 18].武功_等级 = 3;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				case 9:
					player.学习技能(3, 20);
					player.学习技能(3, 21);
					player.武功新[3, 20].武功_等级 = 10;
					player.武功新[3, 21].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				case 11:
					player.学习技能(3, 17);
					player.学习技能(3, 18);
					player.学习技能(3, 19);
					player.武功新[3, 17].武功_等级 = 10;
					player.武功新[3, 18].武功_等级 = 10;
					player.武功新[3, 19].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				case 12:
					player.学习技能(3, 17);
					player.学习技能(3, 18);
					player.武功新[3, 17].武功_等级 = 10;
					player.武功新[3, 18].武功_等级 = 10;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				}
				break;
			}
		}

		private static void 学习升天气功(Players player)
		{
			switch (player.Player_Job_leve)
			{
			case 6:
				switch (player.Player_Job)
				{
				case 1:
					if (player.得到包裹物品位置(1000000349) != -1)
					{
						自动吃药(player, 1000000349);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000000363) != -1)
					{
						自动吃药(player, 1000000363);
					}
					break;
				case 2:
					if (player.得到包裹物品位置(1000000350) != -1)
					{
						自动吃药(player, 1000000350);
					}
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000000362) != -1)
					{
						自动吃药(player, 1000000362);
					}
					break;
				case 3:
					if (player.得到包裹物品位置(1000000352) != -1)
					{
						自动吃药(player, 1000000352);
					}
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000000363) != -1)
					{
						自动吃药(player, 1000000363);
					}
					break;
				case 4:
					if (player.得到包裹物品位置(1000000353) != -1)
					{
						自动吃药(player, 1000000353);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000362) != -1)
					{
						自动吃药(player, 1000000362);
					}
					if (player.得到包裹物品位置(1000000363) != -1)
					{
						自动吃药(player, 1000000363);
					}
					break;
				case 5:
					if (player.得到包裹物品位置(1000000354) != -1)
					{
						自动吃药(player, 1000000354);
					}
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000000364) != -1)
					{
						自动吃药(player, 1000000364);
					}
					break;
				case 6:
					if (player.得到包裹物品位置(1000000355) != -1)
					{
						自动吃药(player, 1000000355);
					}
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					break;
				case 7:
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000362) != -1)
					{
						自动吃药(player, 1000000362);
					}
					if (player.得到包裹物品位置(1000000363) != -1)
					{
						自动吃药(player, 1000000363);
					}
					if (player.得到包裹物品位置(1000000477) != -1)
					{
						自动吃药(player, 1000000477);
					}
					break;
				case 8:
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000000362) != -1)
					{
						自动吃药(player, 1000000362);
					}
					if (player.得到包裹物品位置(1000000561) != -1)
					{
						自动吃药(player, 1000000561);
					}
					break;
				case 9:
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000000362) != -1)
					{
						自动吃药(player, 1000000362);
					}
					if (player.得到包裹物品位置(1000001002) != -1)
					{
						自动吃药(player, 1000001002);
					}
					break;
				case 10:
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000000363) != -1)
					{
						自动吃药(player, 1000000363);
					}
					if (player.得到包裹物品位置(1000001091) != -1)
					{
						自动吃药(player, 1000001091);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					break;
				case 11:
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000001524) != -1)
					{
						自动吃药(player, 1000001524);
					}
					break;
				case 12:
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000001155) != -1)
					{
						自动吃药(player, 1000001155);
					}
					break;
				case 13:
					if (player.得到包裹物品位置(1000000357) != -1)
					{
						自动吃药(player, 1000000357);
					}
					if (player.得到包裹物品位置(1000000358) != -1)
					{
						自动吃药(player, 1000000358);
					}
					if (player.得到包裹物品位置(1000000359) != -1)
					{
						自动吃药(player, 1000000359);
					}
					if (player.得到包裹物品位置(1000000360) != -1)
					{
						自动吃药(player, 1000000360);
					}
					if (player.得到包裹物品位置(1000000361) != -1)
					{
						自动吃药(player, 1000000361);
					}
					if (player.得到包裹物品位置(1000001291) != -1)
					{
						自动吃药(player, 1000001291);
					}
					break;
				}
				break;
			case 7:
				switch (player.Player_Job)
				{
				case 1:
					if (player.得到包裹物品位置(1000000440) != -1)
					{
						自动吃药(player, 1000000440);
					}
					break;
				case 2:
					if (player.得到包裹物品位置(1000000441) != -1)
					{
						自动吃药(player, 1000000441);
					}
					break;
				case 3:
					if (player.得到包裹物品位置(1000000442) != -1)
					{
						自动吃药(player, 1000000442);
					}
					break;
				case 4:
					if (player.得到包裹物品位置(1000000443) != -1)
					{
						自动吃药(player, 1000000443);
					}
					break;
				case 5:
					if (player.得到包裹物品位置(1000000444) != -1)
					{
						自动吃药(player, 1000000444);
					}
					break;
				case 6:
					if (player.得到包裹物品位置(1000000445) != -1)
					{
						自动吃药(player, 1000000445);
					}
					break;
				case 7:
					if (player.得到包裹物品位置(1000000478) != -1)
					{
						自动吃药(player, 1000000478);
					}
					break;
				case 8:
					if (player.得到包裹物品位置(1000000563) != -1)
					{
						自动吃药(player, 1000000563);
					}
					break;
				case 9:
					if (player.得到包裹物品位置(1000000441) != -1)
					{
						自动吃药(player, 1000000441);
					}
					break;
				case 10:
					if (player.得到包裹物品位置(1000001092) != -1)
					{
						自动吃药(player, 1000001092);
					}
					break;
				case 11:
					if (player.得到包裹物品位置(1000001525) != -1)
					{
						自动吃药(player, 1000001525);
					}
					break;
				case 12:
					if (player.得到包裹物品位置(1000001156) != -1)
					{
						自动吃药(player, 1000001156);
					}
					break;
				case 13:
					if (player.得到包裹物品位置(1000001292) != -1)
					{
						自动吃药(player, 1000001292);
					}
					break;
				}
				break;
			case 8:
				switch (player.Player_Job)
				{
				case 1:
					if (player.得到包裹物品位置(1000000482) != -1)
					{
						自动吃药(player, 1000000482);
					}
					break;
				case 2:
					if (player.得到包裹物品位置(1000000483) != -1)
					{
						自动吃药(player, 1000000483);
					}
					break;
				case 3:
					if (player.得到包裹物品位置(1000000484) != -1)
					{
						自动吃药(player, 1000000484);
					}
					break;
				case 4:
					if (player.得到包裹物品位置(1000000485) != -1)
					{
						自动吃药(player, 1000000485);
					}
					break;
				case 5:
					if (player.得到包裹物品位置(1000000486) != -1)
					{
						自动吃药(player, 1000000486);
					}
					break;
				case 6:
					if (player.得到包裹物品位置(1000000487) != -1)
					{
						自动吃药(player, 1000000487);
					}
					break;
				case 7:
					if (player.得到包裹物品位置(1000000479) != -1)
					{
						自动吃药(player, 1000000479);
					}
					break;
				case 8:
					if (player.得到包裹物品位置(1000000562) != -1)
					{
						自动吃药(player, 1000000562);
					}
					break;
				case 9:
					if (player.得到包裹物品位置(1000000483) != -1)
					{
						自动吃药(player, 1000000483);
					}
					break;
				case 10:
					if (player.得到包裹物品位置(1000001093) != -1)
					{
						自动吃药(player, 1000001093);
					}
					break;
				case 11:
					if (player.得到包裹物品位置(1000001526) != -1)
					{
						自动吃药(player, 1000001526);
					}
					break;
				case 12:
					if (player.得到包裹物品位置(1000001157) != -1)
					{
						自动吃药(player, 1000001157);
					}
					break;
				case 13:
					if (player.得到包裹物品位置(1000001293) != -1)
					{
						自动吃药(player, 1000001293);
					}
					break;
				}
				break;
			case 9:
				switch (player.Player_Job)
				{
				case 1:
					if (player.得到包裹物品位置(1000001014) != -1)
					{
						自动吃药(player, 1000001014);
					}
					if (player.得到包裹物品位置(1000001015) != -1)
					{
						自动吃药(player, 1000001015);
					}
					break;
				case 2:
					if (player.得到包裹物品位置(1000001016) != -1)
					{
						自动吃药(player, 1000001016);
					}
					if (player.得到包裹物品位置(1000001017) != -1)
					{
						自动吃药(player, 1000001017);
					}
					break;
				case 3:
					if (player.得到包裹物品位置(1000001018) != -1)
					{
						自动吃药(player, 1000001018);
					}
					if (player.得到包裹物品位置(1000001019) != -1)
					{
						自动吃药(player, 1000001019);
					}
					break;
				case 4:
					if (player.得到包裹物品位置(1000001020) != -1)
					{
						自动吃药(player, 1000001020);
					}
					if (player.得到包裹物品位置(1000001021) != -1)
					{
						自动吃药(player, 1000001021);
					}
					break;
				case 5:
					if (player.得到包裹物品位置(1000001022) != -1)
					{
						自动吃药(player, 1000001022);
					}
					if (player.得到包裹物品位置(1000001023) != -1)
					{
						自动吃药(player, 1000001023);
					}
					break;
				case 6:
					if (player.得到包裹物品位置(1000001024) != -1)
					{
						自动吃药(player, 1000001024);
					}
					if (player.得到包裹物品位置(1000001025) != -1)
					{
						自动吃药(player, 1000001025);
					}
					break;
				case 7:
					if (player.得到包裹物品位置(1000001026) != -1)
					{
						自动吃药(player, 1000001026);
					}
					if (player.得到包裹物品位置(1000001027) != -1)
					{
						自动吃药(player, 1000001027);
					}
					break;
				case 8:
					if (player.得到包裹物品位置(1000001028) != -1)
					{
						自动吃药(player, 1000001028);
					}
					if (player.得到包裹物品位置(1000001029) != -1)
					{
						自动吃药(player, 1000001029);
					}
					break;
				case 9:
					if (player.得到包裹物品位置(1000001030) != -1)
					{
						自动吃药(player, 1000001030);
					}
					if (player.得到包裹物品位置(1000001031) != -1)
					{
						自动吃药(player, 1000001031);
					}
					break;
				case 10:
					if (player.得到包裹物品位置(1000001094) != -1)
					{
						自动吃药(player, 1000001094);
					}
					if (player.得到包裹物品位置(1000001095) != -1)
					{
						自动吃药(player, 1000001095);
					}
					break;
				case 11:
					if (player.得到包裹物品位置(1000001527) != -1)
					{
						自动吃药(player, 1000001527);
					}
					if (player.得到包裹物品位置(1000001528) != -1)
					{
						自动吃药(player, 1000001528);
					}
					break;
				case 12:
					if (player.得到包裹物品位置(1000001158) != -1)
					{
						自动吃药(player, 1000001158);
					}
					if (player.得到包裹物品位置(1000001159) != -1)
					{
						自动吃药(player, 1000001159);
					}
					break;
				case 13:
					if (player.得到包裹物品位置(1000001294) != -1)
					{
						自动吃药(player, 1000001294);
					}
					if (player.得到包裹物品位置(1000001295) != -1)
					{
						自动吃药(player, 1000001295);
					}
					break;
				}
				break;
			case 10:
				switch (player.Player_Job)
				{
				case 1:
					if (player.得到包裹物品位置(1000001211) != -1)
					{
						自动吃药(player, 1000001211);
					}
					if (player.得到包裹物品位置(1000001224) != -1)
					{
						自动吃药(player, 1000001224);
					}
					break;
				case 2:
					if (player.得到包裹物品位置(1000001212) != -1)
					{
						自动吃药(player, 1000001212);
					}
					if (player.得到包裹物品位置(1000001225) != -1)
					{
						自动吃药(player, 1000001225);
					}
					break;
				case 3:
					if (player.得到包裹物品位置(1000001213) != -1)
					{
						自动吃药(player, 1000001213);
					}
					if (player.得到包裹物品位置(1000001226) != -1)
					{
						自动吃药(player, 1000001226);
					}
					break;
				case 4:
					if (player.得到包裹物品位置(1000001214) != -1)
					{
						自动吃药(player, 1000001214);
					}
					if (player.得到包裹物品位置(1000001227) != -1)
					{
						自动吃药(player, 1000001227);
					}
					break;
				case 5:
					if (player.得到包裹物品位置(1000001215) != -1)
					{
						自动吃药(player, 1000001215);
					}
					if (player.得到包裹物品位置(1000001228) != -1)
					{
						自动吃药(player, 1000001228);
					}
					break;
				case 6:
					if (player.得到包裹物品位置(1000001216) != -1)
					{
						自动吃药(player, 1000001216);
					}
					if (player.得到包裹物品位置(1000001229) != -1)
					{
						自动吃药(player, 1000001229);
					}
					break;
				case 7:
					if (player.得到包裹物品位置(1000001217) != -1)
					{
						自动吃药(player, 1000001217);
					}
					if (player.得到包裹物品位置(1000001230) != -1)
					{
						自动吃药(player, 1000001230);
					}
					break;
				case 8:
					if (player.得到包裹物品位置(1000001218) != -1)
					{
						自动吃药(player, 1000001218);
					}
					if (player.得到包裹物品位置(1000001231) != -1)
					{
						自动吃药(player, 1000001231);
					}
					break;
				case 9:
					if (player.得到包裹物品位置(1000001219) != -1)
					{
						自动吃药(player, 1000001219);
					}
					if (player.得到包裹物品位置(1000001232) != -1)
					{
						自动吃药(player, 1000001232);
					}
					break;
				case 10:
					if (player.得到包裹物品位置(1000001220) != -1)
					{
						自动吃药(player, 1000001220);
					}
					if (player.得到包裹物品位置(1000001233) != -1)
					{
						自动吃药(player, 1000001233);
					}
					break;
				case 11:
					if (player.得到包裹物品位置(1000001221) != -1)
					{
						自动吃药(player, 1000001221);
					}
					if (player.得到包裹物品位置(1000001234) != -1)
					{
						自动吃药(player, 1000001234);
					}
					break;
				case 12:
					if (player.得到包裹物品位置(1000001222) != -1)
					{
						自动吃药(player, 1000001222);
					}
					if (player.得到包裹物品位置(1000001235) != -1)
					{
						自动吃药(player, 1000001235);
					}
					break;
				case 13:
					if (player.得到包裹物品位置(1000001296) != -1)
					{
						自动吃药(player, 1000001296);
					}
					if (player.得到包裹物品位置(1000001297) != -1)
					{
						自动吃药(player, 1000001297);
					}
					break;
				}
				break;
			}
		}

		public static void 自动加气动点(Players player)
		{
			if (player.Player_Qigong_point <= 0)
			{
				return;
			}
			升天气功类 value;
			switch (player.Player_Job)
			{
			case 1:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(310, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(311, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(13, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(313, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(314, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(679, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(667, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(386, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 2:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(25, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(321, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(322, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(323, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(324, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(680, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(668, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(385, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 3:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(330, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(331, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(33, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(333, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(334, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(681, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(669, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(386, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 4:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(340, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(341, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(342, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(343, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(344, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(682, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(670, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(386, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(385, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 5:
				if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(387, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(58, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(352, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(353, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(683, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(671, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(354, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(150, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 6:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(370, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(371, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(170, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(374, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(684, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(373, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(672, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 7:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(390, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(391, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(392, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(393, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(394, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(685, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(673, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(386, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(385, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 8:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(600, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(601, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(602, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(603, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(604, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(686, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(674, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(385, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 9:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(700, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(321, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(322, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(701, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(702, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(687, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(675, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(385, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 10:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(562, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(561, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(563, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(564, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(565, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(688, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(676, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(386, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 11:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(316, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(325, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(315, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(326, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(327, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(689, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(677, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 12:
				if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(662, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(663, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(664, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(665, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(666, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(690, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(678, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			case 13:
				if (player.气功[2].气功量 < 20)
				{
					player.气功[2].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[3].气功量 < 20)
				{
					player.气功[3].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[5].气功量 < 20)
				{
					player.气功[5].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[6].气功量 < 20)
				{
					player.气功[6].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[8].气功量 < 20)
				{
					player.气功[8].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[9].气功量 < 20)
				{
					player.气功[9].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[10].气功量 < 20)
				{
					player.气功[10].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[11].气功量 < 20)
				{
					player.气功[11].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(380, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(381, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(382, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(384, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(610, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(611, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(612, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(613, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(614, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(616, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(615, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[7].气功量 < 20)
				{
					player.气功[7].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[4].气功量 < 20)
				{
					player.气功[4].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[1].气功量 < 20)
				{
					player.气功[1].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.升天气功.TryGetValue(383, out value) && value.气功量 < 20)
				{
					value.气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				else if (player.气功[0].气功量 < 20)
				{
					player.气功[0].气功量++;
					player.Player_Qigong_point--;
					player.更新气功();
					player.更新武功和状态();
				}
				break;
			}
		}

		private static void 自动带装备(Players player)
		{
			if (player == null)
			{
				return;
			}
			for (int i = 0; i < 96; i++)
			{
				int num = BitConverter.ToInt32(player.装备栏包裹[i].物品ID, 0);
				if (num != 0)
				{
					ItmeClass itmeClass = World.Itme[num];
					int num2 = 999;
					switch (itmeClass.FLD_RESIDE2)
					{
					case 1:
						num2 = 0;
						break;
					case 2:
						num2 = ((player.装备栏已穿装备[1].Get物品ID == 0L) ? 1 : 2);
						break;
					case 4:
						num2 = 3;
						break;
					case 5:
						num2 = 4;
						break;
					case 6:
						num2 = 5;
						break;
					case 7:
						num2 = 6;
						break;
					case 8:
						num2 = ((player.装备栏已穿装备[7].Get物品ID != 0L) ? 8 : 7);
						break;
					case 10:
						num2 = ((player.装备栏已穿装备[9].Get物品ID != 0L) ? 10 : 9);
						break;
					case 12:
						num2 = 11;
						break;
					case 13:
						num2 = 12;
						break;
					case 14:
						num2 = 13;
						break;
					case 15:
						num2 = 14;
						break;
					case 16:
						num2 = 15;
						break;
					}
					if (num2 != 999 && player.装备栏已穿装备[num2].Get物品ID == 0)
					{
						player.装备栏已穿装备[num2].物品_byte = player.装备栏包裹[i].物品_byte;
						player.装备栏包裹[i].物品_byte = new byte[77];
						player.更换装备位置(1, i, 0, num2, player.装备栏已穿装备[num2].物品_byte, BitConverter.ToInt32(player.装备栏已穿装备[num2].物品数量, 0));
					}
				}
			}
			player.更新人物数据(player);
			player.更新广播人物数据();
			player.更新装备效果();
			player.计算人物装备数据();
			player.更新武功和状态();
			player.更新金钱和负重();
			player.更新HP_MP_SP();
			高等级装备切换(player);
		}

		private static void 高等级装备切换(Players player)
		{
			if (player == null)
			{
				return;
			}
			for (int i = 0; i < 96; i++)
			{
				int num = BitConverter.ToInt32(player.装备栏包裹[i].物品ID, 0);
				if (num != 0)
				{
					ItmeClass itmeClass = World.Itme[num];
					int num2 = 888;
					switch (itmeClass.FLD_RESIDE2)
					{
					case 1:
						num2 = 0;
						break;
					case 2:
						num2 = ((player.装备栏已穿装备[1].FLD_LEVEL < itmeClass.FLD_LEVEL) ? 1 : 2);
						break;
					case 4:
						num2 = 3;
						break;
					case 5:
						num2 = 4;
						break;
					case 6:
						num2 = 5;
						break;
					case 7:
						num2 = 6;
						break;
					case 8:
						num2 = ((player.装备栏已穿装备[7].FLD_LEVEL < itmeClass.FLD_LEVEL) ? 8 : 7);
						break;
					case 10:
						num2 = ((player.装备栏已穿装备[9].FLD_LEVEL < itmeClass.FLD_LEVEL) ? 10 : 9);
						break;
					}
					if (num2 != 888 && player.装备栏已穿装备[num2].FLD_LEVEL < itmeClass.FLD_LEVEL)
					{
						byte[] 物品_byte = player.装备栏已穿装备[num2].物品_byte;
						player.装备栏已穿装备[num2].物品_byte = player.装备栏包裹[i].物品_byte;
						player.装备栏包裹[i].物品_byte = 物品_byte;
						player.更换装备位置(1, i, 0, num2, player.装备栏已穿装备[num2].物品_byte, BitConverter.ToInt32(player.装备栏已穿装备[num2].物品数量, 0));
					}
				}
			}
			player.更新人物数据(player);
			player.更新广播人物数据();
			player.更新装备效果();
			player.计算人物装备数据();
			player.更新武功和状态();
			player.更新金钱和负重();
			player.更新HP_MP_SP();
			高等级装备切换手镯(player);
		}

		private static void 高等级装备切换手镯(Players player)
		{
			if (player == null)
			{
				return;
			}
			for (int i = 0; i < 96; i++)
			{
				int num = BitConverter.ToInt32(player.装备栏包裹[i].物品ID, 0);
				if (num != 0)
				{
					ItmeClass itmeClass = World.Itme[num];
					int num2 = 777;
					switch (itmeClass.FLD_RESIDE2)
					{
					case 2:
						num2 = ((player.装备栏已穿装备[1].FLD_LEVEL < itmeClass.FLD_LEVEL) ? 1 : 2);
						break;
					case 8:
						num2 = ((player.装备栏已穿装备[7].FLD_LEVEL < itmeClass.FLD_LEVEL) ? 8 : 7);
						break;
					case 10:
						num2 = ((player.装备栏已穿装备[9].FLD_LEVEL < itmeClass.FLD_LEVEL) ? 10 : 9);
						break;
					}
					if (num2 != 777 && player.装备栏已穿装备[num2].FLD_LEVEL < itmeClass.FLD_LEVEL)
					{
						byte[] 物品_byte = player.装备栏已穿装备[num2].物品_byte;
						player.装备栏已穿装备[num2].物品_byte = player.装备栏包裹[i].物品_byte;
						player.装备栏包裹[i].物品_byte = 物品_byte;
						player.更换装备位置(1, i, 0, num2, player.装备栏已穿装备[num2].物品_byte, BitConverter.ToInt32(player.装备栏已穿装备[num2].物品数量, 0));
					}
				}
			}
			player.更新人物数据(player);
			player.更新广播人物数据();
			player.更新装备效果();
			player.计算人物装备数据();
			player.更新武功和状态();
			player.更新金钱和负重();
			player.更新HP_MP_SP();
		}

		public static void 内挂出售(Players playe)
		{
			try
			{
				for (int i = 0; i < 36; i++)
				{
					int num = BitConverter.ToInt32(playe.装备栏包裹[i].物品ID, 0);
					int num2 = BitConverter.ToInt32(playe.装备栏包裹[i].物品数量, 0);
					if (num2 <= 0)
					{
						num2 = 1;
					}
					if (num <= 0)
					{
						continue;
					}
					if (!World.Itme.TryGetValue(num, out var value))
					{
						playe.系统提示("核查存物品ID错误！", 10, "内挂");
						continue;
					}
					int num3 = 0;
					int fLD_MAGIC = playe.装备栏包裹[i].FLD_MAGIC0;
					int fLD_MAGIC2 = playe.装备栏包裹[i].FLD_MAGIC1;
					int fLD_MAGIC3 = playe.装备栏包裹[i].FLD_MAGIC2;
					int fLD_MAGIC4 = playe.装备栏包裹[i].FLD_MAGIC3;
					int fLD_MAGIC5 = playe.装备栏包裹[i].FLD_MAGIC4;
					if (fLD_MAGIC >= 1 || fLD_MAGIC2 >= 1 || fLD_MAGIC3 >= 1 || fLD_MAGIC4 >= 1 || fLD_MAGIC5 >= 1)
					{
						num3 = 1;
					}
					string itmeNAME = value.ItmeNAME;
					string itmeDES = value.ItmeDES;
					int fLD_RECYCLE_MONEY = value.FLD_RECYCLE_MONEY;
					if (BitConverter.ToInt32(playe.装备栏包裹[i].物品ID, 0) >= 1)
					{
						if (!itmeDES.Contains("无需"))
						{
							内挂存仓库(playe, num, i, num2, itmeNAME);
						}
						if (value.FLD_RESIDE2 != 17 && num3 != 1 && fLD_RECYCLE_MONEY > 0)
						{
							playe.Player_Money += fLD_RECYCLE_MONEY;
							playe.更新金钱和负重();
							playe.得到钱的提示((uint)fLD_RECYCLE_MONEY);
							playe.系统提示("[" + itmeNAME + "]此物品, 售价为[" + fLD_RECYCLE_MONEY + "] 已出售", 10, "智能出售");
							playe.减去物品(i, num2);
						}
					}
				}
			}
			catch
			{
				MainForm.WriteLine(1, "内挂出售 错误");
			}
		}

		public static void 内挂存仓库(Players playe, int 物品ID, int 背包位置, int 物品数量, string 物品名字)
		{
			try
			{
				int num = playe.得到个人仓库空位(3);
				int num2 = playe.得到个人仓库空位(4);
				if (num != -1)
				{
					playe.仓库_装备栏减物品(物品ID, 背包位置, 物品数量, num, 3);
				}
				else if (num2 != -1)
				{
					playe.仓库_装备栏减物品(物品ID, 背包位置, 物品数量, num2, 4);
				}
				else
				{
					playe.系统提示("仓库已满", 10, "内挂");
				}
			}
			catch
			{
				MainForm.WriteLine(1, "内挂存仓库 错误");
			}
		}

		public static long 获取自动拾取物品(Players player)
		{
			long result = 0L;
			List<地面物品类> list = new List<地面物品类>();
			Random random = new Random();
			foreach (地面物品类 value in World.ItemTemp.Values)
			{
				try
				{
					if (player.查找范围地面物品(300, value) && value.物品优先权 != null && value.物品优先权.UserName == player.UserName)
					{
						list.Add(value);
					}
				}
				catch (Exception)
				{
					throw;
				}
			}
			if (list.Count > 0)
			{
				int index = random.Next(0, list.Count);
				result = list[index].物品.Get物品全局ID;
				list.Clear();
				return result;
			}
			list.Clear();
			return result;
		}

		public static void 自动吃药(Players player, int PID)
		{
			int num = player.得到包裹物品位置(PID);
			if (num >= 0)
			{
				string hex = "AA5522002C013A001C0001000037DC143C00000000000000000000000000010000000000000055AA";
				byte[] array = Converter.hexStringToByte(hex);
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, array, 11, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(PID), 0, array, 14, 4);
				player.打开物品(array, array.Length);
			}
		}

		public static void 离线移动包(Players player, float x, float y, float jl)
		{
			byte[] array = Converter.hexStringToByte("AA552E002E010700280002000000F91DC7426177ACC3978E3C44F91DC74200007041978E3C4401050000000000005C28000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(x), 0, array, 14, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(15f), 0, array, 18, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(y), 0, array, 22, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_X), 0, array, 26, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_Z), 0, array, 30, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_Y), 0, array, 34, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物轻功), 0, array, 39, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(jl), 0, array, 42, 4);
			player.人物移动(array, array.Length);
		}

		public static int 获取自动攻击NPC目标(Players player, float float_0, float float_1)
		{
			int result = 0;
			if (player.NpcList != null)
			{
				List<NpcClass> list = new List<NpcClass>();
				foreach (NpcClass value in player.NpcList.Values)
				{
					if (自动攻击范围Npc(player, World.离线挂机打怪范围, value, float_0, float_1) && !value.NPC死亡 && value.IsNpc != 1 && (long)value.Rxjh_HP > 1L)
					{
						list.Add(value);
					}
				}
				if (list.Count > 0)
				{
					int num = World.离线挂机打怪范围;
					foreach (NpcClass item in list)
					{
						float num2 = item.X - player.人物坐标_X;
						float num3 = item.Y - player.人物坐标_Y;
						float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
						if ((int)num4 < num)
						{
							num = (int)num4;
							result = item.FLD_INDEX;
						}
					}
					list.Clear();
				}
			}
			foreach (Players value2 in World.AllConnectedPlayers.Values)
			{
				if (value2.人物_HP > 0 && !value2.Player死亡 && value2.人物PK模式 != 0 && !value2.Client.挂机 && player.查找范围玩家(50, value2) && player.人物全服ID != value2.人物全服ID)
				{
					result = value2.人物全服ID;
				}
			}
			return result;
		}

		public static bool 自动攻击范围Npc(Players player, int int_75, NpcClass npcClass_0, float float_0, float float_1)
		{
			if (npcClass_0.Rxjh_Map != player.人物坐标_地图)
			{
				return false;
			}
			if (player.人物坐标_地图 == 7101)
			{
				int_75 = 1000;
			}
			float num = npcClass_0.X - float_0;
			float num2 = npcClass_0.Y - float_1;
			float num3 = (int)Math.Sqrt(num * num + num2 * num2);
			return num3 <= (float)int_75;
		}
	}
}
