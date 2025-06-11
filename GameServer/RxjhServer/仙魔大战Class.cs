using System;
using System.Data;
using System.Timers;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class 仙魔大战Class : IDisposable
	{
		private string jlsqlzj = string.Empty;

		private System.Timers.Timer 时间1;

		private System.Timers.Timer 时间2;

		private System.Timers.Timer 时间3;

		private System.Timers.Timer 时间4;

		private System.Timers.Timer 时间5;

		private readonly DateTime kssj;

		private DateTime kssjgj;

		private int kssjint;

		private int 仙魔大战sj;

		public 仙魔大战Class()
		{
			try
			{
				World.仙魔Top.Clear();
				if (World.势力战开始时向其它线广播 == 1)
				{
					if (World.ServerID == 28)
					{
						string text = World.仙魔大战预备时间 + "分钟后将在[银币市场], 开启仙魔大战.请要参加的玩家前往[银币市场]参加";
						World.conn.发送("全线公告|" + 0 + "|" + text + "|仙魔大战");
					}
					else
					{
						string text2 = World.仙魔大战预备时间 + "分钟后将在" + World.ServerID + "线, 开启仙魔大战.请要参加的玩家前往" + World.ServerID + "线参加";
						World.conn.发送("全线公告|" + 0 + "|" + text2 + "|仙魔大战");
					}
				}
				kssj = DateTime.Now.AddMinutes(World.仙魔大战预备时间);
				World.仙魔大战进程 = 1;
				World.仙魔大战正分数 = 0;
				World.仙魔大战邪分数 = 0;
				时间1 = new System.Timers.Timer(20000.0);
				时间1.Elapsed += 时间结束事件1;
				时间1.Enabled = true;
				时间1.AutoReset = true;
				时间结束事件1(null, null);
				World.conn.发送("仙魔大战进程|" + World.仙魔大战进程);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "仙魔大战 EventClass 出错：" + ex);
			}
		}

		public void 时间结束事件1(object source, ElapsedEventArgs e)
		{
			try
			{
				int num = (int)kssj.Subtract(DateTime.Now).TotalSeconds;
				if (num <= 0)
				{
					World.仙魔大战进程 = 2;
					World.仙魔大战正分数 = 0;
					World.仙魔大战邪分数 = 0;
					World.conn.发送("仙魔大战进程|" + World.仙魔大战进程);
					num = 0;
				}
				kssjint = num;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (World.势力战开始时向其它线广播 == 1)
					{
						if (World.ServerID == 28)
						{
							string text = num + "秒后将在[银币市场], 开启仙魔大战.请要参加的玩家前往[银币市场]参加";
							World.conn.发送("全线提示|" + 6 + "|" + text + "|" + World.ServerID);
						}
						else
						{
							string text2 = num + "秒后将在" + World.ServerID + "线, 开启仙魔大战.请要参加的玩家前往" + World.ServerID + "线参加";
							World.conn.发送("全线提示|" + 6 + "|" + text2 + "|" + World.ServerID);
						}
					}
					if (value.人物坐标_地图 == 41001)
					{
						value.发送仙魔大战开始倒计时(kssjint);
					}
					if (!World.申请仙魔大战人物列表.ContainsKey(value.UserName))
					{
						if (value.Player_Level >= World.仙魔大战进入等级 && value.人物坐标_地图 != 41001 && value.是否拒绝仙魔大战 != 1)
						{
							value.发送仙魔大战邀请新();
							if (kssjint / 60 != 0)
							{
								value.系统提示("离仙魔大战开始及参加申请还剩下" + kssjint + "秒。请点此报名", 50, "系统提示");
							}
							else
							{
								value.系统提示("仙魔大战离开始不足" + kssjint + "秒。请尽快报名", 50, "系统提示");
							}
						}
					}
					else if (kssjint / 60 != 0)
					{
						value.系统提示("离仙魔大战开始及参加还剩下" + kssjint + "秒。你已经报名不要下线", 50, "系统提示");
					}
					else
					{
						value.系统提示("仙魔大战离开始不足" + kssjint + "秒。你已经报名不要下线", 50, "系统提示");
					}
				}
				if (kssjint > 0)
				{
					return;
				}
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				bool flag = true;
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					switch (num2)
					{
					case 0:
						num3 = -100;
						num4 = 150;
						break;
					case 1:
						num3 = -100;
						num4 = -250;
						break;
					case 2:
						num3 = 100;
						num4 = -50;
						break;
					case 3:
						num3 = -250;
						num4 = -50;
						break;
					}
					if (value2.人物坐标_地图 == 41001)
					{
						value2.移动(num3, num4, 15f, 41001);
						value2.切换PK模式(1);
						flag = false;
					}
					num2++;
					if (num2 >= 4)
					{
						num2 = 0;
					}
				}
				if (flag)
				{
					Dispose();
					return;
				}
				时间1.Enabled = false;
				时间1.Close();
				时间1.Dispose();
				World.仙魔大战进程 = 3;
				World.conn.发送("仙魔大战进程|" + World.仙魔大战进程);
				kssjgj = DateTime.Now.AddMinutes(World.仙魔大战时长);
				时间2 = new System.Timers.Timer(10000.0);
				时间2.Elapsed += 时间结束事件2;
				时间2.Enabled = true;
				时间2.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "仙魔大战 时间结束事件1 出错：" + ex);
			}
		}

		public void 时间结束事件2(object source, ElapsedEventArgs e)
		{
			try
			{
				int num = (World.仙魔大战时间 = (int)kssjgj.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 41001)
					{
						value.发送仙魔大战消息2();
						value.倒计时提示(num);
					}
				}
				if (num <= 0)
				{
					时间2.Enabled = false;
					时间2.Close();
					时间2.Dispose();
					World.仙魔大战进程 = 4;
					World.conn.发送("仙魔大战进程|" + World.仙魔大战进程);
					时间3 = new System.Timers.Timer(30000.0);
					时间3.Elapsed += 时间结束事件3;
					时间3.Enabled = true;
					时间3.AutoReset = false;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "仙魔大战 时间结束事件2 出错：" + ex);
			}
		}

		public void 时间结束事件3(object source, ElapsedEventArgs e)
		{
			try
			{
				DBA.ExeSqlCommand("DELETE FROM 仙魔大战Top where 分区信息='" + World.ZoneNumber + "'");
				foreach (仙魔大战top value in World.仙魔Top.Values)
				{
					try
					{
						DBA.ExeSqlCommand($"INSERT INTO 仙魔大战Top (人物名, 帮派, 势力, 等级, 杀人数, 死亡数, 分区信息)values('{value.人物名}','{value.帮派}','{value.势力}', {value.等级}, {value.杀人数}, {value.死亡数}, '{World.ZoneNumber}')");
						Players players = World.检查玩家name(value.人物名);
						int num = 1;
						if (players != null)
						{
							num = players.Player_Zx;
						}
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "仙魔大战 Set个人荣誉数据() 出错：" + ex);
					}
				}
				World.仙魔Top.Clear();
				if (World.仙魔大战正分数 > World.仙魔大战邪分数)
				{
					仙魔大战sj = 1;
					jlsqlzj = "仙族";
					World.发送游戏特殊公告("仙魔大战结束仙族胜利", 6, "公告");
				}
				else if (World.仙魔大战正分数 == World.仙魔大战邪分数)
				{
					仙魔大战sj = 3;
					jlsqlzj = string.Empty;
					World.发送游戏特殊公告("仙魔大战结束双方平局", 6, "公告");
				}
				else
				{
					仙魔大战sj = 2;
					jlsqlzj = "魔族";
					World.发送游戏特殊公告("仙魔大战结束魔族胜利", 6, "公告");
				}
				try
				{
					foreach (Players value2 in World.AllConnectedPlayers.Values)
					{
						if (value2.人物坐标_地图 != 41001)
						{
							continue;
						}
						value2.发送仙魔大战结束消息(仙魔大战sj);
						if (jlsqlzj != string.Empty)
						{
							if (value2.仙魔大战派别 == jlsqlzj)
							{
								value2.活动奖励系统(1);
								int num2 = value2.得到包裹空位(value2);
								if (num2 != -1)
								{
									value2.增加物品(BitConverter.GetBytes(RxjhClass.GetDBItmeId()), BitConverter.GetBytes(1008000388), num2, BitConverter.GetBytes(1), new byte[56]);
									value2.系统提示("获得[胜利的庆祝]道具[30分钟经验300%]。");
								}
								else
								{
									value2.系统提示("背包没空位了。");
								}
							}
							else
							{
								value2.活动奖励系统(2);
								int num3 = value2.得到包裹空位(value2);
								if (num3 != -1)
								{
									value2.增加物品(BitConverter.GetBytes(RxjhClass.GetDBItmeId()), BitConverter.GetBytes(1008000389), num3, BitConverter.GetBytes(1), new byte[56]);
									value2.系统提示("获得[崛起的斗志]道具[30分钟经验150%]。");
								}
								else
								{
									value2.系统提示("背包没空位了。");
								}
							}
						}
						else
						{
							value2.活动奖励系统(5);
						}
					}
				}
				catch (Exception ex2)
				{
					MainForm.WriteLine(1, "仙魔大战 奖励随机盒子 出错：" + ex2);
				}
				try
				{
					奖励前三名();
				}
				catch (Exception ex3)
				{
					MainForm.WriteLine(1, "仙魔大战 奖励前三名() 出错：" + ex3);
				}
				World.仙魔大战进程 = 5;
				foreach (Players value3 in World.AllConnectedPlayers.Values)
				{
					if (value3.人物坐标_地图 == 41001 && jlsqlzj != string.Empty)
					{
						value3.系统提示("请胜方[" + jlsqlzj + "]等待30秒，准备好击杀超级BOSS, 五分钟内没击杀死自动传送出去。");
					}
				}
				World.conn.发送("仙魔大战进程|" + World.仙魔大战进程);
				kssjgj = DateTime.Now.AddSeconds(330.0);
				时间3.Enabled = false;
				时间3.Close();
				时间3.Dispose();
				时间4 = new System.Timers.Timer(15000.0);
				时间4.Elapsed += 时间结束事件4;
				时间4.Enabled = true;
				时间4.AutoReset = true;
				时间5 = new System.Timers.Timer(15000.0);
				时间5.Elapsed += 时间结束事件5;
				时间5.Enabled = true;
				时间5.AutoReset = true;
			}
			catch (Exception ex4)
			{
				MainForm.WriteLine(1, "仙魔大战 时间结束事件3 出错：" + ex4);
			}
		}

		public void 奖励前三名()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("Select TOP 1 * from 仙魔大战Top where 分区信息='" + World.ZoneNumber + "'Order By 杀人数 Desc");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					Players players = World.检查玩家name(dBToDataTable.Rows[i]["人物名"].ToString());
					if (players != null && i == 0)
					{
						int num = players.得到包裹空位(players);
						if (num != -1)
						{
							players.增加物品(BitConverter.GetBytes(RxjhClass.GetDBItmeId()), BitConverter.GetBytes(World.第一名奖励礼包), num, BitConverter.GetBytes(1), new byte[56]);
							players.系统提示("仙魔大战第一名奖励礼包。");
						}
						else
						{
							players.系统提示("背包没空位了。");
						}
					}
				}
			}
			dBToDataTable.Dispose();
		}

		public void 时间结束事件4(object source, ElapsedEventArgs e)
		{
			try
			{
				int num = (World.仙魔大战时间 = (int)kssjgj.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 41001 && value.仙魔大战派别 != jlsqlzj)
					{
						value.仙魔大战派别 = string.Empty;
						value.仙魔大战杀人数 = 0;
						value.仙魔大战死亡数 = 0;
						value.移动(-5f, -8f, 15f, 1201);
						value.切换PK模式(0);
					}
				}
				if (num > 0)
				{
					foreach (Players value2 in World.AllConnectedPlayers.Values)
					{
						if (value2.人物坐标_地图 == 41001)
						{
							value2.系统提示("仙魔大战[获胜方]还剩[" + num + "]秒传出.请速度击杀BOSS获得极品奖励....", 3, "系统提示");
						}
					}
					return;
				}
				时间4.Enabled = false;
				时间4.Close();
				时间4.Dispose();
				World.仙魔大战进程 = 6;
				World.conn.发送("仙魔大战进程|" + World.仙魔大战进程);
				foreach (Players value3 in World.AllConnectedPlayers.Values)
				{
					if (value3.人物坐标_地图 == 41001)
					{
						value3.仙魔大战派别 = string.Empty;
						value3.仙魔大战杀人数 = 0;
						value3.仙魔大战死亡数 = 0;
						value3.移动(-5f, -8f, 15f, 1201);
						value3.切换PK模式(0);
					}
				}
				Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "仙魔大战 时间结束事件4 出错：" + ex);
			}
		}

		public void 时间结束事件5(object source, ElapsedEventArgs e)
		{
			try
			{
				时间5.Enabled = false;
				时间5.Close();
				时间5.Dispose();
				World.AddNpc(15526, -100f, -50f, 41001);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "仙魔大战时间结束事件5 出错：" + ex);
			}
		}

		public void Dispose()
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 41001)
					{
						value.仙魔大战派别 = string.Empty;
						value.仙魔大战杀人数 = 0;
						value.仙魔大战死亡数 = 0;
						value.移动(-5f, -50f, 15f, 1201);
						value.切换PK模式(0);
					}
				}
				World.仙魔大战进程 = 0;
				World.仙魔大战时间 = 0;
				World.仙魔大战正分数 = 0;
				World.仙魔大战邪分数 = 0;
				World.仙魔大战正人数 = 0;
				World.仙魔大战邪人数 = 0;
				World.conn.发送("仙魔大战进程|" + World.仙魔大战进程);
				World.conn.发送("仙魔大战人数|" + World.仙魔大战正人数 + "|" + World.仙魔大战邪人数);
				if (World.仙魔大战掉线玩家.Count > 0)
				{
					World.仙魔大战掉线玩家.Clear();
				}
				if (时间1 != null)
				{
					时间1.Enabled = false;
					时间1.Close();
					时间1.Dispose();
					时间1 = null;
				}
				if (时间2 != null)
				{
					时间2.Enabled = false;
					时间2.Close();
					时间2.Dispose();
					时间2 = null;
				}
				if (时间3 != null)
				{
					时间3.Enabled = false;
					时间3.Close();
					时间3.Dispose();
					时间3 = null;
				}
				if (时间4 != null)
				{
					时间4.Enabled = false;
					时间4.Close();
					时间4.Dispose();
					时间4 = null;
				}
				if (时间5 != null)
				{
					时间5.Enabled = false;
					时间5.Close();
					时间5.Dispose();
					时间5 = null;
				}
				World.申请仙魔大战人物列表.Clear();
				if (World.ImmortalDemonWar != null)
				{
					World.delBoss(41001, 15526);
					World.ImmortalDemonWar = null;
					string text = "仙魔大战活动已经结束";
					World.conn.发送("全线公告|" + 1 + "|" + text + "|仙魔大战");
					DBA.ExeSqlCommand("DELETE FROM TBL_仙魔大战");
				}
			}
			catch
			{
				MainForm.WriteLine(1, "仙魔大战时间结束事件6 出错：");
			}
		}
	}
}
