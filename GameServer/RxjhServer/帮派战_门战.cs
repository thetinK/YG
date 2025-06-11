using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Timers;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class 帮派战_门战
	{
		private readonly object AsyncLock = new object();

		private readonly ConcurrentDictionary<string, int> 比分表 = new ConcurrentDictionary<string, int>();

		private readonly System.Timers.Timer 门主申请记时器;

		private System.Timers.Timer 准备记时器;

		private System.Timers.Timer 开始对战记时器;

		private System.Timers.Timer 结束记时器;

		private readonly DateTime 申请时间;

		private DateTime 准备时间;

		private DateTime 开始对战;

		public 帮派战_门战()
		{
			try
			{
				World.新门战进程 = 1;
				World.帮战list = new ConcurrentDictionary<int, 帮战Class>();
				if (World.势力战开始时向其它线广播 == 1)
				{
					if (World.ServerID == 28)
					{
						string text = World.门战准备时间 + "分钟后将在[银币市场], 开启帮派战.请要参加的玩家前往[银币市场]参加";
						World.conn.发送("全线公告|" + 0 + "|" + text + "|帮派战");
					}
					else
					{
						string text2 = World.门战准备时间 + "分钟后将在" + World.ServerID + "线银币市场, 开启帮派战.请要参加的玩家前往" + World.ServerID + "线银币市场参加";
						World.conn.发送("全线公告|" + 0 + "|" + text2 + "|帮派战");
					}
				}
				申请时间 = DateTime.Now.AddMinutes(World.门战准备时间);
				门主申请记时器 = new System.Timers.Timer(60000.0);
				门主申请记时器.Elapsed += 门主申请记时器结束事件;
				门主申请记时器.Enabled = true;
				门主申请记时器.AutoReset = true;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.滚动公告(4500);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "血帮战 准备记时器结束事件 出错：" + ex);
			}
		}

		public void 门主申请记时器结束事件(object source, ElapsedEventArgs e)
		{
			try
			{
				int num = (int)申请时间.Subtract(DateTime.Now).TotalSeconds;
				if (World.势力战开始时向其它线广播 == 1)
				{
					if (World.ServerID == 28)
					{
						string text = num + "秒后将在[银币市场], 开启帮派战.请要参加的玩家前往[银币市场]参加";
						World.conn.发送("全线提示|" + 6 + "|" + text + "|" + World.ServerID);
					}
					else
					{
						string text2 = num + "秒后将在" + World.ServerID + "线银币市场, 开启帮派战.请要参加的玩家前往" + World.ServerID + "线银币市场参加";
						World.conn.发送("全线提示|" + 6 + "|" + text2 + "|" + World.ServerID);
					}
				}
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value.发送其他活动开始倒计时(num);
					value.系统提示("离门战申请还剩下" + (num + 59) / 60 + "分钟。请帮主召集帮派成员从[韦大宝]移动[银币广 场]->[上官清]处申请", 50, "系统提示");
				}
				if (num > 0)
				{
					return;
				}
				门主申请记时器.Enabled = false;
				门主申请记时器.Close();
				门主申请记时器.Dispose();
				foreach (帮战Class value2 in World.帮战list.Values)
				{
					using (new Lock(value2.申请人物列表, "帮战申请人物列表"))
					{
						foreach (Players value3 in value2.申请人物列表.Values)
						{
							value3.系统公告("门战配对成功, 请做好战斗准备, 10秒后开始门战!");
						}
					}
				}
				准备时间 = DateTime.Now.AddSeconds(World.门战准备时间);
				准备记时器 = new System.Timers.Timer(5000.0);
				准备记时器.Elapsed += 准备记时器结束事件;
				准备记时器.Enabled = true;
				准备记时器.AutoReset = true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "帮战 申请记时器结束事件 出错：" + ex);
			}
		}

		public void 准备记时器结束事件(object source, ElapsedEventArgs e)
		{
			try
			{
				if ((int)准备时间.Subtract(DateTime.Now).TotalSeconds > 0)
				{
					return;
				}
				foreach (帮战Class value3 in World.帮战list.Values)
				{
					foreach (Players value4 in value3.申请人物列表.Values)
					{
						if (value4.人物坐标_地图 == 1201 && value4.人物_HP > 0 && !value4.Player死亡 && !value4.退出中)
						{
							continue;
						}
						MainForm.WriteLine(88, "帮派[" + value3.申请帮派名称 + "]成员[" + value4.UserName + "]不符合参加门战条件|等级:" + value4.Player_Level + "|地图:" + value4.人物坐标_地图 + "|生命:" + value4.人物_HP + "|退出:" + value4.退出中 + "|进店:" + value4.进店中 + "|死亡:" + value4.Player死亡);
						value3.申请人物列表.TryRemove(value4.人物全服ID, out var _);
						if (value3.申请人物列表.Count >= 3)
						{
							continue;
						}
						MainForm.WriteLine(88, "帮派[" + value3.申请帮派名称 + "]参战人数小于5人被取消参战资格。");
						using (new Lock(World.帮战list, "帮战list"))
						{
							World.帮战list.TryRemove(value3.申请帮派ID, out var value2);
							if (World.帮战Namelist != null && World.帮战Namelist.Count > 0 && World.帮战Namelist.ContainsKey(value3.申请帮派ID))
							{
								World.帮战Namelist.TryRemove(value3.申请帮派ID, out value2);
							}
						}
					}
				}
				if (World.帮战list.Count < 2)
				{
					MainForm.WriteLine(88, "参加帮战门派数小于2个门派, 帮战取消。");
					foreach (帮战Class value5 in World.帮战list.Values)
					{
						foreach (Players value6 in value5.申请人物列表.Values)
						{
							value6.安全模式 = 0;
							if (value6.帮派人物等级 == 7)
							{
								value6.系统提示("由于没有匹配的帮派无法进行帮战, 系统返还" + World.申请门战需要元宝 + "元宝。", 6, "帮战提示");
								value6.CheckTreasureGems();
								value6.检察元宝数据(World.申请门战需要元宝, 1, "帮战");
								value6.SaveGemData();
								MainForm.WriteLine(88, "返回帮派帮主[" + value6.UserName + "]" + World.申请门战需要元宝 + "元宝");
							}
							else
							{
								value6.系统提示("由于没有匹配的帮派无法进行门战。", 6, "帮战提示");
							}
						}
					}
					World.胜利帮派ID = 0;
					if (World.帮战Namelist != null && World.帮战Namelist.Count > 0)
					{
						World.帮战Namelist.Clear();
					}
					Dispose();
					return;
				}
				World.新门战进程 = 2;
				World.是否开启门战系统 = 0;
				准备记时器.Enabled = false;
				准备记时器.Close();
				准备记时器.Dispose();
				开始对战 = DateTime.Now.AddMinutes(World.门战总时间);
				开始对战记时器 = new System.Timers.Timer(6000.0);
				开始对战记时器.Elapsed += 开始对战记时器结束事件;
				开始对战记时器.Enabled = true;
				开始对战记时器.AutoReset = true;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				foreach (帮战Class value7 in World.帮战list.Values)
				{
					switch (num)
					{
					case 0:
						num2 = 0;
						num3 = 66;
						break;
					case 1:
						num2 = 66;
						num3 = 0;
						break;
					case 2:
						num2 = 0;
						num3 = -66;
						break;
					case 3:
						num2 = -66;
						num3 = 0;
						break;
					}
					using (new Lock(value7.申请人物列表, "帮战申请人物列表"))
					{
						foreach (Players value8 in value7.申请人物列表.Values)
						{
							value8.移动(num2, num3, 15f, 7301);
							value8.帮战开始提示(1, 0);
							value8.系统公告("帮战开始, 尽情的厮杀吧！");
							value8.切换PK模式(2);
							value8.安全模式 = 0;
						}
					}
					num++;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "帮战 准备记时器结束事件 出错：" + ex);
			}
		}

		public void 开始对战记时器结束事件(object source, ElapsedEventArgs e)
		{
			try
			{
				比分表.Clear();
				int num = (int)开始对战.Subtract(DateTime.Now).TotalSeconds;
				foreach (帮战Class value in World.帮战list.Values)
				{
					比分表.TryAdd(value.申请帮派名称, value.当前分数);
				}
				int num2 = 0;
				string text = string.Empty;
				foreach (KeyValuePair<string, int> item in 比分表.OrderByDescending((KeyValuePair<string, int> pair) => pair.Value))
				{
					if (num2 < 10)
					{
						text = text + item.Key + ":" + item.Value + " ";
						num2++;
						continue;
					}
					break;
				}
				if (num <= 60)
				{
					foreach (帮战Class value2 in World.帮战list.Values)
					{
						foreach (Players value3 in value2.申请人物列表.Values)
						{
							if (value3.人物坐标_地图 == 7301)
							{
								value3.系统提示("混战时间最后剩余" + num + "秒, 加油吧。", 6, "帮战提示");
							}
						}
					}
				}
				if (num > 0)
				{
					return;
				}
				World.新门战进程 = 3;
				World.是否开启门战系统 = 0;
				foreach (帮战Class value4 in World.帮战list.Values)
				{
					foreach (Players value5 in value4.申请人物列表.Values)
					{
						if (value5.人物坐标_地图 == 7301)
						{
							value5.安全模式 = 1;
							value5.系统提示("混战时间结束, 请等待10秒公布混战结果!", 6, "帮战提示");
							value5.系统提示(text, 7, "比分排行");
						}
					}
				}
				开始对战记时器.Enabled = false;
				开始对战记时器.Close();
				开始对战记时器.Dispose();
				结束记时器 = new System.Timers.Timer(1000.0);
				结束记时器.Elapsed += 时间结束事件3;
				结束记时器.Enabled = true;
				结束记时器.AutoReset = false;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(100, "帮战 开始对战记时器结束事件 出错：" + ex);
			}
		}

		public void 更新胜利信息()
		{
			DateTime now = DateTime.Now;
			DateTime now2 = DateTime.Now;
			DBA.ExeSqlCommand($"UPDATE 门战胜利门派 SET 胜利奖励时间='{DateTime.Now.AddDays(7.0)}'");
			DBA.ExeSqlCommand($"UPDATE 门战胜利门派 SET 胜利时间='{now2}' ");
		}

		public void 时间结束事件3(object source, ElapsedEventArgs e)
		{
			try
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				foreach (帮战Class value3 in World.帮战list.Values)
				{
					foreach (Players value4 in value3.申请人物列表.Values)
					{
						if (value4.人物坐标_地图 == 7301)
						{
							门战结束奖励();
						}
					}
				}
				foreach (帮战Class value5 in World.帮战list.Values)
				{
					if (value5.当前分数 > num3)
					{
						num3 = value5.当前分数;
						string 申请帮派名称 = value5.申请帮派名称;
						string 帮主名称 = value5.帮主名称;
						num2 = value5.申请帮派ID;
						num = value5.当前分数;
					}
				}
				if (num > 0)
				{
					int num4 = 0;
					foreach (帮战Class value6 in World.帮战list.Values)
					{
						if (value6.当前分数 == num)
						{
							num4++;
						}
					}
					if (num4 == 1)
					{
						foreach (帮战Class value7 in World.帮战list.Values)
						{
							帮战Class value;
							if (value7.申请帮派ID == num2)
							{
								DBA.ExeSqlCommand($"UPDATE TBL_XWWL_Guild SET 门派武勋=门派武勋+5000, 名声=名声+3, 胜=胜+1 WHERE ID='{value7.申请帮派ID}'");
								Players players = World.检查玩家name(value7.帮派门主);
								if (players != null)
								{
									if (players.人物坐标_地图 == 7301)
									{
										try
										{
											int player_Job = players.Player_Job;
											int player_Zx = players.Player_Zx;
											players.更新门派等级(players.UserName);
											RxjhClass.Set帮派荣誉数据(value7.申请帮派名称, value7.帮派门主, value7.等级, player_Job, player_Zx, value7.当前分数, World.ZoneNumber);
											World.胜利帮派ID = value7.申请帮派ID;
											DBA.ExeSqlCommand("DELETE FROM 门战胜利门派 where 分区信息= '" + World.ZoneNumber + "'");
											DBA.ExeSqlCommand($"INSERT INTO 门战胜利门派 (门主名字, 门派名字, 帮派ID, 分区信息)values('{value7.帮派门主}','{value7.申请帮派名称}', {value7.申请帮派ID}, '{World.ZoneNumber}')");
											更新胜利信息();
											players.加载门战数据();
											foreach (Players value8 in value7.申请人物列表.Values)
											{
												if (value8.人物坐标_地图 == 7301)
												{
													jlwp(value8, sl: true);
												}
											}
											World.发送公告("[" + value7.申请帮派名称 + "]取得帮战胜利，门派全部成员得到属性奖励时间为7天！！");
										}
										catch (Exception ex)
										{
											MainForm.WriteLine(1, "帮战 Set帮派荣誉数据() 出错：" + ex);
											MainForm.WriteLine(100, "帮战 Set帮派荣誉数据() 出错：" + ex);
										}
										continue;
									}
									foreach (Players value9 in value7.申请人物列表.Values)
									{
										if (value9.人物坐标_地图 == 7301)
										{
											value9.系统提示("帮战结束, 因帮主离开帮战地图, 取消奖励。", 6, "帮战提示");
										}
									}
									if (World.帮战Namelist != null && World.帮战Namelist.Count > 0 && World.帮战Namelist.ContainsKey(value7.申请帮派ID))
									{
										World.帮战Namelist.TryRemove(value7.申请帮派ID, out value);
									}
									World.胜利帮派ID = 0;
									continue;
								}
								foreach (Players value10 in value7.申请人物列表.Values)
								{
									if (value10.人物坐标_地图 == 7301)
									{
										value10.系统提示("帮战结束, 因帮主退出游戏, 取消奖励。", 6, "帮战提示");
									}
								}
								if (World.帮战Namelist != null && World.帮战Namelist.Count > 0 && World.帮战Namelist.ContainsKey(value7.申请帮派ID))
								{
									World.帮战Namelist.TryRemove(value7.申请帮派ID, out value);
								}
								World.胜利帮派ID = 0;
								continue;
							}
							DBA.ExeSqlCommand($"UPDATE TBL_XWWL_Guild SET 门派武勋=门派武勋+500, 败=败+1 WHERE ID='{value7.申请帮派ID}'");
							foreach (Players value2 in value7.申请人物列表.Values)
							{
								jlwp(value2, sl: false);
							}
							if (World.帮战Namelist != null && World.帮战Namelist.Count > 0 && World.帮战Namelist.ContainsKey(value7.申请帮派ID))
							{
								World.帮战Namelist.TryRemove(value7.申请帮派ID, out value);
							}
						}
					}
					else
					{
						World.胜利帮派ID = 0;
						World.发送游戏特殊公告("帮派混战结束, 由于最高分相同无帮派获得胜利！", 6, "公告");
						if (World.帮战Namelist != null && World.帮战Namelist.Count > 0)
						{
							World.帮战Namelist.Clear();
						}
					}
				}
				else
				{
					World.胜利帮派ID = 0;
					World.发送游戏特殊公告("帮派混战结束, 无帮派获得胜利！", 6, "公告");
					if (World.帮战Namelist != null && World.帮战Namelist.Count > 0)
					{
						World.帮战Namelist.Clear();
					}
				}
				if (结束记时器 != null)
				{
					结束记时器.Enabled = false;
					结束记时器.Close();
					结束记时器.Dispose();
				}
				Dispose();
			}
			catch
			{
				World.胜利帮派ID = 0;
				if (World.帮战Namelist != null && World.帮战Namelist.Count > 0)
				{
					World.帮战Namelist.Clear();
				}
				if (结束记时器 != null)
				{
					结束记时器.Enabled = false;
					结束记时器.Close();
					结束记时器.Dispose();
				}
				Dispose();
			}
		}

		public void jlwp(Players Play, bool sl)
		{
			try
			{
				if (Play == null || !sl)
				{
					return;
				}
				DataTable dBToDataTable = DBA.GetDBToDataTable("select * from [门战胜利门派] where 分区信息= '" + World.ZoneNumber + "' ");
				if (dBToDataTable.Rows[0]["门派名字"].ToString() == Play.帮派名字)
				{
					if (dBToDataTable.Rows[0]["门主名字"].ToString() == Play.UserName)
					{
						if (Play.追加状态列表.ContainsKey(900000047))
						{
							Play.追加状态列表[900000047].时间结束事件();
						}
						int num = 604800000;
						追加状态类 追加状态类2 = new 追加状态类(Play, num, 900000047, 1);
						Play.追加状态列表.Add(追加状态类2.FLD_PID, 追加状态类2);
						Play.状态效果(BitConverter.GetBytes(900000047), 1, num);
						Play.FLD_人物_追加_攻击 += 100;
						Play.FLD_人物_追加_防御 += 100;
						Play.人物追加最大_HP += 500;
						Play.FLD_人物_追加_气功++;
						Play.更新HP_MP_SP();
						Play.更新武功和状态();
						Play.更新气功();
					}
					else
					{
						if (Play.追加状态列表.ContainsKey(900000046))
						{
							Play.追加状态列表[900000046].时间结束事件();
						}
						int num2 = 604800000;
						追加状态类 追加状态类3 = new 追加状态类(Play, num2, 900000046, 1);
						Play.追加状态列表.Add(追加状态类3.FLD_PID, 追加状态类3);
						Play.状态效果(BitConverter.GetBytes(900000046), 1, num2);
						Play.FLD_人物_追加_攻击 += 60;
						Play.FLD_人物_追加_防御 += 60;
						Play.人物追加最大_HP += 300;
						Play.更新HP_MP_SP();
						Play.更新武功和状态();
						Play.更新气功();
					}
				}
				dBToDataTable.Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(100, "帮战 发放奖励物品 出错：" + ex);
			}
		}

		public void Dispose()
		{
			try
			{
				World.新门战进程 = 0;
				World.是否开启门战系统 = 0;
				if (World.帮战list.Count > 0)
				{
					foreach (帮战Class value in World.帮战list.Values)
					{
						foreach (Players value2 in value.申请人物列表.Values)
						{
							value2.系统倒计时(0, 0);
							value2.移动(value2.人物坐标_X, value2.人物坐标_Y, value2.人物坐标_Z, 1201);
							value2.安全模式 = 0;
							value2.切换PK模式(0);
						}
					}
				}
				if (门主申请记时器 != null)
				{
					门主申请记时器.Enabled = false;
					门主申请记时器.Close();
					门主申请记时器.Dispose();
				}
				if (准备记时器 != null)
				{
					准备记时器.Enabled = false;
					准备记时器.Close();
					准备记时器.Dispose();
				}
				if (开始对战记时器 != null)
				{
					开始对战记时器.Enabled = false;
					开始对战记时器.Close();
					开始对战记时器.Dispose();
				}
				if (结束记时器 != null)
				{
					结束记时器.Enabled = false;
					结束记时器.Close();
					结束记时器.Dispose();
				}
				if (World.帮战list.Count > 0)
				{
					World.帮战list.Clear();
				}
				World.GuildWar = null;
				string text = "门战活动已经结束";
				World.conn.发送("全线公告|" + 1 + "|" + text + "|帮派战");
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "帮战 Dispose() 出错：" + ex);
			}
		}

		public void 门战结束奖励()
		{
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				foreach (GuildWarData value2 in World.guildWarDataList.Values)
				{
					if (value.人物坐标_地图 != 7301)
					{
						continue;
					}
					if (value2.行会名字 == value.帮派名字)
					{
						if (value.追加状态列表.ContainsKey(1008001321))
						{
							value.追加状态列表[1008001321].时间结束事件();
						}
						追加状态类 追加状态类2 = new 追加状态类(value, 86400000, 1008001321, 1);
						value.追加状态列表.Add(追加状态类2.FLD_PID, 追加状态类2);
						value.状态效果(BitConverter.GetBytes(1008001321), 1, 86400000);
						value.人物追加最大_HP += 300;
						value.FLD_人物_追加_回避 += (int)((double)value.FLD_回避 * 0.05);
						value.FLD_人物_武功攻击力增加百分比 += 0.1;
						value.FLD_人物_追加_气功 += 2;
						value.CheckTreasureGems();
						value.检察元宝数据(int.Parse(World.门战奖励[0]), 1, "门站奖励");
						value.CheckGemPointsData(int.Parse(World.门战奖励[1]), 1, "门站奖励");
						value.Player_WuXun += int.Parse(World.门战奖励[2]);
						value.更新HP_MP_SP();
						value.SaveGemData();
						value.更新气功();
						value.更新武功和状态();
						value.更新人物数据(value);
						value.更新广播人物数据();
						value.系统提示("系统奖励门战胜利者每人" + World.门战奖励[0] + "元宝", 10, "系统提示");
						value.系统提示("系统奖励门战胜利者每人" + World.门战奖励[1] + "钻石", 10, "系统提示");
						value.系统提示("系统奖励门战胜利者每人" + World.门战奖励[2] + "点的武勋", 10, "系统提示");
					}
					else
					{
						if (value.追加状态列表.ContainsKey(1008001321))
						{
							value.追加状态列表[1008001321].时间结束事件();
						}
						value.CheckTreasureGems();
						value.检察元宝数据(int.Parse(World.门战奖励[3]), 1, "门站奖励");
						value.CheckGemPointsData(int.Parse(World.门战奖励[4]), 1, "门站奖励");
						value.Player_WuXun += int.Parse(World.门战奖励[5]);
						value.更新武功和状态();
						value.更新广播人物数据();
						value.SaveGemData();
						value.系统提示("系统奖励门战参与者每人" + World.门战奖励[3] + "元宝", 10, "系统提示");
						value.系统提示("系统奖励门战参与者每人" + World.门战奖励[4] + "钻石", 10, "系统提示");
						value.系统提示("系统奖励门战参与者每人" + World.门战奖励[5] + "点的武勋", 10, "系统提示");
					}
				}
			}
		}
	}
}
