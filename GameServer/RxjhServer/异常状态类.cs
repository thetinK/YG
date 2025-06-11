using System;
using System.Timers;
using RxjhServer.HelperTools;

namespace RxjhServer
{
	public class 异常状态类 : IDisposable
	{
		public System.Timers.Timer npcyd;

		public System.Timers.Timer yczt;

		public double ycztsl;

		public DateTime time;

		public Players Play;

		public Players PlayS;

		public NpcClass Npc;

		public int NpcPlayId;

		private int _FLD_PID;

		private double _FLD_NUM;

		public int FLD_PID
		{
			get
			{
				return _FLD_PID;
			}
			set
			{
				_FLD_PID = value;
			}
		}

		public double FLD_NUM
		{
			get
			{
				return _FLD_NUM;
			}
			set
			{
				_FLD_NUM = value;
			}
		}

		public void Dispose()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-Dispose");
			}
			if (npcyd != null)
			{
				npcyd.Enabled = false;
				npcyd.Close();
				npcyd.Dispose();
				npcyd = null;
			}
			if (yczt != null)
			{
				yczt.Enabled = false;
				yczt.Close();
				yczt.Dispose();
				yczt = null;
			}
			Play = null;
			Npc = null;
		}

		public 异常状态类(Players Play_, int 时间, int 异常ID, double 异常数量)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-NEW");
			}
			FLD_PID = 异常ID;
			FLD_NUM = 异常数量;
			time = DateTime.Now;
			time = time.AddMilliseconds(时间);
			Play = Play_;
			npcyd = new System.Timers.Timer(时间);
			npcyd.Elapsed += 时间结束事件1;
			npcyd.Enabled = true;
			npcyd.AutoReset = false;
			状态效果(FLD_PID, 1, (int)异常数量, 时间 / 1000);
		}

		public 异常状态类(Players Players, NpcClass Play_, int _NpcPlayId, int 时间, int 异常ID, double 异常数量)
		{
			PlayS = Players;
			NpcPlayId = _NpcPlayId;
			FLD_PID = 异常ID;
			time = DateTime.Now;
			time = time.AddMilliseconds(时间);
			Npc = Play_;
			npcyd = new System.Timers.Timer(时间);
			npcyd.Elapsed += 时间结束事件1;
			npcyd.Enabled = true;
			npcyd.AutoReset = false;
			FLD_NUM = 异常数量;
			状态效果(FLD_PID, 1, (int)异常数量, 时间 / 1000);
		}

		public 异常状态类(Players Play_, int 时间, int 异常ID, double 异常数量, int 每秒执行)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-NEW");
			}
			FLD_PID = 异常ID;
			FLD_NUM = 异常数量;
			time = DateTime.Now;
			time = time.AddMilliseconds(时间);
			Play = Play_;
			npcyd = new System.Timers.Timer(时间);
			npcyd.Elapsed += 时间结束事件1;
			npcyd.Enabled = true;
			npcyd.AutoReset = false;
			状态效果(FLD_PID, 1, (int)异常数量, 时间 / 1000, 每秒执行);
		}

		public void 异常状态类出血(double ycztsll)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-异常状态类出血");
			}
			ycztsl = ycztsll;
			yczt = new System.Timers.Timer(1000.0);
			yczt.Elapsed += yczt_Elapsed;
			yczt.Enabled = true;
			yczt.AutoReset = true;
		}

		public void 异常状态类出血怪物(Players Play, double ycztsll)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-异常状态类出血怪物");
			}
			PlayS = Play;
			ycztsl = ycztsll;
			yczt = new System.Timers.Timer(1000.0);
			yczt.Elapsed += yczt_Elapsed;
			yczt.Enabled = true;
			yczt.AutoReset = true;
		}

		public void 异常状态类出血红潮散(double ycztsll)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-异常状态类出血红潮散");
			}
			ycztsl = ycztsll;
			yczt = new System.Timers.Timer(3000.0);
			yczt.Elapsed += yczt_Elapsed;
			yczt.Enabled = true;
			yczt.AutoReset = true;
		}

		public void 异常状态类掉蓝(double ycztsll)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-异常状态类出血");
			}
			ycztsl = ycztsll;
			yczt = new System.Timers.Timer(3000.0);
			yczt.Elapsed += yczt_Elapsed蓝;
			yczt.Enabled = true;
			yczt.AutoReset = true;
		}

		public void yczt_Elapsed蓝(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "yczt_Elapsed");
			}
			if (Play != null && !Play.Player死亡 && !Play.退出中 && !Play.交易.交易中 && !Play.打开仓库中 && !Play.进店中)
			{
				Play.人物_MP -= (int)ycztsl;
				if (Play.人物_MP <= 0)
				{
					Play.人物_MP = 0;
				}
				Play.更新HP_MP_SP();
			}
		}

		public void yczt_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "yczt_Elapsed");
			}
			if (Play != null)
			{
				if (Play.Player死亡 || Play.退出中 || Play.交易.交易中 || Play.打开仓库中 || Play.进店中)
				{
					return;
				}
				Play.人物_HP -= (int)ycztsl;
				if (Play.人物_HP <= 0)
				{
					Play.死亡2();
					if (yczt != null)
					{
						yczt.Enabled = false;
						yczt.Close();
						yczt.Dispose();
						yczt = null;
					}
				}
				Play.更新HP_MP_SP();
			}
			else
			{
				if (Npc == null)
				{
					return;
				}
				Npc.Rxjh_HP -= (int)ycztsl;
				Npc.Play_Hit(PlayS, (int)ycztsl);
				if (Npc.Rxjh_HP <= 0)
				{
					Npc.发送死亡数据(NpcPlayId);
					if (yczt != null)
					{
						yczt.Enabled = false;
						yczt.Close();
						yczt.Dispose();
						yczt = null;
					}
				}
			}
		}

		public 异常状态类(NpcClass Play_, int _NpcPlayId, int 时间, int 异常ID, double 异常数量)
		{
			NpcPlayId = _NpcPlayId;
			FLD_PID = 异常ID;
			time = DateTime.Now;
			time = time.AddMilliseconds(时间);
			Npc = Play_;
			npcyd = new System.Timers.Timer(时间);
			npcyd.Elapsed += 时间结束事件1;
			npcyd.Enabled = true;
			npcyd.AutoReset = false;
			FLD_NUM = 异常数量;
			状态效果(FLD_PID, 1, (int)异常数量, 时间 / 1000);
		}

		public 异常状态类(NpcClass Play_, int _NpcPlayId, int 时间, int 异常ID, double 异常数量, int 每秒执行)
		{
			NpcPlayId = _NpcPlayId;
			FLD_PID = 异常ID;
			time = DateTime.Now;
			time = time.AddMilliseconds(时间);
			Npc = Play_;
			npcyd = new System.Timers.Timer(时间);
			npcyd.Elapsed += 时间结束事件1;
			npcyd.Enabled = true;
			npcyd.AutoReset = false;
			FLD_NUM = 异常数量;
			状态效果(FLD_PID, 1, (int)异常数量, 时间 / 1000, 每秒执行);
		}

		public void 时间结束事件1(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "时间结束事件1");
			}
			时间结束事件();
		}

		public void 时间结束事件()
		{
			int num = 0;
			try
			{
				if (npcyd != null)
				{
					num = 1;
					npcyd.Enabled = false;
					num = 2;
					npcyd.Close();
					num = 3;
					npcyd.Dispose();
					num = 4;
					npcyd = null;
				}
				num = 5;
				if (Npc != null)
				{
					_ = FLD_PID;
					num = 6;
					if (Npc.异常状态 != null)
					{
						num = 7;
						Npc.异常状态.TryRemove(FLD_PID, out var _);
						num = 8;
					}
					num = 9;
					状态效果(FLD_PID, 0, 0, 0);
					if (FLD_PID == 44)
					{
						Npc.触发阎王爆(PlayS, NpcPlayId);
					}
					num = 10;
					Dispose();
				}
				else
				{
					if (Play == null)
					{
						return;
					}
					num = 11;
					switch (FLD_PID)
					{
					case 242:
						Play.FLD_人物_追加_攻击 -= 15;
						Play.FLD_人物_追加_防御 -= 15;
						Play.人物追加最大_HP -= 300;
						Play.人物追加最大_MP -= 300;
						Play.FLD_人物_追加_经验百分比 -= 0.2;
						if (Play.FLD_人物_追加_经验百分比 < 0.0)
						{
							Play.FLD_人物_追加_经验百分比 = 0.0;
						}
						Play.FLD_结婚礼物_追加_属性石 = 0;
						Play.更新武功和状态();
						Play.更新HP_MP_SP();
						break;
					case 1:
						Play.FLD_药品_减少攻击 += FLD_NUM;
						Play.更新武功和状态();
						break;
					case 2:
						Play.FLD_药品_减少防御 += FLD_NUM;
						Play.更新武功和状态();
						break;
					case 3:
						Play.中毒 = false;
						break;
					case 4:
						Play.人物锁定 = false;
						break;
					case 6:
						Play.FLD_追加百分比_HP上限 += FLD_NUM;
						Play.更新HP_MP_SP();
						break;
					case 7:
						Play.FLD_追加百分比_MP上限 += FLD_NUM;
						Play.更新HP_MP_SP();
						break;
					case 8:
						Play.人物锁定 = false;
						break;
					case 9:
						Play.addFLD_追加百分比_防御(0.07);
						Play.更新武功和状态();
						break;
					case 14:
						Play.FLD_药品_减少防御 += FLD_NUM;
						Play.更新武功和状态();
						break;
					case 17:
						Play.人物锁定 = false;
						break;
					case 26:
						Play.人物锁定 = false;
						break;
					case 28:
						Play.安全模式 = 1;
						Play.人物锁定 = false;
						break;
					}
					num = 22;
					if (Play.异常状态 != null)
					{
						num = 23;
						Play.异常状态.Remove(FLD_PID);
					}
					num = 24;
					状态效果(FLD_PID, 0, 0, 0);
					num = 25;
					Dispose();
					return;
				}
			}
			catch (Exception ex)
			{
				if (World.是否开启票红字 == 1)
				{
					MainForm.WriteLine(100, num + "|异常状态类 时间结束事件 出错：[" + FLD_PID + "]" + ex);
				}
			}
			finally
			{
				Dispose();
			}
		}

		public void 状态效果(int 异常ID, int 开关, int 异常数量, int 时间, int 每秒执行)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-状态效果");
			}
			byte[] array = Converter.hexStringToByte("AA5546003527401538008C0300002C0100000900000001000000000000006016A2496016A2492600000014000000000000008C030000E80300000900000001000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(异常ID), 0, array, 18, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(异常ID), 0, array, 58, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(开关), 0, array, 22, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(开关), 0, array, 62, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(时间), 0, array, 38, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(每秒执行), 0, array, 54, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(异常数量), 0, array, 42, 4);
			if (Play != null)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(Play.人物全服ID), 0, array, 14, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(Play.人物全服ID), 0, array, 4, 2);
				if (Play.Client != null)
				{
					Play.Client.Send多包(array, array.Length);
				}
				Play.发送当前范围广播数据多包(array, array.Length);
			}
			else if (Npc != null)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(Npc.FLD_INDEX), 0, array, 14, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(Npc.FLD_INDEX), 0, array, 4, 2);
				Npc.广播数据(array, array.Length);
			}
		}

		public void 状态效果(int 异常ID, int 开关, int 异常数量, int 时间)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "异常状态类-状态效果");
			}
			byte[] array = Converter.hexStringToByte("AA5546003527401538008C0300002C0100000900000001000000000000006016A2496016A2492600000014000000000000008C030000E80300000900000001000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(异常ID), 0, array, 18, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(异常ID), 0, array, 58, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(开关), 0, array, 22, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(开关), 0, array, 62, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(时间), 0, array, 38, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(异常数量), 0, array, 42, 4);
			if (Play != null)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(Play.人物全服ID), 0, array, 14, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(Play.人物全服ID), 0, array, 4, 2);
				if (Play.Client != null)
				{
					Play.Client.Send多包(array, array.Length);
				}
				Play.发送当前范围广播数据多包(array, array.Length);
			}
			else if (Npc != null)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(Npc.FLD_INDEX), 0, array, 14, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(Npc.FLD_INDEX), 0, array, 4, 2);
				Npc.广播数据(array, array.Length);
			}
		}
	}
}
