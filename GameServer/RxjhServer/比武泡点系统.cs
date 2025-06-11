using System;
using System.Data;
using System.Timers;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class 比武泡点系统 : IDisposable
	{
		private System.Timers.Timer 时间1;

		private System.Timers.Timer 时间2;

		private DateTime kssj;

		private int kssjint;

		private DateTime kssj1;

		private int kssjint1;

		public 比武泡点系统()
		{
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "比武泡点错误1");
				}
				kssj = DateTime.Now.AddMinutes(World.比武泡点倒计时);
				时间1 = new System.Timers.Timer(10000.0);
				时间1.Elapsed += 时间结束事件1;
				时间1.Enabled = true;
				时间1.AutoReset = true;
				时间结束事件1(null, null);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "比武泡点错误2" + ex);
			}
		}

		public void 时间结束事件1(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "比武泡点错误3");
			}
			try
			{
				int num = (kssjint = (int)kssj.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.发送其他活动开始倒计时(num);
					value.系统提示("要参加比武泡点的请速去泫勃派南门NPC进入", 10, "系统提示");
					value.系统提示("要参加比武泡点的请速去泫勃派南门NPC进入", 3, "系统提示");
					value.系统提示("要参加比武泡点的请速去泫勃派南门NPC进入", 7, "系统提示");
				}
				if (kssjint <= 0)
				{
					时间1.Enabled = false;
					时间1.Close();
					时间1.Dispose();
					World.比武泡点进程 = 1;
					kssj1 = DateTime.Now.AddMinutes(World.比武泡点总时间);
					时间2 = new System.Timers.Timer(60000.0);
					时间2.Elapsed += 时间结束事件2;
					时间2.Enabled = true;
					时间2.AutoReset = true;
					时间结束事件2(null, null);
				}
			}
			catch (Exception)
			{
			}
		}

		public void 时间结束事件2(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "比武泡点错误4");
			}
			try
			{
				int 秒 = (kssjint1 = (int)kssj1.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.倒计时提示(秒);
				}
				if (kssjint1 > 0)
				{
					return;
				}
				时间2.Enabled = false;
				时间2.Close();
				时间2.Dispose();
				DBA.ExeSqlCommand("DELETE FROM 比武泡点Top where 分区信息='" + World.ZoneNumber + "'");
				foreach (比武泡点TopClass value2 in World.比武泡点Top.Values)
				{
					string text = "正";
					text = ((value2.势力 != 1) ? "邪" : "正");
					DBA.ExeSqlCommand($"INSERT INTO 比武泡点Top (人物名,帮派,势力,等级,杀人数,分区信息)values('{value2.人物名}','{value2.帮派}','{text}',{value2.等级},{value2.杀人数},'{World.ZoneNumber}')");
				}
				string sqlCommand = string.Format("Select TOP 10 * from 比武泡点Top where 分区信息='" + World.ZoneNumber + "'  Order By 杀人数 Desc");
				DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "GameServer");
				if (dBToDataTable != null)
				{
					if (dBToDataTable.Rows.Count > 0)
					{
						for (int i = 0; i < dBToDataTable.Rows.Count; i++)
						{
							foreach (Players value3 in World.AllConnectedPlayers.Values)
							{
								if (value3.UserName == dBToDataTable.Rows[i]["人物名"].ToString())
								{
									value3.比武泡点奖励(i);
								}
							}
						}
					}
					dBToDataTable.Dispose();
				}
				Dispose();
			}
			catch (Exception)
			{
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "比武泡点错误5");
			}
			World.比武泡点进程 = 0;
			World.发送游戏特殊公告("比武活泡点动已结束，期待下次比武泡点！", 10, "系统提示");
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
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				if (value.人物坐标_地图 == 2341)
				{
					value.移动(25f, -48f, 15f, 1201);
				}
				value.比武追加经验值 = 0.0;
			}
			World.ArenaIdling = null;
			MainForm.WriteLine(22, "比武泡点活动结束");
		}
	}
}
