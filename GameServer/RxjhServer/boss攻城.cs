using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;

namespace RxjhServer
{
	public class boss攻城 : IDisposable
	{
		private readonly System.Timers.Timer timer_0;

		private System.Timers.Timer timer_1;

		private readonly DateTime dateTime_0;

		private DateTime iqOqpBruKS;

		private readonly ConcurrentDictionary<int, NpcClass> ConcurrentDictionary_0;

		private int int_0;

		public boss攻城()
		{
			ConcurrentDictionary_0 = new ConcurrentDictionary<int, NpcClass>();
			ConcurrentDictionary_0.Clear();
			dateTime_0 = DateTime.Now.AddMinutes(World.BOSS攻城倒计时);
			timer_0 = new System.Timers.Timer(60000.0);
			timer_0.Elapsed += 发送BOSS攻城快开始公告;
			timer_0.Enabled = true;
			timer_0.AutoReset = true;
			发送BOSS攻城快开始公告(null, null);
		}

		public void 发送BOSS攻城快开始公告(object sender, ElapsedEventArgs e)
		{
			try
			{
				int num = (int)dateTime_0.Subtract(DateTime.Now).TotalSeconds;
				if (num > 0)
				{
					foreach (Players value in World.AllConnectedPlayers.Values)
					{
						value.发送其他活动开始倒计时(num);
						value.系统提示("离BOSS大军入侵三邪关还剩下" + num / 60 + "分钟.请各位大侠做好迎战准备", 10, "系统广播");
						World.发送公告("离BOSS大军入侵三邪关还剩下" + num / 60 + "分钟.请各位大侠做好迎战准备");
					}
					return;
				}
				timer_0.Enabled = false;
				timer_0.Close();
				timer_0.Dispose();
				iqOqpBruKS = DateTime.Now.AddMinutes(World.BOSS攻城时间);
				timer_1 = new System.Timers.Timer(60000.0);
				timer_1.Elapsed += BOSS战攻城结束;
				timer_1.Enabled = true;
				try
				{
					foreach (攻城怪物 item in World.攻城怪物列表)
					{
						NpcClass npcClass = World.AddBossEveNpc(item.FLD_PID, item.FLD_X, item.FLD_Y, item.MonsterId);
						if (npcClass != null && !ConcurrentDictionary_0.ContainsKey(npcClass.FLD_INDEX))
						{
							ConcurrentDictionary_0.TryAdd(npcClass.FLD_INDEX, npcClass);
						}
						int_0 = item.MonsterId;
					}
					foreach (Players value2 in World.AllConnectedPlayers.Values)
					{
						value2.系统提示("BOSS攻城开始。大家有" + World.BOSS攻城时间 + "分钟的时间来清理BOSS", 10, "系统广播");
					}
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "BOSS攻城战 时间结束事件1 出错：" + ex);
				}
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "BOSS攻城战 时间结束事件1 出错：" + ex2);
			}
		}

		public void BOSS战攻城结束(object sender, ElapsedEventArgs e)
		{
			try
			{
				int num = 0;
				int num2 = (int)iqOqpBruKS.Subtract(DateTime.Now).TotalSeconds;
				if (num2 > 0)
				{
					foreach (NpcClass value in ConcurrentDictionary_0.Values)
					{
						if (!value.NPC死亡)
						{
							num++;
						}
					}
					if (num <= 0)
					{
						return;
					}
					foreach (Players value2 in World.AllConnectedPlayers.Values)
					{
						value2.发送其他活动开始倒计时(num2);
						value2.系统提示("怪物们的攻势异常凶猛, 各位侠士加油!再坚持" + num2 / 60 + "分钟!", 10, "系统广播");
					}
					return;
				}
				timer_1.Enabled = false;
				timer_1.Close();
				timer_1.Dispose();
				foreach (NpcClass value3 in ConcurrentDictionary_0.Values)
				{
					if (!value3.NPC死亡)
					{
						num++;
					}
				}
				if (num > 0)
				{
					foreach (Players value4 in World.AllConnectedPlayers.Values)
					{
						value4.系统公告("非常遗憾，怪物们已经占领[" + 坐标Class.GetMapName(int_0) + "]你们的安全正在受到威胁，请在下一次战斗中务必把可恶的怪物消灭掉");
					}
					Dispose();
					return;
				}
				foreach (Players value5 in World.AllConnectedPlayers.Values)
				{
					value5.系统公告("[" + 坐标Class.GetMapName(int_0) + "]保卫战中获得胜利");
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "计算BOSS攻城的怪物所剩数量出错：" + ex);
			}
		}

		public void Dispose()
		{
			try
			{
				List<NpcClass> list = new List<NpcClass>();
				foreach (NpcClass value in ConcurrentDictionary_0.Values)
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
				ConcurrentDictionary_0.Clear();
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
				World.BossSiege = null;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "BOSS攻城结束出错:" + ex.Message);
			}
		}
	}
}
