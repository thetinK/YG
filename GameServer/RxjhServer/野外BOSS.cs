using System;
using System.Collections.Generic;
using System.Timers;

namespace RxjhServer
{
	public class 野外BOSS : IDisposable
	{
		private readonly DateTime dateTime_0;

		private DateTime dateTime_1;

		private readonly System.Timers.Timer ycUlNmXaVp;

		private System.Timers.Timer timer_0;

		private readonly List<NpcClass> list_0;

		public 野外BOSS()
		{
			list_0 = new List<NpcClass>();
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "野外BOSS初始化事件");
				}
				string[] array = World.野外BOSS配置.Split('/');
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(';');
					if (array2.Length == 0)
					{
						continue;
					}
					string mapName = 坐标Class.GetMapName(Convert.ToInt32(array2[0]));
					string monSterName = botCoord.GetMonSterName(Convert.ToInt32(array2[1]));
					string msg = string.Format(World.野外BOSS倒计时 + "分钟后, {0}城内将出现BOSS怪物{1}", new object[2] { mapName, monSterName });
					foreach (Players value in World.AllConnectedPlayers.Values)
					{
						value.系统公告(msg);
					}
				}
				dateTime_0 = DateTime.Now.AddMinutes(World.野外BOSS倒计时);
				ycUlNmXaVp = new System.Timers.Timer(10000.0);
				ycUlNmXaVp.Elapsed += timer_0_Elapsed;
				ycUlNmXaVp.Enabled = true;
				ycUlNmXaVp.AutoReset = true;
				timer_0_Elapsed(null, null);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "野外BOSS初始化事件出错：" + ex);
			}
		}

		public void timer_0_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "野外BOSS结束事件1");
			}
			try
			{
				int num = (int)dateTime_0.Subtract(DateTime.Now).TotalSeconds;
				if (num > 0)
				{
					return;
				}
				ycUlNmXaVp.Enabled = false;
				ycUlNmXaVp.Close();
				ycUlNmXaVp.Dispose();
				string[] array = World.野外BOSS配置.Split('/');
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(';');
					if (array2.Length == 0)
					{
						continue;
					}
					NpcClass item = World.AddNpc(Convert.ToInt32(array2[1]), Convert.ToInt32(array2[2]), Convert.ToInt32(array2[3]), Convert.ToInt32(array2[0]), 0, 0, 一次性怪: true, 3600);
					list_0.Add(item);
					string mapName = 坐标Class.GetMapName(Convert.ToInt32(array2[0]));
					string monSterName = botCoord.GetMonSterName(Convert.ToInt32(array2[1]));
					string msg = string.Format("{0}城内出现BOSS怪物{1}", new object[2] { mapName, monSterName });
					foreach (Players value in World.AllConnectedPlayers.Values)
					{
						value.系统公告(msg);
					}
				}
				dateTime_1 = DateTime.Now.AddMinutes(World.野外BOSS总时间);
				timer_0 = new System.Timers.Timer(10000.0);
				timer_0.Elapsed += timer_1_Elapsed;
				timer_0.Enabled = true;
				timer_0.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "野外BOSS结束事件1出错：" + ex);
			}
		}

		public void timer_1_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "野外BOSS结束事件2");
			}
			try
			{
				int num = (int)dateTime_1.Subtract(DateTime.Now).TotalSeconds;
				if (num > 0)
				{
					return;
				}
				timer_0.Enabled = false;
				timer_0.Close();
				timer_0.Dispose();
				if (list_0 != null)
				{
					foreach (NpcClass item in list_0)
					{
						World.delBoss(item.Rxjh_Map, item.FLD_PID);
					}
					list_0.Clear();
				}
				Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "野外BOSS结束事件2出错：" + ex);
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "野外BOSS内存释放事件");
			}
			if (ycUlNmXaVp != null)
			{
				ycUlNmXaVp.Enabled = false;
				ycUlNmXaVp.Close();
				ycUlNmXaVp.Dispose();
			}
			if (timer_0 != null)
			{
				timer_0.Enabled = false;
				timer_0.Close();
				timer_0.Dispose();
			}
			World.FieldBoss = null;
			if (list_0 == null)
			{
				return;
			}
			foreach (NpcClass item in list_0)
			{
				World.delBoss(item.Rxjh_Map, item.FLD_PID);
			}
			list_0.Clear();
		}
	}
}
