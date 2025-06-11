using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;

namespace RxjhServer
{
	public class TeamClass : IDisposable
	{
		public List<Players> tem = new List<Players>();

		public ConcurrentDictionary<int, Players> 组队列表;

		public string 队长;

		public int 组队id;

		public int 队伍级别;

		public bool 红包;

		public int 红包时间;

		public int 道具分配规则;

		public int 当前分配;

		public Players 邀请人;

		public System.Timers.Timer 自动显示;

		private int 计数;

		public TeamClass(Players 队长_)
		{
			自动显示 = new System.Timers.Timer(2000.0);
			自动显示.Elapsed += 自动显示事件;
			自动显示.AutoReset = true;
			道具分配规则 = 0;
			当前分配 = 0;
			红包 = false;
			红包时间 = 0;
			队长 = 队长_.UserName;
			队伍级别 = 队长_.Player_Level;
			组队列表 = new ConcurrentDictionary<int, Players>();
			组队列表.TryAdd(队长_.人物全服ID, 队长_);
		}

		public void Dispose()
		{
			TeamClass value;
			try
			{
				foreach (Players value2 in 组队列表.Values)
				{
					value2.解散组队提示();
					value2.组队id = 0;
					value2.夫妻组队中 = false;
				}
				组队列表.Clear();
				World.Teams.TryRemove(组队id, out value);
				if (自动显示 != null)
				{
					自动显示.Enabled = false;
					自动显示.Close();
					自动显示.Dispose();
					自动显示 = null;
				}
				邀请人 = null;
				tem = null;
				红包 = false;
				红包时间 = 0;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "组队类 Dispose 出错!" + ex.Message);
			}
			finally
			{
				tem = null;
				组队列表 = null;
				红包 = false;
				红包时间 = 0;
				World.Teams.TryRemove(组队id, out value);
				if (自动显示 != null)
				{
					自动显示.Enabled = false;
					自动显示.Close();
					自动显示.Dispose();
					自动显示 = null;
				}
			}
		}

		private void 自动显示事件(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "组队Class-自动显示事件");
			}
			try
			{
				if (组队列表.Count <= 1)
				{
					Dispose();
					return;
				}
				计数++;
				if (红包)
				{
					红包时间 -= 3000;
					if (红包时间 <= 0)
					{
						红包 = false;
						红包时间 = 0;
					}
				}
				else
				{
					红包 = false;
					红包时间 = 0;
				}
				foreach (Players value3 in 组队列表.Values)
				{
					if (!World.AllConnectedPlayers.ContainsKey(value3.人物全服ID))
					{
						continue;
					}
					value3.显示队员();
					if (红包 && 红包时间 > 0)
					{
						if (value3.追加状态列表 != null && !value3.GetAddState(1000000050))
						{
							追加状态类 追加状态类2 = new 追加状态类(value3, 红包时间, 1000000050, 0);
							value3.追加状态列表.Add(追加状态类2.FLD_PID, 追加状态类2);
							value3.状态效果(BitConverter.GetBytes(1000000050), 1, 红包时间);
						}
					}
					else if (value3.追加状态列表 != null && value3.GetAddState(1000000050))
					{
						value3.追加状态列表[1000000050].时间结束事件();
					}
				}
				if (tem != null)
				{
					foreach (Players item in tem)
					{
						if (组队列表 != null && 组队列表.TryGetValue(item.人物全服ID, out var value4))
						{
							组队列表.TryRemove(item.人物全服ID, out value4);
						}
					}
				}
				if (tem.Count > 0)
				{
					tem.Clear();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "组队类 自动显示事件 出错!" + ex.Message);
			}
		}

		public void 委任队长(Players 本人, Players 队长类)
		{
			try
			{
				队长 = 队长类.UserName;
				foreach (Players value in 组队列表.Values)
				{
					value.委任队长提示(本人, 队长类);
					value.显示队员();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "组队类 委任队长 出错!" + ex.Message);
			}
		}

		public void 加入队员提示(Players 队员)
		{
			try
			{
				if (队员.FLD_情侣 != "")
				{
					foreach (Players value in 组队列表.Values)
					{
						if (value.UserName == 队员.FLD_情侣)
						{
							队员.夫妻组队中 = true;
							value.夫妻组队中 = true;
							break;
						}
					}
				}
				foreach (Players value2 in 组队列表.Values)
				{
					if (队员 != value2)
					{
						value2.加入组队提示(队员);
						队员.加入组队提示(value2);
					}
					value2.显示队员();
				}
				if (组队列表.Count >= 2)
				{
					自动显示.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "组队类 加入队员提示 出错!" + ex.Message);
			}
		}

		public void 退出(Players 队员, int 退出ID)
		{
			try
			{
				if (组队列表 != null && 组队列表.ContainsKey(队员.人物全服ID))
				{
					组队列表.TryRemove(队员.人物全服ID, out var _);
				}
				if (队员.GetAddState(1000000050))
				{
					队员.追加状态列表[1000000050].时间结束事件();
				}
				if (队员.FLD_情侣 != "")
				{
					队员.夫妻组队中 = false;
					foreach (Players value2 in 组队列表.Values)
					{
						if (value2.UserName == 队员.FLD_情侣)
						{
							value2.夫妻组队中 = false;
							break;
						}
					}
				}
				if (组队列表.Count >= 2)
				{
					if (队长 != 队员.UserName)
					{
						foreach (Players value3 in 组队列表.Values)
						{
							value3.退出组队提示(队员);
							value3.显示队员();
						}
					}
					else
					{
						Players toPlaye = 队员;
						bool flag = true;
						foreach (Players value4 in 组队列表.Values)
						{
							if (flag)
							{
								队长 = value4.UserName;
								toPlaye = value4;
								flag = false;
							}
							value4.委任队长提示(队员, toPlaye);
							value4.退出组队提示(队员);
							value4.显示队员();
						}
					}
				}
				else
				{
					Dispose();
				}
				队员.本人退出组队提示();
				队员.组队id = 0;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "组队类 退出 出错!" + ex.Message);
			}
		}

		public Players 得到对应队员(int key)
		{
			try
			{
				int num = 0;
				foreach (Players value in 组队列表.Values)
				{
					if (key == num)
					{
						return value;
					}
					num++;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "获取对应队员 出错!" + ex.Message);
			}
			return null;
		}
	}
}
