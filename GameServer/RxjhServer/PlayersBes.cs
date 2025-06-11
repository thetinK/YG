using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Timers;
using RxjhServer.DbClss;
using RxjhServer.HelperTools;
using RxjhServer.Network;

namespace RxjhServer
{
	public class PlayersBes : 气功属性
	{
		public bool 打坐刷新移动;

		public int 是否轻功 = 0;

		public int 离线打架攻击人物;

		public int 假人势力战失去人物全服ID;

		public bool 是否解除击杀自动保护 = false;

		public int 离线挂机当前攻击怪物 = 0;

		public int 离线打怪是否有怪打 = 0;

		public int 假人发呆超时计时器;

		public bool 是假人 = false;

		public int 离线自动打怪;

		public int 假人是否参与世界排行boss;

		public int 假人是否参与势力战;

		public int 假人势力战反击index;

		public int 假人移动出错纠正;

		public int 假人被人物击杀多次开启安全模式;

		public int 假人结婚是否成败;

		public int 离线假人卡技能次数;

		public int 假人boss排行是否发呆;

		public int 假人反击PKindex;

		public int 假人反击PK发呆;

		public float 假人组队坐标X = 0f;

		public float 假人组队坐标Y = 0f;

		public int 假人组队坐标地图 = 0;

		public int 假人是否获得过武勋;

		public int 假人死亡次数;

		public int 自动拾取物品;

		public float 假人本次目标X = 0f;

		public float 假人本次目标Y = 0f;

		public string 自动喊话 = "";

		public int 自动喊话开关;

		public DateTime 自动喊话时间;

		public int 自动回血开关;

		public int 自动出售物品;

		public int 加入帮派成败;

		public int 假人反击怪index = 0;

		public int 藏宝图杀怪数量 = 0;

		public System.Timers.Timer 假人离线PK = new System.Timers.Timer(2500.0);

		public System.Timers.Timer 假人离线挂机 = new System.Timers.Timer(2500.0);

		public System.Timers.Timer 假人离线逛街挂机 = new System.Timers.Timer(8000.0);

		public System.Timers.Timer 假人功能计时器 = new System.Timers.Timer(6000.0);

		public System.Timers.Timer 假人离线反击PK = new System.Timers.Timer(1000.0);

		public DateTime 抢红包时间;

		public DateTime 自动得奖励时间;

		private int _FLD_PK积分;

		private int _FLD_积分;

		public int _个人荣誉战编号;

		public int 是否拒绝势力战;

		public int 离线打架武功ID;

		public int 江湖小助手武功ID;

		public int 离线挂机武功ID;

		public int 自动挂机坐标X;

		public int 自动挂机坐标Y;

		public int 自动挂机地图;

		public int 离线挂机打怪模式;

		public int 假人是否开商店;

		public int 江湖小助手打怪模式;

		public int 离线打架模式;

		public int 云挂机模式;

		public bool 云挂机踢号;

		public bool 死亡掉经验;

		public int 追加项链属性;

		public DateTime 在线挂机打怪时间;

		public DateTime 离线挂机打怪时间;

		public DateTime 自动存仓库时间;

		public DateTime 技能释放间隔;

		private DateTime dateTime_5;

		private int int_117;

		public string 自动说话 = string.Empty;

		private readonly object thisLock = new object();

		public List<Players> tem = new List<Players>();

		public List<int> 快捷栏 = new List<int>();

		public List<int> 得到门徽ID = new List<int>();

		public float Speed = 127f;

		public 武功类[,] 武功新 = new 武功类[4, 32];

		public int 行走状态id = 1;

		public int 称号积分;

		public System.Timers.Timer 查坐标 = new System.Timers.Timer(6000.0);

		public System.Timers.Timer 攻击器 = new System.Timers.Timer(100.0);

		public 攻击确认类 AtTimerElapsed;

		public int 武功计数器;

		private readonly byte[] 样式 = Converter.hexStringToByte("00000000030000000000FFFF0000FFFF");

		public double 拳师会心一击威力 = 0.3;

		public string 婚戒刻字 = string.Empty;

		public float 最大移动速度 = 100f;

		public int 证婚人提问答案 = 2;

		public int 是否拒绝仙魔大战;

		public string 游戏安全码 = string.Empty;

		public string 商店名 = string.Empty;

		private string _userid = string.Empty;

		private string _password = string.Empty;

		private string _lastloginip = string.Empty;

		private string _zastcoginip = string.Empty;

		private string _绑定帐号 = string.Empty;

		private string _UserName = string.Empty;

		private string _传书杀人名 = string.Empty;

		private string _帮派名字 = string.Empty;

		private string _FLD_临时师徒 = string.Empty;

		private bool _可结成师徒关系状态 = true;

		public string _仙魔大战派别 = string.Empty;

		public string 客户端设置 = string.Empty;

		public byte[] 移动封包 = new byte[52];

		public ConcurrentDictionary<int, ServerList> SerList;

		public System.Timers.Timer 无敌时间计数器;

		public System.Timers.Timer 移动地图计时器;

		public System.Timers.Timer 障力恢复时间计数器;

		public bool 刺客发起技能加成;

		public double 刺客物理攻击加成;

		public double 刺客魔法攻击加成;

		public double 升天气功武功等级;

		public bool 是否更新配置;

		public int 设置固定伤害;

		public bool 上线;

		public bool 存档时间;

		public ConfigClass Config;

		public bool PK死亡;

		public bool Player无敌;

		public bool 打开商店中;

		public bool 打开交易;

		public bool 打开个人商店;

		public bool 退出中;

		public bool 进店中;

		public bool 妖花青草;

		public int 进店中ID;

		public int IsRanked;

		public bool 打开仓库中;

		public ConcurrentDictionary<int, 个人传书类> 传书列表;

		private NetState _Client;

		public bool FLD_是否可以送花;

		public int _当前操作NPC;

		public int 凝神宝珠位置;

		public int 心跳次数阀值;

		public int 表情次数阀值;

		public int 报错次数阀值;

		public int 死亡不复活计时;

		public bool 打坐;

		public bool 打坐打怪;

		public int PVP分数;

		public int PVP逃跑次数;

		public ConcurrentDictionary<int, 公有药品类> 符列表;

		public int _当前操作类型;

		public ConcurrentDictionary<int, string> allChars;

		public 坐标Class 新坐标;

		public 灵兽类 人物灵兽;

		public ThreadSafeDictionary<int, NpcClass> NpcList;

		public ThreadSafeDictionary<double, 地面物品类> 地面物品列表;

		public Hashtable 土灵符坐标;

		public ThreadSafeDictionary<int, 追加状态类> 追加状态列表;

		public ThreadSafeDictionary<int, 追加状态New类> 追加状态New列表;

		public ThreadSafeDictionary<int, 异常状态类> 异常状态;

		public ThreadSafeDictionary<int, 神女异常状态类> 神女异常状态;

		public ConcurrentDictionary<int, 时间药品类> 时间药品;

		public ConcurrentDictionary<int, 特殊药品类> 特殊药品;

		public ThreadSafeDictionary<int, NpcClass> 怪物攻击列表;

		public bool 怒;

		public List<攻击类> 攻击列表;

		public List<int> 玉连环;

		public List<武功类> 新武功连击;

		public SortedDictionary<int, 升天气功类> 升天气功;

		public 个人商店类 个人商店;

		public int 武功连击记数器;

		public int 装备数据版本;

		public int 综合仓库装备数据版本;

		public 物品类[] 个人仓库;

		public 物品类[] 公共仓库;

		public 物品类[] 灵宠仓库;

		public 物品类[] 灵兽仓库;

		public 物品类[] 装备栏包裹;

		public 物品类[] 披风行囊;

		public 物品类[] 凝神珠包裹;

		public 物品类[] 行囊包裹;

		public 物品类[] 杂货行囊包裹;

		public 物品类[] 装备栏已穿装备;

		public 物品类[] 辅助装备栏装备;

		public 物品类[] 宝珠装备栏装备;

		public 气功类[] 气功;

		public 任务物品类[] 任务物品;

		public ConcurrentDictionary<int, 任务类> 任务;

		public ConcurrentDictionary<int, int> 已完成任务;

		public 师徒类 师傅数据;

		public 师徒类[] 徒弟数据;

		public double 当前移动距离;

		public float 目标坐标X;

		public float 目标坐标Y;

		public float 目标坐标Z;

		public double 人物距离计算;

		public bool 触发杀星义气虎;

		public bool 触发杀星义气杀;

		public bool 触发绝影射魂;

		public bool 触发缩影步;

		public bool 触发天地回流;

		public bool 触发神女传染;

		public bool 神女怒;

		public float destX;

		public float destY;

		public float destZ;

		public float fromX;

		public float fromY;

		public float fromZ;

		public float reach;

		public 交易类 交易;

		public int GM模式;

		public int 组队id;

		public int 组队阶段;

		public int 潜行模式;

		public int 任务次数;

		public double 刺_连消带打数量;

		public double 韩飞官_天魔狂血攻击力;

		public int 韩飞官_天魔狂血叠加次数;

		public byte[] 个人药品;

		public byte[] 追加状态物品New;

		public double 爆毒状态;

		public int 隐身状态id;

		public int 关起来;

		public int 安全模式;

		public int 升天历练当前获得数;

		public int 升天历练数;

		public int 升天武功点数;

		public int 神女武功点数;

		public bool 跑走;

		public int 修炼地图剩余时间;

		public int 活动地图剩余时间;

		public int 天地同寿回避次数;

		public int 天地同寿回避累积攻击力;

		public DateTime FBtime;

		public DateTime PKhmtime;

		public DateTime SThmtime;

		public DateTime XThmtime;

		public DateTime CWhmtime;

		public DateTime TMJCtime;

		public DateTime WXhmtime;

		public DateTime JYhmtime;

		public DateTime CJhmtime;

		public DateTime BWYBhmtime;

		public int 丢失武勋;

		public int 装备追加对怪攻击;

		public int 装备追加对怪防御;

		public int 强化追加对怪攻击;

		public int 强化追加对怪防御;

		public int 药品追加对怪攻击;

		public int 飞行模式;

		public int 变身id;

		public int 当前杀怪数量;

		public int 药品追加对怪防御;

		public int FLD_药品_追加_气功;

		public int 每日获得武勋;

		public int 最大精力;

		public int _恢复精力;

		public int 武皇通币;

		public int 拳师连击控制;

		public int 锁定人物几率;

		public bool 人物锁定;

		public float AttackX;

		public float AttackY;

		public int 攻击次数;

		public float lastX;

		public float lastY;

		public int lastMAP;

		public bool 中毒;

		public double 宠物对怪物伤害;

		public bool 是否携带披风行囊;

		public int 解除关系倒计时;

		public int 是否已婚;

		public int 安全码操作ID;

		public bool 安全码是否通过验证;

		public int 交易人物ID;

		public int 交易操作ID;

		public bool 触发地图移动事件;

		public bool 触发鸾凤和鸣;

		public int 触发属性提升;

		public bool 触发流星漫天;

		public bool 万毒不侵;

		public bool 夫妻组队中;

		public int 玫瑰称号积分;

		public int 行走状态id1;

		public int 门派称号类型;

		public int 称号排名;

		public string _人物分区ID;

		private int _夫妻武功攻击力;

		public int _夫妻武功攻击力MP;

		public int _人物封包ID;

		private string _原服务器IP;

		private int _原服务器端口;

		private int _原服务器序号;

		private int _原服务器ID;

		private string _银币广场服务器IP;

		private int _银币广场服务器端口;

		private int _人物位置;

		private int _人物轻功;

		private int _琴师状态;

		private int _当前激活技能ID;

		private bool _弓群攻触发心神;

		private int _仙魔大战杀人数;

		private int _仙魔大战死亡数;

		private int _帮派Id;

		private int _帮派等级;

		private int _帮派人物等级;

		private int _帮派门服字;

		private byte[] _帮派门徽;

		private int _帮派门服颜色;

		private int _人物历练;

		private long _人物经验;

		private long _人物最大经验;

		private long _人物钱数;

		private int _上河调计数;

		private int _下河调计数;

		private int _玉连环计数;

		private int _人物_HP;

		private int _人物_WX_BUFF_生命;

		private int _人物_WX_BUFF_攻击;

		private int _人物_WX_BUFF_防御;

		private int _人物_WX_BUFF_回避;

		private int _人物_WX_BUFF_内功;

		private int _人物_WX_BUFF_命中;

		private int _人物_WX_BUFF_气功;

		private int _人物_气功_追加_HP;

		private int _人物_气功_追加_武功防御力;

		private int _人物基本最大_HP;

		private int _人物追加最大_HP;

		private int _人物_MP;

		private int _人物_AP;

		private int _人物基本最大_MP;

		private int _人物追加最大_MP;

		private int _人物_气功_追加_MP;

		private double _人物_气功_追加_百分比MP;

		private int _人物基本最大_障力;

		private int _人物_SP;

		private int _人物最大_SP;

		private int _人物没加气功点;

		private int _人物正邪;

		private string _人物IP;

		private int _势力杀人;

		private int _势力死亡;

		private int _人物等级;

		private int _人物武勋;

		private double _比武追加经验值;

		private int _杀人次数;

		private int _被杀次数;

		public int BOSS累计伤害;

		public int _深渊BOSS累计伤害;

		public int _累计伤害 = 0;

		private int _武勋阶段;

		private int _人物善恶;

		private int _人物职业;

		private int _是否假人;

		private int _账号是否假人;

		private int _人物职业等级;

		public 人物模板类 New人物模版;

		private byte[] _人物名字模版;

		private int _人物性别;

		private float _人物坐标_X;

		private float _人物坐标_Y;

		private float _人物坐标_Z;

		private int _人物坐标_地图;

		private int _人物当前负重;

		private int _人物负重总;

		private int _人物PK模式;

		public double _狂意护体加成;

		private long _个人仓库钱数;

		private long _综合仓库钱数;

		private int _FLD_RXPIONT;

		private int _FLD_RXPIONTX;

		private int _FLD_Coin;

		private int _首充次数;

		private int _FLD_推广ID;

		private string _FLD_SPREADERID = string.Empty;

		private int _FLD_ZJF;

		private int _FLD_SPREADER_LEVEL;

		public ConcurrentDictionary<int, 公有药品类> 公有药品;

		public ConcurrentDictionary<int, 称号药品类> 称号药品;

		private int _抽奖次数;

		private int _FLD_VIP;

		private DateTime _FLD_VIPTIM;

		private DateTime _FLD_QDVIPTIM;

		private DateTime _FLD_精力时间;

		private DateTime _FLD_MBVIPTIM;

		private int _FLD_攻击速度;

		private int _FLD_制作类型;

		private int _FLD_制作等级;

		private int _FLD_制作熟练度;

		private string _FLD_情侣;

		private int _FLD_情侣_爱情度;

		private DateTime _解除师徒关系时间;

		public int 中级附魂_复仇;

		public int 中级附魂_吸魂;

		public int 中级附魂_奇缘;

		public int 中级附魂_愤怒;

		public int 中级附魂_移星;

		public int 中级附魂_护体;

		public int 中级附魂_混元;

		public int _FLD_荣誉ID;

		public int _武林荣誉ID_;

		public bool _Player死亡;

		private int _FLD_PVP_Piont;

		private bool _元宝账户状态;

		private bool _是否押注;

		private int _押注专场代码;

		private string _押注单双;

		private double _FLD_追加百分比_攻击;

		private double _FLD_追加百分比_防御;

		private double _FLD_追加百分比_命中;

		private double _FLD_人物_追加百分比_回避;

		private double _FLD_追加百分比_HP上限;

		private double _FLD_追加百分比_MP上限;

		private int _FLD_心;

		private int _FLD_体;

		private int _FLD_力;

		private int _FLD_身;

		private int _FLD_攻击;

		private double _最小攻击;

		private int _FLD_最大攻击;

		private int _FLD_命中;

		private int _FLD_防御;

		private int _FLD_回避;

		private DateTime _FLD_结婚纪念日;

		private double _FLD_人物_气功_攻击;

		private int _FLD_人物_气功_命中;

		private int _FLD_人物_气功_防御;

		private int _FLD_人物_气功_负重;

		private int _FLD_人物_气功_回避;

		private double _FLD_人物_武功攻击力增加百分比;

		private double _FLD_人物_武功防御力增加百分比;

		private double _FLD_人物_气功_武功攻击力增加百分比;

		private double _FLD_人物_气功_武功防御力增加百分比;

		private int _FLD_人物_追加_攻击;

		private int _FLD_人物_追加_防御;

		private int _FLD_人物_追加_命中;

		private int _FLD_人物_追加_回避;

		private int _FLD_人物_追加_气功;

		private int _八彩_追加_攻击;

		private int _八彩_追加_防御;

		private double _FLD_人物_追加_经验百分比;

		private double _FLD_宠物_追加_经验百分比;

		private double _FLD_医生_追加_经验百分比;

		private int _FLD_医生_追加_爆率;

		private double _FLD_人物_追加_历练百分比;

		private double _FLD_人物_追加_合成成功率百分比;

		private int _FLD_夫妻辅助_追加_防具_属性;

		private int _FLD_夫妻辅助_追加_武器_属性;

		private int _FLD_结婚礼物_追加_属性石;

		private int _FLD_宠物_追加_最大HP;

		private int _FLD_宠物_追加_攻击;

		private int _FLD_宠物_追加_防御;

		private double _FLD_人物_追加_贩卖价格百分比;

		private double _FLD_人物_追加_武勋获得量百分比;

		private double _FLD_人物_追加_吸魂几率百分比;

		private double _FLD_人物_追加_获得游戏币百分比;

		private double _FLD_人物_追加_物品掉落概率百分比;

		private double _FLD_装备_追加_合成成功率百分比;

		private double _FLD_装备_追加_获得游戏币百分比;

		private double _FLD_装备_武功攻击力增加百分比;

		private double _FLD_装备_武功防御力;

		private double _FLD_装备_武功防御力增加百分比;

		private int _FLD_装备_追加_攻击;

		private int _FLD_装备_追加_攻击New;

		private int _FLD_装备_追加_防御;

		private int _FLD_装备_追加_战斗力;

		private int _FLD_装备_追加_武器_强化;

		private int _FLD_装备_追加_防具_强化;

		private int _FLD_装备_追加_命中;

		private double _FLD_装备_追加_降低百分比攻击;

		private double _FLD_装备_追加_降低百分比防御;

		private double _武勋降低百分比防御;

		private int _FLD_项链_追加_防具_强化;

		private int _FLD_项链_追加_武器_强化;

		private double _FLD_装备_追加_命中百分比;

		private int _FLD_装备_追加_愤怒;

		private double _FLD_装备_追加_回避百分比;

		private double _FLD_装备_降低_伤害值;

		private int _FLD_装备_追加_伤害值;

		private double _FLD_装备_追加_初始化愤怒概率百分比;

		private double _FLD_装备_追加_中毒概率百分比;

		private int _FLD_装备_追加_回避;

		private int _FLD_装备_追加_气功;

		private double _FLD_装备_追加_经验百分比;

		private double _LS_降低_暴率百分比;

		private double _LS_降低_经验百分比;

		private double _LS_降低_金钱百分比;

		private double _LS_降低_历练百分比;

		private double _FLD_装备_追加_死亡损失经验减少;

		private double _FLD_装备_追加_气功_0;

		private double _FLD_装备_追加_气功_1;

		private double _FLD_装备_追加_气功_2;

		private double _FLD_装备_追加_气功_3;

		private double _FLD_装备_追加_气功_4;

		private double _FLD_装备_追加_气功_5;

		private double _FLD_装备_追加_气功_6;

		private double _FLD_装备_追加_气功_7;

		private double _FLD_装备_追加_气功_8;

		private double _FLD_装备_追加_气功_9;

		private double _FLD_装备_追加_气功_10;

		private double _FLD_装备_追加_气功_11;

		private int _FLD_装备_追加_HP;

		private int _FLD_装备_隐藏_HP;

		private int _FLD_装备_隐藏_DF;

		private int _FLD_装备_隐藏_AT;

		private int _FLD_装备_追加_障力恢复量;

		private int _FLD_装备_追加_MP;

		private int _FLD_装备_追加_障力;

		private double _FLD_装备_追加_升天一遁出逆境;

		private double _FLD_装备_追加_升天一破甲刺魂;

		private double _FLD_装备_追加_升天一绝影射魂;

		private double _FLD_装备_追加_升天三怒意之火;

		private double _FLD_装备_追加_升天一夜魔缠身;

		private double _FLD_装备_追加_升天一力劈华山;

		private double _FLD_装备_追加_升天一长虹贯日;

		private double _FLD_装备_追加_升天一金钟罡气;

		private double _FLD_装备_追加_升天一运气行心;

		private double _FLD_装备_追加_升天一正本培源;

		private double _FLD_装备_追加_升天一运气疗伤;

		private double _FLD_装备_追加_升天一百变神行;

		private double _FLD_装备_追加_升天一狂风天意;

		private double _FLD_装备_追加_升天一飞花点翠;

		private double _FLD_装备_追加_升天一行风弄舞;

		private double _FLD_装备_追加_升天二穷途末路;

		private double _FLD_装备_追加_升天三火龙之火;

		private double _FLD_装备_追加_升天二天地同寿;

		private double _FLD_装备_追加_升天一护身罡气;

		private double _FLD_装备_追加_升天二以退为进;

		private double _FLD_装备_追加_升天二千钧压驼;

		private double _FLD_装备_追加_升天二顺水推舟;

		private double _FLD_装备_追加_升天二三潭映月;

		private double _FLD_装备_追加_升天二天魔护体;

		private double _FLD_装备_追加_升天二万物回春;

		private double _FLD_装备_追加_升天一护身气甲;

		private double _FLD_装备_追加_升天三火凤临朝;

		private double _FLD_装备_追加_升天三天外三矢;

		private double _FLD_装备_追加_升天三无情打击;

		private double _FLD_装备_追加_升天三明镜止水;

		private double _FLD_装备_追加_升天三子夜秋歌;

		private double _FLD_装备_追加_升天三内息行心;

		private double _FLD_装备_追加_升天三以柔克刚;

		private double _FLD_装备_追加_升天四红月狂风;

		private double _FLD_装备_追加_升天四毒蛇出洞;

		private double _FLD_装备_追加_升天四满月狂风;

		private double _FLD_装备_追加_升天四烈日炎炎;

		private double _FLD_装备_追加_升天四长虹贯天;

		private double _FLD_装备_追加_升天四哀鸿遍野;

		private double _FLD_装备_追加_升天一夺命连环;

		private double _FLD_装备_追加_升天一电光石火;

		private double _FLD_装备_追加_升天一精益求精;

		private double _FLD_装备_追加_升天四望梅添花;

		private double _FLD_装备_追加_升天四悬丝诊脉;

		private double _FLD_装备_追加_升天五惊天动地;

		private double _FLD_装备_追加_升天一玄武雷电;

		private double _FLD_装备_追加_升天一陵劲淬砺;

		private double _FLD_装备_追加_升天一愤怒调节;

		private double _FLD_装备_追加_升天二玄武诅咒;

		private double _FLD_装备_追加_升天二杀星光符;

		private double _FLD_装备_追加_升天二蛊毒解除;

		private double _FLD_装备_追加_升天三杀人鬼;

		private double _FLD_装备_追加_升天三技冠群雄;

		private double _FLD_装备_追加_升天三神力保护;

		private double _FLD_装备_追加_升天五致残;

		private double _FLD_装备_追加_升天五龙魂附体;

		private double _FLD_装备_追加_升天五灭世狂舞;

		private double _FLD_装备_追加_升天五千里一击;

		private double _FLD_装备_追加_升天五形移妖相;

		private double _FLD_装备_追加_升天五一招杀神;

		private double _FLD_装备_追加_升天五龙爪纤指手;

		private double _FLD_装备_追加_升天五不死之躯;

		private double _FLD_装备_追加_升天五天魔之力;

		private double _FLD_装备_追加_升天五惊涛骇浪;

		private double _FLD_装备_追加_升天五魔魂之力;

		private double _FLD_装备_追加_升天五破空坠星;

		private double _FLD_装备_追加_升天五尸毒爆发;

		private int _FLD_装备_追加_心;

		private int _FLD_装备_追加_体;

		private int _FLD_装备_追加_力;

		private int _FLD_装备_追加_身;

		private int _FLD_装备_追加_觉醒;

		public int 武器攻击力;

		public double 武器武功攻击力百分比;

		public int 衣服防御力;

		public double 衣服武功防御力百分比;

		public int FLD_爱情度等级;

		public int _门派贡献度;

		private int _武皇通币;

		public string _FLD_情侣戒指;

		public double _FLD_药品_减少攻击;

		public double _FLD_药品_减少防御;

		public int _玫瑰称号追加HP;

		public int _玫瑰称号追加防御;

		public int _玫瑰称号追加攻击;

		public int _花榜追加HP;

		public int _花榜追加防御;

		public int _花榜追加攻击;

		public int _乱斗追加HP;

		public int _VIP称号增加生命;

		public int _乱斗追加防御;

		public int _乱斗追加攻击;

		public int _前十追加HP;

		public int _前十追加防御;

		public int _VIP称号增加防御;

		public int _VIP称号增加攻击;

		public int _前十追加攻击;

		public int _FLD_消耗_追加_防御;

		public int _FLD_消耗_追加_攻击;

		public int _FLD_消耗_追加_气功;

		public int _FLD_消耗_追加_血;

		private double _FLD_消耗_追加_经验百分比;

		private int _FLD_杀人_追加_防御;

		private int _FLD_杀人_追加_攻击;

		private int _FLD_杀人_追加_血;

		public int _门派称号追加HP;

		public int _门派称号追加防御;

		public int _门派称号追加攻击;

		public int _称号追加HP;

		public int _称号追加防御;

		public int _称号追加攻击;

		public int _人物追加战力;

		public int _人物追加武勋战力;

		public int _称号追加战斗力;

		public int _玫瑰追加战斗力;

		public int _前十追加战斗力;

		public double _FLD_追加哀鸿片野_HP上限;

		public int _FLD_最小攻击;

		public double _FLD_人物_追加_武功防御力;

		public double _FLD_灵宠_追加_经验百分比;

		public double _FLD_灵宠_追加_历练百分比;

		public int _FLD_装备_追加_武功命中;

		public int _武器追加百分比;

		public int _防具追加百分比;

		public int _FLD_装备_追加_武功负重;

		public int _FLD_装备_追加_武功回避;

		public int _减免对方伤害;

		public int _药品减免对方伤害;

		public int _FLD_装备_增加异常;

		public int _FLD_装备_增加对方异常;

		public int 药品_追加_首饰_强化;

		public bool 触发弓箭致命绝杀;

		public bool 触发魔法无明暗矢;

		public bool 触发物理无明暗矢;

		public int _武林杀人数;

		public int _人物_战斗增加_HP;

		public int _人物_战斗增加_MP;

		public int _FLD_神女_追加_攻击;

		public int _FLD_神女_追加_防御;

		public string _门派联盟盟主;

		private int _宣告攻城;

		private int _讨伐次数;

		private int _讨伐累计伤害;

		private int _元宝消费;

		private int _元宝消费2;

		private int _钻石消费;

		private int _元宝充值;

		private int _钻石充值;

		private int _账号锁定;

		private int _累计充值;

		private int _转生_追加_攻击;

		private int _转生_追加_防御;

		private int _转生_追加_生命;

		private int _转生次数;

		private int _页码;

		private int _操作ID;

		private int _操作类型;

		public int 最终致命一击;

		private int _FLD_装备_追加_罡气;

		public DateTime 扣钱1间隔;

		public DateTime 扣钱2间隔;

		public DateTime 扣钱3间隔;

		public DateTime 扣钱4间隔;

		public DateTime 扣钱5间隔;

		public DateTime 扣元1间隔;

		public DateTime 扣元2间隔;

		public DateTime 扣元3间隔;

		public DateTime 扣元4间隔;

		public DateTime 扣元5间隔;

		private int _燃烧类型阶段;

		public int 门派胜 { get; set; }

		public int 门派败 { get; set; }

		public int 门派平 { get; set; }

		public int FLD_JF { get; set; }

		public int 每日势力ZX { get; set; }

		public string 势力战派别 { get; set; }

		public int 燃烧类型阶段
		{
			get
			{
				return _燃烧类型阶段;
			}
			set
			{
				_燃烧类型阶段 = value;
			}
		}

		public int 操作页码
		{
			get
			{
				return _页码;
			}
			set
			{
				_页码 = value;
			}
		}

		public int 操作类型
		{
			get
			{
				return _操作类型;
			}
			set
			{
				_操作类型 = value;
			}
		}

		public int 操作ID
		{
			get
			{
				return _操作ID;
			}
			set
			{
				_操作ID = value;
			}
		}

		public int 转生_追加_防御
		{
			get
			{
				return _转生_追加_防御;
			}
			set
			{
				_转生_追加_防御 = value;
			}
		}

		public int 转生_追加_攻击
		{
			get
			{
				return _转生_追加_攻击;
			}
			set
			{
				_转生_追加_攻击 = value;
			}
		}

		public int 转生_追加_生命
		{
			get
			{
				return _转生_追加_生命;
			}
			set
			{
				_转生_追加_生命 = value;
			}
		}

		public int 转生次数
		{
			get
			{
				return _转生次数;
			}
			set
			{
				_转生次数 = value;
			}
		}

		public int 副本剩余次数
		{
			get
			{
				return _讨伐次数;
			}
			set
			{
				_讨伐次数 = value;
			}
		}

		public int 恢复精力
		{
			get
			{
				return _恢复精力;
			}
			set
			{
				_恢复精力 = value;
			}
		}

		public int 讨伐累计伤害
		{
			get
			{
				return _讨伐累计伤害;
			}
			set
			{
				_讨伐累计伤害 = value;
			}
		}

		public int 深渊BOSS累计伤害
		{
			get
			{
				return _深渊BOSS累计伤害;
			}
			set
			{
				_深渊BOSS累计伤害 = value;
			}
		}

		public int FLD_QCVIP
		{
			get
			{
				return int_117;
			}
			set
			{
				int_117 = value;
			}
		}

		public DateTime FLD_QCVIPTIM
		{
			get
			{
				return dateTime_5;
			}
			set
			{
				dateTime_5 = value;
			}
		}

		public int 宣告攻城
		{
			get
			{
				return _宣告攻城;
			}
			set
			{
				_宣告攻城 = value;
			}
		}

		public string 门派联盟盟主
		{
			get
			{
				return _门派联盟盟主;
			}
			set
			{
				_门派联盟盟主 = value;
			}
		}

		public string 人物分区ID
		{
			get
			{
				return _人物分区ID;
			}
			set
			{
				_人物分区ID = value;
			}
		}

		public int 门派贡献度
		{
			get
			{
				return _门派贡献度;
			}
			set
			{
				_门派贡献度 = value;
			}
		}

		public int Player_Whtb
		{
			get
			{
				return _武皇通币;
			}
			set
			{
				if (value < 0)
				{
					_武皇通币 = 0;
				}
				else
				{
					_武皇通币 = value;
				}
			}
		}

		public int 当前操作NPC
		{
			get
			{
				return _当前操作NPC;
			}
			set
			{
				_当前操作NPC = value;
			}
		}

		public int 当前操作类型
		{
			get
			{
				return _当前操作类型;
			}
			set
			{
				_当前操作类型 = value;
			}
		}

		public NetState Client
		{
			get
			{
				return _Client;
			}
			set
			{
				_Client = value;
			}
		}

		public int 夫妻武功攻击力
		{
			get
			{
				return (!夫妻组队中) ? _夫妻武功攻击力 : ((int)((double)_夫妻武功攻击力 + (double)_夫妻武功攻击力 * 0.1));
			}
			set
			{
				_夫妻武功攻击力 = value;
			}
		}

		public int 夫妻武功攻击力MP
		{
			get
			{
				return (!夫妻组队中) ? _夫妻武功攻击力MP : ((int)((double)_夫妻武功攻击力MP + (double)_夫妻武功攻击力MP * 0.1));
			}
			set
			{
				_夫妻武功攻击力MP = value;
			}
		}

		public int AccumulatedDamage
		{
			get
			{
				return _累计伤害;
			}
			set
			{
				_累计伤害 = value;
			}
		}

		public int 人物灵兽全服ID => 人物全服ID * 3 + 40000;

		public int 人物位置
		{
			get
			{
				return _人物位置;
			}
			set
			{
				_人物位置 = value;
			}
		}

		public int 人物轻功
		{
			get
			{
				return _人物轻功;
			}
			set
			{
				_人物轻功 = value;
			}
		}

		public int 琴师状态
		{
			get
			{
				return _琴师状态;
			}
			set
			{
				_琴师状态 = value;
			}
		}

		public int 当前激活技能ID
		{
			get
			{
				return _当前激活技能ID;
			}
			set
			{
				_当前激活技能ID = value;
			}
		}

		public bool 弓群攻触发心神
		{
			get
			{
				return _弓群攻触发心神;
			}
			set
			{
				_弓群攻触发心神 = value;
			}
		}

		public string Userid
		{
			get
			{
				return _userid;
			}
			set
			{
				_userid = value;
			}
		}

		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
			}
		}

		public string lastloginip
		{
			get
			{
				return _lastloginip;
			}
			set
			{
				_lastloginip = value;
			}
		}

		public string zastcoginip
		{
			get
			{
				return _zastcoginip;
			}
			set
			{
				_zastcoginip = value;
			}
		}

		public string 绑定帐号
		{
			get
			{
				return _绑定帐号;
			}
			set
			{
				_绑定帐号 = value;
			}
		}

		public int 个人荣誉战编号
		{
			get
			{
				return _个人荣誉战编号;
			}
			set
			{
				_个人荣誉战编号 = value;
			}
		}

		public int 武林杀人数
		{
			get
			{
				return _武林杀人数;
			}
			set
			{
				_武林杀人数 = value;
			}
		}

		public int 仙魔大战杀人数
		{
			get
			{
				return _仙魔大战杀人数;
			}
			set
			{
				_仙魔大战杀人数 = value;
			}
		}

		public int 仙魔大战死亡数
		{
			get
			{
				return _仙魔大战死亡数;
			}
			set
			{
				_仙魔大战死亡数 = value;
			}
		}

		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				_UserName = value;
			}
		}

		public string 传书杀人名
		{
			get
			{
				return _传书杀人名;
			}
			set
			{
				_传书杀人名 = value;
			}
		}

		public int 帮派Id
		{
			get
			{
				return _帮派Id;
			}
			set
			{
				_帮派Id = value;
			}
		}

		public string 帮派名字
		{
			get
			{
				return _帮派名字;
			}
			set
			{
				_帮派名字 = value;
			}
		}

		public int 帮派等级
		{
			get
			{
				return _帮派等级;
			}
			set
			{
				_帮派等级 = value;
			}
		}

		public int 帮派人物等级
		{
			get
			{
				return _帮派人物等级;
			}
			set
			{
				_帮派人物等级 = value;
			}
		}

		public int 帮派门服字
		{
			get
			{
				return _帮派门服字;
			}
			set
			{
				_帮派门服字 = value;
			}
		}

		public byte[] 帮派门徽
		{
			get
			{
				return _帮派门徽;
			}
			set
			{
				_帮派门徽 = value;
			}
		}

		public int 帮派门服颜色
		{
			get
			{
				return _帮派门服颜色;
			}
			set
			{
				_帮派门服颜色 = value;
			}
		}

		public int Player_ExpErience
		{
			get
			{
				return _人物历练;
			}
			set
			{
				_人物历练 = value;
			}
		}

		public long 人物经验
		{
			get
			{
				return _人物经验;
			}
			set
			{
				_人物经验 = value;
			}
		}

		public long 人物最大经验
		{
			get
			{
				return _人物最大经验;
			}
			set
			{
				_人物最大经验 = value;
			}
		}

		public long Player_Money
		{
			get
			{
				return _人物钱数;
			}
			set
			{
				if (value < 0)
				{
					_人物钱数 = 0L;
				}
				else
				{
					_人物钱数 = value;
				}
			}
		}

		public int 上河调计数
		{
			get
			{
				return _上河调计数;
			}
			set
			{
				_上河调计数 = value;
			}
		}

		public int 下河调计数
		{
			get
			{
				return _下河调计数;
			}
			set
			{
				_下河调计数 = value;
			}
		}

		public int 玉连环计数
		{
			get
			{
				return _玉连环计数;
			}
			set
			{
				_玉连环计数 = value;
			}
		}

		public int 人物_HP
		{
			get
			{
				return _人物_HP;
			}
			set
			{
				_人物_HP = value;
			}
		}

		public int 人物_WX_BUFF_生命
		{
			get
			{
				return _人物_WX_BUFF_生命;
			}
			set
			{
				_人物_WX_BUFF_生命 = value;
			}
		}

		public int 人物_WX_BUFF_攻击
		{
			get
			{
				return _人物_WX_BUFF_攻击;
			}
			set
			{
				_人物_WX_BUFF_攻击 = value;
			}
		}

		public int 人物_WX_BUFF_防御
		{
			get
			{
				return _人物_WX_BUFF_防御;
			}
			set
			{
				_人物_WX_BUFF_防御 = value;
			}
		}

		public int 人物_WX_BUFF_回避
		{
			get
			{
				return _人物_WX_BUFF_回避;
			}
			set
			{
				_人物_WX_BUFF_回避 = value;
			}
		}

		public int 人物_WX_BUFF_内功
		{
			get
			{
				return _人物_WX_BUFF_内功;
			}
			set
			{
				_人物_WX_BUFF_内功 = value;
			}
		}

		public int 人物_WX_BUFF_命中
		{
			get
			{
				return _人物_WX_BUFF_命中;
			}
			set
			{
				_人物_WX_BUFF_命中 = value;
			}
		}

		public int 人物_WX_BUFF_气功
		{
			get
			{
				return _人物_WX_BUFF_气功;
			}
			set
			{
				_人物_WX_BUFF_气功 = value;
			}
		}

		public int FLD_人物基本_攻击
		{
			get
			{
				if (FLD_追加百分比_攻击 < 1E-05)
				{
					FLD_追加百分比_攻击 = 0.0;
				}
				double num = base.精金百炼 - base.减少攻击;
				if (num < 0.0)
				{
					num = 0.0;
				}
				return (int)(((double)(FLD_攻击 + FLD_装备_追加_攻击 + FLD_人物_追加_攻击) + FLD_人物_气功_攻击 + num) * (1.0 + FLD_追加百分比_攻击 + FLD_药品_减少攻击)) + 人物_WX_BUFF_攻击 + FLD_宠物_追加_攻击 + 称号追加攻击 + 玫瑰称号追加攻击 + 门派称号追加攻击 + 花榜追加攻击 + 前十追加攻击 + 转生_追加_攻击 + FLD_装备_隐藏_AT + 八彩_追加_攻击 + FLD_消耗_追加_攻击 + FLD_杀人_追加_攻击 + 乱斗追加攻击 + VIP称号增加攻击;
			}
		}

		public int FLD_人物基本_命中
		{
			get
			{
				if (FLD_追加百分比_命中 < 0.0001)
				{
					FLD_追加百分比_命中 = 0.0;
				}
				if (FLD_装备_追加_命中百分比 < 0.0001)
				{
					FLD_装备_追加_命中百分比 = 0.0;
				}
				return (int)((double)(FLD_命中 + FLD_装备_追加_命中 + FLD_人物_追加_命中 + FLD_人物_气功_命中) * (1.0 + FLD_追加百分比_命中 + FLD_装备_追加_命中百分比)) + 人物_WX_BUFF_命中;
			}
		}

		public int FLD_人物基本_防御
		{
			get
			{
				if (FLD_追加百分比_防御 < 0.0001)
				{
					FLD_追加百分比_防御 = 0.0;
				}
				return (int)((double)(FLD_防御 + FLD_装备_追加_防御 + FLD_人物_追加_防御 + 总罡气) * (1.0 + FLD_追加百分比_防御 + FLD_药品_减少防御)) + 人物_WX_BUFF_防御 + FLD_宠物_追加_防御 + FLD_人物_气功_防御 + 称号追加防御 + 玫瑰称号追加防御 + 门派称号追加防御 + 花榜追加防御 + 前十追加防御 + 转生_追加_防御 + FLD_装备_隐藏_DF + 八彩_追加_防御 + FLD_消耗_追加_防御 + FLD_杀人_追加_防御 + 乱斗追加防御 + VIP称号增加防御;
			}
		}

		public int FLD_人物基本_回避
		{
			get
			{
				if (FLD_人物_追加百分比_回避 < 0.0001)
				{
					FLD_人物_追加百分比_回避 = 0.0;
				}
				if (FLD_装备_追加_回避百分比 < 0.0001)
				{
					FLD_装备_追加_回避百分比 = 0.0;
				}
				return (int)((double)(FLD_回避 + FLD_装备_追加_回避 + FLD_人物_追加_回避 + FLD_人物_气功_回避) * (1.0 + FLD_人物_追加百分比_回避 + FLD_装备_追加_回避百分比)) + 人物_WX_BUFF_回避;
			}
		}

		public int 人物_战斗增加_HP
		{
			get
			{
				return _人物_战斗增加_HP;
			}
			set
			{
				_人物_战斗增加_HP = value;
			}
		}

		public int 人物_战斗增加_MP
		{
			get
			{
				return _人物_战斗增加_MP;
			}
			set
			{
				_人物_战斗增加_MP = value;
			}
		}

		public int 人物最大_HP
		{
			get
			{
				if (人物_战斗增加_HP > 0)
				{
					return 人物_战斗增加_HP;
				}
				return (int)((double)(人物基本最大_HP + FLD_装备_追加_HP + 人物_气功_追加_HP + 人物追加最大_HP) * (1.0 + FLD_追加百分比_HP上限 + FLD_追加哀鸿片野_HP上限)) + 人物_WX_BUFF_生命 + FLD_宠物_追加_最大HP + 称号追加HP + 玫瑰称号追加HP + 门派称号追加HP + 花榜追加HP + 前十追加HP + 转生_追加_生命 + FLD_装备_隐藏_HP + FLD_消耗_追加_血 + FLD_杀人_追加_血 + 乱斗追加HP + VIP称号增加生命;
			}
		}

		public int 人物最大_MP
		{
			get
			{
				if (人物_战斗增加_MP > 0)
				{
					return 人物_战斗增加_MP;
				}
				return (int)((double)(人物基本最大_MP + FLD_装备_追加_MP + 人物_气功_追加_MP + 人物追加最大_MP) * (1.0 + FLD_追加百分比_MP上限 + 人物_气功_追加_百分比MP)) + 人物_WX_BUFF_内功;
			}
		}

		public int 总罡气
		{
			get
			{
				double num = base.血气方刚 - base.减少罡气;
				if (num < 0.0)
				{
					num = 0.0;
				}
				return (int)((double)FLD_装备_追加_罡气 + base.乐师血脉上升 + num);
			}
		}

		public int 人物最大_AP => 人物基本最大_障力 + FLD_装备_追加_障力;

		public double 人物_追加_经验百分比 => FLD_人物_追加_经验百分比;

		public int 人物_气功_追加_HP
		{
			get
			{
				return _人物_气功_追加_HP;
			}
			set
			{
				_人物_气功_追加_HP = value;
			}
		}

		public int 人物_气功_追加_武功防御力
		{
			get
			{
				return _人物_气功_追加_武功防御力;
			}
			set
			{
				_人物_气功_追加_武功防御力 = value;
			}
		}

		public int 人物基本最大_HP
		{
			get
			{
				return _人物基本最大_HP;
			}
			set
			{
				_人物基本最大_HP = value;
			}
		}

		public int 人物追加最大_HP
		{
			get
			{
				return _人物追加最大_HP;
			}
			set
			{
				_人物追加最大_HP = value;
			}
		}

		public int FLD_杀人_追加_防御
		{
			get
			{
				return _FLD_杀人_追加_防御;
			}
			set
			{
				_FLD_杀人_追加_防御 = value;
			}
		}

		public int FLD_杀人_追加_攻击
		{
			get
			{
				return _FLD_杀人_追加_攻击;
			}
			set
			{
				_FLD_杀人_追加_攻击 = value;
			}
		}

		public int FLD_杀人_追加_血
		{
			get
			{
				return _FLD_杀人_追加_血;
			}
			set
			{
				_FLD_杀人_追加_血 = value;
			}
		}

		public int 人物_MP
		{
			get
			{
				return _人物_MP;
			}
			set
			{
				_人物_MP = value;
			}
		}

		public int 人物_AP
		{
			get
			{
				return _人物_AP;
			}
			set
			{
				_人物_AP = value;
			}
		}

		public int 人物基本最大_MP
		{
			get
			{
				return _人物基本最大_MP;
			}
			set
			{
				_人物基本最大_MP = value;
			}
		}

		public int 人物追加最大_MP
		{
			get
			{
				return _人物追加最大_MP;
			}
			set
			{
				_人物追加最大_MP = value;
			}
		}

		public int 人物_气功_追加_MP
		{
			get
			{
				return _人物_气功_追加_MP;
			}
			set
			{
				_人物_气功_追加_MP = value;
			}
		}

		public double 人物_气功_追加_百分比MP
		{
			get
			{
				return _人物_气功_追加_百分比MP;
			}
			set
			{
				_人物_气功_追加_百分比MP = value;
			}
		}

		public int 人物基本最大_障力
		{
			get
			{
				return _人物基本最大_障力;
			}
			set
			{
				_人物基本最大_障力 = value;
			}
		}

		public int 人物_SP
		{
			get
			{
				return _人物_SP;
			}
			set
			{
				_人物_SP = value;
			}
		}

		public int 人物最大_SP
		{
			get
			{
				return _人物最大_SP;
			}
			set
			{
				_人物最大_SP = value;
			}
		}

		public int Player_Qigong_point
		{
			get
			{
				return _人物没加气功点;
			}
			set
			{
				_人物没加气功点 = value;
			}
		}

		public int Player_Zx
		{
			get
			{
				return _人物正邪;
			}
			set
			{
				_人物正邪 = value;
			}
		}

		public string UserNip
		{
			get
			{
				return _人物IP;
			}
			set
			{
				_人物IP = value;
			}
		}

		public int 势力战杀人数
		{
			get
			{
				return _势力杀人;
			}
			set
			{
				_势力杀人 = value;
			}
		}

		public int 势力战死亡数
		{
			get
			{
				return _势力死亡;
			}
			set
			{
				_势力死亡 = value;
			}
		}

		public int Player_Level
		{
			get
			{
				return _人物等级;
			}
			set
			{
				_人物等级 = value;
			}
		}

		public int Player_WuXun
		{
			get
			{
				return _人物武勋;
			}
			set
			{
				_人物武勋 = value;
			}
		}

		public double 比武追加经验值
		{
			get
			{
				return _比武追加经验值;
			}
			set
			{
				_比武追加经验值 = value;
			}
		}

		public int 杀人次数
		{
			get
			{
				return _杀人次数;
			}
			set
			{
				_杀人次数 = value;
			}
		}

		public int 被杀次数
		{
			get
			{
				return _被杀次数;
			}
			set
			{
				_被杀次数 = value;
			}
		}

		public int 武勋阶段
		{
			get
			{
				return _武勋阶段;
			}
			set
			{
				_武勋阶段 = value;
			}
		}

		public int 人物善恶
		{
			get
			{
				return _人物善恶;
			}
			set
			{
				if (_人物善恶 + value > 0)
				{
					_人物善恶 = 0;
				}
				else if (_人物善恶 - value < -30000)
				{
					_人物善恶 = -30000;
				}
				else
				{
					_人物善恶 = value;
				}
			}
		}

		public int Player_Job
		{
			get
			{
				return _人物职业;
			}
			set
			{
				_人物职业 = value;
			}
		}

		public int 是否假人
		{
			get
			{
				return _是否假人;
			}
			set
			{
				_是否假人 = value;
			}
		}

		public int 账号是否假人
		{
			get
			{
				return _账号是否假人;
			}
			set
			{
				_账号是否假人 = value;
			}
		}

		public int Player_Job_leve
		{
			get
			{
				return _人物职业等级;
			}
			set
			{
				_人物职业等级 = value;
			}
		}

		public byte[] 人物名字模版
		{
			get
			{
				return _人物名字模版;
			}
			set
			{
				_人物名字模版 = value;
			}
		}

		public int Player_Sex
		{
			get
			{
				return _人物性别;
			}
			set
			{
				_人物性别 = value;
			}
		}

		public float 人物坐标_X
		{
			get
			{
				return _人物坐标_X;
			}
			set
			{
				_人物坐标_X = value;
			}
		}

		public float 人物坐标_Y
		{
			get
			{
				return _人物坐标_Y;
			}
			set
			{
				_人物坐标_Y = value;
			}
		}

		public float 人物坐标_Z
		{
			get
			{
				return _人物坐标_Z;
			}
			set
			{
				_人物坐标_Z = value;
			}
		}

		public int 人物坐标_地图
		{
			get
			{
				return _人物坐标_地图;
			}
			set
			{
				_人物坐标_地图 = value;
			}
		}

		public int 人物当前负重
		{
			get
			{
				return _人物当前负重;
			}
			set
			{
				_人物当前负重 = value;
			}
		}

		public int 人物负重总
		{
			get
			{
				return _人物负重总 + FLD_人物_气功_负重;
			}
			set
			{
				_人物负重总 = value;
			}
		}

		public int 人物封包ID
		{
			get
			{
				return _人物封包ID;
			}
			set
			{
				_人物封包ID = value;
			}
		}

		public string 原服务器IP
		{
			get
			{
				return _原服务器IP;
			}
			set
			{
				_原服务器IP = value;
			}
		}

		public int 原服务器端口
		{
			get
			{
				return _原服务器端口;
			}
			set
			{
				_原服务器端口 = value;
			}
		}

		public int 原服务器序号
		{
			get
			{
				return _原服务器序号;
			}
			set
			{
				_原服务器序号 = value;
			}
		}

		public int 原服务器ID
		{
			get
			{
				return _原服务器ID;
			}
			set
			{
				_原服务器ID = value;
			}
		}

		public string 银币广场服务器IP
		{
			get
			{
				return _银币广场服务器IP;
			}
			set
			{
				_银币广场服务器IP = value;
			}
		}

		public int 银币广场服务器端口
		{
			get
			{
				return _银币广场服务器端口;
			}
			set
			{
				_银币广场服务器端口 = value;
			}
		}

		public int 人物全服ID => Client.WorldId;

		public int 人物PK模式
		{
			get
			{
				return _人物PK模式;
			}
			set
			{
				_人物PK模式 = value;
			}
		}

		public double 狂意护体加成
		{
			get
			{
				return _狂意护体加成;
			}
			set
			{
				_狂意护体加成 = value;
			}
		}

		public long 个人仓库钱数
		{
			get
			{
				return _个人仓库钱数;
			}
			set
			{
				_个人仓库钱数 = value;
			}
		}

		public long 综合仓库钱数
		{
			get
			{
				return _综合仓库钱数;
			}
			set
			{
				_综合仓库钱数 = value;
			}
		}

		public int FLD_推广ID
		{
			get
			{
				return _FLD_推广ID;
			}
			set
			{
				_FLD_推广ID = value;
			}
		}

		public string FLD_SPREADERID
		{
			get
			{
				return _FLD_SPREADERID;
			}
			set
			{
				_FLD_SPREADERID = value;
			}
		}

		public int FLD_ZJF
		{
			get
			{
				return _FLD_ZJF;
			}
			set
			{
				_FLD_ZJF = value;
			}
		}

		public int FLD_SPREADER_LEVEL
		{
			get
			{
				return _FLD_SPREADER_LEVEL;
			}
			set
			{
				_FLD_SPREADER_LEVEL = value;
			}
		}

		public int FLD_RXPIONT
		{
			get
			{
				return _FLD_RXPIONT;
			}
			set
			{
				_FLD_RXPIONT = value;
			}
		}

		public int FLD_RXPIONTX
		{
			get
			{
				return _FLD_RXPIONTX;
			}
			set
			{
				_FLD_RXPIONTX = value;
			}
		}

		public int FLD_Coin
		{
			get
			{
				return _FLD_Coin;
			}
			set
			{
				_FLD_Coin = value;
			}
		}

		public int FLD_PK积分
		{
			get
			{
				return _FLD_PK积分;
			}
			set
			{
				_FLD_PK积分 = value;
			}
		}

		public int FLD_积分
		{
			get
			{
				return _FLD_积分;
			}
			set
			{
				_FLD_积分 = value;
			}
		}

		public int FLD_首充次数
		{
			get
			{
				return _首充次数;
			}
			set
			{
				_首充次数 = value;
			}
		}

		public int 元宝消费
		{
			get
			{
				return _元宝消费;
			}
			set
			{
				_元宝消费 = value;
			}
		}

		public int 元宝消费2
		{
			get
			{
				return _元宝消费2;
			}
			set
			{
				_元宝消费2 = value;
			}
		}

		public int 钻石消费
		{
			get
			{
				return _钻石消费;
			}
			set
			{
				_钻石消费 = value;
			}
		}

		public int 元宝充值
		{
			get
			{
				return _元宝充值;
			}
			set
			{
				_元宝充值 = value;
			}
		}

		public int 钻石充值
		{
			get
			{
				return _钻石充值;
			}
			set
			{
				_钻石充值 = value;
			}
		}

		public int 账号锁定
		{
			get
			{
				return _账号锁定;
			}
			set
			{
				_账号锁定 = value;
			}
		}

		public int 累计充值
		{
			get
			{
				return _累计充值;
			}
			set
			{
				_累计充值 = value;
			}
		}

		public int FLD_CJCS
		{
			get
			{
				return _抽奖次数;
			}
			set
			{
				_抽奖次数 = value;
			}
		}

		public int FLD_VIP
		{
			get
			{
				return _FLD_VIP;
			}
			set
			{
				_FLD_VIP = value;
			}
		}

		public DateTime FLD_VIPTIM
		{
			get
			{
				return _FLD_VIPTIM;
			}
			set
			{
				_FLD_VIPTIM = value;
			}
		}

		public DateTime FLD_QDVIPTIM
		{
			get
			{
				return _FLD_QDVIPTIM;
			}
			set
			{
				_FLD_QDVIPTIM = value;
			}
		}

		public DateTime FLD_精力时间
		{
			get
			{
				return _FLD_精力时间;
			}
			set
			{
				_FLD_精力时间 = value;
			}
		}

		public DateTime FLD_MBVIPTIM
		{
			get
			{
				return _FLD_MBVIPTIM;
			}
			set
			{
				_FLD_MBVIPTIM = value;
			}
		}

		public int FLD_攻击速度
		{
			get
			{
				return _FLD_攻击速度;
			}
			set
			{
				_FLD_攻击速度 = value;
			}
		}

		public int FLD_制作类型
		{
			get
			{
				return _FLD_制作类型;
			}
			set
			{
				_FLD_制作类型 = value;
			}
		}

		public int FLD_制作等级
		{
			get
			{
				return _FLD_制作等级;
			}
			set
			{
				_FLD_制作等级 = value;
			}
		}

		public int FLD_制作熟练度
		{
			get
			{
				return _FLD_制作熟练度;
			}
			set
			{
				if (value >= 1500)
				{
					_FLD_制作熟练度 = 1500;
				}
				else
				{
					_FLD_制作熟练度 = value;
				}
			}
		}

		public string FLD_情侣
		{
			get
			{
				return _FLD_情侣;
			}
			set
			{
				_FLD_情侣 = value;
			}
		}

		public string FLD_情侣戒指
		{
			get
			{
				return _FLD_情侣戒指;
			}
			set
			{
				_FLD_情侣戒指 = value;
			}
		}

		public int FLD_情侣_爱情度
		{
			get
			{
				return _FLD_情侣_爱情度;
			}
			set
			{
				_FLD_情侣_爱情度 = value;
			}
		}

		public string FLD_临时师徒
		{
			get
			{
				return _FLD_临时师徒;
			}
			set
			{
				_FLD_临时师徒 = value;
			}
		}

		public bool 可结成师徒关系状态
		{
			get
			{
				return _可结成师徒关系状态;
			}
			set
			{
				_可结成师徒关系状态 = value;
			}
		}

		public DateTime 解除师徒关系时间
		{
			get
			{
				return _解除师徒关系时间;
			}
			set
			{
				_解除师徒关系时间 = value;
			}
		}

		public int FLD_荣誉ID
		{
			get
			{
				return _FLD_荣誉ID;
			}
			set
			{
				_FLD_荣誉ID = value;
			}
		}

		public int 荣誉ID_
		{
			get
			{
				return _武林荣誉ID_;
			}
			set
			{
				_武林荣誉ID_ = value;
			}
		}

		public bool Player死亡
		{
			get
			{
				if (人物_HP <= 0)
				{
					_Player死亡 = true;
				}
				return _Player死亡;
			}
			set
			{
				_Player死亡 = value;
			}
		}

		public string 仙魔大战派别
		{
			get
			{
				return _仙魔大战派别;
			}
			set
			{
				_仙魔大战派别 = value;
			}
		}

		public int FLD_PVP_Piont
		{
			get
			{
				return _FLD_PVP_Piont;
			}
			set
			{
				_FLD_PVP_Piont = value;
			}
		}

		public bool 元宝账户状态
		{
			get
			{
				return _元宝账户状态;
			}
			set
			{
				_元宝账户状态 = value;
			}
		}

		public bool 是否押注
		{
			get
			{
				return _是否押注;
			}
			set
			{
				_是否押注 = value;
			}
		}

		public int 押注专场代码
		{
			get
			{
				return _押注专场代码;
			}
			set
			{
				_押注专场代码 = value;
			}
		}

		public string 押注单双
		{
			get
			{
				return _押注单双;
			}
			set
			{
				_押注单双 = value;
			}
		}

		public double FLD_药品_减少攻击
		{
			get
			{
				return _FLD_药品_减少攻击;
			}
			set
			{
				_FLD_药品_减少攻击 = value;
			}
		}

		public double FLD_药品_减少防御
		{
			get
			{
				return _FLD_药品_减少防御;
			}
			set
			{
				_FLD_药品_减少防御 = value;
			}
		}

		public int 玫瑰称号追加HP
		{
			get
			{
				return _玫瑰称号追加HP;
			}
			set
			{
				_玫瑰称号追加HP = value;
			}
		}

		public int 玫瑰称号追加防御
		{
			get
			{
				return _玫瑰称号追加防御;
			}
			set
			{
				_玫瑰称号追加防御 = value;
			}
		}

		public int 玫瑰称号追加攻击
		{
			get
			{
				return _玫瑰称号追加攻击;
			}
			set
			{
				_玫瑰称号追加攻击 = value;
			}
		}

		public int 花榜追加HP
		{
			get
			{
				return _花榜追加HP;
			}
			set
			{
				_花榜追加HP = value;
			}
		}

		public int 花榜追加防御
		{
			get
			{
				return _花榜追加防御;
			}
			set
			{
				_花榜追加防御 = value;
			}
		}

		public int 花榜追加攻击
		{
			get
			{
				return _花榜追加攻击;
			}
			set
			{
				_花榜追加攻击 = value;
			}
		}

		public int 乱斗追加攻击
		{
			get
			{
				return _乱斗追加攻击;
			}
			set
			{
				_乱斗追加攻击 = value;
			}
		}

		public int 乱斗追加防御
		{
			get
			{
				return _乱斗追加防御;
			}
			set
			{
				_乱斗追加防御 = value;
			}
		}

		public int 乱斗追加HP
		{
			get
			{
				return _乱斗追加HP;
			}
			set
			{
				_乱斗追加HP = value;
			}
		}

		public int VIP称号增加生命
		{
			get
			{
				return _VIP称号增加生命;
			}
			set
			{
				_VIP称号增加生命 = value;
			}
		}

		public int 前十追加HP
		{
			get
			{
				return _前十追加HP;
			}
			set
			{
				_前十追加HP = value;
			}
		}

		public int 前十追加防御
		{
			get
			{
				return _前十追加防御;
			}
			set
			{
				_前十追加防御 = value;
			}
		}

		public int VIP称号增加防御
		{
			get
			{
				return _VIP称号增加防御;
			}
			set
			{
				_VIP称号增加防御 = value;
			}
		}

		public int VIP称号增加攻击
		{
			get
			{
				return _VIP称号增加攻击;
			}
			set
			{
				_VIP称号增加攻击 = value;
			}
		}

		public int 前十追加攻击
		{
			get
			{
				return _前十追加攻击;
			}
			set
			{
				_前十追加攻击 = value;
			}
		}

		public int FLD_消耗_追加_防御
		{
			get
			{
				return _FLD_消耗_追加_防御;
			}
			set
			{
				_FLD_消耗_追加_防御 = value;
			}
		}

		public int FLD_消耗_追加_攻击
		{
			get
			{
				return _FLD_消耗_追加_攻击;
			}
			set
			{
				_FLD_消耗_追加_攻击 = value;
			}
		}

		public int FLD_消耗_追加_气功
		{
			get
			{
				return _FLD_消耗_追加_气功;
			}
			set
			{
				_FLD_消耗_追加_气功 = value;
			}
		}

		public double FLD_消耗_追加_经验百分比
		{
			get
			{
				return _FLD_消耗_追加_经验百分比;
			}
			set
			{
				_FLD_消耗_追加_经验百分比 = value;
			}
		}

		public int FLD_消耗_追加_血
		{
			get
			{
				return _FLD_消耗_追加_血;
			}
			set
			{
				_FLD_消耗_追加_血 = value;
			}
		}

		public int 门派称号追加HP
		{
			get
			{
				return _门派称号追加HP;
			}
			set
			{
				_门派称号追加HP = value;
			}
		}

		public int 门派称号追加防御
		{
			get
			{
				return _门派称号追加防御;
			}
			set
			{
				_门派称号追加防御 = value;
			}
		}

		public int 门派称号追加攻击
		{
			get
			{
				return _门派称号追加攻击;
			}
			set
			{
				_门派称号追加攻击 = value;
			}
		}

		public int 称号追加HP
		{
			get
			{
				return _称号追加HP;
			}
			set
			{
				_称号追加HP = value;
			}
		}

		public int 称号追加防御
		{
			get
			{
				return _称号追加防御;
			}
			set
			{
				_称号追加防御 = value;
			}
		}

		public int 称号追加攻击
		{
			get
			{
				return _称号追加攻击;
			}
			set
			{
				_称号追加攻击 = value;
			}
		}

		public int 人物追加战力
		{
			get
			{
				return _人物追加战力;
			}
			set
			{
				_人物追加战力 = value;
			}
		}

		public int 人物追加武勋战力
		{
			get
			{
				return _人物追加武勋战力;
			}
			set
			{
				_人物追加武勋战力 = value;
			}
		}

		public int 称号追加战斗力
		{
			get
			{
				return _称号追加战斗力;
			}
			set
			{
				_称号追加战斗力 = value;
			}
		}

		public int 玫瑰追加战斗力
		{
			get
			{
				return _玫瑰追加战斗力;
			}
			set
			{
				_玫瑰追加战斗力 = value;
			}
		}

		public int 前十追加战斗力
		{
			get
			{
				return _前十追加战斗力;
			}
			set
			{
				_前十追加战斗力 = value;
			}
		}

		public int 人物_追加_PVP战力 => 人物追加战力 + 人物追加武勋战力 + FLD_装备_追加_战斗力 + 称号追加战斗力 + 玫瑰追加战斗力 + 前十追加战斗力;

		public int 人物武功回避 => base.武功回避 + FLD_装备_追加_武功回避;

		public int 人物武功命中 => FLD_装备_追加_武功命中;

		public int 总负重 => 人物负重总 + FLD_装备_追加_武功负重;

		public double FLD_追加百分比_攻击
		{
			get
			{
				return _FLD_追加百分比_攻击;
			}
			set
			{
				_FLD_追加百分比_攻击 = value;
			}
		}

		public double FLD_追加百分比_防御
		{
			get
			{
				return _FLD_追加百分比_防御;
			}
			set
			{
				_FLD_追加百分比_防御 = value;
			}
		}

		public double FLD_追加百分比_命中
		{
			get
			{
				return _FLD_追加百分比_命中;
			}
			set
			{
				_FLD_追加百分比_命中 = value;
			}
		}

		public double FLD_人物_追加百分比_回避
		{
			get
			{
				return _FLD_人物_追加百分比_回避;
			}
			set
			{
				_FLD_人物_追加百分比_回避 = value;
			}
		}

		public double FLD_追加哀鸿片野_HP上限
		{
			get
			{
				return _FLD_追加哀鸿片野_HP上限;
			}
			set
			{
				_FLD_追加哀鸿片野_HP上限 = value;
			}
		}

		public double FLD_追加百分比_HP上限
		{
			get
			{
				return _FLD_追加百分比_HP上限;
			}
			set
			{
				_FLD_追加百分比_HP上限 = value;
			}
		}

		public double FLD_追加百分比_MP上限
		{
			get
			{
				return _FLD_追加百分比_MP上限;
			}
			set
			{
				_FLD_追加百分比_MP上限 = value;
			}
		}

		public int FLD_心
		{
			get
			{
				return _FLD_心;
			}
			set
			{
				_FLD_心 = value;
			}
		}

		public int FLD_体
		{
			get
			{
				return _FLD_体;
			}
			set
			{
				_FLD_体 = value;
			}
		}

		public int FLD_力
		{
			get
			{
				return _FLD_力;
			}
			set
			{
				_FLD_力 = value;
			}
		}

		public int FLD_身
		{
			get
			{
				return _FLD_身;
			}
			set
			{
				_FLD_身 = value;
			}
		}

		public int FLD_攻击
		{
			get
			{
				return _FLD_攻击;
			}
			set
			{
				_FLD_攻击 = value;
			}
		}

		public double 最小攻击
		{
			get
			{
				return _最小攻击;
			}
			set
			{
				_最小攻击 = value;
			}
		}

		public int FLD_最小攻击
		{
			get
			{
				return _FLD_最小攻击;
			}
			set
			{
				_FLD_最小攻击 = value;
			}
		}

		public int FLD_最大攻击
		{
			get
			{
				return _FLD_最大攻击;
			}
			set
			{
				_FLD_最大攻击 = value;
			}
		}

		public int FLD_命中
		{
			get
			{
				return _FLD_命中;
			}
			set
			{
				_FLD_命中 = value;
			}
		}

		public int FLD_防御
		{
			get
			{
				return _FLD_防御;
			}
			set
			{
				_FLD_防御 = value;
			}
		}

		public int FLD_回避
		{
			get
			{
				return _FLD_回避;
			}
			set
			{
				_FLD_回避 = value;
			}
		}

		public DateTime FLD_结婚纪念日
		{
			get
			{
				return _FLD_结婚纪念日;
			}
			set
			{
				_FLD_结婚纪念日 = value;
			}
		}

		public double FLD_人物_气功_攻击
		{
			get
			{
				return _FLD_人物_气功_攻击;
			}
			set
			{
				_FLD_人物_气功_攻击 = value;
			}
		}

		public int FLD_人物_气功_命中
		{
			get
			{
				return _FLD_人物_气功_命中;
			}
			set
			{
				_FLD_人物_气功_命中 = value;
			}
		}

		public int FLD_人物_气功_防御
		{
			get
			{
				return _FLD_人物_气功_防御;
			}
			set
			{
				_FLD_人物_气功_防御 = value;
			}
		}

		public int FLD_人物_气功_负重
		{
			get
			{
				return _FLD_人物_气功_负重;
			}
			set
			{
				_FLD_人物_气功_负重 = value;
			}
		}

		public int FLD_人物_气功_回避
		{
			get
			{
				return _FLD_人物_气功_回避;
			}
			set
			{
				_FLD_人物_气功_回避 = value;
			}
		}

		public double FLD_人物_武功攻击力增加百分比
		{
			get
			{
				return _FLD_人物_武功攻击力增加百分比;
			}
			set
			{
				_FLD_人物_武功攻击力增加百分比 = value;
			}
		}

		public double FLD_人物_武功防御力增加百分比
		{
			get
			{
				return _FLD_人物_武功防御力增加百分比;
			}
			set
			{
				_FLD_人物_武功防御力增加百分比 = value;
			}
		}

		public double FLD_人物_气功_武功攻击力增加百分比
		{
			get
			{
				return _FLD_人物_气功_武功攻击力增加百分比;
			}
			set
			{
				_FLD_人物_气功_武功攻击力增加百分比 = value;
			}
		}

		public double FLD_人物_气功_武功防御力增加百分比
		{
			get
			{
				return _FLD_人物_气功_武功防御力增加百分比;
			}
			set
			{
				_FLD_人物_气功_武功防御力增加百分比 = value;
			}
		}

		public double FLD_人物_追加_武功防御力
		{
			get
			{
				return _FLD_人物_追加_武功防御力;
			}
			set
			{
				_FLD_人物_追加_武功防御力 = value;
			}
		}

		public int FLD_人物_追加_攻击
		{
			get
			{
				return _FLD_人物_追加_攻击;
			}
			set
			{
				_FLD_人物_追加_攻击 = value;
			}
		}

		public int FLD_神女_追加_攻击
		{
			get
			{
				return _FLD_神女_追加_攻击;
			}
			set
			{
				_FLD_神女_追加_攻击 = value;
			}
		}

		public int FLD_人物_追加_防御
		{
			get
			{
				return _FLD_人物_追加_防御;
			}
			set
			{
				_FLD_人物_追加_防御 = value;
			}
		}

		public int FLD_神女_追加_防御
		{
			get
			{
				return _FLD_神女_追加_防御;
			}
			set
			{
				_FLD_神女_追加_防御 = value;
			}
		}

		public int FLD_人物_追加_命中
		{
			get
			{
				return _FLD_人物_追加_命中;
			}
			set
			{
				_FLD_人物_追加_命中 = value;
			}
		}

		public int FLD_人物_追加_回避
		{
			get
			{
				return _FLD_人物_追加_回避;
			}
			set
			{
				_FLD_人物_追加_回避 = value;
			}
		}

		public int FLD_人物_追加_气功
		{
			get
			{
				return _FLD_人物_追加_气功;
			}
			set
			{
				_FLD_人物_追加_气功 = value;
			}
		}

		public int 八彩_追加_攻击
		{
			get
			{
				return _八彩_追加_攻击;
			}
			set
			{
				_八彩_追加_攻击 = value;
			}
		}

		public int 八彩_追加_防御
		{
			get
			{
				return _八彩_追加_防御;
			}
			set
			{
				_八彩_追加_防御 = value;
			}
		}

		public double FLD_人物_追加_经验百分比
		{
			get
			{
				return _FLD_人物_追加_经验百分比;
			}
			set
			{
				_FLD_人物_追加_经验百分比 = value;
			}
		}

		public double FLD_宠物_追加_经验百分比
		{
			get
			{
				return _FLD_宠物_追加_经验百分比;
			}
			set
			{
				_FLD_宠物_追加_经验百分比 = value;
			}
		}

		public double 医生群疗_追加_经验百分比
		{
			get
			{
				return _FLD_医生_追加_经验百分比;
			}
			set
			{
				_FLD_医生_追加_经验百分比 = value;
			}
		}

		public int 医生群疗_追加_爆率
		{
			get
			{
				return _FLD_医生_追加_爆率;
			}
			set
			{
				_FLD_医生_追加_爆率 = value;
			}
		}

		public double FLD_灵宠_追加_经验百分比
		{
			get
			{
				return _FLD_灵宠_追加_经验百分比;
			}
			set
			{
				_FLD_灵宠_追加_经验百分比 = value;
			}
		}

		public double FLD_灵宠_追加_历练百分比
		{
			get
			{
				return _FLD_灵宠_追加_历练百分比;
			}
			set
			{
				_FLD_灵宠_追加_历练百分比 = value;
			}
		}

		public double FLD_人物_追加_历练百分比
		{
			get
			{
				return _FLD_人物_追加_历练百分比;
			}
			set
			{
				_FLD_人物_追加_历练百分比 = value;
			}
		}

		public double FLD_人物_追加_合成成功率百分比
		{
			get
			{
				return _FLD_人物_追加_合成成功率百分比;
			}
			set
			{
				_FLD_人物_追加_合成成功率百分比 = value;
			}
		}

		public int FLD_夫妻辅助_追加_防具_属性
		{
			get
			{
				return _FLD_夫妻辅助_追加_防具_属性;
			}
			set
			{
				_FLD_夫妻辅助_追加_防具_属性 = value;
			}
		}

		public int FLD_夫妻辅助_追加_武器_属性
		{
			get
			{
				return _FLD_夫妻辅助_追加_武器_属性;
			}
			set
			{
				_FLD_夫妻辅助_追加_武器_属性 = value;
			}
		}

		public int FLD_结婚礼物_追加_属性石
		{
			get
			{
				return _FLD_结婚礼物_追加_属性石;
			}
			set
			{
				_FLD_结婚礼物_追加_属性石 = value;
			}
		}

		public int FLD_宠物_追加_最大HP
		{
			get
			{
				return _FLD_宠物_追加_最大HP;
			}
			set
			{
				_FLD_宠物_追加_最大HP = value;
			}
		}

		public int FLD_宠物_追加_攻击
		{
			get
			{
				return _FLD_宠物_追加_攻击;
			}
			set
			{
				_FLD_宠物_追加_攻击 = value;
			}
		}

		public int FLD_宠物_追加_防御
		{
			get
			{
				return _FLD_宠物_追加_防御;
			}
			set
			{
				_FLD_宠物_追加_防御 = value;
			}
		}

		public double FLD_人物_追加_贩卖价格百分比
		{
			get
			{
				return _FLD_人物_追加_贩卖价格百分比;
			}
			set
			{
				_FLD_人物_追加_贩卖价格百分比 = value;
			}
		}

		public double FLD_人物_追加_武勋获得量百分比
		{
			get
			{
				return _FLD_人物_追加_武勋获得量百分比;
			}
			set
			{
				_FLD_人物_追加_武勋获得量百分比 = value;
			}
		}

		public double FLD_人物_追加_吸魂几率百分比
		{
			get
			{
				return _FLD_人物_追加_吸魂几率百分比;
			}
			set
			{
				_FLD_人物_追加_吸魂几率百分比 = value;
			}
		}

		public double FLD_人物_追加_获得游戏币百分比
		{
			get
			{
				return _FLD_人物_追加_获得游戏币百分比;
			}
			set
			{
				_FLD_人物_追加_获得游戏币百分比 = value;
			}
		}

		public double FLD_人物_追加_物品掉落概率百分比
		{
			get
			{
				return _FLD_人物_追加_物品掉落概率百分比;
			}
			set
			{
				_FLD_人物_追加_物品掉落概率百分比 = value;
			}
		}

		public double FLD_装备_追加_合成成功率百分比
		{
			get
			{
				return _FLD_装备_追加_合成成功率百分比;
			}
			set
			{
				_FLD_装备_追加_合成成功率百分比 = value;
			}
		}

		public double FLD_装备_追加_获得游戏币百分比
		{
			get
			{
				return _FLD_装备_追加_获得游戏币百分比;
			}
			set
			{
				_FLD_装备_追加_获得游戏币百分比 = value;
			}
		}

		public double FLD_装备_武功攻击力增加百分比
		{
			get
			{
				return _FLD_装备_武功攻击力增加百分比;
			}
			set
			{
				_FLD_装备_武功攻击力增加百分比 = value;
			}
		}

		public int FLD_装备_追加_武功命中
		{
			get
			{
				return _FLD_装备_追加_武功命中;
			}
			set
			{
				_FLD_装备_追加_武功命中 = value;
			}
		}

		public int 强化武器追加百分比
		{
			get
			{
				return _武器追加百分比;
			}
			set
			{
				_武器追加百分比 = value;
			}
		}

		public int 强化防具追加百分比
		{
			get
			{
				return _防具追加百分比;
			}
			set
			{
				_防具追加百分比 = value;
			}
		}

		public int FLD_装备_追加_武功负重
		{
			get
			{
				return _FLD_装备_追加_武功负重;
			}
			set
			{
				_FLD_装备_追加_武功负重 = value;
			}
		}

		public int FLD_装备_追加_武功回避
		{
			get
			{
				return _FLD_装备_追加_武功回避;
			}
			set
			{
				_FLD_装备_追加_武功回避 = value;
			}
		}

		public int 减免对方伤害
		{
			get
			{
				return _减免对方伤害;
			}
			set
			{
				_减免对方伤害 = value;
			}
		}

		public int 药品减免对方伤害
		{
			get
			{
				return _药品减免对方伤害;
			}
			set
			{
				_药品减免对方伤害 = value;
			}
		}

		public int FLD_装备_增加异常
		{
			get
			{
				return _FLD_装备_增加异常;
			}
			set
			{
				_FLD_装备_增加异常 = value;
			}
		}

		public int FLD_装备_增加对方异常
		{
			get
			{
				return _FLD_装备_增加对方异常;
			}
			set
			{
				_FLD_装备_增加对方异常 = value;
			}
		}

		public double FLD_装备_武功防御力
		{
			get
			{
				return _FLD_装备_武功防御力;
			}
			set
			{
				_FLD_装备_武功防御力 = value;
			}
		}

		public double FLD_装备_武功防御力增加百分比
		{
			get
			{
				return _FLD_装备_武功防御力增加百分比;
			}
			set
			{
				_FLD_装备_武功防御力增加百分比 = value;
			}
		}

		public int FLD_装备_追加_攻击New
		{
			get
			{
				return _FLD_装备_追加_攻击New;
			}
			set
			{
				_FLD_装备_追加_攻击New = value;
			}
		}

		public int FLD_装备_追加_攻击
		{
			get
			{
				return _FLD_装备_追加_攻击;
			}
			set
			{
				_FLD_装备_追加_攻击 = value;
			}
		}

		public int FLD_装备_追加_防御
		{
			get
			{
				return _FLD_装备_追加_防御;
			}
			set
			{
				_FLD_装备_追加_防御 = value;
			}
		}

		public int FLD_装备_追加_战斗力
		{
			get
			{
				return _FLD_装备_追加_战斗力;
			}
			set
			{
				_FLD_装备_追加_战斗力 = value;
			}
		}

		public int FLD_装备_追加_武器_强化
		{
			get
			{
				return _FLD_装备_追加_武器_强化;
			}
			set
			{
				_FLD_装备_追加_武器_强化 = value;
			}
		}

		public int FLD_装备_追加_防具_强化
		{
			get
			{
				return _FLD_装备_追加_防具_强化;
			}
			set
			{
				_FLD_装备_追加_防具_强化 = value;
			}
		}

		public int 防具追加强化总 => FLD_项链_追加_防具_强化 + FLD_装备_追加_防具_强化 + FLD_结婚礼物_追加_属性石;

		public int 武器追加强化总 => FLD_项链_追加_武器_强化 + FLD_装备_追加_武器_强化 + FLD_夫妻辅助_追加_武器_属性 + FLD_结婚礼物_追加_属性石;

		public int FLD_项链_追加_防具_强化
		{
			get
			{
				return _FLD_项链_追加_防具_强化;
			}
			set
			{
				_FLD_项链_追加_防具_强化 = value;
			}
		}

		public int FLD_项链_追加_武器_强化
		{
			get
			{
				return _FLD_项链_追加_武器_强化;
			}
			set
			{
				_FLD_项链_追加_武器_强化 = value;
			}
		}

		public int FLD_装备_追加_命中
		{
			get
			{
				return _FLD_装备_追加_命中;
			}
			set
			{
				_FLD_装备_追加_命中 = value;
			}
		}

		public double FLD_装备_追加_降低百分比攻击
		{
			get
			{
				return _FLD_装备_追加_降低百分比攻击;
			}
			set
			{
				_FLD_装备_追加_降低百分比攻击 = value;
			}
		}

		public double FLD_装备_追加_降低百分比防御
		{
			get
			{
				return _FLD_装备_追加_降低百分比防御;
			}
			set
			{
				_FLD_装备_追加_降低百分比防御 = value;
			}
		}

		public double 武勋降低百分比防御
		{
			get
			{
				return _武勋降低百分比防御;
			}
			set
			{
				_武勋降低百分比防御 = value;
			}
		}

		public double FLD_装备_追加_命中百分比
		{
			get
			{
				return _FLD_装备_追加_命中百分比;
			}
			set
			{
				_FLD_装备_追加_命中百分比 = value;
			}
		}

		public int FLD_装备_追加_愤怒
		{
			get
			{
				return _FLD_装备_追加_愤怒;
			}
			set
			{
				_FLD_装备_追加_愤怒 = value;
			}
		}

		public double FLD_装备_追加_回避百分比
		{
			get
			{
				return _FLD_装备_追加_回避百分比;
			}
			set
			{
				_FLD_装备_追加_回避百分比 = value;
			}
		}

		public double FLD_装备_降低_伤害值
		{
			get
			{
				return _FLD_装备_降低_伤害值;
			}
			set
			{
				_FLD_装备_降低_伤害值 = value;
			}
		}

		public int FLD_装备_追加_伤害值
		{
			get
			{
				return _FLD_装备_追加_伤害值;
			}
			set
			{
				_FLD_装备_追加_伤害值 = value;
			}
		}

		public double FLD_装备_追加_初始化愤怒概率百分比
		{
			get
			{
				return _FLD_装备_追加_初始化愤怒概率百分比;
			}
			set
			{
				_FLD_装备_追加_初始化愤怒概率百分比 = value;
			}
		}

		public double FLD_装备_追加_中毒概率百分比
		{
			get
			{
				return _FLD_装备_追加_中毒概率百分比;
			}
			set
			{
				_FLD_装备_追加_中毒概率百分比 = value;
			}
		}

		public int FLD_装备_追加_回避
		{
			get
			{
				return _FLD_装备_追加_回避;
			}
			set
			{
				_FLD_装备_追加_回避 = value;
			}
		}

		public int FLD_装备_追加_气功
		{
			get
			{
				return _FLD_装备_追加_气功;
			}
			set
			{
				_FLD_装备_追加_气功 = value;
			}
		}

		public double FLD_装备_追加_经验百分比
		{
			get
			{
				return _FLD_装备_追加_经验百分比;
			}
			set
			{
				_FLD_装备_追加_经验百分比 = value;
			}
		}

		public double LS_降低_暴率百分比
		{
			get
			{
				return _LS_降低_暴率百分比;
			}
			set
			{
				_LS_降低_暴率百分比 = value;
			}
		}

		public double LS_降低_经验百分比
		{
			get
			{
				return _LS_降低_经验百分比;
			}
			set
			{
				_LS_降低_经验百分比 = value;
			}
		}

		public double LS_降低_金钱百分比
		{
			get
			{
				return _LS_降低_金钱百分比;
			}
			set
			{
				_LS_降低_金钱百分比 = value;
			}
		}

		public double LS_降低_历练百分比
		{
			get
			{
				return _LS_降低_历练百分比;
			}
			set
			{
				_LS_降低_历练百分比 = value;
			}
		}

		public double FLD_装备_追加_死亡损失经验减少
		{
			get
			{
				return _FLD_装备_追加_死亡损失经验减少;
			}
			set
			{
				_FLD_装备_追加_死亡损失经验减少 = value;
			}
		}

		public double FLD_装备_追加_气功_0
		{
			get
			{
				return _FLD_装备_追加_气功_0;
			}
			set
			{
				_FLD_装备_追加_气功_0 = value;
			}
		}

		public double FLD_装备_追加_气功_1
		{
			get
			{
				return _FLD_装备_追加_气功_1;
			}
			set
			{
				_FLD_装备_追加_气功_1 = value;
			}
		}

		public double FLD_装备_追加_气功_2
		{
			get
			{
				return _FLD_装备_追加_气功_2;
			}
			set
			{
				_FLD_装备_追加_气功_2 = value;
			}
		}

		public double FLD_装备_追加_气功_3
		{
			get
			{
				return _FLD_装备_追加_气功_3;
			}
			set
			{
				_FLD_装备_追加_气功_3 = value;
			}
		}

		public double FLD_装备_追加_气功_4
		{
			get
			{
				return _FLD_装备_追加_气功_4;
			}
			set
			{
				_FLD_装备_追加_气功_4 = value;
			}
		}

		public double FLD_装备_追加_气功_5
		{
			get
			{
				return _FLD_装备_追加_气功_5;
			}
			set
			{
				_FLD_装备_追加_气功_5 = value;
			}
		}

		public double FLD_装备_追加_气功_6
		{
			get
			{
				return _FLD_装备_追加_气功_6;
			}
			set
			{
				_FLD_装备_追加_气功_6 = value;
			}
		}

		public double FLD_装备_追加_气功_7
		{
			get
			{
				return _FLD_装备_追加_气功_7;
			}
			set
			{
				_FLD_装备_追加_气功_7 = value;
			}
		}

		public double FLD_装备_追加_气功_8
		{
			get
			{
				return _FLD_装备_追加_气功_8;
			}
			set
			{
				_FLD_装备_追加_气功_8 = value;
			}
		}

		public double FLD_装备_追加_气功_9
		{
			get
			{
				return _FLD_装备_追加_气功_9;
			}
			set
			{
				_FLD_装备_追加_气功_9 = value;
			}
		}

		public double FLD_装备_追加_气功_11
		{
			get
			{
				return _FLD_装备_追加_气功_11;
			}
			set
			{
				_FLD_装备_追加_气功_11 = value;
			}
		}

		public double FLD_装备_追加_气功_10
		{
			get
			{
				return _FLD_装备_追加_气功_10;
			}
			set
			{
				_FLD_装备_追加_气功_10 = value;
			}
		}

		public int FLD_装备_追加_HP
		{
			get
			{
				return _FLD_装备_追加_HP;
			}
			set
			{
				_FLD_装备_追加_HP = value;
			}
		}

		public int FLD_装备_隐藏_HP
		{
			get
			{
				return _FLD_装备_隐藏_HP;
			}
			set
			{
				_FLD_装备_隐藏_HP = value;
			}
		}

		public int FLD_装备_隐藏_DF
		{
			get
			{
				return _FLD_装备_隐藏_DF;
			}
			set
			{
				_FLD_装备_隐藏_DF = value;
			}
		}

		public int FLD_装备_隐藏_AT
		{
			get
			{
				return _FLD_装备_隐藏_AT;
			}
			set
			{
				_FLD_装备_隐藏_AT = value;
			}
		}

		public int FLD_装备_追加_障力恢复量
		{
			get
			{
				return _FLD_装备_追加_障力恢复量;
			}
			set
			{
				_FLD_装备_追加_障力恢复量 = value;
			}
		}

		public int FLD_装备_追加_MP
		{
			get
			{
				return _FLD_装备_追加_MP;
			}
			set
			{
				_FLD_装备_追加_MP = value;
			}
		}

		public int FLD_装备_追加_障力
		{
			get
			{
				return _FLD_装备_追加_障力;
			}
			set
			{
				_FLD_装备_追加_障力 = value;
			}
		}

		public double FLD_装备_追加_升天一遁出逆境
		{
			get
			{
				return _FLD_装备_追加_升天一遁出逆境;
			}
			set
			{
				_FLD_装备_追加_升天一遁出逆境 = value;
			}
		}

		public double FLD_装备_追加_升天一破甲刺魂
		{
			get
			{
				return _FLD_装备_追加_升天一破甲刺魂;
			}
			set
			{
				_FLD_装备_追加_升天一破甲刺魂 = value;
			}
		}

		public double FLD_装备_追加_升天一绝影射魂
		{
			get
			{
				return _FLD_装备_追加_升天一绝影射魂;
			}
			set
			{
				_FLD_装备_追加_升天一绝影射魂 = value;
			}
		}

		public double FLD_装备_追加_升天三怒意之火
		{
			get
			{
				return _FLD_装备_追加_升天三怒意之火;
			}
			set
			{
				_FLD_装备_追加_升天三怒意之火 = value;
			}
		}

		public double FLD_装备_追加_升天一夜魔缠身
		{
			get
			{
				return _FLD_装备_追加_升天一夜魔缠身;
			}
			set
			{
				_FLD_装备_追加_升天一夜魔缠身 = value;
			}
		}

		public double FLD_装备_追加_升天一力劈华山
		{
			get
			{
				return _FLD_装备_追加_升天一力劈华山;
			}
			set
			{
				_FLD_装备_追加_升天一力劈华山 = value;
			}
		}

		public double FLD_装备_追加_升天一长虹贯日
		{
			get
			{
				return _FLD_装备_追加_升天一长虹贯日;
			}
			set
			{
				_FLD_装备_追加_升天一长虹贯日 = value;
			}
		}

		public double FLD_装备_追加_升天一金钟罡气
		{
			get
			{
				return _FLD_装备_追加_升天一金钟罡气;
			}
			set
			{
				_FLD_装备_追加_升天一金钟罡气 = value;
			}
		}

		public double FLD_装备_追加_升天一运气行心
		{
			get
			{
				return _FLD_装备_追加_升天一运气行心;
			}
			set
			{
				_FLD_装备_追加_升天一运气行心 = value;
			}
		}

		public double FLD_装备_追加_升天一正本培源
		{
			get
			{
				return _FLD_装备_追加_升天一正本培源;
			}
			set
			{
				_FLD_装备_追加_升天一正本培源 = value;
			}
		}

		public double FLD_装备_追加_升天一运气疗伤
		{
			get
			{
				return _FLD_装备_追加_升天一运气疗伤;
			}
			set
			{
				_FLD_装备_追加_升天一运气疗伤 = value;
			}
		}

		public double FLD_装备_追加_升天一百变神行
		{
			get
			{
				return _FLD_装备_追加_升天一百变神行;
			}
			set
			{
				_FLD_装备_追加_升天一百变神行 = value;
			}
		}

		public double FLD_装备_追加_升天一狂风天意
		{
			get
			{
				return _FLD_装备_追加_升天一狂风天意;
			}
			set
			{
				_FLD_装备_追加_升天一狂风天意 = value;
			}
		}

		public double FLD_装备_追加_升天一飞花点翠
		{
			get
			{
				return _FLD_装备_追加_升天一飞花点翠;
			}
			set
			{
				_FLD_装备_追加_升天一飞花点翠 = value;
			}
		}

		public double FLD_装备_追加_升天一行风弄舞
		{
			get
			{
				return _FLD_装备_追加_升天一行风弄舞;
			}
			set
			{
				_FLD_装备_追加_升天一行风弄舞 = value;
			}
		}

		public double FLD_装备_追加_升天二穷途末路
		{
			get
			{
				return _FLD_装备_追加_升天二穷途末路;
			}
			set
			{
				_FLD_装备_追加_升天二穷途末路 = value;
			}
		}

		public double FLD_装备_追加_升天三火龙之火
		{
			get
			{
				return _FLD_装备_追加_升天三火龙之火;
			}
			set
			{
				_FLD_装备_追加_升天三火龙之火 = value;
			}
		}

		public double FLD_装备_追加_升天二天地同寿
		{
			get
			{
				return _FLD_装备_追加_升天二天地同寿;
			}
			set
			{
				_FLD_装备_追加_升天二天地同寿 = value;
			}
		}

		public double FLD_装备_追加_升天一护身罡气
		{
			get
			{
				return _FLD_装备_追加_升天一护身罡气;
			}
			set
			{
				_FLD_装备_追加_升天一护身罡气 = value;
			}
		}

		public double FLD_装备_追加_升天二以退为进
		{
			get
			{
				return _FLD_装备_追加_升天二以退为进;
			}
			set
			{
				_FLD_装备_追加_升天二以退为进 = value;
			}
		}

		public double FLD_装备_追加_升天二千钧压驼
		{
			get
			{
				return _FLD_装备_追加_升天二千钧压驼;
			}
			set
			{
				_FLD_装备_追加_升天二千钧压驼 = value;
			}
		}

		public double FLD_装备_追加_升天二顺水推舟
		{
			get
			{
				return _FLD_装备_追加_升天二顺水推舟;
			}
			set
			{
				_FLD_装备_追加_升天二顺水推舟 = value;
			}
		}

		public double FLD_装备_追加_升天二三潭映月
		{
			get
			{
				return _FLD_装备_追加_升天二三潭映月;
			}
			set
			{
				_FLD_装备_追加_升天二三潭映月 = value;
			}
		}

		public double FLD_装备_追加_升天二天魔护体
		{
			get
			{
				return _FLD_装备_追加_升天二天魔护体;
			}
			set
			{
				_FLD_装备_追加_升天二天魔护体 = value;
			}
		}

		public double FLD_装备_追加_升天二万物回春
		{
			get
			{
				return _FLD_装备_追加_升天二万物回春;
			}
			set
			{
				_FLD_装备_追加_升天二万物回春 = value;
			}
		}

		public double FLD_装备_追加_升天一护身气甲
		{
			get
			{
				return _FLD_装备_追加_升天一护身气甲;
			}
			set
			{
				_FLD_装备_追加_升天一护身气甲 = value;
			}
		}

		public double FLD_装备_追加_升天三火凤临朝
		{
			get
			{
				return _FLD_装备_追加_升天三火凤临朝;
			}
			set
			{
				_FLD_装备_追加_升天三火凤临朝 = value;
			}
		}

		public double FLD_装备_追加_升天三天外三矢
		{
			get
			{
				return _FLD_装备_追加_升天三天外三矢;
			}
			set
			{
				_FLD_装备_追加_升天三天外三矢 = value;
			}
		}

		public double FLD_装备_追加_升天三无情打击
		{
			get
			{
				return _FLD_装备_追加_升天三无情打击;
			}
			set
			{
				_FLD_装备_追加_升天三无情打击 = value;
			}
		}

		public double FLD_装备_追加_升天三明镜止水
		{
			get
			{
				return _FLD_装备_追加_升天三明镜止水;
			}
			set
			{
				_FLD_装备_追加_升天三明镜止水 = value;
			}
		}

		public double FLD_装备_追加_升天三子夜秋歌
		{
			get
			{
				return _FLD_装备_追加_升天三子夜秋歌;
			}
			set
			{
				_FLD_装备_追加_升天三子夜秋歌 = value;
			}
		}

		public double FLD_装备_追加_升天三内息行心
		{
			get
			{
				return _FLD_装备_追加_升天三内息行心;
			}
			set
			{
				_FLD_装备_追加_升天三内息行心 = value;
			}
		}

		public double FLD_装备_追加_升天三以柔克刚
		{
			get
			{
				return _FLD_装备_追加_升天三以柔克刚;
			}
			set
			{
				_FLD_装备_追加_升天三以柔克刚 = value;
			}
		}

		public double FLD_装备_追加_升天四红月狂风
		{
			get
			{
				return _FLD_装备_追加_升天四红月狂风;
			}
			set
			{
				_FLD_装备_追加_升天四红月狂风 = value;
			}
		}

		public double FLD_装备_追加_升天四毒蛇出洞
		{
			get
			{
				return _FLD_装备_追加_升天四毒蛇出洞;
			}
			set
			{
				_FLD_装备_追加_升天四毒蛇出洞 = value;
			}
		}

		public double FLD_装备_追加_升天四满月狂风
		{
			get
			{
				return _FLD_装备_追加_升天四满月狂风;
			}
			set
			{
				_FLD_装备_追加_升天四满月狂风 = value;
			}
		}

		public double FLD_装备_追加_升天四烈日炎炎
		{
			get
			{
				return _FLD_装备_追加_升天四烈日炎炎;
			}
			set
			{
				_FLD_装备_追加_升天四烈日炎炎 = value;
			}
		}

		public double FLD_装备_追加_升天四长虹贯天
		{
			get
			{
				return _FLD_装备_追加_升天四长虹贯天;
			}
			set
			{
				_FLD_装备_追加_升天四长虹贯天 = value;
			}
		}

		public double FLD_装备_追加_升天四哀鸿遍野
		{
			get
			{
				return _FLD_装备_追加_升天四哀鸿遍野;
			}
			set
			{
				_FLD_装备_追加_升天四哀鸿遍野 = value;
			}
		}

		public double FLD_装备_追加_升天一夺命连环
		{
			get
			{
				return _FLD_装备_追加_升天一夺命连环;
			}
			set
			{
				_FLD_装备_追加_升天一夺命连环 = value;
			}
		}

		public double FLD_装备_追加_升天一电光石火
		{
			get
			{
				return _FLD_装备_追加_升天一电光石火;
			}
			set
			{
				_FLD_装备_追加_升天一电光石火 = value;
			}
		}

		public double FLD_装备_追加_升天一精益求精
		{
			get
			{
				return _FLD_装备_追加_升天一精益求精;
			}
			set
			{
				_FLD_装备_追加_升天一精益求精 = value;
			}
		}

		public double FLD_装备_追加_升天四望梅添花
		{
			get
			{
				return _FLD_装备_追加_升天四望梅添花;
			}
			set
			{
				_FLD_装备_追加_升天四望梅添花 = value;
			}
		}

		public double FLD_装备_追加_升天四悬丝诊脉
		{
			get
			{
				return _FLD_装备_追加_升天四悬丝诊脉;
			}
			set
			{
				_FLD_装备_追加_升天四悬丝诊脉 = value;
			}
		}

		public double FLD_装备_追加_升天五惊天动地
		{
			get
			{
				return _FLD_装备_追加_升天五惊天动地;
			}
			set
			{
				_FLD_装备_追加_升天五惊天动地 = value;
			}
		}

		public double FLD_装备_追加_升天一玄武雷电
		{
			get
			{
				return _FLD_装备_追加_升天一玄武雷电;
			}
			set
			{
				_FLD_装备_追加_升天一玄武雷电 = value;
			}
		}

		public double FLD_装备_追加_升天一陵劲淬砺
		{
			get
			{
				return _FLD_装备_追加_升天一陵劲淬砺;
			}
			set
			{
				_FLD_装备_追加_升天一陵劲淬砺 = value;
			}
		}

		public double FLD_装备_追加_升天一愤怒调节
		{
			get
			{
				return _FLD_装备_追加_升天一愤怒调节;
			}
			set
			{
				_FLD_装备_追加_升天一愤怒调节 = value;
			}
		}

		public double FLD_装备_追加_升天二玄武诅咒
		{
			get
			{
				return _FLD_装备_追加_升天二玄武诅咒;
			}
			set
			{
				_FLD_装备_追加_升天二玄武诅咒 = value;
			}
		}

		public double FLD_装备_追加_升天二杀星光符
		{
			get
			{
				return _FLD_装备_追加_升天二杀星光符;
			}
			set
			{
				_FLD_装备_追加_升天二杀星光符 = value;
			}
		}

		public double FLD_装备_追加_升天二蛊毒解除
		{
			get
			{
				return _FLD_装备_追加_升天二蛊毒解除;
			}
			set
			{
				_FLD_装备_追加_升天二蛊毒解除 = value;
			}
		}

		public double FLD_装备_追加_升天三杀人鬼
		{
			get
			{
				return _FLD_装备_追加_升天三杀人鬼;
			}
			set
			{
				_FLD_装备_追加_升天三杀人鬼 = value;
			}
		}

		public double FLD_装备_追加_升天三技冠群雄
		{
			get
			{
				return _FLD_装备_追加_升天三技冠群雄;
			}
			set
			{
				_FLD_装备_追加_升天三技冠群雄 = value;
			}
		}

		public double FLD_装备_追加_升天三神力保护
		{
			get
			{
				return _FLD_装备_追加_升天三神力保护;
			}
			set
			{
				_FLD_装备_追加_升天三神力保护 = value;
			}
		}

		public double FLD_装备_追加_升天五致残
		{
			get
			{
				return _FLD_装备_追加_升天五致残;
			}
			set
			{
				_FLD_装备_追加_升天五致残 = value;
			}
		}

		public double FLD_装备_追加_升天五龙魂附体
		{
			get
			{
				return _FLD_装备_追加_升天五龙魂附体;
			}
			set
			{
				_FLD_装备_追加_升天五龙魂附体 = value;
			}
		}

		public double FLD_装备_追加_升天五灭世狂舞
		{
			get
			{
				return _FLD_装备_追加_升天五灭世狂舞;
			}
			set
			{
				_FLD_装备_追加_升天五灭世狂舞 = value;
			}
		}

		public double FLD_装备_追加_升天五千里一击
		{
			get
			{
				return _FLD_装备_追加_升天五千里一击;
			}
			set
			{
				_FLD_装备_追加_升天五千里一击 = value;
			}
		}

		public double FLD_装备_追加_升天五形移妖相
		{
			get
			{
				return _FLD_装备_追加_升天五形移妖相;
			}
			set
			{
				_FLD_装备_追加_升天五形移妖相 = value;
			}
		}

		public double FLD_装备_追加_升天五一招杀神
		{
			get
			{
				return _FLD_装备_追加_升天五一招杀神;
			}
			set
			{
				_FLD_装备_追加_升天五一招杀神 = value;
			}
		}

		public double FLD_装备_追加_升天五龙爪纤指手
		{
			get
			{
				return _FLD_装备_追加_升天五龙爪纤指手;
			}
			set
			{
				_FLD_装备_追加_升天五龙爪纤指手 = value;
			}
		}

		public double FLD_装备_追加_升天五不死之躯
		{
			get
			{
				return _FLD_装备_追加_升天五不死之躯;
			}
			set
			{
				_FLD_装备_追加_升天五不死之躯 = value;
			}
		}

		public double FLD_装备_追加_升天五天魔之力
		{
			get
			{
				return _FLD_装备_追加_升天五天魔之力;
			}
			set
			{
				_FLD_装备_追加_升天五天魔之力 = value;
			}
		}

		public double FLD_装备_追加_升天五惊涛骇浪
		{
			get
			{
				return _FLD_装备_追加_升天五惊涛骇浪;
			}
			set
			{
				_FLD_装备_追加_升天五惊涛骇浪 = value;
			}
		}

		public double FLD_装备_追加_升天五魔魂之力
		{
			get
			{
				return _FLD_装备_追加_升天五魔魂之力;
			}
			set
			{
				_FLD_装备_追加_升天五魔魂之力 = value;
			}
		}

		public double FLD_装备_追加_升天五破空坠星
		{
			get
			{
				return _FLD_装备_追加_升天五破空坠星;
			}
			set
			{
				_FLD_装备_追加_升天五破空坠星 = value;
			}
		}

		public double FLD_装备_追加_升天五尸毒爆发
		{
			get
			{
				return _FLD_装备_追加_升天五尸毒爆发;
			}
			set
			{
				_FLD_装备_追加_升天五尸毒爆发 = value;
			}
		}

		public int FLD_装备_追加_心
		{
			get
			{
				return _FLD_装备_追加_心;
			}
			set
			{
				_FLD_装备_追加_心 = value;
			}
		}

		public int FLD_装备_追加_体
		{
			get
			{
				return _FLD_装备_追加_体;
			}
			set
			{
				_FLD_装备_追加_体 = value;
			}
		}

		public int FLD_装备_追加_力
		{
			get
			{
				return _FLD_装备_追加_力;
			}
			set
			{
				_FLD_装备_追加_力 = value;
			}
		}

		public int FLD_装备_追加_身
		{
			get
			{
				return _FLD_装备_追加_身;
			}
			set
			{
				_FLD_装备_追加_身 = value;
			}
		}

		public int FLD_装备_追加_觉醒
		{
			get
			{
				return _FLD_装备_追加_觉醒;
			}
			set
			{
				_FLD_装备_追加_觉醒 = value;
			}
		}

		public int FLD_装备_追加_罡气
		{
			get
			{
				return _FLD_装备_追加_罡气;
			}
			set
			{
				_FLD_装备_追加_罡气 = value;
			}
		}

		public void Clear()
		{
			打坐 = false;
			打坐打怪 = false;
			人物PK模式 = 0;
			自动挂机坐标X = 0;
			自动挂机坐标Y = 0;
			自动挂机地图 = 101;
			离线挂机打怪模式 = 0;
			假人是否开商店 = 0;
			离线打架模式 = 0;
			追加项链属性 = 0;
			云挂机模式 = 0;
			云挂机踢号 = false;
			江湖小助手打怪模式 = 0;
			自动说话 = string.Empty;
			传书杀人名 = string.Empty;
			离线挂机武功ID = 0;
			江湖小助手武功ID = 0;
			离线打架武功ID = 0;
			是否拒绝势力战 = 0;
			在线挂机打怪时间 = DateTime.Now;
			离线挂机打怪时间 = DateTime.Now;
			自动存仓库时间 = DateTime.Now;
			技能释放间隔 = DateTime.Now;
			飞行模式 = 0;
			当前杀怪数量 = 0;
			变身id = 0;
			触发属性提升 = 0;
			触发鸾凤和鸣 = false;
			触发神女传染 = false;
			神女怒 = false;
			Player无敌 = false;
			PK死亡 = false;
			跑走 = false;
			是否更新配置 = false;
			上线 = false;
			触发地图移动事件 = false;
			装备追加对怪防御 = 0;
			装备追加对怪攻击 = 0;
			药品追加对怪防御 = 0;
			药品追加对怪攻击 = 0;
			是否拒绝仙魔大战 = 0;
			FLD_药品_追加_气功 = 0;
			武器攻击力 = 0;
			武器武功攻击力百分比 = 0.0;
			衣服防御力 = 0;
			衣服武功防御力百分比 = 0.0;
			交易人物ID = 0;
			交易操作ID = 0;
			商店名 = string.Empty;
			安全码操作ID = -1;
			安全码是否通过验证 = false;
			是否已婚 = 0;
			证婚人提问答案 = 2;
			解除关系倒计时 = 0;
			人物_战斗增加_HP = 0;
			人物_战斗增加_MP = 0;
			婚戒刻字 = string.Empty;
			荣誉ID_ = 0;
			是否携带披风行囊 = false;
			怒 = false;
			中毒 = false;
			新武功连击 = new List<武功类>();
			AtTimerElapsed = new 攻击确认类();
			SerList = new ConcurrentDictionary<int, ServerList>(1, 12);
			特殊药品 = new ConcurrentDictionary<int, 特殊药品类>();
			时间药品 = new ConcurrentDictionary<int, 时间药品类>();
			刺客发起技能加成 = false;
			触发物理无明暗矢 = false;
			触发魔法无明暗矢 = false;
			触发弓箭致命绝杀 = false;
			刺客物理攻击加成 = 0.0;
			刺客魔法攻击加成 = 0.0;
			升天气功武功等级 = 0.0;
			每日获得武勋 = 0;
			最大精力 = 200;
			恢复精力 = 0;
			IsRanked = 0;
			丢失武勋 = 0;
			PVP分数 = 0;
			PVP逃跑次数 = 0;
			lastX = 0f;
			lastY = 0f;
			lastMAP = 101;
			AttackX = 0f;
			AttackY = 0f;
			攻击次数 = 0;
			死亡不复活计时 = 0;
			报错次数阀值 = 0;
			表情次数阀值 = 0;
			心跳次数阀值 = 3;
			修炼地图剩余时间 = 0;
			活动地图剩余时间 = 0;
			FBtime = DateTime.Now;
			PKhmtime = DateTime.Now;
			XThmtime = DateTime.Now;
			TMJCtime = DateTime.Now;
			CWhmtime = DateTime.Now;
			SThmtime = DateTime.Now;
			CJhmtime = DateTime.Now;
			凝神宝珠位置 = -1;
			FLD_宠物_追加_攻击 = 0;
			FLD_宠物_追加_防御 = 0;
			FLD_宠物_追加_最大HP = 0;
			弓群攻触发心神 = false;
			韩飞官_天魔狂血攻击力 = 0.0;
			韩飞官_天魔狂血叠加次数 = 0;
			FLD_爱情度等级 = 0;
			FLD_是否可以送花 = true;
			当前操作类型 = 0;
			人物锁定 = false;
			锁定人物几率 = 0;
			FLD_夫妻辅助_追加_防具_属性 = 0;
			FLD_夫妻辅助_追加_武器_属性 = 0;
			FLD_结婚礼物_追加_属性石 = 0;
			拳师连击控制 = 0;
			拳师会心一击威力 = 0.3;
			解除师徒关系时间 = DateTime.Parse("2012/12/12 12:12:12");
			武皇通币 = 0;
			当前操作NPC = 0;
			天地同寿回避次数 = 0;
			天地同寿回避累积攻击力 = 0;
			FLD_荣誉ID = 0;
			武林杀人数 = 0;
			仙魔大战杀人数 = 0;
			仙魔大战死亡数 = 0;
			琴师状态 = 0;
			base.琴_三和弦_状态效果 = 0.0;
			base.琴_七和弦_状态效果 = 0.0;
			base.琴_九和弦_状态效果 = 0.0;
			元宝账户状态 = false;
			FLD_PVP_Piont = 0;
			当前激活技能ID = 0;
			玉连环 = new List<int>();
			装备数据版本 = 1;
			综合仓库装备数据版本 = 1;
			退出中 = false;
			存档时间 = false;
			妖花青草 = false;
			武功新 = new 武功类[4, 32];
			夫妻武功攻击力 = 0;
			夫妻武功攻击力MP = 0;
			追加状态列表 = new ThreadSafeDictionary<int, 追加状态类>();
			追加状态New列表 = new ThreadSafeDictionary<int, 追加状态New类>();
			公有药品 = new ConcurrentDictionary<int, 公有药品类>();
			称号药品 = new ConcurrentDictionary<int, 称号药品类>();
			任务 = new ConcurrentDictionary<int, 任务类>();
			已完成任务 = new ConcurrentDictionary<int, int>();
			客户端设置 = string.Empty;
			师傅数据 = new 师徒类();
			徒弟数据 = new 师徒类[3];
			武功新 = new 武功类[4, 32];
			异常状态 = new ThreadSafeDictionary<int, 异常状态类>();
			神女异常状态 = new ThreadSafeDictionary<int, 神女异常状态类>();
			装备栏包裹 = new 物品类[96];
			披风行囊 = new 物品类[66];
			宝珠装备栏装备 = new 物品类[15];
			装备栏已穿装备 = new 物品类[17];
			辅助装备栏装备 = new 物品类[15];
			凝神珠包裹 = new 物品类[6];
			行囊包裹 = new 物品类[3];
			杂货行囊包裹 = new 物品类[24];
			气功 = new 气功类[15];
			个人仓库 = new 物品类[60];
			公共仓库 = new 物品类[60];
			灵宠仓库 = new 物品类[20];
			灵兽仓库 = new 物品类[2];
			任务物品 = new 任务物品类[36];
			升天气功 = new SortedDictionary<int, 升天气功类>();
			FLD_追加哀鸿片野_HP上限 = 0.0;
			人物追加最大_HP = 0;
			人物追加最大_MP = 0;
			人物_气功_追加_百分比MP = 0.0;
			人物_气功_追加_武功防御力 = 0;
			人物基本最大_HP = 0;
			FLD_装备_追加_HP = 0;
			FLD_装备_追加_障力恢复量 = 0;
			人物_气功_追加_HP = 0;
			人物基本最大_MP = 0;
			人物基本最大_障力 = 0;
			FLD_装备_追加_MP = 0;
			FLD_装备_隐藏_HP = 0;
			FLD_装备_隐藏_DF = 0;
			FLD_装备_隐藏_AT = 0;
			人物_气功_追加_MP = 0;
			比武追加经验值 = 0.0;
			人物_AP = 0;
			帮派门徽 = null;
			追加状态物品New = null;
			帮派人物等级 = 0;
			帮派名字 = string.Empty;
			帮派Id = 0;
			帮派等级 = 0;
			FLD_追加百分比_攻击 = 0.0;
			FLD_追加百分比_防御 = 0.0;
			FLD_追加百分比_命中 = 0.0;
			FLD_人物_追加百分比_回避 = 0.0;
			FLD_追加百分比_HP上限 = 0.0;
			FLD_追加百分比_MP上限 = 0.0;
			FLD_人物_武功攻击力增加百分比 = 0.0;
			FLD_人物_武功防御力增加百分比 = 0.0;
			最小攻击 = 0.0;
			FLD_药品_减少攻击 = 0.0;
			FLD_药品_减少防御 = 0.0;
			人物追加战力 = 0;
			人物追加武勋战力 = 0;
			称号追加战斗力 = 0;
			玫瑰追加战斗力 = 0;
			前十追加战斗力 = 0;
			称号追加HP = 0;
			称号追加攻击 = 0;
			称号追加防御 = 0;
			门派称号追加HP = 0;
			门派称号追加攻击 = 0;
			门派称号追加防御 = 0;
			玫瑰称号追加HP = 0;
			玫瑰称号追加攻击 = 0;
			玫瑰称号追加防御 = 0;
			FLD_人物_追加_攻击 = 0;
			FLD_人物_追加_防御 = 0;
			FLD_神女_追加_防御 = 0;
			FLD_神女_追加_攻击 = 0;
			FLD_人物_追加_命中 = 0;
			FLD_人物_追加_回避 = 0;
			FLD_人物_追加_气功 = 0;
			药品减免对方伤害 = 0;
			药品_追加_首饰_强化 = 0;
			FLD_人物_追加_贩卖价格百分比 = 0.0;
			FLD_人物_追加_武勋获得量百分比 = 0.0;
			FLD_人物_追加_吸魂几率百分比 = 0.0;
			FLD_人物_追加_合成成功率百分比 = 0.0;
			FLD_人物_追加_获得游戏币百分比 = 0.0;
			FLD_人物_追加_经验百分比 = 0.0;
			FLD_宠物_追加_经验百分比 = 0.0;
			FLD_人物_追加_物品掉落概率百分比 = 0.0;
			FLD_人物_追加_历练百分比 = 0.0;
			FLD_人物_追加_武功防御力 = 0.0;
			FLD_装备_追加_升天二万物回春 = 0.0;
			FLD_装备_追加_升天二千钧压驼 = 0.0;
			FLD_装备_追加_升天二穷途末路 = 0.0;
			FLD_装备_追加_升天三火龙之火 = 0.0;
			FLD_装备_追加_升天一护身罡气 = 0.0;
			FLD_装备_追加_升天一护身气甲 = 0.0;
			FLD_装备_追加_升天三怒意之火 = 0.0;
			FLD_装备_追加_升天二三潭映月 = 0.0;
			FLD_装备_追加_升天二顺水推舟 = 0.0;
			FLD_装备_追加_升天二天地同寿 = 0.0;
			FLD_装备_追加_升天二天魔护体 = 0.0;
			FLD_装备_追加_升天二以退为进 = 0.0;
			FLD_装备_追加_升天三火凤临朝 = 0.0;
			FLD_装备_追加_升天三明镜止水 = 0.0;
			FLD_装备_追加_升天三内息行心 = 0.0;
			FLD_装备_追加_升天三无情打击 = 0.0;
			FLD_装备_追加_升天三天外三矢 = 0.0;
			FLD_装备_追加_升天三以柔克刚 = 0.0;
			FLD_装备_追加_升天三子夜秋歌 = 0.0;
			FLD_装备_追加_升天四哀鸿遍野 = 0.0;
			FLD_装备_追加_升天四毒蛇出洞 = 0.0;
			FLD_装备_追加_升天四红月狂风 = 0.0;
			FLD_装备_追加_升天四烈日炎炎 = 0.0;
			FLD_装备_追加_升天四满月狂风 = 0.0;
			FLD_装备_追加_升天四望梅添花 = 0.0;
			FLD_装备_追加_升天四悬丝诊脉 = 0.0;
			FLD_装备_追加_升天四长虹贯天 = 0.0;
			FLD_装备_追加_升天一百变神行 = 0.0;
			FLD_装备_追加_升天一遁出逆境 = 0.0;
			FLD_装备_追加_升天一飞花点翠 = 0.0;
			FLD_装备_追加_升天一行风弄舞 = 0.0;
			FLD_装备_追加_升天一金钟罡气 = 0.0;
			FLD_装备_追加_升天一绝影射魂 = 0.0;
			FLD_装备_追加_升天一狂风天意 = 0.0;
			FLD_装备_追加_升天一力劈华山 = 0.0;
			FLD_装备_追加_升天一破甲刺魂 = 0.0;
			FLD_装备_追加_升天一夜魔缠身 = 0.0;
			FLD_装备_追加_升天一运气行心 = 0.0;
			FLD_装备_追加_升天一运气疗伤 = 0.0;
			FLD_装备_追加_升天一长虹贯日 = 0.0;
			FLD_装备_追加_升天一正本培源 = 0.0;
			FLD_装备_追加_升天一夺命连环 = 0.0;
			FLD_装备_追加_升天一电光石火 = 0.0;
			FLD_装备_追加_升天一精益求精 = 0.0;
			FLD_装备_追加_升天五惊天动地 = 0.0;
			FLD_装备_追加_升天一玄武雷电 = 0.0;
			FLD_装备_追加_升天一陵劲淬砺 = 0.0;
			FLD_装备_追加_升天一愤怒调节 = 0.0;
			FLD_装备_追加_升天二玄武诅咒 = 0.0;
			FLD_装备_追加_升天二杀星光符 = 0.0;
			FLD_装备_追加_升天二蛊毒解除 = 0.0;
			FLD_装备_追加_升天三杀人鬼 = 0.0;
			FLD_装备_追加_升天三技冠群雄 = 0.0;
			FLD_装备_追加_升天三神力保护 = 0.0;
			FLD_装备_追加_升天五致残 = 0.0;
			FLD_装备_追加_升天五龙魂附体 = 0.0;
			FLD_装备_追加_升天五灭世狂舞 = 0.0;
			FLD_装备_追加_升天五千里一击 = 0.0;
			FLD_装备_追加_升天五形移妖相 = 0.0;
			FLD_装备_追加_升天五一招杀神 = 0.0;
			FLD_装备_追加_升天五龙爪纤指手 = 0.0;
			FLD_装备_追加_升天五不死之躯 = 0.0;
			FLD_装备_追加_升天五天魔之力 = 0.0;
			FLD_装备_追加_升天五惊涛骇浪 = 0.0;
			FLD_装备_追加_升天五魔魂之力 = 0.0;
			FLD_装备_追加_升天五破空坠星 = 0.0;
			FLD_装备_追加_升天五尸毒爆发 = 0.0;
			FLD_装备_追加_合成成功率百分比 = 0.0;
			FLD_装备_追加_获得游戏币百分比 = 0.0;
			FLD_装备_武功攻击力增加百分比 = 0.0;
			FLD_装备_武功防御力 = 0.0;
			FLD_装备_武功防御力增加百分比 = 0.0;
			FLD_装备_追加_降低百分比攻击 = 0.0;
			FLD_装备_追加_降低百分比防御 = 0.0;
			FLD_装备_追加_命中百分比 = 0.0;
			FLD_装备_追加_回避百分比 = 0.0;
			FLD_装备_追加_愤怒 = 0;
			FLD_装备_追加_初始化愤怒概率百分比 = 0.0;
			FLD_装备_追加_中毒概率百分比 = 0.0;
			FLD_装备_降低_伤害值 = 0.0;
			FLD_装备_追加_伤害值 = 0;
			FLD_装备_追加_攻击 = 0;
			FLD_装备_追加_障力 = 0;
			FLD_装备_追加_防御 = 0;
			FLD_装备_追加_命中 = 0;
			FLD_装备_追加_回避 = 0;
			FLD_装备_追加_气功 = 0;
			FLD_装备_追加_防具_强化 = 0;
			FLD_装备_追加_武器_强化 = 0;
			FLD_项链_追加_防具_强化 = 0;
			FLD_项链_追加_武器_强化 = 0;
			FLD_装备_追加_经验百分比 = 0.0;
			LS_降低_暴率百分比 = 0.0;
			LS_降低_经验百分比 = 0.0;
			LS_降低_金钱百分比 = 0.0;
			LS_降低_历练百分比 = 0.0;
			FLD_装备_追加_死亡损失经验减少 = 0.0;
			FLD_装备_追加_心 = 0;
			FLD_装备_追加_体 = 0;
			FLD_装备_追加_力 = 0;
			FLD_装备_追加_身 = 0;
			FLD_装备_追加_觉醒 = 0;
			FLD_装备_追加_气功_0 = 0.0;
			FLD_装备_追加_气功_1 = 0.0;
			FLD_装备_追加_气功_2 = 0.0;
			FLD_装备_追加_气功_3 = 0.0;
			FLD_装备_追加_气功_4 = 0.0;
			FLD_装备_追加_气功_5 = 0.0;
			FLD_装备_追加_气功_6 = 0.0;
			FLD_装备_追加_气功_7 = 0.0;
			FLD_装备_追加_气功_8 = 0.0;
			FLD_装备_追加_气功_9 = 0.0;
			FLD_装备_追加_气功_10 = 0.0;
			FLD_装备_追加_气功_11 = 0.0;
			FLD_结婚纪念日 = DateTime.Now;
			FLD_灵宠_追加_经验百分比 = 0.0;
			医生群疗_追加_经验百分比 = 0.0;
			医生群疗_追加_爆率 = 0;
			base.韩_天魔狂血 = 0.0;
			base.韩_追骨吸元 = 0.0;
			base.韩_火龙问鼎 = 0.0;
			base.刀_连环飞舞 = 0.0;
			base.刀_升天三气功_火龙之火 = 0.0;
			base.剑_破天一剑 = 0.0;
			base.枪_升天三气功_怒意之火 = 0.0;
			base.致命一击几率 = 0.0;
			base.谭_招式新法 = 0.0;
			base.怪反伤几率 = 0.0;
			base.人反伤几率 = 0.0;
			base.破甲几率 = 0.0;
			base.气沉丹田 = 0.0;
			base.真武绝击 = 0.0;
			base.暗影绝杀 = 0.0;
			base.流光乱舞 = 0.0;
			base.剑_升天一气功_护身罡气 = 0.0;
			base.剑_移花接木 = 0.0;
			base.剑_回柳身法 = 0.0;
			base.剑_怒海狂澜 = 0.0;
			base.剑_冲冠一怒 = 0.0;
			base.剑_无坚不摧 = 0.0;
			base.枪_运气疗伤 = 0.0;
			base.枪_灵甲护身 = 0.0;
			base.枪_乾坤挪移 = 0.0;
			base.枪_狂神降世 = 0.0;
			base.枪_转攻为守 = 0.0;
			base.卢_转攻为守 = 0.0;
			base.枪_末日狂舞 = 0.0;
			base.弓_锐利之箭 = 0.0;
			base.弓_猎鹰之眼 = 0.0;
			base.弓_无明暗矢 = 0.0;
			base.弓_回流真气 = 0.0;
			base.弓_流星三矢 = 0.0;
			base.弓_流星三矢时间 = 0.0;
			base.弓_流星三矢概率 = 0.0;
			base.弓_致命绝杀 = 0.0;
			base.弓_心神凝聚 = 0.0;
			base.医_运气疗心 = 0.0;
			base.医_长攻击力 = 0.0;
			base.医_太极心法 = 0.0;
			base.医_妙手回春 = 0.0;
			base.医_神农仙术 = 0.0;
			base.医_九天真气 = 0.0;
			base.医_升天二气功_万物回春 = 0.0;
			base.医_吸星大法 = 0.0;
			base.刺_荆轲之怒 = 0.0;
			base.刺_三花聚顶 = 0.0;
			base.刺_连环飞舞 = 0.0;
			base.刺_必杀一击 = 0.0;
			base.刺_心神凝聚 = 0.0;
			base.刺_致手绝命 = 0.0;
			base.刺_先发制人 = 0.0;
			base.刺_千蛛万手 = 0.0;
			base.刺_连消带打 = 0.0;
			base.刺_剑刃乱舞 = 0.0;
			base.刺_一招残杀 = 0.0;
			base.刺_升天三气功_无情打击 = 0.0;
			base.琴师_高山流水 = 0.0;
			base.琴师_汉宫秋月 = 0.0;
			base.琴师_鸾凤和鸣 = 0.0;
			base.琴师_梅花三弄 = 0.0;
			base.琴师_清心普善 = 0.0;
			base.琴师_秋江夜泊 = 0.0;
			base.琴师_潇湘雨夜 = 0.0;
			base.琴师_阳关三叠 = 0.0;
			base.琴师_阳明春晓 = 0.0;
			base.琴师_岳阳三醉 = 0.0;
			base.琴师_战马奔腾 = 0.0;
			base.琴师_三和弦_发动概率 = 0.0;
			base.谭_冲冠一怒 = 0.0;
			base.谭_怒海狂澜 = 0.0;
			base.谭_回柳身法 = 0.0;
			base.谭_纵横无双 = 0.0;
			base.谭_移花接木 = 0.0;
			base.谭_护身罡气 = 0.0;
			base.谭_连环飞舞 = 0.0;
			base.韩_升天一气功_行风弄舞 = 0.0;
			base.韩_升天二气功_天魔护体 = 0.0;
			base.韩_升天二气功_内息行心 = 0.0;
			base.刀_升天一气功_遁出逆境 = 0.0;
			base.剑_乘胜追击 = 0.0;
			base.枪_升天一气功_破甲刺魂 = 0.0;
			base.弓_升天一气功_绝影射魂 = 0.0;
			base.医_狂意护体 = 0.0;
			base.医_升天一气功_护身气甲 = 0.0;
			base.刺_升天一气功_夜魔缠身 = 0.0;
			base.升天一气功_力劈华山 = 0.0;
			base.升天一气功_长虹贯日 = 0.0;
			base.升天一气功_金钟罡气 = 0.0;
			base.升天一气功_运气行心 = 0.0;
			base.升天一气功_正本培源 = 0.0;
			base.升天一气功_运气疗伤 = 0.0;
			base.升天一气功_百变神行 = 0.0;
			base.升天一气功_狂风天意 = 0.0;
			base.刀_升天二气功_穷途末路 = 0.0;
			base.剑_升天二气功_天地同寿 = 0.0;
			base.枪_升天二气功_以退为进 = 0.0;
			base.弓_升天二气功_千钧压驼 = 0.0;
			base.医_无中生有 = 0.0;
			base.刺_升天二气功_顺水推舟 = 0.0;
			base.琴师_升天一气功_飞花点翠 = 0.0;
			base.琴师_升天二气功_三潭映月 = 0.0;
			base.琴师_升天三气功_子夜秋歌 = 0.0;
			base.刺_以怒还怒 = 0.0;
			base.刀_梵音破镜 = 0.0;
			base.剑_升天三气功_火凤临朝 = 0.0;
			base.枪_怒意之吼 = 0.0;
			base.弓_升天三气功_天外三矢 = 0.0;
			base.医_升天三气功_明镜止水 = 0.0;
			base.谭_升天三气功_以柔克刚 = 0.0;
			base.谭_升天三气功_火凤临朝 = 0.0;
			base.谭_升天二气功_天地同寿 = 0.0;
			base.谭_升天二气功_纵横无双 = 0.0;
			base.谭_升天一气功_怒海狂澜 = 0.0;
			base.全职业气功防御 = 10.0;
			base.大魔神添加全职业气功防御几率 = 0.0;
			base.升天四式_红月狂风 = 0.0;
			base.升天四式_毒蛇出洞 = 0.0;
			base.升天四式_满月狂风 = 0.0;
			base.升天四式_烈日炎炎 = 0.0;
			base.升天四式_望梅添花 = 0.0;
			base.升天四式_悬丝诊脉 = 0.0;
			base.升天四式_长虹贯天 = 0.0;
			base.升天四式_哀鸿遍野 = 0.0;
			base.升天五式_致残 = 0.0;
			base.刀画龙点睛 = 0.0;
			base.剑百毒不侵 = 0.0;
			base.枪寒冰领域 = 0.0;
			base.弓恶尽矢穷 = 0.0;
			base.医生云心月性 = 0.0;
			base.刺客外刚内刚 = 0.0;
			base.乐师血脉上升 = 0.0;
			base.韩飞官真气还原 = 0.0;
			base.谭花灵电光朝露 = 0.0;
			base.格斗家无障无碍 = 0.0;
			base.梅柳真化险为夷 = 0.0;
			base.卢风郎反弹无效 = 0.0;
			base.神女抗击身法 = 0.0;
			base.血气方刚 = 0.0;
			base.精金百炼 = 0.0;
			base.减少罡气 = 0.0;
			base.减少攻击 = 0.0;
			base.升天五式_破空坠星 = 0.0;
			base.升天五式_魔魂之力 = 0.0;
			base.升天五式_不死之躯 = 0.0;
			base.升天五式_惊涛骇浪 = 0.0;
			base.升天五式_天魔之力 = 0.0;
			base.升天五式_龙爪纤指手 = 0.0;
			base.升天五式_一招杀神 = 0.0;
			base.升天五式_形移妖相 = 0.0;
			base.升天五式_千里一击 = 0.0;
			base.升天五式_灭世狂舞 = 0.0;
			base.升天五式_惊天动地 = 0.0;
			base.升天五式_龙魂附体 = 0.0;
			base.升天一式_陵劲淬砺 = 0.0;
			base.升天二式_杀星光符 = 0.0;
			base.升天三式_技冠群雄 = 0.0;
			人物_WX_BUFF_生命 = 0;
			人物_WX_BUFF_攻击 = 0;
			人物_WX_BUFF_防御 = 0;
			人物_WX_BUFF_回避 = 0;
			人物_WX_BUFF_内功 = 0;
			人物_WX_BUFF_命中 = 0;
			人物_WX_BUFF_气功 = 0;
			base.狂风万破 = 0.0;
			上河调计数 = 0;
			下河调计数 = 0;
			玉连环计数 = 0;
			FLD_攻击速度 = 100;
			潜行模式 = 0;
			爆毒状态 = 0.0;
			刺_连消带打数量 = 0.0;
			关起来 = 0;
			升天武功点数 = 0;
			升天历练数 = 0;
			升天历练当前获得数 = 0;
			base.流星漫天 = 0.0;
			base.弱点攻破 = 0.0;
			base.牢不可破 = 0.0;
			base.陵劲淬砺 = 0.0;
			base.卢_破血狂风 = 0.0;
			base.技冠群雄 = 0.0;
			base.神女杀星义虎 = 10.0;
			base.神女杀星义杀 = 10.0;
			base.神女运气行心 = 0.0;
			base.神女太极心法 = 0.0;
			base.神女神力激发 = 0.0;
			base.神女杀星义气 = 0.0;
			base.神女洗髓易筋 = 0.0;
			base.神女黑花漫开 = 0.0;
			base.神女长功击力 = 0.0;
			base.神女黑花集中 = 0.0;
			base.神女真武绝击 = 0.0;
			base.神女万毒不侵 = 0.0;
			base.神女愤怒调节 = 0.0;
			base.神女蛊毒解除 = 0.0;
			base.神女神力保护 = 0.0;
			base.神女尸毒爆发 = 0.0;
			base.神女神力激发对怪防御力 = 0.0;
			自动挂机坐标X = 0;
			自动挂机坐标Y = 0;
			离线挂机当前攻击怪物 = 0;
			离线自动打怪 = 0;
			假人死亡次数 = 0;
			假人反击怪index = 0;
			假人组队坐标X = 0f;
			假人组队坐标Y = 0f;
			假人组队坐标地图 = 0;
			假人移动出错纠正 = 0;
			假人被人物击杀多次开启安全模式 = 0;
			假人结婚是否成败 = 0;
			假人是否参与世界排行boss = 0;
			假人是否参与势力战 = 0;
			假人势力战反击index = 0;
			假人结婚是否成败 = 0;
			离线假人卡技能次数 = 0;
			假人boss排行是否发呆 = 0;
			离线打架攻击人物 = 0;
			假人势力战失去人物全服ID = 0;
			假人反击PKindex = 0;
			假人反击PK发呆 = 0;
			加入帮派成败 = 0;
			假人发呆超时计时器 = 0;
		}

		~PlayersBes()
		{
		}

		public PlayersBes(NetState client)
		{
			触发鸾凤和鸣 = false;
			Player无敌 = false;
			PK死亡 = false;
			跑走 = false;
			触发地图移动事件 = false;
			是否更新配置 = false;
			上线 = false;
			装备追加对怪防御 = 0;
			装备追加对怪攻击 = 0;
			武器攻击力 = 0;
			武器武功攻击力百分比 = 0.0;
			衣服防御力 = 0;
			衣服武功防御力百分比 = 0.0;
			交易人物ID = 0;
			交易操作ID = 0;
			商店名 = string.Empty;
			安全码操作ID = 0;
			安全码是否通过验证 = false;
			是否已婚 = 0;
			证婚人提问答案 = 2;
			解除关系倒计时 = 0;
			人物_战斗增加_HP = 0;
			人物_战斗增加_MP = 0;
			婚戒刻字 = string.Empty;
			客户端设置 = string.Empty;
			荣誉ID_ = 0;
			是否拒绝势力战 = 0;
			是否携带披风行囊 = false;
			怒 = false;
			中毒 = false;
			神女怒 = false;
			新武功连击 = new List<武功类>();
			AtTimerElapsed = new 攻击确认类();
			SerList = new ConcurrentDictionary<int, ServerList>(1, 12);
			触发物理无明暗矢 = false;
			触发魔法无明暗矢 = false;
			触发弓箭致命绝杀 = false;
			刺客发起技能加成 = false;
			刺客物理攻击加成 = 0.0;
			刺客魔法攻击加成 = 0.0;
			每日获得武勋 = 0;
			IsRanked = 0;
			丢失武勋 = 0;
			最大精力 = 200;
			恢复精力 = 0;
			lastX = 0f;
			lastY = 0f;
			lastMAP = 101;
			AttackX = 0f;
			AttackY = 0f;
			攻击次数 = 0;
			当前激活技能ID = 0;
			表情次数阀值 = 0;
			报错次数阀值 = 0;
			死亡不复活计时 = 0;
			心跳次数阀值 = 3;
			修炼地图剩余时间 = 0;
			活动地图剩余时间 = 0;
			凝神宝珠位置 = -1;
			FLD_宠物_追加_攻击 = 0;
			FLD_宠物_追加_防御 = 0;
			FLD_宠物_追加_最大HP = 0;
			弓群攻触发心神 = false;
			韩飞官_天魔狂血攻击力 = 0.0;
			韩飞官_天魔狂血叠加次数 = 0;
			升天气功武功等级 = 0.0;
			FLD_爱情度等级 = 0;
			FLD_是否可以送花 = true;
			当前操作类型 = 0;
			人物锁定 = false;
			锁定人物几率 = 0;
			人物追加战力 = 0;
			FLD_夫妻辅助_追加_防具_属性 = 0;
			FLD_夫妻辅助_追加_武器_属性 = 0;
			FLD_结婚礼物_追加_属性石 = 0;
			解除师徒关系时间 = DateTime.Parse("2022/12/12 12:12:12");
			武皇通币 = 0;
			拳师连击控制 = 0;
			拳师会心一击威力 = 0.3;
			传书列表 = new ConcurrentDictionary<int, 个人传书类>();
			天地同寿回避次数 = 0;
			天地同寿回避累积攻击力 = 0;
			FLD_荣誉ID = 0;
			夫妻武功攻击力MP = 0;
			夫妻武功攻击力 = 0;
			潜行模式 = 0;
			装备数据版本 = 1;
			综合仓库装备数据版本 = 1;
			PKhmtime = DateTime.Now;
			TMJCtime = DateTime.Now;
			XThmtime = DateTime.Now;
			FBtime = DateTime.Now;
			CWhmtime = DateTime.Now;
			SThmtime = DateTime.Now;
			WXhmtime = DateTime.Now;
			JYhmtime = DateTime.Now;
			CJhmtime = DateTime.Now;
			BWYBhmtime = DateTime.Now;
			Config = new ConfigClass();
			交易 = new 交易类();
			Client = client;
			妖花青草 = false;
			NpcList = new ThreadSafeDictionary<int, NpcClass>();
			地面物品列表 = new ThreadSafeDictionary<double, 地面物品类>();
			土灵符坐标 = new Hashtable();
			攻击列表 = new List<攻击类>();
			玉连环 = new List<int>();
			怪物攻击列表 = new ThreadSafeDictionary<int, NpcClass>();
			FLD_追加哀鸿片野_HP上限 = 0.0;
			人物_气功_追加_百分比MP = 0.0;
			人物追加最大_HP = 0;
			人物追加最大_MP = 0;
			人物基本最大_HP = 0;
			FLD_装备_追加_障力恢复量 = 0;
			FLD_装备_追加_HP = 0;
			人物_气功_追加_HP = 0;
			人物基本最大_MP = 0;
			人物基本最大_障力 = 0;
			FLD_装备_追加_MP = 0;
			FLD_装备_隐藏_HP = 0;
			FLD_装备_隐藏_DF = 0;
			FLD_装备_隐藏_AT = 0;
			人物_气功_追加_MP = 0;
			FLD_攻击速度 = 100;
			人物_AP = 0;
			爆毒状态 = 0.0;
			刺_连消带打数量 = 0.0;
			升天武功点数 = 0;
			组队阶段 = 0;
			安全模式 = 0;
			当前操作NPC = 0;
			称号排名 = 0;
			行走状态id1 = 0;
			门派称号类型 = 0;
			隐身状态id = 0;
		}

		public bool GetSTQG(int Key)
		{
			升天气功类 value;
			return 升天气功 != null && 升天气功.Count != 0 && 升天气功.TryGetValue(Key, out value);
		}

		public bool GetAddState(int Key)
		{
			追加状态类 value;
			return 追加状态列表 != null && 追加状态列表.Count != 0 && 追加状态列表.TryGetValue(Key, out value);
		}

		public bool GetAddStateNew(int Key)
		{
			追加状态New类 value;
			return 追加状态New列表 != null && 追加状态New列表.Count != 0 && 追加状态New列表.TryGetValue(Key, out value);
		}

		public bool GetAbnormalState(int Key)
		{
			异常状态类 value;
			return 异常状态 != null && 异常状态.Count != 0 && 异常状态.TryGetValue(Key, out value);
		}

		public void 气功Clear()
		{
			for (int i = 0; i < 12; i++)
			{
				气功[i] = new 气功类(new byte[4]);
			}
		}

		public void 任务Clear()
		{
			任务 = new ConcurrentDictionary<int, 任务类>();
		}

		public void addFLD_追加百分比_攻击(double i)
		{
			using (new Lock(thisLock, "addFLD_追加百分比_攻击"))
			{
				FLD_追加百分比_攻击 += i;
			}
		}

		public void delFLD_追加百分比_攻击(double i)
		{
			using (new Lock(thisLock, "dllFLD_追加百分比_攻击"))
			{
				FLD_追加百分比_攻击 -= i;
				if (!(FLD_追加百分比_攻击 >= 0.0))
				{
					FLD_追加百分比_攻击 = 0.0;
				}
			}
		}

		public void addFLD_追加百分比_防御(double i)
		{
			using (new Lock(thisLock, "addFLD_追加百分比_防御"))
			{
				FLD_追加百分比_防御 += i;
			}
		}

		public void delFLD_追加百分比_防御(double i)
		{
			using (new Lock(thisLock, "dllFLD_追加百分比_防御"))
			{
				FLD_追加百分比_防御 -= i;
				if (!(FLD_追加百分比_防御 >= 0.0))
				{
					FLD_追加百分比_防御 = 0.0;
				}
			}
		}

		public void addFLD_装备_追加_武器_强化(int i)
		{
			using (new Lock(thisLock, "addFLD_装备_追加_武器_强化"))
			{
				FLD_装备_追加_武器_强化 += i;
			}
		}

		public void delFLD_装备_追加_武器_强化(int i)
		{
			using (new Lock(thisLock, "dllFLD_装备_追加_武器_强化"))
			{
				FLD_装备_追加_武器_强化 -= i;
				if (FLD_装备_追加_武器_强化 < 0)
				{
					FLD_装备_追加_武器_强化 = 0;
				}
			}
		}

		public 物品类 得到行囊背包物品(int 物品ID)
		{
			for (int i = 0; i < 3; i++)
			{
				if (BitConverter.ToInt32(行囊包裹[i].物品ID, 0) == 物品ID)
				{
					return 行囊包裹[i];
				}
			}
			return null;
		}

		public void addFLD_装备_追加_防具_强化(int i)
		{
			using (new Lock(thisLock, "addFLD_装备_追加_防具_强化"))
			{
				FLD_装备_追加_防具_强化 += i;
			}
		}

		public void delFLD_装备_追加_防具_强化(int i)
		{
			using (new Lock(thisLock, "dllFLD_装备_追加_防具_强化"))
			{
				FLD_装备_追加_防具_强化 -= i;
				if (FLD_装备_追加_防具_强化 < 0)
				{
					FLD_装备_追加_防具_强化 = 0;
				}
			}
		}

		public bool 检查物品系统(Itimesx 属性)
		{
			if (属性.属性类型 != 0)
			{
				if (属性.属性类型 == 1)
				{
					if (World.物品最高攻击值 != 0 && 属性.属性数量 >= World.物品最高攻击值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 2)
				{
					if (World.物品最高防御值 != 0 && 属性.属性数量 >= World.物品最高防御值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 3)
				{
					if (World.物品最高生命值 != 0 && 属性.属性数量 >= World.物品最高生命值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 4)
				{
					if (World.物品最高内功值 != 0 && 属性.属性数量 >= World.物品最高内功值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 5)
				{
					if (World.物品最高命中值 != 0 && 属性.属性数量 >= World.物品最高命中值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 6)
				{
					if (World.物品最高回避值 != 0 && 属性.属性数量 >= World.物品最高回避值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 7)
				{
					if (World.物品最高武功值 != 0 && 属性.属性数量 >= World.物品最高武功值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 8)
				{
					if (World.物品最高气功值 != 0 && 属性.属性数量 >= World.物品最高气功值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 9)
				{
					if (World.物品最高合成值 != 0 && 属性.属性数量 >= World.物品最高合成值)
					{
						return true;
					}
				}
				else if (属性.属性类型 == 11 && World.物品最高合成值 != 0 && 属性.属性数量 >= World.物品最高武防值)
				{
					return true;
				}
			}
			return false;
		}

		public void 封号(int 时长, string 帐号, string 原因)
		{
			DBA.ExeSqlCommand(string.Format("UPDATE TBL_ACCOUNT SET FLD_ZT={1}, FLD_NAME='{2}' WHERE FLD_ID='{0}'", Userid, 时长, 原因), "rxjhaccount");
			Client.Dispose();
		}

		public void 口令封号(Players players_0, string string_4)
		{
			DBA.ExeSqlCommand("UPDATE TBL_ACCOUNT SET FLD_ZT=720 WHERE FLD_ID='" + players_0.Userid + "'", "rxjhaccount");
			if (players_0.Client != null)
			{
				players_0.Client.Dispose();
			}
		}

		public void 检查物品系统(string 位置, ref 物品类 物品)
		{
			DateTime value = new DateTime(1970, 1, 1, 8, 0, 0);
			if (物品.FLD_JSSJ > 物品.FLD_KSSJ && DateTime.Now.Subtract(value).TotalSeconds > (double)物品.FLD_JSSJ)
			{
				系统提示("您有物品过期[" + 物品.得到物品名称() + "], 系统已删除！", 9, "装备到期提示");
				物品.物品_byte = new byte[73];
				return;
			}
			switch (World.查非法物品)
			{
			case 1:
				if (!World.查绑定非法物品 && 物品.物品绑定)
				{
					break;
				}
				if (物品.属性1.属性类型 != 0 && 检查物品系统(物品.属性1))
				{
					MainForm.WriteLine(77, "非法物品 " + 位置 + " [" + Userid + "]-[" + UserName + "] 位置[" + 物品.物品位置 + "] 编号[" + BitConverter.ToInt32(物品.物品全局ID, 0) + "] 物品名称[" + 物品.得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(物品.物品数量, 0) + "] 属性:[" + 物品.FLD_MAGIC0 + ", " + 物品.FLD_MAGIC1 + ", " + 物品.FLD_MAGIC2 + ", " + 物品.FLD_MAGIC3 + ", " + 物品.FLD_MAGIC4 + "]");
					if (World.查非法物品操作 == 1)
					{
						物品.物品_byte = new byte[World.数据库单个物品大小];
					}
					else if (World.查非法物品操作 == 2)
					{
						封号(720, Userid, "查非法物品操作2-1");
					}
				}
				else if (物品.属性2.属性类型 != 0 && 检查物品系统(物品.属性2))
				{
					MainForm.WriteLine(77, "非法物品 " + 位置 + " [" + Userid + "]-[" + UserName + "] 位置[" + 物品.物品位置 + "] 编号[" + BitConverter.ToInt32(物品.物品全局ID, 0) + "] 物品名称[" + 物品.得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(物品.物品数量, 0) + "] 属性:[" + 物品.FLD_MAGIC0 + ", " + 物品.FLD_MAGIC1 + ", " + 物品.FLD_MAGIC2 + ", " + 物品.FLD_MAGIC3 + ", " + 物品.FLD_MAGIC4 + "]");
					if (World.查非法物品操作 == 1)
					{
						物品.物品_byte = new byte[World.数据库单个物品大小];
					}
					else if (World.查非法物品操作 == 2)
					{
						封号(720, Userid, "查非法物品操作2-2");
					}
				}
				else if (物品.属性3.属性类型 != 0 && 检查物品系统(物品.属性3))
				{
					MainForm.WriteLine(77, "非法物品 " + 位置 + " [" + Userid + "]-[" + UserName + "] 位置[" + 物品.物品位置 + "] 编号[" + BitConverter.ToInt32(物品.物品全局ID, 0) + "] 物品名称[" + 物品.得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(物品.物品数量, 0) + "] 属性:[" + 物品.FLD_MAGIC0 + ", " + 物品.FLD_MAGIC1 + ", " + 物品.FLD_MAGIC2 + ", " + 物品.FLD_MAGIC3 + ", " + 物品.FLD_MAGIC4 + "]");
					if (World.查非法物品操作 == 1)
					{
						物品.物品_byte = new byte[World.数据库单个物品大小];
					}
					else if (World.查非法物品操作 == 2)
					{
						封号(720, Userid, "查非法物品操作2-3");
					}
				}
				else if (物品.属性4.属性类型 != 0 && 检查物品系统(物品.属性4))
				{
					MainForm.WriteLine(77, "非法物品 " + 位置 + " [" + Userid + "]-[" + UserName + "] 位置[" + 物品.物品位置 + "] 编号[" + BitConverter.ToInt32(物品.物品全局ID, 0) + "] 物品名称[" + 物品.得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(物品.物品数量, 0) + "] 属性:[" + 物品.FLD_MAGIC0 + ", " + 物品.FLD_MAGIC1 + ", " + 物品.FLD_MAGIC2 + ", " + 物品.FLD_MAGIC3 + ", " + 物品.FLD_MAGIC4 + "]");
					if (World.查非法物品操作 == 1)
					{
						物品.物品_byte = new byte[World.数据库单个物品大小];
					}
					else if (World.查非法物品操作 == 2)
					{
						封号(720, Userid, "查非法物品操作2-4");
					}
				}
				else if ((物品.FLD_RESIDE2 == 1 || 物品.FLD_RESIDE2 == 4) && 物品.FLD_FJ_觉醒 >= World.物品最高附魂值)
				{
					MainForm.WriteLine(77, "非法物品 " + 位置 + " [" + Userid + "]-[" + UserName + "] 位置[" + 物品.物品位置 + "] 编号[" + BitConverter.ToInt32(物品.物品全局ID, 0) + "] 物品名称[" + 物品.得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(物品.物品数量, 0) + "] 属性:[" + 物品.FLD_MAGIC0 + ", " + 物品.FLD_MAGIC1 + ", " + 物品.FLD_MAGIC2 + ", " + 物品.FLD_MAGIC3 + ", " + 物品.FLD_MAGIC4 + "]");
					if (World.查非法物品操作 == 1)
					{
						物品.物品_byte = new byte[World.数据库单个物品大小];
					}
					else if (World.查非法物品操作 == 2)
					{
						封号(720, Userid, "查非法物品操作2-5");
					}
				}
				break;
			case 2:
			{
				物品.得到物品属性方法(0, 0);
				if (!World.装备检测list.TryGetValue(物品.FLD_RESIDE2, out var value2) || !检查物品系统2(物品, value2))
				{
					break;
				}
				string sqlCommand = $"SELECT count(*) FROM Itme_Log WHERE ItmeId={BitConverter.ToInt32(物品.物品全局ID, 0)}";
				int num;
				try
				{
					num = (int)DBA.GetDBValue_3(sqlCommand, "WebDb");
				}
				catch
				{
					num = -1;
				}
				if (num == 0)
				{
					MainForm.WriteLine(77, "非法物品 " + 位置 + " [" + Userid + "]-[" + UserName + "] 位置[" + 物品.物品位置 + "] 编号[" + BitConverter.ToInt32(物品.物品全局ID, 0) + "] 物品名称[" + 物品.得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(物品.物品数量, 0) + "] 属性:[" + 物品.FLD_MAGIC0 + ", " + 物品.FLD_MAGIC1 + ", " + 物品.FLD_MAGIC2 + ", " + 物品.FLD_MAGIC3 + ", " + 物品.FLD_MAGIC4 + "] 绑定[" + 物品.物品绑定 + "] 魂[" + 物品.FLD_FJ_觉醒 + "] 进化[" + 物品.FLD_FJ_进化 + "]");
					if (World.查非法物品操作 == 1)
					{
						物品.物品_byte = new byte[World.数据库单个物品大小];
					}
					else if (World.查非法物品操作 == 2)
					{
						封号(720, Userid, "查非法物品操作2-6");
					}
				}
				break;
			}
			}
		}

		public bool 检查物品系统2(物品类 物品, 装备检测类 var)
		{
			if ((var.物品最高攻击值 != 0 && 物品.物品属性_攻击力增加 >= var.物品最高攻击值) || (var.物品最高防御值 != 0 && 物品.物品属性_防御力增加 >= var.物品最高防御值) || (var.物品最高生命值 != 0 && 物品.物品属性_生命力增加 >= var.物品最高生命值) || (var.物品最高内功值 != 0 && 物品.物品属性_内功力增加 >= var.物品最高内功值) || (var.物品最高命中值 != 0 && 物品.物品属性_命中率增加 >= var.物品最高命中值) || (var.物品最高回避值 != 0 && 物品.物品属性_回避率增加 >= var.物品最高回避值) || (var.物品最高武功值 != 0 && 物品.物品属性_武功攻击力 >= var.物品最高武功值) || (var.物品最高气功值 != 0 && 物品.物品属性_全部气功等级增加 >= var.物品最高气功值))
			{
				return true;
			}
			return var.物品最高附魂值 != 0 && 物品.FLD_FJ_觉醒 >= var.物品最高附魂值;
		}

		public void 读出灵兽数据(long id, Players play)
		{
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable($"SELECT * FROM TBL_XWWL_Cw WHERE ItmeId ={id}");
				if (dBToDataTable.Rows.Count > 0)
				{
					人物灵兽 = new 灵兽类(id, Client, dBToDataTable, play);
					if (人物灵兽 != null)
					{
						人物灵兽.全服ID = 人物灵兽全服ID;
					}
					else
					{
						系统提示("灵兽召唤出错, 请联系管理员。");
					}
				}
				dBToDataTable.Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "读出灵兽数据出错 [" + Userid + "][" + UserName + "][" + id + "] " + ex.Message);
			}
		}

		public double 得到气功加成值(int job, int index, int type)
		{
			try
			{
				foreach (气功加成属性 value in World.气功加成.Values)
				{
					if (value.FLD_JOB == job && value.FLD_INDEX == index)
					{
						return (type == 0) ? value.FLD_每点加成比率值1 : value.FLD_每点加成比率值2;
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到气功加成比率值出错 [" + Userid + "][" + UserName + "]" + ex.Message);
			}
			return 0.0;
		}

		public double 得到升天气功加成值(int PID)
		{
			try
			{
				if (World.升天气功List.TryGetValue(PID, out var value))
				{
					return value.FLD_每点加成比率值;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到升天气功加成比率值出错 [" + Userid + "][" + UserName + "]" + ex.Message);
			}
			return 0.0;
		}

		public double 得到单项气功增加值(int id)
		{
			if (1 == 0)
			{
			}
			double result = id switch
			{
				58 => FLD_装备_追加_升天一护身气甲, 
				33 => FLD_装备_追加_升天三怒意之火, 
				0 => FLD_装备_追加_气功_0, 
				1 => FLD_装备_追加_气功_1, 
				2 => FLD_装备_追加_气功_2, 
				3 => FLD_装备_追加_气功_3, 
				4 => FLD_装备_追加_气功_4, 
				5 => FLD_装备_追加_气功_5, 
				6 => FLD_装备_追加_气功_6, 
				7 => FLD_装备_追加_气功_7, 
				8 => FLD_装备_追加_气功_8, 
				9 => FLD_装备_追加_气功_9, 
				10 => FLD_装备_追加_气功_10, 
				11 => FLD_装备_追加_气功_11, 
				13 => FLD_装备_追加_升天三火龙之火, 
				25 => FLD_装备_追加_升天一护身罡气, 
				310 => FLD_装备_追加_升天一遁出逆境, 
				311 => FLD_装备_追加_升天二穷途末路, 
				313 => FLD_装备_追加_升天四红月狂风, 
				314 => FLD_装备_追加_升天四毒蛇出洞, 
				321 => FLD_装备_追加_升天二天地同寿, 
				322 => FLD_装备_追加_升天三火凤临朝, 
				323 => FLD_装备_追加_升天四红月狂风, 
				324 => FLD_装备_追加_升天四毒蛇出洞, 
				665 => FLD_装备_追加_升天四毒蛇出洞, 
				170 => FLD_装备_追加_升天三无情打击, 
				150 => FLD_装备_追加_升天二万物回春, 
				370 => FLD_装备_追加_升天一夜魔缠身, 
				371 => FLD_装备_追加_升天二顺水推舟, 
				373 => FLD_装备_追加_升天四满月狂风, 
				613 => FLD_装备_追加_升天四满月狂风, 
				374 => FLD_装备_追加_升天四烈日炎炎, 
				380 => FLD_装备_追加_升天一力劈华山, 
				381 => FLD_装备_追加_升天一长虹贯日, 
				382 => FLD_装备_追加_升天一金钟罡气, 
				383 => FLD_装备_追加_升天一运气行心, 
				384 => FLD_装备_追加_升天一正本培源, 
				385 => FLD_装备_追加_升天一运气疗伤, 
				386 => FLD_装备_追加_升天一百变神行, 
				653 => FLD_装备_追加_升天一百变神行, 
				387 => FLD_装备_追加_升天一狂风天意, 
				390 => FLD_装备_追加_升天一飞花点翠, 
				391 => FLD_装备_追加_升天二三潭映月, 
				392 => FLD_装备_追加_升天三子夜秋歌, 
				393 => FLD_装备_追加_升天四满月狂风, 
				394 => FLD_装备_追加_升天四悬丝诊脉, 
				352 => FLD_装备_追加_升天三明镜止水, 
				353 => FLD_装备_追加_升天四满月狂风, 
				354 => FLD_装备_追加_升天四望梅添花, 
				614 => FLD_装备_追加_升天四望梅添花, 
				330 => FLD_装备_追加_升天一破甲刺魂, 
				331 => FLD_装备_追加_升天二以退为进, 
				333 => FLD_装备_追加_升天四红月狂风, 
				666 => FLD_装备_追加_升天四红月狂风, 
				334 => FLD_装备_追加_升天四毒蛇出洞, 
				340 => FLD_装备_追加_升天一绝影射魂, 
				341 => FLD_装备_追加_升天二千钧压驼, 
				342 => FLD_装备_追加_升天三天外三矢, 
				343 => FLD_装备_追加_升天四满月狂风, 
				327 => FLD_装备_追加_升天四满月狂风, 
				344 => FLD_装备_追加_升天四烈日炎炎, 
				326 => FLD_装备_追加_升天四烈日炎炎, 
				700 => FLD_装备_追加_升天三以柔克刚, 
				701 => FLD_装备_追加_升天四长虹贯天, 
				702 => FLD_装备_追加_升天四哀鸿遍野, 
				600 => FLD_装备_追加_升天一行风弄舞, 
				601 => FLD_装备_追加_升天二天魔护体, 
				602 => FLD_装备_追加_升天三内息行心, 
				603 => FLD_装备_追加_升天四长虹贯天, 
				604 => FLD_装备_追加_升天四哀鸿遍野, 
				561 => FLD_装备_追加_升天一夺命连环, 
				562 => FLD_装备_追加_升天一电光石火, 
				563 => FLD_装备_追加_升天一精益求精, 
				564 => FLD_装备_追加_升天四红月狂风, 
				565 => FLD_装备_追加_升天四毒蛇出洞, 
				680 => FLD_装备_追加_升天五惊天动地, 
				316 => FLD_装备_追加_升天一玄武雷电, 
				662 => FLD_装备_追加_升天一陵劲淬砺, 
				610 => FLD_装备_追加_升天一愤怒调节, 
				325 => FLD_装备_追加_升天二玄武诅咒, 
				663 => FLD_装备_追加_升天二杀星光符, 
				611 => FLD_装备_追加_升天二蛊毒解除, 
				315 => FLD_装备_追加_升天三杀人鬼, 
				664 => FLD_装备_追加_升天三技冠群雄, 
				612 => FLD_装备_追加_升天三神力保护, 
				668 => FLD_装备_追加_升天五致残, 
				667 => FLD_装备_追加_升天五致残, 
				669 => FLD_装备_追加_升天五致残, 
				670 => FLD_装备_追加_升天五致残, 
				671 => FLD_装备_追加_升天五致残, 
				672 => FLD_装备_追加_升天五致残, 
				673 => FLD_装备_追加_升天五致残, 
				674 => FLD_装备_追加_升天五致残, 
				675 => FLD_装备_追加_升天五致残, 
				676 => FLD_装备_追加_升天五致残, 
				677 => FLD_装备_追加_升天五致残, 
				678 => FLD_装备_追加_升天五致残, 
				615 => FLD_装备_追加_升天五致残, 
				679 => FLD_装备_追加_升天五龙魂附体, 
				681 => FLD_装备_追加_升天五灭世狂舞, 
				682 => FLD_装备_追加_升天五千里一击, 
				683 => FLD_装备_追加_升天五形移妖相, 
				684 => FLD_装备_追加_升天五一招杀神, 
				685 => FLD_装备_追加_升天五龙爪纤指手, 
				688 => FLD_装备_追加_升天五不死之躯, 
				686 => FLD_装备_追加_升天五天魔之力, 
				687 => FLD_装备_追加_升天五惊涛骇浪, 
				689 => FLD_装备_追加_升天五魔魂之力, 
				690 => FLD_装备_追加_升天五破空坠星, 
				616 => FLD_装备_追加_升天五尸毒爆发, 
				_ => 0.0, 
			};
			if (1 == 0)
			{
			}
			return result;
		}

		public void 更新气功()
		{
			using (new Lock(thisLock, "更新气功"))
			{
				人物_气功_追加_HP = 0;
				人物_气功_追加_MP = 0;
				FLD_人物_气功_攻击 = 0.0;
				FLD_人物_气功_防御 = 0;
				FLD_人物_气功_命中 = 0;
				FLD_人物_气功_回避 = 0;
				FLD_人物_追加百分比_回避 = 0.0;
				FLD_追加百分比_命中 = 0.0;
				FLD_人物_气功_负重 = 0;
				base.琴_三和弦_状态效果 = 0.0;
				base.琴_七和弦_状态效果 = 0.0;
				base.琴_九和弦_状态效果 = 0.0;
				FLD_人物_气功_武功攻击力增加百分比 = 0.0;
				FLD_人物_气功_武功防御力增加百分比 = 0.0;
				人物_气功_追加_武功防御力 = 0;
				for (int i = 0; i < 12; i++)
				{
					byte[] 气功_byte = 气功[i].气功_byte;
					if (气功_byte[0] == byte.MaxValue || BitConverter.ToInt16(气功_byte, 0) <= 0)
					{
						continue;
					}
					double num = BitConverter.ToInt16(气功_byte, 0);
					if (!(num > 0.0))
					{
						continue;
					}
					double num4 = num + (double)FLD_装备_追加_气功 + (double)FLD_人物_追加_气功 + (double)人物_WX_BUFF_气功 + 得到单项气功增加值(i) + (double)FLD_药品_追加_气功;
					double num5 = 得到气功加成值(Player_Job, i, 0);
					switch (Player_Job)
					{
					case 1:
						switch (i)
						{
						case 0:
						{
							double num10 = (double)FLD_最小攻击 * num4 * num5 / 100.0 / 2.0;
							if (num10 < 1.0)
							{
								num10 = 1.0;
							}
							FLD_人物_气功_攻击 = (int)(num10 + 0.5);
							break;
						}
						case 1:
							FLD_人物_气功_命中 = (int)((double)FLD_命中 * (0.1 + num4 * num5));
							break;
						case 2:
							base.刀_连环飞舞 = 10.0 + num4 * num5;
							break;
						case 3:
							base.狂风万破 = num4 * num5;
							break;
						case 4:
							FLD_人物_气功_防御 = (int)((double)FLD_防御 * num4 * num5);
							人物_气功_追加_HP = (int)(num4 * 得到气功加成值(Player_Job, i, 1));
							break;
						case 5:
							base.破甲几率 = 5.0 + num4 * num5;
							break;
						case 6:
							base.气沉丹田 = num4 * num5;
							break;
						case 7:
							base.真武绝击 = num4 * num5;
							break;
						case 8:
							base.怪反伤几率 = 10.0 + num4 * num5;
							base.人反伤几率 = 3.0 + num4 * 得到气功加成值(Player_Job, i, 1);
							break;
						case 9:
							base.暗影绝杀 = 5.0 + num4 * num5;
							break;
						case 10:
							base.刀_梵音破镜 = num4 * num5;
							break;
						case 11:
							base.流光乱舞 = num4 * num5;
							break;
						}
						break;
					case 2:
						switch (i)
						{
						case 0:
							FLD_人物_气功_攻击 = num4;
							break;
						case 1:
							FLD_人物_追加百分比_回避 = 0.1 + num4 * num5;
							break;
						case 2:
							base.剑_连环飞舞 = 10.0 + num4 * num5;
							break;
						case 3:
							base.剑_破天一剑 = num4 * num5 * 0.01;
							break;
						case 4:
							base.狂风万破 = num4 * num5;
							break;
						case 5:
							base.剑_移花接木 = num4 * num5;
							break;
						case 6:
							base.气沉丹田 = num4 * num5;
							break;
						case 7:
							base.剑_怒海狂澜 = num4 * num5;
							break;
						case 8:
							base.剑_回柳身法 = num4 * num5;
							FLD_人物_气功_武功攻击力增加百分比 = num4 * 得到气功加成值(Player_Job, i, 1);
							break;
						case 9:
							base.剑_无坚不摧 = 10.0 + num4 * num5;
							break;
						case 10:
							base.剑_乘胜追击 = num4 * num5;
							break;
						case 11:
							base.剑_冲冠一怒 = 5.0 + num4 * num5;
							break;
						}
						break;
					case 3:
						switch (i)
						{
						case 0:
							FLD_人物_气功_防御 = (int)(num4 * num5);
							break;
						case 1:
							base.枪_运气疗伤 = num4 * num5 + 0.1;
							break;
						case 2:
							base.枪_连环飞舞 = 10.0 + num4 * num5;
							break;
						case 3:
							base.狂风万破 = num4 * num5;
							break;
						case 4:
							人物_气功_追加_HP = (int)(num4 * num5);
							break;
						case 5:
							base.枪_转攻为守 = 5.0 + num4 * num5;
							break;
						case 6:
							base.气沉丹田 = num4 * num5;
							break;
						case 7:
							base.枪_狂神降世 = num4 * num5;
							break;
						case 8:
							FLD_人物_气功_武功攻击力增加百分比 = num4 * num5;
							base.枪_连环飞舞 *= 1.0 + num4 * 得到气功加成值(Player_Job, i, 1);
							break;
						case 9:
							base.枪_末日狂舞 = num4 * num5;
							break;
						case 10:
							base.枪_怒意之吼 = num4 * num5;
							break;
						case 11:
							FLD_人物_气功_武功防御力增加百分比 = num4 * 0.03;
							break;
						}
						break;
					case 4:
						switch (i)
						{
						case 0:
							FLD_追加百分比_命中 = num4 * num5;
							break;
						case 1:
							base.弓_猎鹰之眼 = (int)(num4 * num5);
							break;
						case 2:
						{
							double num9 = (double)FLD_最小攻击 * num4 * num5 / 100.0 / 2.0;
							if (num9 < 1.0)
							{
								num9 = 1.0;
							}
							FLD_人物_气功_攻击 = (int)(num9 + 0.5);
							break;
						}
						case 3:
							base.狂风万破 = num4 * num5;
							break;
						case 4:
							人物_气功_追加_HP = (int)(num4 * num5);
							break;
						case 5:
							base.弓_锐利之箭 = 5.0 + num4 * num5;
							break;
						case 6:
							base.气沉丹田 = num4 * num5;
							break;
						case 7:
							base.弓_心神凝聚 = 10.0 + num4 * num5;
							break;
						case 8:
							base.弓_流星三矢 = 10.0 + num4 * num5;
							base.弓_流星三矢时间 = num4 * 得到气功加成值(4, 8, 1);
							break;
						case 9:
							base.弓_回流真气 = num4 * num5;
							break;
						case 10:
							base.弓_无明暗矢 = num4 * num5;
							break;
						case 11:
							base.弓_致命绝杀 = 10.0 + num4 * num5;
							break;
						}
						break;
					case 5:
						switch (i)
						{
						case 0:
							base.医_运气疗心 = num4 * num5;
							break;
						case 1:
							base.医_太极心法 = num4 * num5;
							break;
						case 2:
							人物_气功_追加_HP = (int)(num4 * num5);
							break;
						case 3:
							人物_气功_追加_MP = (int)(num4 * num5);
							break;
						case 4:
							base.医_妙手回春 = 10.0 + num4 * num5;
							break;
						case 5:
							base.医_长攻击力 = num4 * num5;
							break;
						case 6:
							base.气沉丹田 = num4 * num5;
							break;
						case 7:
							base.真武绝击 = num4 * num5;
							break;
						case 8:
							base.医_吸星大法 = num4 * num5;
							break;
						case 9:
							base.医_狂意护体 = num4 * num5;
							break;
						case 10:
							base.医_无中生有 = num4 * num5;
							break;
						case 11:
							base.医_九天真气 = num4 * num5;
							break;
						}
						break;
					case 6:
						switch (i)
						{
						case 0:
						{
							double num8 = (double)FLD_最小攻击 * num4 * num5 / 100.0 / 2.0;
							if (num8 < 1.0)
							{
								num8 = 1.0;
							}
							FLD_人物_气功_攻击 = (int)(num8 + 0.5);
							base.刺_荆轲之怒 = num4 * 得到气功加成值(Player_Job, i, 1);
							break;
						}
						case 1:
							FLD_人物_气功_回避 = (int)(10.0 + num4 * num5);
							base.刺_三花聚顶 = 10.0 + num4 * num5;
							break;
						case 2:
							base.刺_连环飞舞 = 10.0 + num4 * num5;
							break;
						case 3:
							base.刺_心神凝聚 = 10.0 + num4 * num5;
							break;
						case 4:
							base.刺_致手绝命 = num4 * num5;
							break;
						case 5:
							base.气沉丹田 = num4 * num5;
							break;
						case 6:
							base.刺_以怒还怒 = num4 * num5;
							break;
						case 7:
							base.刺_先发制人 = num4 * num5;
							break;
						case 8:
							base.刺_千蛛万手 = num4 * num5;
							break;
						case 9:
							base.刺_连消带打 = num4 * num5;
							break;
						case 10:
							base.刺_剑刃乱舞 = num4 * num5;
							break;
						case 11:
							base.刺_一招残杀 = num4 * num5;
							break;
						}
						break;
					case 7:
						switch (i)
						{
						case 0:
							FLD_人物_气功_攻击 = num4;
							break;
						case 1:
							人物_气功_追加_HP = (int)(num4 * num5);
							break;
						case 2:
							人物_气功_追加_MP = (int)(num4 * num5);
							break;
						case 3:
							FLD_人物_气功_防御 = (int)(num4 * num5);
							人物_气功_追加_武功防御力 = (int)(num4 * 得到气功加成值(Player_Job, i, 1));
							FLD_人物_气功_武功防御力增加百分比 = (double)人物_气功_追加_武功防御力 * (1.0 - World.武功防降低百分比) * 0.01;
							break;
						case 4:
							FLD_人物_气功_武功攻击力增加百分比 = num4 * 0.01;
							break;
						case 5:
							base.琴师_高山流水 = num4 * num5;
							break;
						case 6:
							base.气沉丹田 = num4 * num5;
							break;
						case 7:
							base.琴_三和弦_状态效果 = num4 * 0.01;
							base.琴_七和弦_状态效果 = num4 * 0.01;
							base.琴_九和弦_状态效果 = num4 * 0.005;
							break;
						case 8:
							base.琴师_梅花三弄 = num4 * num5;
							break;
						case 9:
							base.琴师_鸾凤和鸣 = num4 * num5;
							break;
						case 10:
							base.琴师_阳明春晓 = num4 * num5;
							break;
						case 11:
							base.琴师_潇湘雨夜 = num4 * num5;
							break;
						}
						break;
					case 8:
						switch (i)
						{
						case 0:
						{
							double num7 = (double)FLD_最小攻击 * num4 * num5 / 100.0 / 2.0;
							if (num7 < 1.0)
							{
								num7 = 1.0;
							}
							FLD_人物_气功_攻击 = (int)(num7 + 0.5);
							break;
						}
						case 1:
							FLD_人物_气功_命中 = (int)((double)FLD_命中 * (0.1 + num4 * num5));
							break;
						case 2:
							FLD_人物_追加百分比_回避 = 0.1 + num4 * num5;
							break;
						case 3:
							base.狂风万破 = num4 * num5;
							break;
						case 4:
							base.韩_天魔狂血 = num4 * num5;
							break;
						case 5:
							base.气沉丹田 = num4 * num5;
							break;
						case 6:
							base.韩_追骨吸元 = num4 * num5;
							break;
						case 7:
							base.破甲几率 = 5.0 + num4 * num5;
							break;
						case 8:
							base.真武绝击 = num4 * num5;
							break;
						case 9:
							base.韩_火龙问鼎 = num4 * num5;
							break;
						case 10:
							base.流光乱舞 = num4 * num5;
							break;
						case 11:
							base.暗影绝杀 = 5.0 + num4 * num5;
							break;
						}
						break;
					case 9:
						switch (i)
						{
						case 0:
							FLD_人物_气功_攻击 = num4;
							break;
						case 1:
							FLD_人物_追加百分比_回避 = 0.1 + num4 * num5;
							break;
						case 2:
							base.谭_连环飞舞 = num4 * num5;
							break;
						case 3:
							base.谭_招式新法 = 1000.0 * num5;
							break;
						case 4:
							base.狂风万破 = num4 * num5;
							break;
						case 5:
							base.气沉丹田 = num4 * num5;
							break;
						case 6:
							base.谭_护身罡气 = 10.0 + num4 * num5;
							break;
						case 7:
							base.谭_移花接木 = num4 * num5;
							break;
						case 8:
							base.谭_纵横无双 = 5.0 + num4 * num5;
							break;
						case 9:
							base.谭_回柳身法 = num4 * num5;
							FLD_人物_气功_武功攻击力增加百分比 = num4 * 得到气功加成值(Player_Job, i, 1);
							break;
						case 10:
							base.谭_怒海狂澜 = 5.0 + num4 * num5;
							break;
						case 11:
							base.谭_冲冠一怒 = 5.0 + num4 * num5;
							break;
						}
						break;
					case 10:
						switch (i)
						{
						case 0:
							base.拳师_狂神降世 = num5 * num4;
							break;
						case 1:
							base.枪_运气疗伤 = num5 * num4;
							break;
						case 2:
						{
							double num6 = (double)FLD_最小攻击 * num4 * num5 / 100.0 / 2.0;
							if (num6 < 1.0)
							{
								num6 = 1.0;
							}
							FLD_人物_气功_攻击 = (int)(num6 + 0.5);
							break;
						}
						case 3:
							base.狂风万破 = num4 * num5;
							break;
						case 4:
							FLD_人物_气功_武功防御力增加百分比 = num4 * 0.03;
							break;
						case 5:
							base.气沉丹田 = num4 * num5;
							break;
						case 6:
							base.拳师_磨杵成针 = 10.0 + num4 * num5;
							break;
						case 7:
							base.拳师_水火一体 = num4 * num5;
							break;
						case 8:
							base.拳师_金刚不坏 = 10.0 + num5 * num4;
							break;
						case 9:
							base.拳师_转攻为守 = 5.0 + num4 * num5;
							break;
						case 10:
							base.拳师_会心一击 = num4 * num5;
							break;
						case 11:
							base.拳师_末日狂舞 = num4 * num5;
							break;
						}
						break;
					case 11:
						switch (i)
						{
						case 0:
							base.梅_障力激活 = 5.0 + num4;
							break;
						case 1:
							base.梅_障力运用 = 10.0 + num4 * num5;
							break;
						case 2:
							FLD_人物_追加百分比_回避 = 0.1 + num4 * num5;
							break;
						case 3:
							base.梅_玄武神功 = num4 * num5;
							break;
						case 4:
							base.梅_玄武的指点 = 8.0 + num4 * num5;
							FLD_人物_气功_攻击 = (double)FLD_最大攻击 * num4 * 得到气功加成值(Player_Job, i, 1) / 2.0;
							break;
						case 5:
							base.气沉丹田 = num4 * num5;
							break;
						case 6:
							base.梅_玄武强击 = num4;
							break;
						case 7:
							base.梅_玄武危化 = num4 * num5;
							break;
						case 8:
							base.梅_障力恢复 = num4 * num5;
							break;
						case 9:
							base.梅_嫉妒的化身 = num4 * num5;
							break;
						case 10:
							base.梅_愤怒爆发 = num4 * num5;
							break;
						case 11:
							base.梅_吸血进击 = num4 * num5;
							break;
						}
						break;
					case 12:
						switch (i)
						{
						case 0:
							FLD_人物_气功_防御 = (int)(num4 * num5);
							break;
						case 1:
							base.枪_运气疗伤 = num4 * num5 + 0.1;
							break;
						case 2:
							base.枪_连环飞舞 = 10.0 + num4 * num5;
							break;
						case 3:
							人物_气功_追加_HP = (int)(num4 * num5);
							break;
						case 4:
							base.狂风万破 = num4 * num5;
							break;
						case 5:
							base.气沉丹田 = num4 * num5;
							break;
						case 6:
							base.真武绝击 = num4 * num5;
							break;
						case 7:
							base.流星漫天 = num4 * num5;
							if (Player_Job_leve == 3)
							{
								base.流星漫天 += 5.0;
							}
							else if (Player_Job_leve == 4)
							{
								base.流星漫天 += 10.0;
							}
							else if (Player_Job_leve == 5)
							{
								base.流星漫天 += 15.0;
							}
							else if (Player_Job_leve >= 6)
							{
								base.流星漫天 += 20.0;
							}
							break;
						case 8:
							FLD_人物_气功_武功攻击力增加百分比 = num4 * num5;
							base.枪_连环飞舞 *= 1.0 + num4 * 得到气功加成值(Player_Job, i, 1);
							break;
						case 9:
							base.卢_转攻为守 = num4 * num5;
							break;
						case 10:
							base.弱点攻破 = 10.0 + num4 * num5;
							break;
						case 11:
							base.牢不可破 = num4 * num5;
							break;
						}
						break;
					case 13:
						switch (i)
						{
						case 0:
							base.神女运气行心 = num4 * num5;
							break;
						case 1:
							base.神女太极心法 = num4 * num5;
							break;
						case 2:
							base.神女神力激发 = num4 * num5;
							base.神女神力激发对怪防御力 = 50.0 + num4 * 得到气功加成值(Player_Job, i, 1);
							break;
						case 3:
							base.神女杀星义气 = num4 * num5;
							break;
						case 4:
							人物_气功_追加_百分比MP = 0.05 + num4 * num5;
							break;
						case 5:
							base.气沉丹田 = num4 * num5;
							break;
						case 6:
							base.神女黑花漫开 = num4 * num5;
							break;
						case 7:
							base.神女妙手回春 = num4 * num5;
							break;
						case 8:
							base.神女长功击力 = num4 * num5;
							break;
						case 9:
							base.神女黑花集中 = num4 * num5;
							break;
						case 10:
							base.神女真武绝击 = num4 * num5;
							break;
						case 11:
							base.神女万毒不侵 = num4 * num5;
							break;
						}
						break;
					}
				}
				if (base.气沉丹田 > 0.0)
				{
					int num11 = (int)((double)FLD_防御 * base.气沉丹田 / 100.0);
					人物_气功_追加_HP += num11;
					人物_气功_追加_武功防御力 += num11;
					FLD_人物_气功_武功防御力增加百分比 += (double)人物_气功_追加_武功防御力 * (1.0 - World.武功防降低百分比) * 0.01;
				}
				try
				{
					if (Player_Job_leve < 6 || 升天气功 == null)
					{
						return;
					}
					foreach (升天气功类 value in 升天气功.Values)
					{
						if (value.气功量 <= 0)
						{
							continue;
						}
						double num2 = (double)(value.气功量 + FLD_装备_追加_气功 + FLD_人物_追加_气功 + 人物_WX_BUFF_气功) + 得到单项气功增加值(value.气功ID) + (double)FLD_药品_追加_气功;
						double num3 = 得到升天气功加成值(value.气功ID);
						switch (value.气功ID)
						{
						case 25:
							base.剑_升天一气功_护身罡气 = 10.0 + num2 * num3;
							break;
						case 13:
							base.刀_升天三气功_火龙之火 = num2 * num3;
							break;
						case 150:
							base.医_升天二气功_万物回春 = num2 * num3;
							break;
						case 58:
							FLD_人物_气功_防御 += (int)(num2 * num3 * (double)FLD_人物基本_攻击);
							break;
						case 33:
							base.枪_升天三气功_怒意之火 = num2 * num3;
							break;
						case 370:
							base.刺_升天一气功_夜魔缠身 = num2 * num3;
							break;
						case 371:
							base.刺_升天二气功_顺水推舟 = num2 * num3;
							break;
						case 373:
							base.升天四式_满月狂风 = num2 * num3;
							break;
						case 374:
							base.升天四式_烈日炎炎 = num2 * num3;
							break;
						case 380:
							if (Player_Job != 1 && Player_Job != 4 && Player_Job != 8 && Player_Job != 10)
							{
								FLD_人物_气功_攻击 += (int)((double)FLD_最小攻击 * num2 * num3 * 0.01 / 2.0);
							}
							break;
						case 381:
							if (Player_Job != 2 && Player_Job != 9)
							{
								FLD_人物_气功_攻击 += num2 * num3;
							}
							break;
						case 382:
							if (Player_Job != 3 && Player_Job != 7)
							{
								FLD_人物_气功_防御 += (int)(num2 * num3);
							}
							break;
						case 383:
							if (Player_Job != 5)
							{
								base.升天一气功_运气行心 = num2 * num3;
							}
							break;
						case 384:
							if (Player_Job != 4 && Player_Job != 7)
							{
								人物_气功_追加_HP += (int)(num2 * num3);
							}
							break;
						case 385:
							if (Player_Job != 3 && Player_Job != 10)
							{
								base.升天一气功_运气疗伤 = 10.0 + num2 * num3;
							}
							break;
						case 386:
							if (Player_Job != 2 && Player_Job != 6 && Player_Job != 8 && Player_Job != 9)
							{
								FLD_人物_追加百分比_回避 += 0.1 + num2 * num3;
							}
							break;
						case 387:
							if (Player_Job == 5)
							{
								base.升天一气功_狂风天意 = num2 * num3;
							}
							break;
						case 390:
							base.琴师_升天一气功_飞花点翠 = num2 * num3;
							break;
						case 391:
							base.琴师_升天二气功_三潭映月 = num2 * num3;
							break;
						case 392:
							base.琴师_升天三气功_子夜秋歌 = num2 * num3;
							break;
						case 393:
							base.升天四式_红月狂风 = num2 * num3;
							break;
						case 394:
							base.升天四式_悬丝诊脉 = num2 * num3;
							break;
						case 310:
							base.刀_升天一气功_遁出逆境 = num2 * num3;
							break;
						case 311:
							base.刀_升天二气功_穷途末路 = num2 * num3;
							break;
						case 313:
							base.升天四式_红月狂风 = num2 * num3;
							break;
						case 314:
							base.升天四式_毒蛇出洞 = num2 * num3;
							break;
						case 315:
							base.梅_升天三气功_杀人鬼 = num2 * num3;
							break;
						case 316:
							base.梅_升天一气功_玄武雷电 = num2 * num3;
							break;
						case 321:
							if (Player_Job == 2)
							{
								base.剑_升天二气功_天地同寿 = num2 * num3;
							}
							else if (Player_Job == 9)
							{
								base.谭_升天二气功_天地同寿 = num2 * num3;
							}
							break;
						case 322:
							if (Player_Job == 2)
							{
								base.剑_升天三气功_火凤临朝 = num2 * num3;
							}
							else if (Player_Job == 9)
							{
								base.谭_升天三气功_火凤临朝 = num2 * num3;
							}
							break;
						case 323:
							base.升天四式_红月狂风 = num2 * num3;
							break;
						case 324:
							base.升天四式_毒蛇出洞 = num2 * num3;
							break;
						case 325:
							base.梅_升天二气功_玄武诅咒 = num2 * num3;
							break;
						case 326:
							base.升天四式_烈日炎炎 = num2 * num3;
							break;
						case 327:
							base.升天四式_满月狂风 = num2 * num3;
							break;
						case 330:
							base.枪_升天一气功_破甲刺魂 = num2 * num3;
							break;
						case 331:
							base.枪_升天二气功_以退为进 = num2 * num3;
							break;
						case 333:
							base.升天四式_红月狂风 = num2 * num3;
							break;
						case 334:
							base.升天四式_毒蛇出洞 = num2 * num3;
							break;
						case 340:
							base.弓_升天一气功_绝影射魂 = num2 * num3;
							break;
						case 341:
							FLD_人物_气功_负重 += (int)((double)人物负重总 * num2 * 0.003);
							FLD_人物_气功_防御 += (int)(num2 * num3);
							break;
						case 342:
							base.弓_升天三气功_天外三矢 = num2 * num3;
							break;
						case 343:
							base.升天四式_满月狂风 = num2 * num3;
							break;
						case 344:
							base.升天四式_烈日炎炎 = num2 * num3;
							break;
						case 352:
							base.医_升天三气功_明镜止水 = num2 * num3;
							break;
						case 353:
							base.升天四式_满月狂风 = num2 * num3;
							break;
						case 354:
							base.升天四式_望梅添花 = num2 * num3;
							break;
						case 170:
							base.刺_升天三气功_无情打击 = 0.1 + num2 * num3;
							break;
						case 662:
							base.陵劲淬砺 = num2 * num3;
							break;
						case 663:
							base.卢_破血狂风 = 10.0 + num2 * num3;
							break;
						case 664:
							base.技冠群雄 = 10.0 + num2 * num3;
							break;
						case 665:
							base.升天四式_毒蛇出洞 = num2 * num3;
							break;
						case 666:
							base.升天四式_红月狂风 = num2 * num3;
							break;
						case 679:
							base.升天五式_龙魂附体 = num2 * num3;
							break;
						case 680:
							base.升天五式_惊天动地 = num2 * num3;
							break;
						case 681:
							base.升天五式_灭世狂舞 = num2 * num3;
							break;
						case 682:
							base.升天五式_千里一击 = num2 * num3;
							break;
						case 683:
							base.升天五式_形移妖相 = num2 * num3;
							break;
						case 684:
							base.升天五式_一招杀神 = num2 * num3;
							break;
						case 685:
							base.升天五式_龙爪纤指手 = num2 * num3;
							break;
						case 686:
							base.升天五式_天魔之力 = num2 * num3;
							break;
						case 687:
							base.升天五式_惊涛骇浪 = num2 * num3;
							break;
						case 688:
							base.升天五式_不死之躯 = num2 * num3;
							break;
						case 689:
							base.升天五式_魔魂之力 = num2 * num3;
							break;
						case 690:
							base.升天五式_破空坠星 = 1.0 + num2 * num3;
							break;
						case 700:
							base.谭_升天三气功_以柔克刚 = num2 * num3;
							break;
						case 701:
							base.升天四式_长虹贯天 = num2 * num3;
							break;
						case 702:
							base.升天四式_哀鸿遍野 = num2 * num3;
							break;
						case 600:
							base.韩_升天一气功_行风弄舞 = num2 * num3;
							break;
						case 601:
							base.韩_升天二气功_天魔护体 = num2 * num3;
							break;
						case 602:
							base.韩_升天二气功_内息行心 = num2 * num3;
							break;
						case 603:
							base.升天四式_长虹贯天 = num2 * num3;
							break;
						case 604:
							base.升天四式_哀鸿遍野 = num2 * num3;
							break;
						case 610:
							base.神女愤怒调节 = num2 * num3;
							break;
						case 611:
							base.神女蛊毒解除 = num2 * num3;
							break;
						case 612:
							base.神女神力保护 = num2 * num3;
							break;
						case 613:
							base.升天四式_满月狂风 = num2 * num3;
							break;
						case 614:
							base.升天四式_望梅添花 = num2 * num3;
							break;
						case 615:
						case 667:
						case 668:
						case 669:
						case 670:
						case 671:
						case 672:
						case 673:
						case 674:
						case 675:
						case 676:
						case 677:
						case 678:
							base.升天五式_致残 = 3.0 + num2 * num3 + (double)强化武器追加百分比;
							break;
						case 616:
							base.神女尸毒爆发 = num2 * num3;
							break;
						case 561:
							base.拳_升天一气功_夺命连环 = num2 * num3;
							break;
						case 562:
							base.拳_升天二气功_电光石火 = 10.0 + num2 * num3;
							break;
						case 563:
							base.拳_升天三气功_精益求精 = num2 * num3;
							break;
						case 564:
							base.升天四式_红月狂风 = num2 * num3;
							break;
						case 565:
							base.升天四式_毒蛇出洞 = num2 * num3;
							break;
						case 620:
						case 621:
						case 622:
						case 623:
						case 624:
						case 625:
						case 626:
						case 627:
						case 628:
						case 629:
						case 630:
						case 631:
						case 632:
							base.精金百炼 = num2 * num3;
							base.减少罡气 = num2 * (num3 + 1.0);
							break;
						case 633:
						case 634:
						case 635:
						case 636:
						case 637:
						case 638:
						case 639:
						case 640:
						case 641:
						case 642:
						case 643:
						case 644:
						case 645:
							base.血气方刚 = num2 * num3;
							base.减少攻击 = num2 * (num3 - 1.0);
							break;
						case 570:
							base.刀画龙点睛 = num2 * num3;
							人物_气功_追加_HP += (int)((double)(FLD_防御 + FLD_装备_追加_防御) * base.刀画龙点睛);
							break;
						case 571:
							base.剑百毒不侵 = num2 * num3;
							break;
						case 572:
							base.枪寒冰领域 = num2 * num3;
							break;
						case 573:
							base.弓恶尽矢穷 = num2 * num3;
							break;
						case 574:
							base.医生云心月性 = num2 * num3;
							break;
						case 575:
							base.刺客外刚内刚 = num2 * num3;
							人物_气功_追加_HP += (int)((double)(FLD_防御 + FLD_装备_追加_防御) * base.刺客外刚内刚);
							break;
						case 576:
							base.乐师血脉上升 = num2 * num3;
							break;
						case 577:
							base.韩飞官真气还原 = num2 * num3;
							break;
						case 578:
							base.谭花灵电光朝露 = num2 * num3;
							break;
						case 579:
							base.格斗家无障无碍 = num2 * num3;
							break;
						case 580:
							base.梅柳真化险为夷 = num2 * num3;
							break;
						case 581:
							base.卢风郎反弹无效 = num2 * num3;
							break;
						case 582:
							base.神女抗击身法 = num2 * num3;
							break;
						}
					}
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "计算升天气功出错" + ex.ToString());
				}
			}
		}

		public int 得到气功ID(int i, int job)
		{
			int result = 0;
			foreach (气功加成属性 value in World.气功加成.Values)
			{
				if (value.FLD_JOB == job && value.FLD_INDEX == i)
				{
					result = value.FLD_PID;
				}
			}
			return result;
		}

		public void 读出人物装备数据(DataTable dBToDataTable)
		{
			byte[] array22 = (byte[])dBToDataTable.Rows[0]["FLD_WEARITEM"];
			for (int num19 = 0; num19 < 装备栏已穿装备.Length; num19++)
			{
				byte[] array23 = new byte[World.数据库单个物品大小];
				if (array22.Length >= num19 * World.数据库单个物品大小 + World.数据库单个物品大小)
				{
					try
					{
						Buffer.BlockCopy(array22, num19 * World.数据库单个物品大小, array23, 0, World.数据库单个物品大小);
					}
					catch (Exception ex13)
					{
						MainForm.WriteLine(num19, "  " + ex13);
					}
				}
				装备栏已穿装备[num19] = new 物品类(array23, num19);
				byte[] array24 = new byte[4];
				Buffer.BlockCopy(装备栏已穿装备[num19].物品_byte, World.物品属性大小, array24, 0, 4);
				int num20 = BitConverter.ToInt32(array24, 0);
				if (num20 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num20)).TotalSeconds >= 0.0)
				{
					系统提示("已穿装备栏有物品过期[" + 装备栏已穿装备[num19].得到物品名称() + "],系统已删除！", 9, "系统提示");
					装备栏已穿装备[num19].物品_byte = new byte[World.数据库单个物品大小];
				}
				if (World.AllItmelog != 1)
				{
					continue;
				}
				try
				{
					if (装备栏已穿装备[num19].得到物品位置类型() != 1 && 装备栏已穿装备[num19].得到物品位置类型() != 2 && 装备栏已穿装备[num19].得到物品位置类型() != 5 && 装备栏已穿装备[num19].得到物品位置类型() != 6)
					{
						if (装备栏已穿装备[num19].得到物品位置类型() != 4 && 装备栏已穿装备[num19].得到物品位置类型() == 12 && (装备栏已穿装备[num19].属性1.属性类型 == 7 || 装备栏已穿装备[num19].属性2.属性类型 == 7 || 装备栏已穿装备[num19].属性3.属性类型 == 7 || 装备栏已穿装备[num19].属性4.属性类型 == 7))
						{
							MainForm.WriteLine(6, "发现WG防物品  装备栏已穿装备  [" + Userid + "]-[" + UserName + "]  位置[" + num19 + "]  编号[" + BitConverter.ToInt32(装备栏已穿装备[num19].物品全局ID, 0) + "]  物品名称[" + 装备栏已穿装备[num19].得到物品名称() + "]  物品数量[" + BitConverter.ToInt32(装备栏已穿装备[num19].物品数量, 0) + "]  属性:[" + 装备栏已穿装备[num19].FLD_MAGIC0 + "," + 装备栏已穿装备[num19].FLD_MAGIC1 + "," + 装备栏已穿装备[num19].FLD_MAGIC2 + "," + 装备栏已穿装备[num19].FLD_MAGIC3 + "," + 装备栏已穿装备[num19].FLD_MAGIC4 + "]");
							装备栏已穿装备[num19].物品_byte = new byte[World.数据库单个物品大小];
						}
					}
					else if (装备栏已穿装备[num19].属性1.属性类型 == 7 || 装备栏已穿装备[num19].属性2.属性类型 == 7 || 装备栏已穿装备[num19].属性3.属性类型 == 7 || 装备栏已穿装备[num19].属性4.属性类型 == 7)
					{
						MainForm.WriteLine(6, "发现WG防物品  装备栏已穿装备  [" + Userid + "]-[" + UserName + "]  位置[" + num19 + "]  编号[" + BitConverter.ToInt32(装备栏已穿装备[num19].物品全局ID, 0) + "]  物品名称[" + 装备栏已穿装备[num19].得到物品名称() + "]  物品数量[" + BitConverter.ToInt32(装备栏已穿装备[num19].物品数量, 0) + "]  属性:[" + 装备栏已穿装备[num19].FLD_MAGIC0 + "," + 装备栏已穿装备[num19].FLD_MAGIC1 + "," + 装备栏已穿装备[num19].FLD_MAGIC2 + "," + 装备栏已穿装备[num19].FLD_MAGIC3 + "," + 装备栏已穿装备[num19].FLD_MAGIC4 + "]");
						装备栏已穿装备[num19].物品_byte = new byte[World.数据库单个物品大小];
					}
				}
				catch (Exception ex12)
				{
					string[] array25 = new string[24]
					{
						"查物品错误        装备栏包裹  错误  [",
						Userid,
						"]-[",
						UserName,
						"]  位置[",
						num19.ToString(),
						"]  编号[",
						BitConverter.ToInt32(装备栏已穿装备[num19].物品全局ID, 0).ToString(),
						"]  物品名称[",
						装备栏已穿装备[num19].得到物品名称(),
						"]  物品数量[",
						BitConverter.ToInt32(装备栏已穿装备[num19].物品数量, 0).ToString(),
						"]  属性:[",
						装备栏已穿装备[num19].FLD_MAGIC0.ToString(),
						",",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					array25[15] = 装备栏已穿装备[num19].FLD_MAGIC1.ToString();
					array25[16] = ",";
					array25[17] = 装备栏已穿装备[num19].FLD_MAGIC2.ToString();
					array25[18] = ",";
					array25[19] = 装备栏已穿装备[num19].FLD_MAGIC3.ToString();
					array25[20] = ",";
					array25[21] = 装备栏已穿装备[num19].FLD_MAGIC4.ToString();
					array25[22] = "]";
					array25[23] = ex12?.ToString();
					MainForm.WriteLine(1, string.Concat(array25));
				}
			}
			byte[] array26 = (byte[])dBToDataTable.Rows[0]["FLD_WEARITEMFZ"];
			for (int num21 = 0; num21 < 15; num21++)
			{
				byte[] array27 = new byte[World.数据库单个物品大小];
				if (array26.Length >= num21 * World.数据库单个物品大小 + World.数据库单个物品大小)
				{
					try
					{
						Buffer.BlockCopy(array26, num21 * World.数据库单个物品大小, array27, 0, World.数据库单个物品大小);
					}
					catch (Exception ex14)
					{
						MainForm.WriteLine(num21, "  " + ex14);
					}
				}
				辅助装备栏装备[num21] = new 物品类(array27, num21);
				byte[] array28 = new byte[4];
				Buffer.BlockCopy(辅助装备栏装备[num21].物品_byte, World.物品属性大小, array28, 0, 4);
				int num22 = BitConverter.ToInt32(array28, 0);
				if (num22 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num22)).TotalSeconds >= 0.0)
				{
					系统提示("已穿装备栏有物品过期[" + 辅助装备栏装备[num21].得到物品名称() + "],系统已删除！", 9, "系统提示");
					辅助装备栏装备[num21 - 16].物品_byte = new byte[World.数据库单个物品大小];
				}
				if (World.AllItmelog != 1)
				{
					continue;
				}
				try
				{
					if (辅助装备栏装备[num21].得到物品位置类型() != 1 && 辅助装备栏装备[num21].得到物品位置类型() != 2 && 辅助装备栏装备[num21].得到物品位置类型() != 5 && 辅助装备栏装备[num21].得到物品位置类型() != 6)
					{
						if (辅助装备栏装备[num21].得到物品位置类型() != 4 && 辅助装备栏装备[num21].得到物品位置类型() == 12 && (辅助装备栏装备[num21].属性1.属性类型 == 7 || 辅助装备栏装备[num21].属性2.属性类型 == 7 || 辅助装备栏装备[num21].属性3.属性类型 == 7 || 辅助装备栏装备[num21].属性4.属性类型 == 7))
						{
							MainForm.WriteLine(6, "发现WG防物品  辅助装备栏装备  [" + Userid + "]-[" + UserName + "]  位置[" + num21 + "]  编号[" + BitConverter.ToInt32(辅助装备栏装备[num21].物品全局ID, 0) + "]  物品名称[" + 辅助装备栏装备[num21].得到物品名称() + "]  物品数量[" + BitConverter.ToInt32(辅助装备栏装备[num21].物品数量, 0) + "]  属性:[" + 辅助装备栏装备[num21].FLD_MAGIC0 + "," + 辅助装备栏装备[num21].FLD_MAGIC1 + "," + 辅助装备栏装备[num21].FLD_MAGIC2 + "," + 辅助装备栏装备[num21].FLD_MAGIC3 + "," + 辅助装备栏装备[num21].FLD_MAGIC4 + "]");
							辅助装备栏装备[num21].物品_byte = new byte[World.数据库单个物品大小];
						}
					}
					else if (辅助装备栏装备[num21].属性1.属性类型 == 7 || 辅助装备栏装备[num21].属性2.属性类型 == 7 || 辅助装备栏装备[num21].属性3.属性类型 == 7 || 辅助装备栏装备[num21].属性4.属性类型 == 7)
					{
						MainForm.WriteLine(6, "发现WG防物品  辅助装备栏装备  [" + Userid + "]-[" + UserName + "]  位置[" + num21 + "]  编号[" + BitConverter.ToInt32(辅助装备栏装备[num21].物品全局ID, 0) + "]  物品名称[" + 辅助装备栏装备[num21].得到物品名称() + "]  物品数量[" + BitConverter.ToInt32(辅助装备栏装备[num21].物品数量, 0) + "]  属性:[" + 辅助装备栏装备[num21].FLD_MAGIC0 + "," + 辅助装备栏装备[num21].FLD_MAGIC1 + "," + 辅助装备栏装备[num21].FLD_MAGIC2 + "," + 辅助装备栏装备[num21].FLD_MAGIC3 + "," + 辅助装备栏装备[num21].FLD_MAGIC4 + "]");
						辅助装备栏装备[num21].物品_byte = new byte[World.数据库单个物品大小];
					}
				}
				catch (Exception ex10)
				{
					string[] array29 = new string[24]
					{
						"查物品错误        装备栏包裹  错误  [",
						Userid,
						"]-[",
						UserName,
						"]  位置[",
						num21.ToString(),
						"]  编号[",
						BitConverter.ToInt32(辅助装备栏装备[num21].物品全局ID, 0).ToString(),
						"]  物品名称[",
						辅助装备栏装备[num21].得到物品名称(),
						"]  物品数量[",
						BitConverter.ToInt32(辅助装备栏装备[num21].物品数量, 0).ToString(),
						"]  属性:[",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					array29[13] = 辅助装备栏装备[num21].FLD_MAGIC0.ToString();
					array29[14] = ",";
					array29[15] = 辅助装备栏装备[num21].FLD_MAGIC1.ToString();
					array29[16] = ",";
					array29[17] = 辅助装备栏装备[num21].FLD_MAGIC2.ToString();
					array29[18] = ",";
					array29[19] = 辅助装备栏装备[num21].FLD_MAGIC3.ToString();
					array29[20] = ",";
					array29[21] = 辅助装备栏装备[num21].FLD_MAGIC4.ToString();
					array29[22] = "]";
					array29[23] = ex10?.ToString();
					MainForm.WriteLine(1, string.Concat(array29));
				}
			}
			byte[] array30 = (byte[])dBToDataTable.Rows[0]["FLD_WEARITEMBZ"];
			for (int num23 = 0; num23 < 15; num23++)
			{
				byte[] array31 = new byte[World.数据库单个物品大小];
				if (array30.Length >= num23 * World.数据库单个物品大小 + World.数据库单个物品大小)
				{
					try
					{
						Buffer.BlockCopy(array30, num23 * World.数据库单个物品大小, array31, 0, World.数据库单个物品大小);
					}
					catch (Exception ex15)
					{
						MainForm.WriteLine(num23, "  " + ex15);
					}
				}
				宝珠装备栏装备[num23] = new 物品类(array31, num23);
				byte[] array32 = new byte[4];
				Buffer.BlockCopy(宝珠装备栏装备[num23].物品_byte, World.物品属性大小, array32, 0, 4);
				int num24 = BitConverter.ToInt32(array32, 0);
				if (num24 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num24)).TotalSeconds >= 0.0)
				{
					系统提示("已穿装备栏有物品过期[" + 宝珠装备栏装备[num23].得到物品名称() + "],系统已删除！", 9, "系统提示");
					宝珠装备栏装备[num23].物品_byte = new byte[World.数据库单个物品大小];
				}
				if (World.AllItmelog != 1)
				{
					continue;
				}
				try
				{
					if (宝珠装备栏装备[num23].得到物品位置类型() != 1 && 宝珠装备栏装备[num23].得到物品位置类型() != 2 && 宝珠装备栏装备[num23].得到物品位置类型() != 5 && 宝珠装备栏装备[num23].得到物品位置类型() != 6)
					{
						if (宝珠装备栏装备[num23].得到物品位置类型() != 4 && 宝珠装备栏装备[num23].得到物品位置类型() == 12 && (宝珠装备栏装备[num23].属性1.属性类型 == 7 || 宝珠装备栏装备[num23].属性2.属性类型 == 7 || 宝珠装备栏装备[num23].属性3.属性类型 == 7 || 宝珠装备栏装备[num23].属性4.属性类型 == 7))
						{
							MainForm.WriteLine(6, "发现WG防物品  宝珠装备栏装备  [" + Userid + "]-[" + UserName + "]  位置[" + num23 + "]  编号[" + BitConverter.ToInt32(宝珠装备栏装备[num23].物品全局ID, 0) + "]  物品名称[" + 宝珠装备栏装备[num23].得到物品名称() + "]  物品数量[" + BitConverter.ToInt32(宝珠装备栏装备[num23].物品数量, 0) + "]  属性:[" + 宝珠装备栏装备[num23].FLD_MAGIC0 + "," + 宝珠装备栏装备[num23].FLD_MAGIC1 + "," + 宝珠装备栏装备[num23].FLD_MAGIC2 + "," + 宝珠装备栏装备[num23].FLD_MAGIC3 + "," + 宝珠装备栏装备[num23].FLD_MAGIC4 + "]");
							宝珠装备栏装备[num23].物品_byte = new byte[World.数据库单个物品大小];
						}
					}
					else if (宝珠装备栏装备[num23].属性1.属性类型 == 7 || 宝珠装备栏装备[num23].属性2.属性类型 == 7 || 宝珠装备栏装备[num23].属性3.属性类型 == 7 || 宝珠装备栏装备[num23].属性4.属性类型 == 7)
					{
						MainForm.WriteLine(6, "发现WG防物品  宝珠装备栏装备  [" + Userid + "]-[" + UserName + "]  位置[" + num23 + "]  编号[" + BitConverter.ToInt32(宝珠装备栏装备[num23].物品全局ID, 0) + "]  物品名称[" + 宝珠装备栏装备[num23].得到物品名称() + "]  物品数量[" + BitConverter.ToInt32(宝珠装备栏装备[num23].物品数量, 0) + "]  属性:[" + 宝珠装备栏装备[num23].FLD_MAGIC0 + "," + 宝珠装备栏装备[num23].FLD_MAGIC1 + "," + 宝珠装备栏装备[num23].FLD_MAGIC2 + "," + 宝珠装备栏装备[num23].FLD_MAGIC3 + "," + 宝珠装备栏装备[num23].FLD_MAGIC4 + "]");
						宝珠装备栏装备[num23].物品_byte = new byte[World.数据库单个物品大小];
					}
				}
				catch (Exception ex11)
				{
					string[] array33 = new string[24]
					{
						"查物品错误        装备栏包裹  错误  [",
						Userid,
						"]-[",
						UserName,
						"]  位置[",
						num23.ToString(),
						"]  编号[",
						BitConverter.ToInt32(宝珠装备栏装备[num23].物品全局ID, 0).ToString(),
						"]  物品名称[",
						宝珠装备栏装备[num23].得到物品名称(),
						"]  物品数量[",
						BitConverter.ToInt32(宝珠装备栏装备[num23].物品数量, 0).ToString(),
						"]  属性:[",
						宝珠装备栏装备[num23].FLD_MAGIC0.ToString(),
						",",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					array33[15] = 宝珠装备栏装备[num23].FLD_MAGIC1.ToString();
					array33[16] = ",";
					array33[17] = 宝珠装备栏装备[num23].FLD_MAGIC2.ToString();
					array33[18] = ",";
					array33[19] = 宝珠装备栏装备[num23].FLD_MAGIC3.ToString();
					array33[20] = ",";
					array33[21] = 宝珠装备栏装备[num23].FLD_MAGIC4.ToString();
					array33[22] = "]";
					array33[23] = ex11?.ToString();
					MainForm.WriteLine(1, string.Concat(array33));
				}
			}
		}

		public void 读出人物数据()
		{
			int num = 0;
			try
			{
				Clear();
				DataTable dBToDataTable = DBA.GetDBToDataTable("select * from [TBL_XWWL_Char] where FLD_ID=@Userid and FLD_NAME =@Username", new SqlParameter[2]
				{
					SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 30, Userid),
					SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, UserName)
				});
				if (dBToDataTable.Rows.Count == 0 && Client != null)
				{
					Client.Dispose();
				}
				GM模式 = (int)dBToDataTable.Rows[0]["FLD_J9"];
				人物位置 = (int)dBToDataTable.Rows[0]["FLD_INDEX"];
				_人物历练 = (int)dBToDataTable.Rows[0]["FLD_FIGHT_EXP"];
				_人物经验 = long.Parse(dBToDataTable.Rows[0]["FLD_EXP"].ToString());
				try
				{
					_人物钱数 = long.Parse(dBToDataTable.Rows[0]["FLD_MONEY"].ToString());
					_武皇通币 = (int)dBToDataTable.Rows[0]["FLD_WHTB"];
				}
				catch
				{
					_人物钱数 = 0L;
					_武皇通币 = 0;
				}
				_人物没加气功点 = (int)dBToDataTable.Rows[0]["FLD_POINT"];
				_人物正邪 = (int)dBToDataTable.Rows[0]["FLD_ZX"];
				_人物等级 = (int)dBToDataTable.Rows[0]["FLD_LEVEL"];
				_人物职业 = (int)dBToDataTable.Rows[0]["FLD_JOB"];
				_人物职业等级 = (int)dBToDataTable.Rows[0]["FLD_JOB_LEVEL"];
				New人物模版 = new 人物模板类((byte[])dBToDataTable.Rows[0]["FLD_FACE"]);
				_人物名字模版 = (byte[])dBToDataTable.Rows[0]["FLD_NAMETYPE"];
				_人物性别 = New人物模版.性别;
				if (_人物性别 != 0 && (int)dBToDataTable.Rows[0]["FLD_性别"] == 0)
				{
					DBA.ExeSqlCommand($"UPDATE [TBL_XWWL_Char] SET FLD_性别={_人物性别} WHERE FLD_NAME='{UserName}'", "GameServer");
				}
				_人物_HP = (int)dBToDataTable.Rows[0]["FLD_HP"];
				_人物_MP = (int)dBToDataTable.Rows[0]["FLD_MP"];
				_人物_SP = (int)dBToDataTable.Rows[0]["FLD_SP"];
				FLD_PVP_Piont = (int)dBToDataTable.Rows[0]["FLD_PVP_Piont"];
				FLD_制作类型 = (int)dBToDataTable.Rows[0]["FLD_ZzType"];
				FLD_制作熟练度 = (int)dBToDataTable.Rows[0]["FLD_ZzSl"];
				_人物坐标_X = float.Parse(dBToDataTable.Rows[0]["FLD_X"].ToString());
				_人物坐标_Y = float.Parse(dBToDataTable.Rows[0]["FLD_Y"].ToString());
				_人物坐标_Z = float.Parse(dBToDataTable.Rows[0]["FLD_Z"].ToString());
				目标坐标X = _人物坐标_X;
				目标坐标Y = _人物坐标_Y;
				目标坐标Z = _人物坐标_Z;
				装备数据版本 = (int)dBToDataTable.Rows[0]["FLD_ZBVER"];
				_人物坐标_地图 = (int)dBToDataTable.Rows[0]["FLD_MENOW"];
				if ((_人物性别 < 1 || _人物性别 > 2) && Client != null)
				{
					Client.Dispose();
				}
				新坐标 = new 坐标Class(人物坐标_X, 人物坐标_Y, 人物坐标_Z, 人物坐标_地图);
				Player_WuXun = (int)dBToDataTable.Rows[0]["FLD_WX"];
				人物善恶 = (int)dBToDataTable.Rows[0]["FLD_SE"];
				人物轻功 = (int)dBToDataTable.Rows[0]["FLD_JQ"];
				FLD_情侣 = dBToDataTable.Rows[0]["FLD_QlNAME"].ToString();
				FLD_情侣戒指 = dBToDataTable.Rows[0]["FLD_QlJZNAME"].ToString();
				FLD_情侣_爱情度 = (int)dBToDataTable.Rows[0]["FLD_QlDu"];
				婚戒刻字 = dBToDataTable.Rows[0]["FLD_LOVE_WORD"].ToString();
				解除关系倒计时 = (int)dBToDataTable.Rows[0]["FLD_MARITAL_STATUS"];
				是否已婚 = (int)dBToDataTable.Rows[0]["FLD_MARRIED"];
				升天武功点数 = (int)dBToDataTable.Rows[0]["FLD_升天武功点"];
				升天历练数 = (int)dBToDataTable.Rows[0]["FLD_升天历练"];
				_FLD_结婚纪念日 = (DateTime)dBToDataTable.Rows[0]["FLD_JH_DATE"];
				修炼地图剩余时间 = (int)dBToDataTable.Rows[0]["FLD_FB_TIME"];
				活动地图剩余时间 = (int)dBToDataTable.Rows[0]["FLD_HD_TIME"];
				丢失武勋 = (int)dBToDataTable.Rows[0]["FLD_LOST_WX"];
				每日获得武勋 = (int)dBToDataTable.Rows[0]["FLD_GET_WX"];
				_人物分区ID = dBToDataTable.Rows[0]["FLD_FQID"].ToString();
				玫瑰称号积分 = (int)dBToDataTable.Rows[0]["FLD_玫瑰称号积分"];
				_门派贡献度 = (int)dBToDataTable.Rows[0]["门派贡献度"];
				客户端设置 = dBToDataTable.Rows[0]["FLD_CONFIG"].ToString();
				神女武功点数 = (int)dBToDataTable.Rows[0]["FLD_神女武功点"];
				元宝消费2 = (int)dBToDataTable.Rows[0]["FLD_YBXF"];
				称号积分 = (int)dBToDataTable.Rows[0]["FLD_称号积分"];
				任务次数 = (int)dBToDataTable.Rows[0]["FLD_任务次数"];
				_转生_追加_攻击 = (int)dBToDataTable.Rows[0]["FLD_ADD_AT"];
				_转生_追加_防御 = (int)dBToDataTable.Rows[0]["FLD_ADD_DF"];
				_转生_追加_生命 = (int)dBToDataTable.Rows[0]["FLD_ADD_HP"];
				_转生次数 = (int)dBToDataTable.Rows[0]["FLD_ZS"];
				_累计充值 = (int)dBToDataTable.Rows[0]["FLD_CZPH"];
				_FLD_精力时间 = DateTime.Parse(dBToDataTable.Rows[0]["攻城时间"].ToString());
				_讨伐次数 = (int)dBToDataTable.Rows[0]["FLD_讨伐次数"];
				_讨伐累计伤害 = (int)dBToDataTable.Rows[0]["FLD_讨伐伤害"];
				_杀人次数 = (int)dBToDataTable.Rows[0]["杀人次数"];
				_被杀次数 = (int)dBToDataTable.Rows[0]["被杀次数"];
				AccumulatedDamage = (int)dBToDataTable.Rows[0]["累计伤害"];
				BOSS累计伤害 = (int)dBToDataTable.Rows[0]["FLD_BOSS伤害"];
				_深渊BOSS累计伤害 = (int)dBToDataTable.Rows[0]["深渊BOSS伤害"];
				if ((int)dBToDataTable.Rows[0]["是否假人"] == 0)
				{
					DBA.ExeSqlCommand($"UPDATE [TBL_XWWL_Char] SET 是否假人={账号是否假人} WHERE FLD_NAME='{UserName}'", "GameServer");
					_是否假人 = 账号是否假人;
				}
				else
				{
					_是否假人 = (int)dBToDataTable.Rows[0]["是否假人"];
				}
				_恢复精力 = (int)dBToDataTable.Rows[0]["FLD_JL"];
				if (人物分区ID != World.ZoneNumber)
				{
					_人物分区ID = World.ZoneNumber;
					DBA.ExeSqlCommand("UPDATE [TBL_XWWL_Char] SET FLD_FQID='" + World.ZoneNumber + "' WHERE FLD_ID='" + Userid + "'", "GameServer");
				}
				if (Player_ExpErience < 0)
				{
					Player_ExpErience = 0;
				}
				if (升天历练数 < 0)
				{
					升天历练数 = 0;
				}
				if (Player_Qigong_point < 0)
				{
					Player_Qigong_point = 0;
				}
				num = 1;
				师傅数据.TID = -1;
				int num22;
				for (int num16 = 0; num16 < 3; num16 = num22)
				{
					徒弟数据[num16] = new 师徒类
					{
						TID = -1
					};
					num22 = num16 + 1;
				}
				DataTable dataTable = RxjhClass.得到师傅数据(UserName);
				if (dataTable != null)
				{
					师傅数据.TID = (int)dataTable.Rows[0]["FLD_INDEX"];
					师傅数据.STNAME = dataTable.Rows[0]["FLD_SNAME"].ToString();
					师傅数据.TLEVEL = (int)dataTable.Rows[0]["FLD_TLEVEL"];
					师傅数据.STLEVEL = (int)dataTable.Rows[0]["FLD_STLEVEL"];
					师傅数据.STYHD = (int)dataTable.Rows[0]["FLD_STYHD"];
					师傅数据.STWG1 = (int)dataTable.Rows[0]["FLD_STWG1"];
					师傅数据.STWG2 = (int)dataTable.Rows[0]["FLD_STWG2"];
					师傅数据.STWG3 = (int)dataTable.Rows[0]["FLD_STWG3"];
					dataTable.Dispose();
				}
				else
				{
					DataTable dataTable2 = RxjhClass.得到徒弟数据(UserName);
					if (dataTable2 != null)
					{
						for (int num33 = 0; num33 < dataTable2.Rows.Count; num33 = num22)
						{
							int num38 = (int)dataTable2.Rows[num33]["FLD_INDEX"];
							if (num38 <= 2)
							{
								徒弟数据[num38].TID = (int)dataTable2.Rows[num33]["FLD_INDEX"];
								徒弟数据[num38].STNAME = dataTable2.Rows[num33]["FLD_TNAME"].ToString();
								徒弟数据[num38].TLEVEL = (int)dataTable2.Rows[num33]["FLD_TLEVEL"];
								徒弟数据[num38].STLEVEL = (int)dataTable2.Rows[num33]["FLD_STLEVEL"];
								徒弟数据[num38].STYHD = (int)dataTable2.Rows[num33]["FLD_STYHD"];
								徒弟数据[num38].STWG1 = (int)dataTable2.Rows[num33]["FLD_STWG1"];
								徒弟数据[num38].STWG2 = (int)dataTable2.Rows[num33]["FLD_STWG2"];
								徒弟数据[num38].STWG3 = (int)dataTable2.Rows[num33]["FLD_STWG3"];
							}
							num22 = num33 + 1;
						}
						dataTable2.Dispose();
					}
				}
				int num39 = 0;
				if (dBToDataTable.Rows[0]["FLD_升天气功"] != DBNull.Value)
				{
					byte[] array = (byte[])dBToDataTable.Rows[0]["FLD_升天气功"];
					if (Player_Job_leve >= 6)
					{
						for (int num40 = 0; num40 < 15; num22 = num40 + 1, num40 = num22)
						{
							byte[] array15 = new byte[4];
							try
							{
								if (array.Length < num40 * 4 + 4)
								{
									break;
								}
								Buffer.BlockCopy(array, num40 * 4, array15, 0, 4);
								升天气功类 升天气功类2 = new 升天气功类(array15);
								if (!World.升天气功List.TryGetValue(升天气功类2.气功ID, out var value))
								{
									continue;
								}
								switch (Player_Job)
								{
								case 1:
									if (value.人物职业1 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 2:
									if (value.人物职业2 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 3:
									if (value.人物职业3 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 4:
									if (value.人物职业4 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 5:
									if (value.人物职业5 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 6:
									if (value.人物职业6 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 7:
									if (value.人物职业7 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 8:
									if (value.人物职业8 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 9:
									if (value.人物职业9 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 10:
									if (value.人物职业10 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 11:
									if (value.人物职业11 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 12:
									if (value.人物职业12 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								case 13:
									if (value.人物职业13 == 1 && !GetSTQG(升天气功类2.气功ID))
									{
										升天气功.Add(升天气功类2.气功ID, 升天气功类2);
										num39 += 升天气功类2.气功量;
									}
									break;
								}
								continue;
							}
							catch
							{
								continue;
							}
						}
					}
				}
				num = 5;
				byte[] array21 = new byte[20];
				byte[] array31 = (byte[])dBToDataTable.Rows[0]["FLD_SKILLS"];
				Buffer.BlockCopy(array31, 0, array21, 0, array31.Length);
				for (int num41 = 0; num41 < 15; num41 = num22)
				{
					byte[] array42 = new byte[2];
					try
					{
						if (array21.Length > num41 + 1)
						{
							Buffer.BlockCopy(array21, num41, array42, 0, 1);
						}
					}
					catch
					{
					}
					气功[num41] = new 气功类(array42);
					switch (num41)
					{
					default:
						if (num41 < 12)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
						}
						break;
					case 0:
						if (Player_Level >= 1)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 1:
						if (Player_Level >= 1)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 2:
						if (Player_Level >= 1)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 3:
						if (Player_Level >= 1)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 4:
						if (Player_Level >= 1)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 5:
						if (Player_Level >= 10 && Player_Job_leve >= 1)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 6:
						if (Player_Level >= 10 && Player_Job_leve >= 1)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 7:
						if (Player_Level >= 35 && Player_Job_leve >= 2)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 8:
						if (Player_Level >= 60 && Player_Job_leve >= 3)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 9:
						if (Player_Level >= 80 && Player_Job_leve >= 4)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 10:
						if (Player_Level >= 90 && Player_Job_leve >= 4)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					case 11:
						if (Player_Level >= 100 && Player_Job_leve >= 5)
						{
							气功[num41].气功ID = 得到气功ID(num41, Player_Job);
							if (气功[num41].气功量 == 255)
							{
								气功[num41].气功量 = 0;
							}
						}
						break;
					}
					num22 = num41 + 1;
				}
				int num42 = 0;
				for (int num2 = 0; num2 < 12; num2 = num22)
				{
					byte[] 气功_byte = 气功[num2].气功_byte;
					int num3 = BitConverter.ToInt16(气功_byte, 0);
					if (气功_byte[0] != byte.MaxValue)
					{
						num42 += num3;
					}
					num22 = num2 + 1;
				}
				int num4 = 0;
				for (int i = 2; i < Player_Level + 1; i++)
				{
					num4 = ((i <= 120) ? ((i <= 35) ? (num4 + 1) : (num4 + 2)) : (num4 + 3));
				}
				if (num42 + Player_Qigong_point + num39 != num4)
				{
					if (num42 + num39 > num4 - Player_Qigong_point)
					{
						Player_Qigong_point = num4;
						for (int num5 = 0; num5 < 12; num5 = num22)
						{
							if (BitConverter.ToInt16(气功[num5].气功_byte, 0) != 255)
							{
								气功[num5].气功_byte = new byte[2];
							}
							num22 = num5 + 1;
						}
						foreach (升天气功类 value4 in 升天气功.Values)
						{
							value4.气功量 = 0;
						}
					}
					else
					{
						Player_Qigong_point = num4 - num42 - num39;
					}
				}
				num = 6;
				byte[] array53 = (byte[])dBToDataTable.Rows[0]["FLD_KONGFU"];
				for (int num6 = 0; num6 < 78; num22 = num6 + 1, num6 = num22)
				{
					byte[] array64 = new byte[4];
					byte[] array65 = new byte[4];
					try
					{
						if (array53.Length < num6 * 8 + 8)
						{
							break;
						}
						Buffer.BlockCopy(array53, num6 * 8, array64, 0, 4);
						Buffer.BlockCopy(array53, num6 * 8 + 4, array65, 0, 4);
						int num7 = BitConverter.ToInt32(array64, 0);
						if (num7 == 0)
						{
							continue;
						}
						int num10 = BitConverter.ToInt32(array65, 0);
						if (num7 == 1000701)
						{
							num7 = ((Player_Zx != 1) ? 1020701 : 1010701);
						}
						if (num7 != 0)
						{
							武功类 武功类2 = new 武功类(num7);
							if ((武功类2.FLD_JOB == 0 || Player_Job == 武功类2.FLD_JOB) && (武功类2.FLD_ZX == 0 || Player_Zx == 武功类2.FLD_ZX) && Player_Job_leve >= 武功类2.FLD_JOBLEVEL && Player_Level >= 武功类2.FLD_LEVEL)
							{
								武功类2.武功_等级 = ((num10 < 武功类2.FLD_武功最高级别) ? num10 : 武功类2.FLD_武功最高级别);
								武功新[武功类2.FLD_武功类型, 武功类2.FLD_INDEX] = 武功类2;
							}
						}
						continue;
					}
					catch
					{
						continue;
					}
				}
				if (Player_Job_leve >= 5 && ((Player_Job != 8) & (Player_Job != 13)))
				{
					if (武功新[0, 25] == null)
					{
						Client.Player.学习技能(0, 25);
					}
					if (武功新[0, 26] == null)
					{
						Client.Player.学习技能(0, 26);
					}
					if (武功新[0, 27] == null)
					{
						Client.Player.学习技能(0, 27);
					}
				}
				if (武功新[1, 2] != null)
				{
					人物轻功 = 2;
				}
				else if (武功新[1, 1] != null)
				{
					人物轻功 = 1;
				}
				if (dBToDataTable.Rows[0]["FLD_升天武功"] != DBNull.Value)
				{
					byte[] array66 = (byte[])dBToDataTable.Rows[0]["FLD_升天武功"];
					int num13 = 0;
					while (num13 < 32 && array66.Length >= num13 * 8 + 8)
					{
						int fLD_PID_ = BitConverter.ToInt32(array66, num13 * 8);
						int num14 = BitConverter.ToInt32(array66, num13 * 8 + 4);
						武功类 武功类3 = new 武功类(fLD_PID_);
						武功类3.武功_等级 = ((num14 < 武功类3.FLD_武功最高级别) ? num14 : 武功类3.FLD_武功最高级别);
						if ((武功类3.FLD_JOB == 0 || Player_Job == 武功类3.FLD_JOB) && (武功类3.FLD_ZX == 0 || Player_Zx == 武功类3.FLD_ZX) && Player_Job_leve >= 武功类3.FLD_JOBLEVEL && Player_Level >= 武功类3.FLD_LEVEL)
						{
							武功新[武功类3.FLD_武功类型, 武功类3.FLD_INDEX] = 武功类3;
						}
						num22 = num13 + 1;
						num13 = num22;
					}
				}
				if (Player_Job_leve >= 6 && Player_Job == 8)
				{
					if (武功新[3, 9] == null)
					{
						Client.Player.学习技能(3, 9);
					}
					if (武功新[3, 10] == null)
					{
						Client.Player.学习技能(3, 10);
					}
					if (武功新[3, 11] == null)
					{
						Client.Player.学习技能(3, 11);
					}
				}
				num = 7;
				byte[] array2 = (byte[])dBToDataTable.Rows[0]["FLD_QITEM"];
				for (int num15 = 0; num15 < 36; num15 = num22)
				{
					byte[] array3 = new byte[8];
					if (array2.Length >= num15 * 8 + 8)
					{
						try
						{
							Buffer.BlockCopy(array2, num15 * 8, array3, 0, 8);
						}
						catch (Exception ex19)
						{
							Console.WriteLine(num15 + " " + ex19);
						}
					}
					任务物品[num15] = new 任务物品类(array3);
					num22 = num15 + 1;
				}
				num = 8;
				byte[] array4 = (byte[])dBToDataTable.Rows[0]["FLD_ITEM"];
				for (int num17 = 0; num17 < 96; num17 = num22)
				{
					byte[] array5 = new byte[World.数据库单个物品大小];
					if (array4.Length >= num17 * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array4, num17 * World.数据库单个物品大小, array5, 0, World.数据库单个物品大小);
						}
						catch (Exception ex20)
						{
							MainForm.WriteLine(num17, " " + ex20);
						}
					}
					装备栏包裹[num17] = new 物品类(array5, num17);
					if (装备栏包裹[num17].Get物品ID == 1008001507)
					{
						是否携带披风行囊 = true;
					}
					if (num17 < 96)
					{
						_人物当前负重 += 装备栏包裹[num17].物品总重量;
					}
					byte[] array6 = new byte[4];
					Buffer.BlockCopy(装备栏包裹[num17].物品_byte, World.物品属性大小, array6, 0, 4);
					int num18 = BitConverter.ToInt32(array6, 0);
					if (num18 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num18)).TotalSeconds >= 0.0)
					{
						系统提示("背包有物品过期[" + 装备栏包裹[num17].得到物品名称() + "], 系统已删除！", 9, "系统提示");
						装备栏包裹[num17].物品_byte = new byte[World.数据库单个物品大小];
					}
					if (World.AllItmelog == 1)
					{
						try
						{
							if (装备栏包裹[num17].得到物品位置类型() == 1 || 装备栏包裹[num17].得到物品位置类型() == 2 || 装备栏包裹[num17].得到物品位置类型() == 5 || 装备栏包裹[num17].得到物品位置类型() == 6)
							{
								if (装备栏包裹[num17].属性1.属性类型 == 7 || 装备栏包裹[num17].属性2.属性类型 == 7 || 装备栏包裹[num17].属性3.属性类型 == 7 || 装备栏包裹[num17].属性4.属性类型 == 7)
								{
									MainForm.WriteLine(6, "发现WG防物品 装备栏包裹 [" + Userid + "]-[" + UserName + "] 位置[" + num17 + "] 编号[" + BitConverter.ToInt32(装备栏包裹[num17].物品全局ID, 0) + "] 物品名称[" + 装备栏包裹[num17].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(装备栏包裹[num17].物品数量, 0) + "] 属性:[" + 装备栏包裹[num17].FLD_MAGIC0 + ", " + 装备栏包裹[num17].FLD_MAGIC1 + ", " + 装备栏包裹[num17].FLD_MAGIC2 + ", " + 装备栏包裹[num17].FLD_MAGIC3 + ", " + 装备栏包裹[num17].FLD_MAGIC4 + "]");
									装备栏包裹[num17].物品_byte = new byte[World.数据库单个物品大小];
								}
							}
							else if (装备栏包裹[num17].得到物品位置类型() != 4 && 装备栏包裹[num17].得到物品位置类型() == 12 && (装备栏包裹[num17].属性1.属性类型 == 7 || 装备栏包裹[num17].属性2.属性类型 == 7 || 装备栏包裹[num17].属性3.属性类型 == 7 || 装备栏包裹[num17].属性4.属性类型 == 7))
							{
								MainForm.WriteLine(6, "发现WG防物品 装备栏包裹 [" + Userid + "]-[" + UserName + "] 位置[" + num17 + "] 编号[" + BitConverter.ToInt32(装备栏包裹[num17].物品全局ID, 0) + "] 物品名称[" + 装备栏包裹[num17].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(装备栏包裹[num17].物品数量, 0) + "] 属性:[" + 装备栏包裹[num17].FLD_MAGIC0 + ", " + 装备栏包裹[num17].FLD_MAGIC1 + ", " + 装备栏包裹[num17].FLD_MAGIC2 + ", " + 装备栏包裹[num17].FLD_MAGIC3 + ", " + 装备栏包裹[num17].FLD_MAGIC4 + "]");
								装备栏包裹[num17].物品_byte = new byte[World.数据库单个物品大小];
							}
						}
						catch (Exception ex17)
						{
							string[] array7 = new string[24]
							{
								"查物品错误 装备栏包裹 错误[",
								Userid,
								"]-[",
								UserName,
								"] 位置[",
								num17.ToString(),
								"] 编号[",
								BitConverter.ToInt32(装备栏包裹[num17].物品全局ID, 0).ToString(),
								"] 物品名称[",
								装备栏包裹[num17].得到物品名称(),
								"] 物品数量[",
								BitConverter.ToInt32(装备栏包裹[num17].物品数量, 0).ToString(),
								"] 属性:[",
								装备栏包裹[num17].FLD_MAGIC0.ToString(),
								", ",
								null,
								null,
								null,
								null,
								null,
								null,
								null,
								null,
								null
							};
							array7[15] = 装备栏包裹[num17].FLD_MAGIC1.ToString();
							array7[16] = ", ";
							array7[17] = 装备栏包裹[num17].FLD_MAGIC2.ToString();
							array7[18] = ", ";
							array7[19] = 装备栏包裹[num17].FLD_MAGIC3.ToString();
							array7[20] = ", ";
							array7[21] = 装备栏包裹[num17].FLD_MAGIC4.ToString();
							array7[22] = "]";
							array7[23] = ex17?.ToString();
							MainForm.WriteLine(1, string.Concat(array7));
						}
					}
					num22 = num17 + 1;
				}
				num = 9;
				byte[] array8 = (byte[])dBToDataTable.Rows[0]["FLD_FASHION_ITEM"];
				for (int j = 0; j < 66; j++)
				{
					byte[] array9 = new byte[World.数据库单个物品大小];
					if (array8.Length >= j * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array8, j * World.数据库单个物品大小, array9, 0, World.数据库单个物品大小);
						}
						catch (Exception ex21)
						{
							MainForm.WriteLine(j, " " + ex21);
						}
					}
					披风行囊[j] = new 物品类(array9, j);
					byte[] array10 = new byte[4];
					Buffer.BlockCopy(披风行囊[j].物品_byte, 56, array10, 0, 4);
					int num19 = BitConverter.ToInt32(array10, 0);
					if (num19 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num19)).TotalSeconds >= 0.0)
					{
						系统提示("披风行囊有物品过期[" + 披风行囊[j].得到物品名称() + "], 系统已删除！", 9, "系统提示");
						披风行囊[j].物品_byte = new byte[World.数据库单个物品大小];
					}
				}
				num = 100;
				byte[] array11 = (byte[])dBToDataTable.Rows[0]["FLD_NSZITEM"];
				for (int k = 0; k < 6; k++)
				{
					byte[] array16 = new byte[World.数据库单个物品大小];
					if (array11.Length >= k * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array11, k * World.数据库单个物品大小, array16, 0, World.数据库单个物品大小);
						}
						catch (Exception ex22)
						{
							Console.WriteLine(k + " " + ex22);
						}
					}
					凝神珠包裹[k] = new 物品类(array16, k);
					byte[] array20 = new byte[4];
					Buffer.BlockCopy(凝神珠包裹[k].物品_byte, 56, array20, 0, 4);
					int num20 = BitConverter.ToInt32(array20, 0);
					if (num20 > 0)
					{
						DateTime dateTime = new DateTime(1970, 1, 1, 8, 0, 0);
						if (DateTime.Now.Subtract(dateTime.AddSeconds(num20)).TotalSeconds >= 0.0)
						{
							系统提示("背包有物品过期[" + 凝神珠包裹[k].得到物品名称() + "], 系统已删除！", 9, "[系统]");
							凝神珠包裹[k].物品_byte = new byte[World.数据库单个物品大小];
						}
					}
					if (World.AllItmelog == 1)
					{
						try
						{
							if (凝神珠包裹[k].得到物品位置类型() != 1 && 凝神珠包裹[k].得到物品位置类型() != 2 && 凝神珠包裹[k].得到物品位置类型() != 5 && 凝神珠包裹[k].得到物品位置类型() != 6)
							{
								if (凝神珠包裹[k].得到物品位置类型() != 4 && 凝神珠包裹[k].得到物品位置类型() == 12 && (凝神珠包裹[k].属性1.属性类型 == 7 || 凝神珠包裹[k].属性2.属性类型 == 7 || 凝神珠包裹[k].属性3.属性类型 == 7 || 凝神珠包裹[k].属性4.属性类型 == 7))
								{
									MainForm.WriteLine(6, "发现WG防物品 凝神珠包裹 [" + Userid + "]-[" + UserName + "] 位置[" + k + "] 编号[" + BitConverter.ToInt32(凝神珠包裹[k].物品全局ID, 0) + "] 物品名称[" + 凝神珠包裹[k].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(凝神珠包裹[k].物品数量, 0) + "] 属性:[" + 凝神珠包裹[k].FLD_MAGIC0 + ", " + 凝神珠包裹[k].FLD_MAGIC1 + ", " + 凝神珠包裹[k].FLD_MAGIC2 + ", " + 凝神珠包裹[k].FLD_MAGIC3 + ", " + 凝神珠包裹[k].FLD_MAGIC4 + "]");
									凝神珠包裹[k].物品_byte = new byte[World.数据库单个物品大小];
								}
							}
							else if (凝神珠包裹[k].属性1.属性类型 == 7 || 凝神珠包裹[k].属性2.属性类型 == 7 || 凝神珠包裹[k].属性3.属性类型 == 7 || 凝神珠包裹[k].属性4.属性类型 == 7)
							{
								MainForm.WriteLine(6, "发现WG防物品 凝神珠包裹 [" + Userid + "]-[" + UserName + "] 位置[" + k + "] 编号[" + BitConverter.ToInt32(凝神珠包裹[k].物品全局ID, 0) + "] 物品名称[" + 凝神珠包裹[k].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(凝神珠包裹[k].物品数量, 0) + "] 属性:[" + 凝神珠包裹[k].FLD_MAGIC0 + ", " + 凝神珠包裹[k].FLD_MAGIC1 + ", " + 凝神珠包裹[k].FLD_MAGIC2 + ", " + 凝神珠包裹[k].FLD_MAGIC3 + ", " + 凝神珠包裹[k].FLD_MAGIC4 + "]");
								凝神珠包裹[k].物品_byte = new byte[World.数据库单个物品大小];
							}
						}
						catch (Exception ex18)
						{
							MainForm.WriteLine(1, "查物品错误 凝神珠包裹 错误[" + Userid + "]-[" + UserName + "] 位置[" + k + "] 编号[" + BitConverter.ToInt32(凝神珠包裹[k].物品全局ID, 0) + "] 物品名称[" + 凝神珠包裹[k].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(凝神珠包裹[k].物品数量, 0) + "] 属性:[" + 凝神珠包裹[k].FLD_MAGIC0 + ", " + 凝神珠包裹[k].FLD_MAGIC1 + ", " + 凝神珠包裹[k].FLD_MAGIC2 + ", " + 凝神珠包裹[k].FLD_MAGIC3 + ", " + 凝神珠包裹[k].FLD_MAGIC4 + "]" + ex18);
						}
					}
					_人物当前负重 += 凝神珠包裹[k].物品总重量;
				}
				num = 43;
				byte[] array12 = (byte[])dBToDataTable.Rows[0]["FLD_HNITEM"];
				for (int num8 = 0; num8 < 3; num8++)
				{
					byte[] array13 = new byte[World.数据库单个物品大小];
					if (array12.Length >= num8 * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array12, num8 * World.数据库单个物品大小, array13, 0, World.数据库单个物品大小);
						}
						catch (Exception ex23)
						{
							MainForm.WriteLine(num8, "丨" + ex23);
						}
					}
					行囊包裹[num8] = new 物品类(array13, num8);
					if (行囊包裹[num8].Get物品ID == 1008001507)
					{
						是否携带披风行囊 = true;
					}
					byte[] array14 = new byte[4];
					Buffer.BlockCopy(行囊包裹[num8].物品_byte, 56, array14, 0, 4);
					int num11 = BitConverter.ToInt32(array14, 0);
					if (num11 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num11)).TotalSeconds >= 0.0 && 行囊包裹[num8].Get物品ID != 1600001)
					{
						系统提示("三格行囊有物品过期[" + 行囊包裹[num8].得到物品名称() + "],系统已删除！", 9, "系统提示");
						行囊包裹[num8].物品_byte = new byte[World.数据库单个物品大小];
					}
				}
				num = 44;
				byte[] array17 = (byte[])dBToDataTable.Rows[0]["FLD_ZHHNITEM"];
				for (int num9 = 0; num9 < 24; num9++)
				{
					byte[] array18 = new byte[World.数据库单个物品大小];
					if (array17.Length >= num9 * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array17, num9 * World.数据库单个物品大小, array18, 0, World.数据库单个物品大小);
						}
						catch (Exception ex24)
						{
							MainForm.WriteLine(num9, "丨" + ex24);
						}
					}
					杂货行囊包裹[num9] = new 物品类(array18, num9);
					byte[] array19 = new byte[4];
					Buffer.BlockCopy(杂货行囊包裹[num9].物品_byte, 56, array19, 0, 4);
					int num12 = BitConverter.ToInt32(array19, 0);
					if (num12 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num12)).TotalSeconds >= 0.0)
					{
						系统提示("杂货行囊有物品过期[" + 杂货行囊包裹[num9].得到物品名称() + "],系统已删除！", 9, "系统提示");
						杂货行囊包裹[num9].物品_byte = new byte[World.数据库单个物品大小];
					}
				}
				num = 10;
				读出人物装备数据(dBToDataTable);
				num = 11;
				byte[] array22 = (byte[])dBToDataTable.Rows[0]["FLD_QUEST"];
				for (int num21 = 0; num21 < 100; num22 = num21 + 1, num21 = num22)
				{
					byte[] array23 = new byte[4];
					try
					{
						if (array22.Length >= num21 * 4 + 4)
						{
							Buffer.BlockCopy(array22, num21 * 4, array23, 0, 4);
							任务类 任务类2 = new 任务类(array23);
							if (任务类2.任务ID != 0 && !任务.ContainsKey(任务类2.任务ID))
							{
								任务.TryAdd(任务类2.任务ID, 任务类2);
							}
							continue;
						}
					}
					catch (Exception value5)
					{
						Console.WriteLine(value5);
						continue;
					}
					break;
				}
				num = 12;
				byte[] array24 = (byte[])dBToDataTable.Rows[0]["FLD_QUEST_FINISH"];
				for (int num23 = 0; num23 < 500; num22 = num23 + 1, num23 = num22)
				{
					byte[] array25 = new byte[2];
					try
					{
						if (array24.Length >= num23 * 2 + 2)
						{
							Buffer.BlockCopy(array24, num23 * 2, array25, 0, 2);
							int num24 = BitConverter.ToInt16(array25, 0);
							if (num24 != 0 && !已完成任务.Values.Contains(num24))
							{
								已完成任务.TryAdd(num24, num24);
							}
							continue;
						}
					}
					catch
					{
						continue;
					}
					break;
				}
				num = 13;
				传书列表.Clear();
				DataTable dataTable3 = RxjhClass.得到传书列表(UserName);
				if (dataTable3 != null)
				{
					for (int num25 = 0; num25 < dataTable3.Rows.Count; num25 = num22)
					{
						个人传书类 个人传书类2 = new 个人传书类();
						个人传书类2.传书ID = (int)dataTable3.Rows[num25]["ID"];
						个人传书类2.是否NPC = (int)dataTable3.Rows[num25]["发送NPC"];
						个人传书类2.传书发送人 = dataTable3.Rows[num25]["发送人物名"].ToString();
						个人传书类2.传书内容 = dataTable3.Rows[num25]["传书内容"].ToString();
						个人传书类2.传书时间 = DateTime.Parse(dataTable3.Rows[num25]["传书时间"].ToString());
						个人传书类2.是否已读 = (int)dataTable3.Rows[num25]["阅读标识"];
						个人传书类 个人传书类3 = 个人传书类2;
						传书列表.TryAdd(个人传书类3.传书ID, 个人传书类3);
						num22 = num25 + 1;
					}
					dataTable3.Dispose();
				}
				num = 144;
				DataTable userCWarehouse = RxjhClass.GetUserCWarehouse(Userid, UserName);
				if (userCWarehouse == null && Client != null)
				{
					Client.Dispose();
				}
				byte[] array26 = (byte[])userCWarehouse.Rows[0]["FLD_ITEM"];
				for (int l = 0; l < 20; l++)
				{
					byte[] array27 = new byte[World.数据库单个物品大小];
					if (array26.Length >= l * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array26, l * World.数据库单个物品大小, array27, 0, World.数据库单个物品大小);
						}
						catch (Exception value6)
						{
							Console.WriteLine(value6);
						}
					}
					灵宠仓库[l] = new 物品类(array27, l);
					byte[] array28 = new byte[4];
					Buffer.BlockCopy(灵宠仓库[l].物品_byte, 56, array28, 0, 4);
					int num26 = BitConverter.ToInt32(array28, 0);
					if (num26 > 0)
					{
						DateTime dateTime2 = new DateTime(1970, 1, 1, 8, 0, 0);
						if (DateTime.Now.Subtract(dateTime2.AddSeconds(num26)).TotalSeconds >= 0.0)
						{
							系统提示("灵宠仓库有物品过期[" + 灵宠仓库[l].得到物品名称() + "], 系统已删除！", 9, "[系统]");
							灵宠仓库[l].物品_byte = new byte[World.数据库单个物品大小];
						}
					}
				}
				userCWarehouse.Dispose();
				num = 145;
				DataTable userLSarehouse = RxjhClass.GetUserLSarehouse(Userid, UserName);
				if (userLSarehouse == null && Client != null)
				{
					Client.Dispose();
				}
				byte[] array29 = (byte[])userLSarehouse.Rows[0]["FLD_ITEM"];
				for (int m = 0; m < 2; m++)
				{
					byte[] array30 = new byte[World.数据库单个物品大小];
					if (array29.Length >= m * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array29, m * World.数据库单个物品大小, array30, 0, World.数据库单个物品大小);
						}
						catch (Exception value7)
						{
							Console.WriteLine(value7);
						}
					}
					灵兽仓库[m] = new 物品类(array30, m);
					byte[] array32 = new byte[4];
					Buffer.BlockCopy(灵兽仓库[m].物品_byte, 56, array32, 0, 4);
					int num27 = BitConverter.ToInt32(array32, 0);
					if (num27 > 0)
					{
						DateTime dateTime3 = new DateTime(1970, 1, 1, 8, 0, 0);
						if (DateTime.Now.Subtract(dateTime3.AddSeconds(num27)).TotalSeconds >= 0.0)
						{
							系统提示("灵宠仓库有物品过期[" + 灵兽仓库[m].得到物品名称() + "], 系统已删除！", 9, "[系统]");
							灵兽仓库[m].物品_byte = new byte[World.数据库单个物品大小];
						}
					}
				}
				userLSarehouse.Dispose();
				num = 14;
				DataTable userWarehouse = RxjhClass.GetUserWarehouse(Userid, UserName);
				if (userWarehouse == null && Client != null)
				{
					Client.Dispose();
				}
				if (userWarehouse.Rows[0] == null && Client != null)
				{
					Client.Dispose();
				}
				byte[] array33 = (byte[])userWarehouse.Rows[0]["FLD_ITEM"];
				try
				{
					个人仓库钱数 = long.Parse(userWarehouse.Rows[0]["FLD_MONEY"].ToString());
				}
				catch
				{
					个人仓库钱数 = 0L;
				}
				for (int num28 = 0; num28 < 60; num28 = num22)
				{
					byte[] array34 = new byte[World.数据库单个物品大小];
					if (array33.Length >= num28 * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array33, num28 * World.数据库单个物品大小, array34, 0, World.数据库单个物品大小);
						}
						catch (Exception value8)
						{
							Console.WriteLine(value8);
						}
					}
					个人仓库[num28] = new 物品类(array34, num28);
					if (个人仓库[num28].Get物品ID == 1008001507)
					{
						是否携带披风行囊 = true;
					}
					byte[] array35 = new byte[4];
					Buffer.BlockCopy(个人仓库[num28].物品_byte, 56, array35, 0, 4);
					int num29 = BitConverter.ToInt32(array35, 0);
					if (num29 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num29)).TotalSeconds >= 0.0)
					{
						系统提示("个人仓库有物品过期[" + 个人仓库[num28].得到物品名称() + "], 系统已删除！", 9, "系统提示");
						个人仓库[num28].物品_byte = new byte[World.数据库单个物品大小];
					}
					if (World.AllItmelog == 1)
					{
						try
						{
							if (个人仓库[num28].得到物品位置类型() == 1 || 个人仓库[num28].得到物品位置类型() == 2 || 个人仓库[num28].得到物品位置类型() == 5 || 个人仓库[num28].得到物品位置类型() == 6)
							{
								if (个人仓库[num28].属性1.属性类型 == 7 || 个人仓库[num28].属性2.属性类型 == 7 || 个人仓库[num28].属性3.属性类型 == 7 || 个人仓库[num28].属性4.属性类型 == 7)
								{
									MainForm.WriteLine(6, "发现WG防物品 个人仓库 [" + Userid + "]-[" + UserName + "] 位置[" + num28 + "] 编号[" + BitConverter.ToInt32(个人仓库[num28].物品全局ID, 0) + "] 物品名称[" + 个人仓库[num28].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(个人仓库[num28].物品数量, 0) + "] 属性:[" + 个人仓库[num28].FLD_MAGIC0 + ", " + 个人仓库[num28].FLD_MAGIC1 + ", " + 个人仓库[num28].FLD_MAGIC2 + ", " + 个人仓库[num28].FLD_MAGIC3 + ", " + 个人仓库[num28].FLD_MAGIC4 + "]");
									个人仓库[num28].物品_byte = new byte[World.数据库单个物品大小];
								}
							}
							else if (个人仓库[num28].得到物品位置类型() != 4 && 个人仓库[num28].得到物品位置类型() == 12 && (个人仓库[num28].属性1.属性类型 == 7 || 个人仓库[num28].属性2.属性类型 == 7 || 个人仓库[num28].属性3.属性类型 == 7 || 个人仓库[num28].属性4.属性类型 == 7))
							{
								MainForm.WriteLine(6, "发现WG防物品 个人仓库 [" + Userid + "]-[" + UserName + "] 位置[" + num28 + "] 编号[" + BitConverter.ToInt32(个人仓库[num28].物品全局ID, 0) + "] 物品名称[" + 个人仓库[num28].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(个人仓库[num28].物品数量, 0) + "] 属性:[" + 个人仓库[num28].FLD_MAGIC0 + ", " + 个人仓库[num28].FLD_MAGIC1 + ", " + 个人仓库[num28].FLD_MAGIC2 + ", " + 个人仓库[num28].FLD_MAGIC3 + ", " + 个人仓库[num28].FLD_MAGIC4 + "]");
								个人仓库[num28].物品_byte = new byte[World.数据库单个物品大小];
							}
						}
						catch (Exception ex13)
						{
							string[] array36 = new string[24]
							{
								"查物品错误 个人仓库 错误 [",
								Userid,
								"]-[",
								UserName,
								"] 位置[",
								num28.ToString(),
								"] 编号[",
								BitConverter.ToInt32(个人仓库[num28].物品全局ID, 0).ToString(),
								"] 物品名称[",
								个人仓库[num28].得到物品名称(),
								"] 物品数量[",
								BitConverter.ToInt32(个人仓库[num28].物品数量, 0).ToString(),
								"] 属性:[",
								个人仓库[num28].FLD_MAGIC0.ToString(),
								", ",
								null,
								null,
								null,
								null,
								null,
								null,
								null,
								null,
								null
							};
							array36[15] = 个人仓库[num28].FLD_MAGIC1.ToString();
							array36[16] = ", ";
							array36[17] = 个人仓库[num28].FLD_MAGIC2.ToString();
							array36[18] = ", ";
							array36[19] = 个人仓库[num28].FLD_MAGIC3.ToString();
							array36[20] = ", ";
							array36[21] = 个人仓库[num28].FLD_MAGIC4.ToString();
							array36[22] = "]";
							array36[23] = ex13?.ToString();
							MainForm.WriteLine(1, string.Concat(array36));
						}
					}
					num22 = num28 + 1;
				}
				userWarehouse.Dispose();
				num = 15;
				DataTable userPublicWarehouse = RxjhClass.GetUserPublicWarehouse(Userid);
				if (userPublicWarehouse == null && Client != null)
				{
					Client.Dispose();
				}
				byte[] array37 = (byte[])userPublicWarehouse.Rows[0]["FLD_ITEM"];
				综合仓库装备数据版本 = (int)userPublicWarehouse.Rows[0]["FLD_ZBVER"];
				byte[] src = (byte[])userPublicWarehouse.Rows[0]["FLD_ITIME"];
				try
				{
					综合仓库钱数 = long.Parse(userPublicWarehouse.Rows[0]["FLD_MONEY"].ToString());
				}
				catch
				{
					综合仓库钱数 = 0L;
				}
				for (int num30 = 0; num30 < 60; num30 = num22)
				{
					byte[] array38 = new byte[World.数据库单个物品大小];
					if (array37.Length >= num30 * World.数据库单个物品大小 + World.数据库单个物品大小)
					{
						try
						{
							Buffer.BlockCopy(array37, num30 * World.数据库单个物品大小, array38, 0, World.数据库单个物品大小);
						}
						catch (Exception value9)
						{
							Console.WriteLine(value9);
						}
					}
					公共仓库[num30] = new 物品类(array38, num30);
					if (公共仓库[num30].Get物品ID == 1008001507)
					{
						是否携带披风行囊 = true;
					}
					byte[] array39 = new byte[4];
					Buffer.BlockCopy(公共仓库[num30].物品_byte, 56, array39, 0, 4);
					int num31 = BitConverter.ToInt32(array39, 0);
					if (num31 > 0 && DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(num31)).TotalSeconds >= 0.0)
					{
						系统提示("公共仓库有物品过期[" + 公共仓库[num30].得到物品名称() + "], 系统已删除！", 9, "系统提示");
						公共仓库[num30].物品_byte = new byte[World.数据库单个物品大小];
					}
					if (World.AllItmelog == 1)
					{
						try
						{
							if (公共仓库[num30].得到物品位置类型() == 1 || 公共仓库[num30].得到物品位置类型() == 2 || 公共仓库[num30].得到物品位置类型() == 5 || 公共仓库[num30].得到物品位置类型() == 6)
							{
								if (公共仓库[num30].属性1.属性类型 == 7 || 公共仓库[num30].属性2.属性类型 == 7 || 公共仓库[num30].属性3.属性类型 == 7 || 公共仓库[num30].属性4.属性类型 == 7)
								{
									MainForm.WriteLine(6, "发现WG防物品 公共仓库 [" + Userid + "]-[" + UserName + "] 位置[" + num30 + "] 编号[" + BitConverter.ToInt32(公共仓库[num30].物品全局ID, 0) + "] 物品名称[" + 公共仓库[num30].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(公共仓库[num30].物品数量, 0) + "] 属性:[" + 公共仓库[num30].FLD_MAGIC0 + ", " + 公共仓库[num30].FLD_MAGIC1 + ", " + 公共仓库[num30].FLD_MAGIC2 + ", " + 公共仓库[num30].FLD_MAGIC3 + ", " + 公共仓库[num30].FLD_MAGIC4 + "]");
									公共仓库[num30].物品_byte = new byte[World.数据库单个物品大小];
								}
							}
							else if (公共仓库[num30].得到物品位置类型() != 4 && 公共仓库[num30].得到物品位置类型() == 12 && (公共仓库[num30].属性1.属性类型 == 7 || 公共仓库[num30].属性2.属性类型 == 7 || 公共仓库[num30].属性3.属性类型 == 7 || 公共仓库[num30].属性4.属性类型 == 7))
							{
								MainForm.WriteLine(6, "发现WG防物品 公共仓库 [" + Userid + "]-[" + UserName + "] 位置[" + num30 + "] 编号[" + BitConverter.ToInt32(公共仓库[num30].物品全局ID, 0) + "] 物品名称[" + 公共仓库[num30].得到物品名称() + "] 物品数量[" + BitConverter.ToInt32(公共仓库[num30].物品数量, 0) + "] 属性:[" + 公共仓库[num30].FLD_MAGIC0 + ", " + 公共仓库[num30].FLD_MAGIC1 + ", " + 公共仓库[num30].FLD_MAGIC2 + ", " + 公共仓库[num30].FLD_MAGIC3 + ", " + 公共仓库[num30].FLD_MAGIC4 + "]");
								公共仓库[num30].物品_byte = new byte[World.数据库单个物品大小];
							}
						}
						catch (Exception ex14)
						{
							string[] array40 = new string[24]
							{
								"查物品错误 个人仓库 错误 [",
								Userid,
								"]-[",
								UserName,
								"] 位置[",
								num30.ToString(),
								"] 编号[",
								BitConverter.ToInt32(公共仓库[num30].物品全局ID, 0).ToString(),
								"] 物品名称[",
								公共仓库[num30].得到物品名称(),
								"] 物品数量[",
								BitConverter.ToInt32(公共仓库[num30].物品数量, 0).ToString(),
								"] 属性:[",
								公共仓库[num30].FLD_MAGIC0.ToString(),
								", ",
								null,
								null,
								null,
								null,
								null,
								null,
								null,
								null,
								null
							};
							array40[15] = 公共仓库[num30].FLD_MAGIC1.ToString();
							array40[16] = ", ";
							array40[17] = 公共仓库[num30].FLD_MAGIC2.ToString();
							array40[18] = ", ";
							array40[19] = 公共仓库[num30].FLD_MAGIC3.ToString();
							array40[20] = ", ";
							array40[21] = 公共仓库[num30].FLD_MAGIC4.ToString();
							array40[22] = "]";
							array40[23] = ex14?.ToString();
							MainForm.WriteLine(1, string.Concat(array40));
						}
					}
					num22 = num30 + 1;
				}
				userPublicWarehouse.Dispose();
				byte[] array41 = (byte[])dBToDataTable.Rows[0]["FLD_STIME"];
				if (array41 != null && array41.Length > 1)
				{
					byte[] array43 = new byte[16];
					Buffer.BlockCopy(array41, 0, array43, 0, 16);
					for (int num32 = 0; num32 < 40; num22 = num32 + 1, num32 = num22)
					{
						try
						{
							byte[] array44 = new byte[4];
							byte[] array45 = new byte[4];
							Buffer.BlockCopy(array43, num32 * 8, array44, 0, 4);
							Buffer.BlockCopy(array43, num32 * 8 + 4, array45, 0, 4);
							if (BitConverter.ToInt32(array44, 0) > 0)
							{
								if (!时间药品.ContainsKey(BitConverter.ToInt32(array44, 0)))
								{
									时间药品类 时间药品类2 = new 时间药品类();
									时间药品类2.药品ID = BitConverter.ToInt32(array44, 0);
									时间药品类2.时间 = BitConverter.ToUInt32(array45, 0);
									时间药品类 时间药品类3 = 时间药品类2;
									时间药品.TryAdd(时间药品类3.药品ID, 时间药品类3);
								}
								continue;
							}
						}
						catch (Exception value10)
						{
							Console.WriteLine(value10);
							continue;
						}
						break;
					}
				}
				byte[] array46 = (byte[])dBToDataTable.Rows[0]["FLD_CHTIME"];
				if (array46 != null && array46.Length > 1)
				{
					byte[] array47 = new byte[16];
					Buffer.BlockCopy(array46, 0, array47, 0, 16);
					for (int num34 = 0; num34 < 40; num22 = num34 + 1, num34 = num22)
					{
						try
						{
							byte[] array48 = new byte[4];
							byte[] array49 = new byte[4];
							Buffer.BlockCopy(array47, num34 * 8, array48, 0, 4);
							Buffer.BlockCopy(array47, num34 * 8 + 4, array49, 0, 4);
							if (BitConverter.ToInt32(array48, 0) > 0)
							{
								if (!称号药品.ContainsKey(BitConverter.ToInt32(array48, 0)))
								{
									称号药品类 称号药品类2 = new 称号药品类();
									称号药品类2.药品ID = BitConverter.ToInt32(array48, 0);
									称号药品类2.时间 = BitConverter.ToUInt32(array49, 0);
									称号药品类 称号药品类3 = 称号药品类2;
									称号药品.TryAdd(称号药品类3.药品ID, 称号药品类3);
								}
								continue;
							}
						}
						catch (Exception value11)
						{
							Console.WriteLine(value11);
							continue;
						}
						break;
					}
				}
				num = 16;
				byte[] array50 = (byte[])dBToDataTable.Rows[0]["FLD_TSTIME"];
				if (array50 != null && array50.Length > 1)
				{
					byte[] array51 = new byte[16];
					Buffer.BlockCopy(array50, 0, array51, 0, 16);
					for (int num35 = 0; num35 < 40; num22 = num35 + 1, num35 = num22)
					{
						try
						{
							byte[] array52 = new byte[4];
							byte[] array54 = new byte[4];
							Buffer.BlockCopy(array51, num35 * 8, array52, 0, 4);
							Buffer.BlockCopy(array51, num35 * 8 + 4, array54, 0, 4);
							if (BitConverter.ToInt32(array52, 0) > 0)
							{
								if (!特殊药品.ContainsKey(BitConverter.ToInt32(array52, 0)))
								{
									特殊药品类 特殊药品类2 = new 特殊药品类();
									特殊药品类2.药品ID = BitConverter.ToInt32(array52, 0);
									特殊药品类2.时间 = BitConverter.ToUInt32(array54, 0);
									特殊药品类 特殊药品类3 = 特殊药品类2;
									特殊药品.TryAdd(特殊药品类3.药品ID, 特殊药品类3);
								}
								continue;
							}
						}
						catch (Exception value12)
						{
							Console.WriteLine(value12);
							continue;
						}
						break;
					}
				}
				num = 17;
				个人药品 = null;
				if (!dBToDataTable.Rows[0]["FLD_CTIME"].Equals(null))
				{
					个人药品 = (byte[])dBToDataTable.Rows[0]["FLD_CTIME"];
				}
				if (!dBToDataTable.Rows[0]["FLD_CTIMENEW"].Equals(null))
				{
					追加状态物品New = (byte[])dBToDataTable.Rows[0]["FLD_CTIMENEW"];
				}
				byte[] array55 = new byte[16];
				Buffer.BlockCopy(src, 0, array55, 0, 16);
				for (int num36 = 0; num36 < 2; num36 = num22)
				{
					try
					{
						byte[] array56 = new byte[4];
						byte[] array57 = new byte[4];
						Buffer.BlockCopy(array55, num36 * 8, array56, 0, 4);
						Buffer.BlockCopy(array55, num36 * 8 + 4, array57, 0, 4);
						DateTime t = new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(BitConverter.ToInt32(array57, 0));
						if (!(t < DateTime.Now) && BitConverter.ToInt32(array56, 0) > 0 && !公有药品.ContainsKey(BitConverter.ToInt32(array56, 0)))
						{
							公有药品类 公有药品类2 = new 公有药品类();
							公有药品类2.药品ID = BitConverter.ToInt32(array56, 0);
							公有药品类2.时间 = BitConverter.ToUInt32(array57, 0);
							公有药品类 公有药品类3 = 公有药品类2;
							公有药品.TryAdd(公有药品类3.药品ID, 公有药品类3);
						}
					}
					catch (Exception value2)
					{
						Console.WriteLine(value2);
					}
					num22 = num36 + 1;
				}
				num = 17;
				byte[] array58 = null;
				if (dBToDataTable.Rows[0]["FLD_DOORS"] != null)
				{
					array58 = (byte[])dBToDataTable.Rows[0]["FLD_DOORS"];
				}
				土灵符坐标.Clear();
				if (array58.Length >= 128)
				{
					for (int num37 = 0; num37 < 30; num37 = num22)
					{
						try
						{
							byte[] array59 = new byte[4];
							byte[] array60 = new byte[4];
							byte[] array61 = new byte[4];
							byte[] array62 = new byte[4];
							byte[] array63 = new byte[14];
							Buffer.BlockCopy(array58, num37 * 32 + 15, array62, 0, 4);
							Buffer.BlockCopy(array58, num37 * 32 + 19, array59, 0, 4);
							Buffer.BlockCopy(array58, num37 * 32 + 23, array60, 0, 4);
							Buffer.BlockCopy(array58, num37 * 32 + 27, array61, 0, 4);
							Buffer.BlockCopy(array58, num37 * 32, array63, 0, 14);
							string rxjh_name = Encoding.Default.GetString(array63).Trim();
							if ((double)BitConverter.ToSingle(array59, 0) != 0.0 || (double)BitConverter.ToSingle(array60, 0) != 0.0 || BitConverter.ToInt32(array62, 0) != 0)
							{
								坐标Class 坐标Class2 = new 坐标Class(BitConverter.ToSingle(array59, 0), BitConverter.ToSingle(array60, 0), BitConverter.ToSingle(array61, 0), BitConverter.ToInt32(array62, 0));
								坐标Class2.Rxjh_name = rxjh_name;
								坐标Class value3 = 坐标Class2;
								if (土灵符坐标.ContainsKey(10 + num37))
								{
									土灵符坐标.Remove(10 + num37);
								}
								土灵符坐标.Add(10 + num37, value3);
							}
						}
						catch
						{
						}
						num22 = num37 + 1;
					}
				}
				num = 18;
				DataTable userNameBp = RxjhClass.GetUserNameBp(UserName);
				if (userNameBp != null)
				{
					帮派Id = (int)userNameBp.Rows[0]["Id"];
					帮派名字 = userNameBp.Rows[0]["G_Name"].ToString();
					帮派人物等级 = (int)userNameBp.Rows[0]["leve"];
					DataTable dBToDataTable2 = DBA.GetDBToDataTable($"SELECT leve FROM TBL_XWWL_Guild WHERE ID ={帮派Id}");
					if (dBToDataTable2 != null)
					{
						帮派等级 = (int)dBToDataTable2.Rows[0]["leve"];
						dBToDataTable2.Dispose();
					}
					帮派门服字 = (int)userNameBp.Rows[0]["门服字"];
					帮派门服颜色 = (int)userNameBp.Rows[0]["门服颜色"];
					try
					{
						if (userNameBp.Rows[0]["Mh"] != DBNull.Value)
						{
							帮派门徽 = (byte[])userNameBp.Rows[0]["Mh"];
						}
					}
					catch (Exception ex15)
					{
						MainForm.WriteLine(2, "读帮派数据出错 " + Userid + " " + ex15.Message);
					}
					userNameBp.Dispose();
				}
				num = 19;
				num = 20;
				计算人物基本数据();
				dBToDataTable.Dispose();
				num = 21;
				装备数据版本 = 1;
				综合仓库装备数据版本 = 1;
			}
			catch (Exception ex16)
			{
				MainForm.WriteLine(1, num + "|读出人物数据出错 " + Userid + " " + ex16.Message);
				Client.Dispose();
			}
		}

		public void 记算夫妻武功攻击力数据()
		{
			if (武功新[2, 16] == null)
			{
				return;
			}
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < 32; i++)
			{
				if (武功新[3, i] != null)
				{
					int num = 武功新[3, i].FLD_AT + (武功新[3, i].武功_等级 - 1) * 武功新[3, i].FLD_每级加危害 / World.升天技能等级加成;
					if (num > 0)
					{
						升天气功武功等级 = 武功新[3, i].武功_等级;
						list.Add(num);
						int item = 武功新[3, i].FLD_MP + (武功新[3, i].武功_等级 - 1) * 武功新[3, i].FLD_每级加MP;
						list2.Add(item);
					}
				}
			}
			for (int j = 0; j < 32; j++)
			{
				if (武功新[0, j] != null)
				{
					int num2 = 武功新[0, j].FLD_AT + (武功新[0, j].武功_等级 - 1) * 武功新[0, j].FLD_每级加危害 / World.升天技能等级加成;
					if (num2 > 0)
					{
						list.Add(num2);
						list2.Add(武功新[0, j].FLD_MP);
					}
				}
			}
			int[] array = list.ToArray();
			int[] array2 = list2.ToArray();
			Array.Sort(array, array2);
			if (array.Length != 0)
			{
				夫妻武功攻击力 = array[array.Length - 1];
				夫妻武功攻击力MP = array2[array2.Length - 1];
			}
		}

		public void 读帮派数据()
		{
			DataTable userNameBp = RxjhClass.GetUserNameBp(UserName);
			if (userNameBp != null)
			{
				帮派Id = (int)userNameBp.Rows[0]["Id"];
				帮派名字 = userNameBp.Rows[0]["G_Name"].ToString();
				帮派人物等级 = (int)userNameBp.Rows[0]["leve"];
				DataTable dBToDataTable = DBA.GetDBToDataTable($"SELECT leve FROM TBL_XWWL_Guild WHERE ID ={帮派Id}");
				if (dBToDataTable != null)
				{
					帮派等级 = (int)dBToDataTable.Rows[0]["leve"];
					dBToDataTable.Dispose();
				}
				帮派门服字 = (int)userNameBp.Rows[0]["门服字"];
				帮派门服颜色 = (int)userNameBp.Rows[0]["门服颜色"];
				try
				{
					if (userNameBp.Rows[0]["Mh"] != DBNull.Value)
					{
						帮派门徽 = (byte[])userNameBp.Rows[0]["Mh"];
					}
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(2, "读出帮派数据出错 " + Userid + " " + ex.Message);
				}
				userNameBp.Dispose();
			}
			else
			{
				帮派Id = 0;
				帮派名字 = string.Empty;
				帮派等级 = 0;
				帮派人物等级 = 0;
				帮派门服颜色 = 0;
				帮派门服字 = 0;
				帮派门徽 = null;
			}
		}

		public void 更新门派等级(string 帮主)
		{
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_Guild WHERE G_Master ='" + 帮主 + "'");
				if (dBToDataTable == null)
				{
					return;
				}
				int num = (int)dBToDataTable.Rows[0]["胜"];
				int num2 = (int)dBToDataTable.Rows[0]["ID"];
				int num3 = (int)dBToDataTable.Rows[0]["leve"];
				int num4 = 5;
				if (num >= 3 && num < 8)
				{
					num4 = 6;
				}
				else if (num >= 8)
				{
					num4 = 7;
				}
				int num5 = num4;
				if (num3 != num5)
				{
					try
					{
						DBA.ExeSqlCommand(string.Format("UPDATE TBL_XWWL_Guild SET leve={1} WHERE ID={0}", num2, num4));
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "帮战 更新门派等级() 出错：" + ex);
						MainForm.WriteLine(100, "帮战 更新门派等级() 出错：" + ex);
					}
				}
				dBToDataTable.Dispose();
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "帮战 更新门派等级() 出错：" + ex2);
				MainForm.WriteLine(100, "帮战 更新门派等级 出错：" + ex2);
			}
		}

		public bool 判断星装(long pid, int reside2)
		{
			if (1 == 0)
			{
			}
			bool result = reside2 switch
			{
				1 => pid == 115301001 || pid == 115302001 || pid == 125301001 || pid == 125302001 || pid == 215301001 || pid == 215302001 || pid == 225301001 || pid == 225302001 || pid == 315301001 || pid == 315302001 || pid == 325301001 || pid == 325302001 || pid == 415301001 || pid == 415302001 || pid == 425301001 || pid == 425302001 || pid == 515301001 || pid == 515302001 || pid == 525301001 || pid == 525302001 || pid == 715301001 || pid == 715302001 || pid == 725301001 || pid == 725302001 || pid == 815301001 || pid == 815302001 || pid == 825301001 || pid == 825302001, 
				2 => pid == 725502001 || pid == 725501001 || pid == 715502001 || pid == 715501001 || pid == 525502001 || pid == 525501001 || pid == 515502001 || pid == 515501001 || pid == 425502001 || pid == 425501001 || pid == 415502001 || pid == 415501001 || pid == 325502001 || pid == 325501001 || pid == 315502001 || pid == 315501001 || pid == 225502001 || pid == 225501001 || pid == 215502001 || pid == 215501001 || pid == 125502001 || pid == 125501001 || pid == 115502001 || pid == 115501001 || pid == 815501001 || pid == 815502001 || pid == 825501001 || pid == 825502001, 
				5 => pid == 115801001 || pid == 115802001 || pid == 125801001 || pid == 125802001 || pid == 215801001 || pid == 215802001 || pid == 225801001 || pid == 225802001 || pid == 315801001 || pid == 315802001 || pid == 325801001 || pid == 325802001 || pid == 415801001 || pid == 415802001 || pid == 425801001 || pid == 425802001 || pid == 515801001 || pid == 515802001 || pid == 525801001 || pid == 525802001 || pid == 715801001 || pid == 715802001 || pid == 725801001 || pid == 725802001 || pid == 815801001 || pid == 815802001 || pid == 825801001 || pid == 825802001, 
				6 => pid == 115401001 || pid == 115402001 || pid == 125401001 || pid == 125402001 || pid == 215401001 || pid == 215402001 || pid == 225401001 || pid == 225402001 || pid == 315401001 || pid == 315402001 || pid == 325401001 || pid == 325402001 || pid == 415401001 || pid == 415402001 || pid == 425401001 || pid == 425402001 || pid == 515401001 || pid == 515402001 || pid == 525401001 || pid == 525402001 || pid == 715401001 || pid == 715402001 || pid == 725401001 || pid == 725402001 || pid == 815401001 || pid == 815402001 || pid == 825401001 || pid == 825402001, 
				_ => false, 
			};
			if (1 == 0)
			{
			}
			return result;
		}

		public bool 判断PVP装备(int pid, int level)
		{
			PVP类 value;
			return World.PVP装备.TryGetValue(pid, out value) && value.物品等级 == level;
		}

		public void 披风收录加成()
		{
			foreach (披风收录 value in World.披风收录buff.Values)
			{
				for (int i = 0; i < 60; i++)
				{
					if (披风行囊[i].Get物品ID == value.披风 && 装备栏已穿装备[11].FLD_RESIDE2 == 12 && Player_Sex == value.性别)
					{
						FLD_装备_追加_攻击 += value.攻击;
						FLD_装备_追加_防御 += value.防御;
						FLD_装备_追加_HP += value.血量;
						break;
					}
				}
			}
		}

		public void PVP装备加成()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < 6; i++)
			{
				if (判断PVP装备((int)装备栏已穿装备[i].Get物品ID, 110))
				{
					num++;
				}
				else if (判断PVP装备((int)装备栏已穿装备[i].Get物品ID, 120))
				{
					num2++;
				}
				else if (判断PVP装备((int)装备栏已穿装备[i].Get物品ID, 130))
				{
					num3++;
				}
				else if (判断PVP装备((int)装备栏已穿装备[i].Get物品ID, 140))
				{
					num4++;
				}
				else if (判断PVP装备((int)装备栏已穿装备[i].Get物品ID, 150))
				{
					num5++;
				}
				else if (判断PVP装备((int)装备栏已穿装备[i].Get物品ID, 160))
				{
					num6++;
				}
			}
			if (num > 0)
			{
				switch (Player_Job)
				{
				case 1:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 2:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				case 3:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				case 4:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 20;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_攻击 += 20;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.2;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 20;
						break;
					}
					break;
				case 5:
				case 13:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 50;
						FLD_装备_追加_MP += 1000;
						break;
					}
					break;
				case 6:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 20;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_攻击 += 20;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.2;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 20;
						break;
					}
					break;
				case 7:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_防御 += 90;
						FLD_装备_追加_MP += 1000;
						break;
					}
					break;
				case 8:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 9:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 10:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				case 11:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				case 12:
					switch (num)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				}
			}
			if (num2 > 0)
			{
				switch (Player_Job)
				{
				case 1:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 400;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 2:
				case 3:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 400;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_防御 += 80;
						break;
					}
					break;
				case 5:
				case 13:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 300;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 300;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_攻击 += 50;
						FLD_装备_追加_MP += 1000;
						break;
					}
					break;
				case 4:
				case 6:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_攻击 += 20;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_攻击 += 20;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.2;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_攻击 += 20;
						break;
					}
					break;
				case 7:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 300;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 300;
						FLD_装备_追加_防御 += 80;
						FLD_装备_追加_MP += 1000;
						break;
					}
					break;
				case 8:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 100;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 100;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 9:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 100;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 100;
						FLD_装备_追加_防御 += 80;
						break;
					}
					break;
				case 10:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 100;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 100;
						FLD_装备_追加_防御 += 80;
						break;
					}
					break;
				case 11:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 7;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 100;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 100;
						FLD_装备_追加_防御 += 80;
						break;
					}
					break;
				case 12:
					switch (num2)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 7;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 30;
						FLD_装备_追加_HP += 100;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 100;
						FLD_装备_追加_防御 += 80;
						break;
					}
					break;
				}
			}
			if (num3 > 0)
			{
				switch (Player_Job)
				{
				case 1:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 2:
				case 3:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				case 5:
				case 13:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 50;
						FLD_装备_追加_MP += 1000;
						break;
					}
					break;
				case 4:
				case 6:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 20;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_攻击 += 20;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.2;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 20;
						break;
					}
					break;
				case 7:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 400;
						FLD_装备_追加_防御 += 90;
						FLD_装备_追加_MP += 1000;
						break;
					}
					break;
				case 8:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 150;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 150;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 9:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 150;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 150;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				case 10:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 150;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 150;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				case 11:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 150;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 150;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				case 12:
					switch (num3)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 15;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 150;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 150;
						FLD_装备_追加_防御 += 90;
						break;
					}
					break;
				}
			}
			if (num4 > 0)
			{
				switch (Player_Job)
				{
				case 1:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 600;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 600;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					return;
				case 2:
				case 3:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 600;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 600;
						FLD_装备_追加_防御 += 100;
						break;
					}
					return;
				case 5:
				case 13:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_攻击 += 50;
						FLD_装备_追加_MP += 1000;
						break;
					}
					return;
				case 4:
				case 6:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.2;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.2;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 600;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.4;
						FLD_装备_追加_HP += 600;
						FLD_装备_追加_防御 += 50;
						break;
					}
					return;
				case 7:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 100;
						FLD_装备_追加_MP += 1000;
						break;
					}
					return;
				case 8:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					return;
				case 9:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 100;
						break;
					}
					return;
				case 10:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 100;
						break;
					}
					return;
				case 11:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 100;
						break;
					}
					return;
				case 12:
					switch (num4)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 100;
						break;
					}
					return;
				}
			}
			if (num5 > 0)
			{
				switch (Player_Job)
				{
				case 1:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 600;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 600;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 2:
				case 3:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 600;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 600;
						FLD_装备_追加_防御 += 100;
						break;
					}
					break;
				case 5:
				case 13:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_攻击 += 50;
						FLD_装备_追加_MP += 1000;
						break;
					}
					break;
				case 4:
				case 6:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.2;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.2;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 600;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.4;
						FLD_装备_追加_HP += 600;
						FLD_装备_追加_防御 += 50;
						break;
					}
					break;
				case 7:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_MP += 1000;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 500;
						FLD_装备_追加_防御 += 100;
						FLD_装备_追加_MP += 1000;
						break;
					}
					break;
				case 8:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 10;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_攻击 += 50;
						break;
					}
					break;
				case 9:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						break;
					case 5:
						人物追加战力 += 10;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 100;
						break;
					}
					break;
				case 10:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 100;
						break;
					}
					break;
				case 11:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 100;
						break;
					}
					break;
				case 12:
					switch (num5)
					{
					case 2:
						人物追加战力 += 5;
						break;
					case 3:
						人物追加战力 += 12;
						break;
					case 4:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						break;
					case 5:
						人物追加战力 += 12;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_防御 += 40;
						FLD_装备_追加_HP += 200;
						break;
					case 6:
						人物追加战力 += 25;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_防御 += 100;
						break;
					}
					break;
				}
			}
			if (num6 <= 0)
			{
				return;
			}
			switch (Player_Job)
			{
			case 1:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_HP += 800;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_攻击 += 50;
					break;
				}
				break;
			case 2:
			case 3:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_HP += 800;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 100;
					break;
				}
				break;
			case 5:
			case 13:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 40;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_MP += 1000;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_攻击 += 50;
					FLD_装备_追加_MP += 1000;
					break;
				}
				break;
			case 4:
			case 6:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.2;
					FLD_装备_追加_防御 += 50;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.2;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_HP += 800;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.2;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 50;
					break;
				}
				break;
			case 7:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_MP += 1000;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 100;
					FLD_装备_追加_MP += 1000;
					break;
				}
				break;
			case 8:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_HP += 800;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_攻击 += 50;
					break;
				}
				break;
			case 9:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 50;
					FLD_装备_追加_HP += 800;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 100;
					break;
				}
				break;
			case 10:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 40;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 40;
					FLD_装备_追加_HP += 800;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 100;
					break;
				}
				break;
			case 11:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 40;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 40;
					FLD_装备_追加_HP += 800;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 100;
					break;
				}
				break;
			case 12:
				switch (num6)
				{
				case 2:
					人物追加战力 += 10;
					break;
				case 3:
					人物追加战力 += 17;
					break;
				case 4:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 40;
					break;
				case 5:
					人物追加战力 += 17;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += 40;
					FLD_装备_追加_HP += 800;
					break;
				case 6:
					人物追加战力 += 35;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_HP += 800;
					FLD_装备_追加_防御 += 100;
					break;
				}
				break;
			}
		}

		public void 计算灵宠增加属性(物品类 物品)
		{
			long get物品ID = 物品.Get物品ID;
			long num = get物品ID;
			if (num <= 1000001276)
			{
				if (num <= 1000001250)
				{
					long num2 = num - 1000001183;
					if ((ulong)num2 <= 5uL)
					{
						long num3 = num2;
						long num4 = num3;
						if ((ulong)num4 <= 5uL)
						{
							switch (num4)
							{
							case 0L:
								switch (Player_Job_leve)
								{
								case 0:
								case 1:
								case 2:
								case 3:
								case 4:
								case 5:
									FLD_灵宠_追加_经验百分比 = 2.0;
									FLD_灵宠_追加_历练百分比 = 2.0;
									break;
								case 6:
								case 7:
									FLD_灵宠_追加_经验百分比 = 1.5;
									FLD_灵宠_追加_历练百分比 = 1.5;
									break;
								case 8:
									FLD_灵宠_追加_历练百分比 = 1.25;
									FLD_灵宠_追加_历练百分比 = 1.25;
									break;
								case 9:
									FLD_灵宠_追加_经验百分比 = 1.0;
									FLD_灵宠_追加_历练百分比 = 1.0;
									break;
								case 10:
									FLD_灵宠_追加_经验百分比 = 0.5;
									FLD_灵宠_追加_历练百分比 = 0.5;
									break;
								}
								宠物对怪物伤害 += 0.15;
								goto IL_0b0e;
							case 1L:
								switch (Player_Job_leve)
								{
								case 0:
								case 1:
								case 2:
								case 3:
								case 4:
								case 5:
									FLD_灵宠_追加_经验百分比 = 3.0;
									FLD_灵宠_追加_历练百分比 = 2.0;
									break;
								case 6:
								case 7:
									FLD_灵宠_追加_经验百分比 = 2.0;
									break;
								case 8:
									FLD_灵宠_追加_历练百分比 += 1.5;
									break;
								case 9:
								case 10:
									FLD_灵宠_追加_经验百分比 = 1.0;
									装备追加对怪防御 += 50;
									break;
								}
								宠物对怪物伤害 += 0.09;
								goto IL_0b0e;
							case 3L:
								FLD_灵宠_追加_经验百分比 = 0.5;
								宠物对怪物伤害 += 0.03;
								goto IL_0b0e;
							case 4L:
							case 5L:
								switch (Player_Job_leve)
								{
								case 0:
								case 1:
								case 2:
								case 3:
								case 4:
								case 5:
									装备追加对怪防御 += 150;
									装备追加对怪攻击 += 150;
									break;
								case 6:
								case 7:
								case 8:
								case 9:
								case 10:
									装备追加对怪防御 += 75;
									装备追加对怪攻击 += 75;
									break;
								}
								宠物对怪物伤害 += 0.06;
								goto IL_0b0e;
							case 2L:
								goto IL_0b0e;
							}
						}
					}
					if (num == 1000001250)
					{
						switch (Player_Job_leve)
						{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
							装备追加对怪防御 += 100;
							装备追加对怪攻击 += 100;
							FLD_灵宠_追加_经验百分比 = 1.5;
							break;
						case 9:
							装备追加对怪防御 += 100;
							装备追加对怪攻击 += 100;
							FLD_灵宠_追加_经验百分比 = 1.0;
							break;
						case 10:
							装备追加对怪防御 += 100;
							装备追加对怪攻击 += 100;
							FLD_灵宠_追加_经验百分比 = 0.5;
							break;
						}
						宠物对怪物伤害 += 0.12;
					}
				}
				else
				{
					switch (num)
					{
					case 1000001276L:
						switch (Player_Job_leve)
						{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
							FLD_灵宠_追加_经验百分比 = 3.0;
							FLD_灵宠_追加_历练百分比 = 3.0;
							break;
						case 6:
						case 7:
							FLD_灵宠_追加_经验百分比 = 2.0;
							FLD_灵宠_追加_历练百分比 = 2.0;
							break;
						case 8:
							FLD_灵宠_追加_历练百分比 = 1.5;
							FLD_灵宠_追加_经验百分比 = 1.5;
							break;
						case 9:
							FLD_灵宠_追加_经验百分比 = 1.0;
							FLD_灵宠_追加_历练百分比 = 1.0;
							装备追加对怪防御 += 100;
							装备追加对怪攻击 += 100;
							break;
						case 10:
							FLD_灵宠_追加_经验百分比 = 0.5;
							FLD_灵宠_追加_历练百分比 = 0.5;
							装备追加对怪防御 += 200;
							装备追加对怪攻击 += 200;
							break;
						}
						break;
					case 1000001265L:
						switch (Player_Job_leve)
						{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
							装备追加对怪防御 += 200;
							装备追加对怪攻击 += 200;
							FLD_灵宠_追加_经验百分比 = 3.0;
							break;
						case 9:
							装备追加对怪防御 += 200;
							装备追加对怪攻击 += 200;
							FLD_灵宠_追加_经验百分比 = 2.0;
							break;
						case 10:
							装备追加对怪防御 += 200;
							装备追加对怪攻击 += 200;
							FLD_灵宠_追加_经验百分比 = 1.0;
							break;
						}
						宠物对怪物伤害 += 0.21;
						break;
					}
				}
			}
			else
			{
				switch (num)
				{
				case 1000001445L:
					switch (Player_Job_leve)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
						FLD_灵宠_追加_经验百分比 = 3.0;
						装备追加对怪防御 += 200;
						装备追加对怪攻击 += 200;
						break;
					case 9:
						FLD_灵宠_追加_经验百分比 = 2.0;
						装备追加对怪防御 += 200;
						装备追加对怪攻击 += 200;
						break;
					case 10:
						FLD_灵宠_追加_经验百分比 = 1.0;
						装备追加对怪防御 += 200;
						装备追加对怪攻击 += 200;
						break;
					case 11:
						FLD_灵宠_追加_经验百分比 = 0.4;
						装备追加对怪防御 += 200;
						装备追加对怪攻击 += 200;
						break;
					}
					宠物对怪物伤害 += 0.4;
					break;
				case 1000001303L:
				case 1000001304L:
					switch (Player_Job_leve)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						FLD_灵宠_追加_经验百分比 = 1.0;
						FLD_灵宠_追加_历练百分比 = 2.0;
						break;
					case 6:
					case 7:
						FLD_灵宠_追加_经验百分比 = 0.75;
						装备追加对怪防御 += 30;
						break;
					case 8:
						FLD_灵宠_追加_经验百分比 = 0.6;
						装备追加对怪防御 += 50;
						break;
					case 9:
						FLD_灵宠_追加_经验百分比 = 0.5;
						装备追加对怪防御 += 75;
						break;
					case 10:
						FLD_灵宠_追加_经验百分比 = 0.3;
						装备追加对怪防御 += 100;
						break;
					}
					FLD_装备_追加_气功++;
					宠物对怪物伤害 += 0.3;
					break;
				case 1000001301L:
				case 1000001302L:
					switch (Player_Job_leve)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						FLD_灵宠_追加_经验百分比 = 2.0;
						FLD_灵宠_追加_历练百分比 = 2.0;
						break;
					case 6:
					case 7:
						FLD_灵宠_追加_经验百分比 = 2.0;
						装备追加对怪防御 += 50;
						break;
					case 8:
						FLD_灵宠_追加_历练百分比 += 1.25;
						装备追加对怪防御 += 75;
						break;
					case 9:
						FLD_灵宠_追加_经验百分比 = 1.0;
						装备追加对怪防御 += 100;
						break;
					case 10:
						FLD_灵宠_追加_经验百分比 = 0.6;
						装备追加对怪防御 += 150;
						break;
					}
					宠物对怪物伤害 += 0.24;
					break;
				case 1000001440L:
					switch (Player_Job_leve)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						FLD_灵宠_追加_经验百分比 = 3.0;
						break;
					case 6:
					case 7:
						FLD_灵宠_追加_经验百分比 = 2.0;
						break;
					case 8:
						FLD_灵宠_追加_经验百分比 = 1.5;
						break;
					case 9:
						装备追加对怪防御 += 50;
						FLD_灵宠_追加_经验百分比 = 1.0;
						break;
					case 10:
						装备追加对怪防御 += 50;
						FLD_灵宠_追加_经验百分比 = 0.8;
						break;
					}
					宠物对怪物伤害 += 0.27;
					break;
				}
			}
			goto IL_0b0e;
			IL_0b0e:
			物品.得到物品属性方法();
			FLD_装备_追加_攻击 += (物品.物品攻击力 + 物品.物品攻击力MAX) / 2;
			FLD_装备_追加_防御 += 物品.物品防御力;
		}

		public void 计算花珠增加属性(物品类 物品)
		{
			long get物品ID = 物品.Get物品ID;
			long num = get物品ID - 1900001;
			if ((ulong)num > 14uL)
			{
				return;
			}
			long num2 = num;
			long num3 = num2;
			if ((ulong)num3 > 14uL)
			{
				return;
			}
			long num4 = num3;
			long num5 = num4;
			if ((ulong)num5 <= 14uL)
			{
				switch (num5)
				{
				case 0L:
				case 5L:
				case 10L:
					FLD_装备_追加_气功 += 3;
					FLD_装备_追加_经验百分比 += 1.0;
					FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 7 / 200;
					FLD_装备_武功攻击力增加百分比 += 0.12;
					FLD_装备_追加_防御 += FLD_装备_追加_防御 / 8;
					FLD_装备_追加_HP += 600;
					FLD_装备_追加_MP += 400;
					装备追加对怪攻击 += 200;
					装备追加对怪防御 += 200;
					break;
				case 1L:
				case 6L:
				case 11L:
					FLD_装备_追加_气功 += 3;
					FLD_装备_追加_经验百分比 += 0.4;
					FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 7 / 200;
					FLD_装备_武功攻击力增加百分比 += 0.12;
					FLD_装备_追加_防御 += FLD_装备_追加_防御 / 12;
					FLD_装备_追加_HP += 600;
					FLD_装备_追加_MP += 400;
					break;
				case 2L:
				case 7L:
				case 12L:
					FLD_装备_追加_气功 += 3;
					FLD_装备_追加_经验百分比 += 0.2;
					FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 5 / 200;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += FLD_装备_追加_防御 / 10;
					FLD_装备_追加_HP += 500;
					FLD_装备_追加_MP += 300;
					break;
				case 3L:
				case 8L:
				case 13L:
					FLD_装备_追加_气功 += 3;
					FLD_装备_追加_经验百分比 += 0.2;
					break;
				case 4L:
				case 9L:
				case 14L:
					FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 5 / 200;
					FLD_装备_武功攻击力增加百分比 += 0.1;
					FLD_装备_追加_防御 += FLD_装备_追加_防御 / 10;
					FLD_装备_追加_HP += 500;
					FLD_装备_追加_MP += 300;
					break;
				}
			}
		}

		public int 计算武器四神相克(int 武器四神, int 防具四神)
		{
			int result = 0;
			switch (武器四神)
			{
			case 1:
				switch (防具四神)
				{
				case 0:
					result = 1;
					break;
				case 1:
					result = 0;
					break;
				case 2:
					result = 1;
					break;
				case 3:
					result = 0;
					break;
				case 4:
					result = 0;
					break;
				}
				break;
			case 2:
				switch (防具四神)
				{
				case 0:
					result = 1;
					break;
				case 1:
					result = 0;
					break;
				case 2:
					result = 0;
					break;
				case 3:
					result = 1;
					break;
				case 4:
					result = 0;
					break;
				}
				break;
			case 3:
				switch (防具四神)
				{
				case 0:
					result = 1;
					break;
				case 1:
					result = 0;
					break;
				case 2:
					result = 0;
					break;
				case 3:
					result = 0;
					break;
				case 4:
					result = 1;
					break;
				}
				break;
			case 4:
				switch (防具四神)
				{
				case 0:
					result = 1;
					break;
				case 1:
					result = 1;
					break;
				case 2:
					result = 0;
					break;
				case 3:
					result = 0;
					break;
				case 4:
					result = 0;
					break;
				}
				break;
			}
			return result;
		}

		public int 计算衣服四神相克(int 衣服四神, int 武器四神)
		{
			int result = 0;
			switch (衣服四神)
			{
			case 1:
				switch (武器四神)
				{
				case 0:
					result = 1;
					break;
				case 1:
					result = 0;
					break;
				case 2:
					result = 1;
					break;
				case 3:
					result = 0;
					break;
				case 4:
					result = 0;
					break;
				}
				break;
			case 2:
				switch (武器四神)
				{
				case 0:
					result = 1;
					break;
				case 1:
					result = 0;
					break;
				case 2:
					result = 0;
					break;
				case 3:
					result = 1;
					break;
				case 4:
					result = 0;
					break;
				}
				break;
			case 3:
				switch (武器四神)
				{
				case 0:
					result = 1;
					break;
				case 1:
					result = 0;
					break;
				case 2:
					result = 0;
					break;
				case 3:
					result = 0;
					break;
				case 4:
					result = 1;
					break;
				}
				break;
			case 4:
				switch (武器四神)
				{
				case 0:
					result = 1;
					break;
				case 1:
					result = 1;
					break;
				case 2:
					result = 0;
					break;
				case 3:
					result = 0;
					break;
				case 4:
					result = 0;
					break;
				}
				break;
			}
			return result;
		}

		public void 计算人物装备数据()
		{
			using (new Lock(thisLock, "计算人物装备数据"))
			{
				int num = 0;
				int num12 = 0;
				int num23 = 0;
				int num32 = 0;
				int num33 = 0;
				int num34 = 0;
				int num35 = 0;
				int num36 = 0;
				int num37 = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				装备追加对怪防御 = 0;
				装备追加对怪攻击 = 0;
				强化追加对怪防御 = 0;
				强化追加对怪攻击 = 0;
				武器攻击力 = 0;
				武器武功攻击力百分比 = 0.0;
				宠物对怪物伤害 = 0.0;
				衣服防御力 = 0;
				衣服武功防御力百分比 = 0.0;
				FLD_装备_追加_降低百分比攻击 = 0.0;
				FLD_装备_追加_降低百分比防御 = 0.0;
				FLD_装备_追加_命中百分比 = 0.0;
				FLD_装备_追加_初始化愤怒概率百分比 = 0.0;
				FLD_装备_追加_中毒概率百分比 = 0.0;
				FLD_装备_降低_伤害值 = 0.0;
				FLD_装备_追加_回避百分比 = 0.0;
				FLD_装备_追加_愤怒 = 0;
				FLD_装备_追加_伤害值 = 0;
				FLD_装备_追加_升天三火龙之火 = 0.0;
				FLD_装备_追加_升天一护身罡气 = 0.0;
				FLD_装备_追加_升天一护身气甲 = 0.0;
				FLD_装备_追加_升天三怒意之火 = 0.0;
				FLD_装备_追加_升天二万物回春 = 0.0;
				FLD_装备_追加_升天二千钧压驼 = 0.0;
				FLD_装备_追加_升天二穷途末路 = 0.0;
				FLD_装备_追加_升天二三潭映月 = 0.0;
				FLD_装备_追加_升天二顺水推舟 = 0.0;
				FLD_装备_追加_升天二天地同寿 = 0.0;
				FLD_装备_追加_升天二天魔护体 = 0.0;
				FLD_装备_追加_升天二以退为进 = 0.0;
				FLD_装备_追加_升天三火凤临朝 = 0.0;
				FLD_装备_追加_升天三明镜止水 = 0.0;
				FLD_装备_追加_升天三无情打击 = 0.0;
				FLD_装备_追加_升天三内息行心 = 0.0;
				FLD_装备_追加_升天三天外三矢 = 0.0;
				FLD_装备_追加_升天三以柔克刚 = 0.0;
				FLD_装备_追加_升天三子夜秋歌 = 0.0;
				FLD_装备_追加_升天四哀鸿遍野 = 0.0;
				FLD_装备_追加_升天四毒蛇出洞 = 0.0;
				FLD_装备_追加_升天四红月狂风 = 0.0;
				FLD_装备_追加_升天四烈日炎炎 = 0.0;
				FLD_装备_追加_升天四满月狂风 = 0.0;
				FLD_装备_追加_升天四望梅添花 = 0.0;
				FLD_装备_追加_升天四悬丝诊脉 = 0.0;
				FLD_装备_追加_升天四长虹贯天 = 0.0;
				FLD_装备_追加_升天一百变神行 = 0.0;
				FLD_装备_追加_升天一遁出逆境 = 0.0;
				FLD_装备_追加_升天一飞花点翠 = 0.0;
				FLD_装备_追加_升天一行风弄舞 = 0.0;
				FLD_装备_追加_升天一金钟罡气 = 0.0;
				FLD_装备_追加_升天一绝影射魂 = 0.0;
				FLD_装备_追加_升天一狂风天意 = 0.0;
				FLD_装备_追加_升天一力劈华山 = 0.0;
				FLD_装备_追加_升天一破甲刺魂 = 0.0;
				FLD_装备_追加_升天一夜魔缠身 = 0.0;
				FLD_装备_追加_升天一运气行心 = 0.0;
				FLD_装备_追加_升天一运气疗伤 = 0.0;
				FLD_装备_追加_升天一长虹贯日 = 0.0;
				FLD_装备_追加_升天一正本培源 = 0.0;
				FLD_装备_追加_升天一夺命连环 = 0.0;
				FLD_装备_追加_升天一电光石火 = 0.0;
				FLD_装备_追加_升天一精益求精 = 0.0;
				FLD_装备_追加_升天五惊天动地 = 0.0;
				FLD_装备_追加_升天一玄武雷电 = 0.0;
				FLD_装备_追加_升天一陵劲淬砺 = 0.0;
				FLD_装备_追加_升天一愤怒调节 = 0.0;
				FLD_装备_追加_升天二玄武诅咒 = 0.0;
				FLD_装备_追加_升天二杀星光符 = 0.0;
				FLD_装备_追加_升天二蛊毒解除 = 0.0;
				FLD_装备_追加_升天三杀人鬼 = 0.0;
				FLD_装备_追加_升天三技冠群雄 = 0.0;
				FLD_装备_追加_升天三神力保护 = 0.0;
				FLD_装备_追加_升天五致残 = 0.0;
				FLD_装备_追加_升天五龙魂附体 = 0.0;
				FLD_装备_追加_升天五灭世狂舞 = 0.0;
				FLD_装备_追加_升天五千里一击 = 0.0;
				FLD_装备_追加_升天五形移妖相 = 0.0;
				FLD_装备_追加_升天五一招杀神 = 0.0;
				FLD_装备_追加_升天五龙爪纤指手 = 0.0;
				FLD_装备_追加_升天五不死之躯 = 0.0;
				FLD_装备_追加_升天五天魔之力 = 0.0;
				FLD_装备_追加_升天五惊涛骇浪 = 0.0;
				FLD_装备_追加_升天五魔魂之力 = 0.0;
				FLD_装备_追加_升天五破空坠星 = 0.0;
				FLD_装备_追加_升天五尸毒爆发 = 0.0;
				FLD_装备_追加_合成成功率百分比 = 0.0;
				FLD_装备_追加_获得游戏币百分比 = 0.0;
				FLD_装备_武功攻击力增加百分比 = 0.0;
				FLD_装备_武功防御力增加百分比 = 0.0;
				FLD_装备_追加_障力 = 0;
				FLD_装备_武功防御力 = 0.0;
				FLD_装备_追加_攻击 = 0;
				FLD_装备_追加_防御 = 0;
				FLD_装备_追加_命中 = 0;
				FLD_装备_追加_回避 = 0;
				FLD_装备_追加_气功 = 0;
				FLD_装备_追加_经验百分比 = 0.0;
				FLD_装备_追加_死亡损失经验减少 = 0.0;
				FLD_装备_追加_气功_0 = 0.0;
				FLD_装备_追加_气功_1 = 0.0;
				FLD_装备_追加_气功_2 = 0.0;
				FLD_装备_追加_气功_3 = 0.0;
				FLD_装备_追加_气功_4 = 0.0;
				FLD_装备_追加_气功_5 = 0.0;
				FLD_装备_追加_气功_6 = 0.0;
				FLD_装备_追加_气功_7 = 0.0;
				FLD_装备_追加_气功_8 = 0.0;
				FLD_装备_追加_气功_9 = 0.0;
				FLD_装备_追加_气功_10 = 0.0;
				FLD_装备_追加_气功_11 = 0.0;
				中级附魂_复仇 = 0;
				中级附魂_吸魂 = 0;
				中级附魂_奇缘 = 0;
				中级附魂_愤怒 = 0;
				中级附魂_移星 = 0;
				中级附魂_护体 = 0;
				中级附魂_混元 = 0;
				FLD_装备_追加_心 = 0;
				FLD_装备_追加_体 = 0;
				FLD_装备_追加_力 = 0;
				FLD_装备_追加_身 = 0;
				FLD_装备_追加_觉醒 = 0;
				FLD_装备_追加_HP = 0;
				FLD_装备_追加_障力恢复量 = 0;
				FLD_装备_隐藏_HP = 0;
				FLD_装备_隐藏_DF = 0;
				FLD_装备_隐藏_AT = 0;
				FLD_装备_追加_MP = 0;
				锁定人物几率 = 0;
				人物追加战力 = 0;
				FLD_装备_追加_武功回避 = 0;
				FLD_装备_追加_武功负重 = 0;
				FLD_装备_追加_战斗力 = 0;
				FLD_装备_追加_武功命中 = 0;
				强化武器追加百分比 = 0;
				强化防具追加百分比 = 0;
				FLD_装备_增加对方异常 = 0;
				FLD_装备_增加异常 = 0;
				减免对方伤害 = 0;
				FLD_灵宠_追加_经验百分比 = 0.0;
				FLD_项链_追加_防具_强化 = 0;
				FLD_项链_追加_武器_强化 = 0;
				FLD_装备_追加_罡气 = 0;
				long get物品ID = 装备栏已穿装备[6].Get物品ID;
				long num9 = get物品ID - 1100001;
				if ((ulong)num9 <= 2uL)
				{
					long num10 = num9;
					long num11 = num10;
					if ((ulong)num11 <= 2uL)
					{
						long num38 = num11;
						long num39 = num38;
						if ((ulong)num39 <= 2uL)
						{
							switch (num39)
							{
							case 0L:
								FLD_项链_追加_武器_强化 += 2;
								break;
							case 1L:
								FLD_项链_追加_防具_强化++;
								break;
							case 2L:
								FLD_项链_追加_武器_强化 += 2;
								FLD_项链_追加_防具_强化++;
								break;
							}
						}
					}
				}
				int num14;
				for (int num13 = 0; num13 < 17; num14 = num13 + 1, num13 = num14)
				{
					if (num13 < 15 && 宝珠装备栏装备[num13].Get物品ID != 0)
					{
						宝珠装备栏装备[num13].得到物品属性方法();
						宝珠装备栏装备[num13].得到物品属性方法(FLD_装备_追加_防具_强化, 触发属性提升);
						FLD_装备_隐藏_HP += 宝珠装备栏装备[num13].物品隐藏生命;
						FLD_装备_隐藏_AT += 宝珠装备栏装备[num13].物品隐藏攻击;
						FLD_装备_隐藏_DF += 宝珠装备栏装备[num13].物品隐藏防御;
						FLD_装备_追加_降低百分比攻击 += 宝珠装备栏装备[num13].物品属性_降低百分比攻击;
						FLD_装备_追加_降低百分比防御 += 宝珠装备栏装备[num13].物品属性_降低百分比防御;
						FLD_装备_追加_愤怒 += 宝珠装备栏装备[num13].物品属性_愤怒值增加;
						FLD_装备_追加_初始化愤怒概率百分比 += 宝珠装备栏装备[num13].物品属性_初始化愤怒概率百分比;
						FLD_装备_追加_中毒概率百分比 += 宝珠装备栏装备[num13].物品属性_追加中毒几率百分比;
						FLD_装备_追加_命中 += 宝珠装备栏装备[num13].物品属性_命中率增加;
						FLD_装备_追加_命中百分比 += 宝珠装备栏装备[num13].物品属性_增加百分比命中;
						FLD_装备_追加_回避 += 宝珠装备栏装备[num13].物品属性_回避率增加;
						FLD_装备_追加_回避百分比 += 宝珠装备栏装备[num13].物品属性_增加百分比回避;
						FLD_装备_追加_伤害值 += 宝珠装备栏装备[num13].物品属性_追加伤害值;
						FLD_装备_降低_伤害值 += 宝珠装备栏装备[num13].物品属性_降低伤害值;
						if (宝珠装备栏装备[num13].物品属性_武功防御力增加 > 0)
						{
							FLD_装备_武功防御力 += 宝珠装备栏装备[num13].物品属性_武功防御力增加;
							FLD_装备_武功防御力增加百分比 += (double)宝珠装备栏装备[num13].物品属性_武功防御力增加New * (1.0 - World.武功防降低百分比) * 0.01;
							if (num13 == 0)
							{
								衣服武功防御力百分比 += FLD_装备_武功防御力增加百分比;
							}
						}
						if (宝珠装备栏装备[num13].物品属性_武功攻击力 > 0)
						{
							FLD_装备_武功攻击力增加百分比 += (double)宝珠装备栏装备[num13].物品属性_武功攻击力New * World.武功攻击力百分比;
							if (num13 == 3)
							{
								武器武功攻击力百分比 += FLD_装备_武功攻击力增加百分比;
							}
						}
						FLD_装备_追加_气功 += 宝珠装备栏装备[num13].物品属性_全部气功等级增加;
						FLD_装备_追加_HP += 宝珠装备栏装备[num13].物品属性_生命力增加;
						FLD_装备_追加_MP += 宝珠装备栏装备[num13].物品属性_内功力增加;
						FLD_装备_追加_障力恢复量 += 宝珠装备栏装备[num13].物品属性_障力恢复量增加;
						装备追加对怪防御 += 宝珠装备栏装备[num13].物品对怪防御力;
						装备追加对怪攻击 += 宝珠装备栏装备[num13].物品对怪攻击力;
						if (Player_Job == 11)
						{
							FLD_装备_追加_障力 += 宝珠装备栏装备[num13].物品属性_障力增加;
						}
						else
						{
							FLD_装备_追加_障力 = 0;
						}
						if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 22 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 21)
						{
							if (宝珠装备栏装备[num13].FLD_FJ_觉醒 > 0)
							{
								FLD_装备_追加_觉醒 = 宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 20;
							}
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 20 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 16)
						{
							FLD_装备_追加_身 = (int)((double)(宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 15) * 0.01 * (double)FLD_身);
							FLD_装备_追加_命中 += FLD_装备_追加_身;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 15 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 11)
						{
							FLD_装备_追加_力 = (int)((double)(宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 10) * 0.01 * (double)FLD_力);
							FLD_装备_追加_防御 += FLD_装备_追加_力;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 10 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 6)
						{
							FLD_装备_追加_体 = (int)((double)(宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 5) * 0.01 * (double)FLD_体);
							FLD_装备_追加_攻击 += FLD_装备_追加_体;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 5 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 1)
						{
							FLD_装备_追加_心 = (int)((double)宝珠装备栏装备[num13].FLD_FJ_中级附魂 * 0.01 * (double)FLD_心);
							FLD_装备_追加_回避 += FLD_装备_追加_心;
						}
						if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 51 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 47)
						{
							中级附魂_混元 = 宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 46;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 46 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 42)
						{
							中级附魂_护体 = 宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 41;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 41 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 37)
						{
							中级附魂_移星 = 宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 36;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 36 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 34)
						{
							中级附魂_愤怒 = 宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 33;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 33 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 31)
						{
							中级附魂_奇缘 = 宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 30;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 30 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 28)
						{
							中级附魂_吸魂 = 宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 27;
						}
						else if (宝珠装备栏装备[num13].FLD_FJ_中级附魂 <= 27 && 宝珠装备栏装备[num13].FLD_FJ_中级附魂 >= 23)
						{
							中级附魂_复仇 = 宝珠装备栏装备[num13].FLD_FJ_中级附魂 - 22;
						}
					}
					装备栏已穿装备[num13].得到物品属性方法();
					ItmeClass value = new ItmeClass();
					if (装备栏已穿装备[num13].Get物品ID == 0L || !World.Itme.TryGetValue(BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0), out value))
					{
						continue;
					}
					if (value.FLD_NJ > 0 && ((装备栏已穿装备[num13].FLD_FJ_NJ <= 0) ? true : false))
					{
						装备栏已穿装备[num13].FLD_FJ_NJ = 0;
						continue;
					}
					if ((value.FLD_RESIDE2 == 8 || value.FLD_RESIDE2 == 7 || value.FLD_RESIDE2 == 10) && value.FLD_NJ > 0)
					{
						num23++;
					}
					if ((value.FLD_RESIDE2 == 14 && !检查门甲条件((int)装备栏已穿装备[num13].Get物品ID)) || Player_Level < value.FLD_LEVEL || Player_Job_leve < value.FLD_JOB_LEVEL)
					{
						continue;
					}
					if (value.FLD_RESIDE1 != 0)
					{
						if (value.FLD_RESIDE2 == 13)
						{
							if (Player_Job == 11)
							{
								if (value.FLD_PID == 1000000992 || value.FLD_PID == 1000000993 || value.FLD_PID == 1000000994 || value.FLD_PID == 1000000995)
								{
									continue;
								}
							}
							else if (Player_Job == 4 && (value.FLD_PID == 1000001536 || value.FLD_PID == 1000001537 || value.FLD_PID == 1000001538 || value.FLD_PID == 1000001539 || value.FLD_PID == 1000001540))
							{
								continue;
							}
						}
						else if (value.FLD_RESIDE1 != Player_Job)
						{
							continue;
						}
					}
					if (value.FLD_SEX != 0 && Player_Sex != value.FLD_SEX)
					{
						continue;
					}
					FLD_装备_追加_觉醒 = 0;
					装备栏已穿装备[num13].得到物品属性方法(FLD_装备_追加_防具_强化, 触发属性提升);
					FLD_装备_隐藏_HP += 装备栏已穿装备[num13].物品隐藏生命;
					FLD_装备_隐藏_AT += 装备栏已穿装备[num13].物品隐藏攻击;
					FLD_装备_隐藏_DF += 装备栏已穿装备[num13].物品隐藏防御;
					FLD_装备_追加_攻击 += (装备栏已穿装备[num13].物品攻击力 + 装备栏已穿装备[num13].物品攻击力MAX) / 2;
					FLD_装备_追加_防御 += 装备栏已穿装备[num13].物品防御力;
					if (num13 == 3)
					{
						武器攻击力 += (装备栏已穿装备[num13].物品攻击力New + 装备栏已穿装备[num13].物品攻击力MaxNew) / 2;
					}
					if (num13 == 0)
					{
						衣服防御力 += 装备栏已穿装备[num13].物品防御力;
					}
					FLD_装备_追加_降低百分比攻击 += 装备栏已穿装备[num13].物品属性_降低百分比攻击;
					FLD_装备_追加_降低百分比防御 += 装备栏已穿装备[num13].物品属性_降低百分比防御;
					FLD_装备_追加_愤怒 += 装备栏已穿装备[num13].物品属性_愤怒值增加;
					FLD_装备_追加_初始化愤怒概率百分比 += 装备栏已穿装备[num13].物品属性_初始化愤怒概率百分比;
					FLD_装备_追加_中毒概率百分比 += 装备栏已穿装备[num13].物品属性_追加中毒几率百分比;
					FLD_装备_追加_命中 += 装备栏已穿装备[num13].物品属性_命中率增加;
					FLD_装备_追加_命中百分比 += 装备栏已穿装备[num13].物品属性_增加百分比命中;
					FLD_装备_追加_回避 += 装备栏已穿装备[num13].物品属性_回避率增加;
					FLD_装备_追加_回避百分比 += 装备栏已穿装备[num13].物品属性_增加百分比回避;
					FLD_装备_追加_伤害值 += 装备栏已穿装备[num13].物品属性_追加伤害值;
					FLD_装备_降低_伤害值 += 装备栏已穿装备[num13].物品属性_降低伤害值;
					FLD_装备_追加_武功回避 += 装备栏已穿装备[num13].物品武功回避;
					FLD_装备_追加_武功命中 += 装备栏已穿装备[num13].物品武功命中;
					宠物对怪物伤害 += 装备栏已穿装备[num13].物品属性_对怪伤害;
					if (value.FLD_RESIDE2 == 16)
					{
						计算灵宠增加属性(装备栏已穿装备[num13]);
					}
					if (num13 == 0 && 装备栏已穿装备[num13].Get物品ID != 0L && 装备栏已穿装备[num13].FLD_FJ_四神之力 != 0)
					{
						FLD_装备_追加_防御 += 50;
						FLD_装备_追加_HP += 200;
						FLD_装备_追加_MP += 200;
					}
					if (num13 == 3 && 装备栏已穿装备[num13].Get物品ID != 0L && 装备栏已穿装备[num13].FLD_FJ_四神之力 != 0)
					{
						FLD_装备_追加_攻击 += 50;
						FLD_装备_武功攻击力增加百分比 += 0.1;
						FLD_装备_追加_气功++;
					}
					if (装备栏已穿装备[num13].物品属性_武功防御力增加 > 0)
					{
						FLD_装备_武功防御力 += 装备栏已穿装备[num13].物品属性_武功防御力增加;
						FLD_装备_武功防御力增加百分比 += (double)装备栏已穿装备[num13].物品属性_武功防御力增加New * (1.0 - World.武功防降低百分比) * 0.01;
						if (num13 == 0)
						{
							衣服武功防御力百分比 += FLD_装备_武功防御力增加百分比;
						}
					}
					if (装备栏已穿装备[num13].物品属性_武功攻击力 > 0)
					{
						FLD_装备_武功攻击力增加百分比 += (double)装备栏已穿装备[num13].物品属性_武功攻击力New * World.武功攻击力百分比;
						if (num13 == 3)
						{
							武器武功攻击力百分比 += FLD_装备_武功攻击力增加百分比;
						}
					}
					FLD_装备_追加_气功 += 装备栏已穿装备[num13].物品属性_全部气功等级增加;
					FLD_装备_追加_HP += 装备栏已穿装备[num13].物品属性_生命力增加;
					FLD_装备_追加_MP += 装备栏已穿装备[num13].物品属性_内功力增加;
					FLD_装备_追加_障力恢复量 += 装备栏已穿装备[num13].物品属性_障力恢复量增加;
					装备追加对怪防御 += 装备栏已穿装备[num13].物品对怪防御力;
					装备追加对怪攻击 += 装备栏已穿装备[num13].物品对怪攻击力;
					if (Player_Job == 11)
					{
						FLD_装备_追加_障力 += 装备栏已穿装备[num13].物品属性_障力增加;
					}
					else
					{
						FLD_装备_追加_障力 = 0;
					}
					if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 22 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 21) ? true : false))
					{
						if (装备栏已穿装备[num13].FLD_FJ_觉醒 > 0)
						{
							FLD_装备_追加_觉醒 = 装备栏已穿装备[num13].FLD_FJ_中级附魂 - 20;
						}
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 20 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 16) ? true : false))
					{
						FLD_装备_追加_身 = (int)((double)(装备栏已穿装备[num13].FLD_FJ_中级附魂 - 15) * 0.01 * (double)FLD_身);
						FLD_装备_追加_命中 += FLD_装备_追加_身;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 15 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 11) ? true : false))
					{
						FLD_装备_追加_力 = (int)((double)(装备栏已穿装备[num13].FLD_FJ_中级附魂 - 10) * 0.01 * (double)FLD_力);
						FLD_装备_追加_防御 += FLD_装备_追加_力;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 10 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 6) ? true : false))
					{
						FLD_装备_追加_体 = (int)((double)(装备栏已穿装备[num13].FLD_FJ_中级附魂 - 5) * 0.01 * (double)FLD_体);
						FLD_装备_追加_攻击 += FLD_装备_追加_体;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 5 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 1) ? true : false))
					{
						FLD_装备_追加_心 = (int)((double)装备栏已穿装备[num13].FLD_FJ_中级附魂 * 0.01 * (double)FLD_心);
						FLD_装备_追加_回避 += FLD_装备_追加_心;
					}
					if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 51 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 47) ? true : false))
					{
						中级附魂_混元 = 装备栏已穿装备[num13].FLD_FJ_中级附魂 - 46;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 46 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 42) ? true : false))
					{
						中级附魂_护体 = 装备栏已穿装备[num13].FLD_FJ_中级附魂 - 41;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 41 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 37) ? true : false))
					{
						中级附魂_移星 = 装备栏已穿装备[num13].FLD_FJ_中级附魂 - 36;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 36 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 34) ? true : false))
					{
						中级附魂_愤怒 = 装备栏已穿装备[num13].FLD_FJ_中级附魂 - 33;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 33 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 31) ? true : false))
					{
						中级附魂_奇缘 = 装备栏已穿装备[num13].FLD_FJ_中级附魂 - 30;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 30 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 28) ? true : false))
					{
						中级附魂_吸魂 = 装备栏已穿装备[num13].FLD_FJ_中级附魂 - 27;
					}
					else if (装备栏已穿装备[num13].FLD_FJ_中级附魂 <= 27 && ((装备栏已穿装备[num13].FLD_FJ_中级附魂 >= 23) ? true : false))
					{
						中级附魂_复仇 = 装备栏已穿装备[num13].FLD_FJ_中级附魂 - 22;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 12)
					{
						检查五行披风属性符(装备栏已穿装备[num13]);
						if (装备栏已穿装备[num13].Get物品ID == 26900772 || ((装备栏已穿装备[num13].Get物品ID == 16900772) ? true : false))
						{
							num14 = num23 + 1;
							num23 = num14;
						}
						FLD_装备_追加_命中百分比 += 装备栏已穿装备[num13].物品属性_增加百分比命中;
						FLD_装备_追加_回避 += 装备栏已穿装备[num13].物品属性_回避率增加;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4)
					{
						检查武器属性符(装备栏已穿装备[num13]);
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4 && ((装备栏已穿装备[num13].物品属性强 == 8) ? true : false))
					{
						FLD_装备_追加_攻击 += World.武器8阶段添加攻击;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4 && ((装备栏已穿装备[num13].物品属性强 == 9) ? true : false))
					{
						FLD_装备_追加_攻击 += World.武器9阶段添加攻击;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4 && ((装备栏已穿装备[num13].物品属性强 == 10) ? true : false))
					{
						FLD_装备_追加_攻击 += World.武器10阶段添加攻击;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4 && ((装备栏已穿装备[num13].物品属性强 == 11) ? true : false))
					{
						FLD_装备_追加_攻击 += World.武器11阶段添加攻击;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4 && ((装备栏已穿装备[num13].物品属性强 == 12) ? true : false))
					{
						FLD_装备_追加_攻击 += World.武器12阶段添加攻击;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4 && ((装备栏已穿装备[num13].物品属性强 == 13) ? true : false))
					{
						FLD_装备_追加_攻击 += World.武器13阶段添加攻击;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4 && ((装备栏已穿装备[num13].物品属性强 == 14) ? true : false))
					{
						FLD_装备_追加_攻击 += World.武器14阶段添加攻击;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 4 && ((装备栏已穿装备[num13].物品属性强 == 15) ? true : false))
					{
						FLD_装备_追加_攻击 += World.武器15阶段添加攻击;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 1 && ((装备栏已穿装备[num13].物品属性强 == 8) ? true : false))
					{
						FLD_装备_追加_防御 += World.衣服8阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 84;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 70;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 98;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 1 && ((装备栏已穿装备[num13].物品属性强 == 9) ? true : false))
					{
						FLD_装备_追加_防御 += World.衣服9阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 84;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 70;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 98;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 1 && ((装备栏已穿装备[num13].物品属性强 == 10) ? true : false))
					{
						FLD_装备_追加_防御 += World.衣服10阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 163;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 143;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 183;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 1 && ((装备栏已穿装备[num13].物品属性强 == 11) ? true : false))
					{
						FLD_装备_追加_防御 += World.衣服11阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 198;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 176;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 220;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 1 && ((装备栏已穿装备[num13].物品属性强 == 12) ? true : false))
					{
						FLD_装备_追加_防御 += World.衣服12阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 233;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 209;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 257;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 1 && ((装备栏已穿装备[num13].物品属性强 == 13) ? true : false))
					{
						FLD_装备_追加_防御 += World.衣服13阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 268;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 242;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 294;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 1 && ((装备栏已穿装备[num13].物品属性强 == 14) ? true : false))
					{
						FLD_装备_追加_防御 += World.衣服14阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 303;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 275;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 331;
						}
						FLD_装备_追加_罡气 = 衣服防御力 / 10;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 1 && ((装备栏已穿装备[num13].物品属性强 == 15) ? true : false))
					{
						FLD_装备_追加_防御 += World.衣服15阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 343;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 315;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 371;
						}
						FLD_装备_追加_罡气 = 衣服防御力 / 5;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 5 && ((装备栏已穿装备[num13].物品属性强 == 8) ? true : false))
					{
						FLD_装备_追加_防御 += World.鞋子8阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 49;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 35;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 63;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 5 && ((装备栏已穿装备[num13].物品属性强 == 9) ? true : false))
					{
						FLD_装备_追加_防御 += World.鞋子9阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 49;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 35;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 63;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 5 && ((装备栏已穿装备[num13].物品属性强 == 10) ? true : false))
					{
						FLD_装备_追加_防御 += World.鞋子10阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 113;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 93;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 133;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 5 && ((装备栏已穿装备[num13].物品属性强 == 11) ? true : false))
					{
						FLD_装备_追加_防御 += World.鞋子11阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 143;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 121;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 165;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 5 && ((装备栏已穿装备[num13].物品属性强 == 12) ? true : false))
					{
						FLD_装备_追加_防御 += World.鞋子12阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 173;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 149;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 197;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 5 && ((装备栏已穿装备[num13].物品属性强 == 13) ? true : false))
					{
						FLD_装备_追加_防御 += World.鞋子13阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 203;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 177;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 229;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 5 && ((装备栏已穿装备[num13].物品属性强 == 14) ? true : false))
					{
						FLD_装备_追加_防御 += World.鞋子14阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 233;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 205;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 261;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 5 && ((装备栏已穿装备[num13].物品属性强 == 15) ? true : false))
					{
						FLD_装备_追加_防御 += World.鞋子15阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 263;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 233;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 293;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 2 && ((装备栏已穿装备[num13].物品属性强 == 8) ? true : false))
					{
						FLD_装备_追加_防御 += World.护手8阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 49;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 35;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 63;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 2 && ((装备栏已穿装备[num13].物品属性强 == 9) ? true : false))
					{
						FLD_装备_追加_防御 += World.护手9阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 49;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 35;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 63;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 2 && ((装备栏已穿装备[num13].物品属性强 == 10) ? true : false))
					{
						FLD_装备_追加_防御 += World.护手10阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 113;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 93;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 133;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 2 && ((装备栏已穿装备[num13].物品属性强 == 11) ? true : false))
					{
						FLD_装备_追加_防御 += World.护手11阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 143;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 121;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 165;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 2 && ((装备栏已穿装备[num13].物品属性强 == 12) ? true : false))
					{
						FLD_装备_追加_防御 += World.护手10阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 173;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 149;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 197;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 2 && ((装备栏已穿装备[num13].物品属性强 == 13) ? true : false))
					{
						FLD_装备_追加_防御 += World.护手13阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 203;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 177;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 229;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 2 && ((装备栏已穿装备[num13].物品属性强 == 14) ? true : false))
					{
						FLD_装备_追加_防御 += World.护手14阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 233;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 205;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 261;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 2 && ((装备栏已穿装备[num13].物品属性强 == 15) ? true : false))
					{
						FLD_装备_追加_防御 += World.护手15阶段添加防御;
						if ((装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0) || (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0))
						{
							装备追加对怪防御 += 263;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL == 140 && value.FLD_UP_LEVEL == 0 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 233;
						}
						else if (装备栏已穿装备[num13].FLD_LEVEL >= 150 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 293;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 6 && ((装备栏已穿装备[num13].物品属性强 == 8) ? true : false))
					{
						FLD_装备_追加_防御 += World.内甲8阶段添加防御;
						if (装备栏已穿装备[num13].FLD_LEVEL >= 135 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 35;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 6 && ((装备栏已穿装备[num13].物品属性强 == 9) ? true : false))
					{
						FLD_装备_追加_防御 += World.内甲9阶段添加防御;
						if (装备栏已穿装备[num13].FLD_LEVEL >= 135 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 35;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 6 && ((装备栏已穿装备[num13].物品属性强 == 10) ? true : false))
					{
						FLD_装备_追加_防御 += World.内甲10阶段添加防御;
						if (装备栏已穿装备[num13].FLD_LEVEL >= 135 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 93;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 6 && ((装备栏已穿装备[num13].物品属性强 == 11) ? true : false))
					{
						FLD_装备_追加_防御 += World.内甲11阶段添加防御;
						if (装备栏已穿装备[num13].FLD_LEVEL >= 135 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 121;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 6 && ((装备栏已穿装备[num13].物品属性强 == 12) ? true : false))
					{
						FLD_装备_追加_防御 += World.内甲12阶段添加防御;
						if (装备栏已穿装备[num13].FLD_LEVEL >= 135 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 149;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 6 && ((装备栏已穿装备[num13].物品属性强 == 13) ? true : false))
					{
						FLD_装备_追加_防御 += World.内甲13阶段添加防御;
						if (装备栏已穿装备[num13].FLD_LEVEL >= 135 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 177;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 6 && ((装备栏已穿装备[num13].物品属性强 == 14) ? true : false))
					{
						FLD_装备_追加_防御 += World.内甲14阶段添加防御;
						if (装备栏已穿装备[num13].FLD_LEVEL >= 135 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 205;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 6 && ((装备栏已穿装备[num13].物品属性强 == 15) ? true : false))
					{
						FLD_装备_追加_防御 += World.内甲15阶段添加防御;
						if (装备栏已穿装备[num13].FLD_LEVEL >= 135 && value.FLD_UP_LEVEL == 1 && value.FLD_NJ == 0)
						{
							装备追加对怪防御 += 233;
						}
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 14)
					{
						int num15 = BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0);
						if (装备栏已穿装备[num13].FLD_强化数量 > 0 && num15 < 900105)
						{
							switch (装备栏已穿装备[num13].FLD_强化数量)
							{
							case 1:
								FLD_装备_追加_防御 += 3;
								break;
							case 2:
								FLD_装备_追加_防御 += 6;
								break;
							case 3:
								FLD_装备_追加_防御 += 9;
								break;
							case 4:
								FLD_装备_追加_防御 += 12;
								break;
							case 5:
								FLD_装备_追加_防御 += 15;
								break;
							case 6:
								FLD_装备_追加_防御 += 19;
								FLD_装备_追加_HP += 5;
								break;
							case 7:
								FLD_装备_追加_防御 += 23;
								FLD_装备_追加_HP += 10;
								break;
							case 8:
								FLD_装备_追加_防御 += 29;
								FLD_装备_追加_HP += 15;
								break;
							case 9:
								FLD_装备_追加_防御 += 38;
								FLD_装备_追加_HP += 20;
								break;
							case 10:
								FLD_装备_追加_防御 += 53;
								FLD_装备_追加_HP += 30;
								break;
							}
						}
						else if (装备栏已穿装备[num13].FLD_强化数量 > 0 && num15 > 900104)
						{
							switch (装备栏已穿装备[num13].FLD_强化数量)
							{
							case 1:
								FLD_装备_追加_防御 += 4;
								break;
							case 2:
								FLD_装备_追加_防御 += 8;
								break;
							case 3:
								FLD_装备_追加_防御 += 12;
								break;
							case 4:
								FLD_装备_追加_防御 += 16;
								break;
							case 5:
								FLD_装备_追加_防御 += 20;
								break;
							case 6:
								FLD_装备_追加_防御 += 25;
								FLD_装备_追加_HP += 5;
								人物追加战力 += 3;
								break;
							case 7:
								FLD_装备_追加_防御 += 30;
								FLD_装备_追加_HP += 10;
								人物追加战力 += 6;
								break;
							case 8:
								FLD_装备_追加_防御 += 37;
								FLD_装备_追加_HP += 15;
								人物追加战力 += 9;
								break;
							case 9:
								FLD_装备_追加_防御 += 47;
								FLD_装备_追加_HP += 20;
								人物追加战力 += 12;
								break;
							case 10:
								FLD_装备_追加_防御 += 63;
								FLD_装备_追加_HP += 30;
								人物追加战力 += 15;
								break;
							}
						}
					}
					if (装备栏已穿装备[num13].FLD_FJ_MAGIC3 == 6)
					{
						FLD_装备_追加_气功 += 3;
						FLD_装备_追加_攻击 += 100;
					}
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 7)
					{
						FLD_装备_追加_防御 += 装备栏已穿装备[num13].FLD_强化数量 * 3;
					}
					FLD_装备_追加_伤害值 += 装备栏已穿装备[num13].FLD_强化数量 * 5;
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 8)
					{
						FLD_装备_追加_HP += 装备栏已穿装备[num13].FLD_强化数量 * 10;
					}
					FLD_装备_追加_伤害值 += 装备栏已穿装备[num13].FLD_强化数量 * 5;
					if (装备栏已穿装备[num13].FLD_RESIDE2 == 10)
					{
						FLD_装备_追加_攻击 += 装备栏已穿装备[num13].FLD_强化数量 * 5;
					}
					FLD_装备_追加_伤害值 += 装备栏已穿装备[num13].FLD_强化数量 * 5;
					if (装备栏已穿装备[num13].FLD_强化数量 > 5 && ((装备栏已穿装备[num13].FLD_RESIDE2 != 6) ? true : false))
					{
						int num16 = 装备栏已穿装备[num13].FLD_强化数量 + FLD_装备_追加_防具_强化;
						if (装备栏已穿装备[num13].FLD_LEVEL < 60)
						{
							FLD_装备_追加_HP += (num16 - 5) * 5;
						}
						else
						{
							减免对方伤害 += (num16 - 5) * 8;
						}
					}
					int fLD_强化数量 = 装备栏已穿装备[num13].FLD_强化数量;
					switch (value.FLD_RESIDE2)
					{
					case 1:
						if (FLD_装备_追加_武器_强化 > 0 && ((装备栏已穿装备[num13].物品属性强 + FLD_装备_追加_武器_强化 > 15) ? true : false))
						{
							FLD_装备_增加对方异常 = 装备栏已穿装备[num13].物品属性强 + FLD_装备_追加_武器_强化 - 10;
						}
						if (this.防具追加强化总 > 0)
						{
							if (fLD_强化数量 <= 6)
							{
								int num29 = this.防具追加强化总 * 3;
								FLD_装备_追加_防御 += num29;
								if (value.FLD_RESIDE2 == 1)
								{
									衣服防御力 += num29;
								}
							}
							else if (value.FLD_RESIDE2 == 1)
							{
								int num30 = this.防具追加强化总 * 6;
								FLD_装备_追加_防御 += num30;
								衣服防御力 += num30;
							}
						}
						if (value.FLD_RESIDE2 == 1)
						{
							if (装备栏已穿装备[num13].物品属性阶段类型 != 0 && ((装备栏已穿装备[num13].物品属性阶段数 > 0) ? true : false))
							{
								int 防具追加强化总 = this.防具追加强化总;
								switch (装备栏已穿装备[num13].物品属性阶段类型)
								{
								case 1:
									FLD_装备_追加_降低百分比攻击 += (double)防具追加强化总 * 0.01;
									宠物对怪物伤害 += (double)防具追加强化总 * 0.005;
									break;
								case 2:
									FLD_装备_追加_愤怒 += 防具追加强化总;
									break;
								case 3:
									FLD_装备_追加_回避百分比 += (double)防具追加强化总 * 0.01;
									break;
								case 5:
									FLD_装备_追加_防御 += 防具追加强化总 * 3;
									break;
								case 6:
									FLD_装备_追加_中毒概率百分比 += (double)防具追加强化总 * 0.01;
									break;
								}
							}
							if (FLD_装备_追加_觉醒 > 0)
							{
								int num31 = FLD_装备_追加_觉醒 * 5;
								FLD_装备_追加_防御 += num31;
								衣服防御力 += num31;
							}
						}
						if (num13 <= 15)
						{
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001426 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 16;
									break;
								case 2:
									装备追加对怪防御 += 32;
									break;
								case 3:
									装备追加对怪防御 += 48;
									break;
								case 4:
									装备追加对怪防御 += 64;
									break;
								case 5:
									装备追加对怪防御 += 80;
									break;
								case 6:
									装备追加对怪防御 += 96;
									break;
								case 7:
									装备追加对怪防御 += 112;
									break;
								case 8:
									装备追加对怪防御 += 128;
									break;
								case 9:
									装备追加对怪防御 += 144;
									break;
								case 10:
									装备追加对怪防御 += 160;
									break;
								case 11:
									装备追加对怪防御 += 176;
									break;
								case 12:
									装备追加对怪防御 += 192;
									break;
								case 13:
									装备追加对怪防御 += 208;
									break;
								case 14:
									装备追加对怪防御 += 224;
									break;
								case 15:
									装备追加对怪防御 += 240;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001422 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 8;
									break;
								case 2:
									装备追加对怪防御 += 16;
									break;
								case 3:
									装备追加对怪防御 += 24;
									break;
								case 4:
									装备追加对怪防御 += 32;
									break;
								case 5:
									装备追加对怪防御 += 40;
									break;
								case 6:
									装备追加对怪防御 += 48;
									break;
								case 7:
									装备追加对怪防御 += 56;
									break;
								case 8:
									装备追加对怪防御 += 64;
									break;
								case 9:
									装备追加对怪防御 += 72;
									break;
								case 10:
									装备追加对怪防御 += 80;
									break;
								case 11:
									装备追加对怪防御 += 88;
									break;
								case 12:
									装备追加对怪防御 += 96;
									break;
								case 13:
									装备追加对怪防御 += 104;
									break;
								case 14:
									装备追加对怪防御 += 112;
									break;
								case 15:
									装备追加对怪防御 += 120;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001418 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 4;
									break;
								case 2:
									装备追加对怪防御 += 8;
									break;
								case 3:
									装备追加对怪防御 += 12;
									break;
								case 4:
									装备追加对怪防御 += 16;
									break;
								case 5:
									装备追加对怪防御 += 20;
									break;
								case 6:
									装备追加对怪防御 += 24;
									break;
								case 7:
									装备追加对怪防御 += 28;
									break;
								case 8:
									装备追加对怪防御 += 32;
									break;
								case 9:
									装备追加对怪防御 += 36;
									break;
								case 10:
									装备追加对怪防御 += 40;
									break;
								case 11:
									装备追加对怪防御 += 44;
									break;
								case 12:
									装备追加对怪防御 += 48;
									break;
								case 13:
									装备追加对怪防御 += 52;
									break;
								case 14:
									装备追加对怪防御 += 56;
									break;
								case 15:
									装备追加对怪防御 += 60;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001414 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 2;
									break;
								case 2:
									装备追加对怪防御 += 4;
									break;
								case 3:
									装备追加对怪防御 += 6;
									break;
								case 4:
									装备追加对怪防御 += 8;
									break;
								case 5:
									装备追加对怪防御 += 10;
									break;
								case 6:
									装备追加对怪防御 += 12;
									break;
								case 7:
									装备追加对怪防御 += 14;
									break;
								case 8:
									装备追加对怪防御 += 16;
									break;
								case 9:
									装备追加对怪防御 += 18;
									break;
								case 10:
									装备追加对怪防御 += 20;
									break;
								case 11:
									装备追加对怪防御 += 22;
									break;
								case 12:
									装备追加对怪防御 += 24;
									break;
								case 13:
									装备追加对怪防御 += 26;
									break;
								case 14:
									装备追加对怪防御 += 28;
									break;
								case 15:
									装备追加对怪防御 += 30;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001406 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 20;
									break;
								case 2:
									装备追加对怪防御 += 40;
									break;
								case 3:
									装备追加对怪防御 += 60;
									break;
								case 4:
									装备追加对怪防御 += 80;
									break;
								case 5:
									装备追加对怪防御 += 100;
									break;
								case 6:
									装备追加对怪防御 += 120;
									break;
								case 7:
									装备追加对怪防御 += 140;
									break;
								case 8:
									装备追加对怪防御 += 160;
									break;
								case 9:
									装备追加对怪防御 += 180;
									break;
								case 10:
									装备追加对怪防御 += 200;
									break;
								case 11:
									装备追加对怪防御 += 220;
									break;
								case 12:
									装备追加对怪防御 += 240;
									break;
								case 13:
									装备追加对怪防御 += 260;
									break;
								case 14:
									装备追加对怪防御 += 280;
									break;
								case 15:
									装备追加对怪防御 += 300;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001401 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 15;
									break;
								case 2:
									装备追加对怪防御 += 30;
									break;
								case 3:
									装备追加对怪防御 += 45;
									break;
								case 4:
									装备追加对怪防御 += 60;
									break;
								case 5:
									装备追加对怪防御 += 75;
									break;
								case 6:
									装备追加对怪防御 += 90;
									break;
								case 7:
									装备追加对怪防御 += 105;
									break;
								case 8:
									装备追加对怪防御 += 120;
									break;
								case 9:
									装备追加对怪防御 += 135;
									break;
								case 10:
									装备追加对怪防御 += 150;
									break;
								case 11:
									装备追加对怪防御 += 165;
									break;
								case 12:
									装备追加对怪防御 += 180;
									break;
								case 13:
									装备追加对怪防御 += 195;
									break;
								case 14:
									装备追加对怪防御 += 210;
									break;
								case 15:
									装备追加对怪防御 += 225;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001396 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 10;
									break;
								case 2:
									装备追加对怪防御 += 20;
									break;
								case 3:
									装备追加对怪防御 += 30;
									break;
								case 4:
									装备追加对怪防御 += 40;
									break;
								case 5:
									装备追加对怪防御 += 50;
									break;
								case 6:
									装备追加对怪防御 += 60;
									break;
								case 7:
									装备追加对怪防御 += 70;
									break;
								case 8:
									装备追加对怪防御 += 80;
									break;
								case 9:
									装备追加对怪防御 += 90;
									break;
								case 10:
									装备追加对怪防御 += 100;
									break;
								case 11:
									装备追加对怪防御 += 110;
									break;
								case 12:
									装备追加对怪防御 += 120;
									break;
								case 13:
									装备追加对怪防御 += 130;
									break;
								case 14:
									装备追加对怪防御 += 140;
									break;
								case 15:
									装备追加对怪防御 += 150;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001391 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 5;
									break;
								case 2:
									装备追加对怪防御 += 10;
									break;
								case 3:
									装备追加对怪防御 += 15;
									break;
								case 4:
									装备追加对怪防御 += 20;
									break;
								case 5:
									装备追加对怪防御 += 25;
									break;
								case 6:
									装备追加对怪防御 += 30;
									break;
								case 7:
									装备追加对怪防御 += 35;
									break;
								case 8:
									装备追加对怪防御 += 40;
									break;
								case 9:
									装备追加对怪防御 += 45;
									break;
								case 10:
									装备追加对怪防御 += 50;
									break;
								case 11:
									装备追加对怪防御 += 55;
									break;
								case 12:
									装备追加对怪防御 += 60;
									break;
								case 13:
									装备追加对怪防御 += 65;
									break;
								case 14:
									装备追加对怪防御 += 70;
									break;
								case 15:
									装备追加对怪防御 += 75;
									break;
								}
							}
							if (BitConverter.ToInt32(辅助装备栏装备[num13].物品ID, 0) == 900000228 && 装备栏已穿装备[num13].FLD_RESIDE2 == 1)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 10:
									FLD_装备_追加_HP += 200;
									FLD_装备_追加_攻击 += 200;
									FLD_装备_追加_防御 += 200;
									break;
								case 11:
									FLD_装备_追加_HP += 300;
									FLD_装备_追加_攻击 += 300;
									FLD_装备_追加_防御 += 300;
									break;
								case 12:
									FLD_装备_追加_HP += 400;
									FLD_装备_追加_攻击 += 500;
									FLD_装备_追加_防御 += 500;
									break;
								case 13:
									FLD_装备_追加_HP += 600;
									FLD_装备_追加_攻击 += 600;
									FLD_装备_追加_防御 += 600;
									break;
								case 14:
									FLD_装备_追加_HP += 700;
									FLD_装备_追加_攻击 += 700;
									FLD_装备_追加_防御 += 700;
									break;
								case 15:
									FLD_装备_追加_HP += 800;
									FLD_装备_追加_攻击 += 800;
									FLD_装备_追加_防御 += 800;
									break;
								}
							}
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 115301001)
						{
							num12++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 115302001)
						{
							num32++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 820301011 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 820302011)
						{
							num3++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 125301001)
						{
							num5++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 125300001)
						{
							num6++;
						}
						if (装备栏已穿装备[num13].FLD_强化数量 + this.防具追加强化总 > 15)
						{
							强化防具追加百分比 += 2;
						}
						break;
					case 2:
						if (this.防具追加强化总 > 0)
						{
							if (fLD_强化数量 <= 6)
							{
								if (value.FLD_LEVEL < 60)
								{
									FLD_装备_追加_HP += this.防具追加强化总 * 5;
								}
								else
								{
									FLD_装备_降低_伤害值 += this.防具追加强化总 * 5;
								}
							}
							else
							{
								FLD_装备_追加_防御 += this.防具追加强化总 * 6;
								if (value.FLD_LEVEL < 60)
								{
									FLD_装备_追加_HP += this.防具追加强化总 * 10;
								}
								else
								{
									FLD_装备_降低_伤害值 += this.防具追加强化总 * 10;
								}
							}
						}
						if (num <= 15)
						{
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001428 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 16;
									break;
								case 2:
									装备追加对怪防御 += 32;
									break;
								case 3:
									装备追加对怪防御 += 48;
									break;
								case 4:
									装备追加对怪防御 += 64;
									break;
								case 5:
									装备追加对怪防御 += 80;
									break;
								case 6:
									装备追加对怪防御 += 96;
									break;
								case 7:
									装备追加对怪防御 += 112;
									break;
								case 8:
									装备追加对怪防御 += 128;
									break;
								case 9:
									装备追加对怪防御 += 144;
									break;
								case 10:
									装备追加对怪防御 += 160;
									break;
								case 11:
									装备追加对怪防御 += 176;
									break;
								case 12:
									装备追加对怪防御 += 192;
									break;
								case 13:
									装备追加对怪防御 += 208;
									break;
								case 14:
									装备追加对怪防御 += 224;
									break;
								case 15:
									装备追加对怪防御 += 240;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001424 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 8;
									break;
								case 2:
									装备追加对怪防御 += 16;
									break;
								case 3:
									装备追加对怪防御 += 24;
									break;
								case 4:
									装备追加对怪防御 += 32;
									break;
								case 5:
									装备追加对怪防御 += 40;
									break;
								case 6:
									装备追加对怪防御 += 48;
									break;
								case 7:
									装备追加对怪防御 += 56;
									break;
								case 8:
									装备追加对怪防御 += 64;
									break;
								case 9:
									装备追加对怪防御 += 72;
									break;
								case 10:
									装备追加对怪防御 += 80;
									break;
								case 11:
									装备追加对怪防御 += 88;
									break;
								case 12:
									装备追加对怪防御 += 96;
									break;
								case 13:
									装备追加对怪防御 += 104;
									break;
								case 14:
									装备追加对怪防御 += 112;
									break;
								case 15:
									装备追加对怪防御 += 120;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001420 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 4;
									break;
								case 2:
									装备追加对怪防御 += 8;
									break;
								case 3:
									装备追加对怪防御 += 12;
									break;
								case 4:
									装备追加对怪防御 += 16;
									break;
								case 5:
									装备追加对怪防御 += 20;
									break;
								case 6:
									装备追加对怪防御 += 24;
									break;
								case 7:
									装备追加对怪防御 += 28;
									break;
								case 8:
									装备追加对怪防御 += 32;
									break;
								case 9:
									装备追加对怪防御 += 36;
									break;
								case 10:
									装备追加对怪防御 += 40;
									break;
								case 11:
									装备追加对怪防御 += 44;
									break;
								case 12:
									装备追加对怪防御 += 48;
									break;
								case 13:
									装备追加对怪防御 += 52;
									break;
								case 14:
									装备追加对怪防御 += 56;
									break;
								case 15:
									装备追加对怪防御 += 60;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001416 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 2;
									break;
								case 2:
									装备追加对怪防御 += 4;
									break;
								case 3:
									装备追加对怪防御 += 6;
									break;
								case 4:
									装备追加对怪防御 += 8;
									break;
								case 5:
									装备追加对怪防御 += 10;
									break;
								case 6:
									装备追加对怪防御 += 12;
									break;
								case 7:
									装备追加对怪防御 += 14;
									break;
								case 8:
									装备追加对怪防御 += 16;
									break;
								case 9:
									装备追加对怪防御 += 18;
									break;
								case 10:
									装备追加对怪防御 += 20;
									break;
								case 11:
									装备追加对怪防御 += 22;
									break;
								case 12:
									装备追加对怪防御 += 24;
									break;
								case 13:
									装备追加对怪防御 += 26;
									break;
								case 14:
									装备追加对怪防御 += 28;
									break;
								case 15:
									装备追加对怪防御 += 30;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001408 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 20;
									break;
								case 2:
									装备追加对怪防御 += 40;
									break;
								case 3:
									装备追加对怪防御 += 60;
									break;
								case 4:
									装备追加对怪防御 += 80;
									break;
								case 5:
									装备追加对怪防御 += 100;
									break;
								case 6:
									装备追加对怪防御 += 120;
									break;
								case 7:
									装备追加对怪防御 += 140;
									break;
								case 8:
									装备追加对怪防御 += 160;
									break;
								case 9:
									装备追加对怪防御 += 180;
									break;
								case 10:
									装备追加对怪防御 += 200;
									break;
								case 11:
									装备追加对怪防御 += 220;
									break;
								case 12:
									装备追加对怪防御 += 240;
									break;
								case 13:
									装备追加对怪防御 += 260;
									break;
								case 14:
									装备追加对怪防御 += 280;
									break;
								case 15:
									装备追加对怪防御 += 300;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001403 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 15;
									break;
								case 2:
									装备追加对怪防御 += 30;
									break;
								case 3:
									装备追加对怪防御 += 45;
									break;
								case 4:
									装备追加对怪防御 += 60;
									break;
								case 5:
									装备追加对怪防御 += 75;
									break;
								case 6:
									装备追加对怪防御 += 90;
									break;
								case 7:
									装备追加对怪防御 += 105;
									break;
								case 8:
									装备追加对怪防御 += 120;
									break;
								case 9:
									装备追加对怪防御 += 135;
									break;
								case 10:
									装备追加对怪防御 += 150;
									break;
								case 11:
									装备追加对怪防御 += 165;
									break;
								case 12:
									装备追加对怪防御 += 180;
									break;
								case 13:
									装备追加对怪防御 += 195;
									break;
								case 14:
									装备追加对怪防御 += 210;
									break;
								case 15:
									装备追加对怪防御 += 225;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001398 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 10;
									break;
								case 2:
									装备追加对怪防御 += 20;
									break;
								case 3:
									装备追加对怪防御 += 30;
									break;
								case 4:
									装备追加对怪防御 += 40;
									break;
								case 5:
									装备追加对怪防御 += 50;
									break;
								case 6:
									装备追加对怪防御 += 60;
									break;
								case 7:
									装备追加对怪防御 += 70;
									break;
								case 8:
									装备追加对怪防御 += 80;
									break;
								case 9:
									装备追加对怪防御 += 90;
									break;
								case 10:
									装备追加对怪防御 += 100;
									break;
								case 11:
									装备追加对怪防御 += 110;
									break;
								case 12:
									装备追加对怪防御 += 120;
									break;
								case 13:
									装备追加对怪防御 += 130;
									break;
								case 14:
									装备追加对怪防御 += 140;
									break;
								case 15:
									装备追加对怪防御 += 150;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001393 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 5;
									break;
								case 2:
									装备追加对怪防御 += 10;
									break;
								case 3:
									装备追加对怪防御 += 15;
									break;
								case 4:
									装备追加对怪防御 += 20;
									break;
								case 5:
									装备追加对怪防御 += 25;
									break;
								case 6:
									装备追加对怪防御 += 30;
									break;
								case 7:
									装备追加对怪防御 += 35;
									break;
								case 8:
									装备追加对怪防御 += 40;
									break;
								case 9:
									装备追加对怪防御 += 45;
									break;
								case 10:
									装备追加对怪防御 += 50;
									break;
								case 11:
									装备追加对怪防御 += 55;
									break;
								case 12:
									装备追加对怪防御 += 60;
									break;
								case 13:
									装备追加对怪防御 += 65;
									break;
								case 14:
									装备追加对怪防御 += 70;
									break;
								case 15:
									装备追加对怪防御 += 75;
									break;
								}
							}
							if (BitConverter.ToInt32(辅助装备栏装备[num13].物品ID, 0) == 500801 && 装备栏已穿装备[num13].FLD_RESIDE2 == 2)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 10:
									FLD_装备_追加_HP += 200;
									FLD_装备_追加_攻击 += 200;
									FLD_装备_追加_防御 += 200;
									break;
								case 11:
									FLD_装备_追加_HP += 300;
									FLD_装备_追加_攻击 += 300;
									FLD_装备_追加_防御 += 300;
									break;
								case 12:
									FLD_装备_追加_HP += 400;
									FLD_装备_追加_攻击 += 500;
									FLD_装备_追加_防御 += 500;
									break;
								case 13:
									FLD_装备_追加_HP += 600;
									FLD_装备_追加_攻击 += 600;
									FLD_装备_追加_防御 += 600;
									break;
								case 14:
									FLD_装备_追加_HP += 700;
									FLD_装备_追加_攻击 += 700;
									FLD_装备_追加_防御 += 700;
									break;
								case 15:
									FLD_装备_追加_HP += 800;
									FLD_装备_追加_攻击 += 800;
									FLD_装备_追加_防御 += 800;
									break;
								}
							}
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 115501001)
						{
							num12++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 115502001)
						{
							num32++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 125501001)
						{
							num5++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 125500001)
						{
							num6++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 501012 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 502012)
						{
							num3++;
						}
						if (装备栏已穿装备[num13].FLD_强化数量 + FLD_装备_追加_防具_强化 > 15)
						{
							强化防具追加百分比 += 2;
						}
						break;
					case 5:
						if (this.防具追加强化总 > 0)
						{
							if (fLD_强化数量 <= 6)
							{
								if (value.FLD_LEVEL < 60)
								{
									FLD_装备_追加_HP += this.防具追加强化总 * 5;
								}
								else
								{
									FLD_装备_降低_伤害值 += this.防具追加强化总 * 5;
								}
							}
							else
							{
								FLD_装备_追加_防御 += this.防具追加强化总 * 6;
								if (value.FLD_LEVEL < 60)
								{
									FLD_装备_追加_HP += this.防具追加强化总 * 10;
								}
								else
								{
									FLD_装备_降低_伤害值 += this.防具追加强化总 * 10;
								}
							}
						}
						if (num13 <= 15)
						{
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001429 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 16;
									break;
								case 2:
									装备追加对怪防御 += 32;
									break;
								case 3:
									装备追加对怪防御 += 48;
									break;
								case 4:
									装备追加对怪防御 += 64;
									break;
								case 5:
									装备追加对怪防御 += 80;
									break;
								case 6:
									装备追加对怪防御 += 96;
									break;
								case 7:
									装备追加对怪防御 += 112;
									break;
								case 8:
									装备追加对怪防御 += 128;
									break;
								case 9:
									装备追加对怪防御 += 144;
									break;
								case 10:
									装备追加对怪防御 += 160;
									break;
								case 11:
									装备追加对怪防御 += 176;
									break;
								case 12:
									装备追加对怪防御 += 192;
									break;
								case 13:
									装备追加对怪防御 += 208;
									break;
								case 14:
									装备追加对怪防御 += 224;
									break;
								case 15:
									装备追加对怪防御 += 240;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001425 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 8;
									break;
								case 2:
									装备追加对怪防御 += 16;
									break;
								case 3:
									装备追加对怪防御 += 24;
									break;
								case 4:
									装备追加对怪防御 += 32;
									break;
								case 5:
									装备追加对怪防御 += 40;
									break;
								case 6:
									装备追加对怪防御 += 48;
									break;
								case 7:
									装备追加对怪防御 += 56;
									break;
								case 8:
									装备追加对怪防御 += 64;
									break;
								case 9:
									装备追加对怪防御 += 72;
									break;
								case 10:
									装备追加对怪防御 += 80;
									break;
								case 11:
									装备追加对怪防御 += 88;
									break;
								case 12:
									装备追加对怪防御 += 96;
									break;
								case 13:
									装备追加对怪防御 += 104;
									break;
								case 14:
									装备追加对怪防御 += 112;
									break;
								case 15:
									装备追加对怪防御 += 120;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001421 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 4;
									break;
								case 2:
									装备追加对怪防御 += 8;
									break;
								case 3:
									装备追加对怪防御 += 12;
									break;
								case 4:
									装备追加对怪防御 += 16;
									break;
								case 5:
									装备追加对怪防御 += 20;
									break;
								case 6:
									装备追加对怪防御 += 24;
									break;
								case 7:
									装备追加对怪防御 += 28;
									break;
								case 8:
									装备追加对怪防御 += 32;
									break;
								case 9:
									装备追加对怪防御 += 36;
									break;
								case 10:
									装备追加对怪防御 += 40;
									break;
								case 11:
									装备追加对怪防御 += 44;
									break;
								case 12:
									装备追加对怪防御 += 48;
									break;
								case 13:
									装备追加对怪防御 += 52;
									break;
								case 14:
									装备追加对怪防御 += 56;
									break;
								case 15:
									装备追加对怪防御 += 60;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001417 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 2;
									break;
								case 2:
									装备追加对怪防御 += 4;
									break;
								case 3:
									装备追加对怪防御 += 6;
									break;
								case 4:
									装备追加对怪防御 += 8;
									break;
								case 5:
									装备追加对怪防御 += 10;
									break;
								case 6:
									装备追加对怪防御 += 12;
									break;
								case 7:
									装备追加对怪防御 += 14;
									break;
								case 8:
									装备追加对怪防御 += 16;
									break;
								case 9:
									装备追加对怪防御 += 18;
									break;
								case 10:
									装备追加对怪防御 += 20;
									break;
								case 11:
									装备追加对怪防御 += 22;
									break;
								case 12:
									装备追加对怪防御 += 24;
									break;
								case 13:
									装备追加对怪防御 += 26;
									break;
								case 14:
									装备追加对怪防御 += 28;
									break;
								case 15:
									装备追加对怪防御 += 30;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001409 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 20;
									break;
								case 2:
									装备追加对怪防御 += 40;
									break;
								case 3:
									装备追加对怪防御 += 60;
									break;
								case 4:
									装备追加对怪防御 += 80;
									break;
								case 5:
									装备追加对怪防御 += 100;
									break;
								case 6:
									装备追加对怪防御 += 120;
									break;
								case 7:
									装备追加对怪防御 += 140;
									break;
								case 8:
									装备追加对怪防御 += 160;
									break;
								case 9:
									装备追加对怪防御 += 180;
									break;
								case 10:
									装备追加对怪防御 += 200;
									break;
								case 11:
									装备追加对怪防御 += 220;
									break;
								case 12:
									装备追加对怪防御 += 240;
									break;
								case 13:
									装备追加对怪防御 += 260;
									break;
								case 14:
									装备追加对怪防御 += 280;
									break;
								case 15:
									装备追加对怪防御 += 300;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001404 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 15;
									break;
								case 2:
									装备追加对怪防御 += 30;
									break;
								case 3:
									装备追加对怪防御 += 45;
									break;
								case 4:
									装备追加对怪防御 += 60;
									break;
								case 5:
									装备追加对怪防御 += 75;
									break;
								case 6:
									装备追加对怪防御 += 90;
									break;
								case 7:
									装备追加对怪防御 += 105;
									break;
								case 8:
									装备追加对怪防御 += 120;
									break;
								case 9:
									装备追加对怪防御 += 135;
									break;
								case 10:
									装备追加对怪防御 += 150;
									break;
								case 11:
									装备追加对怪防御 += 165;
									break;
								case 12:
									装备追加对怪防御 += 180;
									break;
								case 13:
									装备追加对怪防御 += 195;
									break;
								case 14:
									装备追加对怪防御 += 210;
									break;
								case 15:
									装备追加对怪防御 += 225;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001399 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 10;
									break;
								case 2:
									装备追加对怪防御 += 20;
									break;
								case 3:
									装备追加对怪防御 += 30;
									break;
								case 4:
									装备追加对怪防御 += 40;
									break;
								case 5:
									装备追加对怪防御 += 50;
									break;
								case 6:
									装备追加对怪防御 += 60;
									break;
								case 7:
									装备追加对怪防御 += 70;
									break;
								case 8:
									装备追加对怪防御 += 80;
									break;
								case 9:
									装备追加对怪防御 += 90;
									break;
								case 10:
									装备追加对怪防御 += 100;
									break;
								case 11:
									装备追加对怪防御 += 110;
									break;
								case 12:
									装备追加对怪防御 += 120;
									break;
								case 13:
									装备追加对怪防御 += 130;
									break;
								case 14:
									装备追加对怪防御 += 140;
									break;
								case 15:
									装备追加对怪防御 += 150;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001394 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 5;
									break;
								case 2:
									装备追加对怪防御 += 10;
									break;
								case 3:
									装备追加对怪防御 += 15;
									break;
								case 4:
									装备追加对怪防御 += 20;
									break;
								case 5:
									装备追加对怪防御 += 25;
									break;
								case 6:
									装备追加对怪防御 += 30;
									break;
								case 7:
									装备追加对怪防御 += 35;
									break;
								case 8:
									装备追加对怪防御 += 40;
									break;
								case 9:
									装备追加对怪防御 += 45;
									break;
								case 10:
									装备追加对怪防御 += 50;
									break;
								case 11:
									装备追加对怪防御 += 55;
									break;
								case 12:
									装备追加对怪防御 += 60;
									break;
								case 13:
									装备追加对怪防御 += 65;
									break;
								case 14:
									装备追加对怪防御 += 70;
									break;
								case 15:
									装备追加对怪防御 += 75;
									break;
								}
							}
							if (BitConverter.ToInt32(辅助装备栏装备[num13].物品ID, 0) == 800801 && 装备栏已穿装备[num13].FLD_RESIDE2 == 5)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 10:
									FLD_装备_追加_HP += 200;
									FLD_装备_追加_攻击 += 200;
									FLD_装备_追加_防御 += 200;
									break;
								case 11:
									FLD_装备_追加_HP += 300;
									FLD_装备_追加_攻击 += 300;
									FLD_装备_追加_防御 += 300;
									break;
								case 12:
									FLD_装备_追加_HP += 400;
									FLD_装备_追加_攻击 += 500;
									FLD_装备_追加_防御 += 500;
									break;
								case 13:
									FLD_装备_追加_HP += 600;
									FLD_装备_追加_攻击 += 600;
									FLD_装备_追加_防御 += 600;
									break;
								case 14:
									FLD_装备_追加_HP += 700;
									FLD_装备_追加_攻击 += 700;
									FLD_装备_追加_防御 += 700;
									break;
								case 15:
									FLD_装备_追加_HP += 800;
									FLD_装备_追加_攻击 += 800;
									FLD_装备_追加_防御 += 800;
									break;
								}
							}
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 115801001)
						{
							num12++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 115802001)
						{
							num32++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 125801001)
						{
							num5++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 125800001)
						{
							num6++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 801013 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 802013)
						{
							num3++;
						}
						if (装备栏已穿装备[num13].FLD_强化数量 + FLD_装备_追加_防具_强化 > 15)
						{
							强化防具追加百分比 += 2;
						}
						break;
					case 4:
					{
						long get物品ID2 = 装备栏已穿装备[num13].Get物品ID;
						if (num13 <= 15)
						{
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001413 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪攻击 += 27;
									break;
								case 2:
									装备追加对怪攻击 += 54;
									break;
								case 3:
									装备追加对怪攻击 += 81;
									break;
								case 4:
									装备追加对怪攻击 += 108;
									break;
								case 5:
									装备追加对怪攻击 += 135;
									break;
								case 6:
									装备追加对怪攻击 += 162;
									break;
								case 7:
									装备追加对怪攻击 += 189;
									break;
								case 8:
									装备追加对怪攻击 += 216;
									break;
								case 9:
									装备追加对怪攻击 += 243;
									break;
								case 10:
									装备追加对怪攻击 += 270;
									break;
								case 11:
									装备追加对怪攻击 += 297;
									break;
								case 12:
									装备追加对怪攻击 += 324;
									break;
								case 13:
									装备追加对怪攻击 += 351;
									break;
								case 14:
									装备追加对怪攻击 += 378;
									break;
								case 15:
									装备追加对怪攻击 += 405;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001412 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪攻击 += 12;
									break;
								case 2:
									装备追加对怪攻击 += 24;
									break;
								case 3:
									装备追加对怪攻击 += 36;
									break;
								case 4:
									装备追加对怪攻击 += 48;
									break;
								case 5:
									装备追加对怪攻击 += 60;
									break;
								case 6:
									装备追加对怪攻击 += 72;
									break;
								case 7:
									装备追加对怪攻击 += 84;
									break;
								case 8:
									装备追加对怪攻击 += 96;
									break;
								case 9:
									装备追加对怪攻击 += 108;
									break;
								case 10:
									装备追加对怪攻击 += 120;
									break;
								case 11:
									装备追加对怪攻击 += 132;
									break;
								case 12:
									装备追加对怪攻击 += 144;
									break;
								case 13:
									装备追加对怪攻击 += 156;
									break;
								case 14:
									装备追加对怪攻击 += 168;
									break;
								case 15:
									装备追加对怪攻击 += 180;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001411 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪攻击 += 6;
									break;
								case 2:
									装备追加对怪攻击 += 12;
									break;
								case 3:
									装备追加对怪攻击 += 18;
									break;
								case 4:
									装备追加对怪攻击 += 24;
									break;
								case 5:
									装备追加对怪攻击 += 30;
									break;
								case 6:
									装备追加对怪攻击 += 36;
									break;
								case 7:
									装备追加对怪攻击 += 42;
									break;
								case 8:
									装备追加对怪攻击 += 48;
									break;
								case 9:
									装备追加对怪攻击 += 54;
									break;
								case 10:
									装备追加对怪攻击 += 60;
									break;
								case 11:
									装备追加对怪攻击 += 66;
									break;
								case 12:
									装备追加对怪攻击 += 72;
									break;
								case 13:
									装备追加对怪攻击 += 78;
									break;
								case 14:
									装备追加对怪攻击 += 84;
									break;
								case 15:
									装备追加对怪攻击 += 90;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001410 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪攻击 += 3;
									break;
								case 2:
									装备追加对怪攻击 += 6;
									break;
								case 3:
									装备追加对怪攻击 += 9;
									break;
								case 4:
									装备追加对怪攻击 += 12;
									break;
								case 5:
									装备追加对怪攻击 += 15;
									break;
								case 6:
									装备追加对怪攻击 += 18;
									break;
								case 7:
									装备追加对怪攻击 += 21;
									break;
								case 8:
									装备追加对怪攻击 += 24;
									break;
								case 9:
									装备追加对怪攻击 += 27;
									break;
								case 10:
									装备追加对怪攻击 += 30;
									break;
								case 11:
									装备追加对怪攻击 += 33;
									break;
								case 12:
									装备追加对怪攻击 += 36;
									break;
								case 13:
									装备追加对怪攻击 += 39;
									break;
								case 14:
									装备追加对怪攻击 += 42;
									break;
								case 15:
									装备追加对怪攻击 += 45;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001405 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪攻击 += 20;
									break;
								case 2:
									装备追加对怪攻击 += 40;
									break;
								case 3:
									装备追加对怪攻击 += 60;
									break;
								case 4:
									装备追加对怪攻击 += 80;
									break;
								case 5:
									装备追加对怪攻击 += 100;
									break;
								case 6:
									装备追加对怪攻击 += 120;
									break;
								case 7:
									装备追加对怪攻击 += 140;
									break;
								case 8:
									装备追加对怪攻击 += 160;
									break;
								case 9:
									装备追加对怪攻击 += 180;
									break;
								case 10:
									装备追加对怪攻击 += 200;
									break;
								case 11:
									装备追加对怪攻击 += 220;
									break;
								case 12:
									装备追加对怪攻击 += 240;
									break;
								case 13:
									装备追加对怪攻击 += 260;
									break;
								case 14:
									装备追加对怪攻击 += 280;
									break;
								case 15:
									装备追加对怪攻击 += 300;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001400 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪攻击 += 15;
									break;
								case 2:
									装备追加对怪攻击 += 30;
									break;
								case 3:
									装备追加对怪攻击 += 45;
									break;
								case 4:
									装备追加对怪攻击 += 60;
									break;
								case 5:
									装备追加对怪攻击 += 75;
									break;
								case 6:
									装备追加对怪攻击 += 90;
									break;
								case 7:
									装备追加对怪攻击 += 105;
									break;
								case 8:
									装备追加对怪攻击 += 120;
									break;
								case 9:
									装备追加对怪攻击 += 135;
									break;
								case 10:
									装备追加对怪攻击 += 150;
									break;
								case 11:
									装备追加对怪攻击 += 165;
									break;
								case 12:
									装备追加对怪攻击 += 180;
									break;
								case 13:
									装备追加对怪攻击 += 195;
									break;
								case 14:
									装备追加对怪攻击 += 210;
									break;
								case 15:
									装备追加对怪攻击 += 225;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001395 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪攻击 += 10;
									break;
								case 2:
									装备追加对怪攻击 += 20;
									break;
								case 3:
									装备追加对怪攻击 += 30;
									break;
								case 4:
									装备追加对怪攻击 += 40;
									break;
								case 5:
									装备追加对怪攻击 += 50;
									break;
								case 6:
									装备追加对怪攻击 += 60;
									break;
								case 7:
									装备追加对怪攻击 += 70;
									break;
								case 8:
									装备追加对怪攻击 += 80;
									break;
								case 9:
									装备追加对怪攻击 += 90;
									break;
								case 10:
									装备追加对怪攻击 += 100;
									break;
								case 11:
									装备追加对怪攻击 += 110;
									break;
								case 12:
									装备追加对怪攻击 += 120;
									break;
								case 13:
									装备追加对怪攻击 += 130;
									break;
								case 14:
									装备追加对怪攻击 += 140;
									break;
								case 15:
									装备追加对怪攻击 += 150;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001390 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪攻击 += 5;
									break;
								case 2:
									装备追加对怪攻击 += 10;
									break;
								case 3:
									装备追加对怪攻击 += 15;
									break;
								case 4:
									装备追加对怪攻击 += 20;
									break;
								case 5:
									装备追加对怪攻击 += 25;
									break;
								case 6:
									装备追加对怪攻击 += 30;
									break;
								case 7:
									装备追加对怪攻击 += 35;
									break;
								case 8:
									装备追加对怪攻击 += 40;
									break;
								case 9:
									装备追加对怪攻击 += 45;
									break;
								case 10:
									装备追加对怪攻击 += 50;
									break;
								case 11:
									装备追加对怪攻击 += 55;
									break;
								case 12:
									装备追加对怪攻击 += 60;
									break;
								case 13:
									装备追加对怪攻击 += 65;
									break;
								case 14:
									装备追加对怪攻击 += 70;
									break;
								case 15:
									装备追加对怪攻击 += 75;
									break;
								}
							}
							if (BitConverter.ToInt32(辅助装备栏装备[num13].物品ID, 0) == 900000047 && 装备栏已穿装备[num13].FLD_RESIDE2 == 4)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 10:
									FLD_装备_追加_HP += 200;
									FLD_装备_追加_攻击 += 200;
									FLD_装备_追加_防御 += 200;
									break;
								case 11:
									FLD_装备_追加_HP += 300;
									FLD_装备_追加_攻击 += 300;
									FLD_装备_追加_防御 += 300;
									break;
								case 12:
									FLD_装备_追加_HP += 400;
									FLD_装备_追加_攻击 += 500;
									FLD_装备_追加_防御 += 500;
									break;
								case 13:
									FLD_装备_追加_HP += 600;
									FLD_装备_追加_攻击 += 600;
									FLD_装备_追加_防御 += 600;
									break;
								case 14:
									FLD_装备_追加_HP += 700;
									FLD_装备_追加_攻击 += 700;
									FLD_装备_追加_防御 += 700;
									break;
								case 15:
									FLD_装备_追加_HP += 800;
									FLD_装备_追加_攻击 += 800;
									FLD_装备_追加_防御 += 800;
									break;
								}
							}
						}
						if (this.武器追加强化总 > 0)
						{
							int num17 = this.武器追加强化总 * 25;
							FLD_装备_追加_攻击 += num17;
							武器攻击力 += num17;
							if (装备栏已穿装备[num13].物品属性阶段类型 != 0 && ((装备栏已穿装备[num13].物品属性阶段数 > 0) ? true : false))
							{
								int 武器追加强化总 = this.武器追加强化总;
								switch (装备栏已穿装备[num13].物品属性阶段类型)
								{
								case 1:
									FLD_装备_追加_降低百分比防御 += (double)武器追加强化总 * 0.005;
									宠物对怪物伤害 += (double)武器追加强化总 * 0.003;
									break;
								case 2:
									FLD_装备_追加_初始化愤怒概率百分比 += 武器追加强化总;
									break;
								case 3:
									FLD_装备_追加_命中百分比 += (double)武器追加强化总 * 0.01;
									break;
								case 4:
									FLD_装备_武功攻击力增加百分比 += (double)武器追加强化总 * 0.5 * 0.01;
									break;
								case 5:
									FLD_装备_追加_伤害值 += 武器追加强化总 * 3;
									break;
								case 6:
									FLD_装备_追加_中毒概率百分比 += (double)武器追加强化总 * 0.01;
									FLD_装备_追加_攻击 += 武器追加强化总 * 3;
									break;
								}
							}
							ConcurrentDictionary<int, Itimesx> concurrentDictionary = new ConcurrentDictionary<int, Itimesx>();
							concurrentDictionary.TryAdd(0, 装备栏已穿装备[num13].属性1);
							concurrentDictionary.TryAdd(1, 装备栏已穿装备[num13].属性2);
							concurrentDictionary.TryAdd(2, 装备栏已穿装备[num13].属性3);
							concurrentDictionary.TryAdd(3, 装备栏已穿装备[num13].属性4);
							for (int num18 = 0; num18 < 4; num14 = num18 + 1, num18 = num14)
							{
								if (concurrentDictionary[num18].属性类型 == 0)
								{
									continue;
								}
								switch (concurrentDictionary[num18].属性类型)
								{
								case 1:
								{
									double num22 = 0.0;
									switch (fLD_强化数量)
									{
									case 5:
										if (num18 < 2)
										{
											num22 = 1.0;
											break;
										}
										continue;
									case 6:
										num22 = 1.0;
										break;
									case 7:
										if (num18 < 3)
										{
											num22 = 2.0;
											break;
										}
										continue;
									case 8:
										num22 = 2.0;
										break;
									case 9:
										num22 = 2.0;
										break;
									case 10:
										num22 = 2.0;
										break;
									case 11:
										num22 = 8.0;
										break;
									case 12:
										num22 = 8.0;
										break;
									case 13:
										num22 = 1.0;
										break;
									}
									FLD_装备_追加_攻击 += (int)num22;
									break;
								}
								case 3:
								{
									double num20 = 0.0;
									switch (fLD_强化数量)
									{
									case 5:
										if (num18 < 2)
										{
											num20 = 1.0;
											break;
										}
										continue;
									case 6:
										num20 = 1.0;
										break;
									case 7:
										if (num18 < 3)
										{
											num20 = 2.0;
											break;
										}
										continue;
									case 8:
										num20 = 2.0;
										break;
									case 9:
										num20 = 2.0;
										break;
									case 10:
										num20 = 2.0;
										break;
									case 11:
										num20 = 15.0;
										break;
									case 12:
										num20 = 15.0;
										break;
									case 13:
										num20 = 1.0;
										break;
									}
									FLD_装备_追加_HP += (int)num20;
									break;
								}
								case 7:
								{
									double num21 = 0.0;
									switch (fLD_强化数量)
									{
									case 5:
										if (num18 < 2)
										{
											num21 = 1.0;
											break;
										}
										continue;
									case 6:
										num21 = 1.0;
										break;
									case 7:
										if (num18 < 3)
										{
											num21 = 2.0;
											break;
										}
										continue;
									case 8:
										num21 = 2.0;
										break;
									case 9:
										num21 = 2.0;
										break;
									case 10:
										num21 = 2.0;
										break;
									case 11:
										num21 = 11.0;
										break;
									case 12:
										num21 = 11.0;
										break;
									case 13:
										num21 = 1.0;
										break;
									}
									FLD_装备_武功攻击力增加百分比 += num21 * World.武功攻击力百分比;
									break;
								}
								case 10:
								{
									double num19 = 0.0;
									switch (fLD_强化数量)
									{
									case 5:
										if (num18 < 2)
										{
											num19 = 1.0;
											break;
										}
										continue;
									case 6:
										num19 = 1.0;
										break;
									case 7:
										if (num18 < 3)
										{
											num19 = 2.0;
											break;
										}
										continue;
									case 8:
										num19 = 2.0;
										break;
									case 9:
										num19 = 2.0;
										break;
									case 10:
										num19 = 2.0;
										break;
									case 11:
										num19 = 15.0;
										break;
									case 12:
										num19 = 15.0;
										break;
									case 13:
										num19 = 1.0;
										break;
									}
									FLD_装备_追加_伤害值 += (int)num19;
									break;
								}
								}
							}
							if (fLD_强化数量 >= 14)
							{
								锁定人物几率 += 8;
							}
							switch (fLD_强化数量)
							{
							case 8:
								FLD_装备_追加_气功++;
								break;
							case 9:
								FLD_装备_追加_气功 += 2;
								break;
							case 10:
								FLD_装备_追加_气功 += 2;
								break;
							case 11:
								FLD_装备_追加_气功 += 2;
								break;
							case 12:
								FLD_装备_追加_气功++;
								break;
							}
							concurrentDictionary.Clear();
						}
						if (FLD_装备_追加_觉醒 > 0)
						{
							int num24 = FLD_装备_追加_觉醒 * 8;
							FLD_装备_追加_攻击 += num24;
							武器攻击力 += num24;
						}
						int num25;
						switch (get物品ID2)
						{
						case 101200001L:
						case 101220001L:
						case 201200001L:
						case 301200001L:
						case 401200001L:
						case 501200001L:
						case 701200001L:
						case 801200001L:
							num25 = 1;
							break;
						case 201220001L:
						case 301220001L:
						case 401220001L:
						case 501220001L:
							num25 = 1;
							break;
						case 701220001L:
							num25 = 1;
							break;
						default:
							num25 = ((get物品ID2 == 801220001) ? 1 : 0);
							break;
						}
						if (num25 != 0)
						{
							FLD_装备_追加_气功 += 3;
							FLD_装备_追加_经验百分比 += 0.5;
						}
						else if (FLD_装备_追加_武器_强化 > 0 && ((装备栏已穿装备[num13].物品属性强 + FLD_装备_追加_武器_强化 > 15) ? true : false))
						{
							FLD_装备_增加异常 = 装备栏已穿装备[num13].物品属性强 + FLD_装备_追加_武器_强化 - 10;
						}
						break;
					}
					case 6:
						if (num13 <= 15)
						{
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001427 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 16;
									break;
								case 2:
									装备追加对怪防御 += 32;
									break;
								case 3:
									装备追加对怪防御 += 48;
									break;
								case 4:
									装备追加对怪防御 += 64;
									break;
								case 5:
									装备追加对怪防御 += 80;
									break;
								case 6:
									装备追加对怪防御 += 96;
									break;
								case 7:
									装备追加对怪防御 += 112;
									break;
								case 8:
									装备追加对怪防御 += 128;
									break;
								case 9:
									装备追加对怪防御 += 144;
									break;
								case 10:
									装备追加对怪防御 += 160;
									break;
								case 11:
									装备追加对怪防御 += 176;
									break;
								case 12:
									装备追加对怪防御 += 192;
									break;
								case 13:
									装备追加对怪防御 += 208;
									break;
								case 14:
									装备追加对怪防御 += 224;
									break;
								case 15:
									装备追加对怪防御 += 240;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001423 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 8;
									break;
								case 2:
									装备追加对怪防御 += 16;
									break;
								case 3:
									装备追加对怪防御 += 24;
									break;
								case 4:
									装备追加对怪防御 += 32;
									break;
								case 5:
									装备追加对怪防御 += 40;
									break;
								case 6:
									装备追加对怪防御 += 48;
									break;
								case 7:
									装备追加对怪防御 += 56;
									break;
								case 8:
									装备追加对怪防御 += 64;
									break;
								case 9:
									装备追加对怪防御 += 74;
									break;
								case 10:
									装备追加对怪防御 += 82;
									break;
								case 11:
									装备追加对怪防御 += 90;
									break;
								case 12:
									装备追加对怪防御 += 98;
									break;
								case 13:
									装备追加对怪防御 += 106;
									break;
								case 14:
									装备追加对怪防御 += 112;
									break;
								case 15:
									装备追加对怪防御 += 120;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001419 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 4;
									break;
								case 2:
									装备追加对怪防御 += 8;
									break;
								case 3:
									装备追加对怪防御 += 12;
									break;
								case 4:
									装备追加对怪防御 += 16;
									break;
								case 5:
									装备追加对怪防御 += 20;
									break;
								case 6:
									装备追加对怪防御 += 24;
									break;
								case 7:
									装备追加对怪防御 += 28;
									break;
								case 8:
									装备追加对怪防御 += 32;
									break;
								case 9:
									装备追加对怪防御 += 36;
									break;
								case 10:
									装备追加对怪防御 += 40;
									break;
								case 11:
									装备追加对怪防御 += 44;
									break;
								case 12:
									装备追加对怪防御 += 48;
									break;
								case 13:
									装备追加对怪防御 += 52;
									break;
								case 14:
									装备追加对怪防御 += 56;
									break;
								case 15:
									装备追加对怪防御 += 60;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001415 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 2;
									break;
								case 2:
									装备追加对怪防御 += 4;
									break;
								case 3:
									装备追加对怪防御 += 6;
									break;
								case 4:
									装备追加对怪防御 += 8;
									break;
								case 5:
									装备追加对怪防御 += 10;
									break;
								case 6:
									装备追加对怪防御 += 12;
									break;
								case 7:
									装备追加对怪防御 += 14;
									break;
								case 8:
									装备追加对怪防御 += 16;
									break;
								case 9:
									装备追加对怪防御 += 18;
									break;
								case 10:
									装备追加对怪防御 += 20;
									break;
								case 11:
									装备追加对怪防御 += 22;
									break;
								case 12:
									装备追加对怪防御 += 24;
									break;
								case 13:
									装备追加对怪防御 += 26;
									break;
								case 14:
									装备追加对怪防御 += 28;
									break;
								case 15:
									装备追加对怪防御 += 30;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001407 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 20;
									break;
								case 2:
									装备追加对怪防御 += 40;
									break;
								case 3:
									装备追加对怪防御 += 60;
									break;
								case 4:
									装备追加对怪防御 += 80;
									break;
								case 5:
									装备追加对怪防御 += 100;
									break;
								case 6:
									装备追加对怪防御 += 120;
									break;
								case 7:
									装备追加对怪防御 += 140;
									break;
								case 8:
									装备追加对怪防御 += 160;
									break;
								case 9:
									装备追加对怪防御 += 180;
									break;
								case 10:
									装备追加对怪防御 += 200;
									break;
								case 11:
									装备追加对怪防御 += 220;
									break;
								case 12:
									装备追加对怪防御 += 240;
									break;
								case 13:
									装备追加对怪防御 += 260;
									break;
								case 14:
									装备追加对怪防御 += 280;
									break;
								case 15:
									装备追加对怪防御 += 300;
									FLD_装备_追加_战斗力 += 5;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001402 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 15;
									break;
								case 2:
									装备追加对怪防御 += 30;
									break;
								case 3:
									装备追加对怪防御 += 45;
									break;
								case 4:
									装备追加对怪防御 += 60;
									break;
								case 5:
									装备追加对怪防御 += 75;
									break;
								case 6:
									装备追加对怪防御 += 90;
									break;
								case 7:
									装备追加对怪防御 += 105;
									break;
								case 8:
									装备追加对怪防御 += 120;
									break;
								case 9:
									装备追加对怪防御 += 135;
									break;
								case 10:
									装备追加对怪防御 += 150;
									break;
								case 11:
									装备追加对怪防御 += 165;
									break;
								case 12:
									装备追加对怪防御 += 180;
									break;
								case 13:
									装备追加对怪防御 += 195;
									break;
								case 14:
									装备追加对怪防御 += 210;
									break;
								case 15:
									装备追加对怪防御 += 225;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001397 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 10;
									break;
								case 2:
									装备追加对怪防御 += 20;
									break;
								case 3:
									装备追加对怪防御 += 30;
									break;
								case 4:
									装备追加对怪防御 += 40;
									break;
								case 5:
									装备追加对怪防御 += 50;
									break;
								case 6:
									装备追加对怪防御 += 60;
									break;
								case 7:
									装备追加对怪防御 += 70;
									break;
								case 8:
									装备追加对怪防御 += 80;
									break;
								case 9:
									装备追加对怪防御 += 90;
									break;
								case 10:
									装备追加对怪防御 += 100;
									break;
								case 11:
									装备追加对怪防御 += 110;
									break;
								case 12:
									装备追加对怪防御 += 120;
									break;
								case 13:
									装备追加对怪防御 += 130;
									break;
								case 14:
									装备追加对怪防御 += 140;
									break;
								case 15:
									装备追加对怪防御 += 150;
									break;
								}
							}
							if (BitConverter.ToInt32(宝珠装备栏装备[num13].物品ID, 0) == 1000001392 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 1:
									装备追加对怪防御 += 5;
									break;
								case 2:
									装备追加对怪防御 += 10;
									break;
								case 3:
									装备追加对怪防御 += 15;
									break;
								case 4:
									装备追加对怪防御 += 20;
									break;
								case 5:
									装备追加对怪防御 += 25;
									break;
								case 6:
									装备追加对怪防御 += 30;
									break;
								case 7:
									装备追加对怪防御 += 35;
									break;
								case 8:
									装备追加对怪防御 += 40;
									break;
								case 9:
									装备追加对怪防御 += 45;
									break;
								case 10:
									装备追加对怪防御 += 50;
									break;
								case 11:
									装备追加对怪防御 += 55;
									break;
								case 12:
									装备追加对怪防御 += 60;
									break;
								case 13:
									装备追加对怪防御 += 65;
									break;
								case 14:
									装备追加对怪防御 += 70;
									break;
								case 15:
									装备追加对怪防御 += 75;
									break;
								}
							}
							if (BitConverter.ToInt32(辅助装备栏装备[num13].物品ID, 0) == 900000046 && 装备栏已穿装备[num13].FLD_RESIDE2 == 6)
							{
								switch (装备栏已穿装备[num13].FLD_强化数量)
								{
								case 10:
									FLD_装备_追加_HP += 200;
									FLD_装备_追加_攻击 += 200;
									FLD_装备_追加_防御 += 200;
									break;
								case 11:
									FLD_装备_追加_HP += 300;
									FLD_装备_追加_攻击 += 300;
									FLD_装备_追加_防御 += 300;
									break;
								case 12:
									FLD_装备_追加_HP += 400;
									FLD_装备_追加_攻击 += 500;
									FLD_装备_追加_防御 += 500;
									break;
								case 13:
									FLD_装备_追加_HP += 600;
									FLD_装备_追加_攻击 += 600;
									FLD_装备_追加_防御 += 600;
									break;
								case 14:
									FLD_装备_追加_HP += 700;
									FLD_装备_追加_攻击 += 700;
									FLD_装备_追加_防御 += 700;
									break;
								case 15:
									FLD_装备_追加_HP += 800;
									FLD_装备_追加_攻击 += 800;
									FLD_装备_追加_防御 += 800;
									break;
								}
							}
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 115401001)
						{
							num12++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 115402001)
						{
							num32++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 400011)
						{
							num3++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 125401001)
						{
							num5++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 125400001)
						{
							num6++;
						}
						break;
					case 7:
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100015 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100115)
						{
							num37++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100001 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100101)
						{
							num2++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100016 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100116)
						{
							num4++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100002 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100102)
						{
							num7++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100003 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 100103)
						{
							num8++;
						}
						if (药品_追加_首饰_强化 != 0)
						{
							int num28 = 药品_追加_首饰_强化 * 25;
							FLD_装备_追加_防御 += num28;
						}
						break;
					case 8:
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 22 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 122)
						{
							num37++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 21 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 121)
						{
							num2++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 12 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 112)
						{
							num4++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 24 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 124)
						{
							num7++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 19 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 119)
						{
							num8++;
						}
						if (装备栏已穿装备[num13].Get物品ID == 1000500 || ((装备栏已穿装备[num13].Get物品ID == 1020500) ? true : false))
						{
							num14 = num + 1;
							num = num14;
						}
						if (药品_追加_首饰_强化 != 0)
						{
							int num26 = 药品_追加_首饰_强化 * 350;
							FLD_装备_追加_HP += num26;
						}
						break;
					case 10:
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700027 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700127)
						{
							num37++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700026 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700126)
						{
							num2++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700018 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700118)
						{
							num4++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700029 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700129)
						{
							num7++;
						}
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700024 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 700124)
						{
							num8++;
						}
						if (装备栏已穿装备[num13].Get物品ID == 1700500 || ((装备栏已穿装备[num13].Get物品ID == 1720500) ? true : false))
						{
							num14 = num + 1;
							num = num14;
						}
						if (药品_追加_首饰_强化 != 0)
						{
							int num27 = 药品_追加_首饰_强化 * 25;
							FLD_装备_追加_攻击 += num27;
						}
						break;
					case 12:
					case 14:
						FLD_装备_追加_合成成功率百分比 += (double)装备栏已穿装备[num13].物品属性_升级成功率 * 0.01;
						FLD_装备_追加_获得游戏币百分比 += (double)装备栏已穿装备[num13].物品属性_获得金钱增加 * 0.01;
						FLD_装备_追加_经验百分比 += (double)装备栏已穿装备[num13].物品属性_经验获得增加 * 0.01;
						FLD_装备_追加_死亡损失经验减少 += (double)装备栏已穿装备[num13].物品属性_死亡损失经验减少 * 0.01;
						if (装备栏已穿装备[num13].Get物品ID == 26900772 || 装备栏已穿装备[num13].Get物品ID == 16900772 || 装备栏已穿装备[num13].Get物品ID == 26920772 || ((装备栏已穿装备[num13].Get物品ID == 16920772) ? true : false))
						{
							num14 = num + 1;
							num = num14;
						}
						if (装备栏已穿装备[num13].Get物品ID == 900104)
						{
							num36++;
						}
						switch (Player_Job)
						{
						case 1:
							if (装备栏已穿装备[num13].物品属性_追加刀力劈华山 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加刀力劈华山;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀摄魂一击 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加刀摄魂一击;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀连环飞舞 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加刀连环飞舞;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀狂风万破 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加刀狂风万破;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀稳如泰山 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加刀稳如泰山;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀霸气破甲 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加刀霸气破甲;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀真武绝击 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加刀真武绝击;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀四两千斤 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加刀四两千斤;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀暗影绝杀 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加刀暗影绝杀;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀梵音破镜 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加刀梵音破镜;
							}
							if (装备栏已穿装备[num13].物品属性_追加刀流光乱舞 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加刀流光乱舞;
							}
							break;
						case 2:
							if (装备栏已穿装备[num13].物品属性_追加剑长虹贯日 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加剑长虹贯日;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑百变神行 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加剑百变神行;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑连环飞舞 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加剑连环飞舞;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑破天一剑 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加剑破天一剑;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑狂风万破 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加剑狂风万破;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑移花接木 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加剑移花接木;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑怒海狂澜 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加剑怒海狂澜;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑回柳身法 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加剑回柳身法;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑无坚不摧 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加剑无坚不摧;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑乘胜追击 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加剑乘胜追击;
							}
							if (装备栏已穿装备[num13].物品属性_追加剑冲冠一怒 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加剑冲冠一怒;
							}
							break;
						case 3:
							if (装备栏已穿装备[num13].物品属性_追加枪金钟罩气 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加枪金钟罩气;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪运气疗伤 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加枪运气疗伤;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪连环飞舞 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加枪连环飞舞;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪狂风万破 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加枪狂风万破;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪横练太保 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加枪横练太保;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪转守为攻 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加枪转守为攻;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪狂神降世 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加枪狂神降世;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪乾坤挪移 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加枪乾坤挪移;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪末日狂舞 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加枪末日狂舞;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪怒意之吼 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加枪怒意之吼;
							}
							if (装备栏已穿装备[num13].物品属性_追加枪灵甲护身 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加枪灵甲护身;
							}
							break;
						case 4:
							if (装备栏已穿装备[num13].物品属性_追加弓百步穿杨 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加弓百步穿杨;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓猎鹰之眼 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加弓猎鹰之眼;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓凝神聚气 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加弓凝神聚气;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓狂风万破 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加弓狂风万破;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓正本培元 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加弓正本培元;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓锐利之箭 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加弓锐利之箭;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓心神凝聚 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加弓心神凝聚;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓流星三矢 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加弓流星三矢;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓回流真气 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加弓回流真气;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓无明暗矢 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加弓无明暗矢;
							}
							if (装备栏已穿装备[num13].物品属性_追加弓致命绝杀 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加弓致命绝杀;
							}
							break;
						case 5:
							if (装备栏已穿装备[num13].物品属性_追加医运气行心 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加医运气行心;
							}
							if (装备栏已穿装备[num13].物品属性_追加医太极心法 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加医太极心法;
							}
							if (装备栏已穿装备[num13].物品属性_追加医体血倍增 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加医体血倍增;
							}
							if (装备栏已穿装备[num13].物品属性_追加医洗髓易经 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加医洗髓易经;
							}
							if (装备栏已穿装备[num13].物品属性_追加医妙手回春 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加医妙手回春;
							}
							if (装备栏已穿装备[num13].物品属性_追加医长功攻击 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加医长功攻击;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加医真武绝击 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加医真武绝击;
							}
							if (装备栏已穿装备[num13].物品属性_追加医吸星大法 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加医吸星大法;
							}
							if (装备栏已穿装备[num13].物品属性_追加医狂意护体 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加医狂意护体;
							}
							if (装备栏已穿装备[num13].物品属性_追加医无中生有 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加医无中生有;
							}
							if (装备栏已穿装备[num13].物品属性_追加医九天真气 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加医九天真气;
							}
							break;
						case 6:
							if (装备栏已穿装备[num13].物品属性_追加刺荆轲之怒 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加刺荆轲之怒;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺三花聚顶 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加刺三花聚顶;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺连环飞舞 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加刺连环飞舞;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺心神凝聚 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加刺心神凝聚;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺致手绝命 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加刺致手绝命;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺以怒还怒 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加刺以怒还怒;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺先发制人 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加刺先发制人;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺千株万手 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加刺千株万手;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺连消带打 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加刺连消带打;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺剑刃乱舞 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加刺剑刃乱舞;
							}
							if (装备栏已穿装备[num13].物品属性_追加刺一招残杀 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加刺一招残杀;
							}
							break;
						case 7:
							if (装备栏已穿装备[num13].物品属性_追加琴战马奔腾 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加琴战马奔腾;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴秋江夜泊 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加琴秋江夜泊;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴清心普善 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加琴清心普善;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴阳关三叠 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加琴阳关三叠;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴汉宫秋月 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加琴汉宫秋月;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴高山流水 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加琴高山流水;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴岳阳三醉 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加琴岳阳三醉;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴梅花三弄 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加琴梅花三弄;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴鸾凤和鸣 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加琴鸾凤和鸣;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴阳明春晓 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加琴阳明春晓;
							}
							if (装备栏已穿装备[num13].物品属性_追加琴潇湘雨夜 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加琴潇湘雨夜;
							}
							break;
						case 8:
							if (装备栏已穿装备[num13].物品属性_追加韩力劈华山 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加韩力劈华山;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩摄魂一击 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加韩摄魂一击;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩百变神行 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加韩百变神行;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩狂风万破 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加韩狂风万破;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩天魔狂血 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加韩天魔狂血;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩追骨吸元 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加韩追骨吸元;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩霸气破甲 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加韩霸气破甲;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩真武绝击 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加韩真武绝击;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩火龙问鼎 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加韩火龙问鼎;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩流光乱舞 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加韩流光乱舞;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩暗影绝杀 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加韩暗影绝杀;
							}
							break;
						case 9:
							if (装备栏已穿装备[num13].物品属性_追加谭长虹贯日 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_追加谭长虹贯日;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭百变神行 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_追加谭百变神行;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭新_连环飞舞 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_追加谭新_连环飞舞;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭招式新法 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_追加谭招式新法;
							}
							if (装备栏已穿装备[num13].物品属性_追加韩狂风万破 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_追加韩狂风万破;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭护身罡气 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_追加谭护身罡气;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭移花接木 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_追加谭移花接木;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭纵横无双 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_追加谭纵横无双;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭回柳身法 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_追加谭回柳身法;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭怒海狂澜 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_追加谭怒海狂澜;
							}
							if (装备栏已穿装备[num13].物品属性_追加谭冲冠一怒 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_追加谭冲冠一怒;
							}
							break;
						case 10:
							if (装备栏已穿装备[num13].物品属性_拳师狂神降世 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_拳师狂神降世;
							}
							if (装备栏已穿装备[num13].物品属性_拳师运气疗伤 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_拳师运气疗伤;
							}
							if (装备栏已穿装备[num13].物品属性_拳师力劈华山 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_拳师力劈华山;
							}
							if (装备栏已穿装备[num13].物品属性_拳师狂风万破 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_拳师狂风万破;
							}
							if (装备栏已穿装备[num13].物品属性_拳师灵甲护身 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_拳师灵甲护身;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_拳师磨杵成针 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_拳师磨杵成针;
							}
							if (装备栏已穿装备[num13].物品属性_拳师水火一体 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_拳师水火一体;
							}
							if (装备栏已穿装备[num13].物品属性_拳师金刚不坏 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_拳师金刚不坏;
							}
							if (装备栏已穿装备[num13].物品属性_拳师转攻为守 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_拳师转攻为守;
							}
							if (装备栏已穿装备[num13].物品属性_拳师会心一击 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_拳师会心一击;
							}
							if (装备栏已穿装备[num13].物品属性_拳师末日狂舞 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_拳师末日狂舞;
							}
							break;
						case 11:
							if (装备栏已穿装备[num13].物品属性_梅障力激活 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_梅障力激活;
							}
							if (装备栏已穿装备[num13].物品属性_梅障力运用 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_梅障力运用;
							}
							if (装备栏已穿装备[num13].物品属性_梅百变神行 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_梅百变神行;
							}
							if (装备栏已穿装备[num13].物品属性_梅玄武神功 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_梅玄武神功;
							}
							if (装备栏已穿装备[num13].物品属性_梅玄武的指点 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_梅玄武的指点;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_梅玄武强击 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_梅玄武强击;
							}
							if (装备栏已穿装备[num13].物品属性_梅玄武危化 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_梅玄武危化;
							}
							if (装备栏已穿装备[num13].物品属性_梅障力恢复 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_梅障力恢复;
							}
							if (装备栏已穿装备[num13].物品属性_梅嫉妒的化身 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_梅嫉妒的化身;
							}
							if (装备栏已穿装备[num13].物品属性_梅愤怒爆发 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_梅愤怒爆发;
							}
							if (装备栏已穿装备[num13].物品属性_梅吸血进击 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_梅吸血进击;
							}
							break;
						case 12:
							if (装备栏已穿装备[num13].物品属性_卢金钟罡气 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_卢金钟罡气;
							}
							if (装备栏已穿装备[num13].物品属性_卢运气疗伤 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_卢运气疗伤;
							}
							if (装备栏已穿装备[num13].物品属性_卢连环飞舞 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_卢连环飞舞;
							}
							if (装备栏已穿装备[num13].物品属性_卢横练太保 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_卢横练太保;
							}
							if (装备栏已穿装备[num13].物品属性_卢狂风万破 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_卢狂风万破;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_卢真武绝击 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_卢真武绝击;
							}
							if (装备栏已穿装备[num13].物品属性_卢流星漫天 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_卢流星漫天;
							}
							if (装备栏已穿装备[num13].物品属性_卢乾坤挪移 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_卢乾坤挪移;
							}
							if (装备栏已穿装备[num13].物品属性_卢转攻为守 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_卢转攻为守;
							}
							if (装备栏已穿装备[num13].物品属性_卢弱点击破 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_卢弱点击破;
							}
							if (装备栏已穿装备[num13].物品属性_卢牢不可破 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_卢牢不可破;
							}
							break;
						case 13:
							if (装备栏已穿装备[num13].物品属性_神女运气行心 != 0)
							{
								FLD_装备_追加_气功_0 += 装备栏已穿装备[num13].物品属性_神女运气行心;
							}
							if (装备栏已穿装备[num13].物品属性_神女太极心法 != 0)
							{
								FLD_装备_追加_气功_1 += 装备栏已穿装备[num13].物品属性_神女太极心法;
							}
							if (装备栏已穿装备[num13].物品属性_神女神力激发 != 0)
							{
								FLD_装备_追加_气功_2 += 装备栏已穿装备[num13].物品属性_神女神力激发;
							}
							if (装备栏已穿装备[num13].物品属性_神女杀星义气 != 0)
							{
								FLD_装备_追加_气功_3 += 装备栏已穿装备[num13].物品属性_神女杀星义气;
							}
							if (装备栏已穿装备[num13].物品属性_神女洗髓易筋 != 0)
							{
								FLD_装备_追加_气功_4 += 装备栏已穿装备[num13].物品属性_神女洗髓易筋;
							}
							if (装备栏已穿装备[num13].物品属性_追加气沉丹田 != 0)
							{
								FLD_装备_追加_气功_5 += 装备栏已穿装备[num13].物品属性_追加气沉丹田;
							}
							if (装备栏已穿装备[num13].物品属性_神女黑花漫开 != 0)
							{
								FLD_装备_追加_气功_6 += 装备栏已穿装备[num13].物品属性_神女黑花漫开;
							}
							if (装备栏已穿装备[num13].物品属性_神女妙手回春 != 0)
							{
								FLD_装备_追加_气功_7 += 装备栏已穿装备[num13].物品属性_神女妙手回春;
							}
							if (装备栏已穿装备[num13].物品属性_神女长功击力 != 0)
							{
								FLD_装备_追加_气功_8 += 装备栏已穿装备[num13].物品属性_神女长功击力;
							}
							if (装备栏已穿装备[num13].物品属性_神女黑花集中 != 0)
							{
								FLD_装备_追加_气功_9 += 装备栏已穿装备[num13].物品属性_神女黑花集中;
							}
							if (装备栏已穿装备[num13].物品属性_神女真武绝击 != 0)
							{
								FLD_装备_追加_气功_10 += 装备栏已穿装备[num13].物品属性_神女真武绝击;
							}
							if (装备栏已穿装备[num13].物品属性_神女万毒不侵 != 0)
							{
								FLD_装备_追加_气功_11 += 装备栏已穿装备[num13].物品属性_神女万毒不侵;
							}
							break;
						}
						if (Player_Job_leve < 6)
						{
							break;
						}
						foreach (升天气功类 value2 in 升天气功.Values)
						{
							if (value2.气功量 > 0)
							{
								switch (value2.气功ID)
								{
								case 13:
									FLD_装备_追加_升天三火龙之火 += 装备栏已穿装备[num13].物品属性_追加升天三火龙之火;
									break;
								case 25:
									FLD_装备_追加_升天一护身罡气 += 装备栏已穿装备[num13].物品属性_追加升天一护身罡气;
									break;
								case 33:
									FLD_装备_追加_升天三怒意之火 += 装备栏已穿装备[num13].物品属性_追加升天三怒意之火;
									break;
								case 58:
									FLD_装备_追加_升天一护身气甲 += 装备栏已穿装备[num13].物品属性_追加升天一护身气甲;
									break;
								case 150:
									FLD_装备_追加_升天二万物回春 += 装备栏已穿装备[num13].物品属性_追加升天二万物回春;
									break;
								case 170:
									FLD_装备_追加_升天三无情打击 += 装备栏已穿装备[num13].物品属性_追加升天三无情打击;
									break;
								case 310:
									FLD_装备_追加_升天一遁出逆境 += 装备栏已穿装备[num13].物品属性_追加升天一遁出逆境;
									break;
								case 311:
									FLD_装备_追加_升天二穷途末路 += 装备栏已穿装备[num13].物品属性_追加升天二穷途末路;
									break;
								case 313:
								case 323:
								case 333:
								case 564:
								case 666:
									FLD_装备_追加_升天四红月狂风 += 装备栏已穿装备[num13].物品属性_追加升天四红月狂风;
									break;
								case 314:
								case 324:
								case 334:
								case 565:
								case 665:
									FLD_装备_追加_升天四毒蛇出洞 += 装备栏已穿装备[num13].物品属性_追加升天四毒蛇出洞;
									break;
								case 321:
									FLD_装备_追加_升天二天地同寿 += 装备栏已穿装备[num13].物品属性_追加升天二天地同寿;
									break;
								case 322:
									FLD_装备_追加_升天三火凤临朝 += 装备栏已穿装备[num13].物品属性_追加升天三火凤临朝;
									break;
								case 330:
									FLD_装备_追加_升天一破甲刺魂 += 装备栏已穿装备[num13].物品属性_追加升天一破甲刺魂;
									break;
								case 331:
									FLD_装备_追加_升天二以退为进 += 装备栏已穿装备[num13].物品属性_追加升天二以退为进;
									break;
								case 340:
									FLD_装备_追加_升天一绝影射魂 += 装备栏已穿装备[num13].物品属性_追加升天一绝影射魂;
									break;
								case 341:
									FLD_装备_追加_升天二千钧压驼 += 装备栏已穿装备[num13].物品属性_追加升天二千钧压驼;
									break;
								case 342:
									FLD_装备_追加_升天三天外三矢 += 装备栏已穿装备[num13].物品属性_追加升天三天外三矢;
									break;
								case 327:
								case 343:
								case 353:
								case 373:
								case 393:
								case 613:
									FLD_装备_追加_升天四满月狂风 += 装备栏已穿装备[num13].物品属性_追加升天四满月狂风;
									break;
								case 326:
								case 344:
								case 374:
									FLD_装备_追加_升天四烈日炎炎 += 装备栏已穿装备[num13].物品属性_追加升天四烈日炎炎;
									break;
								case 352:
									FLD_装备_追加_升天三明镜止水 += 装备栏已穿装备[num13].物品属性_追加升天三明镜止水;
									break;
								case 354:
								case 614:
									FLD_装备_追加_升天四望梅添花 += 装备栏已穿装备[num13].物品属性_追加升天四望梅添花;
									break;
								case 370:
									FLD_装备_追加_升天一夜魔缠身 += 装备栏已穿装备[num13].物品属性_追加升天一夜魔缠身;
									break;
								case 371:
									FLD_装备_追加_升天二顺水推舟 += 装备栏已穿装备[num13].物品属性_追加升天二顺水推舟;
									break;
								case 380:
									FLD_装备_追加_升天一力劈华山 += 装备栏已穿装备[num13].物品属性_追加升天一力劈华山;
									break;
								case 381:
									FLD_装备_追加_升天一长虹贯日 += 装备栏已穿装备[num13].物品属性_追加升天一长虹贯日;
									break;
								case 382:
									FLD_装备_追加_升天一金钟罡气 += 装备栏已穿装备[num13].物品属性_追加升天一金钟罡气;
									break;
								case 383:
									FLD_装备_追加_升天一运气行心 += 装备栏已穿装备[num13].物品属性_追加升天一运气行心;
									break;
								case 384:
									FLD_装备_追加_升天一正本培源 += 装备栏已穿装备[num13].物品属性_追加升天一正本培源;
									break;
								case 385:
									FLD_装备_追加_升天一运气疗伤 += 装备栏已穿装备[num13].物品属性_追加升天一运气疗伤;
									break;
								case 386:
								case 653:
									FLD_装备_追加_升天一百变神行 += 装备栏已穿装备[num13].物品属性_追加升天一百变神行;
									break;
								case 387:
									FLD_装备_追加_升天一狂风天意 += 装备栏已穿装备[num13].物品属性_追加升天一狂风天意;
									break;
								case 390:
									FLD_装备_追加_升天一飞花点翠 += 装备栏已穿装备[num13].物品属性_追加升天一飞花点翠;
									break;
								case 391:
									FLD_装备_追加_升天二三潭映月 += 装备栏已穿装备[num13].物品属性_追加升天二三潭映月;
									break;
								case 392:
									FLD_装备_追加_升天三子夜秋歌 += 装备栏已穿装备[num13].物品属性_追加升天三子夜秋歌;
									break;
								case 394:
									FLD_装备_追加_升天四悬丝诊脉 += 装备栏已穿装备[num13].物品属性_追加升天四悬丝诊脉;
									break;
								case 561:
									FLD_装备_追加_升天一夺命连环 += 装备栏已穿装备[num13].物品属性_追加升天夺命连环;
									break;
								case 562:
									FLD_装备_追加_升天一电光石火 += 装备栏已穿装备[num13].物品属性_追加升天电光石火;
									break;
								case 563:
									FLD_装备_追加_升天一精益求精 += 装备栏已穿装备[num13].物品属性_追加升天精益求精;
									break;
								case 600:
									FLD_装备_追加_升天一行风弄舞 += 装备栏已穿装备[num13].物品属性_追加升天一行风弄舞;
									break;
								case 601:
									FLD_装备_追加_升天二天魔护体 += 装备栏已穿装备[num13].物品属性_追加升天二天魔护体;
									break;
								case 602:
									FLD_装备_追加_升天三内息行心 += 装备栏已穿装备[num13].物品属性_追加升天三内息行心;
									break;
								case 603:
								case 701:
									FLD_装备_追加_升天四长虹贯天 += 装备栏已穿装备[num13].物品属性_追加升天四长虹贯天;
									break;
								case 604:
								case 702:
									FLD_装备_追加_升天四哀鸿遍野 += 装备栏已穿装备[num13].物品属性_追加升天四哀鸿遍野;
									break;
								case 700:
									FLD_装备_追加_升天三以柔克刚 += 装备栏已穿装备[num13].物品属性_追加升天三以柔克刚;
									break;
								case 680:
									FLD_装备_追加_升天五惊天动地 += 装备栏已穿装备[num13].物品属性_追加升天五惊天动地;
									break;
								case 316:
									FLD_装备_追加_升天一玄武雷电 += 装备栏已穿装备[num13].物品属性_追加升天一玄武雷电;
									break;
								case 662:
									FLD_装备_追加_升天一陵劲淬砺 += 装备栏已穿装备[num13].物品属性_追加升天一陵劲淬砺;
									break;
								case 610:
									FLD_装备_追加_升天一愤怒调节 += 装备栏已穿装备[num13].物品属性_追加升天一愤怒调节;
									break;
								case 325:
									FLD_装备_追加_升天二玄武诅咒 += 装备栏已穿装备[num13].物品属性_追加升天二玄武诅咒;
									break;
								case 663:
									FLD_装备_追加_升天二杀星光符 += 装备栏已穿装备[num13].物品属性_追加升天二杀星光符;
									break;
								case 611:
									FLD_装备_追加_升天二蛊毒解除 += 装备栏已穿装备[num13].物品属性_追加升天二蛊毒解除;
									break;
								case 315:
									FLD_装备_追加_升天三杀人鬼 += 装备栏已穿装备[num13].物品属性_追加升天三杀人鬼;
									break;
								case 664:
									FLD_装备_追加_升天三技冠群雄 += 装备栏已穿装备[num13].物品属性_追加升天三技冠群雄;
									break;
								case 612:
									FLD_装备_追加_升天三神力保护 += 装备栏已穿装备[num13].物品属性_追加升天三神力保护;
									break;
								case 615:
								case 667:
								case 668:
								case 669:
								case 670:
								case 671:
								case 672:
								case 673:
								case 674:
								case 675:
								case 676:
								case 677:
								case 678:
									FLD_装备_追加_升天五致残 += 装备栏已穿装备[num13].物品属性_追加升天五致残;
									break;
								case 679:
									FLD_装备_追加_升天五龙魂附体 += 装备栏已穿装备[num13].物品属性_追加升天五龙魂附体;
									break;
								case 681:
									FLD_装备_追加_升天五灭世狂舞 += 装备栏已穿装备[num13].物品属性_追加升天五灭世狂舞;
									break;
								case 682:
									FLD_装备_追加_升天五千里一击 += 装备栏已穿装备[num13].物品属性_追加升天五千里一击;
									break;
								case 683:
									FLD_装备_追加_升天五形移妖相 += 装备栏已穿装备[num13].物品属性_追加升天五形移妖相;
									break;
								case 684:
									FLD_装备_追加_升天五一招杀神 += 装备栏已穿装备[num13].物品属性_追加升天五一招杀神;
									break;
								case 685:
									FLD_装备_追加_升天五龙爪纤指手 += 装备栏已穿装备[num13].物品属性_追加升天五龙爪纤指手;
									break;
								case 688:
									FLD_装备_追加_升天五不死之躯 += 装备栏已穿装备[num13].物品属性_追加升天五不死之躯;
									break;
								case 686:
									FLD_装备_追加_升天五天魔之力 += 装备栏已穿装备[num13].物品属性_追加升天五天魔之力;
									break;
								case 687:
									FLD_装备_追加_升天五惊涛骇浪 += 装备栏已穿装备[num13].物品属性_追加升天五惊涛骇浪;
									break;
								case 689:
									FLD_装备_追加_升天五魔魂之力 += 装备栏已穿装备[num13].物品属性_追加升天五魔魂之力;
									break;
								case 690:
									FLD_装备_追加_升天五破空坠星 += 装备栏已穿装备[num13].物品属性_追加升天五破空坠星;
									break;
								case 616:
									FLD_装备_追加_升天五尸毒爆发 += 装备栏已穿装备[num13].物品属性_追加升天五尸毒爆发;
									break;
								}
							}
						}
						break;
					case 13:
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1900001 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1900002 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1900003 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1900004)
						{
							num33++;
						}
						break;
					case 15:
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000001385 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000001384 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000001383 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000001382 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000002006 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000002001 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000002002 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000002003 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000002004 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000002005)
						{
							num34++;
						}
						break;
					case 16:
						if (BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000001304 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000001303 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000001302 || BitConverter.ToInt32(装备栏已穿装备[num13].物品ID, 0) == 1000001301)
						{
							num35++;
						}
						break;
					case 26:
						计算花珠增加属性(装备栏已穿装备[num13]);
						break;
					}
				}
				if (num == 3)
				{
					FLD_装备_追加_HP += 80;
					FLD_装备_追加_攻击 += 10;
					FLD_装备_武功攻击力增加百分比 += 0.09;
				}
				if (num23 >= 2)
				{
					switch (Player_Job)
					{
					case 1:
						switch (num23)
						{
						case 4:
							FLD_装备_追加_防御 += 40;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							break;
						case 5:
							FLD_装备_追加_防御 += 40;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							FLD_装备_追加_HP += 500;
							break;
						case 6:
							FLD_装备_追加_防御 += 40;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							FLD_装备_追加_HP += 500;
							FLD_装备_追加_攻击 += 50;
							break;
						}
						break;
					case 2:
					case 3:
						switch (num23)
						{
						case 4:
							FLD_装备_追加_防御 += 40;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							break;
						case 5:
							FLD_装备_追加_防御 += 40;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							FLD_装备_追加_HP += 500;
							break;
						case 6:
							FLD_装备_追加_防御 += 90;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							FLD_装备_追加_HP += 500;
							break;
						}
						break;
					case 4:
						switch (num23)
						{
						case 4:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							break;
						case 5:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							FLD_装备_追加_HP += 500;
							break;
						case 6:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							FLD_装备_追加_HP += 500;
							FLD_装备_武功攻击力增加百分比 += 0.2;
							break;
						}
						break;
					case 5:
						switch (num23)
						{
						case 4:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							break;
						case 5:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							FLD_装备_追加_HP += 500;
							FLD_装备_追加_MP += 1000;
							break;
						case 6:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_HP += 500;
							FLD_装备_追加_MP += 1000;
							FLD_装备_追加_攻击 += 60;
							break;
						}
						break;
					case 6:
						switch (num23)
						{
						case 4:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							break;
						case 5:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							FLD_装备_追加_HP += 500;
							break;
						case 6:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							FLD_装备_追加_HP += 500;
							FLD_装备_武功攻击力增加百分比 += 0.2;
							break;
						}
						break;
					case 7:
						switch (num23)
						{
						case 4:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							break;
						case 5:
							FLD_装备_追加_防御 += 40;
							FLD_装备_追加_攻击 += 10;
							FLD_装备_追加_HP += 500;
							FLD_装备_追加_MP += 1000;
							break;
						case 6:
							FLD_装备_追加_防御 += 90;
							FLD_装备_追加_攻击 += 10;
							FLD_装备_追加_HP += 500;
							FLD_装备_追加_MP += 1000;
							break;
						}
						break;
					case 8:
						switch (num23)
						{
						case 4:
							FLD_装备_追加_防御 += 40;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							break;
						case 5:
							FLD_装备_追加_防御 += 40;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							FLD_装备_追加_HP += 500;
							break;
						case 6:
							FLD_装备_追加_防御 += 40;
							FLD_装备_武功攻击力增加百分比 += 0.1;
							FLD_装备_追加_HP += 500;
							FLD_装备_追加_攻击 += 50;
							break;
						}
						break;
					}
				}
				PVP装备加成();
			}
			更新气功();
			披风收录加成();
			计算花珠增加属性(装备栏已穿装备[16]);
			更新宝珠属性显示();
		}

		public void 更新宝珠属性显示()
		{
			string hex = "AA55DE0042011205D80001002100000009000D0000000000000000000000000000001F000000000000000000000000002300000009000D00000000000000000000000000000016000000000000000000000000002300000009000D00000000000000000000000000000016000000000000000000000000002000000009000D00000000000000000000002300000000000000000000000000000000002400000009000D00000000000000000000000000000016000000000000000000000000002200000009000D00000000000000000000000000000016000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			for (int i = 0; i < 宝珠装备栏装备.Length; i++)
			{
				int num = 0;
				int value = 0;
				int num2 = 0;
				int value2 = 0;
				int value3 = 0;
				物品类 物品类2 = 宝珠装备栏装备[i];
				物品类 物品类3 = 装备栏已穿装备[i];
				if (物品类2 == null || 物品类2.Get物品ID <= 0)
				{
					continue;
				}
				num = 装备栏已穿装备[i].FLD_强化数量;
				switch (物品类2.FLD_RESIDE2)
				{
				case 32:
					if (物品类2.Get物品ID != 0L && 物品类3.Get物品ID != 0)
					{
						ItmeClass itmeID2 = ItmeClass.GetItmeID((int)物品类2.Get物品ID);
						value = num * 5 * (itmeID2.FLD_UP_LEVEL + 1);
					}
					break;
				case 33:
					if (物品类2.Get物品ID != 0)
					{
						ItmeClass itmeID5 = ItmeClass.GetItmeID((int)物品类2.Get物品ID);
						if (物品类3.Get物品ID != 0)
						{
							num2 = num * 5 * (itmeID5.FLD_UP_LEVEL + 1);
						}
					}
					break;
				case 34:
					if (物品类2.Get物品ID != 0)
					{
						ItmeClass itmeID3 = ItmeClass.GetItmeID((int)物品类2.Get物品ID);
						if (物品类3.Get物品ID != 0)
						{
							num2 += num * 5 * (itmeID3.FLD_UP_LEVEL + 1);
						}
					}
					break;
				case 35:
					if (物品类2.Get物品ID != 0)
					{
						ItmeClass itmeID4 = ItmeClass.GetItmeID((int)物品类2.Get物品ID);
						if (物品类3.Get物品ID != 0)
						{
							num2 += num * 5 * (itmeID4.FLD_UP_LEVEL + 1);
						}
					}
					break;
				case 36:
					if (物品类2.Get物品ID != 0)
					{
						ItmeClass itmeID = ItmeClass.GetItmeID((int)物品类2.Get物品ID);
						if (物品类3.Get物品ID != 0)
						{
							num2 += num * 5 * (itmeID.FLD_UP_LEVEL + 1);
						}
					}
					break;
				}
				Buffer.BlockCopy(BitConverter.GetBytes(物品类2.FLD_RESIDE2), 0, array, 12 + i * 36, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, array, 18 + i * 36, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(value2), 0, array, 22 + i * 36, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, array, 30 + i * 36, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(num2), 0, array, 34 + i * 36, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(value3), 0, array, 38 + i * 36, 2);
			}
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send多包(array, array.Length);
			}
		}

		public void 计算人物制作等级()
		{
			int fLD_制作等级 = FLD_制作等级;
			FLD_制作等级 = ((FLD_制作熟练度 >= 800) ? 8 : ((FLD_制作熟练度 >= 700) ? 7 : ((FLD_制作熟练度 >= 600) ? 6 : ((FLD_制作熟练度 >= 500) ? 5 : ((FLD_制作熟练度 >= 400) ? 4 : ((FLD_制作熟练度 >= 300) ? 3 : ((FLD_制作熟练度 < 100) ? 1 : 2)))))));
			if (FLD_制作等级 > fLD_制作等级)
			{
				更新制作系统();
			}
		}

		public void 计算人物基本数据3()
		{
			int player_Level = Player_Level;
			int num = Player_Level;
			long 人物经验 = this.人物经验;
			long num2 = 人物最大经验;
			人物最大经验 = (long)World.lever[Player_Level];
			int num3 = 0;
			while (Player_Level < World.限制最高级别)
			{
				if (人物经验 < num2)
				{
					if ((double)(this.人物经验 - Convert.ToInt64(World.lever[Player_Level - 1])) < 1.0)
					{
						this.人物经验 = Convert.ToInt64(World.lever[Player_Level - 1]);
						num--;
					}
					break;
				}
				if (num3 > 270 || !Client.Running)
				{
					return;
				}
				num++;
				num2 = (long)World.lever[num];
				num3++;
			}
			if (num - player_Level != 0)
			{
				计算人物基本数据();
				Players players = World.检查玩家世界ID(人物全服ID);
				if (players != null)
				{
					players.更新HP_MP_SP();
					players.更新武功和状态();
				}
				保存帮派数据();
			}
		}

		public void 计算人物基本数据()
		{
			if (Player_Level > World.限制最高级别)
			{
				Player_Level = World.限制最高级别;
			}
			人物最大经验 = (long)World.lever[Player_Level];
			int player_Level = Player_Level;
			while (Player_Level < World.限制最高级别)
			{
				if (Client == null || !Client.Running)
				{
					return;
				}
				if (人物经验 >= 人物最大经验)
				{
					Player_Level++;
					人物最大经验 = (long)World.lever[Player_Level];
					if (World.是否开启等级奖励 != 1)
					{
						continue;
					}
					foreach (等级奖励类 value in World.等级奖励.Values)
					{
						if (Player_Level == value.等级)
						{
							Players players = World.检查玩家世界ID(人物全服ID);
							if (转生次数 >= 1)
							{
								系统提示("转生后不能领取等级奖励", 20, "系统提示");
							}
							else
							{
								players?.冲级奖励();
							}
						}
					}
					continue;
				}
				if (死亡掉经验 && Player_Level != 1 && (double)(人物经验 - Convert.ToInt64(World.lever[Player_Level - 1])) < 1.0)
				{
					Player_Level--;
					人物最大经验 = (long)World.lever[Player_Level];
					死亡掉经验 = false;
				}
				break;
			}
			if (Player_Level - player_Level > 0)
			{
				升级后的提示(1);
				int num = Player_Level - player_Level;
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						if (Player_Level > 120)
						{
							Player_Qigong_point += 3;
						}
						else if (Player_Level > 35)
						{
							Player_Qigong_point += 2;
						}
						else
						{
							Player_Qigong_point++;
						}
					}
				}
			}
			else if (Player_Level - player_Level < 0)
			{
				int num12 = player_Level - Player_Level;
				if (num12 > 0)
				{
					for (int j = 0; j < num12; j++)
					{
						if (Player_Level > 120)
						{
							if (Player_Qigong_point >= 3)
							{
								Player_Qigong_point -= 3;
								continue;
							}
							for (int k = 0; k < 12; k++)
							{
								if (气功[k].气功量 >= 3)
								{
									气功[k].气功量 -= 3;
									初始化气功();
									break;
								}
							}
							continue;
						}
						if (Player_Level > 35)
						{
							if (Player_Qigong_point >= 2)
							{
								Player_Qigong_point -= 2;
								continue;
							}
							for (int l = 0; l < 12; l++)
							{
								if (气功[l].气功量 >= 2)
								{
									气功[l].气功量 -= 2;
									初始化气功();
									break;
								}
							}
							continue;
						}
						if (Player_Qigong_point >= 1)
						{
							Player_Qigong_point--;
							continue;
						}
						for (int m = 0; m < 5; m++)
						{
							if (气功[m].气功量 >= 1)
							{
								气功[m].气功量--;
								初始化气功();
								break;
							}
						}
					}
				}
			}
			if (Player_Job == 1 || Player_Job == 2 || Player_Job == 3 || Player_Job == 4 || Player_Job == 8)
			{
				人物最大_SP = 100;
			}
			else
			{
				人物最大_SP = 100 + Player_Level;
			}
			人物最大_SP = 100 + Player_Level * 10;
			人物负重总 = 500 + 20 * Player_Level;
			人物基本最大_HP = 0;
			人物基本最大_MP = 0;
			人物基本最大_障力 = 0;
			FLD_心 = 0;
			FLD_身 = 0;
			FLD_命中 = 0;
			FLD_回避 = 0;
			FLD_力 = 0;
			FLD_体 = 0;
			FLD_最小攻击 = 0;
			FLD_最大攻击 = 0;
			FLD_攻击 = 0;
			FLD_防御 = 0;
			switch (Player_Job)
			{
			case 1:
			{
				int num8 = Player_Level;
				if (Player_Level >= 130)
				{
					num8 += 5;
				}
				人物基本最大_HP = 145 + (num8 - 1) * 12;
				人物基本最大_MP = 116 + (num8 - 1) * 2;
				FLD_攻击 = 8;
				FLD_防御 = 15;
				FLD_命中 = 2 + (int)((double)(num8 - 1) / 2.9 + 0.5);
				FLD_回避 = 4 + (int)((double)(num8 - 1) / 1.9 + 0.5);
				FLD_心 = 8 + (num8 - 1);
				FLD_力 = 8;
				FLD_体 = 15;
				FLD_身 = 9 + (num8 - 1);
				for (int num9 = 2; num9 <= num8; num9++)
				{
					if (num9 % 2 == 0)
					{
						FLD_力++;
						FLD_体++;
						FLD_攻击++;
						FLD_防御++;
					}
					else
					{
						FLD_力 += 2;
						FLD_体 += 2;
						FLD_攻击 += 2;
						FLD_防御 += 2;
					}
				}
				if (Player_Job_leve >= 6 && Player_Level >= 115)
				{
					FLD_命中 += 17;
					FLD_回避 += 27;
					FLD_心 += 50;
					FLD_力 += 76;
					FLD_体 += 77;
					FLD_身 += 54;
				}
				break;
			}
			case 2:
			{
				int num11 = Player_Level;
				if (Player_Level >= 130)
				{
					num11 += 5;
				}
				人物基本最大_HP = 133 + (num11 - 1) * 9;
				人物基本最大_MP = 118;
				FLD_攻击 = 11 + (num11 - 1) * 2;
				FLD_防御 = 11 + num11 - 1;
				FLD_命中 = 2 + (num11 - 1);
				FLD_回避 = 4 + (num11 - 1);
				FLD_心 = 9;
				FLD_力 = 11 + (num11 - 1) * 2;
				FLD_体 = 11 + (num11 - 1);
				FLD_身 = 9 + (num11 - 1) * 2;
				for (int num13 = 2; num13 <= num11; num13++)
				{
					if (num13 % 2 == 0)
					{
						FLD_心++;
						人物基本最大_MP += 2;
					}
					else
					{
						FLD_心 += 2;
						人物基本最大_MP += 4;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 41;
					FLD_回避 += 67;
					FLD_心 += 75;
					FLD_力 += 100;
					FLD_体 += 52;
					FLD_身 += 99;
				}
				break;
			}
			case 3:
			{
				int num7 = Player_Level;
				if (Player_Level >= 130)
				{
					num7 += 5;
				}
				人物基本最大_HP = 133 + (num7 - 1) * 7;
				人物基本最大_MP = 118 + (num7 - 1) * 2;
				FLD_攻击 = 13 + (num7 - 1) * 3;
				FLD_防御 = 11 + (num7 - 1);
				FLD_命中 = 2 + (int)((double)(num7 - 1) / 3.4 + 0.5);
				FLD_回避 = 3 + (int)((double)(num7 - 1) / 2.0 + 0.5);
				FLD_心 = 9 + (num7 - 1);
				FLD_力 = 13 + (num7 - 1) * 3;
				FLD_体 = 11 + (num7 - 1);
				FLD_身 = 7 + (num7 - 1);
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 12;
					FLD_回避 += 27;
					FLD_心 += 51;
					FLD_力 += 147;
					FLD_体 += 52;
					FLD_身 += 53;
				}
				break;
			}
			case 4:
			{
				int num5 = Player_Level;
				if (Player_Level >= 130)
				{
					num5 += 5;
				}
				人物基本最大_HP = 133 + (num5 - 1) * 6;
				人物基本最大_MP = 118 + (num5 - 1) * 4;
				FLD_攻击 = 11;
				FLD_防御 = 9 + (num5 - 1);
				FLD_命中 = 3 + (num5 - 1);
				FLD_回避 = 5;
				FLD_心 = 9 + (num5 - 1) * 2;
				FLD_力 = 11;
				FLD_体 = 9 + (num5 - 1);
				FLD_身 = 11 + (num5 - 1) * 3;
				for (int num6 = 2; num6 <= num5; num6++)
				{
					if (num6 % 2 == 0)
					{
						FLD_回避 += 2;
						FLD_力 += 2;
						FLD_攻击 += 2;
					}
					else
					{
						FLD_回避++;
						FLD_力 += 3;
						FLD_攻击 += 3;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 31;
					FLD_回避 += 71;
					FLD_心 += 99;
					FLD_力 += 118;
					FLD_体 += 49;
					FLD_身 += 143;
				}
				break;
			}
			case 5:
			{
				int num14 = Player_Level;
				if (Player_Level >= 130)
				{
					num14 += 5;
				}
				人物基本最大_HP = 124 + (num14 - 1) * 7;
				人物基本最大_MP = 136;
				FLD_攻击 = 7 + (int)((double)(num14 - 1) * 2.1);
				FLD_防御 = 8 + (num14 - 1);
				FLD_命中 = 2 + (int)((double)num14 / 4.0 + 0.5);
				FLD_回避 = 3 + (int)((double)num14 / 3.0 + 0.5);
				FLD_心 = 18;
				FLD_力 = 7 + (num14 - 1) * 2;
				FLD_体 = 8 + (num14 - 1);
				FLD_身 = 7 + (num14 - 1);
				for (int num15 = 2; num15 <= num14; num15++)
				{
					if (num15 % 2 == 0)
					{
						人物基本最大_MP += 6;
						FLD_心 += 3;
					}
					else
					{
						人物基本最大_MP += 8;
						FLD_心 += 4;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 21;
					FLD_回避 += 46;
					FLD_心 += 169;
					FLD_力 += 96;
					FLD_体 += 48;
					FLD_身 += 53;
				}
				break;
			}
			case 6:
			{
				int num19 = Player_Level;
				if (Player_Level >= 130)
				{
					num19 += 5;
				}
				人物基本最大_HP = 133 + (num19 - 1) * 9;
				人物基本最大_MP = 114;
				FLD_攻击 = 10 + (int)((double)(num19 - 1) * 2.1);
				FLD_防御 = 9 + (num19 - 1);
				FLD_命中 = 4 + (num19 - 1);
				FLD_回避 = 7 + (num19 - 1) * 2;
				FLD_心 = 7 + (num19 - 1) * 2;
				FLD_力 = 10 + (num19 - 1) * 2;
				FLD_体 = 9 + (num19 - 1);
				FLD_身 = 14;
				for (int num20 = 2; num20 <= num19; num20++)
				{
					if (num20 % 2 == 0)
					{
						人物基本最大_MP += 2;
						FLD_身 += 3;
					}
					else
					{
						人物基本最大_MP += 4;
						FLD_身 += 4;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 56;
					FLD_回避 += 83;
					FLD_心 += 99;
					FLD_力 += 102;
					FLD_体 += 51;
					FLD_身 += 168;
				}
				break;
			}
			case 7:
			{
				int num4 = Player_Level;
				if (Player_Level >= 130)
				{
					num4 += 5;
				}
				人物基本最大_HP = ((Player_Level > 2) ? (124 + (num4 - 2) * 6) : 124);
				人物基本最大_MP = 136 + (num4 - 1) * 8;
				FLD_攻击 = 7 + num4 * 2;
				FLD_防御 = ((num4 != 1) ? (7 + (num4 - 2)) : 8);
				FLD_命中 = 2 + (int)((double)(num4 - 1) / 3.5 + 0.5);
				FLD_回避 = 4 + (int)((double)(num4 - 1) / 2.0 + 0.5);
				FLD_心 = 18 + (num4 - 1) * 4;
				FLD_力 = 7 + (num4 - 1) * 2;
				switch (num4)
				{
				default:
					FLD_体 = 8 + (num4 - 3);
					break;
				case 2:
					FLD_体 = 7;
					break;
				case 1:
					FLD_体 = 8;
					break;
				}
				FLD_身 = 7 + (num4 - 1);
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 22;
					FLD_回避 += 46;
					FLD_心 += 191;
					FLD_力 += 101;
					FLD_体 += 50;
					FLD_身 += 53;
				}
				break;
			}
			case 8:
			{
				int num23 = Player_Level;
				if (Player_Level >= 130)
				{
					num23 += 5;
				}
				人物基本最大_HP = 145 + (num23 - 1) * 12;
				人物基本最大_MP = 116 + (num23 - 1) * 2;
				FLD_攻击 = 8;
				FLD_防御 = 15;
				FLD_命中 = 2 + (int)((double)(num23 - 1) / 3.0 + 0.5);
				FLD_回避 = 4 + (int)((double)(num23 - 1) / 3.0 + 0.5);
				FLD_心 = 8 + (num23 - 1);
				FLD_力 = 8;
				FLD_体 = 15;
				FLD_身 = 9 + (num23 - 1);
				for (int num24 = 2; num24 <= num23; num24++)
				{
					if (num24 % 2 == 0)
					{
						FLD_力++;
						FLD_体++;
						FLD_攻击++;
						FLD_防御++;
					}
					else
					{
						FLD_力 += 2;
						FLD_体 += 2;
						FLD_攻击 += 2;
						FLD_防御 += 2;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 18;
					FLD_回避 += 57;
					FLD_心 += 50;
					FLD_力 += 76;
					FLD_体 += 77;
					FLD_身 += 54;
				}
				break;
			}
			case 9:
			{
				int num16 = Player_Level;
				if (Player_Level >= 130)
				{
					num16 += 5;
				}
				人物基本最大_HP = 133 + (num16 - 1) * 9;
				人物基本最大_MP = 118;
				FLD_攻击 = 11 + (num16 - 1) * 2;
				FLD_防御 = 11 + (num16 - 1);
				FLD_命中 = 2;
				FLD_回避 = 4 + (num16 - 1);
				FLD_心 = 9;
				FLD_力 = 11 + (num16 - 1) * 2;
				FLD_体 = 11 + (num16 - 1);
				FLD_身 = 9 + (num16 - 1) * 2;
				for (int num17 = 2; num17 <= num16; num17++)
				{
					if (num17 % 2 == 0)
					{
						人物基本最大_MP += 2;
						FLD_命中++;
						FLD_心++;
					}
					else
					{
						FLD_心 += 2;
						人物基本最大_MP += 4;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 41;
					FLD_回避 += 67;
					FLD_心 += 75;
					FLD_力 += 100;
					FLD_体 += 52;
					FLD_身 += 99;
				}
				break;
			}
			case 10:
			{
				int num21 = Player_Level;
				if (Player_Level >= 130)
				{
					num21 += 5;
				}
				人物基本最大_HP = 145 + (num21 - 1) * 12;
				人物基本最大_MP = 114 + (num21 - 1) * 2;
				FLD_攻击 = 9;
				FLD_防御 = 16 + (num21 - 1) * 2;
				FLD_命中 = 2 + (int)((double)(num21 - 1) / 3.0 + 0.5);
				FLD_回避 = 4 + (int)((double)(num21 - 1) / 2.0 + 0.5);
				FLD_心 = 7 + (num21 - 1);
				FLD_力 = 9;
				FLD_体 = 16 + (num21 - 1) * 2;
				FLD_身 = 8;
				for (int num22 = 2; num22 <= num21; num22++)
				{
					if (num22 % 2 == 0)
					{
						FLD_力++;
						FLD_身++;
						FLD_攻击++;
					}
					else
					{
						FLD_力 += 2;
						FLD_身 += 2;
						FLD_攻击 += 2;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 37;
					FLD_回避 += 67;
					FLD_心 += 50;
					FLD_力 += 75;
					FLD_身 += 74;
				}
				break;
			}
			case 11:
			{
				int num2 = Player_Level;
				if (Player_Level >= 130)
				{
					num2 += 5;
				}
				人物基本最大_HP = 133 + (num2 - 1) * 4;
				人物基本最大_MP = 118 + (num2 - 1) * 3;
				人物基本最大_障力 = 145 + (int)((double)(num2 - 1) * 14.07563 + 0.5);
				FLD_攻击 = 11;
				FLD_防御 = 9 + (num2 - 1);
				FLD_命中 = 3 + (int)((double)(num2 - 1) / 3.0 + 0.5);
				FLD_回避 = 5 + (int)((double)(num2 - 1) / 2.0 + 0.5);
				FLD_心 = 9 + (num2 - 1);
				FLD_力 = 11 + (int)((double)(num2 - 1) / 2.0 + 0.5);
				FLD_体 = 9 + (num2 - 1);
				FLD_身 = 11 + (int)((double)(num2 - 1) / 3.0 + 0.5);
				for (int num3 = 2; num3 <= num2; num3++)
				{
					if (num3 % 2 == 0)
					{
						FLD_攻击++;
					}
					else
					{
						FLD_攻击 += 2;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 12;
					FLD_回避 += 36;
					FLD_心 += 52;
					FLD_力 += 190;
					FLD_体 += 47;
					FLD_身 += 133;
				}
				break;
			}
			case 12:
			{
				int num10 = Player_Level;
				if (Player_Level >= 130)
				{
					num10 += 5;
				}
				人物基本最大_HP = 133 + (num10 - 1) * 7;
				人物基本最大_MP = 118 + (num10 - 1) * 2;
				FLD_攻击 = 13 + (int)((double)(num10 - 1) * 1.5);
				FLD_防御 = 11 + (num10 - 1);
				FLD_命中 = 2 + (int)((double)(num10 - 1) / 3.4 + 0.5);
				FLD_回避 = 3 + (int)((double)(num10 - 1) / 2.0 + 0.5);
				FLD_心 = 9 + (num10 - 1);
				FLD_力 = 13 + (num10 - 1) * 3;
				FLD_体 = 11 + (num10 - 1);
				FLD_身 = 7 + (num10 - 1);
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 12;
					FLD_回避 += 27;
					FLD_心 += 51;
					FLD_力 += 147;
					FLD_体 += 52;
					FLD_身 += 53;
				}
				break;
			}
			case 13:
			{
				int num18 = Player_Level;
				if (Player_Level >= 130)
				{
					num18 += 5;
				}
				人物基本最大_HP = 124 + (num18 - 1) * 7;
				人物基本最大_MP = 136;
				FLD_攻击 = 7 + (int)((double)(num18 - 1) * 1.5);
				FLD_防御 = 8 + (num18 - 1);
				FLD_命中 = 2 + (int)((double)num18 / 4.0 + 0.5);
				FLD_回避 = 3 + (int)((double)num18 / 3.0 + 0.5);
				FLD_心 = 18;
				FLD_力 = 7 + (num18 - 1) * 2;
				FLD_体 = 8 + (num18 - 1);
				FLD_身 = 7 + (num18 - 1);
				for (int n = 2; n <= num18; n++)
				{
					if (n % 2 == 0)
					{
						人物基本最大_MP += 6;
						FLD_心 += 3;
					}
					else
					{
						人物基本最大_MP += 8;
						FLD_心 += 4;
					}
				}
				if (Player_Level >= 115 && Player_Job_leve >= 6)
				{
					FLD_命中 += 21;
					FLD_回避 += 46;
					FLD_心 += 169;
					FLD_力 += 96;
					FLD_体 += 48;
					FLD_身 += 53;
				}
				break;
			}
			}
			FLD_最小攻击 = FLD_攻击;
			switch (Player_Job_leve)
			{
			case 1:
				if (Player_Job == 11)
				{
					FLD_攻击 += 5;
					FLD_防御 += 5;
					人物基本最大_HP += 25;
					人物基本最大_MP += 25;
				}
				else
				{
					FLD_攻击 += 5;
					FLD_防御 += 5;
					人物基本最大_HP += 50;
					人物基本最大_MP += 50;
				}
				break;
			case 2:
				if (Player_Job == 11)
				{
					FLD_攻击 += 15;
					FLD_防御 += 15;
					人物基本最大_HP += 75;
					人物基本最大_MP += 75;
				}
				else
				{
					FLD_攻击 += 15;
					FLD_防御 += 15;
					人物基本最大_HP += 150;
					人物基本最大_MP += 150;
				}
				break;
			case 3:
				if (Player_Job == 11)
				{
					FLD_攻击 += 30;
					FLD_防御 += 30;
					人物基本最大_HP += 175;
					人物基本最大_MP += 175;
				}
				else
				{
					FLD_攻击 += 30;
					FLD_防御 += 30;
					人物基本最大_HP += 350;
					人物基本最大_MP += 350;
				}
				break;
			case 4:
				if (Player_Job == 1)
				{
					FLD_攻击 += 37;
					FLD_防御 += 54;
					人物基本最大_HP += 613;
					人物基本最大_MP += 649;
				}
				else if (Player_Job == 2)
				{
					FLD_攻击 += 40;
					FLD_防御 += 47;
					人物基本最大_HP += 613;
					人物基本最大_MP += 624;
				}
				else if (Player_Job == 3)
				{
					FLD_攻击 += 50;
					FLD_防御 += 50;
					人物基本最大_HP += 650;
					人物基本最大_MP += 650;
				}
				else if (Player_Job == 4)
				{
					FLD_攻击 += 43;
					FLD_防御 += 45;
					人物基本最大_HP += 650;
					人物基本最大_MP += 636;
				}
				else if (Player_Job == 5)
				{
					FLD_攻击 += 35;
					FLD_防御 += 41;
					人物基本最大_HP += 577;
					人物基本最大_MP += 750;
				}
				else if (Player_Job == 6)
				{
					FLD_攻击 += 40;
					FLD_防御 += 42;
					人物基本最大_HP += 577;
					人物基本最大_MP += 745;
				}
				else if (Player_Job == 7)
				{
					FLD_攻击 += 40;
					FLD_防御 += 43;
					人物基本最大_HP += 598;
					人物基本最大_MP += 762;
				}
				else if (Player_Job == 8)
				{
					FLD_攻击 += 37;
					FLD_防御 += 54;
					人物基本最大_HP += 613;
					人物基本最大_MP += 649;
				}
				else if (Player_Job == 9)
				{
					FLD_攻击 += 40;
					FLD_防御 += 47;
					人物基本最大_HP += 613;
					人物基本最大_MP += 624;
				}
				else if (Player_Job == 10)
				{
					FLD_攻击 += 40;
					FLD_防御 += 59;
					人物基本最大_HP += 638;
					人物基本最大_MP += 649;
				}
				else if (Player_Job == 11)
				{
					FLD_攻击 += 37;
					FLD_防御 += 32;
					人物基本最大_HP += 332;
					人物基本最大_MP += 594;
				}
				else if (Player_Job == 12)
				{
					FLD_攻击 += 50;
					FLD_防御 += 50;
					人物基本最大_HP += 650;
					人物基本最大_MP += 650;
				}
				else if (Player_Job == 13)
				{
					FLD_攻击 += 35;
					FLD_防御 += 41;
					人物基本最大_HP += 577;
					人物基本最大_MP += 750;
				}
				break;
			case 5:
				if (Player_Job == 1)
				{
					FLD_攻击 += 70;
					FLD_防御 += 97;
					人物基本最大_HP += 1223;
					人物基本最大_MP += 1177;
				}
				else if (Player_Job == 2)
				{
					FLD_攻击 += 76;
					FLD_防御 += 84;
					人物基本最大_HP += 1223;
					人物基本最大_MP += 1130;
				}
				else if (Player_Job == 3)
				{
					FLD_攻击 += 94;
					FLD_防御 += 90;
					人物基本最大_HP += 1296;
					人物基本最大_MP += 1178;
				}
				else if (Player_Job == 4)
				{
					FLD_攻击 += 81;
					FLD_防御 += 82;
					人物基本最大_HP += 1296;
					人物基本最大_MP += 1152;
				}
				else if (Player_Job == 5)
				{
					FLD_攻击 += 66;
					FLD_防御 += 74;
					人物基本最大_HP += 1150;
					人物基本最大_MP += 1359;
				}
				else if (Player_Job == 6)
				{
					FLD_攻击 += 75;
					FLD_防御 += 75;
					人物基本最大_HP += 1150;
					人物基本最大_MP += 1350;
				}
				else if (Player_Job == 7)
				{
					FLD_攻击 += 76;
					FLD_防御 += 76;
					人物基本最大_HP += 1193;
					人物基本最大_MP += 1380;
				}
				else if (Player_Job == 8)
				{
					FLD_攻击 += 70;
					FLD_防御 += 97;
					人物基本最大_HP += 1223;
					人物基本最大_MP += 1176;
				}
				else if (Player_Job == 9)
				{
					FLD_攻击 += 76;
					FLD_防御 += 84;
					人物基本最大_HP += 1223;
					人物基本最大_MP += 1130;
				}
				else if (Player_Job == 10)
				{
					FLD_攻击 += 76;
					FLD_防御 += 105;
					人物基本最大_HP += 1272;
					人物基本最大_MP += 1177;
				}
				else if (Player_Job == 11)
				{
					FLD_攻击 += 69;
					FLD_防御 += 57;
					人物基本最大_HP += 662;
					人物基本最大_MP += 1076;
				}
				else if (Player_Job == 12)
				{
					FLD_攻击 += 94;
					FLD_防御 += 90;
					人物基本最大_HP += 1296;
					人物基本最大_MP += 1178;
				}
				else if (Player_Job == 13)
				{
					FLD_攻击 += 66;
					FLD_防御 += 74;
					人物基本最大_HP += 1150;
					人物基本最大_MP += 1359;
				}
				break;
			case 6:
				if (Player_Job == 1)
				{
					FLD_攻击 += 207;
					FLD_防御 += 195;
					人物基本最大_HP += 2280;
					人物基本最大_MP += 2411;
				}
				else if (Player_Job == 2)
				{
					FLD_攻击 += 223;
					FLD_防御 += 169;
					人物基本最大_HP += 2280;
					人物基本最大_MP += 2314;
				}
				else if (Player_Job == 3)
				{
					FLD_攻击 += 235;
					FLD_防御 += 180;
					人物基本最大_HP += 2417;
					人物基本最大_MP += 2413;
				}
				else if (Player_Job == 4)
				{
					FLD_攻击 += 238;
					FLD_防御 += 163;
					人物基本最大_HP += 2417;
					人物基本最大_MP += 2361;
				}
				else if (Player_Job == 5)
				{
					FLD_攻击 += 194;
					FLD_防御 += 148;
					人物基本最大_HP += 2144;
					人物基本最大_MP += 2785;
				}
				else if (Player_Job == 6)
				{
					FLD_攻击 += 220;
					FLD_防御 += 150;
					人物基本最大_HP += 2144;
					人物基本最大_MP += 2766;
				}
				else if (Player_Job == 7)
				{
					FLD_攻击 += 222;
					FLD_防御 += 153;
					人物基本最大_HP += 2225;
					人物基本最大_MP += 2827;
				}
				else if (Player_Job == 8)
				{
					FLD_攻击 += 207;
					FLD_防御 += 195;
					人物基本最大_HP += 2280;
					人物基本最大_MP += 2411;
				}
				else if (Player_Job == 9)
				{
					FLD_攻击 += 223;
					FLD_防御 += 169;
					人物基本最大_HP += 2280;
					人物基本最大_MP += 2314;
				}
				else if (Player_Job == 10)
				{
					FLD_攻击 += 223;
					FLD_防御 += 211;
					人物基本最大_HP += 2371;
					人物基本最大_MP += 2411;
				}
				else if (Player_Job == 11)
				{
					FLD_攻击 += 202;
					FLD_防御 += 114;
					人物基本最大_HP += 1234;
					人物基本最大_MP += 2204;
				}
				else if (Player_Job == 12)
				{
					FLD_攻击 += 235;
					FLD_防御 += 180;
					人物基本最大_HP += 2417;
					人物基本最大_MP += 2413;
				}
				else if (Player_Job == 13)
				{
					FLD_攻击 += 194;
					FLD_防御 += 148;
					人物基本最大_HP += 2144;
					人物基本最大_MP += 2785;
				}
				break;
			case 7:
				switch (Player_Job)
				{
				case 1:
					人物基本最大_HP += 2510;
					人物基本最大_MP += 2500;
					FLD_攻击 += 246;
					FLD_防御 += 267;
					break;
				case 2:
					FLD_攻击 += 265;
					FLD_防御 += 232;
					人物基本最大_HP += 2510;
					人物基本最大_MP += 2400;
					break;
				case 3:
					人物基本最大_HP += 2660;
					人物基本最大_MP += 2502;
					FLD_攻击 += 275;
					FLD_防御 += 247;
					break;
				case 4:
					人物基本最大_HP += 2660;
					人物基本最大_MP += 2448;
					FLD_攻击 += 283;
					FLD_防御 += 224;
					break;
				case 5:
					人物基本最大_HP += 2360;
					人物基本最大_MP += 2888;
					FLD_攻击 += 231;
					FLD_防御 += 203;
					break;
				case 6:
					人物基本最大_HP += 2360;
					人物基本最大_MP += 2868;
					FLD_攻击 += 262;
					FLD_防御 += 206;
					break;
				case 7:
					人物基本最大_HP += 2449;
					人物基本最大_MP += 2932;
					FLD_攻击 += 264;
					FLD_防御 += 210;
					break;
				case 8:
					人物基本最大_HP += 2510;
					人物基本最大_MP += 2500;
					FLD_攻击 += 246;
					FLD_防御 += 267;
					break;
				case 9:
					人物基本最大_HP += 2510;
					人物基本最大_MP += 2400;
					FLD_攻击 += 265;
					FLD_防御 += 232;
					break;
				case 10:
					人物基本最大_HP += 2610;
					人物基本最大_MP += 2500;
					FLD_攻击 += 265;
					FLD_防御 += 289;
					break;
				case 11:
					人物基本最大_HP += 1358;
					人物基本最大_MP += 2285;
					FLD_攻击 += 241;
					FLD_防御 += 157;
					break;
				case 12:
					人物基本最大_HP += 2660;
					人物基本最大_MP += 2502;
					FLD_攻击 += 275;
					FLD_防御 += 247;
					break;
				case 13:
					人物基本最大_HP += 2360;
					人物基本最大_MP += 2888;
					FLD_攻击 += 231;
					FLD_防御 += 203;
					break;
				}
				break;
			case 8:
				switch (Player_Job)
				{
				case 1:
					人物基本最大_HP += 3910;
					人物基本最大_MP += 3500;
					FLD_攻击 += 346;
					FLD_防御 += 382;
					break;
				case 2:
					人物基本最大_HP += 3910;
					人物基本最大_MP += 3360;
					FLD_攻击 += 373;
					FLD_防御 += 332;
					break;
				case 3:
					人物基本最大_HP += 4144;
					人物基本最大_MP += 3503;
					FLD_攻击 += 383;
					FLD_防御 += 353;
					break;
				case 4:
					人物基本最大_HP += 4144;
					人物基本最大_MP += 3427;
					FLD_攻击 += 398;
					FLD_防御 += 320;
					break;
				case 5:
					人物基本最大_HP += 3676;
					人物基本最大_MP += 4043;
					FLD_攻击 += 325;
					FLD_防御 += 290;
					break;
				case 6:
					人物基本最大_HP += 3676;
					人物基本最大_MP += 4015;
					FLD_攻击 += 369;
					FLD_防御 += 295;
					break;
				case 7:
					人物基本最大_HP += 3815;
					人物基本最大_MP += 4105;
					FLD_攻击 += 371;
					FLD_防御 += 300;
					break;
				case 8:
					人物基本最大_HP += 3910;
					人物基本最大_MP += 3500;
					FLD_攻击 += 346;
					FLD_防御 += 382;
					break;
				case 9:
					人物基本最大_HP += 3910;
					人物基本最大_MP += 3360;
					FLD_攻击 += 373;
					FLD_防御 += 332;
					break;
				case 10:
					人物基本最大_HP += 4066;
					人物基本最大_MP += 3500;
					FLD_攻击 += 373;
					FLD_防御 += 413;
					break;
				case 11:
					人物基本最大_HP += 2115;
					人物基本最大_MP += 3199;
					FLD_攻击 += 398;
					FLD_防御 += 225;
					break;
				case 12:
					人物基本最大_HP += 4144;
					人物基本最大_MP += 3503;
					FLD_攻击 += 383;
					FLD_防御 += 353;
					break;
				case 13:
					人物基本最大_HP += 3676;
					人物基本最大_MP += 4043;
					FLD_攻击 += 325;
					FLD_防御 += 290;
					break;
				}
				break;
			case 9:
				switch (Player_Job)
				{
				case 1:
					人物基本最大_HP += 6091;
					人物基本最大_MP += 4900;
					FLD_攻击 += 487;
					FLD_防御 += 547;
					break;
				case 2:
					人物基本最大_HP += 6091;
					人物基本最大_MP += 4704;
					FLD_攻击 += 524;
					FLD_防御 += 475;
					break;
				case 3:
					人物基本最大_HP += 6455;
					人物基本最大_MP += 4904;
					FLD_攻击 += 550;
					FLD_防御 += 506;
					break;
				case 4:
					人物基本最大_HP += 6455;
					人物基本最大_MP += 4798;
					FLD_攻击 += 560;
					FLD_防御 += 459;
					break;
				case 5:
					人物基本最大_HP += 5727;
					人物基本最大_MP += 5660;
					FLD_攻击 += 457;
					FLD_防御 += 416;
					break;
				case 6:
					人物基本最大_HP += 5727;
					人物基本最大_MP += 5621;
					FLD_攻击 += 518;
					FLD_防御 += 422;
					break;
				case 7:
					人物基本最大_HP += 5943;
					人物基本最大_MP += 5747;
					FLD_攻击 += 522;
					FLD_防御 += 430;
					break;
				case 8:
					人物基本最大_HP += 6091;
					人物基本最大_MP += 4900;
					FLD_攻击 += 487;
					FLD_防御 += 547;
					break;
				case 9:
					人物基本最大_HP += 6091;
					人物基本最大_MP += 4704;
					FLD_攻击 += 524;
					FLD_防御 += 475;
					break;
				case 10:
					人物基本最大_HP += 6334;
					人物基本最大_MP += 4900;
					FLD_攻击 += 524;
					FLD_防御 += 592;
					break;
				case 11:
					人物基本最大_HP += 3295;
					人物基本最大_MP += 4479;
					FLD_攻击 += 560;
					FLD_防御 += 321;
					break;
				case 12:
					人物基本最大_HP += 6455;
					人物基本最大_MP += 4904;
					FLD_攻击 += 550;
					FLD_防御 += 506;
					break;
				case 13:
					人物基本最大_HP += 5727;
					人物基本最大_MP += 5660;
					FLD_攻击 += 457;
					FLD_防御 += 416;
					break;
				}
				break;
			case 10:
				switch (Player_Job)
				{
				case 1:
					人物基本最大_HP += 9488;
					人物基本最大_MP += 6860;
					FLD_攻击 += 684;
					FLD_防御 += 782;
					break;
				case 2:
					人物基本最大_HP += 9488;
					人物基本最大_MP += 6586;
					FLD_攻击 += 737;
					FLD_防御 += 679;
					break;
				case 3:
					人物基本最大_HP += 10055;
					人物基本最大_MP += 6865;
					FLD_攻击 += 750;
					FLD_防御 += 723;
					break;
				case 4:
					人物基本最大_HP += 10055;
					人物基本最大_MP += 6717;
					FLD_攻击 += 787;
					FLD_防御 += 656;
					break;
				case 5:
					人物基本最大_HP += 8921;
					人物基本最大_MP += 7925;
					FLD_攻击 += 643;
					FLD_防御 += 594;
					break;
				case 6:
					人物基本最大_HP += 8921;
					人物基本最大_MP += 7870;
					FLD_攻击 += 729;
					FLD_防御 += 603;
					break;
				case 7:
					人物基本最大_HP += 9258;
					人物基本最大_MP += 8045;
					FLD_攻击 += 735;
					FLD_防御 += 615;
					break;
				case 8:
					人物基本最大_HP += 9488;
					人物基本最大_MP += 6860;
					FLD_攻击 += 684;
					FLD_防御 += 782;
					break;
				case 9:
					人物基本最大_HP += 9488;
					人物基本最大_MP += 6586;
					FLD_攻击 += 737;
					FLD_防御 += 679;
					break;
				case 10:
					人物基本最大_HP += 9866;
					人物基本最大_MP += 6860;
					FLD_攻击 += 737;
					FLD_防御 += 846;
					break;
				case 11:
					人物基本最大_HP += 5133;
					人物基本最大_MP += 6270;
					FLD_攻击 += 780;
					FLD_防御 += 460;
					break;
				case 12:
					人物基本最大_HP += 10055;
					人物基本最大_MP += 6865;
					FLD_攻击 += 750;
					FLD_防御 += 723;
					break;
				case 13:
					人物基本最大_HP += 8921;
					人物基本最大_MP += 7925;
					FLD_攻击 += 643;
					FLD_防御 += 594;
					break;
				}
				break;
			case 11:
				switch (Player_Job)
				{
				case 1:
					人物基本最大_HP += 13488;
					人物基本最大_MP += 10860;
					FLD_攻击 += 984;
					FLD_防御 += 1082;
					break;
				case 2:
					人物基本最大_HP += 13488;
					人物基本最大_MP += 10586;
					FLD_攻击 += 1037;
					FLD_防御 += 979;
					break;
				case 3:
					人物基本最大_HP += 14055;
					人物基本最大_MP += 10865;
					FLD_攻击 += 1050;
					FLD_防御 += 1023;
					break;
				case 4:
					人物基本最大_HP += 14055;
					人物基本最大_MP += 10717;
					FLD_攻击 += 1087;
					FLD_防御 += 956;
					break;
				case 5:
					人物基本最大_HP += 12921;
					人物基本最大_MP += 11925;
					FLD_攻击 += 943;
					FLD_防御 += 894;
					break;
				case 6:
					人物基本最大_HP += 12921;
					人物基本最大_MP += 11870;
					FLD_攻击 += 1029;
					FLD_防御 += 903;
					break;
				case 7:
					人物基本最大_HP += 13258;
					人物基本最大_MP += 12045;
					FLD_攻击 += 1035;
					FLD_防御 += 915;
					break;
				case 8:
					人物基本最大_HP += 13488;
					人物基本最大_MP += 10860;
					FLD_攻击 += 984;
					FLD_防御 += 1082;
					break;
				case 9:
					人物基本最大_HP += 13488;
					人物基本最大_MP += 10586;
					FLD_攻击 += 1037;
					FLD_防御 += 979;
					break;
				case 10:
					人物基本最大_HP += 13866;
					人物基本最大_MP += 10860;
					FLD_攻击 += 1037;
					FLD_防御 += 1146;
					break;
				case 11:
					人物基本最大_HP += 9133;
					人物基本最大_MP += 10270;
					FLD_攻击 += 1080;
					FLD_防御 += 760;
					break;
				case 12:
					人物基本最大_HP += 14055;
					人物基本最大_MP += 10865;
					FLD_攻击 += 1150;
					FLD_防御 += 1123;
					break;
				case 13:
					人物基本最大_HP += 12921;
					人物基本最大_MP += 11925;
					FLD_攻击 += 943;
					FLD_防御 += 894;
					break;
				}
				break;
			}
			FLD_最大攻击 = FLD_攻击;
			计算人物装备数据();
			计算人物制作等级();
		}

		public void 更新经验和历练()
		{
			double num = Convert.ToInt64(World.lever[Player_Level]) - Convert.ToInt64(World.lever[Player_Level - 1]);
			double num2 = 人物经验 - Convert.ToInt64(World.lever[Player_Level - 1]);
			if (num2 < 1.0)
			{
				人物经验 = Convert.ToInt64(World.lever[Player_Level - 1]);
				num2 = 0.0;
			}
			using 发包类 发包类 = new 发包类();
			if (Player_Level < 105)
			{
				发包类.Write8((long)num2);
				发包类.Write8((long)num);
			}
			else
			{
				发包类.Write8((long)(num2 / 10.0));
				发包类.Write8((long)(num / 10.0));
			}
			发包类.Write4(0);
			if (Player_ExpErience >= 2000000000)
			{
				Player_ExpErience = 2000000000;
			}
			else if (Player_ExpErience <= 0)
			{
				Player_ExpErience = 0;
			}
			发包类.Write4(Player_ExpErience);
			发包类.Write2(FLD_制作类型);
			发包类.Write2(FLD_制作等级);
			发包类.Write4(FLD_制作熟练度);
			if (Player_Job_leve >= 6)
			{
				升天历练数 += 升天历练当前获得数;
				if (升天历练数 >= 2000000000)
				{
					升天历练数 = 2000000000;
				}
				else if (升天历练数 <= 0)
				{
					升天历练数 = 0;
				}
				if (升天历练数 >= 50000000)
				{
					int num3 = GetEmptyBagSlot();
					if (num3 != -1)
					{
						升天历练数 -= 50000000;
						增加物品3(BitConverter.GetBytes(RxjhClass.GetDBItmeId()), BitConverter.GetBytes(1000000714), num3, BitConverter.GetBytes(1), new byte[56]);
					}
					else
					{
						系统提示("人物背包没有空位了。");
					}
				}
				发包类.Write4(升天历练数);
				发包类.Write4(升天历练当前获得数);
			}
			else
			{
				发包类.Write4(0);
				发包类.Write4(0);
			}
			发包类.Write8(0L);
			升天历练当前获得数 = 0;
			if (Client != null)
			{
				Client.SendPak(发包类, 27136, 人物全服ID);
			}
		}

		public void 更新金钱和负重()
		{
			if (Player_Money < 0)
			{
				Player_Money = 0L;
			}
			人物当前负重 = 0;
			if (World.无限负重 == 0)
			{
				for (int i = 0; i < 96; i++)
				{
					if (装备栏包裹[i].Get物品ID > 0)
					{
						人物当前负重 += 装备栏包裹[i].物品总重量;
					}
				}
			}
			using 发包类 发包类 = new 发包类();
			发包类.Write8(Player_Money);
			发包类.Write((float)人物当前负重);
			发包类.Write((float)总负重);
			if (Client != null)
			{
				Client.SendPak(发包类, 31744, 人物全服ID);
			}
		}

		public void 初始化气功()
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write2(43940);
			发包类.Write2(10);
			发包类.Write4(0);
			发包类.Write4(0);
			发包类.Write2(0);
			for (int i = 0; i < 15; i++)
			{
				if (i < 12)
				{
					发包类.Write2(气功[i].气功ID);
					if (气功[i].气功ID != 0)
					{
						if (气功[i].气功量 != 0)
						{
							发包类.Write2(气功[i].气功量 + FLD_装备_追加_气功 + FLD_人物_追加_气功 + 人物_WX_BUFF_气功 + (int)得到单项气功增加值(i) + FLD_药品_追加_气功);
						}
						else
						{
							发包类.Write2(0);
						}
					}
					else
					{
						发包类.Write2(0);
					}
				}
				else
				{
					发包类.Write4(0);
				}
			}
			发包类.Write2(0);
			发包类.Write2(65520);
			发包类.Write2(7);
			发包类.Write4(0);
			if (Client != null)
			{
				Client.SendPak(发包类, 27648, 人物全服ID);
			}
		}

		public void 更新武勋效果()
		{
			人物_WX_BUFF_生命 = 0;
			人物_WX_BUFF_攻击 = 0;
			人物_WX_BUFF_防御 = 0;
			人物_WX_BUFF_回避 = 0;
			人物_WX_BUFF_内功 = 0;
			人物_WX_BUFF_命中 = 0;
			人物_WX_BUFF_气功 = 0;
			人物追加武勋战力 = 0;
			武勋降低百分比防御 = 0.0;
			base.武功回避 = 0;
			if (Config.武勋开关 != 0)
			{
				foreach (武勋加成类 value in World.Wxlever.Values)
				{
					switch (武勋阶段)
					{
					case 2:
						if (武勋阶段 == value.增加阶段)
						{
							人物_WX_BUFF_生命 = value.增加HP;
							人物_WX_BUFF_内功 = value.增加MP;
							人物_WX_BUFF_攻击 = value.增加攻击;
							人物_WX_BUFF_防御 = value.增加防御;
							人物_WX_BUFF_气功 = value.增加气功;
						}
						break;
					case 3:
						if (武勋阶段 == value.增加阶段)
						{
							人物_WX_BUFF_生命 = value.增加HP;
							人物_WX_BUFF_内功 = value.增加MP;
							人物_WX_BUFF_攻击 = value.增加攻击;
							人物_WX_BUFF_防御 = value.增加防御;
							人物_WX_BUFF_气功 = value.增加气功;
						}
						break;
					case 4:
						if (武勋阶段 == value.增加阶段)
						{
							人物_WX_BUFF_生命 = value.增加HP;
							人物_WX_BUFF_内功 = value.增加MP;
							人物_WX_BUFF_攻击 = value.增加攻击;
							人物_WX_BUFF_防御 = value.增加防御;
							人物_WX_BUFF_气功 = value.增加气功;
						}
						break;
					case 5:
						if (武勋阶段 == value.增加阶段)
						{
							人物_WX_BUFF_生命 = value.增加HP;
							人物_WX_BUFF_内功 = value.增加MP;
							人物_WX_BUFF_攻击 = value.增加攻击;
							人物_WX_BUFF_防御 = value.增加防御;
							人物_WX_BUFF_气功 = value.增加气功;
						}
						break;
					case 6:
						if (武勋阶段 == value.增加阶段)
						{
							人物_WX_BUFF_生命 = value.增加HP;
							人物_WX_BUFF_内功 = value.增加MP;
							人物_WX_BUFF_攻击 = value.增加攻击;
							人物_WX_BUFF_防御 = value.增加防御;
							人物_WX_BUFF_气功 = value.增加气功;
						}
						break;
					case 7:
						if (武勋阶段 == value.增加阶段)
						{
							人物_WX_BUFF_生命 = value.增加HP;
							人物_WX_BUFF_内功 = value.增加MP;
							人物_WX_BUFF_攻击 = value.增加攻击;
							人物_WX_BUFF_防御 = value.增加防御;
							人物_WX_BUFF_气功 = value.增加气功;
						}
						break;
					case 8:
						if (武勋阶段 == value.增加阶段)
						{
							人物_WX_BUFF_生命 = value.增加HP;
							人物_WX_BUFF_内功 = value.增加MP;
							人物_WX_BUFF_攻击 = value.增加攻击;
							人物_WX_BUFF_防御 = value.增加防御;
							人物_WX_BUFF_气功 = value.增加气功;
							if (称号药品.ContainsKey(1008001042) || 称号药品.ContainsKey(1008001043))
							{
								人物追加武勋战力 = 20;
								武勋降低百分比防御 = 0.005;
								base.武功回避 = (int)((double)FLD_人物基本_回避 * 0.05);
							}
						}
						break;
					case 9:
						if (武勋阶段 == value.增加阶段)
						{
							人物_WX_BUFF_生命 = value.增加HP;
							人物_WX_BUFF_内功 = value.增加MP;
							人物_WX_BUFF_攻击 = value.增加攻击;
							人物_WX_BUFF_防御 = value.增加防御;
							人物_WX_BUFF_气功 = value.增加气功;
							base.大魔神添加全职业气功防御几率 = value.武勋气功防御;
							if (称号药品.ContainsKey(1008002376) || 称号药品.ContainsKey(1008002377))
							{
								人物追加武勋战力 = 30;
								武勋降低百分比防御 = 0.005;
								base.武功回避 = (int)((double)FLD_人物基本_回避 * 0.1);
							}
						}
						break;
					}
				}
			}
			World.检查玩家世界ID(人物全服ID)?.更新HP_MP_SP();
		}

		public void 计算人物武勋阶段和荣誉()
		{
			try
			{
				if (荣誉ID_ == 0)
				{
					return;
				}
				更新荣誉();
				if (荣誉ID_ != 0)
				{
					if (追加状态列表 != null && !GetAddState(荣誉ID_))
					{
						Players players = 得到人物数据(人物全服ID);
						if (players != null)
						{
							追加状态类 追加状态类2 = new 追加状态类(players, 604800000, 荣誉ID_, 0);
							players.追加状态列表.Add(追加状态类2.FLD_PID, 追加状态类2);
							players.状态效果(BitConverter.GetBytes(荣誉ID_), 1, 604800000);
							players.前十追加战斗力 = 5;
						}
						if (World.是否开启前十上线公告 == 1)
						{
							World.conn.发送("狮子吼|" + players.人物全服ID + "|" + players.UserName + "|" + string.Format(World.前十上线公告内容, players.UserName) + "|" + players.Client.ToString() + "|" + World.ServerID + "|" + players.人物坐标_地图 + "|" + 38);
						}
					}
				}
				else
				{
					int num = 当前荣誉称号();
					if (num != 0)
					{
						追加状态列表[num].时间结束事件();
						荣誉ID_ = 0;
						FLD_荣誉ID = 0;
					}
				}
			}
			catch
			{
			}
		}

		public int 当前荣誉称号()
		{
			try
			{
				if (追加状态列表 == null || 追加状态列表.Count == 0)
				{
					return 0;
				}
				if (GetAddState(1008001300))
				{
					return 1008001300;
				}
				if (GetAddState(1008001301))
				{
					return 1008001301;
				}
				if (GetAddState(1008001302))
				{
					return 1008001302;
				}
				if (GetAddState(1008001303))
				{
					return 1008001303;
				}
				if (GetAddState(1008001304))
				{
					return 1008001304;
				}
				if (GetAddState(1008001305))
				{
					return 1008001305;
				}
				if (GetAddState(1008001306))
				{
					return 1008001306;
				}
				if (GetAddState(1008001307))
				{
					return 1008001307;
				}
				if (GetAddState(1008001308))
				{
					return 1008001308;
				}
				if (GetAddState(1008001309))
				{
					return 1008001309;
				}
				if (GetAddState(1008001310))
				{
					return 1008001310;
				}
				if (GetAddState(1008001311))
				{
					return 1008001311;
				}
				if (GetAddState(1008001312))
				{
					return 1008001312;
				}
				if (GetAddState(1008001313))
				{
					return 1008001313;
				}
				if (GetAddState(1008001314))
				{
					return 1008001314;
				}
				if (GetAddState(1008001315))
				{
					return 1008001315;
				}
				if (GetAddState(1008001316))
				{
					return 1008001316;
				}
				if (GetAddState(1008001317))
				{
					return 1008001317;
				}
				if (GetAddState(1008001318))
				{
					return 1008001318;
				}
				if (GetAddState(1008001319))
				{
					return 1008001319;
				}
				if (GetAddState(1008001200))
				{
					return 1008001200;
				}
				if (GetAddState(1008001201))
				{
					return 1008001201;
				}
				if (GetAddState(1008001202))
				{
					return 1008001202;
				}
				if (GetAddState(1008001203))
				{
					return 1008001203;
				}
				if (GetAddState(1008001204))
				{
					return 1008001204;
				}
				if (GetAddState(1008001205))
				{
					return 1008001205;
				}
				if (GetAddState(1008001206))
				{
					return 1008001206;
				}
				if (GetAddState(1008001207))
				{
					return 1008001207;
				}
				if (GetAddState(1008001208))
				{
					return 1008001208;
				}
				if (GetAddState(1008001209))
				{
					return 1008001209;
				}
				if (GetAddState(1008001210))
				{
					return 1008001210;
				}
				if (GetAddState(1008001211))
				{
					return 1008001211;
				}
				if (GetAddState(1008001212))
				{
					return 1008001212;
				}
				if (GetAddState(1008001213))
				{
					return 1008001213;
				}
				if (GetAddState(1008001214))
				{
					return 1008001214;
				}
				if (GetAddState(1008001215))
				{
					return 1008001215;
				}
				if (GetAddState(1008001216))
				{
					return 1008001216;
				}
				if (GetAddState(1008001217))
				{
					return 1008001217;
				}
				if (GetAddState(1008001218))
				{
					return 1008001218;
				}
				if (GetAddState(1008001219))
				{
					return 1008001219;
				}
				if (GetAddState(1008001220))
				{
					return 1008001220;
				}
				if (GetAddState(1008001221))
				{
					return 1008001221;
				}
				if (GetAddState(1008001222))
				{
					return 1008001222;
				}
				if (GetAddState(1008001223))
				{
					return 1008001223;
				}
				if (GetAddState(1008001224))
				{
					return 1008001224;
				}
				if (GetAddState(1008001225))
				{
					return 1008001225;
				}
				if (GetAddState(1008001226))
				{
					return 1008001226;
				}
				if (GetAddState(1008001227))
				{
					return 1008001227;
				}
				if (GetAddState(1008001228))
				{
					return 1008001228;
				}
				if (GetAddState(1008001229))
				{
					return 1008001229;
				}
				if (GetAddState(1008001230))
				{
					return 1008001230;
				}
				if (GetAddState(1008001231))
				{
					return 1008001231;
				}
				if (GetAddState(1008001232))
				{
					return 1008001232;
				}
				if (GetAddState(1008001233))
				{
					return 1008001233;
				}
				if (GetAddState(1008001234))
				{
					return 1008001234;
				}
				if (GetAddState(1008001235))
				{
					return 1008001235;
				}
				if (GetAddState(1008001236))
				{
					return 1008001236;
				}
				if (GetAddState(1008001237))
				{
					return 1008001237;
				}
				if (GetAddState(1008001238))
				{
					return 1008001238;
				}
				if (GetAddState(1008001239))
				{
					return 1008001239;
				}
				if (GetAddState(1008001240))
				{
					return 1008001240;
				}
				if (GetAddState(1008001241))
				{
					return 1008001241;
				}
				if (GetAddState(1008001242))
				{
					return 1008001242;
				}
				if (GetAddState(1008001243))
				{
					return 1008001243;
				}
				if (GetAddState(1008001244))
				{
					return 1008001244;
				}
				if (GetAddState(1008001245))
				{
					return 1008001245;
				}
				if (GetAddState(1008001246))
				{
					return 1008001246;
				}
				if (GetAddState(1008001247))
				{
					return 1008001247;
				}
				if (GetAddState(1008001248))
				{
					return 1008001248;
				}
				if (GetAddState(1008001249))
				{
					return 1008001249;
				}
				if (GetAddState(1008001250))
				{
					return 1008001250;
				}
				if (GetAddState(1008001251))
				{
					return 1008001251;
				}
				if (GetAddState(1008001252))
				{
					return 1008001252;
				}
				if (GetAddState(1008001253))
				{
					return 1008001253;
				}
				if (GetAddState(1008001254))
				{
					return 1008001254;
				}
				if (GetAddState(1008001255))
				{
					return 1008001255;
				}
				if (GetAddState(1008001256))
				{
					return 1008001256;
				}
				if (GetAddState(1008001257))
				{
					return 1008001257;
				}
				if (GetAddState(1008001258))
				{
					return 1008001258;
				}
				if (GetAddState(1008001259))
				{
					return 1008001259;
				}
				if (GetAddState(1008001260))
				{
					return 1008001260;
				}
				if (GetAddState(1008001261))
				{
					return 1008001261;
				}
				if (GetAddState(1008001262))
				{
					return 1008001262;
				}
				if (GetAddState(1008001263))
				{
					return 1008001263;
				}
				if (GetAddState(1008001264))
				{
					return 1008001264;
				}
				if (GetAddState(1008001265))
				{
					return 1008001265;
				}
				if (GetAddState(1008001266))
				{
					return 1008001266;
				}
				if (GetAddState(1008001267))
				{
					return 1008001267;
				}
				if (GetAddState(1008001268))
				{
					return 1008001268;
				}
				if (GetAddState(1008001269))
				{
					return 1008001269;
				}
				if (GetAddState(1008001270))
				{
					return 1008001270;
				}
				if (GetAddState(1008001271))
				{
					return 1008001271;
				}
				if (GetAddState(1008001272))
				{
					return 1008001272;
				}
				if (GetAddState(1008001273))
				{
					return 1008001273;
				}
				if (GetAddState(1008001274))
				{
					return 1008001274;
				}
				if (GetAddState(1008001275))
				{
					return 1008001275;
				}
				if (GetAddState(1008001276))
				{
					return 1008001276;
				}
				if (GetAddState(1008001277))
				{
					return 1008001277;
				}
				if (GetAddState(1008001278))
				{
					return 1008001278;
				}
				if (GetAddState(1008001279))
				{
					return 1008001279;
				}
				if (GetAddState(1008001280))
				{
					return 1008001280;
				}
				if (GetAddState(1008001281))
				{
					return 1008001281;
				}
				if (GetAddState(1008001282))
				{
					return 1008001282;
				}
				if (GetAddState(1008001283))
				{
					return 1008001283;
				}
				if (GetAddState(1008001284))
				{
					return 1008001284;
				}
				if (GetAddState(1008001285))
				{
					return 1008001285;
				}
				if (GetAddState(1008001286))
				{
					return 1008001286;
				}
				if (GetAddState(1008001287))
				{
					return 1008001287;
				}
				if (GetAddState(1008001288))
				{
					return 1008001288;
				}
				if (GetAddState(1008001289))
				{
					return 1008001289;
				}
				if (GetAddState(1008001290))
				{
					return 1008001290;
				}
				if (GetAddState(1008001291))
				{
					return 1008001291;
				}
				if (GetAddState(1008001292))
				{
					return 1008001292;
				}
				if (GetAddState(1008001293))
				{
					return 1008001293;
				}
				if (GetAddState(1008001294))
				{
					return 1008001294;
				}
				if (GetAddState(1008001295))
				{
					return 1008001295;
				}
				if (GetAddState(1008001296))
				{
					return 1008001296;
				}
				if (GetAddState(1008001297))
				{
					return 1008001297;
				}
				return GetAddState(1008001298) ? 1008001298 : (GetAddState(1008001299) ? 1008001299 : 0);
			}
			catch
			{
				return 0;
			}
		}

		public void 更新荣誉()
		{
			try
			{
				int num = get_荣誉ID(UserName, 3);
				if (num == 0)
				{
					num = get_荣誉ID(UserName, 2);
					if (num == 0)
					{
						num = get_荣誉ID(UserName, 1);
					}
				}
				if (num == 0)
				{
					FLD_荣誉ID = 0;
					荣誉ID_ = 0;
					return;
				}
				荣誉ID_ = num;
				if (num < 1008001250)
				{
					FLD_荣誉ID = num - 1008001099;
				}
				else
				{
					FLD_荣誉ID = num - 1008001049;
				}
			}
			catch
			{
			}
		}

		public void 更新武功和状态()
		{
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			if ((Player_Zx == 1 && 称号药品.ContainsKey(1008001042)) || (Player_Zx == 2 && 称号药品.ContainsKey(1008001043)))
			{
				flag = true;
			}
			if ((Player_Zx == 1 && 称号药品.ContainsKey(1008002376)) || (Player_Zx == 2 && 称号药品.ContainsKey(1008002377)))
			{
				flag2 = true;
			}
			if ((double)Player_WuXun > World.Wxlever[9].武勋点 && flag2)
			{
				武勋阶段 = 9;
			}
			else if ((double)Player_WuXun > World.Wxlever[8].武勋点 && flag)
			{
				武勋阶段 = 8;
			}
			else if ((double)Player_WuXun > World.Wxlever[7].武勋点)
			{
				武勋阶段 = 7;
			}
			else if ((double)Player_WuXun > World.Wxlever[6].武勋点)
			{
				武勋阶段 = 6;
			}
			else if ((double)Player_WuXun > World.Wxlever[5].武勋点)
			{
				武勋阶段 = 5;
			}
			else if ((double)Player_WuXun > World.Wxlever[4].武勋点)
			{
				武勋阶段 = 4;
			}
			else if ((double)Player_WuXun > World.Wxlever[3].武勋点)
			{
				武勋阶段 = 3;
			}
			else if ((double)Player_WuXun > World.Wxlever[2].武勋点)
			{
				武勋阶段 = 2;
			}
			else if ((double)Player_WuXun > World.Wxlever[1].武勋点)
			{
				武勋阶段 = 1;
			}
			try
			{
				更新武勋效果();
				计算人物武勋阶段和荣誉();
				num = 1;
				using 发包类 发包类 = new 发包类();
				发包类.Write2(Player_Level);
				发包类.Write2(FLD_心 + FLD_装备_追加_心);
				发包类.Write2(FLD_力 + FLD_装备_追加_力);
				发包类.Write2(FLD_体 + FLD_装备_追加_体);
				发包类.Write2(FLD_身 + FLD_装备_追加_身);
				发包类.Write2(0);
				if (FLD_人物基本_攻击 > 65535)
				{
					发包类.Write2(65535);
				}
				else
				{
					发包类.Write2(FLD_人物基本_攻击);
				}
				if (FLD_人物基本_防御 > 65535)
				{
					发包类.Write2(65535);
				}
				else
				{
					发包类.Write2(FLD_人物基本_防御);
				}
				发包类.Write2(FLD_人物基本_命中);
				发包类.Write2(FLD_人物基本_回避);
				发包类.Write2(Player_Qigong_point);
				num = 2;
				for (int i = 0; i < 15; i++)
				{
					if (i < 12)
					{
						发包类.Write2(气功[i].气功ID);
						if (气功[i].气功ID != 0)
						{
							if (气功[i].气功量 != 0)
							{
								发包类.Write2(气功[i].气功量 + FLD_装备_追加_气功 + FLD_人物_追加_气功 + 人物_WX_BUFF_气功 + (int)得到单项气功增加值(i) + FLD_药品_追加_气功);
							}
							else
							{
								发包类.Write2(0);
							}
						}
						else
						{
							发包类.Write2(0);
						}
					}
					else
					{
						发包类.Write4(0);
					}
				}
				num = 3;
				发包类.Write2(0);
				for (int j = 0; j < 32; j++)
				{
					if (武功新[0, j] != null)
					{
						发包类.Write4(武功新[0, j].FLD_PID);
					}
					else
					{
						发包类.Write4(0);
					}
				}
				for (int k = 0; k < 28; k++)
				{
					if (武功新[1, k] != null)
					{
						发包类.Write4(武功新[1, k].FLD_PID);
					}
					else
					{
						发包类.Write4(0);
					}
				}
				发包类.Write4(0);
				for (int l = 0; l < 15; l++)
				{
					if (武功新[2, l] != null)
					{
						发包类.Write4(武功新[2, l].FLD_PID);
					}
					else
					{
						发包类.Write4(0);
					}
				}
				num = 4;
				for (int m = 0; m < 32; m++)
				{
					if (武功新[0, m] != null)
					{
						发包类.Write2(武功新[0, m].武功_等级);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				for (int n = 0; n < 28; n++)
				{
					if (武功新[1, n] != null)
					{
						发包类.Write2(武功新[1, n].武功_等级);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				for (int num7 = 0; num7 < 16; num7++)
				{
					if (武功新[2, num7] != null)
					{
						发包类.Write2(武功新[2, num7].武功_等级);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				num = 5;
				for (int num8 = 0; num8 < 32; num8++)
				{
					if (武功新[0, num8] != null)
					{
						发包类.Write2(武功新[0, num8].FLD_武功最高级别);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				for (int num9 = 0; num9 < 28; num9++)
				{
					if (武功新[1, num9] != null)
					{
						发包类.Write2(武功新[1, num9].FLD_武功最高级别);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				for (int num10 = 0; num10 < 16; num10++)
				{
					if (武功新[2, num10] != null)
					{
						发包类.Write2(武功新[2, num10].FLD_武功最高级别);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				num = 6;
				if (武功新[2, 16] != null)
				{
					发包类.Write4(武功新[2, 16].FLD_PID);
				}
				else
				{
					发包类.Write4(0);
				}
				if (武功新[2, 17] != null)
				{
					发包类.Write4(武功新[2, 17].FLD_PID);
				}
				else
				{
					发包类.Write4(1);
				}
				num = 7;
				发包类.Write4((int)((FLD_装备_武功防御力 + (double)人物_气功_追加_武功防御力) * (1.0 + FLD_人物_武功防御力增加百分比 + FLD_人物_气功_武功防御力增加百分比)));
				if (Player_WuXun < 1500000)
				{
					if (GetAddState(1008001042))
					{
						追加状态列表[1008001042].时间结束事件();
					}
					if (GetAddState(1008001043))
					{
						追加状态列表[1008001043].时间结束事件();
					}
				}
				发包类.Write4(Player_WuXun);
				发包类.Write4(人物善恶);
				发包类.Write4(Player_Job);
				发包类.Write4(FLD_攻击速度);
				发包类.Write2(1);
				num = 8;
				if (升天气功 != null && 升天气功.Count > 0)
				{
					foreach (升天气功类 value in 升天气功.Values)
					{
						发包类.Write2(value.气功ID);
						if (value.气功量 != 0)
						{
							发包类.Write2(value.气功量 + FLD_装备_追加_气功 + FLD_人物_追加_气功 + 人物_WX_BUFF_气功 + (int)得到单项气功增加值(value.气功ID) + FLD_药品_追加_气功);
						}
						else
						{
							发包类.Write2(0);
						}
					}
					for (int num11 = 0; num11 < 17 - 升天气功.Count; num11++)
					{
						发包类.Write4(0);
					}
				}
				else
				{
					for (int num12 = 0; num12 < 17; num12++)
					{
						发包类.Write4(0);
					}
				}
				发包类.Write2(0);
				for (int num13 = 0; num13 < 3; num13++)
				{
					发包类.Write4(0);
				}
				num = 9;
				for (int num14 = 1; num14 < 28; num14++)
				{
					if (武功新[3, num14] != null)
					{
						发包类.Write4(武功新[3, num14].FLD_PID);
						发包类.Write4(武功新[3, num14].武功_等级);
					}
					else
					{
						发包类.Write4(0);
						发包类.Write4(0);
					}
				}
				num = 10;
				for (int num2 = 0; num2 < 8; num2++)
				{
					发包类.Write4(0);
				}
				发包类.Write4(升天武功点数);
				for (int num3 = 0; num3 < 15; num3++)
				{
					if (num3 < 12)
					{
						if (气功[num3].气功ID != 0)
						{
							发包类.Write((byte)气功[num3].气功量);
						}
						else
						{
							发包类.Write(0);
						}
					}
					else
					{
						发包类.Write(0);
					}
				}
				num = 11;
				if (升天气功 != null && 升天气功.Count > 0)
				{
					foreach (升天气功类 value2 in 升天气功.Values)
					{
						发包类.Write((byte)value2.气功量);
					}
					for (int num4 = 0; num4 < 15 - 升天气功.Count; num4++)
					{
						发包类.Write(0);
					}
				}
				else
				{
					for (int num5 = 0; num5 < 15; num5++)
					{
						发包类.Write(0);
					}
				}
				num = 12;
				发包类.Write4(0);
				发包类.Write2(0);
				发包类.Write4(恢复精力);
				发包类.Write4(最大精力);
				发包类.Write4(人物武功命中);
				发包类.Write4(Player_Whtb);
				发包类.Write2(人物_追加_PVP战力);
				if (每日获得武勋 > 30000)
				{
					发包类.Write2(30000);
				}
				else
				{
					发包类.Write2(每日获得武勋);
				}
				if (丢失武勋 > 30000)
				{
					发包类.Write2(30000);
				}
				else
				{
					发包类.Write2(丢失武勋);
				}
				发包类.Write2(装备追加对怪攻击 + 药品追加对怪攻击 + 强化追加对怪攻击);
				发包类.Write2(装备追加对怪防御 + (int)base.升天五式_魔魂之力 + 药品追加对怪防御 + 强化追加对怪防御 + (int)base.神女神力激发对怪防御力);
				发包类.Write2(人物武功回避);
				if (Player_Job == 13)
				{
					for (int num6 = 5; num6 < 23; num6++)
					{
						if (武功新[1, num6] != null)
						{
							发包类.Write4(武功新[1, num6].FLD_PID);
							发包类.Write4(武功新[1, num6].武功_等级);
							发包类.Write4(武功新[1, num6].FLD_武功最高级别);
						}
						else
						{
							发包类.Write4(0);
							发包类.Write4(0);
							发包类.Write4(0);
						}
					}
					发包类.Write2(神女武功点数);
				}
				num = 13;
				if (Client != null)
				{
					Client.SendPak(发包类, 27392, 人物全服ID);
				}
			}
			catch (Exception ex)
			{
				logo.FileTxtLog("更新武功和状态出错[" + Userid + "]-[" + UserName + "][" + num + "]" + ex.Message);
				MainForm.WriteLine(1, "更新武功和状态出错[" + Userid + "]-[" + UserName + "] " + ex.Message);
			}
		}

		public int 计算每日武勋量(int level)
		{
			if (人物坐标_地图 == 101 || 人物坐标_地图 == 201 || 人物坐标_地图 == 301 || 人物坐标_地图 == 1001 || 人物坐标_地图 == 1101 || 人物坐标_地图 == 29000)
			{
				return 210000000;
			}
			if (World.week == 0 || World.week == 6)
			{
				return World.周末武勋量;
			}
			if (level < 2)
			{
				return 0;
			}
			switch (level)
			{
			default:
				return 0;
			case 2:
				return World.二转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			case 3:
				return World.三转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			case 4:
				return World.四转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			case 5:
				return World.五转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			case 6:
				return World.六转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			case 7:
				return World.七转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			case 8:
				return World.八转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			case 9:
				return World.九转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			case 10:
			case 11:
				return World.十转每日武勋上限 + 计算武皇丹增加每日武勋上限();
			}
		}

		public void 发送任务物品列表()
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write4(36);
				for (int i = 0; i < 36; i++)
				{
					发包类.Write4(i);
					发包类.Write4(0);
					发包类.Write4(任务物品[i].物品ID);
					发包类.Write4(0);
					发包类.Write4(任务物品[i].物品数量);
				}
				if (Client != null)
				{
					Client.SendPak(发包类, 33024, 人物全服ID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送任务物品列表出错![" + Userid + "]-[" + UserName + "]" + ex);
			}
		}

		public void 初始化凝神珠包裹()
		{
			try
			{
				using (发包类 发包类 = new 发包类())
				{
					发包类.Write(171);
					for (int i = 0; i < 6; i++)
					{
						if (BitConverter.ToInt32(凝神珠包裹[i].物品数量, 0) == 0)
						{
							凝神珠包裹[i].物品_byte = new byte[World.数据库单个物品大小];
						}
						else
						{
							检查物品系统("凝神珠包裹", ref 凝神珠包裹[i]);
						}
						发包类.Write(凝神珠包裹[i].GetByte(), 0, World.发包单个物品大小);
					}
					if (Client != null)
					{
						Client.SendPak(发包类, 28928, 人物全服ID);
					}
				}
				int num = 0;
				for (int j = 0; j < 6; j++)
				{
					if (BitConverter.ToInt32(凝神珠包裹[j].物品ID, 0) != 0)
					{
						if (num == 3)
						{
							break;
						}
						if (凝神珠包裹[j].FLD_MAGIC1 != 凝神珠包裹[j].FLD_MAGIC0)
						{
							num++;
							凝神珠操作包(1, j, BitConverter.ToInt32(凝神珠包裹[j].物品ID, 0), 凝神珠包裹[j].FLD_MAGIC1, 凝神珠包裹[j].FLD_MAGIC0);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public void 凝神珠操作包(int int_70, int int_71, int int_72, int int_73, int int_74)
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write4(int_70);
			发包类.Write4(int_71);
			发包类.Write4(int_72);
			发包类.Write4(0);
			发包类.Write4(int_73);
			发包类.Write4(int_74);
			if (Client != null)
			{
				Client.SendPak(发包类, 57368, 人物全服ID);
			}
		}

		public int 计算武皇丹增加每日武勋上限()
		{
			if (追加状态列表 != null)
			{
				foreach (追加状态类 value in 追加状态列表.Values)
				{
					switch (value.FLD_PID)
					{
					case 1008002054:
						return 10000;
					case 1008001040:
						return 5000;
					case 1100004:
						return 1000;
					}
				}
			}
			return 0;
		}

		public void 初始化行囊包裹()
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write(192);
				for (int i = 0; i < 3; i++)
				{
					if (BitConverter.ToInt32(行囊包裹[i].物品数量, 0) == 0)
					{
						行囊包裹[i].物品_byte = new byte[World.数据库单个物品大小];
					}
					else
					{
						检查物品系统("行囊包裹", ref 行囊包裹[i]);
					}
					发包类.Write(行囊包裹[i].GetByte(), 0, World.发包单个物品大小);
				}
				if (Client != null)
				{
					Client.SendPak(发包类, 28928, 人物全服ID);
				}
			}
			catch (Exception)
			{
			}
		}

		public void 初始化杂货行囊包裹()
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write(193);
				发包类.Write4(1);
				for (int i = 0; i < 24; i++)
				{
					if (BitConverter.ToInt32(杂货行囊包裹[i].物品数量, 0) == 0)
					{
						杂货行囊包裹[i].物品_byte = new byte[World.数据库单个物品大小];
					}
					else
					{
						检查物品系统("杂货行囊包裹", ref 杂货行囊包裹[i]);
					}
					发包类.Write(杂货行囊包裹[i].GetByte(), 0, World.发包单个物品大小);
				}
				if (Client != null)
				{
					Client.SendPak(发包类, 15621, 人物全服ID);
				}
			}
			catch (Exception)
			{
			}
		}

		public void 初始化披风行囊()
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write4(169);
			发包类.Write(1);
			for (int i = 0; i < 66; i++)
			{
				if (BitConverter.ToInt32(披风行囊[i].物品数量, 0) == 0)
				{
					披风行囊[i].物品_byte = new byte[World.数据库单个物品大小];
					发包类.Write(new byte[World.发包单个物品大小], 0, World.发包单个物品大小);
				}
				else
				{
					发包类.Write(披风行囊[i].GetByte(), 0, World.发包单个物品大小);
				}
			}
			if (Client != null)
			{
				Client.SendPak(发包类, 40448, 人物全服ID);
			}
		}

		public void 初始化装备篮包裹()
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write(1);
			发包类.Write(2);
			发包类.Write(0);
			发包类.Write2(0);
			for (int i = 0; i < 96; i++)
			{
				if (BitConverter.ToInt32(装备栏包裹[i].物品数量, 0) == 0)
				{
					装备栏包裹[i].物品_byte = new byte[World.数据库单个物品大小];
				}
				if (装备栏包裹[i].FLD_FJ_中级附魂 <= 22 && 装备栏包裹[i].FLD_FJ_中级附魂 >= 21 && 装备栏包裹[i].FLD_FJ_觉醒 > 0)
				{
					装备栏包裹[i].物品_中级附魂_追加_觉醒 = 装备栏包裹[i].FLD_FJ_中级附魂 - 20;
				}
				发包类.Write(装备栏包裹[i].GetByte(), 0, 96);
			}
			if (Client != null)
			{
				Client.SendPak(发包类, 28928, 人物全服ID);
			}
		}

		public void 初始化已装备物品()
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("AA55960FB603A000900F01000000B6030000B6C0D0D0CFC0CDBDB5DC3100000000000000000000000000000000000000000000000000000001003C000300050100000100000000000000000001017B143944000070410A97F344650000000000000002000100000000000000000000000000FFFFFFFFFFFFFFFF0100000000000000FFFFFFFFFFFFFFFF0200000000000000FFFFFFFFFFFFFFFFE09D6ECF98495009618F6A1E0000000001000000052D3101000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000289A012200654D090DA507000000000001000000052D3101042D3101042D3101042D3101042D31010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000E0AE18A496A650090DA507000000000001000000052D3101042D3101042D3101042D3101042D3101000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002777DC9864455094972D01D00000000010000003675333C12E1F50512E1F50511E1F50511E1F5050000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000EC9DB830066E4909EF380C000000000001000000062D3101042D3101032D3101032D310100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				byte[] array = Converter.hexStringToByte2(stringBuilder.ToString());
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 14, 2);
				byte[] bytes = Encoding.Default.GetBytes(UserName);
				Buffer.BlockCopy(bytes, 0, array, 18, bytes.Length);
				if (帮派Id != 0)
				{
					byte[] bytes2 = BitConverter.GetBytes(帮派Id);
					Buffer.BlockCopy(bytes2, 0, array, 34, bytes2.Length);
					byte[] bytes3 = Encoding.Default.GetBytes(帮派名字);
					Buffer.BlockCopy(bytes3, 0, array, 38, bytes3.Length);
					Buffer.BlockCopy(BitConverter.GetBytes(帮派人物等级), 0, array, 53, 1);
					if (帮派门徽 != null)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(World.服务器组ID), 0, array, 54, 1);
					}
				}
				Buffer.BlockCopy(BitConverter.GetBytes(Player_Zx), 0, array, 56, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(Player_Level), 0, array, 58, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(Player_Job_leve), 0, array, 60, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(Player_Job), 0, array, 62, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 63, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(New人物模版.发色), 0, array, 64, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(New人物模版.发型), 0, array, 66, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(New人物模版.声音), 0, array, 76, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(New人物模版.性别), 0, array, 77, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(人物坐标_X), 0, array, 78, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(人物坐标_Z), 0, array, 82, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(人物坐标_Y), 0, array, 86, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(人物坐标_地图), 0, array, 90, 2);
				Buffer.BlockCopy(人物名字模版, 0, array, 106, 48);
				for (int i = 0; i < 17; i++)
				{
					if (BitConverter.ToInt32(装备栏已穿装备[i].物品数量, 0) == 0)
					{
						装备栏已穿装备[i].物品_byte = new byte[World.数据库单个物品大小];
					}
					else
					{
						检查物品系统("人物穿戴装备", ref 装备栏已穿装备[i]);
					}
					if (装备栏已穿装备[i].FLD_FJ_中级附魂 <= 22 && 装备栏已穿装备[i].FLD_FJ_中级附魂 >= 21 && 装备栏已穿装备[i].FLD_FJ_觉醒 > 0)
					{
						装备栏已穿装备[i].物品_中级附魂_追加_觉醒 = 装备栏已穿装备[i].FLD_FJ_中级附魂 - 20;
					}
					Buffer.BlockCopy(装备栏已穿装备[i].GetByte(), 0, array, 154 + i * World.发包单个物品大小, World.发包单个物品大小);
				}
				for (int j = 0; j < 15; j++)
				{
					if (BitConverter.ToInt32(辅助装备栏装备[j].物品数量, 0) == 0)
					{
						辅助装备栏装备[j].物品_byte = new byte[World.数据库单个物品大小];
					}
					else
					{
						检查物品系统("辅助穿戴装备", ref 辅助装备栏装备[j]);
					}
					Buffer.BlockCopy(辅助装备栏装备[j].GetByte(), 0, array, 154 + (15 + j) * World.发包单个物品大小, World.发包单个物品大小);
				}
				if (BitConverter.ToInt32(装备栏已穿装备[15].物品数量, 0) != 0)
				{
					Buffer.BlockCopy(装备栏已穿装备[15].GetByte(), 0, array, 154 + 30 * World.发包单个物品大小, World.发包单个物品大小);
				}
				byte[] src = new byte[World.发包单个物品大小];
				Buffer.BlockCopy(src, 0, array, 154 + 31 * World.发包单个物品大小, World.发包单个物品大小);
				if (BitConverter.ToInt32(装备栏已穿装备[16].物品数量, 0) != 0)
				{
					Buffer.BlockCopy(装备栏已穿装备[16].GetByte(), 0, array, 154 + 32 * World.发包单个物品大小, World.发包单个物品大小);
				}
				Buffer.BlockCopy(src, 0, array, 154 + 33 * World.发包单个物品大小, World.发包单个物品大小);
				for (int k = 0; k < 6; k++)
				{
					int num = 0;
					switch (k)
					{
					case 0:
						num = 3;
						break;
					case 1:
						num = 5;
						break;
					case 2:
						num = 4;
						break;
					case 3:
						num = 1;
						break;
					case 4:
						num = 2;
						break;
					case 5:
						num = 0;
						break;
					}
					if (BitConverter.ToInt32(宝珠装备栏装备[num].物品数量, 0) == 0)
					{
						宝珠装备栏装备[num].物品_byte = new byte[World.数据库单个物品大小];
					}
					else
					{
						检查物品系统("宝珠穿戴装备", ref 宝珠装备栏装备[num]);
					}
					Buffer.BlockCopy(宝珠装备栏装备[num].GetByte(), 0, array, 154 + (34 + k) * World.发包单个物品大小, World.发包单个物品大小);
				}
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send多包(array, array.Length);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "初始话已装备物品出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
		}

		public void 更新制作系统()
		{
			if (FLD_制作类型 == 0)
			{
				return;
			}
			ConcurrentDictionary<int, CraftingItem> concurrentDictionary = CraftingItem.Get制作物品类列表(FLD_制作类型, FLD_制作等级);
			ConcurrentDictionary<int, CraftingItem> concurrentDictionary2 = new ConcurrentDictionary<int, CraftingItem>();
			ConcurrentDictionary<int, CraftingItem> concurrentDictionary3 = new ConcurrentDictionary<int, CraftingItem>();
			if (concurrentDictionary == null || concurrentDictionary.Count <= 0)
			{
				return;
			}
			foreach (int key in concurrentDictionary.Keys)
			{
				if (concurrentDictionary[key].CraftType != 4)
				{
					concurrentDictionary2.TryAdd(concurrentDictionary[key].ItemID, concurrentDictionary[key]);
				}
				else
				{
					concurrentDictionary3.TryAdd(concurrentDictionary[key].ItemID, concurrentDictionary[key]);
				}
			}
			if (concurrentDictionary2 != null && concurrentDictionary2.Count > 0)
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write2(concurrentDictionary2.Count);
				foreach (CraftingItem value in concurrentDictionary2.Values)
				{
					发包类.Write8(value.ItemID);
					发包类.Write4(10000);
					发包类.Write2(0);
					发包类.Write2(1);
					发包类.Write2(1);
					if (FLD_制作类型 == 3)
					{
						发包类.Write2(FLD_制作类型);
						发包类.Write2(0);
						发包类.Write2(0);
					}
					else
					{
						发包类.Write2(FLD_制作类型);
						发包类.Write2(35);
						发包类.Write2(0);
					}
				}
				if (Client != null)
				{
					Client.SendPak(发包类, 13079, 人物全服ID);
				}
			}
			ConcurrentDictionary<long, long> concurrentDictionary4 = new ConcurrentDictionary<long, long>();
			concurrentDictionary4.TryAdd(1000001400L, 10000L);
			concurrentDictionary4.TryAdd(1000001401L, 10000L);
			concurrentDictionary4.TryAdd(1000001402L, 10000L);
			concurrentDictionary4.TryAdd(1000001403L, 10000L);
			concurrentDictionary4.TryAdd(1000001404L, 10000L);
			concurrentDictionary4.TryAdd(1008002222L, 100L);
			concurrentDictionary4.TryAdd(1008002223L, 80L);
			concurrentDictionary4.TryAdd(1008002224L, 89L);
			concurrentDictionary4.TryAdd(1008002225L, 67L);
			concurrentDictionary4.TryAdd(1008002226L, 67L);
			concurrentDictionary4.TryAdd(1008002227L, 67L);
			concurrentDictionary4.TryAdd(1008002228L, 89L);
			concurrentDictionary4.TryAdd(1008002229L, 100L);
			concurrentDictionary4.TryAdd(1008002230L, 200L);
			concurrentDictionary4.TryAdd(1008002231L, 133L);
			concurrentDictionary4.TryAdd(1008002232L, 133L);
			concurrentDictionary4.TryAdd(1008002233L, 89L);
			concurrentDictionary4.TryAdd(1008002234L, 83L);
			concurrentDictionary4.TryAdd(1008002235L, 83L);
			concurrentDictionary4.TryAdd(1008002236L, 103L);
			concurrentDictionary4.TryAdd(1008002237L, 133L);
			concurrentDictionary4.TryAdd(1008002238L, 111L);
			concurrentDictionary4.TryAdd(1008002239L, 117L);
			concurrentDictionary4.TryAdd(1008002240L, 119L);
			concurrentDictionary4.TryAdd(1008002241L, 100L);
			concurrentDictionary4.TryAdd(1008002242L, 83L);
			concurrentDictionary4.TryAdd(1008002243L, 89L);
			concurrentDictionary4.TryAdd(1008002244L, 80L);
			concurrentDictionary4.TryAdd(1008002245L, 89L);
			concurrentDictionary4.TryAdd(1008002246L, 222L);
			concurrentDictionary4.TryAdd(1008002247L, 187L);
			concurrentDictionary4.TryAdd(1008002248L, 178L);
			concurrentDictionary4.TryAdd(1008002249L, 120L);
			concurrentDictionary4.TryAdd(1008002250L, 111L);
			concurrentDictionary4.TryAdd(1008002251L, 111L);
			concurrentDictionary4.TryAdd(1008002252L, 100L);
			concurrentDictionary4.TryAdd(1008002253L, 107L);
			concurrentDictionary4.TryAdd(1008002254L, 83L);
			concurrentDictionary4.TryAdd(1008002255L, 89L);
			concurrentDictionary4.TryAdd(1008002256L, 83L);
			concurrentDictionary4.TryAdd(1008002257L, 80L);
			concurrentDictionary4.TryAdd(1008002258L, 89L);
			concurrentDictionary4.TryAdd(1008002259L, 80L);
			concurrentDictionary4.TryAdd(1008002260L, 76L);
			concurrentDictionary4.TryAdd(1008002261L, 83L);
			concurrentDictionary4.TryAdd(1008002262L, 100L);
			concurrentDictionary4.TryAdd(1008002263L, 111L);
			concurrentDictionary4.TryAdd(1008002264L, 111L);
			concurrentDictionary4.TryAdd(1008002265L, 100L);
			concurrentDictionary4.TryAdd(1008002266L, 107L);
			concurrentDictionary4.TryAdd(1008002267L, 100L);
			concurrentDictionary4.TryAdd(1008002268L, 89L);
			concurrentDictionary4.TryAdd(1008002269L, 95L);
			concurrentDictionary4.TryAdd(1008002272L, 100L);
			concurrentDictionary4.TryAdd(1008002273L, 80L);
			concurrentDictionary4.TryAdd(1008002274L, 89L);
			concurrentDictionary4.TryAdd(1008002275L, 67L);
			concurrentDictionary4.TryAdd(1008002276L, 67L);
			concurrentDictionary4.TryAdd(1008002277L, 67L);
			concurrentDictionary4.TryAdd(1008002278L, 89L);
			concurrentDictionary4.TryAdd(1008002279L, 100L);
			concurrentDictionary4.TryAdd(1008002280L, 200L);
			concurrentDictionary4.TryAdd(1008002281L, 133L);
			concurrentDictionary4.TryAdd(1008002282L, 133L);
			concurrentDictionary4.TryAdd(1008002283L, 89L);
			concurrentDictionary4.TryAdd(1008002284L, 83L);
			concurrentDictionary4.TryAdd(1008002285L, 83L);
			concurrentDictionary4.TryAdd(1008002286L, 103L);
			concurrentDictionary4.TryAdd(1008002287L, 133L);
			concurrentDictionary4.TryAdd(1008002288L, 111L);
			concurrentDictionary4.TryAdd(1008002289L, 117L);
			concurrentDictionary4.TryAdd(1008002290L, 119L);
			concurrentDictionary4.TryAdd(1008002291L, 100L);
			concurrentDictionary4.TryAdd(1008002292L, 83L);
			concurrentDictionary4.TryAdd(1008002293L, 89L);
			concurrentDictionary4.TryAdd(1008002294L, 80L);
			concurrentDictionary4.TryAdd(1008002295L, 89L);
			concurrentDictionary4.TryAdd(1008002296L, 222L);
			concurrentDictionary4.TryAdd(1008002297L, 187L);
			concurrentDictionary4.TryAdd(1008002298L, 178L);
			concurrentDictionary4.TryAdd(1008002299L, 120L);
			concurrentDictionary4.TryAdd(1008002300L, 111L);
			concurrentDictionary4.TryAdd(1008002301L, 111L);
			concurrentDictionary4.TryAdd(1008002302L, 100L);
			concurrentDictionary4.TryAdd(1008002303L, 107L);
			concurrentDictionary4.TryAdd(1008002304L, 83L);
			concurrentDictionary4.TryAdd(1008002305L, 89L);
			concurrentDictionary4.TryAdd(1008002306L, 83L);
			concurrentDictionary4.TryAdd(1008002307L, 80L);
			concurrentDictionary4.TryAdd(1008002308L, 89L);
			concurrentDictionary4.TryAdd(1008002309L, 80L);
			concurrentDictionary4.TryAdd(1008002310L, 76L);
			concurrentDictionary4.TryAdd(1008002311L, 83L);
			concurrentDictionary4.TryAdd(1008002312L, 100L);
			concurrentDictionary4.TryAdd(1008002313L, 111L);
			concurrentDictionary4.TryAdd(1008002314L, 111L);
			concurrentDictionary4.TryAdd(1008002315L, 100L);
			concurrentDictionary4.TryAdd(1008002316L, 107L);
			concurrentDictionary4.TryAdd(1008002317L, 100L);
			concurrentDictionary4.TryAdd(1008002318L, 89L);
			concurrentDictionary4.TryAdd(1008002319L, 95L);
			if (concurrentDictionary3 == null || concurrentDictionary3.Count <= 0)
			{
				return;
			}
			using 发包类 发包类2 = new 发包类();
			发包类2.Write2(concurrentDictionary3.Count);
			foreach (CraftingItem value2 in concurrentDictionary3.Values)
			{
				发包类2.Write8(value2.ItemID);
				发包类2.Write8(concurrentDictionary4[value2.ItemID]);
				发包类2.Write8(0L);
			}
			if (Client != null)
			{
				Client.SendPak(发包类2, 13335, 人物全服ID);
			}
		}

		public void 更新情侣系统(int 对方是否在线, string 对方名字, string 戒指刻字, int 关系状态, DateTime 离婚日期)
		{
			byte[] array = Converter.hexStringToByte("AA558E00A6007C17800001000000714C7E0000000000C4687E0000000000BDD600000000000000000000000000B7709C000000000000AC89014D00000000AC89014D040000002330000002D0A9B77406000000000000A59D0300CB1C0A4D00000000010000000000000000000000000000000000000000000000000000000000000000000000001F86A3000000000000568055AA");
			DateTime value = new DateTime(1970, 1, 1, 8, 0, 0);
			Buffer.BlockCopy(BitConverter.GetBytes(对方是否在线), 0, array, 10, 2);
			byte[] bytes = Encoding.Default.GetBytes(对方名字);
			Buffer.BlockCopy(bytes, 0, array, 30, bytes.Length);
			if (关系状态 == 0)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(关系状态), 0, array, 58, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 62, 4);
			}
			else
			{
				Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 58, 4);
				Buffer.BlockCopy(BitConverter.GetBytes((int)DateTime.Now.AddMinutes(关系状态 - 4320 - 5760).Subtract(value).TotalSeconds), 0, array, 62, 4);
			}
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_爱情度等级), 0, array, 66, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_情侣_爱情度), 0, array, 70, 4);
			if (是否已婚 == 1)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 74, 1);
			}
			else
			{
				Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 74, 1);
			}
			Buffer.BlockCopy(BitConverter.GetBytes((int)FLD_结婚纪念日.Subtract(value).TotalSeconds), 0, array, 90, 4);
			if (戒指刻字.Length != 0)
			{
				byte[] bytes2 = Encoding.Default.GetBytes(戒指刻字);
				Buffer.BlockCopy(bytes2, 0, array, 102, bytes2.Length);
			}
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send多包(array, array.Length);
			}
		}

		public void 保存人物数据存储过程()
		{
			if (UserName.Length == 0)
			{
				return;
			}
			try
			{
				SqlParameter[] prams = new SqlParameter[81]
				{
					SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 20, Userid),
					SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 20, UserName),
					SqlDBA.MakeInParam("@level", SqlDbType.Int, 0, Player_Level),
					SqlDBA.MakeInParam("@strFace", SqlDbType.VarBinary, 20, New人物模版.人物模板_byte),
					SqlDBA.MakeInParam("@job", SqlDbType.Int, 0, Player_Job),
					SqlDBA.MakeInParam("@exp", SqlDbType.VarChar, 50, 人物经验),
					SqlDBA.MakeInParam("@zx", SqlDbType.Int, 0, Player_Zx),
					SqlDBA.MakeInParam("@job_level", SqlDbType.Int, 0, Player_Job_leve),
					SqlDBA.MakeInParam("@x", SqlDbType.Float, 0, 人物坐标_X),
					SqlDBA.MakeInParam("@y", SqlDbType.Float, 0, 人物坐标_Y),
					SqlDBA.MakeInParam("@z", SqlDbType.Float, 0, 人物坐标_Z),
					SqlDBA.MakeInParam("@menow", SqlDbType.Int, 0, 人物坐标_地图),
					SqlDBA.MakeInParam("@money", SqlDbType.VarChar, 0, Player_Money),
					SqlDBA.MakeInParam("@hp", SqlDbType.Int, 0, 人物_HP),
					SqlDBA.MakeInParam("@mp", SqlDbType.Int, 0, 人物_MP),
					SqlDBA.MakeInParam("@sp", SqlDbType.Int, 0, 人物_SP),
					SqlDBA.MakeInParam("@wx", SqlDbType.Int, 0, Player_WuXun),
					SqlDBA.MakeInParam("@srcs", SqlDbType.Int, 0, 杀人次数),
					SqlDBA.MakeInParam("@bscs", SqlDbType.Int, 0, 被杀次数),
					SqlDBA.MakeInParam("@se", SqlDbType.Int, 0, 人物善恶),
					SqlDBA.MakeInParam("@point", SqlDbType.Int, 0, Player_Qigong_point),
					SqlDBA.MakeInParam("@strSkills", SqlDbType.VarBinary, 20, GetWgCodesbyte()),
					SqlDBA.MakeInParam("@strWearitem", SqlDbType.VarBinary, 3650, GetWEARITEMCodesbyte()),
					SqlDBA.MakeInParam("@strFZitem", SqlDbType.VarBinary, 1500, GetFZITEMCodesbyte()),
					SqlDBA.MakeInParam("@strBZitem", SqlDbType.VarBinary, 1500, GetBZITEMCodesbyte()),
					SqlDBA.MakeInParam("@strItem", SqlDbType.VarBinary, 8000, GetFLD_ITEMCodesbyte()),
					SqlDBA.MakeInParam("@strnszItem", SqlDbType.VarBinary, World.数据库单个物品大小 * 6, GetFLD_ITEMNSZCodesbyte()),
					SqlDBA.MakeInParam("@strhnItem", SqlDbType.VarBinary, 219, GetFLD_ITEMHNCodesbyte()),
					SqlDBA.MakeInParam("@strzhhnItem", SqlDbType.VarBinary, 1752, GetFLD_ITEMZHHNCodesbyte()),
					SqlDBA.MakeInParam("@strFaskion", SqlDbType.VarBinary, 5640, GetFLD_FASHION_ITEMCodesbyte()),
					SqlDBA.MakeInParam("@strQusetItem", SqlDbType.VarBinary, 300, GetQuestITEMCodesbyte()),
					SqlDBA.MakeInParam("@strKongfu", SqlDbType.VarBinary, 768, GetFLD_KONGFUCodesbyte()),
					SqlDBA.MakeInParam("@strCtime", SqlDbType.VarBinary, 320, Get个人药品byte()),
					SqlDBA.MakeInParam("@strDoors", SqlDbType.VarBinary, 1200, Get土灵符byte()),
					SqlDBA.MakeInParam("@strQuest", SqlDbType.VarBinary, 1200, Get任务byte()),
					SqlDBA.MakeInParam("@fight_exp", SqlDbType.Int, 0, Player_ExpErience),
					SqlDBA.MakeInParam("@rwqg", SqlDbType.Int, 0, 人物轻功),
					SqlDBA.MakeInParam("@NameType", SqlDbType.VarBinary, 48, 人物名字模版),
					SqlDBA.MakeInParam("@zbver", SqlDbType.Int, 0, 装备数据版本),
					SqlDBA.MakeInParam("@zzlx", SqlDbType.Int, 0, FLD_制作类型),
					SqlDBA.MakeInParam("@zzsld", SqlDbType.Int, 0, FLD_制作熟练度),
					SqlDBA.MakeInParam("@strCtimeNew", SqlDbType.VarBinary, 240, Get个人药品Newbyte()),
					SqlDBA.MakeInParam("@qlname", SqlDbType.VarChar, 20, FLD_情侣),
					SqlDBA.MakeInParam("@qlaqd", SqlDbType.Int, 0, FLD_情侣_爱情度),
					SqlDBA.MakeInParam("@qljzname", SqlDbType.VarChar, 32, FLD_情侣戒指),
					SqlDBA.MakeInParam("@maritalstatus", SqlDbType.Int, 0, 解除关系倒计时),
					SqlDBA.MakeInParam("@maried", SqlDbType.Int, 0, 是否已婚),
					SqlDBA.MakeInParam("@loveword", SqlDbType.VarChar, 50, 婚戒刻字),
					SqlDBA.MakeInParam("@strStSkills", SqlDbType.VarBinary, 64, Get升天气功Codesbyte()),
					SqlDBA.MakeInParam("@strStKongfu", SqlDbType.VarBinary, 256, Get升天武功Codesbyte()),
					SqlDBA.MakeInParam("@stlilian", SqlDbType.Int, 0, 升天历练数),
					SqlDBA.MakeInParam("@stwugongdian", SqlDbType.Int, 0, 升天武功点数),
					SqlDBA.MakeInParam("@jhdate", SqlDbType.DateTime, 0, FLD_结婚纪念日),
					SqlDBA.MakeInParam("@pvpiont", SqlDbType.Int, 0, FLD_PVP_Piont),
					SqlDBA.MakeInParam("@fbtime", SqlDbType.Int, 0, 修炼地图剩余时间),
					SqlDBA.MakeInParam("@hdtime", SqlDbType.Int, 0, 活动地图剩余时间),
					SqlDBA.MakeInParam("@lostwx", SqlDbType.Int, 0, 丢失武勋),
					SqlDBA.MakeInParam("@getwx", SqlDbType.Int, 0, 每日获得武勋),
					SqlDBA.MakeInParam("@mgchjh", SqlDbType.Int, 0, 玫瑰称号积分),
					SqlDBA.MakeInParam("@mpgxd", SqlDbType.Int, 0, 门派贡献度),
					SqlDBA.MakeInParam("@whtb", SqlDbType.Int, 0, Player_Whtb),
					SqlDBA.MakeInParam("@strCHtime", SqlDbType.VarBinary, 320, Get称号药品byte()),
					SqlDBA.MakeInParam("@strTStime", SqlDbType.VarBinary, 320, Get特殊药品byte()),
					SqlDBA.MakeInParam("@strStime", SqlDbType.VarBinary, 640, Get时间药品byte()),
					SqlDBA.MakeInParam("@chjh", SqlDbType.Int, 0, 称号积分),
					SqlDBA.MakeInParam("@snwugongdian", SqlDbType.Int, 0, 神女武功点数),
					SqlDBA.MakeInParam("@renwucishu", SqlDbType.Int, 0, 任务次数),
					SqlDBA.MakeInParam("@tfcs", SqlDbType.Int, 0, 副本剩余次数),
					SqlDBA.MakeInParam("@tfljsh", SqlDbType.Int, 0, 讨伐累计伤害),
					SqlDBA.MakeInParam("@addat", SqlDbType.Int, 0, 转生_追加_攻击),
					SqlDBA.MakeInParam("@adddf", SqlDbType.Int, 0, 转生_追加_防御),
					SqlDBA.MakeInParam("@addhp", SqlDbType.Int, 0, 转生_追加_生命),
					SqlDBA.MakeInParam("@zs", SqlDbType.Int, 0, 转生次数),
					SqlDBA.MakeInParam("@ljcz", SqlDbType.Int, 0, 累计充值),
					SqlDBA.MakeInParam("@hfjl", SqlDbType.Int, 0, 恢复精力),
					SqlDBA.MakeInParam("@jlsj", SqlDbType.SmallDateTime, 4, FLD_精力时间),
					SqlDBA.MakeInParam("@config", SqlDbType.VarChar, 100, 客户端设置),
					SqlDBA.MakeInParam("@ljsh", SqlDbType.Int, 0, AccumulatedDamage),
					SqlDBA.MakeInParam("@bossljsh", SqlDbType.Int, 0, BOSS累计伤害),
					SqlDBA.MakeInParam("@syboss", SqlDbType.Int, 0, 深渊BOSS累计伤害),
					SqlDBA.MakeInParam("@ybxf", SqlDbType.Int, 0, 元宝消费2)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = "XWWL_UPDATE_USER_DATA_NEW"
				});
				if (师傅数据.TID != -1)
				{
					保存师徒数据存储过程();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存人物数据出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
		}

		public void 保存师徒数据存储过程()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "PlayersBes_保存师徒数据存储过程()");
			}
			try
			{
				SqlParameter[] prams = new SqlParameter[7]
				{
					SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 20, UserName),
					SqlDBA.MakeInParam("@level", SqlDbType.Int, 0, 师傅数据.TLEVEL),
					SqlDBA.MakeInParam("@stlevel", SqlDbType.Int, 0, 师傅数据.STLEVEL),
					SqlDBA.MakeInParam("@styhd", SqlDbType.Int, 0, 师傅数据.STYHD),
					SqlDBA.MakeInParam("@stwg1", SqlDbType.Int, 0, 师傅数据.STWG1),
					SqlDBA.MakeInParam("@stwg2", SqlDbType.Int, 0, 师傅数据.STWG2),
					SqlDBA.MakeInParam("@stwg3", SqlDbType.Int, 0, 师傅数据.STWG3)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = "UPDATE_St_DATA"
				});
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存师徒数据出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
		}

		public void 保存宠物仓库存储过程()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "PlayersBes_保存宠物仓库存储过程()");
			}
			try
			{
				SqlParameter[] prams = new SqlParameter[3]
				{
					SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 50, Userid),
					SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 50, UserName),
					SqlDBA.MakeInParam("@strItem", SqlDbType.VarBinary, World.数据库单个物品大小 * 20, Get灵宠仓库byte())
				};
				DbPoolClass obj = new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = "XWWL_UPDATE_USER_CWarehouse"
				};
				World.SqlPool.Enqueue(obj);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存灵宠仓库数据出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
		}

		public void 保存灵兽仓库存储过程()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "PlayersBes_保存宠物仓库存储过程()");
			}
			try
			{
				SqlParameter[] prams = new SqlParameter[3]
				{
					SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 50, Userid),
					SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 50, UserName),
					SqlDBA.MakeInParam("@strItem", SqlDbType.VarBinary, World.数据库单个物品大小 * 2, Get灵兽仓库byte())
				};
				DbPoolClass obj = new DbPoolClass
				{
					Conn = DBA.getstrConnection(null),
					Prams = prams,
					Sql = "XWWL_UPDATE_USER_LSarehouse"
				};
				World.SqlPool.Enqueue(obj);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存灵宠仓库数据出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
		}

		public void 保存个人仓库存储过程()
		{
			if (UserName.Length != 0 && !Client.挂机)
			{
				try
				{
					SqlParameter[] prams = new SqlParameter[4]
					{
						SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 20, Userid),
						SqlDBA.MakeInParam("@name", SqlDbType.VarChar, 20, UserName),
						SqlDBA.MakeInParam("@money", SqlDbType.VarChar, 0, 个人仓库钱数),
						SqlDBA.MakeInParam("@strItem", SqlDbType.VarBinary, 4620, Get个人仓库byte())
					};
					World.SqlPool.Enqueue(new DbPoolClass
					{
						Conn = DBA.getstrConnection(null),
						Prams = prams,
						Sql = "XWWL_UPDATE_USER_Warehouse"
					});
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "保存个人仓库数据出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
				}
			}
		}

		public void 保存综合仓库存储过程()
		{
			if (UserName.Length != 0 && !Client.挂机)
			{
				try
				{
					SqlParameter[] prams = new SqlParameter[5]
					{
						SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 20, Userid),
						SqlDBA.MakeInParam("@money", SqlDbType.VarChar, 0, 综合仓库钱数),
						SqlDBA.MakeInParam("@strItem", SqlDbType.VarBinary, 4620, Get综合仓库byte()),
						SqlDBA.MakeInParam("@strItime", SqlDbType.VarBinary, 50, Get综合仓库品byte()),
						SqlDBA.MakeInParam("@zbver", SqlDbType.Int, 0, 综合仓库装备数据版本)
					};
					World.SqlPool.Enqueue(new DbPoolClass
					{
						Conn = DBA.getstrConnection(null),
						Prams = prams,
						Sql = "XWWL_UPDATE_ID_Warehouse"
					});
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "保存综合仓库数据出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
				}
			}
		}

		public void 检察元宝数据1(int int_109, int int_110)
		{
			if (int_109 <= 0)
			{
				return;
			}
			if (World.元宝检测 == 1)
			{
				if (int_109 >= World.单次交易元宝数量上限)
				{
					MainForm.WriteLine(77, "元宝交易数量超出系统允许上限[" + Userid + "]-[" + UserName + "]            [交易数量：" + int_109 + "]      [系统允许上限数量：" + World.单次交易元宝数量上限 + "]");
					switch (World.元宝检测操作)
					{
					case 1:
						return;
					case 2:
						封号(720, Userid, "元宝检测操作2-1");
						break;
					}
				}
				if (FLD_RXPIONT >= World.帐号总元宝上限)
				{
					string[] array = new string[9] { "玩家元宝总数超出系统允许上限[", Userid, "]-[", UserName, "]            [元宝总数：", null, null, null, null };
					array[5] = FLD_RXPIONT.ToString();
					array[6] = "]      [系统允许上限数量：";
					array[7] = World.帐号总元宝上限.ToString();
					array[8] = "]";
					MainForm.WriteLine(77, string.Concat(array));
					switch (World.元宝检测操作)
					{
					case 2:
						封号(720, Userid, "元宝检测操作2-2");
						break;
					case 1:
						FLD_RXPIONT = 0;
						SaveGemData();
						return;
					}
				}
			}
			if (int_110 == 0)
			{
				FLD_RXPIONT -= int_109;
				元宝消费数据(int_109, 1);
				系统提示("消费" + int_109 + "个元宝      [" + DateTime.Now.ToString() + "]。", 22, "系统提示");
			}
			else
			{
				FLD_RXPIONT += int_109;
				系统提示("获得" + int_109 + "个元宝      [" + DateTime.Now.ToString() + "]。", 22, "系统提示");
			}
		}

		public void 检察元宝数据(int 元宝, int 类型, string 来源)
		{
			if (元宝 <= 0)
			{
				return;
			}
			if (World.元宝检测 == 1)
			{
				if (元宝 >= World.单次交易元宝数量上限)
				{
					MainForm.WriteLine(77, "元宝交易数量超出系统允许上限[" + Userid + "]-[" + UserName + "] [交易数量：" + 元宝 + "] [系统允许上限数量：" + World.单次交易元宝数量上限 + "]");
					switch (World.元宝检测操作)
					{
					case 1:
						return;
					case 2:
						封号(720, Userid, "元宝检测操作2-1");
						break;
					}
				}
				if (FLD_RXPIONT >= World.帐号总元宝上限)
				{
					string[] array = new string[9] { "玩家元宝总数超出系统允许上限[", Userid, "]-[", UserName, "] [元宝总数：", null, null, null, null };
					array[5] = FLD_RXPIONT.ToString();
					array[6] = "] [系统允许上限数量：";
					array[7] = World.帐号总元宝上限.ToString();
					array[8] = "]";
					MainForm.WriteLine(77, string.Concat(array));
					switch (World.元宝检测操作)
					{
					case 1:
						FLD_RXPIONT = 0;
						SaveGemData();
						return;
					case 2:
						封号(720, Userid, "元宝检测操作2-2");
						break;
					}
				}
			}
			if (类型 == 0)
			{
				FLD_RXPIONT -= 元宝;
				元宝消费数据(元宝, 1);
				元宝消费数据2(元宝, 1);
				系统提示("消费" + 元宝 + "个元宝[" + DateTime.Now.ToString() + "]。", 22, 来源 ?? "");
				RxjhClass.元宝记录(Userid, UserName, "减少", 来源, "元宝", 元宝);
				SaveGemData();
			}
			else
			{
				FLD_RXPIONT += 元宝;
				系统提示("获得" + 元宝 + "个元宝 [" + DateTime.Now.ToString() + "]。", 22, 来源 ?? "");
				RxjhClass.元宝记录(Userid, UserName, "增加", 来源, "元宝", 元宝);
				SaveGemData();
			}
		}

		public void 返利元宝数据(int 元宝, string 来源)
		{
			if (元宝 > 0)
			{
				FLD_RXPIONT += 元宝;
				系统提示("推广返利, 您获得" + 元宝 + "个元宝 [" + DateTime.Now.ToString() + "]。", 22, 来源 ?? "");
				RxjhClass.元宝记录(Userid, UserName, "增加", 来源, "元宝", 元宝);
			}
		}

		public void 更新代理积分(int nPrice)
		{
			if (FLD_SPREADERID.Length == 0 || nPrice <= 0)
			{
				return;
			}
			DataTable dataTable = RxjhClass.得到上线账号(FLD_SPREADERID.ToString());
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				return;
			}
			int num = 0;
			string userid = dataTable.Rows[0]["FLD_ID"].ToString();
			Players players = World.检查玩家(userid);
			if (players != null)
			{
				players.CheckTreasureGems();
				players.FLD_ZJF += nPrice;
				double num2;
				switch (players.FLD_SPREADER_LEVEL)
				{
				case 1:
					num2 = 0.02;
					if (players.FLD_ZJF >= 20000)
					{
						players.FLD_SPREADER_LEVEL = 2;
					}
					break;
				case 2:
					num2 = 0.05;
					if (players.FLD_ZJF >= 50000)
					{
						players.FLD_SPREADER_LEVEL = 3;
					}
					break;
				case 3:
					num2 = 0.1;
					break;
				default:
					num2 = 0.0;
					if (players.FLD_ZJF >= 5000)
					{
						players.FLD_SPREADER_LEVEL = 1;
					}
					break;
				}
				if (num2 > 0.0 && players.FLD_SPREADER_LEVEL > 0)
				{
					int num3 = (int)((double)nPrice * num2);
					if (num3 >= 1)
					{
						players.返利元宝数据(num3, UserName ?? "");
					}
				}
				players.SaveGemData();
			}
			else
			{
				int num4 = (int)dataTable.Rows[0]["FLD_ZJF"] + nPrice;
				int num5 = (int)dataTable.Rows[0]["FLD_SPREADER_LEVEL"];
				double num6;
				switch (num5)
				{
				case 1:
					num6 = 0.02;
					if (num4 >= 20000)
					{
						num5 = 2;
					}
					break;
				case 2:
					num6 = 0.05;
					if (num4 >= 50000)
					{
						num5 = 3;
					}
					break;
				case 3:
					num6 = 0.1;
					break;
				default:
					num6 = 0.0;
					if (num4 >= 5000)
					{
						num5 = 1;
					}
					break;
				}
				if (num6 > 0.0 && num5 > 0)
				{
					num = (int)((double)nPrice * num6);
				}
				int num7 = (int)dataTable.Rows[0]["FLD_RXPIONT"];
				if (num >= 1)
				{
					num7 += num;
				}
				int rxpiontx = (int)dataTable.Rows[0]["FLD_RXPIONTX"];
				RxjhClass.保存元宝数据(userid, num7, rxpiontx, num4, num5);
			}
			dataTable.Dispose();
		}

		public void CheckGemPointsData(int 元宝, int 类型, string 来源)
		{
			if (元宝 > 0)
			{
				if (类型 == 0)
				{
					FLD_RXPIONTX -= 元宝;
					钻石消费存档(元宝, 1);
					系统提示("消费" + 元宝 + "个钻石[" + DateTime.Now.ToString() + "]。", 22, 来源 ?? "");
					RxjhClass.元宝记录(Userid, UserName, "减少", 来源, "钻石", 元宝);
				}
				else
				{
					FLD_RXPIONTX += 元宝;
					系统提示("获得" + 元宝 + "个钻石 [" + DateTime.Now.ToString() + "]。", 22, 来源 ?? "");
					RxjhClass.元宝记录(Userid, UserName, "增加", 来源, "钻石", 元宝);
				}
			}
		}

		public void 检察元宝积分数据1(int int_109, int int_110)
		{
			if (int_109 > 0)
			{
				if (int_110 == 0)
				{
					FLD_RXPIONTX -= int_109;
					系统提示("消费" + int_109 + "个钻石      [" + DateTime.Now.ToString() + "]。", 22, "系统提示");
				}
				else
				{
					FLD_RXPIONTX += int_109;
					系统提示("获得" + int_109 + "个钻石      [" + DateTime.Now.ToString() + "]。", 22, "系统提示");
				}
			}
		}

		public void 元宝消费数据(int 元宝, int int_110)
		{
			if (元宝 > 0)
			{
				if (int_110 == 0)
				{
					元宝消费 -= 元宝;
					return;
				}
				元宝消费 += 元宝;
				DBA.ExeSqlCommand($"UPDATE TBL_ACCOUNT SET FLD_QDCS='{元宝消费}' WHERE FLD_ID='{Userid}'", "rxjhaccount");
			}
		}

		public void 元宝消费数据2(int int_109, int int_110)
		{
			if (int_109 > 0)
			{
				if (int_110 == 0)
				{
					元宝消费2 -= int_109;
					return;
				}
				元宝消费2 += int_109;
				DBA.ExeSqlCommand($"UPDATE TBL_XWWL_Char SET FLD_YBXF='{元宝消费2}' WHERE FLD_NAME='{UserName}'", "GameServer");
			}
		}

		public void 钻石消费数据(int int_109, int int_110)
		{
			if (int_109 > 0)
			{
				if (int_110 == 0)
				{
					钻石消费 -= int_109;
					return;
				}
				钻石消费 += int_109;
				DBA.ExeSqlCommand($"UPDATE TBL_ACCOUNT SET FLD_YY='{钻石消费}' WHERE FLD_ID='{Userid}'", "rxjhaccount");
			}
		}

		public void 元宝消费存档(int int_109, int int_110)
		{
			if (int_109 > 0)
			{
				if (int_110 == 0)
				{
					元宝消费 -= int_109;
				}
				else
				{
					元宝消费 += int_109;
				}
			}
		}

		public void 钻石消费存档(int int_109, int int_110)
		{
			if (int_109 > 0)
			{
				if (int_110 == 0)
				{
					钻石消费 -= int_109;
				}
				else
				{
					钻石消费 += int_109;
				}
			}
		}

		public void 检察华夏币数据(int 元宝, int 类型)
		{
			if (元宝 > 0)
			{
				if (类型 == 0)
				{
					FLD_Coin -= 元宝;
				}
				else
				{
					FLD_Coin += 元宝;
				}
			}
		}

		public void 检察抽奖数据(int int_109, int int_110, string 来源)
		{
			if (int_109 > 0)
			{
				if (int_110 == 0)
				{
					FLD_CJCS -= int_109;
					系统提示("减少" + int_109 + "次抽奖，[" + DateTime.Now.ToString() + "]。", 22, 来源 ?? "");
					RxjhClass.元宝记录(Userid, UserName, "减少", 来源, "抽奖次数", int_110);
				}
				else
				{
					FLD_CJCS += int_109;
					系统提示("增加" + int_109 + "次抽奖，[" + DateTime.Now.ToString() + "]。", 22, 来源 ?? "");
					RxjhClass.元宝记录(Userid, UserName, "增加", 来源, "抽奖次数", int_110);
				}
			}
		}

		public void SaveGemData()
		{
			try
			{
				SqlParameter[] prams = new SqlParameter[14]
				{
					SqlDBA.MakeInParam("@id", SqlDbType.VarChar, 20, Userid),
					SqlDBA.MakeInParam("@rxpiont", SqlDbType.Int, 0, FLD_RXPIONT),
					SqlDBA.MakeInParam("@rxpiontx", SqlDbType.Int, 0, FLD_RXPIONTX),
					SqlDBA.MakeInParam("@coin", SqlDbType.Int, 0, FLD_Coin),
					SqlDBA.MakeInParam("@ybxf", SqlDbType.Int, 0, 元宝消费),
					SqlDBA.MakeInParam("@zsxf", SqlDbType.Int, 0, 钻石消费),
					SqlDBA.MakeInParam("@cjcs", SqlDbType.Int, 0, FLD_CJCS),
					SqlDBA.MakeInParam("@czyb", SqlDbType.Int, 0, 元宝充值),
					SqlDBA.MakeInParam("@czzs", SqlDbType.Int, 0, 钻石充值),
					SqlDBA.MakeInParam("@sccs", SqlDbType.Int, 0, FLD_首充次数),
					SqlDBA.MakeInParam("@zhsd", SqlDbType.Int, 0, 账号锁定),
					SqlDBA.MakeInParam("@safeword", SqlDbType.VarChar, 20, 游戏安全码),
					SqlDBA.MakeInParam("@zjf", SqlDbType.Int, 0, FLD_ZJF),
					SqlDBA.MakeInParam("@spreaderlv", SqlDbType.Int, 0, FLD_SPREADER_LEVEL)
				};
				World.SqlPool.Enqueue(new DbPoolClass
				{
					Conn = DBA.getstrConnection("rxjhaccount"),
					Prams = prams,
					Sql = "XWWL_UPDATE_RXPIONT"
				});
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存ID 元宝 数据出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
		}

		public void 保存会员数据()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE TBL_ACCOUNT SET FLD_VIP={1}, FLD_VIPTIM='{2}' WHERE FLD_ID='{0}'", Userid, 1, FLD_VIPTIM);
			if (DBA.ExeSqlCommand(stringBuilder.ToString(), "rxjhaccount") == -1)
			{
				MainForm.WriteLine(1, "保存ID会员数据出错[" + Userid + "]-[" + UserName + "]");
			}
		}

		public void 保存会员签到数据()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE TBL_ACCOUNT SET FLD_VIP={1}, FLD_TRANSFER_TIMES='{2}' WHERE FLD_ID='{0}'", Userid, 1, FLD_QDVIPTIM);
			if (DBA.ExeSqlCommand(stringBuilder.ToString(), "rxjhaccount") == -1)
			{
				MainForm.WriteLine(1, "保存ID签到数据出错[" + Userid + "]-[" + UserName + "]");
			}
		}

		public void 保存膜拜数据()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE TBL_ACCOUNT SET FLD_MACHINEID='{1}' WHERE FLD_ID='{0}'", Userid, FLD_MBVIPTIM);
			if (DBA.ExeSqlCommand(stringBuilder.ToString(), "rxjhaccount") == -1)
			{
				MainForm.WriteLine(1, "保存ID膜拜数据出错[" + Userid + "]-[" + UserName + "]");
			}
		}

		public void SavePlayerData()
		{
			try
			{
				if (UserName.Length != 0)
				{
					保存人物数据存储过程();
					保存个人仓库存储过程();
					保存综合仓库存储过程();
					保存宠物仓库存储过程();
					保存灵兽仓库存储过程();
					if (人物灵兽 != null)
					{
						人物灵兽.保存数据();
					}
					存档时间 = true;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
		}

		public void 保存帮派数据()
		{
			try
			{
				if (UserName.Length != 0 && 帮派Id != 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendFormat("UPDATE TBL_XWWL_GuildMember SET FLD_LEVEL = @zw WHERE FLD_NAME = @Username");
					SqlParameter[] prams = new SqlParameter[2]
					{
						SqlDBA.MakeInParam("@zw", SqlDbType.Int, 0, Player_Level),
						SqlDBA.MakeInParam("@Username", SqlDbType.VarChar, 30, UserName)
					};
					if (DBA.ExeSqlCommand(stringBuilder.ToString(), prams) == -1)
					{
						MainForm.WriteLine(3, "保存人物帮派等级数据出错1[" + Userid + "]-[" + UserName + "]");
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存人物帮派等级数据出错2[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
		}

		public byte[] Get时间药品byte()
		{
			byte[] array = new byte[320];
			try
			{
				int num = 0;
				foreach (时间药品类 value in 时间药品.Values)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(value.药品ID), 0, array, num * 8, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.时间), 0, array, num * 8 + 4, 4);
					num++;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get时间药品byte[" + Userid + "]-[" + UserName + "][" + 时间药品.Count + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get称号药品byte()
		{
			byte[] array = new byte[320];
			try
			{
				int num = 0;
				foreach (称号药品类 value in 称号药品.Values)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(value.药品ID), 0, array, num * 8, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.时间), 0, array, num * 8 + 4, 4);
					num++;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get称号药品byte[" + Userid + "]-[" + UserName + "][" + 称号药品.Count + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get特殊药品byte()
		{
			byte[] array = new byte[320];
			try
			{
				int num = 0;
				foreach (特殊药品类 value in 特殊药品.Values)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(value.药品ID), 0, array, num * 8, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.时间), 0, array, num * 8 + 4, 4);
					num++;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get特殊药品byte[" + Userid + "]-[" + UserName + "][" + 特殊药品.Count + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get任务byte()
		{
			using 发包类 发包类 = new 发包类();
			try
			{
				if (任务 == null)
				{
					return new byte[1200];
				}
				foreach (任务类 value in 任务.Values)
				{
					发包类.Write2(value.任务ID);
					发包类.Write2(value.任务阶段ID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get任务byte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return 发包类.ToArray3();
		}

		public byte[] Get土灵符byte()
		{
			byte[] array = new byte[1200];
			try
			{
				foreach (DictionaryEntry item in 土灵符坐标)
				{
					坐标Class 坐标Class2 = (坐标Class)item.Value;
					int num = (int)item.Key;
					if (num >= 10)
					{
						Buffer.BlockCopy(Encoding.Default.GetBytes(坐标Class2.Rxjh_name), 0, array, (num - 10) * 32, Encoding.Default.GetBytes(坐标Class2.Rxjh_name).Length);
						Buffer.BlockCopy(BitConverter.GetBytes(坐标Class2.Rxjh_Map), 0, array, (num - 10) * 32 + 15, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(坐标Class2.Rxjh_X), 0, array, (num - 10) * 32 + 19, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(坐标Class2.Rxjh_Y), 0, array, (num - 10) * 32 + 23, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(坐标Class2.Rxjh_Z), 0, array, (num - 10) * 32 + 27, 4);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get土灵符byte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get个人药品byte()
		{
			int num = 0;
			byte[] array = new byte[320];
			try
			{
				if (追加状态列表 == null)
				{
					return array;
				}
				foreach (追加状态类 value in 追加状态列表.Values)
				{
					if (value.FLD_RESIDE1 == 1)
					{
						if (num > 39)
						{
							break;
						}
						Buffer.BlockCopy(BitConverter.GetBytes(value.FLD_PID), 0, array, num * 8, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(value.FLD_sj), 0, array, num * 8 + 4, 4);
						num++;
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get个人药品byte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get个人药品Newbyte()
		{
			int num = 0;
			byte[] array = new byte[240];
			try
			{
				if (追加状态New列表 == null)
				{
					return array;
				}
				foreach (追加状态New类 value in 追加状态New列表.Values)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(value.FLD_PID), 0, array, num * 16, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.FLD_sj), 0, array, num * 16 + 4, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.数量), 0, array, num * 16 + 8, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.数量类型), 0, array, num * 16 + 12, 4);
					num++;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get个人药品Newbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get灵宠仓库byte()
		{
			byte[] array = new byte[World.数据库单个物品大小 * 20];
			try
			{
				for (int i = 0; i < 20; i++)
				{
					try
					{
						byte[] 物品_byte = 灵宠仓库[i].物品_byte;
						Buffer.BlockCopy(物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						byte[] src = new byte[World.数据库单个物品大小];
						Buffer.BlockCopy(src, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get灵宠仓库byte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get灵兽仓库byte()
		{
			byte[] array = new byte[World.数据库单个物品大小 * 2];
			try
			{
				for (int i = 0; i < 2; i++)
				{
					try
					{
						byte[] 物品_byte = 灵兽仓库[i].物品_byte;
						Buffer.BlockCopy(物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						byte[] src = new byte[World.数据库单个物品大小];
						Buffer.BlockCopy(src, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get灵宠仓库byte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get个人仓库byte()
		{
			byte[] array = new byte[4620];
			try
			{
				for (int i = 0; i < 60; i++)
				{
					try
					{
						Buffer.BlockCopy(个人仓库[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						Buffer.BlockCopy(new byte[World.数据库单个物品大小], 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get个人仓库byte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get综合仓库byte()
		{
			byte[] array = new byte[4620];
			try
			{
				for (int i = 0; i < 60; i++)
				{
					try
					{
						Buffer.BlockCopy(公共仓库[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						Buffer.BlockCopy(new byte[World.数据库单个物品大小], 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get综合仓库byte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] Get综合仓库品byte()
		{
			byte[] array = new byte[16];
			try
			{
				if (公有药品 == null)
				{
					return array;
				}
				int num = 0;
				foreach (公有药品类 value in 公有药品.Values)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(value.药品ID), 0, array, num * 8, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.时间), 0, array, num * 8 + 4, 4);
					num++;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get综合仓库品byte[" + Userid + "]-[" + UserName + "][" + 公有药品.Count + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetWgCodesbyte()
		{
			byte[] array = new byte[20];
			try
			{
				for (int i = 0; i < 12; i++)
				{
					byte[] src;
					try
					{
						src = 气功[i].气功_byte;
					}
					catch
					{
						src = new byte[2];
					}
					Buffer.BlockCopy(src, 0, array, i, 1);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetWgCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetFZITEMCodesbyte()
		{
			byte[] array = new byte[1500];
			try
			{
				for (int i = 0; i < 15; i++)
				{
					try
					{
						Buffer.BlockCopy(辅助装备栏装备[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						Buffer.BlockCopy(new byte[World.数据库单个物品大小], 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
				return array;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetWEARITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
				return array;
			}
		}

		public byte[] GetBZITEMCodesbyte()
		{
			byte[] array = new byte[1500];
			try
			{
				for (int i = 0; i < 15; i++)
				{
					try
					{
						Buffer.BlockCopy(宝珠装备栏装备[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						Buffer.BlockCopy(new byte[World.数据库单个物品大小], 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
				return array;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetWEARITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
				return array;
			}
		}

		public byte[] GetWEARITEMCodesbyte()
		{
			byte[] array = new byte[3650];
			try
			{
				for (int i = 0; i < 17; i++)
				{
					try
					{
						Buffer.BlockCopy(装备栏已穿装备[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						Buffer.BlockCopy(new byte[World.数据库单个物品大小], 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetWEARITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetFLD_ITEMHNCodesbyte()
		{
			byte[] array = new byte[219];
			try
			{
				for (int i = 0; i < 3; i++)
				{
					try
					{
						Buffer.BlockCopy(行囊包裹[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						byte[] src = new byte[World.数据库单个物品大小];
						Buffer.BlockCopy(src, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
				return array;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetFLD_ITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetFLD_ITEMZHHNCodesbyte()
		{
			byte[] array = new byte[1752];
			try
			{
				for (int i = 0; i < 24; i++)
				{
					try
					{
						Buffer.BlockCopy(杂货行囊包裹[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						byte[] src = new byte[World.数据库单个物品大小];
						Buffer.BlockCopy(src, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
				return array;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetFLD_ITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetFLD_ITEMNSZCodesbyte()
		{
			byte[] array = new byte[World.数据库单个物品大小 * 6];
			try
			{
				for (int i = 0; i < 6; i++)
				{
					try
					{
						Buffer.BlockCopy(凝神珠包裹[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						byte[] src = new byte[World.数据库单个物品大小];
						Buffer.BlockCopy(src, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
				return array;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetFLD_ITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetFLD_ITEMCodesbyte()
		{
			byte[] array = new byte[8000];
			try
			{
				for (int i = 0; i < 96; i++)
				{
					try
					{
						Buffer.BlockCopy(装备栏包裹[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						Buffer.BlockCopy(new byte[World.数据库单个物品大小], 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetFLD_ITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetFLD_FASHION_ITEMCodesbyte()
		{
			byte[] array = new byte[5640];
			try
			{
				for (int i = 0; i < 60; i++)
				{
					try
					{
						Buffer.BlockCopy(披风行囊[i].物品_byte, 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
					catch
					{
						Buffer.BlockCopy(new byte[World.数据库单个物品大小], 0, array, i * World.数据库单个物品大小, World.数据库单个物品大小);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetFLD_FASHION_ITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetQuestITEMCodesbyte()
		{
			byte[] array = new byte[288];
			try
			{
				for (int i = 0; i < 36; i++)
				{
					try
					{
						Buffer.BlockCopy(任务物品[i].物品_byte, 0, array, i * 8, 8);
					}
					catch
					{
						Buffer.BlockCopy(new byte[8], 0, array, i * 8, 8);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错GetQuestITEMCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return array;
		}

		public byte[] GetFLD_KONGFUCodesbyte()
		{
			using 发包类 发包类 = new 发包类();
			try
			{
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 32; j++)
					{
						if (武功新[i, j] != null)
						{
							发包类.Write4(武功新[i, j].FLD_PID);
							发包类.Write4(武功新[i, j].武功_等级);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_GetFLD_KONGFUCodesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return 发包类.ToArray3();
		}

		public byte[] Get升天武功Codesbyte()
		{
			using 发包类 发包类 = new 发包类();
			try
			{
				for (int i = 0; i < 32; i++)
				{
					if (武功新[3, i] != null)
					{
						发包类.Write4(武功新[3, i].FLD_PID);
						发包类.Write4(武功新[3, i].武功_等级);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get升天武功Codesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return 发包类.ToArray3();
		}

		public byte[] Get升天气功Codesbyte()
		{
			using 发包类 发包类 = new 发包类();
			try
			{
				foreach (升天气功类 value in 升天气功.Values)
				{
					发包类.Write2(value.气功ID);
					发包类.Write2(value.气功量);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "保存的数据出错_Get升天气功odesbyte[" + Userid + "]-[" + UserName + "]" + ex.Message);
			}
			return 发包类.ToArray3();
		}

		public void 地面物品增加(byte[] itme, float x, float y, float z)
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write4(1);
				发包类.Write(itme, 0, 16);
				发包类.Write(x);
				发包类.Write(15f);
				发包类.Write(y);
				发包类.Write(itme, 16, 60);
				if (Client != null)
				{
					Client.SendPak(发包类, 29184, 9999);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "地面物品增加数据113 出错" + Client.WorldId + "|" + Client.ToString() + " " + ex);
			}
		}

		public void 地面物品增加(ConcurrentDictionary<long, 地面物品类> Itmes)
		{
			try
			{
				if (Itmes == null || Itmes.Count <= 0)
				{
					return;
				}
				using 发包类 发包类 = new 发包类();
				发包类.Write4(Itmes.Count);
				foreach (地面物品类 value in Itmes.Values)
				{
					发包类.Write(value.物品_byte, 0, 12);
					发包类.Write4(0);
					发包类.Write(value.物品_byte, 12, 4);
					发包类.Write(value.Rxjh_X);
					发包类.Write(15f);
					发包类.Write(value.Rxjh_Y);
					发包类.Write(value.物品_byte, 16, 56);
				}
				if (Client != null)
				{
					Client.SendPak(发包类, 29184, 人物全服ID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "地面物品增加数据 出错" + Client.WorldId + "|" + Client.ToString() + " " + ex);
			}
		}

		public void 地面物品消失(long 全局ID)
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write8(全局ID);
				if (Client != null)
				{
					Client.SendPak(发包类, 29440, 人物全服ID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "地面物品消失数据 出错" + Client.WorldId + "|" + Client.ToString() + " " + ex);
			}
		}

		public bool 得到更新人物数据(Players Play, 发包类 发包类)
		{
			try
			{
				if (Play == null)
				{
					return false;
				}
				if (Play.Client == null)
				{
					return false;
				}
				发包类.Write4(1);
				发包类.Write4(Play.人物全服ID);
				发包类.WriteName(Play.UserName);
				发包类.Write4(Play.帮派Id);
				发包类.WriteName(Play.帮派名字);
				发包类.Write(Play.帮派人物等级);
				if (Play.帮派门徽 != null)
				{
					发包类.Write2(World.服务器组ID);
				}
				else
				{
					发包类.Write2(0);
				}
				发包类.Write(Play.Player_Zx);
				发包类.Write(Play.Player_Level);
				发包类.Write(Play.Player_Job_leve);
				发包类.Write(Play.Player_Job);
				发包类.Write(0);
				发包类.Write2(Play.New人物模版.发色);
				发包类.Write2(Play.New人物模版.发型);
				发包类.Write2(0);
				发包类.Write2(0);
				发包类.Write2(0);
				发包类.Write2(Play.New人物模版.脸型);
				发包类.Write(Play.New人物模版.声音);
				发包类.Write(Play.New人物模版.性别);
				发包类.Write(Play.人物坐标_X);
				if (Play.飞行模式 == 0)
				{
					发包类.Write(Play.人物坐标_Z);
				}
				else
				{
					发包类.Write(270f);
				}
				发包类.Write(Play.人物坐标_Y);
				发包类.Write4(Play.人物坐标_地图);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[0].物品ID, 0));
				发包类.Write4(0);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[1].物品ID, 0));
				发包类.Write4(0);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[2].物品ID, 0));
				发包类.Write4(0);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[4].物品ID, 0));
				发包类.Write4(0);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[3].物品ID, 0));
				发包类.Write4(0);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[5].物品ID, 0));
				发包类.Write4(0);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[9].物品ID, 0));
				发包类.Write4(0);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[10].物品ID, 0));
				发包类.Write4(0);
				if (Play.人物坐标_地图 != 9001 && Play.人物坐标_地图 != 9101 && Play.人物坐标_地图 != 9201)
				{
					发包类.Write(Play.装备栏已穿装备[3].FLD_强化数量);
				}
				else
				{
					发包类.Write(0);
				}
				if (Play.人物坐标_地图 == 41001)
				{
					if (Play.仙魔大战派别 == "仙族")
					{
						if (Play.Player_Sex == 1)
						{
							发包类.Write4(16900001);
						}
						else
						{
							发包类.Write4(26900075);
						}
					}
					else if (Play.Player_Sex == 1)
					{
						发包类.Write4(16900672);
					}
					else
					{
						发包类.Write4(26900672);
					}
				}
				else
				{
					发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[11].物品ID, 0));
				}
				发包类.Write4(0);
				int num = ConfigClass.GetConfig(Play.Config, Play.人物坐标_地图);
				if (Play.追加状态列表 != null && Play.追加状态列表.ContainsKey(700014))
				{
					num += 8;
				}
				发包类.Write(num);
				if (Play.Player_Job == 7)
				{
					if (Play.追加状态列表 != null)
					{
						if (Play.追加状态列表.ContainsKey(900401))
						{
							发包类.Write(18);
						}
						else if (Play.追加状态列表.ContainsKey(900402))
						{
							发包类.Write(34);
						}
						else if (Play.追加状态列表.ContainsKey(900403))
						{
							发包类.Write(66);
						}
						else if (Play.Config.武勋开关 == 90 && (Play.称号药品.ContainsKey(1008001478) || Play.称号药品.ContainsKey(1008001479)))
						{
							发包类.Write(8);
						}
						else if (Play.Config.武勋开关 != 0)
						{
							发包类.Write(1);
						}
						else
						{
							发包类.Write(0);
						}
					}
					else if (Play.Config.武勋开关 == 90 && (Play.称号药品.ContainsKey(1008001478) || Play.称号药品.ContainsKey(1008001479)))
					{
						if (Play.Config.头发开关 != 1 && Play.Config.头发开关 != 0)
						{
							发包类.Write(136);
						}
						else
						{
							发包类.Write(8);
						}
					}
					else if (Play.Config.武勋开关 != 0)
					{
						if (Play.Config.头发开关 != 1 && Play.Config.头发开关 != 0)
						{
							发包类.Write(129);
						}
						else
						{
							发包类.Write(1);
						}
					}
					else if (Play.Config.武勋开关 == 0)
					{
						if (Play.Config.头发开关 != 1 && Play.Config.头发开关 != 0)
						{
							发包类.Write(128);
						}
						else
						{
							发包类.Write(0);
						}
					}
					else
					{
						发包类.Write(0);
					}
				}
				else if (Play.Config.武勋开关 == 90 && (Play.称号药品.ContainsKey(1008001478) || Play.称号药品.ContainsKey(1008001479)))
				{
					if (Play.Config.头发开关 != 1 && Play.Config.头发开关 != 0)
					{
						发包类.Write(136);
					}
					else
					{
						发包类.Write(8);
					}
				}
				else if (Play.Config.武勋开关 != 0)
				{
					if (Play.Config.头发开关 != 1 && Play.Config.头发开关 != 0)
					{
						发包类.Write(129);
					}
					else
					{
						发包类.Write(1);
					}
				}
				else if (Play.Config.武勋开关 == 0)
				{
					if (Play.Config.头发开关 != 1 && Play.Config.头发开关 != 0)
					{
						发包类.Write(128);
					}
					else
					{
						发包类.Write(0);
					}
				}
				else
				{
					发包类.Write(0);
				}
				发包类.Write2(琴师状态);
				发包类.Write(Play.人物坐标_X);
				if (Play.飞行模式 == 0)
				{
					发包类.Write(Play.人物坐标_Z);
				}
				else
				{
					发包类.Write(270f);
				}
				发包类.Write(Play.人物坐标_Y);
				发包类.Write4(0);
				if (Play.人物灵兽 != null)
				{
					if (Play.人物灵兽.骑 == 1)
					{
						发包类.Write4(3);
					}
					else
					{
						发包类.Write4(0);
					}
				}
				else
				{
					发包类.Write4(255);
				}
				发包类.Write(0);
				发包类.Write4(BitConverter.ToInt32(Play.装备栏已穿装备[13].物品ID, 0));
				发包类.Write4(0);
				发包类.Write2(0);
				发包类.Write2(0);
				发包类.Write4(Play.Player_WuXun);
				if (Play.人物坐标_地图 == 41001 || Play.人物坐标_地图 == 801)
				{
					发包类.Write4(0);
				}
				else
				{
					发包类.Write4(Play.人物善恶);
				}
				发包类.Write2(0);
				if (Play.人物PK模式 != 0)
				{
					发包类.Write2(1);
				}
				else
				{
					发包类.Write2(0);
				}
				if (Play.追加状态列表 != null)
				{
					if (Play.追加状态列表.ContainsKey(1008000183))
					{
						发包类.Write4(2);
					}
					else if (Play.追加状态列表.ContainsKey(1008000156))
					{
						发包类.Write4(1);
					}
					else if (Play.追加状态列表.ContainsKey(1008000195))
					{
						发包类.Write4(4);
					}
					else if (Play.追加状态列表.ContainsKey(999000771))
					{
						发包类.Write4(4);
					}
					else if (Play.追加状态列表.ContainsKey(1008000187))
					{
						发包类.Write4(3);
					}
					else
					{
						发包类.Write4(0);
					}
				}
				else
				{
					发包类.Write4(0);
				}
				发包类.Write4(Play.潜行模式);
				if (Play.追加状态列表 != null)
				{
					if (Play.追加状态列表.ContainsKey(1008000188))
					{
						发包类.Write2(1);
					}
					else if (Play.追加状态列表.ContainsKey(1008000252))
					{
						发包类.Write2(20);
					}
					else if (Play.追加状态列表.ContainsKey(1008000245))
					{
						发包类.Write2(8);
					}
					else if (Play.追加状态列表.ContainsKey(999000770))
					{
						发包类.Write2(8);
					}
					else if (Play.追加状态列表.ContainsKey(1008000232))
					{
						发包类.Write2(6);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				else
				{
					发包类.Write2(0);
				}
				发包类.Write(Play.人物名字模版, 0, 16);
				发包类.Write(Play.人物名字模版, 16, 16);
				发包类.Write(Play.人物名字模版, 32, 16);
				发包类.Write(0);
				if (Play.Config.蔬菜武器开关 == 1)
				{
					if (Play.追加状态列表 != null)
					{
						if (Play.追加状态列表.ContainsKey(1008000240) || Play.追加状态列表.ContainsKey(1008000241) || Play.追加状态列表.ContainsKey(1008000242))
						{
							发包类.Write(1);
						}
						else if (Play.追加状态列表.ContainsKey(1008000250) || Play.追加状态列表.ContainsKey(1008000251))
						{
							发包类.Write(2);
						}
						else if (Play.追加状态列表.ContainsKey(1008000304) || Play.追加状态列表.ContainsKey(1008000305))
						{
							发包类.Write(3);
						}
						else if (Play.追加状态列表.ContainsKey(1008000306) || Play.追加状态列表.ContainsKey(1008000307))
						{
							发包类.Write(3);
						}
						else if (Play.追加状态列表.ContainsKey(1008000325) || Play.追加状态列表.ContainsKey(1008000326))
						{
							发包类.Write(4);
						}
						else if (Play.追加状态列表.ContainsKey(1008001111) || Play.追加状态列表.ContainsKey(1008001112) || Play.追加状态列表.ContainsKey(900000205))
						{
							发包类.Write(5);
						}
						else if (Play.追加状态列表.ContainsKey(1008002386) || Play.追加状态列表.ContainsKey(1008002385) || Play.追加状态列表.ContainsKey(900000206))
						{
							发包类.Write(6);
						}
						else
						{
							发包类.Write(0);
						}
					}
					else
					{
						发包类.Write4(0);
					}
				}
				else
				{
					发包类.Write(0);
				}
				发包类.Write(0);
				发包类.Write(0);
				发包类.Write(0);
				if (Play.FLD_情侣.Length != 0)
				{
					发包类.Write(1);
					发包类.WriteName(Play.FLD_情侣);
					if (Play.是否已婚 == 1)
					{
						发包类.Write2(Play.FLD_爱情度等级);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				else
				{
					发包类.Write(0);
					发包类.WriteName(string.Empty);
					发包类.Write2(0);
				}
				发包类.Write(0);
				发包类.Write(0);
				发包类.Write(0);
				发包类.Write(0);
				if (Play.人物坐标_地图 != 9001 && Play.人物坐标_地图 != 9101 && Play.人物坐标_地图 != 9201)
				{
					发包类.Write(Play.装备栏已穿装备[3].FLD_FJ_进化);
					发包类.Write(Play.装备栏已穿装备[3].FLD_属性类型);
					发包类.Write(Play.装备栏已穿装备[3].FLD_属性数量);
				}
				else
				{
					发包类.Write(0);
					发包类.Write(0);
					发包类.Write(0);
				}
				if (Play.人物坐标_地图 == 41001)
				{
					if (Play.仙魔大战派别 == "仙族")
					{
						发包类.Write2(1);
					}
					else
					{
						发包类.Write2(0);
					}
				}
				else
				{
					发包类.Write2(0);
				}
				if (Play.人物坐标_地图 != 9001 && Play.人物坐标_地图 != 9101 && Play.人物坐标_地图 != 9201)
				{
					发包类.Write4(Play.武勋阶段);
					发包类.Write2(Play.FLD_荣誉ID);
				}
				else
				{
					发包类.Write4(0);
					发包类.Write2(0);
				}
				if (Play.人物坐标_地图 == 41001 || Play.人物坐标_地图 == 801)
				{
					发包类.Write(0);
				}
				else if (Play.人物坐标_地图 != 9001 && Play.人物坐标_地图 != 9101 && Play.人物坐标_地图 != 9201)
				{
					if (Play.人物坐标_地图 == 7301)
					{
						if (Play.帮派人物等级 == 6)
						{
							发包类.Write(1);
						}
						else
						{
							发包类.Write(0);
						}
					}
					else if (Play.UserName == World.赞助大使名字)
					{
						if (Play.Player_Zx == 2)
						{
							发包类.Write(Play.称号排名);
						}
						else
						{
							发包类.Write(Play.称号排名);
						}
					}
					else
					{
						发包类.Write(Play.称号排名);
					}
				}
				else
				{
					发包类.Write(0);
				}
				发包类.Write2(Play.门派称号类型);
				if (Play.人物灵兽 != null)
				{
					if (Play.人物坐标_地图 != 9001 || Play.人物坐标_地图 != 9101 || Play.人物坐标_地图 != 9201)
					{
						发包类.Write(1);
						发包类.Write2(Play.人物灵兽全服ID);
						发包类.WriteString(Play.人物灵兽.Name, 16);
						发包类.Write4(0);
						发包类.Write(Play.人物灵兽.FLD_LEVEL);
						发包类.Write(Play.人物灵兽.FLD_JOB_LEVEL);
						发包类.Write(Play.人物灵兽.FLD_JOB);
						发包类.Write(Play.人物灵兽.Bs);
						发包类.Write(0);
						if (Play.人物灵兽.武功新[0, 3] != null)
						{
							发包类.Write4(Play.人物灵兽.武功新[0, 3].FLD_PID);
							发包类.Write(Play.人物灵兽.武功新[0, 3].FLD_INDEX);
						}
						else if (Play.人物灵兽.武功新[0, 2] != null)
						{
							发包类.Write4(Play.人物灵兽.武功新[0, 2].FLD_PID);
							发包类.Write(Play.人物灵兽.武功新[0, 2].FLD_INDEX);
						}
						else if (Play.人物灵兽.武功新[0, 1] != null)
						{
							发包类.Write4(Play.人物灵兽.武功新[0, 1].FLD_PID);
							发包类.Write(Play.人物灵兽.武功新[0, 1].FLD_INDEX);
						}
						else
						{
							发包类.Write4(0);
							发包类.Write(0);
						}
						发包类.Write(0);
						for (int i = 0; i < 5; i++)
						{
							if (Play.人物灵兽.宠物以装备[i].Get物品ID != 0)
							{
								发包类.Write4((int)Play.人物灵兽.宠物以装备[i].Get物品ID);
							}
							else
							{
								发包类.Write4(0);
							}
						}
						发包类.Write4(256);
					}
					else
					{
						发包类.Write(0);
						for (int j = 0; j < 14; j++)
						{
							发包类.Write4(0);
						}
						发包类.Write(0);
					}
				}
				else
				{
					发包类.Write(0);
					for (int k = 0; k < 14; k++)
					{
						发包类.Write4(0);
					}
					发包类.Write(0);
				}
				发包类.Write(0);
				发包类.Write(0);
				if (Play.检查烈日炎炎状态() && Play.检查毒蛇出洞状态() && Play.检查哀鸿遍野状态() && 检查致残状态())
				{
					发包类.Write(71);
				}
				else if (Play.检查毒蛇出洞状态() && Play.检查哀鸿遍野状态() && 检查致残状态())
				{
					发包类.Write(69);
				}
				else if (Play.检查烈日炎炎状态() && Play.检查毒蛇出洞状态() && Play.检查哀鸿遍野状态())
				{
					发包类.Write(7);
				}
				else if (Play.检查毒蛇出洞状态() && 检查致残状态())
				{
					发包类.Write(66);
				}
				else if (Play.检查哀鸿遍野状态() && 检查致残状态())
				{
					发包类.Write(68);
				}
				else if (Play.检查烈日炎炎状态() && 检查致残状态())
				{
					发包类.Write(65);
				}
				else if (Play.检查烈日炎炎状态() && Play.检查毒蛇出洞状态())
				{
					发包类.Write(3);
				}
				else if (Play.检查烈日炎炎状态() && Play.检查哀鸿遍野状态())
				{
					发包类.Write(5);
				}
				else if (Play.检查毒蛇出洞状态() && Play.检查哀鸿遍野状态())
				{
					发包类.Write(6);
				}
				else if (Play.检查致残状态())
				{
					发包类.Write(64);
				}
				else if (Play.检查烈日炎炎状态())
				{
					发包类.Write(1);
				}
				else if (Play.检查毒蛇出洞状态())
				{
					发包类.Write(2);
				}
				else if (Play.检查哀鸿遍野状态())
				{
					发包类.Write(4);
				}
				else
				{
					发包类.Write(0);
				}
				发包类.Write2(0);
				发包类.Write(0);
				if (Play.装备栏已穿装备[0].FLD_强化数量 == 15 && Play.装备栏已穿装备[1].FLD_强化数量 == 15 && Play.装备栏已穿装备[2].FLD_强化数量 == 15 && Play.装备栏已穿装备[3].FLD_强化数量 == 15 && Play.装备栏已穿装备[4].FLD_强化数量 == 15 && Play.装备栏已穿装备[5].FLD_强化数量 == 15)
				{
					发包类.Write(1);
				}
				else
				{
					发包类.Write(0);
				}
				发包类.Write(0);
				if (Play.人物坐标_地图 != 9001 && Play.人物坐标_地图 != 9101 && Play.人物坐标_地图 != 9201)
				{
					if (Play.装备栏已穿装备[3].FLD_强化数量 == 15)
					{
						发包类.Write(1);
					}
					else
					{
						发包类.Write(0);
					}
				}
				else
				{
					发包类.Write(0);
				}
				发包类.Write(0);
				发包类.Write(0);
				发包类.Write4(uint.MaxValue);
				if (Play.装备栏已穿装备[3].FLD_FJ_四神之力 != 0)
				{
					发包类.Write2(Play.装备栏已穿装备[3].FLD_FJ_四神之力);
				}
				else
				{
					发包类.Write2(0);
				}
				if (Play.装备栏已穿装备[0].FLD_FJ_四神之力 != 0)
				{
					发包类.Write2(Play.装备栏已穿装备[0].FLD_FJ_四神之力);
				}
				else
				{
					发包类.Write2(0);
				}
				int value = RNG.Next(1, 2);
				发包类.Write(0);
				发包类.Write(value);
				发包类.Write4((int)Play.装备栏已穿装备[15].Get物品ID);
				发包类.Write4(0);
				发包类.Write4(Play.装备栏已穿装备[15].FLD_MAGIC1);
				发包类.Write4(Play.装备栏已穿装备[15].属性1.属性数量);
				发包类.Write4(0);
				发包类.Write4(0);
				发包类.Write4(0);
				发包类.Write4(0);
				发包类.Write(new byte[32], 0, 32);
				发包类.Write(Play.飞行模式);
				发包类.Write4(Play.变身id);
				发包类.Write4(0);
				return true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到更新人物数据 出错" + Client.WorldId + "|" + Client.ToString() + " " + Converter.ToString(发包类.ToArray3()) + " " + ex);
				return false;
			}
		}

		public int get_荣誉ID(string Name, int Type)
		{
			try
			{
				switch (Type)
				{
				case 1:
				{
					for (int j = 0; j < World.势力排名数据.Count; j++)
					{
						if (World.势力排名数据[j].势力人物名 == Name)
						{
							int num2 = j + 1;
							if (1 == 0)
							{
							}
							int result = num2 switch
							{
								1 => 1008001240, 
								2 => 1008001241, 
								3 => 1008001242, 
								4 => 1008001243, 
								5 => 1008001244, 
								6 => 1008001245, 
								7 => 1008001246, 
								8 => 1008001247, 
								9 => 1008001248, 
								10 => 1008001249, 
								_ => 0, 
							};
							if (1 == 0)
							{
							}
							return result;
						}
					}
					break;
				}
				case 2:
				{
					for (int k = 0; k < World.武林排名数据.Count; k++)
					{
						if (World.武林排名数据[k].武林人物名 == Name)
						{
							int num3 = k + 1;
							if (1 == 0)
							{
							}
							int result = num3 switch
							{
								1 => 1008001290, 
								2 => 1008001291, 
								3 => 1008001292, 
								4 => 1008001293, 
								5 => 1008001294, 
								6 => 1008001295, 
								7 => 1008001296, 
								8 => 1008001297, 
								9 => 1008001298, 
								10 => 1008001299, 
								_ => 0, 
							};
							if (1 == 0)
							{
							}
							return result;
						}
					}
					break;
				}
				case 3:
				{
					for (int i = 0; i < World.杀人排行数据.Count; i++)
					{
						if (World.杀人排行数据[i].人物名 == Name)
						{
							int num = i + 1;
							if (1 == 0)
							{
							}
							int result = num switch
							{
								1 => 1008001250, 
								2 => 1008001251, 
								3 => 1008001252, 
								4 => 1008001253, 
								5 => 1008001254, 
								6 => 1008001255, 
								7 => 1008001256, 
								8 => 1008001257, 
								9 => 1008001258, 
								10 => 1008001259, 
								_ => 0, 
							};
							if (1 == 0)
							{
							}
							return result;
						}
					}
					break;
				}
				}
				return 0;
			}
			catch
			{
				return 0;
			}
		}

		public void 更新广播人物数据()
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				if (得到更新人物数据(Client.Player, 发包类))
				{
					发送当前范围广播数据(发包类, 25600, 人物全服ID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "更新广播人物数据 出错" + Client.WorldId + "|" + Client.ToString() + " " + ex);
			}
		}

		public void 头顶发光()
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA551E00DC0102311000DC0100000000000001000000FFEF0100000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 10, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
				发送当前范围广播数据(array, array.Length);
			}
			catch (Exception)
			{
			}
		}

		public void 头顶发光(Players Play)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA551E00DC0102311000DC0100000000000001000000FFEF0100000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(Play.人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(Play.人物全服ID), 0, array, 10, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
				发送当前范围广播数据(array, array.Length);
			}
			catch (Exception)
			{
			}
		}

		public void 更新人物数据(Players Play)
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				if (得到更新人物数据(Play, 发包类))
				{
					Client.SendPak(发包类, 25600, Play.人物全服ID);
					if (发包类.Length < 224)
					{
						string str = Converter.ToString(发包类.ToArray3());
						MainForm.WriteLine(100, "更新人物数据" + 发包类.Length + " " + str);
					}
					if (Play.个人商店 != null)
					{
						更新个人商店数据(Play);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "更新人物数据 出错" + Client.WorldId + "|" + Client.ToString() + " " + ex);
			}
		}

		public void 更新个人商店数据(Players Play)
		{
			if (!Play.个人商店.个人商店是否开启)
			{
				return;
			}
			using 发包类 发包类 = new 发包类();
			发包类.Write4(1);
			发包类.Write4(Play.人物全服ID);
			发包类.Write4(Play.人物全服ID);
			发包类.Write2((byte)Play.个人商店.商店名.Length);
			发包类.Write(Play.个人商店.商店名, 0, Play.个人商店.商店名.Length);
			if (Client != null)
			{
				Client.SendPak(发包类, 51712, 人物全服ID);
			}
		}

		public bool 检查红月狂风状态()
		{
			return GetAddState(1008001172);
		}

		public bool 检查哀鸿遍野状态()
		{
			return GetAddState(1008001176);
		}

		public bool 检查满月狂风状态()
		{
			return GetAddState(1008001171) || 怒;
		}

		public bool 检查毒蛇出洞状态()
		{
			return GetAddState(1008001170);
		}

		public bool 检查致残状态()
		{
			return GetAddState(1008002012);
		}

		public bool 检查烈日炎炎状态()
		{
			return GetAddState(1008001169);
		}

		public bool 检查长虹贯天状态()
		{
			return GetAddState(1008001173);
		}

		public bool 检查和弦状态()
		{
			return 追加状态列表.ContainsKey(900401) || 追加状态列表.ContainsKey(900402) || 追加状态列表.ContainsKey(900403);
		}

		public void 更换装备位置(int no, int noid, int to, int toid, byte[] itmeid, int sl)
		{
			try
			{
				int num = BitConverter.ToInt32(itmeid, 8);
				if (no == 1 && to == 0)
				{
					num = (int)装备栏已穿装备[toid].Get物品ID;
					if (装备栏已穿装备[toid].FLD_Intrgration == 1)
					{
						num -= 5000;
					}
				}
				byte[] array = Converter.hexStringToByte("AA55820098011B0074000100000001000003010000002F2724060000000042EEF80500000000010000000000000000030100640100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000E8030000000000000000000000000000000000000000000000000000000000000000000055AA");
				byte[] bytes = BitConverter.GetBytes(no);
				byte[] bytes2 = BitConverter.GetBytes(noid);
				byte[] bytes3 = BitConverter.GetBytes(to);
				byte[] bytes4 = BitConverter.GetBytes(toid);
				Buffer.BlockCopy(bytes, 0, array, 14, 2);
				Buffer.BlockCopy(bytes2, 0, array, 16, 2);
				Buffer.BlockCopy(bytes3, 0, array, 18, 2);
				Buffer.BlockCopy(bytes4, 0, array, 20, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(sl), 0, array, 22, 4);
				Buffer.BlockCopy(itmeid, 0, array, 26, 8);
				Buffer.BlockCopy(BitConverter.GetBytes((long)num), 0, array, 34, 8);
				Buffer.BlockCopy(BitConverter.GetBytes((long)sl), 0, array, 42, 8);
				Buffer.BlockCopy(bytes3, 0, array, 50, 2);
				Buffer.BlockCopy(bytes4, 0, array, 52, 2);
				array[53] = 0;
				array[54] = 3;
				array[54] = 1;
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
				MainForm.WriteLine(1, "更换装备位置出错");
			}
		}

		public void 增加物品3(byte[] 物品全局ID, byte[] 物品ID, int 位置, byte[] 数量, byte[] 物品属性)
		{
			try
			{
				if (!World.Itme.TryGetValue(BitConverter.ToInt32(物品ID, 0), out var value))
				{
					return;
				}
				byte[] array = Converter.hexStringToByte("AA557200940223006400010000008716E567818320060208AF2F000000000100000000000000010F020F00020000470D0300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000C3E755AA");
				byte[] array2 = new byte[World.数据库单个物品大小];
				if (value.FLD_SIDE != 0)
				{
					byte[] array3 = new byte[4];
					Buffer.BlockCopy(物品属性, 0, array3, 0, 4);
					物品类 物品类2 = 得到人物物品类型(BitConverter.ToInt32(物品ID, 0), BitConverter.ToInt32(array3, 0));
					if (BitConverter.ToInt32(物品ID, 0) == 1008000044 || BitConverter.ToInt32(物品ID, 0) == 1008000045)
					{
						物品全局ID = BitConverter.GetBytes(RxjhClass.GetDBItmeId());
						数量 = BitConverter.GetBytes(BitConverter.ToInt32(数量, 0));
					}
					else if (物品类2 != null)
					{
						位置 = 物品类2.物品位置;
						物品全局ID = 物品类2.物品全局ID;
						数量 = BitConverter.GetBytes(BitConverter.ToInt32(物品类2.物品数量, 0) + BitConverter.ToInt32(数量, 0));
					}
				}
				else
				{
					数量 = BitConverter.GetBytes(1);
				}
				Buffer.BlockCopy(物品全局ID, 0, array2, 0, 8);
				Buffer.BlockCopy(物品ID, 0, array2, 8, 4);
				Buffer.BlockCopy(数量, 0, array2, 12, 4);
				Buffer.BlockCopy(物品属性, 0, array2, 16, 物品属性.Length);
				Buffer.BlockCopy(BitConverter.GetBytes(位置), 0, array, 40, 2);
				Buffer.BlockCopy(array2, 0, array, 14, 12);
				Buffer.BlockCopy(array2, 12, array, 30, 4);
				Buffer.BlockCopy(array2, 16, array, 46, 物品属性.Length);
				装备栏包裹[位置].物品_byte = array2;
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "增加物品4出错 [" + Userid + "][" + UserName + "] 位置[" + 位置 + "] 数量[" + BitConverter.ToInt32(数量, 0) + "]" + ex.Message);
			}
		}

		public void 显示大字(int 对方ID, int id)
		{
			try
			{
				using 发包类 发包类 = new 发包类();
				发包类.Write4(对方ID);
				发包类.Write4(id);
				发包类.Write4(0);
				if (Client != null)
				{
					Client.SendPak(发包类, 35072, 人物全服ID);
					发送当前范围广播数据(发包类, 35072, 人物全服ID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "xsz出错!" + ex.Message);
			}
		}

		public void 物品使用(int 背包ID, int 位置, int 数量)
		{
			BitConverter.GetBytes(位置);
			BitConverter.GetBytes(数量);
			byte[] array = new byte[4];
			int num = BitConverter.ToInt32((背包ID != 1) ? 人物灵兽.宠物装备栏[位置].物品ID : 装备栏包裹[位置].物品ID, 0);
			if (背包ID == 1)
			{
				if (BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) <= 数量)
				{
					装备栏包裹[位置].物品_byte = new byte[World.数据库单个物品大小];
					BitConverter.GetBytes(0);
				}
				else
				{
					byte[] bytes = BitConverter.GetBytes(BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) - 数量);
					装备栏包裹[位置].物品数量 = bytes;
				}
			}
			else if (BitConverter.ToInt32(人物灵兽.宠物装备栏[位置].物品数量, 0) <= 数量)
			{
				人物灵兽.宠物装备栏[位置].物品_byte = new byte[World.数据库单个物品大小];
				BitConverter.GetBytes(0);
			}
			else
			{
				byte[] bytes2 = BitConverter.GetBytes(BitConverter.ToInt32(人物灵兽.宠物装备栏[位置].物品数量, 0) - 数量);
				人物灵兽.宠物装备栏[位置].物品数量 = bytes2;
			}
			using 发包类 发包类 = new 发包类();
			发包类.Write1(背包ID);
			发包类.Write1(位置);
			发包类.Write2(0);
			发包类.Write8(装备栏包裹[位置].Get物品ID);
			if (数量 == 0)
			{
				if (背包ID == 1)
				{
					发包类.Write4(装备栏包裹[位置].Get物品数量);
				}
				else
				{
					发包类.Write4(人物灵兽.宠物装备栏[位置].Get物品数量);
				}
			}
			else
			{
				发包类.Write4(数量);
			}
			if (背包ID == 1)
			{
				发包类.Write4(装备栏包裹[位置].Get物品数量);
			}
			else
			{
				发包类.Write4(人物灵兽.宠物装备栏[位置].Get物品数量);
			}
			if (背包ID == 1 && num == 1700101)
			{
				发包类.Write4(111);
			}
			else
			{
				发包类.Write4(0);
			}
			发包类.Write4(0);
			if (Client != null)
			{
				Client.SendPak(发包类, 15104, 人物全服ID);
			}
		}

		public void 物品使用1(int 背包ID, int 位置, int 数量)
		{
			BitConverter.GetBytes(位置);
			BitConverter.GetBytes(数量);
			byte[] array = new byte[4];
			int num = BitConverter.ToInt32((背包ID != 1) ? 人物灵兽.宠物装备栏[位置].物品ID : 装备栏包裹[位置].物品ID, 0);
			if (背包ID == 1)
			{
				if (BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) <= 数量)
				{
					装备栏包裹[位置].物品_byte = new byte[World.数据库单个物品大小];
					BitConverter.GetBytes(0);
				}
				else
				{
					byte[] bytes = BitConverter.GetBytes(BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) - 数量);
					装备栏包裹[位置].物品数量 = bytes;
				}
			}
			else if (BitConverter.ToInt32(人物灵兽.宠物装备栏[位置].物品数量, 0) <= 数量)
			{
				人物灵兽.宠物装备栏[位置].物品_byte = new byte[World.数据库单个物品大小];
				BitConverter.GetBytes(0);
			}
			else
			{
				byte[] bytes2 = BitConverter.GetBytes(BitConverter.ToInt32(人物灵兽.宠物装备栏[位置].物品数量, 0) - 数量);
				人物灵兽.宠物装备栏[位置].物品数量 = bytes2;
			}
			using 发包类 发包类 = new 发包类();
			发包类.Write1(背包ID);
			发包类.Write1(位置);
			发包类.Write2(0);
			发包类.Write8(装备栏包裹[位置].Get物品ID);
			if (数量 == 0)
			{
				if (背包ID == 1)
				{
					发包类.Write4(装备栏包裹[位置].Get物品数量);
				}
				else
				{
					发包类.Write4(人物灵兽.宠物装备栏[位置].Get物品数量);
				}
			}
			else
			{
				发包类.Write4(数量);
			}
			if (背包ID == 1)
			{
				发包类.Write4(装备栏包裹[位置].Get物品数量);
			}
			else
			{
				发包类.Write4(人物灵兽.宠物装备栏[位置].Get物品数量);
			}
			if (背包ID == 1 && num == 1700101)
			{
				发包类.Write4(111);
			}
			else
			{
				发包类.Write4(0);
			}
			发包类.Write4(0);
			if (Client != null)
			{
				Client.SendPak(发包类, 15104, 人物全服ID);
			}
		}

		public void 物品使用戒指(int 位置, int 数量, int 使用提示)
		{
			byte[] array = Converter.hexStringToByte("AA55220000003B001400010A000065CA9A3B010000006100000000000000000000000000000055AAA");
			Buffer.BlockCopy(BitConverter.GetBytes(位置), 0, array, 11, 2);
			Buffer.BlockCopy(装备栏包裹[位置].物品ID, 0, array, 14, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(使用提示), 0, array, 18, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(数量), 0, array, 22, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 物品使用千年雪参(int 位置, int 数量)
		{
			try
			{
				if (中毒)
				{
					数量 *= 2;
				}
				byte[] array = Converter.hexStringToByte("AA552B002C013B001C000105000065CA9A3B000000000100000009000000000000000000000000000000000000000055AA");
				byte[] array2 = new byte[4];
				Buffer.BlockCopy(装备栏包裹[位置].物品_byte, 20, array2, 0, 4);
				int num = BitConverter.ToInt32(array2, 0) - 2010000000 - 数量;
				Buffer.BlockCopy(BitConverter.GetBytes(位置), 0, array, 11, 2);
				Buffer.BlockCopy(装备栏包裹[位置].物品ID, 0, array, 14, 4);
				if (num <= 0)
				{
					if (BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) <= 1)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 26, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(2010000000), 0, array, 30, 4);
						装备栏包裹[位置].物品_byte = new byte[World.数据库单个物品大小];
					}
					else
					{
						int value = BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) - 1;
						装备栏包裹[位置].物品数量 = BitConverter.GetBytes(value);
						if (装备栏包裹[位置].Get物品ID == 1008000044 || 装备栏包裹[位置].Get物品ID == 1008000045)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2019999999), 0, 装备栏包裹[位置].物品_byte, 20, 4);
						}
						else if (装备栏包裹[位置].Get物品ID == 1008000003 || 装备栏包裹[位置].Get物品ID == 1008000006)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2011000000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
						}
						else if (装备栏包裹[位置].Get物品ID == 1008000007 || 装备栏包裹[位置].Get物品ID == 1008000008)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2010400000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
						}
						else if (装备栏包裹[位置].Get物品ID == 1008000068 || 装备栏包裹[位置].Get物品ID == 1008000069)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2011000000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
						}
						else
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2010600000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
						}
						Buffer.BlockCopy(装备栏包裹[位置].物品数量, 0, array, 26, 4);
						if (装备栏包裹[位置].Get物品ID == 1008000044 || 装备栏包裹[位置].Get物品ID == 1008000045)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2019999999), 0, array, 30, 4);
						}
						else if (装备栏包裹[位置].Get物品ID == 1008000003 || 装备栏包裹[位置].Get物品ID == 1008000006)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2011000000), 0, array, 30, 4);
						}
						else if (装备栏包裹[位置].Get物品ID == 1008000007 || 装备栏包裹[位置].Get物品ID == 1008000008)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2010400000), 0, array, 30, 4);
						}
						else if (装备栏包裹[位置].Get物品ID == 1008000068 || 装备栏包裹[位置].Get物品ID == 1008000069)
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2011000000), 0, array, 30, 4);
						}
						else
						{
							Buffer.BlockCopy(BitConverter.GetBytes(2010600000), 0, array, 30, 4);
						}
					}
				}
				else
				{
					Buffer.BlockCopy(BitConverter.GetBytes(num + 2010000000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
					Buffer.BlockCopy(装备栏包裹[位置].物品数量, 0, array, 26, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(num + 2010000000), 0, array, 30, 4);
				}
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 物品使用无双九转丹(int 位置, int 数量)
		{
			try
			{
				if (中毒)
				{
					数量 *= 2;
				}
				byte[] array = Converter.hexStringToByte("AA552200FF033B001C00010000004DDC143C000000000100000001000000923192410000000055AA");
				byte[] array2 = new byte[4];
				Buffer.BlockCopy(装备栏包裹[位置].物品_byte, 20, array2, 0, 4);
				int num = (int)(((装备栏包裹[位置].Get物品ID != 1008000077) ? (((double)((BitConverter.ToInt32(array2, 0) - 1100000000) / 100 * 人物最大_HP) - (double)数量) / (double)(1000 * 人物最大_HP)) : (((double)((BitConverter.ToInt32(array2, 0) - 1100000000) / 100 * 人物最大_HP) - (double)数量) / (double)(1000 * 人物最大_HP))) * 100000.0);
				Buffer.BlockCopy(BitConverter.GetBytes(位置), 0, array, 11, 2);
				Buffer.BlockCopy(装备栏包裹[位置].物品ID, 0, array, 14, 4);
				if (num <= 0)
				{
					if (BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) <= 1)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 26, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(1100000000), 0, array, 30, 4);
						装备栏包裹[位置].物品_byte = new byte[World.数据库单个物品大小];
					}
					else
					{
						int value = BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) - 1;
						装备栏包裹[位置].物品数量 = BitConverter.GetBytes(value);
						Buffer.BlockCopy(BitConverter.GetBytes(1100100000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
						Buffer.BlockCopy(装备栏包裹[位置].物品数量, 0, array, 26, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(1100100000), 0, array, 30, 4);
					}
				}
				else
				{
					Buffer.BlockCopy(BitConverter.GetBytes(num + 1100000000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
					Buffer.BlockCopy(装备栏包裹[位置].物品数量, 0, array, 26, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(num + 1100000000), 0, array, 30, 4);
				}
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 物品使用无双千年雪参(int 位置, int 数量)
		{
			try
			{
				if (中毒)
				{
					数量 *= 2;
				}
				byte[] array = Converter.hexStringToByte("AA552200FF033B001C00010000004DDC143C000000000100000001000000923192410000000055AA");
				byte[] array2 = new byte[4];
				Buffer.BlockCopy(装备栏包裹[位置].物品_byte, 20, array2, 0, 4);
				int num = (int)(((装备栏包裹[位置].Get物品ID != 1008000078) ? (((double)((BitConverter.ToInt32(array2, 0) - 1110000000) / 100 * 人物最大_MP) - (double)数量) / (double)(1000 * 人物最大_MP)) : (((double)((BitConverter.ToInt32(array2, 0) - 1110000000) / 100 * 人物最大_MP) - (double)数量) / (double)(1000 * 人物最大_MP))) * 100000.0);
				Buffer.BlockCopy(BitConverter.GetBytes(位置), 0, array, 11, 2);
				Buffer.BlockCopy(装备栏包裹[位置].物品ID, 0, array, 14, 4);
				if (num <= 0)
				{
					if (BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) <= 1)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 26, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(1110000000), 0, array, 30, 4);
						装备栏包裹[位置].物品_byte = new byte[World.数据库单个物品大小];
					}
					else
					{
						int value = BitConverter.ToInt32(装备栏包裹[位置].物品数量, 0) - 1;
						装备栏包裹[位置].物品数量 = BitConverter.GetBytes(value);
						Buffer.BlockCopy(BitConverter.GetBytes(1110100000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
						Buffer.BlockCopy(装备栏包裹[位置].物品数量, 0, array, 26, 4);
						Buffer.BlockCopy(BitConverter.GetBytes(1110100000), 0, array, 30, 4);
					}
				}
				else
				{
					Buffer.BlockCopy(BitConverter.GetBytes(num + 1110000000), 0, 装备栏包裹[位置].物品_byte, 20, 4);
					Buffer.BlockCopy(装备栏包裹[位置].物品数量, 0, array, 26, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(num + 1110000000), 0, array, 30, 4);
				}
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送门徽2(byte[] _门徽, int id)
		{
			byte[] array = Converter.hexStringToByte("AA5518030A00EB000A036A42020001000100FF00FFFF00FF0000FF0000FFFF00FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFF80FF00FFFFFF80FFFF80FFFF80FFFF80FF00FFFF00FF0000FF0000FF0000FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFF80FF00FFFFFF80FFFF80FFFF80FFFF80FF00FFFF00FF0000FFFF00FF0000FFFF00FF0000FFFF00FFFF00FFFFFF80FF00FFFFFF80FFFF80FFFF80FF00FFFFFF80FF00FFFF00FF0000FFFF00FF0000FFFF00FF0000FFFF00FFFF00FFFFFF80FFFF80FFFF80FFFF80FF00FFFFFF80FFFF80FF00FFFF00FF0000FFFF00FF0000FF0000FF0000FFFF00FFFF00FFFFFF80FFFF80FFFF80FFFF80FF00FFFFFF80FFFF80FF00FFFF00FF0000FFFF00FFFF00FF0000FF0000FF0000FFFFFF80FFFF80FFFF80FFFF80FFFF80FFFF80FFFF80FF00FFFF00FFFF00FF0000FFFF00FFFF00FF0000FFFF00FF0000FFFFFF80FFFF80FF0000FFFF80FFFF80FFFF80FFFF80FF0000FF00FFFF0000FF0000FF0000FF0000FF0000FF0000FFFF80FFFF80FF0000FF0000FFFF80FFFF80FFFF80FF00FFFF00FFFF00FFFF00FFFF0000FF0000FF0000FF0000FFFF80FF0000FFFF80FF0000FF0000FFFF80FFFF80FFFF80FF0000FF0000FF0000FF0000FF0000FF0000FF0000FFFF80FF0000FF0000FFFF80FF0000FF0000FFFF80FFFF80FF0000FF0000FF0000FF00FFFF00FF0000FFFF00FFFFFF80FF00FFFF00FF0000FFFFFF80FF00FFFFFF80FFFF80FF0000FF0000FF00FFFF00FFFF0000FF0000FFFF80FFFF80FF0000FF0000FF0000FF0000FFFF80FFFF80FF0000FF0000FF0000FF0000FF0000FF0000FF00FFFF00FF0000FFFF00FFFF00FFFF00FFFF00FFFF00FFFFFF80FF00FFFF0000FF0000FF0000FF0000FF0000FF00FFFF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FFFF80FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF00FFFF00FFFF00FFFF00FFFF00FFFF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF0000FF00000000000000000000BC6F55AA");
			Buffer.BlockCopy(_门徽, 0, array, 18, _门徽.Length);
			Buffer.BlockCopy(BitConverter.GetBytes(id), 0, array, 10, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(World.服务器组ID), 0, array, 16, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 更新攻击速度()
		{
			byte[] array = Converter.hexStringToByte("AA551A00B20206200C00060000008801580064000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(FLD_攻击速度), 0, array, 18, 4);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
			发送当前范围广播数据(array, array.Length);
		}

		public void 发送激活技能数据(int 武功PID, int id)
		{
			byte[] array = Converter.hexStringToByte("AA552E00A2013D00200026B706000100000000000000000000000000000000000000E803000001000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(武功PID), 0, array, 10, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(id), 0, array, 14, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (当前激活技能ID == 0)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 38, 2);
			}
			else
			{
				Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 38, 2);
			}
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 解除召唤(Players TOPlaye, Players Playe)
		{
			byte[] array = Converter.hexStringToByte("AA551600549C6300080001000000549C0001000000000000A37B55AA");
			Buffer.BlockCopy(BitConverter.GetBytes(Playe.人物灵兽.全服ID), 0, array, 14, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(TOPlaye.人物全服ID), 0, array, 4, 2);
			if (TOPlaye.Client != null)
			{
				TOPlaye.Client.Send多包(array, array.Length);
			}
			发送当前范围广播数据(array, array.Length);
		}

		public void 解除召唤2(Players TOPlaye, Players Playe)
		{
			byte[] array = Converter.hexStringToByte("AA551600549C6300080001000000549C0001000000000000A37B55AA");
			Buffer.BlockCopy(BitConverter.GetBytes(Playe.人物灵兽.全服ID), 0, array, 14, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(TOPlaye.人物全服ID), 0, array, 4, 2);
			if (TOPlaye.Client != null)
			{
				TOPlaye.Client.Send多包(array, array.Length);
			}
		}

		public void 离开当前地图(Players Playe, Players ToPlaye)
		{
			try
			{
				using (发包类 发包类 = new 发包类())
				{
					发包类.Write4(1);
					发包类.Write4(ToPlaye.人物全服ID);
					if (Playe.Client != null)
					{
						Playe.Client.SendPak(发包类, 25344, Playe.人物全服ID);
					}
				}
				if (ToPlaye.人物灵兽 != null)
				{
					解除召唤2(Playe, ToPlaye);
				}
			}
			catch
			{
			}
		}

		public void 发送组队消息广播数据(byte[] data, int length, ConcurrentDictionary<int, Players> 组队列表)
		{
			try
			{
				foreach (Players value in 组队列表.Values)
				{
					if (World.AllConnectedPlayers.ContainsKey(value.人物全服ID) && value.Client != null)
					{
						value.Client.Send(data, length);
					}
				}
			}
			catch
			{
			}
		}

		public void 发送传音消息数据(byte[] Msg, int Length, string name, string msg, int msgType)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (!(value.UserName == name))
					{
						continue;
					}
					if (value.Config.传音 == 0)
					{
						系统提示("对方设置不容许传音。");
						break;
					}
					if (Client != null)
					{
						Client.Send(Msg, Length);
					}
					发送传音消息(value, msg, msgType);
					break;
				}
			}
			catch
			{
			}
		}

		public void 发送传音消息(Players ToPlaye, string msg, int msgType)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA55A50000006600970000000000000000000000000000000000000000000000003000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				array[10] = (byte)msgType;
				byte[] bytes = Encoding.Default.GetBytes(UserName);
				byte[] bytes2 = Encoding.Default.GetBytes(msg);
				Buffer.BlockCopy(bytes2, 0, array, 35, bytes2.Length);
				Buffer.BlockCopy(bytes, 0, array, 12, bytes.Length);
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (ToPlaye.Client != null)
				{
					ToPlaye.Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送传音消息(string name, int PID, Players ToPlaye, string msg, int msgType)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA55A50000006600970000000000000000000000000000000000000000000000003000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				array[10] = (byte)msgType;
				byte[] bytes = Encoding.Default.GetBytes(name);
				byte[] bytes2 = Encoding.Default.GetBytes(msg);
				Buffer.BlockCopy(bytes2, 0, array, 35, bytes2.Length);
				Buffer.BlockCopy(bytes, 0, array, 12, bytes.Length);
				Buffer.BlockCopy(BitConverter.GetBytes(PID), 0, array, 4, 2);
				if (ToPlaye.Client != null)
				{
					ToPlaye.Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送仙魔大战邀请新()
		{
			byte[] array = Converter.hexStringToByte("AA5536000F2713223000010001005C00000001000000010000000600000006000000330E0000320000000000000000000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 22, 1);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 仙魔大战复活选择()
		{
			byte[] array = Converter.hexStringToByte("AA552E000F2713222000010001000A000000010000000400000005000000050000000000000000000000000000000000153555AA");
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 发送其他活动开始倒计时(int kssjint)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA552E000F2713222000090001000B000000010000000C0000002101000000000000000000000000000000000000000002EE55AA");
				Buffer.BlockCopy(BitConverter.GetBytes(kssjint), 0, array, 26, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送仙魔大战开始倒计时(int kssjint)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA552E000F2713222000090001000B000000010000000C0000002101000000000000000000000000000000000000000002EE55AA");
				Buffer.BlockCopy(BitConverter.GetBytes(kssjint), 0, array, 26, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public bool PrivateState(int Key)
		{
			if (追加状态列表 == null)
			{
				追加状态列表 = new ThreadSafeDictionary<int, 追加状态类>();
				return false;
			}
			if (追加状态列表.Count <= 0)
			{
				return false;
			}
			追加状态类 value;
			return 追加状态列表.TryGetValue(Key, out value);
		}

		public void 发送仙魔大战消息2()
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA5536000F2713223000090001001D000000010000000D000000EC0100001200000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(World.仙魔大战进程), 0, array, 12, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(World.仙魔大战正分数), 0, array, 26, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(World.仙魔大战邪分数), 0, array, 30, 4);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送仙魔大战消息1()
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA551D005400B7000F000212270300000064000000640002000000000000008E1B55AA");
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送仙魔大战结束消息(int kssjint)
		{
			try
			{
				string hex = "AA5536000F2713223000040001000F00000001000000010000000500000005000000330E0000000000000000000000000000000000000000000055AA";
				byte[] array = Converter.hexStringToByte(hex);
				switch (kssjint)
				{
				case 1:
					if (Player_Zx == 1)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 22, 1);
					}
					else
					{
						Buffer.BlockCopy(BitConverter.GetBytes(1), 0, array, 22, 1);
					}
					break;
				case 2:
					if (Player_Zx == 1)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 22, 1);
					}
					else
					{
						Buffer.BlockCopy(BitConverter.GetBytes(2), 0, array, 22, 1);
					}
					break;
				case 3:
					Buffer.BlockCopy(BitConverter.GetBytes(3), 0, array, 22, 1);
					break;
				}
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(World.仙魔大战进程), 0, array, 10, 1);
				Buffer.BlockCopy(BitConverter.GetBytes(World.仙魔大战正分数), 0, array, 34, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(World.仙魔大战邪分数), 0, array, 38, 4);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送仙魔大战关闭消息()
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA551B00A205BA000D0006132700000000000000000000000000000000AC4155AA");
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送安全码消息(int 操作ID)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA552B002C0138151C000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
				安全码操作ID = 操作ID;
			}
			catch
			{
			}
		}

		public void 发送帮派消息(string BpName, byte[] data, int length)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.帮派名字 == BpName && value.Client != null)
					{
						value.Client.Send(data, length);
					}
				}
			}
			catch
			{
			}
		}

		public Players 得到人物数据(int 人物ID)
		{
			Players value;
			return (!World.AllConnectedPlayers.TryGetValue(人物ID, out value)) ? null : value;
		}

		public Players 得到人物数据(string 人物名)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.UserName == 人物名)
					{
						return value;
					}
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		public 物品类 得到包裹物品(int 物品ID)
		{
			for (int i = 0; i < 96; i++)
			{
				if (BitConverter.ToInt32(装备栏包裹[i].物品ID, 0) == 物品ID)
				{
					return 装备栏包裹[i];
				}
			}
			return null;
		}

		public 任务物品类 得到任务包裹栏物品(int PID)
		{
			for (int i = 0; i < 36; i++)
			{
				if (任务物品[i].物品ID == PID)
				{
					return 任务物品[i];
				}
			}
			return null;
		}

		public int 得到包裹空位(Players Playe)
		{
			for (int i = 0; i < 96; i++)
			{
				if (BitConverter.ToInt32(Playe.装备栏包裹[i].物品ID, 0) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		public int 得到行囊空位(Players Playe)
		{
			for (int i = 36; i < 96; i++)
			{
				if (BitConverter.ToInt32(Playe.装备栏包裹[i].物品ID, 0) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		public int 得到包裹物品位置(int PID)
		{
			int num = 0;
			while (true)
			{
				if (num < 96)
				{
					if (BitConverter.ToInt32(装备栏包裹[num].物品ID, 0) == PID)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		public int GetEmptyBagSlot()
		{
			for (int i = 0; i < 96; i++)
			{
				if (BitConverter.ToInt32(装备栏包裹[i].物品ID, 0) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		public List<int> 得到包裹空位位置组(int 数量)
		{
			int num = 0;
			List<int> list = new List<int>();
			for (int i = 0; i < 96; i++)
			{
				if (BitConverter.ToInt32(装备栏包裹[i].物品ID, 0) == 0)
				{
					num++;
					list.Add(i);
					if (num >= 数量)
					{
						break;
					}
				}
			}
			return list;
		}

		public int 得到包裹空位数()
		{
			int num = 0;
			for (int i = 0; i < 96; i++)
			{
				if (BitConverter.ToInt32(装备栏包裹[i].物品ID, 0) == 0)
				{
					num++;
				}
			}
			return num;
		}

		public int 得到行囊空位数()
		{
			for (int i = 36; i < 96; i++)
			{
				if (BitConverter.ToInt32(装备栏包裹[i].物品ID, 0) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		public 物品类 得到人物公共仓库类型(int id, int 仓库类型)
		{
			if (仓库类型 == 3)
			{
				物品类[] array = 个人仓库;
				物品类[] array2 = array;
				物品类[] array5 = array2;
				foreach (物品类 物品类2 in array5)
				{
					if (BitConverter.ToInt32(物品类2.物品ID, 0) == id)
					{
						return 物品类2;
					}
				}
			}
			else
			{
				物品类[] array3 = 公共仓库;
				物品类[] array4 = array3;
				物品类[] array6 = array4;
				foreach (物品类 物品类3 in array6)
				{
					if (BitConverter.ToInt32(物品类3.物品ID, 0) == id)
					{
						return 物品类3;
					}
				}
			}
			return null;
		}

		public 物品类 得到人物物品物品全局ID(Players Playe, long 物品全局ID)
		{
			物品类[] array = Playe.装备栏包裹;
			物品类[] array2 = array;
			物品类[] array3 = array2;
			foreach (物品类 物品类2 in array3)
			{
				if (物品类2.Get物品全局ID == 物品全局ID)
				{
					return 物品类2;
				}
			}
			return null;
		}

		public 物品类 得到人物物品类型(int id)
		{
			物品类[] array = 装备栏包裹;
			物品类[] array2 = array;
			物品类[] array3 = array2;
			foreach (物品类 物品类2 in array3)
			{
				if (物品类2.Get物品ID == id)
				{
					return 物品类2;
				}
			}
			return null;
		}

		public 物品类 得到人物物品类型(int id, int fld_magic0)
		{
			物品类[] array = 装备栏包裹;
			物品类[] array2 = array;
			物品类[] array3 = array2;
			foreach (物品类 物品类2 in array3)
			{
				if (物品类2.Get物品ID == id && 物品类2.FLD_MAGIC0 == fld_magic0)
				{
					return 物品类2;
				}
			}
			return null;
		}

		public 物品类 得到人物公共仓库类型(int id, int 仓库类型, int magic0)
		{
			if (仓库类型 == 3)
			{
				物品类[] array = 个人仓库;
				物品类[] array2 = array;
				物品类[] array5 = array2;
				foreach (物品类 物品类2 in array5)
				{
					if (BitConverter.ToInt32(物品类2.物品ID, 0) == id && 物品类2.FLD_MAGIC0 == magic0)
					{
						return 物品类2;
					}
				}
			}
			else
			{
				物品类[] array3 = 公共仓库;
				物品类[] array4 = array3;
				物品类[] array6 = array4;
				foreach (物品类 物品类3 in array6)
				{
					if (BitConverter.ToInt32(物品类3.物品ID, 0) == id && 物品类3.FLD_MAGIC0 == magic0)
					{
						return 物品类3;
					}
				}
			}
			return null;
		}

		public void 加血(int sl)
		{
			if (中毒)
			{
				sl -= (int)((double)sl * 0.2);
			}
			if (Player_Job == 3)
			{
				sl = (int)((double)sl * (1.0 + base.枪_运气疗伤));
			}
			if (Player_Job != 3 && Player_Job_leve >= 6)
			{
				sl += (int)base.升天一气功_运气疗伤;
			}
			if (人物_HP + sl < 人物最大_HP)
			{
				人物_HP += sl;
			}
			else
			{
				人物_HP = 人物最大_HP;
			}
		}

		public void 加魔(int sl)
		{
			if (中毒)
			{
				sl -= (int)((double)sl * 0.2);
			}
			if (Player_Job == 5)
			{
				sl = (int)((double)sl * (1.0 + base.医_运气疗心));
			}
			if (Player_Job == 13)
			{
				sl = (int)((double)sl * (1.0 + base.神女运气行心));
			}
			if (Player_Job != 5 && Player_Job_leve >= 6)
			{
				sl = (int)((double)sl * (1.0 + base.升天一气功_运气行心));
			}
			if (人物_MP + sl < 人物最大_MP)
			{
				人物_MP += sl;
			}
			else
			{
				人物_MP = 人物最大_MP;
			}
		}

		public void 加血灵兽(int sl)
		{
			if (人物灵兽.FLD_HP + sl < 人物灵兽.灵兽基本最大_HP)
			{
				人物灵兽.FLD_HP += sl;
			}
			else
			{
				人物灵兽.FLD_HP = 人物灵兽.灵兽基本最大_HP;
			}
		}

		public void 加魔灵兽(int sl)
		{
			if (人物灵兽.FLD_MP + sl < 人物灵兽.灵兽基本最大_MP)
			{
				人物灵兽.FLD_MP += sl;
			}
			else
			{
				人物灵兽.FLD_MP = 人物灵兽.灵兽基本最大_MP;
			}
		}

		public void 新吃药提示()
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write4(1025);
			发包类.Write8(1008000093L);
			发包类.Write4(3);
			发包类.Write4(1);
			发包类.Write4(2000000012);
			发包类.Write4(0);
			if (Client != null)
			{
				Client.SendPak(发包类, 15104, 人物全服ID);
			}
		}

		public void 得到钱的提示(uint 数量)
		{
			byte[] array = Converter.hexStringToByte("AA554200EA010D0034000100000000000000000000000094357700000000A701000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
			byte[] bytes = BitConverter.GetBytes(数量);
			Buffer.BlockCopy(bytes, 0, array, 30, bytes.Length);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 升级后的提示(int ID)
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write(Player_Level);
			发包类.Write(ID);
			发包类.Write4(0);
			发包类.Write4(0);
			if (Client != null)
			{
				Client.SendPak(发包类, 30464, 人物全服ID);
				发送当前范围广播数据(发包类, 30464, 人物全服ID);
			}
		}

		public void 分解物品提示(int id)
		{
			byte[] array = Converter.hexStringToByte("AA5512003B0231170400FEFFFFFF000000000000B0EB55AA");
			Buffer.BlockCopy(BitConverter.GetBytes(id), 0, array, 10, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 购买物品提示(int id)
		{
			byte[] array = Converter.hexStringToByte("AA551300000093000800050000000E000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(id), 0, array, 14, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 捡物品提示(int id, long 物品全局ID)
		{
			byte[] array = Converter.hexStringToByte("AA551A0000000D000C00030000006843030000000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(id), 0, array, 10, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(物品全局ID), 0, array, 14, 8);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 商店提示(int id)
		{
			byte[] array = Converter.hexStringToByte("AA5512000000CF000700010D0000000000000000000000000055AA");
			Buffer.BlockCopy(BitConverter.GetBytes(id), 0, array, 11, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 组队传送符提示(int id, int 位置, int pid)
		{
			byte[] array = Converter.hexStringToByte("AA552200D001121614000106000078DC143C010000000100000009943577000000000000A65455AA");
			Buffer.BlockCopy(BitConverter.GetBytes(位置), 0, array, 11, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(pid), 0, array, 14, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(id), 0, array, 18, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 倒计时提示(int 秒)
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write4(秒);
			发包类.Write4(0);
			发包类.Write4(0);
			if (Client != null)
			{
				Client.SendPak(发包类, 5911, 人物全服ID);
			}
		}

		public void 帮派传送符提示(int id, int 位置, int pid)
		{
			byte[] array = Converter.hexStringToByte("AA552000D001311614000106000078DC143C010000000100000009943577000000000000A65455AA");
			Buffer.BlockCopy(BitConverter.GetBytes(位置), 0, array, 11, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(pid), 0, array, 14, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(id), 0, array, 18, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 滚动公告(int msgID)
		{
			if (!Client.挂机)
			{
				byte[] array = Converter.hexStringToByte("AA554D000F27B018480001000000941100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(msgID), 0, array, 14, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send多包(array, array.Length);
				}
			}
		}

		public void 系统提示(string msg, int msgType, string name)
		{
			byte[] array = Converter.hexStringToByte("AA55A50000006600970000000000000000000000000000000000000000000000003000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
			array[10] = (byte)msgType;
			byte[] bytes = Encoding.Default.GetBytes(name);
			byte[] bytes2 = Encoding.Default.GetBytes(msg);
			Buffer.BlockCopy(bytes, 0, array, 12, bytes.Length);
			Buffer.BlockCopy(bytes2, 0, array, 35, bytes2.Length);
			Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 系统提示(string msg)
		{
			byte[] array = Converter.hexStringToByte("AA55A5000000660097000F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
			byte[] bytes = Encoding.Default.GetBytes(msg);
			Buffer.BlockCopy(bytes, 0, array, 35, bytes.Length);
			Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 发送提示文本(string 提示内容)
		{
			string hex = "AA55BE00EE036600B8000F00000000000000000000000000000000000000000000000131000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			byte[] bytes = Encoding.Default.GetBytes(提示内容);
			Buffer.BlockCopy(BitConverter.GetBytes(bytes.Length), 0, array, 34, 1);
			Buffer.BlockCopy(bytes, 0, array, 35, bytes.Length);
			Buffer.BlockCopy(BitConverter.GetBytes(0), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send多包(array, array.Length);
			}
		}

		public void 系统公告(string msg)
		{
			byte[] array = Converter.hexStringToByte("AA55A50000006600970008000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
			byte[] bytes = Encoding.Default.GetBytes(msg);
			Buffer.BlockCopy(bytes, 0, array, 35, bytes.Length);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 系统滚动公告(string msg)
		{
			byte[] array = Converter.hexStringToByte("AA55A50000006600970008000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
			byte[] bytes = Encoding.Default.GetBytes(msg);
			Buffer.BlockCopy(bytes, 0, array, 35, bytes.Length);
			if (Client != null)
			{
				Client.Send(array, array.Length);
			}
		}

		public void 送花公告(string msg)
		{
			string hex = "AA55B7002F046600A800F1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			byte[] bytes = Encoding.Default.GetBytes(msg);
			Buffer.BlockCopy(bytes, 0, array, 35, bytes.Length);
			if (Client != null)
			{
				Client.Send多包(array, array.Length);
			}
		}

		public void 横幅公告(string msg)
		{
			string hex = "AA5566000F27B0186000010000004C0E0000000000000000000000000000000000000000000000A100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA";
			byte[] array = Converter.hexStringToByte(hex);
			byte[] bytes = Encoding.Default.GetBytes(msg);
			Buffer.BlockCopy(bytes, 0, array, 39, bytes.Length);
			if (Client != null)
			{
				Client.Send多包(array, array.Length);
			}
		}

		public void 保存八彩数据()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE  TBL_ACCOUNT  SET      FLD_QCVIP={1},FLD_QCVIPTIM='{2}'      WHERE      FLD_ID='{0}'", Userid, 1, FLD_QCVIPTIM);
			if (DBA.ExeSqlCommand(stringBuilder.ToString(), "rxjhaccount") == -1)
			{
				MainForm.WriteLine(1, "保存ID      八彩会员      数据出错[" + Userid + "]-[" + UserName + "]");
			}
		}

		public virtual void 发送当前范围广播数据(byte[] data, int length)
		{
		}

		public virtual void 发送当前范围广播数据(发包类 pak, int id, int wordid)
		{
		}

		public void 有新传书提示(int 传书类型, int 数量)
		{
			foreach (个人传书类 value in 传书列表.Values)
			{
				if (value.是否已读 == 0)
				{
					byte[] array = Converter.hexStringToByte("AA550F000000B200010002000000000000F1A755AA");
					Buffer.BlockCopy(BitConverter.GetBytes(传书类型), 0, array, 10, 1);
					if (传书类型 == 3)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(数量), 0, array, 11, 4);
					}
					Client.Send(array, array.Length);
				}
			}
		}

		public void 查看传书()
		{
			try
			{
				if (传书列表 == null)
				{
					return;
				}
				byte[] array = Converter.hexStringToByte("AA55D1010000B2002302000000");
				byte[] array2 = Converter.hexStringToByte("55AA");
				byte[] array3 = new byte[array.Length + array2.Length + 传书列表.Count * 36];
				Buffer.BlockCopy(array, 0, array3, 0, array.Length);
				Buffer.BlockCopy(array2, 0, array3, array3.Length - array2.Length, array2.Length);
				Buffer.BlockCopy(BitConverter.GetBytes(传书列表.Count * 36 + 9), 0, array3, 2, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(传书列表.Count * 36 + 3), 0, array3, 8, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(传书列表.Count), 0, array3, 11, 2);
				int num = 0;
				foreach (个人传书类 value in 传书列表.Values)
				{
					byte[] array4 = new byte[36];
					Buffer.BlockCopy(BitConverter.GetBytes(value.传书ID), 0, array4, 0, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(value.是否NPC), 0, array4, 4, 1);
					byte[] bytes = Encoding.Default.GetBytes(value.传书发送人);
					Buffer.BlockCopy(bytes, 0, array4, 5, bytes.Length);
					Buffer.BlockCopy(BitConverter.GetBytes(value.传书时间.Year - 2000), 0, array4, 25, 1);
					Buffer.BlockCopy(BitConverter.GetBytes(value.传书时间.Month), 0, array4, 26, 1);
					Buffer.BlockCopy(BitConverter.GetBytes(value.传书时间.Day), 0, array4, 27, 1);
					Buffer.BlockCopy(BitConverter.GetBytes(value.传书时间.Hour), 0, array4, 28, 1);
					Buffer.BlockCopy(BitConverter.GetBytes(value.传书时间.Minute), 0, array4, 29, 1);
					Buffer.BlockCopy(BitConverter.GetBytes(value.是否已读), 0, array4, 30, 2);
					Buffer.BlockCopy(array4, 0, array3, num * 36 + 13, array4.Length);
					num++;
				}
				Client.Send(array3, array3.Length);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "查看传书出错()出错" + 人物全服ID + "| " + ex.Message);
			}
		}

		public bool 检查五行披风属性符(物品类 wp)
		{
			if (追加状态列表.ContainsKey(1008001135) || 追加状态列表.ContainsKey(1008001136))
			{
				FLD_装备_追加_气功 += 3;
				FLD_装备_追加_经验百分比 += 0.5;
				FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 7 / 180;
				FLD_装备_武功攻击力增加百分比 += 0.13;
				FLD_装备_追加_防御 += FLD_装备_追加_防御 / 7;
				FLD_装备_追加_HP += 800;
				FLD_装备_追加_MP += 600;
				return true;
			}
			if (追加状态列表.ContainsKey(1008001134) || 追加状态列表.ContainsKey(1008001026))
			{
				FLD_装备_追加_气功 += 3;
				FLD_装备_追加_经验百分比 += 0.4;
				FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 7 / 200;
				FLD_装备_武功攻击力增加百分比 += 0.12;
				FLD_装备_追加_防御 += FLD_装备_追加_防御 / 8;
				FLD_装备_追加_HP += 600;
				FLD_装备_追加_MP += 400;
				return true;
			}
			if (追加状态列表.ContainsKey(1008001022) || 追加状态列表.ContainsKey(1008001027))
			{
				FLD_装备_追加_气功 += 3;
				FLD_装备_追加_经验百分比 += 0.4;
				FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 5 / 200;
				FLD_装备_武功攻击力增加百分比 += 0.1;
				FLD_装备_追加_防御 += FLD_装备_追加_防御 / 10;
				FLD_装备_追加_HP += 500;
				FLD_装备_追加_MP += 300;
				return true;
			}
			if (追加状态列表.ContainsKey(1008001023) || 追加状态列表.ContainsKey(1008001028))
			{
				FLD_装备_追加_气功 += 3;
				FLD_装备_追加_经验百分比 += 0.2;
				FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 5 / 200;
				FLD_装备_武功攻击力增加百分比 += 0.1;
				FLD_装备_追加_防御 += FLD_装备_追加_防御 / 10;
				FLD_装备_追加_HP += 500;
				FLD_装备_追加_MP += 500;
				return true;
			}
			if (追加状态列表.ContainsKey(1008001024) || 追加状态列表.ContainsKey(1008001029))
			{
				FLD_装备_追加_气功 += 3;
				FLD_装备_追加_经验百分比 += 0.2;
				return true;
			}
			if (!追加状态列表.ContainsKey(1008001025) && !追加状态列表.ContainsKey(1008001030))
			{
				return false;
			}
			FLD_装备_追加_攻击 += (装备栏已穿装备[3].物品攻击力 + 装备栏已穿装备[3].物品攻击力MAX) * 5 / 200;
			FLD_装备_武功攻击力增加百分比 += 0.1;
			FLD_装备_追加_防御 += FLD_装备_追加_防御 / 10;
			FLD_装备_追加_HP += 500;
			FLD_装备_追加_MP += 500;
			return true;
		}

		public bool 检查武器属性符(物品类 wp)
		{
			if (追加状态列表.ContainsKey(900000203))
			{
				FLD_装备_追加_HP += 1000;
				FLD_装备_武功攻击力增加百分比 += 0.05;
				FLD_装备_武功防御力增加百分比 += 0.05;
				return true;
			}
			if (追加状态列表.ContainsKey(900000204))
			{
				FLD_装备_追加_HP += 2000;
				FLD_装备_武功攻击力增加百分比 += 0.1;
				FLD_装备_武功防御力增加百分比 += 0.1;
				return true;
			}
			if (追加状态列表.ContainsKey(900000205))
			{
				FLD_装备_追加_HP += 3000;
				FLD_装备_武功攻击力增加百分比 += 0.15;
				FLD_装备_武功防御力增加百分比 += 0.15;
				return true;
			}
			if (追加状态列表.ContainsKey(900000206))
			{
				FLD_装备_追加_HP += 4000;
				FLD_装备_武功攻击力增加百分比 += 0.2;
				FLD_装备_武功防御力增加百分比 += 0.2;
				return true;
			}
			return false;
		}

		public bool 检查门甲条件(int wpid)
		{
			if (wpid == 900102 && 帮派等级 < 4)
			{
				系统提示("必须加入门派, 并且门派等级大于4级才可以佩戴。");
				return false;
			}
			if (wpid == 900103 && 帮派等级 < 5)
			{
				系统提示("必须加入门派, 并且门派等级大于5级才可以佩戴。");
				return false;
			}
			if (wpid == 900104 && 帮派等级 < 7)
			{
				系统提示("必须加入门派, 并且门派等级大于7级才可以佩戴。");
				return false;
			}
			if (wpid >= 900105 && wpid <= 900108)
			{
				if (帮派等级 < 7)
				{
					系统提示("必须加入门派, 并且门派等级大于7级才可以佩戴。");
					return false;
				}
				if (帮派人物等级 < 2)
				{
					系统提示("必须是门派长老级别以上才可以佩戴。");
					return false;
				}
			}
			if (wpid < 900109 || wpid > 900112 || 帮派等级 >= 7)
			{
				return true;
			}
			系统提示("必须加入门派, 并且门派等级大于7级才可以佩戴。");
			return false;
		}

		public bool 查询天关地图(int map)
		{
			return map == 25202 || map == 25203 || map == 25204 || map == 25205 || map == 25206 || map == 25207 || map == 25208 || map == 25209 || map == 25210;
		}

		public bool 查询天关条件(int map)
		{
			try
			{
				if (追加状态列表 != null && (uint)(map - 25202) <= 8u && GetAddState(999000163))
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
			return false;
		}

		public double 得到天关福利加成(int type, int map)
		{
			try
			{
				if ((uint)(map - 25202) <= 8u)
				{
					return (type == 0) ? (World.天关经验提高百分比基数 + World.天关经验提高百分比递增 * 2.0) : ((double)(World.天关物品爆率提高基数 + World.天关物品爆率提高递增 * 2));
				}
			}
			catch
			{
				return 0.0;
			}
			return 0.0;
		}

		public bool 检查符()
		{
			if (公有药品 == null)
			{
				return false;
			}
			return 公有药品.ContainsKey(1008000027) || 公有药品.ContainsKey(1008000058) || 公有药品.ContainsKey(1008000061) || 公有药品.ContainsKey(1008000028) || 公有药品.ContainsKey(1008000059) || 公有药品.ContainsKey(1008000062) || 公有药品.ContainsKey(1008000029) || 公有药品.ContainsKey(1008000060) || 公有药品.ContainsKey(1008000063);
		}

		public bool 检查符2()
		{
			return 公有药品.ContainsKey(1008000124) || 公有药品.ContainsKey(1008000058) || 公有药品.ContainsKey(1008000141) || 公有药品.ContainsKey(1008000140) || 公有药品.ContainsKey(1008000311) || 公有药品.ContainsKey(1008000877) || 公有药品.ContainsKey(1008000312) || 公有药品.ContainsKey(1008000320) || 公有药品.ContainsKey(1008000318);
		}

		public int 首饰升级取首饰(int reside2, int Pid, int Type)
		{
			if (Type == 0)
			{
				switch (reside2)
				{
				case 7:
					switch (Pid)
					{
					case 100018:
						return 100020;
					case 100015:
						return 100018;
					default:
						Pid++;
						return Pid;
					case 100026:
						return 0;
					case 100021:
						return 100026;
					}
				case 8:
					switch (Pid)
					{
					default:
						Pid++;
						return Pid;
					case 18:
						return 0;
					case 16:
						return 18;
					case 11:
						return 14;
					}
				default:
					return 0;
				case 10:
					switch (Pid)
					{
					default:
						Pid++;
						return Pid;
					case 700911:
						return 0;
					case 700022:
						return 700911;
					case 700017:
						return 700020;
					}
				}
			}
			switch (reside2)
			{
			case 7:
				switch (Pid)
				{
				case 100018:
					return 100015;
				case 100001:
					return 0;
				default:
					Pid--;
					return Pid;
				case 100026:
					return 100021;
				case 100020:
					return 100018;
				}
			case 8:
				switch (Pid)
				{
				default:
					Pid--;
					return Pid;
				case 18:
					return 16;
				case 14:
					return 11;
				case 1:
					return 0;
				}
			default:
				return 0;
			case 10:
				switch (Pid)
				{
				default:
					Pid--;
					return Pid;
				case 700911:
					return 700022;
				case 700020:
					return 700017;
				case 700001:
					return 0;
				}
			}
		}

		public bool 是否灵兽(int pid)
		{
			return pid == 1000000065 || pid == 1000000066 || pid == 1000000067 || pid == 1000000068 || pid == 1000000083 || pid == 1000000084 || pid == 1000000085 || pid == 1000000086 || pid == 1000001011 || pid == 1000001377 || pid == 1000001378 || pid == 1000001379 || pid == 1000001380 || pid == 1000001381 || pid == 1000001382 || pid == 1000001383 || pid == 1000001384 || pid == 1000001385 || pid == 1000002006 || pid == 1000002001 || pid == 1000002002 || pid == 1000002003 || pid == 1000002004 || pid == 1000002005;
		}

		public void 发送灵兽数据(long long_5, 灵兽类 灵兽类_0)
		{
			byte[] array = Converter.hexStringToByte("AA555600CD04591050000B00000001000000313131313100000000000000000000000000000004003900000000000000000000000000000000000000000005835400000000001B1D670000000000B5036131188EC80C0000000055AA");
			byte[] bytes = Encoding.Default.GetBytes(灵兽类_0.Name);
			Buffer.BlockCopy(bytes, 0, array, 18, bytes.Length);
			Buffer.BlockCopy(BitConverter.GetBytes(灵兽类_0.FLD_JOB), 0, array, 38, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(灵兽类_0.FLD_JOB_LEVEL), 0, array, 39, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(灵兽类_0.FLD_LEVEL), 0, array, 40, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(灵兽类_0.FLD_MAGIC1), 0, array, 42, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(灵兽类_0.FLD_MAGIC2), 0, array, 46, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(灵兽类_0.FLD_MAGIC3), 0, array, 50, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(灵兽类_0.FLD_MAGIC4), 0, array, 54, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(灵兽类_0.FLD_MAGIC5), 0, array, 58, 4);
			double num = Convert.ToInt64(World.lever[人物灵兽.FLD_LEVEL]) - Convert.ToInt64(World.lever[人物灵兽.FLD_LEVEL - 1]);
			double num2 = 人物灵兽.FLD_EXP - Convert.ToInt64(World.lever[人物灵兽.FLD_LEVEL - 1]);
			if (num2 < 1.0)
			{
				人物灵兽.FLD_EXP = Convert.ToInt64(World.lever[人物灵兽.FLD_LEVEL - 1]);
				num2 = 0.0;
			}
			Buffer.BlockCopy(BitConverter.GetBytes((int)num2), 0, array, 62, 4);
			Buffer.BlockCopy(BitConverter.GetBytes((int)num), 0, array, 70, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(long_5), 0, array, 78, 8);
			Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
			if (Client != null)
			{
				Client.Send多包(array, array.Length);
			}
		}

		public void 发送势力战开始倒计时(int int_109)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA552E000F2713222000090001000B000000010000000C0000002101000000000000000000000000000000000000000002EE55AA");
				Buffer.BlockCopy(BitConverter.GetBytes(int_109), 0, array, 26, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				if (Client != null)
				{
					Client.Send(array, array.Length);
				}
			}
			catch
			{
			}
		}

		public void 发送灵兽数据(long long_5)
		{
			string sqlCommand = $"SELECT * FROM TBL_XWWL_Cw WHERE ItmeId ={long_5}";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand);
			if (dBToDataTable == null || dBToDataTable.Rows.Count <= 0)
			{
				return;
			}
			using (发包类 发包类 = new 发包类())
			{
				发包类.Write4(11);
				发包类.Write4(1);
				发包类.WriteString(dBToDataTable.Rows[0]["Name"].ToString(), 20);
				发包类.Write1((int)dBToDataTable.Rows[0]["FLD_JOB"]);
				发包类.Write1(3);
				发包类.Write2((int)dBToDataTable.Rows[0]["FLD_LEVEL"]);
				发包类.Write4((int)dBToDataTable.Rows[0]["FLD_MAGIC1"]);
				发包类.Write4((int)dBToDataTable.Rows[0]["FLD_MAGIC2"]);
				发包类.Write4((int)dBToDataTable.Rows[0]["FLD_MAGIC3"]);
				发包类.Write4((int)dBToDataTable.Rows[0]["FLD_MAGIC4"]);
				发包类.Write4((int)dBToDataTable.Rows[0]["FLD_MAGIC5"]);
				发包类.Write8(0L);
				发包类.Write8(0L);
				发包类.Write(long_5);
				发包类.Write4((int)dBToDataTable.Rows[0]["FLD_BS"]);
				if (Client != null)
				{
					Client.SendPak(发包类, 22800, 人物全服ID);
				}
			}
			dBToDataTable.Dispose();
		}

		public void 发送灵兽数据_按玩家名称(string name)
		{
			string sqlCommand = "SELECT * FROM TBL_XWWL_Cw WHERE ZrName ='" + name + "'";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand);
			if (dBToDataTable == null || dBToDataTable.Rows.Count <= 0)
			{
				return;
			}
			int num = ((dBToDataTable.Rows.Count > 2) ? 2 : dBToDataTable.Rows.Count);
			using (发包类 发包类 = new 发包类())
			{
				发包类.Write4(11);
				发包类.Write4(num);
				for (int i = 0; i < num; i++)
				{
					发包类.WriteString(dBToDataTable.Rows[i]["Name"].ToString(), 20);
					发包类.Write1((int)dBToDataTable.Rows[i]["FLD_JOB"]);
					发包类.Write1((int)dBToDataTable.Rows[i]["FLD_JOB_LEVEL"]);
					发包类.Write2(3);
					发包类.Write4((int)dBToDataTable.Rows[i]["FLD_MAGIC1"]);
					发包类.Write4((int)dBToDataTable.Rows[i]["FLD_MAGIC2"]);
					发包类.Write4((int)dBToDataTable.Rows[i]["FLD_MAGIC3"]);
					发包类.Write4((int)dBToDataTable.Rows[i]["FLD_MAGIC4"]);
					发包类.Write4((int)dBToDataTable.Rows[i]["FLD_MAGIC5"]);
					发包类.Write8(0L);
					发包类.Write8(0L);
					发包类.Write((long)dBToDataTable.Rows[i]["ItmeId"]);
					发包类.Write4((int)dBToDataTable.Rows[0]["FLD_BS"]);
				}
				if (Client != null)
				{
					Client.SendPak(发包类, 22800, 人物全服ID);
				}
			}
			dBToDataTable.Dispose();
		}

		public void 更新玫瑰排行(Players players_0, Players players_1, int int_109)
		{
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_玫瑰花排行榜 WHERE FLD_NAME='" + players_0.UserName + "'");
				if (dBToDataTable != null && dBToDataTable.Rows.Count > 0)
				{
					DBA.ExeSqlCommand(string.Format("UPDATE TBL_玫瑰花排行榜 SET FLD_OUTNUM=FLD_OUTNUM+{1} WHERE FLD_NAME='{0}'", players_0.UserName, int_109));
				}
				else
				{
					DBA.ExeSqlCommand($"INSERT INTO TBL_玫瑰花排行榜 (FLD_NAME, FLD_SEX, FLD_ZX, FLD_INNUM, FLD_OUTNUM, FLD_FQ) VALUES ('{players_0.UserName}', {players_0.Player_Sex}, {players_0.Player_Zx}, {0}, {int_109}, '{World.ZoneNumber}')");
				}
				DataTable dBToDataTable2 = DBA.GetDBToDataTable("SELECT * FROM TBL_玫瑰花排行榜 WHERE FLD_NAME= '" + players_1.UserName + "'");
				if (dBToDataTable2 != null && dBToDataTable2.Rows.Count > 0)
				{
					DBA.ExeSqlCommand(string.Format("UPDATE TBL_玫瑰花排行榜 SET FLD_INNUM=FLD_INNUM+{1} WHERE FLD_NAME='{0}'", players_1.UserName, int_109));
				}
				else
				{
					DBA.ExeSqlCommand($"INSERT INTO TBL_玫瑰花排行榜 (FLD_NAME, FLD_SEX, FLD_ZX, FLD_INNUM, FLD_OUTNUM, FLD_FQ) VALUES ('{players_1.UserName}', {players_1.Player_Sex}, {players_1.Player_Zx}, {int_109}, {0}, '{World.ZoneNumber}')");
				}
				dBToDataTable2?.Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "更新玫瑰排行()出错 [" + Userid + "][" + UserName + "][赠送数量:" + int_109 + "] " + ex.Message);
			}
		}

		public void 打开玫瑰排行(byte[] byte_0, int int_109)
		{
			try
			{
				int num = 1;
				int num2 = 1;
				using 发包类 发包类 = new 发包类();
				for (int i = 0; i < 4; i++)
				{
					switch (i)
					{
					case 1:
						num = 2;
						num2 = 1;
						break;
					case 2:
						num = 1;
						num2 = 2;
						break;
					case 3:
						num = 2;
						num2 = 2;
						break;
					}
					DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT top 5 * FROM TBL_玫瑰花排行榜 where FLD_SEX = {0} and FLD_ZX={1} and FLD_FQ= '" + World.ZoneNumber + "' Order By FLD_INNUM Desc", num2, num));
					if (dBToDataTable != null && dBToDataTable.Rows.Count > 0)
					{
						for (int j = 0; j < dBToDataTable.Rows.Count; j++)
						{
							int value = j + 1;
							发包类.Write1(value);
							发包类.WriteString(dBToDataTable.Rows[j]["FLD_NAME"].ToString(), 15);
							发包类.Write4((int)dBToDataTable.Rows[j]["FLD_INNUM"]);
							发包类.Write4(0);
						}
						if (dBToDataTable.Rows.Count < 5)
						{
							for (int k = 0; k < 5 - dBToDataTable.Rows.Count; k++)
							{
								发包类.Write8(0L);
								发包类.Write8(0L);
								发包类.Write8(0L);
							}
						}
						dBToDataTable.Dispose();
					}
					else
					{
						dBToDataTable?.Dispose();
						for (int l = 0; l < 5; l++)
						{
							发包类.Write8(0L);
							发包类.Write8(0L);
							发包类.Write8(0L);
						}
					}
				}
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				DataTable dBToDataTable2 = DBA.GetDBToDataTable("SELECT FLD_NAME, FLD_INNUM, FLD_OUTNUM FROM TBL_玫瑰花排行榜 Order By FLD_INNUM Desc");
				if (dBToDataTable2 != null && dBToDataTable2.Rows.Count > 0)
				{
					for (int m = 0; m < dBToDataTable2.Rows.Count; m++)
					{
						if (dBToDataTable2.Rows[m]["FLD_NAME"].ToString() == UserName)
						{
							num3 = m + 1;
							num4 = (int)dBToDataTable2.Rows[m]["FLD_OUTNUM"];
							num5 = (int)dBToDataTable2.Rows[m]["FLD_INNUM"];
							break;
						}
					}
				}
				dBToDataTable2?.Dispose();
				发包类.Write8(num3);
				发包类.Write8(num4);
				发包类.Write8(num5);
				发包类.Write4(0);
				if (Client != null)
				{
					Client.SendPak(发包类, 1795, 人物全服ID);
				}
			}
			catch
			{
			}
		}

		public byte[] 得到更新人物排名数据(string 人物名, string 门派帮派名, int 人物正邪, int 人物等级, int 职业, int 转职, int 排名)
		{
			using 发包类 发包类 = new 发包类();
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT FLD_FACE, FLD_WEARITEM, FLD_JOB_LEVEL FROM TBL_XWWL_Char where FLD_NAME='" + 人物名 + "'", "GameServer");
				if (dBToDataTable != null && dBToDataTable.Rows.Count != 0)
				{
					人物模板类 人物模板类2 = new 人物模板类((byte[])dBToDataTable.Rows[0]["FLD_FACE"]);
					int value = (int)dBToDataTable.Rows[0]["FLD_JOB_LEVEL"];
					byte[] array = (byte[])dBToDataTable.Rows[0]["FLD_WEARITEM"];
					物品类[] array2 = new 物品类[15];
					for (int i = 0; i < 15; i++)
					{
						byte[] array3 = new byte[World.数据库单个物品大小];
						if (array.Length >= i * World.数据库单个物品大小 + World.数据库单个物品大小)
						{
							try
							{
								Buffer.BlockCopy(array, i * World.数据库单个物品大小, array3, 0, World.数据库单个物品大小);
							}
							catch (Exception ex3)
							{
								MainForm.WriteLine(i, " " + ex3);
							}
						}
						array2[i] = new 物品类(array3, i);
					}
					int value4 = BitConverter.ToInt32(array2[0].物品ID, 0);
					int value5 = BitConverter.ToInt32(array2[1].物品ID, 0);
					int value6 = BitConverter.ToInt32(array2[2].物品ID, 0);
					int value7 = BitConverter.ToInt32(array2[4].物品ID, 0);
					int value8 = BitConverter.ToInt32(array2[3].物品ID, 0);
					int value9 = BitConverter.ToInt32(array2[5].物品ID, 0);
					int value10 = BitConverter.ToInt32(array2[6].物品ID, 0);
					int value11 = BitConverter.ToInt32(array2[7].物品ID, 0);
					int value2 = BitConverter.ToInt32(array2[11].物品ID, 0);
					int value3 = BitConverter.ToInt32(array2[13].物品ID, 0);
					int fLD_强化数量 = array2[3].FLD_强化数量;
					dBToDataTable.Dispose();
					发包类.WriteString(人物名, 14);
					发包类.Write(0);
					发包类.Write4(0);
					发包类.WriteString(门派帮派名, 14);
					发包类.Write4(0);
					发包类.Write(人物正邪);
					发包类.Write(人物等级);
					发包类.Write(value);
					发包类.Write(职业);
					发包类.Write2(人物模板类2.发色);
					发包类.Write2(人物模板类2.发型);
					发包类.Write2(人物模板类2.脸型);
					发包类.Write(new byte[7], 0, 7);
					发包类.Write(人物模板类2.声音);
					发包类.Write(人物模板类2.性别);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write4(value4);
					发包类.Write4(0);
					发包类.Write4(value5);
					发包类.Write4(0);
					发包类.Write4(value6);
					发包类.Write4(0);
					发包类.Write4(value7);
					发包类.Write4(0);
					发包类.Write4(value8);
					发包类.Write4(0);
					发包类.Write4(value9);
					发包类.Write4(0);
					发包类.Write4(value10);
					发包类.Write4(0);
					发包类.Write4(value11);
					发包类.Write4(0);
					发包类.Write(fLD_强化数量);
					发包类.Write4(value2);
					发包类.Write4(0);
					发包类.Write8(0L);
					发包类.Write8(0L);
					发包类.Write8(0L);
					发包类.Write8(0L);
					发包类.Write4(value3);
					发包类.Write4(0);
					发包类.Write2(0);
					发包类.Write2(0);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write2(0);
					发包类.Write2(0);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write(new byte[48], 0, 48);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write(0);
					发包类.WriteName("");
					发包类.Write(0);
					发包类.Write(0);
					发包类.Write(0);
					发包类.Write(0);
					发包类.Write(0);
					发包类.Write(0);
					发包类.Write(0);
					发包类.Write(0);
					发包类.Write2(0);
					发包类.Write2(0);
					发包类.Write2(0);
					发包类.Write2(0);
					发包类.Write2(0);
					发包类.Write2(0);
					发包类.Write2(0);
					发包类.Write(new byte[51]);
					发包类.Write4(排名);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write2(0);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write2(0);
					发包类.Write(new byte[47]);
					发包类.Write4(0);
					发包类.Write4(0);
				}
				dBToDataTable.Dispose();
				return 发包类.ToArray3();
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "得到更新人物数据 出错" + Client.WorldId + "|" + Client.ToString() + " " + Converter.ToString(发包类.ToArray3()) + " " + ex2);
				return new byte[0];
			}
		}

		public void 进入游戏发送传书(string 内容, string 接受名字, string name)
		{
			if (RxjhClass.GetUserName(接受名字) != 1 && 得到人物数据(接受名字) != null)
			{
				个人传书类 个人传书类2 = new 个人传书类
				{
					传书ID = (int)RxjhClass.GetDBItmeId(),
					传书发送人 = name,
					传书内容 = 内容,
					传书时间 = DateTime.Now,
					是否NPC = 1,
					是否已读 = 0
				};
				传书列表.TryAdd(个人传书类2.传书ID, 个人传书类2);
				有新传书提示(2, 0);
			}
		}

		public int 计算升天武功威力(武功类 武功)
		{
			return (武功新[武功.FLD_武功类型, 武功.FLD_INDEX] != null) ? ((武功.FLD_武功类型 == 3) ? (武功.FLD_AT + (武功新[武功.FLD_武功类型, 武功.FLD_INDEX].武功_等级 - 1) * 武功.FLD_每级加危害 / World.升天技能等级加成) : ((武功新[武功.FLD_武功类型, 武功.FLD_INDEX].武功_等级 <= 1) ? 武功.FLD_AT : (武功.FLD_AT + (武功新[武功.FLD_武功类型, 武功.FLD_INDEX].武功_等级 - 1) * 武功.FLD_每级加危害))) : 0;
		}

		public void 更新服务器列表(string ser)
		{
			try
			{
				string[] array = ser.Split(',');
				ServerList value = new ServerList
				{
					服务器IP = array[1],
					服务器端口 = int.Parse(array[2]),
					服务器ID = int.Parse(array[3])
				};
				int key = int.Parse(array[0]);
				if (!SerList.TryGetValue(key, out var _))
				{
					SerList.TryAdd(key, value);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "换线 获取服务器列表出错[" + Userid + "][" + UserName + "]" + ex.Message);
			}
		}

		public void kickidlog(string dec)
		{
			logo.kickid(Userid + "|" + UserName + "|" + Client.ToString() + "|" + dec);
		}

		private string 得到初级附魂字符(string ysqh)
		{
			if (1 == 0)
			{
			}
			string result = ysqh switch
			{
				"1" => "初级附魂1", 
				"2" => "初级附魂2", 
				"3" => "初级附魂3", 
				"4" => "初级附魂4", 
				"5" => "初级附魂5", 
				_ => "未附魂", 
			};
			if (1 == 0)
			{
			}
			return result;
		}

		private string 得到进化字符(string ysqh)
		{
			if (!(ysqh == "1"))
			{
				if (ysqh == "2")
				{
					return "进化Lv2";
				}
				return "未进化";
			}
			return "进化Lv1";
		}

		private string 得到中级附魂字符(string ysqh)
		{
			if (!(ysqh == "1"))
			{
				if (ysqh == "2")
				{
					return "心(防具-命中)2";
				}
				return "未中级附魂";
			}
			return "心(防具-命中)1";
		}

		private string 得到强化字符(string ysqh)
		{
			string result = "";
			if (ysqh.Length == 6)
			{
				int num = int.Parse(ysqh.Substring(ysqh.Length - 2, 2));
				switch (ysqh.Substring(0, 1))
				{
				case "1":
					result = "攻击力+" + num + " ";
					break;
				case "2":
					result = "防御力+" + num + " ";
					break;
				case "3":
					result = "生命力+" + num + " ";
					break;
				case "4":
					result = "内功力+" + num + " ";
					break;
				case "5":
					result = "命中率+" + num + " ";
					break;
				case "6":
					result = "回避率+" + num + " ";
					break;
				case "7":
					result = "武功攻击力+" + num + "% ";
					break;
				case "8":
					switch (int.Parse(ysqh.Substring(2, 2)))
					{
					case 0:
						result = "全部气功等级+" + num + " ";
						break;
					case 10:
						result = "力劈华山+" + num + " ";
						break;
					case 11:
						result = "摄魂一击+" + num + " ";
						break;
					case 12:
						result = "连环飞舞+" + num + " ";
						break;
					case 13:
						result = "必杀一击+" + num + " ";
						break;
					case 14:
						result = "狂风万破+" + num + " ";
						break;
					case 15:
						result = "四两千斤+" + num + " ";
						break;
					case 16:
						result = "霸气破甲+" + num + " ";
						break;
					case 17:
						result = "真武绝击+" + num + " ";
						break;
					case 18:
						result = "暗影绝杀+" + num + " ";
						break;
					case 19:
						result = "稳如泰山+" + num + " ";
						break;
					case 20:
						result = "长虹贯日+" + num + " ";
						break;
					case 21:
						result = "百变神行+" + num + " ";
						break;
					case 22:
						result = "连环飞舞+" + num + " ";
						break;
					case 23:
						result = "必杀一击+" + num + " ";
						break;
					case 24:
						result = "狂风万破+" + num + " ";
						break;
					case 25:
						result = "护身罡气+" + num + " ";
						break;
					case 26:
						result = "移花接木+" + num + " ";
						break;
					case 27:
						result = "回柳身法+" + num + " ";
						break;
					case 28:
						result = "怒海狂澜+" + num + " ";
						break;
					case 29:
						result = "冲冠一怒+" + num + " ";
						break;
					case 30:
						result = "金钟罩气+" + num + " ";
						break;
					case 31:
						result = "运气疗伤+" + num + " ";
						break;
					case 32:
						result = "连环飞舞+" + num + " ";
						break;
					case 33:
						result = "必杀一击+" + num + " ";
						break;
					case 34:
						result = "狂风万破+" + num + " ";
						break;
					case 35:
						result = "横练太保+" + num + " ";
						break;
					case 36:
						result = "乾坤挪移+" + num + " ";
						break;
					case 37:
						result = "灵甲护身+" + num + " ";
						break;
					case 38:
						result = "狂神降世+" + num + " ";
						break;
					case 39:
						result = "转守为攻+" + num + " ";
						break;
					case 40:
						result = "百步穿杨+" + num + " ";
						break;
					case 41:
						result = "猎鹰之眼+" + num + " ";
						break;
					case 42:
						result = "弓凝神聚气+" + num + " ";
						break;
					case 43:
						result = "必杀一击+" + num + " ";
						break;
					case 44:
						result = "狂风万破+" + num + " ";
						break;
					case 45:
						result = "正本培元+" + num + " ";
						break;
					case 46:
						result = "心神凝聚+" + num + " ";
						break;
					case 47:
						result = "流星三矢+" + num + " ";
						break;
					case 48:
						result = "锐利之箭+" + num + " ";
						break;
					case 49:
						result = "弓无明暗矢+" + num + " ";
						break;
					case 50:
						result = "运气行心+" + num + " ";
						break;
					case 51:
						result = "太极心法+" + num + " ";
						break;
					case 52:
						result = "体血倍增+" + num + " ";
						break;
					case 53:
						result = "洗髓易经+" + num + " ";
						break;
					case 54:
						result = "妙手回春+" + num + " ";
						break;
					case 55:
						result = "长功攻击+" + num + " ";
						break;
					case 56:
						result = "吸星大法+" + num + " ";
						break;
					case 57:
						result = "必杀一击+" + num + " ";
						break;
					case 58:
						result = "天佑之气+" + num + " ";
						break;
					case 59:
						result = "九天真气+" + num + " ";
						break;
					case 110:
						result = "流光乱舞+" + num + " ";
						break;
					case 120:
						result = "无坚不摧+" + num + " ";
						break;
					case 130:
						result = "末日狂舞+" + num + " ";
						break;
					case 140:
						result = "致命绝杀+" + num + " ";
						break;
					case 150:
						result = "万物回春+" + num + " ";
						break;
					}
					break;
				case "9":
					result = "升级成功率+" + num + "% ";
					break;
				case "12":
					result = "获得金钱+" + num + "% ";
					break;
				case "13":
					result = "死亡损失经验减少" + num + "% ";
					break;
				case "15":
					result = "经验获得+" + num + "% ";
					break;
				}
			}
			else if (ysqh.Length == 7)
			{
				int num2 = int.Parse(ysqh.Substring(ysqh.Length - 2, 2));
				string text = ysqh.Substring(0, 2);
				string a = text;
				if (!(a == "10"))
				{
					if (a == "11")
					{
						result = "武功防御+" + num2 + " ";
					}
				}
				else
				{
					result = "追加伤害+" + num2 + " ";
				}
			}
			else if (ysqh.Length == 8)
			{
				result = "强化:" + int.Parse(ysqh.Substring(ysqh.Length - 2, 2));
			}
			else if (ysqh.Length == 10)
			{
				int num3 = int.Parse(ysqh.Substring(ysqh.Length - 4, 1));
				int num4 = int.Parse(ysqh.Substring(ysqh.Length - 3, 1)) + 1;
				int num5 = int.Parse(ysqh.Substring(ysqh.Length - 2, 2));
				switch (num3)
				{
				case 1:
					result = "火+" + num4 + " 强化+" + num5 + " ";
					break;
				case 2:
					result = "水+" + num4 + " 强化+" + num5 + " ";
					break;
				case 3:
					result = "风+" + num4 + " 强化+" + num5 + " ";
					break;
				case 4:
					result = "内+" + num4 + " 强化+" + num5 + " ";
					break;
				case 5:
					result = "外+" + num4 + " 强化+" + num5 + " ";
					break;
				case 6:
					result = "毒+" + num4 + " 强化+" + num5 + " ";
					break;
				}
			}
			return result;
		}

		private string 得到属性字符(string ysqh)
		{
			string result = "";
			switch (ysqh.Length)
			{
			case 6:
			{
				int num4 = int.Parse(ysqh.Substring(ysqh.Length - 2, 2));
				switch (ysqh.Substring(0, 1))
				{
				case "1":
					result = "攻击力+" + num4 + " ";
					break;
				case "2":
					result = "防御力+" + num4 + " ";
					break;
				case "3":
					result = "生命力+" + num4 + " ";
					break;
				case "4":
					result = "内功力+" + num4 + " ";
					break;
				case "5":
					result = "命中率+" + num4 + " ";
					break;
				case "6":
					result = "回避率+" + num4 + " ";
					break;
				case "7":
					result = "武功攻击力+" + num4 + "% ";
					break;
				case "8":
					switch (int.Parse(ysqh.Substring(2, 2)))
					{
					case 0:
						result = "全部气功等级+" + num4 + " ";
						break;
					case 10:
						result = "力劈华山+" + num4 + " ";
						break;
					case 11:
						result = "摄魂一击+" + num4 + " ";
						break;
					case 12:
						result = "连环飞舞+" + num4 + " ";
						break;
					case 13:
						result = "必杀一击+" + num4 + " ";
						break;
					case 14:
						result = "狂风万破+" + num4 + " ";
						break;
					case 15:
						result = "四两千斤+" + num4 + " ";
						break;
					case 16:
						result = "霸气破甲+" + num4 + " ";
						break;
					case 17:
						result = "真武绝击+" + num4 + " ";
						break;
					case 18:
						result = "暗影绝杀+" + num4 + " ";
						break;
					case 19:
						result = "稳如泰山+" + num4 + " ";
						break;
					case 20:
						result = "长虹贯日+" + num4 + " ";
						break;
					case 21:
						result = "百变神行+" + num4 + " ";
						break;
					case 22:
						result = "连环飞舞+" + num4 + " ";
						break;
					case 23:
						result = "必杀一击+" + num4 + " ";
						break;
					case 24:
						result = "狂风万破+" + num4 + " ";
						break;
					case 25:
						result = "护身罡气+" + num4 + " ";
						break;
					case 26:
						result = "移花接木+" + num4 + " ";
						break;
					case 27:
						result = "回柳身法+" + num4 + " ";
						break;
					case 28:
						result = "怒海狂澜+" + num4 + " ";
						break;
					case 29:
						result = "冲冠一怒+" + num4 + " ";
						break;
					case 30:
						result = "金钟罩气+" + num4 + " ";
						break;
					case 31:
						result = "运气疗伤+" + num4 + " ";
						break;
					case 32:
						result = "连环飞舞+" + num4 + " ";
						break;
					case 33:
						result = "必杀一击+" + num4 + " ";
						break;
					case 34:
						result = "狂风万破+" + num4 + " ";
						break;
					case 35:
						result = "横练太保+" + num4 + " ";
						break;
					case 36:
						result = "乾坤挪移+" + num4 + " ";
						break;
					case 37:
						result = "灵甲护身+" + num4 + " ";
						break;
					case 38:
						result = "狂神降世+" + num4 + " ";
						break;
					case 39:
						result = "转守为攻+" + num4 + " ";
						break;
					case 40:
						result = "百步穿杨+" + num4 + " ";
						break;
					case 41:
						result = "猎鹰之眼+" + num4 + " ";
						break;
					case 42:
						result = "弓凝神聚气+" + num4 + " ";
						break;
					case 43:
						result = "必杀一击+" + num4 + " ";
						break;
					case 44:
						result = "狂风万破+" + num4 + " ";
						break;
					case 45:
						result = "正本培元+" + num4 + " ";
						break;
					case 46:
						result = "心神凝聚+" + num4 + " ";
						break;
					case 47:
						result = "流星三矢+" + num4 + " ";
						break;
					case 48:
						result = "锐利之箭+" + num4 + " ";
						break;
					case 49:
						result = "弓无明暗矢+" + num4 + " ";
						break;
					case 50:
						result = "运气行心+" + num4 + " ";
						break;
					case 51:
						result = "太极心法+" + num4 + " ";
						break;
					case 52:
						result = "体血倍增+" + num4 + " ";
						break;
					case 53:
						result = "洗髓易经+" + num4 + " ";
						break;
					case 54:
						result = "妙手回春+" + num4 + " ";
						break;
					case 55:
						result = "长功攻击+" + num4 + " ";
						break;
					case 56:
						result = "吸星大法+" + num4 + " ";
						break;
					case 57:
						result = "必杀一击+" + num4 + " ";
						break;
					case 58:
						result = "天佑之气+" + num4 + " ";
						break;
					case 59:
						result = "九天真气+" + num4 + " ";
						break;
					case 110:
						result = "流光乱舞+" + num4 + " ";
						break;
					case 120:
						result = "无坚不摧+" + num4 + " ";
						break;
					case 130:
						result = "末日狂舞+" + num4 + " ";
						break;
					case 140:
						result = "致命绝杀+" + num4 + " ";
						break;
					case 150:
						result = "万物回春+" + num4 + " ";
						break;
					}
					break;
				case "9":
					result = "升级成功率+" + num4 + "% ";
					break;
				case "12":
					result = "获得金钱+" + num4 + "% ";
					break;
				case "13":
					result = "死亡损失经验减少" + num4 + "% ";
					break;
				case "15":
					result = "经验获得+" + num4 + "% ";
					break;
				}
				break;
			}
			case 7:
			{
				int num3 = int.Parse(ysqh.Substring(ysqh.Length - 2, 2));
				string text = ysqh.Substring(0, 2);
				string a = text;
				if (!(a == "10"))
				{
					if (a == "11")
					{
						result = "武功防御+" + num3 + " ";
					}
				}
				else
				{
					result = "追加伤害+" + num3 + " ";
				}
				break;
			}
			case 8:
			{
				int num2 = int.Parse(ysqh.Substring(6, 2));
				switch (ysqh.Substring(0, 1))
				{
				case "1":
					result = "攻击力+" + num2 + " ";
					break;
				case "2":
					result = "防御力+" + num2 + " ";
					break;
				case "3":
					result = "生命力+" + num2 + " ";
					break;
				case "4":
					result = "内功力+" + num2 + " ";
					break;
				case "5":
					result = "命中率+" + num2 + " ";
					break;
				case "6":
					result = "回避率+" + num2 + " ";
					break;
				case "7":
					result = "武功攻击力+" + num2 + "% ";
					break;
				case "8":
					switch (int.Parse(ysqh.Substring(4, 2)))
					{
					case 0:
						result = "全部气功等级+" + num2 + " ";
						break;
					case 10:
						result = "力劈华山+" + num2 + " ";
						break;
					case 11:
						result = "摄魂一击+" + num2 + " ";
						break;
					case 12:
						result = "连环飞舞+" + num2 + " ";
						break;
					case 13:
						result = "必杀一击+" + num2 + " ";
						break;
					case 14:
						result = "狂风万破+" + num2 + " ";
						break;
					case 15:
						result = "四两千斤+" + num2 + " ";
						break;
					case 16:
						result = "霸气破甲+" + num2 + " ";
						break;
					case 17:
						result = "真武绝击+" + num2 + " ";
						break;
					case 18:
						result = "暗影绝杀+" + num2 + " ";
						break;
					case 19:
						result = "稳如泰山+" + num2 + " ";
						break;
					case 20:
						result = "长虹贯日+" + num2 + " ";
						break;
					case 21:
						result = "百变神行+" + num2 + " ";
						break;
					case 22:
						result = "连环飞舞+" + num2 + " ";
						break;
					case 23:
						result = "必杀一击+" + num2 + " ";
						break;
					case 24:
						result = "狂风万破+" + num2 + " ";
						break;
					case 25:
						result = "护身罡气+" + num2 + " ";
						break;
					case 26:
						result = "移花接木+" + num2 + " ";
						break;
					case 27:
						result = "回柳身法+" + num2 + " ";
						break;
					case 28:
						result = "怒海狂澜+" + num2 + " ";
						break;
					case 29:
						result = "冲冠一怒+" + num2 + " ";
						break;
					case 30:
						result = "金钟罩气+" + num2 + " ";
						break;
					case 31:
						result = "运气疗伤+" + num2 + " ";
						break;
					case 32:
						result = "连环飞舞+" + num2 + " ";
						break;
					case 33:
						result = "必杀一击+" + num2 + " ";
						break;
					case 34:
						result = "狂风万破+" + num2 + " ";
						break;
					case 35:
						result = "横练太保+" + num2 + " ";
						break;
					case 36:
						result = "乾坤挪移+" + num2 + " ";
						break;
					case 37:
						result = "灵甲护身+" + num2 + " ";
						break;
					case 38:
						result = "狂神降世+" + num2 + " ";
						break;
					case 39:
						result = "转守为攻+" + num2 + " ";
						break;
					case 40:
						result = "百步穿杨+" + num2 + " ";
						break;
					case 41:
						result = "猎鹰之眼+" + num2 + " ";
						break;
					case 42:
						result = "弓凝神聚气+" + num2 + " ";
						break;
					case 43:
						result = "必杀一击+" + num2 + " ";
						break;
					case 44:
						result = "狂风万破+" + num2 + " ";
						break;
					case 45:
						result = "正本培元+" + num2 + " ";
						break;
					case 46:
						result = "心神凝聚+" + num2 + " ";
						break;
					case 47:
						result = "流星三矢+" + num2 + " ";
						break;
					case 48:
						result = "锐利之箭+" + num2 + " ";
						break;
					case 49:
						result = "弓无明暗矢+" + num2 + " ";
						break;
					case 50:
						result = "运气行心+" + num2 + " ";
						break;
					case 51:
						result = "太极心法+" + num2 + " ";
						break;
					case 52:
						result = "体血倍增+" + num2;
						break;
					case 53:
						result = "洗髓易经+" + num2 + " ";
						break;
					case 54:
						result = "妙手回春+" + num2 + " ";
						break;
					case 55:
						result = "长功攻击+" + num2 + " ";
						break;
					case 56:
						result = "吸星大法+" + num2 + " ";
						break;
					case 57:
						result = "必杀一击+" + num2 + " ";
						break;
					case 58:
						result = "天佑之气+" + num2 + " ";
						break;
					case 59:
						result = "九天真气+" + num2 + " ";
						break;
					case 110:
						result = "流光乱舞+" + num2 + " ";
						break;
					case 120:
						result = "无坚不摧+" + num2 + " ";
						break;
					case 130:
						result = "末日狂舞+" + num2 + " ";
						break;
					case 140:
						result = "致命绝杀+" + num2 + " ";
						break;
					case 150:
						result = "万物回春+" + num2 + " ";
						break;
					}
					break;
				case "9":
					result = "升级成功率+" + num2 + " %";
					break;
				case "12":
					result = "获得金钱+" + num2 + " %";
					break;
				case "13":
					result = "死亡损失经验减少" + num2 + "% ";
					break;
				case "15":
					result = "经验获得+" + num2 + "% ";
					break;
				}
				break;
			}
			case 9:
			{
				int num = int.Parse(ysqh.Substring(ysqh.Length - 5, 5));
				switch (ysqh.Substring(0, 2))
				{
				case "10":
					result = "追加伤害+" + num + " ";
					break;
				case "11":
					result = "武功防御力+" + num + " ";
					break;
				case "12":
					result = "获得金钱+" + num + "% ";
					break;
				case "13":
					result = "死亡损失经验减少" + num + "% ";
					break;
				case "15":
					result = "经验获得+" + num + "% ";
					break;
				}
				break;
			}
			}
			return result;
		}

		public string 得到物品说明(int FLD_MAGIC0, int FLD_MAGIC1, int FLD_MAGIC2, int FLD_MAGIC3, int FLD_MAGIC4, int 初级附魂, int 中级附魂, int 进化, int 绑定, string username, string 分区)
		{
			switch (分区)
			{
			case "d1":
				分区 = "一区";
				break;
			case "d2":
				分区 = "二区";
				break;
			case "d3":
				分区 = "三区";
				break;
			}
			string text = "[" + 得到强化字符(FLD_MAGIC0.ToString()) + 得到属性字符(FLD_MAGIC1.ToString()) + 得到属性字符(FLD_MAGIC2.ToString()) + 得到属性字符(FLD_MAGIC3.ToString()) + 得到属性字符(FLD_MAGIC4.ToString()) + "][" + 得到初级附魂字符(初级附魂.ToString()) + "][" + 得到中级附魂字符(中级附魂.ToString()) + "][" + 得到进化字符(进化.ToString()) + "]";
			if (绑定 > 0)
			{
				text += "-物品绑定，购买后无法交易";
			}
			return text + "卖家<FONT color=#EE00EE><B>[" + username + "]-[" + 分区 + "]</B></FONT>";
		}

		public void 检察PK积分数据(int PK积分, int 类型)
		{
			if (PK积分 < 0)
			{
				MainForm.WriteLine(100, "PK积分数据异常[" + Userid + "]-[" + UserName + "] [" + FLD_RXPIONT + "] [" + PK积分 + "]");
			}
			if (类型 == 0)
			{
				FLD_PK积分 -= PK积分;
			}
			else
			{
				FLD_PK积分 += PK积分;
			}
		}

		public void 保存PK积分数据()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "PlayersBes_保存PK积分数据()");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE [TBL_ACCOUNT] SET FLD_PKJF = {1} WHERE FLD_ID = '{0}'", Userid, FLD_PK积分);
			if (DBA.ExeSqlCommand(stringBuilder.ToString(), "rxjhaccount") == -1)
			{
				MainForm.WriteLine(1, "保存ID PK积分 数据出错[" + Userid + "]-[" + UserName + "]");
			}
		}

		public void 保存积分数据()
		{
			if (World.JlMsg == 1)
			{
				MainForm.WriteLine(0, "PlayersBes_保存积分数据()");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("UPDATE [TBL_ACCOUNT] SET FLD_RXPIONTX = {1} WHERE FLD_ID = '{0}'", Userid, FLD_积分);
			if (DBA.ExeSqlCommand(stringBuilder.ToString(), "rxjhaccount") == -1)
			{
				MainForm.WriteLine(1, "保存ID 积分 数据出错[" + Userid + "]-[" + UserName + "]");
			}
		}

		public void 有新传书提示()
		{
			foreach (个人传书类 value in 传书列表.Values)
			{
				if (value.是否已读 == 0)
				{
					byte[] array = Converter.hexStringToByte("AA551000010000B200010002000000000000F1A755AA");
					Client.Send(array, array.Length);
				}
			}
		}

		public void 更新传书列表()
		{
			try
			{
				if (传书列表 == null || 传书列表.Count <= 0)
				{
					return;
				}
				发包类 发包类 = new 发包类();
				发包类.Write1(0);
				发包类.Write2(传书列表.Count);
				foreach (个人传书类 value in 传书列表.Values)
				{
					发包类.Write4(value.传书ID);
					发包类.Write1(value.是否NPC);
					发包类.WriteName(value.传书发送人);
					发包类.Write1(0);
					发包类.Write4(0);
					发包类.Write1(value.传书时间.Year - 2000);
					发包类.Write1(value.传书时间.Month);
					发包类.Write1(value.传书时间.Day);
					发包类.Write1(value.传书时间.Hour);
					发包类.Write1(value.传书时间.Minute);
					发包类.Write2(value.是否已读);
				}
				if (Client != null)
				{
					Client.SendPak(发包类, 45568, 人物全服ID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "查看传书出错()出错" + 人物全服ID + "|   " + ex.Message);
			}
		}
	}
}
