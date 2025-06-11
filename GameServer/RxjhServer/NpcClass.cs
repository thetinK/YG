using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;
using RxjhServer.DbClss;
using RxjhServer.HelperTools;
using RxjhServer.Network;

namespace RxjhServer
{
	public class NpcClass : IDisposable
	{
		private static readonly PlayGjClass asfd = new PlayGjClass();

		private readonly object AsyncLocksw = new object();

		private readonly ArrayList tem = new ArrayList();

		private readonly ThreadSafeDictionary<int, PlayZDClass> 组队列表 = new ThreadSafeDictionary<int, PlayZDClass>();

		public Reverser<PlayGjClass> reverser = new Reverser<PlayGjClass>(asfd.GetType(), "Gjsl", ReverserInfo.Direction.DESC);

		private List<PlayGjClass> PlayGjList = new List<PlayGjClass>();

		public ConcurrentDictionary<int, Players> templayer = new ConcurrentDictionary<int, Players>();

		private ThreadSafeDictionary<int, Players> PlayList;

		public System.Timers.Timer 自动移动;

		public System.Timers.Timer 自动攻击;

		public System.Timers.Timer 自动复活;

		private static Random Ran;

		public ConcurrentDictionary<int, 异常状态类> 异常状态;

		private readonly Random publicRan = new Random(DateTime.Now.Millisecond);

		private 灵兽类 _PlayCw;

		private float _FLD_FACE1;

		private float _FLD_FACE2;

		private int _IsNpc;

		private string _Name;

		private int _FLD_INDEX;

		private int _FLD_PID;

		private double _FLD_AT;

		private float _Rxjh_X;

		private float _Rxjh_Y;

		private float _Rxjh_Z;

		private float _Rxjh_cs_X;

		private float _Rxjh_cs_Y;

		private float _Rxjh_cs_Z;

		private int _Rxjh_Map;

		private int _Rxjh_Exp;

		private int _Max_Rxjh_HP;

		private int _阎王爆累计伤害;

		private int _Rxjh_HP;

		private int _Level;

		private double _FLD_DF;

		private int _FLD_AUTO;

		private int _FLD_BOSS;

		private int _FLD_NEWTIME;

		private bool _NPC死亡;

		private bool _一次性怪;

		public int 怪物数字;

		private bool _怪物阎王爆;

		private bool _是否绝命技死亡;

		private double _绝命技死亡爆率加成;

		private double _绝命技死亡经验加成;

		private double _绝命技死亡历练加成;

		private double _绝命技死亡金钱加成;

		private static List<int> _有技能的BOSS列表 = new List<int> { 15419, 15420, 15421, 15422, 15423, 15424 };

		public 灵兽类 PlayCw
		{
			get
			{
				return _PlayCw;
			}
			set
			{
				_PlayCw = value;
			}
		}

		public bool 怪物阎王爆
		{
			get
			{
				return _怪物阎王爆;
			}
			set
			{
				_怪物阎王爆 = value;
			}
		}

		public bool 是否绝命技死亡
		{
			get
			{
				return _是否绝命技死亡;
			}
			set
			{
				_是否绝命技死亡 = value;
			}
		}

		public double 绝命技死亡爆率加成
		{
			get
			{
				return _绝命技死亡爆率加成;
			}
			set
			{
				_绝命技死亡爆率加成 = value;
			}
		}

		public double 绝命技死亡经验加成
		{
			get
			{
				return _绝命技死亡经验加成;
			}
			set
			{
				_绝命技死亡经验加成 = value;
			}
		}

		public double 绝命技死亡历练加成
		{
			get
			{
				return _绝命技死亡历练加成;
			}
			set
			{
				_绝命技死亡历练加成 = value;
			}
		}

		public double 绝命技死亡金钱加成
		{
			get
			{
				return _绝命技死亡金钱加成;
			}
			set
			{
				_绝命技死亡金钱加成 = value;
			}
		}

		public ThreadSafeDictionary<int, Players> _PlayList => PlayList;

		public List<PlayGjClass> PlayGj
		{
			get
			{
				return PlayGjList;
			}
			set
			{
				PlayGjList = value;
			}
		}

		public int PlayerWid
		{
			get
			{
				if (PlayGjList.Count <= 0)
				{
					return 0;
				}
				try
				{
					PlayGjList.Sort(new Reverser<PlayGjClass>(new PlayGjClass().GetType(), "Gjsl", ReverserInfo.Direction.DESC));
					return PlayGjList[0].HitPlayID;
				}
				catch (Exception)
				{
					return 0;
				}
			}
		}

		public int BossPlayerWid
		{
			get
			{
				if (PlayGjList.Count <= 0)
				{
					return 0;
				}
				try
				{
					int num = 0;
					int index;
					while (true)
					{
						num++;
						index = new Random().Next(0, PlayGjList.Count);
						int num2 = Max_Rxjh_HP / 100;
						if (PlayGjList[index].Hitsl >= num2)
						{
							break;
						}
						if (num >= PlayGjList.Count)
						{
							PlayGjList.Sort(new Reverser<PlayGjClass>(new PlayGjClass().GetType(), "Gjsl", ReverserInfo.Direction.DESC));
							return PlayGjList[0].HitPlayID;
						}
					}
					return PlayGjList[index].PlayID;
				}
				catch (Exception)
				{
					return 0;
				}
			}
		}

		public float FLD_FACE1
		{
			get
			{
				return _FLD_FACE1;
			}
			set
			{
				_FLD_FACE1 = value;
			}
		}

		public float FLD_FACE2
		{
			get
			{
				return _FLD_FACE2;
			}
			set
			{
				_FLD_FACE2 = value;
			}
		}

		public int IsNpc
		{
			get
			{
				return _IsNpc;
			}
			set
			{
				_IsNpc = value;
			}
		}

		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		public int FLD_INDEX
		{
			get
			{
				return _FLD_INDEX;
			}
			set
			{
				_FLD_INDEX = value;
			}
		}

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

		public double FLD_AT
		{
			get
			{
				return _FLD_AT;
			}
			set
			{
				_FLD_AT = value;
			}
		}

		public float X
		{
			get
			{
				return _Rxjh_X;
			}
			set
			{
				_Rxjh_X = value;
			}
		}

		public float Y
		{
			get
			{
				return _Rxjh_Y;
			}
			set
			{
				_Rxjh_Y = value;
			}
		}

		public float Z
		{
			get
			{
				return _Rxjh_Z;
			}
			set
			{
				_Rxjh_Z = value;
			}
		}

		public float Rxjh_cs_X
		{
			get
			{
				return _Rxjh_cs_X;
			}
			set
			{
				_Rxjh_cs_X = value;
			}
		}

		public float Rxjh_cs_Y
		{
			get
			{
				return _Rxjh_cs_Y;
			}
			set
			{
				_Rxjh_cs_Y = value;
			}
		}

		public float Rxjh_cs_Z
		{
			get
			{
				return _Rxjh_cs_Z;
			}
			set
			{
				_Rxjh_cs_Z = value;
			}
		}

		public int Rxjh_Map
		{
			get
			{
				return _Rxjh_Map;
			}
			set
			{
				_Rxjh_Map = value;
			}
		}

		public int Rxjh_Exp
		{
			get
			{
				return _Rxjh_Exp;
			}
			set
			{
				_Rxjh_Exp = value;
			}
		}

		public int Max_Rxjh_HP
		{
			get
			{
				return _Max_Rxjh_HP;
			}
			set
			{
				_Max_Rxjh_HP = value;
			}
		}

		public int 阎王爆累计伤害
		{
			get
			{
				return _阎王爆累计伤害;
			}
			set
			{
				_阎王爆累计伤害 = value;
			}
		}

		public int Rxjh_HP
		{
			get
			{
				return _Rxjh_HP;
			}
			set
			{
				_Rxjh_HP = value;
			}
		}

		public int Level
		{
			get
			{
				return _Level;
			}
			set
			{
				_Level = value;
			}
		}

		public double FLD_DF
		{
			get
			{
				return _FLD_DF;
			}
			set
			{
				_FLD_DF = value;
			}
		}

		public int FLD_AUTO
		{
			get
			{
				return _FLD_AUTO;
			}
			set
			{
				_FLD_AUTO = value;
			}
		}

		public int FLD_BOSS
		{
			get
			{
				return _FLD_BOSS;
			}
			set
			{
				_FLD_BOSS = value;
			}
		}

		public int FLD_NEWTIME
		{
			get
			{
				return _FLD_NEWTIME;
			}
			set
			{
				_FLD_NEWTIME = value;
			}
		}

		public bool NPC死亡
		{
			get
			{
				return _NPC死亡;
			}
			set
			{
				_NPC死亡 = value;
			}
		}

		public bool isOneTimeMonster
		{
			get
			{
				return _一次性怪;
			}
			set
			{
				_一次性怪 = value;
			}
		}

