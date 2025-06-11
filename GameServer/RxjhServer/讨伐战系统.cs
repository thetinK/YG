using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Timers;
using RxjhServer.HelperTools;

namespace RxjhServer
{
	public class 讨伐战系统
	{
		public static int 讨伐副本进程;

		public static int 讨伐副本占领者;

		public static int 火龙释放的状态ID;

		public DateTime 讨伐副本进行中结束时间;

		private System.Timers.Timer timer_0;

		private System.Timers.Timer timer_1;

		public static ConcurrentDictionary<int, NpcClass> 讨伐战副本怪物数据列表;

		public 讨伐战系统()
		{
			讨伐副本进程 = 1;
			讨伐战副本怪物数据列表 = new ConcurrentDictionary<int, NpcClass>();
			讨伐副本进行中结束时间 = DateTime.Now.AddMinutes(World.讨伐副本时长);
			timer_0 = new System.Timers.Timer(60000.0);
			timer_0.Elapsed += 时间结束事件1;
			timer_0.Enabled = true;
			timer_0.AutoReset = true;
			NpcClass npcClass = World.AddNpc2(16556, -65f, 49f, 43001, isOneTimeMonster: false, 10);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16556, -3f, -106f, 43001, isOneTimeMonster: true, 10);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16557, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16557, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16557, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16557, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16600, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16602, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16602, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16604, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16604, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16604, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16604, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16607, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16607, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16607, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
			npcClass = World.AddNpc2(16607, 0f, 0f, 43001, isOneTimeMonster: false, 25);
			讨伐战副本怪物数据列表.TryAdd(npcClass.FLD_INDEX, npcClass);
		}

