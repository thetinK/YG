using Newtonsoft.Json;
using RxjhServer.DbClss;
using RxjhServer.HelperTools;
using RxjhServer.Network;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace RxjhServer
{
	public class World
	{
		public static int 红字标识;

		public static string 师傅增强属性;

		public static string 徒弟增强属性;

		public static int 假人死亡几次换位置;

		public static int 假人获得武勋计时器;

		public static int 假人势力战参与人数;

		public static string 分区ID;

		public static int 上线属性提示开关;

		public static Dictionary<string, string> 势力战掉线玩家;

		public static int 势力战正人数;

		public static int 势力战邪人数;

		public static int 物品数据;

		public static int 新手上线礼包;

		public static int BOOS总开关;

		public static int BOSS进程;

		public static int BOSS假人参与数;

		public static int 等级相差提示;

		public static int 封印宝盒开启;

		public static int 转换职业功能是否开启;

		public static int 转换职业所需物品类型;

		public static int 转换职业需要人物等级;

		public static int 转换职业需要物品PID;

		public static int 转换职业需要元宝数量;

		public static int 剑皇圣地地图;

		public static int 剑皇圣地武勋;

		public static int 是否活动互通;

		public static string[] 武林血战星期几开放;

		public static List<坐标Class> 乱斗地区;

		public static string[] 排位榜第一名奖励;

		public static string[] 排位榜第二名奖励;

		public static string[] 排位榜第三名奖励;

		public static string[] 排位榜第四名奖励;

		public static string[] 排位榜第五名奖励;

		public static string[] 排位榜第六名奖励;

		public static string[] 排位榜第七名奖励;

		public static string[] 排位榜第八名奖励;

		public static string[] 排位榜第九名奖励;

		public static string[] 排位榜第十名奖励;

		public static string[] 前十第一名奖励;

		public static string[] 前十第二名奖励;

		public static string[] 前十第三名奖励;

		public static string[] 前十第四名奖励;

		public static string[] 前十第五名奖励;

		public static string[] 前十第六名奖励;

		public static string[] 前十第七名奖励;

		public static string[] 前十第八名奖励;

		public static string[] 前十第九名奖励;

		public static string[] 前十第十名奖励;

		public static string[] 花榜前十第一名奖励;

		public static string[] 花榜前十第二名奖励;

		public static string[] 花榜前十第三名奖励;

		public static string[] 花榜前十第四名奖励;

		public static string[] 花榜前十第五名奖励;

		public static string[] 花榜前十第六名奖励;

		public static string[] 花榜前十第七名奖励;

		public static string[] 花榜前十第八名奖励;

		public static string[] 花榜前十第九名奖励;

		public static string[] 花榜前十第十名奖励;

		public static string[] 八彩属性增加;

		public static int 咕咕鸡ID;

		public static int 宝珠武器ID;

		public static int 宝珠衣服ID;

		public static int 宝珠护手ID;

		public static int 宝珠鞋子ID;

		public static int 宝珠内甲ID;

		public static int 宝珠武器高级ID;

		public static int 宝珠衣服高级ID;

		public static int 宝珠护手高级ID;

		public static int 宝珠鞋子高级ID;

		public static int 宝珠内甲高级ID;

		public static int 宝珠武器稀有ID;

		public static int 宝珠衣服稀有ID;

		public static int 宝珠护手稀有ID;

		public static int 宝珠鞋子稀有ID;

		public static int 宝珠内甲稀有ID;

		public static int 宝珠武器传说ID;

		public static int 宝珠衣服传说ID;

		public static int 宝珠护手传说ID;

		public static int 宝珠鞋子传说ID;

		public static int 宝珠内甲传说ID;

		public static string 定制咕咕鸡属性;

		public static int 是否开启咕咕鸡属性重置;

		public static string 咕咕鸡属性;

		public static string 宝珠武器属性;

		public static string 宝珠武器高级属性;

		public static string 宝珠武器稀有属性;

		public static string 宝珠武器传说属性;

		public static string 宝珠衣服属性;

		public static string 宝珠衣服高级属性;

		public static string 宝珠衣服稀有属性;

		public static string 宝珠衣服传说属性;

		public static string 宝珠鞋子属性;

		public static string 宝珠鞋子高级属性;

		public static string 宝珠鞋子稀有属性;

		public static string 宝珠鞋子传说属性;

		public static string 宝珠护手属性;

		public static string 宝珠护手高级属性;

		public static string 宝珠护手稀有属性;

		public static string 宝珠护手传说属性;

		public static string 宝珠内甲属性;

		public static string 宝珠内甲高级属性;

		public static string 宝珠内甲稀有属性;

		public static string 宝珠内甲传说属性;

		public static int 红包雨结束时间;

		public static int 红包雨开启小时;

		public static int 红包雨开启分;

		public static int 红包雨开启秒;

		public static string 开启抢红包命令;

		public static string 关闭抢红包命令;

		public static string 抢红包命令;

		public static int 比武泡点进程;

		public static int 比武泡点倒计时;

		public static int 比武泡点总时间;

		public static int 比武泡点是否开启;

		public static double 比武场经验基数;

		public static int 比武泡点元宝基数;

		public static int 比武泡点元宝时间;

		public static int 比武泡点武勋基数;

		public static int 比武泡点金钱基数;

		public static int 比武泡点开启小时;

		public static int 比武泡点开启分;

		public static int 比武泡点开启秒;

		public static string 比武泡点开启时间星期;

		public static string 武林血战开启时间星期;

		public static 比武泡点系统 ArenaIdling;

		public static ConcurrentDictionary<string, 比武泡点TopClass> 比武泡点Top;

		public static double 经验条长度;

		public static double 寄售获得钻石比例;

		public static int 寄售系统是否开启;

		public static int 是否开启同势力门派;

		public static int 是否可以寄售绑定装备;

		public static string 物品锁定;

		public static ConcurrentDictionary<int, 讨伐战队伍类> 讨伐队伍;

		public static 双倍扣武勋 开启双倍扣武勋;

		public static int 讨伐副本最少人数;

		public static int 讨伐副本最多人数;

		public static int 讨伐副本时长;

		public static 讨伐战系统 讨伐战副本;

		public static int 群体辅助组队范围;

		public static int 群医加经验开关;

		public static int 群医加爆率;

		public static double 医生群疗经验加成;

		public static int 自动存取时间;

		public static int 打怪说话时间;

		public static int 内挂打怪说话时间;

		public static int 双倍扣武勋倍数;

		public static string 双倍扣武勋公告内容;

		public static int 双倍扣武勋结束时间;

		public static int 双倍扣武勋元宝数量;

		public static string 离线挂机打架命令;

		public static string 离线挂机打怪命令;

		public static string 离线挂机提示内容;

		public static string 在线挂机提示内容;

		public static int 离线挂机打怪范围;

		public static int 自动拾取开关;

		public static string 假人自动商店命令;

		public static string 假人关闭商店命令;

		public static int 假人当前卖物品阶段;

		public static string[] 假人出售物品;

		public static string[] 假人自动商店起名头;

		public static DateTime 膜拜大神时间间隔;

		public static int OfflineBots;

		public static int 是否给假人武器强化;

		public static int 是否给假人开安全模式;

		public static int 全部假人安全模式;

		public static int 假人获得武勋;

		public static int 假人自动转生;

		public static int 假人智能PK;

		public static int 假人自动转生计时器;

		public static int 假人自动结婚;

		public static int 假人气功开关;

		public static int 假人死亡提示;

		public static int 假人是否参加势力战;

		public static int 假人是否参加个人战;

		public static int 假人是否参加乱斗战;

		public static int 假人接受组队;

		public static int 假人打怪喊话;

		public static int 假人发呆提示;

		public static int 假人参与BOSS开关;

		public static int 假人上线获得装备模式;

		public static int 假人加入门派;

		public static int 假人PK功能是否开启;

		public static Dictionary<int, BotCoordinates> BotMonsters;

		public static Dictionary<int, BotChatMessage> BotChatMessages;

		public static List<TBL_假人出售物品> 假人出售物品列表;

		public static double ServerVer;

		public static double ServerVerD;

		public static string ServerRegTime;

		public static string[] 移动速度;

		public static string[] 充值排行比例;

		public static int 限制连环飞舞确认时间;

		public static int MainServer;

		public static bool Droplog;

		public static int ServerIDStart;

		public static int OfflineCount;

		public static int 假人数量;

		public static int CloudAfkCount;

		public static int 假人开商店;

		public static int 假人关商店;

		public static string Key1;

		public static string Key2;

		public static AtapiDevice Keyk;

		public static int 初始占领日期;

		public static string 天魔神宫占领者;

		public static string 天魔临时占领者;

		public static string 门战占领者;

		public static DateTime 天魔神宫占领时间;

		public static DateTime 天魔神宫奖励时间;

		public static List<门派联盟申请状态> 门派联盟申请状态;

		public static List<Players> 参加红包列表;

		public static ConcurrentDictionary<string, Players> 申请仙魔大战人物列表;

		public static ThreadSafeDictionary<int, 客户端IP地址> IpList;

		public static ThreadSafeDictionary<string, Players> PrivateTeams;

		public static 全服经验 EnableServerWideExp;

		public static 异口同声 EnableUnisonSpeech;

		public static 伏魔洞副本 伏魔洞副本;

		public static 野外BOSS FieldBoss;

		public static int 伏魔洞限制等级;

		public static int 野外BOSS开关;

		public static int 野外BOSS倒计时;

		public static int 野外BOSS总时间;

		public static string 野外BOSS时间;

		public static string 野外BOSS配置;

		public static boss攻城 BossSiege;

		public static int BOSS攻城倒计时;

		public static int BOSS攻城时间;

		public static int BOSS攻城是否开启;

		public static int BOSS攻城开启小时;

		public static int BOSS攻城开启分;

		public static int BOSS攻城开启秒;

		public static 世界BOSS WorldBoss;

		public static int 世界BOSS攻城进程;

		public static int 世界BOSS攻城倒计时;

		public static int 世界BOSS攻城时间;

		public static int 世界BOSS攻城是否开启;

		public static int 世界BOSS攻城开启小时;

		public static int 世界BOSS攻城开启分;

		public static int 世界BOSS攻城开启秒;

		public static int BOSS血;

		public static int BOSS攻击;

		public static int BOSS防御;

		public static int BOSSPID;

		public static int BOSS地图;

		public static int BOSS坐标X;

		public static int BOSS坐标Y;

		public static bool 自动换端口同步变量;

		public static int AllItmelog;

		public static int 是否开启共用银币市场;

		public static int 是否开启跨线活动;

		public static int 当前是否是银币线路;

		public static int 活动开启中;

		public static int 打开换线线路1;

		public static int 打开换线线路2;

		public static int 打开换线线路3;

		public static int 打开换线线路4;

		public static int 打开换线线路5;

		public static int 打开换线线路6;

		public static int 打开换线线路7;

		public static int 打开换线线路8;

		public static int 打开换线线路9;

		public static int 打开换线线路10;

		public static int 打开换线线路11;

		public static int 打开换线线路12;

		public static int 允许开店;

		public static int 允许交易;

		public static int 允许挂机;

		public static int 报错踢号次数;

		public static int 连续快速攻击次数;

		public static int 连续攻击有效时间;

		public static int 非法攻击外挂操作;

		public static bool AlWorldlog;

		public static bool Process;

		public static Players AdminPlayer;

		public static object lockLogin;

		public static object AsyncLocksw;

		public static ConcurrentDictionary<int, 装备检测类> 装备检测list;

		public static ThreadSafeDictionary<int, NetState> ConnectionList;

		public static List<int> 普通气功ID;

		public static ConcurrentDictionary<string, 仙魔大战top> 仙魔Top;

		public static ThreadSafeDictionary<int, Players> AllConnectedPlayers;

		public static 武林血战 PersonalBloodBattle;

		public static ConcurrentDictionary<string, string> 禁言列表;

		public static ConcurrentDictionary<int, 升天气功总类> 升天气功List;

		public static ConcurrentDictionary<int, 任务类> 任务list;

		public static ConcurrentDictionary<string, DbClass> Db;

		public static Queue DisposedQueue;

		public static Queue SqlPool;

		public static ConcurrentDictionary<int, MapClass> Map;

		public static ConcurrentDictionary<int, 帮战Class> 帮战list;

		public static ConcurrentDictionary<int, 帮战Class> 帮战Namelist;

		public static ConcurrentDictionary<int, string> Maplist;

		public static ConcurrentDictionary<int, NpcClass> NpcList;

		public static ConcurrentDictionary<int, Wedding> 婚礼list;

		public static ConcurrentDictionary<int, 门派成员> 门派成员list;

		public static ConcurrentDictionary<int, 百宝阁类> 百宝阁属性物品类list;

		public static ConcurrentDictionary<int, 百宝阁类> 百宝阁抽奖物品类list;

		public static ConcurrentDictionary<int, PVP类> PVP装备;

		public static List<NpcClass> 一转地图;

		public static List<NpcClass> 二转地图;

		public static List<NpcClass> 三转地图;

		public static List<NpcClass> 四转地图;

		public static List<NpcClass> 五转地图;

		public static List<NpcClass> 六转地图;

		public static List<NpcClass> 七转地图;

		public static List<NpcClass> 八转地图;

		public static List<NpcClass> 九转地图;

		public static string 临时GM命令;

		public static string 临时管理员;

		public static int 老泫勃派开关;

		public static int 新门战进程;

		public static int 攻击时间间隔;

		public static int AtPort;

		public static bool 龙赡殿是否在使用中;

		public static bool 华婚殿是否在使用中;

		public static bool 圣礼殿是否在使用中;

		public static int 最大速度超出次数操作;

		public static int 三十秒内允许超出次数;

		public static int 周末武勋量;

		public static string 装备升级命令;

		public static string 福利命令;

		public static string 首充命令;

		public static string 转生命令;

		public static int 限制转生次数;

		public static int 转生需要等级;

		public static int 转生需要几转;

		public static int 转生降落几转;

		public static int 转生回落等级;

		public static string 转生获得属性;

		public static int 天气系统开关;

		public static int 无限负重;

		public static int PK掉装备;

		public static int PK掉装备几率;

		public static int PK掉装备善恶;

		public static int 开启下雪场景;

		public static int 八彩提示是否开启;

		public static string 八彩红色提示内容;

		public static string 八彩赤色提示内容;

		public static string 八彩橙色提示内容;

		public static string 八彩绿色提示内容;

		public static string 八彩蓝色提示内容;

		public static string 八彩深蓝提示内容;

		public static string 八彩紫色提示内容;

		public static string 八彩浅色提示内容;

		public static int 二转每日武勋上限;

		public static int 三转每日武勋上限;

		public static int 四转每日武勋上限;

		public static int 五转每日武勋上限;

		public static int 六转每日武勋上限;

		public static int 七转每日武勋上限;

		public static int 八转每日武勋上限;

		public static int 九转每日武勋上限;

		public static int 十转每日武勋上限;

		public static int 是否开启上线BUFF;

		public static int 是否开启任务领取;

		public static int 补偿的任务物品ID;

		public static int 异口同声是否开启;

		public static int 异口同声开启中;

		public static int 异口同声开启时;

		public static int 异口同声开启分;

		public static int 异口同声开启秒;

		public static int 异口同声结束时间;

		public static string 异口同声内容;

		public static int 双倍奖励是否开启;

		public static int 双倍奖励开启小时;

		public static int 双倍奖励开启分;

		public static int 双倍奖励开启秒;

		public static double 双倍奖励经验倍数;

		public static int 双倍奖励爆率倍数;

		public static int 双倍奖励武勋倍数;

		public static int 双倍奖励结束时间;

		public static string 双倍奖励公告内容;

		public static double 三十五级以下经验倍数;

		public static double 六十级以下经验倍数;

		public static double 八十级以下经验倍数;

		public static double 百级以下经验倍数;

		public static double 升天一以下经验倍数;

		public static double 升天二以下经验倍数;

		public static double 升天三以下经验倍数;

		public static double 升天四以下经验倍数;

		public static double 升天五以下经验倍数;

		public static List<int> 限制PK地图列表;

		public static List<int> 限时PK地图列表;

		public static int 限时地图开PK时间;

		public static int 限时地图关PK时间;

		public static int 限时地图是否开启;

		public static int 周末全天PK是否开启;

		public static double 经验提高倍数;

		public static int 高倍经验开始时间;

		public static int 高倍经验结束时间;

		public static List<int> 周末全天PK地图列表;

		public static int 工作日限时地图开PK时间;

		public static int 工作日限时地图关PK时间;

		public static int 工作日限时地图是否开启;

		public static int 门战准备时间;

		public static int 门战总时间;

		public static int 武林血战是否开启;

		public static int 武林血战开启小时;

		public static int 武林血战开启分;

		public static int 武林血战开启秒;

		public static int 武林血战参战等级;

		public static string 武林血战参加奖励;

		public static string 武林血战第一回合奖励;

		public static string 武林血战第二回合奖励;

		public static string 武林血战第三回合奖励;

		public static int MartialBloodBattleProgress;

		public static int 武林血战人数;

		public static bool 线程同步变量;

		public static bool AutoPortSwitching;

		public static List<DropClass> Drop_Jl;

		public static ConcurrentDictionary<string, string> 仙魔大战掉线玩家;

		public static ConcurrentDictionary<int, 荣誉Class> 武林血战排行数据;

		public static ConcurrentDictionary<int, 荣誉Class> 杀人排行数据;

		public static List<门派排名> 门派排名数据;

		public static List<势力排名> 势力排名数据;

		public static List<武林排名> 武林排名数据;

		public static List<讨伐排名> 讨伐排名数据;

		public static double 武功防御力控制;

		public static double 武功攻击力倍数;

		public static int 开启卡技能;

		public static int 卡技能次数;

		public static int 坐标刷新时间;

		public static int 攻击时间控制;

		public static int 贡献元宝数;

		public static int 贡献元宝荣誉点;

		public static int Script;

		public static int 双倍经验等级上限;

		public static int 双倍金钱等级上限;

		public static int 双倍历练等级上限;

		public static int 双倍暴率等级上限;

		public static double 双倍等级上限倍数;

		public static int 英雄职业转职需要武器;

		public static int 限制最高级别;

		public static int 发包单个物品大小;

		public static int 数据库单个物品大小;

		public static int 物品属性大小;

		public static int 升天技能等级加成;

		public static int 外挂PK时间;

		public static int 外挂打怪时间;

		public static int AutGC;

		public static double locklist;

		public static double locklist2;

		public static List<object> locklist3;

		public static int 每次狮吼功消耗元宝;

		public static string 信任连接IP;

		public static int 允许多开数量;

		public static int 在线多开数量;

		public static int 是否开启多开提示;

		public static int 是否开启票红字;

		public static int 是否开启票红字2;

		public static int 是否开启安全码;

		public static int 记录多开数量;

		public static int 是否开启门战系统;

		public static int 开启门战系统;

		public static int 开启攻城战系统;

		public static int 攻城战时长;

		public static int 攻城战预备时间;

		public static int 攻城战开启小时;

		public static int 攻城战开启分;

		public static int 攻城战开启秒;

		public static int 申请门战需要元宝;

		public static int 门战系统开启时;

		public static int 门战系统开启分;

		public static int 门战系统开启秒;

		public static int 胜利帮派ID;

		public static int 每次分解消耗元宝数;

		public static int 游戏登陆端口最大连接数;

		public static int 游戏登陆端口最大连接时间数;

		public static int 查非法物品;

		public static int 查非法物品操作;

		public static bool 查绑定非法物品;

		public static int 物品最高攻击值;

		public static int 物品最高防御值;

		public static int 物品最高生命值;

		public static int 物品最高内功值;

		public static int 物品最高命中值;

		public static int 物品最高回避值;

		public static int 物品最高武功值;

		public static int 物品最高气功值;

		public static int 物品最高合成值;

		public static int 物品最高附魂值;

		public static int 物品最高武防值;

		public static int 组队级别限制;

		public static int 心跳检测开关;

		public static int 是否开启等级奖励;

		public static int 心跳检测时间阀值;

		public static int 心跳检测时长;

		public static int 安全模式消耗元宝;

		public static int 是否开启安全模式;

		public static string[] 安全模式时间;

		public static int 是否开启新手上线设置;

		public static int 登录器版本切换;

		public static int 上线等级;

		public static int 赠送气功书;

		public static int 上线转职等级;

		public static int 上线金币数量;

		public static int 上线历练数量;

		public static int 上线武勋设置;

		public static int 上线升天气功点;

		public static int 自动分配正邪;

		public static int 银票兑换元宝;

		public static int 是否开启银票兑换元宝;

		public static int 上线送礼包是否开启;

		public static int 转职赠送礼包;

		public static int 上线送礼包套装;

		public static int 获得经验等级差;

		public static string[] 获得物品等级差;

		public static int 移动间隔时间;

		public static int 是否开启装备加解锁功能;

		public static int 装备加锁消耗元宝;

		public static int 装备解锁消耗元宝;

		public static int 是否开启挂机奖励;

		public static int 挂机奖励时间周期;

		public static int 挂机抽奖时间周期;

		public static int 普通挂机奖励元宝;

		public static int 会员挂机奖励元宝;

		public static int 普通挂机奖励钻石;

		public static int 会员挂机奖励钻石;

		public static int 会员挂机奖励武勋;

		public static int 挂机奖励抽奖次数;

		public static int 普通挂机奖励武勋;

		public static int 挂机消除宠物忠诚度;

		public static int 挂机奖励要求等级;

		public static int 挂机抽奖要求等级;

		public static string 挂机双倍区域BOSS;

		public static bool 双倍区域BOSS是否开启;

		public static string 挂机双倍时间段;

		public static int 购买武勋装备消耗武勋;

		public static int BOSS掉落物品数量下限;

		public static int BOSS掉落物品数量上限;

		public static int 世界BOSS掉落元宝概率;

		public static int 世界BOSS掉落元宝最小;

		public static int 世界BOSS掉落元宝最大;

		public static int 世界BOSS掉落金钱概率;

		public static int 世界BOSS掉落金钱最小;

		public static int 世界BOSS掉落金钱最大;

		public static int 是否开启公告掉落提示;

		public static int 是否支持扩展物品属性位数;

		public static int 安全挂机时间;

		public static double 武器防具进化2成功几率;

		public static double 二人组队经验加成;

		public static double 三人组队经验加成;

		public static double 四人组队经验加成;

		public static double 五人组队经验加成;

		public static double 六人组队经验加成;

		public static double 七人组队经验加成;

		public static double 八人组队经验加成;

		public static double 灵宠进化率;

		public static double 灵宠强化率;

		public static double 道具强化概率;

		public static int 武器PK掉耐久度;

		public static int 防具PK掉耐久度;

		public static double 刀PK伤害参数;

		public static double 剑PK伤害参数;

		public static double 枪PK伤害参数;

		public static double 弓PK伤害参数;

		public static double 医PK伤害参数;

		public static double 刺PK伤害参数;

		public static double 乐PK伤害参数;

		public static double 韩PK伤害参数;

		public static double 谭PK伤害参数;

		public static double 拳PK伤害参数;

		public static double 梅PK伤害参数;

		public static double 卢PK伤害参数;

		public static double 神女PK伤害参数;

		public static int 单次交易元宝数量上限;

		public static string 修炼药品;

		public static string 遗忘药品;

		public static string 皮皮岛药品;

		public static string 世外药品;

		public static int 帐号总元宝上限;

		public static int 元宝检测操作;

		public static int 是否开启武勋系统;

		public static int PK等级差;

		public static int 武勋保护等级;

		public static string 死亡减少武勋数量;

		public static string 系统回收数量;

		public static double 武勋回收百分比;

		public static int 物品记录;

		public static int 登陆记录;

		public static int 掉落记录;

		public static int 开盒记录;

		public static int 商店记录;

		public static int 药品记录;

		public static int 合成记录;

		public static int 进化记录;

		public static int 传书记录;

		public static int 卡号记录;

		public static int 记录保存天数;

		public static int 传书保存天数;

		public static bool 封IP;

		public static List<IPAddress> BipList;

		public static int AutoReconnectInterval;

		public static int 版本验证时间;

		public static bool MainSocket;

		public static string SocketState;

		public static bool 自动开启连接;

		public static int MaxAllowedConnections;

		public static bool 断开连接;

		public static bool 加入过滤列表;

		public static bool 关闭连接;

		public static int 世界时间;

		public static int W组队Id;

		public static int ver;

		public static int tf;

		public static int JlMsg;

		public static int week;

		public static int 是否允许快速攻击;

		public static int 是否开启四神系统;

		public static int 外挂检测操作;

		public static int 仙魔大战进程;

		public static int 仙魔大战进入等级;

		public static int 攻城战进入等级;

		public static int 仙魔大战时间;

		public static int 仙魔大战正分数;

		public static int 仙魔大战邪分数;

		public static int 仙魔大战正人数;

		public static int 仙魔大战邪人数;

		public static int 仙魔大战是否开启;

		public static int 仙魔大战开启小时;

		public static int 仙魔大战开启分;

		public static int 仙魔大战开启秒;

		public static int 仙魔大战时长;

		public static int 仙魔大战预备时间;

		public static int 武林血战奖励礼包;

		public static int 第一名奖励礼包;

		public static int 是否开启对练场赌元宝;

		public static int 允许玩家押注数量;

		public static float 场地有效范围;

		public static int 进场最低费用;

		public static double 场地佣金百分比;

		public static int 允许逃跑次数;

		public static int 分数扣完扣除元宝;

		public static int 分数扣完扣除金钱;

		public static int Eve90进程;

		public static int Eve90时间;

		public static ThreadSafeDictionary<int, Players> evePlayers;

		public static ConcurrentDictionary<int, 比武泡点奖励> 比武泡点奖励;

		public static bool isvip;

		public static int 元宝合成;

		public static long 最大钱数;

		public static double SendSpeed;

		public static string laozhu;

		public static double BroadcastSendSpeed;

		public static double ReceiveSpeed;

		public static double 经验倍数;

		public static int 吸魂机率;

		public static int 钱倍数;

		public static int 历练倍数;

		public static int 钱总倍率;

		public static int 历练总倍率;

		public static int 升天历练总倍率;

		public static int 属性替换失败率;

		public static double 升天历练倍数;

		public static int 暴率;

		public static double 合成率;

		public static double 强化率;

		public static double 赋予属性率;

		public static double 附魂率;

		public static double 首饰加工率;

		public static double 披风强化率;

		public static double 装备升级率;

		public static double 首饰升级率;

		public static string 百宝阁地址;

		public static string 百宝阁服务器IP;

		public static int 百宝阁服务器端口;

		public static string 帐号验证服务器IP;

		public static int 帐号验证服务器端口;

		public static int GameServerPort;

		public static int CurrentGameServerPort;

		public static int 游戏服务器端口2;

		public static int 游戏服务器端口3;

		public static int 转发器网关服务端口;

		public static int vip线;

		public static int MaxOnline;

		public static int 服务器组ID;

		public static int ServerID;

		public static string ServerName;

		public static string 进入公告;

		public static string sql;

		public static int Gamedayov;

		public static AtapiDevice KeykF;

		public static int 狮子吼ID;

		public static Queue LionRoarList;

		public static ConcurrentDictionary<int, 攻城战> 攻城战list;

		public static List<Players> 申请攻城人物列表;

		public static ConcurrentDictionary<int, 攻城数据> 攻城数据list;

		public static ConcurrentDictionary<int, GuildWarData> guildWarDataList;

		public static int 吸怪数量;

		public static int 吸怪距离;

		public static int 移动坐标异常后反弹;

		public static int 开启实时坐标检测;

		public static int 是否开启实时坐标显示;

		public static int 实时检测距离;

		public static float 普通走;

		public static float 轻功一;

		public static float 轻功二;

		public static float 轻功三;

		public static int 实时移动时间;

		public static float 宠物普通走;

		public static float 韩轻功一;

		public static float 韩轻功二;

		public static float 韩轻功三;

		public static float 韩轻功四;

		public static int 天魔神宫雕像是否死亡;

		public static int 天魔神宫大门是否死亡;

		public static int 天魔神宫东门是否死亡;

		public static int 攻城战进程;

		public static int 城门强化等级;

		public static int 攻城时间;

		public static int 狮子吼最大数;

		public static int 是否加密;

		public static int 元宝送积分是否开启;

		public static int 百宝消费榜是否开启;

		public static string 加密密钥;

		public static string 赞助大使名字;

		public static byte[] g_cur_key;

		public static byte[] g_cur_key2;

		public static int 是否加密2;

		public static int 封包封号;

		public static int 组队等级限制;

		public static int 特效道具ID;

		public static int Vip上线公告;

		public static string Vip上线公告内容;

		public static string 神豪上线公告内容;

		public static string 普通上线公告内容;

		public static int 是否开启前十上线公告;

		public static string 前十上线公告内容;

		public static string VIP地图;

		public static string 地图锁定;

		public static string SqlJl;

		public static int 元宝检测;

		public static int 装备最大数;

		public static int AutoSave;

		public static double 至尊强化率;

		public static string 灵宠强化总概率;

		public static double 灵宠强化一阶段概率;

		public static double 灵宠强化二阶段概率;

		public static double 灵宠强化三阶段概率;

		public static double 灵宠强化四阶段概率;

		public static double 灵宠强化五阶段概率;

		public static double 灵宠强化六阶段概率;

		public static double 灵宠强化七阶段概率;

		public static long 王龙的金币;

		public static int 是否开启王龙;

		public static int 是否开启GM功能;

		public static double 九泉金币比率;

		public static double 其他地图金币比率;

		public static int 王龙地图ID;

		public static string 文件MD5;

		public static string 再造金刚石攻击;

		public static string 再造金刚石追伤;

		public static string 再造金刚石武功;

		public static string 再造金刚石命中;

		public static string 再造金刚石生命;

		public static string 再造寒玉石防御;

		public static string 再造寒玉石回避;

		public static string 再造寒玉石生命;

		public static string 再造寒玉石内功;

		public static string 再造寒玉石武防;

		public static double 武功防增加百分比;

		public static double 武功防降低百分比;

		public static double 武功攻击力百分比;

		public static double 攻减防加乘;

		public static double 武功减武防加乘;

		public static int 是否开启死亡掉经验;

		public static double VIP经验增加百分比;

		public static double VIP历练增加百分比;

		public static double VIP金钱增加百分比;

		public static double VIP合成率增加百分比;

		public static string[] VIP称号增加攻击;

		public static string[] VIP称号增加防御;

		public static string[] VIP称号增加生命;

		public static double 宝珠进化概率;

		public static double 水晶赋予属性一阶段;

		public static double 水晶赋予属性二阶段;

		public static double 水晶赋予属性三阶段;

		public static double 水晶赋予属性四阶段;

		public static double 水晶赋予属性五阶段;

		public static double 水晶赋予属性六阶段;

		public static double 水晶赋予属性七阶段;

		public static double 水晶赋予属性八阶段;

		public static double 水晶赋予属性九阶段;

		public static double 水晶赋予属性十阶段;

		public static double 中魂成功几率;

		public static double 四神成功几率;

		public static double 医生PK距离;

		public static double 弓箭手PK距离;

		public static double 其他职业PK距离;

		public static double 医生打怪距离;

		public static double 弓箭手打怪距离;

		public static double 其他职业打怪距离;

		public static int VIP爆率增加;

		public static int 披风强化是否消耗元宝;

		public static int 披风强化最大数量;

		public static int 披风强化消耗元宝数量;

		public static int 灵宠强化是否消耗武皇币;

		public static int 灵宠强化最大数量;

		public static int 灵宠强化消耗武皇币数量;

		public static double 天关经验提高百分比基数;

		public static double 天关经验提高百分比递增;

		public static int 天关物品爆率提高基数;

		public static int 天关物品爆率提高递增;

		public static int wg40;

		public static int wg39;

		public static int wg38;

		public static int wg37;

		public static int wg36;

		public static int wg35;

		public static int wg34;

		public static int wg33;

		public static int wg32;

		public static int wg31;

		public static int wg30;

		public static int wg29;

		public static int wg28;

		public static int wg27;

		public static int wg26;

		public static int wg25;

		public static int wg24;

		public static int wg23;

		public static int wg22;

		public static int wg21;

		public static int wg20;

		public static int wf120;

		public static int wf118;

		public static int wf116;

		public static int wf114;

		public static int wf112;

		public static int wf110;

		public static int wf100;

		public static int wf98;

		public static int wf96;

		public static int wf95;

		public static int wf94;

		public static int wf92;

		public static int wf90;

		public static int wf85;

		public static int wf80;

		public static int wf78;

		public static int wf76;

		public static int wf74;

		public static int wf72;

		public static int wf70;

		public static int wf68;

		public static int g25;

		public static int g24;

		public static int g23;

		public static int g22;

		public static int g21;

		public static int g20;

		public static int f15;

		public static int f14;

		public static int f13;

		public static int f12;

		public static int f11;

		public static int f10;

		public static int 装备提真消耗;

		public static int 装备提真数量;

		public static string 门战参与奖励物品;

		public static string[] 门战奖励;

		public static int 门战奖励物品ID;

		public static int 修炼之地是否开启;

		public static int 修炼之地开启ID;

		public static string 随机BOSS出现时间表;

		public static int 是否开启锁人攻击检测;

		public static int 锁人攻击次数上限;

		public static int 锁人攻击检测操作;

		public static string ipaddress;

		public static ConcurrentDictionary<int, CraftingItem> craftingItemsList;

		public static ConcurrentDictionary<int, 制药物品类> 制药物品列表;

		public static string 进入传书内容;

		public static string 进入传书发送人;

		public static string 贡献元宝命令;

		public static string 贡献物品命令;

		public static string[] 门派第一称号奖励;

		public static string[] 门派第二称号奖励;

		public static string[] 门派第三称号奖励;

		public static string[] 玫瑰第一名奖励;

		public static string[] 玫瑰第二名奖励;

		public static string[] 玫瑰第三名奖励;

		public static string[] 玫瑰第四名奖励;

		public static string[] 玫瑰第五名奖励;

		public static string[] 花榜第一名奖励;

		public static string[] 花榜第二名奖励;

		public static string[] 花榜第三名奖励;

		public static string[] 花榜第四名奖励;

		public static string[] 花榜第五名奖励;

		public static string[] 地图限制等级;

		public static string[] 强化数量大于发送快报;

		public static string ZoneNumber;

		public static int 是否开启元宝商店;

		public static 攻城Class SiegeWar;

		public static object 地面物品Lock;

		public static object 开箱Lock;

		public static ConcurrentDictionary<int, double> lever;

		public static ConcurrentDictionary<int, 武勋加成类> Wxlever;

		public static ConcurrentDictionary<int, AnnouncementClass> 公告;

		public static ConcurrentDictionary<int, 等级奖励类> 等级奖励;

		public static ConcurrentDictionary<int, 气功加成属性> 气功加成;

		public static ConcurrentDictionary<int, 物品兑换类> 物品兑换;

		public static ThreadSafeDictionary<long, 地面物品类> ItemTemp;

		public static ConcurrentDictionary<int, botCoord> MonSter;

		public static ConcurrentDictionary<int, ItmeClass> Itme;

		public static ConcurrentDictionary<int, 武功类> TBL_KONGFU;

		public static ConcurrentDictionary<int, TeamClass> Teams;

		public static ConcurrentDictionary<int, BbgSellClass> 百宝阁数据;

		public static ConcurrentDictionary<int, 物品回收类> 物品回收数据;

		public static ConcurrentDictionary<int, 披风收录> 披风收录buff;

		public static ConcurrentDictionary<int, 装备洗髓> 装备洗髓系统;

		public static ConcurrentDictionary<int, 英雄职业武器> 英雄职业武器系统;

		public static ConcurrentDictionary<int, 累计充值礼包> 累计充值礼包;

		public static 帮派战_血战 血战;

		public static 帮派战_门战 GuildWar;

		public static List<ShopClass> Shop;

		public static List<检查物品类> 物品检查;

		public static List<KillClass> Kill;

		public static List<DropClass> Drop;

		public static List<DropClass> Drop_GS;

		public static List<DropClass> BossDrop;

		public static List<OpenClass> Open;

		public static List<MoveClass> Mover;

		public static List<坐标Class> 移动;

		public static List<坐标Class> 自动得奖励地区;

		public static List<攻城怪物> 攻城怪物列表;

		public static List<伏魔洞怪物> 伏魔洞怪物列表;

		public static List<ItemSellClass> 套装数据;

		public static 仙魔大战Class ImmortalDemonWar;

		public static 仙魔战循环公告 仙魔战公告;

		public static 攻城战循环公告 攻城战公告;

		public static string 势力战胜利奖励物品;

		public static string 势力战参与奖励物品;

		public static string 仙魔大战胜利奖励物品;

		public static string 仙魔大战失败奖励物品;

		public static string 仙魔大战平局奖励物品;

		public static string 天魔胜利奖励物品;

		public static string 天魔失败奖励物品;

		public static ThreadSafeDictionary<int, Players> allPVPChars;

		public static ConcurrentDictionary<int, 安全区Class> 地图安全区;

		public static Dictionary<int, 消耗提示> 消耗提示数据;

		public static Dictionary<int, PkNotification> PkNotificationData;

		public static Dictionary<int, ItemContributionData> ItemContributionData;

		public static List<坐标Class> 对练区;

		public static List<坐标Class> 仙魔大战区域;

		public static List<坐标Class> 势力战区域;

		public static List<坐标Class> 帮战区;

		public static List<坐标Class> 比武泡点区;

		public static EvePVPClass EVEPVP;

		public static List<int> BOSSListTime;

		public static int Log;

		public static int 验证服务器log;

		public static int jllog;

		public static ScriptClass 脚本;

		public static Connect conn;

		public static int 每次消耗的数量;

		public static int 每次再造消耗设置;

		public static int 平砍间隔时间;

		public static double 首饰加工一概率;

		public static double 首饰加工二概率;

		public static double 首饰加工三概率;

		public static double 首饰加工四概率;

		public static double 首饰加工五概率;

		public static double 首饰加工六概率;

		public static double 首饰加工七概率;

		public static double 首饰加工八概率;

		public static double 首饰加工九概率;

		public static double 首饰加工十概率;

		public static double 赋予属性一阶段;

		public static double 赋予属性二阶段;

		public static double 赋予属性三阶段;

		public static double 赋予属性四阶段;

		public static double 赋予属性五阶段;

		public static double 赋予属性六阶段;

		public static double 赋予属性七阶段;

		public static double 赋予属性八阶段;

		public static double 赋予属性九阶段;

		public static double 赋予属性十阶段;

		public static double 强化一合成率;

		public static double 强化二合成率;

		public static double 强化三合成率;

		public static double 强化四合成率;

		public static double 强化五合成率;

		public static double 强化六合成率;

		public static double 强化七合成率;

		public static double 强化八合成率;

		public static double 强化九合成率;

		public static double 强化十合成率;

		public static double 强化十一合成率;

		public static double 强化十二合成率;

		public static double 强化十三合成率;

		public static double 强化十四合成率;

		public static double 强化十五合成率;

		public static double 水晶符强1;

		public static double 水晶符强2;

		public static double 水晶符强3;

		public static double 水晶符强4;

		public static double 水晶符强5;

		public static double 水晶符强6;

		public static double 水晶符强7;

		public static double 水晶符强8;

		public static double 水晶符强9;

		public static double 水晶符强10;

		public static double 至尊取玉强11;

		public static double 至尊取玉强12;

		public static double 至尊取玉强13;

		public static double 至尊取玉强14;

		public static double 至尊取玉强15;

		public static string[] 至高无上称号奖励;

		public static string[] 举世无双称号奖励;

		public static string[] 雄霸天下称号奖励;

		public static string[] 孤胆英雄称号奖励;

		public static string[] 英雄豪杰称号奖励;

		public static int 参与钻石奖励数量;

		public static int 深渊第一名钻石奖励数量;

		public static int 深渊第二名钻石奖励数量;

		public static int 深渊第三名钻石奖励数量;

		public static int 深渊第410名元宝奖励数量;

		public static int 深渊第一名boss奖励物品;

		public static int 深渊第二名boss奖励物品;

		public static int 深渊第三名boss奖励物品;

		public static int 讨伐第一名钻石奖励数量;

		public static int 讨伐第二名钻石奖励数量;

		public static int diamonds;

		public static int 讨伐第410名元宝奖励数量;

		public static int 讨伐第一名boss奖励物品;

		public static int 讨伐第二名boss奖励物品;

		public static int 讨伐第三名boss奖励物品;

		public static string 开箱提示内容;

		public static double 刺客攻击倍数;

		public static double 弓手攻击倍数;

		public static int 制作进化一概率;

		public static int 制作进化二概率;

		public static int 武器8阶段添加攻击;

		public static int 武器9阶段添加攻击;

		public static int 武器10阶段添加攻击;

		public static int 武器11阶段添加攻击;

		public static int 武器12阶段添加攻击;

		public static int 武器13阶段添加攻击;

		public static int 武器14阶段添加攻击;

		public static int 武器15阶段添加攻击;

		public static int 衣服8阶段添加防御;

		public static int 衣服9阶段添加防御;

		public static int 衣服10阶段添加防御;

		public static int 衣服11阶段添加防御;

		public static int 衣服12阶段添加防御;

		public static int 衣服13阶段添加防御;

		public static int 衣服14阶段添加防御;

		public static int 衣服15阶段添加防御;

		public static int 护手8阶段添加防御;

		public static int 护手9阶段添加防御;

		public static int 护手10阶段添加防御;

		public static int 护手11阶段添加防御;

		public static int 护手12阶段添加防御;

		public static int 护手13阶段添加防御;

		public static int 护手14阶段添加防御;

		public static int 护手15阶段添加防御;

		public static int 鞋子8阶段添加防御;

		public static int 鞋子9阶段添加防御;

		public static int 鞋子10阶段添加防御;

		public static int 鞋子11阶段添加防御;

		public static int 鞋子12阶段添加防御;

		public static int 鞋子13阶段添加防御;

		public static int 鞋子14阶段添加防御;

		public static int 鞋子15阶段添加防御;

		public static int 内甲8阶段添加防御;

		public static int 内甲9阶段添加防御;

		public static int 内甲10阶段添加防御;

		public static int 内甲11阶段添加防御;

		public static int 内甲12阶段添加防御;

		public static int 内甲13阶段添加防御;

		public static int 内甲14阶段添加防御;

		public static int 内甲15阶段添加防御;

		public static double 荣誉排行榜更新时间;

		public static string 清理绑定背包命令;

		public static int 伤害排行1;

		public static int 伤害排行2;

		public static int 伤害排行3;

		public static int 伤害排行4;

		public static int 伤害排行5;

		public static int 伤害排行6;

		public static int 伤害排行7;

		public static int 伤害排行8;

		public static int 伤害排行9;

		public static int 伤害排行10;

		public static int 伤害排行11;

		public static int 伤害排行12;

		public static int 伤害排行13;

		public static int 伤害排行14;

		public static int 伤害排行15;

		public static int 伤害排行16;

		public static int 伤害排行17;

		public static int 伤害排行18;

		public static int 伤害排行19;

		public static int 伤害排行20;

		public static string 账号排行1;

		public static string 账号排行2;

		public static string 账号排行3;

		public static string 账号排行4;

		public static string 账号排行5;

		public static string 账号排行6;

		public static string 账号排行7;

		public static string 账号排行8;

		public static string 账号排行9;

		public static string 账号排行10;

		public static string 账号排行11;

		public static string 账号排行12;

		public static string 账号排行13;

		public static string 账号排行14;

		public static string 账号排行15;

		public static string 账号排行16;

		public static string 账号排行17;

		public static string 账号排行18;

		public static string 账号排行19;

		public static string 账号排行20;

		public static int FirstPlaceDamage;

		public static int 讨伐伤害排行2;

		public static int 讨伐伤害排行3;

		public static int 讨伐伤害排行4;

		public static int 讨伐伤害排行5;

		public static int 讨伐伤害排行6;

		public static int 讨伐伤害排行7;

		public static int 讨伐伤害排行8;

		public static int 讨伐伤害排行9;

		public static int 讨伐伤害排行10;

		public static string FirstPlaceUserId;

		public static string 讨伐账号排行2;

		public static string 讨伐账号排行3;

		public static string 讨伐账号排行4;

		public static string 讨伐账号排行5;

		public static string 讨伐账号排行6;

		public static string 讨伐账号排行7;

		public static string 讨伐账号排行8;

		public static string 讨伐账号排行9;

		public static string 讨伐账号排行10;

		public static int 是否开启打坐打怪;

		public static double 怪物防御百分比;

		public static double 怪物攻击百分比;

		public static double 剑对怪物伤害;

		public static double 刀对怪物伤害;

		public static double 枪对怪物伤害;

		public static double 弓对怪物伤害;

		public static double 医对怪物伤害;

		public static double 刺对怪物伤害;

		public static double 琴对怪物伤害;

		public static double 韩对怪物伤害;

		public static double 谭对怪物伤害;

		public static double 拳对怪物伤害;

		public static double 梅对怪物伤害;

		public static double 卢对怪物伤害;

		public static double 神女对怪物伤害;

		public static string 换线命令;

		public static int 坐牢系统是否开启;

		public static string 监狱地图;

		public static int 坐牢善恶;

		public static int 坐牢善恶恢复间隔;

		public static int 坐牢恢复善恶值;

		public static string 坐牢回城坐标;

		public static string 坐牢杀人公告;

		public static string 刑满释放公告;

		public static int 斗神称号激活方式;

		public static int 斗神称号需要数量;

		public static int 搜索组队ID;

		public static int 势力战开始时向其它线广播;

		public static int 同IP势力战不计分;

		public static int 势力战进程;

		public static int 势力战正分数;

		public static int 势力战邪分数;

		public static int 势力战正派参战人数;

		public static int 势力战邪派参战人数;

		public static int 势力战是否开启;

		public static int 势力战开启分;

		public static int 势力战开启秒;

		public static string 势力战设置;

		public static int 势力战开启自动踢人;

		public static string 势力战踢人设置;

		public static int 势力战打死大怪得分;

		public static int 势力战打死小怪得分;

		public static List<KeyValuePair<int, int>> 势力战踢人方案;

		public static ConcurrentDictionary<int, 势力战场次> 所有势力战场次;

		public static int 势力战参加最低转职;

		public static int 势力战参加最高转职;

		public static int 势力战类型;

		public static int 势力战战斗时间;

		public static int 势力战预备时间;

		public static EventClass eve;

		public static ConcurrentDictionary<string, Players> 申请势力人物列表;

		public static int 势力战正派申请人数;

		public static int 势力战邪派申请人数;

		public static string 势力怪暴热血石;

		public static ConcurrentDictionary<string, EventTopClass> EventTop;

		public static double 属性一合成率;

		public static double 属性二合成率;

		public static double 属性三合成率;

		public static double 属性四合成率;

		public void clear()
		{
			wg40 = 0;
			wg39 = 0;
			wg38 = 0;
			wg37 = 0;
			wg36 = 0;
			wg35 = 0;
			wg34 = 0;
			wg33 = 0;
			wg32 = 0;
			wg31 = 0;
			wg30 = 0;
			wg29 = 0;
			wg28 = 0;
			wg27 = 0;
			wg26 = 0;
			wg25 = 0;
			wg24 = 0;
			wg23 = 0;
			wg22 = 0;
			wg21 = 0;
			wg20 = 0;
			wf120 = 0;
			wf118 = 0;
			wf116 = 0;
			wf114 = 0;
			wf112 = 0;
			wf110 = 0;
			wf100 = 0;
			wf98 = 0;
			wf96 = 0;
			wf95 = 0;
			wf94 = 0;
			wf92 = 0;
			wf90 = 0;
			wf85 = 0;
			wf80 = 0;
			wf78 = 0;
			wf76 = 0;
			wf74 = 0;
			wf72 = 0;
			wf70 = 0;
			wf68 = 0;
			g25 = 0;
			g24 = 0;
			g23 = 0;
			g22 = 0;
			g21 = 0;
			g20 = 0;
			f15 = 0;
			f14 = 0;
			f13 = 0;
			f12 = 0;
			f11 = 0;
			f10 = 0;
		}

		public static void UpdateAllRankingData()
		{
			try
			{
				武林血战排行数据.Clear();
				DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT  top  10  *  FROM  TBL_荣誉系统  where  FLD_类型  =  2  and FLD_帮派门主='" + ZoneNumber + "' Order  By  FLD_分数  Desc");
				if (dBToDataTable != null && dBToDataTable.Rows.Count != 0)
				{
					for (int j = 0; j < dBToDataTable.Rows.Count; j++)
					{
						武林血战排行数据.TryAdd(j, new 荣誉Class
						{
							人物名 = dBToDataTable.Rows[j]["FLD_人物名"].ToString(),
							帮派 = dBToDataTable.Rows[j]["FLD_帮派"].ToString(),
							职业 = (int)dBToDataTable.Rows[j]["FLD_职业"],
							势力 = (int)dBToDataTable.Rows[j]["FLD_势力"],
							等级 = (int)dBToDataTable.Rows[j]["FLD_等级"],
							分数 = (int)dBToDataTable.Rows[j]["FLD_分数"],
							帮派门主 = ZoneNumber,
							类型 = 2
						});
					}
				}
				dBToDataTable.Dispose();
				杀人排行数据.Clear();
				DataTable dBToDataTable2 = DBA.GetDBToDataTable("SELECT top 10 * FROM TBL_荣誉系统 where FLD_类型 = 6 Order By FLD_分数 Desc");
				if (dBToDataTable2 != null && dBToDataTable2.Rows.Count != 0)
				{
					for (int i = 0; i < dBToDataTable2.Rows.Count; i++)
					{
						杀人排行数据.TryAdd(i, new 荣誉Class
						{
							人物名 = dBToDataTable2.Rows[i]["FLD_人物名"].ToString(),
							帮派 = dBToDataTable2.Rows[i]["FLD_帮派"].ToString(),
							职业 = (int)dBToDataTable2.Rows[i]["FLD_职业"],
							势力 = (int)dBToDataTable2.Rows[i]["FLD_势力"],
							等级 = (int)dBToDataTable2.Rows[i]["FLD_等级"],
							分数 = (int)dBToDataTable2.Rows[i]["FLD_分数"],
							类型 = 6
						});
					}
				}
				dBToDataTable2.Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "更新所有排行数据错误" + ex.Message);
			}
		}

		public static void 发送全服大武圣称号获得消息(string name, int zx)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA55BA0060000051B400010000000A000000BC17000000000000000000000000000000000000000000000000000033300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				byte[] bytes = Encoding.Default.GetBytes(name);
				Buffer.BlockCopy(bytes, 0, array, 46, bytes.Length);
				if (zx == 2)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(6077), 0, array, 18, 2);
				}
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.Client != null)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(value.人物全服ID), 0, array, 4, 2);
						value.Client.Send(array, array.Length);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "World发送全服武勋称号获得消息数据出错![" + name + "]" + ex.Message);
			}
		}

		public static void 发送全服武勋称号获得消息(string name, int zx)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA55C200E8040051B400010000000A00000064110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				byte[] bytes = Encoding.Default.GetBytes(name);
				Buffer.BlockCopy(bytes, 0, array, 46, bytes.Length);
				if (zx == 1)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(4451), 0, array, 18, 2);
				}
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.Client != null)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(value.人物全服ID), 0, array, 4, 2);
						value.Client.Send(array, array.Length);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "World发送全服武勋称号获得消息数据出错![" + name + "]" + ex.Message);
			}
		}

		public static byte[] 封包转换(byte[] data, int length, int 类型)
		{
			if (类型 == 0)
			{
				byte[] array = new byte[length + 1];
				Buffer.BlockCopy(data, 0, array, 0, 4);
				Buffer.BlockCopy(data, 4, array, 5, length - 4);
				Buffer.BlockCopy(BitConverter.GetBytes(data[2] + 1), 0, array, 2, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(data[8] + 1), 0, array, 9, 2);
				return array;
			}
			byte[] array2 = new byte[length - 1];
			Buffer.BlockCopy(data, 0, array2, 0, 4);
			Buffer.BlockCopy(data, 5, array2, 4, length - 5);
			Buffer.BlockCopy(BitConverter.GetBytes(array2.Length - 6), 0, array2, 2, 2);
			Buffer.BlockCopy(BitConverter.GetBytes(array2.Length - 12), 0, array2, 8, 2);
			return array2;
		}

		public static int 计算玩家下注结果(int 分数1, int 分数2, int 专场代码)
		{
			int num = RNG.Next(0, 9) + 分数1 + 分数2;
			try
			{
				int num2 = 0;
				int num3 = 0;
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (!value.Client.挂机 && value.是否押注 && value.押注专场代码 == 专场代码)
					{
						if (value.押注单双 == "单")
						{
							num2++;
						}
						else
						{
							num3++;
						}
					}
				}
				if (num % 2 == 0)
				{
					if (num3 != 0 && num2 != 0)
					{
						int num4 = (int)((double)(num2 * 允许玩家押注数量) * (1.0 - 场地佣金百分比) / (double)num3);
						foreach (Players value2 in AllConnectedPlayers.Values)
						{
							if (!value2.Client.挂机 && value2.是否押注 && value2.押注专场代码 == 专场代码)
							{
								if (value2.押注单双 == "双")
								{
									value2.CheckTreasureGems();
									value2.检察元宝数据(num4, 1, "下注");
									value2.SaveGemData();
									value2.系统提示("恭喜你，这回出的是【双】数。", 13, "系统提示");
									RxjhClass.百宝记录(value2.Userid, value2.UserName, 0.0, "押注赢", 1, num4);
								}
								else
								{
									value2.CheckTreasureGems();
									value2.检察元宝数据(允许玩家押注数量, 0, "下注");
									value2.SaveGemData();
									value2.系统提示("手气真差，这回出的是【双】数。", 13, "系统提示");
									RxjhClass.百宝记录(value2.Userid, value2.UserName, 0.0, "押注输", 1, 允许玩家押注数量);
								}
								value2.押注单双 = string.Empty;
								value2.押注专场代码 = 0;
								value2.是否押注 = false;
								value2.元宝账户状态 = false;
							}
						}
					}
					else if (num2 == 0)
					{
						foreach (Players value3 in AllConnectedPlayers.Values)
						{
							if (!value3.Client.挂机 && value3.是否押注 && value3.押注专场代码 == 专场代码)
							{
								if (value3.押注单双 == "双")
								{
									value3.CheckTreasureGems();
									value3.检察元宝数据((int)((double)允许玩家押注数量 * 场地佣金百分比), 0, "下注");
									value3.SaveGemData();
									value3.系统提示("由于本场无人压【单】数, 系统将扣除压【双】数玩家手续费" + (int)((double)允许玩家押注数量 * 场地佣金百分比) + "元宝！", 13, "系统提示");
									RxjhClass.百宝记录(value3.Userid, value3.UserName, 0.0, "押注手续费", 1, (int)((double)允许玩家押注数量 * 场地佣金百分比));
								}
								value3.押注单双 = string.Empty;
								value3.押注专场代码 = 0;
								value3.是否押注 = false;
								value3.元宝账户状态 = false;
							}
						}
					}
					else if (num3 == 0)
					{
						foreach (Players value4 in AllConnectedPlayers.Values)
						{
							if (!value4.Client.挂机 && value4.是否押注 && value4.押注专场代码 == 专场代码)
							{
								if (value4.押注单双 == "单")
								{
									value4.CheckTreasureGems();
									value4.检察元宝数据(允许玩家押注数量, 0, "下注");
									value4.SaveGemData();
									value4.系统提示("手气真差, 这回出的是【双】数。", 13, "系统提示");
									RxjhClass.百宝记录(value4.Userid, value4.UserName, 0.0, "押注输", 1, 允许玩家押注数量);
								}
								value4.押注单双 = string.Empty;
								value4.押注专场代码 = 0;
								value4.是否押注 = false;
								value4.元宝账户状态 = false;
							}
						}
					}
				}
				else if (num2 != 0 && num3 != 0)
				{
					int num5 = (int)((double)(num3 * 允许玩家押注数量) * (1.0 - 场地佣金百分比) / (double)num2);
					foreach (Players value5 in AllConnectedPlayers.Values)
					{
						if (!value5.Client.挂机 && value5.是否押注 && value5.押注专场代码 == 专场代码)
						{
							if (value5.押注单双 == "单")
							{
								value5.CheckTreasureGems();
								value5.检察元宝数据(num5, 1, "下注");
								value5.SaveGemData();
								value5.系统提示("恭喜你，这回出的是【单】数。", 13, "系统提示");
								RxjhClass.百宝记录(value5.Userid, value5.UserName, 0.0, "押注赢", 1, num5);
							}
							else
							{
								value5.CheckTreasureGems();
								value5.检察元宝数据(允许玩家押注数量, 0, "下注");
								value5.SaveGemData();
								value5.系统提示("手气真差，这回出的是【单】数。", 13, "系统提示");
								RxjhClass.百宝记录(value5.Userid, value5.UserName, 0.0, "押注输", 1, 允许玩家押注数量);
							}
							value5.押注单双 = string.Empty;
							value5.押注专场代码 = 0;
							value5.是否押注 = false;
							value5.元宝账户状态 = false;
						}
					}
				}
				else if (num3 == 0)
				{
					foreach (Players value6 in AllConnectedPlayers.Values)
					{
						if (!value6.Client.挂机 && value6.是否押注 && value6.押注专场代码 == 专场代码)
						{
							if (value6.押注单双 == "单")
							{
								value6.CheckTreasureGems();
								value6.检察元宝数据((int)((double)允许玩家押注数量 * 场地佣金百分比), 0, "下注");
								value6.SaveGemData();
								value6.系统提示("由于本场无人压【双】数, 系统将扣除压【单】数玩家手续费" + (int)((double)允许玩家押注数量 * 场地佣金百分比) + "元宝。", 13, "系统提示");
								RxjhClass.百宝记录(value6.Userid, value6.UserName, 0.0, "押注手续费", 1, (int)((double)允许玩家押注数量 * 场地佣金百分比));
							}
							value6.押注单双 = string.Empty;
							value6.押注专场代码 = 0;
							value6.是否押注 = false;
							value6.元宝账户状态 = false;
						}
					}
				}
				else if (num2 == 0)
				{
					foreach (Players value7 in AllConnectedPlayers.Values)
					{
						if (!value7.Client.挂机 && value7.是否押注 && value7.押注专场代码 == 专场代码)
						{
							if (value7.押注单双 == "双")
							{
								value7.CheckTreasureGems();
								value7.检察元宝数据(允许玩家押注数量, 0, "下注");
								value7.SaveGemData();
								value7.系统提示("手气真差，这回出的是【单】数。", 13, "系统提示");
								RxjhClass.百宝记录(value7.Userid, value7.UserName, 0.0, "押注输", 1, 允许玩家押注数量);
							}
							value7.押注单双 = string.Empty;
							value7.押注专场代码 = 0;
							value7.是否押注 = false;
							value7.元宝账户状态 = false;
						}
					}
				}
				return num;
			}
			catch
			{
				return num;
			}
		}

		public static Players 检查玩家(string Userid)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				if (value.Userid == Userid)
				{
					return value;
				}
			}
			return null;
		}

		public static Players 检查玩家世界ID(int ID)
		{
			Players value;
			return (!AllConnectedPlayers.TryGetValue(ID, out value)) ? null : value;
		}

		public static Players 检查玩家name(string Username)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				if (value.UserName == Username)
				{
					return value;
				}
			}
			return null;
		}

		public static void 发送公告(string msg)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				if (!value.Client.挂机)
				{
					value.系统公告(msg);
				}
			}
		}

		public static void 发送游戏特殊公告(string A_0, int A_1, string A_2)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				value.系统提示(A_0, A_1, A_2);
			}
		}

		public static void 全局倒计时提示(int int_0)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				if (!value.Client.挂机)
				{
					value.发送势力战开始倒计时(int_0);
				}
			}
		}

		public static void 系统滚动公告(string msg)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				if (!value.Client.挂机)
				{
					value.系统滚动公告(msg);
				}
			}
		}

		public static void 发送玫瑰公告(string msg)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				if (!value.Client.挂机)
				{
					value.送花公告(msg);
				}
			}
		}

		public static void Process狮子吼Queue()
		{
			if (LionRoarList.Count > 0)
			{
				狮子吼Class 狮子吼Class2 = (狮子吼Class)LionRoarList.Dequeue();
				发送狮子吼消息广播数据(狮子吼Class2.Index, 狮子吼Class2.UserName, 狮子吼Class2.TxtId, 狮子吼Class2.Txt);
			}
		}

		private int 得到气功ID(int i, int Player_Job)
		{
			int result = 0;
			foreach (气功加成属性 value in 气功加成.Values)
			{
				if (value.FLD_JOB == Player_Job && value.FLD_INDEX == i)
				{
					result = value.FLD_PID;
				}
			}
			return result;
		}

		public static void 发送狮子吼消息广播数据(int 人物全服ID, string name, int msgid, string msg)
		{
			try
			{
				byte[] array = Converter.hexStringToByte("AA55B6002D016600A800CC00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA");
				array[10] = 35;
				byte[] bytes = Encoding.Default.GetBytes(name);
				byte[] bytes2 = Encoding.Default.GetBytes(msg);
				Buffer.BlockCopy(bytes2, 0, array, 35, bytes2.Length);
				Buffer.BlockCopy(bytes, 0, array, 12, bytes.Length);
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				array[34] = (byte)msgid;
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.Client != null && !value.Client.挂机)
					{
						value.Client.Send(array, array.Length);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "World发送狮子吼消息广播数据出错![" + 人物全服ID + "]-[" + name + "]-[" + msg + "]" + ex.Message);
			}
		}

		public static string 得到职业文本(int player_job)
		{
			if (1 == 0)
			{
			}
			string result = player_job switch
			{
				1 => "刀客", 
				2 => "剑客", 
				3 => "枪客", 
				4 => "弓箭手", 
				5 => "医生", 
				6 => "刺客", 
				7 => "琴师", 
				8 => "韩飞官", 
				9 => "谭花灵", 
				10 => "格斗家", 
				11 => "梅柳真", 
				12 => "卢风郎", 
				13 => "东陵神女", 
				_ => string.Empty, 
			};
			if (1 == 0)
			{
			}
			return result;
		}

		public static void 发送全服狮子吼消息广播数据(int 人物全服ID, string name, int msgid, string msg, int 线, int map, int 样式)
		{
			try
			{
				string hex = "AA55B600E5026600A800260000000000000000000000000000000000000000000000560000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000065000000000000000000000055AA";
				byte[] array = Converter.hexStringToByte(hex);
				array[10] = (byte)样式;
				Buffer.BlockCopy(BitConverter.GetBytes(线), 0, array, 169, 2);
				Buffer.BlockCopy(BitConverter.GetBytes(map), 0, array, 174, 4);
				byte[] bytes = Encoding.Default.GetBytes(name);
				byte[] bytes2 = Encoding.Default.GetBytes(msg);
				Buffer.BlockCopy(bytes2, 0, array, 35, bytes2.Length);
				Buffer.BlockCopy(bytes, 0, array, 12, bytes.Length);
				Buffer.BlockCopy(BitConverter.GetBytes(人物全服ID), 0, array, 4, 2);
				array[34] = (byte)msgid;
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.Client != null && !value.Client.挂机)
					{
						value.Client.Send(array, array.Length);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "World发送狮子吼消息广播数据出错![" + 人物全服ID + "]-[" + name + "]-[" + msg + "]" + ex.Message);
			}
		}

		public static void 发送传音消息(int 人物全服ID, string name, string ToName, string msg, int msgType, string StringHex)
		{
			try
			{
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.UserName == ToName)
					{
						if (value.Config.传音 == 0)
						{
							value.系统提示("您有传音消息, 请打开传音开关。", 50, "系统提示");
						}
						else
						{
							value.发送传音消息(name, 人物全服ID, value, msg, msgType);
						}
						break;
					}
				}
			}
			catch
			{
			}
		}

		public static void 发送同盟聊天(string bpname, string username, string msg, int 服务器组)
		{
			try
			{
				string text = RxjhClass.取得门派联盟盟主(bpname);
				if (text == "")
				{
					return;
				}
				string hex = "AA55BE000F276600B8002001B60000000000000000000000000000000000000000000C30000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000055AA";
				byte[] array = Converter.hexStringToByte(hex);
				array[10] = 32;
				array[33] = 1;
				byte[] bytes = Encoding.Default.GetBytes(username);
				byte[] bytes2 = Encoding.Default.GetBytes(msg);
				array[34] = (byte)bytes2.Length;
				Buffer.BlockCopy(bytes2, 0, array, 35, bytes2.Length);
				Buffer.BlockCopy(bytes, 0, array, 12, bytes.Length);
				byte[] bytes3 = Encoding.Default.GetBytes(bpname);
				Buffer.BlockCopy(bytes3, 0, array, 178, bytes3.Length);
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.门派联盟盟主 == text && value.Client != null)
					{
						value.Client.Send多包(array, array.Length);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送同盟消息出错![" + username + "]-[" + bpname + "]" + ex.Message);
			}
		}

		public static void 发送帮派消息(string BpName, byte[] data, int length)
		{
			try
			{
				foreach (Players value in AllConnectedPlayers.Values)
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

		public static int Add组队(TeamClass 队)
		{
			W组队Id++;
			Teams.TryAdd(W组队Id, 队);
			return W组队Id;
		}

		static World()
		{
			红字标识 = 0;
			假人死亡几次换位置 = 15;
			假人获得武勋计时器 = 0;
			物品数据 = 73;
			BOSS进程 = 0;
			BOSS假人参与数 = 0;
			等级相差提示 = 0;
			是否给假人武器强化 = 0;
			是否给假人开安全模式 = 0;
			全部假人安全模式 = 0;
			假人获得武勋 = 0;
			假人自动转生 = 0;
			假人智能PK = 0;
			假人自动结婚 = 0;
			假人气功开关 = 0;
			假人死亡提示 = 0;
			假人是否参加势力战 = 0;
			假人是否参加个人战 = 0;
			假人是否参加乱斗战 = 0;
			假人接受组队 = 0;
			假人打怪喊话 = 0;
			假人发呆提示 = 0;
			假人参与BOSS开关 = 0;
			假人上线获得装备模式 = 0;
			假人加入门派 = 0;
			假人PK功能是否开启 = 1;
			乱斗地区 = new List<坐标Class>();
			经验条长度 = 100.0;
			寄售获得钻石比例 = 0.9;
			寄售系统是否开启 = 1;
			是否开启同势力门派 = 1;
			是否可以寄售绑定装备 = 0;
			讨伐副本最少人数 = 10;
			讨伐副本最多人数 = 30;
			讨伐副本时长 = 60;
			天魔神宫占领者 = string.Empty;
			天魔临时占领者 = string.Empty;
			门战占领者 = string.Empty;
			天魔神宫占领时间 = DateTime.Now;
			天魔神宫奖励时间 = DateTime.Now;
			BotMonsters = new Dictionary<int, BotCoordinates>();
			BotChatMessages = new Dictionary<int, BotChatMessage>();
			门派联盟申请状态 = new List<门派联盟申请状态>();
			参加红包列表 = new List<Players>();
			申请仙魔大战人物列表 = new ConcurrentDictionary<string, Players>();
			IpList = new ThreadSafeDictionary<int, 客户端IP地址>();
			PrivateTeams = new ThreadSafeDictionary<string, Players>();
			百宝阁抽奖物品类list = new ConcurrentDictionary<int, 百宝阁类>();
			信任连接IP = "";
			修炼药品 = "1008001190;1008001327;1008001502;1008001503;1008001504";
			遗忘药品 = "1008001182;1008001183;1008001184;1008001328";
			皮皮岛药品 = "1008001513";
			世外药品 = "1008002585;1008002586;1008002587";
			laozhu = "";
			物品回收数据 = new ConcurrentDictionary<int, 物品回收类>();
			披风收录buff = new ConcurrentDictionary<int, 披风收录>();
			装备洗髓系统 = new ConcurrentDictionary<int, 装备洗髓>();
			英雄职业武器系统 = new ConcurrentDictionary<int, 英雄职业武器>();
			累计充值礼包 = new ConcurrentDictionary<int, 累计充值礼包>();
			地图安全区 = new ConcurrentDictionary<int, 安全区Class>();
			坐牢杀人公告 = "{0}杀人啦！";
			刑满释放公告 = "{0}刑满释放了！";
			属性一合成率 = 100.0;
			属性二合成率 = 100.0;
			属性三合成率 = 100.0;
			属性四合成率 = 100.0;
			假人自动商店命令 = "!假人开店";
			假人关闭商店命令 = "!假人关店";
			假人当前卖物品阶段 = 1;
			假人出售物品 = new string[1200];
			在线挂机提示内容 = "我爱热血江湖";
			离线挂机提示内容 = "我爱热血江湖";
			离线挂机打怪命令 = "!离线打怪";
			离线挂机打架命令 = "!离线打架";
			离线挂机打怪范围 = 0;
			膜拜大神时间间隔 = DateTime.Now;
			自动拾取开关 = 0;
			内挂打怪说话时间 = 0;
			比武泡点开启小时 = 0;
			比武泡点开启分 = 0;
			比武泡点开启秒 = 0;
			比武泡点进程 = 0;
			比武泡点倒计时 = 3;
			比武泡点总时间 = 30;
			比武场经验基数 = 0.0;
			比武泡点元宝时间 = 0;
			比武泡点元宝基数 = 0;
			比武泡点武勋基数 = 0;
			比武泡点金钱基数 = 0;
			打怪说话时间 = 0;
			自动存取时间 = 0;
			群体辅助组队范围 = 400;
			讨伐队伍 = new ConcurrentDictionary<int, 讨伐战队伍类>();
			讨伐副本时长 = 60;
			ServerVer = 5.0;
			ServerVerD = 0.0;
			ServerRegTime = string.Empty;
			赞助大使名字 = string.Empty;
			移动速度 = new string[5];
			限制连环飞舞确认时间 = 25;
			MainServer = 1;
			Droplog = false;
			ServerIDStart = 0;
			OfflineCount = 0;
			假人数量 = 0;
			CloudAfkCount = 0;
			假人开商店 = 0;
			假人关商店 = 0;
			Key1 = "192.168.0.4";
			Key2 = "192.168.0.4";
			Keyk = new AtapiDevice();
			自动换端口同步变量 = false;
			AllItmelog = 1;
			是否开启共用银币市场 = 0;
			当前是否是银币线路 = 0;
			活动开启中 = 1;
			是否开启元宝商店 = 1;
			打开换线线路1 = 0;
			打开换线线路2 = 0;
			打开换线线路3 = 0;
			打开换线线路4 = 0;
			打开换线线路5 = 0;
			打开换线线路6 = 0;
			打开换线线路7 = 0;
			打开换线线路8 = 0;
			打开换线线路9 = 0;
			打开换线线路10 = 0;
			打开换线线路11 = 0;
			打开换线线路12 = 0;
			允许开店 = 0;
			允许交易 = 0;
			允许挂机 = 0;
			报错踢号次数 = 0;
			野外BOSS开关 = 0;
			野外BOSS时间 = "";
			野外BOSS配置 = "";
			连续快速攻击次数 = 1;
			连续攻击有效时间 = 1000;
			非法攻击外挂操作 = 0;
			AlWorldlog = true;
			Process = false;
			AdminPlayer = null;
			lockLogin = new object();
			AsyncLocksw = new object();
			装备检测list = new ConcurrentDictionary<int, 装备检测类>();
			ConnectionList = new ThreadSafeDictionary<int, NetState>();
			普通气功ID = new List<int>();
			仙魔Top = new ConcurrentDictionary<string, 仙魔大战top>();
			AllConnectedPlayers = new ThreadSafeDictionary<int, Players>();
			禁言列表 = new ConcurrentDictionary<string, string>();
			升天气功List = new ConcurrentDictionary<int, 升天气功总类>();
			任务list = new ConcurrentDictionary<int, 任务类>();
			Db = new ConcurrentDictionary<string, DbClass>();
			DisposedQueue = Queue.Synchronized(new Queue());
			SqlPool = Queue.Synchronized(new Queue());
			Map = new ConcurrentDictionary<int, MapClass>();
			帮战list = new ConcurrentDictionary<int, 帮战Class>();
			帮战Namelist = new ConcurrentDictionary<int, 帮战Class>();
			Maplist = new ConcurrentDictionary<int, string>();
			NpcList = new ConcurrentDictionary<int, NpcClass>();
			婚礼list = new ConcurrentDictionary<int, Wedding>();
			门派成员list = new ConcurrentDictionary<int, 门派成员>();
			百宝阁属性物品类list = new ConcurrentDictionary<int, 百宝阁类>();
			比武泡点Top = new ConcurrentDictionary<string, 比武泡点TopClass>();
			PVP装备 = new ConcurrentDictionary<int, PVP类>();
			一转地图 = new List<NpcClass>();
			二转地图 = new List<NpcClass>();
			三转地图 = new List<NpcClass>();
			四转地图 = new List<NpcClass>();
			五转地图 = new List<NpcClass>();
			六转地图 = new List<NpcClass>();
			七转地图 = new List<NpcClass>();
			八转地图 = new List<NpcClass>();
			九转地图 = new List<NpcClass>();
			EventTop = new ConcurrentDictionary<string, EventTopClass>();
			新门战进程 = 0;
			攻击时间间隔 = 1000;
			AtPort = 55980;
			龙赡殿是否在使用中 = false;
			华婚殿是否在使用中 = false;
			圣礼殿是否在使用中 = false;
			最大速度超出次数操作 = 0;
			三十秒内允许超出次数 = 0;
			周末武勋量 = 100000;
			二转每日武勋上限 = 0;
			三转每日武勋上限 = 0;
			四转每日武勋上限 = 0;
			五转每日武勋上限 = 0;
			六转每日武勋上限 = 0;
			七转每日武勋上限 = 0;
			八转每日武勋上限 = 0;
			九转每日武勋上限 = 0;
			十转每日武勋上限 = 0;
			是否开启上线BUFF = 0;
			是否开启任务领取 = 0;
			补偿的任务物品ID = 1000000290;
			异口同声是否开启 = 0;
			异口同声开启中 = 0;
			异口同声开启时 = 0;
			异口同声开启分 = 0;
			异口同声开启秒 = 0;
			异口同声内容 = "";
			异口同声结束时间 = 0;
			三十五级以下经验倍数 = 2.0;
			六十级以下经验倍数 = 3.0;
			八十级以下经验倍数 = 3.0;
			百级以下经验倍数 = 1.5;
			升天一以下经验倍数 = 1.5;
			升天二以下经验倍数 = 1.5;
			升天三以下经验倍数 = 1.5;
			升天四以下经验倍数 = 1.5;
			升天五以下经验倍数 = 1.5;
			限制PK地图列表 = new List<int>();
			限时PK地图列表 = new List<int>();
			限时地图开PK时间 = 19;
			限时地图关PK时间 = 23;
			限时地图是否开启 = 0;
			周末全天PK是否开启 = 0;
			周末全天PK地图列表 = new List<int>();
			经验提高倍数 = 0.0;
			高倍经验开始时间 = 20;
			高倍经验结束时间 = 22;
			工作日限时地图开PK时间 = 5;
			工作日限时地图关PK时间 = 23;
			工作日限时地图是否开启 = 1;
			门战准备时间 = 10;
			门战总时间 = 30;
			武林血战是否开启 = 0;
			武林血战开启小时 = 0;
			武林血战开启分 = 0;
			武林血战开启秒 = 0;
			武林血战参战等级 = 60;
			武林血战参加奖励 = "";
			武林血战第一回合奖励 = "";
			武林血战第二回合奖励 = "";
			武林血战第三回合奖励 = "";
			MartialBloodBattleProgress = 0;
			武林血战人数 = 0;
			线程同步变量 = false;
			AutoPortSwitching = true;
			Drop_Jl = new List<DropClass>();
			仙魔大战掉线玩家 = new ConcurrentDictionary<string, string>();
			武林血战排行数据 = new ConcurrentDictionary<int, 荣誉Class>();
			杀人排行数据 = new ConcurrentDictionary<int, 荣誉Class>();
			门派排名数据 = new List<门派排名>();
			武林排名数据 = new List<武林排名>();
			讨伐排名数据 = new List<讨伐排名>();
			势力排名数据 = new List<势力排名>();
			消耗提示数据 = new Dictionary<int, 消耗提示>();
			PkNotificationData = new Dictionary<int, PkNotification>();
			ItemContributionData = new Dictionary<int, ItemContributionData>();
			武功防御力控制 = 100.0;
			武功攻击力倍数 = 1.0;
			开启卡技能 = 1;
			卡技能次数 = 5;
			坐标刷新时间 = 3000;
			攻击时间控制 = 600;
			贡献元宝数 = 0;
			贡献元宝荣誉点 = 0;
			Script = 0;
			双倍经验等级上限 = 59;
			双倍金钱等级上限 = 59;
			双倍历练等级上限 = 59;
			双倍暴率等级上限 = 59;
			双倍等级上限倍数 = 2.0;
			限制最高级别 = 180;
			发包单个物品大小 = 96;
			数据库单个物品大小 = 73;
			物品属性大小 = 56;
			升天技能等级加成 = 3;
			外挂PK时间 = 0;
			外挂打怪时间 = 1000;
			AutGC = 0;
			locklist = 0.0;
			locklist2 = 0.0;
			locklist3 = new List<object>();
			每次狮吼功消耗元宝 = 20;
			记录多开数量 = 0;
			允许多开数量 = 2;
			在线多开数量 = 2;
			是否开启门战系统 = 0;
			开启门战系统 = 0;
			开启攻城战系统 = 0;
			攻城战时长 = 60;
			攻城战预备时间 = 3;
			攻城战开启小时 = 0;
			攻城战开启分 = 0;
			攻城战开启秒 = 0;
			申请门战需要元宝 = 0;
			门战系统开启时 = 0;
			门战系统开启分 = 0;
			门战系统开启秒 = 0;
			胜利帮派ID = 0;
			每次分解消耗元宝数 = 10;
			游戏登陆端口最大连接数 = 20;
			游戏登陆端口最大连接时间数 = 1000;
			查非法物品 = 0;
			查非法物品操作 = 3;
			查绑定非法物品 = false;
			物品最高攻击值 = 0;
			物品最高防御值 = 0;
			物品最高生命值 = 0;
			物品最高内功值 = 0;
			物品最高命中值 = 0;
			物品最高回避值 = 0;
			物品最高武功值 = 0;
			物品最高气功值 = 0;
			物品最高合成值 = 0;
			物品最高附魂值 = 0;
			物品最高武防值 = 0;
			组队级别限制 = 15;
			心跳检测开关 = 0;
			是否开启等级奖励 = 0;
			心跳检测时间阀值 = 10000;
			心跳检测时长 = 0;
			安全模式消耗元宝 = 0;
			是否开启安全模式 = 1;
			是否开启新手上线设置 = 0;
			上线等级 = 0;
			赠送气功书 = 0;
			上线转职等级 = 0;
			上线金币数量 = 0;
			上线历练数量 = 0;
			上线武勋设置 = 0;
			上线升天气功点 = 0;
			自动分配正邪 = 0;
			银票兑换元宝 = 0;
			是否开启银票兑换元宝 = 0;
			转职赠送礼包 = 1;
			上线送礼包是否开启 = 1;
			上线送礼包套装 = 0;
			获得经验等级差 = 15;
			移动间隔时间 = 600;
			是否开启装备加解锁功能 = 0;
			装备加锁消耗元宝 = 0;
			装备解锁消耗元宝 = 0;
			是否开启挂机奖励 = 0;
			挂机奖励时间周期 = 0;
			挂机抽奖时间周期 = 0;
			普通挂机奖励元宝 = 0;
			普通挂机奖励钻石 = 0;
			挂机奖励抽奖次数 = 0;
			会员挂机奖励钻石 = 0;
			会员挂机奖励武勋 = 100;
			普通挂机奖励武勋 = 50;
			挂机消除宠物忠诚度 = 0;
			挂机奖励要求等级 = 0;
			挂机抽奖要求等级 = 0;
			挂机双倍区域BOSS = "";
			双倍区域BOSS是否开启 = false;
			挂机双倍时间段 = "20;22";
			购买武勋装备消耗武勋 = 1000;
			是否支持扩展物品属性位数 = 0;
			是否开启公告掉落提示 = 0;
			BOSS掉落物品数量下限 = 10;
			BOSS掉落物品数量上限 = 30;
			武器防具进化2成功几率 = 0.0;
			世界BOSS掉落元宝概率 = 5;
			世界BOSS掉落元宝最小 = 1;
			世界BOSS掉落元宝最大 = 2;
			世界BOSS掉落金钱概率 = 10;
			世界BOSS掉落金钱最小 = 1;
			世界BOSS掉落金钱最大 = 30;
			安全挂机时间 = 0;
			会员挂机奖励元宝 = 0;
			灵宠进化率 = 0.0;
			灵宠强化率 = 0.0;
			道具强化概率 = 0.0;
			武器PK掉耐久度 = 0;
			防具PK掉耐久度 = 0;
			刀PK伤害参数 = 1.0;
			剑PK伤害参数 = 1.0;
			枪PK伤害参数 = 1.0;
			弓PK伤害参数 = 1.0;
			医PK伤害参数 = 1.0;
			刺PK伤害参数 = 1.0;
			乐PK伤害参数 = 1.0;
			韩PK伤害参数 = 1.0;
			谭PK伤害参数 = 1.0;
			拳PK伤害参数 = 1.0;
			梅PK伤害参数 = 1.0;
			卢PK伤害参数 = 1.0;
			神女PK伤害参数 = 1.0;
			单次交易元宝数量上限 = 0;
			帐号总元宝上限 = 0;
			元宝检测操作 = 0;
			是否开启武勋系统 = 0;
			PK等级差 = 20;
			武勋保护等级 = 80;
			死亡减少武勋数量 = "0;0;0;0;0;0";
			系统回收数量 = "0;0;0;0;0;0";
			武勋回收百分比 = 0.2;
			物品记录 = 0;
			登陆记录 = 0;
			掉落记录 = 0;
			开盒记录 = 0;
			商店记录 = 0;
			药品记录 = 0;
			进化记录 = 0;
			卡号记录 = 0;
			合成记录 = 0;
			传书记录 = 0;
			记录保存天数 = 30;
			传书保存天数 = 1;
			封IP = true;
			BipList = new List<IPAddress>();
			AutoReconnectInterval = 10;
			版本验证时间 = 10000;
			MainSocket = false;
			SocketState = "Stoped";
			自动开启连接 = true;
			MaxAllowedConnections = 100;
			断开连接 = true;
			加入过滤列表 = true;
			关闭连接 = true;
			世界时间 = 0;
			W组队Id = 1;
			ver = 3;
			tf = 0;
			JlMsg = 0;
			week = (int)DateTime.Now.DayOfWeek;
			转换职业功能是否开启 = 0;
			转换职业所需物品类型 = 0;
			转换职业需要元宝数量 = 0;
			转换职业需要物品PID = 0;
			转换职业需要人物等级 = 150;
			是否允许快速攻击 = 1;
			是否开启四神系统 = 0;
			外挂检测操作 = 0;
			仙魔大战进程 = 0;
			仙魔大战时间 = 0;
			仙魔大战正分数 = 0;
			仙魔大战邪分数 = 0;
			仙魔大战正人数 = 0;
			仙魔大战邪人数 = 0;
			仙魔大战是否开启 = 0;
			仙魔大战开启小时 = 0;
			仙魔大战开启分 = 0;
			仙魔大战开启秒 = 0;
			仙魔大战时长 = 30;
			仙魔大战预备时间 = 5;
			武林血战奖励礼包 = 0;
			第一名奖励礼包 = 0;
			是否开启对练场赌元宝 = 0;
			允许玩家押注数量 = 100;
			场地有效范围 = 60f;
			进场最低费用 = 100;
			场地佣金百分比 = 0.2;
			允许逃跑次数 = 10;
			分数扣完扣除元宝 = 10;
			分数扣完扣除金钱 = 10000;
			Eve90进程 = 0;
			Eve90时间 = 0;
			evePlayers = new ThreadSafeDictionary<int, Players>();
			isvip = false;
			元宝合成 = 5;
			最大钱数 = 20000000000L;
			SendSpeed = 0.0;
			BroadcastSendSpeed = 0.0;
			ReceiveSpeed = 0.0;
			经验倍数 = 100.0;
			吸魂机率 = 70;
			钱倍数 = 580;
			钱总倍率 = 20;
			历练总倍率 = 100;
			升天历练总倍率 = 100;
			历练倍数 = 80;
			属性替换失败率 = 10;
			升天历练倍数 = 80.0;
			暴率 = 800;
			合成率 = 0.0;
			强化率 = 0.0;
			赋予属性率 = 0.0;
			附魂率 = 0.0;
			首饰加工率 = 0.0;
			披风强化率 = 0.0;
			装备升级率 = 0.0;
			首饰升级率 = 0.0;
			百宝阁地址 = "http://bbg.xwwl.net/login.aspx?server=1";
			百宝阁服务器IP = "127.0.0.1";
			百宝阁服务器端口 = 9001;
			帐号验证服务器IP = "127.0.0.1";
			帐号验证服务器端口 = 55970;
			GameServerPort = 13001;
			CurrentGameServerPort = 13001;
			游戏服务器端口2 = 13001;
			游戏服务器端口3 = 13001;
			转发器网关服务端口 = 50020;
			vip线 = 0;
			MaxOnline = 100;
			服务器组ID = 1;
			ServerID = 0;
			ServerName = "热血江湖";
			进入公告 = "欢迎光临热血江湖，本江湖网址http://www.rxjhsf.com, 打 !help 查看自定义命令";
			八彩提示是否开启 = 1;
			八彩红色提示内容 = "《{0}》驭龙而来，你就是最亮的一颗小星星; 八彩提示";
			八彩赤色提示内容 = "《{0}》驭龙而来，你就是最亮的一颗小星星; 八彩提示";
			八彩橙色提示内容 = "《{0}》驭龙而来，你就是最亮的一颗小星星; 八彩提示";
			八彩绿色提示内容 = "《{0}》驭龙而来，你就是最亮的一颗小星星; 八彩提示";
			八彩蓝色提示内容 = "《{0}》驭龙而来，你就是最亮的一颗小星星; 八彩提示";
			八彩深蓝提示内容 = "《{0}》驭龙而来，你就是最亮的一颗小星星; 八彩提示";
			八彩紫色提示内容 = "《{0}》驭龙而来，你就是最亮的一颗小星星; 八彩提示";
			八彩浅色提示内容 = "《{0}》驭龙而来，你就是最亮的一颗小星星; 八彩提示";
			KeykF = new AtapiDevice();
			Gamedayov = 0;
			狮子吼ID = 0;
			LionRoarList = Queue.Synchronized(new Queue());
			攻城战list = new ConcurrentDictionary<int, 攻城战>();
			申请攻城人物列表 = new List<Players>();
			攻城数据list = new ConcurrentDictionary<int, 攻城数据>();
			guildWarDataList = new ConcurrentDictionary<int, GuildWarData>();
			天魔神宫雕像是否死亡 = 0;
			天魔神宫大门是否死亡 = 0;
			天魔神宫东门是否死亡 = 0;
			城门强化等级 = 0;
			攻城战进程 = 0;
			攻城时间 = 30;
			狮子吼最大数 = 100;
			是否加密 = 1;
			元宝送积分是否开启 = 1;
			加密密钥 = "CCDA2343677C3790";
			g_cur_key = new byte[32]
			{
				54, 50, 51, 203, 80, 71, 40, 233, 162, 15,
				227, 20, 30, 171, 169, 87, 51, 66, 68, 42,
				8, 60, 20, 42, 37, 163, 130, 242, 168, 47,
				250, 45
			};
			g_cur_key2 = new byte[8] { 204, 218, 35, 67, 103, 124, 55, 144 };
			是否加密2 = 0;
			封包封号 = 0;
			组队等级限制 = 10;
			Vip上线公告 = 0;
			是否开启前十上线公告 = 0;
			Vip上线公告内容 = "尊贵的VIP玩家{0}上线了！大家欢迎！";
			神豪上线公告内容 = "尊贵的VIP玩家{0}上线了！大家欢迎！";
			普通上线公告内容 = "尊贵的VIP玩家{0}上线了！大家欢迎！";
			VIP地图 = string.Empty;
			地图锁定 = string.Empty;
			SqlJl = string.Empty;
			移动坐标异常后反弹 = 0;
			开启实时坐标检测 = 0;
			普通走 = 3.15f;
			轻功一 = 4.15f;
			轻功二 = 5.15f;
			轻功三 = 6.15f;
			实时移动时间 = 100;
			宠物普通走 = 3.15f;
			韩轻功一 = 3.15f;
			韩轻功二 = 3.15f;
			韩轻功三 = 3.15f;
			韩轻功四 = 3.15f;
			元宝检测 = 0;
			装备最大数 = 36;
			AutoSave = 1;
			至尊强化率 = 0.0;
			灵宠强化总概率 = "20;180";
			灵宠强化一阶段概率 = 1.1;
			灵宠强化二阶段概率 = 1.1;
			灵宠强化三阶段概率 = 1.1;
			灵宠强化四阶段概率 = 1.1;
			灵宠强化五阶段概率 = 1.1;
			灵宠强化六阶段概率 = 1.1;
			灵宠强化七阶段概率 = 1.1;
			王龙的金币 = 5000000L;
			是否开启GM功能 = 1;
			是否开启王龙 = 1;
			九泉金币比率 = 0.8;
			其他地图金币比率 = 0.8;
			王龙地图ID = 0;
			文件MD5 = string.Empty;
			再造金刚石攻击 = string.Empty;
			再造金刚石追伤 = string.Empty;
			再造金刚石武功 = string.Empty;
			再造金刚石命中 = string.Empty;
			再造金刚石生命 = string.Empty;
			再造寒玉石防御 = string.Empty;
			再造寒玉石回避 = string.Empty;
			再造寒玉石生命 = string.Empty;
			再造寒玉石内功 = string.Empty;
			再造寒玉石武防 = string.Empty;
			武功防降低百分比 = 0.925;
			武功防增加百分比 = 0.925;
			武功攻击力百分比 = 0.01;
			攻减防加乘 = 1.5;
			武功减武防加乘 = 1.3;
			是否开启死亡掉经验 = 0;
			VIP经验增加百分比 = 0.0;
			VIP历练增加百分比 = 0.0;
			VIP金钱增加百分比 = 0.0;
			VIP合成率增加百分比 = 0.0;
			宝珠进化概率 = 0.0;
			水晶赋予属性一阶段 = 100.0;
			水晶赋予属性二阶段 = 95.0;
			水晶赋予属性三阶段 = 90.0;
			水晶赋予属性四阶段 = 60.0;
			水晶赋予属性五阶段 = 40.0;
			水晶赋予属性六阶段 = 25.0;
			水晶赋予属性七阶段 = 15.0;
			水晶赋予属性八阶段 = 5.0;
			水晶赋予属性九阶段 = 5.0;
			水晶赋予属性十阶段 = 5.0;
			医生PK距离 = 50.0;
			弓箭手PK距离 = 60.0;
			其他职业PK距离 = 40.0;
			医生打怪距离 = 50.0;
			弓箭手打怪距离 = 60.0;
			其他职业打怪距离 = 40.0;
			VIP爆率增加 = 0;
			双倍奖励是否开启 = 0;
			双倍奖励开启小时 = 21;
			双倍奖励开启分 = 0;
			双倍奖励开启秒 = 0;
			双倍奖励结束时间 = 120;
			双倍奖励经验倍数 = 2.0;
			双倍奖励爆率倍数 = 2;
			双倍奖励武勋倍数 = 2;
			披风强化是否消耗元宝 = 0;
			灵宠强化最大数量 = 100;
			披风强化最大数量 = 100;
			披风强化消耗元宝数量 = 1;
			灵宠强化是否消耗武皇币 = 0;
			灵宠强化消耗武皇币数量 = 1;
			天关经验提高百分比基数 = 0.0;
			天关物品爆率提高基数 = 0;
			天关经验提高百分比递增 = 0.0;
			天关物品爆率提高递增 = 0;
			wg40 = 0;
			wg39 = 0;
			wg38 = 0;
			wg37 = 0;
			wg36 = 0;
			wg35 = 0;
			wg34 = 0;
			wg33 = 0;
			wg32 = 0;
			wg31 = 0;
			wg30 = 0;
			wg29 = 0;
			wg28 = 0;
			wg27 = 0;
			wg26 = 0;
			wg25 = 0;
			wg24 = 0;
			wg23 = 0;
			wg22 = 0;
			wg21 = 0;
			wg20 = 0;
			wf120 = 0;
			wf118 = 0;
			wf116 = 0;
			wf114 = 0;
			wf112 = 0;
			wf110 = 0;
			wf100 = 0;
			wf98 = 0;
			wf96 = 0;
			wf95 = 0;
			wf94 = 0;
			wf92 = 0;
			wf90 = 0;
			wf85 = 0;
			wf80 = 0;
			wf78 = 0;
			wf76 = 0;
			wf74 = 0;
			wf72 = 0;
			wf70 = 0;
			wf68 = 0;
			g25 = 0;
			g24 = 0;
			g23 = 0;
			g22 = 0;
			g21 = 0;
			g20 = 0;
			f15 = 0;
			f14 = 0;
			f13 = 0;
			f12 = 0;
			f11 = 0;
			f10 = 0;
			势力战开始时向其它线广播 = 1;
			搜索组队ID = 0;
			同IP势力战不计分 = 0;
			势力战打死大怪得分 = 100;
			势力战打死小怪得分 = 500;
			势力战踢人方案 = new List<KeyValuePair<int, int>>();
			所有势力战场次 = new ConcurrentDictionary<int, 势力战场次>();
			势力战参加最低转职 = 2;
			势力战参加最高转职 = 11;
			申请势力人物列表 = new ConcurrentDictionary<string, Players>();
			势力怪暴热血石 = "";
			势力战类型 = 0;
			势力战进程 = 0;
			势力战正分数 = 0;
			势力战邪分数 = 0;
			势力战正派参战人数 = 0;
			势力战邪派参战人数 = 0;
			势力战是否开启 = 0;
			势力战开启分 = 0;
			势力战开启秒 = 0;
			势力战设置 = "";
			势力战开启自动踢人 = 0;
			势力战战斗时间 = 30;
			势力战预备时间 = 5;
			装备提真消耗 = 0;
			装备提真数量 = 0;
			门战奖励物品ID = 0;
			修炼之地是否开启 = 0;
			修炼之地开启ID = 0;
			二人组队经验加成 = 0.1;
			三人组队经验加成 = 0.1;
			四人组队经验加成 = 0.1;
			五人组队经验加成 = 0.2;
			六人组队经验加成 = 0.2;
			七人组队经验加成 = 0.2;
			八人组队经验加成 = 0.3;
			随机BOSS出现时间表 = string.Empty;
			是否开启锁人攻击检测 = 0;
			锁人攻击次数上限 = 10;
			锁人攻击检测操作 = 0;
			ipaddress = Hasher.GetIP();
			craftingItemsList = new ConcurrentDictionary<int, CraftingItem>();
			制药物品列表 = new ConcurrentDictionary<int, 制药物品类>();
			进入传书内容 = "欢迎进入[{0}]V23.0巅峰对决-仿官，打造经典耐玩版，一切靠打!-www.yuandd.net";
			进入传书发送人 = "源多多资源网";
			平砍间隔时间 = 1000;
			首饰加工一概率 = 100.0;
			首饰加工二概率 = 100.0;
			首饰加工三概率 = 100.0;
			首饰加工四概率 = 100.0;
			首饰加工五概率 = 80.0;
			首饰加工六概率 = 70.0;
			首饰加工七概率 = 50.0;
			首饰加工八概率 = 30.0;
			首饰加工九概率 = 20.0;
			首饰加工十概率 = 10.0;
			赋予属性一阶段 = 100.0;
			赋予属性二阶段 = 100.0;
			赋予属性三阶段 = 100.0;
			赋予属性四阶段 = 100.0;
			赋予属性五阶段 = 100.0;
			赋予属性六阶段 = 80.0;
			赋予属性七阶段 = 70.0;
			赋予属性八阶段 = 50.0;
			赋予属性九阶段 = 30.0;
			赋予属性十阶段 = 10.0;
			强化一合成率 = 100.0;
			强化二合成率 = 90.0;
			强化三合成率 = 80.0;
			强化四合成率 = 70.0;
			强化五合成率 = 60.0;
			强化六合成率 = 50.0;
			强化七合成率 = 40.0;
			强化八合成率 = 30.0;
			强化九合成率 = 20.0;
			强化十合成率 = 10.0;
			强化十一合成率 = 5.0;
			强化十二合成率 = 5.0;
			强化十三合成率 = 5.0;
			强化十四合成率 = 5.0;
			强化十五合成率 = 5.0;
			无限负重 = 0;
			开启下雪场景 = 0;
			是否开启安全码 = 0;
			是否开启票红字 = 0;
			是否开启票红字2 = 0;
			是否开启多开提示 = 0;
			水晶符强1 = 0.0;
			水晶符强2 = 0.0;
			水晶符强3 = 0.0;
			水晶符强4 = 0.0;
			水晶符强5 = 0.0;
			水晶符强6 = 0.0;
			水晶符强7 = 0.0;
			水晶符强8 = 0.0;
			水晶符强9 = 0.0;
			水晶符强10 = 0.0;
			至尊取玉强11 = 0.0;
			至尊取玉强12 = 0.0;
			至尊取玉强13 = 0.0;
			至尊取玉强14 = 0.0;
			至尊取玉强15 = 0.0;
			刺客攻击倍数 = 1.4;
			弓手攻击倍数 = 1.5;
			制作进化一概率 = 100;
			制作进化二概率 = 300;
			武器8阶段添加攻击 = 0;
			武器9阶段添加攻击 = 0;
			武器10阶段添加攻击 = 0;
			武器11阶段添加攻击 = 0;
			武器12阶段添加攻击 = 0;
			武器13阶段添加攻击 = 0;
			武器14阶段添加攻击 = 0;
			武器15阶段添加攻击 = 0;
			衣服8阶段添加防御 = 0;
			衣服9阶段添加防御 = 0;
			衣服10阶段添加防御 = 0;
			衣服11阶段添加防御 = 0;
			衣服12阶段添加防御 = 0;
			衣服13阶段添加防御 = 0;
			衣服14阶段添加防御 = 0;
			衣服15阶段添加防御 = 0;
			护手8阶段添加防御 = 0;
			护手9阶段添加防御 = 0;
			护手10阶段添加防御 = 0;
			护手11阶段添加防御 = 0;
			护手12阶段添加防御 = 0;
			护手13阶段添加防御 = 0;
			护手14阶段添加防御 = 0;
			护手15阶段添加防御 = 0;
			鞋子8阶段添加防御 = 0;
			鞋子9阶段添加防御 = 0;
			鞋子10阶段添加防御 = 0;
			鞋子11阶段添加防御 = 0;
			鞋子12阶段添加防御 = 0;
			鞋子13阶段添加防御 = 0;
			鞋子14阶段添加防御 = 0;
			鞋子15阶段添加防御 = 0;
			内甲8阶段添加防御 = 0;
			内甲9阶段添加防御 = 0;
			内甲10阶段添加防御 = 0;
			内甲11阶段添加防御 = 0;
			内甲12阶段添加防御 = 0;
			内甲13阶段添加防御 = 0;
			内甲14阶段添加防御 = 0;
			内甲15阶段添加防御 = 0;
			斗神称号激活方式 = 0;
			斗神称号需要数量 = 0;
			清理绑定背包命令 = "!清理绑定背包";
			try
			{
				Kill = new List<KillClass>();
				帮战Namelist = new ConcurrentDictionary<int, 帮战Class>();
				allPVPChars = new ThreadSafeDictionary<int, Players>();
				Teams = new ConcurrentDictionary<int, TeamClass>();
				公告 = new ConcurrentDictionary<int, AnnouncementClass>();
				等级奖励 = new ConcurrentDictionary<int, 等级奖励类>();
				气功加成 = new ConcurrentDictionary<int, 气功加成属性>();
				物品兑换 = new ConcurrentDictionary<int, 物品兑换类>();
				lever = new ConcurrentDictionary<int, double>();
				Wxlever = new ConcurrentDictionary<int, 武勋加成类>();
				Itme = new ConcurrentDictionary<int, ItmeClass>();
				百宝阁数据 = new ConcurrentDictionary<int, BbgSellClass>();
				ItemTemp = new ThreadSafeDictionary<long, 地面物品类>();
				TBL_KONGFU = new ConcurrentDictionary<int, 武功类>();
				MonSter = new ConcurrentDictionary<int, botCoord>();
				物品检查 = new List<检查物品类>();
				BossDrop = new List<DropClass>();
				Drop = new List<DropClass>();
				Drop_GS = new List<DropClass>();
				Open = new List<OpenClass>();
				套装数据 = new List<ItemSellClass>();
				Shop = new List<ShopClass>();
				Mover = new List<MoveClass>();
				移动 = new List<坐标Class>();
				对练区 = new List<坐标Class>();
				BOSSListTime = new List<int>();
				仙魔大战区域 = new List<坐标Class>();
				势力战区域 = new List<坐标Class>();
				帮战区 = new List<坐标Class>();
				比武泡点区 = new List<坐标Class>();
				自动得奖励地区 = new List<坐标Class>();
				开箱Lock = new object();
				Keyk.CpuID = Hasher.GetCpuID();
				Keyk.DriveID = Hasher.GetDriveID("C");
				Keyk.IP = Hasher.GetIP();
				Keyk.Mac = Hasher.GetMac();
				isvip = false;
				地面物品Lock = new object();
				攻城怪物列表 = new List<攻城怪物>();
				伏魔洞怪物列表 = new List<伏魔洞怪物>();
				比武泡点奖励 = new ConcurrentDictionary<int, 比武泡点奖励>();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(100, "系统错误:World" + ex);
				Environment.Exit(0);
			}
		}

		private void 世界时间事件2()
		{
			try
			{
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.神女异常状态 == null || !value.神女异常状态.ContainsKey(46))
					{
						continue;
					}
					if (value.人物_HP <= 0)
					{
						value.人物_HP = 0;
					}
					else if (value.人物_HP != value.人物最大_HP)
					{
						if (value.人物_HP + 160 < value.人物最大_HP)
						{
							value.人物_HP += 160;
						}
						else
						{
							value.人物_HP = value.人物最大_HP;
						}
						value.更新HP_MP_SP();
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "神女异常错误46" + ex.Message);
			}
		}

		public static void 发送地图PK公告2(int msg)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				foreach (int item in 限时PK地图列表)
				{
					if (value.人物坐标_地图 == item)
					{
						if (msg == 1)
						{
							value.系统公告("本地图现在开始开放PK");
						}
						else
						{
							value.系统公告("时间太晚了, 为了广大玩家身心健康, 本地图现在开始禁止PK");
						}
					}
				}
			}
		}

		public static void 发送地图PK公告(int msg)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				foreach (int item in 限时PK地图列表)
				{
					if (value.人物坐标_地图 == item)
					{
						if (msg == 1)
						{
							value.系统公告("本地图现在开始开放PK");
						}
						else
						{
							value.系统公告("本地图现在开始禁止PK");
						}
					}
				}
			}
		}

		private void 世界时间事件()
		{
			if ((int)DateTime.Now.Subtract(膜拜大神时间间隔).TotalMilliseconds >= 4000 && 赞助大使名字 != string.Empty)
			{
				foreach (Players value3 in AllConnectedPlayers.Values)
				{
					if (value3.UserName == 赞助大使名字)
					{
						value3.膜拜特效(特效道具ID, value3.人物全服ID);
					}
				}
				膜拜大神时间间隔 = DateTime.Now;
			}
			try
			{
				foreach (Players value4 in AllConnectedPlayers.Values)
				{
					if (value4.神女异常状态 != null && value4.神女异常状态.ContainsKey(48))
					{
						value4.人物_HP -= (int)((double)value4.人物最大_HP * 0.03);
						if (value4.人物_HP <= 0)
						{
							value4.人物_HP = 1;
						}
						value4.更新HP_MP_SP();
					}
					if (value4.神女异常状态 != null && value4.神女异常状态.ContainsKey(49))
					{
						value4.人物_HP -= (int)((double)value4.人物最大_HP * 0.05);
						if (value4.人物_HP <= 0)
						{
							value4.人物_HP = 1;
						}
						value4.更新HP_MP_SP();
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "神女异常错误48/49" + ex.Message);
			}
			foreach (Players value5 in AllConnectedPlayers.Values)
			{
				if (value5.称号积分 >= int.Parse(至高无上称号奖励[0]))
				{
					value5.头顶发光();
				}
				value5.称号物品结束();
				value5.时间物品结束();
				value5.特殊物品结束();
			}
			try
			{
				if (异口同声是否开启 == 1 && DateTime.Now.Hour == 异口同声开启时 && DateTime.Now.Minute == 异口同声开启分 && DateTime.Now.Second == 异口同声开启秒 && EnableUnisonSpeech == null)
				{
					EnableUnisonSpeech = new 异口同声();
					MainForm.WriteLine(1, "自动开启异口同声成功");
				}
				if (BOSS攻城是否开启 == 1 && DateTime.Now.Hour == BOSS攻城开启小时 && DateTime.Now.Minute == BOSS攻城开启分 && DateTime.Now.Second >= BOSS攻城开启秒 && BossSiege == null)
				{
					BossSiege = new boss攻城();
					MainForm.WriteLine(2, "boss攻城战开启成功");
				}
				if (世界BOSS攻城是否开启 == 1 && DateTime.Now.Hour == 世界BOSS攻城开启小时 && DateTime.Now.Minute == 世界BOSS攻城开启分 && DateTime.Now.Second >= 世界BOSS攻城开启秒 && WorldBoss == null)
				{
					WorldBoss = new 世界BOSS();
					MainForm.WriteLine(2, "世界boss开启成功");
				}
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "开启异口同声/幸运抽奖/BOSS攻城/世界BOSS出错" + ex2.Message);
			}
			string[] array = 武林血战开启时间星期.Split(':');
			for (int i = 0; i < array.Length; i++)
			{
				if (int.Parse(array[i]) == 取星期几() && 武林血战是否开启 == 1 && DateTime.Now.Hour == 武林血战开启小时 && DateTime.Now.Minute == 武林血战开启分 && DateTime.Now.Second == 武林血战开启秒 && PersonalBloodBattle == null)
				{
					if (PersonalBloodBattle != null)
					{
						PersonalBloodBattle.Dispose();
						PersonalBloodBattle = null;
					}
					PersonalBloodBattle = new 武林血战();
				}
			}
			if (DateTime.Now.Hour == 限时地图开PK时间)
			{
				if (限时地图是否开启 == 0)
				{
					限时地图是否开启 = 1;
					发送地图PK公告(1);
				}
			}
			else if (DateTime.Now.Hour == 限时地图关PK时间 && 限时地图是否开启 == 1)
			{
				限时地图是否开启 = 0;
				发送地图PK公告(0);
			}
			if (Convert.ToInt32(DateTime.Today.DayOfWeek) < 5 && 周末全天PK是否开启 == 1)
			{
				if (DateTime.Now.Hour == 工作日限时地图开PK时间)
				{
					if (工作日限时地图是否开启 == 0)
					{
						工作日限时地图是否开启 = 1;
						发送地图PK公告2(1);
					}
				}
				else if (DateTime.Now.Hour == 工作日限时地图关PK时间 && 工作日限时地图是否开启 == 1)
				{
					工作日限时地图是否开启 = 0;
					发送地图PK公告2(0);
				}
			}
			if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 6 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 7) && 双倍奖励是否开启 == 1 && DateTime.Now.Hour == 双倍奖励开启小时 && DateTime.Now.Minute == 双倍奖励开启分 && DateTime.Now.Second >= 双倍奖励开启秒 && EnableServerWideExp == null)
			{
				EnableServerWideExp = new 全服经验();
				MainForm.WriteLine(2, "双倍经验开启成功");
				发送公告("全服双倍已经开启, 请各位大侠做好准备");
			}
			if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
			{
				DBA.ExeSqlCommand(string.Format(string.Concat(new object[2] { "UPDATE TBL_XWWL_Char SET FLD_讨伐次数=", 5 })), "GameServer");
				DBA.ExeSqlCommand("DELETE FROM 荣誉讨伐排行");
				foreach (Players value6 in AllConnectedPlayers.Values)
				{
					value6.副本剩余次数 = 5;
					value6.SavePlayerData();
				}
				发送游戏特殊公告("每天00.00准时自动重置....", 6, "系统提示");
			}
			if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
			{
				DBA.ExeSqlCommand(string.Format("UPDATE TBL_XWWL_Char SET FLD_LOST_WX=" + 0 + " , FLD_GET_WX=" + 0), "GameServer");
				foreach (Players value7 in AllConnectedPlayers.Values)
				{
					value7.每日获得武勋 = 0;
					value7.丢失武勋 = 0;
					value7.SavePlayerData();
				}
				发送游戏特殊公告("每日武勋已重置, 每天24.00准时自动重置....", 6, "系统提示");
			}
			if (是否开启安全模式 == 1 && DateTime.Now.Hour == int.Parse(安全模式时间[1]) && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
			{
				foreach (Players value8 in AllConnectedPlayers.Values)
				{
					if (value8.追加状态列表 != null && value8.GetAddState(900000619))
					{
						value8.追加状态列表[900000619].时间结束事件();
					}
					value8.安全模式 = 0;
				}
				发送游戏特殊公告("每天[" + int.Parse(安全模式时间[1]) + "]点, 安全模式自动解除....", 6, "系统提示");
			}
			if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 1 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 3 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 5 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 7) && 开启攻城战系统 == 1 && DateTime.Now.Hour == 攻城战开启小时 && DateTime.Now.Minute == 攻城战开启分 && DateTime.Now.Second == 攻城战开启秒 && 攻城战公告 == null)
			{
				if (是否开启跨线活动 == 1 && 攻城战公告 == null)
				{
					攻城战公告 = new 攻城战循环公告();
					MainForm.WriteLine(2, "跨线攻城战开启成功");
				}
				else
				{
					SiegeWar = new 攻城Class();
					MainForm.WriteLine(2, "单线攻城战开启成功");
				}
			}
			if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 6 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 7) && 仙魔大战是否开启 == 1 && DateTime.Now.Hour == 仙魔大战开启小时 && DateTime.Now.Minute == 仙魔大战开启分 && DateTime.Now.Second == 仙魔大战开启秒 && ImmortalDemonWar == null)
			{
				if (是否开启跨线活动 == 1 && 仙魔战公告 == null)
				{
					仙魔战公告 = new 仙魔战循环公告();
					MainForm.WriteLine(2, "跨线仙魔大战开启");
				}
				else if (ImmortalDemonWar == null)
				{
					ImmortalDemonWar = new 仙魔大战Class();
					MainForm.WriteLine(2, "单线仙魔大战开启成功");
				}
			}
			if (是否开启对练场赌元宝 == 1 && EVEPVP == null && evePlayers != null && evePlayers.Count >= 2)
			{
				EVEPVP = new EvePVPClass(evePlayers);
			}
			try
			{
				if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 1 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 2 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 3 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 4 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 5) && 势力战是否开启 == 1 && 所有势力战场次.TryGetValue(DateTime.Now.Hour, out var value) && DateTime.Now.Minute == 势力战开启分 && DateTime.Now.Second == 势力战开启秒 && eve == null)
				{
					势力战类型 = value.势力战类型;
					势力战参加最低转职 = value.最小转职;
					势力战参加最高转职 = value.最大转职;
					eve = new EventClass();
				}
			}
			catch (Exception ex3)
			{
				MainForm.WriteLine(1, "势力战系统错误 " + ex3.Message);
			}
			try
			{
				if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 6 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 7) && 开启门战系统 == 1 && DateTime.Now.Hour == 13 && DateTime.Now.Minute == 门战系统开启分 && DateTime.Now.Second == 门战系统开启秒 && GuildWar == null)
				{
					是否开启门战系统 = 1;
					胜利帮派ID = 0;
					GuildWar = new 帮派战_门战();
				}
				if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 6 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 7) && 开启门战系统 == 1 && DateTime.Now.Hour == 15 && DateTime.Now.Minute == 门战系统开启分 && DateTime.Now.Second == 门战系统开启秒 && GuildWar == null)
				{
					是否开启门战系统 = 1;
					GuildWar = new 帮派战_门战();
				}
				if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 1 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 2 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 3 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 4 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 5) && 开启门战系统 == 1 && DateTime.Now.Hour == 门战系统开启时 && DateTime.Now.Minute == 门战系统开启分 && DateTime.Now.Second == 门战系统开启秒 && GuildWar == null)
				{
					是否开启门战系统 = 1;
					胜利帮派ID = 0;
					GuildWar = new 帮派战_门战();
				}
				if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 1 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 2 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 3 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 4 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 5 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 7) && 开启门战系统 == 1 && DateTime.Now.Hour == 门战系统开启时 + 2 && DateTime.Now.Minute == 门战系统开启分 && DateTime.Now.Second == 门战系统开启秒 && GuildWar == null)
				{
					是否开启门战系统 = 1;
					GuildWar = new 帮派战_门战();
				}
			}
			catch (Exception ex4)
			{
				MainForm.WriteLine(1, "开启门战系统错误 " + ex4.Message);
			}
			if (是否开启王龙 == 1)
			{
				try
				{
					bool flag = false;
					if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
					{
						delNpc(王龙地图ID, 15261);
						int mapp = new Random().Next(23002, 23050);
						AddNpc(15261, 0f, 0f, mapp);
						王龙地图ID = mapp;
						flag = true;
					}
					if (DateTime.Now.Hour == 4 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
					{
						delNpc(王龙地图ID, 15261);
						int mapp2 = new Random().Next(23002, 23050);
						AddNpc(15261, 0f, 0f, mapp2);
						王龙地图ID = mapp2;
						flag = true;
					}
					if (DateTime.Now.Hour == 8 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
					{
						delNpc(王龙地图ID, 15261);
						int mapp3 = new Random().Next(23002, 23050);
						AddNpc(15261, 0f, 0f, mapp3);
						王龙地图ID = mapp3;
						flag = true;
					}
					if (DateTime.Now.Hour == 12 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
					{
						delNpc(王龙地图ID, 15261);
						int mapp4 = new Random().Next(23002, 23050);
						AddNpc(15261, 0f, 0f, mapp4);
						王龙地图ID = mapp4;
						flag = true;
					}
					if (DateTime.Now.Hour == 16 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
					{
						delNpc(王龙地图ID, 15261);
						int mapp5 = new Random().Next(23002, 23050);
						AddNpc(15261, 0f, 0f, mapp5);
						王龙地图ID = mapp5;
						flag = true;
					}
					if (DateTime.Now.Hour == 20 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
					{
						delNpc(王龙地图ID, 15261);
						int mapp6 = new Random().Next(23002, 23050);
						AddNpc(15261, 0f, 0f, mapp6);
						王龙地图ID = mapp6;
						flag = true;
					}
					if (!flag)
					{
						return;
					}
					系统滚动公告("[BOSS王龙]现身九泉[" + (王龙地图ID - 23000) + "]层, 当前九泉累积金币数为" + 王龙的金币 / 10000 + "万, 泫勃派南门码头:殷黎亭");
				}
				catch
				{
					MainForm.WriteLine(1, "九泉BOSS王龙错误");
				}
			}
			if (修炼之地是否开启 == 1)
			{
				if (DateTime.Now.Hour == 10 && DateTime.Now.Minute == 0)
				{
					if (修炼之地开启ID != 1)
					{
						修炼之地开启ID = 1;
						发送游戏特殊公告("修炼地区开启, 进入时间[10:00-10:20], 修炼时间为2小时", 6, "公告");
					}
				}
				else
				{
					if (DateTime.Now.Hour == 10 && DateTime.Now.Minute == 20)
					{
						if (修炼之地开启ID == 0)
						{
							return;
						}
						修炼之地开启ID = 0;
						foreach (Players value9 in AllConnectedPlayers.Values)
						{
							if (value9.人物坐标_地图 == 30000 || value9.人物坐标_地图 == 30100 || value9.人物坐标_地图 == 30200 || value9.人物坐标_地图 == 30300)
							{
								if (老泫勃派开关 == 1)
								{
									value9.移动(495f, 1727f, 15f, 29000);
								}
								else
								{
									value9.移动(560f, 1550f, 15f, 101);
								}
							}
						}
						return;
					}
					if (DateTime.Now.Hour == 18 && DateTime.Now.Minute == 0)
					{
						if (修炼之地开启ID != 3)
						{
							修炼之地开启ID = 3;
							发送游戏特殊公告("修炼地区开启, 进入时间[18:00-18:20], 修炼时间为2小时", 6, "公告");
						}
					}
					else
					{
						if (DateTime.Now.Hour == 18 && DateTime.Now.Minute == 20)
						{
							if (修炼之地开启ID == 0)
							{
								return;
							}
							修炼之地开启ID = 0;
							foreach (Players value10 in AllConnectedPlayers.Values)
							{
								if (value10.人物坐标_地图 == 30000 || value10.人物坐标_地图 == 30100 || value10.人物坐标_地图 == 30200 || value10.人物坐标_地图 == 30300)
								{
									if (老泫勃派开关 == 1)
									{
										value10.移动(495f, 1727f, 15f, 29000);
									}
									else
									{
										value10.移动(560f, 1550f, 15f, 101);
									}
								}
							}
							return;
						}
						if (DateTime.Now.Hour == 22 && DateTime.Now.Minute == 0)
						{
							if (修炼之地开启ID != 4)
							{
								修炼之地开启ID = 4;
								发送游戏特殊公告("修炼地区开启, 进入时间[22:00-22:20], 修炼时间为2小时", 6, "公告");
							}
						}
						else
						{
							if (DateTime.Now.Hour != 22 || DateTime.Now.Minute != 20 || 修炼之地开启ID == 0)
							{
								return;
							}
							修炼之地开启ID = 0;
							foreach (Players value2 in AllConnectedPlayers.Values)
							{
								if (value2.人物坐标_地图 == 30000 || value2.人物坐标_地图 == 30100 || value2.人物坐标_地图 == 30200 || value2.人物坐标_地图 == 30300)
								{
									if (老泫勃派开关 == 1)
									{
										value2.移动(495f, 1727f, 15f, 29000);
									}
									else
									{
										value2.移动(560f, 1550f, 15f, 101);
									}
								}
							}
						}
					}
				}
			}
			if (经验提高倍数 > 1.0)
			{
				if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 1 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 2 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 3 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 4 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 5) && DateTime.Now.Hour == 高倍经验开始时间 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
				{
					经验倍数 = (int)(经验提高倍数 * 经验倍数);
					GlobalNotification("系统提示", 6, 经验提高倍数 + "倍经验开启。");
				}
				else if ((Convert.ToInt32(DateTime.Today.DayOfWeek) == 1 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 2 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 3 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 4 || Convert.ToInt32(DateTime.Today.DayOfWeek) == 5) && DateTime.Now.Hour == 高倍经验结束时间 && DateTime.Now.Minute == 0 && (DateTime.Now.Second == 0 || DateTime.Now.Second == 1 || DateTime.Now.Second == 2))
				{
					经验倍数 = ((Config.IniReadValue("GameServer", "经验倍数").Trim().Length == 0) ? 经验倍数 : ((double)int.Parse(Config.IniReadValue("GameServer", "经验倍数").Trim())));
					GlobalNotification("系统提示", 6, 经验提高倍数 + "倍经验结束。");
				}
			}
			if (野外BOSS开关 == 1)
			{
				野外BOSS开启();
			}
			if (比武泡点是否开启 == 1)
			{
				开启比武泡点();
			}
		}

		public World()
		{
			Timer.DelayCall(TimeSpan.FromMilliseconds(1000.0), TimeSpan.FromMilliseconds(1000.0), 世界时间事件);
			Timer.DelayCall(TimeSpan.FromMilliseconds(1500.0), TimeSpan.FromMilliseconds(1500.0), 自动离线打怪);
			Timer.DelayCall(TimeSpan.FromMilliseconds(1500.0), TimeSpan.FromMilliseconds(1500.0), 江湖小助手打怪);
			Timer.DelayCall(TimeSpan.FromMilliseconds(3000.0), TimeSpan.FromMilliseconds(3000.0), 世界时间事件2);
			Timer.DelayCall(TimeSpan.FromMilliseconds(1000.0), TimeSpan.FromMilliseconds(1000.0), 掉线组队核查);
			Timer.DelayCall(TimeSpan.FromMilliseconds(1500.0), TimeSpan.FromMilliseconds(1500.0), 江湖离线打架);
		}

		public void 野外BOSS开启()
		{
			string[] array = 野外BOSS时间.Split('/');
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.Length > 0 && DateTime.Now.Hour == Convert.ToInt32(text) && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0 && FieldBoss == null)
				{
					FieldBoss = new 野外BOSS();
				}
			}
		}

		public void 开启比武泡点()
		{
			try
			{
				string[] array = 比武泡点开启时间星期.Split(':');
				for (int i = 0; i < array.Length; i++)
				{
					if (int.Parse(array[i]) == 取星期几() && DateTime.Now.Hour == 比武泡点开启小时 && DateTime.Now.Minute == 比武泡点开启分 && DateTime.Now.Second >= 比武泡点开启秒 && ArenaIdling == null)
					{
						ArenaIdling = new 比武泡点系统();
						MainForm.WriteLine(66, "自动开启比武泡点");
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "开启比武泡点触发出错" + ex.Message);
			}
		}

		public static int 取星期几()
		{
			int result = 0;
			switch (DateTime.Today.DayOfWeek.ToString())
			{
			case "Thursday":
				result = 4;
				break;
			case "Monday":
				result = 1;
				break;
			case "Saturday":
				result = 6;
				break;
			case "Sunday":
				result = 7;
				break;
			case "Friday":
				result = 5;
				break;
			case "Tuesday":
				result = 2;
				break;
			case "Wednesday":
				result = 3;
				break;
			}
			return result;
		}

		private void 江湖小助手打怪()
		{
			try
			{
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.Client != null && value.江湖小助手打怪模式 == 1 && !value.Player死亡 && (long)value.人物_HP > 0L)
					{
						江湖小助手系统.江湖小助手(value);
					}
				}
			}
			catch
			{
				MainForm.WriteLine(1, "江湖小助手循环出现错误");
			}
		}

		private void 江湖离线打架()
		{
			try
			{
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.Client != null && value.离线打架模式 == 1)
					{
						离线打架系统.离线打架(value);
					}
				}
			}
			catch
			{
				MainForm.WriteLine(1, "江湖小助手循环出现错误");
			}
		}

		public static void 自动离线打怪()
		{
			try
			{
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.Client != null && value.离线挂机打怪模式 == 1)
					{
						离线挂机系统.离线挂机(value);
					}
				}
			}
			catch
			{
				MainForm.WriteLine(1, "假人打怪循环出现错误");
			}
		}

		private void 掉线组队核查()
		{
			try
			{
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (!value.Client.假人 && value.报错次数阀值 >= 报错踢号次数)
					{
						RxjhClass.卡号记录(value.Userid, value.UserName, "报错次数", value.Player_Job);
						value.Client.Dispose();
					}
					if ((!value.Client.假人 && value.Player死亡) || value.人物_HP < 0)
					{
						if (value.人物坐标_地图 != 101)
						{
							value.死亡不复活计时++;
						}
						if (value.死亡不复活计时 > 3600)
						{
							RxjhClass.卡号记录(value.Userid, value.UserName, "死亡1小时", value.Player_Job);
							value.Client.Dispose();
						}
					}
				}
			}
			catch
			{
				MainForm.WriteLine(1, "报错踢号循环出错");
			}
		}

		public static void 随机BOSS系统()
		{
			try
			{
				string text = string.Empty;
				int num = 0;
				int num2 = 0;
				ConcurrentDictionary<int, NpcClass> concurrentDictionary = new ConcurrentDictionary<int, NpcClass>();
				int num3 = 1;
				foreach (NpcClass value2 in MapClass.GetnpcTemplate(101).Values)
				{
					if (value2.IsNpc != 1)
					{
						concurrentDictionary.TryAdd(num3, value2);
						num3++;
					}
				}
				int key = RNG.Next(1, concurrentDictionary.Count - 1);
				if (!concurrentDictionary.TryGetValue(key, out var value))
				{
					return;
				}
				int num4 = 0;
				foreach (botCoord value3 in MonSter.Values)
				{
					if (value3.FLD_BOSS == 1 && value3.FLD_PID != 15584)
					{
						float x = value.X + (float)num4;
						float y = value.Y - (float)num4;
						AddNpc(value3.FLD_PID, x, y, 101);
						num = (int)value.X;
						num2 = (int)value.Y;
						text = value3.Name;
						num4 += 10;
					}
				}
				foreach (Players value4 in AllConnectedPlayers.Values)
				{
					if (!value4.Client.挂机)
					{
						value4.发送传音消息(value4, text.Replace("\r", string.Empty) + " 携带大量宝物出现在泫勃派" + num + ", " + num2 + "。", 4);
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "随机BOSS系统加载NPC数据 出错：" + ex);
			}
		}

		public void SetScript()
		{
			脚本 = new ScriptClass();
		}

		public static void GlobalNotification(string name, int type, string msg)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				if (!value.Client.挂机)
				{
					value.系统提示(msg, type, name);
				}
			}
		}

		public static void PK全局提示(string name, int type, string msg)
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				if (!value.Client.挂机 && value.PK提示 == 1)
				{
					value.系统提示(msg, type, name);
				}
			}
		}

		public void SetConfig()
		{
			string str = "获取配置文件路径";
			try
			{
				Config.Path = Application.StartupPath + "\\config\\config.ini";
				MainServer = ((Config.IniReadValue("GameServer", "主服务器").Trim().Length == 0) ? MainServer : int.Parse(Config.IniReadValue("GameServer", "主服务器").Trim()));
				游戏登陆端口最大连接数 = ((Config.IniReadValue("GameServer", "游戏登陆端口最大连接数").Length == 0) ? 游戏登陆端口最大连接数 : int.Parse(Config.IniReadValue("GameServer", "游戏登陆端口最大连接数")));
				游戏登陆端口最大连接时间数 = ((Config.IniReadValue("GameServer", "游戏登陆端口最大连接时间数").Length == 0) ? 游戏登陆端口最大连接时间数 : int.Parse(Config.IniReadValue("GameServer", "游戏登陆端口最大连接时间数")));
				AutoReconnectInterval = ((Config.IniReadValue("GameServer", "自动连接时间").Length == 0) ? AutoReconnectInterval : int.Parse(Config.IniReadValue("GameServer", "自动连接时间")));
				封IP = Config.IniReadValue("GameServer", "封IP").Trim().ToLower() == "true";
				自动开启连接 = Config.IniReadValue("GameServer", "自动开启连接").Trim().ToLower() == "true";
				MaxAllowedConnections = ((Config.IniReadValue("GameServer", "允许最大连接数").Length == 0) ? MaxAllowedConnections : int.Parse(Config.IniReadValue("GameServer", "允许最大连接数")));
				转发器网关服务端口 = ((Config.IniReadValue("GameServer", "转发器网关服务端口").Trim().Length == 0) ? 转发器网关服务端口 : int.Parse(Config.IniReadValue("GameServer", "转发器网关服务端口").Trim()));
				断开连接 = Config.IniReadValue("GameServer", "断开连接").Trim().ToLower() == "true";
				AutoPortSwitching = Config.IniReadValue("GameServer", "自动开启换端口").Trim().ToLower() == "true";
				加入过滤列表 = Config.IniReadValue("GameServer", "加入过滤列表").Trim().ToLower() == "true";
				关闭连接 = Config.IniReadValue("GameServer", "关闭连接").Trim().ToLower() == "true";
				Key1 = Config.IniReadValue("GameServer", "Key1").Trim();
				Key2 = Config.IniReadValue("GameServer", "Key2").Trim();
				高倍经验开始时间 = ((Config.IniReadValue("GameServer", "高倍经验开始时间").Trim().Length == 0) ? 高倍经验开始时间 : int.Parse(Config.IniReadValue("GameServer", "高倍经验开始时间").Trim()));
				高倍经验结束时间 = ((Config.IniReadValue("GameServer", "高倍经验结束时间").Trim().Length == 0) ? 高倍经验结束时间 : int.Parse(Config.IniReadValue("GameServer", "高倍经验结束时间").Trim()));
				经验提高倍数 = ((Config.IniReadValue("GameServer", "经验提高倍数").Trim().Length == 0) ? 经验提高倍数 : double.Parse(Config.IniReadValue("GameServer", "经验提高倍数").Trim()));
				经验倍数 = ((Config.IniReadValue("GameServer", "经验倍数").Trim().Length == 0) ? 经验倍数 : double.Parse(Config.IniReadValue("GameServer", "经验倍数").Trim()));
				钱倍数 = ((Config.IniReadValue("GameServer", "钱倍数").Trim().Length == 0) ? 钱倍数 : int.Parse(Config.IniReadValue("GameServer", "钱倍数").Trim()));
				钱总倍率 = ((Config.IniReadValue("GameServer", "钱总倍率").Trim().Length == 0) ? 钱总倍率 : int.Parse(Config.IniReadValue("GameServer", "钱总倍率").Trim()));
				历练总倍率 = ((Config.IniReadValue("GameServer", "历练总倍率").Trim().Length == 0) ? 历练总倍率 : int.Parse(Config.IniReadValue("GameServer", "历练总倍率").Trim()));
				升天历练总倍率 = ((Config.IniReadValue("GameServer", "升天历练总倍率").Trim().Length == 0) ? 升天历练总倍率 : int.Parse(Config.IniReadValue("GameServer", "升天历练总倍率").Trim()));
				吸魂机率 = ((Config.IniReadValue("GameServer", "吸魂几率").Trim().Length == 0) ? 吸魂机率 : int.Parse(Config.IniReadValue("GameServer", "吸魂几率").Trim()));
				历练倍数 = ((Config.IniReadValue("GameServer", "历练倍数").Trim().Length == 0) ? 历练倍数 : int.Parse(Config.IniReadValue("GameServer", "历练倍数").Trim()));
				属性替换失败率 = ((Config.IniReadValue("GameServer", "属性替换失败率").Trim().Length == 0) ? 属性替换失败率 : int.Parse(Config.IniReadValue("GameServer", "属性替换失败率").Trim()));
				升天历练倍数 = ((Config.IniReadValue("GameServer", "升天历练倍数").Trim().Length == 0) ? 升天历练倍数 : double.Parse(Config.IniReadValue("GameServer", "升天历练倍数").Trim()));
				暴率 = ((Config.IniReadValue("GameServer", "暴率").Trim().Length == 0) ? 暴率 : int.Parse(Config.IniReadValue("GameServer", "暴率").Trim()));
				MaxOnline = ((Config.IniReadValue("GameServer", "最大在线").Trim().Length == 0) ? MaxOnline : int.Parse(Config.IniReadValue("GameServer", "最大在线").Trim()));
				服务器组ID = ((Config.IniReadValue("GameServer", "服务器组ID").Trim().Length == 0) ? 服务器组ID : int.Parse(Config.IniReadValue("GameServer", "服务器组ID").Trim()));
				ServerID = ((Config.IniReadValue("GameServer", "服务器ID").Trim().Length == 0) ? ServerID : int.Parse(Config.IniReadValue("GameServer", "服务器ID").Trim()));
				GameServerPort = ((Config.IniReadValue("GameServer", "游戏服务器端口").Trim().Length == 0) ? GameServerPort : int.Parse(Config.IniReadValue("GameServer", "游戏服务器端口").Trim()));
				百宝阁服务器端口 = ((Config.IniReadValue("GameServer", "百宝阁服务器端口").Trim().Length == 0) ? 百宝阁服务器端口 : int.Parse(Config.IniReadValue("GameServer", "百宝阁服务器端口").Trim()));
				帐号验证服务器端口 = ((Config.IniReadValue("GameServer", "帐号验证服务器端口").Trim().Length == 0) ? 帐号验证服务器端口 : int.Parse(Config.IniReadValue("GameServer", "帐号验证服务器端口").Trim()));
				帐号验证服务器IP = Config.IniReadValue("GameServer", "帐号验证服务器IP").Trim();
				进入公告 = Config.IniReadValue("GameServer", "进入公告").Trim();
				百宝阁地址 = Config.IniReadValue("GameServer", "百宝阁地址").Trim();
				ServerName = Config.IniReadValue("GameServer", "服务器名").Trim();
				vip线 = ((Config.IniReadValue("GameServer", "vip线").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "vip线").Trim()) : 0);
				仙魔大战是否开启 = int.Parse(Config.IniReadValue("GameServer", "仙魔大战是否开启").Trim());
				仙魔大战进入等级 = int.Parse(Config.IniReadValue("GameServer", "仙魔大战进入等级").Trim());
				攻城战进入等级 = int.Parse(Config.IniReadValue("GameServer", "攻城战进入等级").Trim());
				仙魔大战开启小时 = int.Parse(Config.IniReadValue("GameServer", "仙魔大战开启小时").Trim());
				仙魔大战开启分 = int.Parse(Config.IniReadValue("GameServer", "仙魔大战开启分").Trim());
				仙魔大战开启秒 = int.Parse(Config.IniReadValue("GameServer", "仙魔大战开启秒").Trim());
				仙魔大战时长 = int.Parse(Config.IniReadValue("GameServer", "仙魔大战时长").Trim());
				仙魔大战预备时间 = int.Parse(Config.IniReadValue("GameServer", "仙魔大战预备时间").Trim());
				老泫勃派开关 = int.Parse(Config.IniReadValue("GameServer", "老泫勃派开关").Trim());
				AutGC = ((Config.IniReadValue("GameServer", "AutGC").Trim().Length == 0) ? AutGC : int.Parse(Config.IniReadValue("GameServer", "AutGC").Trim()));
				封包封号 = ((Config.IniReadValue("GameServer", "封包封号").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "封包封号").Trim()) : 0);
				Script = ((Config.IniReadValue("GameServer", "Script").Trim().Length == 0) ? Script : int.Parse(Config.IniReadValue("GameServer", "Script").Trim()));
				狮子吼最大数 = ((Config.IniReadValue("GameServer", "狮子吼最大数").Length == 0) ? 50 : int.Parse(Config.IniReadValue("GameServer", "狮子吼最大数")));
				合成率 = ((Config.IniReadValue("GameServer", "合成率").Length == 0) ? 合成率 : double.Parse(Config.IniReadValue("GameServer", "合成率")));
				强化率 = ((Config.IniReadValue("GameServer", "强化率").Length == 0) ? 强化率 : double.Parse(Config.IniReadValue("GameServer", "强化率")));
				赋予属性率 = ((Config.IniReadValue("GameServer", "赋予属性率").Length == 0) ? 赋予属性率 : double.Parse(Config.IniReadValue("GameServer", "赋予属性率")));
				附魂率 = ((Config.IniReadValue("GameServer", "附魂率").Length == 0) ? 附魂率 : double.Parse(Config.IniReadValue("GameServer", "附魂率")));
				首饰加工率 = ((Config.IniReadValue("GameServer", "首饰加工率").Length == 0) ? 首饰加工率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工率")));
				披风强化率 = ((Config.IniReadValue("GameServer", "披风强化率").Length == 0) ? 披风强化率 : double.Parse(Config.IniReadValue("GameServer", "披风强化率")));
				装备升级率 = ((Config.IniReadValue("GameServer", "装备升级率").Length == 0) ? 装备升级率 : double.Parse(Config.IniReadValue("GameServer", "装备升级率")));
				首饰升级率 = ((Config.IniReadValue("GameServer", "首饰升级率").Length == 0) ? 首饰升级率 : double.Parse(Config.IniReadValue("GameServer", "首饰升级率")));
				元宝合成 = ((Config.IniReadValue("GameServer", "元宝合成").Trim().Length == 0) ? 元宝合成 : int.Parse(Config.IniReadValue("GameServer", "元宝合成").Trim()));
				是否加密 = ((Config.IniReadValue("GameServer", "是否加密").Trim().Length == 0) ? 是否加密 : int.Parse(Config.IniReadValue("GameServer", "是否加密").Trim()));
				元宝送积分是否开启 = ((Config.IniReadValue("GameServer", "元宝送积分是否开启").Trim().Length == 0) ? 元宝送积分是否开启 : int.Parse(Config.IniReadValue("GameServer", "元宝送积分是否开启").Trim()));
				百宝消费榜是否开启 = ((Config.IniReadValue("GameServer", "百宝消费榜是否开启").Trim().Length == 0) ? 百宝消费榜是否开启 : int.Parse(Config.IniReadValue("GameServer", "百宝消费榜是否开启").Trim()));
				加密密钥 = Config.IniReadValue("GameServer", "加密密钥").Trim();
				版本验证时间 = ((Config.IniReadValue("GameServer", "版本验证时间").Trim().Length == 0) ? 版本验证时间 : int.Parse(Config.IniReadValue("GameServer", "版本验证时间").Trim()));
				Vip上线公告 = ((Config.IniReadValue("GameServer", "Vip上线公告").Trim().Length == 0) ? Vip上线公告 : int.Parse(Config.IniReadValue("GameServer", "Vip上线公告").Trim()));
				Vip上线公告内容 = ((Config.IniReadValue("GameServer", "Vip上线公告内容").Trim().Length == 0) ? Vip上线公告内容 : Config.IniReadValue("GameServer", "Vip上线公告内容").Trim());
				VIP地图 = Config.IniReadValue("GameServer", "VIP地图").Trim();
				是否开启前十上线公告 = ((Config.IniReadValue("GameServer", "是否开启前十上线公告").Trim().Length == 0) ? 是否开启前十上线公告 : int.Parse(Config.IniReadValue("GameServer", "是否开启前十上线公告").Trim()));
				前十上线公告内容 = ((Config.IniReadValue("GameServer", "前十上线公告内容").Trim().Length == 0) ? 前十上线公告内容 : Config.IniReadValue("GameServer", "前十上线公告内容").Trim());
				神豪上线公告内容 = ((Config.IniReadValue("GameServer", "神豪上线公告内容").Trim().Length == 0) ? 神豪上线公告内容 : Config.IniReadValue("GameServer", "神豪上线公告内容").Trim());
				普通上线公告内容 = ((Config.IniReadValue("GameServer", "普通上线公告内容").Trim().Length == 0) ? 普通上线公告内容 : Config.IniReadValue("GameServer", "普通上线公告内容").Trim());
				查非法物品 = ((Config.IniReadValue("GameServer", "查非法物品").Trim().Length == 0) ? 查非法物品 : int.Parse(Config.IniReadValue("GameServer", "查非法物品").Trim()));
				查绑定非法物品 = ((Config.IniReadValue("GameServer", "查绑定非法物品").Trim().Length == 0) ? 查绑定非法物品 : (Config.IniReadValue("GameServer", "查绑定非法物品").Trim() == "1"));
				查非法物品操作 = ((Config.IniReadValue("GameServer", "查非法物品操作").Trim().Length == 0) ? 查非法物品操作 : int.Parse(Config.IniReadValue("GameServer", "查非法物品操作").Trim()));
				物品最高攻击值 = ((Config.IniReadValue("GameServer", "物品最高攻击值").Trim().Length == 0) ? 物品最高攻击值 : int.Parse(Config.IniReadValue("GameServer", "物品最高攻击值").Trim()));
				物品最高防御值 = ((Config.IniReadValue("GameServer", "物品最高防御值").Trim().Length == 0) ? 物品最高防御值 : int.Parse(Config.IniReadValue("GameServer", "物品最高防御值").Trim()));
				物品最高生命值 = ((Config.IniReadValue("GameServer", "物品最高生命值").Trim().Length == 0) ? 物品最高生命值 : int.Parse(Config.IniReadValue("GameServer", "物品最高生命值").Trim()));
				物品最高内功值 = ((Config.IniReadValue("GameServer", "物品最高内功值").Trim().Length == 0) ? 物品最高内功值 : int.Parse(Config.IniReadValue("GameServer", "物品最高内功值").Trim()));
				物品最高命中值 = ((Config.IniReadValue("GameServer", "物品最高命中值").Trim().Length == 0) ? 物品最高命中值 : int.Parse(Config.IniReadValue("GameServer", "物品最高命中值").Trim()));
				物品最高回避值 = ((Config.IniReadValue("GameServer", "物品最高回避值").Trim().Length == 0) ? 物品最高回避值 : int.Parse(Config.IniReadValue("GameServer", "物品最高回避值").Trim()));
				物品最高武功值 = ((Config.IniReadValue("GameServer", "物品最高武功值").Trim().Length == 0) ? 物品最高武功值 : int.Parse(Config.IniReadValue("GameServer", "物品最高武功值").Trim()));
				物品最高气功值 = ((Config.IniReadValue("GameServer", "物品最高气功值").Trim().Length == 0) ? 物品最高气功值 : int.Parse(Config.IniReadValue("GameServer", "物品最高气功值").Trim()));
				物品最高合成值 = ((Config.IniReadValue("GameServer", "物品最高合成值").Trim().Length == 0) ? 物品最高合成值 : int.Parse(Config.IniReadValue("GameServer", "物品最高合成值").Trim()));
				物品最高附魂值 = ((Config.IniReadValue("GameServer", "物品最高附魂值").Trim().Length == 0) ? 物品最高附魂值 : int.Parse(Config.IniReadValue("GameServer", "物品最高附魂值").Trim()));
				物品最高武防值 = ((Config.IniReadValue("GameServer", "物品最高武防值").Trim().Length == 0) ? 物品最高武防值 : int.Parse(Config.IniReadValue("GameServer", "物品最高武防值").Trim()));
				仙魔大战胜利奖励物品 = Config.IniReadValue("GameServer", "仙魔大战胜利奖励物品").Trim();
				仙魔大战失败奖励物品 = Config.IniReadValue("GameServer", "仙魔大战失败奖励物品").Trim();
				仙魔大战平局奖励物品 = Config.IniReadValue("GameServer", "仙魔大战平局奖励物品").Trim();
				势力战胜利奖励物品 = Config.IniReadValue("GameServer", "势力战胜利奖励物品").Trim();
				势力战参与奖励物品 = Config.IniReadValue("GameServer", "势力战参与奖励物品").Trim();
				天魔胜利奖励物品 = Config.IniReadValue("GameServer", "天魔胜利奖励物品").Trim();
				天魔失败奖励物品 = Config.IniReadValue("GameServer", "天魔失败奖励物品").Trim();
				门战参与奖励物品 = Config.IniReadValue("GameServer", "门战参与奖励物品").Trim();
				门战奖励 = Config.IniReadValue("GameServer", "门战奖励").Trim().Split(';');
				门战奖励物品ID = ((Config.IniReadValue("GameServer", "门战奖励物品ID").Trim().Length == 0) ? 门战奖励物品ID : int.Parse(Config.IniReadValue("GameServer", "门战奖励物品ID").Trim()));
				是否开启打坐打怪 = int.Parse(Config.IniReadValue("GameServer", "是否开启打坐打怪").Trim());
				SqlJl = ((Config.IniReadValue("GameServer", "SqlJl").Trim().Length == 0) ? SqlJl : Config.IniReadValue("GameServer", "SqlJl").Trim());
				AutoSave = ((Config.IniReadValue("GameServer", "自动存档").Trim().Length == 0) ? AutoSave : int.Parse(Config.IniReadValue("GameServer", "自动存档").Trim()));
				物品记录 = ((Config.IniReadValue("GameServer", "物品记录").Trim().Length == 0) ? 物品记录 : int.Parse(Config.IniReadValue("GameServer", "物品记录").Trim()));
				登陆记录 = ((Config.IniReadValue("GameServer", "登陆记录").Trim().Length == 0) ? 登陆记录 : int.Parse(Config.IniReadValue("GameServer", "登陆记录").Trim()));
				掉落记录 = ((Config.IniReadValue("GameServer", "掉落记录").Trim().Length == 0) ? 掉落记录 : int.Parse(Config.IniReadValue("GameServer", "掉落记录").Trim()));
				药品记录 = ((Config.IniReadValue("GameServer", "药品记录").Trim().Length == 0) ? 药品记录 : int.Parse(Config.IniReadValue("GameServer", "药品记录").Trim()));
				合成记录 = ((Config.IniReadValue("GameServer", "合成记录").Trim().Length == 0) ? 合成记录 : int.Parse(Config.IniReadValue("GameServer", "合成记录").Trim()));
				商店记录 = ((Config.IniReadValue("GameServer", "商店记录").Trim().Length == 0) ? 商店记录 : int.Parse(Config.IniReadValue("GameServer", "商店记录").Trim()));
				传书记录 = ((Config.IniReadValue("GameServer", "传书记录").Trim().Length == 0) ? 传书记录 : int.Parse(Config.IniReadValue("GameServer", "传书记录").Trim()));
				开盒记录 = ((Config.IniReadValue("GameServer", "开盒记录").Trim().Length == 0) ? 开盒记录 : int.Parse(Config.IniReadValue("GameServer", "开盒记录").Trim()));
				进化记录 = ((Config.IniReadValue("GameServer", "进化记录").Trim().Length == 0) ? 进化记录 : int.Parse(Config.IniReadValue("GameServer", "进化记录").Trim()));
				卡号记录 = ((Config.IniReadValue("GameServer", "卡号记录").Trim().Length == 0) ? 卡号记录 : int.Parse(Config.IniReadValue("GameServer", "卡号记录").Trim()));
				记录保存天数 = ((Config.IniReadValue("GameServer", "记录保存天数").Trim().Length == 0) ? 记录保存天数 : int.Parse(Config.IniReadValue("GameServer", "记录保存天数").Trim()));
				传书保存天数 = ((Config.IniReadValue("GameServer", "传书保存天数").Trim().Length == 0) ? 传书保存天数 : int.Parse(Config.IniReadValue("GameServer", "传书保存天数").Trim()));
				元宝检测 = ((Config.IniReadValue("GameServer", "元宝检测").Trim().Length == 0) ? 元宝检测 : int.Parse(Config.IniReadValue("GameServer", "元宝检测").Trim()));
				外挂打怪时间 = ((Config.IniReadValue("GameServer", "外挂打怪时间").Trim().Length == 0) ? 外挂打怪时间 : int.Parse(Config.IniReadValue("GameServer", "外挂打怪时间").Trim()));
				外挂PK时间 = ((Config.IniReadValue("GameServer", "外挂PK时间").Trim().Length == 0) ? 外挂PK时间 : int.Parse(Config.IniReadValue("GameServer", "外挂PK时间").Trim()));
				升天技能等级加成 = ((Config.IniReadValue("GameServer", "升天技能等级加成").Trim().Length == 0) ? 1 : int.Parse(Config.IniReadValue("GameServer", "升天技能等级加成").Trim()));
				组队级别限制 = ((Config.IniReadValue("GameServer", "组队级别限制").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "组队级别限制").Trim()) : 0);
				是否开启安全模式 = ((Config.IniReadValue("GameServer", "是否开启安全模式").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "是否开启安全模式").Trim()) : 0);
				是否开启新手上线设置 = ((Config.IniReadValue("GameServer", "是否开启新手上线设置").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "是否开启新手上线设置").Trim()) : 0);
				登录器版本切换 = ((Config.IniReadValue("GameServer", "登录器版本切换").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "登录器版本切换").Trim()) : 0);
				上线等级 = ((Config.IniReadValue("GameServer", "上线等级").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "上线等级").Trim()) : 0);
				上线转职等级 = ((Config.IniReadValue("GameServer", "上线转职等级").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "上线转职等级").Trim()) : 0);
				上线金币数量 = ((Config.IniReadValue("GameServer", "上线金币数量").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "上线金币数量").Trim()) : 0);
				上线历练数量 = ((Config.IniReadValue("GameServer", "上线历练数量").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "上线历练数量").Trim()) : 0);
				上线武勋设置 = ((Config.IniReadValue("GameServer", "上线武勋设置").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "上线武勋设置").Trim()) : 0);
				自动分配正邪 = ((Config.IniReadValue("GameServer", "自动分配正邪").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "自动分配正邪").Trim()) : 0);
				上线升天气功点 = ((Config.IniReadValue("GameServer", "上线升天气功点").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "上线升天气功点").Trim()) : 0);
				赠送气功书 = ((Config.IniReadValue("GameServer", "赠送气功书").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "赠送气功书").Trim()) : 0);
				转职赠送礼包 = int.Parse(Config.IniReadValue("GameServer", "转职赠送礼包").Trim());
				上线送礼包是否开启 = int.Parse(Config.IniReadValue("GameServer", "上线送礼包是否开启").Trim());
				上线送礼包套装 = ((Config.IniReadValue("GameServer", "上线送礼包套装").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "上线送礼包套装").Trim()) : 0);
				是否开启银票兑换元宝 = ((Config.IniReadValue("GameServer", "是否开启银票兑换元宝").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "是否开启银票兑换元宝").Trim()) : 0);
				银票兑换元宝 = ((Config.IniReadValue("GameServer", "银票兑换元宝").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "银票兑换元宝").Trim()) : 0);
				是否开启挂机奖励 = ((Config.IniReadValue("GameServer", "是否开启挂机奖励").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "是否开启挂机奖励").Trim()) : 0);
				挂机奖励时间周期 = ((Config.IniReadValue("GameServer", "挂机奖励时间周期").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "挂机奖励时间周期").Trim()) : 0);
				挂机奖励要求等级 = ((Config.IniReadValue("GameServer", "挂机奖励要求等级").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "挂机奖励要求等级").Trim()) : 0);
				普通挂机奖励元宝 = ((Config.IniReadValue("GameServer", "普通挂机奖励元宝").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "普通挂机奖励元宝").Trim()) : 0);
				会员挂机奖励元宝 = ((Config.IniReadValue("GameServer", "会员挂机奖励元宝").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "会员挂机奖励元宝").Trim()) : 0);
				挂机奖励抽奖次数 = ((Config.IniReadValue("GameServer", "挂机奖励抽奖次数").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "挂机奖励抽奖次数").Trim()) : 0);
				普通挂机奖励武勋 = ((Config.IniReadValue("GameServer", "普通挂机奖励武勋").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "普通挂机奖励武勋").Trim()) : 0);
				会员挂机奖励武勋 = ((Config.IniReadValue("GameServer", "会员挂机奖励武勋").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "会员挂机奖励武勋").Trim()) : 0);
				普通挂机奖励钻石 = ((Config.IniReadValue("GameServer", "普通挂机奖励钻石").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "普通挂机奖励钻石").Trim()) : 0);
				会员挂机奖励钻石 = ((Config.IniReadValue("GameServer", "会员挂机奖励钻石").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "会员挂机奖励钻石").Trim()) : 0);
				挂机抽奖时间周期 = ((Config.IniReadValue("GameServer", "挂机抽奖时间周期").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "挂机抽奖时间周期").Trim()) : 0);
				挂机抽奖要求等级 = ((Config.IniReadValue("GameServer", "挂机抽奖要求等级").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "挂机抽奖要求等级").Trim()) : 0);
				挂机双倍时间段 = Config.IniReadValue("GameServer", "挂机双倍时间段").Trim();
				挂机双倍区域BOSS = Config.IniReadValue("GameServer", "挂机双倍区域BOSS").Trim();
				临时GM命令 = Config.IniReadValue("GameServer", "临时GM命令").Trim();
				临时管理员 = Config.IniReadValue("GameServer", "临时管理员").Trim();
				灵宠强化最大数量 = ((Config.IniReadValue("GameServer", "灵宠强化最大数量").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "灵宠强化最大数量").Trim()) : 0);
				披风强化最大数量 = ((Config.IniReadValue("GameServer", "披风强化最大数量").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "披风强化最大数量").Trim()) : 0);
				灵宠强化是否消耗武皇币 = ((Config.IniReadValue("GameServer", "灵宠强化是否消耗武皇币").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "灵宠强化是否消耗武皇币").Trim()) : 0);
				披风强化是否消耗元宝 = ((Config.IniReadValue("GameServer", "披风强化是否消耗元宝").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "披风强化是否消耗元宝").Trim()) : 0);
				异口同声是否开启 = ((Config.IniReadValue("GameServer", "异口同声是否开启").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "异口同声是否开启").Trim()) : 0);
				异口同声开启时 = ((Config.IniReadValue("GameServer", "异口同声开启时 ").Trim().Length == 0) ? 异口同声开启时 : int.Parse(Config.IniReadValue("GameServer", "异口同声开启时 ").Trim()));
				异口同声开启分 = ((Config.IniReadValue("GameServer", "异口同声开启分").Trim().Length == 0) ? 异口同声开启分 : int.Parse(Config.IniReadValue("GameServer", "异口同声开启分").Trim()));
				异口同声开启秒 = ((Config.IniReadValue("GameServer", "异口同声开启秒").Trim().Length == 0) ? 异口同声开启秒 : int.Parse(Config.IniReadValue("GameServer", "异口同声开启秒").Trim()));
				异口同声结束时间 = int.Parse(Config.IniReadValue("GameServer", "异口同声结束时间").Trim());
				异口同声内容 = Config.IniReadValue("GameServer", "异口同声内容").Trim();
				八彩属性增加 = Config.IniReadValue("GameServer", "八彩属性增加").Trim().Split(';');
				BOSS攻城是否开启 = int.Parse(Config.IniReadValue("GameServer", "BOSS攻城是否开启").Trim());
				BOSS攻城开启小时 = int.Parse(Config.IniReadValue("GameServer", "BOSS攻城开启小时").Trim());
				BOSS攻城开启分 = int.Parse(Config.IniReadValue("GameServer", "BOSS攻城开启分").Trim());
				BOSS攻城开启秒 = int.Parse(Config.IniReadValue("GameServer", "BOSS攻城开启秒").Trim());
				BOSS攻城倒计时 = int.Parse(Config.IniReadValue("GameServer", "BOSS攻城倒计时").Trim());
				BOSS攻城时间 = int.Parse(Config.IniReadValue("GameServer", "BOSS攻城时间").Trim());
				世界BOSS攻城是否开启 = int.Parse(Config.IniReadValue("GameServer", "世界BOSS攻城是否开启").Trim());
				世界BOSS攻城开启小时 = int.Parse(Config.IniReadValue("GameServer", "世界BOSS攻城开启小时").Trim());
				世界BOSS攻城开启分 = int.Parse(Config.IniReadValue("GameServer", "世界BOSS攻城开启分").Trim());
				世界BOSS攻城开启秒 = int.Parse(Config.IniReadValue("GameServer", "世界BOSS攻城开启秒").Trim());
				世界BOSS攻城倒计时 = int.Parse(Config.IniReadValue("GameServer", "世界BOSS攻城倒计时").Trim());
				世界BOSS攻城时间 = int.Parse(Config.IniReadValue("GameServer", "世界BOSS攻城时间").Trim());
				讨伐第一名钻石奖励数量 = int.Parse(Config.IniReadValue("GameServer", "讨伐第一名钻石奖励数量").Trim());
				讨伐第二名钻石奖励数量 = int.Parse(Config.IniReadValue("GameServer", "讨伐第二名钻石奖励数量").Trim());
				diamonds = int.Parse(Config.IniReadValue("GameServer", "讨伐第三名钻石奖励数量").Trim());
				讨伐第410名元宝奖励数量 = int.Parse(Config.IniReadValue("GameServer", "讨伐第410名元宝奖励数量").Trim());
				讨伐第一名boss奖励物品 = int.Parse(Config.IniReadValue("GameServer", "讨伐第一名boss奖励物品").Trim());
				讨伐第二名boss奖励物品 = int.Parse(Config.IniReadValue("GameServer", "讨伐第二名boss奖励物品").Trim());
				讨伐第三名boss奖励物品 = int.Parse(Config.IniReadValue("GameServer", "讨伐第三名boss奖励物品").Trim());
				BOSSPID = int.Parse(Config.IniReadValue("GameServer", "BOSSPID").Trim());
				BOSS地图 = int.Parse(Config.IniReadValue("GameServer", "BOSS地图").Trim());
				BOSS坐标X = int.Parse(Config.IniReadValue("GameServer", "BOSS坐标X").Trim());
				BOSS坐标Y = int.Parse(Config.IniReadValue("GameServer", "BOSS坐标Y").Trim());
				BOSS血 = int.Parse(Config.IniReadValue("GameServer", "BOSS血").Trim());
				BOSS攻击 = int.Parse(Config.IniReadValue("GameServer", "BOSS攻击").Trim());
				BOSS防御 = int.Parse(Config.IniReadValue("GameServer", "BOSS防御").Trim());
				披风强化消耗元宝数量 = ((Config.IniReadValue("GameServer", "披风强化消耗元宝数量").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "披风强化消耗元宝数量").Trim()) : 0);
				灵宠强化消耗武皇币数量 = ((Config.IniReadValue("GameServer", "灵宠强化消耗武皇币数量").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "灵宠强化消耗武皇币数量").Trim()) : 0);
				挂机消除宠物忠诚度 = ((Config.IniReadValue("GameServer", "挂机消除宠物忠诚度").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "挂机消除宠物忠诚度").Trim()) : 0);
				获得经验等级差 = ((Config.IniReadValue("GameServer", "获得经验等级差").Trim().Length == 0) ? 15 : int.Parse(Config.IniReadValue("GameServer", "获得经验等级差").Trim()));
				获得物品等级差 = Config.IniReadValue("GameServer", "获得物品等级差").Trim().Split(',');
				是否开启装备加解锁功能 = ((Config.IniReadValue("GameServer", "是否开启装备加解锁功能").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "是否开启装备加解锁功能").Trim()) : 0);
				装备加锁消耗元宝 = ((Config.IniReadValue("GameServer", "装备加锁消耗元宝").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "装备加锁消耗元宝").Trim()) : 0);
				装备解锁消耗元宝 = ((Config.IniReadValue("GameServer", "装备解锁消耗元宝").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "装备解锁消耗元宝").Trim()) : 0);
				单次交易元宝数量上限 = ((Config.IniReadValue("GameServer", "单次交易元宝数量上限").Trim().Length == 0) ? 单次交易元宝数量上限 : int.Parse(Config.IniReadValue("GameServer", "单次交易元宝数量上限").Trim()));
				帐号总元宝上限 = ((Config.IniReadValue("GameServer", "帐号总元宝上限").Trim().Length == 0) ? 帐号总元宝上限 : int.Parse(Config.IniReadValue("GameServer", "帐号总元宝上限").Trim()));
				元宝检测操作 = ((Config.IniReadValue("GameServer", "元宝检测操作").Trim().Length == 0) ? 元宝检测操作 : int.Parse(Config.IniReadValue("GameServer", "元宝检测操作").Trim()));
				是否开启武勋系统 = ((Config.IniReadValue("GameServer", "是否开启武勋系统").Trim().Length == 0) ? 是否开启武勋系统 : int.Parse(Config.IniReadValue("GameServer", "是否开启武勋系统").Trim()));
				PK等级差 = ((Config.IniReadValue("GameServer", "PK等级差").Trim().Length == 0) ? PK等级差 : int.Parse(Config.IniReadValue("GameServer", "PK等级差").Trim()));
				武勋保护等级 = ((Config.IniReadValue("GameServer", "武勋保护等级").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "武勋保护等级").Trim()) : 0);
				死亡减少武勋数量 = Config.IniReadValue("GameServer", "死亡减少武勋数量").Trim();
				系统回收数量 = Config.IniReadValue("GameServer", "系统回收数量").Trim();
				再造金刚石攻击 = Config.IniReadValue("GameServer", "再造金刚石攻击").Trim();
				再造金刚石追伤 = Config.IniReadValue("GameServer", "再造金刚石追伤").Trim();
				再造金刚石武功 = Config.IniReadValue("GameServer", "再造金刚石武功").Trim();
				再造金刚石命中 = Config.IniReadValue("GameServer", "再造金刚石命中").Trim();
				再造金刚石生命 = Config.IniReadValue("GameServer", "再造金刚石生命").Trim();
				再造寒玉石防御 = Config.IniReadValue("GameServer", "再造寒玉石防御").Trim();
				再造寒玉石回避 = Config.IniReadValue("GameServer", "再造寒玉石回避").Trim();
				再造寒玉石生命 = Config.IniReadValue("GameServer", "再造寒玉石生命").Trim();
				再造寒玉石内功 = Config.IniReadValue("GameServer", "再造寒玉石内功").Trim();
				再造寒玉石武防 = Config.IniReadValue("GameServer", "再造寒玉石武防").Trim();
				至尊强化率 = ((Config.IniReadValue("GameServer", "至尊强化率").Length == 0) ? 至尊强化率 : double.Parse(Config.IniReadValue("GameServer", "至尊强化率")));
				灵宠强化总概率 = Config.IniReadValue("GameServer", "灵宠强化总概率").Trim();
				灵宠强化一阶段概率 = ((Config.IniReadValue("GameServer", "灵宠强化一阶段概率") == "") ? 灵宠强化一阶段概率 : double.Parse(Config.IniReadValue("GameServer", "灵宠强化一阶段概率")));
				灵宠强化二阶段概率 = ((Config.IniReadValue("GameServer", "灵宠强化二阶段概率") == "") ? 灵宠强化二阶段概率 : double.Parse(Config.IniReadValue("GameServer", "灵宠强化二阶段概率")));
				灵宠强化三阶段概率 = ((Config.IniReadValue("GameServer", "灵宠强化三阶段概率") == "") ? 灵宠强化三阶段概率 : double.Parse(Config.IniReadValue("GameServer", "灵宠强化三阶段概率")));
				灵宠强化四阶段概率 = ((Config.IniReadValue("GameServer", "灵宠强化四阶段概率") == "") ? 灵宠强化四阶段概率 : double.Parse(Config.IniReadValue("GameServer", "灵宠强化四阶段概率")));
				灵宠强化五阶段概率 = ((Config.IniReadValue("GameServer", "灵宠强化五阶段概率") == "") ? 灵宠强化一阶段概率 : double.Parse(Config.IniReadValue("GameServer", "灵宠强化五阶段概率")));
				灵宠强化六阶段概率 = ((Config.IniReadValue("GameServer", "灵宠强化六阶段概率") == "") ? 灵宠强化一阶段概率 : double.Parse(Config.IniReadValue("GameServer", "灵宠强化六阶段概率")));
				灵宠强化七阶段概率 = ((Config.IniReadValue("GameServer", "灵宠强化一阶段概率") == "") ? 灵宠强化七阶段概率 : double.Parse(Config.IniReadValue("GameServer", "灵宠强化七阶段概率")));
				赋予属性一阶段 = ((Config.IniReadValue("GameServer", "赋予属性一阶段") == "") ? 赋予属性一阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性一阶段")));
				赋予属性二阶段 = ((Config.IniReadValue("GameServer", "赋予属性二阶段") == "") ? 赋予属性二阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性二阶段")));
				赋予属性三阶段 = ((Config.IniReadValue("GameServer", "赋予属性三阶段") == "") ? 赋予属性三阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性三阶段")));
				赋予属性四阶段 = ((Config.IniReadValue("GameServer", "赋予属性四阶段") == "") ? 赋予属性四阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性四阶段")));
				赋予属性五阶段 = ((Config.IniReadValue("GameServer", "赋予属性五阶段") == "") ? 赋予属性五阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性五阶段")));
				赋予属性六阶段 = ((Config.IniReadValue("GameServer", "赋予属性六阶段") == "") ? 赋予属性六阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性六阶段")));
				赋予属性七阶段 = ((Config.IniReadValue("GameServer", "赋予属性七阶段") == "") ? 赋予属性七阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性七阶段")));
				赋予属性八阶段 = ((Config.IniReadValue("GameServer", "赋予属性八阶段") == "") ? 赋予属性八阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性八阶段")));
				赋予属性九阶段 = ((Config.IniReadValue("GameServer", "赋予属性九阶段") == "") ? 赋予属性九阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性九阶段")));
				赋予属性十阶段 = ((Config.IniReadValue("GameServer", "赋予属性十阶段") == "") ? 赋予属性十阶段 : double.Parse(Config.IniReadValue("GameServer", "赋予属性十阶段")));
				首饰加工一概率 = ((Config.IniReadValue("GameServer", "首饰加工一概率") == "") ? 首饰加工一概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工一概率")));
				首饰加工二概率 = ((Config.IniReadValue("GameServer", "首饰加工二概率") == "") ? 首饰加工二概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工二概率")));
				首饰加工三概率 = ((Config.IniReadValue("GameServer", "首饰加工三概率") == "") ? 首饰加工三概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工三概率")));
				首饰加工四概率 = ((Config.IniReadValue("GameServer", "首饰加工四概率") == "") ? 首饰加工四概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工四概率")));
				首饰加工五概率 = ((Config.IniReadValue("GameServer", "首饰加工五概率") == "") ? 首饰加工五概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工五概率")));
				首饰加工六概率 = ((Config.IniReadValue("GameServer", "首饰加工六概率") == "") ? 首饰加工六概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工六概率")));
				首饰加工七概率 = ((Config.IniReadValue("GameServer", "首饰加工七概率") == "") ? 首饰加工七概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工七概率")));
				首饰加工八概率 = ((Config.IniReadValue("GameServer", "首饰加工八概率") == "") ? 首饰加工八概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工八概率")));
				首饰加工九概率 = ((Config.IniReadValue("GameServer", "首饰加工九概率") == "") ? 首饰加工九概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工九概率")));
				首饰加工十概率 = ((Config.IniReadValue("GameServer", "首饰加工十概率") == "") ? 首饰加工十概率 : double.Parse(Config.IniReadValue("GameServer", "首饰加工十概率")));
				强化一合成率 = ((Config.IniReadValue("GameServer", "强化一合成率") == "") ? 强化一合成率 : double.Parse(Config.IniReadValue("GameServer", "强化一合成率")));
				强化二合成率 = ((Config.IniReadValue("GameServer", "强化二合成率") == "") ? 强化二合成率 : double.Parse(Config.IniReadValue("GameServer", "强化二合成率")));
				强化三合成率 = ((Config.IniReadValue("GameServer", "强化三合成率") == "") ? 强化三合成率 : double.Parse(Config.IniReadValue("GameServer", "强化三合成率")));
				强化四合成率 = ((Config.IniReadValue("GameServer", "强化四合成率") == "") ? 强化四合成率 : double.Parse(Config.IniReadValue("GameServer", "强化四合成率")));
				强化五合成率 = ((Config.IniReadValue("GameServer", "强化五合成率") == "") ? 强化五合成率 : double.Parse(Config.IniReadValue("GameServer", "强化五合成率")));
				强化六合成率 = ((Config.IniReadValue("GameServer", "强化六合成率") == "") ? 强化六合成率 : double.Parse(Config.IniReadValue("GameServer", "强化六合成率")));
				强化七合成率 = ((Config.IniReadValue("GameServer", "强化七合成率") == "") ? 强化七合成率 : double.Parse(Config.IniReadValue("GameServer", "强化七合成率")));
				强化八合成率 = ((Config.IniReadValue("GameServer", "强化八合成率") == "") ? 强化八合成率 : double.Parse(Config.IniReadValue("GameServer", "强化八合成率")));
				强化九合成率 = ((Config.IniReadValue("GameServer", "强化九合成率") == "") ? 强化九合成率 : double.Parse(Config.IniReadValue("GameServer", "强化九合成率")));
				强化十合成率 = ((Config.IniReadValue("GameServer", "强化十合成率") == "") ? 强化十合成率 : double.Parse(Config.IniReadValue("GameServer", "强化十合成率")));
				强化十一合成率 = ((Config.IniReadValue("GameServer", "强化十一合成率") == "") ? 强化十一合成率 : double.Parse(Config.IniReadValue("GameServer", "强化十一合成率")));
				强化十二合成率 = ((Config.IniReadValue("GameServer", "强化十二合成率") == "") ? 强化十二合成率 : double.Parse(Config.IniReadValue("GameServer", "强化十二合成率")));
				强化十三合成率 = ((Config.IniReadValue("GameServer", "强化十三合成率") == "") ? 强化十三合成率 : double.Parse(Config.IniReadValue("GameServer", "强化十三合成率")));
				强化十四合成率 = ((Config.IniReadValue("GameServer", "强化十四合成率") == "") ? 强化十四合成率 : double.Parse(Config.IniReadValue("GameServer", "强化十四合成率")));
				强化十五合成率 = ((Config.IniReadValue("GameServer", "强化十五合成率") == "") ? 强化十五合成率 : double.Parse(Config.IniReadValue("GameServer", "强化十五合成率")));
				至尊强化率 = ((Config.IniReadValue("GameServer", "至尊强化率").Length == 0) ? 至尊强化率 : double.Parse(Config.IniReadValue("GameServer", "至尊强化率")));
				至尊取玉强11 = ((Config.IniReadValue("GameServer", "至尊取玉强11") == "") ? 至尊取玉强11 : double.Parse(Config.IniReadValue("GameServer", "至尊取玉强11")));
				至尊取玉强12 = ((Config.IniReadValue("GameServer", "至尊取玉强12") == "") ? 至尊取玉强12 : double.Parse(Config.IniReadValue("GameServer", "至尊取玉强12")));
				至尊取玉强13 = ((Config.IniReadValue("GameServer", "至尊取玉强13") == "") ? 至尊取玉强13 : double.Parse(Config.IniReadValue("GameServer", "至尊取玉强13")));
				至尊取玉强14 = ((Config.IniReadValue("GameServer", "至尊取玉强14") == "") ? 至尊取玉强14 : double.Parse(Config.IniReadValue("GameServer", "至尊取玉强14")));
				至尊取玉强15 = ((Config.IniReadValue("GameServer", "至尊取玉强15") == "") ? 至尊取玉强15 : double.Parse(Config.IniReadValue("GameServer", "至尊取玉强15")));
				天气系统开关 = int.Parse(Config.IniReadValue("GameServer", "天气系统开关").Trim());
				无限负重 = int.Parse(Config.IniReadValue("GameServer", "无限负重").Trim());
				PK掉装备 = int.Parse(Config.IniReadValue("GameServer", "PK掉装备").Trim());
				PK掉装备善恶 = int.Parse(Config.IniReadValue("GameServer", "PK掉装备善恶").Trim());
				PK掉装备几率 = int.Parse(Config.IniReadValue("GameServer", "PK掉装备几率").Trim());
				水晶符强1 = ((Config.IniReadValue("GameServer", "水晶符强1") == "") ? 水晶符强1 : double.Parse(Config.IniReadValue("GameServer", "水晶符强1")));
				水晶符强2 = ((Config.IniReadValue("GameServer", "水晶符强2") == "") ? 水晶符强2 : double.Parse(Config.IniReadValue("GameServer", "水晶符强2")));
				水晶符强3 = ((Config.IniReadValue("GameServer", "水晶符强3") == "") ? 水晶符强3 : double.Parse(Config.IniReadValue("GameServer", "水晶符强3")));
				水晶符强4 = ((Config.IniReadValue("GameServer", "水晶符强4") == "") ? 水晶符强4 : double.Parse(Config.IniReadValue("GameServer", "水晶符强4")));
				水晶符强5 = ((Config.IniReadValue("GameServer", "水晶符强5") == "") ? 水晶符强5 : double.Parse(Config.IniReadValue("GameServer", "水晶符强5")));
				水晶符强6 = ((Config.IniReadValue("GameServer", "水晶符强6") == "") ? 水晶符强6 : double.Parse(Config.IniReadValue("GameServer", "水晶符强6")));
				水晶符强7 = ((Config.IniReadValue("GameServer", "水晶符强7") == "") ? 水晶符强7 : double.Parse(Config.IniReadValue("GameServer", "水晶符强7")));
				水晶符强8 = ((Config.IniReadValue("GameServer", "水晶符强8") == "") ? 水晶符强8 : double.Parse(Config.IniReadValue("GameServer", "水晶符强8")));
				水晶符强9 = ((Config.IniReadValue("GameServer", "水晶符强9") == "") ? 水晶符强9 : double.Parse(Config.IniReadValue("GameServer", "水晶符强9")));
				水晶符强10 = ((Config.IniReadValue("GameServer", "水晶符强10") == "") ? 水晶符强10 : double.Parse(Config.IniReadValue("GameServer", "水晶符强10")));
				至高无上称号奖励 = Config.IniReadValue("GameServer", "至高无上称号奖励").Trim().Split(';');
				举世无双称号奖励 = Config.IniReadValue("GameServer", "举世无双称号奖励").Trim().Split(';');
				雄霸天下称号奖励 = Config.IniReadValue("GameServer", "雄霸天下称号奖励").Trim().Split(';');
				孤胆英雄称号奖励 = Config.IniReadValue("GameServer", "孤胆英雄称号奖励").Trim().Split(';');
				英雄豪杰称号奖励 = Config.IniReadValue("GameServer", "英雄豪杰称号奖励").Trim().Split(';');
				VIP称号增加攻击 = Config.IniReadValue("GameServer", "VIP称号增加攻击").Trim().Split(';');
				VIP称号增加防御 = Config.IniReadValue("GameServer", "VIP称号增加防御").Trim().Split(';');
				VIP称号增加生命 = Config.IniReadValue("GameServer", "VIP称号增加生命").Trim().Split(';');
				首充命令 = Config.IniReadValue("GameServer", "首充命令").Trim();
				福利命令 = Config.IniReadValue("GameServer", "福利命令").Trim();
				装备升级命令 = Config.IniReadValue("GameServer", "装备升级命令").Trim();
				转生命令 = Config.IniReadValue("GameServer", "转生命令").Trim();
				限制转生次数 = int.Parse(Config.IniReadValue("GameServer", "限制转生次数").Trim());
				转生需要几转 = int.Parse(Config.IniReadValue("GameServer", "转生需要几转").Trim());
				转生降落几转 = int.Parse(Config.IniReadValue("GameServer", "转生降落几转").Trim());
				转生需要等级 = int.Parse(Config.IniReadValue("GameServer", "转生需要等级").Trim());
				转生回落等级 = int.Parse(Config.IniReadValue("GameServer", "转生回落等级").Trim());
				转生获得属性 = Config.IniReadValue("GameServer", "转生获得属性").Trim();
				武器8阶段添加攻击 = ((!(Config.IniReadValue("GameServer", "武器8阶段添加攻击").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "武器8阶段添加攻击").Trim()) : 0);
				武器9阶段添加攻击 = ((!(Config.IniReadValue("GameServer", "武器9阶段添加攻击").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "武器9阶段添加攻击").Trim()) : 0);
				武器10阶段添加攻击 = ((!(Config.IniReadValue("GameServer", "武器10阶段添加攻击").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "武器10阶段添加攻击").Trim()) : 0);
				武器11阶段添加攻击 = ((!(Config.IniReadValue("GameServer", "武器11阶段添加攻击").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "武器11阶段添加攻击").Trim()) : 0);
				武器12阶段添加攻击 = ((!(Config.IniReadValue("GameServer", "武器12阶段添加攻击").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "武器12阶段添加攻击").Trim()) : 0);
				武器13阶段添加攻击 = ((!(Config.IniReadValue("GameServer", "武器13阶段添加攻击").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "武器13阶段添加攻击").Trim()) : 0);
				武器14阶段添加攻击 = ((!(Config.IniReadValue("GameServer", "武器14阶段添加攻击").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "武器14阶段添加攻击").Trim()) : 0);
				武器15阶段添加攻击 = ((!(Config.IniReadValue("GameServer", "武器15阶段添加攻击").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "武器15阶段添加攻击").Trim()) : 0);
				衣服8阶段添加防御 = ((!(Config.IniReadValue("GameServer", "衣服8阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "衣服8阶段添加防御").Trim()) : 0);
				衣服9阶段添加防御 = ((!(Config.IniReadValue("GameServer", "衣服9阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "衣服9阶段添加防御").Trim()) : 0);
				衣服10阶段添加防御 = ((!(Config.IniReadValue("GameServer", "衣服10阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "衣服10阶段添加防御").Trim()) : 0);
				衣服11阶段添加防御 = ((!(Config.IniReadValue("GameServer", "衣服11阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "衣服11阶段添加防御").Trim()) : 0);
				衣服12阶段添加防御 = ((!(Config.IniReadValue("GameServer", "衣服12阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "衣服12阶段添加防御").Trim()) : 0);
				衣服13阶段添加防御 = ((!(Config.IniReadValue("GameServer", "衣服13阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "衣服13阶段添加防御").Trim()) : 0);
				衣服14阶段添加防御 = ((!(Config.IniReadValue("GameServer", "衣服14阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "衣服14阶段添加防御").Trim()) : 0);
				衣服15阶段添加防御 = ((!(Config.IniReadValue("GameServer", "衣服15阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "衣服15阶段添加防御").Trim()) : 0);
				鞋子8阶段添加防御 = ((!(Config.IniReadValue("GameServer", "鞋子8阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "鞋子8阶段添加防御").Trim()) : 0);
				鞋子9阶段添加防御 = ((!(Config.IniReadValue("GameServer", "鞋子9阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "鞋子9阶段添加防御").Trim()) : 0);
				鞋子10阶段添加防御 = ((!(Config.IniReadValue("GameServer", "鞋子10阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "鞋子10阶段添加防御").Trim()) : 0);
				鞋子11阶段添加防御 = ((!(Config.IniReadValue("GameServer", "鞋子11阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "鞋子11阶段添加防御").Trim()) : 0);
				鞋子12阶段添加防御 = ((!(Config.IniReadValue("GameServer", "鞋子12阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "鞋子12阶段添加防御").Trim()) : 0);
				鞋子13阶段添加防御 = ((!(Config.IniReadValue("GameServer", "鞋子13阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "鞋子13阶段添加防御").Trim()) : 0);
				鞋子14阶段添加防御 = ((!(Config.IniReadValue("GameServer", "鞋子14阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "鞋子14阶段添加防御").Trim()) : 0);
				鞋子15阶段添加防御 = ((!(Config.IniReadValue("GameServer", "鞋子15阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "鞋子15阶段添加防御").Trim()) : 0);
				护手8阶段添加防御 = ((!(Config.IniReadValue("GameServer", "护手8阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "护手8阶段添加防御").Trim()) : 0);
				护手9阶段添加防御 = ((!(Config.IniReadValue("GameServer", "护手9阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "护手9阶段添加防御").Trim()) : 0);
				护手10阶段添加防御 = ((!(Config.IniReadValue("GameServer", "护手10阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "护手10阶段添加防御").Trim()) : 0);
				护手11阶段添加防御 = ((!(Config.IniReadValue("GameServer", "护手11阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "护手11阶段添加防御").Trim()) : 0);
				护手12阶段添加防御 = ((!(Config.IniReadValue("GameServer", "护手12阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "护手12阶段添加防御").Trim()) : 0);
				护手13阶段添加防御 = ((!(Config.IniReadValue("GameServer", "护手13阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "护手13阶段添加防御").Trim()) : 0);
				护手14阶段添加防御 = ((!(Config.IniReadValue("GameServer", "护手14阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "护手14阶段添加防御").Trim()) : 0);
				护手15阶段添加防御 = ((!(Config.IniReadValue("GameServer", "护手15阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "护手15阶段添加防御").Trim()) : 0);
				内甲8阶段添加防御 = ((!(Config.IniReadValue("GameServer", "内甲8阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "内甲8阶段添加防御").Trim()) : 0);
				内甲9阶段添加防御 = ((!(Config.IniReadValue("GameServer", "内甲9阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "内甲9阶段添加防御").Trim()) : 0);
				内甲10阶段添加防御 = ((!(Config.IniReadValue("GameServer", "内甲10阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "内甲10阶段添加防御").Trim()) : 0);
				内甲11阶段添加防御 = ((!(Config.IniReadValue("GameServer", "内甲11阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "内甲11阶段添加防御").Trim()) : 0);
				内甲12阶段添加防御 = ((!(Config.IniReadValue("GameServer", "内甲12阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "内甲12阶段添加防御").Trim()) : 0);
				内甲13阶段添加防御 = ((!(Config.IniReadValue("GameServer", "内甲13阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "内甲13阶段添加防御").Trim()) : 0);
				内甲14阶段添加防御 = ((!(Config.IniReadValue("GameServer", "内甲14阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "内甲14阶段添加防御").Trim()) : 0);
				内甲15阶段添加防御 = ((!(Config.IniReadValue("GameServer", "内甲15阶段添加防御").Trim() == "")) ? int.Parse(Config.IniReadValue("GameServer", "内甲15阶段添加防御").Trim()) : 0);
				荣誉排行榜更新时间 = ((Config.IniReadValue("GameServer", "荣誉排行榜更新时间") == "") ? 荣誉排行榜更新时间 : double.Parse(Config.IniReadValue("GameServer", "荣誉排行榜更新时间")));
				八彩提示是否开启 = int.Parse(Config.IniReadValue("GameServer", "八彩提示是否开启").Trim());
				八彩红色提示内容 = Config.IniReadValue("GameServer", "八彩红色提示内容").Trim();
				八彩赤色提示内容 = Config.IniReadValue("GameServer", "八彩赤色提示内容").Trim();
				八彩橙色提示内容 = Config.IniReadValue("GameServer", "八彩橙色提示内容").Trim();
				八彩绿色提示内容 = Config.IniReadValue("GameServer", "八彩绿色提示内容").Trim();
				八彩蓝色提示内容 = Config.IniReadValue("GameServer", "八彩蓝色提示内容").Trim();
				八彩深蓝提示内容 = Config.IniReadValue("GameServer", "八彩深蓝提示内容").Trim();
				八彩紫色提示内容 = Config.IniReadValue("GameServer", "八彩紫色提示内容").Trim();
				八彩浅色提示内容 = Config.IniReadValue("GameServer", "八彩浅色提示内容").Trim();
				剑对怪物伤害 = ((Config.IniReadValue("GameServer", "剑对怪物伤害") == string.Empty) ? 剑对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "剑对怪物伤害")));
				刀对怪物伤害 = ((Config.IniReadValue("GameServer", "刀对怪物伤害") == string.Empty) ? 刀对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "刀对怪物伤害")));
				枪对怪物伤害 = ((Config.IniReadValue("GameServer", "枪对怪物伤害") == string.Empty) ? 枪对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "枪对怪物伤害")));
				弓对怪物伤害 = ((Config.IniReadValue("GameServer", "弓对怪物伤害") == string.Empty) ? 弓对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "弓对怪物伤害")));
				医对怪物伤害 = ((Config.IniReadValue("GameServer", "医对怪物伤害") == string.Empty) ? 医对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "医对怪物伤害")));
				刺对怪物伤害 = ((Config.IniReadValue("GameServer", "刺对怪物伤害") == string.Empty) ? 刺对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "刺对怪物伤害")));
				琴对怪物伤害 = ((Config.IniReadValue("GameServer", "琴对怪物伤害") == string.Empty) ? 琴对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "琴对怪物伤害")));
				韩对怪物伤害 = ((Config.IniReadValue("GameServer", "韩对怪物伤害") == string.Empty) ? 韩对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "韩对怪物伤害")));
				谭对怪物伤害 = ((Config.IniReadValue("GameServer", "谭对怪物伤害") == string.Empty) ? 谭对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "谭对怪物伤害")));
				拳对怪物伤害 = ((Config.IniReadValue("GameServer", "拳对怪物伤害") == string.Empty) ? 拳对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "拳对怪物伤害")));
				梅对怪物伤害 = ((Config.IniReadValue("GameServer", "梅对怪物伤害") == string.Empty) ? 梅对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "梅对怪物伤害")));
				卢对怪物伤害 = ((Config.IniReadValue("GameServer", "卢对怪物伤害") == string.Empty) ? 卢对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "卢对怪物伤害")));
				神女对怪物伤害 = ((Config.IniReadValue("GameServer", "神女对怪物伤害") == string.Empty) ? 神女对怪物伤害 : double.Parse(Config.IniReadValue("GameServer", "神女对怪物伤害")));
				怪物防御百分比 = ((Config.IniReadValue("GameServer", "怪物防御百分比").Trim().Length == 0) ? 怪物防御百分比 : double.Parse(Config.IniReadValue("GameServer", "怪物防御百分比").Trim()));
				怪物攻击百分比 = ((Config.IniReadValue("GameServer", "怪物攻击百分比").Trim().Length == 0) ? 怪物攻击百分比 : double.Parse(Config.IniReadValue("GameServer", "怪物攻击百分比").Trim()));
				封印宝盒开启 = int.Parse(Config.IniReadValue("GameServer", "封印宝盒开启").Trim());
				开箱提示内容 = Config.IniReadValue("GameServer", "开箱提示内容").Trim();
				每次再造消耗设置 = ((Config.IniReadValue("GameServer", "每次再造消耗设置").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "每次再造消耗设置").Trim()) : 0);
				每次消耗的数量 = ((Config.IniReadValue("GameServer", "每次消耗的数量").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "每次消耗的数量").Trim()) : 0);
				double num = ((Config.IniReadValue("GameServer", "武功防降低百分比").Trim().Length == 0) ? 武功防降低百分比 : double.Parse(Config.IniReadValue("GameServer", "武功防降低百分比").Trim()));
				武功攻击力百分比 = ((Config.IniReadValue("GameServer", "武功攻击力百分比").Trim().Length == 0) ? 武功攻击力百分比 : double.Parse(Config.IniReadValue("GameServer", "武功攻击力百分比").Trim()));
				攻减防加乘 = ((Config.IniReadValue("GameServer", "攻减防加乘").Trim().Length == 0) ? 攻减防加乘 : double.Parse(Config.IniReadValue("GameServer", "攻减防加乘").Trim()));
				武功减武防加乘 = ((Config.IniReadValue("GameServer", "武功减武防加乘").Trim().Length == 0) ? 武功减武防加乘 : double.Parse(Config.IniReadValue("GameServer", "武功减武防加乘").Trim()));
				换线命令 = Config.IniReadValue("GameServer", "换线命令").Trim();
				是否开启GM功能 = ((Config.IniReadValue("GameServer", "是否开启GM功能").Trim().Length == 0) ? 是否开启GM功能 : int.Parse(Config.IniReadValue("GameServer", "是否开启GM功能").Trim()));
				是否开启王龙 = ((Config.IniReadValue("GameServer", "是否开启王龙").Trim().Length == 0) ? 是否开启王龙 : int.Parse(Config.IniReadValue("GameServer", "是否开启王龙").Trim()));
				武功防增加百分比 = ((Config.IniReadValue("GameServer", "武功防增加百分比").Trim().Length == 0) ? 武功防增加百分比 : double.Parse(Config.IniReadValue("GameServer", "武功防增加百分比").Trim()));
				二人组队经验加成 = ((Config.IniReadValue("GameServer", "二人组队经验加成").Trim().Length == 0) ? 二人组队经验加成 : double.Parse(Config.IniReadValue("GameServer", "二人组队经验加成").Trim()));
				三人组队经验加成 = ((Config.IniReadValue("GameServer", "三人组队经验加成").Trim().Length == 0) ? 三人组队经验加成 : double.Parse(Config.IniReadValue("GameServer", "三人组队经验加成").Trim()));
				四人组队经验加成 = ((Config.IniReadValue("GameServer", "四人组队经验加成").Trim().Length == 0) ? 四人组队经验加成 : double.Parse(Config.IniReadValue("GameServer", "四人组队经验加成").Trim()));
				五人组队经验加成 = ((Config.IniReadValue("GameServer", "五人组队经验加成").Trim().Length == 0) ? 五人组队经验加成 : double.Parse(Config.IniReadValue("GameServer", "五人组队经验加成").Trim()));
				六人组队经验加成 = ((Config.IniReadValue("GameServer", "六人组队经验加成").Trim().Length == 0) ? 六人组队经验加成 : double.Parse(Config.IniReadValue("GameServer", "六人组队经验加成").Trim()));
				七人组队经验加成 = ((Config.IniReadValue("GameServer", "七人组队经验加成").Trim().Length == 0) ? 七人组队经验加成 : double.Parse(Config.IniReadValue("GameServer", "七人组队经验加成").Trim()));
				八人组队经验加成 = ((Config.IniReadValue("GameServer", "八人组队经验加成").Trim().Length == 0) ? 八人组队经验加成 : double.Parse(Config.IniReadValue("GameServer", "八人组队经验加成").Trim()));
				武器防具进化2成功几率 = ((Config.IniReadValue("GameServer", "武器防具进化2成功几率").Length == 0) ? 武器防具进化2成功几率 : double.Parse(Config.IniReadValue("GameServer", "武器防具进化2成功几率")));
				if (武功防降低百分比 != num)
				{
					武功防降低百分比 = num;
					foreach (Players value in AllConnectedPlayers.Values)
					{
						value.计算人物装备数据();
					}
				}
				心跳检测开关 = ((Config.IniReadValue("GameServer", "心跳检测开关").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "心跳检测开关").Trim()) : 0);
				心跳检测时间阀值 = ((Config.IniReadValue("GameServer", "心跳检测时间阀值").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "心跳检测时间阀值").Trim()) : 0);
				心跳检测时长 = ((Config.IniReadValue("GameServer", "心跳检测时长").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "心跳检测时长").Trim()) : 0);
				安全模式时间 = Config.IniReadValue("GameServer", "安全模式时间").Trim().Split('-');
				安全模式消耗元宝 = ((Config.IniReadValue("GameServer", "安全模式消耗元宝").Trim().Length != 0) ? int.Parse(Config.IniReadValue("GameServer", "安全模式消耗元宝").Trim()) : 0);
				每次狮吼功消耗元宝 = ((Config.IniReadValue("GameServer", "每次狮吼功消耗元宝").Trim().Length == 0) ? 每次狮吼功消耗元宝 : int.Parse(Config.IniReadValue("GameServer", "每次狮吼功消耗元宝").Trim()));
				信任连接IP = Config.IniReadValue("GameServer", "信任连接IP").Trim();
				在线多开数量 = ((Config.IniReadValue("GameServer", "在线多开数量").Trim().Length == 0) ? 在线多开数量 : int.Parse(Config.IniReadValue("GameServer", "在线多开数量").Trim()));
				允许多开数量 = ((Config.IniReadValue("GameServer", "允许多开数量").Trim().Length == 0) ? 允许多开数量 : int.Parse(Config.IniReadValue("GameServer", "允许多开数量").Trim()));
				每次分解消耗元宝数 = ((Config.IniReadValue("GameServer", "每次分解消耗元宝数").Trim().Length == 0) ? 每次分解消耗元宝数 : int.Parse(Config.IniReadValue("GameServer", "每次分解消耗元宝数").Trim()));
				str = "是否开启对练场赌元宝";
				是否开启对练场赌元宝 = ((Config.IniReadValue("GameServer", "是否开启对练场赌元宝").Trim().Length == 0) ? 是否开启对练场赌元宝 : int.Parse(Config.IniReadValue("GameServer", "是否开启对练场赌元宝").Trim()));
				str = "进场最低费用";
				进场最低费用 = ((Config.IniReadValue("GameServer", "进场最低费用").Trim().Length == 0) ? 进场最低费用 : int.Parse(Config.IniReadValue("GameServer", "进场最低费用").Trim()));
				str = "场地佣金百分比";
				场地佣金百分比 = ((Config.IniReadValue("GameServer", "场地佣金百分比").Trim().Length == 0) ? 场地佣金百分比 : double.Parse(Config.IniReadValue("GameServer", "场地佣金百分比").Trim()));
				str = "场地有效范围";
				场地有效范围 = ((Config.IniReadValue("GameServer", "场地有效范围").Trim().Length == 0) ? 场地有效范围 : float.Parse(Config.IniReadValue("GameServer", "场地有效范围").Trim()));
				str = "分数扣完扣除元宝";
				分数扣完扣除元宝 = ((Config.IniReadValue("GameServer", "分数扣完扣除元宝").Trim().Length == 0) ? 分数扣完扣除元宝 : int.Parse(Config.IniReadValue("GameServer", "分数扣完扣除元宝").Trim()));
				str = "分数扣完扣除金钱";
				分数扣完扣除金钱 = ((Config.IniReadValue("GameServer", "分数扣完扣除金钱").Trim().Length == 0) ? 分数扣完扣除金钱 : int.Parse(Config.IniReadValue("GameServer", "分数扣完扣除金钱").Trim()));
				str = "允许玩家押注数量";
				允许玩家押注数量 = ((Config.IniReadValue("GameServer", "允许玩家押注数量").Trim().Length == 0) ? 允许玩家押注数量 : int.Parse(Config.IniReadValue("GameServer", "允许玩家押注数量").Trim()));
				str = "地图锁定";
				地图锁定 = Config.IniReadValue("GameServer", "地图锁定").Trim();
				str = "组队等级限制";
				组队等级限制 = ((Config.IniReadValue("GameServer", "组队等级限制").Trim().Length == 0) ? 组队等级限制 : int.Parse(Config.IniReadValue("GameServer", "组队等级限制").Trim()));
				str = "是否开启死亡掉经验";
				是否开启死亡掉经验 = ((Config.IniReadValue("GameServer", "是否开启死亡掉经验").Trim().Length == 0) ? 是否开启死亡掉经验 : int.Parse(Config.IniReadValue("GameServer", "是否开启死亡掉经验").Trim()));
				str = "VIP经验增加百分比";
				VIP经验增加百分比 = ((Config.IniReadValue("GameServer", "VIP经验增加百分比").Trim().Length == 0) ? VIP经验增加百分比 : double.Parse(Config.IniReadValue("GameServer", "VIP经验增加百分比").Trim()));
				str = "VIP历练增加百分比";
				VIP历练增加百分比 = ((Config.IniReadValue("GameServer", "VIP历练增加百分比").Trim().Length == 0) ? VIP历练增加百分比 : double.Parse(Config.IniReadValue("GameServer", "VIP历练增加百分比").Trim()));
				str = "VIP金钱增加百分比";
				VIP金钱增加百分比 = ((Config.IniReadValue("GameServer", "VIP金钱增加百分比").Trim().Length == 0) ? VIP金钱增加百分比 : double.Parse(Config.IniReadValue("GameServer", "VIP金钱增加百分比").Trim()));
				str = "医生PK距离";
				医生PK距离 = ((Config.IniReadValue("GameServer", "医生PK距离").Trim().Length == 0) ? 医生PK距离 : double.Parse(Config.IniReadValue("GameServer", "医生PK距离").Trim()));
				str = "弓箭手PK距离";
				弓箭手PK距离 = ((Config.IniReadValue("GameServer", "弓箭手PK距离").Trim().Length == 0) ? 弓箭手PK距离 : double.Parse(Config.IniReadValue("GameServer", "弓箭手PK距离").Trim()));
				str = "其他职业攻击距离";
				其他职业PK距离 = ((Config.IniReadValue("GameServer", "其他职业PK距离").Trim().Length == 0) ? 其他职业PK距离 : double.Parse(Config.IniReadValue("GameServer", "其他职业PK距离").Trim()));
				str = "医生打怪距离";
				医生打怪距离 = ((Config.IniReadValue("GameServer", "医生打怪距离").Trim().Length == 0) ? 医生打怪距离 : double.Parse(Config.IniReadValue("GameServer", "医生打怪距离").Trim()));
				str = "弓箭手PK距离";
				弓箭手打怪距离 = ((Config.IniReadValue("GameServer", "弓箭手打怪距离").Trim().Length == 0) ? 弓箭手打怪距离 : double.Parse(Config.IniReadValue("GameServer", "弓箭手打怪距离").Trim()));
				str = "其他职业攻击距离";
				其他职业打怪距离 = ((Config.IniReadValue("GameServer", "其他职业打怪距离").Trim().Length == 0) ? 其他职业打怪距离 : double.Parse(Config.IniReadValue("GameServer", "其他职业打怪距离").Trim()));
				第一名奖励礼包 = ((Config.IniReadValue("GameServer", "第一名奖励礼包").Trim().Length == 0) ? 500 : int.Parse(Config.IniReadValue("GameServer", "第一名奖励礼包").Trim()));
				武林血战奖励礼包 = ((Config.IniReadValue("GameServer", "武林血战奖励礼包").Trim().Length == 0) ? 500 : int.Parse(Config.IniReadValue("GameServer", "武林血战奖励礼包").Trim()));
				定制咕咕鸡属性 = Config.IniReadValue("GameServer", "定制咕咕鸡属性").Trim();
				是否开启咕咕鸡属性重置 = int.Parse(Config.IniReadValue("GameServer", "是否开启咕咕鸡属性重置").Trim());
				咕咕鸡属性 = Config.IniReadValue("GameServer", "咕咕鸡属性").Trim();
				咕咕鸡ID = ((Config.IniReadValue("GameServer", "咕咕鸡ID").Trim() == "") ? 咕咕鸡ID : int.Parse(Config.IniReadValue("GameServer", "咕咕鸡ID").Trim()));
				宝珠武器属性 = Config.IniReadValue("GameServer", "宝珠武器属性").Trim();
				宝珠武器高级属性 = Config.IniReadValue("GameServer", "宝珠武器高级属性").Trim();
				宝珠武器稀有属性 = Config.IniReadValue("GameServer", "宝珠武器稀有属性").Trim();
				宝珠武器传说属性 = Config.IniReadValue("GameServer", "宝珠武器传说属性").Trim();
				宝珠武器ID = ((Config.IniReadValue("GameServer", "宝珠武器ID").Trim() == "") ? 宝珠武器ID : int.Parse(Config.IniReadValue("GameServer", "宝珠武器ID").Trim()));
				宝珠衣服属性 = Config.IniReadValue("GameServer", "宝珠衣服属性").Trim();
				宝珠衣服高级属性 = Config.IniReadValue("GameServer", "宝珠衣服高级属性").Trim();
				宝珠衣服稀有属性 = Config.IniReadValue("GameServer", "宝珠衣服稀有属性").Trim();
				宝珠衣服传说属性 = Config.IniReadValue("GameServer", "宝珠衣服传说属性").Trim();
				宝珠衣服ID = ((Config.IniReadValue("GameServer", "宝珠衣服ID").Trim() == "") ? 宝珠衣服ID : int.Parse(Config.IniReadValue("GameServer", "宝珠衣服ID").Trim()));
				宝珠鞋子属性 = Config.IniReadValue("GameServer", "宝珠鞋子属性").Trim();
				宝珠鞋子高级属性 = Config.IniReadValue("GameServer", "宝珠鞋子高级属性").Trim();
				宝珠鞋子稀有属性 = Config.IniReadValue("GameServer", "宝珠鞋子稀有属性").Trim();
				宝珠鞋子传说属性 = Config.IniReadValue("GameServer", "宝珠鞋子传说属性").Trim();
				宝珠鞋子ID = ((Config.IniReadValue("GameServer", "宝珠鞋子ID").Trim() == "") ? 宝珠鞋子ID : int.Parse(Config.IniReadValue("GameServer", "宝珠鞋子ID").Trim()));
				宝珠护手属性 = Config.IniReadValue("GameServer", "宝珠护手属性").Trim();
				宝珠护手高级属性 = Config.IniReadValue("GameServer", "宝珠护手高级属性").Trim();
				宝珠护手稀有属性 = Config.IniReadValue("GameServer", "宝珠护手稀有属性").Trim();
				宝珠护手传说属性 = Config.IniReadValue("GameServer", "宝珠护手传说属性").Trim();
				宝珠护手ID = ((Config.IniReadValue("GameServer", "宝珠护手ID").Trim() == "") ? 宝珠护手ID : int.Parse(Config.IniReadValue("GameServer", "宝珠护手ID").Trim()));
				宝珠内甲属性 = Config.IniReadValue("GameServer", "宝珠内甲属性").Trim();
				宝珠内甲高级属性 = Config.IniReadValue("GameServer", "宝珠内甲高级属性").Trim();
				宝珠内甲稀有属性 = Config.IniReadValue("GameServer", "宝珠内甲稀有属性").Trim();
				宝珠内甲传说属性 = Config.IniReadValue("GameServer", "宝珠内甲传说属性").Trim();
				宝珠内甲ID = ((Config.IniReadValue("GameServer", "宝珠内甲ID").Trim() == "") ? 宝珠内甲ID : int.Parse(Config.IniReadValue("GameServer", "宝珠内甲ID").Trim()));
				宝珠武器高级ID = ((Config.IniReadValue("GameServer", "宝珠武器高级ID").Trim() == "") ? 宝珠武器高级ID : int.Parse(Config.IniReadValue("GameServer", "宝珠武器高级ID").Trim()));
				宝珠衣服高级ID = ((Config.IniReadValue("GameServer", "宝珠衣服高级ID").Trim() == "") ? 宝珠衣服高级ID : int.Parse(Config.IniReadValue("GameServer", "宝珠衣服高级ID").Trim()));
				宝珠鞋子高级ID = ((Config.IniReadValue("GameServer", "宝珠鞋子高级ID").Trim() == "") ? 宝珠鞋子高级ID : int.Parse(Config.IniReadValue("GameServer", "宝珠鞋子高级ID").Trim()));
				宝珠护手高级ID = ((Config.IniReadValue("GameServer", "宝珠护手高级ID").Trim() == "") ? 宝珠护手高级ID : int.Parse(Config.IniReadValue("GameServer", "宝珠护手高级ID").Trim()));
				宝珠内甲高级ID = ((Config.IniReadValue("GameServer", "宝珠内甲高级ID").Trim() == "") ? 宝珠内甲高级ID : int.Parse(Config.IniReadValue("GameServer", "宝珠内甲高级ID").Trim()));
				宝珠武器稀有ID = ((Config.IniReadValue("GameServer", "宝珠武器稀有ID").Trim() == "") ? 宝珠武器稀有ID : int.Parse(Config.IniReadValue("GameServer", "宝珠武器稀有ID").Trim()));
				宝珠衣服稀有ID = ((Config.IniReadValue("GameServer", "宝珠衣服稀有ID").Trim() == "") ? 宝珠衣服稀有ID : int.Parse(Config.IniReadValue("GameServer", "宝珠衣服稀有ID").Trim()));
				宝珠鞋子稀有ID = ((Config.IniReadValue("GameServer", "宝珠鞋子稀有ID").Trim() == "") ? 宝珠鞋子稀有ID : int.Parse(Config.IniReadValue("GameServer", "宝珠鞋子稀有ID").Trim()));
				宝珠护手稀有ID = ((Config.IniReadValue("GameServer", "宝珠护手稀有ID").Trim() == "") ? 宝珠护手稀有ID : int.Parse(Config.IniReadValue("GameServer", "宝珠护手稀有ID").Trim()));
				宝珠内甲稀有ID = ((Config.IniReadValue("GameServer", "宝珠内甲稀有ID").Trim() == "") ? 宝珠内甲稀有ID : int.Parse(Config.IniReadValue("GameServer", "宝珠内甲稀有ID").Trim()));
				宝珠武器传说ID = ((Config.IniReadValue("GameServer", "宝珠武器传说ID").Trim() == "") ? 宝珠武器传说ID : int.Parse(Config.IniReadValue("GameServer", "宝珠武器传说ID").Trim()));
				宝珠衣服传说ID = ((Config.IniReadValue("GameServer", "宝珠衣服传说ID").Trim() == "") ? 宝珠衣服传说ID : int.Parse(Config.IniReadValue("GameServer", "宝珠衣服传说ID").Trim()));
				宝珠鞋子传说ID = ((Config.IniReadValue("GameServer", "宝珠鞋子传说ID").Trim() == "") ? 宝珠鞋子传说ID : int.Parse(Config.IniReadValue("GameServer", "宝珠鞋子传说ID").Trim()));
				宝珠护手传说ID = ((Config.IniReadValue("GameServer", "宝珠护手传说ID").Trim() == "") ? 宝珠护手传说ID : int.Parse(Config.IniReadValue("GameServer", "宝珠护手传说ID").Trim()));
				宝珠内甲传说ID = ((Config.IniReadValue("GameServer", "宝珠内甲传说ID").Trim() == "") ? 宝珠内甲传说ID : int.Parse(Config.IniReadValue("GameServer", "宝珠内甲传说ID").Trim()));
				双倍奖励是否开启 = int.Parse(Config.IniReadValue("GameServer", "双倍奖励是否开启").Trim());
				双倍奖励开启小时 = int.Parse(Config.IniReadValue("GameServer", "双倍奖励开启小时").Trim());
				双倍奖励开启分 = int.Parse(Config.IniReadValue("GameServer", "双倍奖励开启分").Trim());
				双倍奖励开启秒 = int.Parse(Config.IniReadValue("GameServer", "双倍奖励开启秒").Trim());
				双倍奖励结束时间 = int.Parse(Config.IniReadValue("GameServer", "双倍奖励结束时间").Trim());
				双倍奖励经验倍数 = int.Parse(Config.IniReadValue("GameServer", "双倍奖励经验倍数").Trim());
				双倍奖励爆率倍数 = int.Parse(Config.IniReadValue("GameServer", "双倍奖励爆率倍数").Trim());
				双倍奖励武勋倍数 = int.Parse(Config.IniReadValue("GameServer", "双倍奖励武勋倍数").Trim());
				双倍奖励公告内容 = Config.IniReadValue("GameServer", "双倍奖励公告内容").Trim();
				str = "双倍奖励经验倍数";
				双倍奖励经验倍数 = ((Config.IniReadValue("GameServer", "双倍奖励经验倍数").Trim().Length == 0) ? 双倍奖励经验倍数 : double.Parse(Config.IniReadValue("GameServer", "双倍奖励经验倍数").Trim()));
				str = "移动间隔时间";
				VIP经验增加百分比 = ((Config.IniReadValue("GameServer", "VIP经验增加百分比").Trim().Length == 0) ? VIP经验增加百分比 : double.Parse(Config.IniReadValue("GameServer", "VIP经验增加百分比").Trim()));
				VIP历练增加百分比 = ((Config.IniReadValue("GameServer", "VIP历练增加百分比").Trim().Length == 0) ? VIP历练增加百分比 : double.Parse(Config.IniReadValue("GameServer", "VIP历练增加百分比").Trim()));
				VIP金钱增加百分比 = ((Config.IniReadValue("GameServer", "VIP金钱增加百分比").Trim().Length == 0) ? VIP金钱增加百分比 : double.Parse(Config.IniReadValue("GameServer", "VIP金钱增加百分比").Trim()));
				宝珠进化概率 = ((Config.IniReadValue("GameServer", "宝珠进化概率").Trim().Length == 0) ? 宝珠进化概率 : double.Parse(Config.IniReadValue("GameServer", "宝珠进化概率").Trim()));
				VIP合成率增加百分比 = ((Config.IniReadValue("GameServer", "VIP合成率增加百分比").Trim().Length == 0) ? VIP合成率增加百分比 : double.Parse(Config.IniReadValue("GameServer", "VIP合成率增加百分比").Trim()));
				水晶赋予属性一阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性一阶段") == "") ? 水晶赋予属性一阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性一阶段")));
				水晶赋予属性二阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性二阶段") == "") ? 水晶赋予属性二阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性二阶段")));
				中魂成功几率 = ((Config.IniReadValue("GameServer", "中魂成功几率").Length == 0) ? 中魂成功几率 : double.Parse(Config.IniReadValue("GameServer", "中魂成功几率")));
				四神成功几率 = ((Config.IniReadValue("GameServer", "四神成功几率").Length == 0) ? 四神成功几率 : double.Parse(Config.IniReadValue("GameServer", "四神成功几率")));
				水晶赋予属性三阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性三阶段") == "") ? 水晶赋予属性三阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性三阶段")));
				水晶赋予属性四阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性四阶段") == "") ? 水晶赋予属性四阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性四阶段")));
				水晶赋予属性五阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性五阶段") == "") ? 水晶赋予属性五阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性五阶段")));
				水晶赋予属性六阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性六阶段") == "") ? 水晶赋予属性六阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性六阶段")));
				水晶赋予属性七阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性七阶段") == "") ? 水晶赋予属性七阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性七阶段")));
				水晶赋予属性八阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性八阶段") == "") ? 水晶赋予属性八阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性八阶段")));
				水晶赋予属性九阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性九阶段") == "") ? 水晶赋予属性九阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性九阶段")));
				水晶赋予属性十阶段 = ((Config.IniReadValue("GameServer", "水晶赋予属性十阶段") == "") ? 水晶赋予属性十阶段 : double.Parse(Config.IniReadValue("GameServer", "水晶赋予属性十阶段")));
				移动间隔时间 = ((Config.IniReadValue("GameServer", "移动间隔时间").Trim().Length == 0) ? 移动间隔时间 : int.Parse(Config.IniReadValue("GameServer", "移动间隔时间").Trim()));
				开启门战系统 = ((Config.IniReadValue("GameServer", "开启门战系统").Trim().Length == 0) ? 开启门战系统 : int.Parse(Config.IniReadValue("GameServer", "开启门战系统").Trim()));
				门战系统开启时 = ((Config.IniReadValue("GameServer", "门战系统开启时").Trim().Length == 0) ? 门战系统开启时 : int.Parse(Config.IniReadValue("GameServer", "门战系统开启时").Trim()));
				门战系统开启分 = ((Config.IniReadValue("GameServer", "门战系统开启分").Trim().Length == 0) ? 门战系统开启分 : int.Parse(Config.IniReadValue("GameServer", "门战系统开启分").Trim()));
				门战系统开启秒 = ((Config.IniReadValue("GameServer", "门战系统开启秒").Trim().Length == 0) ? 门战系统开启秒 : int.Parse(Config.IniReadValue("GameServer", "门战系统开启秒").Trim()));
				申请门战需要元宝 = ((Config.IniReadValue("GameServer", "申请门战需要元宝").Trim().Length == 0) ? 申请门战需要元宝 : int.Parse(Config.IniReadValue("GameServer", "申请门战需要元宝").Trim()));
				双倍经验等级上限 = ((Config.IniReadValue("GameServer", "双倍经验等级上限").Trim().Length == 0) ? 双倍经验等级上限 : int.Parse(Config.IniReadValue("GameServer", "双倍经验等级上限").Trim()));
				双倍金钱等级上限 = ((Config.IniReadValue("GameServer", "双倍金钱等级上限").Trim().Length == 0) ? 双倍金钱等级上限 : int.Parse(Config.IniReadValue("GameServer", "双倍金钱等级上限").Trim()));
				双倍历练等级上限 = ((Config.IniReadValue("GameServer", "双倍历练等级上限").Trim().Length == 0) ? 双倍历练等级上限 : int.Parse(Config.IniReadValue("GameServer", "双倍历练等级上限").Trim()));
				双倍暴率等级上限 = ((Config.IniReadValue("GameServer", "双倍暴率等级上限").Trim().Length == 0) ? 双倍暴率等级上限 : int.Parse(Config.IniReadValue("GameServer", "双倍暴率等级上限").Trim()));
				双倍等级上限倍数 = ((Config.IniReadValue("GameServer", "双倍等级上限倍数").Trim().Length == 0) ? 双倍等级上限倍数 : double.Parse(Config.IniReadValue("GameServer", "双倍等级上限倍数").Trim()));
				英雄职业转职需要武器 = ((Config.IniReadValue("GameServer", "英雄职业转职需要武器").Trim().Length == 0) ? 英雄职业转职需要武器 : int.Parse(Config.IniReadValue("GameServer", "英雄职业转职需要武器").Trim()));
				限制最高级别 = ((Config.IniReadValue("GameServer", "限制最高级别").Trim().Length == 0) ? 限制最高级别 : int.Parse(Config.IniReadValue("GameServer", "限制最高级别").Trim()));
				str = "天关经验提高百分比基数";
				天关经验提高百分比基数 = ((Config.IniReadValue("GameServer", "天关经验提高百分比基数").Trim().Length == 0) ? 天关经验提高百分比基数 : double.Parse(Config.IniReadValue("GameServer", "天关经验提高百分比基数").Trim()));
				str = "天关物品爆率提高基数";
				天关物品爆率提高基数 = ((Config.IniReadValue("GameServer", "天关物品爆率提高基数").Trim().Length == 0) ? 天关物品爆率提高基数 : int.Parse(Config.IniReadValue("GameServer", "天关物品爆率提高基数").Trim()));
				str = "天关经验提高百分比递增";
				天关经验提高百分比递增 = ((Config.IniReadValue("GameServer", "天关经验提高百分比递增").Trim().Length == 0) ? 天关经验提高百分比递增 : double.Parse(Config.IniReadValue("GameServer", "天关经验提高百分比递增").Trim()));
				str = "天关物品爆率提高递增";
				天关物品爆率提高递增 = ((Config.IniReadValue("GameServer", "天关物品爆率提高递增").Trim().Length == 0) ? 天关物品爆率提高递增 : int.Parse(Config.IniReadValue("GameServer", "天关物品爆率提高递增").Trim()));
				str = "装备提真消耗";
				装备提真消耗 = ((Config.IniReadValue("GameServer", "装备提真消耗").Trim().Length == 0) ? 装备提真消耗 : int.Parse(Config.IniReadValue("GameServer", "装备提真消耗").Trim()));
				str = "装备提真数量";
				装备提真数量 = ((Config.IniReadValue("GameServer", "装备提真数量").Trim().Length == 0) ? 装备提真数量 : int.Parse(Config.IniReadValue("GameServer", "装备提真数量").Trim()));
				str = "修炼之地是否开启";
				修炼之地是否开启 = ((Config.IniReadValue("GameServer", "修炼之地是否开启").Trim().Length == 0) ? 修炼之地是否开启 : int.Parse(Config.IniReadValue("GameServer", "修炼之地是否开启").Trim()));
				是否开启锁人攻击检测 = ((Config.IniReadValue("GameServer", "是否开启锁人攻击检测").Trim().Length == 0) ? 是否开启锁人攻击检测 : int.Parse(Config.IniReadValue("GameServer", "是否开启锁人攻击检测").Trim()));
				锁人攻击次数上限 = ((Config.IniReadValue("GameServer", "锁人攻击次数上限").Trim().Length == 0) ? 锁人攻击次数上限 : int.Parse(Config.IniReadValue("GameServer", "锁人攻击次数上限").Trim()));
				锁人攻击检测操作 = ((Config.IniReadValue("GameServer", "锁人攻击检测操作").Trim().Length == 0) ? 锁人攻击检测操作 : int.Parse(Config.IniReadValue("GameServer", "锁人攻击检测操作").Trim()));
				随机BOSS出现时间表 = Config.IniReadValue("GameServer", "随机BOSS出现时间表").Trim();
				是否开启元宝商店 = ((Config.IniReadValue("GameServer", "是否开启元宝商店").Trim().Length == 0) ? 是否开启元宝商店 : int.Parse(Config.IniReadValue("GameServer", "是否开启元宝商店").Trim()));
				门派第一称号奖励 = Config.IniReadValue("GameServer", "门派第一称号奖励").Trim().Split(';');
				门派第二称号奖励 = Config.IniReadValue("GameServer", "门派第二称号奖励").Trim().Split(';');
				门派第三称号奖励 = Config.IniReadValue("GameServer", "门派第三称号奖励").Trim().Split(';');
				是否开启跨线活动 = ((Config.IniReadValue("GameServer", "是否开启跨线活动").Trim().Length == 0) ? 是否开启跨线活动 : int.Parse(Config.IniReadValue("GameServer", "是否开启跨线活动").Trim()));
				当前是否是银币线路 = ((Config.IniReadValue("GameServer", "当前是否是银币线路").Trim().Length == 0) ? 当前是否是银币线路 : int.Parse(Config.IniReadValue("GameServer", "当前是否是银币线路").Trim()));
				是否开启共用银币市场 = ((Config.IniReadValue("GameServer", "是否开启共用银币市场").Trim().Length == 0) ? 是否开启共用银币市场 : int.Parse(Config.IniReadValue("GameServer", "是否开启共用银币市场").Trim()));
				打开换线线路1 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路1").Trim());
				打开换线线路2 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路2").Trim());
				打开换线线路3 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路3").Trim());
				打开换线线路4 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路4").Trim());
				打开换线线路5 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路5").Trim());
				打开换线线路6 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路6").Trim());
				打开换线线路7 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路7").Trim());
				打开换线线路8 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路8").Trim());
				打开换线线路9 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路9").Trim());
				打开换线线路10 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路10").Trim());
				打开换线线路11 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路11").Trim());
				打开换线线路12 = int.Parse(Config.IniReadValue("GameServer", "打开换线线路12").Trim());
				贡献元宝命令 = Config.IniReadValue("GameServer", "贡献元宝命令").Trim();
				贡献物品命令 = Config.IniReadValue("GameServer", "贡献物品命令").Trim();
				贡献元宝数 = int.Parse(Config.IniReadValue("GameServer", "贡献元宝数").Trim());
				贡献元宝荣誉点 = int.Parse(Config.IniReadValue("GameServer", "贡献元宝荣誉点").Trim());
				特效道具ID = int.Parse(Config.IniReadValue("GameServer", "特效道具ID").Trim());
				玫瑰第一名奖励 = Config.IniReadValue("GameServer", "玫瑰第一名奖励").Trim().Split(';');
				玫瑰第二名奖励 = Config.IniReadValue("GameServer", "玫瑰第二名奖励").Trim().Split(';');
				玫瑰第三名奖励 = Config.IniReadValue("GameServer", "玫瑰第三名奖励").Trim().Split(';');
				玫瑰第四名奖励 = Config.IniReadValue("GameServer", "玫瑰第四名奖励").Trim().Split(';');
				玫瑰第五名奖励 = Config.IniReadValue("GameServer", "玫瑰第五名奖励").Trim().Split(';');
				花榜第一名奖励 = Config.IniReadValue("GameServer", "花榜第一名奖励").Trim().Split(';');
				花榜第二名奖励 = Config.IniReadValue("GameServer", "花榜第二名奖励").Trim().Split(';');
				花榜第三名奖励 = Config.IniReadValue("GameServer", "花榜第三名奖励").Trim().Split(';');
				花榜第四名奖励 = Config.IniReadValue("GameServer", "花榜第四名奖励").Trim().Split(';');
				花榜第五名奖励 = Config.IniReadValue("GameServer", "花榜第五名奖励").Trim().Split(';');
				前十第一名奖励 = Config.IniReadValue("GameServer", "前十第一名奖励").Trim().Split(';');
				前十第二名奖励 = Config.IniReadValue("GameServer", "前十第二名奖励").Trim().Split(';');
				前十第三名奖励 = Config.IniReadValue("GameServer", "前十第三名奖励").Trim().Split(';');
				前十第四名奖励 = Config.IniReadValue("GameServer", "前十第四名奖励").Trim().Split(';');
				前十第五名奖励 = Config.IniReadValue("GameServer", "前十第五名奖励").Trim().Split(';');
				前十第六名奖励 = Config.IniReadValue("GameServer", "前十第六名奖励").Trim().Split(';');
				前十第七名奖励 = Config.IniReadValue("GameServer", "前十第七名奖励").Trim().Split(';');
				前十第八名奖励 = Config.IniReadValue("GameServer", "前十第八名奖励").Trim().Split(';');
				前十第九名奖励 = Config.IniReadValue("GameServer", "前十第九名奖励").Trim().Split(';');
				前十第十名奖励 = Config.IniReadValue("GameServer", "前十第十名奖励").Trim().Split(';');
				花榜前十第一名奖励 = Config.IniReadValue("GameServer", "花榜前十第一名奖励").Trim().Split(';');
				花榜前十第二名奖励 = Config.IniReadValue("GameServer", "花榜前十第二名奖励").Trim().Split(';');
				花榜前十第三名奖励 = Config.IniReadValue("GameServer", "花榜前十第三名奖励").Trim().Split(';');
				花榜前十第四名奖励 = Config.IniReadValue("GameServer", "花榜前十第四名奖励").Trim().Split(';');
				花榜前十第五名奖励 = Config.IniReadValue("GameServer", "花榜前十第五名奖励").Trim().Split(';');
				花榜前十第六名奖励 = Config.IniReadValue("GameServer", "花榜前十第六名奖励").Trim().Split(';');
				花榜前十第七名奖励 = Config.IniReadValue("GameServer", "花榜前十第七名奖励").Trim().Split(';');
				花榜前十第八名奖励 = Config.IniReadValue("GameServer", "花榜前十第八名奖励").Trim().Split(';');
				花榜前十第九名奖励 = Config.IniReadValue("GameServer", "花榜前十第九名奖励").Trim().Split(';');
				花榜前十第十名奖励 = Config.IniReadValue("GameServer", "花榜前十第十名奖励").Trim().Split(';');
				排位榜第一名奖励 = Config.IniReadValue("GameServer", "排位榜第一名奖励").Trim().Split(';');
				排位榜第二名奖励 = Config.IniReadValue("GameServer", "排位榜第二名奖励").Trim().Split(';');
				排位榜第三名奖励 = Config.IniReadValue("GameServer", "排位榜第三名奖励").Trim().Split(';');
				排位榜第四名奖励 = Config.IniReadValue("GameServer", "排位榜第四名奖励").Trim().Split(';');
				排位榜第五名奖励 = Config.IniReadValue("GameServer", "排位榜第五名奖励").Trim().Split(';');
				排位榜第六名奖励 = Config.IniReadValue("GameServer", "排位榜第六名奖励").Trim().Split(';');
				排位榜第七名奖励 = Config.IniReadValue("GameServer", "排位榜第七名奖励").Trim().Split(';');
				排位榜第八名奖励 = Config.IniReadValue("GameServer", "排位榜第八名奖励").Trim().Split(';');
				排位榜第九名奖励 = Config.IniReadValue("GameServer", "排位榜第九名奖励").Trim().Split(';');
				排位榜第十名奖励 = Config.IniReadValue("GameServer", "排位榜第十名奖励").Trim().Split(';');
				地图限制等级 = Config.IniReadValue("GameServer", "地图限制等级").Trim().Split(';');
				强化数量大于发送快报 = Config.IniReadValue("GameServer", "强化数量大于发送快报").Trim().Split(';');
				门战准备时间 = int.Parse(Config.IniReadValue("GameServer", "门战准备时间").Trim());
				门战总时间 = int.Parse(Config.IniReadValue("GameServer", "门战总时间").Trim());
				武林血战是否开启 = int.Parse(Config.IniReadValue("GameServer", "武林血战是否开启").Trim());
				武林血战开启小时 = int.Parse(Config.IniReadValue("GameServer", "武林血战开启小时").Trim());
				武林血战开启分 = int.Parse(Config.IniReadValue("GameServer", "武林血战开启分").Trim());
				武林血战开启秒 = int.Parse(Config.IniReadValue("GameServer", "武林血战开启秒").Trim());
				武林血战参加奖励 = Config.IniReadValue("GameServer", "武林血战参加奖励").Trim();
				武林血战第一回合奖励 = Config.IniReadValue("GameServer", "武林血战第一回合奖励").Trim();
				武林血战第二回合奖励 = Config.IniReadValue("GameServer", "武林血战第二回合奖励").Trim();
				武林血战第三回合奖励 = Config.IniReadValue("GameServer", "武林血战第三回合奖励").Trim();
				武林血战参战等级 = ((Config.IniReadValue("GameServer", "武林血战参战等级").Trim() == "") ? 武林血战参战等级 : int.Parse(Config.IniReadValue("GameServer", "武林血战参战等级").Trim()));
				ZoneNumber = Config.IniReadValue("GameServer", "分区编号").Trim();
				AtPort = ((Config.IniReadValue("GameServer", "AtPort").Trim() == "") ? AtPort : int.Parse(Config.IniReadValue("GameServer", "AtPort").Trim()));
				最大速度超出次数操作 = ((Config.IniReadValue("GameServer", "最大速度超出次数操作").Trim().Length == 0) ? 最大速度超出次数操作 : int.Parse(Config.IniReadValue("GameServer", "最大速度超出次数操作").Trim()));
				三十秒内允许超出次数 = ((Config.IniReadValue("GameServer", "三十秒内允许超出次数").Trim().Length == 0) ? 三十秒内允许超出次数 : int.Parse(Config.IniReadValue("GameServer", "三十秒内允许超出次数").Trim()));
				周末武勋量 = ((Config.IniReadValue("GameServer", "周末武勋量").Trim().Length == 0) ? 周末武勋量 : int.Parse(Config.IniReadValue("GameServer", "周末武勋量").Trim()));
				二转每日武勋上限 = ((Config.IniReadValue("GameServer", "二转每日武勋上限").Trim().Length == 0) ? 二转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "二转每日武勋上限").Trim()));
				三转每日武勋上限 = ((Config.IniReadValue("GameServer", "三转每日武勋上限").Trim().Length == 0) ? 三转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "三转每日武勋上限").Trim()));
				四转每日武勋上限 = ((Config.IniReadValue("GameServer", "四转每日武勋上限").Trim().Length == 0) ? 四转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "四转每日武勋上限").Trim()));
				五转每日武勋上限 = ((Config.IniReadValue("GameServer", "五转每日武勋上限").Trim().Length == 0) ? 五转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "五转每日武勋上限").Trim()));
				六转每日武勋上限 = ((Config.IniReadValue("GameServer", "六转每日武勋上限").Trim().Length == 0) ? 六转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "六转每日武勋上限").Trim()));
				七转每日武勋上限 = ((Config.IniReadValue("GameServer", "七转每日武勋上限").Trim().Length == 0) ? 七转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "七转每日武勋上限").Trim()));
				八转每日武勋上限 = ((Config.IniReadValue("GameServer", "八转每日武勋上限").Trim().Length == 0) ? 八转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "八转每日武勋上限").Trim()));
				九转每日武勋上限 = ((Config.IniReadValue("GameServer", "九转每日武勋上限").Trim().Length == 0) ? 九转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "九转每日武勋上限").Trim()));
				十转每日武勋上限 = ((Config.IniReadValue("GameServer", "十转每日武勋上限").Trim().Length == 0) ? 十转每日武勋上限 : int.Parse(Config.IniReadValue("GameServer", "十转每日武勋上限").Trim()));
				三十五级以下经验倍数 = ((Config.IniReadValue("GameServer", "三十五级以下经验倍数").Trim() == "") ? 三十五级以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "三十五级以下经验倍数").Trim()));
				六十级以下经验倍数 = ((Config.IniReadValue("GameServer", "六十级以下经验倍数").Trim() == "") ? 六十级以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "六十级以下经验倍数").Trim()));
				八十级以下经验倍数 = ((Config.IniReadValue("GameServer", "八十级以下经验倍数").Trim() == "") ? 八十级以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "八十级以下经验倍数").Trim()));
				百级以下经验倍数 = ((Config.IniReadValue("GameServer", "百级以下经验倍数").Trim() == "") ? 百级以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "百级以下经验倍数").Trim()));
				升天一以下经验倍数 = ((Config.IniReadValue("GameServer", "升天一以下经验倍数").Trim() == "") ? 升天一以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "升天一以下经验倍数").Trim()));
				升天二以下经验倍数 = ((Config.IniReadValue("GameServer", "升天二以下经验倍数").Trim() == "") ? 升天二以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "升天二以下经验倍数").Trim()));
				升天三以下经验倍数 = ((Config.IniReadValue("GameServer", "升天三以下经验倍数").Trim() == "") ? 升天三以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "升天三以下经验倍数").Trim()));
				升天四以下经验倍数 = ((Config.IniReadValue("GameServer", "升天四以下经验倍数").Trim() == "") ? 升天四以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "升天四以下经验倍数").Trim()));
				升天五以下经验倍数 = ((Config.IniReadValue("GameServer", "升天五以下经验倍数").Trim() == "") ? 升天五以下经验倍数 : double.Parse(Config.IniReadValue("GameServer", "升天五以下经验倍数").Trim()));
				允许挂机 = ((Config.IniReadValue("GameServer", "允许挂机").Trim().Length == 0) ? 允许挂机 : int.Parse(Config.IniReadValue("GameServer", "允许挂机").Trim()));
				报错踢号次数 = ((Config.IniReadValue("GameServer", "报错踢号次数").Trim().Length == 0) ? 报错踢号次数 : int.Parse(Config.IniReadValue("GameServer", "报错踢号次数").Trim()));
				是否开启任务领取 = ((Config.IniReadValue("GameServer", "是否开启任务领取").Trim() == "") ? 是否开启任务领取 : int.Parse(Config.IniReadValue("GameServer", "是否开启任务领取").Trim()));
				补偿的任务物品ID = ((Config.IniReadValue("GameServer", "补偿的任务物品ID").Trim() == "") ? 补偿的任务物品ID : int.Parse(Config.IniReadValue("GameServer", "补偿的任务物品ID").Trim()));
				是否开启上线BUFF = ((Config.IniReadValue("GameServer", "是否开启上线BUFF").Trim() == "") ? 是否开启上线BUFF : int.Parse(Config.IniReadValue("GameServer", "是否开启上线BUFF").Trim()));
				移动速度 = Config.IniReadValue("GameServer", "最大移动速度").Trim().Split(';');
				充值排行比例 = Config.IniReadValue("GameServer", "充值排行比例").Trim().Split(';');
				转换职业功能是否开启 = int.Parse(Config.IniReadValue("GameServer", "转换职业功能是否开启").Trim());
				转换职业所需物品类型 = int.Parse(Config.IniReadValue("GameServer", "转换职业所需物品类型").Trim());
				转换职业需要元宝数量 = int.Parse(Config.IniReadValue("GameServer", "转换职业需要元宝数量").Trim());
				转换职业需要物品PID = int.Parse(Config.IniReadValue("GameServer", "转换职业需要物品PID").Trim());
				转换职业需要人物等级 = int.Parse(Config.IniReadValue("GameServer", "转换职业需要人物等级").Trim());
				外挂检测操作 = ((Config.IniReadValue("GameServer", "外挂检测操作").Trim().Length == 0) ? 外挂检测操作 : int.Parse(Config.IniReadValue("GameServer", "外挂检测操作").Trim()));
				是否允许快速攻击 = ((Config.IniReadValue("GameServer", "是否允许快速攻击").Trim().Length == 0) ? 是否允许快速攻击 : int.Parse(Config.IniReadValue("GameServer", "是否允许快速攻击").Trim()));
				是否开启四神系统 = ((Config.IniReadValue("GameServer", "是否开启四神系统").Trim().Length == 0) ? 是否开启四神系统 : int.Parse(Config.IniReadValue("GameServer", "是否开启四神系统").Trim()));
				BOSS掉落物品数量下限 = ((Config.IniReadValue("GameServer", "BOSS掉落物品数量下限").Trim().Length == 0) ? BOSS掉落物品数量下限 : int.Parse(Config.IniReadValue("GameServer", "BOSS掉落物品数量下限").Trim()));
				BOSS掉落物品数量上限 = ((Config.IniReadValue("GameServer", "BOSS掉落物品数量上限").Trim().Length == 0) ? BOSS掉落物品数量上限 : int.Parse(Config.IniReadValue("GameServer", "BOSS掉落物品数量上限").Trim()));
				世界BOSS掉落元宝概率 = ((Config.IniReadValue("GameServer", "世界BOSS掉落元宝概率").Trim().Length == 0) ? 世界BOSS掉落元宝概率 : int.Parse(Config.IniReadValue("GameServer", "世界BOSS掉落元宝概率").Trim()));
				世界BOSS掉落元宝最小 = ((Config.IniReadValue("GameServer", "世界BOSS掉落元宝最小").Trim().Length == 0) ? 世界BOSS掉落元宝最小 : int.Parse(Config.IniReadValue("GameServer", "世界BOSS掉落元宝最小").Trim()));
				世界BOSS掉落元宝最大 = ((Config.IniReadValue("GameServer", "世界BOSS掉落元宝最大").Trim().Length == 0) ? 世界BOSS掉落元宝最大 : int.Parse(Config.IniReadValue("GameServer", "世界BOSS掉落元宝最大").Trim()));
				世界BOSS掉落金钱概率 = ((Config.IniReadValue("GameServer", "世界BOSS掉落金钱概率").Trim().Length == 0) ? 世界BOSS掉落金钱概率 : int.Parse(Config.IniReadValue("GameServer", "世界BOSS掉落金钱概率").Trim()));
				世界BOSS掉落金钱最小 = ((Config.IniReadValue("GameServer", "世界BOSS掉落金钱最小").Trim().Length == 0) ? 世界BOSS掉落金钱最小 : int.Parse(Config.IniReadValue("GameServer", "世界BOSS掉落金钱最小").Trim()));
				世界BOSS掉落金钱最大 = ((Config.IniReadValue("GameServer", "世界BOSS掉落金钱最大").Trim().Length == 0) ? 世界BOSS掉落金钱最大 : int.Parse(Config.IniReadValue("GameServer", "世界BOSS掉落金钱最大").Trim()));
				是否支持扩展物品属性位数 = ((Config.IniReadValue("GameServer", "是否支持扩展物品属性位数").Trim().Length == 0) ? 是否支持扩展物品属性位数 : int.Parse(Config.IniReadValue("GameServer", "是否支持扩展物品属性位数").Trim()));
				武器PK掉耐久度 = ((Config.IniReadValue("GameServer", "武器PK掉耐久度").Trim().Length == 0) ? 武器PK掉耐久度 : int.Parse(Config.IniReadValue("GameServer", "武器PK掉耐久度").Trim()));
				防具PK掉耐久度 = ((Config.IniReadValue("GameServer", "防具PK掉耐久度").Trim().Length == 0) ? 防具PK掉耐久度 : int.Parse(Config.IniReadValue("GameServer", "防具PK掉耐久度").Trim()));
				安全挂机时间 = ((Config.IniReadValue("GameServer", "安全挂机时间").Trim().Length == 0) ? 安全挂机时间 : int.Parse(Config.IniReadValue("GameServer", "安全挂机时间").Trim()));
				灵宠进化率 = ((Config.IniReadValue("GameServer", "灵宠进化率").Trim().Length == 0) ? 灵宠进化率 : double.Parse(Config.IniReadValue("GameServer", "灵宠进化率").Trim()));
				灵宠强化率 = ((Config.IniReadValue("GameServer", "灵宠强化率").Trim().Length == 0) ? 灵宠强化率 : double.Parse(Config.IniReadValue("GameServer", "灵宠强化率").Trim()));
				灵宠进化率 = ((Config.IniReadValue("GameServer", "灵宠进化率").Trim().Length == 0) ? 灵宠进化率 : double.Parse(Config.IniReadValue("GameServer", "灵宠进化率").Trim()));
				道具强化概率 = ((Config.IniReadValue("GameServer", "道具强化概率").Trim().Length == 0) ? 道具强化概率 : double.Parse(Config.IniReadValue("GameServer", "道具强化概率").Trim()));
				购买武勋装备消耗武勋 = ((Config.IniReadValue("GameServer", "购买武勋装备消耗武勋").Trim().Length == 0) ? 购买武勋装备消耗武勋 : int.Parse(Config.IniReadValue("GameServer", "购买武勋装备消耗武勋").Trim()));
				刀PK伤害参数 = ((Config.IniReadValue("GameServer", "刀PK伤害参数").Trim().Length == 0) ? 刀PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "刀PK伤害参数").Trim()));
				剑PK伤害参数 = ((Config.IniReadValue("GameServer", "剑PK伤害参数").Trim().Length == 0) ? 剑PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "剑PK伤害参数").Trim()));
				枪PK伤害参数 = ((Config.IniReadValue("GameServer", "枪PK伤害参数").Trim().Length == 0) ? 枪PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "枪PK伤害参数").Trim()));
				弓PK伤害参数 = ((Config.IniReadValue("GameServer", "弓PK伤害参数").Trim().Length == 0) ? 弓PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "弓PK伤害参数").Trim()));
				医PK伤害参数 = ((Config.IniReadValue("GameServer", "医PK伤害参数").Trim().Length == 0) ? 医PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "医PK伤害参数").Trim()));
				刺PK伤害参数 = ((Config.IniReadValue("GameServer", "刺PK伤害参数").Trim().Length == 0) ? 刺PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "刺PK伤害参数").Trim()));
				乐PK伤害参数 = ((Config.IniReadValue("GameServer", "乐PK伤害参数").Trim().Length == 0) ? 乐PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "乐PK伤害参数").Trim()));
				韩PK伤害参数 = ((Config.IniReadValue("GameServer", "韩PK伤害参数").Trim().Length == 0) ? 韩PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "韩PK伤害参数").Trim()));
				谭PK伤害参数 = ((Config.IniReadValue("GameServer", "谭PK伤害参数").Trim().Length == 0) ? 谭PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "谭PK伤害参数").Trim()));
				拳PK伤害参数 = ((Config.IniReadValue("GameServer", "拳PK伤害参数").Trim().Length == 0) ? 拳PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "拳PK伤害参数").Trim()));
				梅PK伤害参数 = ((Config.IniReadValue("GameServer", "梅PK伤害参数").Trim().Length == 0) ? 梅PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "梅PK伤害参数").Trim()));
				卢PK伤害参数 = ((Config.IniReadValue("GameServer", "卢PK伤害参数").Trim().Length == 0) ? 卢PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "卢PK伤害参数").Trim()));
				神女PK伤害参数 = ((Config.IniReadValue("GameServer", "神女PK伤害参数").Trim().Length == 0) ? 神女PK伤害参数 : double.Parse(Config.IniReadValue("GameServer", "神女PK伤害参数").Trim()));
				双倍扣武勋公告内容 = Config.IniReadValue("GameServer", "双倍扣武勋公告内容").Trim();
				比武场经验基数 = ((Config.IniReadValue("GameServer", "比武场经验基数").Trim().Length == 0) ? 比武场经验基数 : double.Parse(Config.IniReadValue("GameServer", "比武场经验基数").Trim()));
				比武泡点是否开启 = int.Parse(Config.IniReadValue("GameServer", "比武泡点是否开启").Trim());
				比武泡点开启小时 = int.Parse(Config.IniReadValue("GameServer", "比武泡点开启小时").Trim());
				比武泡点开启分 = int.Parse(Config.IniReadValue("GameServer", "比武泡点开启分").Trim());
				比武泡点开启秒 = int.Parse(Config.IniReadValue("GameServer", "比武泡点开启秒").Trim());
				比武泡点倒计时 = int.Parse(Config.IniReadValue("GameServer", "比武泡点倒计时").Trim());
				比武泡点总时间 = int.Parse(Config.IniReadValue("GameServer", "比武泡点总时间").Trim());
				比武泡点元宝时间 = int.Parse(Config.IniReadValue("GameServer", "比武泡点元宝时间").Trim());
				比武泡点开启时间星期 = Config.IniReadValue("GameServer", "比武泡点开启时间星期").Trim();
				比武泡点元宝基数 = int.Parse(Config.IniReadValue("GameServer", "比武泡点元宝基数").Trim());
				比武泡点金钱基数 = int.Parse(Config.IniReadValue("GameServer", "比武泡点金钱基数").Trim());
				比武泡点武勋基数 = int.Parse(Config.IniReadValue("GameServer", "比武泡点武勋基数").Trim());
				双倍扣武勋结束时间 = int.Parse(Config.IniReadValue("GameServer", "双倍扣武勋结束时间").Trim());
				双倍扣武勋元宝数量 = int.Parse(Config.IniReadValue("GameServer", "双倍扣武勋元宝数量").Trim());
				双倍扣武勋倍数 = int.Parse(Config.IniReadValue("GameServer", "双倍扣武勋倍数").Trim());
				打怪说话时间 = int.Parse(Config.IniReadValue("GameServer", "打怪说话时间").Trim());
				内挂打怪说话时间 = int.Parse(Config.IniReadValue("GameServer", "内挂打怪说话时间").Trim());
				自动存取时间 = int.Parse(Config.IniReadValue("GameServer", "自动存取时间").Trim());
				离线挂机提示内容 = Config.IniReadValue("GameServer", "离线挂机提示内容").Trim();
				在线挂机提示内容 = Config.IniReadValue("GameServer", "在线挂机提示内容").Trim();
				离线挂机打怪命令 = Config.IniReadValue("GameServer", "离线挂机打怪命令").Trim();
				离线挂机打架命令 = Config.IniReadValue("GameServer", "离线挂机打架命令").Trim();
				离线挂机打怪范围 = int.Parse(Config.IniReadValue("GameServer", "离线挂机打怪范围").Trim());
				自动拾取开关 = int.Parse(Config.IniReadValue("GameServer", "自动拾取开关").Trim());
				讨伐副本时长 = int.Parse(Config.IniReadValue("GameServer", "讨伐副本时长").Trim());
				讨伐副本最少人数 = int.Parse(Config.IniReadValue("GameServer", "讨伐副本最少人数").Trim());
				讨伐副本最多人数 = int.Parse(Config.IniReadValue("GameServer", "讨伐副本最多人数").Trim());
				物品锁定 = Config.IniReadValue("GameServer", "物品锁定").Trim();
				是否开启同势力门派 = ((Config.IniReadValue("GameServer", "是否开启同势力门派").Trim() == "") ? 是否开启同势力门派 : int.Parse(Config.IniReadValue("GameServer", "是否开启同势力门派").Trim()));
				寄售系统是否开启 = ((Config.IniReadValue("GameServer", "寄售系统是否开启").Trim() == "") ? 寄售系统是否开启 : int.Parse(Config.IniReadValue("GameServer", "寄售系统是否开启").Trim()));
				寄售获得钻石比例 = ((Config.IniReadValue("GameServer", "寄售获得钻石比例").Trim() == "") ? 寄售获得钻石比例 : double.Parse(Config.IniReadValue("GameServer", "寄售获得钻石比例").Trim()));
				经验条长度 = ((Config.IniReadValue("GameServer", "经验条长度").Trim() == "") ? 经验条长度 : double.Parse(Config.IniReadValue("GameServer", "经验条长度").Trim()));
				是否可以寄售绑定装备 = ((Config.IniReadValue("GameServer", "是否可以寄售绑定装备").Trim() == "") ? 是否可以寄售绑定装备 : int.Parse(Config.IniReadValue("GameServer", "是否可以寄售绑定装备").Trim()));
				群体辅助组队范围 = int.Parse(Config.IniReadValue("GameServer", "群体辅助组队范围").Trim());
				群医加经验开关 = int.Parse(Config.IniReadValue("GameServer", "群医加经验开关").Trim());
				群医加爆率 = int.Parse(Config.IniReadValue("GameServer", "群医加爆率").Trim());
				医生群疗经验加成 = ((Config.IniReadValue("GameServer", "医生群疗经验加成").Trim().Length == 0) ? 医生群疗经验加成 : double.Parse(Config.IniReadValue("GameServer", "医生群疗经验加成").Trim()));
				VIP爆率增加 = int.Parse(Config.IniReadValue("GameServer", "VIP爆率增加").Trim());
				开启卡技能 = int.Parse(Config.IniReadValue("GameServer", "开启卡技能").Trim());
				卡技能次数 = int.Parse(Config.IniReadValue("GameServer", "卡技能次数").Trim());
				坐牢系统是否开启 = int.Parse(Config.IniReadValue("GameServer", "坐牢系统是否开启").Trim());
				坐牢回城坐标 = Config.IniReadValue("GameServer", "坐牢回城坐标").Trim();
				监狱地图 = Config.IniReadValue("GameServer", "监狱地图").Trim();
				坐牢善恶 = int.Parse(Config.IniReadValue("GameServer", "坐牢善恶").Trim());
				坐牢善恶恢复间隔 = int.Parse(Config.IniReadValue("GameServer", "坐牢善恶恢复间隔").Trim());
				坐牢恢复善恶值 = int.Parse(Config.IniReadValue("GameServer", "坐牢恢复善恶值").Trim());
				刑满释放公告 = ((Config.IniReadValue("GameServer", "刑满释放公告").Trim() == "") ? 刑满释放公告 : Config.IniReadValue("GameServer", "刑满释放公告").Trim());
				坐牢杀人公告 = ((Config.IniReadValue("GameServer", "坐牢杀人公告").Trim() == "") ? 坐牢杀人公告 : Config.IniReadValue("GameServer", "坐牢杀人公告").Trim());
				是否开启等级奖励 = int.Parse(Config.IniReadValue("GameServer", "是否开启等级奖励").Trim());
				开启攻城战系统 = ((Config.IniReadValue("GameServer", "开启攻城战系统").Trim().Length == 0) ? 开启攻城战系统 : int.Parse(Config.IniReadValue("GameServer", "开启攻城战系统").Trim()));
				攻城战时长 = int.Parse(Config.IniReadValue("GameServer", "攻城战时长").Trim());
				攻城战预备时间 = int.Parse(Config.IniReadValue("GameServer", "攻城战预备时间").Trim());
				攻城战开启小时 = int.Parse(Config.IniReadValue("GameServer", "攻城战开启小时").Trim());
				攻城战开启分 = int.Parse(Config.IniReadValue("GameServer", "攻城战开启分").Trim());
				攻城战开启秒 = int.Parse(Config.IniReadValue("GameServer", "攻城战开启秒").Trim());
				斗神称号激活方式 = int.Parse(Config.IniReadValue("GameServer", "斗神称号激活方式").Trim());
				斗神称号需要数量 = int.Parse(Config.IniReadValue("GameServer", "斗神称号需要数量").Trim());
				吸怪数量 = ((Config.IniReadValue("GameServer", "吸怪数量").Trim().Length == 0) ? 吸怪数量 : int.Parse(Config.IniReadValue("GameServer", "吸怪数量").Trim()));
				吸怪距离 = ((Config.IniReadValue("GameServer", "吸怪距离").Trim().Length == 0) ? 吸怪距离 : int.Parse(Config.IniReadValue("GameServer", "吸怪距离").Trim()));
				移动坐标异常后反弹 = int.Parse(Config.IniReadValue("GameServer", "移动坐标异常后反弹").Trim());
				开启实时坐标检测 = int.Parse(Config.IniReadValue("GameServer", "开启实时坐标检测").Trim());
				是否开启实时坐标显示 = int.Parse(Config.IniReadValue("GameServer", "是否开启实时坐标显示").Trim());
				实时检测距离 = int.Parse(Config.IniReadValue("GameServer", "实时检测距离").Trim());
				轻功三 = ((Config.IniReadValue("GameServer", "轻功三") == "") ? 轻功三 : float.Parse(Config.IniReadValue("GameServer", "轻功三")));
				实时移动时间 = ((Config.IniReadValue("GameServer", "实时移动时间") == "") ? 实时移动时间 : int.Parse(Config.IniReadValue("GameServer", "实时移动时间")));
				普通走 = ((Config.IniReadValue("GameServer", "普通走") == "") ? 普通走 : float.Parse(Config.IniReadValue("GameServer", "普通走")));
				轻功一 = ((Config.IniReadValue("GameServer", "轻功一") == "") ? 轻功一 : float.Parse(Config.IniReadValue("GameServer", "轻功一")));
				轻功二 = ((Config.IniReadValue("GameServer", "轻功二") == "") ? 轻功二 : float.Parse(Config.IniReadValue("GameServer", "轻功二")));
				宠物普通走 = ((Config.IniReadValue("GameServer", "宠物普通走") == "") ? 宠物普通走 : float.Parse(Config.IniReadValue("GameServer", "宠物普通走")));
				韩轻功一 = ((Config.IniReadValue("GameServer", "韩轻功一") == "") ? 韩轻功一 : float.Parse(Config.IniReadValue("GameServer", "韩轻功一")));
				韩轻功二 = ((Config.IniReadValue("GameServer", "韩轻功二") == "") ? 韩轻功二 : float.Parse(Config.IniReadValue("GameServer", "韩轻功二")));
				韩轻功三 = ((Config.IniReadValue("GameServer", "韩轻功三") == "") ? 韩轻功三 : float.Parse(Config.IniReadValue("GameServer", "韩轻功三")));
				韩轻功四 = ((Config.IniReadValue("GameServer", "韩轻功四") == "") ? 韩轻功四 : float.Parse(Config.IniReadValue("GameServer", "韩轻功四")));
				同IP势力战不计分 = int.Parse(Config.IniReadValue("GameServer", "同IP势力战不计分").Trim());
				势力战是否开启 = int.Parse(Config.IniReadValue("GameServer", "势力战是否开启").Trim());
				势力战开启分 = int.Parse(Config.IniReadValue("GameServer", "势力战开启分").Trim());
				势力战开启秒 = int.Parse(Config.IniReadValue("GameServer", "势力战开启秒").Trim());
				势力战设置 = Config.IniReadValue("GameServer", "势力战设置").Trim();
				势力战开启自动踢人 = int.Parse(Config.IniReadValue("GameServer", "势力战开启自动踢人").Trim());
				势力战踢人设置 = Config.IniReadValue("GameServer", "势力战踢人设置").Trim();
				势力战打死大怪得分 = int.Parse(Config.IniReadValue("GameServer", "势力战打死大怪得分").Trim());
				势力战打死小怪得分 = int.Parse(Config.IniReadValue("GameServer", "势力战打死小怪得分").Trim());
				势力战预备时间 = int.Parse(Config.IniReadValue("GameServer", "势力战预备时间").Trim());
				势力战战斗时间 = int.Parse(Config.IniReadValue("GameServer", "势力战战斗时间").Trim());
				势力战开始时向其它线广播 = int.Parse(Config.IniReadValue("GameServer", "势力战开始时向其它线广播").Trim());
				加载势力战场次();
				加载势力战踢人设置();
				野外BOSS开关 = int.Parse(Config.IniReadValue("GameServer", "野外BOSS开关").Trim());
				野外BOSS时间 = Config.IniReadValue("GameServer", "野外BOSS时间").Trim();
				野外BOSS配置 = Config.IniReadValue("GameServer", "野外BOSS配置").Trim();
				野外BOSS倒计时 = int.Parse(Config.IniReadValue("GameServer", "野外BOSS倒计时").Trim());
				野外BOSS总时间 = int.Parse(Config.IniReadValue("GameServer", "野外BOSS总时间").Trim());
				假人自动商店命令 = Config.IniReadValue("GameServer", "假人自动商店命令").Trim();
				假人关闭商店命令 = Config.IniReadValue("GameServer", "假人关闭商店命令").Trim();
				假人自动商店起名头 = Config.IniReadValue("GameServer", "假人自动商店起名头").Trim().Split(';');
				假人当前卖物品阶段 = int.Parse(Config.IniReadValue("GameServer", "假人当前卖物品阶段").Trim());
				属性一合成率 = ((Config.IniReadValue("GameServer", "属性一合成率") == "") ? 属性一合成率 : double.Parse(Config.IniReadValue("GameServer", "属性一合成率")));
				属性二合成率 = ((Config.IniReadValue("GameServer", "属性二合成率") == "") ? 属性二合成率 : double.Parse(Config.IniReadValue("GameServer", "属性二合成率")));
				属性三合成率 = ((Config.IniReadValue("GameServer", "属性三合成率") == "") ? 属性三合成率 : double.Parse(Config.IniReadValue("GameServer", "属性三合成率")));
				属性四合成率 = ((Config.IniReadValue("GameServer", "属性四合成率") == "") ? 属性四合成率 : double.Parse(Config.IniReadValue("GameServer", "属性四合成率")));
				制作进化一概率 = int.Parse(Config.IniReadValue("GameServer", "制作进化一概率").Trim());
				制作进化二概率 = int.Parse(Config.IniReadValue("GameServer", "制作进化二概率").Trim());
				伏魔洞限制等级 = int.Parse(Config.IniReadValue("GameServer", "伏魔洞限制等级").Trim());
				武林血战开启时间星期 = Config.IniReadValue("GameServer", "武林血战开启时间星期").Trim();
				for (int i = 0; i < 1200; i++)
				{
					假人出售物品[i] = "";
				}
				string text = Config.IniReadValue("GameServer", "假人出售物品");
				if (假人当前卖物品阶段 >= 1)
				{
					for (int j = 0; j < 301; j++)
					{
						假人出售物品[j] = ((Config.IniReadValue("GameServer", "假人出售物品" + j).Trim() == "") ? "" : Config.IniReadValue("GameServer", "假人出售物品" + j).Trim());
					}
				}
				if (假人当前卖物品阶段 >= 2)
				{
					for (int k = 301; k < 601; k++)
					{
						假人出售物品[k] = ((Config.IniReadValue("GameServer", "假人出售物品" + k).Trim() == "") ? "" : Config.IniReadValue("GameServer", "假人出售物品" + k).Trim());
					}
				}
				if (假人当前卖物品阶段 >= 3)
				{
					for (int l = 601; l < 901; l++)
					{
						假人出售物品[l] = ((Config.IniReadValue("GameServer", "假人出售物品" + l).Trim() == "") ? "" : Config.IniReadValue("GameServer", "假人出售物品" + l).Trim());
					}
				}
				if (假人当前卖物品阶段 >= 4)
				{
					for (int m = 901; m < 1200; m++)
					{
						假人出售物品[m] = ((Config.IniReadValue("GameServer", "假人出售物品" + m).Trim() == "") ? "" : Config.IniReadValue("GameServer", "假人出售物品" + m).Trim());
					}
				}
				int num2 = 0;
				for (int n = 0; n < 1200; n++)
				{
					if (假人出售物品[n] != "")
					{
						num2++;
					}
				}
				if (随机BOSS出现时间表.Length != 0)
				{
					BOSSListTime.Clear();
					string text2 = 随机BOSS出现时间表;
					char[] separator = new char[1] { ';' };
					string[] array = text2.Split(separator);
					string[] array2 = array;
					string[] array9 = array2;
					foreach (string s in array9)
					{
						int item = int.Parse(s);
						BOSSListTime.Add(item);
					}
				}
				else
				{
					BOSSListTime.Clear();
				}
				if (是否加密 != 1)
				{
					return;
				}
				for (int num3 = 0; num3 < 8; num3++)
				{
					g_cur_key2[num3] = Convert.ToByte(加密密钥.Substring(num3 * 2, 2), 16);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(100, "配置文件 config.ini 配置错误:" + ex.Message);
				MainForm.WriteLine(100, "在设置项: " + str);
			}
			try
			{
				string text3 = ((Config.IniReadValue("GameServer", "限制PK地图").Trim() == string.Empty) ? string.Empty : Config.IniReadValue("GameServer", "限制PK地图").Trim());
				限制PK地图列表.Clear();
				if (text3 != string.Empty)
				{
					string text4 = text3;
					char[] separator2 = new char[1] { ';' };
					string[] array3 = text4.Split(separator2);
					string[] array4 = array3;
					string[] array10 = array4;
					foreach (string s2 in array10)
					{
						if (!限制PK地图列表.Contains(int.Parse(s2)))
						{
							限制PK地图列表.Add(int.Parse(s2));
						}
					}
				}
				string text5 = ((Config.IniReadValue("GameServer", "限时间PK地图").Trim() == string.Empty) ? string.Empty : Config.IniReadValue("GameServer", "限时间PK地图").Trim());
				限时PK地图列表.Clear();
				if (text5 != string.Empty)
				{
					string text6 = text5;
					char[] separator3 = new char[1] { ';' };
					string[] array5 = text6.Split(separator3);
					string[] array6 = array5;
					string[] array11 = array6;
					foreach (string s3 in array11)
					{
						if (!限时PK地图列表.Contains(int.Parse(s3)))
						{
							限时PK地图列表.Add(int.Parse(s3));
						}
					}
				}
				限时地图开PK时间 = ((Config.IniReadValue("GameServer", "限时地图开PK时间").Trim() == string.Empty) ? 限时地图开PK时间 : int.Parse(Config.IniReadValue("GameServer", "限时地图开PK时间").Trim()));
				工作日限时地图开PK时间 = ((Config.IniReadValue("GameServer", "工作日限时地图开PK时间").Trim() == string.Empty) ? 工作日限时地图开PK时间 : int.Parse(Config.IniReadValue("GameServer", "工作日限时地图开PK时间").Trim()));
				限时地图关PK时间 = ((Config.IniReadValue("GameServer", "限时地图关PK时间").Trim() == string.Empty) ? 限时地图关PK时间 : int.Parse(Config.IniReadValue("GameServer", "限时地图关PK时间").Trim()));
				工作日限时地图关PK时间 = ((Config.IniReadValue("GameServer", "工作日限时地图关PK时间").Trim() == string.Empty) ? 工作日限时地图关PK时间 : int.Parse(Config.IniReadValue("GameServer", "工作日限时地图关PK时间").Trim()));
				周末全天PK是否开启 = ((Config.IniReadValue("GameServer", "周末全天PK是否开启").Trim() == string.Empty) ? 周末全天PK是否开启 : int.Parse(Config.IniReadValue("GameServer", "周末全天PK是否开启").Trim()));
				string text7 = ((Config.IniReadValue("GameServer", "全天PK地图").Trim() == string.Empty) ? "1301;2001;5001" : Config.IniReadValue("GameServer", "全天PK地图").Trim());
				周末全天PK地图列表.Clear();
				if (!(text7 != string.Empty))
				{
					return;
				}
				string text8 = text7;
				char[] separator4 = new char[1] { ';' };
				string[] array7 = text8.Split(separator4);
				string[] array8 = array7;
				string[] array12 = array8;
				foreach (string s4 in array12)
				{
					if (!周末全天PK地图列表.Contains(int.Parse(s4)))
					{
						周末全天PK地图列表.Add(int.Parse(s4));
					}
				}
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(100, " 配置文件加载挂机地图表错误:" + ex2.Message);
			}
		}

		public static void 加载势力战场次()
		{
			string[] array = 势力战设置.Split('/');
			所有势力战场次.Clear();
			string[] array2 = array;
			string[] array3 = array2;
			string[] array5 = array3;
			foreach (string text in array5)
			{
				if (text.Length > 0)
				{
					string[] array4 = text.Split(':');
					if (array4.Length > 3)
					{
						势力战场次 势力战场次2 = new 势力战场次
						{
							开启时间 = int.Parse(array4[0]),
							最小转职 = int.Parse(array4[1]),
							最大转职 = int.Parse(array4[2]),
							势力战类型 = int.Parse(array4[3])
						};
						所有势力战场次.TryAdd(势力战场次2.开启时间, 势力战场次2);
					}
				}
			}
		}

		public static void 加载势力战踢人设置()
		{
			string[] array = 势力战踢人设置.Split('/');
			势力战踢人方案.Clear();
			string[] array2 = array;
			string[] array3 = array2;
			string[] array5 = array3;
			foreach (string text in array5)
			{
				if (text.Length > 0)
				{
					string[] array4 = text.Split(':');
					if (array4.Length > 1)
					{
						KeyValuePair<int, int> item = new KeyValuePair<int, int>(int.Parse(array4[0]), int.Parse(array4[1]));
						势力战踢人方案.Add(item);
					}
				}
			}
		}

		public static bool 检查数据库配置()
		{
			using (SqlConnection sqlConnection = new SqlConnection(DBA.getstrConnection("rxjhaccount")))
			{
				try
				{
					sqlConnection.Open();
				}
				catch
				{
					MainForm.WriteLine(1, "数据库rxjhaccount配置错误，无法连接");
					return false;
				}
				finally
				{
					sqlConnection.Close();
				}
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DBA.getstrConnection("GameServer")))
			{
				try
				{
					sqlConnection2.Open();
				}
				catch
				{
					MainForm.WriteLine(1, "数据库rxjhgame配置错误，无法连接");
					return false;
				}
				finally
				{
					sqlConnection2.Close();
				}
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DBA.getstrConnection("PublicDb")))
			{
				try
				{
					sqlConnection3.Open();
				}
				catch
				{
					MainForm.WriteLine(1, "数据库PublicDb配置错误，无法连接");
					return false;
				}
				finally
				{
					sqlConnection3.Close();
				}
			}
			using (SqlConnection sqlConnection4 = new SqlConnection(DBA.getstrConnection("WebDb")))
			{
				try
				{
					sqlConnection4.Open();
				}
				catch
				{
					MainForm.WriteLine(1, "数据库WebDb配置错误，无法连接");
					return false;
				}
				finally
				{
					sqlConnection4.Close();
				}
			}
			using (SqlConnection sqlConnection5 = new SqlConnection(DBA.getstrConnection("BBG")))
			{
				try
				{
					sqlConnection5.Open();
				}
				catch
				{
					MainForm.WriteLine(1, "数据库BBG配置错误，无法连接");
					return false;
				}
				finally
				{
					sqlConnection5.Close();
				}
			}
			return true;
		}

		public void SetConfig2()
		{
			Db.TryAdd("rxjhaccount", new DbClass
			{
				ServerDb = "rxjhaccount",
				SqlConnect = string.Format("Data Source={0};uid={1};pwd={2};database={3};Packet Size=4096;Pooling=true;Max Pool Size=512;Min Pool Size=1", Config.IniReadValue("rxjhaccount", "Server").Trim(), Config.IniReadValue("rxjhaccount", "UserName").Trim(), Config.IniReadValue("rxjhaccount", "PassWord").Trim(), Config.IniReadValue("rxjhaccount", "DataName").Trim())
			});
			Db.TryAdd("GameServer", new DbClass
			{
				ServerDb = "GameServer",
				SqlConnect = string.Format("Data Source={0};uid={1};pwd={2};database={3};Packet Size=4096;Pooling=true;Max Pool Size=512;Min Pool Size=1", Config.IniReadValue("GameServer", "Server").Trim(), Config.IniReadValue("GameServer", "UserName").Trim(), Config.IniReadValue("GameServer", "PassWord").Trim(), Config.IniReadValue("GameServer", "DataName").Trim())
			});
			Db.TryAdd("PublicDb", new DbClass
			{
				ServerDb = "PublicDb",
				SqlConnect = string.Format("Data Source={0};uid={1};pwd={2};database={3};Packet Size=4096;Pooling=true;Max Pool Size=512;Min Pool Size=1", Config.IniReadValue("PublicDb", "Server").Trim(), Config.IniReadValue("PublicDb", "UserName").Trim(), Config.IniReadValue("PublicDb", "PassWord").Trim(), Config.IniReadValue("PublicDb", "DataName").Trim())
			});
			Db.TryAdd("WebDb", new DbClass
			{
				ServerDb = "WebDb",
				SqlConnect = string.Format("Data Source={0};uid={1};pwd={2};database={3};Packet Size=4096;Pooling=true;Max Pool Size=512;Min Pool Size=1", Config.IniReadValue("WebDb", "Server").Trim(), Config.IniReadValue("WebDb", "UserName").Trim(), Config.IniReadValue("WebDb", "PassWord").Trim(), Config.IniReadValue("WebDb", "DataName").Trim())
			});
			Db.TryAdd("BBG", new DbClass
			{
				ServerDb = "BBG",
				SqlConnect = string.Format("Data Source={0};uid={1};pwd={2};database={3};Packet Size=4096;Pooling=true;Max Pool Size=512;Min Pool Size=1", Config.IniReadValue("BBG", "Server").Trim(), Config.IniReadValue("BBG", "UserName").Trim(), Config.IniReadValue("BBG", "PassWord").Trim(), Config.IniReadValue("BBG", "DataName").Trim())
			});
		}

		public void SetWxLever()
		{
			string sqlCommand = "SELECT * FROM TBL_武勋加成";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "PublicDb");
			if (dBToDataTable != null)
			{
				if (dBToDataTable.Rows.Count == 0)
				{
					MainForm.WriteLine(2, "加载武勋列表出错----没有武勋数据");
				}
				else
				{
					Wxlever.Clear();
					for (int i = 0; i < dBToDataTable.Rows.Count; i++)
					{
						武勋加成类 value = new 武勋加成类
						{
							武勋气功防御 = double.Parse(dBToDataTable.Rows[i]["FLD_武勋气功防御"].ToString()),
							武勋点 = double.Parse(dBToDataTable.Rows[i]["FLD_武勋点数"].ToString()),
							增加攻击 = (int)dBToDataTable.Rows[i]["FLD_攻击"],
							增加防御 = (int)dBToDataTable.Rows[i]["FLD_防御"],
							增加HP = (int)dBToDataTable.Rows[i]["FLD_血量"],
							增加MP = (int)dBToDataTable.Rows[i]["FLD_蓝量"],
							增加气功 = (int)dBToDataTable.Rows[i]["FLD_所有气功增加"],
							增加阶段 = (int)dBToDataTable.Rows[i]["FLD_阶段"]
						};
						Wxlever.TryAdd((int)dBToDataTable.Rows[i]["ID"], value);
					}
				}
				dBToDataTable.Dispose();
			}
			MainForm.WriteLine(2, "加载武勋阶段表完成");
		}

		public void Set安全区()
		{
			对练区.Add(new 坐标Class
			{
				Rxjh_name = "对练区",
				Rxjh_Map = 2301,
				Rxjh_X = 120f,
				Rxjh_Y = 0f,
				Rxjh_Z = 15f
			});
			比武泡点区.Add(new 坐标Class
			{
				Rxjh_name = "比武泡点区",
				Rxjh_Map = 2341,
				Rxjh_X = 120f,
				Rxjh_Y = 0f,
				Rxjh_Z = 15f
			});
			势力战区域.Add(new 坐标Class
			{
				Rxjh_name = "势力战区域",
				Rxjh_Map = 801,
				Rxjh_X = 0f,
				Rxjh_Y = 0f,
				Rxjh_Z = 15f
			});
			仙魔大战区域.Add(new 坐标Class
			{
				Rxjh_name = "仙魔大战区域",
				Rxjh_Map = 41001,
				Rxjh_X = 0f,
				Rxjh_Y = 0f,
				Rxjh_Z = 15f
			});
			帮战区.Add(new 坐标Class
			{
				Rxjh_name = "帮战区",
				Rxjh_Map = 7301,
				Rxjh_X = 0f,
				Rxjh_Y = 0f,
				Rxjh_Z = 15f
			});
		}

		public void SetJianc()
		{
			if (查非法物品 != 2)
			{
				return;
			}
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 装备检测", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count != 0)
			{
				装备检测list.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					装备检测list.TryAdd((int)dBToDataTable.Rows[i]["物品类型"], new 装备检测类
					{
						物品最高攻击值 = (int)dBToDataTable.Rows[i]["物品最高攻击值"],
						物品最高防御值 = (int)dBToDataTable.Rows[i]["物品最高防御值"],
						物品最高生命值 = (int)dBToDataTable.Rows[i]["物品最高生命值"],
						物品最高内功值 = (int)dBToDataTable.Rows[i]["物品最高内功值"],
						物品最高命中值 = (int)dBToDataTable.Rows[i]["物品最高命中值"],
						物品最高回避值 = (int)dBToDataTable.Rows[i]["物品最高回避值"],
						物品最高武功值 = (int)dBToDataTable.Rows[i]["物品最高武功值"],
						物品最高气功值 = (int)dBToDataTable.Rows[i]["物品最高气功值"],
						物品最高附魂值 = (int)dBToDataTable.Rows[i]["物品最高附魂值"]
					});
				}
				MainForm.WriteLine(2, "加载装备检测数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void 安全地图区域()
		{
			string sqlCommand = "SELECT * FROM TBL_安全区";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载安全区出错----没有数据");
			}
			else
			{
				地图安全区.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					安全区Class 安全区Class2 = new 安全区Class
					{
						地图编号 = (int)dBToDataTable.Rows[i]["地图编号"],
						FLD_X = float.Parse(dBToDataTable.Rows[i]["FLD_X"].ToString()),
						FLD_Y = float.Parse(dBToDataTable.Rows[i]["FLD_Y"].ToString()),
						坐标_X = float.Parse(dBToDataTable.Rows[i]["坐标_X"].ToString()),
						坐标_Y = float.Parse(dBToDataTable.Rows[i]["坐标_Y"].ToString())
					};
					地图安全区.TryAdd(安全区Class2.地图编号, 安全区Class2);
				}
				MainForm.WriteLine(2, "加载安全区地图完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void 加载披风收录()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_披风收录", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载披风收录出错----没有披风收录数据");
			}
			else
			{
				披风收录buff.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					披风收录 value = new 披风收录
					{
						披风 = (int)dBToDataTable.Rows[i]["披风"],
						攻击 = (int)dBToDataTable.Rows[i]["攻击"],
						防御 = (int)dBToDataTable.Rows[i]["防御"],
						血量 = (int)dBToDataTable.Rows[i]["血量"],
						性别 = (int)dBToDataTable.Rows[i]["性别"],
						备注 = dBToDataTable.Rows[i]["备注"].ToString()
					};
					披风收录buff.TryAdd(i, value);
				}
				MainForm.WriteLine(2, "加载披风收录数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void 加载物品回收()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 物品回收", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载物品回收出错----没有物品回收数据");
			}
			else
			{
				物品回收数据.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					物品回收类 value = new 物品回收类
					{
						需要物品 = dBToDataTable.Rows[i]["需要物品"].ToString(),
						元宝 = (int)dBToDataTable.Rows[i]["元宝"],
						钻石 = (int)dBToDataTable.Rows[i]["钻石"],
						说明 = dBToDataTable.Rows[i]["说明"].ToString()
					};
					物品回收数据.TryAdd(i, value);
				}
				MainForm.WriteLine(2, "加载物品回收数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public static void 删除指定地图指定类型怪物(int 参数地图ID, int 参数怪物系统编号)
		{
			try
			{
				List<NpcClass> list = new List<NpcClass>();
				foreach (NpcClass value in MapClass.GetnpcTemplate(参数地图ID).Values)
				{
					if (value.FLD_PID == 参数怪物系统编号)
					{
						list.Add(value);
					}
				}
				if (list == null)
				{
					return;
				}
				foreach (NpcClass item in list)
				{
					item.发送怪物一次性死亡数据();
				}
				list.Clear();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "删除怪 [" + 参数怪物系统编号 + "]出错：" + ex);
			}
		}

		public void 加载装备洗髓()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_装备洗髓", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载装备洗髓出错----没有装备洗髓数据");
			}
			else
			{
				装备洗髓系统.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					装备洗髓 value = new 装备洗髓
					{
						装备ID = (int)dBToDataTable.Rows[i]["装备ID"],
						类型 = (int)dBToDataTable.Rows[i]["类型"],
						属性一最小 = (int)dBToDataTable.Rows[i]["属性一最小"],
						属性一最大 = (int)dBToDataTable.Rows[i]["属性一最大"],
						属性二最小 = (int)dBToDataTable.Rows[i]["属性二最小"],
						属性二最大 = (int)dBToDataTable.Rows[i]["属性二最大"],
						属性三最小 = (int)dBToDataTable.Rows[i]["属性三最小"],
						属性三最大 = (int)dBToDataTable.Rows[i]["属性三最大"],
						属性四最小 = (int)dBToDataTable.Rows[i]["属性四最小"],
						属性四最大 = (int)dBToDataTable.Rows[i]["属性四最大"],
						模式 = (int)dBToDataTable.Rows[i]["模式"]
					};
					装备洗髓系统.TryAdd(i, value);
				}
				MainForm.WriteLine(2, "加载装备洗髓数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void 加载英雄职业武器()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_英雄职业武器", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载英雄职业武器出错----没有英雄职业武器");
			}
			else
			{
				英雄职业武器系统.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					英雄职业武器 value = new 英雄职业武器
					{
						装备ID = (int)dBToDataTable.Rows[i]["装备ID"],
						职业 = (int)dBToDataTable.Rows[i]["职业"],
						几转 = (int)dBToDataTable.Rows[i]["几转"]
					};
					英雄职业武器系统.TryAdd(i, value);
				}
				MainForm.WriteLine(2, "加载英雄职业武器数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void 加载累计充值礼包()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 累计充值礼包", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载累计充值礼包出错----没有累计充值礼包");
			}
			else
			{
				累计充值礼包.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					累计充值礼包 value = new 累计充值礼包
					{
						累计最小 = (int)dBToDataTable.Rows[i]["累计最小"],
						累计最大 = (int)dBToDataTable.Rows[i]["累计最大"],
						礼包编号 = (int)dBToDataTable.Rows[i]["礼包编号"],
						档次 = (int)dBToDataTable.Rows[i]["档次"]
					};
					累计充值礼包.TryAdd(i, value);
				}
				MainForm.WriteLine(2, "加载累计充值礼包数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetQG()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_SKILL", "PublicDb");
			if (dBToDataTable != null)
			{
				if (dBToDataTable.Rows.Count != 0)
				{
					气功加成.Clear();
					for (int i = 0; i < dBToDataTable.Rows.Count; i++)
					{
						气功加成.TryAdd(i, new 气功加成属性
						{
							FLD_PID = (int)dBToDataTable.Rows[i]["FLD_PID"],
							FLD_INDEX = (int)dBToDataTable.Rows[i]["FLD_INDEX"],
							FLD_JOB = (int)dBToDataTable.Rows[i]["FLD_JOB"],
							FLD_NAME = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
							FLD_每点加成比率值1 = (double)dBToDataTable.Rows[i]["FLD_每点加成比率值1"],
							FLD_每点加成比率值2 = (double)dBToDataTable.Rows[i]["FLD_每点加成比率值2"]
						});
					}
					MainForm.WriteLine(2, "加载气功加成比率数据完成" + dBToDataTable.Rows.Count);
				}
				dBToDataTable.Dispose();
			}
			普通气功ID.Clear();
			for (int j = 0; j < 12; j++)
			{
				for (int k = 1; k < 14; k++)
				{
					普通气功ID.Add(得到气功ID(j, k));
				}
			}
			普通气功ID.Sort();
		}

		public void SetKill()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM XWWL_kill", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载过滤出错----没有过滤数据");
			}
			else
			{
				Kill.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					Kill.Add(new KillClass
					{
						Txt = dBToDataTable.Rows[i]["txt"].ToString(),
						Sffh = (int)dBToDataTable.Rows[i]["sffh"]
					});
				}
				MainForm.WriteLine(2, "加载过滤数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public static string 查询门派向哪个门派发出联盟申请(string 门派名字)
		{
			for (int i = 0; i < 门派联盟申请状态.Count; i++)
			{
				门派联盟申请状态 门派联盟申请状态2 = 门派联盟申请状态[i];
				if (门派联盟申请状态2.申请门派名字 == 门派名字)
				{
					return 门派联盟申请状态2.盟主门派名字;
				}
			}
			return "";
		}

		public void Set等级奖励()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 等级奖励", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载等级奖励出错----没有等级奖励数据");
			}
			else
			{
				等级奖励.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					等级奖励.TryAdd(i, new 等级奖励类
					{
						等级 = (int)dBToDataTable.Rows[i]["级别"],
						武勋 = (int)dBToDataTable.Rows[i]["武勋"],
						元宝 = (int)dBToDataTable.Rows[i]["元宝"],
						套装 = (int)dBToDataTable.Rows[i]["套装ID"],
						金钱 = dBToDataTable.Rows[i]["金钱"].ToString(),
						单件物品 = dBToDataTable.Rows[i]["单件物品"].ToString()
					});
				}
				MainForm.WriteLine(2, "加载等级奖励数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void Set比武泡点奖励()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT  *  FROM  比武泡点奖励", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载假人等级奖励出错----没有假人等级奖励数据");
			}
			else
			{
				比武泡点奖励.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					比武泡点奖励.TryAdd(i, new 比武泡点奖励
					{
						排名 = (int)dBToDataTable.Rows[i]["排名"],
						名次 = (int)dBToDataTable.Rows[i]["名次"],
						武勋 = (int)dBToDataTable.Rows[i]["武勋"],
						元宝 = (int)dBToDataTable.Rows[i]["元宝"],
						钻石 = (int)dBToDataTable.Rows[i]["钻石"],
						套装 = (int)dBToDataTable.Rows[i]["套装ID"],
						金钱 = dBToDataTable.Rows[i]["金钱"].ToString(),
						单件物品 = dBToDataTable.Rows[i]["单件物品"].ToString()
					});
				}
				MainForm.WriteLine(2, "加载比武泡点奖励数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void Set石头属性()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_STONE", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载石头属性出错----没有石头数据");
			}
			else
			{
				clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					SetStone((int)dBToDataTable.Rows[i]["FLD_TYPE"], (int)dBToDataTable.Rows[i]["FLD_VALUE"], (int)dBToDataTable.Rows[i]["FLD_增减"]);
				}
				MainForm.WriteLine(2, "加载石头属性效果数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetStone(int type, int value, int 增减)
		{
			try
			{
				switch (type)
				{
				case 2:
					switch (value)
					{
					case 10:
						f10 += 增减;
						break;
					case 11:
						f11 += 增减;
						break;
					case 12:
						f12 += 增减;
						break;
					case 13:
						f13 += 增减;
						break;
					case 14:
						f14 += 增减;
						break;
					case 15:
						f15 += 增减;
						break;
					}
					break;
				case 1:
					switch (value)
					{
					case 20:
						g20 += 增减;
						break;
					case 21:
						g21 += 增减;
						break;
					case 22:
						g22 += 增减;
						break;
					case 23:
						g23 += 增减;
						break;
					case 24:
						g24 += 增减;
						break;
					case 25:
						g25 += 增减;
						break;
					}
					break;
				case 11:
					switch (value)
					{
					case 68:
						wf68 += 增减;
						break;
					case 69:
						break;
					case 70:
						wf70 += 增减;
						break;
					case 71:
						break;
					case 72:
						wf72 += 增减;
						break;
					case 73:
						break;
					case 74:
						wf74 += 增减;
						break;
					case 75:
						break;
					case 76:
						wf76 += 增减;
						break;
					case 77:
						break;
					case 78:
						wf78 += 增减;
						break;
					case 79:
						break;
					case 80:
						wf80 += 增减;
						break;
					case 81:
						break;
					case 82:
						break;
					case 83:
						break;
					case 84:
						break;
					case 85:
						wf85 += 增减;
						break;
					case 86:
						break;
					case 87:
						break;
					case 88:
						break;
					case 89:
						break;
					case 90:
						wf90 += 增减;
						break;
					case 91:
						break;
					case 92:
						wf92 += 增减;
						break;
					case 93:
						break;
					case 94:
						wf94 += 增减;
						break;
					case 95:
						wf95 += 增减;
						break;
					case 96:
						wf96 += 增减;
						break;
					case 97:
						break;
					case 98:
						wf98 += 增减;
						break;
					case 99:
						break;
					case 100:
						wf100 += 增减;
						break;
					case 110:
						wf110 += 增减;
						break;
					case 112:
						wf112 += 增减;
						break;
					case 114:
						wf114 += 增减;
						break;
					case 116:
						wf116 += 增减;
						break;
					case 118:
						wf118 += 增减;
						break;
					case 120:
						wf120 += 增减;
						break;
					case 101:
					case 102:
					case 103:
					case 104:
					case 105:
					case 106:
					case 107:
					case 108:
					case 109:
					case 111:
					case 113:
					case 115:
					case 117:
					case 119:
						break;
					}
					break;
				case 7:
					switch (value)
					{
					case 20:
						wg20 += 增减;
						break;
					case 21:
						wg21 += 增减;
						break;
					case 22:
						wg22 += 增减;
						break;
					case 23:
						wg23 += 增减;
						break;
					case 24:
						wg24 += 增减;
						break;
					case 25:
						wg25 += 增减;
						break;
					case 26:
						wg26 += 增减;
						break;
					case 27:
						wg27 += 增减;
						break;
					case 28:
						wg28 += 增减;
						break;
					case 29:
						wg29 += 增减;
						break;
					case 30:
						wg30 += 增减;
						break;
					case 31:
						wg31 += 增减;
						break;
					case 32:
						wg32 += 增减;
						break;
					case 33:
						wg33 += 增减;
						break;
					case 34:
						wg34 += 增减;
						break;
					case 35:
						wg35 += 增减;
						break;
					case 36:
						wg36 += 增减;
						break;
					case 37:
						wg37 += 增减;
						break;
					case 38:
						wg38 += 增减;
						break;
					case 39:
						wg39 += 增减;
						break;
					case 40:
						wg40 += 增减;
						break;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "设置石头出错|" + type + "|" + value + "|" + 增减 + "|" + ex.Message);
			}
		}

		public void Set物品兑换()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 物品兑换", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载物品兑换出错----没有物品兑换数据");
			}
			else
			{
				物品兑换.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					物品兑换.TryAdd(i, new 物品兑换类
					{
						需要物品 = dBToDataTable.Rows[i]["需要物品"].ToString(),
						武勋 = (int)dBToDataTable.Rows[i]["武勋"],
						元宝 = (int)dBToDataTable.Rows[i]["元宝"],
						积分 = (int)dBToDataTable.Rows[i]["积分"],
						套装 = (int)dBToDataTable.Rows[i]["套装ID"],
						金钱 = dBToDataTable.Rows[i]["金钱"].ToString(),
						命令 = dBToDataTable.Rows[i]["命令"].ToString(),
						增加 = (int)dBToDataTable.Rows[i]["增加"],
						颜色 = (int)dBToDataTable.Rows[i]["颜色"],
						单件物品 = dBToDataTable.Rows[i]["单件物品"].ToString(),
						系统公告 = dBToDataTable.Rows[i]["系统公告"].ToString()
					});
				}
				MainForm.WriteLine(2, "加载物品兑换数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void Set公告()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_Gg", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载公告出错----没有公告数据");
			}
			else
			{
				公告.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					公告.TryAdd(i, new AnnouncementClass
					{
						msg = dBToDataTable.Rows[i]["txt"].ToString(),
						type = (int)dBToDataTable.Rows[i]["type"]
					});
				}
				MainForm.WriteLine(2, "加载公告数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void Set任务数据新()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_MISSION WHERE FLD_ON = 1", "PublicDb");
			int rwpid = 0;
			try
			{
				if (dBToDataTable == null)
				{
					return;
				}
				if (dBToDataTable.Rows.Count == 0)
				{
					MainForm.WriteLine(2, "加载任务数据新出错----没有任务传书数据");
				}
				else
				{
					任务list.Clear();
					for (int i = 0; i < dBToDataTable.Rows.Count; i++)
					{
						任务类 任务类2 = new 任务类
						{
							RwID = (int)dBToDataTable.Rows[i]["FLD_PID"]
						};
						rwpid = 任务类2.RwID;
						任务类2.任务名 = dBToDataTable.Rows[i]["FLD_NAME"].ToString();
						任务类2.任务等级 = (int)dBToDataTable.Rows[i]["FLD_LEVEL"];
						任务类2.任务正邪 = (int)dBToDataTable.Rows[i]["FLD_ZX"];
						任务类2.职业 = (int)dBToDataTable.Rows[i]["FLD_JOB"];
						任务类2.NpcID = (int)dBToDataTable.Rows[i]["FLD_NPCID"];
						任务类2.NPCNAME = dBToDataTable.Rows[i]["FLD_NPCNAME"].ToString();
						任务类2.Npc坐标.地图ID = (int)dBToDataTable.Rows[i]["FLD_MAP"];
						任务类2.Npc坐标.坐标X = (int)dBToDataTable.Rows[i]["FLD_X"];
						任务类2.Npc坐标.坐标Y = (int)dBToDataTable.Rows[i]["FLD_Y"];
						任务类2.任务开关 = (int)dBToDataTable.Rows[i]["FLD_ON"];
						任务类2.任务类型 = (int)dBToDataTable.Rows[i]["FLD_TYPE"];
						int num = (int)dBToDataTable.Rows[i]["FLD_ZHMR"];
						任务类2.是否账号每日 = num != 0;
						任务类2.ZJPID = (int)dBToDataTable.Rows[i]["FLD_ZJPID"];
						任务类2.WPPID = (int)dBToDataTable.Rows[i]["FLD_WPPID"];
						任务类2.WPSL = (int)dBToDataTable.Rows[i]["FLD_WPSL"];
						int num2 = (int)dBToDataTable.Rows[i]["FLD_ZDHD"];
						任务类2.是否组队获得 = num2 != 0;
						DataTable dataTable = RxjhClass.得到自定义任务阶段(rwpid);
						if (dataTable != null)
						{
							for (int j = 0; j < dataTable.Rows.Count; j++)
							{
								任务阶段类 任务阶段类2 = new 任务阶段类
								{
									阶段ID = (int)dataTable.Rows[j]["任务阶段ID"],
									NpcID = (int)dataTable.Rows[j]["NpcID"]
								};
								string text = dataTable.Rows[j]["FLD_NEED_ITEM"].ToString();
								if (text.Length > 0)
								{
									string[] array = text.Split(';');
									string[] array3 = array;
									string[] array4 = array3;
									string[] array5 = array4;
									string[] array11 = array5;
									foreach (string text2 in array11)
									{
										任务需要物品类 任务需要物品类2 = new 任务需要物品类();
										string[] array6 = text2.Split(',');
										任务需要物品类2.物品ID = int.Parse(array6[0]);
										任务需要物品类2.物品数量 = int.Parse(array6[1]);
										任务需要物品类2.NPCPID = int.Parse(array6[2]);
										任务需要物品类2.难度 = int.Parse(array6[3]);
										任务阶段类2.任务需要物品.Add(任务需要物品类2);
									}
								}
								string text3 = dataTable.Rows[j]["FLD_GET_ITEM"].ToString();
								if (text3.Length > 0)
								{
									string[] array7 = text3.Split(';');
									string[] array8 = array7;
									string[] array9 = array8;
									string[] array10 = array9;
									string[] array12 = array10;
									foreach (string text4 in array12)
									{
										任务获得物品类 任务获得物品类2 = new 任务获得物品类();
										string[] array2 = text4.Split(',');
										任务获得物品类2.物品ID = int.Parse(array2[0]);
										任务获得物品类2.物品数量 = int.Parse(array2[1]);
										任务获得物品类2.是否绑定 = int.Parse(array2[2]);
										任务获得物品类2.奖励类型 = int.Parse(array2[3]);
										任务获得物品类2.时间 = int.Parse(array2[4]);
										任务阶段类2.任务获得物品.Add(任务获得物品类2);
									}
								}
								任务类2.任务阶段.Add(任务阶段类2);
							}
						}
						任务类2.任务阶段数量 = 任务类2.任务阶段.Count;
						任务list.TryAdd(任务类2.RwID, 任务类2);
					}
					MainForm.WriteLine(2, "加载任务数据新完成" + dBToDataTable.Rows.Count);
				}
				dBToDataTable.Dispose();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "加载任务数据新出错, 任务ID-" + rwpid + "|" + ex.ToString());
			}
		}

		public void Set检查物品()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM XWWL_JC", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载检查物品出错----没有检查物品数据");
			}
			else
			{
				物品检查.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					物品检查.Add(new 检查物品类
					{
						物品ID = (int)dBToDataTable.Rows[i]["FLD_PID"],
						物品类型 = (int)dBToDataTable.Rows[i]["FLD_TYPE"],
						FLD_MAGIC1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"],
						FLD_MAGIC1_1 = dBToDataTable.Rows[i]["FLD_MAGIC1_1"].ToString(),
						FLD_MAGIC2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"],
						FLD_MAGIC2_2 = dBToDataTable.Rows[i]["FLD_MAGIC2_2"].ToString(),
						FLD_MAGIC3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"],
						FLD_MAGIC3_3 = dBToDataTable.Rows[i]["FLD_MAGIC3_3"].ToString(),
						FLD_MAGIC4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"],
						FLD_MAGIC4_4 = dBToDataTable.Rows[i]["FLD_MAGIC4_4"].ToString(),
						FLD_MAGIC5 = (int)dBToDataTable.Rows[i]["FLD_MAGIC5"],
						FLD_MAGIC5_5 = dBToDataTable.Rows[i]["FLD_MAGIC5_5"].ToString()
					});
				}
				MainForm.WriteLine(2, "加载检查物品数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void Set制药物品()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 制药物品列表 ORDER BY 物品ID", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载制作物品完成----没有制作物品数据");
				return;
			}
			制药物品列表.Clear();
			for (int i = 0; i < dBToDataTable.Rows.Count; i++)
			{
				制药物品类 制药物品类2 = new 制药物品类();
				try
				{
					制药物品类2.物品ID = (int)dBToDataTable.Rows[i]["物品ID"];
					制药物品类2.物品名 = dBToDataTable.Rows[i]["物品名"].ToString();
					制药物品类2.物品数量 = (int)dBToDataTable.Rows[i]["物品数量"];
					string value = dBToDataTable.Rows[i]["需要物品"].ToString();
					制药物品类2.需要物品 = JsonConvert.DeserializeObject<List<制药需要物品类>>(value);
					if (!制药物品列表.ContainsKey(制药物品类2.物品ID))
					{
						制药物品列表.TryAdd(制药物品类2.物品ID, 制药物品类2);
					}
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "加载制药物品 错误" + 制药物品类2.物品ID + " " + ex.Message);
				}
			}
			MainForm.WriteLine(2, "加载制药物品 " + dBToDataTable.Rows.Count);
		}

		public void Set移动()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_MAP WHERE (X IS NOT NULL)", "PublicDb");
			if (dBToDataTable != null)
			{
				if (dBToDataTable.Rows.Count == 0)
				{
					MainForm.WriteLine(2, "加载自定义移动出错----没有移动数据");
				}
				else
				{
					移动.Clear();
					for (int i = 0; i < dBToDataTable.Rows.Count; i++)
					{
						移动.Add(new 坐标Class
						{
							Rxjh_name = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
							Rxjh_Map = (int)dBToDataTable.Rows[i]["FLD_MID"],
							Rxjh_X = float.Parse(dBToDataTable.Rows[i]["X"].ToString()),
							Rxjh_Y = float.Parse(dBToDataTable.Rows[i]["Y"].ToString()),
							Rxjh_Z = 15f
						});
					}
					MainForm.WriteLine(2, "加载自定义移动数据完成" + dBToDataTable.Rows.Count);
				}
				dBToDataTable.Dispose();
			}
			DataTable dBToDataTable2 = DBA.GetDBToDataTable("SELECT FLD_MID, FLD_NAME FROM TBL_XWWL_MAP", "PublicDb");
			if (dBToDataTable2 == null)
			{
				return;
			}
			if (dBToDataTable2.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载自定义移动出错----没有移动数据");
			}
			else
			{
				Maplist.Clear();
				for (int j = 0; j < dBToDataTable2.Rows.Count; j++)
				{
					int key = (int)dBToDataTable2.Rows[j]["FLD_MID"];
					if (!Maplist.ContainsKey(key))
					{
						Maplist.TryAdd(key, dBToDataTable2.Rows[j]["FLD_NAME"].ToString());
					}
				}
			}
			dBToDataTable2.Dispose();
		}

		public void SetLever()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_EXP", "PublicDb");
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载经验表出错----没有经验数据");
			}
			else
			{
				lever.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					lever.GetOrAdd((int)dBToDataTable.Rows[i]["FLD_LEVEL"], (double)dBToDataTable.Rows[i]["FLD_EXP"]);
				}
				MainForm.WriteLine(2, "加载经验表完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetMover()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_VOME", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载移动出错----没有移动数据");
			}
			else
			{
				Mover.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					Mover.Add(new MoveClass
					{
						MAP = (int)dBToDataTable.Rows[i]["MAP"],
						X = float.Parse(dBToDataTable.Rows[i]["X"].ToString()),
						Y = float.Parse(dBToDataTable.Rows[i]["Y"].ToString()),
						Z = float.Parse(dBToDataTable.Rows[i]["Z"].ToString()),
						ToMAP = (int)dBToDataTable.Rows[i]["ToMAP"],
						ToX = float.Parse(dBToDataTable.Rows[i]["ToX"].ToString()),
						ToY = float.Parse(dBToDataTable.Rows[i]["ToY"].ToString()),
						ToZ = float.Parse(dBToDataTable.Rows[i]["ToZ"].ToString())
					});
				}
				MainForm.WriteLine(2, "加载移动数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetKONGFU()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_KONGFU", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载武功出错----没有武功数据");
			}
			else
			{
				TBL_KONGFU.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					武功类 武功类2 = new 武功类
					{
						FLD_NAME = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
						FLD_AT = (int)dBToDataTable.Rows[i]["FLD_AT"],
						FLD_EFFERT = (int)dBToDataTable.Rows[i]["FLD_EFFERT"],
						FLD_INDEX = (int)dBToDataTable.Rows[i]["FLD_INDEX"],
						FLD_JOB = (int)dBToDataTable.Rows[i]["FLD_JOB"],
						FLD_JOBLEVEL = (int)dBToDataTable.Rows[i]["FLD_JOBLEVEL"],
						FLD_LEVEL = (int)dBToDataTable.Rows[i]["FLD_LEVEL"],
						FLD_MP = (int)dBToDataTable.Rows[i]["FLD_MP"],
						FLD_NEEDEXP = (int)dBToDataTable.Rows[i]["FLD_NEEDEXP"],
						FLD_PID = (int)dBToDataTable.Rows[i]["FLD_PID"],
						FLD_TYPE = (int)dBToDataTable.Rows[i]["FLD_TYPE"],
						FLD_ZX = (int)dBToDataTable.Rows[i]["FLD_ZX"],
						FLD_攻击数量 = (int)dBToDataTable.Rows[i]["FLD_攻击数量"],
						FLD_武功类型 = (int)dBToDataTable.Rows[i]["FLD_武功类型"],
						FLD_每级加MP = (int)dBToDataTable.Rows[i]["FLD_每级加MP"],
						FLD_每级加历练 = (int)dBToDataTable.Rows[i]["FLD_每级加历练"],
						FLD_每级危害 = dBToDataTable.Rows[i]["FLD_每级危害"].ToString(),
						FLD_每级加危害 = (int)dBToDataTable.Rows[i]["FLD_每级加危害"],
						FLD_每级武功点数 = (int)dBToDataTable.Rows[i]["FLD_每级武功点数"],
						FLD_TIME = (int)dBToDataTable.Rows[i]["FLD_TIME"],
						FLD_DEATHTIME = (int)dBToDataTable.Rows[i]["FLD_DEATHTIME"],
						FLD_CDTIME = (int)dBToDataTable.Rows[i]["FLD_CDTIME"],
						FLD_武功最高级别 = (int)dBToDataTable.Rows[i]["FLD_武功最高级别"],
						FLD_每级加修炼等级 = (int)dBToDataTable.Rows[i]["FLD_每级加修炼等级"]
					};
					TBL_KONGFU.TryAdd(武功类2.FLD_PID, 武功类2);
				}
				MainForm.WriteLine(2, "加载武功数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public static BbgSellClass 查询百宝物品(int pid)
		{
			foreach (BbgSellClass value in 百宝阁数据.Values)
			{
				if (value.PID == pid)
				{
					return value;
				}
			}
			return null;
		}

		public void 加载百宝阁抽奖()
		{
			string sqlCommand = "SELECT * FROM tbl_award";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "BBG");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载百宝阁物品----没有百宝阁抽奖数据");
			}
			else
			{
				百宝阁抽奖物品类list.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					百宝阁类 百宝阁类2 = new 百宝阁类
					{
						PID = int.Parse(dBToDataTable.Rows[i]["id"].ToString()),
						NAME = dBToDataTable.Rows[i]["text"].ToString(),
						MAGIC0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"],
						MAGIC1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"],
						MAGIC2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"],
						MAGIC3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"],
						MAGIC4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC5"],
						觉醒 = (int)dBToDataTable.Rows[i]["FLD_初级附魂"],
						中级魂 = (int)dBToDataTable.Rows[i]["FLD_中级附魂"],
						进化 = (int)dBToDataTable.Rows[i]["FLD_进化"],
						绑定 = (int)dBToDataTable.Rows[i]["FLD_是否绑定"],
						使用天数 = (int)dBToDataTable.Rows[i]["FLD_DAYS"]
					};
					百宝阁抽奖物品类list.TryAdd(百宝阁类2.PID, 百宝阁类2);
				}
				MainForm.WriteLine(2, "加载百宝阁抽奖数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetBbgItem()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM ITEMSELL", "BBG");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载百宝阁物品----没有百宝阁数据");
			}
			else
			{
				百宝阁属性物品类list.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					百宝阁类 百宝阁类2 = new 百宝阁类
					{
						PID = (int)dBToDataTable.Rows[i]["FLD_PID"],
						NAME = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
						PRICE = long.Parse(dBToDataTable.Rows[i]["FLD_PRICE"].ToString()),
						DESC = dBToDataTable.Rows[i]["FLD_DESC"].ToString(),
						TYPE = (int)dBToDataTable.Rows[i]["FLD_TYPE"],
						RETURN = (int)dBToDataTable.Rows[i]["FLD_RETURN"],
						NUMBER = (int)dBToDataTable.Rows[i]["FLD_NUMBER"],
						MAGIC0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"],
						MAGIC1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"],
						MAGIC2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"],
						MAGIC3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"],
						MAGIC4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC5"],
						觉醒 = (int)dBToDataTable.Rows[i]["FLD_初级附魂"],
						中级魂 = (int)dBToDataTable.Rows[i]["FLD_中级附魂"],
						进化 = (int)dBToDataTable.Rows[i]["FLD_进化"],
						绑定 = (int)dBToDataTable.Rows[i]["FLD_是否绑定"],
						使用天数 = (int)dBToDataTable.Rows[i]["FLD_DAYS"],
						是否锁定 = (int)dBToDataTable.Rows[i]["FLD_是否锁定"]
					};
					百宝阁属性物品类list.TryAdd(百宝阁类2.PID, 百宝阁类2);
				}
				MainForm.WriteLine(2, "加载百宝阁数据完成" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetItme()
		{
			int num = 0;
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_ITEM", "PublicDb");
				if (dBToDataTable == null)
				{
					return;
				}
				if (dBToDataTable.Rows.Count == 0)
				{
					MainForm.WriteLine(2, "加载物品出错----没有物品数据");
				}
				else
				{
					PVP装备.Clear();
					Itme.Clear();
					for (int i = 0; i < dBToDataTable.Rows.Count; i++)
					{
						try
						{
							ItmeClass itmeClass = new ItmeClass();
							int num2 = (int)dBToDataTable.Rows[i]["FLD_NJ"];
							itmeClass.FLD_AT = (int)dBToDataTable.Rows[i]["FLD_AT1"];
							itmeClass.FLD_AT_Max = (int)dBToDataTable.Rows[i]["FLD_AT2"];
							itmeClass.FLD_DF = (int)dBToDataTable.Rows[i]["FLD_DF"];
							itmeClass.FLD_RESIDE1 = (int)dBToDataTable.Rows[i]["FLD_RESIDE1"];
							itmeClass.FLD_RESIDE2 = (int)dBToDataTable.Rows[i]["FLD_RESIDE2"];
							itmeClass.FLD_JOB_LEVEL = (int)dBToDataTable.Rows[i]["FLD_JOB_LEVEL"];
							itmeClass.FLD_LEVEL = (int)dBToDataTable.Rows[i]["FLD_LEVEL"];
							itmeClass.FLD_RECYCLE_MONEY = (int)dBToDataTable.Rows[i]["FLD_RECYCLE_MONEY"];
							itmeClass.FLD_SALE_MONEY = (int)dBToDataTable.Rows[i]["FLD_SALE_MONEY"];
							itmeClass.FLD_PID = int.Parse(dBToDataTable.Rows[i]["FLD_PID"].ToString());
							itmeClass.FLD_SEX = (int)dBToDataTable.Rows[i]["FLD_SEX"];
							itmeClass.FLD_WEIGHT = (int)dBToDataTable.Rows[i]["FLD_WEIGHT"];
							itmeClass.FLD_ZX = (int)dBToDataTable.Rows[i]["FLD_ZX"];
							itmeClass.FLD_SIDE = (int)dBToDataTable.Rows[i]["FLD_SIDE"];
							itmeClass.FLD_MAGIC0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"];
							itmeClass.FLD_MAGIC1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"];
							itmeClass.FLD_MAGIC2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"];
							itmeClass.FLD_MAGIC3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"];
							itmeClass.FLD_MAGIC4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC5"];
							itmeClass.FLD_UP_LEVEL = (int)dBToDataTable.Rows[i]["FLD_UP_LEVEL"];
							itmeClass.FLD_XW = (int)dBToDataTable.Rows[i]["FLD_WX"];
							itmeClass.FLD_XWJD = (int)dBToDataTable.Rows[i]["FLD_WXJD"];
							itmeClass.FLD_TYPE = (int)dBToDataTable.Rows[i]["FLD_TYPE"];
							itmeClass.FLD_QUESTITEM = (int)dBToDataTable.Rows[i]["FLD_QUESTITEM"];
							itmeClass.ItmeNAME = dBToDataTable.Rows[i]["FLD_NAME"].ToString();
							itmeClass.FLD_NJ = num2;
							itmeClass.FLD_LOCK = (int)dBToDataTable.Rows[i]["FLD_LOCK"];
							itmeClass.FLD_NEED_MONEY = (int)dBToDataTable.Rows[i]["FLD_NEED_MONEY"];
							itmeClass.FLD_NEED_FIGHTEXP = (int)dBToDataTable.Rows[i]["FLD_NEED_FIGHTEXP"];
							itmeClass.FLD_INTEGRATION = (int)dBToDataTable.Rows[i]["FLD_INTEGRATION"];
							itmeClass.FLD_SERIES = (int)dBToDataTable.Rows[i]["FLD_SERIES"];
							itmeClass.FLD_HEAD_WEAR = (int)dBToDataTable.Rows[i]["FLD_HEAD_WEAR"];
							itmeClass.ItmeDES = dBToDataTable.Rows[i]["FLD_ZBSJ"].ToString();
							itmeClass.FLD_YCHP = (int)dBToDataTable.Rows[i]["FLD_YCHP"];
							itmeClass.FLD_YCAT = (int)dBToDataTable.Rows[i]["FLD_YCAT"];
							itmeClass.FLD_YCDF = (int)dBToDataTable.Rows[i]["FLD_YCDF"];
							num = itmeClass.FLD_PID;
							Itme.TryAdd(itmeClass.FLD_PID, itmeClass);
							if (num2 == 1000)
							{
								PVP类 pVP类 = new PVP类
								{
									物品ID = int.Parse(dBToDataTable.Rows[i]["FLD_PID"].ToString()),
									物品类型 = (int)dBToDataTable.Rows[i]["FLD_RESIDE2"],
									物品等级 = (int)dBToDataTable.Rows[i]["FLD_LEVEL"]
								};
								PVP装备.TryAdd(pVP类.物品ID, pVP类);
							}
							foreach (百宝阁类 value in 百宝阁属性物品类list.Values)
							{
								if (num == value.PID)
								{
									itmeClass.FLD_LOCK = value.是否锁定;
								}
							}
						}
						catch (Exception ex)
						{
							MainForm.WriteLine(1, num + "|" + ex.Message);
						}
					}
					MainForm.WriteLine(2, "加载物品数据完成" + dBToDataTable.Rows.Count);
				}
				dBToDataTable.Dispose();
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, num + "|" + ex2.Message);
			}
		}

        /// <summary>
        /// โหลดข้อมูลร้านค้าแบบ LINQ (สำหรับข้อมูลจำนวนมาก)
        /// </summary>
        public void LoadShopData()
        {
            // ใช้ using statement เพื่อจัดการ resource อัตโนมัติ
            using (var dataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_SELL ORDER BY FLD_INDEX", "PublicDb"))
            {
                // ตรวจสอบว่ามีข้อมูลร้านค้าหรือไม่
                if (dataTable?.Rows.Count == 0)
                {
                    MainForm.WriteLine(2, "No shop data found");
                    return;
                }

                try
                {
                    // ล้างข้อมูลเก่า
                    Shop.Clear();

                    // ใช้ LINQ เพื่อแปลงข้อมูลและกรองข้อมูลที่ถูกต้อง
                    var validItems = dataTable.Rows.Cast<DataRow>()                      // แปลง DataRowCollection เป็น IEnumerable<DataRow>
                        .Select(row => CreateShopItem(row))                              // สร้างออบเจ็กต์สินค้าจากแต่ละแถว
                        .Where(item => item != null)                                     // กรองเฉพาะข้อมูลที่ไม่เป็น null
                        .ToList();                                                       // แปลงเป็น List

                    // เพิ่มสินค้าที่ถูกต้องทั้งหมดลงในร้านค้า
                    Shop.AddRange(validItems);

                    // แสดงผลสรุปการโหลดข้อมูลร้านค้า
                    MainForm.WriteLine(2, "Shop data loaded: " + validItems.Count + "/" + dataTable.Rows.Count + " items");
                }
                catch (Exception ex)
                {
                    // จัดการ error ระดับ method
                    MainForm.WriteLine(1, "Error loading shop data: " + ex.Message);
                }
            }
        }

        // Helper method สำหรับสร้างออบเจ็กต์ ShopClass
        private ShopClass CreateShopItem(DataRow row)
        {
            try
            {
                // สร้างออบเจ็กต์สินค้าในร้านจากข้อมูลในแถว
                return new ShopClass
                {
                    NpcId = Convert.ToInt32(row["FLD_NID"]),              // รหัส NPC เจ้าของร้าน
                    ItemIndex = Convert.ToInt32(row["FLD_INDEX"]),        // รหัสไอเทม
                    PlayerId = Convert.ToInt32(row["FLD_PID"]),           // รหัสผู้เล่น
                    Price = Convert.ToInt64(row["FLD_MONEY"]),            // ราคาสินค้า
                    MagicProperty0 = Convert.ToInt32(row["FLD_MAGIC0"]),  // คุณสมบัติพิเศษ
                    MagicProperty1 = Convert.ToInt32(row["FLD_MAGIC1"]),
                    MagicProperty2 = Convert.ToInt32(row["FLD_MAGIC2"]),
                    MagicProperty3 = Convert.ToInt32(row["FLD_MAGIC3"]),
                    MagicProperty4 = Convert.ToInt32(row["FLD_MAGIC4"]),
                    RequiredWarMerit = Convert.ToInt32(row["FLD_需要武勋"]), // คะแนนการรบที่ต้องการ
                    RequiredIceJade = Convert.ToInt32(row["FLD_冰魄水玉"])    // วัสดุหายากที่ต้องการ
                };
            }
            catch
            {
                // ถ้าข้อมูลไม่ถูกต้อง ให้คืนค่า null
                return null; // Invalid data
            }
        }

        public void LoadGuildWarData()
        {
            var query = "SELECT * FROM 门战胜利门派 WHERE 分区信息 = @zoneNumber";

            using var dataTable = DBA.GetDBToDataTable(query.Replace("@zoneNumber", $"'{ZoneNumber}'"), "GameServer");
            if (dataTable?.Rows.Count == 0) return;

            guildWarDataList.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                var warData = new GuildWarData
                {
                    ID = (int)row["帮派ID"],
                    GuildName = row["门派名字"].ToString(),
                    WarTime = DateTime.Parse(row["胜利时间"].ToString()),
                    RewardTime = DateTime.Parse(row["胜利奖励时间"].ToString()),
                    LeaderName = row["门主名字"].ToString()
                };

                guildWarDataList.TryAdd(warData.ID, warData);
            }
        }

        public void LoadCraftingItems()
        {
            using var dataTable = DBA.GetDBToDataTable("SELECT * FROM 制作物品列表 ORDER BY 物品ID", "PublicDb");
            if (dataTable?.Rows.Count == 0)
            {
                ComprehensiveLogger.WriteSystem("โหลดข้อมูลไอเทมคราฟต์เสร็จ - ไม่มีข้อมูลไอเทมคราฟต์");
                return;
            }

            craftingItemsList.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    var craftingItem = new CraftingItem
                    {
                        ItemID = (int)row["物品ID"],
                        ItemName = row["物品名"].ToString(),
                        ItemQuantity = (int)row["物品数量"],
                        CraftType = (int)row["制作类型"],
                        CraftLevel = (int)row["制作等级"],
                        RequiredItems = ParseRequiredItems(row["需要物品"].ToString())
                    };

                    craftingItemsList.TryAdd(craftingItem.ItemID, craftingItem);
                }
                catch (Exception ex)
                {
                    var itemId = row["物品ID"]?.ToString() ?? "Unknown";
                    ComprehensiveLogger.WriteError($"โหลดไอเทมคราฟต์ผิดพลาด ItemID: {itemId} - {ex.Message}");
                }
            }
        }

        private List<RequiredItem> ParseRequiredItems(string requiredItemsData)
        {
            return requiredItemsData
                .Split('|')
                .Where(item => !string.IsNullOrEmpty(item))
                .Select(item =>
                {
                    var parts = item.Split(',');
                    return new RequiredItem
                    {
                        Id = int.Parse(parts[0]),
                        Number = int.Parse(parts[1])
                    };
                })
                .ToList();
        }

        public static NpcClass AddNpc2(int monsterId, float x, float y, int mapId, bool isOneTimeMonster, int respawnTime)
		{
			try
			{

				if (MonSter.TryGetValue(monsterId, out var monsterTemplate))
				{
					NpcClass npcClass = new NpcClass
					{
						FLD_PID = monsterTemplate.FLD_PID,
						Name = monsterTemplate.Name,
						Level = monsterTemplate.Level,
						Rxjh_Exp = monsterTemplate.Rxjh_Exp,
						X = x,
						Y = y,
						Z = 15f,
						Rxjh_cs_X = x,
						Rxjh_cs_Y = y,
						Rxjh_cs_Z = 15f,
						Rxjh_Map = mapId,
						IsNpc = 0,
						FLD_FACE1 = 0f,
						FLD_FACE2 = 0f,
						Max_Rxjh_HP = monsterTemplate.Rxjh_HP,
						Rxjh_HP = monsterTemplate.Rxjh_HP,
						FLD_AT = monsterTemplate.FLD_AT,
						FLD_DF = monsterTemplate.FLD_DF,
						FLD_AUTO = monsterTemplate.FLD_AUTO,
						FLD_BOSS = ((mapId == 101 || mapId == 41001 || mapId == 29000) ? 1 : monsterTemplate.FLD_BOSS),
						FLD_NEWTIME = respawnTime,
						isOneTimeMonster = isOneTimeMonster
					};
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						MapClass mapClass = new MapClass
						{
							MapID = npcClass.Rxjh_Map
						};
						mapClass.add(npcClass);
						Map.TryAdd(mapClass.MapID, mapClass);
					}
					return npcClass;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "增加怪 [" + monsterId + "]出错：" + ex);
			}
			return null;
		}

		public void SetDrop()
		{
			try
			{
				DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_DROP ORDER BY FLD_LEVEL1, FLD_LEVEL2", "PublicDb");
				if (dBToDataTable == null)
				{
					return;
				}
				if (dBToDataTable.Rows.Count == 0)
				{
					MainForm.WriteLine(2, "加载掉落物品完成----没有物品数据");
				}
				else
				{
					Drop.Clear();
					for (int i = 0; i < dBToDataTable.Rows.Count; i++)
					{
						DropClass dropClass = new DropClass();
						try
						{
							dropClass.ID = (int)dBToDataTable.Rows[i]["ID"];
							dropClass.FLD_LEVEL1 = (int)dBToDataTable.Rows[i]["FLD_LEVEL1"];
							dropClass.FLD_LEVEL2 = (int)dBToDataTable.Rows[i]["FLD_LEVEL2"];
							dropClass.FLD_PID = (int)dBToDataTable.Rows[i]["FLD_PID"];
							dropClass.FLD_PIDNew = (int)dBToDataTable.Rows[i]["FLD_PID"];
							dropClass.FLD_PP = (int)dBToDataTable.Rows[i]["FLD_PP"];
							dropClass.FLD_NAME = dBToDataTable.Rows[i]["FLD_NAME"].ToString();
							dropClass.FLD_MAGIC0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC0"];
							dropClass.FLD_MAGIC1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"];
							dropClass.FLD_MAGIC2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"];
							dropClass.FLD_MAGIC3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"];
							dropClass.FLD_MAGIC4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"];
							dropClass.FLD_初级附魂 = (int)dBToDataTable.Rows[i]["FLD_初级附魂"];
							dropClass.FLD_中级附魂 = (int)dBToDataTable.Rows[i]["FLD_中级附魂"];
							dropClass.FLD_进化 = (int)dBToDataTable.Rows[i]["FLD_进化"];
							dropClass.FLD_绑定 = (int)dBToDataTable.Rows[i]["FLD_绑定"];
							dropClass.FLD_MAGICNew0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC0"];
							dropClass.FLD_MAGICNew1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"];
							dropClass.FLD_MAGICNew2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"];
							dropClass.FLD_MAGICNew3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"];
							dropClass.FLD_MAGICNew4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"];
							dropClass.是否开启公告 = (int)dBToDataTable.Rows[i]["是否开启公告"];
							dropClass.会员掉落 = (int)dBToDataTable.Rows[i]["会员掉落"];
							dropClass.MAPID = (int)dBToDataTable.Rows[i]["掉落地图ID"];
							dropClass.NPCPID = (int)dBToDataTable.Rows[i]["掉落怪物ID"];
							dropClass.数量控制 = (int)dBToDataTable.Rows[i]["数量控制"];
							dropClass.当前数量 = (int)dBToDataTable.Rows[i]["当前数量"];
							dropClass.最大数量 = (int)dBToDataTable.Rows[i]["最大数量"];
							Drop.Add(dropClass);
						}
						catch (Exception ex)
						{
							MainForm.WriteLine(1, "加载掉落物品 错误" + dropClass.FLD_NAME + " " + ex.Message);
						}
					}
					MainForm.WriteLine(2, "加载掉落物品 " + dBToDataTable.Rows.Count);
				}
				dBToDataTable.Dispose();
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "加载掉落物品 错误" + ex2.Message);
			}
		}

		public void Set_GSDrop()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_DROP_GS ORDER BY FLD_LEVEL1, FLD_LEVEL2", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				BossDrop.Clear();
				MainForm.WriteLine(2, "加载高手怪掉落物品完成----没有物品数据");
			}
			else
			{
				Drop_GS.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					DropClass dropClass = new DropClass();
					try
					{
						dropClass.FLD_LEVEL1 = (int)dBToDataTable.Rows[i]["FLD_LEVEL1"];
						dropClass.FLD_LEVEL2 = (int)dBToDataTable.Rows[i]["FLD_LEVEL2"];
						dropClass.FLD_PID = (int)dBToDataTable.Rows[i]["FLD_PID"];
						dropClass.FLD_PP = (int)dBToDataTable.Rows[i]["FLD_PP"];
						dropClass.FLD_PIDNew = (int)dBToDataTable.Rows[i]["FLD_PID"];
						dropClass.FLD_NAME = dBToDataTable.Rows[i]["FLD_NAME"].ToString();
						dropClass.FLD_MAGIC0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC0"];
						dropClass.FLD_MAGIC1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"];
						dropClass.FLD_MAGIC2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"];
						dropClass.FLD_MAGIC3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"];
						dropClass.FLD_MAGIC4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"];
						dropClass.FLD_初级附魂 = (int)dBToDataTable.Rows[i]["FLD_初级附魂"];
						dropClass.FLD_中级附魂 = (int)dBToDataTable.Rows[i]["FLD_中级附魂"];
						dropClass.FLD_进化 = (int)dBToDataTable.Rows[i]["FLD_进化"];
						dropClass.FLD_绑定 = (int)dBToDataTable.Rows[i]["FLD_绑定"];
						dropClass.FLD_MAGICNew0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC0"];
						dropClass.FLD_MAGICNew1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"];
						dropClass.FLD_MAGICNew2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"];
						dropClass.FLD_MAGICNew3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"];
						dropClass.FLD_MAGICNew4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"];
						dropClass.是否开启公告 = (int)dBToDataTable.Rows[i]["是否开启公告"];
						dropClass.会员掉落 = (int)dBToDataTable.Rows[i]["会员掉落"];
						dropClass.MAPID = (int)dBToDataTable.Rows[i]["掉落地图ID"];
						dropClass.NPCPID = (int)dBToDataTable.Rows[i]["掉落怪物ID"];
						Drop_GS.Add(dropClass);
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "加载掉落物品 错误" + dropClass.FLD_NAME + " " + ex.Message);
					}
				}
				MainForm.WriteLine(2, "加载高手怪落物品 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetBossDrop()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_BossDROP ORDER BY FLD_LEVEL1, FLD_LEVEL2", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				BossDrop.Clear();
				MainForm.WriteLine(2, "加载BOSS掉落物品完成----没有物品数据");
			}
			else
			{
				BossDrop.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					DropClass dropClass = new DropClass();
					try
					{
						dropClass.FLD_LEVEL1 = (int)dBToDataTable.Rows[i]["FLD_LEVEL1"];
						dropClass.FLD_LEVEL2 = (int)dBToDataTable.Rows[i]["FLD_LEVEL2"];
						dropClass.FLD_PID = (int)dBToDataTable.Rows[i]["FLD_PID"];
						dropClass.FLD_PIDNew = (int)dBToDataTable.Rows[i]["FLD_PID"];
						dropClass.FLD_PP = (int)dBToDataTable.Rows[i]["FLD_PP"];
						dropClass.FLD_NAME = dBToDataTable.Rows[i]["FLD_NAME"].ToString();
						dropClass.FLD_MAGIC0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC0"];
						dropClass.FLD_MAGIC1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"];
						dropClass.FLD_MAGIC2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"];
						dropClass.FLD_MAGIC3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"];
						dropClass.FLD_MAGIC4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"];
						dropClass.FLD_初级附魂 = (int)dBToDataTable.Rows[i]["FLD_初级附魂"];
						dropClass.FLD_中级附魂 = (int)dBToDataTable.Rows[i]["FLD_中级附魂"];
						dropClass.FLD_进化 = (int)dBToDataTable.Rows[i]["FLD_进化"];
						dropClass.FLD_绑定 = (int)dBToDataTable.Rows[i]["FLD_绑定"];
						dropClass.FLD_MAGICNew0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC0"];
						dropClass.FLD_MAGICNew1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"];
						dropClass.FLD_MAGICNew2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"];
						dropClass.FLD_MAGICNew3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"];
						dropClass.FLD_MAGICNew4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"];
						dropClass.是否开启公告 = (int)dBToDataTable.Rows[i]["是否开启公告"];
						dropClass.会员掉落 = (int)dBToDataTable.Rows[i]["会员掉落"];
						dropClass.MAPID = (int)dBToDataTable.Rows[i]["掉落地图ID"];
						dropClass.NPCPID = (int)dBToDataTable.Rows[i]["掉落怪物ID"];
						try
						{
							if (dBToDataTable.Rows[0]["FLD_SUNX"] != DBNull.Value && dBToDataTable.Rows[i]["FLD_SUNX"].ToString().Length != 0)
							{
								string value = dBToDataTable.Rows[i]["FLD_SUNX"].ToString();
								dropClass.DropShuX = JsonConvert.DeserializeObject<List<DropShuXClass>>(value);
							}
						}
						catch
						{
						}
						BossDrop.Add(dropClass);
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "加载掉落物品 错误" + dropClass.FLD_NAME + " " + ex.Message);
					}
				}
				MainForm.WriteLine(2, "加载BOSS掉落物品 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetOpen()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_OPEN", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载开箱物品完成----没有开箱物品数据");
			}
			else
			{
				Open.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					Open.Add(new OpenClass
					{
						FLD_PID = (int)dBToDataTable.Rows[i]["FLD_PID"],
						FLD_PIDX = (int)dBToDataTable.Rows[i]["FLD_PIDX"],
						FLD_NUMBER = (int)dBToDataTable.Rows[i]["FLD_NUMBER"],
						FLD_MAGIC1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"],
						FLD_MAGIC2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"],
						FLD_MAGIC3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"],
						FLD_MAGIC4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"],
						FLD_MAGIC5 = (int)dBToDataTable.Rows[i]["FLD_MAGIC5"],
						FLD_觉醒 = (int)dBToDataTable.Rows[i]["FLD_FJ_觉醒"],
						FLD_进化 = (int)dBToDataTable.Rows[i]["FLD_FJ_进化"],
						FLD_中级附魂 = (int)dBToDataTable.Rows[i]["FLD_FJ_中级附魂"],
						FLD_BD = (int)dBToDataTable.Rows[i]["FLD_BD"],
						FLD_DAYS = (int)dBToDataTable.Rows[i]["FLD_DAYS"],
						FLD_PP = (int)dBToDataTable.Rows[i]["FLD_PP"],
						FLD_NAME = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
						是否开启公告 = (int)dBToDataTable.Rows[i]["是否开启公告"],
						FLD_NAMEX = dBToDataTable.Rows[i]["FLD_NAMEX"].ToString()
					});
				}
				MainForm.WriteLine(2, "加载开箱物品 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public static bool 检查物品是否被锁定(int int_0)
		{
			string[] array = 物品锁定.Split(',');
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (array[num] == int_0.ToString())
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		public void 充值排行()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT TOP 1 * FROM TBL_XWWL_Char where FLD_FQID='" + ZoneNumber + "' and FLD_CZPH !=0 Order By FLD_CZPH Desc"), "GameServer");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(1, "加载充值排行----没有充值排行数据");
			}
			else
			{
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					赞助大使名字 = dBToDataTable.Rows[i]["FLD_NAME"].ToString();
				}
			}
			dBToDataTable.Dispose();
		}

		public void LoadGuildHonorRankings()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT TOP 10 * FROM 荣誉门派排行 where FLD_FQ='" + ZoneNumber + "' Order By FLD_RY Desc"), "GameServer");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				门派排名数据.Clear();
				MainForm.WriteLine(1, "加载荣誉门派排行----没有荣誉门派排行数据");
			}
			else
			{
				门派排名数据.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					门派排名 item = new 门派排名
					{
						门派帮派名 = dBToDataTable.Rows[i]["FLD_BP"].ToString(),
						门派人物名 = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
						门派正邪 = (int)dBToDataTable.Rows[i]["FLD_ZX"],
						门派职业 = (int)dBToDataTable.Rows[i]["FLD_JOB"],
						门派转职 = (int)dBToDataTable.Rows[i]["FLD_JOB_LEVEL"],
						门派人物等级 = (int)dBToDataTable.Rows[i]["FLD_LEVEL"],
						门派荣誉点 = (int)dBToDataTable.Rows[i]["FLD_RY"],
						门派分区ID = dBToDataTable.Rows[i]["FLD_FQ"].ToString()
					};
					门派排名数据.Add(item);
				}
			}
			dBToDataTable.Dispose();
		}

		public void 荣誉势力排行()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT TOP 10 * FROM 荣誉势力排行 where FLD_FQ='" + ZoneNumber + "' Order By FLD_RY Desc"), "GameServer");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				势力排名数据.Clear();
				MainForm.WriteLine(1, "加载荣誉势力排行----没有荣誉势力排行数据");
			}
			else
			{
				势力排名数据.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					势力排名 item = new 势力排名
					{
						势力帮派名 = dBToDataTable.Rows[i]["FLD_BP"].ToString(),
						势力人物名 = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
						势力正邪 = (int)dBToDataTable.Rows[i]["FLD_ZX"],
						势力职业 = (int)dBToDataTable.Rows[i]["FLD_JOB"],
						势力人物等级 = (int)dBToDataTable.Rows[i]["FLD_LEVEL"],
						势力转职 = (int)dBToDataTable.Rows[i]["FLD_JOB_LEVEL"],
						势力荣誉点 = (int)dBToDataTable.Rows[i]["FLD_RY"],
						势力分区ID = dBToDataTable.Rows[i]["FLD_FQ"].ToString()
					};
					势力排名数据.Add(item);
				}
			}
			dBToDataTable.Dispose();
		}

		public void 荣誉武林排行()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT TOP 10 * FROM 荣誉武林排行 where FLD_FQ='" + ZoneNumber + "' Order By FLD_RY Desc"), "GameServer");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				武林排名数据.Clear();
				MainForm.WriteLine(1, "加载荣誉武林排行----没有荣誉武林排行数据");
			}
			else
			{
				武林排名数据.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					武林排名 item = new 武林排名
					{
						武林帮派名 = dBToDataTable.Rows[i]["FLD_BP"].ToString(),
						武林人物名 = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
						武林正邪 = (int)dBToDataTable.Rows[i]["FLD_ZX"],
						武林职业 = (int)dBToDataTable.Rows[i]["FLD_JOB"],
						武林人物等级 = (int)dBToDataTable.Rows[i]["FLD_LEVEL"],
						武林转职 = (int)dBToDataTable.Rows[i]["FLD_JOB_LEVEL"],
						武林荣誉点 = (int)dBToDataTable.Rows[i]["FLD_RY"],
						武林分区ID = dBToDataTable.Rows[i]["FLD_FQ"].ToString()
					};
					武林排名数据.Add(item);
				}
			}
			dBToDataTable.Dispose();
		}

		public void 荣誉讨伐排行()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable(string.Format("SELECT TOP 10 * FROM 荣誉讨伐排行 where FLD_FQ='" + ZoneNumber + "' Order By FLD_RY Desc"), "GameServer");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				讨伐排名数据.Clear();
				MainForm.WriteLine(1, "加载荣誉讨伐排行----没有荣誉武林排行数据");
			}
			else
			{
				讨伐排名数据.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					讨伐排名 item = new 讨伐排名
					{
						讨伐帮派名 = dBToDataTable.Rows[i]["FLD_BP"].ToString(),
						讨伐人物名 = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
						讨伐正邪 = (int)dBToDataTable.Rows[i]["FLD_ZX"],
						讨伐职业 = (int)dBToDataTable.Rows[i]["FLD_JOB"],
						讨伐人物等级 = (int)dBToDataTable.Rows[i]["FLD_LEVEL"],
						讨伐转职 = (int)dBToDataTable.Rows[i]["FLD_JOB_LEVEL"],
						讨伐荣誉点 = (int)dBToDataTable.Rows[i]["FLD_RY"],
						讨伐分区ID = dBToDataTable.Rows[i]["FLD_FQ"].ToString()
					};
					讨伐排名数据.Add(item);
				}
			}
			dBToDataTable.Dispose();
		}

		public void boss攻城怪物()
		{
			攻城怪物列表.Clear();
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_攻城BOSS", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载攻城BOSS数据出错----没有攻城BOSS数据");
			}
			else
			{
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					try
					{
						int num = (int)dBToDataTable.Rows[i]["FLD_PID"];
						if (MonSter.TryGetValue(num, out var _) && num >= 10000)
						{
							攻城怪物 攻城怪物2 = new 攻城怪物
							{
								FLD_PID = num,
								MonsterId = (int)dBToDataTable.Rows[i]["FLD_MID"],
								FLD_X = (int)dBToDataTable.Rows[i]["FLD_X"],
								FLD_Y = (int)dBToDataTable.Rows[i]["FLD_Y"]
							};
							攻城怪物 item = 攻城怪物2;
							攻城怪物列表.Add(item);
						}
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "加载攻城BOSS数据 出错：" + ex);
					}
				}
				MainForm.WriteLine(2, "加载攻城BOSS数据完成 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void boss伏魔洞怪物()
		{
			伏魔洞怪物列表.Clear();
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_伏魔洞", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载伏魔洞数据出错----没有伏魔洞数据");
			}
			else
			{
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					try
					{
						int num = (int)dBToDataTable.Rows[i]["FLD_PID"];
						if (MonSter.TryGetValue(num, out var _) && num >= 10000)
						{
							伏魔洞怪物 伏魔洞怪物2 = new 伏魔洞怪物
							{
								FLD_PID = num,
								FLD_MID = (int)dBToDataTable.Rows[i]["FLD_MID"],
								FLD_X = (int)dBToDataTable.Rows[i]["FLD_X"],
								FLD_Y = (int)dBToDataTable.Rows[i]["FLD_Y"]
							};
							伏魔洞怪物 item = 伏魔洞怪物2;
							伏魔洞怪物列表.Add(item);
						}
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "加载伏魔洞数据 出错：" + ex);
					}
				}
				MainForm.WriteLine(2, "加载伏魔洞数据完成 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void Set套装()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM ITMECLSS", "WebDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载套装物品完成----没有套装物品数据");
			}
			else
			{
				套装数据.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					套装数据.Add(new ItemSellClass
					{
						ID = (int)dBToDataTable.Rows[i]["ID"],
						Type = (int)dBToDataTable.Rows[i]["FLD_TYPE"],
						Reside = (int)dBToDataTable.Rows[i]["FLD_RESIDE"],
						name = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
						sql = dBToDataTable.Rows[i]["FLD_SQL"].ToString(),
						Magic0 = (int)dBToDataTable.Rows[i]["FLD_MAGIC0"],
						Magic1 = (int)dBToDataTable.Rows[i]["FLD_MAGIC1"],
						Magic2 = (int)dBToDataTable.Rows[i]["FLD_MAGIC2"],
						Magic3 = (int)dBToDataTable.Rows[i]["FLD_MAGIC3"],
						Magic4 = (int)dBToDataTable.Rows[i]["FLD_MAGIC4"],
						Magic5 = (int)dBToDataTable.Rows[i]["FLD_MAGIC5"],
						NJ = (int)dBToDataTable.Rows[i]["FLD_FJ_NJ"],
						DAYS = (int)dBToDataTable.Rows[i]["FLD_DAYS"],
						进化 = (int)dBToDataTable.Rows[i]["FLD_FJ_进化"],
						觉醒 = (int)dBToDataTable.Rows[i]["FLD_FJ_觉醒"],
						中级附魂 = (int)dBToDataTable.Rows[i]["FLD_FJ_中级附魂"],
						BD = (int)dBToDataTable.Rows[i]["FLD_BD"]
					});
				}
				MainForm.WriteLine(2, "加载套装物品 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void Set升天气功()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM 升天气功 ORDER BY 气功ID", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载升天气功完成----没有升天气功数据");
			}
			else
			{
				升天气功List.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					升天气功总类 升天气功总类2 = new 升天气功总类
					{
						气功ID = (int)dBToDataTable.Rows[i]["气功ID"],
						气功名 = dBToDataTable.Rows[i]["气功名"].ToString(),
						物品ID = (int)dBToDataTable.Rows[i]["物品ID"],
						人物职业1 = (int)dBToDataTable.Rows[i]["人物职业1"],
						人物职业2 = (int)dBToDataTable.Rows[i]["人物职业2"],
						人物职业3 = (int)dBToDataTable.Rows[i]["人物职业3"],
						人物职业4 = (int)dBToDataTable.Rows[i]["人物职业4"],
						人物职业5 = (int)dBToDataTable.Rows[i]["人物职业5"],
						人物职业6 = (int)dBToDataTable.Rows[i]["人物职业6"],
						人物职业7 = (int)dBToDataTable.Rows[i]["人物职业7"],
						人物职业8 = (int)dBToDataTable.Rows[i]["人物职业8"],
						人物职业9 = (int)dBToDataTable.Rows[i]["人物职业9"],
						人物职业10 = (int)dBToDataTable.Rows[i]["人物职业10"],
						人物职业11 = (int)dBToDataTable.Rows[i]["人物职业11"],
						人物职业12 = (int)dBToDataTable.Rows[i]["人物职业12"],
						人物职业13 = (int)dBToDataTable.Rows[i]["人物职业13"],
						FLD_每点加成比率值 = (double)dBToDataTable.Rows[i]["FLD_每点加成比率值"]
					};
					升天气功List.TryAdd(升天气功总类2.气功ID, 升天气功总类2);
				}
				MainForm.WriteLine(2, "加载升天气功 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetMonSter()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_MONSTER", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载怪物数据完成----没有怪物数据");
			}
			else
			{
				MonSter.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					try
					{
						botCoord monSterClss = new botCoord
						{
							FLD_PID = (int)dBToDataTable.Rows[i]["FLD_PID"],
							FLD_AT = (int)dBToDataTable.Rows[i]["FLD_AT"],
							FLD_AUTO = (int)dBToDataTable.Rows[i]["FLD_AUTO"],
							FLD_BOSS = (int)dBToDataTable.Rows[i]["FLD_BOSS"],
							FLD_DF = (int)dBToDataTable.Rows[i]["FLD_DF"],
							Level = (int)dBToDataTable.Rows[i]["FLD_LEVEL"],
							Name = dBToDataTable.Rows[i]["FLD_NAME"].ToString(),
							Rxjh_Exp = (int)dBToDataTable.Rows[i]["FLD_EXP"],
							Rxjh_HP = (int)dBToDataTable.Rows[i]["FLD_HP"],
							FLD_NPC = (int)dBToDataTable.Rows[i]["FLD_NPC"],
							FLD_QUEST = (int)dBToDataTable.Rows[i]["FLD_QUEST"],
							FLD_QUESTID = (int)dBToDataTable.Rows[i]["FLD_QUESTID"],
							FLD_STAGES = (int)dBToDataTable.Rows[i]["FLD_STAGES"],
							FLD_QUESTITEM = (int)dBToDataTable.Rows[i]["FLD_QUESTITEM"],
							FLD_PP = (int)dBToDataTable.Rows[i]["FLD_PP"]
						};
						MonSter.TryAdd(monSterClss.FLD_PID, monSterClss);
						if (Map == null || Map.Count <= 0)
						{
							continue;
						}
						foreach (MapClass value in Map.Values)
						{
							foreach (NpcClass value2 in value.npcTemplate.Values)
							{
								if (value2.FLD_PID == monSterClss.FLD_PID)
								{
									value2.FLD_AT = monSterClss.FLD_AT;
									value2.FLD_DF = monSterClss.FLD_DF;
									value2.Rxjh_Exp = monSterClss.Rxjh_Exp;
									value2.FLD_AUTO = monSterClss.FLD_AUTO;
									value2.FLD_BOSS = monSterClss.FLD_BOSS;
									value2.Level = monSterClss.Level;
									value2.Rxjh_HP = monSterClss.Rxjh_HP;
								}
							}
						}
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "加载怪物数据 出错：" + ex);
					}
				}
				MainForm.WriteLine(2, "加载怪物数据完成 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public void SetNpc()
		{
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_NPC", "PublicDb");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "加载NPC数据出错----没有NPC数据");
			}
			else
			{
				Map.Clear();
				NpcList.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					try
					{
						NpcClass npcClass = new NpcClass
						{
							FLD_PID = (int)dBToDataTable.Rows[i]["FLD_PID"]
						};
						if (MonSter.TryGetValue(npcClass.FLD_PID, out var value) && npcClass.FLD_PID >= 10000)
						{
							npcClass.Name = value.Name;
							npcClass.Level = value.Level;
							npcClass.Rxjh_Exp = value.Rxjh_Exp;
							npcClass.IsNpc = value.FLD_NPC;
							npcClass.Max_Rxjh_HP = value.Rxjh_HP;
							npcClass.Rxjh_HP = value.Rxjh_HP;
							npcClass.FLD_AT = value.FLD_AT;
							npcClass.FLD_DF = value.FLD_DF;
							npcClass.FLD_AUTO = value.FLD_AUTO;
							npcClass.FLD_BOSS = value.FLD_BOSS;
							npcClass.FLD_NEWTIME = (int)dBToDataTable.Rows[i]["FLD_NEWTIME"];
						}
						else
						{
							npcClass.Name = dBToDataTable.Rows[i]["FLD_NAME"].ToString();
							npcClass.Level = 0;
							npcClass.Rxjh_Exp = 0;
							npcClass.IsNpc = 1;
							npcClass.Max_Rxjh_HP = 32000;
							npcClass.Rxjh_HP = 32000;
							npcClass.FLD_AT = 0.0;
							npcClass.FLD_DF = 0.0;
							npcClass.FLD_AUTO = 0;
							npcClass.FLD_BOSS = 0;
							npcClass.FLD_NEWTIME = 0;
						}
						npcClass.Rxjh_Map = (int)dBToDataTable.Rows[i]["FLD_MID"];
						npcClass.FLD_FACE1 = float.Parse(dBToDataTable.Rows[i]["FLD_FACE0"].ToString());
						npcClass.FLD_FACE2 = float.Parse(dBToDataTable.Rows[i]["FLD_FACE"].ToString());
						npcClass.X = float.Parse(dBToDataTable.Rows[i]["FLD_X"].ToString());
						npcClass.Y = float.Parse(dBToDataTable.Rows[i]["FLD_Y"].ToString());
						npcClass.Z = float.Parse(dBToDataTable.Rows[i]["FLD_Z"].ToString());
						npcClass.Rxjh_cs_X = float.Parse(dBToDataTable.Rows[i]["FLD_X"].ToString());
						npcClass.Rxjh_cs_Y = float.Parse(dBToDataTable.Rows[i]["FLD_Y"].ToString());
						npcClass.Rxjh_cs_Z = float.Parse(dBToDataTable.Rows[i]["FLD_Z"].ToString());
						if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
						{
							value2.add(npcClass);
						}
						else
						{
							value2 = new MapClass
							{
								MapID = npcClass.Rxjh_Map
							};
							value2.add(npcClass);
							Map.TryAdd(value2.MapID, value2);
						}
						if (npcClass.IsNpc == 0)
						{
							switch (npcClass.Rxjh_Map)
							{
							case 101:
								一转地图.Add(npcClass);
								break;
							case 201:
							case 301:
								二转地图.Add(npcClass);
								break;
							case 1001:
							case 1101:
								三转地图.Add(npcClass);
								break;
							case 2101:
							case 2201:
								四转地图.Add(npcClass);
								break;
							case 5001:
								五转地图.Add(npcClass);
								break;
							case 6001:
								六转地图.Add(npcClass);
								break;
							case 25100:
								七转地图.Add(npcClass);
								break;
							case 26000:
								八转地图.Add(npcClass);
								break;
							case 26100:
								九转地图.Add(npcClass);
								break;
							}
						}
						if (npcClass.FLD_PID >= 10000)
						{
							try
							{
								if (!NpcList.ContainsKey(npcClass.FLD_PID))
								{
									NpcList.TryAdd(npcClass.FLD_PID, npcClass);
								}
							}
							catch
							{
								continue;
							}
						}
						if (npcClass.IsNpc == 1 && npcClass.FLD_PID != 5 && npcClass.FLD_PID != 3)
						{
							npcClass.自动移动.Enabled = false;
							npcClass.自动移动.Close();
							npcClass.自动移动.Dispose();
							npcClass.自动移动 = null;
							npcClass.自动攻击.Enabled = false;
							npcClass.自动攻击.Close();
							npcClass.自动攻击.Dispose();
							npcClass.自动攻击 = null;
							if (npcClass.自动复活 != null)
							{
								npcClass.自动复活.Enabled = false;
							}
						}
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "加载NPC数据 出错：" + ex);
					}
				}
				MainForm.WriteLine(2, "加载NPC数据完成 " + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

		public static void delNpc(int mapp, int Npcid)
		{
			try
			{
				List<NpcClass> list = new List<NpcClass>();
				foreach (NpcClass value in MapClass.GetnpcTemplate(mapp).Values)
				{
					if (value.FLD_PID == Npcid)
					{
						list.Add(value);
					}
				}
				if (list == null)
				{
					return;
				}
				foreach (NpcClass item in list)
				{
					item.Dispose();
				}
				list.Clear();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "删除怪 [" + Npcid + "]出错：" + ex);
			}
		}

		public static void delBoss(int mapp, int Npcid)
		{
			try
			{
				List<NpcClass> list = new List<NpcClass>();
				foreach (NpcClass value in MapClass.GetnpcTemplate(mapp).Values)
				{
					if (value.FLD_PID == Npcid)
					{
						list.Add(value);
					}
				}
				if (list == null)
				{
					return;
				}
				foreach (NpcClass item in list)
				{
					item.发送怪物一次性死亡数据();
				}
				list.Clear();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "删除怪 [" + Npcid + "]出错：" + ex);
			}
		}

		public static NpcClass AddBossEveNpc(int Npcid, float x, float y, int mapp)
		{
			try
			{
				if (MonSter.TryGetValue(Npcid, out var value))
				{
					NpcClass npcClass = new NpcClass
					{
						FLD_PID = value.FLD_PID,
						Name = value.Name,
						Level = value.Level,
						Rxjh_Exp = value.Rxjh_Exp,
						X = x,
						Y = y,
						Z = 15f,
						Rxjh_cs_X = x,
						Rxjh_cs_Y = y,
						Rxjh_cs_Z = 15f,
						Rxjh_Map = mapp,
						IsNpc = 0,
						FLD_FACE1 = 0f,
						FLD_FACE2 = 0f,
						Max_Rxjh_HP = value.Rxjh_HP,
						Rxjh_HP = value.Rxjh_HP,
						FLD_AT = value.FLD_AT,
						FLD_DF = value.FLD_DF,
						FLD_AUTO = value.FLD_AUTO,
						FLD_BOSS = value.FLD_BOSS,
						isOneTimeMonster = true
					};
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						value2 = new MapClass
						{
							MapID = npcClass.Rxjh_Map
						};
						value2.add(npcClass);
						Map.TryAdd(value2.MapID, value2);
					}
					npcClass.获取范围玩家发送增加数据包();
					Thread.Sleep(1);
					return npcClass;
				}
				return null;
			}
			catch (Exception ex)
			{
				string str = "增加BOSS攻城怪 [";
				string str2 = Npcid.ToString();
				string str3 = "]出错：";
				MainForm.WriteLine(2, str + str2 + str3 + ex);
				return null;
			}
		}

		public static void AddNpc(int Npcid, float x, float y, int mapp)
		{
			try
			{
				if (MonSter.TryGetValue(Npcid, out var value))
				{
					NpcClass npcClass = new NpcClass
					{
						FLD_PID = value.FLD_PID,
						Name = value.Name,
						Level = value.Level,
						Rxjh_Exp = value.Rxjh_Exp,
						X = x,
						Y = y,
						Z = 15f,
						Rxjh_cs_X = x,
						Rxjh_cs_Y = y,
						Rxjh_cs_Z = 15f,
						Rxjh_Map = mapp,
						IsNpc = 0,
						FLD_FACE1 = 0f,
						FLD_FACE2 = 0f,
						Max_Rxjh_HP = value.Rxjh_HP,
						Rxjh_HP = value.Rxjh_HP,
						FLD_AT = value.FLD_AT,
						FLD_DF = value.FLD_DF,
						FLD_AUTO = value.FLD_AUTO,
						FLD_BOSS = ((mapp == 101 || mapp == 101 || mapp == 41001 || mapp == 29000) ? 1 : value.FLD_BOSS),
						FLD_NEWTIME = 10,
						isOneTimeMonster = true
					};
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						MapClass mapClass = new MapClass
						{
							MapID = npcClass.Rxjh_Map
						};
						mapClass.add(npcClass);
						Map.TryAdd(mapClass.MapID, mapClass);
					}
					npcClass.获取范围玩家发送增加数据包();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "增加怪 [" + Npcid + "]出错：" + ex);
			}
		}

		public static void AddNpc飞刀血魔(int Npcid, float x, float y, int mapp)
		{
			try
			{
				if (MonSter.TryGetValue(Npcid, out var value))
				{
					NpcClass npcClass = new NpcClass
					{
						FLD_PID = value.FLD_PID,
						Name = value.Name,
						Level = value.Level,
						Rxjh_Exp = value.Rxjh_Exp,
						X = x,
						Y = y,
						Z = 15f,
						Rxjh_cs_X = x,
						Rxjh_cs_Y = y,
						Rxjh_cs_Z = 15f,
						Rxjh_Map = mapp,
						IsNpc = 0,
						FLD_FACE1 = 0f,
						FLD_FACE2 = 0f,
						Max_Rxjh_HP = value.Rxjh_HP,
						Rxjh_HP = value.Rxjh_HP,
						FLD_AT = value.FLD_AT,
						FLD_DF = value.FLD_DF,
						FLD_AUTO = value.FLD_AUTO,
						FLD_BOSS = ((mapp == 101 || mapp == 801 || mapp == 41001) ? 1 : value.FLD_BOSS),
						FLD_NEWTIME = 10,
						isOneTimeMonster = true
					};
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						MapClass mapClass = new MapClass
						{
							MapID = npcClass.Rxjh_Map
						};
						mapClass.add(npcClass);
						Map.TryAdd(mapClass.MapID, mapClass);
					}
					npcClass.获取范围玩家发送增加数据包();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "增加怪 [" + Npcid + "]出错：" + ex);
			}
		}

		public static void 添加天魔怪物(int Npcid, float x, float y, int mapp, int AUTO)
		{
			try
			{
				if (MonSter.TryGetValue(Npcid, out var value))
				{
					NpcClass npcClass = new NpcClass
					{
						FLD_PID = value.FLD_PID,
						Name = value.Name,
						Level = value.Level,
						Rxjh_Exp = value.Rxjh_Exp,
						X = x,
						Y = y,
						Z = 15f,
						Rxjh_cs_X = x,
						Rxjh_cs_Y = y,
						Rxjh_cs_Z = 15f,
						Rxjh_Map = mapp,
						IsNpc = 0
					};
					if (Npcid == 16431)
					{
						npcClass.FLD_FACE1 = -1f;
						npcClass.FLD_FACE2 = 0f;
					}
					else
					{
						npcClass.FLD_FACE1 = 0f;
						npcClass.FLD_FACE2 = 0f;
					}
					npcClass.Max_Rxjh_HP = value.Rxjh_HP;
					npcClass.Rxjh_HP = value.Rxjh_HP;
					npcClass.FLD_AT = value.FLD_AT;
					npcClass.FLD_DF = value.FLD_DF;
					npcClass.FLD_AUTO = AUTO;
					npcClass.FLD_BOSS = value.FLD_BOSS;
					npcClass.isOneTimeMonster = true;
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						MapClass mapClass = new MapClass
						{
							MapID = npcClass.Rxjh_Map
						};
						mapClass.add(npcClass);
						Map.TryAdd(mapClass.MapID, mapClass);
					}
					npcClass.获取范围玩家发送增加数据包();
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "增加怪 [" + Npcid + "]出错：" + ex);
			}
		}

		public static void 天魔神宫雕像击杀添加怪物()
		{
			天魔神宫大门是否死亡 = 0;
			天魔神宫雕像是否死亡 = 0;
			Thread.Sleep(1000);
			delNpc(42001, 16431);
			Thread.Sleep(1000);
			delNpc(42001, 16430);
			Thread.Sleep(1000);
			添加天魔怪物(16430, -430f, -393f, 42001, 0);
			Thread.Sleep(1000);
			添加天魔怪物(16431, 57f, 470f, 42001, 0);
		}

		public static NpcClass AddNpc(int FLD_PID, float Rxjh_cs_X, float Rxjh_cs_Y, int Rxjh_Map, int FLD_FACE1, int FLD_FACE2, bool 一次性怪, int 刷新时间)
		{
			try
			{
				if (MonSter.TryGetValue(FLD_PID, out var value))
				{
					NpcClass npcClass = new NpcClass
					{
						FLD_PID = value.FLD_PID,
						Name = value.Name,
						Level = value.Level,
						Rxjh_Exp = value.Rxjh_Exp,
						X = Rxjh_cs_X,
						Y = Rxjh_cs_Y,
						Z = 15f,
						Rxjh_cs_X = Rxjh_cs_X,
						Rxjh_cs_Y = Rxjh_cs_Y,
						Rxjh_cs_Z = 15f,
						Rxjh_Map = Rxjh_Map,
						IsNpc = 0,
						FLD_FACE1 = FLD_FACE1,
						FLD_FACE2 = FLD_FACE2,
						Max_Rxjh_HP = value.Rxjh_HP,
						Rxjh_HP = value.Rxjh_HP,
						FLD_AT = value.FLD_AT,
						FLD_DF = value.FLD_DF,
						FLD_AUTO = value.FLD_AUTO,
						FLD_BOSS = value.FLD_BOSS,
						isOneTimeMonster = 一次性怪,
						FLD_NEWTIME = 刷新时间
					};
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						MapClass mapClass = new MapClass
						{
							MapID = npcClass.Rxjh_Map
						};
						mapClass.add(npcClass);
						Map.TryAdd(mapClass.MapID, mapClass);
					}
					npcClass.获取范围玩家发送增加数据包();
					return npcClass;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "增加怪 [" + FLD_PID + "]出错：" + ex.ToString());
			}
			return null;
		}

		public static void AddNpc一次(int 怪物ID, float 坐标X, float 坐标Y, int 地图, bool 是否true, int 血, int 攻击, int 防御)
		{
			try
			{
				if (MonSter.TryGetValue(怪物ID, out var _))
				{
					NpcClass npcClass = new NpcClass();
					npcClass.FLD_PID = 怪物ID;
					npcClass.Name = "BOSS世界";
					npcClass.Level = 1;
					npcClass.Rxjh_Exp = 1;
					npcClass.X = 坐标X;
					npcClass.Y = 坐标Y;
					npcClass.Z = 15f;
					npcClass.Rxjh_cs_X = 坐标X;
					npcClass.Rxjh_cs_Y = 坐标Y;
					npcClass.Rxjh_cs_Z = 15f;
					npcClass.Rxjh_Map = 地图;
					npcClass.IsNpc = 0;
					npcClass.FLD_FACE1 = 0f;
					npcClass.FLD_FACE2 = 0f;
					npcClass.Max_Rxjh_HP = 血;
					npcClass.Rxjh_HP = 血;
					npcClass.FLD_AT = 攻击;
					npcClass.FLD_DF = 防御;
					npcClass.FLD_AUTO = 1;
					npcClass.FLD_BOSS = 0;
					npcClass.isOneTimeMonster = true;
					npcClass.FLD_NEWTIME = 10;
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						MapClass mapClass = new MapClass();
						mapClass.MapID = npcClass.Rxjh_Map;
						mapClass.add(npcClass);
						Map.TryAdd(mapClass.MapID, mapClass);
					}
					npcClass.获取范围玩家发送增加数据包();
				}
				else
				{
					MainForm.WriteLine(2, "增加怪一次  [" + 怪物ID + "]错误1");
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "增加怪一次  [" + 怪物ID + "]出错：" + ex);
			}
		}

		public static void AddNpc一次深渊(int 怪物ID, float 坐标X, float 坐标Y, int 地图, bool 是否true, int 血, int 攻击, int 防御)
		{
			try
			{
				if (MonSter.TryGetValue(怪物ID, out var _))
				{
					NpcClass npcClass = new NpcClass();
					npcClass.FLD_PID = 怪物ID;
					npcClass.Name = "深渊BOSS";
					npcClass.Level = 1;
					npcClass.Rxjh_Exp = 1;
					npcClass.X = 坐标X;
					npcClass.Y = 坐标Y;
					npcClass.Z = 15f;
					npcClass.Rxjh_cs_X = 坐标X;
					npcClass.Rxjh_cs_Y = 坐标Y;
					npcClass.Rxjh_cs_Z = 15f;
					npcClass.Rxjh_Map = 地图;
					npcClass.IsNpc = 0;
					npcClass.FLD_FACE1 = 0f;
					npcClass.FLD_FACE2 = 0f;
					npcClass.Max_Rxjh_HP = 血;
					npcClass.Rxjh_HP = 血;
					npcClass.FLD_AT = 攻击;
					npcClass.FLD_DF = 防御;
					npcClass.FLD_AUTO = 1;
					npcClass.FLD_BOSS = 0;
					npcClass.isOneTimeMonster = true;
					npcClass.FLD_NEWTIME = 10;
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						MapClass mapClass = new MapClass();
						mapClass.MapID = npcClass.Rxjh_Map;
						mapClass.add(npcClass);
						Map.TryAdd(mapClass.MapID, mapClass);
					}
					npcClass.获取范围玩家发送增加数据包();
				}
				else
				{
					MainForm.WriteLine(2, "增加怪一次  [" + 怪物ID + "]错误1");
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "增加怪一次  [" + 怪物ID + "]出错：" + ex);
			}
		}

		public static void SerNpc(int Npcid, float x, float y, int mapp)
		{
			try
			{
				if (MonSter.TryGetValue(Npcid, out var value))
				{
					NpcClass npcClass = new NpcClass
					{
						FLD_PID = value.FLD_PID,
						Name = value.Name,
						Level = value.Level,
						Rxjh_Exp = value.Rxjh_Exp,
						X = x,
						Y = y,
						Z = 15f,
						Rxjh_cs_X = x,
						Rxjh_cs_Y = y,
						Rxjh_cs_Z = 15f,
						Rxjh_Map = mapp,
						IsNpc = 0,
						FLD_FACE1 = 0f,
						FLD_FACE2 = 0f,
						Max_Rxjh_HP = value.Rxjh_HP,
						Rxjh_HP = value.Rxjh_HP,
						FLD_AT = value.FLD_AT,
						FLD_DF = value.FLD_DF,
						FLD_AUTO = value.FLD_AUTO,
						FLD_BOSS = value.FLD_BOSS,
						FLD_NEWTIME = 10
					};
					if (Map.TryGetValue(npcClass.Rxjh_Map, out var value2))
					{
						value2.add(npcClass);
					}
					else
					{
						MapClass mapClass = new MapClass
						{
							MapID = npcClass.Rxjh_Map
						};
						mapClass.add(npcClass);
						Map.TryAdd(mapClass.MapID, mapClass);
					}
					npcClass.获取范围玩家发送增加数据包();
					DBA.ExeSqlCommand($"INSERT INTO TBL_XWWL_NPC(FLD_PID, FLD_X, FLD_Y, FLD_Z, FLD_FACE0, FLD_FACE, FLD_MID, FLD_NAME, FLD_HP, FLD_AT, FLD_DF, FLD_NPC, FLD_NEWTIME, FLD_LEVEL, FLD_EXP, FLD_AUTO, FLD_BOSS)VALUES ({npcClass.FLD_PID}, {x}, {y}, {15}, {0}, {0}, {npcClass.Rxjh_Map}, '{npcClass.Name}', {npcClass.Max_Rxjh_HP}, {npcClass.FLD_AT}, {npcClass.FLD_DF}, {0}, {10}, {npcClass.Level}, {npcClass.Rxjh_Exp}, {npcClass.FLD_AUTO}, {npcClass.FLD_BOSS})", "PublicDb");
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "增加怪 [" + Npcid + "]出错：" + ex);
			}
		}

		public static void ProcessSqlQueue()
		{
			try
			{
				if (JlMsg == 1)
				{
					MainForm.WriteLine(0, "ProcessSqlQueue111()");
				}
				while (SqlPool.Count > 0)
				{
					if (JlMsg == 1)
					{
						MainForm.WriteLine(0, "ProcessSqlQueue");
					}
					DbPoolClass dbPoolClass = (DbPoolClass)SqlPool.Dequeue();
					try
					{
						if (DbPoolClass.DbPoolClassRun(dbPoolClass.Conn, dbPoolClass.Sql, dbPoolClass.Prams, dbPoolClass.Type) == -1)
						{
							MainForm.WriteLine(1, "ProcessSqlQueue()2 数据库连接出错 " + SqlPool.Count);
							Thread.Sleep(50);
						}
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "ProcessSqlQueue()1出错 " + ex);
						Thread.Sleep(1);
					}
				}
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "ProcessSqlQueue()出错 " + ex2);
			}
		}

		public static void Rape()
		{
			foreach (Players value in AllConnectedPlayers.Values)
			{
				laozhu = "";
				SHA1 sHA = SHA1.Create();
				byte[] bytes = Encoding.UTF8.GetBytes(value.UserName);
				byte[] array = sHA.ComputeHash(bytes);
				byte[] array2 = array;
				byte[] array3 = array2;
				foreach (byte b in array3)
				{
					laozhu += b.ToString("X2");
				}
			}
		}

		public static bool 是否讨伐副本危险区域(Players player)
		{
			if (player.人物坐标_地图 == 43001 && player.人物坐标_X < 270f && player.人物坐标_X > -270f && player.人物坐标_Y < 110f && player.人物坐标_Y > -450f)
			{
				return true;
			}
			return false;
		}

		public static string pWord(string sSource, int iFlag)
		{
			if (sSource == null)
			{
				return null;
			}
			if (sSource.Equals(string.Empty))
			{
				return string.Empty;
			}
			string text = string.Empty;
			if (iFlag == 2)
			{
				int length = sSource.Length;
				text = string.Empty;
				int num = Convert.ToInt32(sSource.ToCharArray(0, 1)[0]) % 10;
				for (int i = 2; i < length; i += 2)
				{
					int num2 = Convert.ToInt32(sSource.ToCharArray(i, 1)[0]);
					string text2 = ((Convert.ToInt32(sSource.ToCharArray(i - 1, 1)[0]) % 2 != 0) ? ((char)(num2 - (i - 1) / 2 - num)).ToString() : ((char)(num2 + (i - 1) / 2 + num)).ToString());
					string str = text2;
					text += str;
				}
			}
			return text;
		}

		public static int GetRandomSeed()
		{
			byte[] array = new byte[4];
			new RNGCryptoServiceProvider().GetBytes(array);
			return BitConverter.ToInt32(array, 0);
		}

		public static int GetValue(int pid, int type)
		{
			int result = 0;
			try
			{
				switch (pid)
				{
				case 800000062:
				{
					int num10 = RNG.Next(0, 110);
					int num11 = 1;
					string text6 = ((type == 2) ? ((num10 < 0 || num10 >= 40) ? "11" : "2") : ((num10 >= 0 && num10 < 40) ? "2" : ((num10 >= 40 && num10 < 50) ? "3" : ((num10 >= 50 && num10 < 60) ? "4" : ((num10 < 60 || num10 >= 70) ? "11" : "6")))));
					switch (type)
					{
					case 1:
						if (text6 == null)
						{
							break;
						}
						switch (text6)
						{
						case "11":
							num11 = RNG.Next(23, 45);
							if (num11 % 2 != 0)
							{
								num11--;
							}
							break;
						case "6":
							num11 = RNG.Next(1, 10);
							break;
						case "4":
							num11 = RNG.Next(17, 36);
							if (num11 % 2 != 0)
							{
								num11--;
							}
							break;
						case "3":
							num11 = RNG.Next(30, 60);
							if (num11 % 2 != 0)
							{
								num11--;
							}
							break;
						case "2":
							num11 = RNG.Next(5, 9);
							break;
						}
						break;
					case 2:
					{
						string text11 = text6;
						string text12 = text11;
						if (!(text12 == "11"))
						{
							if (text12 == "2")
							{
								num11 = RNG.Next(11, 15);
							}
							break;
						}
						num11 = RNG.Next(80, 100);
						if (num11 >= 80 && num11 < 83)
						{
							num11 = 80;
						}
						else if (num11 >= 83 && num11 < 86)
						{
							num11 = 80;
						}
						else if (num11 >= 86 && num11 < 89)
						{
							num11 = 85;
						}
						else if (num11 >= 89 && num11 < 92)
						{
							num11 = 85;
						}
						else if (num11 >= 92 && num11 < 95)
						{
							num11 = 90;
						}
						else if (num11 >= 95 && num11 < 98)
						{
							num11 = 95;
						}
						else if (num11 >= 98 && num11 <= 100)
						{
							num11 = 100;
						}
						if (num11 != 85 && num11 != 95 && num11 % 2 != 0)
						{
							num11--;
						}
						break;
					}
					case 3:
					case 4:
					case 5:
					case 6:
						if (text6 == null)
						{
							break;
						}
						switch (text6)
						{
						case "11":
							num11 = RNG.Next(76, 100);
							if (num11 > 80 && num11 <= 83)
							{
								num11 = 80;
							}
							else if (num11 > 83 && num11 <= 86)
							{
								num11 = 80;
							}
							else if (num11 > 86 && num11 <= 89)
							{
								num11 = 85;
							}
							else if (num11 > 89 && num11 <= 92)
							{
								num11 = 90;
							}
							else if (num11 > 92 && num11 <= 95)
							{
								num11 = 90;
							}
							else if (num11 > 95 && num11 <= 98)
							{
								num11 = 95;
							}
							else if (num11 > 98 && num11 <= 100)
							{
								num11 = 95;
							}
							if (num11 != 85 && num11 != 95 && num11 % 2 != 0)
							{
								num11--;
							}
							break;
						case "6":
							num11 = RNG.Next(3, 10);
							break;
						case "4":
							num11 = RNG.Next(35, 50);
							if (num11 % 2 != 0)
							{
								num11--;
							}
							break;
						case "3":
							num11 = RNG.Next(50, 80);
							if (num11 % 2 != 0)
							{
								num11--;
							}
							break;
						case "2":
							num11 = RNG.Next(10, 14);
							break;
						}
						break;
					}
					result = int.Parse(text6) * 100000 + num11;
					break;
				}
				case 800000061:
				{
					int num17 = RNG.Next(0, 120);
					int num18 = 1;
					string text2 = ((type == 2) ? ((num17 >= 0 && num17 < 55) ? "1" : ((num17 < 55 || num17 >= 110) ? "8" : "7")) : ((num17 >= 0 && num17 < 30) ? "1" : ((num17 >= 30 && num17 < 40) ? "3" : ((num17 >= 40 && num17 < 45) ? "4" : ((num17 >= 45 && num17 < 50) ? "5" : ((num17 >= 50 && num17 < 110) ? "7" : ((num17 < 110 || num17 >= 115) ? "10" : "8")))))));
					switch (type)
					{
					case 1:
						switch (text2)
						{
						case "4":
							num18 = RNG.Next(20, 25);
							if (num18 % 2 != 0)
							{
								num18--;
							}
							break;
						case "5":
							num18 = RNG.Next(1, 10);
							break;
						case "10":
							num18 = RNG.Next(10, 25);
							break;
						case "1":
							num18 = RNG.Next(10, 20);
							break;
						case "7":
							num18 = RNG.Next(15, 25);
							break;
						case "8":
							num18 = 1;
							break;
						case "3":
							num18 = RNG.Next(50, 70);
							if (num18 % 2 != 0)
							{
								num18--;
							}
							break;
						}
						break;
					case 2:
						if (text2 != null)
						{
							switch (text2)
							{
							case "8":
								num18 = 2;
								break;
							case "7":
								num18 = RNG.Next(30, 35);
								break;
							case "1":
								num18 = RNG.Next(20, 25);
								break;
							}
						}
						break;
					case 3:
					case 4:
					case 5:
					case 6:
						switch (text2)
						{
						case "4":
							num18 = RNG.Next(25, 50);
							if (num18 % 2 != 0)
							{
								num18--;
							}
							break;
						case "5":
							num18 = RNG.Next(5, 10);
							break;
						case "10":
							num18 = RNG.Next(15, 25);
							break;
						case "1":
							num18 = RNG.Next(15, 24);
							break;
						case "7":
							num18 = RNG.Next(15, 34);
							break;
						case "8":
							num18 = RNG.Next(1, 2);
							break;
						case "3":
							num18 = RNG.Next(50, 80);
							if (num18 % 2 != 0)
							{
								num18--;
							}
							break;
						}
						break;
					}
					result = int.Parse(text2) * 100000 + num18;
					break;
				}
				case 800000001:
				case 800000011:
				{
					int num5 = RNG.Next(0, 120);
					int num6 = 1;
					string text5 = ((num5 >= 0 && num5 < 50) ? "1" : ((num5 >= 50 && num5 < 55) ? "3" : ((num5 >= 55 && num5 < 60) ? "4" : ((num5 >= 60 && num5 < 65) ? "5" : ((num5 >= 65 && num5 < 100) ? "7" : ((num5 < 100 || num5 >= 110) ? "10" : "8"))))));
					switch (type)
					{
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						switch (text5)
						{
						case "4":
							num6 = RNG.Next(25, 36);
							if (num6 % 2 != 0)
							{
								num6--;
							}
							break;
						case "5":
							num6 = RNG.Next(5, 10);
							break;
						case "10":
							num6 = RNG.Next(10, 25);
							break;
						case "1":
							num6 = RNG.Next(8, 15);
							break;
						case "7":
							num6 = RNG.Next(20, 25);
							break;
						case "8":
							num6 = RNG.Next(1, 2);
							break;
						case "3":
							num6 = RNG.Next(20, 40);
							if (num6 % 2 != 0)
							{
								num6--;
							}
							break;
						}
						break;
					case 1:
						switch (text5)
						{
						case "4":
							num6 = RNG.Next(15, 25);
							if (num6 % 2 != 0)
							{
								num6--;
							}
							break;
						case "5":
							num6 = RNG.Next(1, 10);
							break;
						case "10":
							num6 = RNG.Next(20, 25);
							break;
						case "1":
							num6 = RNG.Next(5, 10);
							break;
						case "7":
							num6 = RNG.Next(15, 22);
							break;
						case "8":
							num6 = 1;
							break;
						case "3":
							num6 = RNG.Next(25, 30);
							if (num6 % 2 != 0)
							{
								num6--;
							}
							break;
						}
						break;
					}
					result = int.Parse(text5) * 100000 + num6;
					break;
				}
				case 800000002:
				case 800000012:
				{
					int num3 = RNG.Next(0, 100);
					int num4 = 1;
					string text4 = ((num3 >= 0 && num3 < 75) ? "2" : ((num3 >= 75 && num3 < 80) ? "3" : ((num3 >= 80 && num3 < 85) ? "4" : ((num3 < 85 || num3 >= 90) ? "11" : "6"))));
					switch (type)
					{
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						if (text4 == null)
						{
							break;
						}
						switch (text4)
						{
						case "11":
							num4 = RNG.Next(35, 45);
							if (num4 % 2 != 0)
							{
								num4--;
							}
							break;
						case "6":
							num4 = RNG.Next(5, 10);
							break;
						case "4":
							num4 = RNG.Next(25, 50);
							if (num4 % 2 != 0)
							{
								num4--;
							}
							break;
						case "3":
							num4 = RNG.Next(25, 50);
							if (num4 % 2 != 0)
							{
								num4--;
							}
							break;
						case "2":
							num4 = RNG.Next(6, 10);
							break;
						}
						break;
					case 1:
						if (text4 == null)
						{
							break;
						}
						switch (text4)
						{
						case "11":
							num4 = RNG.Next(2, 35);
							if (num4 % 2 != 0)
							{
								num4--;
							}
							break;
						case "6":
							num4 = RNG.Next(1, 10);
							break;
						case "4":
							num4 = RNG.Next(20, 36);
							if (num4 % 2 != 0)
							{
								num4--;
							}
							break;
						case "3":
							num4 = RNG.Next(20, 40);
							if (num4 % 2 != 0)
							{
								num4--;
							}
							break;
						case "2":
							num4 = RNG.Next(4, 8);
							break;
						}
						break;
					}
					result = int.Parse(text4) * 100000 + num4;
					break;
				}
				case 800000013:
				{
					int num7 = 0;
					string str = "0000";
					int num8 = RNG.Next(0, 125);
					int num9 = ((num8 >= 0 && num8 <= 40) ? 8 : ((num8 > 40 && num8 <= 70) ? 9 : ((num8 > 70 && num8 <= 90) ? 12 : ((num8 <= 90 || num8 > 110) ? 15 : 13))));
					switch (num9)
					{
					case 8:
						num7 = 1;
						str = "0000";
						break;
					case 9:
						num7 = 1;
						break;
					case 12:
						num7 = 10;
						break;
					case 13:
						num7 = 5;
						break;
					case 15:
						num7 = 1;
						break;
					}
					result = int.Parse((num9 != 12) ? (num9 + str + num7) : (num9 + "000" + num7));
					break;
				}
				case 800000023:
				{
					int num19 = RNG.Next(0, 120);
					int num2 = 1;
					string text3 = ((type == 2) ? ((num19 < 0 || num19 >= 30) ? "7" : "1") : ((num19 >= 0 && num19 < 20) ? "1" : ((num19 >= 20 && num19 < 30) ? "3" : ((num19 >= 30 && num19 < 35) ? "4" : ((num19 >= 35 && num19 < 40) ? "5" : ((num19 >= 40 && num19 < 110) ? "7" : ((num19 < 110 || num19 >= 115) ? "10" : "8")))))));
					switch (type)
					{
					case 1:
						switch (text3)
						{
						case "4":
							num2 = RNG.Next(15, 25);
							if (num2 % 2 != 0)
							{
								num2--;
							}
							break;
						case "5":
							num2 = RNG.Next(1, 10);
							break;
						case "10":
							num2 = RNG.Next(10, 25);
							break;
						case "1":
							num2 = RNG.Next(8, 15);
							break;
						case "7":
							num2 = RNG.Next(15, 24);
							break;
						case "8":
							num2 = 1;
							break;
						case "3":
							num2 = RNG.Next(45, 70);
							if (num2 % 2 != 0)
							{
								num2--;
							}
							break;
						}
						break;
					case 2:
					{
						string text9 = text3;
						string text10 = text9;
						if (!(text10 == "7"))
						{
							if (text10 == "1")
							{
								num2 = RNG.Next(21, 24);
							}
						}
						else
						{
							num2 = RNG.Next(27, 31);
						}
						break;
					}
					case 3:
					case 4:
					case 5:
					case 6:
						switch (text3)
						{
						case "4":
							num2 = RNG.Next(15, 50);
							if (num2 % 2 != 0)
							{
								num2--;
							}
							break;
						case "5":
							num2 = RNG.Next(5, 10);
							break;
						case "10":
							num2 = RNG.Next(10, 25);
							break;
						case "1":
							num2 = RNG.Next(13, 20);
							break;
						case "7":
							num2 = RNG.Next(24, 31);
							break;
						case "8":
							num2 = RNG.Next(1, 2);
							break;
						case "3":
							num2 = RNG.Next(25, 80);
							if (num2 % 2 != 0)
							{
								num2--;
							}
							break;
						}
						break;
					}
					result = int.Parse(text3) * 100000 + num2;
					break;
				}
				case 800000024:
				{
					int num15 = RNG.Next(0, 100);
					int num16 = 1;
					string text = ((type == 2) ? ((num15 < 0 || num15 >= 50) ? "11" : "2") : ((num15 >= 0 && num15 < 45) ? "2" : ((num15 >= 45 && num15 < 50) ? "3" : ((num15 >= 50 && num15 < 55) ? "4" : ((num15 < 55 || num15 >= 60) ? "11" : "6")))));
					switch (type)
					{
					case 1:
						if (text == null)
						{
							break;
						}
						switch (text)
						{
						case "11":
							num16 = RNG.Next(45, 70);
							if (num16 % 2 != 0)
							{
								num16--;
							}
							break;
						case "6":
							num16 = RNG.Next(1, 10);
							break;
						case "4":
							num16 = RNG.Next(20, 36);
							if (num16 % 2 != 0)
							{
								num16--;
							}
							break;
						case "3":
							num16 = RNG.Next(20, 36);
							if (num16 % 2 != 0)
							{
								num16--;
							}
							break;
						case "2":
							num16 = RNG.Next(5, 9);
							break;
						}
						break;
					case 2:
					{
						string text7 = text;
						string text8 = text7;
						if (!(text8 == "11"))
						{
							if (text8 == "2")
							{
								num16 = RNG.Next(8, 11);
							}
							break;
						}
						num16 = RNG.Next(74, 80);
						if (num16 % 2 != 0)
						{
							num16--;
						}
						break;
					}
					case 3:
					case 4:
					case 5:
					case 6:
						if (text == null)
						{
							break;
						}
						switch (text)
						{
						case "11":
							num16 = RNG.Next(64, 80);
							if (num16 % 2 != 0)
							{
								num16--;
							}
							break;
						case "6":
							num16 = RNG.Next(3, 10);
							break;
						case "4":
							num16 = RNG.Next(15, 30);
							if (num16 % 2 != 0)
							{
								num16--;
							}
							break;
						case "3":
							num16 = RNG.Next(30, 50);
							if (num16 % 2 != 0)
							{
								num16--;
							}
							break;
						case "2":
							num16 = RNG.Next(8, 11);
							break;
						}
						break;
					}
					result = int.Parse(text) * 100000 + num16;
					break;
				}
				case 800000025:
					result = 1000000 + RNG.Next(15, 20);
					break;
				case 800000026:
					result = 700000 + RNG.Next(15, 25);
					break;
				case 800000028:
					result = int.Parse("200" + RNG.Next(1, 6) + "000");
					break;
				case 800000030:
				case 800000034:
					switch (type)
					{
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					{
						int num14 = RNG.Next(0, 100);
						result = ((num14 >= 0 && num14 < 20) ? RNG.Next(100005, 100015) : ((num14 >= 20 && num14 < 40) ? RNG.Next(700008, 700025) : ((num14 >= 40 && num14 < 60) ? RNG.Next(1000008, 1000025) : ((num14 < 60 || num14 >= 80) ? 1500001 : RNG.Next(200001, 200020)))));
						break;
					}
					case 1:
					{
						int num13 = RNG.Next(0, 100);
						result = ((num13 >= 0 && num13 < 20) ? RNG.Next(100005, 100010) : ((num13 >= 20 && num13 < 40) ? RNG.Next(700008, 700020) : ((num13 >= 40 && num13 < 60) ? RNG.Next(1000008, 1000020) : ((num13 < 60 || num13 >= 80) ? 1500001 : RNG.Next(200001, 200010)))));
						break;
					}
					}
					break;
				case 800000031:
				case 800000035:
					switch (type)
					{
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					{
						int num12 = RNG.Next(0, 100);
						result = ((num12 >= 0 && num12 < 20) ? RNG.Next(100005, 100025) : ((num12 >= 20 && num12 < 40) ? RNG.Next(700008, 700035) : ((num12 >= 40 && num12 < 60) ? RNG.Next(1000008, 1000025) : ((num12 < 60 || num12 >= 80) ? RNG.Next(1500001, 1500002) : RNG.Next(200001, 200020)))));
						break;
					}
					case 1:
					{
						int num = RNG.Next(0, 100);
						result = ((num >= 0 && num < 20) ? RNG.Next(100005, 100015) : ((num >= 20 && num < 40) ? RNG.Next(700008, 700020) : ((num >= 40 && num < 60) ? RNG.Next(1000008, 1000020) : ((num < 60 || num >= 80) ? 1500001 : RNG.Next(200001, 200010)))));
						break;
					}
					}
					break;
				case 800000032:
				case 800000036:
					switch (type)
					{
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						result = RNG.Next(200005, 200020);
						break;
					case 1:
						result = RNG.Next(200001, 200005);
						break;
					}
					break;
				case 800000033:
				case 800000037:
					switch (type)
					{
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						result = RNG.Next(200005, 200025);
						break;
					case 1:
						result = RNG.Next(200001, 200005);
						break;
					}
					break;
				}
			}
			catch
			{
				return 1;
			}
			return result;
		}

        public void LoadPkNotificationData()
        {
            // ใช้ using statement เพื่อจัดการ resource อัตโนมัติ
            using (var dataTable = DBA.GetDBToDataTable("SELECT * FROM 杀人提示", "PublicDb"))
            {
                // ตรวจสอบว่ามีข้อมูลการแจ้งเตือน PK หรือไม่
                if (dataTable?.Rows.Count == 0)
                {
                    MainForm.WriteLine(1, "No PK notification data found");
                    return;
                }

                try
                {
                    // ล้างข้อมูลเก่า
                    PkNotificationData.Clear();

                    // ใช้ LINQ เพื่อแปลงข้อมูลและกรองข้อมูลที่ถูกต้อง
                    var validData = dataTable.Rows.Cast<DataRow>()                        // แปลง DataRowCollection เป็น IEnumerable<DataRow>
                        .Select((row, index) => new { Index = index, Data = CreatePkNotification(row) })  // สร้างออบเจ็กต์การแจ้งเตือนพร้อม index
                        .Where(x => x.Data != null)                                       // กรองเฉพาะข้อมูลที่ไม่เป็น null
                        .ToDictionary(x => x.Index, x => x.Data);                         // แปลงเป็น Dictionary

                    // เพิ่มข้อมูลที่ถูกต้องลงใน Dictionary หลัก
                    foreach (var kvp in validData)
                    {
                        PkNotificationData.Add(kvp.Key, kvp.Value);
                    }

                    // แสดงผลสรุปการโหลดข้อมูลการแจ้งเตือน PK
                    MainForm.WriteLine(2, "PK notification data loaded: " + validData.Count + "/" + dataTable.Rows.Count + " records");
                }
                catch (Exception ex)
                {
                    // จัดการ error ระดับ method
                    MainForm.WriteLine(1, "Error loading PK notification data: " + ex.Message);
                }
            }
        }

        // Helper method สำหรับสร้างออบเจ็กต์ PkNotification
        private PkNotification CreatePkNotification(DataRow row)
        {
            try
            {
                // สร้างออบเจ็กต์การแจ้งเตือน PK จากข้อมูลในแถว
                return new PkNotification
                {
                    MinKillCount = Convert.ToInt32(row["杀人次数最小"]),        // แปลงจำนวนการฆ่าต่ำสุดเป็น int
                    MaxKillCount = Convert.ToInt32(row["杀人次数最大"]),        // แปลงจำนวนการฆ่าสูงสุดเป็น int
                    AttackBonus = Convert.ToInt32(row["攻击"]),               // แปลงโบนัสการโจมตีเป็น int
                    DefenseBonus = Convert.ToInt32(row["防御"]),              // แปลงโบนัสการป้องกันเป็น int
                    HealthBonus = Convert.ToInt32(row["血"]),                 // แปลงโบนัสพลังชีวิตเป็น int
                    LoginMessage = row["上线提示"].ToString()                  // ดึงข้อความแจ้งเตือน
                };
            }
            catch
            {
                // ถ้าข้อมูลไม่ถูกต้อง ให้คืนค่า null
                return null; // Invalid data
            }
        }

        public void LoadItemContribution()
        {
            using (var dataTable = DBA.GetDBToDataTable("SELECT * FROM 物品贡献", "PublicDb"))
            {
                if (dataTable?.Rows.Count == 0)
                {
                    MainForm.WriteLine(1, "No item contribution data found");
                    return;
                }

                ItemContributionData.Clear();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ItemContributionData.Add(i, new ItemContributionClass
                    {
                        RequiredItem = dataTable.Rows[i]["需要物品"].ToString(),
                        ContributionValue = (int)dataTable.Rows[i]["贡献度"]
                    });
                }

                MainForm.WriteLine(2, "Item contribution data loaded: " + dataTable.Rows.Count + " items");
            }
        }

        public static void ClearAccumulatedData()
        {
            try
            {
                var players = AllConnectedPlayers.Values.ToList();

                Parallel.ForEach(players, player =>
                {
                    player.AccumulatedDamage = 0;
                    player.SavePlayerData();
                });

                MainForm.WriteLine(2, "Accumulated damage cleared for " + players.Count + " players");
            }
            catch (Exception ex)
            {
                MainForm.WriteLine(1, "Error clearing accumulated data: " + ex.Message);
            }
        }

        public static void DistributeCrusadeRewards()
		{
			try
			{
				FirstPlaceDamage = 0;
				讨伐伤害排行2 = 0;
				讨伐伤害排行3 = 0;
				讨伐伤害排行4 = 0;
				讨伐伤害排行5 = 0;
				讨伐伤害排行6 = 0;
				讨伐伤害排行7 = 0;
				讨伐伤害排行8 = 0;
				讨伐伤害排行9 = 0;
				讨伐伤害排行10 = 0;
				FirstPlaceUserId = "";
				讨伐账号排行2 = "";
				讨伐账号排行3 = "";
				讨伐账号排行4 = "";
				讨伐账号排行5 = "";
				讨伐账号排行6 = "";
				讨伐账号排行7 = "";
				讨伐账号排行8 = "";
				讨伐账号排行9 = "";
				讨伐账号排行10 = "";
				int num = 0;
				foreach (Players value in AllConnectedPlayers.Values)
				{
					if (value.讨伐累计伤害 >= 1)
					{
						num++;
					}
				}
				foreach (Players value2 in AllConnectedPlayers.Values)
				{
					value2.IsRanked = 0;
				}
				if (num >= 1)
				{
					GlobalNotification("系统提示", 20, "本届副本战参加人数:" + num + "人");
					int num2 = 0;
					for (num2 = 0; num2 < 31; num2++)
					{
						if (num2 == 1)
						{
							foreach (Players value3 in AllConnectedPlayers.Values)
							{
								if (value3.讨伐累计伤害 >= FirstPlaceDamage && value3.讨伐累计伤害 > 0 && value3.IsRanked == 0)
								{
									FirstPlaceDamage = value3.讨伐累计伤害;
									FirstPlaceUserId = value3.Userid;
								}
							}
							foreach (Players value4 in AllConnectedPlayers.Values)
							{
								if (FirstPlaceUserId == value4.Userid)
								{
									value4.IsRanked = 1;
								}
							}
						}
						if (num2 == 2)
						{
							foreach (Players value5 in AllConnectedPlayers.Values)
							{
								if (value5.讨伐累计伤害 >= 讨伐伤害排行2 && value5.讨伐累计伤害 > 0 && value5.IsRanked == 0)
								{
									讨伐伤害排行2 = value5.讨伐累计伤害;
									讨伐账号排行2 = value5.Userid;
								}
							}
							foreach (Players value6 in AllConnectedPlayers.Values)
							{
								if (讨伐账号排行2 == value6.Userid)
								{
									value6.IsRanked = 1;
								}
							}
						}
						if (num2 != 3)
						{
							continue;
						}
						foreach (Players value7 in AllConnectedPlayers.Values)
						{
							if (value7.讨伐累计伤害 >= 讨伐伤害排行3 && value7.讨伐累计伤害 > 0 && value7.IsRanked == 0)
							{
								讨伐伤害排行3 = value7.讨伐累计伤害;
								讨伐账号排行3 = value7.Userid;
							}
						}
						foreach (Players value8 in AllConnectedPlayers.Values)
						{
							if (讨伐账号排行3 == value8.Userid)
							{
								value8.IsRanked = 1;
							}
						}
					}
				}
				if (FirstPlaceUserId.Length >= 1)
				{
					Players players = 检查玩家(FirstPlaceUserId);
					if (players != null)
					{
						int num3 = players.GetEmptyBagSlot();
						if (num3 >= 0)
						{
							players.CheckTreasureGems();
							players.CheckGemPointsData(讨伐第一名钻石奖励数量, 1, "讨伐BOSS");
							players.SaveGemData();
							players.AddItemWithProperties(讨伐第一名boss奖励物品, players.GetEmptyBagSlot(), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
							GlobalNotification("讨伐BOSS", 6, "恭喜玩家[" + players.UserName + "]赢得此次讨伐BOSS第一名，获得" + 讨伐第一名钻石奖励数量 + "钻石及宝盒");
						}
						else
						{
							players.系统提示("没有空位，本次没有获得奖励！", 10, "提示");
						}
					}
				}
				if (讨伐账号排行2.Length >= 1)
				{
					Players players2 = 检查玩家(讨伐账号排行2);
					if (players2 != null)
					{
						int num4 = players2.GetEmptyBagSlot();
						if (num4 >= 0)
						{
							players2.CheckTreasureGems();
							players2.CheckGemPointsData(讨伐第二名钻石奖励数量, 1, "讨伐BOSS");
							players2.SaveGemData();
							players2.AddItemWithProperties(讨伐第二名boss奖励物品, players2.GetEmptyBagSlot(), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
							GlobalNotification("讨伐BOSS", 6, "恭喜玩家[" + players2.UserName + "]赢得此次讨伐BOSS第二名，获得" + 讨伐第二名钻石奖励数量 + "钻石及宝盒");
						}
						else
						{
							players2.系统提示("没有空位，本次没有获得奖励！", 10, "提示");
						}
					}
				}
				if (讨伐账号排行3.Length < 1)
				{
					return;
				}
				Players player = 检查玩家(讨伐账号排行3);
				if (player != null)
				{
					int emptySlot = player.GetEmptyBagSlot();
					if (emptySlot >= 0)
					{
						player.CheckTreasureGems();
						player.CheckGemPointsData(diamonds, 1, "讨伐BOSS");
						player.SaveGemData();
						player.AddItemWithProperties(讨伐第二名boss奖励物品, player.GetEmptyBagSlot(), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
						GlobalNotification("讨伐BOSS", 6, "恭喜玩家[" + player.UserName + "]赢得此次讨伐BOSS第三名，获得" + diamonds + "钻石及宝盒");
					}
					else
					{
						player.系统提示("没有空位，本次没有获得奖励！", 10, "提示");
					}
				}
			}
			catch
			{
				MainForm.WriteLine(1, "发奖励错误 ");
			}
		}

        public void LoadBotChatMessages()
        {
            // ใช้ using statement เพื่อจัดการ resource อัตโนมัติ
            using (var dataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_假人喊话内容", "PublicDb"))
            {
                // ตรวจสอบว่ามีข้อมูลข้อความแชทหรือไม่
                if (dataTable?.Rows.Count == 0)
                {
                    MainForm.WriteLine(2, "No bot chat message data found");
                    return;
                }

                try
                {
                    // ใช้ LINQ เพื่อแปลงข้อมูลและกรองข้อมูลที่ถูกต้อง
                    BotChatMessages = dataTable.Rows.Cast<DataRow>()                      // แปลง DataRowCollection เป็น IEnumerable<DataRow>
                        .Select((row, index) => new { Index = index, Data = CreateBotChatMessage(row) })  // สร้างออบเจ็กต์ข้อความพร้อม index
                        .Where(x => x.Data != null)                                       // กรองเฉพาะข้อมูลที่ไม่เป็น null
                        .ToDictionary(x => x.Index, x => x.Data);                         // แปลงเป็น Dictionary

                    // แสดงผลสรุปการโหลดข้อความแชท
                    MainForm.WriteLine(2, "Bot chat messages loaded: " + BotChatMessages.Count + "/" + dataTable.Rows.Count + " messages");
                }
                catch (Exception ex)
                {
                    // จัดการ error ระดับ method
                    MainForm.WriteLine(1, "Error loading bot chat messages: " + ex.Message);
                }
            }
        }

        // Helper method สำหรับสร้างออบเจ็กต์ BotChatMessage
        private BotChatMessage CreateBotChatMessage(DataRow row)
        {
            try
            {
                // สร้างออบเจ็กต์ข้อความแชทของบอทจากข้อมูลในแถว
                return new BotChatMessage
                {
                    PlayerId = Convert.ToInt32(row["FLD_PID"]),           // แปลง Player ID เป็น int
                    BotMode = Convert.ToInt32(row["假人模式"]),             // แปลงโหมดบอทเป็น int
                    ChatContent = row["喊话内容"].ToString()               // ดึงเนื้อหาข้อความ
                };
            }
            catch
            {
                // ถ้าข้อมูลไม่ถูกต้อง ให้คืนค่า null
                return null; // Invalid data
            }
        }

        public void LoadBotMonsterCoordinates()
        {
            // ใช้ using statement เพื่อจัดการ resource อัตโนมัติ
            using (var dataTable = DBA.GetDBToDataTable("SELECT * FROM TBL_XWWL_NPC", "PublicDb"))
            {
                // ตรวจสอบว่ามีข้อมูลหรือไม่
                if (dataTable?.Rows.Count == 0)
                {
                    MainForm.WriteLine(2, "No bot monster data found");
                    return;
                }

                try
                {
                    // ใช้ LINQ เพื่อแปลงข้อมูลและกรองข้อมูลที่ถูกต้อง
                    BotMonsters = dataTable.Rows.Cast<DataRow>()                          // แปลง DataRowCollection เป็น IEnumerable<DataRow>
                        .Select((row, index) => new { Index = index, Data = CreateBotCoordinates(row) })  // สร้างออบเจ็กต์ชั่วคราวพร้อม index
                        .Where(x => x.Data != null)                                       // กรองเฉพาะข้อมูลที่ไม่เป็น null
                        .ToDictionary(x => x.Index, x => x.Data);                         // แปลงเป็น Dictionary

                    // แสดงผลสรุปการโหลด
                    MainForm.WriteLine(2, "Bot monster data loaded: " + BotMonsters.Count + "/" + dataTable.Rows.Count + " records");
                }
                catch (Exception ex)
                {
                    // จัดการ error ระดับ method
                    MainForm.WriteLine(1, "Error loading bot monster data: " + ex.Message);
                }
            }
        }

        // Helper method สำหรับสร้างออบเจ็กต์ BotCoordinates
        private BotCoordinates CreateBotCoordinates(DataRow row)
        {
            try
            {
                // สร้างออบเจ็กต์พิกัดบอทจากข้อมูลในแถว
                return new BotCoordinates
                {
                    Index = Convert.ToInt32(row["FLD_INDEX"]),        // แปลง index เป็น int
                    MonsterId = Convert.ToInt32(row["FLD_MID"]),      // แปลง monster ID เป็น int  
                    Level = Convert.ToInt32(row["FLD_LEVEL"]),        // แปลง level เป็น int
                    X = Convert.ToSingle(row["FLD_X"]),               // แปลงพิกัด X เป็น float
                    Y = Convert.ToSingle(row["FLD_Y"])                // แปลงพิกัด Y เป็น float
                };
            }
            catch
            {
                // ถ้าข้อมูลไม่ถูกต้อง ให้คืนค่า null
                return null; // Invalid data
            }
        }
    }
}
