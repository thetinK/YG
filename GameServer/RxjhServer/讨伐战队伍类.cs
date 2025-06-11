using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using RxjhServer.HelperTools;

namespace RxjhServer
{
	public class 讨伐战队伍类
	{
		public static int 全局讨伐队编号 = 1;

		public Players 队长;

		public ThreadSafeDictionary<int, Players> 队员列表 = new ThreadSafeDictionary<int, Players>();

		public int 队伍ID;

		public int 队伍等级;

		public int 队伍转职;

		public int 队伍副本难度;

		public static int 创建讨伐队(讨伐战队伍类 讨伐战队)
		{
			全局讨伐队编号++;
			讨伐战队.队伍ID = 全局讨伐队编号;
			World.讨伐队伍.TryAdd(全局讨伐队编号, 讨伐战队);
			return 全局讨伐队编号;
		}

		public static 讨伐战队伍类 得到讨伐队伍信息(int 队伍编号)
		{
			if (World.讨伐队伍.TryGetValue(队伍编号, out var value))
			{
				return value;
			}
			return null;
		}

		public static void 讨伐队管理(Players player, byte[] data, int legth)
		{
			try
			{
				switch (data[12])
				{
				case 30:
					创建讨伐队(player, data, legth);
					break;
				case 31:
					查看讨伐队目录(player, data, legth);
					break;
				case 32:
					查看讨伐队信息(player, data, legth);
					break;
				case 33:
					加入讨伐队(player, data, legth);
					break;
				case 34:
					取消参加讨伐(player, data, legth);
					break;
				case 35:
					退出讨伐队(player, data, legth);
					break;
				case 36:
					强制逐出讨伐队(player, data, legth);
					break;
				case 37:
					委任讨伐队队长(player, data, legth);
					break;
				case 45:
					我的讨伐队管理(player, data, legth);
					break;
				case 47:
					大厅登记(player, data, legth);
					break;
				case 48:
					取消登记(player, data, legth);
					break;
				case 50:
					查看佣兵大厅(player, data, legth);
					break;
				case 52:
					银币广场集合(player, data, legth);
					break;
				case 53:
					进入讨伐(player, data, legth);
					break;
				case 54:
					再次进入讨伐队(player, data, legth);
					break;
				case 58:
					if (World.是否开启共用银币市场 == 1)
					{
						if (World.老泫勃派开关 == 1)
						{
							player.移动(495f, 1727f, 15f, 29000);
						}
						else
						{
							player.移动(10f, 10f, 15f, 1201);
						}
					}
					else if (World.老泫勃派开关 == 1)
					{
						player.移动(495f, 1727f, 15f, 29000);
					}
					else
					{
						player.移动(420f, 1520f, 15f, 101);
					}
					break;
				case 61:
					打开讨伐队面板(player, data, legth);
					break;
				case 62:
					关闭讨伐队面板(player, data, legth);
					break;
				case 38:
				case 39:
				case 40:
				case 41:
				case 42:
				case 43:
				case 44:
				case 46:
				case 49:
				case 51:
				case 55:
				case 56:
				case 57:
				case 59:
				case 60:
					break;
				}
			}
			catch
			{
			}
		}

		public static void 再次进入讨伐队(Players player, byte[] data, int legth)
		{
			try
			{
				if (World.讨伐战副本 == null)
				{
					player.系统提示("讨伐副本未开启");
				}
				else
				{
					if (player.讨伐队队伍ID == 0 || 讨伐战系统.讨伐副本占领者 != player.讨伐队队伍ID)
					{
						return;
					}
					讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(player.讨伐队队伍ID);
					if (讨伐战队伍类2 == null)
					{
						return;
					}
					物品类 物品类2 = player.得到包裹物品(1000001596);
					if (player.人物坐标_地图 != 43001 && player.副本剩余次数 != 0 && 物品类2 != null)
					{
						player.移动(20f, -600f, 15f, 43001);
						player.发送副本复活剩余次数();
						ConcurrentDictionary<int, NpcClass> concurrentDictionary = MapClass.GetnpcTemplate(43001);
						if (concurrentDictionary != null)
						{
							NpcClass.更新NPC复活数据(concurrentDictionary, player);
						}
						int time = (int)World.讨伐战副本.讨伐副本进行中结束时间.Subtract(DateTime.Now).TotalSeconds;
						讨伐战系统.进入副本提示(player, time);
						player.减去物品(物品类2.物品位置, 1);
					}
					else
					{
						player.系统提示("讨伐副本次数用完,下周再来吧,或您背包没有讨伐队入场券(地狱火龙)无法进入");
					}
					return;
				}
			}
			catch
			{
			}
		}

