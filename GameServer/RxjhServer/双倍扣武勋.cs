using System;
using System.Timers;

namespace RxjhServer
{
	public class 双倍扣武勋 : IDisposable
	{
		private readonly DateTime dateTime_0;

		private int int_0;

		private readonly System.Timers.Timer timer_0;

		public 双倍扣武勋()
		{
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "双倍扣武勋1");
				}
				dateTime_0 = DateTime.Now.AddMinutes(World.双倍扣武勋结束时间);
				timer_0 = new System.Timers.Timer(120000.0);
				timer_0.Elapsed += 时间结束事件1;
				timer_0.Enabled = true;
				timer_0.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "双倍扣武勋1 出错：" + ex);
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "双倍扣武勋2");
			}
			if (timer_0 != null)
			{
				timer_0.Enabled = false;
				timer_0.Close();
				timer_0.Dispose();
			}
			World.开启双倍扣武勋 = null;
		}

		public void 时间结束事件1(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "双倍扣武勋时间结束事件1");
			}
			try
			{
				int num = (int_0 = (int)dateTime_0.Subtract(DateTime.Now).TotalSeconds);
				string text = string.Format(World.双倍扣武勋公告内容, int_0 / 60);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.系统提示(text ?? "", 10, "系统提示");
				}
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					value2.系统提示("现在是" + World.双倍扣武勋倍数 + "倍扣武勋时间！尽情的厮杀吧。", 10, "系统提示");
				}
				if (int_0 <= 0)
				{
					timer_0.Enabled = false;
					timer_0.Close();
					timer_0.Dispose();
					Dispose();
					World.开启双倍扣武勋 = null;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "双倍扣武勋时间结束事件1 出错：" + ex);
			}
		}
	}
}
