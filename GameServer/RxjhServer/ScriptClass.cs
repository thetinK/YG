using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NLua;

namespace RxjhServer
{
	public class ScriptClass
	{
		public ConcurrentDictionary<int, LuaFunction> 任务事件列表 = new ConcurrentDictionary<int, LuaFunction>();

		public string 脚本目录 = "script";

		public LuaFunction 怪物死亡事件;

		public LuaFunction 打开物品事件;

		public LuaFunction 物品兑换事件;

		public Lua pLuaVM;

		private string _更新HP_MP_SP;

		private string _删除任务物品;

		private string _检查任务物品数量;

		private string _计算人物基本数据;

		private string _学习技能提示;

		private string _设置人物元宝;

		private string _设置人物会员;

		private string _设置玩家等级;

		private string _物品使用;

		private string _删除物品;

		private string _得到包裹物品;

		private string _学习升天武功书;

		private string _初始话已装备物品;

		private string _更新经验和历练;

		private string _更新金钱和负重;

		private string _更新武功和状态;

		private string _新学气功;

		private string _人物转职业;

		private string _得到包裹空位位置;

		private string _得到包裹空位位置组;

		private string _Get任务阶段;

		private string _GetWorldItme;

		private string _GetPlayerThis;

		private string _增加物品Script;

		private string _得到任务物品;

		private string _增加任务物品;

		private string _增加物品带属性;

		private string _任务提示数据发送;

		private string _系统提示;

		private string _设置任务数据;

		private string _学习技能;

		private string _发送六转技能书;

		private string _发送七转技能书;

		private string _发送八转技能书;

		private string _发送九转技能书;

		private string _发送公告;

		private string _追加状态物品;

		private string _得到包裹空位数;

		private string _GetPlayer_Name;

		private string _GetPlayer_Level;

		private string _GetPlayer_Job;

		private string _GetPlayer_Zx;

		private string _GetPlayer_Job_Level;

		private string _GetPlayer_Qigong_Point;

		private string _SetPlayer_Money;

		private string _GetPlayer_Sex;

		private string _GetPlayer_Wx;

		private string _SetPlayer_Wx;

		private string _GetWorldItme_Level;

		private string _GetWorldItme_Zx;

		private string _GetWorldItme_Reside1;

		private string _GetWorldItme_Job_Level;

		private string _SetPlayer_ExpErience;

		private string _GetPlayer_ExpErience;

		public ScriptClass()
		{
			注册脚本API();
			脚本目录 = Application.StartupPath + "\\Script";
			GetUrlDirectory(脚本目录);
			MainForm.WriteLine(2, "加载脚本完成");
			注册事件();
		}

		public void 注册事件()
		{
			打开物品事件 = pLuaVM.GetFunction("OpenItmeTrigGer");
			怪物死亡事件 = pLuaVM.GetFunction("DestroyMonster");
			物品兑换事件 = pLuaVM.GetFunction("ExchangeItem");
		}

		public void SetUrlFile(string Url)
		{
			if (Path.GetExtension(Url) == ".lua")
			{
				try
				{
					pLuaVM.DoFile(Url);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					MainForm.WriteLine(2, "加载Lua脚本出错" + ex.Message);
				}
			}
		}

		public void GetUrlDirectory(string url)
		{
			if (!Directory.Exists(url))
			{
				return;
			}
			string[] files = Directory.GetFiles(url);
			string[] array = files;
			string[] array2 = array;
			foreach (string urlFile in array2)
			{
				try
				{
					SetUrlFile(urlFile);
				}
				catch (Exception value)
				{
					Console.Write(value);
				}
			}
			GetUrlDirectoryS(url);
		}

		public void GetUrlDirectoryS(string url)
		{
			string[] directories = Directory.GetDirectories(url);
			string[] array = directories;
			string[] array2 = array;
			foreach (string url2 in array2)
			{
				GetUrlDirectory(url2);
			}
		}