		public static void 进入讨伐(Players player, byte[] data, int legth)
		{
			try
			{
				if (player.讨伐队队伍ID == 0)
				{
					return;
				}
				讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(player.讨伐队队伍ID);
				if (讨伐战队伍类2 == null || 讨伐战队伍类2.队长 != player)
				{
					return;
				}
				if (讨伐战队伍类2.队员列表.Count < World.讨伐副本最少人数)
				{
					player.系统提示("讨伐副本最少要" + World.讨伐副本最少人数 + "人参加");
				}
				else if (讨伐战系统.讨伐副本占领者 == 0)
				{
					讨伐战系统.讨伐副本占领者 = player.讨伐队队伍ID;
					World.讨伐战副本 = new 讨伐战系统();
					foreach (Players value in 讨伐战队伍类2.队员列表.Values)
					{
						value.讨伐累计伤害 = 0;
						value.副本复活剩余次数 = 10;
						物品类 物品类2 = value.得到包裹物品(1000001596);
						if (value.人物坐标_地图 != 43001 && value.副本剩余次数 != 0 && 物品类2 != null)
						{
							value.移动(20f, -600f, 15f, 43001);
							value.副本剩余次数--;
							value.发送副本复活剩余次数();
							int time = (int)World.讨伐战副本.讨伐副本进行中结束时间.Subtract(DateTime.Now).TotalSeconds;
							讨伐战系统.进入副本提示(value, time);
							value.减去物品(物品类2.物品位置, 1);
						}
						else
						{
							value.移动(420f, 1500f, 15f, 101);
							player.系统提示("你讨伐副本次数不够,或您背包没有讨伐队入场券(地狱火龙)无法进入.");
						}
					}
				}
				else
				{
					player.系统提示("讨伐副本正在被使用.");
				}
			}
			catch
			{
			}
		}

		public static void 银币广场集合(Players player, byte[] data, int legth)
		{
			try
			{
				if (player.讨伐队队伍ID == 0)
				{
					return;
				}
				讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(player.讨伐队队伍ID);
				if (讨伐战队伍类2 == null || 讨伐战队伍类2.队长 != player)
				{
					return;
				}
				foreach (Players value in 讨伐战队伍类2.队员列表.Values)
				{
					if (value != 讨伐战队伍类2.队长)
					{
						value.移动(415f, -25f, 15f, 1201);
					}
				}
			}
			catch
			{
			}
		}

		public static void 委任讨伐队队长(Players player, byte[] data, int legth)
		{
			try
			{
				if (player.讨伐队队伍ID == 0)
				{
					return;
				}
				讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(player.讨伐队队伍ID);
				if (讨伐战队伍类2 == null || 讨伐战队伍类2.队长 != player || 讨伐战队伍类2.队员列表.Count <= 1)
				{
					return;
				}
				byte[] array = new byte[15];
				Buffer.BlockCopy(data, 138, array, 0, 15);
				string text = Encoding.Default.GetString(array).Replace("\0", string.Empty).Trim();
				if (text.Length > 0)
				{
					Players players = World.检查玩家name(text);
					if (players != null)
					{
						讨伐战队伍类2.队长 = players;
						更新讨伐队队员信息(player.讨伐队队伍ID);
					}
				}
			}
			catch
			{
			}
		}