		public void 发送阎王爆复仇反伤攻击数据(int 掉落血量)
		{
			byte[] array = Converter.hexStringToByte("AA551200A42789000C002C0100000F0000000100000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 10, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(掉落血量), 0, array, 18, 2);
			广播数据(array, array.Length);
		}

		public void 触发阎王爆(Players players, int ID)
		{
			if (players == null || !查找范围玩家(400, players))
			{
				return;
			}
			int num = (int)((double)阎王爆累计伤害 * (1.0 + players.神女尸毒爆发));
			if (num >= 1)
			{
				int num2 = 40;
				num2 += (int)players.神女黑花漫开;
				List<NpcClass> list = 阎王爆查找范围Npc(players, num2);
				foreach (NpcClass item in list)
				{
					if (num <= 0)
					{
						num = 1;
					}
					if (item.Rxjh_HP > num)
					{
						item.Play_Hit(players, num);
						item.Rxjh_HP -= num;
					}
					else
					{
						item.Play_Hit(players, item.Rxjh_HP);
						item.Rxjh_HP = 0;
					}
					item.发送阎王爆复仇反伤攻击数据(num);
					if (item.Rxjh_HP <= 0 && !item.NPC死亡)
					{
						item.发送死亡数据(ID);
					}
					item.阎王爆累计伤害 = 0;
				}
			}
			怪物阎王爆 = false;
		}

		public List<NpcClass> 阎王爆查找范围Npc(Players player, int 范围)
		{
			try
			{
				List<NpcClass> list = new List<NpcClass>();
				foreach (NpcClass value in player.NpcList.Values)
				{
					if (!value.NPC死亡 && value.IsNpc == 0 && 查找范围Npc(范围, value))
					{
						list.Add(value);
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "阎王爆查找范围Npc 出错：" + ex);
				return null;
			}
		}

		public void 发送怪物当前血量()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "NpcClass_发送怪物当前血量");
			}
			string hex = "AA5512000F272E210C0012272E4000A86100A02E630055AA";
			byte[] array = Converter.hexStringToByte(hex);
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 10, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_PID), 0, array, 12, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(Rxjh_HP), 0, array, 14, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(Max_Rxjh_HP), 0, array, 18, 4);
			广播数据(array, array.Length);
		}

		public void 吸怪清理(Players payer)
		{
			try
			{
				if (payer == null)
				{
					return;
				}
				List<NpcClass> list = new List<NpcClass>();
				foreach (NpcClass value in payer.怪物攻击列表.Values)
				{
					list.Add(value);
				}
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].怪距离检测(payer))
					{
						payer.怪物攻击列表.RemoveSafe(list[i].FLD_INDEX);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "吸怪 出错：" + ex);
			}
		}

		public void npc_Add(Players payer)
		{
			try
			{
				if (payer != null)
				{
					if (payer.怪物攻击列表 == null)
					{
						payer.怪物攻击列表 = new ThreadSafeDictionary<int, NpcClass>();
					}
					if (!payer.怪物攻击列表.ContainsKey(FLD_INDEX))
					{
						payer.怪物攻击列表.Add(FLD_INDEX, this);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "引怪 出错：" + ex);
			}
		}

		public bool 怪距离检测(Players npcTemp)
		{
			float num = X - npcTemp.人物坐标_X;
			float num2 = Y - npcTemp.人物坐标_Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			if (num3 >= (float)World.吸怪距离 || Rxjh_Map != npcTemp.人物坐标_地图 || NPC死亡 || Rxjh_HP <= 0)
			{
				return true;
			}
			return false;
		}

		public bool 玩家是否在指定范围内(int 查找范围, Players players_0)
		{
			if (Rxjh_Map != 43001 && (long)players_0.人物_HP <= 0L)
			{
				return false;
			}
			if (players_0.人物坐标_地图 == Rxjh_Map)
			{
				if (players_0.人物坐标_地图 == 7301 || players_0.人物坐标_地图 == 43001)
				{
					查找范围 = 1000;
				}
				float num = players_0.人物坐标_X - X;
				float num2 = players_0.人物坐标_Y - Y;
				float num3 = (int)Math.Sqrt(num * num + num2 * num2);
				return num3 <= (float)查找范围;
			}
			return false;
		}

		public NpcClass()
		{
			Ran = new Random(DateTime.Now.Millisecond);
			PlayList = new ThreadSafeDictionary<int, Players>();
			double interval = Ran.Next(5000, 15000);
			自动移动 = new System.Timers.Timer(interval);
			自动移动.Elapsed += 自动移动事件;
			自动移动.AutoReset = true;
			自动移动.Enabled = true;
			自动攻击 = new System.Timers.Timer(1000.0);
			自动攻击.Elapsed += 自动攻击事件;
			自动攻击.AutoReset = true;
			异常状态 = new ConcurrentDictionary<int, 异常状态类>();
			是否绝命技死亡 = false;
			绝命技死亡爆率加成 = 0.0;
			绝命技死亡经验加成 = 0.0;
			绝命技死亡历练加成 = 0.0;
			绝命技死亡金钱加成 = 0.0;
		}

		public void Cw_Add(灵兽类 灵兽)
		{
			foreach (PlayGjClass playGj in PlayGjList)
			{
				if (playGj.PlayID == 灵兽.全服ID)
				{
					playGj.Gjsl++;
					return;
				}
			}
			PlayGjList.Add(new PlayGjClass
			{
				Gjsl = 1,
				PlayID = 灵兽.全服ID
			});
			PlayCw = 灵兽;
		}

		public void PlayList_Add(Players Play)
		{
			if (!Play.Client.挂机 && !Contains(Play))
			{
				PlayList.Add(Play.人物全服ID, Play);
			}
		}

		public void PlayList_Remove(Players payer)
		{
			if (Contains(payer))
			{
				PlayList.Remove(payer.人物全服ID);
			}
		}

		public bool Contains(Players payer)
		{
			Players value;
			return PlayList != null && PlayList.Count != 0 && PlayList.TryGetValue(payer.人物全服ID, out value);
		}

		public void Play_dell(Players payer)
		{
		}

		public void Play_Add(Players payer)
		{
			foreach (PlayGjClass playGj in PlayGjList)
			{
				if (playGj.PlayID == payer.人物全服ID)
				{
					playGj.Gjsl++;
					return;
				}
			}
			PlayGjList.Add(new PlayGjClass
			{
				Hitsl = 0,
				Gjsl = 1,
				PlayID = payer.人物全服ID,
				HitPlayID = payer.人物全服ID
			});
		}

		public void 发送复仇显示伤害血量(int 掉落血量)
		{
			byte[] array = Converter.hexStringToByte("AA551200A42789000C002C0100000F0000000100000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 10, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(掉落血量), 0, array, 18, 2);
			广播数据(array, array.Length);
		}

		public void Play_Hit(Players payer, int 攻击数量)
		{
			if (Rxjh_HP < 0)
			{
				攻击数量 += Rxjh_HP;
			}
			if (攻击数量 < 0)
			{
				return;
			}
			foreach (PlayGjClass playGj in PlayGjList)
			{
				if (playGj.PlayID == payer.人物全服ID)
				{
					playGj.Hitsl += 攻击数量;
					break;
				}
				if (payer.人物灵兽 != null && playGj.PlayID == payer.人物灵兽.全服ID)
				{
					playGj.Hitsl += 攻击数量;
					break;
				}
			}
			if (payer.组队id != 0 && !组队列表.ContainsKey(payer.组队id))
			{
				PlayZDClass playZDClass = new PlayZDClass
				{
					dwID = payer.组队id,
					Hitsl = 0
				};
				组队列表.Add(playZDClass.dwID, playZDClass);
			}
		}

		public void Play_null()
		{
			try
			{
				if (PlayGjList.Count > 0)
				{
					PlayGjList.Clear();
				}
				if (组队列表.Count > 0)
				{
					组队列表.Clear();
				}
			}
			catch
			{
			}
		}

		public void 获取范围玩家发送增加数据包()
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (查找范围玩家(400, value))
					{
						value.获取复查范围Npc();
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "获取范围玩家发送地面增加Npc数据包 出错：" + ex);
			}
		}

		public void Dispose()
		{
			try
			{
				MapClass.delnpc(Rxjh_Map, FLD_INDEX);
				if (自动攻击 != null)
				{
					自动攻击.Enabled = false;
					自动攻击.Close();
					自动攻击.Dispose();
				}
				if (自动移动 != null)
				{
					自动移动.Enabled = false;
					自动移动.Close();
					自动移动.Dispose();
				}
				if (自动复活 != null)
				{
					自动复活.Enabled = false;
					自动复活.Close();
					自动复活.Dispose();
					自动复活 = null;
				}
				Play_null();
				if (PlayCw != null)
				{
					PlayCw = null;
				}
				获取范围玩家发送消失数据包();
				if (tem != null)
				{
					tem.Clear();
				}
				if (PlayList != null)
				{
					PlayList.Dispose();
					PlayList = null;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "NPC 关闭数据Dispose() 出错：" + ex);
			}
		}

		public void 获取范围玩家发送消失数据包()
		{
			if (PlayList == null)
			{
				return;
			}
			int num = 0;
			try
			{
				foreach (Players value in PlayList.Values)
				{
					num = 1;
					if (value.Client != null)
					{
						num = 2;
						更新NPC死亡数据(value);
						更新NPC删除数据(value);
						if (value.NpcList.ContainsKey(FLD_INDEX))
						{
							value.NpcList.Remove(FLD_INDEX);
						}
						num = 3;
					}
				}
				num = 4;
				if (PlayList != null)
				{
					num = 5;
					PlayList.Clear();
					num = 6;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "NPC 获取范围玩家发送消失数据包3 出错：num=" + num + ex);
			}
		}

		~NpcClass()
		{
		}

		public bool ContainsKeyInAbnormalState(int Key)
		{
			异常状态类 value;
			return 异常状态 != null && 异常状态.Count != 0 && 异常状态.TryGetValue(Key, out value);
		}

		public void getbl()
		{
			if (PlayList.Count > 0)
			{
				MainForm.WriteLine(2, _Name + " 人物：" + PlayList.Count);
				if (自动移动 != null)
				{
					MainForm.WriteLine(2, _Name + " 人物_自动移动：" + 自动移动.Enabled);
				}
				if (自动攻击 != null)
				{
					MainForm.WriteLine(2, _Name + " 人物_自动攻击：" + 自动攻击.Enabled);
				}
				if (自动复活 != null)
				{
					MainForm.WriteLine(2, _Name + " 人物_自动复活：" + 自动复活.Enabled);
				}
			}
			if (PlayGjList.Count > 0)
			{
				MainForm.WriteLine(2, _Name + " 攻击：" + PlayGjList.Count);
			}
			if (PlayCw != null)
			{
				MainForm.WriteLine(2, _Name + " 灵兽：" + PlayCw.Name + "主人名：" + PlayCw.ZrName);
			}
		}

		private void 自动移动事件(object source, ElapsedEventArgs e)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "自动移动事件");
			}
			try
			{
				if (Rxjh_Map == 43001 && FLD_PID != 16555)
				{
					return;
				}
				if (IsNpc != 0)
				{
					自动移动.Enabled = false;
				}
				else if (!NPC死亡 && FLD_AT > 0.0 && PlayList.Count >= 1)
				{
					Random random = new Random(DateTime.Now.Millisecond);
					int num = random.Next(5000, 15000);
					if (自动移动 != null)
					{
						自动移动.Interval = num;
					}
					else
					{
						自动移动 = new System.Timers.Timer(num);
						自动移动.Elapsed += 自动移动事件;
						自动移动.AutoReset = true;
						自动移动.Enabled = true;
					}
					if (FLD_AUTO == 1 && 获取范围玩家())
					{
						自动移动.Enabled = false;
						自动攻击.Enabled = true;
					}
					else if (FLD_PID != 16431 && FLD_PID != 16430 && FLD_PID != 16435)
					{
						发送移动数据(Rxjh_cs_X, Rxjh_cs_Y, (FLD_PID != 5) ? 50 : 20, 0);
					}
					else
					{
						自动移动.Enabled = false;
						自动攻击.Enabled = false;
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "自动移动事件 出错：" + ex);
			}
		}

		private void 自动复活事件(object source, ElapsedEventArgs e)
		{
			try
			{
				if (IsNpc == 1)
				{
					自动复活.Enabled = false;
					return;
				}
				自动移动.Enabled = true;
				if (!NPC死亡)
				{
					return;
				}
				if (Rxjh_Map == 43001)
				{
					if (讨伐战系统.讨伐副本占领者 == 0)
					{
						更新NPC复活数据();
					}
					else if (FLD_PID != 16555)
					{
						地狱火龙副本状态效果消失(是否玩家击杀: false);
						if (自动复活 != null)
						{
							自动复活.Enabled = false;
							自动复活.Close();
							自动复活.Dispose();
							自动复活 = null;
						}
					}
				}
				else
				{
					更新NPC复活数据();
				}
			}
			catch (Exception ex)
			{
				if (自动复活 != null)
				{
					自动复活.Enabled = false;
					自动复活.Close();
					自动复活.Dispose();
					自动复活 = null;
				}
				MainForm.WriteLine(1, "自动复活事件1 出错：" + ex);
			}
			finally
			{
				if (自动复活 != null)
				{
					自动复活.Enabled = false;
					自动复活.Close();
					自动复活.Dispose();
					自动复活 = null;
				}
			}
		}

		private void 自动攻击事件(object source, ElapsedEventArgs e)
		{
			try
			{
				if (Rxjh_Map == 43001 && FLD_PID != 16555 && FLD_PID != 16556)
				{
					return;
				}
				if (IsNpc != 0)
				{
					自动攻击.Enabled = false;
				}
				else if (Rxjh_HP < 0)
				{
					自动攻击.Enabled = false;
				}
				else
				{
					if (FLD_AT <= 0.0)
					{
						return;
					}
					int num = (int)(FLD_AT * World.怪物攻击百分比);
					Random random = new Random(DateTime.Now.Millisecond);
					自动攻击.Interval = random.Next(1000, 3000);
					int num5 = random.Next(num - 8, num + 8);
					if (PlayList.TryGetValue(PlayerWid, out var value))
					{
						switch (value.Player_Zx)
						{
						case 1:
							if (FLD_PID == 15450 || FLD_PID == 15451 || FLD_PID == 15491 || FLD_PID == 15492)
							{
								return;
							}
							break;
						case 2:
							if (FLD_PID == 15452 || FLD_PID == 15453 || FLD_PID == 15493 || FLD_PID == 15494)
							{
								return;
							}
							break;
						}
						if (value.人物_HP <= 0 || value.Player死亡 || value.GM模式 == 8)
						{
							if (value.自动攻击 != null)
							{
								value.自动攻击.Enabled = false;
								value.自动攻击.Close();
								value.自动攻击.Dispose();
								value.自动攻击 = null;
							}
							if (value.自动恢复 != null)
							{
								value.自动恢复.Enabled = false;
								value.自动恢复.Close();
								value.自动恢复.Dispose();
								value.自动恢复 = null;
							}
							if (value.无敌时间计数器 != null)
							{
								value.无敌时间计数器.Enabled = false;
								value.无敌时间计数器.Close();
								value.无敌时间计数器.Dispose();
							}
							PlayCw = null;
							Play_null();
							自动攻击.Enabled = false;
							自动移动.Enabled = true;
							X = Rxjh_cs_X;
							Y = Rxjh_cs_Y;
							Z = Rxjh_cs_Z;
							发送移动数据(Rxjh_cs_X, Rxjh_cs_Y, 50, 1);
							return;
						}
						int num6 = 28;
						double num7 = (double)(value.FLD_人物基本_防御 + value.装备追加对怪防御 + value.药品追加对怪防御 + value.强化追加对怪防御) + value.升天五式_魔魂之力 + value.神女神力激发对怪防御力;
						if (!value.检查毒蛇出洞状态() && value.Player_Job == 12 && value.牢不可破 >= (double)RNG.Next(0, 100))
						{
							num7 += num7 * ((double)value.装备栏已穿装备[0].物品属性阶段数 * 0.005 * 2.0);
							value.显示大字(value.人物全服ID, 1010);
						}
						bool flag = false;
						if (value.FLD_装备_追加_降低百分比攻击 > 0.0)
						{
							num5 = (int)((double)num5 * (1.0 - value.FLD_装备_追加_降低百分比攻击));
						}
						if (Level >= 60)
						{
							switch (RNG.Next(0, 10))
							{
							case 1:
								num6 = 28;
								break;
							case 2:
								num6 = 29;
								break;
							case 4:
								num6 = 29;
								break;
							}
							if (num6 == 29)
							{
								num5 = (int)((double)num5 * 1.2);
							}
						}
						if (value.中级附魂_移星 != 0 && (double)RNG.Next(1, 100) <= (double)value.中级附魂_移星)
						{
							num5 = 0;
							value.显示大字(value.人物全服ID, 405);
						}
						if (value.Player_Job == 3 && (double)RNG.Next(0, 100) <= value.枪_转攻为守)
						{
							value.显示大字(value.人物全服ID, 130);
							num7 += (double)value.FLD_攻击;
						}
						if (value.Player_Job == 12 && (double)RNG.Next(0, 100) <= value.卢_转攻为守)
						{
							value.显示大字(value.人物全服ID, 130);
							num7 += (double)value.FLD_攻击 / 2.0;
						}
						if (value.Player_Job == 10)
						{
							if ((double)RNG.Next(0, 100) <= value.拳师_转攻为守)
							{
								value.显示大字(value.人物全服ID, 130);
								num7 += (double)value.FLD_攻击;
							}
							if (num6 == 29 && (double)RNG.Next(1, 100) <= value.拳师_金刚不坏)
							{
								value.显示大字(value.人物全服ID, 554);
								num5 = (int)((double)num5 * 0.1);
							}
							if ((double)RNG.Next(1, 100) <= value.升天五式_不死之躯)
							{
								value.显示大字(value.人物全服ID, 1021);
								num5 = 0;
							}
						}
						if (value.中级附魂_护体 != 0 && RNG.Next(1, 100) <= value.中级附魂_护体)
						{
							value.显示大字(value.人物全服ID, 406);
							value.人物_MP += num5;
							value.更新HP_MP_SP();
							num5 = 0;
						}
						int num8 = ((!((double)num5 > num7)) ? 1 : (num5 - (int)num7));
						if (查找范围玩家(20, value))
						{
							if (FLD_PID == 15516 && (double)RNG.Next(1, 100) <= 10.0)
							{
								if (value.异常状态 != null)
								{
									if (!value.GetAbnormalState(17))
									{
										异常状态类 value2 = new 异常状态类(value, 2000, 17, 0.0);
										value.异常状态.Add(17, value2);
										value.人物锁定 = true;
									}
								}
								else
								{
									value.异常状态 = new ThreadSafeDictionary<int, 异常状态类>();
									异常状态类 value3 = new 异常状态类(value, 2000, 17, 0.0);
									value.异常状态.Add(17, value3);
									value.人物锁定 = true;
								}
							}
							if (value.中级附魂_混元 != 0 && RNG.Next(1, 100) <= value.中级附魂_混元)
							{
								value.显示大字(value.人物全服ID, 407);
								num8 = (int)((double)num8 * 0.5);
							}
							if (value.FLD_装备_降低_伤害值 > 0.0)
							{
								num8 -= (int)value.FLD_装备_降低_伤害值;
							}
							if (value.Player_Job == 2)
							{
								double num9 = num8;
								if ((double)RNG.Next(1, 110) <= value.剑_升天一气功_护身罡气)
								{
									value.显示大字(value.人物全服ID, 25);
									num8 = (int)(num9 * 0.5);
								}
								if ((double)RNG.Next(1, 100) <= value.剑_回柳身法)
								{
									num8 = 0;
								}
							}
							else if (value.Player_Job == 6)
							{
								if ((double)RNG.Next(1, 110) <= value.刺_三花聚顶)
								{
									value.刺_连消带打数量 = (double)num8 * value.刺_连消带打;
									num8 = 0;
								}
								if ((double)RNG.Next(1, 110) <= value.刺_升天一气功_夜魔缠身)
								{
									num8 = (int)((double)num8 * 0.7);
									value.显示大字(value.人物全服ID, 370);
								}
								if ((double)RNG.Next(1, 100) <= value.刺_升天二气功_顺水推舟)
								{
									value.加血((int)((double)num8 * 0.2));
									value.显示大字(value.人物全服ID, 371);
								}
							}
							else if (value.Player_Job == 9)
							{
								double num10 = num8;
								if ((double)RNG.Next(1, 100) <= value.谭_护身罡气)
								{
									value.显示大字(value.人物全服ID, 25);
									num8 = (int)(num10 * 0.5);
								}
								if ((double)RNG.Next(1, 100) <= value.谭_回柳身法)
								{
									num8 = 0;
								}
							}
							if (num8 <= 0)
							{
								num8 = RNG.Next(0, 5);
							}
							int num11 = 0;
							if (value.Player_Job == 11 && value.梅_障力激活 > 0.0)
							{
								num11 = (int)((double)num8 * (value.梅_障力激活 * 2.0 * 0.01));
								if (num11 > value.人物_AP)
								{
									num11 = value.人物_AP;
								}
								value.人物_AP -= num11;
							}
							int num12 = num8 - num11;
							发送攻击数据(num12, num6, value.人物全服ID, num11);
							value.人物_HP -= num12;
							if (value.Player_Job == 1 || value.Player_Job == 7)
							{
								if ((double)num12 <= num7)
								{
									if (!value.怒)
									{
										value.人物_SP++;
									}
								}
								else if (!value.怒)
								{
									value.人物_SP += 2;
								}
								try
								{
									if ((double)RNG.Next(1, 100) <= ((value.Player_Job != 1) ? value.琴师_升天二气功_三潭映月 : value.怪反伤几率) && num12 > 0)
									{
										if (value.Player_Job == 7)
										{
											value.显示大字(value.人物全服ID, 391);
										}
										else
										{
											发送反伤攻击数据(num12, value.人物全服ID);
										}
										if (num12 <= 0)
										{
											num12 = 1;
										}
										if (Rxjh_HP > num12)
										{
											Play_Hit(value, num12);
											Rxjh_HP -= num12;
										}
										else
										{
											Play_Hit(value, num12);
											Rxjh_HP = 0;
										}
										if (Rxjh_HP <= 0 && !NPC死亡)
										{
											flag = true;
										}
									}
								}
								catch (Exception ex)
								{
									MainForm.WriteLine(1, "自动攻击事件 琴师/刀客反伤 出错：" + ex);
								}
							}
							else if (value.Player_Job == 2)
							{
								if ((double)RNG.Next(1, 100) <= value.剑_升天三气功_火凤临朝 && value.人物_HP <= 0)
								{
									value.人物_HP = 10;
									value.显示大字(value.人物全服ID, 322);
								}
								if ((double)num12 <= num7)
								{
									if (!value.怒)
									{
										value.人物_SP++;
									}
								}
								else if (!value.怒)
								{
									value.人物_SP += 2;
								}
							}
							else if (value.Player_Job == 3)
							{
								if (value.枪_狂神降世 != 0.0)
								{
									if (!value.怒)
									{
										value.人物_SP += (int)(3.0 + (double)(value.Player_Level * 2) * value.枪_狂神降世);
									}
								}
								else if ((double)num12 <= num7)
								{
									if (!value.怒)
									{
										value.人物_SP++;
									}
								}
								else if (!value.怒)
								{
									value.人物_SP += 2;
								}
							}
							else if (value.Player_Job == 6)
							{
								if (value.刺_荆轲之怒 != 0.0)
								{
									value.人物_SP += (int)(3.0 + (double)value.Player_Level * 0.5 * 0.01 * value.刺_荆轲之怒);
								}
								else if ((double)num12 <= num7)
								{
									value.人物_SP++;
								}
								else
								{
									value.人物_SP += 2;
								}
							}
							else if (value.Player_Job == 8)
							{
								if ((double)num12 <= num7)
								{
									if (!value.怒)
									{
										value.人物_SP++;
									}
								}
								else if (!value.怒)
								{
									value.人物_SP += 2;
								}
								try
								{
									if ((double)RNG.Next(1, 100) <= value.韩_追骨吸元)
									{
										double num2 = (double)num12 * value.韩_追骨吸元 * 0.01;
										if (num2 <= 0.0)
										{
											num2 = 1.0;
										}
										value.加血((int)num2);
										if (Rxjh_HP > (int)num2)
										{
											Play_Hit(value, (int)num2);
											Rxjh_HP -= (int)num2;
										}
										else
										{
											Play_Hit(value, Rxjh_HP);
											Rxjh_HP = 0;
										}
										if (Rxjh_HP <= 0)
										{
											flag = true;
										}
									}
								}
								catch (Exception ex2)
								{
									MainForm.WriteLine(1, "自动攻击事件 韩飞官追骨吸元反伤 出错：" + ex2);
								}
							}
							else if (value.Player_Job == 9)
							{
								if ((double)RNG.Next(1, 100) <= value.谭_升天三气功_火凤临朝 && value.人物_HP <= 0)
								{
									value.人物_HP = 10;
									value.显示大字(value.人物全服ID, 322);
								}
								if ((double)num12 <= num7)
								{
									if (!value.怒)
									{
										value.人物_SP++;
									}
								}
								else if (!value.怒)
								{
									value.人物_SP += 2;
								}
							}
							else if (value.Player_Job == 10)
							{
								if (value.拳师_狂神降世 != 0.0)
								{
									if (!value.怒)
									{
										value.人物_SP += (int)(3.0 + (double)(value.Player_Level * 2) * value.拳师_狂神降世);
									}
								}
								else if ((double)num12 <= num7)
								{
									if (!value.怒)
									{
										value.人物_SP++;
									}
								}
								else if (!value.怒)
								{
									value.人物_SP += 2;
								}
							}
							else if (value.Player_Job == 11)
							{
								if ((double)num12 <= num7)
								{
									if (!value.怒)
									{
										value.人物_SP++;
									}
								}
								else if (!value.怒)
								{
									value.人物_SP += 2;
								}
								if (value.梅_障力恢复 > 0.0 && value.人物_AP * 2 < value.人物最大_AP && (double)RNG.Next(1, 100) <= value.梅_障力恢复)
								{
									value.人物_AP = value.人物最大_AP;
									value.显示大字(value.人物全服ID, 801);
								}
								if (value.梅_愤怒爆发 > 0.0 && RNG.Next(1, 100) <= 40 && value.怒点 < 3)
								{
									value.怒点++;
								}
							}
							else if ((double)num12 <= num7)
							{
								if (!value.怒)
								{
									value.人物_SP++;
								}
							}
							else if (!value.怒)
							{
								value.人物_SP += 2;
							}
							if (value.FLD_装备_追加_愤怒 > 0 && !value.怒)
							{
								value.人物_SP += value.FLD_装备_追加_愤怒;
							}
							if (value.FLD_装备_追加_中毒概率百分比 > 0.0 && (double)RNG.Next(1, 100) <= value.FLD_装备_追加_中毒概率百分比 && !ContainsKeyInAbnormalState(3))
							{
								异常状态.TryAdd(3, new 异常状态类(this, PlayerWid, 60000, 3, 0.0));
							}
							if (value.人物_HP <= 0)
							{
								if (World.是否开启死亡掉经验 == 1 && value.人物坐标_地图 != 41001 && value.Player_Level >= 10)
								{
									long num3 = ((long)World.lever[value.Player_Level + 1] - (long)World.lever[value.Player_Level]) / 1000;
									if (value.公有药品 != null)
									{
										if (value.检查符() || value.检查符2())
										{
											num3 = (long)((double)num3 * 0.01);
										}
									}
									else
									{
										int num4 = RNG.Next(1, 100);
										num3 = ((num4 >= 1 && num4 <= 10) ? num3 : ((num4 >= 11 && num4 <= 20) ? (num3 * 2) : ((num4 >= 21 && num4 <= 30) ? (num3 * 3) : ((num4 >= 31 && num4 <= 40) ? (num3 * 4) : ((num4 >= 41 && num4 <= 50) ? (num3 * 5) : ((num4 >= 51 && num4 <= 60) ? (num3 * 6) : ((num4 >= 61 && num4 <= 70) ? (num3 * 7) : ((num4 >= 71 && num4 <= 80) ? (num3 * 8) : ((num4 < 81 || num4 > 90) ? (num3 * 10) : (num3 * 9))))))))));
									}
									if (value.FLD_装备_追加_死亡损失经验减少 > 0.0)
									{
										num3 = (long)((double)num3 * (1.0 - value.FLD_装备_追加_死亡损失经验减少));
										if (num3 < 0)
										{
											num3 = 0L;
										}
									}
									for (int i = 0; i < 15; i++)
									{
										if (BitConverter.ToInt32(value.装备栏已穿装备[i].物品ID, 0) == 700004)
										{
											num3 = 0L;
											value.装备栏已穿装备[i].物品_byte = new byte[World.数据库单个物品大小];
											value.初始化已装备物品();
											break;
										}
									}
									if (value.GetAddState(1008000160) || value.GetAddState(1008000159))
									{
										num3 = 0L;
									}
									else if (value.特殊药品.ContainsKey(1008000142))
									{
										value.特殊药品.TryRemove(1008000142, out var _);
										value.药品新效果(1008000142, 0, 0u, 0u);
										num3 = 0L;
									}
									else
									{
										value.人物经验 -= num3;
										value.死亡掉经验 = true;
										value.计算人物基本数据3();
										value.更新经验和历练();
									}
								}
								自动攻击.Enabled = false;
								自动移动.Enabled = true;
								X = Rxjh_cs_X;
								Y = Rxjh_cs_Y;
								Z = Rxjh_cs_Z;
								发送移动数据(Rxjh_cs_X, Rxjh_cs_Y, 50, 1);
								value.人物_HP = 0;
								value.死亡2();
								PlayCw = null;
								Play_null();
							}
							if (flag)
							{
								发送死亡数据(value.人物全服ID);
							}
							value.更新HP_MP_SP();
						}
						else if (查找范围玩家(80, value))
						{
							发送移动数据(value.人物坐标_X, value.人物坐标_Y, 10, 2);
						}
						else
						{
							PlayCw = null;
							Play_null();
							自动攻击.Enabled = false;
							自动移动.Enabled = true;
							X = Rxjh_cs_X;
							Y = Rxjh_cs_Y;
							Z = Rxjh_cs_Z;
							发送移动数据(Rxjh_cs_X, Rxjh_cs_Y, 50, 1);
						}
					}
					else
					{
						PlayCw = null;
						Play_null();
						自动攻击.Enabled = false;
						自动移动.Enabled = true;
						X = Rxjh_cs_X;
						Y = Rxjh_cs_Y;
						Z = Rxjh_cs_Z;
						发送移动数据(Rxjh_cs_X, Rxjh_cs_Y, 50, 1);
					}
					return;
				}
			}
			catch (Exception)
			{
				PlayCw = null;
				Play_null();
				自动攻击.Enabled = false;
				自动移动.Enabled = true;
				X = Rxjh_cs_X;
				Y = Rxjh_cs_Y;
				Z = Rxjh_cs_Z;
				发送移动数据(Rxjh_cs_X, Rxjh_cs_Y, 50, 1);
			}
		}

		public List<NpcClass> 群攻查找范围Npc2(Players player, int 数量)
		{
			try
			{
				List<NpcClass> list = new List<NpcClass>();
				int num = 0;
				foreach (NpcClass value in player.NpcList.Values)
				{
					if (!value.NPC死亡 && value.IsNpc == 0 && 查找范围Npc(25, value) && value._FLD_INDEX != _FLD_INDEX)
					{
						list.Add(value);
						if (num >= 数量)
						{
							break;
						}
						num++;
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "群攻查找范围Npc 出错：" + ex);
				return null;
			}
		}

		public static void 更新NPC数据(ConcurrentDictionary<int, NpcClass> NpcList, Players Playe)
		{
			if (NpcList == null || NpcList.Count <= 0)
			{
				return;
			}
			using 发包类 发包类 = new 发包类();
			发包类.Write4(NpcList.Count);
			foreach (NpcClass value in NpcList.Values)
			{
				发包类.Write4(value.FLD_INDEX);
				发包类.Write4(value.FLD_INDEX);
				发包类.Write2(value.FLD_PID);
				if (value.NPC死亡)
				{
					发包类.Write2(0);
				}
				else
				{
					发包类.Write2(1);
				}
				发包类.Write4(value.Rxjh_HP);
				发包类.Write4(value.Max_Rxjh_HP);
				发包类.Write(value.X);
				发包类.Write(value.Z);
				发包类.Write(value.Y);
				发包类.Write(4f);
				发包类.Write(value.FLD_FACE1);
				发包类.Write(value.FLD_FACE2);
				发包类.Write(value.X);
				发包类.Write(value.Z);
				发包类.Write(value.Y);
				发包类.Write4(0);
				发包类.Write4(0);
				发包类.Write4(11);
				发包类.Write4(0);
				发包类.Write4(0);
				发包类.Write4(uint.MaxValue);
			}
			if (Playe.Client != null)
			{
				Playe.Client.SendPak(发包类, 26368, Playe.人物全服ID);
			}
		}

		public static void 更新NPC删除数据(ConcurrentDictionary<int, NpcClass> NpcList, Players Playe)
		{
			if (NpcList == null || NpcList.Count <= 0)
			{
				return;
			}
			using 发包类 发包类 = new 发包类();
			发包类.Write4(NpcList.Count);
			foreach (NpcClass value in NpcList.Values)
			{
				发包类.Write2(value.FLD_INDEX);
				发包类.Write2(value.FLD_INDEX);
				发包类.Write2(value.FLD_PID);
				发包类.Write4(1);
				发包类.Write4(value.Rxjh_HP);
				发包类.Write4(value.Max_Rxjh_HP);
				发包类.Write(value.X);
				发包类.Write(value.Z);
				发包类.Write(value.Y);
				发包类.Write4(1082130432);
				发包类.Write(value.FLD_FACE1);
				发包类.Write(value.FLD_FACE2);
				发包类.Write(value.X);
				发包类.Write(value.Z);
				发包类.Write(value.Y);
				发包类.Write4(0);
				发包类.Write4(0);
				发包类.Write4(12);
				发包类.Write4(0);
				发包类.Write4(0);
				发包类.Write4(uint.MaxValue);
			}
			if (Playe.Client != null)
			{
				Playe.Client.SendPak(发包类, 26624, Playe.人物全服ID);
			}
		}

		public void 更新NPC删除数据(Players Playe)
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write4(1);
			发包类.Write2(FLD_INDEX);
			发包类.Write2(FLD_INDEX);
			发包类.Write2(FLD_PID);
			发包类.Write4(1);
			发包类.Write4(Rxjh_HP);
			发包类.Write4(Max_Rxjh_HP);
			发包类.Write(X);
			发包类.Write(Z);
			发包类.Write(Y);
			发包类.Write4(1082130432);
			发包类.Write(FLD_FACE1);
			发包类.Write(FLD_FACE2);
			发包类.Write(X);
			发包类.Write(Z);
			发包类.Write(Y);
			发包类.Write4(0);
			发包类.Write4(0);
			发包类.Write4(12);
			发包类.Write4(0);
			发包类.Write4(0);
			发包类.Write4(uint.MaxValue);
			if (Playe.Client != null)
			{
				Playe.Client.SendPak(发包类, 26624, Playe.人物全服ID);
			}
		}

		public void 更新NPC复活数据()
		{
			try
			{
				NPC死亡 = false;
				Rxjh_HP = Max_Rxjh_HP;
				if (FLD_PID != 15349 && FLD_PID != 15350)
				{
					if (FLD_PID != 15450 && FLD_PID != 15451 && FLD_PID != 15452 && FLD_PID != 15453 && FLD_PID != 15491 && FLD_PID != 15492 && FLD_PID != 15493 && FLD_PID != 15494)
					{
						Random random = new Random();
						int num = random.Next(0, 2);
						double num2 = random.NextDouble() * 50.0;
						double num3 = random.NextDouble() * 50.0;
						if (num == 0)
						{
							X = Rxjh_cs_X + (float)num2;
							Y = Rxjh_cs_Y + (float)num3;
						}
						else
						{
							X = Rxjh_cs_X - (float)num2;
							Y = Rxjh_cs_Y - (float)num3;
						}
					}
					else
					{
						X = Rxjh_cs_X;
						Y = Rxjh_cs_Y;
					}
				}
				else
				{
					X = Rxjh_cs_X;
					Y = Rxjh_cs_Y;
				}
				Z = Rxjh_cs_Z;
				using (发包类 发包类 = new 发包类())
				{
					发包类.Write4(1);
					发包类.Write4(FLD_INDEX);
					发包类.Write4(FLD_INDEX);
					发包类.Write2(FLD_PID);
					发包类.Write2(1);
					发包类.Write4(Rxjh_HP);
					发包类.Write4(Max_Rxjh_HP);
					发包类.Write(X);
					发包类.Write(Z);
					发包类.Write(Y);
					发包类.Write(4f);
					发包类.Write(FLD_FACE1);
					发包类.Write(FLD_FACE2);
					发包类.Write(X);
					发包类.Write(Z);
					发包类.Write(Y);
					发包类.Write4(0);
					发包类.Write4(128369664);
					发包类.Write4(0);
					发包类.Write4(215040);
					发包类.Write4(0);
					发包类.Write4(786432);
					发包类.Write4(uint.MaxValue);
					发送当前范围广播数据(发包类, 31488, FLD_INDEX);
				}
				if (自动复活 != null)
				{
					自动复活.Enabled = false;
					自动复活.Close();
					自动复活.Dispose();
					自动复活 = null;
				}
			}
			catch (Exception ex)
			{
				if (自动复活 != null)
				{
					自动复活.Close();
					自动复活.Dispose();
					自动复活 = null;
				}
				if (World.是否开启票红字2 == 1)
				{
					MainForm.WriteLine(1, "更新NPC复活数据 出错" + FLD_PID + "|" + Name + ex.Message);
				}
			}
		}

		private void 更新NPC死亡数据(Players Playe)
		{
			using 发包类 pak = new 发包类();
			if (Playe.Client != null)
			{
				Playe.Client.SendPak(pak, 34816, FLD_INDEX);
			}
		}

		private void 广播NPC死亡数据()
		{
			using 发包类 pak = new 发包类();
			发送当前范围广播数据(pak, 34816, FLD_INDEX);
		}

		public void 发送移动数据(float X, float Y, int sl, int 移动方式)
		{
			if (FLD_PID == 16556)
			{
				return;
			}
			try
			{
				using 发包类 发包类 = new 发包类();
				Random random = new Random(DateTime.Now.Millisecond);
				int num = RNG.Next(0, 4);
				double num2 = random.NextDouble() * (double)sl;
				double num3 = random.NextDouble() * (double)sl;
				switch (num)
				{
				case 0:
					this.X = X + (float)num2;
					this.Y = Y + (float)num3;
					break;
				case 1:
					this.X = X + (float)num2;
					this.Y = Y - (float)num3;
					break;
				case 2:
					this.X = X - (float)num2;
					this.Y = Y - (float)num3;
					break;
				case 3:
					this.X = X - (float)num2;
					this.Y = Y + (float)num3;
					break;
				}
				发包类.Write(this.X);
				发包类.Write(this.Y);
				发包类.Write(Z);
				发包类.Write4(-1);
				if (FLD_PID == 5)
				{
					发包类.Write4(0);
				}
				else if (移动方式 != 2)
				{
					发包类.Write4(random.Next(0, 2));
				}
				else
				{
					发包类.Write4(移动方式);
				}
				double num4 = Math.Sqrt(X * this.X + Y * this.Y);
				发包类.Write((float)num4);
				发包类.Write4(Rxjh_HP);
				发包类.Write(this.X);
				发包类.Write(Z);
				发包类.Write(this.Y);
				发送当前范围广播数据(发包类, 29696, FLD_INDEX);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送移动数据 出错" + FLD_PID + "|" + Name + " " + ex.Message);
			}
		}

		public void 发送攻击数据(int 攻击力, int 攻击类型, int 人物全服ID, int 恢复障力)
		{
			try
			{
				if (攻击类型 == 29 && _有技能的BOSS列表.Contains(FLD_PID))
				{
					using 发包类 发包类 = new 发包类();
					发包类.Write4(人物全服ID);
					发包类.Write2(13);
					if (FLD_PID == 15419)
					{
						发包类.Write2(1);
					}
					if (FLD_PID == 15420)
					{
						发包类.Write2(1);
					}
					if (FLD_PID == 15421)
					{
						发包类.Write2(1);
					}
					if (FLD_PID == 15422)
					{
						发包类.Write2(1);
					}
					if (FLD_PID == 15423)
					{
						发包类.Write2(RNG.Next(0, 1));
					}
					if (FLD_PID == 15424)
					{
						发包类.Write2(RNG.Next(0, 1));
					}
					发包类.Write4(3);
					发包类.Write4(1);
					for (int i = 0; i < 8; i++)
					{
						发包类.Write4(0);
					}
					发送当前范围广播数据(发包类, 290, FLD_INDEX);
				}
				using 发包类 发包类2 = new 发包类();
				发包类2.Write4(人物全服ID);
				发包类2.Write2(1);
				发包类2.Write2(0);
				发包类2.Write4(攻击力);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(恢复障力);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(攻击类型);
				发包类2.Write(X);
				发包类2.Write(15f);
				发包类2.Write(Y);
				发包类2.Write(0);
				发包类2.Write(1);
				发包类2.Write2(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(-1);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发包类2.Write4(0);
				发送当前范围广播数据(发包类2, 3072, FLD_INDEX);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送攻击数据 出错" + FLD_PID + "|" + Name + " " + ex);
			}
		}

		public void 发送当前范围广播数据(发包类 pak, int id, int wordid)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "Players_发送当前范围广播数据");
			}
			try
			{
				if (PlayList == null)
				{
					return;
				}
				foreach (Players value in PlayList.Values)
				{
					if (value.Client != null && value.Client.Running)
					{
						if (!value.Client.挂机)
						{
							value.Client.SendPak(pak, id, wordid);
						}
						continue;
					}
					if (Contains(value))
					{
						PlayList.Remove(value.人物全服ID);
					}
					if (value.NpcList != null && value.NpcList.Count > 0)
					{
						foreach (NpcClass value2 in value.NpcList.Values)
						{
							if (value2.Contains(value))
							{
								value2.PlayList.Remove(value.人物全服ID);
							}
						}
					}
					if (value.Client != null)
					{
						MainForm.WriteLine(2, "NPC发送当前范围广播数据 删除卡号人物：[" + value.Userid + "] [" + value.UserName + "]");
						value.Client.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "NPC广播数据 出错3：" + ex);
			}
		}

		public void 更新死亡数据()
		{
			try
			{
				if (NPC死亡)
				{
					return;
				}
				NPC死亡 = true;
				if (_一次性怪)
				{
					if (PlayCw != null)
					{
						PlayCw = null;
					}
					Play_null();
					广播NPC死亡数据();
					Dispose();
					return;
				}
				if (自动攻击 != null)
				{
					自动攻击.Enabled = false;
				}
				if (自动移动 != null)
				{
					自动移动.Enabled = false;
				}
				if (自动复活 != null)
				{
					自动复活.Interval = FLD_NEWTIME * 1000;
					自动复活.Enabled = true;
				}
				else
				{
					自动复活 = new System.Timers.Timer(FLD_NEWTIME * 1000);
					自动复活.Elapsed += 自动复活事件;
					自动复活.Enabled = true;
				}
				if (PlayCw != null)
				{
					PlayCw = null;
				}
				Play_null();
				广播NPC死亡数据();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "更新死亡数据 出错" + FLD_PID + "|" + Name + " " + ex.Message);
			}
		}

		public void 发送采药数据()
		{
			if (IsNpc == 2)
			{
				if (自动复活 != null)
				{
					自动复活.Interval = FLD_NEWTIME * 1000;
					自动复活.Enabled = true;
				}
				else
				{
					自动复活 = new System.Timers.Timer(FLD_NEWTIME * 1000);
					自动复活.Elapsed += 自动复活事件;
					自动复活.Enabled = true;
				}
				PlayCw = null;
				Play_null();
				广播NPC死亡数据();
			}
		}

		public void 发送怪物一次性死亡数据()
		{
			try
			{
				异常状态列表();
				if (IsNpc != 1 && !NPC死亡)
				{
					if (PlayCw != null)
					{
						PlayCw = null;
					}
					Play_null();
					广播NPC死亡数据();
					Dispose();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送死亡数据1 出错" + FLD_PID + "|" + Name + " " + ex.Message);
			}
		}

		public void 势力战打怪得分(Players player, int 攻击血量)
		{
			try
			{
				if (!player.查找范围Npc(700, this) || 攻击血量 <= 0)
				{
					return;
				}
				if (攻击血量 > Max_Rxjh_HP)
				{
					攻击血量 = Max_Rxjh_HP;
				}
				double num = (double)攻击血量 / (double)Max_Rxjh_HP;
				if (Rxjh_Map == 801 && World.势力战进程 == 3 && World.EventTop.TryGetValue(player.UserName, out var value))
				{
					switch (FLD_PID)
					{
					case 15491:
					{
						int num7 = (int)(num * (double)World.势力战打死大怪得分);
						value.玩家杀怪分数 += num7;
						World.势力战邪分数 += num7;
						return;
					}
					case 15492:
					{
						int num4 = (int)(num * (double)World.势力战打死小怪得分);
						value.玩家杀怪分数 += num4;
						World.势力战邪分数 += num4;
						return;
					}
					case 15493:
					{
						int num9 = (int)(num * (double)World.势力战打死大怪得分);
						value.玩家杀怪分数 += num9;
						World.势力战正分数 += num9;
						return;
					}
					case 15494:
					{
						int num8 = (int)(num * (double)World.势力战打死小怪得分);
						value.玩家杀怪分数 += num8;
						World.势力战正分数 += num8;
						return;
					}
					case 15450:
					{
						int num6 = (int)(num * (double)World.势力战打死大怪得分);
						value.玩家杀怪分数 += num6;
						World.势力战邪分数 += num6;
						if (World.势力战类型 == 1)
						{
							World.eve.势力战胜利状态 = 2;
							World.eve.势力战进行中结束时间 = DateTime.Now;
						}
						return;
					}
					case 15451:
					{
						int num5 = (int)(num * (double)World.势力战打死小怪得分);
						value.玩家杀怪分数 += num5;
						World.势力战邪分数 += num5;
						return;
					}
					case 15452:
					{
						int num3 = (int)(num * (double)World.势力战打死大怪得分);
						value.玩家杀怪分数 += num3;
						World.势力战正分数 += num3;
						if (World.势力战类型 == 1)
						{
							World.eve.势力战胜利状态 = 1;
							World.eve.势力战进行中结束时间 = DateTime.Now;
						}
						return;
					}
					case 15453:
					{
						int num2 = (int)(num * (double)World.势力战打死小怪得分);
						value.玩家杀怪分数 += num2;
						World.势力战正分数 += num2;
						return;
					}
					}
				}
				if (Rxjh_Map == 21001 && FLD_PID == 15226 && World.伏魔洞副本 != null)
				{
					World.伏魔洞副本.bossgcsj = DateTime.Now;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "势力战打死大怪:" + ex.Message + "/" + ex.StackTrace);
			}
		}

		public void 怪物死亡掉落任务物品(Players yxqplayer)
		{
			try
			{
				if (yxqplayer.组队id == 0 || yxqplayer.组队阶段 != 2 || !World.Teams.TryGetValue(yxqplayer.组队id, out var value))
				{
					怪物死亡掉落物品实现(yxqplayer, 组队: false);
					return;
				}
				foreach (Players value2 in value.组队列表.Values)
				{
					if (查找范围玩家(1000, value2) && value2.人物_HP > 0 && !value2.Player死亡)
					{
						怪物死亡掉落物品实现(value2, value2.人物全服ID != yxqplayer.人物全服ID);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "掉落任务物品出错 怪物ID-" + FLD_PID + ex.Message);
			}
		}

		public void 怪物死亡掉落物品实现(Players play, bool 组队)
		{
			int num = 0;
			try
			{
				foreach (任务类 value in play.任务.Values)
				{
					if (value.任务阶段ID == 0 || (组队 && !value.是否组队获得))
					{
						continue;
					}
					num = value.任务ID;
					任务类 rW = 任务类.GetRW(num);
					if (rW == null)
					{
						continue;
					}
					if (num == 45 && 15062 == FLD_PID)
					{
						play.设置任务物品(900000099, 1);
					}
					if (num == 46 && 15072 == FLD_PID)
					{
						play.设置任务物品(900000101, 1);
					}
					任务阶段类 rWJD = rW.GetRWJD(value.任务阶段ID);
					if (rWJD == null)
					{
						continue;
					}
					foreach (任务需要物品类 item in rWJD.任务需要物品)
					{
						if (item.NPCPID != 0 && (item.NPCPID == 0 || item.NPCPID == FLD_PID))
						{
							int num2 = RNG.Next(1, 100);
							if (!play.CheckItem(item.物品ID, item.物品数量) && num2 >= item.难度)
							{
								play.设置任务物品(item.物品ID, 1);
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "怪物死亡掉落物品实现出错 怪物ID-" + FLD_PID + "|任务ID-" + num + "|玩家name-" + play.UserName + "|" + ex.Message);
			}
		}

		public void 发送死亡数据(int UserWorldId)
		{
			int num = 0;
			if (IsNpc == 1 || NPC死亡 || !PlayList.TryGetValue(UserWorldId, out var value))
			{
				return;
			}
			try
			{
				num = 1;
				怪物死亡掉落任务物品(value);
				num = 2;
				异常状态列表();
				num = 3;
				获得分配经验();
				num = 4;
				暴物品(value);
				num = 5;
				if (FLD_PID == 15261)
				{
					value.AddItemWithProperties(1000000262, value.GetEmptyBagSlot(), 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					string text = "恭喜玩家[" + value.UserName + "]，在九泉之下击杀王龙获得[3根金条]...";
					World.conn.发送("狮子吼|" + value.人物全服ID + "|" + value.UserName + "|" + text + "|" + value.Client.ToString() + "|" + World.ServerID + "|" + value.人物坐标_地图 + "|" + 41);
				}
				num = 6;
				if (FLD_PID == 16556)
				{
					value.AddItemWithProperties(900000233, value.GetEmptyBagSlot(), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
					string text2 = "恭喜玩家[" + value.UserName + "]，在讨伐副本击杀堕落的地狱火龙获得[1个神器之石]...";
					World.conn.发送("狮子吼|" + value.人物全服ID + "|" + value.UserName + "|" + text2 + "|" + value.Client.ToString() + "|" + World.ServerID + "|" + value.人物坐标_地图 + "|" + 41);
				}
				num = 7;
				foreach (Players value3 in World.AllConnectedPlayers.Values)
				{
					if (!World.AllConnectedPlayers.TryGetValue(UserWorldId, out var value2))
					{
						continue;
					}
					if (FLD_PID == 16430)
					{
						value3.天魔神宫正城门已开启();
						World.天魔神宫大门是否死亡 = 1;
					}
					if (FLD_PID == 16431)
					{
						value3.天魔神宫东城门已开启();
						World.天魔神宫大门是否死亡 = 1;
					}
					if (FLD_PID == 16435)
					{
						Players players = 取最大攻击伤害者();
						if (players != null)
						{
							value2 = players;
						}
						value2.天魔神宫雕像击杀();
						value3.天魔神宫攻城胜利包(value2);
						value3.天魔神宫雕像击杀移动(value3);
						World.天魔神宫雕像是否死亡 = 1;
						World.SiegeWar.火龙之力释放 = false;
					}
				}
				NPC死亡 = true;
				num = 8;
				if (_一次性怪)
				{
					if (PlayCw != null)
					{
						PlayCw = null;
					}
					Play_null();
					广播NPC死亡数据();
					Dispose();
					return;
				}
				num = 9;
				if (自动攻击 != null)
				{
					自动攻击.Enabled = false;
				}
				if (自动移动 != null)
				{
					自动移动.Enabled = true;
				}
				num = 10;
				if (World.仙魔大战进程 == 3 && (_FLD_PID == 15121 || _FLD_PID == 15122))
				{
					if (_FLD_PID == 15122)
					{
						World.仙魔大战正分数 += 500;
					}
					else
					{
						World.仙魔大战邪分数 += 500;
					}
				}
				num = 11;
				if (自动复活 != null)
				{
					自动复活.Interval = FLD_NEWTIME * 1000;
					自动复活.Enabled = true;
				}
				else
				{
					自动复活 = new System.Timers.Timer(FLD_NEWTIME * 1000);
					自动复活.Elapsed += 自动复活事件;
					自动复活.Enabled = true;
				}
				num = 12;
				if (PlayCw != null)
				{
					PlayCw = null;
				}
				Play_null();
				广播NPC死亡数据();
			}
			catch (Exception ex)
			{
				if (World.是否开启票红字 == 1)
				{
					MainForm.WriteLine(1, "发送死亡数据2 出错" + FLD_PID + "|" + Name + "丨" + num + "丨" + ex.Message);
				}
			}
		}

		public Players 取最大攻击伤害者()
		{
			int num = 0;
			Players result = null;
			try
			{
				for (int i = 0; i < PlayGjList.Count; i++)
				{
					if (i >= PlayGjList.Count)
					{
						continue;
					}
					PlayGjClass playGjClass = PlayGjList[i];
					if (playGjClass != null)
					{
						int playID = playGjClass.PlayID;
						Players players = World.检查玩家世界ID(playID);
						if (players != null && players.组队id == 0 && num < playGjClass.Gjsl)
						{
							num = playGjClass.Gjsl;
							result = players;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "取最大攻击伤害者出错:" + ex.Message);
			}
			return result;
		}

		public void 获得分配经验()
		{
			int num = 0;
			try
			{
				num = 1;
				if (FLD_PID == 16556 && World.讨伐战副本 != null)
				{
					讨伐战系统.讨伐副本进程 = 2;
					World.讨伐战副本.时间结束事件1(null, null);
					World.讨伐战副本.讨伐奖励buff();
					World.DistributeCrusadeRewards();
				}
				num = 2;
				double num12 = World.经验倍数;
				if (World.EnableServerWideExp != null)
				{
					num12 *= World.双倍奖励经验倍数;
				}
				double num23 = (double)Rxjh_Exp * num12;
				int maxValue = (int)(num23 / 10.0);
				double num33 = num23 + (double)publicRan.Next(0, maxValue);
				int num34 = Rxjh_Exp * World.钱倍数 / World.钱总倍率;
				int num35 = num34 / 3;
				double num36 = publicRan.Next(num34 - num35, num34 + num35);
				int num37 = Rxjh_Exp * World.历练倍数 / World.历练总倍率;
				int num38 = num37 / 3;
				double num2 = publicRan.Next(num37 - num38, num37 + num38);
				int num3 = (int)((double)Rxjh_Exp * World.升天历练倍数 / (double)World.升天历练总倍率);
				int num4 = num3 / 3;
				double num5 = publicRan.Next(num3 - num4, num3 + num4);
				num = 3;
				if (是否绝命技死亡)
				{
					num34 += (int)((double)num34 * 绝命技死亡金钱加成);
					num12 += (double)(int)(num12 * 绝命技死亡经验加成);
					num37 += (int)((double)num37 * 绝命技死亡历练加成);
					num3 += (int)((double)num3 * 绝命技死亡历练加成);
				}
				if (num36 > 100000000.0)
				{
					num36 = 100000000.0;
				}
				num = 4;
				foreach (PlayGjClass playGj in PlayGjList)
				{
					if (!World.AllConnectedPlayers.TryGetValue(playGj.PlayID, out var value))
					{
						continue;
					}
					num = 5;
					if (value.组队id != 0)
					{
						if (World.Teams.TryGetValue(value.组队id, out var value2))
						{
							num = 6;
							if (value2.组队列表.ContainsKey(value.人物全服ID))
							{
								foreach (PlayZDClass value4 in 组队列表.Values)
								{
									if (value.组队id == value4.dwID)
									{
										value4.Hitsl += playGj.Hitsl;
										break;
									}
								}
							}
							else
							{
								if (!查找范围玩家(700, value) || Math.Abs(value.Player_Level - Level) >= World.获得经验等级差)
								{
									continue;
								}
								double num6 = num33 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
								double num7 = num2 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
								double num8 = num36 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
								double num9 = num5 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
								num = 7;
								if (value.中级附魂_奇缘 != 0 && (double)publicRan.Next(0, 80) <= (double)value.中级附魂_奇缘)
								{
									num6 *= 2.0;
									value.显示大字(value.人物全服ID, 403);
								}
								num = 8;
								if (value.检查公有药品())
								{
									num6 += num6 * 0.2;
									num7 += num7 * 0.5;
									num9 += num9 * 0.4;
									num8 += num8 * 0.2;
								}
								num = 9;
								if (value.Player_Level < 35)
								{
									num6 *= World.三十五级以下经验倍数;
								}
								else if (value.Player_Level < 60)
								{
									num6 *= World.六十级以下经验倍数;
								}
								else if (value.Player_Level < 80)
								{
									num6 *= World.八十级以下经验倍数;
								}
								else if (value.Player_Level < 100)
								{
									num6 *= World.百级以下经验倍数;
								}
								else if (value.Player_Level < 115)
								{
									num6 *= World.升天一以下经验倍数;
								}
								else if (value.Player_Level < 120)
								{
									num6 *= World.升天二以下经验倍数;
								}
								else if (value.Player_Level < 130)
								{
									num6 *= World.升天三以下经验倍数;
								}
								else if (value.Player_Level < 140)
								{
									num6 *= World.升天四以下经验倍数;
								}
								else if (value.Player_Level < 150)
								{
									num6 *= World.升天五以下经验倍数;
								}
								num = 10;
								if (value.查询天关地图(value.人物坐标_地图))
								{
									num6 *= (double)(int)value.得到天关福利加成(0, value.人物坐标_地图);
								}
								num = 11;
								if (value.FLD_SPREADER_LEVEL == 1)
								{
									num6 *= 1.01;
								}
								else if (value.FLD_SPREADER_LEVEL == 2)
								{
									num6 *= 1.02;
								}
								else if (value.FLD_SPREADER_LEVEL == 3)
								{
									num6 *= 1.03;
								}
								num = 12;
								if (value.Player_Level < World.限制最高级别)
								{
									double 经验 = num6 * (1.0 + value.人物_追加_经验百分比 + value.FLD_装备_追加_经验百分比 + value.FLD_灵宠_追加_经验百分比 + value.FLD_宠物_追加_经验百分比) * (1.0 - value.LS_降低_经验百分比);
									value.精神宝珠包(3, 经验);
									value.人物获得经验(经验);
								}
								double num10 = 1.0 + num7 * (1.0 + value.FLD_人物_追加_历练百分比 + value.FLD_灵宠_追加_历练百分比) * (1.0 - value.LS_降低_历练百分比);
								double num11 = 1.0 + num9 * (1.0 + value.FLD_人物_追加_历练百分比 + value.FLD_灵宠_追加_历练百分比) * (1.0 - value.LS_降低_历练百分比);
								value.Player_ExpErience += (int)num10;
								value.升天历练当前获得数 += (int)num11;
								num = 13;
								if (World.是否开启王龙 == 1)
								{
									if (value.人物坐标_地图 >= 23001 && value.人物坐标_地图 <= 23050)
									{
										World.王龙的金币 += (uint)(num8 * (1.0 - World.九泉金币比率));
									}
									else
									{
										World.王龙的金币 += (uint)(num8 * (1.0 - World.其他地图金币比率));
									}
								}
								double 金币 = 1.0 + num8 * (1.0 + value.FLD_装备_追加_获得游戏币百分比 + value.FLD_人物_追加_获得游戏币百分比) * (1.0 - value.LS_降低_金钱百分比);
								value.人物获得金钱(金币, 1);
								value.计算人物基本数据3();
								value.更新经验和历练();
								value.更新金钱和负重();
							}
						}
						else
						{
							if (!查找范围玩家(700, value) || Math.Abs(value.Player_Level - Level) >= World.获得经验等级差)
							{
								continue;
							}
							double num13 = num33 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
							double num14 = num2 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
							double num15 = num36 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
							double num16 = num5 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
							num = 14;
							if (value.中级附魂_奇缘 != 0 && (double)publicRan.Next(0, 80) <= (double)value.中级附魂_奇缘)
							{
								num13 *= 2.0;
								value.显示大字(value.人物全服ID, 403);
							}
							num = 15;
							if (value.检查公有药品())
							{
								num13 += num13 * 0.2;
								num14 += num14 * 0.5;
								num16 += num16 * 0.4;
								num15 += num15 * 0.2;
							}
							num = 16;
							if (value.Player_Level < 35)
							{
								num13 *= World.三十五级以下经验倍数;
							}
							else if (value.Player_Level < 60)
							{
								num13 *= World.六十级以下经验倍数;
							}
							else if (value.Player_Level < 80)
							{
								num13 *= World.八十级以下经验倍数;
							}
							else if (value.Player_Level < 100)
							{
								num13 *= World.百级以下经验倍数;
							}
							else if (value.Player_Level < 115)
							{
								num13 *= World.升天一以下经验倍数;
							}
							else if (value.Player_Level < 120)
							{
								num13 *= World.升天二以下经验倍数;
							}
							else if (value.Player_Level < 130)
							{
								num13 *= World.升天三以下经验倍数;
							}
							else if (value.Player_Level < 140)
							{
								num13 *= World.升天四以下经验倍数;
							}
							else if (value.Player_Level < 150)
							{
								num13 *= World.升天五以下经验倍数;
							}
							num = 17;
							if (value.查询天关地图(value.人物坐标_地图))
							{
								num13 *= (double)(int)value.得到天关福利加成(0, value.人物坐标_地图);
							}
							num = 18;
							if (value.FLD_SPREADER_LEVEL == 1)
							{
								num13 *= 1.01;
							}
							else if (value.FLD_SPREADER_LEVEL == 2)
							{
								num13 *= 1.02;
							}
							else if (value.FLD_SPREADER_LEVEL == 3)
							{
								num13 *= 1.03;
							}
							num = 19;
							if (value.Player_Level < World.限制最高级别)
							{
								double 经验2 = num13 * (1.0 + value.人物_追加_经验百分比 + value.FLD_装备_追加_经验百分比 + value.FLD_灵宠_追加_经验百分比 + value.FLD_宠物_追加_经验百分比) * (1.0 - value.LS_降低_经验百分比);
								value.精神宝珠包(3, 经验2);
								value.人物获得经验(经验2);
							}
							double num17 = 1.0 + num14 * (1.0 + value.FLD_人物_追加_历练百分比 + value.FLD_灵宠_追加_历练百分比) * (1.0 - value.LS_降低_历练百分比);
							double num18 = 1.0 + num16 * (1.0 + value.FLD_人物_追加_历练百分比 + value.FLD_灵宠_追加_历练百分比) * (1.0 - value.LS_降低_历练百分比);
							value.Player_ExpErience += (int)num17;
							value.升天历练当前获得数 += (int)num18;
							num = 20;
							if (World.是否开启王龙 == 1)
							{
								if (value.人物坐标_地图 >= 23001 && value.人物坐标_地图 <= 23050)
								{
									World.王龙的金币 += (uint)(num15 * (1.0 - World.九泉金币比率));
								}
								else
								{
									World.王龙的金币 += (uint)(num15 * (1.0 - World.其他地图金币比率));
								}
							}
							double 金币2 = 1.0 + num15 * (1.0 + value.FLD_装备_追加_获得游戏币百分比 + value.FLD_人物_追加_获得游戏币百分比) * (1.0 - value.LS_降低_金钱百分比);
							value.人物获得金钱(金币2, 1);
							value.计算人物基本数据3();
							value.更新经验和历练();
							value.更新金钱和负重();
						}
					}
					else
					{
						if (!查找范围玩家(700, value) || Math.Abs(value.Player_Level - Level) >= World.获得经验等级差)
						{
							continue;
						}
						double num19 = num33 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
						double num20 = num2 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
						double num21 = num36 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
						double num22 = num5 * (double)playGj.Hitsl / (double)Max_Rxjh_HP;
						num = 21;
						if (value.中级附魂_奇缘 != 0 && (double)publicRan.Next(0, 80) <= (double)value.中级附魂_奇缘)
						{
							num19 *= 2.0;
							value.显示大字(value.人物全服ID, 403);
						}
						num = 22;
						if (value.检查公有药品())
						{
							num19 += num19 * 0.2;
							num20 += num20 * 0.5;
							num22 += num22 * 0.4;
							num21 += num21 * 0.2;
						}
						num = 23;
						if (value.Player_Level < 35)
						{
							num19 *= World.三十五级以下经验倍数;
						}
						else if (value.Player_Level < 60)
						{
							num19 *= World.六十级以下经验倍数;
						}
						else if (value.Player_Level < 80)
						{
							num19 *= World.八十级以下经验倍数;
						}
						else if (value.Player_Level < 100)
						{
							num19 *= World.百级以下经验倍数;
						}
						else if (value.Player_Level < 115)
						{
							num19 *= World.升天一以下经验倍数;
						}
						else if (value.Player_Level < 120)
						{
							num19 *= World.升天二以下经验倍数;
						}
						else if (value.Player_Level < 130)
						{
							num19 *= World.升天三以下经验倍数;
						}
						else if (value.Player_Level < 140)
						{
							num19 *= World.升天四以下经验倍数;
						}
						else if (value.Player_Level < 150)
						{
							num19 *= World.升天五以下经验倍数;
						}
						num = 24;
						if (value.查询天关地图(value.人物坐标_地图))
						{
							num19 *= (double)(int)value.得到天关福利加成(0, value.人物坐标_地图);
						}
						num = 25;
						if (value.FLD_SPREADER_LEVEL == 1)
						{
							num19 *= 1.01;
						}
						else if (value.FLD_SPREADER_LEVEL == 2)
						{
							num19 *= 1.02;
						}
						else if (value.FLD_SPREADER_LEVEL == 3)
						{
							num19 *= 1.03;
						}
						num = 26;
						if (value.Player_Level < World.限制最高级别)
						{
							double 经验3 = num19 * (1.0 + value.人物_追加_经验百分比 + value.FLD_装备_追加_经验百分比 + value.FLD_灵宠_追加_经验百分比 + value.FLD_宠物_追加_经验百分比) * (1.0 - value.LS_降低_经验百分比);
							value.精神宝珠包(3, 经验3);
							value.人物获得经验(经验3);
						}
						double num24 = 1.0 + num20 * (1.0 + value.FLD_人物_追加_历练百分比 + value.FLD_灵宠_追加_历练百分比) * (1.0 - value.LS_降低_历练百分比);
						double num25 = 1.0 + num22 * (1.0 + value.FLD_人物_追加_历练百分比 + value.FLD_灵宠_追加_历练百分比) * (1.0 - value.LS_降低_历练百分比);
						value.Player_ExpErience += (int)num24;
						value.升天历练当前获得数 += (int)num25;
						num = 27;
						if (World.是否开启王龙 == 1)
						{
							if (value.人物坐标_地图 >= 23001 && value.人物坐标_地图 <= 23050)
							{
								World.王龙的金币 += (uint)(num21 * (1.0 - World.九泉金币比率));
							}
							else
							{
								World.王龙的金币 += (uint)(num21 * (1.0 - World.其他地图金币比率));
							}
						}
						num = 41;
						double 金币3 = 1.0 + num21 * (1.0 + value.FLD_装备_追加_获得游戏币百分比 + value.FLD_人物_追加_获得游戏币百分比) * (1.0 - value.LS_降低_金钱百分比);
						value.人物获得金钱(金币3, 1);
						num = 42;
						value.计算人物基本数据3();
						num = 43;
						value.更新经验和历练();
						num = 44;
						value.更新金钱和负重();
					}
				}
				num = 28;
				foreach (PlayZDClass value5 in 组队列表.Values)
				{
					num = 29;
					if (!World.Teams.TryGetValue(value5.dwID, out var value3))
					{
						continue;
					}
					num = 30;
					foreach (Players value6 in value3.组队列表.Values)
					{
						num = 31;
						if (!查找范围玩家(700, value6) || value5.dwID != value6.组队id || Math.Abs(value6.Player_Level - Level) >= World.获得经验等级差 || value6.人物_HP <= 0 || value6.组队id == 0)
						{
							continue;
						}
						double num26 = num33 * (double)value5.Hitsl / (double)Max_Rxjh_HP * (1.0 + (double)value3.组队列表.Count * 0.1) * (1.0 + value6.人物_追加_经验百分比 + value6.FLD_装备_追加_经验百分比 + value6.FLD_灵宠_追加_经验百分比 + value6.FLD_宠物_追加_经验百分比) / (double)value3.组队列表.Count;
						double num27 = num2 * (double)value5.Hitsl / (double)Max_Rxjh_HP * (1.0 + (double)value3.组队列表.Count * 0.1) * (1.0 + value6.FLD_人物_追加_历练百分比) / (double)value3.组队列表.Count;
						double num28 = num5 * (double)value5.Hitsl / (double)Max_Rxjh_HP * (1.0 + (double)value3.组队列表.Count * 0.1) * (1.0 + value6.FLD_人物_追加_历练百分比) / (double)value3.组队列表.Count;
						double num29 = num36 * (double)value5.Hitsl / (double)Max_Rxjh_HP * (1.0 + (double)value3.组队列表.Count * 0.1) * (1.0 + value6.FLD_装备_追加_获得游戏币百分比 + value6.FLD_人物_追加_获得游戏币百分比) / (double)value3.组队列表.Count;
						num = 32;
						if (value3.组队列表.Count == 1)
						{
							num26 = num33 * (double)value5.Hitsl / (double)Max_Rxjh_HP * (1.0 + value6.人物_追加_经验百分比);
							num27 = num2 * (double)value5.Hitsl / (double)Max_Rxjh_HP * (1.0 + value6.FLD_人物_追加_历练百分比);
							num28 = num5 * (double)value5.Hitsl / (double)Max_Rxjh_HP * (1.0 + value6.FLD_人物_追加_历练百分比);
							num29 = num36 * (double)value5.Hitsl / (double)Max_Rxjh_HP * (1.0 + value6.FLD_装备_追加_获得游戏币百分比 + value6.FLD_人物_追加_获得游戏币百分比);
						}
						else if (value3.组队列表.Count == 8)
						{
							num26 += num26 * World.八人组队经验加成;
						}
						else if (value3.组队列表.Count == 7)
						{
							num26 += num26 * World.七人组队经验加成;
						}
						else if (value3.组队列表.Count == 6)
						{
							num26 += num26 * World.六人组队经验加成;
						}
						else if (value3.组队列表.Count == 5)
						{
							num26 += num26 * World.五人组队经验加成;
						}
						else if (value3.组队列表.Count == 4)
						{
							num26 += num26 * World.四人组队经验加成;
						}
						else if (value3.组队列表.Count == 3)
						{
							num26 += num26 * World.三人组队经验加成;
						}
						else if (value3.组队列表.Count == 2)
						{
							num26 += num26 * World.二人组队经验加成;
						}
						num = 33;
						if (value3.红包)
						{
							num26 += num26 * 0.2;
							num27 += num27 * 0.2;
							num28 += num28 * 0.2;
							num29 += num29 * 0.2;
						}
						num = 34;
						if (value6.检查公有药品())
						{
							num26 += num26 * 0.2;
							num27 += num27 * 0.5;
							num28 += num28 * 0.4;
							num29 += num29 * 0.2;
						}
						num = 35;
						if (value6.Player_Level < 35)
						{
							num26 *= World.三十五级以下经验倍数;
						}
						else if (value6.Player_Level < 60)
						{
							num26 *= World.六十级以下经验倍数;
						}
						else if (value6.Player_Level < 80)
						{
							num26 *= World.八十级以下经验倍数;
						}
						else if (value6.Player_Level < 100)
						{
							num26 *= World.百级以下经验倍数;
						}
						else if (value6.Player_Level < 115)
						{
							num26 *= World.升天一以下经验倍数;
						}
						else if (value6.Player_Level < 120)
						{
							num26 *= World.升天二以下经验倍数;
						}
						else if (value6.Player_Level < 130)
						{
							num26 *= World.升天三以下经验倍数;
						}
						else if (value6.Player_Level < 140)
						{
							num26 *= World.升天四以下经验倍数;
						}
						else if (value6.Player_Level < 150)
						{
							num26 *= World.升天五以下经验倍数;
						}
						num = 36;
						if (value6.医生群疗_追加_经验百分比 > 0.0)
						{
							num26 *= 1.0 + value6.医生群疗_追加_经验百分比;
						}
						num = 37;
						if (value6.查询天关地图(value6.人物坐标_地图))
						{
							num26 *= (double)(int)value6.得到天关福利加成(0, value6.人物坐标_地图);
						}
						num = 38;
						if (value6.FLD_SPREADER_LEVEL == 1)
						{
							num26 *= 1.01;
						}
						else if (value6.FLD_SPREADER_LEVEL == 2)
						{
							num26 *= 1.02;
						}
						else if (value6.FLD_SPREADER_LEVEL == 3)
						{
							num26 *= 1.03;
						}
						double num30 = 1.0 - value6.LS_降低_历练百分比;
						value6.升天历练当前获得数 += (int)(num28 * num30);
						num = 39;
						if (value6.Player_Level < World.限制最高级别)
						{
							double num31 = 1.0 - value6.LS_降低_经验百分比;
							value6.精神宝珠包(3, num26 * num31);
							value6.人物获得经验(num26);
						}
						value6.Player_ExpErience += (int)(num27 * num30);
						num = 40;
						if (World.是否开启王龙 == 1)
						{
							if (value6.人物坐标_地图 >= 23002 && value6.人物坐标_地图 <= 23052)
							{
								World.王龙的金币 += (uint)(num29 * (1.0 - World.九泉金币比率));
							}
							else
							{
								World.王龙的金币 += (uint)(num29 * (1.0 - World.其他地图金币比率));
							}
						}
						double num32 = 1.0 - value6.LS_降低_金钱百分比;
						value6.人物获得金钱(num29 * num32, 1);
						value6.计算人物基本数据3();
						value6.更新经验和历练();
						value6.更新金钱和负重();
					}
				}
			}
			catch (Exception ex)
			{
				if (World.是否开启票红字 == 1)
				{
					MainForm.WriteLine(1, "怪物死亡分配经验出错:标记" + num + "/PID:" + FLD_PID + "/" + ex.Message);
				}
			}
		}

		public void 发送反伤攻击数据(int 攻击力, int 人物ID)
		{
			byte[] array = Converter.hexStringToByte("AA551B00A42789000C002C0100000F0000000100000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(人物ID), 0, array, 10, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(攻击力), 0, array, 18, 2);
			广播数据(array, array.Length);
		}

		public byte[] 掉出物品(DropClass drop, Players yxqname)
		{
			byte[] result;
			try
			{
				long dBItmeId = RxjhClass.GetDBItmeId();
				byte[] array = new byte[World.数据库单个物品大小];
				byte[] bytes = BitConverter.GetBytes(dBItmeId);
				byte[] array2 = new byte[20];
				if (!World.Itme.TryGetValue(drop.FLD_PID, out var value))
				{
					result = null;
				}
				else if (value.FLD_QUESTITEM != 1)
				{
					try
					{
						if (World.Droplog)
						{
							object[] args = new object[13]
							{
								"物品掉落--物品名:", drop.FLD_NAME, " 属性1[", drop.FLD_MAGIC0, "]属性2[", drop.FLD_MAGIC1, "]属性3[", drop.FLD_MAGIC2, "]属性4[", drop.FLD_MAGIC3,
								"]属性5[", drop.FLD_MAGIC4, "]"
							};
							MainForm.WriteLine(4, string.Concat(args));
						}
						if (drop.是否开启公告 == 1 && World.是否开启公告掉落提示 == 0)
						{
							string text = yxqname.UserName + "玩家的队伍在[" + Name + "]处获得了[" + drop.FLD_NAME + "]。";
							World.conn.发送("刷怪掉宝|" + 10 + "|" + text + "|" + World.ServerID);
						}
						Buffer.BlockCopy(BitConverter.GetBytes(drop.FLD_MAGIC0), 0, array2, 0, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(drop.FLD_MAGIC1), 0, array2, 4, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(drop.FLD_MAGIC2), 0, array2, 8, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(drop.FLD_MAGIC3), 0, array2, 12, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(drop.FLD_MAGIC4), 0, array2, 16, 4);
						Buffer.BlockCopy(bytes, 0, array, 0, 4);
						Buffer.BlockCopy(array2, 0, array, 16, 20);
						Buffer.BlockCopy(BitConverter.GetBytes(drop.FLD_PID), 0, array, 8, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 12, 4);
						if (value.FLD_NJ > 0 && (value.FLD_RESIDE2 == 1 || value.FLD_RESIDE2 == 2 || value.FLD_RESIDE2 == 5 || value.FLD_RESIDE2 == 4 || value.FLD_RESIDE2 == 6))
						{
							Buffer.BlockCopy(BitConverter.GetBytes(1000), 0, array, 56, 2);
						}
					}
					catch (Exception ex)
					{
						Exception ex2 = ex;
						object[] args2 = new object[6] { "掉出物品1 出错 ", FLD_PID, "|", Name, " ", ex2.Message };
						MainForm.WriteLine(1, string.Concat(args2));
						result = null;
						return result;
					}
					地面物品类 地面物品类2;
					地面物品类 value2;
					try
					{
						if (FLD_BOSS != 0)
						{
							Random random = new Random();
							int num = random.Next(0, 2);
							double num2 = random.NextDouble() * 25.0;
							double num3 = random.NextDouble() * 25.0;
							地面物品类2 = ((num != 0) ? new 地面物品类(array, X - (float)num2, Y - (float)num3, Z, Rxjh_Map, yxqname, 0, FLD_PID, drop.是否开启公告) : new 地面物品类(array, X + (float)num2, Y + (float)num3, Z, Rxjh_Map, yxqname, 0, FLD_PID, drop.是否开启公告));
						}
						else
						{
							地面物品类2 = new 地面物品类(array, X, Y, Z, Rxjh_Map, yxqname, 0, FLD_PID, drop.是否开启公告);
						}
						if (地面物品类2 == null)
						{
							object[] args3 = new object[4] { "掉出物品2 出错 ", FLD_PID, "|", Name };
							MainForm.WriteLine(1, string.Concat(args3));
							result = null;
							return result;
						}
						if (!World.ItemTemp.TryGetValue(dBItmeId, out value2))
						{
							World.ItemTemp.Add(dBItmeId, 地面物品类2);
						}
					}
					catch (Exception ex3)
					{
						object[] args4 = new object[6] { "掉出物品3 出错 ", FLD_PID, "|", Name, " ", ex3.Message };
						MainForm.WriteLine(1, string.Concat(args4));
						result = null;
						return result;
					}
					try
					{
						if (World.ItemTemp.TryGetValue(dBItmeId, out value2))
						{
							地面物品类2.获取范围玩家发送地面增加物品数据包();
						}
						result = array;
					}
					catch (Exception ex4)
					{
						object[] args5 = new object[6] { "掉出物品4 出错 ", FLD_PID, "|", Name, " ", ex4.Message };
						MainForm.WriteLine(1, string.Concat(args5));
						result = null;
					}
				}
				else
				{
					if (yxqname != null)
					{
						int num4 = yxqname.得到包裹空位(yxqname);
						if (num4 != -1)
						{
							yxqname.增加物品(bytes, BitConverter.GetBytes(drop.FLD_PID), num4, BitConverter.GetBytes(1), new byte[56]);
						}
					}
					result = null;
				}
			}
			catch (Exception ex5)
			{
				Exception ex6 = ex5;
				object[] args6 = new object[6] { "掉出物品5 出错 ", FLD_PID, "|", Name, " ", ex6.Message };
				MainForm.WriteLine(1, string.Concat(args6));
				result = null;
			}
			finally
			{
				drop.FLD_PID = drop.FLD_PIDNew;
				drop.FLD_MAGIC0 = drop.FLD_MAGICNew0;
				drop.FLD_MAGIC1 = drop.FLD_MAGICNew1;
				drop.FLD_MAGIC2 = drop.FLD_MAGICNew2;
				drop.FLD_MAGIC3 = drop.FLD_MAGICNew3;
				drop.FLD_MAGIC4 = drop.FLD_MAGICNew4;
			}
			return result;
		}

		public void 暴物品(Players yxqname)
		{
			try
			{
				if (Rxjh_Map == 41001)
				{
					yxqname = null;
				}
				switch (FLD_BOSS)
				{
				case 0:
				{
					int num = yxqname.Player_Level - Level;
					int num2 = Level - yxqname.Player_Level;
					if (num < int.Parse(World.获得物品等级差[0]) && num2 < int.Parse(World.获得物品等级差[1]))
					{
						暴物品2(yxqname);
					}
					break;
				}
				case 1:
					Boss暴物品(yxqname);
					break;
				case 2:
					GS暴物品(yxqname);
					break;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "暴物品 出错：" + ex);
			}
		}

		public void GS暴物品(Players yxqname)
		{
			try
			{
				if (Rxjh_Exp <= 0)
				{
					return;
				}
				int num = RNG.Next(1, 8000);
				int num6 = World.暴率;
				if (World.EnableServerWideExp != null)
				{
					num6 *= World.双倍奖励爆率倍数;
				}
				if (yxqname != null)
				{
					if (yxqname.Player_Level <= World.双倍暴率等级上限)
					{
						num6 *= (int)World.双倍等级上限倍数;
					}
					if (yxqname.FLD_人物_追加_物品掉落概率百分比 > 0.0)
					{
						num6 += (int)((double)num6 * yxqname.FLD_人物_追加_物品掉落概率百分比);
					}
					if (yxqname.查询天关地图(yxqname.人物坐标_地图))
					{
						num6 += (int)yxqname.得到天关福利加成(1, yxqname.人物坐标_地图);
					}
					if (yxqname.医生群疗_追加_爆率 > 0)
					{
						num6 += yxqname.医生群疗_追加_爆率;
					}
					if (yxqname.FLD_VIP == 1)
					{
						num6 += World.VIP爆率增加;
					}
					if (yxqname.FLD_SPREADER_LEVEL == 1)
					{
						num6 += 20;
					}
					else if (yxqname.FLD_SPREADER_LEVEL == 2)
					{
						num6 += 30;
					}
					else if (yxqname.FLD_SPREADER_LEVEL == 3)
					{
						num6 += 50;
					}
					if (yxqname.LS_降低_暴率百分比 != 0.0)
					{
						num6 = (int)((double)num6 * (1.0 - yxqname.LS_降低_暴率百分比));
					}
				}
				if (num > num6)
				{
					return;
				}
				List<DropClass> gSDrop = DropClass.GetGSDrop(yxqname, Level, Rxjh_Map, FLD_PID);
				if (gSDrop == null)
				{
					return;
				}
				foreach (DropClass item in gSDrop)
				{
					if (item == null)
					{
						continue;
					}
					switch (item.FLD_PID)
					{
					case 800000002:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC4 = 0;
							int num8 = RNG.Next(1, 100);
							foreach (DropShuXClass item5 in item.DropShuX)
							{
								if (num8 <= item5.Max)
								{
									fLD_MAGIC4 = RNG.Next(item5.ShuXMin, item5.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC4;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					case 800000001:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC2 = 0;
							int num4 = RNG.Next(1, 100);
							foreach (DropShuXClass item6 in item.DropShuX)
							{
								if (num4 <= item6.Max)
								{
									fLD_MAGIC2 = RNG.Next(item6.ShuXMin, item6.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC2;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					case 800000046:
						if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = RNG.Next(1, 22);
						}
						break;
					case 800000023:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC9 = 0;
							int num13 = RNG.Next(1, 100);
							foreach (DropShuXClass item7 in item.DropShuX)
							{
								if (num13 <= item7.Max)
								{
									fLD_MAGIC9 = RNG.Next(item7.ShuXMin, item7.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC9;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					case 800000024:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC8 = 0;
							int num12 = RNG.Next(1, 100);
							foreach (DropShuXClass item8 in item.DropShuX)
							{
								if (num12 <= item8.Max)
								{
									fLD_MAGIC8 = RNG.Next(item8.ShuXMin, item8.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC8;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					case 800000025:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC6 = 0;
							int num10 = RNG.Next(1, 100);
							foreach (DropShuXClass item9 in item.DropShuX)
							{
								if (num10 <= item9.Max)
								{
									fLD_MAGIC6 = RNG.Next(item9.ShuXMin, item9.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC6;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					case 800000026:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC3 = 0;
							int num5 = RNG.Next(1, 100);
							foreach (DropShuXClass item10 in item.DropShuX)
							{
								if (num5 <= item10.Max)
								{
									fLD_MAGIC3 = RNG.Next(item10.ShuXMin, item10.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC3;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					case 800000028:
						item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						break;
					case 800000030:
						item.FLD_MAGIC0 = World.GetValue(800000030, 5);
						break;
					case 800000031:
						item.FLD_MAGIC0 = World.GetValue(800000031, 5);
						break;
					case 800000032:
						item.FLD_MAGIC0 = World.GetValue(800000032, 5);
						break;
					case 800000033:
						item.FLD_MAGIC0 = World.GetValue(800000033, 5);
						break;
					case 800000061:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC5 = 0;
							int num9 = RNG.Next(1, 100);
							foreach (DropShuXClass item11 in item.DropShuX)
							{
								if (num9 <= item11.Max)
								{
									fLD_MAGIC5 = RNG.Next(item11.ShuXMin, item11.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC5;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					case 800000071:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC11 = 0;
							int num3 = RNG.Next(1, 100);
							foreach (DropShuXClass item12 in item.DropShuX)
							{
								if (num3 <= item12.Max)
								{
									fLD_MAGIC11 = RNG.Next(item12.ShuXMin, item12.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC11;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					case 800000047:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC10 = 0;
							int num2 = RNG.Next(1, 100);
							foreach (DropShuXClass item2 in item.DropShuX)
							{
								if (num2 <= item2.Max)
								{
									fLD_MAGIC10 = RNG.Next(item2.ShuXMin, item2.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC10;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = RNG.Next(23, 51);
						}
						break;
					case 1000000321:
						item.FLD_MAGIC0 = RNG.Next(1001, 2999);
						item.FLD_MAGIC1 = RNG.Next(10, 50);
						break;
					case 1000000323:
						item.FLD_MAGIC0 = RNG.Next(1001, 2999);
						item.FLD_MAGIC1 = RNG.Next(100, 150);
						break;
					case 1000000325:
						item.FLD_MAGIC0 = RNG.Next(1001, 2999);
						item.FLD_MAGIC1 = RNG.Next(400, 699);
						break;
					default:
					{
						if (item.FLD_MAGIC0 != 10)
						{
							break;
						}
						int fLD_MAGIC7 = 0;
						int num11 = RNG.Next(1, 100);
						foreach (DropShuXClass item3 in item.DropShuX)
						{
							if (num11 <= item3.Max)
							{
								fLD_MAGIC7 = RNG.Next(item3.ShuXMin, item3.ShuXMax - 1);
								break;
							}
						}
						item.FLD_MAGIC0 = fLD_MAGIC7;
						break;
					}
					case 1000000327:
						item.FLD_MAGIC0 = RNG.Next(1001, 2999);
						item.FLD_MAGIC1 = RNG.Next(2000, 2499);
						break;
					case 800000062:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC = 0;
							int num7 = RNG.Next(1, 100);
							foreach (DropShuXClass item4 in item.DropShuX)
							{
								if (num7 <= item4.Max)
								{
									fLD_MAGIC = RNG.Next(item4.ShuXMin, item4.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 5);
						}
						break;
					}
					掉出物品(item, yxqname);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "暴物品 出错：" + ex);
			}
		}

		public void Boss暴物品(Players yxqname)
		{
			try
			{
				if (Rxjh_Exp <= 0)
				{
					return;
				}
				List<DropClass> bossDrop = DropClass.GetBossDrop(yxqname, Level, Rxjh_Map, FLD_PID);
				if (bossDrop == null)
				{
					return;
				}
				foreach (DropClass item in bossDrop)
				{
					if (item == null)
					{
						continue;
					}
					switch (item.FLD_PID)
					{
					case 800000002:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC4 = 0;
							int num4 = RNG.Next(1, 100);
							foreach (DropShuXClass item5 in item.DropShuX)
							{
								if (num4 <= item5.Max)
								{
									fLD_MAGIC4 = RNG.Next(item5.ShuXMin, item5.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC4;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					case 800000001:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC2 = 0;
							int num2 = RNG.Next(1, 100);
							foreach (DropShuXClass item6 in item.DropShuX)
							{
								if (num2 <= item6.Max)
								{
									fLD_MAGIC2 = RNG.Next(item6.ShuXMin, item6.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC2;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					case 800000046:
						if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = RNG.Next(1, 22);
						}
						break;
					case 800000023:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC9 = 0;
							int num9 = RNG.Next(1, 100);
							foreach (DropShuXClass item7 in item.DropShuX)
							{
								if (num9 <= item7.Max)
								{
									fLD_MAGIC9 = RNG.Next(item7.ShuXMin, item7.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC9;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					case 800000024:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC8 = 0;
							int num8 = RNG.Next(1, 100);
							foreach (DropShuXClass item8 in item.DropShuX)
							{
								if (num8 <= item8.Max)
								{
									fLD_MAGIC8 = RNG.Next(item8.ShuXMin, item8.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC8;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					case 800000025:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC6 = 0;
							int num6 = RNG.Next(1, 100);
							foreach (DropShuXClass item9 in item.DropShuX)
							{
								if (num6 <= item9.Max)
								{
									fLD_MAGIC6 = RNG.Next(item9.ShuXMin, item9.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC6;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					case 800000026:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC3 = 0;
							int num3 = RNG.Next(1, 100);
							foreach (DropShuXClass item10 in item.DropShuX)
							{
								if (num3 <= item10.Max)
								{
									fLD_MAGIC3 = RNG.Next(item10.ShuXMin, item10.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC3;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					case 800000028:
						item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						break;
					case 800000030:
						item.FLD_MAGIC0 = World.GetValue(800000030, 4);
						break;
					case 800000031:
						item.FLD_MAGIC0 = World.GetValue(800000031, 4);
						break;
					case 800000032:
						item.FLD_MAGIC0 = World.GetValue(800000032, 4);
						break;
					case 800000033:
						item.FLD_MAGIC0 = World.GetValue(800000033, 4);
						break;
					case 800000061:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC5 = 0;
							int num5 = RNG.Next(1, 100);
							foreach (DropShuXClass item11 in item.DropShuX)
							{
								if (num5 <= item11.Max)
								{
									fLD_MAGIC5 = RNG.Next(item11.ShuXMin, item11.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC5;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					case 800000071:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC11 = 0;
							int num11 = RNG.Next(1, 100);
							foreach (DropShuXClass item12 in item.DropShuX)
							{
								if (num11 <= item12.Max)
								{
									fLD_MAGIC11 = RNG.Next(item12.ShuXMin, item12.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC11;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					case 800000047:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC10 = 0;
							int num10 = RNG.Next(1, 100);
							foreach (DropShuXClass item2 in item.DropShuX)
							{
								if (num10 <= item2.Max)
								{
									fLD_MAGIC10 = RNG.Next(item2.ShuXMin, item2.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC10;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = RNG.Next(23, 51);
						}
						break;
					case 1000000321:
						item.FLD_MAGIC0 = RNG.Next(1001, 2999);
						item.FLD_MAGIC1 = RNG.Next(10, 50);
						break;
					case 1000000323:
						item.FLD_MAGIC0 = RNG.Next(1001, 2999);
						item.FLD_MAGIC1 = RNG.Next(100, 150);
						break;
					case 1000000325:
						item.FLD_MAGIC0 = RNG.Next(1001, 2999);
						item.FLD_MAGIC1 = RNG.Next(400, 699);
						break;
					default:
					{
						if (item.FLD_MAGIC0 != 10)
						{
							break;
						}
						int fLD_MAGIC7 = 0;
						int num7 = RNG.Next(1, 100);
						foreach (DropShuXClass item3 in item.DropShuX)
						{
							if (num7 <= item3.Max)
							{
								fLD_MAGIC7 = RNG.Next(item3.ShuXMin, item3.ShuXMax - 1);
								break;
							}
						}
						item.FLD_MAGIC0 = fLD_MAGIC7;
						break;
					}
					case 1000000327:
						item.FLD_MAGIC0 = RNG.Next(1001, 2999);
						item.FLD_MAGIC1 = RNG.Next(2000, 2499);
						break;
					case 800000062:
						if (item.FLD_MAGIC0 == 10)
						{
							int fLD_MAGIC = 0;
							int num = RNG.Next(1, 100);
							foreach (DropShuXClass item4 in item.DropShuX)
							{
								if (num <= item4.Max)
								{
									fLD_MAGIC = RNG.Next(item4.ShuXMin, item4.ShuXMax - 1);
									break;
								}
							}
							item.FLD_MAGIC0 = fLD_MAGIC;
						}
						else if (item.FLD_MAGIC0 == 0)
						{
							item.FLD_MAGIC0 = World.GetValue(item.FLD_PID, 4);
						}
						break;
					}
					掉出物品(item, yxqname);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "暴物品 出错：" + ex);
			}
		}

		public void 暴物品2(Players yxqname)
		{
			try
			{
				if (Rxjh_Exp <= 0)
				{
					return;
				}
				int num = RNG.Next(1, 8000);
				int num6 = World.暴率;
				if (World.EnableServerWideExp != null)
				{
					num6 *= World.双倍奖励爆率倍数;
				}
				if (yxqname != null)
				{
					if (yxqname.Player_Level <= World.双倍暴率等级上限)
					{
						num6 *= (int)World.双倍等级上限倍数;
					}
					if (yxqname.FLD_人物_追加_物品掉落概率百分比 > 0.0)
					{
						num6 += (int)((double)num6 * yxqname.FLD_人物_追加_物品掉落概率百分比);
					}
					if (yxqname.查询天关地图(yxqname.人物坐标_地图))
					{
						num6 += (int)yxqname.得到天关福利加成(1, yxqname.人物坐标_地图);
					}
					if (yxqname.医生群疗_追加_爆率 > 0)
					{
						num6 += yxqname.医生群疗_追加_爆率;
					}
					if (yxqname.FLD_VIP == 1)
					{
						num6 += World.VIP爆率增加;
					}
					if (yxqname.FLD_SPREADER_LEVEL == 1)
					{
						num6 += 20;
					}
					else if (yxqname.FLD_SPREADER_LEVEL == 2)
					{
						num6 += 30;
					}
					else if (yxqname.FLD_SPREADER_LEVEL == 3)
					{
						num6 += 50;
					}
					if (yxqname.LS_降低_暴率百分比 != 0.0)
					{
						num6 = (int)((double)num6 * (1.0 - yxqname.LS_降低_暴率百分比));
					}
					if (是否绝命技死亡)
					{
						num6 += (int)((double)num6 * 绝命技死亡爆率加成);
					}
				}
				if (num > num6)
				{
					return;
				}
				DropClass drop = DropClass.GetDrop(yxqname, Level, Rxjh_Map, FLD_PID);
				if (drop == null)
				{
					return;
				}
				switch (drop.FLD_PID)
				{
				case 800000002:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC4 = 0;
						int num8 = RNG.Next(1, 100);
						foreach (DropShuXClass item in drop.DropShuX)
						{
							if (num8 <= item.Max)
							{
								fLD_MAGIC4 = RNG.Next(item.ShuXMin, item.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC4;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				case 800000001:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC2 = 0;
						int num4 = RNG.Next(1, 100);
						foreach (DropShuXClass item4 in drop.DropShuX)
						{
							if (num4 <= item4.Max)
							{
								fLD_MAGIC2 = RNG.Next(item4.ShuXMin, item4.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC2;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				case 800000046:
					if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = RNG.Next(1, 22);
					}
					break;
				case 800000023:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC9 = 0;
						int num13 = RNG.Next(1, 100);
						foreach (DropShuXClass item5 in drop.DropShuX)
						{
							if (num13 <= item5.Max)
							{
								fLD_MAGIC9 = RNG.Next(item5.ShuXMin, item5.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC9;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				case 800000024:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC8 = 0;
						int num12 = RNG.Next(1, 100);
						foreach (DropShuXClass item6 in drop.DropShuX)
						{
							if (num12 <= item6.Max)
							{
								fLD_MAGIC8 = RNG.Next(item6.ShuXMin, item6.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC8;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				case 800000025:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC6 = 0;
						int num10 = RNG.Next(1, 100);
						foreach (DropShuXClass item7 in drop.DropShuX)
						{
							if (num10 <= item7.Max)
							{
								fLD_MAGIC6 = RNG.Next(item7.ShuXMin, item7.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC6;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				case 800000026:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC3 = 0;
						int num5 = RNG.Next(1, 100);
						foreach (DropShuXClass item8 in drop.DropShuX)
						{
							if (num5 <= item8.Max)
							{
								fLD_MAGIC3 = RNG.Next(item8.ShuXMin, item8.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC3;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				case 800000028:
					drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					break;
				case 800000030:
					drop.FLD_MAGIC0 = World.GetValue(800000030, 3);
					break;
				case 800000031:
					drop.FLD_MAGIC0 = World.GetValue(800000031, 3);
					break;
				case 800000032:
					drop.FLD_MAGIC0 = World.GetValue(800000032, 3);
					break;
				case 800000033:
					drop.FLD_MAGIC0 = World.GetValue(800000033, 3);
					break;
				case 800000061:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC5 = 0;
						int num9 = RNG.Next(1, 100);
						foreach (DropShuXClass item9 in drop.DropShuX)
						{
							if (num9 <= item9.Max)
							{
								fLD_MAGIC5 = RNG.Next(item9.ShuXMin, item9.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC5;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				case 800000071:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC11 = 0;
						int num3 = RNG.Next(1, 100);
						foreach (DropShuXClass item10 in drop.DropShuX)
						{
							if (num3 <= item10.Max)
							{
								fLD_MAGIC11 = RNG.Next(item10.ShuXMin, item10.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC11;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				case 800000047:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC10 = 0;
						int num2 = RNG.Next(1, 100);
						foreach (DropShuXClass item11 in drop.DropShuX)
						{
							if (num2 <= item11.Max)
							{
								fLD_MAGIC10 = RNG.Next(item11.ShuXMin, item11.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC10;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = RNG.Next(23, 51);
					}
					break;
				case 1000000321:
					drop.FLD_MAGIC0 = RNG.Next(1001, 2999);
					drop.FLD_MAGIC1 = RNG.Next(10, 50);
					break;
				case 1000000323:
					drop.FLD_MAGIC0 = RNG.Next(1001, 2999);
					drop.FLD_MAGIC1 = RNG.Next(100, 150);
					break;
				case 1000000325:
					drop.FLD_MAGIC0 = RNG.Next(1001, 2999);
					drop.FLD_MAGIC1 = RNG.Next(400, 699);
					break;
				default:
				{
					if (drop.FLD_MAGIC0 != 10)
					{
						break;
					}
					int fLD_MAGIC7 = 0;
					int num11 = RNG.Next(1, 100);
					foreach (DropShuXClass item2 in drop.DropShuX)
					{
						if (num11 <= item2.Max)
						{
							fLD_MAGIC7 = RNG.Next(item2.ShuXMin, item2.ShuXMax - 1);
							break;
						}
					}
					drop.FLD_MAGIC0 = fLD_MAGIC7;
					break;
				}
				case 1000000327:
					drop.FLD_MAGIC0 = RNG.Next(1001, 2999);
					drop.FLD_MAGIC1 = RNG.Next(2000, 2499);
					break;
				case 800000062:
					if (drop.FLD_MAGIC0 == 10)
					{
						int fLD_MAGIC = 0;
						int num7 = RNG.Next(1, 100);
						foreach (DropShuXClass item3 in drop.DropShuX)
						{
							if (num7 <= item3.Max)
							{
								fLD_MAGIC = RNG.Next(item3.ShuXMin, item3.ShuXMax - 1);
								break;
							}
						}
						drop.FLD_MAGIC0 = fLD_MAGIC;
					}
					else if (drop.FLD_MAGIC0 == 0)
					{
						drop.FLD_MAGIC0 = World.GetValue(drop.FLD_PID, 3);
					}
					break;
				}
				掉出物品(drop, yxqname);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "暴物品 出错：" + ex);
			}
		}

		public void 异常状态列表()
		{
			if (异常状态 == null || 异常状态.Count == 0)
			{
				return;
			}
			Queue queue = Queue.Synchronized(new Queue());
			try
			{
				foreach (异常状态类 value2 in 异常状态.Values)
				{
					queue.Enqueue(value2);
				}
				while (queue.Count > 0)
				{
					异常状态类 异常状态类2 = (异常状态类)queue.Dequeue();
					异常状态类2.时间结束事件();
					if (异常状态 != null)
					{
						异常状态.TryRemove(异常状态类2.FLD_PID, out var _);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "MPC异常状态列表出错![" + FLD_INDEX + "]-[" + Name + "]" + ex.Message);
			}
			finally
			{
			}
		}

		public bool 查找范围Npc(int far_, NpcClass Npc)
		{
			if (Npc.Rxjh_Map != Rxjh_Map)
			{
				return false;
			}
			float num = Npc.X - X;
			float num2 = Npc.Y - Y;
			return (double)(int)Math.Sqrt((double)num * (double)num + (double)num2 * (double)num2) <= (double)far_;
		}

		public bool 查找范围玩家(int far_, Players Playe)
		{
			if (Playe.人物坐标_地图 != Rxjh_Map)
			{
				return false;
			}
			if (Playe.人物坐标_地图 == 7101)
			{
				far_ = 1000;
			}
			float num = Playe.人物坐标_X - X;
			float num2 = Playe.人物坐标_Y - Y;
			return (double)(int)Math.Sqrt((double)num * (double)num + (double)num2 * (double)num2) <= (double)far_;
		}

		public void 发送怪物头上图标(int 是否消失)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "NpcClass_发送怪物头上图标");
			}
			string hex = "AA551200E9478B100C0046050000E94700000100000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 14, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(是否消失), 0, array, 18, 4);
			广播数据(array, array.Length);
		}

		public bool 查找范围玩家(int far_, 灵兽类 Playe)
		{
			if (Playe.人物坐标_MAP != Rxjh_Map)
			{
				return false;
			}
			float num = Playe.人物坐标_X - X;
			float num2 = Playe.人物坐标_Y - Y;
			return (double)(int)Math.Sqrt((double)num * (double)num + (double)num2 * (double)num2) <= (double)far_;
		}

		public bool 获取范围玩家()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "NpcClass_获取范围玩家");
			}
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物_HP > 0 && 查找范围玩家(80, value))
					{
						吸怪清理(value);
						if (value.怪物攻击列表.Count < World.吸怪数量)
						{
							npc_Add(value);
							Play_Add(value);
							return true;
						}
					}
				}
			}
			catch (Exception)
			{
				return false;
			}
			return false;
		}

		public void 广播数据(byte[] data, int length)
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "Players_发送当前范围广播数据");
			}
			try
			{
				if (PlayList == null)
				{
					return;
				}
				foreach (Players value in PlayList.Values)
				{
					if (value.Client != null)
					{
						if (value.Client.Running)
						{
							value.Client.Send(data, length);
						}
					}
					else
					{
						value.Client.Dispose();
						PlayList.Remove(value.人物全服ID);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "NPC广播数据2 出错2：" + ex);
			}
		}

		public static void 发送当前显示的讨伐副本怪物(ConcurrentDictionary<int, NpcClass> NpcList, Players player)
		{
			if (NpcList == null || NpcList.Count <= 0)
			{
				return;
			}
			foreach (NpcClass value in NpcList.Values)
			{
				if (value.FLD_PID == 16555 || value.FLD_PID == 16556)
				{
					continue;
				}
				if (value.NPC死亡)
				{
					byte[] array = Converter.hexStringToByte("AA5536008E47012230008E4700000000000000000000000001000000A0400000000000004442000000000000000000000000000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(value.FLD_INDEX), 0, array, 4, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.FLD_INDEX), 0, array, 10, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.X), 0, array, 26, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.Y), 0, array, 34, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.怪物数字), 0, array, 46, 4);
					if (player.Client != null)
					{
						player.Client.Send(array, array.Length);
					}
				}
				else
				{
					byte[] array2 = Converter.hexStringToByte("AA5526008E47052220008E47010000000000000034C20000000000006DC300000000000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(value.FLD_INDEX), 0, array2, 4, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.FLD_INDEX), 0, array2, 10, 2);
					Buffer.BlockCopy(BitConverter.GetBytes(value.X), 0, array2, 18, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.Y), 0, array2, 26, 4);
					if (player.Client != null)
					{
						player.Client.Send(array2, array2.Length);
					}
				}
			}
		}

		public void 地狱火龙副本状态效果()
		{
			Random random = new Random(DateTime.Now.Millisecond);
			int num = random.Next(1, 400);
			X = num - 200;
			num = random.Next(1, 400);
			Y = num - 400;
			byte[] array = Converter.hexStringToByte("AA5536008E47012230008E4700000000000000000000000001000000A0400000000000004442000000000000000000000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 10, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(X), 0, array, 26, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(Y), 0, array, 34, 4);
			if (FLD_PID == 16607 || FLD_PID == 16557)
			{
				num = random.Next(2, 5);
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, array, 46, 4);
				怪物数字 = num;
			}
			广播数据(array, array.Length);
			tem.Clear();
			NPC死亡 = true;
			if (自动攻击 != null)
			{
				自动攻击.Enabled = false;
			}
			if (自动移动 != null)
			{
				自动移动.Enabled = true;
			}
			if (自动复活 != null)
			{
				自动复活.Interval = FLD_NEWTIME * 1000;
				自动复活.Enabled = true;
			}
			else
			{
				自动复活 = new System.Timers.Timer(FLD_NEWTIME * 1000);
				自动复活.Elapsed += 自动复活事件;
				自动复活.Enabled = true;
			}
		}

		public void 地狱火龙副本状态效果消失(bool 是否玩家击杀)
		{
			NPC死亡 = false;
			byte[] array = Converter.hexStringToByte("AA5526008E47052220008E47010000000000000034C20000000000006DC300000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_INDEX), 0, array, 10, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(X), 0, array, 18, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(Y), 0, array, 26, 4);
			广播数据(array, array.Length);
			if (自动复活 != null)
			{
				自动复活.Enabled = false;
				自动复活.Close();
				自动复活.Dispose();
				自动复活 = null;
			}
			if (!是否玩家击杀)
			{
				讨伐副本怪物秒人();
			}
		}

		public void 讨伐副本怪物秒人()
		{
			switch (FLD_PID)
			{
			case 16557:
			{
				List<Players> list = new List<Players>();
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.人物坐标_地图 == 43001 && World.是否讨伐副本危险区域(value) && !value.Player死亡 && value.副本复活剩余次数 > 0)
					{
						list.Add(value);
					}
				}
				if (list.Count <= 0)
				{
					break;
				}
				for (int i = 0; i < 怪物数字; i++)
				{
					Random random = new Random(DateTime.Now.Millisecond);
					int index = random.Next(0, list.Count - 1);
					Players players = list[index];
					players.人物_HP = 0;
					players.死亡2();
					PlayCw = null;
					Play_null();
					players.更新HP_MP_SP();
					list.Remove(players);
					if (list.Count == 0)
					{
						break;
					}
				}
				break;
			}
			case 16600:
				foreach (Players value2 in World.AllConnectedPlayers.Values)
				{
					if (!查找范围玩家(100, value2) && World.是否讨伐副本危险区域(value2) && value2.副本复活剩余次数 > 0)
					{
						value2.人物_HP = 0;
						value2.死亡2();
						PlayCw = null;
						Play_null();
						value2.更新HP_MP_SP();
					}
				}
				break;
			case 16602:
				foreach (Players value3 in World.AllConnectedPlayers.Values)
				{
					if (查找范围玩家(100, value3) && value3.副本复活剩余次数 > 0)
					{
						value3.人物_HP = 0;
						value3.死亡2();
						PlayCw = null;
						Play_null();
						value3.更新HP_MP_SP();
					}
				}
				break;
			case 16604:
				foreach (Players value4 in World.AllConnectedPlayers.Values)
				{
					if (查找范围玩家(80, value4) && value4.副本复活剩余次数 > 0)
					{
						value4.人物_HP = 0;
						value4.死亡2();
						PlayCw = null;
						Play_null();
						value4.更新HP_MP_SP();
					}
				}
				break;
			case 16607:
				if (NPC死亡)
				{
					break;
				}
				foreach (Players value5 in World.AllConnectedPlayers.Values)
				{
					if (World.是否讨伐副本危险区域(value5) && !value5.Player死亡 && value5.副本复活剩余次数 > 0)
					{
						value5.人物_HP = 0;
						value5.死亡2();
						PlayCw = null;
						Play_null();
						value5.更新HP_MP_SP();
					}
				}
				break;
			}
		}

		public static void 更新NPC复活数据(ConcurrentDictionary<int, NpcClass> NpcList, Players Playe)
		{
			if (NpcList == null || NpcList.Count <= 0)
			{
				return;
			}
			foreach (NpcClass value in NpcList.Values)
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write4(1);
				发包类.Write4(value.FLD_INDEX);
				发包类.Write4(value.FLD_INDEX);
				发包类.Write2(value.FLD_PID);
				发包类.Write2(1);
				发包类.Write4(value.Rxjh_HP);
				发包类.Write4(value.Max_Rxjh_HP);
				发包类.Write(value.X);
				发包类.Write(value.Z);
				发包类.Write(value.Y);
				发包类.Write(4f);
				发包类.Write(value.FLD_FACE1);
				发包类.Write(value.FLD_FACE2);
				发包类.Write(value.X);
				发包类.Write(value.Z);
				发包类.Write(value.Y);
				发包类.Write4(0);
				发包类.Write4(128369664);
				发包类.Write4(0);
				发包类.Write4(215040);
				发包类.Write4(0);
				发包类.Write4(786432);
				发包类.Write4(uint.MaxValue);
				if (Playe.Client != null)
				{
					Playe.Client.SendPak(发包类, 31488, value.FLD_INDEX);
				}
			}
		}
	}
}
