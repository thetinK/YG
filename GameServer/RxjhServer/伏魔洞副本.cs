using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;

namespace RxjhServer
{
	public class 伏魔洞副本 : IDisposable
	{
		private readonly System.Timers.Timer 时间1;

		private System.Timers.Timer 时间2;

		private readonly DateTime kssj;

		private int kssjint = 0;

		public DateTime bossgcsj;

		private int bossgcsjint = 0;

		private readonly ConcurrentDictionary<int, NpcClass> 副本怪物;

		private readonly TeamClass 参加队伍;

		public 伏魔洞副本(TeamClass 组队)
		{
			try
			{
				if (World.JlMsg == 1)
				{
					MainForm.WriteLine(0, "EventClass-");
				}
				参加队伍 = 组队;
				foreach (Players value in 参加队伍.组队列表.Values)
				{
					value.系统提示("伏魔洞副本申请成功, 一分钟后将被传送到伏魔洞1层");
				}
				副本怪物 = new ConcurrentDictionary<int, NpcClass>();
				副本怪物.Clear();
				kssj = DateTime.Now.AddMinutes(1.0);
				时间1 = new System.Timers.Timer(20000.0);
				时间1.Elapsed += 时间结束事件1;
				时间1.Enabled = true;
				时间1.AutoReset = true;
				时间结束事件1(null, null);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "伏魔洞副本出错1：" + ex);
			}
		}

		public void 时间结束事件1(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "伏魔洞副本出错2");
			}
			try
			{
				int num = (kssjint = (int)kssj.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in 参加队伍.组队列表.Values)
				{
					value.发送其他活动开始倒计时(kssjint);
				}
				if (kssjint > 0)
				{
					return;
				}
				时间1.Enabled = false;
				时间1.Close();
				时间1.Dispose();
				foreach (Players value2 in 参加队伍.组队列表.Values)
				{
					if (value2.恢复精力 >= 200)
					{
						value2.恢复精力 -= 200;
						value2.移动(-100f, 900f, 15f, 21001);
						value2.SavePlayerData();
						value2.更新武功和状态();
					}
					else
					{
						value2.系统提示("精力不足50点, 武剑刀每天可以恢复100点精力");
					}
				}
				try
				{
					foreach (伏魔洞怪物 item in World.伏魔洞怪物列表)
					{
						NpcClass npcClass = World.AddBossEveNpc(item.FLD_PID, item.FLD_X, item.FLD_Y, item.FLD_MID);
						if (npcClass != null && !副本怪物.ContainsKey(npcClass.FLD_INDEX))
						{
							副本怪物.TryAdd(npcClass.FLD_INDEX, npcClass);
						}
					}
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "伏魔洞副本出错3：" + ex);
				}
				bossgcsj = DateTime.Now.AddMinutes(30.0);
				时间2 = new System.Timers.Timer(30000.0);
				时间2.Elapsed += 时间结束事件2;
				时间2.Enabled = true;
				时间2.AutoReset = true;
			}
			catch
			{
				MainForm.WriteLine(22, "队伍被解散伏魔洞副本结束-1");
				Dispose();
			}
		}

		public void 时间结束事件2(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "伏魔洞副本出错4");
			}
			try
			{
				int num = (bossgcsjint = (int)bossgcsj.Subtract(DateTime.Now).TotalSeconds);
				foreach (Players value in 参加队伍.组队列表.Values)
				{
					if (value.人物坐标_地图 == 21001)
					{
						value.发送其他活动开始倒计时(bossgcsjint);
					}
				}
				if (bossgcsjint <= 0)
				{
					时间2.Enabled = false;
					时间2.Close();
					时间2.Dispose();
					Dispose();
				}
			}
			catch
			{
				MainForm.WriteLine(22, "队伍被解散伏魔洞副本结束-2");
				Dispose();
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "伏魔洞副本出错6");
			}
			List<NpcClass> list = new List<NpcClass>();
			foreach (NpcClass value in 副本怪物.Values)
			{
				list.Add(value);
			}
			if (list != null)
			{
				foreach (NpcClass item in list)
				{
					item.发送怪物一次性死亡数据();
				}
				list.Clear();
			}
			副本怪物.Clear();
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
			foreach (Players value2 in World.AllConnectedPlayers.Values)
			{
				if (value2.人物坐标_地图 == 21001)
				{
					value2.移动(0f, 300f, 15f, 20001);
					value2.发送其他活动开始倒计时(5);
				}
			}
			World.发送游戏特殊公告("伏魔洞副本已结束.其他队伍可以继续参加！", 6, "公告");
			World.伏魔洞副本 = null;
		}
	}
}