		public static void 强制逐出讨伐队(Players player, byte[] data, int legth)
		{
			try
			{
				if (player.讨伐队队伍ID == 0)
				{
					return;
				}
				讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(player.讨伐队队伍ID);
				if (讨伐战队伍类2 == null || 讨伐战队伍类2.队长 != player)
				{
					return;
				}
				byte[] array = new byte[15];
				Buffer.BlockCopy(data, 138, array, 0, 15);
				string text = Encoding.Default.GetString(array).Replace("\0", string.Empty).Trim();
				if (text.Length <= 0)
				{
					return;
				}
				Players players = World.检查玩家name(text);
				if (players != null)
				{
					讨伐战队伍类2.队员列表.Remove(players.人物全服ID);
					更新讨伐队队员信息(players.讨伐队队伍ID);
					players.讨伐队队伍ID = 0;
					byte[] array2 = Converter.hexStringToByte("AA55AA0011020105A400080029000000000000000000000000000000000000000000000000000000000000000000000000000A00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(players.人物全服ID), 0, array2, 4, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array2, 50, 2);
					if (players.Client != null)
					{
						players.Client.Send(array2, array2.Length);
					}
					byte[] array3 = Converter.hexStringToByte("AA55AA0075050105A40008002A000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(players.人物全服ID), 0, array3, 4, 2);
					if (players.Client != null)
					{
						players.Client.Send(array3, array3.Length);
					}
				}
			}
			catch
			{
			}
		}

		public static void 关闭讨伐队面板(Players player, byte[] data, int legth)
		{
			try
			{
			}
			catch
			{
			}
		}

		public static void 打开讨伐队面板(Players player, byte[] data, int legth)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA55AA0011020105A40008003D0000000100050000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FFFFFFFF0000000000000000000000005323116100000000108F78C9311500001090000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(player.副本剩余次数), 0, array, 18, 4);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
				array = Converter.hexStringToByte("AA55AA0011020105A400080026000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
				array = Converter.hexStringToByte("AA55AA0011020105A400080026000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
					player.系统提示("查看讨伐队目录");
				}
				array = Converter.hexStringToByte("AA55AA0011020105A40008001F000000010001000000000000008C0000000000000009000000000000000B000000000000001E000000000000001E0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				foreach (讨伐战队伍类 value in World.讨伐队伍.Values)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.队伍等级), 0, array, 26, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.队伍转职), 0, array, 34, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.队伍ID), 0, array, 42, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.队员列表.Count), 0, array, 50, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(30), 0, array, 58, 4);
					if (player.Client != null)
					{
						player.Client.Send(array, array.Length);
					}
				}
			}
			catch
			{
			}
		}

