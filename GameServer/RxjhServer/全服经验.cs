using System;
using System.Timers;

namespace RxjhServer
{
	public class 全服经验 : IDisposable
	{
		private readonly DateTime dateTime_0;

		private int int_0;

		private readonly System.Timers.Timer timer_0;

		public 全服经验()
		{
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "全服双倍");
				}
				dateTime_0 = DateTime.Now.AddMinutes(World.双倍奖励结束时间);
				timer_0 = new System.Timers.Timer(600000.0);
				timer_0.Elapsed += 时间结束事件1;
				timer_0.Enabled = true;
				timer_0.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "全服双倍 出错：" + ex);
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass-Dispose");
			}
			if (timer_0 != null)
			{
				timer_0.Enabled = false;
				timer_0.Close();
				timer_0.Dispose();
			}
			World.EnableServerWideExp = null;
		}

		public void 时间结束事件1(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "EventClass_时间结束事件1");
			}
			try
			{
				int num = (int_0 = (int)dateTime_0.Subtract(DateTime.Now).TotalSeconds);
				string text = string.Format(World.双倍奖励公告内容, int_0 / 60);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.系统提示(text ?? "", 10, "全服双倍活动");
				}
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					value2.系统提示("现在是" + World.双倍奖励经验倍数 + "倍经验时间！尽情的升级吧。", 10, "系统提示");
					value2.系统提示("现在是" + World.双倍奖励爆率倍数 + "倍爆率时间！尽情的刷宝吧。", 10, "系统提示");
					value2.系统提示("现在是" + World.双倍奖励武勋倍数 + "倍武勋时间！尽情的战斗吧。", 10, "系统提示");
				}
				if (int_0 <= 0)
				{
					timer_0.Enabled = false;
					timer_0.Close();
					timer_0.Dispose();
					Dispose();
					World.EnableServerWideExp = null;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "全服经验 时间结束事件1 出错：" + ex);
			}
		}
	}
}