		public void 初始化函数名()
		{
			发送六转技能书(1, 1);
			发送七转技能书(1, 1);
			发送八转技能书(1, 1);
			发送九转技能书(1, 1);
			更新HP_MP_SP(1);
			删除任务物品(1, 1, 1);
			检查任务物品数量(1, 1, 1);
			计算人物基本数据(1);
			学习技能提示(1);
			设置人物元宝(1, 1, 1);
			设置人物会员(1, 1);
			设置玩家等级(1, 1);
			物品使用(1, 1, 1);
			删除物品(1, 1, 1);
			得到包裹物品(1, 1);
			学习升天武功书(1, 1, 1);
			初始话已装备物品(1);
			更新经验和历练(1);
			更新金钱和负重(1);
			更新武功和状态(1);
			新学气功(1, 1);
			人物转职业(1, 1, 1);
			得到包裹空位位置(1);
			得到包裹空位位置组(1, 1);
			Get任务阶段(1, 1);
			GetWorldItme(0);
			GetPlayerThis(1);
			增加物品Script(1, 1, 1, 1);
			得到任务物品(1, 1, 1);
			增加任务物品(1, 1, 1);
			增加物品带属性(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
			任务提示数据发送(1, 1, 1, 1);
			系统提示(1, "1", 1, "1");
			设置任务数据(1, 1, 1);
			学习技能(1, 1, 1);
			追加状态物品(1, 1, 1, 1, 1, 1);
			发送公告("1", 1);
			得到包裹空位数(1);
			GetPlayer_Name(1);
			GetPlayer_Level(1);
			GetPlayer_Job(1);
			GetPlayer_Zx(1);
			GetPlayer_Job_Level(1);
			GetPlayer_Qigong_Point(1);
			SetPlayer_Money(1, 1);
			GetPlayer_Sex(1);
			GetPlayer_Wx(1);
			SetPlayer_Wx(1, 0);
			GetWorldItme_Level(0);
			GetWorldItme_Zx(0);
			GetWorldItme_Reside1(0);
			GetWorldItme_Job_Level(0);
			SetPlayer_ExpErience(1, 0);
			GetPlayer_ExpErience(1);
		}

		public void 注册脚本API()
		{
			int num = 0;
			try
			{
				num = 1;
				初始化函数名();
				pLuaVM = new Lua();
				num = 2;
				pLuaVM.RegisterFunction("SendMissionMsg", this, GetType().GetMethod(_任务提示数据发送));
				num = 3;
				pLuaVM.RegisterFunction("SendSysMsg", this, GetType().GetMethod(_系统提示));
				pLuaVM.RegisterFunction("SendKongfuMsg", this, GetType().GetMethod(_学习技能提示));
				pLuaVM.RegisterFunction("SendNoticeMsg", this, GetType().GetMethod(_发送公告));
				pLuaVM.RegisterFunction("AddQuest", this, GetType().GetMethod(_设置任务数据));
				pLuaVM.RegisterFunction("AddMission", this, GetType().GetMethod(_设置任务数据));
				pLuaVM.RegisterFunction("AddStKongfu", this, GetType().GetMethod(_学习升天武功书));
				pLuaVM.RegisterFunction("AddQigong", this, GetType().GetMethod(_新学气功));
				pLuaVM.RegisterFunction("AddSkill", this, GetType().GetMethod(_学习技能));
				pLuaVM.RegisterFunction("AddSkillBook6", this, GetType().GetMethod(_发送六转技能书));
				pLuaVM.RegisterFunction("AddSkillBook7", this, GetType().GetMethod(_发送七转技能书));
				pLuaVM.RegisterFunction("AddSkillBook8", this, GetType().GetMethod(_发送八转技能书));
				pLuaVM.RegisterFunction("AddSkillBook9", this, GetType().GetMethod(_发送九转技能书));
				pLuaVM.RegisterFunction("AddItme", this, GetType().GetMethod(_增加物品Script));
				pLuaVM.RegisterFunction("AddItmeProp", this, GetType().GetMethod(_增加物品带属性));
				pLuaVM.RegisterFunction("DelItme", this, GetType().GetMethod(_删除物品));
				pLuaVM.RegisterFunction("AddQuestItme", this, GetType().GetMethod(_增加任务物品));
				pLuaVM.RegisterFunction("DelQuestItme", this, GetType().GetMethod(_删除任务物品));
				pLuaVM.RegisterFunction("GetWorldItme", this, GetType().GetMethod(_GetWorldItme));
				pLuaVM.RegisterFunction("GetPlayer", this, GetType().GetMethod(_GetPlayerThis));
				pLuaVM.RegisterFunction("GetQuestLevel", this, GetType().GetMethod(_Get任务阶段));
				pLuaVM.RegisterFunction("GetPackage", this, GetType().GetMethod(_得到包裹空位位置));
				pLuaVM.RegisterFunction("GetPackagenum", this, GetType().GetMethod(_得到包裹空位数));
				pLuaVM.RegisterFunction("GetPackages", this, GetType().GetMethod(_得到包裹空位位置组));
				pLuaVM.RegisterFunction("GetPakItme", this, GetType().GetMethod(_得到包裹物品));
				pLuaVM.RegisterFunction("GetQuestItme", this, GetType().GetMethod(_得到任务物品));
				pLuaVM.RegisterFunction("SetPlayerTransfer", this, GetType().GetMethod(_人物转职业));
				pLuaVM.RegisterFunction("SetQigong", this, GetType().GetMethod(_新学气功));
				pLuaVM.RegisterFunction("SetPlayerLevel", this, GetType().GetMethod(_设置玩家等级));
				pLuaVM.RegisterFunction("SetPlayerVIP", this, GetType().GetMethod(_设置人物会员));
				pLuaVM.RegisterFunction("SetPlayerRxpiont", this, GetType().GetMethod(_设置人物元宝));
				pLuaVM.RegisterFunction("UpGongFu", this, GetType().GetMethod(_更新武功和状态));
				pLuaVM.RegisterFunction("UpMoney", this, GetType().GetMethod(_更新金钱和负重));
				pLuaVM.RegisterFunction("UpExp", this, GetType().GetMethod(_更新经验和历练));
				pLuaVM.RegisterFunction("UpYzbItme", this, GetType().GetMethod(_初始话已装备物品));
				pLuaVM.RegisterFunction("UpUseItme", this, GetType().GetMethod(_物品使用));
				pLuaVM.RegisterFunction("CheckQitemNum", this, GetType().GetMethod(_检查任务物品数量));
				pLuaVM.RegisterFunction("UpHpMpSp", this, GetType().GetMethod(_更新HP_MP_SP));
				pLuaVM.RegisterFunction("UpPlayerBase", this, GetType().GetMethod(_计算人物基本数据));
				pLuaVM.RegisterFunction("AddStateItems", this, GetType().GetMethod(_追加状态物品));
				num = 3;
				pLuaVM.RegisterFunction("GetPlayer_Name", this, GetType().GetMethod(_GetPlayer_Name));
				pLuaVM.RegisterFunction("GetPlayer_Level", this, GetType().GetMethod(_GetPlayer_Level));
				pLuaVM.RegisterFunction("GetPlayer_Job", this, GetType().GetMethod(_GetPlayer_Job));
				pLuaVM.RegisterFunction("GetPlayer_Zx", this, GetType().GetMethod(_GetPlayer_Zx));
				pLuaVM.RegisterFunction("GetPlayer_Job_Level", this, GetType().GetMethod(_GetPlayer_Job_Level));
				pLuaVM.RegisterFunction("GetPlayer_Qigong_Point", this, GetType().GetMethod(_GetPlayer_Qigong_Point));
				pLuaVM.RegisterFunction("GetPlayer_Sex", this, GetType().GetMethod(_GetPlayer_Sex));
				pLuaVM.RegisterFunction("SetPlayer_Money", this, GetType().GetMethod(_SetPlayer_Money));
				pLuaVM.RegisterFunction("GetPlayer_Wx", this, GetType().GetMethod(_GetPlayer_Wx));
				pLuaVM.RegisterFunction("SetPlayer_Wx", this, GetType().GetMethod(_SetPlayer_Wx));
				num = 4;
				pLuaVM.RegisterFunction("GetWorldItme_Level", this, GetType().GetMethod(_GetWorldItme_Level));
				pLuaVM.RegisterFunction("GetWorldItme_Zx", this, GetType().GetMethod(_GetWorldItme_Zx));
				pLuaVM.RegisterFunction("GetWorldItme_Reside1", this, GetType().GetMethod(_GetWorldItme_Reside1));
				pLuaVM.RegisterFunction("GetWorldItme_Job_Level", this, GetType().GetMethod(_GetWorldItme_Job_Level));
				pLuaVM.RegisterFunction("SetPlayer_ExpErience", this, GetType().GetMethod(_SetPlayer_ExpErience));
				pLuaVM.RegisterFunction("GetPlayer_ExpErience", this, GetType().GetMethod(_GetPlayer_ExpErience));
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, num + "|注册脚本API出错-" + ex.Message);
			}
		}