		public static void 退出讨伐队(Players player, byte[] data, int legth)
		{
			try
			{
				if (player.讨伐队队伍ID == 0)
				{
					return;
				}
				讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(player.讨伐队队伍ID);
				if (讨伐战队伍类2 == null)
				{
					return;
				}
				讨伐战队伍类2.队员列表.Remove(player.人物全服ID);
				if (讨伐战队伍类2.队长 == player && 讨伐战队伍类2.队员列表.Count > 0)
				{
					using IEnumerator<Players> enumerator = 讨伐战队伍类2.队员列表.Values.GetEnumerator();
					if (enumerator.MoveNext())
					{
						Players players = (讨伐战队伍类2.队长 = enumerator.Current);
					}
				}
				更新讨伐队队员信息(player.讨伐队队伍ID);
				player.讨伐队队伍ID = 0;
				if (讨伐战队伍类2.队员列表.Count < 1)
				{
					World.讨伐队伍.TryRemove(讨伐战队伍类2.队伍ID, out var _);
				}
				byte[] array = Converter.hexStringToByte("AA55AA0011020105A400080029000000000000000000000000000000000000000000000000000000000000000000000000000A00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array, 50, 2);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
				byte[] array2 = Converter.hexStringToByte("AA55AA0075050105A40008002A000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array2, 4, 2);
				if (player.Client != null)
				{
					player.Client.Send(array2, array2.Length);
				}
			}
			catch
			{
			}
		}

		public static void 创建讨伐队(Players player, byte[] data, int legth)
		{
			try
			{
				int num = data[26];
				int num2 = data[34];
				if (player.讨伐队队伍ID == 0 && player.副本剩余次数 != 0)
				{
					讨伐战队伍类 讨伐战队伍类2 = new 讨伐战队伍类
					{
						队长 = player
					};
					讨伐战队伍类2.队员列表.Add(player.人物全服ID, player);
					讨伐战队伍类2.队伍等级 = num;
					讨伐战队伍类2.队伍转职 = num2;
					创建讨伐队(讨伐战队伍类2);
					player.讨伐队队伍ID = 讨伐战队伍类2.队伍ID;
					byte[] array = Converter.hexStringToByte("AA55AA0075050105A40008001E000100010001000000000000008C0000000000000009000000000000000B000000000000001400000000000000320000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000AA00000066B4A66DE614000000000000AA00000006F5A66DE61400001E00000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍等级), 0, array, 26, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍转职), 0, array, 34, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array, 42, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 50, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(World.讨伐副本最多人数), 0, array, 58, 4);
					if (player.Client != null)
					{
						player.Client.Send(array, array.Length);
					}
				}
				else
				{
					player.系统提示("您讨伐次数不足, 无法创建讨伐副本");
				}
			}
			catch
			{
			}
		}

		public static void 查看讨伐队目录(Players player, byte[] data, int legth)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA55AA0011020105A400080026000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
				foreach (讨伐战队伍类 value in World.讨伐队伍.Values)
				{
					array = Converter.hexStringToByte("AA55AA0011020105A40008001F000000010001000000000000008C0000000000000009000000000000000B000000000000001E000000000000001E0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.队伍等级), 0, array, 26, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.队伍转职), 0, array, 34, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.队伍ID), 0, array, 42, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.队员列表.Count), 0, array, 50, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(World.讨伐副本最多人数), 0, array, 58, 4);
					if (player.Client != null)
					{
						player.Client.Send(array, array.Length);
					}
				}
			}
			catch
			{
			}
		}

		public static void 查看讨伐队信息(Players player, byte[] data, int legth)
		{
			try
			{
				int 队伍编号 = data[42];
				讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(队伍编号);
				if (讨伐战队伍类2 == null)
				{
					return;
				}
				byte[] array = Converter.hexStringToByte("AA55AA0011020105A400080029000000000000000000000000000000000000000000000000000000000000000000000000000A00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array, 50, 2);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
				Players players = 讨伐战队伍类2.队长;
				array = Converter.hexStringToByte("AA55AA0075050105A4000800200001000100650000000000000004000000000000009600000000000000020000000000000005000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000C1000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				if (player == 讨伐战队伍类2.队长)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 14, 2);
				}
				else
				{
					Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 14, 2);
				}
				Buffer.BlockCopy(BitConverter.GetBytes(players.副本剩余次数), 0, array, 18, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(players.Player_Job), 0, array, 26, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(players.Player_Level), 0, array, 34, 2);
				if (players == 讨伐战队伍类2.队长)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 42, 2);
				}
				else
				{
					Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 42, 2);
				}
				Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array, 50, 2);
				byte[] bytes = Encoding.Default.GetBytes(players.UserName);
				Buffer.BlockCopy(bytes, 0, array, 138, bytes.Length);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
				foreach (Players value in 讨伐战队伍类2.队员列表.Values)
				{
					if (value != 讨伐战队伍类2.队长)
					{
						array = Converter.hexStringToByte("AA55AA0075050105A4000800200001000100650000000000000004000000000000009600000000000000020000000000000005000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000C1000000000000000000000000000000000000000000000000000000000000000000000055AA");
						Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
						if (player == 讨伐战队伍类2.队长)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 14, 2);
						}
						else
						{
							Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 14, 2);
						}
						Buffer.BlockCopy(BitConverter.GetBytes(value.副本剩余次数), 0, array, 18, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(value.Player_Job), 0, array, 26, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(value.Player_Level), 0, array, 34, 2);
						if (value == 讨伐战队伍类2.队长)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 42, 2);
						}
						else
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 42, 2);
						}
						Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array, 50, 2);
						byte[] bytes2 = Encoding.Default.GetBytes(value.UserName);
						Buffer.BlockCopy(bytes2, 0, array, 138, bytes2.Length);
						if (player.Client != null)
						{
							player.Client.Send(array, array.Length);
						}
					}
				}
			}
			catch
			{
			}
		}

		public static void 加入讨伐队(Players player, byte[] data, int legth)
		{
			try
			{
				int num = data[42];
				if (player.讨伐队队伍ID == 0)
				{
					讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(num);
					if (讨伐战队伍类2 != null)
					{
						player.讨伐队队伍ID = num;
						讨伐战队伍类2.队员列表.Add(player.人物全服ID, player);
						更新讨伐队队员信息(num);
					}
				}
			}
			catch
			{
			}
		}

		public static void 取消参加讨伐(Players player, byte[] data, int legth)
		{
			try
			{
				if (player.讨伐队队伍ID == 0)
				{
					return;
				}
				讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(player.讨伐队队伍ID);
				if (讨伐战队伍类2 != null)
				{
					讨伐战队伍类2.队员列表.Remove(player.人物全服ID);
					更新讨伐队队员信息(player.讨伐队队伍ID);
					player.讨伐队队伍ID = 0;
					if (讨伐战队伍类2.队员列表.Count < 1)
					{
						World.讨伐队伍.TryRemove(讨伐战队伍类2.队伍ID, out var _);
					}
					byte[] array = Converter.hexStringToByte("AA55AA0011020105A400080029000000000000000000000000000000000000000000000000000000000000000000000000000A00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array, 50, 2);
					if (player.Client != null)
					{
						player.Client.Send(array, array.Length);
					}
					byte[] array2 = Converter.hexStringToByte("AA55AA0075050105A40008002A000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array2, 4, 2);
					if (player.Client != null)
					{
						player.Client.Send(array2, array2.Length);
					}
				}
			}
			catch
			{
			}
		}

		public static void 我的讨伐队管理(Players player, byte[] data, int legth)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA55AA0011020105A40008002D000000222800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public static void 查看佣兵大厅(Players player, byte[] data, int legth)
		{
			try
			{
			}
			catch
			{
			}
		}

		public static void 大厅登记(Players player, byte[] data, int legth)
		{
			try
			{
			}
			catch
			{
			}
		}

		public static void 取消登记(Players player, byte[] data, int legth)
		{
			try
			{
			}
			catch
			{
			}
		}

		public static void 更新讨伐队队员信息(int 讨伐队队伍ID)
		{
			try
			{
				讨伐战队伍类 讨伐战队伍类2 = 得到讨伐队伍信息(讨伐队队伍ID);
				if (讨伐战队伍类2 == null)
				{
					return;
				}
				foreach (Players value in 讨伐战队伍类2.队员列表.Values)
				{
					byte[] array = Converter.hexStringToByte("AA55AA0011020105A400080029000000000000000000000000000000000000000000000000000000000000000000000000000A00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(value.人物全服ID), 0, array, 4, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array, 50, 2);
					if (value.Client != null)
					{
						value.Client.Send(array, array.Length);
					}
					foreach (Players value2 in 讨伐战队伍类2.队员列表.Values)
					{
						array = Converter.hexStringToByte("AA55AA0011020105A4000800200000000100030000000000000005000000000000009600000000000000010000000000000002000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000D2000000000000000000000000000000000000000000000000000000000000000000000055AA");
						Buffer.BlockCopy(BitConverter.GetBytes(value.人物全服ID), 0, array, 4, 2);
						Buffer.BlockCopy(BitConverter.GetBytes(value2.副本剩余次数), 0, array, 18, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(value2.Player_Job), 0, array, 26, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(value2.Player_Level), 0, array, 34, 2);
						if (value2 == 讨伐战队伍类2.队长)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 42, 2);
						}
						else
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 42, 2);
						}
						Buffer.BlockCopy(BitConverter.GetBytes(讨伐战队伍类2.队伍ID), 0, array, 50, 2);
						byte[] bytes = Encoding.Default.GetBytes(value2.UserName);
						Buffer.BlockCopy(bytes, 0, array, 138, bytes.Length);
						if (value.Client != null)
						{
							value.Client.Send(array, array.Length);
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
