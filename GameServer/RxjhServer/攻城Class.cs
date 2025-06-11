using System;
using System.Data;
using System.Threading;
using System.Timers;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class 攻城Class : IDisposable
	{
		private readonly System.Timers.Timer 时间1;

		private System.Timers.Timer 攻城中每分钟执行;

		private readonly DateTime 天魔攻城准备时间;

		private DateTime 天魔攻城总时间;

		public DateTime 开始计时;

		private int 开始倒计时;

		public static DateTime 当前进程结束时间;

		public bool 火龙之力释放;

		public NpcClass 守城雕像 = null;

		public 攻城Class()
		{
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "EventClass-");
				}
				World.攻城战list.Clear();
				if (World.势力战开始时向其它线广播 == 1)
				{
					if (World.ServerID == 28)
					{
						string text = World.攻城战预备时间 + "分钟后将在[银币市场], 开启攻城战.请要参加的玩家前往[银币市场]参加";
						World.conn.发送("全线公告|" + 0 + "|" + text + "|攻城战");
					}
					else
					{
						string text2 = World.攻城战预备时间 + "分钟后将在" + World.ServerID + "线, 开启攻城战.请要参加的玩家前往" + World.ServerID + "线参加";
						World.conn.发送("全线公告|" + 0 + "|" + text2 + "|攻城战");
					}
				}
				天魔攻城准备时间 = DateTime.Now.AddMinutes(World.攻城战预备时间);
				当前进程结束时间 = 天魔攻城准备时间;
				World.攻城战进程 = 1;
				时间1 = new System.Timers.Timer(6000.0);
				时间1.Elapsed += 时间结束事件1;
				时间1.Enabled = true;
				时间1.AutoReset = true;
				时间结束事件1(null, null);
				开始计时 = DateTime.Now;
				NpcClass npcClass = World.AddNpc(16430, -430f, -393f, 42001, 0, 0, 一次性怪: true, 600);
				if (npcClass != null)
				{
					npcClass.Max_Rxjh_HP += World.城门强化等级 * 250000;
					npcClass.Rxjh_HP = npcClass.Max_Rxjh_HP;
					npcClass.FLD_DF += World.城门强化等级 * 50;
				}
				NpcClass npcClass2 = World.AddNpc(16431, 50f, 468f, 42001, 1, 0, 一次性怪: true, 600);
				if (npcClass2 != null)
				{
					npcClass2.Max_Rxjh_HP += World.城门强化等级 * 250000;
					npcClass2.Rxjh_HP = npcClass2.Max_Rxjh_HP;
					npcClass2.FLD_DF += World.城门强化等级 * 50;
				}
				守城雕像 = World.AddNpc(16435, -436f, 530f, 42001, 0, 0, 一次性怪: true, 600);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "攻城战 EventClass 出错：" + ex);
			}
		}

		public void 时间结束事件1(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass_时间结束事件1");
			}
			try
			{
				TimeSpan timeSpan = 天魔攻城准备时间.Subtract(DateTime.Now);
				int num = (int)timeSpan.TotalSeconds;
				int minutes = timeSpan.Minutes;
				if (num <= 0)
				{
					World.攻城战进程 = 2;
					num = 0;
				}
				if (World.势力战开始时向其它线广播 == 1)
				{
					if (World.ServerID == 28)
					{
						string text = num + "秒后将在[银币市场], 开启攻城战.请要参加的玩家前往[银币市场]参加";
						World.conn.发送("全线提示|" + 6 + "|" + text + "|" + World.ServerID);
					}
					else
					{
						string text2 = num + "秒后将在" + World.ServerID + "线, 开启攻城战.请要参加的玩家前往" + World.ServerID + "线参加";
						World.conn.发送("全线提示|" + 6 + "|" + text2 + "|" + World.ServerID);
					}
				}
				开始倒计时 = num;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 42001)
					{
						value.发送攻城战剩余时间(开始倒计时);
						value.天魔神宫显示图标(value, World.申请攻城人物列表.Count);
						value.系统提示("你已经报名不要下线, 掉线的玩家从银币市场点管理员参加即可", 50, "系统提示");
					}
					else if (value.Player_Level >= World.攻城战进入等级 && value.宣告攻城 != 0 && value.人物坐标_地图 != 42001)
					{
						value.发送天魔神宫邀请();
						value.系统提示("离攻城战开始还剩下" + num + "秒。没报名的点击移动报名", 50, "系统提示");
					}
				}
				if (开始倒计时 > 0)
				{
					return;
				}
				时间1.Enabled = false;
				时间1.Close();
				时间1.Dispose();
				World.攻城战进程 = 3;
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					if (value2.人物坐标_地图 == 42001)
					{
						value2.切换PK模式(2);
						value2.发送攻城战剩余时间(3600);
					}
				}
				天魔攻城总时间 = DateTime.Now.AddMinutes(World.攻城战时长);
				当前进程结束时间 = 天魔攻城总时间;
				攻城中每分钟执行 = new System.Timers.Timer(6000.0);
				攻城中每分钟执行.Elapsed += 时间结束事件2;
				攻城中每分钟执行.Enabled = true;
				攻城中每分钟执行.AutoReset = true;
				时间结束事件2(null, null);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "攻城战 时间结束事件1 出错：" + ex);
			}
		}

		public void 时间结束事件2(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass_时间结束事件2");
			}
			try
			{
				TimeSpan timeSpan = 当前进程结束时间.Subtract(DateTime.Now);
				int minutes = timeSpan.Minutes;
				int num = (int)timeSpan.TotalSeconds;
				int num2 = (World.攻城战预备时间 + World.攻城战时长) * 60;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 42001)
					{
						value.天魔神宫显示图标(value, World.申请攻城人物列表.Count);
						value.加载攻城数据();
						if (World.天魔神宫雕像是否死亡 == 1)
						{
							World.天魔神宫雕像击杀添加怪物();
							守城雕像 = World.AddNpc(16435, -436f, 530f, 42001, 0, 0, 一次性怪: true, 600);
							value.系统提示("攻城战雕像已刷新.击杀雕像即可获得守城方....", 6, "公告");
							当前进程结束时间 = DateTime.Now.AddMinutes(10.0);
							string text = "≮" + World.天魔临时占领者 + "≯同盟门派，在攻城战中击杀『守城雕像』.攻城战结束还剩『10』分钟...";
							World.conn.发送("狮子吼|" + value.人物全服ID + "|" + World.天魔临时占领者 + "|" + text + "|" + value.Client.ToString() + "|" + World.ServerID + "|" + value.人物坐标_地图 + "|" + 38);
						}
						value.发送攻城战剩余时间(num);
					}
				}
				if (num > 0 && DateTime.Now.Subtract(开始计时).TotalSeconds < (double)num2)
				{
					return;
				}
				攻城中每分钟执行.Enabled = false;
				攻城中每分钟执行.Close();
				攻城中每分钟执行.Dispose();
				World.攻城战进程 = 4;
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					if (value2.人物坐标_地图 == 42001)
					{
						value2.天魔神宫守城胜利结束包(value2);
					}
				}
				更新城主信息();
				攻城结束奖励();
				Dispose();
			}
			catch (Exception ex)
			{
				World.SiegeWar.Dispose();
				MainForm.WriteLine(1, "攻城战 时间结束事件2 出错：" + ex);
			}
		}

		public void 更新城主信息()
		{
			DateTime now = DateTime.Now;
			DBA.ExeSqlCommand($"UPDATE 攻城城主 SET 攻城奖励时间='{DateTime.Now.AddDays(7.0)}' WHERE 分区信息 = '{World.ZoneNumber}'");
			DBA.ExeSqlCommand($"UPDATE 攻城城主 SET 攻城时间='{now}' WHERE 分区信息 = '{World.ZoneNumber}' ");
		}

		public void 攻城结束奖励()
		{
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				value.加载攻城数据();
				DataTable dBToDataTable = DBA.GetDBToDataTable("select * from [攻城城主] where 分区信息= '" + World.ZoneNumber + "'");
				if (value.人物坐标_地图 == 42001)
				{
					if (dBToDataTable.Rows[0]["攻城行会名"].ToString() == value.门派联盟盟主)
					{
						value.活动奖励系统(3);
					}
					else
					{
						value.活动奖励系统(4);
					}
					value.发送攻城相关BUFF(是否消失: false);
					value.切换PK模式(0);
				}
				dBToDataTable.Dispose();
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass-Dispose");
			}
			World.攻城战进程 = 0;
			World.delNpc(42001, 16431);
			Thread.Sleep(1000);
			World.delNpc(42001, 16430);
			Thread.Sleep(1000);
			World.delNpc(42001, 16435);
			Thread.Sleep(1000);
			World.城门强化等级 = 0;
			if (时间1 != null)
			{
				时间1.Enabled = false;
				时间1.Close();
				时间1.Dispose();
			}
			if (攻城中每分钟执行 != null)
			{
				攻城中每分钟执行.Enabled = false;
				攻城中每分钟执行.Close();
				攻城中每分钟执行.Dispose();
			}
			World.申请攻城人物列表.Clear();
			World.攻城战list.Clear();
			World.SiegeWar = null;
			string text = "天魔攻城战活动已经结束";
			World.conn.发送("全线公告|" + 1 + "|" + text + "|攻城战");
		}
	}
}