		public void 时间结束事件1(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "讨伐副本_时间结束事件1");
			}
			try
			{
				int num = (int)讨伐副本进行中结束时间.Subtract(DateTime.Now).TotalSeconds;
				if (讨伐副本进程 == 2)
				{
					num = 0;
				}
				if (num > 0)
				{
					地狱火龙释放状态();
					return;
				}
				if (讨伐副本进程 == 2)
				{
					讨伐副本结束提示(讨伐结果: true);
				}
				else
				{
					讨伐副本结束提示(讨伐结果: false);
				}
				foreach (NpcClass value in 讨伐战副本怪物数据列表.Values)
				{
					value.发送死亡数据(0);
					MapClass.delnpc(43001, value.FLD_INDEX);
				}
				讨伐副本进程 = 2;
				timer_0.Enabled = false;
				timer_0.Close();
				timer_0.Dispose();
				timer_1 = new System.Timers.Timer(3000.0);
				timer_1.Elapsed += 时间结束事件2;
				timer_1.Enabled = true;
				timer_1.AutoReset = true;
			}
			catch
			{
			}
		}

		public void 时间结束事件2(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "讨伐副本_时间结束事件1");
			}
			try
			{
				timer_1.Enabled = false;
				timer_1.Close();
				timer_1.Dispose();
				Dispose();
			}
			catch
			{
			}
		}

		public void Dispose()
		{
			try
			{
				讨伐副本进程 = 0;
				讨伐副本占领者 = 0;
				if (timer_0 != null)
				{
					timer_0.Enabled = false;
					timer_0.Close();
					timer_0.Dispose();
					timer_0 = null;
				}
				if (timer_1 != null)
				{
					timer_1.Enabled = false;
					timer_1.Close();
					timer_1.Dispose();
					timer_1 = null;
				}
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 43001)
					{
						value.副本复活剩余次数 = 0;
						value.发送副本复活剩余次数();
						value.讨伐累计伤害 = 0;
						if (World.老泫勃派开关 == 1)
						{
							value.移动(495f, 1727f, 15f, 29000);
						}
						else
						{
							value.移动(420f, 1500f, 15f, 101);
						}
					}
				}
				if (讨伐战副本怪物数据列表 != null)
				{
					foreach (NpcClass value2 in 讨伐战副本怪物数据列表.Values)
					{
						value2.Dispose();
					}
					讨伐战副本怪物数据列表.Clear();
					讨伐战副本怪物数据列表 = null;
				}
				World.讨伐战副本 = null;
				World.DistributeCrusadeRewards();
			}
			catch
			{
			}
		}

		public void 讨伐奖励buff()
		{
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				if (value.人物坐标_地图 == 43001)
				{
					if (value.追加状态列表.ContainsKey(1008002150))
					{
						value.追加状态列表[1008002150].时间结束事件();
					}
					追加状态类 追加状态类2 = new 追加状态类(value, 7200000, 1008002150, 1);
					value.追加状态列表.Add(追加状态类2.FLD_PID, 追加状态类2);
					value.状态效果(BitConverter.GetBytes(1008002150), 1, 7200000);
					value.药品追加对怪攻击 += 100;
					value.药品追加对怪防御 += 100;
					value.更新武功和状态();
					value.更新广播人物数据();
				}
			}
		}

		public static void 地狱火龙释放状态()
		{
			Random random = new Random(DateTime.Now.Millisecond);
			火龙释放的状态ID = random.Next(0, 5);
			byte[] array = Converter.hexStringToByte("AA55AA0000000105A40008003B000000000002000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(火龙释放的状态ID), 0, array, 18, 4);
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				if (value.Client != null)
				{
					value.Client.Send(array, array.Length);
				}
			}
			switch (火龙释放的状态ID)
			{
			case 0:
			{
				ConcurrentDictionary<int, NpcClass> concurrentDictionary5 = MapClass.GetnpcPID(43001, 16600);
				foreach (NpcClass value2 in concurrentDictionary5.Values)
				{
					value2.地狱火龙副本状态效果();
					Thread.Sleep(1);
				}
				break;
			}
			case 1:
			{
				ConcurrentDictionary<int, NpcClass> concurrentDictionary4 = MapClass.GetnpcPID(43001, 16602);
				foreach (NpcClass value3 in concurrentDictionary4.Values)
				{
					value3.地狱火龙副本状态效果();
					Thread.Sleep(1);
				}
				break;
			}
			case 2:
			{
				ConcurrentDictionary<int, NpcClass> concurrentDictionary3 = MapClass.GetnpcPID(43001, 16604);
				foreach (NpcClass value4 in concurrentDictionary3.Values)
				{
					value4.地狱火龙副本状态效果();
					Thread.Sleep(1);
				}
				break;
			}
			case 3:
			{
				ConcurrentDictionary<int, NpcClass> concurrentDictionary2 = MapClass.GetnpcPID(43001, 16607);
				foreach (NpcClass value5 in concurrentDictionary2.Values)
				{
					value5.地狱火龙副本状态效果();
					Thread.Sleep(1);
				}
				break;
			}
			case 4:
			{
				ConcurrentDictionary<int, NpcClass> concurrentDictionary = MapClass.GetnpcPID(43001, 16557);
				foreach (NpcClass value6 in concurrentDictionary.Values)
				{
					value6.地狱火龙副本状态效果();
					Thread.Sleep(1);
				}
				break;
			}
			}
		}

		public static void 进入副本提示(Players player, int time)
		{
			byte[] array = Converter.hexStringToByte("AA55AA0075050105A40008000A00000001000100000000000000100E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
			if (player.Client != null)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(player.人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(time), 0, array, 26, 4);
				player.Client.Send(array, array.Length);
			}
		}

		public static void 讨伐副本结束提示(bool 讨伐结果)
		{
			byte[] array = Converter.hexStringToByte("AA55AA0075050105A400080006000000010078000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
			if (讨伐结果)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 16, 1);
			}
			else
			{
				Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 16, 1);
			}
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				if (value.人物坐标_地图 == 43001 && value.Client != null)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(value.人物全服ID), 0, array, 4, 2);
					value.Client.Send(array, array.Length);
				}
			}
		}
	}
}
