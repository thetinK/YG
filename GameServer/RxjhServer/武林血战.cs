using System;
using System.Timers;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class 武林血战 : IDisposable
	{
		private readonly object AsyncLock = new object();

		private readonly System.Timers.Timer 准备记时器;

		private System.Timers.Timer 开始对战记时器1;

		private System.Timers.Timer 开始对战记时器2;

		private System.Timers.Timer 开始对战记时器3;

		private System.Timers.Timer 休息记时器1;

		private System.Timers.Timer 休息记时器2;

		private System.Timers.Timer 结束计时器;

		private readonly DateTime 准备时间;

		private DateTime 开始对战1;

		private DateTime 中间休息1;

		private DateTime 开始对战2;

		private DateTime 中间休息2;

		private DateTime 开始对战3;

		private DateTime 结束对战;

		public 武林血战()
		{
			try
			{
				World.武林血战人数 = 0;
				准备时间 = DateTime.Now.AddMinutes(3.0);
				准备记时器 = new System.Timers.Timer(20000.0);
				准备记时器.Elapsed += 准备记时器结束事件;
				准备记时器.Enabled = true;
				准备记时器.AutoReset = true;
				准备记时器结束事件(null, null);
				World.MartialBloodBattleProgress = 1;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "武林血战 准备记时器结束事件 出错：" + ex);
			}
		}

		public void 准备记时器结束事件(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "准备记时器结束事件");
			}
			try
			{
				int num = (int)准备时间.Subtract(DateTime.Now).TotalSeconds;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 8001)
					{
						value.武林杀人数 = 0;
						value.发送其他活动开始倒计时(num);
						value.系统提示("离武林血战开始还剩下" + num + "秒。请做好准备", 22, "武林血战");
					}
					else if (value.Player_Job_leve >= 3)
					{
						value.武林杀人数 = 0;
						value.系统滚动公告("离武林血战开始及参加申请还剩下" + num + "秒。请到银币广场[雪中轩]处申请");
						value.系统提示("离武林血战开始及参加申请还剩下" + num + "秒。请到银币广场[雪中轩]处申请", 10, "系统信息");
					}
				}
				if (num > 0)
				{
					return;
				}
				准备记时器.Enabled = false;
				准备记时器.Close();
				准备记时器.Dispose();
				int num2 = 0;
				string[] array = World.武林血战参加奖励.Split(',');
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					if (value2.人物坐标_地图 != 8001)
					{
						continue;
					}
					num2++;
					if (array.Length >= 2)
					{
						if (int.Parse(array[0]) > 0)
						{
							value2.系统提示("您参与武林血战系统奖励" + array[0] + "点的元宝", 10, "奖励提示");
						}
						if (int.Parse(array[1]) > 0)
						{
							value2.系统提示("您参与武林血战系统奖励" + array[1] + "点的武勋", 10, "奖励提示");
						}
						value2.增加属性(int.Parse(array[0]), int.Parse(array[1]));
						value2.更新武功和状态();
					}
				}
				if (num2 > 10)
				{
					foreach (Players value3 in World.AllConnectedPlayers.Values)
					{
						if (value3.人物坐标_地图 == 8001)
						{
							value3.系统提示("第一回合开始", 22, "武林血战");
							value3.切换PK模式(2);
						}
					}
					World.MartialBloodBattleProgress = 2;
					World.武林血战人数 = num2;
					开始对战1 = DateTime.Now.AddMinutes(10.0);
					开始对战记时器1 = new System.Timers.Timer(1000.0);
					开始对战记时器1.Elapsed += 开始对战记时器结束事件1;
					开始对战记时器1.Enabled = true;
					开始对战记时器1.AutoReset = true;
				}
				else
				{
					World.GlobalNotification("武林提示", 10, "武林血战参加人数少于[10]人，自动结束活动。传送至泫勃派");
					Dispose();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "武林血战 准备记时器结束事件 出错：" + ex);
			}
		}

		public void 开始对战记时器结束事件1(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "开始对战记时器结束事件");
			}
			try
			{
				int num = (int)开始对战1.Subtract(DateTime.Now).TotalSeconds;
				int num2 = 0;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 8001)
					{
						num2++;
					}
				}
				if (num2 < 10)
				{
					World.MartialBloodBattleProgress = 3;
					开始对战记时器1.Enabled = false;
					开始对战记时器1.Close();
					开始对战记时器1.Dispose();
					中间休息1 = DateTime.Now.AddMinutes(1.0);
					休息记时器1 = new System.Timers.Timer(1000.0);
					休息记时器1.Elapsed += 对战休息记时器结束事件1;
					休息记时器1.Enabled = true;
					休息记时器1.AutoReset = true;
					string[] array = World.武林血战第一回合奖励.Split(',');
					foreach (Players value2 in World.AllConnectedPlayers.Values)
					{
						if (value2.人物坐标_地图 != 8001)
						{
							continue;
						}
						value2.人物_HP = value2.人物最大_HP;
						value2.人物_MP = value2.人物最大_MP;
						value2.更新HP_MP_SP();
						value2.移动(value2.人物坐标_X, value2.人物坐标_Y, value2.人物坐标_Z, 8001);
						value2.系统提示("第一回合结束, 中间休息1分钟, 一分钟后开始第二回合", 22, "武林血战");
						if (array.Length >= 2)
						{
							if (int.Parse(array[0]) > 0)
							{
								value2.系统提示("第一回合胜出系统奖励您" + array[0] + "点的元宝", 10, "奖励提示");
							}
							if (int.Parse(array[1]) > 0)
							{
								value2.系统提示("第一回合胜出系统奖励您" + array[1] + "点的武勋", 10, "奖励提示");
							}
							value2.增加属性(int.Parse(array[0]), int.Parse(array[1]));
							value2.更新武功和状态();
						}
					}
				}
				else if (num <= 0)
				{
					Dispose();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "武林血战 开始对战记时器结束事件 出错：" + ex);
			}
		}

		public void 对战休息记时器结束事件1(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "开始对战记时器结束事件");
			}
			try
			{
				if ((int)中间休息1.Subtract(DateTime.Now).TotalSeconds > 0)
				{
					return;
				}
				World.MartialBloodBattleProgress = 2;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 8001)
					{
						value.系统提示("第二回合开始", 22, "武林血战");
						value.切换PK模式(2);
					}
				}
				休息记时器1.Enabled = false;
				休息记时器1.Close();
				休息记时器1.Dispose();
				开始对战2 = DateTime.Now.AddMinutes(10.0);
				开始对战记时器2 = new System.Timers.Timer(1000.0);
				开始对战记时器2.Elapsed += 开始对战记时器结束事件2;
				开始对战记时器2.Enabled = true;
				开始对战记时器2.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "武林血战 开始对战记时器结束事件 出错：" + ex);
			}
		}

		public void 开始对战记时器结束事件2(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "开始对战记时器结束事件");
			}
			try
			{
				int num = (int)开始对战2.Subtract(DateTime.Now).TotalSeconds;
				int num2 = 0;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 8001)
					{
						num2++;
					}
				}
				if (num2 < 5)
				{
					World.MartialBloodBattleProgress = 3;
					开始对战记时器2.Enabled = false;
					开始对战记时器2.Close();
					开始对战记时器2.Dispose();
					中间休息2 = DateTime.Now.AddMinutes(1.0);
					休息记时器2 = new System.Timers.Timer(1000.0);
					休息记时器2.Elapsed += 对战休息记时器结束事件2;
					休息记时器2.Enabled = true;
					休息记时器2.AutoReset = true;
					string[] array = World.武林血战第二回合奖励.Split(',');
					foreach (Players value2 in World.AllConnectedPlayers.Values)
					{
						if (value2.人物坐标_地图 != 8001)
						{
							continue;
						}
						value2.人物_HP = value2.人物最大_HP;
						value2.人物_MP = value2.人物最大_MP;
						value2.更新HP_MP_SP();
						value2.移动(value2.人物坐标_X, value2.人物坐标_Y, value2.人物坐标_Z, 8001);
						value2.系统提示("第二回合结束, 中间休息1分钟, 一分钟后开始第三回合", 22, "武林血战");
						if (array.Length >= 2)
						{
							if (int.Parse(array[0]) > 0)
							{
								value2.系统提示("第二回合胜出系统奖励您" + array[0] + "点的元宝", 10, "奖励提示");
							}
							if (int.Parse(array[1]) > 0)
							{
								value2.系统提示("第二回合胜出系统奖励您" + array[1] + "点的武勋", 10, "奖励提示");
							}
							value2.增加属性(int.Parse(array[0]), int.Parse(array[1]));
							value2.更新武功和状态();
						}
					}
				}
				else if (num <= 0)
				{
					Dispose();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "武林血战 开始对战记时器结束事件 出错：" + ex);
			}
		}

		public void 对战休息记时器结束事件2(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "开始对战记时器结束事件");
			}
			try
			{
				if ((int)中间休息2.Subtract(DateTime.Now).TotalSeconds > 0)
				{
					return;
				}
				World.MartialBloodBattleProgress = 2;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 8001)
					{
						value.系统提示("第三回合开始", 22, "武林血战");
					}
				}
				休息记时器2.Enabled = false;
				休息记时器2.Close();
				休息记时器2.Dispose();
				开始对战3 = DateTime.Now.AddMinutes(10.0);
				开始对战记时器3 = new System.Timers.Timer(1000.0);
				开始对战记时器3.Elapsed += 开始对战记时器结束事件3;
				开始对战记时器3.Enabled = true;
				开始对战记时器3.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "武林血战 开始对战记时器结束事件 出错：" + ex);
			}
		}

		public void 开始对战记时器结束事件3(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "开始对战记时器结束事件");
			}
			try
			{
				if ((int)开始对战3.Subtract(DateTime.Now).TotalSeconds <= 0)
				{
					Dispose();
				}
				int num = 0;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 8001)
					{
						num++;
					}
				}
				if (num != 1)
				{
					return;
				}
				World.MartialBloodBattleProgress = 2;
				开始对战记时器3.Enabled = false;
				开始对战记时器3.Close();
				开始对战记时器3.Dispose();
				结束对战 = DateTime.Now.AddMinutes(10.0);
				结束计时器 = new System.Timers.Timer(1000.0);
				结束计时器.Elapsed += 结束对战记时器结束事件;
				结束计时器.Enabled = true;
				结束计时器.AutoReset = true;
				string[] array = World.武林血战第三回合奖励.Split(',');
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					if (value2.人物坐标_地图 != 8001)
					{
						continue;
					}
					value2.人物_MP = value2.人物最大_MP;
					value2.人物_HP = value2.人物最大_HP;
					value2.更新HP_MP_SP();
					value2.移动(value2.人物坐标_X, value2.人物坐标_Y, value2.人物坐标_Z, 8001);
					if (array.Length >= 2)
					{
						if (int.Parse(array[0]) > 0)
						{
							value2.系统提示("第三回合胜出系统奖励您" + array[0] + "点的元宝", 10, "奖励提示");
						}
						if (int.Parse(array[1]) > 0)
						{
							value2.系统提示("第三回合胜出系统奖励您" + array[1] + "点的武勋", 10, "奖励提示");
						}
						value2.增加属性(int.Parse(array[0]), int.Parse(array[1]));
						value2.更新武功和状态();
					}
					int num2 = value2.得到包裹空位(value2);
					if (num2 != -1)
					{
						value2.增加物品(BitConverter.GetBytes(RxjhClass.GetDBItmeId()), BitConverter.GetBytes(World.武林血战奖励礼包), num2, BitConverter.GetBytes(1), new byte[56]);
						value2.系统提示("武林血战第一名奖励礼包。");
					}
					else
					{
						value2.系统提示("背包没空位了。");
					}
					value2.系统提示("全部回合结束", 22, "武林血战");
					if (value2.人物_战斗增加_HP > 0)
					{
						value2.人物_战斗增加_HP = 0;
					}
					value2.人物_HP = value2.人物最大_HP;
					if (value2.人物_战斗增加_MP > 0)
					{
						value2.人物_战斗增加_MP = 0;
					}
					value2.人物_MP = value2.人物最大_MP;
					value2.更新HP_MP_SP();
					if (World.老泫勃派开关 == 1)
					{
						value2.移动(495f, 1727f, 15f, 29000);
					}
					else
					{
						value2.移动(415f, 1528f, 15f, 101);
					}
					World.GlobalNotification("武林血战", 10, "恭喜玩家[" + value2.UserName + "]取得武林血战的最后胜利");
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "武林血战 开始对战记时器结束事件 出错：" + ex);
			}
		}

		public void 结束对战记时器结束事件(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "结束对战记时器结束事件");
			}
			try
			{
				if ((int)结束对战.Subtract(DateTime.Now).TotalSeconds > 0)
				{
					return;
				}
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 8001)
					{
						value.系统提示("全部回合结束", 22, "武林血战");
						if (value.人物_战斗增加_HP > 0)
						{
							value.人物_战斗增加_HP = 0;
						}
						value.人物_HP = value.人物最大_HP;
						if (value.人物_战斗增加_MP > 0)
						{
							value.人物_战斗增加_MP = 0;
						}
						value.人物_HP = value.人物最大_MP;
						value.更新HP_MP_SP();
						if (World.老泫勃派开关 == 1)
						{
							value.移动(495f, 1727f, 15f, 29000);
						}
						else
						{
							value.移动(415f, 1528f, 15f, 101);
						}
						value.切换PK模式(0);
					}
				}
				结束计时器.Enabled = false;
				结束计时器.Close();
				结束计时器.Dispose();
				Dispose();
			}
			catch (Exception ex)
			{
				Dispose();
				MainForm.WriteLine(1, "武林血战 结束对战记时器结束事件 出错：" + ex);
			}
		}

		public void Dispose()
		{
			try
			{
				World.MartialBloodBattleProgress = 0;
				if (准备记时器 != null)
				{
					准备记时器.Enabled = false;
					准备记时器.Close();
					准备记时器.Dispose();
				}
				if (开始对战记时器1 != null)
				{
					开始对战记时器1.Enabled = false;
					开始对战记时器1.Close();
					开始对战记时器1.Dispose();
				}
				if (开始对战记时器2 != null)
				{
					开始对战记时器2.Enabled = false;
					开始对战记时器2.Close();
					开始对战记时器2.Dispose();
				}
				if (开始对战记时器3 != null)
				{
					开始对战记时器3.Enabled = false;
					开始对战记时器3.Close();
					开始对战记时器3.Dispose();
				}
				if (结束计时器 != null)
				{
					结束计时器.Enabled = false;
					结束计时器.Close();
					结束计时器.Dispose();
				}
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 8001 || value.人物坐标_地图 == 8002 || value.人物坐标_地图 == 8003 || value.人物坐标_地图 == 8004 || value.人物坐标_地图 == 8005)
					{
						if (value.人物_战斗增加_HP > 0)
						{
							value.人物_战斗增加_HP = 0;
						}
						value.人物_HP = value.人物最大_HP;
						if (value.人物_战斗增加_MP > 0)
						{
							value.人物_战斗增加_MP = 0;
						}
						value.人物_HP = value.人物最大_MP;
						value.更新HP_MP_SP();
						if (World.老泫勃派开关 == 1)
						{
							value.移动(495f, 1727f, 15f, 29000);
						}
						else
						{
							value.移动(415f, 1528f, 15f, 101);
						}
						value.武林杀人数 = 0;
						value.切换PK模式(0);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "武林血战 Dispose() 出错：" + ex);
			}
		}
	}
}
