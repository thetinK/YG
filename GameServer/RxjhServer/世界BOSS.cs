using System;
using System.Threading;
using System.Timers;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class 世界BOSS : IDisposable
	{
		private readonly System.Timers.Timer 时间1;

		private System.Timers.Timer 时间2;

		private readonly DateTime kssj;

		private int kssjint = 0;

		private DateTime bossgcsj;

		private int bossgcsjint = 0;

		public 世界BOSS()
		{
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "世界BOSS");
				}
				kssj = DateTime.Now.AddMinutes(World.世界BOSS攻城倒计时);
				时间1 = new System.Timers.Timer(20000.0);
				时间1.Elapsed += 时间结束事件1;
				时间1.Enabled = true;
				时间1.AutoReset = true;
				时间结束事件1(null, null);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "世界BOSS 出错：" + ex);
			}
		}

		public void 时间结束事件1(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "世界BOSS时间结束事件1");
			}
			try
			{
				int num = (kssjint = (int)kssj.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.发送其他活动开始倒计时(kssjint);
				}
				World.发送游戏特殊公告("距离[世界BOSS携带大量宝物出现], 还剩下[" + kssjint + "]秒，出现在泫勃派南门..", 6, "公告");
				if (kssjint <= 0)
				{
					时间1.Enabled = false;
					时间1.Close();
					时间1.Dispose();
					World.世界BOSS攻城进程 = 1;
					DBA.GetDBToDataTable(string.Format("update TBL_XWWL_Char set FLD_BOSS伤害=0", "1"));
					World.AddNpc一次(World.BOSSPID, World.BOSS坐标X, World.BOSS坐标Y, World.BOSS地图, 是否true: true, World.BOSS血, World.BOSS攻击, World.BOSS防御);
					Thread.Sleep(1000);
					bossgcsj = DateTime.Now.AddMinutes(World.世界BOSS攻城时间);
					时间2 = new System.Timers.Timer(30000.0);
					时间2.Elapsed += 时间结束事件2;
					时间2.Enabled = true;
					时间2.AutoReset = true;
				}
			}
			catch
			{
			}
		}

		public void 时间结束事件2(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "BOSS攻城系统_时间结束事件2");
			}
			try
			{
				int num = (bossgcsjint = (int)bossgcsj.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.系统提示("距离[世界boss]逃离, 还剩下[" + bossgcsjint + "]秒，勇士们努力干吧!", 3, "系统提示");
					value.发送其他活动开始倒计时(bossgcsjint);
				}
				if (bossgcsjint <= 0)
				{
					时间2.Enabled = false;
					时间2.Close();
					时间2.Dispose();
					World.WorldBoss.Dispose();
				}
			}
			catch
			{
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "世界boss-Dispose");
			}
			if (时间1 != null)
			{
				时间1.Enabled = false;
				时间1.Close();
				时间1.Dispose();
			}
			if (时间2 != null)
			{
				时间2.Enabled = false;
				时间2.Close();
				时间2.Dispose();
			}
			World.delBoss(101, 16556);
			Thread.Sleep(1000);
			World.世界BOSS攻城进程 = 0;
			World.发送游戏特殊公告("本次世界boss已结束。期待下次的到来！", 6, "公告");
			World.WorldBoss = null;
		}
	}
}
