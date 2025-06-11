using System;
using System.Timers;

namespace RxjhServer
{
	public class 异口同声 : IDisposable
	{
		private readonly DateTime dateTime_0;

		private DateTime dateTime_1;

		private int int_0;

		private readonly System.Timers.Timer timer_0;

		private System.Timers.Timer timer_1;

		public 异口同声()
		{
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "异口同声-");
				}
				dateTime_0 = DateTime.Now.AddMinutes(2.0);
				timer_0 = new System.Timers.Timer(10000.0);
				timer_0.Elapsed += 时间结束事件1;
				timer_0.Enabled = true;
				timer_0.AutoReset = true;
				时间结束事件1(null, null);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "异口同声 异口同声 出错：" + ex);
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异口同声-Dispose");
			}
			if (timer_0 != null)
			{
				timer_0.Enabled = false;
				timer_0.Close();
				timer_0.Dispose();
			}
			if (timer_1 != null)
			{
				timer_1.Enabled = false;
				timer_1.Close();
				timer_1.Dispose();
			}
			World.EnableUnisonSpeech = null;
			World.异口同声开启中 = 0;
		}

		public void 时间结束事件1(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异口同声时间结束事件1");
			}
			try
			{
				int kssjint = (int_0 = (int)dateTime_0.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.发送其他活动开始倒计时(kssjint);
					value.系统提示("距离开始还有[" + kssjint + "]秒开始.开始后[" + World.异口同声结束时间 + "]分钟结束。", 10, "异口同声");
					value.系统公告("请在聊天窗口输入[" + World.异口同声内容 + "]。就会得到神秘BUF");
				}
				if (int_0 <= 0)
				{
					World.异口同声开启中 = 1;
					timer_0.Enabled = false;
					timer_0.Close();
					timer_0.Dispose();
					dateTime_1 = DateTime.Now.AddMinutes(World.异口同声结束时间);
					timer_1 = new System.Timers.Timer(World.异口同声结束时间 * 60000);
					timer_1.Elapsed += 时间结束事件2;
					timer_1.Enabled = true;
					timer_1.AutoReset = true;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "异口同声 时间结束事件1 出错：" + ex);
			}
		}

		public void 时间结束事件2(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异口同声时间结束事件2");
			}
			try
			{
				int num = (int)dateTime_1.Subtract(DateTime.Now).TotalSeconds;
				if (num > 0)
				{
					return;
				}
				timer_1.Enabled = false;
				timer_1.Close();
				timer_1.Dispose();
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.系统公告("异口同声活动结束，请关注下次公告开启！！");
				}
				Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "异口同声 时间结束事件2 出错：" + ex);
			}
		}
	}
}
