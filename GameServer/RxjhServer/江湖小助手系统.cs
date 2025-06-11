using System;
using System.Collections.Generic;
using RxjhServer.HelperTools;

namespace RxjhServer
{
	public class 江湖小助手系统
	{
		public static void 江湖小助手(Players player)
		{
			try
			{
				if ((int)DateTime.Now.Subtract(player.在线挂机打怪时间).TotalMilliseconds >= World.内挂打怪说话时间)
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
						自动说话 = World.在线挂机提示内容;
						player.发送消息(自动说话, msgType, userName);
					}
					player.在线挂机打怪时间 = DateTime.Now;
					return;
				}
				if (player.人物_HP <= (int)((double)player.人物最大_HP * 0.95) && (long)player.人物_HP > 0L)
				{
					int sl = player.人物最大_HP - player.人物_HP;
					player.加血(sl);
					player.吃药效果(1000000102);
					player.更新HP_MP_SP();
				}
				if (player.人物_MP <= (int)((double)player.人物最大_MP * 0.95) && (long)player.人物_MP > 0L)
				{
					player.加魔(20000);
					player.吃药效果(1000000104);
					player.更新HP_MP_SP();
				}
				long num = 获取自动拾取物品(player);
				if (num != 0L && World.ItemTemp.ContainsKey(num))
				{
					int num2 = player.得到包裹空位(player);
					if (player.江湖小助手打怪模式 != 0 || num2 == -1)
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
				if (player.江湖小助手打怪模式 == 1)
				{
					自动吃药(player);
					假人转职(player);
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
			if (!player.追加状态列表.ContainsKey(1008000362) && !player.追加状态列表.ContainsKey(1008000363) && player.得到包裹物品位置(1008000362) != -1)
			{
				自动吃药(player, 1008000362);
			}
			if (!player.追加状态列表.ContainsKey(1008001134) && !player.追加状态列表.ContainsKey(1008001135) && player.装备栏已穿装备[11].Get物品ID != 0L && player.得到包裹物品位置(1008001134) != -1)
			{
				自动吃药(player, 1008001134);
			}
			if (!player.追加状态列表.ContainsKey(1007000005) && player.得到包裹物品位置(1008000082) != -1)
			{
				自动吃药(player, 1008000082);
			}
		}

		private static void 假人转职(Players player)
		{
			if (player.Player_Level > 9 && player.Player_Level < 35 && player.Player_Job_leve != 1)
			{
				player.人物转职业(0, 1);
				MainForm.WriteLine(2, "小助手自动1转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 34 && player.Player_Level < 60 && player.Player_Job_leve != 2)
			{
				int num = new Random(DateTime.Now.Millisecond).Next(1, 100);
				if (num >= 55)
				{
					player.人物转职业(1, 2);
					MainForm.WriteLine(2, "小助手自动2转");
				}
				else
				{
					player.人物转职业(2, 2);
					MainForm.WriteLine(2, "小助手自动2转");
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
				MainForm.WriteLine(2, "小助手自动3转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 79 && player.Player_Level < 100 && player.Player_Job_leve != 4)
			{
				player.人物转职业(player.Player_Zx, 4);
				MainForm.WriteLine(2, "小助手自动4转");
				player.更新人物数据(player);
				player.更新经验和历练();
				player.初始化已装备物品();
				player.更新金钱和负重();
				player.更新武功和状态();
			}
			else if (player.Player_Level > 99 && player.Player_Level < 115 && player.Player_Job_leve != 5)
			{
				player.人物转职业(player.Player_Zx, 5);
				MainForm.WriteLine(2, "小助手自动5转");
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
				MainForm.WriteLine(2, "小助手自动6转");
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
				MainForm.WriteLine(2, "小助手自动7转");
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
				MainForm.WriteLine(2, "小助手自动8转");
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
				MainForm.WriteLine(2, "小助手自动9转");
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
				MainForm.WriteLine(2, "小助手自动10转");
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
					player.武功新[3, 1].武功_等级 = 1;
					player.武功新[3, 2].武功_等级 = 1;
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
					player.武功新[3, 1].武功_等级 = 1;
					player.武功新[3, 2].武功_等级 = 1;
					player.武功新[3, 3].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天一技能");
					break;
				case 12:
					player.学习技能(3, 1);
					player.学习技能(3, 2);
					player.学习技能(3, 3);
					player.武功新[3, 1].武功_等级 = 1;
					player.武功新[3, 2].武功_等级 = 1;
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
					player.武功新[3, 4].武功_等级 = 1;
					player.武功新[3, 5].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天二技能");
					break;
				case 8:
					player.学习技能(3, 5);
					player.学习技能(1, 11);
					player.学习技能(1, 13);
					player.武功新[3, 5].武功_等级 = 1;
					player.武功新[1, 11].武功_等级 = 1;
					player.武功新[1, 13].武功_等级 = 1;
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
					player.武功新[3, 5].武功_等级 = 1;
					player.武功新[3, 6].武功_等级 = 1;
					player.武功新[3, 7].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天二技能");
					break;
				case 12:
					player.学习技能(3, 5);
					player.学习技能(3, 6);
					player.武功新[3, 5].武功_等级 = 1;
					player.武功新[3, 6].武功_等级 = 1;
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
					player.武功新[3, 9].武功_等级 = 1;
					player.武功新[1, 12].武功_等级 = 1;
					player.武功新[1, 14].武功_等级 = 1;
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
					player.武功新[3, 16].武功_等级 = 1;
					player.武功新[3, 17].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天三技能");
					break;
				case 11:
					player.学习技能(3, 9);
					player.学习技能(3, 10);
					player.学习技能(3, 11);
					player.武功新[3, 9].武功_等级 = 1;
					player.武功新[3, 10].武功_等级 = 1;
					player.武功新[3, 11].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天三技能");
					break;
				case 12:
					player.学习技能(3, 9);
					player.学习技能(3, 10);
					player.武功新[3, 9].武功_等级 = 1;
					player.武功新[3, 10].武功_等级 = 1;
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
					player.武功新[3, 10].武功_等级 = 1;
					player.武功新[3, 11].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				case 8:
					player.学习技能(3, 13);
					player.学习技能(1, 15);
					player.学习技能(1, 16);
					player.武功新[3, 13].武功_等级 = 1;
					player.武功新[1, 15].武功_等级 = 1;
					player.武功新[1, 16].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				case 9:
					player.学习技能(3, 18);
					player.学习技能(3, 19);
					player.武功新[3, 18].武功_等级 = 1;
					player.武功新[3, 19].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				case 11:
					player.学习技能(3, 13);
					player.学习技能(3, 14);
					player.学习技能(3, 15);
					player.武功新[3, 13].武功_等级 = 1;
					player.武功新[3, 14].武功_等级 = 1;
					player.武功新[3, 15].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天四技能");
					break;
				case 12:
					player.学习技能(3, 13);
					player.学习技能(3, 14);
					player.武功新[3, 13].武功_等级 = 1;
					player.武功新[3, 14].武功_等级 = 1;
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
					player.武功新[3, 13].武功_等级 = 1;
					player.武功新[3, 14].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				case 8:
					player.学习技能(3, 17);
					player.学习技能(1, 17);
					player.学习技能(1, 18);
					player.武功新[3, 17].武功_等级 = 1;
					player.武功新[1, 17].武功_等级 = 1;
					player.武功新[1, 18].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				case 9:
					player.学习技能(3, 20);
					player.学习技能(3, 21);
					player.武功新[3, 20].武功_等级 = 1;
					player.武功新[3, 21].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				case 11:
					player.学习技能(3, 17);
					player.学习技能(3, 18);
					player.学习技能(3, 19);
					player.武功新[3, 17].武功_等级 = 1;
					player.武功新[3, 18].武功_等级 = 1;
					player.武功新[3, 19].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
				case 12:
					player.学习技能(3, 17);
					player.学习技能(3, 18);
					player.武功新[3, 17].武功_等级 = 1;
					player.武功新[3, 18].武功_等级 = 1;
					MainForm.WriteLine(2, "学习升天五技能");
					break;
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

		public static void 离线攻击包(Players player)
		{
			byte[] array = Converter.hexStringToByte("AA551E002E01090018005828B3C300000000AE705F4300007041B82D35440100000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(player.离线挂机当前攻击怪物), 0, array, 10, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(player.江湖小助手武功ID), 0, array, 14, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_X), 0, array, 18, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_Z), 0, array, 22, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物坐标_Y), 0, array, 26, 4);
			player.攻击(array, array.Length);
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
				if (player.人物PK模式 > 0 && value2.人物_HP > 0 && !value2.Player死亡 && value2.人物PK模式 != 0 && !value2.Client.挂机 && player.查找范围玩家(50, value2) && player.人物全服ID != value2.人物全服ID)
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