		public int GetWorldItme_Level(int 物品ID)
		{
			if (物品ID == 0)
			{
				_GetWorldItme_Level = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			ItmeClass value;
			return World.Itme.TryGetValue(物品ID, out value) ? value.FLD_LEVEL : 0;
		}

		public int GetWorldItme_Zx(int 物品ID)
		{
			if (物品ID == 0)
			{
				_GetWorldItme_Zx = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			ItmeClass value;
			return World.Itme.TryGetValue(物品ID, out value) ? value.FLD_ZX : 0;
		}

		public int GetWorldItme_Reside1(int 物品ID)
		{
			if (物品ID == 0)
			{
				_GetWorldItme_Reside1 = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			ItmeClass value;
			return World.Itme.TryGetValue(物品ID, out value) ? value.FLD_RESIDE1 : 0;
		}

		public int GetWorldItme_Job_Level(int 物品ID)
		{
			if (物品ID == 0)
			{
				_GetWorldItme_Job_Level = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			ItmeClass value;
			return World.Itme.TryGetValue(物品ID, out value) ? value.FLD_JOB_LEVEL : 0;
		}

		public void SetPlayer_ExpErience(int UserWorldId, int ExpErience)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_SetPlayer_ExpErience = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.Player_ExpErience += ExpErience;
			}
		}

		public int GetPlayer_ExpErience(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_ExpErience = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Player_ExpErience : 0;
		}

		public void SetPlayer_Wx(int UserWorldId, int wx)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_SetPlayer_Wx = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.Player_WuXun += wx;
			}
		}

