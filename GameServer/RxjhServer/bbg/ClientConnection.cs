using System;
using System.Net.Sockets;
using System.Text;

namespace RxjhServer.bbg
{
	public class ClientConnection : SockClienT
	{
		public ClientConnection(Socket sock, RemoveClientDelegateE rcd)
			: base(sock, rcd)
		{
		}

		public override void ProcessDataReceived(byte[] data, int length)
		{
			int num = 0;
			if (170 != data[0] || 136 != data[1])
			{
				return;
			}
			byte[] array = new byte[4];
			Buffer.BlockCopy(data, 2, array, 0, 4);
			int num2 = BitConverter.ToInt32(array, 0);
			if (length < num2 + 6)
			{
				return;
			}
			while (true)
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "ProcessDataReceived");
				}
				byte[] array2 = new byte[num2];
				Buffer.BlockCopy(data, num + 6, array2, 0, num2);
				num += num2 + 6;
				DataReceived(array2, num2);
				if (num >= length || data[num] != 170 || data[num + 1] != 102)
				{
					break;
				}
				Buffer.BlockCopy(data, num + 2, array, 0, 4);
				num2 = BitConverter.ToInt16(array, 0);
			}
		}

		public void DataReceived(byte[] data, int length)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "ProcessDataReceived()");
			}
			try
			{
				byte[] array = new byte[length];
				for (int i = 0; i < length; i++)
				{
					array[i] = data[i];
				}
				string @string = Encoding.Default.GetString(array);
				string str = "-1";
				string[] array2 = @string.Split(',');
				switch (array2[0])
				{
				case "用户登陆":
				{
					Players players4 = World.检查玩家(array2[1]);
					str = ((players4 != null) ? "登陆成功" : "登陆失败");
					break;
				}
				case "领取元宝":
				{
					Players players8 = World.检查玩家(array2[1]);
					str = ((players8 != null) ? players8.领取充值奖励(int.Parse(array2[2]), int.Parse(array2[3])) : "-1");
					break;
				}
				case "查询百宝":
				{
					Players players2 = World.检查玩家(array2[1]);
					if (players2 == null)
					{
						str = "-1";
					}
					else if (array2[2] == "热血元宝")
					{
						players2.CheckTreasureGems();
						str = players2.FLD_RXPIONT.ToString();
					}
					else if (array2[2] == "热血钻石")
					{
						players2.CheckTreasureGems();
						str = players2.FLD_RXPIONTX.ToString();
					}
					else if (array2[2] == "抽奖次数")
					{
						players2.CheckTreasureGems();
						str = players2.FLD_CJCS.ToString();
					}
					else if (array2[2] == "空位")
					{
						str = players2.得到包裹空位数().ToString();
					}
					else if (array2[2] == "累计充值")
					{
						str = players2.累计充值.ToString();
					}
					break;
				}
				case "购买百宝":
				{
					Players players6 = World.检查玩家(array2[1]);
					if (int.Parse(array2[4]) >= 0 && int.Parse(array2[3]) >= 1)
					{
						百宝阁类 value2;
						if (players6 == null)
						{
							str = "-1";
						}
						else if (World.百宝阁属性物品类list.TryGetValue(int.Parse(array2[2]), out value2))
						{
							str = players6.百宝阁买卖东西(int.Parse(array2[2]), int.Parse(array2[3]), int.Parse(array2[4]), int.Parse(array2[5]), value2.MAGIC0, value2.MAGIC1, value2.MAGIC2, value2.MAGIC3, value2.MAGIC4, value2.中级魂, value2.觉醒, value2.进化, value2.绑定, value2.使用天数);
						}
					}
					else
					{
						str = "-1";
						players6.Dispose();
					}
					break;
				}
				case "购买寄售":
				{
					Players players3 = World.检查玩家(array2[1]);
					if (long.Parse(array2[4]) >= 0 && int.Parse(array2[3]) >= 1)
					{
						str = ((players3 != null) ? players3.百宝阁寄售买卖(int.Parse(array2[2]), int.Parse(array2[3]), int.Parse(array2[4])) : "-1");
						break;
					}
					str = "-1";
					players3.Dispose();
					break;
				}
				case "删除寄售":
				{
					Players players7 = World.检查玩家(array2[1]);
					str = ((players7 != null) ? players7.百宝阁取消寄售(int.Parse(array2[2]), int.Parse(array2[3])) : "-1");
					break;
				}
				case "百宝阁抽奖":
				{
					Players players5 = World.检查玩家(array2[1]);
					if (long.Parse(array2[4]) >= 0 && int.Parse(array2[3]) >= 1)
					{
						百宝阁类 value;
						if (players5 == null)
						{
							str = "-1";
						}
						else if (World.百宝阁抽奖物品类list.TryGetValue(int.Parse(array2[2]), out value))
						{
							str = players5.百宝阁抽奖(int.Parse(array2[2]), int.Parse(array2[3]), int.Parse(array2[4]), int.Parse(array2[5]), value.MAGIC0, value.MAGIC1, value.MAGIC2, value.MAGIC3, value.MAGIC4, value.中级魂, value.觉醒, value.进化, value.绑定, value.使用天数);
						}
					}
					else
					{
						str = "-1";
						players5.Dispose();
					}
					break;
				}
				case "地图传送":
				{
					Players players = World.检查玩家(array2[1]);
					str = ((players != null) ? players.地图传送(int.Parse(array2[6]), int.Parse(array2[3]), int.Parse(array2[4])) : "-1");
					break;
				}
				default:
					str = "-1";
					break;
				}
				Sendd(str);
			}
			catch (Exception)
			{
				Dispose();
			}
		}
	}
}
