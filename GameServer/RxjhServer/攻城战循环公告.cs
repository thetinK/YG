using System;
using System.Timers;

namespace RxjhServer
{
	public class 攻城战循环公告 : IDisposable
	{
		private System.Timers.Timer 时间1;

		private readonly DateTime kssj;

		private int kssjint;

		public 攻城战循环公告()
		{
			try
			{
				kssj = DateTime.Now.AddMinutes(3.0);
				时间1 = new System.Timers.Timer(2000.0);
				时间1.Elapsed += 时间结束事件1;
				时间1.Enabled = true;
				时间1.AutoReset = true;
				时间结束事件1(null, null);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "攻城战循环公告出错1" + ex);
			}
		}

		public void 时间结束事件1(object source, ElapsedEventArgs e)
		{
			try
			{
				int num = (int)kssj.Subtract(DateTime.Now).TotalSeconds;
				if (num <= 0)
				{
					num = 0;
				}
				kssjint = num;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.门派联盟盟主 != "" && value.人物坐标_地图 != 42001)
					{
						value.发出攻城战准备开始第二次通知();
						value.系统提示("跨线攻城战, 还剩下" + num + "秒开始.没报名的点击移动报名", 3, "系统提示");
					}
				}
				if (kssjint <= 0)
				{
					Dispose();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "攻城战循环公告出错2" + ex);
			}
		}

		public void Dispose()
		{
			try
			{
				if (时间1 != null)
				{
					时间1.Enabled = false;
					时间1.Close();
					时间1.Dispose();
					时间1 = null;
				}
				if (World.攻城战公告 != null)
				{
					World.攻城战公告 = null;
				}
			}
			catch
			{
				MainForm.WriteLine(1, "攻城战循环公告出错3");
			}
		}
	}
}
