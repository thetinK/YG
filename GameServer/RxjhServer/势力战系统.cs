using System;
using RxjhServer.HelperTools;
using RxjhServer.Network;

namespace RxjhServer
{
	public class 势力战系统
	{
		public static void 势力战风云大战血战分析(Players player, byte[] data, int len)
		{
			try
			{
				player.封包修改(data, len);
				byte[] array = new byte[2];
				Buffer.BlockCopy(data, 12, array, 0, 2);
				short num = BitConverter.ToInt16(array, 0);
				short num2 = num;
				if (num2 == 1)
				{
					势力战数据分析(player, data);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, " 出错 [" + player.Userid + "][" + player.UserName + "] " + ex);
			}
		}

		public static void 势力战数据分析(Players player, byte[] 封包数据)
		{
			player.封包修改(封包数据, 封包数据.Length);
			if (player.人物坐标_地图 == 9001 || player.人物坐标_地图 == 9101 || player.人物坐标_地图 == 9201 || (player.Player死亡 && player.人物坐标_地图 != 801) || player.交易.交易中 || player.退出中 || (player.打开仓库中 ? true : false))
			{
				return;
			}
			Buffer.BlockCopy(BitConverter.GetBytes(0), 0, 封包数据, 3, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, 封包数据, 4, 2);
			byte[] array = new byte[2];
			byte[] array2 = new byte[2];
			Buffer.BlockCopy(封包数据, 10, array, 0, 2);
			Buffer.BlockCopy(封包数据, 18, array2, 0, 2);
			int num = BitConverter.ToInt16(array, 0);
			int num2 = BitConverter.ToInt16(array2, 0);
			switch (BitConverter.ToInt16(array, 0))
			{
			case 1:
				if (player.人物_HP <= 0 || (player.Player死亡 ? true : false))
				{
					return;
				}
				switch (num2)
				{
				case 0:
					player.是否拒绝势力战 = 1;
					player.系统提示("你已经拒绝参加势力战，将无法参加。", 50, "");
					return;
				case 1:
					if (World.eve == null)
					{
						break;
					}
					if (World.势力战进程 < 3 && World.势力战进程 > 0 && player.Player_Job_leve >= World.势力战参加最低转职 && ((player.Player_Job_leve <= World.势力战参加最高转职) ? true : false))
					{
						if (World.申请势力人物列表.ContainsKey(player.UserName))
						{
							break;
						}
						World.申请势力人物列表.TryAdd(player.UserName, player);
						player.系统提示("已经申请参加势力战请等待时间开放自动传送期间不要下线", 50, "");
						if (player.Player_Zx == 1)
						{
							World.势力战正派申请人数++;
						}
						else
						{
							World.势力战邪派申请人数++;
						}
						发送势力战第几名申请数据包(player);
						foreach (Players value3 in World.申请势力人物列表.Values)
						{
							发送势力战申请人数(value3);
						}
					}
					else
					{
						player.系统提示("势力战已经开始或者没有开放暂时无法参加。", 50, "");
					}
					break;
				}
				break;
			case 2:
				if (player.人物_HP <= 0 || (player.Player死亡 ? true : false))
				{
					return;
				}
				if (num2 == 1)
				{
					if (World.eve == null)
					{
						player.系统提示("势力战没有开放暂时无法参加。");
						return;
					}
					if (World.势力战进程 < 3 && ((World.势力战进程 > 0) ? true : false))
					{
						if (player.Player_Job_leve >= World.势力战参加最低转职 && ((player.Player_Job_leve <= World.势力战参加最高转职) ? true : false))
						{
							if (!World.申请势力人物列表.ContainsKey(player.UserName))
							{
								World.申请势力人物列表.TryAdd(player.UserName, player);
								player.系统提示("已经申请参加势力战请等待时间开放自动传送期间不要下线", 50, "");
								if (player.Player_Zx == 1)
								{
									World.势力战正派申请人数++;
								}
								else
								{
									World.势力战邪派申请人数++;
								}
								发送势力战第几名申请数据包(player);
								foreach (Players value4 in World.申请势力人物列表.Values)
								{
									发送势力战申请人数(value4);
								}
							}
							if (player.Player_Zx == 1)
							{
								World.势力战正派参战人数++;
								player.移动(545f, 0f, 15f, 801);
							}
							else
							{
								World.势力战邪派参战人数++;
								player.移动(-565f, 0f, 15f, 801);
							}
							if (!World.EventTop.TryGetValue(player.UserName, out var _))
							{
								EventTopClass value2 = new EventTopClass
								{
									人物名 = player.UserName,
									等级 = player.Player_Level,
									势力 = player.Player_Zx,
									帮派 = player.帮派名字,
									全服ID = player.人物全服ID
								};
								World.EventTop.TryAdd(player.UserName, value2);
							}
						}
						else
						{
							player.系统提示("不符合势力战的转职要求，请等待相应转职的势力战开启。");
						}
					}
					else
					{
						player.系统提示("势力战已经开始暂时无法参加。");
					}
				}
				else
				{
					player.是否拒绝势力战 = 1;
					player.系统提示("你已经拒绝参加势力战，将无法参加。", 50, "");
				}
				break;
			case 3:
				if (player.人物_HP <= 0 || (player.Player死亡 ? true : false))
				{
					return;
				}
				if (BitConverter.ToInt16(array2, 0) != 1)
				{
					break;
				}
				if (player.人物坐标_地图 == 801)
				{
					return;
				}
				if (player.Player_Job_leve >= 2 && player.人物坐标_地图 != 801 && ((player.是否拒绝势力战 == 0) ? true : false))
				{
					player.是否拒绝势力战 = 1;
					Buffer.BlockCopy(BitConverter.GetBytes(2), 0, 封包数据, 10, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(2), 0, 封包数据, 14, 2);
					switch (player.Player_Zx)
					{
					case 1:
						World.势力战正派参战人数++;
						if (World.是否开启共用银币市场 == 1)
						{
							player.换线移动(520f, 0f, 15f, 801);
						}
						else
						{
							player.移动(520f, 0f, 15f, 801);
						}
						break;
					case 2:
						World.势力战邪派参战人数++;
						if (World.是否开启共用银币市场 == 1)
						{
							player.换线移动(-565f, 0f, 15f, 801);
						}
						else
						{
							player.移动(-565f, 0f, 15f, 801);
						}
						break;
					}
				}
				else
				{
					Buffer.BlockCopy(array, 0, 封包数据, 10, 2);
					Buffer.BlockCopy(array, 0, 封包数据, 14, 2);
				}
				break;
			case 4:
				if (player.人物坐标_地图 != 801)
				{
					return;
				}
				if (player.人物_HP > 0 && !player.Player死亡)
				{
					break;
				}
				switch (BitConverter.ToInt16(array2, 0))
				{
				case 1:
					if (player.Player_Zx == 1)
					{
						player.死亡移动(545f, 0f, 15f, 801);
					}
					else
					{
						player.死亡移动(-565f, 0f, 15f, 801);
					}
					break;
				case 2:
					if (player.Player_Zx == 1)
					{
						player.死亡移动(158f, 0f, 15f, 801);
					}
					else
					{
						player.死亡移动(-158f, 0f, 15f, 801);
					}
					break;
				}
				player.人物_HP = player.人物最大_HP;
				player.更新HP_MP_SP();
				player.Player死亡 = false;
				break;
			case 9:
				发送势力战战绩(player);
				break;
			case 11:
				if (player.人物坐标_地图 == 801)
				{
					if (World.是否开启共用银币市场 == 1 && ((World.当前是否是银币线路 == 1) ? true : false))
					{
						player.移动(10f, 10f, 15f, 1201);
					}
					else
					{
						player.移动(499f, 2215f, 15f, 101);
					}
					if (player.Player死亡 || ((player.人物_HP <= 0) ? true : false))
					{
						player.人物_HP = player.人物最大_HP;
						player.更新HP_MP_SP();
						player.Player死亡 = false;
					}
					player.获取复查范围玩家();
					player.获取复查范围Npc();
					player.获取复查范围地面物品();
				}
				break;
			default:
				Buffer.BlockCopy(array, 0, 封包数据, 10, 2);
				Buffer.BlockCopy(array, 0, 封包数据, 14, 2);
				break;
			}
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, 封包数据, 4, 2);
			if (player.Client != null)
			{
				player.Client.Send(封包数据, 封包数据.Length);
			}
		}