		public int GetPlayer_Wx(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_Wx = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Player_WuXun : 0;
		}

		public int GetPlayer_Sex(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_Sex = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Player_Sex : 0;
		}

		public string GetPlayer_Name(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_Name = new StackTrace().GetFrame(0).GetMethod().Name;
				return string.Empty;
			}
			Players value;
			return (!World.AllConnectedPlayers.TryGetValue(UserWorldId, out value)) ? string.Empty : value.UserName;
		}

		public int GetPlayer_Qigong_Point(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_Qigong_Point = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Player_Qigong_point : 0;
		}

		public void SetPlayer_Money(int UserWorldId, int money)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_SetPlayer_Money = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.Player_Money += money;
			}
		}

		public int GetPlayer_Level(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_Level = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Player_Level : 0;
		}

		public int GetPlayer_Job(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_Job = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Player_Job : 0;
		}

		public int GetPlayer_Zx(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_Zx = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Player_Zx : 0;
		}

		public int GetPlayer_Job_Level(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayer_Job_Level = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Player_Job_leve : 0;
		}

		public void 删除任务物品(int UserWorldId, int 物品ID, int 数量)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_删除任务物品 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.del任务物品(物品ID, 数量);
			}
		}

		public void 计算人物基本数据(int UserWorldId)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_计算人物基本数据 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.计算人物基本数据();
			}
		}

		public void 更新HP_MP_SP(int UserWorldId)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_更新HP_MP_SP = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.更新HP_MP_SP();
			}
		}

		public bool 检查任务物品数量(int UserWorldId, int 物品ID, int 数量)
		{
			if (UserWorldId == 1)
			{
				_检查任务物品数量 = new StackTrace().GetFrame(0).GetMethod().Name;
				return false;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) && value.检查任务物品数量(物品ID, 数量);
		}

		public void 追加状态物品(int UserWorldId, int 类型ID, int time, int 数量, int 数量类型, int 包位置)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_追加状态物品 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				if (value.追加状态New列表.Count > 0)
				{
					value.新吃药提示();
					return;
				}
				value.Set追加状态物品(类型ID, time, 数量, 数量类型);
				value.计算人物装备数据();
				value.更新武功和状态();
				value.物品减去属性数量(包位置, 1);
			}
		}

		public void 学习技能提示(int UserWorldId)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_学习技能提示 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.学习技能提示();
			}
		}

		public void 设置人物元宝(int UserWorldId, int 元宝数, int 操作类型)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_设置人物元宝 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.检察元宝数据(元宝数, 操作类型, "脚本");
				value.SaveGemData();
			}
		}

		public void 设置人物会员(int UserWorldId, int 会员时间)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_设置人物会员 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				DateTime fLD_VIPTIM = value.FLD_VIPTIM;
				DateTime fLD_VIPTIM2 = ((!(fLD_VIPTIM < DateTime.Now)) ? fLD_VIPTIM.AddMonths(会员时间) : DateTime.Now.AddMonths(会员时间));
				value.FLD_VIP = 1;
				value.FLD_VIPTIM = fLD_VIPTIM2;
				value.保存会员数据();
			}
		}

		public void 设置玩家等级(int UserWorldId, int 等级)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_设置玩家等级 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				if (World.自动分配正邪 == 1)
				{
					value.Player_Zx = new Random().Next(1, 3);
				}
				value.Player_Job_leve = World.上线转职等级;
				value.Player_WuXun = World.上线武勋设置;
				value.Player_Money = World.上线金币数量;
				value.Player_ExpErience = World.上线历练数量;
				value.升天武功点数 = World.上线升天气功点;
				value.人物经验 = (long)World.lever[等级];
				value.Player_Level = 等级;
				value.计算人物基本数据3();
				value.更新经验和历练();
				value.更新金钱和负重();
				value.保存人物数据存储过程();
				value.保存个人仓库存储过程();
				value.保存综合仓库存储过程();
				value.保存宠物仓库存储过程();
				value.保存灵兽仓库存储过程();
				value.保存帮派数据();
			}
		}

		public void 物品使用(int UserWorldId, int 位置, int 数量)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_物品使用 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.物品使用(1, 位置, 数量);
			}
		}

		public void 删除物品(int UserWorldId, int 位置, int 数量)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_删除物品 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.减去物品(位置, 数量);
			}
		}

		public int 得到包裹物品(int UserWorldId, int 物品ID)
		{
			if (UserWorldId == 1)
			{
				_得到包裹物品 = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out var value))
			{
				for (int i = 0; i < 96; i++)
				{
					if (BitConverter.ToInt32(value.装备栏包裹[i].物品ID, 0) == 物品ID)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public void 学习升天武功书(int UserWorldId, int FLD_武功类型, int FLD_INDEX)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_学习升天武功书 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				武功类.学习武功书(value, FLD_武功类型, FLD_INDEX);
			}
		}

		public void 初始话已装备物品(int UserWorldId)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_初始话已装备物品 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.初始化已装备物品();
			}
		}

		public void 更新经验和历练(int UserWorldId)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_更新经验和历练 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.更新经验和历练();
			}
		}

		public void 更新金钱和负重(int UserWorldId)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_更新金钱和负重 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.更新金钱和负重();
			}
		}

		public void 更新武功和状态(int UserWorldId)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_更新武功和状态 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.更新武功和状态();
			}
		}

		public void 新学气功(int UserWorldId, int 气功位置)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_新学气功 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.新学气功(气功位置, 0);
			}
		}

		public void 人物转职业(int UserWorldId, int 人物正邪, int 转)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_人物转职业 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.人物转职业(人物正邪, 转);
			}
		}

		public int 得到包裹空位位置(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_得到包裹空位位置 = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return (!World.AllConnectedPlayers.TryGetValue(UserWorldId, out value)) ? (-1) : value.GetEmptyBagSlot();
		}

		public int 得到包裹空位数(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_得到包裹空位数 = new StackTrace().GetFrame(0).GetMethod().Name;
				return -1;
			}
			Players value;
			return (!World.AllConnectedPlayers.TryGetValue(UserWorldId, out value)) ? (-1) : value.得到包裹空位数();
		}

		public List<int> 得到包裹空位位置组(int UserWorldId, int 数量)
		{
			if (UserWorldId == 1)
			{
				_得到包裹空位位置组 = new StackTrace().GetFrame(0).GetMethod().Name;
				return null;
			}
			Players value;
			return (!World.AllConnectedPlayers.TryGetValue(UserWorldId, out value)) ? new List<int>() : value.得到包裹空位位置组(数量);
		}

		public int Get任务阶段(int UserWorldId, int 任务ID)
		{
			if (UserWorldId == 1)
			{
				_Get任务阶段 = new StackTrace().GetFrame(0).GetMethod().Name;
				return 0;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) ? value.Get任务阶段(任务ID) : 0;
		}

		public ItmeClass GetWorldItme(int 物品ID)
		{
			if (物品ID == 0)
			{
				_GetWorldItme = new StackTrace().GetFrame(0).GetMethod().Name;
				return null;
			}
			ItmeClass value;
			return (!World.Itme.TryGetValue(物品ID, out value)) ? null : value;
		}

		public Players GetPlayerThis(int UserWorldId)
		{
			if (UserWorldId == 1)
			{
				_GetPlayerThis = new StackTrace().GetFrame(0).GetMethod().Name;
				return null;
			}
			Players value;
			return (!World.AllConnectedPlayers.TryGetValue(UserWorldId, out value)) ? null : value;
		}

		public void 增加物品Script(int UserWorldId, int 物品ID, int 空位, int 数量)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_增加物品Script = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.增加物品Script(物品ID, 空位, 数量);
			}
		}

		public bool 得到任务物品(int UserWorldId, int 物品ID, int 数量)
		{
			if (UserWorldId == 1)
			{
				_得到任务物品 = new StackTrace().GetFrame(0).GetMethod().Name;
				return false;
			}
			Players value;
			return World.AllConnectedPlayers.TryGetValue(UserWorldId, out value) && value.得到任务物品(物品ID, 数量);
		}

		public void 增加任务物品(int UserWorldId, int 物品ID, int 数量)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_增加任务物品 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.设置任务物品(物品ID, 数量);
			}
		}

		public void 增加物品带属性(int UserWorldId, int 物品ID, int 位置, int 数量, int 物品属性0, int 物品属性1, int 物品属性2, int 物品属性3, int 物品属性4, int 初级附魂, int 中级附魂, int 进化, int 绑定, int 使用天数)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_增加物品带属性 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.AddItemWithProperties(物品ID, 位置, 数量, 物品属性0, 物品属性1, 物品属性2, 物品属性3, 物品属性4, 初级附魂, 中级附魂, 进化, 绑定, 使用天数);
			}
		}

		public void 任务提示数据发送(int UserWorldId, int 任务ID, int 操作ID, int 任务阶段ID)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_任务提示数据发送 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.任务提示数据发送(任务ID, 操作ID, 任务阶段ID);
			}
		}

		public void 系统提示(int UserWorldId, string msg, int msgType, string name)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_系统提示 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.系统提示(msg, msgType, name);
			}
		}

		public void 设置任务数据(int UserWorldId, int 任务ID, int 任务阶段ID)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_设置任务数据 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.设置任务数据(任务ID, 任务阶段ID);
			}
		}

		public void 学习技能(int UserWorldId, int FLD_武功类型, int FLD_INDEX)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_学习技能 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.学习技能(FLD_武功类型, FLD_INDEX);
			}
		}

		public void 发送六转技能书(int UserWorldId, int 空位)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_发送六转技能书 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.发送六转技能书(空位);
			}
		}

		public void 发送七转技能书(int UserWorldId, int 空位)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_发送七转技能书 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.发送七转技能书(空位);
			}
		}

		public void 发送八转技能书(int UserWorldId, int 空位)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_发送八转技能书 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.发送八转技能书(空位);
			}
		}

		public void 发送九转技能书(int UserWorldId, int 空位)
		{
			Players value;
			if (UserWorldId == 1)
			{
				_发送九转技能书 = new StackTrace().GetFrame(0).GetMethod().Name;
			}
			else if (World.AllConnectedPlayers.TryGetValue(UserWorldId, out value))
			{
				value.发送九转技能书(空位);
			}
		}

		public void 发送公告(string txt, int ggid)
		{
			if (txt == "1")
			{
				_发送公告 = new StackTrace().GetFrame(0).GetMethod().Name;
				return;
			}
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value != null)
					{
						switch (ggid)
						{
						case 0:
							value.系统公告(txt);
							break;
						case 1:
							value.系统滚动公告(txt);
							break;
						case 2:
							value.系统提示(txt, 10, "系统信息");
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送公告出错：" + ex.Message);
			}
		}
	}
}
