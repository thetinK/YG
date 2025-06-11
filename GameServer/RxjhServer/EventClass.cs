using System;
using System.Collections.Generic;
using System.Data;
using System.Timers;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class EventClass : IDisposable
	{
		private readonly DateTime dateTime_0;

		private DateTime dateTime_1;

		public DateTime 势力战进行中结束时间;

		public int 势力战胜利状态;

		private System.Timers.Timer timer_0;

		private System.Timers.Timer timer_1;

		private System.Timers.Timer timer_2;

		private System.Timers.Timer timer_3;

		private System.Timers.Timer timer_4;

		private List<NpcClass> list_0;

		public EventClass()
		{
			list_0 = new List<NpcClass>();
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "EventClass-");
				}
				World.势力战正派申请人数 = 0;
				World.势力战正派参战人数 = 0;
				World.势力战正分数 = 0;
				World.势力战邪派申请人数 = 0;
				World.势力战邪派参战人数 = 0;
				World.势力战邪分数 = 0;
				World.申请势力人物列表.Clear();
				World.EventTop.Clear();
				World.势力战进程 = 1;
				if (World.势力战开始时向其它线广播 == 1)
				{
					if (World.ServerID == 28)
					{
						string text = World.势力战预备时间 + "分钟后将在[银币市场], 开启" + World.势力战参加最低转职 + "～" + World.势力战参加最高转职 + "转势力战.请要参加的玩家前往[银币市场]参加";
						World.conn.发送("全线公告|" + 0 + "|" + text + "|势力战");
					}
					else
					{
						string text2 = World.势力战预备时间 + "分钟后将在" + World.ServerID + "线, 开启" + World.势力战参加最低转职 + "～" + World.势力战参加最高转职 + "转势力战.请要参加的玩家前往" + World.ServerID + "线参加";
						World.conn.发送("全线公告|" + 0 + "|" + text2 + "|势力战");
					}
				}
				dateTime_0 = DateTime.Now.AddMinutes(World.势力战预备时间);
				timer_0 = new System.Timers.Timer(10000.0);
				timer_0.Elapsed += 时间0结束事件;
				timer_0.Enabled = true;
				timer_0.AutoReset = true;
				势力战胜利状态 = 0;
				时间0结束事件(null, null);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "势力战 EventClass 出错：" + ex);
			}
		}

		public void Dispose()
		{
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "EventClass-Dispose");
				}
				if (World.EventTop != null)
				{
					World.EventTop.Clear();
				}
				World.势力战进程 = 0;
				World.势力战正分数 = 0;
				World.势力战邪分数 = 0;
				World.势力战正派参战人数 = 0;
				World.势力战正派申请人数 = 0;
				World.势力战邪派参战人数 = 0;
				World.势力战邪派申请人数 = 0;
				if (timer_0 != null)
				{
					timer_0.Enabled = false;
					timer_0.Close();
					timer_0.Dispose();
					timer_0 = null;
				}
				if (timer_1 != null)
				{
					timer_1.Enabled = false;
					timer_1.Close();
					timer_1.Dispose();
					timer_1 = null;
				}
				if (timer_2 != null)
				{
					timer_2.Enabled = false;
					timer_2.Close();
					timer_2.Dispose();
					timer_2 = null;
				}
				if (timer_3 != null)
				{
					timer_3.Enabled = false;
					timer_3.Close();
					timer_3.Dispose();
					timer_3 = null;
				}
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 801)
					{
						value.移出势力战();
					}
				}
				World.申请势力人物列表.Clear();
				if (list_0 != null)
				{
					foreach (NpcClass item in list_0)
					{
						World.删除指定地图指定类型怪物(801, item.FLD_PID);
					}
					list_0.Clear();
					list_0 = null;
				}
				World.eve = null;
				string text = "势力战活动已经结束";
				World.conn.发送("全线公告|" + 1 + "|" + text + "|势力战");
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "势力战结束出错:" + ex.Message);
			}
		}

		public void 时间0结束事件(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass_时间结束事件1");
			}
			try
			{
				int num = (int)dateTime_0.Subtract(DateTime.Now).TotalSeconds;
				if (num > 0)
				{
					if (World.势力战开始时向其它线广播 == 1)
					{
						if (World.ServerID == 28)
						{
							string text = num + "秒后将在[银币市场], 开启" + World.势力战参加最低转职 + "～" + World.势力战参加最高转职 + "转势力战.请要参加的玩家前往[银币市场]参加";
							World.conn.发送("全线提示|" + 6 + "|" + text + "|" + World.ServerID);
						}
						else
						{
							string text2 = num + "秒后将在" + World.ServerID + "线, 开启" + World.势力战参加最低转职 + "～" + World.势力战参加最高转职 + "转势力战.请要参加的玩家前往" + World.ServerID + "线参加";
							World.conn.发送("全线提示|" + 6 + "|" + text2 + "|" + World.ServerID);
						}
					}
					foreach (Players value in World.AllConnectedPlayers.Values)
					{
						if (!World.申请势力人物列表.ContainsKey(value.UserName))
						{
							if (value.Player_Job_leve >= World.势力战参加最低转职 && value.Player_Job_leve <= World.势力战参加最高转职 && value.是否拒绝势力战 != 1 && !value.Client.挂机 && !value.Client.假人)
							{
								势力战系统.发送势力战五分钟后开始数据包(value);
								if (num / 60 != 0)
								{
									value.系统提示("离势力大战开始及参加申请还剩下" + num / 60 + "分钟。请点此报名", 50, "");
								}
								else
								{
									value.系统提示("势力大战离开始不足一分钟。请尽快报名", 50, "");
								}
							}
						}
						else if (num / 60 != 0)
						{
							value.系统提示("离势力大战开始及参加还剩下" + num / 60 + "分钟。你已经报名不要下线", 50, "");
						}
						else
						{
							value.系统提示("势力大战离开始不足一分钟。你已经报名不要下线", 50, "");
						}
					}
				}
				else
				{
					World.势力战进程 = 2;
					World.势力战正分数 = 0;
					World.势力战邪分数 = 0;
					timer_0.Enabled = false;
					timer_0.Close();
					timer_0.Dispose();
					dateTime_1 = DateTime.Now.AddMinutes(World.势力战预备时间);
					timer_1 = new System.Timers.Timer(10000.0);
					timer_1.Elapsed += 时间1结束事件;
					timer_1.Enabled = true;
					timer_1.AutoReset = true;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "势力战 时间结束事件0 出错：" + ex);
			}
		}

		public void 时间1结束事件(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass_时间结束事件1");
			}
			try
			{
				int num = (int)dateTime_1.Subtract(DateTime.Now).TotalSeconds;
				if (num > 0)
				{
					foreach (Players value in World.AllConnectedPlayers.Values)
					{
						if (value.是否拒绝势力战 != 0 || value.Player_Job_leve < World.势力战参加最低转职 || value.Player_Job_leve > World.势力战参加最高转职 || value.Client.挂机 || value.Client.假人)
						{
							continue;
						}
						if (World.申请势力人物列表.ContainsKey(value.UserName))
						{
							if (value.人物坐标_地图 == 801)
							{
								势力战系统.发送势力战战绩(value);
								势力战系统.发送势力战快开始消息(value, num);
							}
						}
						else
						{
							势力战系统.发送势力战五分钟后开始数据包(value);
						}
					}
					return;
				}
				foreach (Players value2 in World.申请势力人物列表.Values)
				{
					if (value2.人物坐标_地图 == 801)
					{
						if (value2.Player_Zx == 1)
						{
							World.势力战正派参战人数++;
						}
						else
						{
							World.势力战邪派参战人数++;
						}
						势力战系统.发送势力战开始数据(value2);
						势力战系统.发送势力战自动开PK模式数据(value2);
						value2.更新人物数据(value2);
					}
				}
				timer_1.Enabled = false;
				timer_1.Close();
				timer_1.Dispose();
				World.势力战进程 = 3;
				if (World.势力战类型 == 1)
				{
					NpcClass item = World.AddNpc(15450, 190f, 40f, 801, 0, 0, 一次性怪: false, 10);
					list_0.Add(item);
					item = World.AddNpc(15451, 190f, 10f, 801, 0, 0, 一次性怪: false, 10);
					list_0.Add(item);
					item = World.AddNpc(15452, -190f, 40f, 801, 0, 0, 一次性怪: false, 10);
					list_0.Add(item);
					item = World.AddNpc(15453, -190f, 10f, 801, 0, 0, 一次性怪: false, 10);
					list_0.Add(item);
				}
				else
				{
					NpcClass item2 = World.AddNpc(15491, 190f, 40f, 801, 0, 0, 一次性怪: false, 10);
					list_0.Add(item2);
					item2 = World.AddNpc(15492, 190f, 10f, 801, 0, 0, 一次性怪: false, 10);
					list_0.Add(item2);
					item2 = World.AddNpc(15493, -190f, 40f, 801, 0, 0, 一次性怪: false, 10);
					list_0.Add(item2);
					item2 = World.AddNpc(15494, -190f, 10f, 801, 0, 0, 一次性怪: false, 10);
					list_0.Add(item2);
				}
				势力战进行中结束时间 = DateTime.Now.AddMinutes(World.势力战战斗时间);
				timer_2 = new System.Timers.Timer(10000.0);
				timer_2.Elapsed += 时间2结束事件;
				timer_2.Enabled = true;
				timer_2.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "势力战 时间结束事件1 出错：" + ex);
			}
		}

		public void 时间2结束事件(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass_时间结束事件2");
			}
			try
			{
				int num = (int)势力战进行中结束时间.Subtract(DateTime.Now).TotalSeconds;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 801)
					{
						势力战系统.发送势力战人数及分数(value);
						势力战系统.发送势力战战绩(value);
						势力战系统.发送势力战剩余时间(value, num / 60);
						势力战系统.发送势力战自动开PK模式数据(value);
					}
				}
				if (num <= 0)
				{
					timer_2.Enabled = false;
					timer_2.Close();
					timer_2.Dispose();
					timer_2 = null;
					World.势力战进程 = 4;
					timer_3 = new System.Timers.Timer(30000.0);
					timer_3.Elapsed += 时间3结束事件;
					timer_3.Enabled = true;
					timer_3.AutoReset = false;
					if (list_0 != null)
					{
						foreach (NpcClass item in list_0)
						{
							World.删除指定地图指定类型怪物(801, item.FLD_PID);
						}
						list_0.Clear();
					}
				}
				if (World.势力战开启自动踢人 != 1)
				{
					return;
				}
				int num2 = (int)DateTime.Now.Subtract(dateTime_1).TotalSeconds;
				int num3 = World.势力战踢人方案.Count;
				KeyValuePair<int, int> keyValuePair;
				while (true)
				{
					if (num3 > 0)
					{
						keyValuePair = World.势力战踢人方案[num3 - 1];
						if (num2 > keyValuePair.Key * 60)
						{
							break;
						}
						num3--;
						continue;
					}
					return;
				}
				势力战踢人(keyValuePair.Value);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "势力战 时间结束事件2 出错：" + ex);
			}
		}

		public void 时间3结束事件(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass_时间结束事件3");
			}
			try
			{
				DBA.ExeSqlCommand("DELETE FROM EventTop where 分区信息='" + World.ZoneNumber + "'");
				foreach (EventTopClass value2 in World.EventTop.Values)
				{
					string text = "正";
					text = ((value2.势力 != 1) ? "邪" : "正");
					DBA.ExeSqlCommand($"INSERT INTO EventTop (人物名, 帮派, 势力, 等级, 杀人数, 死亡数, 分区信息)values('{value2.人物名}','{value2.帮派}','{text}', {value2.等级}, {value2.杀人数}, {value2.死亡数}, '{World.ZoneNumber}')");
				}
				if (World.势力战类型 == 1 && 势力战胜利状态 != 0)
				{
					if (势力战胜利状态 == 1)
					{
						势力战胜利状态 = 1;
						World.发送公告("势力战结束正派胜利");
					}
					else
					{
						势力战胜利状态 = 2;
						World.发送公告("势力战结束邪派胜利");
					}
				}
				else if (World.势力战正分数 > World.势力战邪分数)
				{
					势力战胜利状态 = 1;
					World.发送公告("势力战结束正派胜利");
				}
				else if (World.势力战正分数 == World.势力战邪分数)
				{
					势力战胜利状态 = 3;
					World.发送公告("势力战结束双方平局");
				}
				else
				{
					势力战胜利状态 = 2;
					World.发送公告("势力战结束邪派胜利");
				}
				foreach (Players value3 in World.AllConnectedPlayers.Values)
				{
					if (value3.人物坐标_地图 != 801 || !World.EventTop.TryGetValue(value3.UserName, out var value))
					{
						continue;
					}
					势力战系统.发送势力战结束消息新(value3, 势力战胜利状态);
					value3.系统提示("1分钟后将传送至银币广场", 10, "提示信息");
					if (value3.Player_Zx == 势力战胜利状态)
					{
						DataTable dataTable = RxjhClass.得到势力荣誉数据(value3.UserName, value3.人物分区ID);
						if (dataTable != null)
						{
							int num = (int)dataTable.Rows[0]["FLD_RY"];
							RxjhClass.更新势力荣誉(value3.UserName, value3.帮派名字, value3.Player_Zx, value3.Player_Level, value3.Player_Job, value3.Player_Job_leve, num + value.玩家杀怪分数 + value.玩家杀人分数, value3.人物分区ID);
						}
						else
						{
							RxjhClass.创建势力荣誉(value3.UserName, value3.帮派名字, value3.Player_Zx, value3.Player_Level, value3.Player_Job, value3.Player_Job_leve, value.玩家杀怪分数 + value.玩家杀人分数, value3.人物分区ID);
						}
						value3.系统提示("恭喜你获得100点势力荣誉点请再接再厉！", 50, "");
						value3.活动奖励系统(7);
					}
					else
					{
						DataTable dataTable2 = RxjhClass.得到势力荣誉数据(value3.UserName, value3.人物分区ID);
						if (dataTable2 != null)
						{
							int num2 = (int)dataTable2.Rows[0]["FLD_RY"];
							RxjhClass.更新势力荣誉(value3.UserName, value3.帮派名字, value3.Player_Zx, value3.Player_Level, value3.Player_Job, value3.Player_Job_leve, num2 + value.玩家杀怪分数 + value.玩家杀人分数, value3.人物分区ID);
						}
						else
						{
							RxjhClass.创建势力荣誉(value3.UserName, value3.帮派名字, value3.Player_Zx, value3.Player_Level, value3.Player_Job, value3.Player_Job_leve, value.玩家杀怪分数 + value.玩家杀人分数, value3.人物分区ID);
						}
						value3.活动奖励系统(8);
						value3.系统提示("恭喜你获得50点势力荣誉点请再接再厉！", 50, "");
					}
				}
				World.势力战进程 = 5;
				timer_3.Enabled = false;
				timer_3.Close();
				timer_3.Dispose();
				timer_4 = new System.Timers.Timer(30000.0);
				timer_4.Elapsed += 时间4结束事件;
				timer_4.Enabled = true;
				timer_4.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "势力战 时间结束事件3 出错：" + ex);
			}
		}

		public void 时间4结束事件(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass_时间结束事件4");
			}
			try
			{
				timer_4.Enabled = false;
				timer_4.Close();
				timer_4.Dispose();
				World.势力战进程 = 6;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 801)
					{
						value.移出势力战();
						value.人物_HP = value.人物最大_HP;
						value.更新HP_MP_SP();
						value.Player死亡 = false;
					}
				}
				Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "势力战 时间结束事件4 出错：" + ex);
			}
		}

		public void 势力战踢人(int 最低分数)
		{
			try
			{
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					if (value2.人物坐标_地图 == 801 && World.EventTop.TryGetValue(value2.UserName, out var value) && value.玩家杀人分数 + value.玩家杀怪分数 < 最低分数)
					{
						if (value2.人物_HP <= 0 || value2.Player死亡)
						{
							value2.人物_HP = value2.人物最大_HP;
							value2.更新HP_MP_SP();
							value2.Player死亡 = false;
							value2.死亡移动(value2.人物坐标_X, value2.人物坐标_Y, value2.人物坐标_Z, value2.人物坐标_地图);
						}
						value2.移出势力战();
						势力战系统.发送势力战参与度低被踢出消息(value2);
						势力战系统.关闭势力战提示(value2);
					}
				}
			}
			catch
			{
			}
		}
	}
}