		public static void 发送势力战系统封包(Players player, int 邀请类型, int 势力战类型, int 类型)
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write4(势力战类型);
			发包类.Write2(1);
			if (邀请类型 == 14)
			{
				发包类.Write2(70);
			}
			else if (邀请类型 == 3 && 类型 == 11)
			{
				发包类.Write2(类型);
			}
			else
			{
				发包类.Write2(70);
			}
			发包类.Write4(0);
			if (邀请类型 == 1 && 类型 == 2)
			{
				发包类.Write4(2);
			}
			else if (邀请类型 == 1 && 类型 != 2)
			{
				发包类.Write4(1);
			}
			else
			{
				发包类.Write4(邀请类型);
			}
			if (邀请类型 == 3 && 类型 == 11)
			{
				发包类.Write4(World.势力战正分数);
				发包类.Write4(World.势力战邪分数);
				发包类.Write4(World.势力战正派参战人数);
				发包类.Write4(World.势力战邪派参战人数);
			}
			else if (邀请类型 == 1 && 类型 == 2)
			{
				发包类.Write4(8);
				发包类.Write4(8);
				发包类.Write4(3636);
				发包类.Write4(0);
			}
			else if (邀请类型 == 1 && 类型 != 2)
			{
				发包类.Write4(8);
				发包类.Write4(8);
				发包类.Write4(3635);
				发包类.Write4(0);
			}
			else
			{
				发包类.Write4(类型);
				发包类.Write4(0);
				发包类.Write4(0);
				发包类.Write4(0);
			}
			发包类.Write4(0);
			发包类.Write2(0);
			if (player.Client != null)
			{
				player.Client.SendPak(发包类, 4898, player.人物全服ID);
			}
			byte[] bytes = 发包类.ToArray2(4898, player.人物全服ID);
			string value = Converter.ToString(bytes);
			Console.WriteLine(value);
		}

		public static void 发送势力战快开始消息(Players player, int int_109)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA5536000F2713223000090001001D000000010000000C0000009E0000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(int_109), 0, array, 26, 2);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public static void 发送势力战人数及分数(Players player)
		{
			byte[] array = Converter.hexStringToByte("AA552E000F2713222000010001000B00000001000000030000000500000005000000620F000000000000000000000000BD8455AA");
			Buffer.BlockCopy(BitConverter.GetBytes(World.势力战正派参战人数), 0, array, 26, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(World.势力战邪派参战人数), 0, array, 30, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(World.势力战正分数), 0, array, 34, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(World.势力战邪分数), 0, array, 38, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(3), 0, array, 22, 1);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 发送势力战战绩(Players player)
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write2(World.EventTop.Count);
				发包类.Write2(0);
				发包类.Write2(0);
				发包类.Write2(0);
				foreach (EventTopClass value in World.EventTop.Values)
				{
					if (value.势力 == 1)
					{
						发包类.Write1(1);
					}
					else if (value.势力 == 2)
					{
						发包类.Write1(2);
					}
					发包类.WriteString(value.人物名, 15);
					发包类.Write2(value.等级);
					发包类.Write2(value.杀人数);
					发包类.Write2(value.死亡数);
					发包类.Write2(value.玩家杀怪分数);
					发包类.Write2(value.玩家杀人分数 + value.玩家杀怪分数);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write2(0);
				}
				if (player.Client != null)
				{
					player.Client.SendPak(发包类, 5410, player.人物全服ID);
				}
			}
			catch
			{
			}
		}

		public static void 发送势力战自动开PK模式数据(Players player)
		{
			player.人物PK模式 = 1;
			string hex = "AA5536000F2713223000030001001D0000000100000000000000000000000000000000000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 发送势力战开始数据(Players player)
		{
			string hex = "AA5536000F27132230000A000100160000000100000008000000010000000000000000000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 关闭势力战提示(Players player)
		{
			string hex = "AA5536000F2713223000040001000A000000010000000E000000010000000100000000000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 发送势力战五分钟后开始数据包(Players player)
		{
			string hex = "AA5536000F2713223000010001001D0000000100000002000000030000000A000000340E0000F00000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 发送势力战剩余时间(Players player, int 剩余时间)
		{
			string hex = "AA5536000F2713223000080001001600000001000000430E000001000000010000000D000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			Buffer.BlockCopy(BitConverter.GetBytes(剩余时间), 0, array, 34, 4);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 发送势力战参与度低被踢出消息(Players player)
		{
			string hex = "AA5536000F2713223000020001000A000000010000000E000000010000000100000000000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 发送势力战第几名申请数据包(Players player)
		{
			string hex = "AA5536000F2713223000080001000100000001000000320E0000000000000100000009000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			Buffer.BlockCopy(BitConverter.GetBytes(World.申请势力人物列表.Count), 0, array, 34, 4);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 发送势力战申请人数(Players player)
		{
			string hex = "AA5536000F2713223000080001000100000001000000440E0000000000000200000010000000150000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(World.势力战正派申请人数), 0, array, 34, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(World.势力战邪派申请人数), 0, array, 38, 4);
			if (player.Client != null)
			{
				player.Client.Send(array, array.Length);
			}
		}

		public static void 发送势力战消息1(Players player)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA551D005400B7000F000212270300000064000000640002000000000000008E1B55AA");
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

		public static void 发送势力战消息2(Players player)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA551B00A205BA000D000303271806FFFF0000FFFF000000000000000059DF55AA");
				Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 10, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(World.势力战战斗时间), 0, array, 13, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(World.势力战正分数), 0, array, 15, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(World.势力战邪分数), 0, array, 19, 4);
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

		public static void 发送势力战结束消息新(Players player, int 参数势力战胜利状态)
		{
			try
			{
				string hex = "AA5536000F2713223000040001000F00000001000000010000000500000005000000330E0000000000000000000000000000000000000000000055AA";
				byte[] array = Converter.hexStringToByte(hex);
				switch (参数势力战胜利状态)
				{
				case 1:
					if (player.Player_Zx == 1)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 22, 1);
					}
					else
					{
						Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 22, 1);
					}
					break;
				case 2:
					if (player.Player_Zx == 1)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 22, 1);
					}
					else
					{
						Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 22, 1);
					}
					break;
				case 3:
					Buffer.BlockCopy(BitConverter.GetBytes(3), 0, array, 22, 1);
					break;
				}
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(World.势力战进程), 0, array, 10, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(World.势力战正分数), 0, array, 34, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(World.势力战邪分数), 0, array, 38, 4);
				if (player.Client != null)
				{
					player.Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public static void 发送势力战关闭消息旧(Players player)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA551B00A205BA000D0006132700000000000000000000000000000000AC4155AA");
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
	}
}
