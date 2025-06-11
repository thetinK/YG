using System;
using System.Collections.Concurrent;
using RxjhServer.HelperTools;
using RxjhServer.Network;

namespace RxjhServer
{
	public class 物品类 : IDisposable
	{
		public bool 锁定;

		private bool _物品绑定;

		private string _物品string;

		private int _物品位置;

		private byte[] _物品_byte;

		private Itimesx _属性1;

		private Itimesx _属性2;

		private Itimesx _属性3;

		private Itimesx _属性4;

		private int _物品防御力;

		private int _物品武功回避;

		private int _物品武功命中;

		private int _物品隐藏生命;

		private int _物品隐藏攻击;

		private int _物品隐藏防御;

		private int _物品增加负重;

		private int _物品对怪防御力;

		private int _物品对怪攻击力;

		private int _物品_中级附魂_追加_觉醒;

		private int _物品攻击力;

		private int _物品攻击力MAX;

		private int _物品属性_障力增加;

		private int _物品属性强类型;

		private int _物品属性强;

		private int _物品属性阶段类型;

		private int _物品属性阶段数;

		private int _物品属性_攻击力增加;

		private int _物品攻击力New;

		private int _物品攻击力MaxNew;

		private int _物品属性_防御力增加;

		private int _物品属性_生命力增加;

		private int _物品属性_障力恢复量增加;

		private int _物品属性_内功力增加;

		private int _物品属性_命中率增加;

		private int _物品属性_回避率增加;

		private int _物品属性_武功攻击力;

		private int _物品属性_武功攻击力New;

		private double _物品属性_降低百分比攻击;

		private double _物品属性_降低百分比防御;

		private double _物品属性_增加百分比命中;

		private double _物品属性_增加百分比回避;

		private double _物品属性_初始化愤怒概率百分比;

		private double _物品属性_对怪伤害;

		private int _物品属性_愤怒值增加;

		private int _物品属性_全部气功等级增加;

		private int _物品属性_追加刀力劈华山;

		private int _物品属性_追加刀摄魂一击;

		private int _物品属性_追加刀连环飞舞;

		private int _物品属性_追加升天三火龙之火;

		private int _物品属性_追加刀狂风万破;

		private int _物品属性_追加刀四两千斤;

		private int _物品属性_追加刀霸气破甲;

		private int _物品属性_追加气沉丹田;

		private int _物品属性_追加刀真武绝击;

		private int _物品属性_追加刀暗影绝杀;

		private int _物品属性_追加刀稳如泰山;

		private int _物品属性_追加刀流光乱舞;

		private int _物品属性_追加刀梵音破镜;

		private int _物品属性_追加剑长虹贯日;

		private int _物品属性_追加剑百变神行;

		private int _物品属性_追加剑连环飞舞;

		private int _物品属性_追加剑破天一剑;

		private int _物品属性_追加剑狂风万破;

		private int _物品属性_追加升天一护身罡气;

		private int _物品属性_追加剑移花接木;

		private int _物品属性_追加剑回柳身法;

		private int _物品属性_追加剑怒海狂澜;

		private int _物品属性_追加剑冲冠一怒;

		private int _物品属性_追加剑无坚不摧;

		private int _物品属性_追加剑乘胜追击;

		private int _物品属性_追加枪金钟罩气;

		private int _物品属性_追加枪运气疗伤;

		private int _物品属性_追加枪连环飞舞;

		private int _物品属性_追加升天三怒意之火;

		private int _物品属性_追加枪狂风万破;

		private int _物品属性_追加枪横练太保;

		private int _物品属性_追加枪乾坤挪移;

		private int _物品属性_追加枪灵甲护身;

		private int _物品属性_追加枪狂神降世;

		private int _物品属性_追加枪转守为攻;

		private int _物品属性_追加枪末日狂舞;

		private int _物品属性_追加枪怒意之吼;

		private int _物品属性_追加弓百步穿杨;

		private int _物品属性_追加弓猎鹰之眼;

		private int _物品属性_追加弓凝神聚气;

		private int _物品属性_追加弓回流真气;

		private int _物品属性_追加弓狂风万破;

		private int _物品属性_追加弓正本培元;

		private int _物品属性_追加弓心神凝聚;

		private int _物品属性_追加弓流星三矢;

		private int _物品属性_追加弓锐利之箭;

		private int _物品属性_追加弓无明暗矢;

		private int _物品属性_追加弓致命绝杀;

		private int _物品属性_追加医运气行心;

		private int _物品属性_追加医太极心法;

		private int _物品属性_追加医体血倍增;

		private int _物品属性_追加医洗髓易经;

		private int _物品属性_追加医妙手回春;

		private int _物品属性_追加医长功攻击;

		private int _物品属性_追加医吸星大法;

		private int _物品属性_追加医真武绝击;

		private int _物品属性_追加升天一护身气甲;

		private int _物品属性_追加医九天真气;

		private int _物品属性_追加医狂意护体;

		private int _物品属性_追加医无中生有;

		private int _物品属性_追加刺荆轲之怒;

		private int _物品属性_追加刺三花聚顶;

		private int _物品属性_追加刺连环飞舞;

		private int _物品属性_追加刺一招残杀;

		private int _物品属性_追加刺心神凝聚;

		private int _物品属性_追加刺致手绝命;

		private int _物品属性_追加刺先发制人;

		private int _物品属性_追加刺千株万手;

		private int _物品属性_追加刺连消带打;

		private int _物品属性_追加刺剑刃乱舞;

		private int _物品属性_追加刺以怒还怒;

		private int _物品属性_追加琴战马奔腾;

		private int _物品属性_追加琴秋江夜泊;

		private int _物品属性_追加琴清心普善;

		private int _物品属性_追加琴阳关三叠;

		private int _物品属性_追加琴汉宫秋月;

		private int _物品属性_追加琴高山流水;

		private int _物品属性_追加琴岳阳三醉;

		private int _物品属性_追加琴梅花三弄;

		private int _物品属性_追加琴鸾凤和鸣;

		private int _物品属性_追加琴阳明春晓;

		private int _物品属性_追加琴潇湘雨夜;

		private int _物品属性_追加韩力劈华山;

		private int _物品属性_追加韩摄魂一击;

		private int _物品属性_追加韩天魔狂血;

		private int _物品属性_追加韩百变神行;

		private int _物品属性_追加韩狂风万破;

		private int _物品属性_追加韩追骨吸元;

		private int _物品属性_追加韩霸气破甲;

		private int _物品属性_追加韩真武绝击;

		private int _物品属性_追加韩暗影绝杀;

		private int _物品属性_追加韩火龙问鼎;

		private int _物品属性_追加韩流光乱舞;

		private int _物品属性_追加谭长虹贯日;

		private int _物品属性_追加谭百变神行;

		private int _物品属性_追加谭新_连环飞舞;

		private int _物品属性_追加谭招式新法;

		private int _物品属性_追加谭狂风万破;

		private int _物品属性_追加谭护身罡气;

		private int _物品属性_追加谭移花接木;

		private int _物品属性_追加谭纵横无双;

		private int _物品属性_追加谭回柳身法;

		private int _物品属性_追加谭怒海狂澜;

		private int _物品属性_追加谭冲冠一怒;

		private int _物品属性_追加升天一遁出逆境;

		private int _物品属性_追加升天二穷途末路;

		private int _物品属性_追加升天四红月狂风;

		private int _物品属性_追加升天四毒蛇出洞;

		private int _物品属性_追加升天四满月狂风;

		private int _物品属性_追加升天四烈日炎炎;

		private int _物品属性_追加升天四长虹贯天;

		private int _物品属性_追加升天四哀鸿遍野;

		private int _物品属性_追加升天夺命连环;

		private int _物品属性_追加升天电光石火;

		private int _物品属性_追加升天精益求精;

		private int _物品属性_追加升天二天地同寿;

		private int _物品属性_追加升天三火凤临朝;

		private int _物品属性_追加升天一破甲刺魂;

		private int _物品属性_追加升天二以退为进;

		private int _物品属性_追加升天一绝影射魂;

		private int _物品属性_追加升天二千钧压驼;

		private int _物品属性_追加升天二万物回春;

		private int _物品属性_追加升天三天外三矢;

		private int _物品属性_追加升天三明镜止水;

		private int _物品属性_追加升天四望梅添花;

		private int _物品属性_追加升天一夜魔缠身;

		private int _物品属性_追加升天二顺水推舟;

		private int _物品属性_追加升天三无情打击;

		private int _物品属性_追加升天三以柔克刚;

		private int _物品属性_追加升天三内息行心;

		private int _物品属性_追加升天二天魔护体;

		private int _物品属性_追加升天一行风弄舞;

		private int _物品属性_追加升天四悬丝诊脉;

		private int _物品属性_追加升天三子夜秋歌;

		private int _物品属性_追加升天二三潭映月;

		private int _物品属性_追加升天一力劈华山;

		private int _物品属性_追加升天一长虹贯日;

		private int _物品属性_追加升天一金钟罡气;

		private int _物品属性_追加升天一运气行心;

		private int _物品属性_追加升天一正本培源;

		private int _物品属性_追加升天一运气疗伤;

		private int _物品属性_追加升天一百变神行;

		private int _物品属性_追加升天一狂风天意;

		private int _物品属性_追加升天一飞花点翠;

		private int _物品属性_追加升天五惊天动地;

		private int _物品属性_追加升天一玄武雷电;

		private int _物品属性_追加升天一陵劲淬砺;

		private int _物品属性_追加升天一愤怒调节;

		private int _物品属性_追加升天二玄武诅咒;

		private int _物品属性_追加升天二杀星光符;

		private int _物品属性_追加升天二蛊毒解除;

		private int _物品属性_追加升天三杀人鬼;

		private int _物品属性_追加升天三技冠群雄;

		private int _物品属性_追加升天三神力保护;

		private int _物品属性_追加升天五致残;

		private int _物品属性_追加升天五龙魂附体;

		private int _物品属性_追加升天五灭世狂舞;

		private int _物品属性_追加升天五千里一击;

		private int _物品属性_追加升天五形移妖相;

		private int _物品属性_追加升天五一招杀神;

		private int _物品属性_追加升天五龙爪纤指手;

		private int _物品属性_追加升天五不死之躯;

		private int _物品属性_追加升天五天魔之力;

		private int _物品属性_追加升天五惊涛骇浪;

		private int _物品属性_追加升天五魔魂之力;

		private int _物品属性_追加升天五破空坠星;

		private int _物品属性_追加升天五尸毒爆发;

		private int _物品属性_升级成功率;

		private int _物品属性_追加伤害值;

		private int _物品属性_降低伤害值;

		private double _物品属性_追加中毒几率百分比;

		private double _物品属性_追加强化;

		private int _物品属性_武功防御力增加;

		private int _物品属性_武功防御力增加New;

		private int _物品属性_获得金钱增加;

		private int _物品属性_死亡损失经验减少;

		private int _物品属性_经验获得增加;

		private int _FLD_RESIDE2;

		private int _背包耐久度;

		private int _提真装备;

		public int _物品属性_拳师狂神降世;

		public int _物品属性_拳师运气疗伤;

		public int _物品属性_拳师力劈华山;

		public int _物品属性_拳师狂风万破;

		public int _物品属性_拳师金刚不坏;

		public int _物品属性_拳师转攻为守;

		public int _物品属性_拳师水火一体;

		public int _物品属性_拳师会心一击;

		public int _物品属性_拳师灵甲护身;

		public int _物品属性_拳师磨杵成针;

		public int _物品属性_拳师末日狂舞;

		public int _物品属性_梅障力激活;

		public int _物品属性_梅障力运用;

		public int _物品属性_梅百变神行;

		public int _物品属性_梅玄武神功;

		public int _物品属性_梅玄武的指点;

		public int _物品属性_梅玄武强击;

		public int _物品属性_梅玄武危化;

		public int _物品属性_梅障力恢复;

		public int _物品属性_梅嫉妒的化身;

		public int _物品属性_梅愤怒爆发;

		public int _物品属性_梅吸血进击;

		public int _物品属性_卢金钟罡气;

		public int _物品属性_卢运气疗伤;

		public int _物品属性_卢连环飞舞;

		public int _物品属性_卢横练太保;

		public int _物品属性_卢狂风万破;

		public int _物品属性_卢真武绝击;

		public int _物品属性_卢流星漫天;

		public int _物品属性_卢乾坤挪移;

		public int _物品属性_卢转攻为守;

		public int _物品属性_卢弱点击破;

		public int _物品属性_卢牢不可破;

		public int _物品属性_神女运气行心;

		public int _物品属性_神女太极心法;

		public int _物品属性_神女神力激发;

		public int _物品属性_神女杀星义气;

		public int _物品属性_神女洗髓易筋;

		public int _物品属性_神女黑花漫开;

		public int _物品属性_神女妙手回春;

		public int _物品属性_神女长功击力;

		public int _物品属性_神女黑花集中;

		public int _物品属性_神女真武绝击;

		public int _物品属性_神女万毒不侵;

		public int _FLD_LEVEL;

		public int _背包装备等级;

		public int _背包装备位置;

		public int _背包装备类型;

		public bool 物品绑定
		{
			get
			{
				try
				{
					byte[] array = new byte[2];
					Buffer.BlockCopy(物品_byte, 76, array, 0, 1);
					return BitConverter.ToInt16(array, 0) != 0;
				}
				catch (Exception)
				{
					return false;
				}
			}
			set
			{
				_物品绑定 = value;
			}
		}

		public long Get物品全局ID => BitConverter.ToInt64(物品_byte, 0);

		public long Get物品ID => BitConverter.ToInt32(物品_byte, 8);

		public int FLD_Intrgration
		{
			get
			{
				try
				{
					if (Get物品ID != 0)
					{
						return World.Itme[(int)Get物品ID].FLD_INTEGRATION;
					}
				}
				catch
				{
				}
				return 0;
			}
		}

		public int FLD_SERIES
		{
			get
			{
				try
				{
					if (Get物品ID != 0)
					{
						return World.Itme[(int)Get物品ID].FLD_SERIES;
					}
				}
				catch
				{
				}
				return 0;
			}
		}

		public int Get物品数量 => BitConverter.ToInt32(物品_byte, 12);

		public string 物品string
		{
			get
			{
				return 得到物品string();
			}
			set
			{
				_物品string = value;
			}
		}

		public int 物品位置
		{
			get
			{
				return _物品位置;
			}
			set
			{
				_物品位置 = value;
			}
		}

		public int 物品类型 => 得到物品类型();

		public int 物品单个重量 => 得到物品单个重量();

		public int 物品总重量 => 得到物品重量();

		public byte[] 物品_byte
		{
			get
			{
				return _物品_byte;
			}
			set
			{
				锁定 = false;
				_物品_byte = value;
			}
		}

		public byte[] 物品数量
		{
			get
			{
				return 得到物品数量();
			}
			set
			{
				设置物品数量(value);
			}
		}

		public byte[] 物品ID => 得到物品ID();

		public byte[] 物品全局ID => 得到全局ID();

		public byte[] 物品属性 => 得到物品属性();

		public Itimesx 属性1
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 20, array, 0, 4);
				属性1 = new Itimesx(array);
				return _属性1;
			}
			set
			{
				_属性1 = value;
			}
		}

		public Itimesx 属性2
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 24, array, 0, 4);
				属性2 = new Itimesx(array);
				return _属性2;
			}
			set
			{
				_属性2 = value;
			}
		}

		public Itimesx 属性3
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 28, array, 0, 4);
				属性3 = new Itimesx(array);
				return _属性3;
			}
			set
			{
				_属性3 = value;
			}
		}

		public Itimesx 属性4
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 32, array, 0, 4);
				属性4 = new Itimesx(array);
				return _属性4;
			}
			set
			{
				_属性4 = value;
			}
		}

		public int 物品防御力
		{
			get
			{
				return _物品防御力;
			}
			set
			{
				_物品防御力 = value;
			}
		}

		public int 物品武功回避
		{
			get
			{
				return _物品武功回避;
			}
			set
			{
				_物品武功回避 = value;
			}
		}

		public int 物品武功命中
		{
			get
			{
				return _物品武功命中;
			}
			set
			{
				_物品武功命中 = value;
			}
		}

		public int 物品隐藏生命
		{
			get
			{
				return _物品隐藏生命;
			}
			set
			{
				_物品隐藏生命 = value;
			}
		}

		public int 物品隐藏攻击
		{
			get
			{
				return _物品隐藏攻击;
			}
			set
			{
				_物品隐藏攻击 = value;
			}
		}

		public int 物品隐藏防御
		{
			get
			{
				return _物品隐藏防御;
			}
			set
			{
				_物品隐藏防御 = value;
			}
		}

		public int 物品增加负重
		{
			get
			{
				return _物品增加负重;
			}
			set
			{
				_物品增加负重 = value;
			}
		}

		public int 物品对怪防御力
		{
			get
			{
				return _物品对怪防御力;
			}
			set
			{
				_物品对怪防御力 = value;
			}
		}

		public int 物品对怪攻击力
		{
			get
			{
				return _物品对怪攻击力;
			}
			set
			{
				_物品对怪攻击力 = value;
			}
		}

		public int 物品_中级附魂_追加_觉醒
		{
			get
			{
				return _物品_中级附魂_追加_觉醒;
			}
			set
			{
				_物品_中级附魂_追加_觉醒 = value;
			}
		}

		public int 物品攻击力
		{
			get
			{
				return _物品攻击力;
			}
			set
			{
				_物品攻击力 = value;
			}
		}

		public int 物品攻击力MAX
		{
			get
			{
				return _物品攻击力MAX;
			}
			set
			{
				_物品攻击力MAX = value;
			}
		}

		public int 物品属性_障力增加
		{
			get
			{
				return _物品属性_障力增加;
			}
			set
			{
				_物品属性_障力增加 = value;
			}
		}

		public int 物品属性强类型
		{
			get
			{
				return _物品属性强类型;
			}
			set
			{
				_物品属性强类型 = value;
			}
		}

		public int 物品属性强
		{
			get
			{
				return _物品属性强;
			}
			set
			{
				_物品属性强 = value;
			}
		}

		public int 物品属性阶段类型
		{
			get
			{
				return _物品属性阶段类型;
			}
			set
			{
				_物品属性阶段类型 = value;
			}
		}

		public int 物品属性阶段数
		{
			get
			{
				return _物品属性阶段数;
			}
			set
			{
				_物品属性阶段数 = value;
			}
		}

		public int 物品属性_攻击力增加
		{
			get
			{
				return _物品属性_攻击力增加;
			}
			set
			{
				_物品属性_攻击力增加 = value;
			}
		}

		public int 物品攻击力New
		{
			get
			{
				return _物品攻击力New;
			}
			set
			{
				_物品攻击力New = value;
			}
		}

		public int 物品攻击力MaxNew
		{
			get
			{
				return _物品攻击力MaxNew;
			}
			set
			{
				_物品攻击力MaxNew = value;
			}
		}

		public int 物品属性_防御力增加
		{
			get
			{
				return _物品属性_防御力增加;
			}
			set
			{
				_物品属性_防御力增加 = value;
			}
		}

		public int 物品属性_生命力增加
		{
			get
			{
				return _物品属性_生命力增加;
			}
			set
			{
				_物品属性_生命力增加 = value;
			}
		}

		public int 物品属性_障力恢复量增加
		{
			get
			{
				return _物品属性_障力恢复量增加;
			}
			set
			{
				_物品属性_障力恢复量增加 = value;
			}
		}

		public int 物品属性_内功力增加
		{
			get
			{
				return _物品属性_内功力增加;
			}
			set
			{
				_物品属性_内功力增加 = value;
			}
		}

		public int 物品属性_命中率增加
		{
			get
			{
				return _物品属性_命中率增加;
			}
			set
			{
				_物品属性_命中率增加 = value;
			}
		}

		public int 物品属性_回避率增加
		{
			get
			{
				return _物品属性_回避率增加;
			}
			set
			{
				_物品属性_回避率增加 = value;
			}
		}

		public int 物品属性_武功攻击力
		{
			get
			{
				return _物品属性_武功攻击力;
			}
			set
			{
				_物品属性_武功攻击力 = value;
			}
		}

		public int 物品属性_武功攻击力New
		{
			get
			{
				return _物品属性_武功攻击力New;
			}
			set
			{
				_物品属性_武功攻击力New = value;
			}
		}

		public double 物品属性_降低百分比攻击
		{
			get
			{
				return _物品属性_降低百分比攻击;
			}
			set
			{
				_物品属性_降低百分比攻击 = value;
			}
		}

		public double 物品属性_降低百分比防御
		{
			get
			{
				return _物品属性_降低百分比防御;
			}
			set
			{
				_物品属性_降低百分比防御 = value;
			}
		}

		public double 物品属性_对怪伤害
		{
			get
			{
				return _物品属性_对怪伤害;
			}
			set
			{
				_物品属性_对怪伤害 = value;
			}
		}

		public double 物品属性_增加百分比命中
		{
			get
			{
				return _物品属性_增加百分比命中;
			}
			set
			{
				_物品属性_增加百分比命中 = value;
			}
		}

		public double 物品属性_增加百分比回避
		{
			get
			{
				return _物品属性_增加百分比回避;
			}
			set
			{
				_物品属性_增加百分比回避 = value;
			}
		}

		public double 物品属性_初始化愤怒概率百分比
		{
			get
			{
				return _物品属性_初始化愤怒概率百分比;
			}
			set
			{
				_物品属性_初始化愤怒概率百分比 = value;
			}
		}

		public int 物品属性_愤怒值增加
		{
			get
			{
				return _物品属性_愤怒值增加;
			}
			set
			{
				_物品属性_愤怒值增加 = value;
			}
		}

		public int 物品属性_全部气功等级增加
		{
			get
			{
				return _物品属性_全部气功等级增加;
			}
			set
			{
				_物品属性_全部气功等级增加 = value;
			}
		}

		public int 物品属性_追加刀力劈华山
		{
			get
			{
				return _物品属性_追加刀力劈华山;
			}
			set
			{
				_物品属性_追加刀力劈华山 = value;
			}
		}

		public int 物品属性_追加刀摄魂一击
		{
			get
			{
				return _物品属性_追加刀摄魂一击;
			}
			set
			{
				_物品属性_追加刀摄魂一击 = value;
			}
		}

		public int 物品属性_追加刀连环飞舞
		{
			get
			{
				return _物品属性_追加刀连环飞舞;
			}
			set
			{
				_物品属性_追加刀连环飞舞 = value;
			}
		}

		public int 物品属性_追加升天三火龙之火
		{
			get
			{
				return _物品属性_追加升天三火龙之火;
			}
			set
			{
				_物品属性_追加升天三火龙之火 = value;
			}
		}

		public int 物品属性_追加刀狂风万破
		{
			get
			{
				return _物品属性_追加刀狂风万破;
			}
			set
			{
				_物品属性_追加刀狂风万破 = value;
			}
		}

		public int 物品属性_追加刀四两千斤
		{
			get
			{
				return _物品属性_追加刀四两千斤;
			}
			set
			{
				_物品属性_追加刀四两千斤 = value;
			}
		}

		public int 物品属性_追加刀霸气破甲
		{
			get
			{
				return _物品属性_追加刀霸气破甲;
			}
			set
			{
				_物品属性_追加刀霸气破甲 = value;
			}
		}

		public int 物品属性_追加气沉丹田
		{
			get
			{
				return _物品属性_追加气沉丹田;
			}
			set
			{
				_物品属性_追加气沉丹田 = value;
			}
		}

		public int 物品属性_追加刀真武绝击
		{
			get
			{
				return _物品属性_追加刀真武绝击;
			}
			set
			{
				_物品属性_追加刀真武绝击 = value;
			}
		}

		public int 物品属性_追加刀暗影绝杀
		{
			get
			{
				return _物品属性_追加刀暗影绝杀;
			}
			set
			{
				_物品属性_追加刀暗影绝杀 = value;
			}
		}

		public int 物品属性_追加刀稳如泰山
		{
			get
			{
				return _物品属性_追加刀稳如泰山;
			}
			set
			{
				_物品属性_追加刀稳如泰山 = value;
			}
		}

		public int 物品属性_追加刀流光乱舞
		{
			get
			{
				return _物品属性_追加刀流光乱舞;
			}
			set
			{
				_物品属性_追加刀流光乱舞 = value;
			}
		}

		public int 物品属性_追加刀梵音破镜
		{
			get
			{
				return _物品属性_追加刀梵音破镜;
			}
			set
			{
				_物品属性_追加刀梵音破镜 = value;
			}
		}

		public int 物品属性_追加剑长虹贯日
		{
			get
			{
				return _物品属性_追加剑长虹贯日;
			}
			set
			{
				_物品属性_追加剑长虹贯日 = value;
			}
		}

		public int 物品属性_追加剑百变神行
		{
			get
			{
				return _物品属性_追加剑百变神行;
			}
			set
			{
				_物品属性_追加剑百变神行 = value;
			}
		}

		public int 物品属性_追加剑连环飞舞
		{
			get
			{
				return _物品属性_追加剑连环飞舞;
			}
			set
			{
				_物品属性_追加剑连环飞舞 = value;
			}
		}

		public int 物品属性_追加剑破天一剑
		{
			get
			{
				return _物品属性_追加剑破天一剑;
			}
			set
			{
				_物品属性_追加剑破天一剑 = value;
			}
		}

		public int 物品属性_追加剑狂风万破
		{
			get
			{
				return _物品属性_追加剑狂风万破;
			}
			set
			{
				_物品属性_追加剑狂风万破 = value;
			}
		}

		public int 物品属性_追加升天一护身罡气
		{
			get
			{
				return _物品属性_追加升天一护身罡气;
			}
			set
			{
				_物品属性_追加升天一护身罡气 = value;
			}
		}

		public int 物品属性_追加剑移花接木
		{
			get
			{
				return _物品属性_追加剑移花接木;
			}
			set
			{
				_物品属性_追加剑移花接木 = value;
			}
		}

		public int 物品属性_追加剑回柳身法
		{
			get
			{
				return _物品属性_追加剑回柳身法;
			}
			set
			{
				_物品属性_追加剑回柳身法 = value;
			}
		}

		public int 物品属性_追加剑怒海狂澜
		{
			get
			{
				return _物品属性_追加剑怒海狂澜;
			}
			set
			{
				_物品属性_追加剑怒海狂澜 = value;
			}
		}

		public int 物品属性_追加剑冲冠一怒
		{
			get
			{
				return _物品属性_追加剑冲冠一怒;
			}
			set
			{
				_物品属性_追加剑冲冠一怒 = value;
			}
		}

		public int 物品属性_追加剑无坚不摧
		{
			get
			{
				return _物品属性_追加剑无坚不摧;
			}
			set
			{
				_物品属性_追加剑无坚不摧 = value;
			}
		}

		public int 物品属性_追加剑乘胜追击
		{
			get
			{
				return _物品属性_追加剑乘胜追击;
			}
			set
			{
				_物品属性_追加剑乘胜追击 = value;
			}
		}

		public int 物品属性_追加枪金钟罩气
		{
			get
			{
				return _物品属性_追加枪金钟罩气;
			}
			set
			{
				_物品属性_追加枪金钟罩气 = value;
			}
		}

		public int 物品属性_追加枪运气疗伤
		{
			get
			{
				return _物品属性_追加枪运气疗伤;
			}
			set
			{
				_物品属性_追加枪运气疗伤 = value;
			}
		}

		public int 物品属性_追加枪连环飞舞
		{
			get
			{
				return _物品属性_追加枪连环飞舞;
			}
			set
			{
				_物品属性_追加枪连环飞舞 = value;
			}
		}

		public int 物品属性_追加升天三怒意之火
		{
			get
			{
				return _物品属性_追加升天三怒意之火;
			}
			set
			{
				_物品属性_追加升天三怒意之火 = value;
			}
		}

		public int 物品属性_追加枪狂风万破
		{
			get
			{
				return _物品属性_追加枪狂风万破;
			}
			set
			{
				_物品属性_追加枪狂风万破 = value;
			}
		}

		public int 物品属性_追加枪横练太保
		{
			get
			{
				return _物品属性_追加枪横练太保;
			}
			set
			{
				_物品属性_追加枪横练太保 = value;
			}
		}

		public int 物品属性_追加枪乾坤挪移
		{
			get
			{
				return _物品属性_追加枪乾坤挪移;
			}
			set
			{
				_物品属性_追加枪乾坤挪移 = value;
			}
		}

		public int 物品属性_追加枪灵甲护身
		{
			get
			{
				return _物品属性_追加枪灵甲护身;
			}
			set
			{
				_物品属性_追加枪灵甲护身 = value;
			}
		}

		public int 物品属性_追加枪狂神降世
		{
			get
			{
				return _物品属性_追加枪狂神降世;
			}
			set
			{
				_物品属性_追加枪狂神降世 = value;
			}
		}

		public int 物品属性_追加枪转守为攻
		{
			get
			{
				return _物品属性_追加枪转守为攻;
			}
			set
			{
				_物品属性_追加枪转守为攻 = value;
			}
		}

		public int 物品属性_追加枪末日狂舞
		{
			get
			{
				return _物品属性_追加枪末日狂舞;
			}
			set
			{
				_物品属性_追加枪末日狂舞 = value;
			}
		}

		public int 物品属性_追加枪怒意之吼
		{
			get
			{
				return _物品属性_追加枪怒意之吼;
			}
			set
			{
				_物品属性_追加枪怒意之吼 = value;
			}
		}

		public int 物品属性_追加弓百步穿杨
		{
			get
			{
				return _物品属性_追加弓百步穿杨;
			}
			set
			{
				_物品属性_追加弓百步穿杨 = value;
			}
		}

		public int 物品属性_追加弓猎鹰之眼
		{
			get
			{
				return _物品属性_追加弓猎鹰之眼;
			}
			set
			{
				_物品属性_追加弓猎鹰之眼 = value;
			}
		}

		public int 物品属性_追加弓凝神聚气
		{
			get
			{
				return _物品属性_追加弓凝神聚气;
			}
			set
			{
				_物品属性_追加弓凝神聚气 = value;
			}
		}

		public int 物品属性_追加弓回流真气
		{
			get
			{
				return _物品属性_追加弓回流真气;
			}
			set
			{
				_物品属性_追加弓回流真气 = value;
			}
		}

		public int 物品属性_追加弓狂风万破
		{
			get
			{
				return _物品属性_追加弓狂风万破;
			}
			set
			{
				_物品属性_追加弓狂风万破 = value;
			}
		}

		public int 物品属性_追加弓正本培元
		{
			get
			{
				return _物品属性_追加弓正本培元;
			}
			set
			{
				_物品属性_追加弓正本培元 = value;
			}
		}

		public int 物品属性_追加弓心神凝聚
		{
			get
			{
				return _物品属性_追加弓心神凝聚;
			}
			set
			{
				_物品属性_追加弓心神凝聚 = value;
			}
		}

		public int 物品属性_追加弓流星三矢
		{
			get
			{
				return _物品属性_追加弓流星三矢;
			}
			set
			{
				_物品属性_追加弓流星三矢 = value;
			}
		}

		public int 物品属性_追加弓锐利之箭
		{
			get
			{
				return _物品属性_追加弓锐利之箭;
			}
			set
			{
				_物品属性_追加弓锐利之箭 = value;
			}
		}

		public int 物品属性_追加弓无明暗矢
		{
			get
			{
				return _物品属性_追加弓无明暗矢;
			}
			set
			{
				_物品属性_追加弓无明暗矢 = value;
			}
		}

		public int 物品属性_追加弓致命绝杀
		{
			get
			{
				return _物品属性_追加弓致命绝杀;
			}
			set
			{
				_物品属性_追加弓致命绝杀 = value;
			}
		}

		public int 物品属性_追加医运气行心
		{
			get
			{
				return _物品属性_追加医运气行心;
			}
			set
			{
				_物品属性_追加医运气行心 = value;
			}
		}

		public int 物品属性_追加医太极心法
		{
			get
			{
				return _物品属性_追加医太极心法;
			}
			set
			{
				_物品属性_追加医太极心法 = value;
			}
		}

		public int 物品属性_追加医体血倍增
		{
			get
			{
				return _物品属性_追加医体血倍增;
			}
			set
			{
				_物品属性_追加医体血倍增 = value;
			}
		}

		public int 物品属性_追加医洗髓易经
		{
			get
			{
				return _物品属性_追加医洗髓易经;
			}
			set
			{
				_物品属性_追加医洗髓易经 = value;
			}
		}

		public int 物品属性_追加医妙手回春
		{
			get
			{
				return _物品属性_追加医妙手回春;
			}
			set
			{
				_物品属性_追加医妙手回春 = value;
			}
		}

		public int 物品属性_追加医长功攻击
		{
			get
			{
				return _物品属性_追加医长功攻击;
			}
			set
			{
				_物品属性_追加医长功攻击 = value;
			}
		}

		public int 物品属性_追加医吸星大法
		{
			get
			{
				return _物品属性_追加医吸星大法;
			}
			set
			{
				_物品属性_追加医吸星大法 = value;
			}
		}

		public int 物品属性_追加医真武绝击
		{
			get
			{
				return _物品属性_追加医真武绝击;
			}
			set
			{
				_物品属性_追加医真武绝击 = value;
			}
		}

		public int 物品属性_追加升天一护身气甲
		{
			get
			{
				return _物品属性_追加升天一护身气甲;
			}
			set
			{
				_物品属性_追加升天一护身气甲 = value;
			}
		}

		public int 物品属性_追加医九天真气
		{
			get
			{
				return _物品属性_追加医九天真气;
			}
			set
			{
				_物品属性_追加医九天真气 = value;
			}
		}

		public int 物品属性_追加医狂意护体
		{
			get
			{
				return _物品属性_追加医狂意护体;
			}
			set
			{
				_物品属性_追加医狂意护体 = value;
			}
		}

		public int 物品属性_追加医无中生有
		{
			get
			{
				return _物品属性_追加医无中生有;
			}
			set
			{
				_物品属性_追加医无中生有 = value;
			}
		}

		public int 物品属性_追加刺荆轲之怒
		{
			get
			{
				return _物品属性_追加刺荆轲之怒;
			}
			set
			{
				_物品属性_追加刺荆轲之怒 = value;
			}
		}

		public int 物品属性_追加刺三花聚顶
		{
			get
			{
				return _物品属性_追加刺三花聚顶;
			}
			set
			{
				_物品属性_追加刺三花聚顶 = value;
			}
		}

		public int 物品属性_追加刺连环飞舞
		{
			get
			{
				return _物品属性_追加刺连环飞舞;
			}
			set
			{
				_物品属性_追加刺连环飞舞 = value;
			}
		}

		public int 物品属性_追加刺一招残杀
		{
			get
			{
				return _物品属性_追加刺一招残杀;
			}
			set
			{
				_物品属性_追加刺一招残杀 = value;
			}
		}

		public int 物品属性_追加刺心神凝聚
		{
			get
			{
				return _物品属性_追加刺心神凝聚;
			}
			set
			{
				_物品属性_追加刺心神凝聚 = value;
			}
		}

		public int 物品属性_追加刺致手绝命
		{
			get
			{
				return _物品属性_追加刺致手绝命;
			}
			set
			{
				_物品属性_追加刺致手绝命 = value;
			}
		}

		public int 物品属性_追加刺先发制人
		{
			get
			{
				return _物品属性_追加刺先发制人;
			}
			set
			{
				_物品属性_追加刺先发制人 = value;
			}
		}

		public int 物品属性_追加刺千株万手
		{
			get
			{
				return _物品属性_追加刺千株万手;
			}
			set
			{
				_物品属性_追加刺千株万手 = value;
			}
		}

		public int 物品属性_追加刺连消带打
		{
			get
			{
				return _物品属性_追加刺连消带打;
			}
			set
			{
				_物品属性_追加刺连消带打 = value;
			}
		}

		public int 物品属性_追加刺剑刃乱舞
		{
			get
			{
				return _物品属性_追加刺剑刃乱舞;
			}
			set
			{
				_物品属性_追加刺剑刃乱舞 = value;
			}
		}

		public int 物品属性_追加刺以怒还怒
		{
			get
			{
				return _物品属性_追加刺以怒还怒;
			}
			set
			{
				_物品属性_追加刺以怒还怒 = value;
			}
		}

		public int 物品属性_追加琴战马奔腾
		{
			get
			{
				return _物品属性_追加琴战马奔腾;
			}
			set
			{
				_物品属性_追加琴战马奔腾 = value;
			}
		}

		public int 物品属性_追加琴秋江夜泊
		{
			get
			{
				return _物品属性_追加琴秋江夜泊;
			}
			set
			{
				_物品属性_追加琴秋江夜泊 = value;
			}
		}

		public int 物品属性_追加琴清心普善
		{
			get
			{
				return _物品属性_追加琴清心普善;
			}
			set
			{
				_物品属性_追加琴清心普善 = value;
			}
		}

		public int 物品属性_追加琴阳关三叠
		{
			get
			{
				return _物品属性_追加琴阳关三叠;
			}
			set
			{
				_物品属性_追加琴阳关三叠 = value;
			}
		}

		public int 物品属性_追加琴汉宫秋月
		{
			get
			{
				return _物品属性_追加琴汉宫秋月;
			}
			set
			{
				_物品属性_追加琴汉宫秋月 = value;
			}
		}

		public int 物品属性_追加琴高山流水
		{
			get
			{
				return _物品属性_追加琴高山流水;
			}
			set
			{
				_物品属性_追加琴高山流水 = value;
			}
		}

		public int 物品属性_追加琴岳阳三醉
		{
			get
			{
				return _物品属性_追加琴岳阳三醉;
			}
			set
			{
				_物品属性_追加琴岳阳三醉 = value;
			}
		}

		public int 物品属性_追加琴梅花三弄
		{
			get
			{
				return _物品属性_追加琴梅花三弄;
			}
			set
			{
				_物品属性_追加琴梅花三弄 = value;
			}
		}

		public int 物品属性_追加琴鸾凤和鸣
		{
			get
			{
				return _物品属性_追加琴鸾凤和鸣;
			}
			set
			{
				_物品属性_追加琴鸾凤和鸣 = value;
			}
		}

		public int 物品属性_追加琴阳明春晓
		{
			get
			{
				return _物品属性_追加琴阳明春晓;
			}
			set
			{
				_物品属性_追加琴阳明春晓 = value;
			}
		}

		public int 物品属性_追加琴潇湘雨夜
		{
			get
			{
				return _物品属性_追加琴潇湘雨夜;
			}
			set
			{
				_物品属性_追加琴潇湘雨夜 = value;
			}
		}

		public int 物品属性_追加韩力劈华山
		{
			get
			{
				return _物品属性_追加韩力劈华山;
			}
			set
			{
				_物品属性_追加韩力劈华山 = value;
			}
		}

		public int 物品属性_追加韩摄魂一击
		{
			get
			{
				return _物品属性_追加韩摄魂一击;
			}
			set
			{
				_物品属性_追加韩摄魂一击 = value;
			}
		}

		public int 物品属性_追加韩天魔狂血
		{
			get
			{
				return _物品属性_追加韩天魔狂血;
			}
			set
			{
				_物品属性_追加韩天魔狂血 = value;
			}
		}

		public int 物品属性_追加韩百变神行
		{
			get
			{
				return _物品属性_追加韩百变神行;
			}
			set
			{
				_物品属性_追加韩百变神行 = value;
			}
		}

		public int 物品属性_追加韩狂风万破
		{
			get
			{
				return _物品属性_追加韩狂风万破;
			}
			set
			{
				_物品属性_追加韩狂风万破 = value;
			}
		}

		public int 物品属性_追加韩追骨吸元
		{
			get
			{
				return _物品属性_追加韩追骨吸元;
			}
			set
			{
				_物品属性_追加韩追骨吸元 = value;
			}
		}

		public int 物品属性_追加韩霸气破甲
		{
			get
			{
				return _物品属性_追加韩霸气破甲;
			}
			set
			{
				_物品属性_追加韩霸气破甲 = value;
			}
		}

		public int 物品属性_追加韩真武绝击
		{
			get
			{
				return _物品属性_追加韩真武绝击;
			}
			set
			{
				_物品属性_追加韩真武绝击 = value;
			}
		}

		public int 物品属性_追加韩暗影绝杀
		{
			get
			{
				return _物品属性_追加韩暗影绝杀;
			}
			set
			{
				_物品属性_追加韩暗影绝杀 = value;
			}
		}

		public int 物品属性_追加韩火龙问鼎
		{
			get
			{
				return _物品属性_追加韩火龙问鼎;
			}
			set
			{
				_物品属性_追加韩火龙问鼎 = value;
			}
		}

		public int 物品属性_追加韩流光乱舞
		{
			get
			{
				return _物品属性_追加韩流光乱舞;
			}
			set
			{
				_物品属性_追加韩流光乱舞 = value;
			}
		}

		public int 物品属性_追加谭长虹贯日
		{
			get
			{
				return _物品属性_追加谭长虹贯日;
			}
			set
			{
				_物品属性_追加谭长虹贯日 = value;
			}
		}

		public int 物品属性_追加谭百变神行
		{
			get
			{
				return _物品属性_追加谭百变神行;
			}
			set
			{
				_物品属性_追加谭百变神行 = value;
			}
		}

		public int 物品属性_追加谭新_连环飞舞
		{
			get
			{
				return _物品属性_追加谭新_连环飞舞;
			}
			set
			{
				_物品属性_追加谭新_连环飞舞 = value;
			}
		}

		public int 物品属性_追加谭招式新法
		{
			get
			{
				return _物品属性_追加谭招式新法;
			}
			set
			{
				_物品属性_追加谭招式新法 = value;
			}
		}

		public int 物品属性_追加谭狂风万破
		{
			get
			{
				return _物品属性_追加谭狂风万破;
			}
			set
			{
				_物品属性_追加谭狂风万破 = value;
			}
		}

		public int 物品属性_追加谭护身罡气
		{
			get
			{
				return _物品属性_追加谭护身罡气;
			}
			set
			{
				_物品属性_追加谭护身罡气 = value;
			}
		}

		public int 物品属性_追加谭移花接木
		{
			get
			{
				return _物品属性_追加谭移花接木;
			}
			set
			{
				_物品属性_追加谭移花接木 = value;
			}
		}

		public int 物品属性_追加谭纵横无双
		{
			get
			{
				return _物品属性_追加谭纵横无双;
			}
			set
			{
				_物品属性_追加谭纵横无双 = value;
			}
		}

		public int 物品属性_追加谭回柳身法
		{
			get
			{
				return _物品属性_追加谭回柳身法;
			}
			set
			{
				_物品属性_追加谭回柳身法 = value;
			}
		}

		public int 物品属性_追加谭怒海狂澜
		{
			get
			{
				return _物品属性_追加谭怒海狂澜;
			}
			set
			{
				_物品属性_追加谭怒海狂澜 = value;
			}
		}

		public int 物品属性_追加谭冲冠一怒
		{
			get
			{
				return _物品属性_追加谭冲冠一怒;
			}
			set
			{
				_物品属性_追加谭冲冠一怒 = value;
			}
		}

		public int 物品属性_追加升天一遁出逆境
		{
			get
			{
				return _物品属性_追加升天一遁出逆境;
			}
			set
			{
				_物品属性_追加升天一遁出逆境 = value;
			}
		}

		public int 物品属性_追加升天二穷途末路
		{
			get
			{
				return _物品属性_追加升天二穷途末路;
			}
			set
			{
				_物品属性_追加升天二穷途末路 = value;
			}
		}

		public int 物品属性_追加升天四红月狂风
		{
			get
			{
				return _物品属性_追加升天四红月狂风;
			}
			set
			{
				_物品属性_追加升天四红月狂风 = value;
			}
		}

		public int 物品属性_追加升天四毒蛇出洞
		{
			get
			{
				return _物品属性_追加升天四毒蛇出洞;
			}
			set
			{
				_物品属性_追加升天四毒蛇出洞 = value;
			}
		}

		public int 物品属性_追加升天四满月狂风
		{
			get
			{
				return _物品属性_追加升天四满月狂风;
			}
			set
			{
				_物品属性_追加升天四满月狂风 = value;
			}
		}

		public int 物品属性_追加升天四烈日炎炎
		{
			get
			{
				return _物品属性_追加升天四烈日炎炎;
			}
			set
			{
				_物品属性_追加升天四烈日炎炎 = value;
			}
		}

		public int 物品属性_追加升天四长虹贯天
		{
			get
			{
				return _物品属性_追加升天四长虹贯天;
			}
			set
			{
				_物品属性_追加升天四长虹贯天 = value;
			}
		}

		public int 物品属性_追加升天四哀鸿遍野
		{
			get
			{
				return _物品属性_追加升天四哀鸿遍野;
			}
			set
			{
				_物品属性_追加升天四哀鸿遍野 = value;
			}
		}

		public int 物品属性_追加升天夺命连环
		{
			get
			{
				return _物品属性_追加升天夺命连环;
			}
			set
			{
				_物品属性_追加升天夺命连环 = value;
			}
		}

		public int 物品属性_追加升天电光石火
		{
			get
			{
				return _物品属性_追加升天电光石火;
			}
			set
			{
				_物品属性_追加升天电光石火 = value;
			}
		}

		public int 物品属性_追加升天精益求精
		{
			get
			{
				return _物品属性_追加升天精益求精;
			}
			set
			{
				_物品属性_追加升天精益求精 = value;
			}
		}

		public int 物品属性_追加升天二天地同寿
		{
			get
			{
				return _物品属性_追加升天二天地同寿;
			}
			set
			{
				_物品属性_追加升天二天地同寿 = value;
			}
		}

		public int 物品属性_追加升天三火凤临朝
		{
			get
			{
				return _物品属性_追加升天三火凤临朝;
			}
			set
			{
				_物品属性_追加升天三火凤临朝 = value;
			}
		}

		public int 物品属性_追加升天一破甲刺魂
		{
			get
			{
				return _物品属性_追加升天一破甲刺魂;
			}
			set
			{
				_物品属性_追加升天一破甲刺魂 = value;
			}
		}

		public int 物品属性_追加升天二以退为进
		{
			get
			{
				return _物品属性_追加升天二以退为进;
			}
			set
			{
				_物品属性_追加升天二以退为进 = value;
			}
		}

		public int 物品属性_追加升天一绝影射魂
		{
			get
			{
				return _物品属性_追加升天一绝影射魂;
			}
			set
			{
				_物品属性_追加升天一绝影射魂 = value;
			}
		}

		public int 物品属性_追加升天二千钧压驼
		{
			get
			{
				return _物品属性_追加升天二千钧压驼;
			}
			set
			{
				_物品属性_追加升天二千钧压驼 = value;
			}
		}

		public int 物品属性_追加升天二万物回春
		{
			get
			{
				return _物品属性_追加升天二万物回春;
			}
			set
			{
				_物品属性_追加升天二万物回春 = value;
			}
		}

		public int 物品属性_追加升天三天外三矢
		{
			get
			{
				return _物品属性_追加升天三天外三矢;
			}
			set
			{
				_物品属性_追加升天三天外三矢 = value;
			}
		}

		public int 物品属性_追加升天三明镜止水
		{
			get
			{
				return _物品属性_追加升天三明镜止水;
			}
			set
			{
				_物品属性_追加升天三明镜止水 = value;
			}
		}

		public int 物品属性_追加升天四望梅添花
		{
			get
			{
				return _物品属性_追加升天四望梅添花;
			}
			set
			{
				_物品属性_追加升天四望梅添花 = value;
			}
		}

		public int 物品属性_追加升天一夜魔缠身
		{
			get
			{
				return _物品属性_追加升天一夜魔缠身;
			}
			set
			{
				_物品属性_追加升天一夜魔缠身 = value;
			}
		}

		public int 物品属性_追加升天二顺水推舟
		{
			get
			{
				return _物品属性_追加升天二顺水推舟;
			}
			set
			{
				_物品属性_追加升天二顺水推舟 = value;
			}
		}

		public int 物品属性_追加升天三无情打击
		{
			get
			{
				return _物品属性_追加升天三无情打击;
			}
			set
			{
				_物品属性_追加升天三无情打击 = value;
			}
		}

		public int 物品属性_追加升天三以柔克刚
		{
			get
			{
				return _物品属性_追加升天三以柔克刚;
			}
			set
			{
				_物品属性_追加升天三以柔克刚 = value;
			}
		}

		public int 物品属性_追加升天三内息行心
		{
			get
			{
				return _物品属性_追加升天三内息行心;
			}
			set
			{
				_物品属性_追加升天三内息行心 = value;
			}
		}

		public int 物品属性_追加升天二天魔护体
		{
			get
			{
				return _物品属性_追加升天二天魔护体;
			}
			set
			{
				_物品属性_追加升天二天魔护体 = value;
			}
		}

		public int 物品属性_追加升天一行风弄舞
		{
			get
			{
				return _物品属性_追加升天一行风弄舞;
			}
			set
			{
				_物品属性_追加升天一行风弄舞 = value;
			}
		}

		public int 物品属性_追加升天四悬丝诊脉
		{
			get
			{
				return _物品属性_追加升天四悬丝诊脉;
			}
			set
			{
				_物品属性_追加升天四悬丝诊脉 = value;
			}
		}

		public int 物品属性_追加升天三子夜秋歌
		{
			get
			{
				return _物品属性_追加升天三子夜秋歌;
			}
			set
			{
				_物品属性_追加升天三子夜秋歌 = value;
			}
		}

		public int 物品属性_追加升天二三潭映月
		{
			get
			{
				return _物品属性_追加升天二三潭映月;
			}
			set
			{
				_物品属性_追加升天二三潭映月 = value;
			}
		}

		public int 物品属性_追加升天一力劈华山
		{
			get
			{
				return _物品属性_追加升天一力劈华山;
			}
			set
			{
				_物品属性_追加升天一力劈华山 = value;
			}
		}

		public int 物品属性_追加升天一长虹贯日
		{
			get
			{
				return _物品属性_追加升天一长虹贯日;
			}
			set
			{
				_物品属性_追加升天一长虹贯日 = value;
			}
		}

		public int 物品属性_追加升天一金钟罡气
		{
			get
			{
				return _物品属性_追加升天一金钟罡气;
			}
			set
			{
				_物品属性_追加升天一金钟罡气 = value;
			}
		}

		public int 物品属性_追加升天一运气行心
		{
			get
			{
				return _物品属性_追加升天一运气行心;
			}
			set
			{
				_物品属性_追加升天一运气行心 = value;
			}
		}

		public int 物品属性_追加升天一正本培源
		{
			get
			{
				return _物品属性_追加升天一正本培源;
			}
			set
			{
				_物品属性_追加升天一正本培源 = value;
			}
		}

		public int 物品属性_追加升天一运气疗伤
		{
			get
			{
				return _物品属性_追加升天一运气疗伤;
			}
			set
			{
				_物品属性_追加升天一运气疗伤 = value;
			}
		}

		public int 物品属性_追加升天一百变神行
		{
			get
			{
				return _物品属性_追加升天一百变神行;
			}
			set
			{
				_物品属性_追加升天一百变神行 = value;
			}
		}

		public int 物品属性_追加升天一狂风天意
		{
			get
			{
				return _物品属性_追加升天一狂风天意;
			}
			set
			{
				_物品属性_追加升天一狂风天意 = value;
			}
		}

		public int 物品属性_追加升天一飞花点翠
		{
			get
			{
				return _物品属性_追加升天一飞花点翠;
			}
			set
			{
				_物品属性_追加升天一飞花点翠 = value;
			}
		}

		public int 物品属性_追加升天五惊天动地
		{
			get
			{
				return _物品属性_追加升天五惊天动地;
			}
			set
			{
				_物品属性_追加升天五惊天动地 = value;
			}
		}

		public int 物品属性_追加升天一玄武雷电
		{
			get
			{
				return _物品属性_追加升天一玄武雷电;
			}
			set
			{
				_物品属性_追加升天一玄武雷电 = value;
			}
		}

		public int 物品属性_追加升天一陵劲淬砺
		{
			get
			{
				return _物品属性_追加升天一陵劲淬砺;
			}
			set
			{
				_物品属性_追加升天一陵劲淬砺 = value;
			}
		}

		public int 物品属性_追加升天一愤怒调节
		{
			get
			{
				return _物品属性_追加升天一愤怒调节;
			}
			set
			{
				_物品属性_追加升天一愤怒调节 = value;
			}
		}

		public int 物品属性_追加升天二玄武诅咒
		{
			get
			{
				return _物品属性_追加升天二玄武诅咒;
			}
			set
			{
				_物品属性_追加升天二玄武诅咒 = value;
			}
		}

		public int 物品属性_追加升天二杀星光符
		{
			get
			{
				return _物品属性_追加升天二杀星光符;
			}
			set
			{
				_物品属性_追加升天二杀星光符 = value;
			}
		}

		public int 物品属性_追加升天二蛊毒解除
		{
			get
			{
				return _物品属性_追加升天二蛊毒解除;
			}
			set
			{
				_物品属性_追加升天二蛊毒解除 = value;
			}
		}

		public int 物品属性_追加升天三杀人鬼
		{
			get
			{
				return _物品属性_追加升天三杀人鬼;
			}
			set
			{
				_物品属性_追加升天三杀人鬼 = value;
			}
		}

		public int 物品属性_追加升天三技冠群雄
		{
			get
			{
				return _物品属性_追加升天三技冠群雄;
			}
			set
			{
				_物品属性_追加升天三技冠群雄 = value;
			}
		}

		public int 物品属性_追加升天三神力保护
		{
			get
			{
				return _物品属性_追加升天三神力保护;
			}
			set
			{
				_物品属性_追加升天三神力保护 = value;
			}
		}

		public int 物品属性_追加升天五致残
		{
			get
			{
				return _物品属性_追加升天五致残;
			}
			set
			{
				_物品属性_追加升天五致残 = value;
			}
		}

		public int 物品属性_追加升天五龙魂附体
		{
			get
			{
				return _物品属性_追加升天五龙魂附体;
			}
			set
			{
				_物品属性_追加升天五龙魂附体 = value;
			}
		}

		public int 物品属性_追加升天五灭世狂舞
		{
			get
			{
				return _物品属性_追加升天五灭世狂舞;
			}
			set
			{
				_物品属性_追加升天五灭世狂舞 = value;
			}
		}

		public int 物品属性_追加升天五千里一击
		{
			get
			{
				return _物品属性_追加升天五千里一击;
			}
			set
			{
				_物品属性_追加升天五千里一击 = value;
			}
		}

		public int 物品属性_追加升天五形移妖相
		{
			get
			{
				return _物品属性_追加升天五形移妖相;
			}
			set
			{
				_物品属性_追加升天五形移妖相 = value;
			}
		}

		public int 物品属性_追加升天五一招杀神
		{
			get
			{
				return _物品属性_追加升天五一招杀神;
			}
			set
			{
				_物品属性_追加升天五一招杀神 = value;
			}
		}

		public int 物品属性_追加升天五龙爪纤指手
		{
			get
			{
				return _物品属性_追加升天五龙爪纤指手;
			}
			set
			{
				_物品属性_追加升天五龙爪纤指手 = value;
			}
		}

		public int 物品属性_追加升天五不死之躯
		{
			get
			{
				return _物品属性_追加升天五不死之躯;
			}
			set
			{
				_物品属性_追加升天五不死之躯 = value;
			}
		}

		public int 物品属性_追加升天五天魔之力
		{
			get
			{
				return _物品属性_追加升天五天魔之力;
			}
			set
			{
				_物品属性_追加升天五天魔之力 = value;
			}
		}

		public int 物品属性_追加升天五惊涛骇浪
		{
			get
			{
				return _物品属性_追加升天五惊涛骇浪;
			}
			set
			{
				_物品属性_追加升天五惊涛骇浪 = value;
			}
		}

		public int 物品属性_追加升天五魔魂之力
		{
			get
			{
				return _物品属性_追加升天五魔魂之力;
			}
			set
			{
				_物品属性_追加升天五魔魂之力 = value;
			}
		}

		public int 物品属性_追加升天五破空坠星
		{
			get
			{
				return _物品属性_追加升天五破空坠星;
			}
			set
			{
				_物品属性_追加升天五破空坠星 = value;
			}
		}

		public int 物品属性_追加升天五尸毒爆发
		{
			get
			{
				return _物品属性_追加升天五尸毒爆发;
			}
			set
			{
				_物品属性_追加升天五尸毒爆发 = value;
			}
		}

		public int 物品属性_升级成功率
		{
			get
			{
				return _物品属性_升级成功率;
			}
			set
			{
				_物品属性_升级成功率 = value;
			}
		}

		public int 物品属性_追加伤害值
		{
			get
			{
				return _物品属性_追加伤害值;
			}
			set
			{
				_物品属性_追加伤害值 = value;
			}
		}

		public int 物品属性_降低伤害值
		{
			get
			{
				return _物品属性_降低伤害值;
			}
			set
			{
				_物品属性_降低伤害值 = value;
			}
		}

		public double 物品属性_追加中毒几率百分比
		{
			get
			{
				return _物品属性_追加中毒几率百分比;
			}
			set
			{
				_物品属性_追加中毒几率百分比 = value;
			}
		}

		public double 物品属性_追加强化
		{
			get
			{
				return _物品属性_追加强化;
			}
			set
			{
				_物品属性_追加强化 = value;
			}
		}

		public int 物品属性_武功防御力增加
		{
			get
			{
				return _物品属性_武功防御力增加;
			}
			set
			{
				_物品属性_武功防御力增加 = value;
			}
		}

		public int 物品属性_武功防御力增加New
		{
			get
			{
				return _物品属性_武功防御力增加New;
			}
			set
			{
				_物品属性_武功防御力增加New = value;
			}
		}

		public int 物品属性_获得金钱增加
		{
			get
			{
				return _物品属性_获得金钱增加;
			}
			set
			{
				_物品属性_获得金钱增加 = value;
			}
		}

		public int 物品属性_死亡损失经验减少
		{
			get
			{
				return _物品属性_死亡损失经验减少;
			}
			set
			{
				_物品属性_死亡损失经验减少 = value;
			}
		}

		public int 物品属性_经验获得增加
		{
			get
			{
				return _物品属性_经验获得增加;
			}
			set
			{
				_物品属性_经验获得增加 = value;
			}
		}

		public int 物品属性_拳师狂神降世
		{
			get
			{
				return _物品属性_拳师狂神降世;
			}
			set
			{
				_物品属性_拳师狂神降世 = value;
			}
		}

		public int 物品属性_拳师运气疗伤
		{
			get
			{
				return _物品属性_拳师运气疗伤;
			}
			set
			{
				_物品属性_拳师运气疗伤 = value;
			}
		}

		public int 物品属性_拳师力劈华山
		{
			get
			{
				return _物品属性_拳师力劈华山;
			}
			set
			{
				_物品属性_拳师力劈华山 = value;
			}
		}

		public int 物品属性_拳师狂风万破
		{
			get
			{
				return _物品属性_拳师狂风万破;
			}
			set
			{
				_物品属性_拳师狂风万破 = value;
			}
		}

		public int 物品属性_拳师金刚不坏
		{
			get
			{
				return _物品属性_拳师金刚不坏;
			}
			set
			{
				_物品属性_拳师金刚不坏 = value;
			}
		}

		public int 物品属性_拳师转攻为守
		{
			get
			{
				return _物品属性_拳师转攻为守;
			}
			set
			{
				_物品属性_拳师转攻为守 = value;
			}
		}

		public int 物品属性_拳师水火一体
		{
			get
			{
				return _物品属性_拳师水火一体;
			}
			set
			{
				_物品属性_拳师水火一体 = value;
			}
		}

		public int 物品属性_拳师会心一击
		{
			get
			{
				return _物品属性_拳师会心一击;
			}
			set
			{
				_物品属性_拳师会心一击 = value;
			}
		}

		public int 物品属性_拳师灵甲护身
		{
			get
			{
				return _物品属性_拳师灵甲护身;
			}
			set
			{
				_物品属性_拳师灵甲护身 = value;
			}
		}

		public int 物品属性_拳师磨杵成针
		{
			get
			{
				return _物品属性_拳师磨杵成针;
			}
			set
			{
				_物品属性_拳师磨杵成针 = value;
			}
		}

		public int 物品属性_拳师末日狂舞
		{
			get
			{
				return _物品属性_拳师末日狂舞;
			}
			set
			{
				_物品属性_拳师末日狂舞 = value;
			}
		}

		public int 物品属性_梅障力激活
		{
			get
			{
				return _物品属性_梅障力激活;
			}
			set
			{
				_物品属性_梅障力激活 = value;
			}
		}

		public int 物品属性_梅障力运用
		{
			get
			{
				return _物品属性_梅障力运用;
			}
			set
			{
				_物品属性_梅障力运用 = value;
			}
		}

		public int 物品属性_梅百变神行
		{
			get
			{
				return _物品属性_梅百变神行;
			}
			set
			{
				_物品属性_梅百变神行 = value;
			}
		}

		public int 物品属性_梅玄武神功
		{
			get
			{
				return _物品属性_梅玄武神功;
			}
			set
			{
				_物品属性_梅玄武神功 = value;
			}
		}

		public int 物品属性_梅玄武的指点
		{
			get
			{
				return _物品属性_梅玄武的指点;
			}
			set
			{
				_物品属性_梅玄武的指点 = value;
			}
		}

		public int 物品属性_梅玄武强击
		{
			get
			{
				return _物品属性_梅玄武强击;
			}
			set
			{
				_物品属性_梅玄武强击 = value;
			}
		}

		public int 物品属性_梅玄武危化
		{
			get
			{
				return _物品属性_梅玄武危化;
			}
			set
			{
				_物品属性_梅玄武危化 = value;
			}
		}

		public int 物品属性_梅障力恢复
		{
			get
			{
				return _物品属性_梅障力恢复;
			}
			set
			{
				_物品属性_梅障力恢复 = value;
			}
		}

		public int 物品属性_梅嫉妒的化身
		{
			get
			{
				return _物品属性_梅嫉妒的化身;
			}
			set
			{
				_物品属性_梅嫉妒的化身 = value;
			}
		}

		public int 物品属性_梅愤怒爆发
		{
			get
			{
				return _物品属性_梅愤怒爆发;
			}
			set
			{
				_物品属性_梅愤怒爆发 = value;
			}
		}

		public int 物品属性_梅吸血进击
		{
			get
			{
				return _物品属性_梅吸血进击;
			}
			set
			{
				_物品属性_梅吸血进击 = value;
			}
		}

		public int 物品属性_卢金钟罡气
		{
			get
			{
				return _物品属性_卢金钟罡气;
			}
			set
			{
				_物品属性_卢金钟罡气 = value;
			}
		}

		public int 物品属性_卢运气疗伤
		{
			get
			{
				return _物品属性_卢运气疗伤;
			}
			set
			{
				_物品属性_卢运气疗伤 = value;
			}
		}

		public int 物品属性_卢连环飞舞
		{
			get
			{
				return _物品属性_卢连环飞舞;
			}
			set
			{
				_物品属性_卢连环飞舞 = value;
			}
		}

		public int 物品属性_卢横练太保
		{
			get
			{
				return _物品属性_卢横练太保;
			}
			set
			{
				_物品属性_卢横练太保 = value;
			}
		}

		public int 物品属性_卢狂风万破
		{
			get
			{
				return _物品属性_卢狂风万破;
			}
			set
			{
				_物品属性_卢狂风万破 = value;
			}
		}

		public int 物品属性_卢真武绝击
		{
			get
			{
				return _物品属性_卢真武绝击;
			}
			set
			{
				_物品属性_卢真武绝击 = value;
			}
		}

		public int 物品属性_卢流星漫天
		{
			get
			{
				return _物品属性_卢流星漫天;
			}
			set
			{
				_物品属性_卢流星漫天 = value;
			}
		}

		public int 物品属性_卢乾坤挪移
		{
			get
			{
				return _物品属性_卢乾坤挪移;
			}
			set
			{
				_物品属性_卢乾坤挪移 = value;
			}
		}

		public int 物品属性_卢转攻为守
		{
			get
			{
				return _物品属性_卢转攻为守;
			}
			set
			{
				_物品属性_卢转攻为守 = value;
			}
		}

		public int 物品属性_卢弱点击破
		{
			get
			{
				return _物品属性_卢弱点击破;
			}
			set
			{
				_物品属性_卢弱点击破 = value;
			}
		}

		public int 物品属性_卢牢不可破
		{
			get
			{
				return _物品属性_卢牢不可破;
			}
			set
			{
				_物品属性_卢牢不可破 = value;
			}
		}

		public int 物品属性_神女运气行心
		{
			get
			{
				return _物品属性_神女运气行心;
			}
			set
			{
				_物品属性_神女运气行心 = value;
			}
		}

		public int 物品属性_神女太极心法
		{
			get
			{
				return _物品属性_神女太极心法;
			}
			set
			{
				_物品属性_神女太极心法 = value;
			}
		}

		public int 物品属性_神女神力激发
		{
			get
			{
				return _物品属性_神女神力激发;
			}
			set
			{
				_物品属性_神女神力激发 = value;
			}
		}

		public int 物品属性_神女杀星义气
		{
			get
			{
				return _物品属性_神女杀星义气;
			}
			set
			{
				_物品属性_神女杀星义气 = value;
			}
		}

		public int 物品属性_神女洗髓易筋
		{
			get
			{
				return _物品属性_神女洗髓易筋;
			}
			set
			{
				_物品属性_神女洗髓易筋 = value;
			}
		}

		public int 物品属性_神女黑花漫开
		{
			get
			{
				return _物品属性_神女黑花漫开;
			}
			set
			{
				_物品属性_神女黑花漫开 = value;
			}
		}

		public int 物品属性_神女妙手回春
		{
			get
			{
				return _物品属性_神女妙手回春;
			}
			set
			{
				_物品属性_神女妙手回春 = value;
			}
		}

		public int 物品属性_神女长功击力
		{
			get
			{
				return _物品属性_神女长功击力;
			}
			set
			{
				_物品属性_神女长功击力 = value;
			}
		}

		public int 物品属性_神女黑花集中
		{
			get
			{
				return _物品属性_神女黑花集中;
			}
			set
			{
				_物品属性_神女黑花集中 = value;
			}
		}

		public int 物品属性_神女真武绝击
		{
			get
			{
				return _物品属性_神女真武绝击;
			}
			set
			{
				_物品属性_神女真武绝击 = value;
			}
		}

		public int 物品属性_神女万毒不侵
		{
			get
			{
				return _物品属性_神女万毒不侵;
			}
			set
			{
				_物品属性_神女万毒不侵 = value;
			}
		}

		public int FLD_LEVEL
		{
			get
			{
				return _FLD_LEVEL;
			}
			set
			{
				_FLD_LEVEL = value;
			}
		}

		public int 背包装备等级
		{
			get
			{
				return _背包装备等级;
			}
			set
			{
				_背包装备等级 = value;
			}
		}

		public int 背包装备位置
		{
			get
			{
				return _背包装备位置;
			}
			set
			{
				_背包装备位置 = value;
			}
		}

		public int 背包装备类型
		{
			get
			{
				return _背包装备类型;
			}
			set
			{
				_背包装备类型 = value;
			}
		}

		public int FLD_RESIDE2
		{
			get
			{
				return _FLD_RESIDE2;
			}
			set
			{
				_FLD_RESIDE2 = value;
			}
		}

		public int 背包耐久度
		{
			get
			{
				return _背包耐久度;
			}
			set
			{
				_背包耐久度 = value;
			}
		}

		public int 提真装备
		{
			get
			{
				return _提真装备;
			}
			set
			{
				_提真装备 = value;
			}
		}

		public int FLD_MAGIC0
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 16, array, 0, 4);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 16, 4);
			}
		}

		public int FLD_强化类型
		{
			get
			{
				int fLD_MAGIC = FLD_MAGIC0;
				if (fLD_MAGIC <= 0)
				{
					return 0;
				}
				string text = fLD_MAGIC.ToString();
				return int.Parse(text.Substring(text.Length - 8, 1));
			}
		}

		public int FLD_强化数量
		{
			get
			{
				int fLD_MAGIC = FLD_MAGIC0;
				if (fLD_MAGIC <= 0)
				{
					return 0;
				}
				string text = fLD_MAGIC.ToString();
				return int.Parse(text.Substring(text.Length - 2, 2));
			}
		}

		public int FLD_属性类型
		{
			get
			{
				int fLD_MAGIC = FLD_MAGIC0;
				if (fLD_MAGIC <= 0 || fLD_MAGIC <= 1000000000)
				{
					return 0;
				}
				string text = fLD_MAGIC.ToString();
				return int.Parse(text.Substring(text.Length - 4, 1));
			}
		}

		public int FLD_属性数量
		{
			get
			{
				int fLD_MAGIC = FLD_MAGIC0;
				if (fLD_MAGIC <= 0 || fLD_MAGIC <= 1000000000)
				{
					return 0;
				}
				string text = fLD_MAGIC.ToString();
				return int.Parse(text.Substring(text.Length - 3, 1));
			}
		}

		public int FLD_MAGIC1
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 20, array, 0, 4);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 20, 4);
			}
		}

		public int FLD_MAGIC2
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 24, array, 0, 4);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 24, 4);
			}
		}

		public int FLD_MAGIC3
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 28, array, 0, 4);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 28, 4);
			}
		}

		public int FLD_MAGIC4
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 32, array, 0, 4);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 32, 4);
			}
		}

		public int FLD_FJ_MAGIC0
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品_byte, 36, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 36, 2);
			}
		}

		public int FLD_FJ_MAGIC1
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品_byte, 38, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 38, 2);
			}
		}

		public int FLD_FJ_中级附魂
		{
			get
			{
				try
				{
					byte[] array = new byte[2];
					Buffer.BlockCopy(物品_byte, 40, array, 0, 2);
					return BitConverter.ToInt16(array, 0);
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "FLD_FJ_中级附魂 Get出错： [" + 得到物品string() + "]" + ex);
					return 0;
				}
			}
			set
			{
				try
				{
					if (value > 0)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(1), 0, 物品_byte, 38, 2);
					}
					else if (value == 0)
					{
						Buffer.BlockCopy(BitConverter.GetBytes(0), 0, 物品_byte, 38, 2);
					}
					Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 40, 2);
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "FLD_FJ_中级附魂 Set出错： [" + 得到物品string() + "]" + ex);
				}
			}
		}

		public int FLD_FJ_MAGIC2
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品_byte, 42, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 42, 2);
			}
		}

		public int FLD_FJ_MAGIC3
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品_byte, 44, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 44, 2);
			}
		}

		public int FLD_FJ_MAGIC4
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品_byte, 46, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 46, 2);
			}
		}

		public int FLD_FJ_MAGIC5
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品_byte, 48, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 48, 2);
			}
		}

		public int FLD_JSSJ
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 56, array, 0, 4);
				DateTime dateTime = new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(BitConverter.ToInt32(array, 0));
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 56, 4);
			}
		}

		public int FLD_KSSJ
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 52, array, 0, 4);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 52, 4);
			}
		}

		public int FLD_FJ_觉醒
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 62, array, 0, 4);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 62, 4);
			}
		}

		public int FLD_FJ_NJ
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品_byte, 60, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 60, 2);
			}
		}

		public int FLD_FJ_进化
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 68, array, 0, 2);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 68, 2);
			}
		}

		public int FLD_FJ_四神之力
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品_byte, 71, array, 0, 1);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品_byte, 71, 1);
			}
		}

		public byte[] GetByte()
		{
			using 发包类 发包类 = new 发包类();
			发包类.Write(Get物品全局ID);
			if (物品绑定)
			{
				发包类.Write(Get物品ID + 20000);
			}
			else
			{
				发包类.Write(Get物品ID);
			}
			发包类.Write4(Get物品数量);
			发包类.Write4(FLD_MAGIC0);
			发包类.Write4(FLD_MAGIC1);
			发包类.Write4(FLD_MAGIC2);
			发包类.Write4(FLD_MAGIC3);
			发包类.Write4(FLD_MAGIC4);
			发包类.Write2(FLD_FJ_MAGIC0);
			发包类.Write2(FLD_FJ_MAGIC1);
			发包类.Write2(FLD_FJ_中级附魂);
			发包类.Write2(FLD_FJ_MAGIC2);
			发包类.Write2(FLD_FJ_MAGIC3);
			发包类.Write2(FLD_FJ_MAGIC4);
			发包类.Write2(FLD_FJ_MAGIC5);
			发包类.Write2(0);
			发包类.Write4(FLD_KSSJ);
			发包类.Write4(FLD_JSSJ);
			发包类.Write2(FLD_FJ_NJ);
			发包类.Write4(FLD_FJ_觉醒 + 物品_中级附魂_追加_觉醒);
			发包类.Write2(0);
			发包类.Write2(FLD_FJ_进化);
			发包类.Write2(0);
			发包类.Write4(FLD_FJ_四神之力);
			发包类.Write4(0);
			发包类.Write4(0);
			发包类.Write2(0);
			发包类.Write2(0);
			发包类.Write2(0);
			发包类.Write2(0);
			发包类.Write2(0);
			return 发包类.ToArray3();
		}

		public 物品类()
		{
		}

		public 物品类(byte[] 物品_byte_)
		{
			物品_byte = 物品_byte_;
		}

		public 物品类(byte[] 物品_byte_, int 位置)
		{
			物品_byte = 物品_byte_;
			物品位置 = 位置;
		}

		public void Dispose()
		{
		}

		public string 得到物品string()
		{
			try
			{
				return Converter.ToString(物品_byte);
			}
			catch
			{
				return string.Empty;
			}
		}

		public int 得到物品单个重量()
		{
			try
			{
				ItmeClass value;
				return World.Itme.TryGetValue(BitConverter.ToInt32(物品ID, 0), out value) ? value.FLD_WEIGHT : 0;
			}
			catch
			{
				return 0;
			}
		}

		public int 得到物品重量()
		{
			try
			{
				ItmeClass value;
				return World.Itme.TryGetValue(BitConverter.ToInt32(物品ID, 0), out value) ? (value.FLD_WEIGHT * BitConverter.ToInt32(物品数量, 0)) : 0;
			}
			catch
			{
				return 0;
			}
		}

		public byte[] 得到物品属性()
		{
			byte[] array = new byte[56];
			Buffer.BlockCopy(物品_byte, 16, array, 0, 56);
			return array;
		}

		public byte[] 得到全局ID()
		{
			byte[] array = new byte[8];
			Buffer.BlockCopy(物品_byte, 0, array, 0, 8);
			return array;
		}

		public byte[] 得到物品ID()
		{
			byte[] array = new byte[4];
			Buffer.BlockCopy(物品_byte, 8, array, 0, 4);
			return array;
		}

		public byte[] 得到物品数量()
		{
			byte[] array = new byte[4];
			Buffer.BlockCopy(物品_byte, 12, array, 0, 4);
			return array;
		}

		public void 设置物品数量(byte[] 数量)
		{
			Buffer.BlockCopy(数量, 0, 物品_byte, 12, 4);
		}

		public int 得到物品类型()
		{
			int key = BitConverter.ToInt32(得到物品ID(), 0);
			return World.Itme[key].FLD_SIDE;
		}

		public int 得到物品位置类型()
		{
			byte[] value = 得到物品ID();
			ItmeClass value2;
			return World.Itme.TryGetValue(BitConverter.ToInt32(value, 0), out value2) ? value2.FLD_RESIDE2 : 0;
		}

		public string 得到物品名称()
		{
			ItmeClass value;
			return World.Itme.TryGetValue(BitConverter.ToInt32(物品ID, 0), out value) ? value.ItmeNAME : string.Empty;
		}

		private void 清空物品属性方法()
		{
			物品攻击力 = 0;
			物品攻击力New = 0;
			物品攻击力MAX = 0;
			物品攻击力MaxNew = 0;
			物品属性_攻击力增加 = 0;
			物品属性_障力增加 = 0;
			物品防御力 = 0;
			物品武功回避 = 0;
			物品武功命中 = 0;
			物品增加负重 = 0;
			物品属性_防御力增加 = 0;
			物品属性_生命力增加 = 0;
			物品属性_对怪伤害 = 0.0;
			物品属性_障力恢复量增加 = 0;
			物品属性_内功力增加 = 0;
			物品属性_命中率增加 = 0;
			物品属性_回避率增加 = 0;
			物品属性_武功攻击力 = 0;
			物品属性_武功攻击力New = 0;
			物品属性_降低百分比防御 = 0.0;
			物品属性_降低百分比攻击 = 0.0;
			物品属性_增加百分比命中 = 0.0;
			物品属性_增加百分比回避 = 0.0;
			物品属性_初始化愤怒概率百分比 = 0.0;
			物品属性_愤怒值增加 = 0;
			物品属性_追加中毒几率百分比 = 0.0;
			物品属性_降低伤害值 = 0;
			物品属性_全部气功等级增加 = 0;
			物品属性_升级成功率 = 0;
			物品属性_追加伤害值 = 0;
			物品属性_武功防御力增加 = 0;
			物品属性_武功防御力增加New = 0;
			物品属性_获得金钱增加 = 0;
			物品属性_死亡损失经验减少 = 0;
			物品属性_拳师狂神降世 = 0;
			物品属性_拳师运气疗伤 = 0;
			物品属性_拳师力劈华山 = 0;
			物品属性_拳师狂风万破 = 0;
			物品属性_拳师金刚不坏 = 0;
			物品属性_拳师转攻为守 = 0;
			物品属性_拳师水火一体 = 0;
			物品属性_拳师会心一击 = 0;
			物品属性_拳师灵甲护身 = 0;
			物品属性_拳师磨杵成针 = 0;
			物品属性_拳师末日狂舞 = 0;
			物品属性_卢金钟罡气 = 0;
			物品属性_卢运气疗伤 = 0;
			物品属性_卢连环飞舞 = 0;
			物品属性_卢横练太保 = 0;
			物品属性_卢真武绝击 = 0;
			物品属性_卢流星漫天 = 0;
			物品属性_卢乾坤挪移 = 0;
			物品属性_卢转攻为守 = 0;
			物品属性_卢弱点击破 = 0;
			物品属性_卢牢不可破 = 0;
			物品属性_卢狂风万破 = 0;
			物品属性_梅障力激活 = 0;
			物品属性_梅障力运用 = 0;
			物品属性_梅百变神行 = 0;
			物品属性_梅玄武神功 = 0;
			物品属性_梅玄武的指点 = 0;
			物品属性_梅玄武强击 = 0;
			物品属性_梅玄武危化 = 0;
			物品属性_梅障力恢复 = 0;
			物品属性_梅嫉妒的化身 = 0;
			物品属性_梅愤怒爆发 = 0;
			物品属性_梅吸血进击 = 0;
			物品属性_神女运气行心 = 0;
			物品属性_神女太极心法 = 0;
			物品属性_神女神力激发 = 0;
			物品属性_神女杀星义气 = 0;
			物品属性_神女洗髓易筋 = 0;
			物品属性_神女黑花漫开 = 0;
			物品属性_神女妙手回春 = 0;
			物品属性_神女长功击力 = 0;
			物品属性_神女黑花集中 = 0;
			物品属性_神女真武绝击 = 0;
			物品属性_神女万毒不侵 = 0;
			物品属性_经验获得增加 = 0;
			物品_中级附魂_追加_觉醒 = 0;
			FLD_RESIDE2 = 0;
			FLD_LEVEL = 0;
			物品属性_追加医长功攻击 = 0;
			物品属性_追加医运气行心 = 0;
			物品属性_追加医洗髓易经 = 0;
			物品属性_追加医吸星大法 = 0;
			物品属性_追加升天一护身气甲 = 0;
			物品属性_追加医体血倍增 = 0;
			物品属性_追加医太极心法 = 0;
			物品属性_追加医真武绝击 = 0;
			物品属性_追加医妙手回春 = 0;
			物品属性_追加医九天真气 = 0;
			物品属性_追加医狂意护体 = 0;
			物品属性_追加医无中生有 = 0;
			物品属性_追加琴战马奔腾 = 0;
			物品属性_追加琴岳阳三醉 = 0;
			物品属性_追加琴阳明春晓 = 0;
			物品属性_追加琴阳关三叠 = 0;
			物品属性_追加琴秋江夜泊 = 0;
			物品属性_追加琴清心普善 = 0;
			物品属性_追加琴梅花三弄 = 0;
			物品属性_追加琴鸾凤和鸣 = 0;
			物品属性_追加琴汉宫秋月 = 0;
			物品属性_追加琴高山流水 = 0;
			物品属性_追加琴潇湘雨夜 = 0;
			物品属性_追加枪转守为攻 = 0;
			物品属性_追加枪运气疗伤 = 0;
			物品属性_追加枪乾坤挪移 = 0;
			物品属性_追加枪灵甲护身 = 0;
			物品属性_追加枪连环飞舞 = 0;
			物品属性_追加枪狂神降世 = 0;
			物品属性_追加枪狂风万破 = 0;
			物品属性_追加枪金钟罩气 = 0;
			物品属性_追加枪横练太保 = 0;
			物品属性_追加升天三怒意之火 = 0;
			物品属性_追加枪末日狂舞 = 0;
			物品属性_追加枪怒意之吼 = 0;
			物品属性_追加剑长虹贯日 = 0;
			物品属性_追加剑移花接木 = 0;
			物品属性_追加剑怒海狂澜 = 0;
			物品属性_追加剑连环飞舞 = 0;
			物品属性_追加剑狂风万破 = 0;
			物品属性_追加剑回柳身法 = 0;
			物品属性_追加升天一护身罡气 = 0;
			物品属性_追加剑冲冠一怒 = 0;
			物品属性_追加剑破天一剑 = 0;
			物品属性_追加剑百变神行 = 0;
			物品属性_追加剑无坚不摧 = 0;
			物品属性_追加剑乘胜追击 = 0;
			物品属性_追加弓正本培元 = 0;
			物品属性_追加弓心神凝聚 = 0;
			物品属性_追加弓无明暗矢 = 0;
			物品属性_追加弓锐利之箭 = 0;
			物品属性_追加弓凝神聚气 = 0;
			物品属性_追加弓流星三矢 = 0;
			物品属性_追加弓猎鹰之眼 = 0;
			物品属性_追加弓狂风万破 = 0;
			物品属性_追加弓回流真气 = 0;
			物品属性_追加弓百步穿杨 = 0;
			物品属性_追加弓致命绝杀 = 0;
			物品属性_追加刀真武绝击 = 0;
			物品属性_追加刀稳如泰山 = 0;
			物品属性_追加刀四两千斤 = 0;
			物品属性_追加刀摄魂一击 = 0;
			物品属性_追加刀连环飞舞 = 0;
			物品属性_追加刀力劈华山 = 0;
			物品属性_追加刀狂风万破 = 0;
			物品属性_追加升天三火龙之火 = 0;
			物品属性_追加刀霸气破甲 = 0;
			物品属性_追加气沉丹田 = 0;
			物品属性_追加刀暗影绝杀 = 0;
			物品属性_追加刀流光乱舞 = 0;
			物品属性_追加刀梵音破镜 = 0;
			物品属性_追加刺以怒还怒 = 0;
			物品属性_追加刺致手绝命 = 0;
			物品属性_追加刺心神凝聚 = 0;
			物品属性_追加刺先发制人 = 0;
			物品属性_追加刺三花聚顶 = 0;
			物品属性_追加刺千株万手 = 0;
			物品属性_追加刺连消带打 = 0;
			物品属性_追加刺连环飞舞 = 0;
			物品属性_追加刺荆轲之怒 = 0;
			物品属性_追加刺剑刃乱舞 = 0;
			物品属性_追加刺一招残杀 = 0;
			物品属性_追加韩暗影绝杀 = 0;
			物品属性_追加韩霸气破甲 = 0;
			物品属性_追加韩百变神行 = 0;
			物品属性_追加韩火龙问鼎 = 0;
			物品属性_追加韩狂风万破 = 0;
			物品属性_追加韩力劈华山 = 0;
			物品属性_追加韩流光乱舞 = 0;
			物品属性_追加韩摄魂一击 = 0;
			物品属性_追加韩天魔狂血 = 0;
			物品属性_追加韩真武绝击 = 0;
			物品属性_追加韩追骨吸元 = 0;
			物品属性_追加谭百变神行 = 0;
			物品属性_追加谭冲冠一怒 = 0;
			物品属性_追加谭护身罡气 = 0;
			物品属性_追加谭回柳身法 = 0;
			物品属性_追加谭狂风万破 = 0;
			物品属性_追加谭怒海狂澜 = 0;
			物品属性_追加谭新_连环飞舞 = 0;
			物品属性_追加谭移花接木 = 0;
			物品属性_追加谭长虹贯日 = 0;
			物品属性_追加谭招式新法 = 0;
			物品属性_追加谭纵横无双 = 0;
			物品属性_追加升天夺命连环 = 0;
			物品属性_追加升天电光石火 = 0;
			物品属性_追加升天精益求精 = 0;
			物品属性_追加升天四长虹贯天 = 0;
			物品属性_追加升天四悬丝诊脉 = 0;
			物品属性_追加升天四望梅添花 = 0;
			物品属性_追加升天四哀鸿遍野 = 0;
			物品属性_追加升天四毒蛇出洞 = 0;
			物品属性_追加升天四红月狂风 = 0;
			物品属性_追加升天四烈日炎炎 = 0;
			物品属性_追加升天四满月狂风 = 0;
			物品属性_追加升天三天外三矢 = 0;
			物品属性_追加升天三以柔克刚 = 0;
			物品属性_追加升天三子夜秋歌 = 0;
			物品属性_追加升天三火凤临朝 = 0;
			物品属性_追加升天三明镜止水 = 0;
			物品属性_追加升天三内息行心 = 0;
			物品属性_追加升天三无情打击 = 0;
			物品属性_追加升天二天魔护体 = 0;
			物品属性_追加升天二天地同寿 = 0;
			物品属性_追加升天二顺水推舟 = 0;
			物品属性_追加升天二以退为进 = 0;
			物品属性_追加升天二千钧压驼 = 0;
			物品属性_追加升天二穷途末路 = 0;
			物品属性_追加升天二三潭映月 = 0;
			物品属性_追加升天二万物回春 = 0;
			物品属性_追加升天一夜魔缠身 = 0;
			物品属性_追加升天一正本培源 = 0;
			物品属性_追加升天一长虹贯日 = 0;
			物品属性_追加升天一运气疗伤 = 0;
			物品属性_追加升天一运气行心 = 0;
			物品属性_追加升天一力劈华山 = 0;
			物品属性_追加升天一狂风天意 = 0;
			物品属性_追加升天一金钟罡气 = 0;
			物品属性_追加升天一飞花点翠 = 0;
			物品属性_追加升天一百变神行 = 0;
			物品属性_追加升天一遁出逆境 = 0;
			物品属性_追加升天一行风弄舞 = 0;
			物品属性_追加升天一绝影射魂 = 0;
			物品属性_追加升天一破甲刺魂 = 0;
			物品属性_追加升天五惊天动地 = 0;
			物品属性_追加升天一玄武雷电 = 0;
			物品属性_追加升天一陵劲淬砺 = 0;
			物品属性_追加升天一愤怒调节 = 0;
			物品属性_追加升天二玄武诅咒 = 0;
			物品属性_追加升天二杀星光符 = 0;
			物品属性_追加升天二蛊毒解除 = 0;
			物品属性_追加升天三杀人鬼 = 0;
			物品属性_追加升天三技冠群雄 = 0;
			物品属性_追加升天三神力保护 = 0;
			物品属性_追加升天五致残 = 0;
			物品属性_追加升天五龙魂附体 = 0;
			物品属性_追加升天五灭世狂舞 = 0;
			物品属性_追加升天五千里一击 = 0;
			物品属性_追加升天五形移妖相 = 0;
			物品属性_追加升天五一招杀神 = 0;
			物品属性_追加升天五龙爪纤指手 = 0;
			物品属性_追加升天五不死之躯 = 0;
			物品属性_追加升天五天魔之力 = 0;
			物品属性_追加升天五惊涛骇浪 = 0;
			物品属性_追加升天五魔魂之力 = 0;
			物品属性_追加升天五破空坠星 = 0;
			物品属性_追加升天五尸毒爆发 = 0;
			物品属性_追加强化 = 0.0;
			物品对怪防御力 = 0;
			物品对怪攻击力 = 0;
		}

		public void 得到物品属性方法()
		{
			try
			{
				清空物品属性方法();
				if (BitConverter.ToInt32(物品ID, 0) != 0)
				{
					得到物品基本攻击力();
					byte[] array = new byte[4];
					Buffer.BlockCopy(物品_byte, 16, array, 0, 4);
					得到强化(BitConverter.ToInt32(array, 0).ToString());
					for (int i = 0; i < 4; i++)
					{
						byte[] array2 = new byte[4];
						Buffer.BlockCopy(物品_byte, 20 + i * 4, array2, 0, 4);
						得到基本属性(BitConverter.ToInt32(array2, 0).ToString());
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到物品属性方法 出错：" + ex);
			}
		}

		private void 得到强化(string 强化数)
		{
			try
			{
				if (!World.Itme.TryGetValue(BitConverter.ToInt32(物品ID, 0), out var value))
				{
					return;
				}
				int length = 强化数.Length;
				int num = length;
				if (num != 9)
				{
					return;
				}
				int num2 = 0;
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品_byte, 20, array, 0, 4);
				string text = BitConverter.ToInt32(array, 0).ToString();
				if (text != "0")
				{
					num2 = int.Parse(text.Substring(text.Length - 2, 2));
				}
				物品属性强类型 = int.Parse(强化数.Substring(强化数.Length - 9, 2));
				物品属性强 = int.Parse(强化数.Substring(强化数.Length - 2, 2));
				if (物品属性强类型 != 19 || FLD_RESIDE2 != 16 || !World.Itme.TryGetValue(BitConverter.ToInt32(物品ID, 0), out var _))
				{
					return;
				}
				if (物品属性强 >= 105)
				{
					物品属性强 = 105;
				}
				if (物品属性强 > 1)
				{
					if (value.FLD_PID == 1000001170)
					{
						物品对怪防御力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 2 + 10;
						物品对怪攻击力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 2 + 10;
						物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 10;
					}
					else if (value.FLD_PID == 1000001171)
					{
						物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.785) + 9;
						物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.785) + 9;
						物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 8;
					}
					else if (value.FLD_PID == 1000001172)
					{
						物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.089 + 5.5);
						物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.089 + 5.5);
						物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 1;
					}
					else if (value.FLD_PID == 1000001173)
					{
						物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.196) + 6;
						物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.196) + 6;
						物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 2;
					}
					else if (value.FLD_PID == 1000001174)
					{
						物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.785) + 9;
						物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.785) + 9;
						物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10;
					}
					else if (value.FLD_PID == 1000001175)
					{
						物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.0) + 5;
						物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.0) + 5;
						物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 6;
					}
					switch (num2)
					{
					case 0:
						物品防御力 += (int)Math.Ceiling((double)物品属性强 / 2.0) + 4;
						物品攻击力 += (int)Math.Ceiling((double)物品属性强) + 4;
						物品攻击力New += (int)Math.Ceiling((double)物品属性强) + 4;
						break;
					case 1:
						物品防御力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 1.1875) + 5;
						物品攻击力 += (int)(Math.Ceiling((double)物品属性强) * 1.1875) + 5;
						物品攻击力New += (int)(Math.Ceiling((double)物品属性强) * 1.1875) + 5;
						物品对怪防御力 *= 2;
						物品对怪攻击力 *= 2;
						break;
					case 2:
						物品防御力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 1.5 + 5.5);
						物品攻击力 += (int)(Math.Ceiling((double)物品属性强) * 1.5 + 5.5);
						物品攻击力New += (int)(Math.Ceiling((double)物品属性强) * 1.5 + 5.5);
						物品对怪防御力 *= 4;
						物品对怪攻击力 *= 4;
						break;
					case 3:
						物品防御力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 2.0) + 8;
						物品攻击力 += (int)(Math.Ceiling((double)物品属性强) * 2.0) + 8;
						物品攻击力New += (int)(Math.Ceiling((double)物品属性强) * 2.0) + 8;
						物品对怪防御力 *= 8;
						物品对怪攻击力 *= 8;
						break;
					}
				}
				else if (物品属性强 == 1)
				{
					int num3 = 5;
					int num4 = 10;
					switch (num2)
					{
					case 1:
						num3 += 6;
						num4 += 20;
						break;
					case 2:
						num3 += 7;
						num4 += 40;
						break;
					case 3:
						num3 += 10;
						num4 += 80;
						break;
					}
					物品防御力 += num3;
					物品攻击力 += num3;
					物品攻击力New += num3;
					物品对怪防御力 += num4;
					物品对怪攻击力 += num4;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到强化 出错：" + ex);
			}
		}

		public void 得到物品属性方法(int 追加强化, int 触发属性提升)
		{
			try
			{
				清空物品属性方法();
				if (BitConverter.ToInt32(物品ID, 0) != 0)
				{
					得到物品基本攻击力();
					物品属性_追加强化 = 追加强化;
					byte[] array = new byte[4];
					Buffer.BlockCopy(物品_byte, 16, array, 0, 4);
					得到强化(BitConverter.ToInt32(array, 0).ToString(), 触发属性提升);
					for (int i = 0; i < 4; i++)
					{
						byte[] array2 = new byte[4];
						Buffer.BlockCopy(物品_byte, 20 + i * 4, array2, 0, 4);
						得到基本属性(BitConverter.ToInt32(array2, 0).ToString());
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到物品属性方法 出错：" + ex);
			}
		}

		public void 得到物品基本攻击力()
		{
			try
			{
				if (BitConverter.ToInt32(物品ID, 0) == 0)
				{
					return;
				}
				ItmeClass itmeClass = World.Itme[BitConverter.ToInt32(物品ID, 0)];
				FLD_RESIDE2 = itmeClass.FLD_RESIDE2;
				FLD_LEVEL = itmeClass.FLD_LEVEL;
				switch (FLD_RESIDE2)
				{
				case 1:
				case 2:
				case 5:
				case 6:
					物品属性_障力增加 = itmeClass.FLD_LEVEL;
					if (FLD_FJ_进化 == 0)
					{
						物品防御力 = itmeClass.FLD_DF;
					}
					else if (FLD_FJ_进化 == 1)
					{
						物品防御力 = (int)((double)itmeClass.FLD_DF + (double)itmeClass.FLD_DF * 0.1);
					}
					else if (FLD_FJ_进化 == 2)
					{
						物品防御力 = (int)((double)itmeClass.FLD_DF + (double)itmeClass.FLD_DF * 0.153);
					}
					物品隐藏生命 = itmeClass.FLD_YCHP;
					物品隐藏攻击 = itmeClass.FLD_YCAT;
					物品隐藏防御 = itmeClass.FLD_YCDF;
					break;
				case 4:
					物品属性_障力增加 = itmeClass.FLD_LEVEL;
					if (FLD_FJ_进化 == 0)
					{
						物品攻击力 = itmeClass.FLD_AT;
						物品攻击力MAX = itmeClass.FLD_AT_Max;
						物品攻击力New = itmeClass.FLD_AT;
						物品攻击力MaxNew = itmeClass.FLD_AT_Max;
					}
					else if (FLD_FJ_进化 == 1)
					{
						物品攻击力 = (int)((double)itmeClass.FLD_AT + (double)itmeClass.FLD_AT * 0.05);
						物品攻击力MAX = (int)((double)itmeClass.FLD_AT_Max + (double)itmeClass.FLD_AT_Max * 0.05);
						物品攻击力New = (int)((double)itmeClass.FLD_AT + (double)itmeClass.FLD_AT * 0.05);
						物品攻击力MaxNew = (int)((double)itmeClass.FLD_AT_Max + (double)itmeClass.FLD_AT_Max * 0.05);
					}
					else if (FLD_FJ_进化 == 2)
					{
						物品攻击力 = (int)((double)itmeClass.FLD_AT + (double)itmeClass.FLD_AT * 0.08);
						物品攻击力MAX = (int)((double)itmeClass.FLD_AT_Max + (double)itmeClass.FLD_AT_Max * 0.08);
						物品攻击力New = (int)((double)itmeClass.FLD_AT + (double)itmeClass.FLD_AT * 0.08);
						物品攻击力MaxNew = (int)((double)itmeClass.FLD_AT_Max + (double)itmeClass.FLD_AT_Max * 0.08);
					}
					物品隐藏生命 = itmeClass.FLD_YCHP;
					物品隐藏攻击 = itmeClass.FLD_YCAT;
					物品隐藏防御 = itmeClass.FLD_YCDF;
					break;
				case 13:
					物品攻击力 = itmeClass.FLD_AT;
					物品攻击力MAX = itmeClass.FLD_AT_Max;
					物品攻击力New = itmeClass.FLD_AT;
					物品攻击力MaxNew = itmeClass.FLD_AT_Max;
					物品隐藏生命 = itmeClass.FLD_YCHP;
					物品隐藏攻击 = itmeClass.FLD_YCAT;
					物品隐藏防御 = itmeClass.FLD_YCDF;
					break;
				case 7:
				case 8:
				case 10:
					物品属性_障力增加 = itmeClass.FLD_LEVEL;
					物品隐藏生命 = itmeClass.FLD_YCHP;
					物品隐藏攻击 = itmeClass.FLD_YCAT;
					物品隐藏防御 = itmeClass.FLD_YCDF;
					break;
				case 12:
				case 14:
				case 15:
				case 16:
				case 32:
				case 33:
				case 34:
				case 35:
				case 36:
					物品隐藏生命 = itmeClass.FLD_YCHP;
					物品隐藏攻击 = itmeClass.FLD_YCAT;
					物品隐藏防御 = itmeClass.FLD_YCDF;
					break;
				}
			}
			catch (Exception)
			{
				MainForm.WriteLine(1, "得到物品基本攻击力 出错：" + BitConverter.ToInt32(物品ID, 0));
			}
		}

		public void 洗髓装备攻击力()
		{
			try
			{
				if (BitConverter.ToInt32(物品ID, 0) != 0)
				{
					ItmeClass itmeClass = World.Itme[BitConverter.ToInt32(物品ID, 0)];
					背包装备等级 = itmeClass.FLD_LEVEL;
					背包装备类型 = itmeClass.FLD_RESIDE2;
					背包耐久度 = itmeClass.FLD_NJ;
					提真装备 = itmeClass.FLD_UP_LEVEL;
					背包装备位置 = itmeClass.FLD_HEAD_WEAR;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "洗髓装备攻击力攻击力 出错：" + ex);
			}
		}

		private void 得到基本属性(string ysqh)
		{
			try
			{
				string text;
				switch (ysqh.Length)
				{
				default:
					return;
				case 9:
					text = ysqh.Substring(0, 2);
					break;
				case 8:
					text = ysqh.Substring(0, 1);
					break;
				}
				int num = ((World.是否支持扩展物品属性位数 == 0) ? ((!(text == "8")) ? int.Parse(ysqh.Substring(ysqh.Length - 3, 3)) : int.Parse(ysqh.Substring(ysqh.Length - 2, 2))) : ((!(text == "8")) ? (int.Parse(ysqh) - int.Parse(text) * 10000000) : int.Parse(ysqh.Substring(ysqh.Length - 2, 2))));
				switch (int.Parse(text))
				{
				case 1:
					物品属性_攻击力增加 += num;
					物品攻击力 += num;
					物品攻击力MAX += num;
					switch (num)
					{
					case 20:
						num += World.g20;
						break;
					case 21:
						num += World.g21;
						break;
					case 22:
						num += World.g22;
						break;
					case 23:
						num += World.g23;
						break;
					case 24:
						num += World.g24;
						break;
					case 25:
						num += World.g25;
						break;
					}
					物品攻击力New += num;
					物品攻击力MaxNew += num;
					break;
				case 2:
					switch (num)
					{
					case 10:
						num += World.f10;
						break;
					case 11:
						num += World.f11;
						break;
					case 12:
						num += World.f12;
						break;
					case 13:
						num += World.f13;
						break;
					case 14:
						num += World.f14;
						break;
					case 15:
						num += World.f15;
						break;
					}
					物品属性_防御力增加 += num;
					物品防御力 += num;
					break;
				case 3:
					物品属性_生命力增加 += num;
					break;
				case 4:
					物品属性_内功力增加 += num;
					break;
				case 5:
					物品属性_命中率增加 += num;
					break;
				case 6:
					物品属性_回避率增加 += num;
					break;
				case 7:
					物品属性_武功攻击力 += num;
					switch (num)
					{
					case 20:
						num += World.wg20;
						break;
					case 21:
						num += World.wg21;
						break;
					case 22:
						num += World.wg22;
						break;
					case 23:
						num += World.wg23;
						break;
					case 24:
						num += World.wg24;
						break;
					case 25:
						num += World.wg25;
						break;
					case 26:
						num += World.wg26;
						break;
					case 27:
						num += World.wg27;
						break;
					case 28:
						num += World.wg28;
						break;
					case 29:
						num += World.wg29;
						break;
					case 30:
						num += World.wg30;
						break;
					case 31:
						num += World.wg31;
						break;
					case 32:
						num += World.wg32;
						break;
					case 33:
						num += World.wg33;
						break;
					case 34:
						num += World.wg34;
						break;
					case 35:
						num += World.wg35;
						break;
					case 36:
						num += World.wg36;
						break;
					case 37:
						num += World.wg37;
						break;
					case 38:
						num += World.wg38;
						break;
					case 39:
						num += World.wg39;
						break;
					case 40:
						num += World.wg40;
						break;
					}
					物品属性_武功攻击力New += num;
					break;
				case 8:
				{
					string text2 = ysqh.Substring(3, 3);
					if (text2 != null)
					{
						switch (text2)
						{
						case "659":
							物品属性_梅障力恢复 += num;
							break;
						case "658":
							物品属性_梅玄武危化 += num;
							break;
						case "700":
							物品属性_追加升天三以柔克刚 += num;
							break;
						case "453":
							物品属性_神女杀星义气 += num;
							break;
						case "251":
							物品属性_追加刀摄魂一击 += num;
							物品属性_追加韩摄魂一击 += num;
							break;
						case "250":
							物品属性_追加刀力劈华山 += num;
							物品属性_追加韩力劈华山 += num;
							break;
						case "253":
							物品属性_追加剑百变神行 += num;
							物品属性_追加谭百变神行 += num;
							物品属性_追加韩百变神行 += num;
							物品属性_梅百变神行 += num;
							物品属性_追加升天一百变神行 += num;
							break;
						case "252":
							物品属性_追加韩天魔狂血 += num;
							break;
						case "255":
							物品属性_追加韩追骨吸元 += num;
							break;
						case "254":
							物品属性_追加刀狂风万破 += num;
							物品属性_追加剑狂风万破 += num;
							物品属性_追加枪狂风万破 += num;
							物品属性_追加弓狂风万破 += num;
							物品属性_追加韩狂风万破 += num;
							物品属性_追加谭狂风万破 += num;
							break;
						case "257":
							物品属性_追加刀真武绝击 += num;
							物品属性_追加韩真武绝击 += num;
							物品属性_追加医真武绝击 += num;
							break;
						case "256":
							物品属性_追加刀霸气破甲 += num;
							物品属性_追加韩霸气破甲 += num;
							break;
						case "181":
						case "182":
						case "183":
						case "184":
						case "185":
						case "186":
						case "187":
						case "188":
						case "189":
						case "190":
						case "191":
						case "192":
						case "193":
							物品属性_追加气沉丹田 += num;
							break;
						case "286":
							物品属性_卢流星漫天 += num;
							break;
						case "258":
							物品属性_追加刀暗影绝杀 += num;
							物品属性_追加韩暗影绝杀 += num;
							break;
						case "562":
							物品属性_追加升天电光石火 += num;
							break;
						case "259":
							物品属性_追加韩火龙问鼎 += num;
							break;
						case "563":
							物品属性_追加升天精益求精 += num;
							break;
						case "280":
							物品属性_追加剑冲冠一怒 += num;
							物品属性_追加谭冲冠一怒 += num;
							break;
						case "561":
							物品属性_追加升天夺命连环 += num;
							break;
						case "321":
							物品属性_追加升天二天地同寿 += num;
							break;
						case "320":
							物品属性_追加剑乘胜追击 += num;
							break;
						case "342":
							物品属性_追加升天三天外三矢 += num;
							break;
						case "322":
							物品属性_追加升天三火凤临朝 += num;
							break;
						case "332":
							物品属性_追加枪怒意之吼 += num;
							break;
						case "340":
							物品属性_追加升天一绝影射魂 += num;
							break;
						case "355":
							break;
						case "341":
							物品属性_追加升天二千钧压驼 += num;
							break;
						case "331":
							物品属性_追加升天二以退为进 += num;
							break;
						case "330":
							物品属性_追加升天一破甲刺魂 += num;
							break;
						case "354":
						case "614":
							物品属性_追加升天四望梅添花 += num;
							break;
						case "346":
							break;
						case "337":
							break;
						case "328":
							break;
						case "357":
							break;
						case "347":
							break;
						case "336":
							break;
						case "329":
							break;
						case "356":
							break;
						case "345":
							break;
						case "335":
							break;
						case "350":
							物品属性_追加医狂意护体 += num;
							break;
						case "351":
							物品属性_追加医无中生有 += num;
							break;
						case "348":
							break;
						case "339":
							break;
						case "352":
							物品属性_追加升天三明镜止水 += num;
							break;
						case "338":
							break;
						case "349":
							break;
						case "041":
							物品属性_追加弓猎鹰之眼 += num;
							break;
						case "358":
							break;
						case "359":
							break;
						case "040":
							物品属性_追加弓百步穿杨 += num;
							break;
						case "092":
							break;
						case "043":
							物品属性_追加弓回流真气 += num;
							break;
						case "093":
							break;
						case "042":
							物品属性_追加弓凝神聚气 += num;
							break;
						case "090":
							break;
						case "085":
							物品属性_追加琴高山流水 += num;
							break;
						case "091":
							break;
						case "034":
							物品属性_追加刀狂风万破 += num;
							物品属性_追加剑狂风万破 += num;
							物品属性_追加枪狂风万破 += num;
							物品属性_追加弓狂风万破 += num;
							物品属性_追加韩狂风万破 += num;
							物品属性_追加谭狂风万破 += num;
							物品属性_拳师狂风万破 += num;
							物品属性_卢狂风万破 += num;
							break;
						case "035":
							物品属性_追加枪横练太保 += num;
							物品属性_卢横练太保 += num;
							break;
						case "045":
							物品属性_追加弓正本培元 += num;
							break;
						case "084":
							物品属性_追加琴汉宫秋月 += num;
							break;
						case "096":
							break;
						case "036":
							物品属性_追加枪乾坤挪移 += num;
							物品属性_卢乾坤挪移 += num;
							break;
						case "044":
							物品属性_追加刀狂风万破 += num;
							物品属性_追加剑狂风万破 += num;
							物品属性_追加枪狂风万破 += num;
							物品属性_追加弓狂风万破 += num;
							物品属性_追加韩狂风万破 += num;
							物品属性_追加谭狂风万破 += num;
							物品属性_拳师狂风万破 += num;
							物品属性_卢狂风万破 += num;
							break;
						case "087":
							物品属性_追加琴梅花三弄 += num;
							break;
						case "097":
							break;
						case "037":
						case "558":
							物品属性_拳师灵甲护身 += num;
							物品属性_追加枪灵甲护身 += num;
							break;
						case "047":
							物品属性_追加弓流星三矢 += num;
							break;
						case "094":
							break;
						case "027":
							物品属性_追加剑回柳身法 += num;
							物品属性_追加谭回柳身法 += num;
							break;
						case "046":
							物品属性_追加刺心神凝聚 += num;
							物品属性_追加弓心神凝聚 += num;
							break;
						case "086":
							物品属性_追加琴岳阳三醉 += num;
							break;
						case "095":
							break;
						case "026":
							物品属性_追加剑移花接木 += num;
							物品属性_追加谭移花接木 += num;
							break;
						case "030":
						case "281":
							物品属性_卢金钟罡气 += num;
							物品属性_追加枪金钟罩气 += num;
							break;
						case "049":
							物品属性_追加弓无明暗矢 += num;
							break;
						case "081":
							物品属性_追加琴秋江夜泊 += num;
							break;
						case "025":
							物品属性_追加升天一护身罡气 += num;
							物品属性_追加谭护身罡气 += num;
							break;
						case "275":
							物品属性_追加升天一护身罡气 += num;
							物品属性_追加谭护身罡气 += num;
							break;
						case "031":
							物品属性_追加枪运气疗伤 += num;
							物品属性_拳师运气疗伤 += num;
							物品属性_卢运气疗伤 += num;
							break;
						case "048":
							物品属性_追加弓锐利之箭 += num;
							break;
						case "080":
							物品属性_追加琴战马奔腾 += num;
							break;
						case "083":
							物品属性_追加琴阳关三叠 += num;
							break;
						case "024":
							物品属性_追加刀狂风万破 += num;
							物品属性_追加剑狂风万破 += num;
							物品属性_追加枪狂风万破 += num;
							物品属性_追加弓狂风万破 += num;
							物品属性_追加韩狂风万破 += num;
							物品属性_追加谭狂风万破 += num;
							物品属性_拳师狂风万破 += num;
							物品属性_卢狂风万破 += num;
							break;
						case "032":
							物品属性_追加刀连环飞舞 += num;
							物品属性_追加剑连环飞舞 += num;
							物品属性_追加枪连环飞舞 += num;
							物品属性_追加刺连环飞舞 += num;
							物品属性_卢连环飞舞 += num;
							break;
						case "283":
							物品属性_追加刀连环飞舞 += num;
							物品属性_追加剑连环飞舞 += num;
							物品属性_追加枪连环飞舞 += num;
							物品属性_追加刺连环飞舞 += num;
							物品属性_卢连环飞舞 += num;
							break;
						case "023":
							物品属性_追加剑破天一剑 += num;
							break;
						case "033":
							物品属性_追加升天三怒意之火 += num;
							break;
						case "082":
							物品属性_追加琴清心普善 += num;
							break;
						case "098":
							break;
						case "018":
							物品属性_追加刀暗影绝杀 += num;
							物品属性_追加韩暗影绝杀 += num;
							break;
						case "022":
							物品属性_追加刀连环飞舞 += num;
							物品属性_追加剑连环飞舞 += num;
							物品属性_追加枪连环飞舞 += num;
							物品属性_追加刺连环飞舞 += num;
							物品属性_卢连环飞舞 += num;
							break;
						case "019":
							物品属性_追加刀稳如泰山 += num;
							break;
						case "021":
							物品属性_追加剑百变神行 += num;
							物品属性_追加谭百变神行 += num;
							物品属性_追加韩百变神行 += num;
							物品属性_梅百变神行 += num;
							物品属性_追加升天一百变神行 += num;
							break;
						case "099":
							break;
						case "038":
							物品属性_追加枪狂神降世 += num;
							物品属性_拳师狂神降世 += num;
							break;
						case "020":
							物品属性_追加剑长虹贯日 += num;
							物品属性_追加谭长虹贯日 += num;
							break;
						case "039":
						case "289":
							物品属性_卢转攻为守 += num;
							物品属性_追加枪转守为攻 += num;
							物品属性_拳师转攻为守 += num;
							break;
						case "089":
							物品属性_追加琴阳明春晓 += num;
							break;
						case "012":
							物品属性_追加刀连环飞舞 += num;
							物品属性_追加剑连环飞舞 += num;
							物品属性_追加枪连环飞舞 += num;
							物品属性_追加刺连环飞舞 += num;
							物品属性_卢连环飞舞 += num;
							break;
						case "088":
							物品属性_追加琴鸾凤和鸣 += num;
							break;
						case "029":
							物品属性_追加剑冲冠一怒 += num;
							物品属性_追加谭冲冠一怒 += num;
							break;
						case "010":
							物品属性_追加刀力劈华山 += num;
							物品属性_追加韩力劈华山 += num;
							物品属性_拳师力劈华山 += num;
							break;
						case "013":
							物品属性_追加升天三火龙之火 += num;
							break;
						case "028":
							物品属性_追加剑怒海狂澜 += num;
							物品属性_追加谭怒海狂澜 += num;
							break;
						case "011":
							物品属性_追加刀摄魂一击 += num;
							物品属性_追加韩摄魂一击 += num;
							break;
						case "017":
							物品属性_追加刀真武绝击 += num;
							物品属性_追加韩真武绝击 += num;
							物品属性_追加医真武绝击 += num;
							物品属性_卢真武绝击 += num;
							物品属性_神女真武绝击 += num;
							break;
						case "460":
							物品属性_神女万毒不侵 += num;
							break;
						case "016":
							物品属性_追加刀霸气破甲 += num;
							物品属性_追加韩霸气破甲 += num;
							break;
						case "452":
							物品属性_神女神力激发 += num;
							break;
						case "290":
							物品属性_卢弱点击破 += num;
							break;
						case "291":
							物品属性_卢牢不可破 += num;
							break;
						case "014":
							物品属性_追加刀狂风万破 += num;
							物品属性_追加剑狂风万破 += num;
							物品属性_追加枪狂风万破 += num;
							物品属性_追加弓狂风万破 += num;
							物品属性_追加韩狂风万破 += num;
							物品属性_追加谭狂风万破 += num;
							物品属性_拳师狂风万破 += num;
							物品属性_卢狂风万破 += num;
							break;
						case "104":
							break;
						case "106":
							break;
						case "015":
							物品属性_追加刀四两千斤 += num;
							break;
						case "105":
							break;
						case "117":
							break;
						case "107":
							break;
						case "100":
							break;
						case "148":
							break;
						case "149":
							break;
						case "116":
							break;
						case "102":
							break;
						case "115":
							break;
						case "101":
							break;
						case "103":
							break;
						case "114":
							break;
						case "112":
							break;
						case "113":
							break;
						case "111":
							break;
						case "128":
							break;
						case "140":
							物品属性_追加弓致命绝杀 += num;
							break;
						case "110":
							物品属性_追加刀流光乱舞 += num;
							物品属性_追加韩流光乱舞 += num;
							break;
						case "129":
							break;
						case "141":
							break;
						case "108":
							break;
						case "139":
							break;
						case "109":
							break;
						case "122":
							break;
						case "142":
							break;
						case "143":
							break;
						case "138":
							break;
						case "144":
							break;
						case "123":
							break;
						case "145":
							break;
						case "120":
							物品属性_追加剑无坚不摧 += num;
							break;
						case "121":
							break;
						case "119":
							break;
						case "118":
							break;
						case "146":
							break;
						case "135":
							break;
						case "134":
							break;
						case "126":
							break;
						case "137":
							break;
						case "147":
							break;
						case "136":
							break;
						case "124":
							break;
						case "130":
							物品属性_拳师末日狂舞 += num;
							物品属性_追加枪末日狂舞 += num;
							break;
						case "131":
							break;
						case "125":
							break;
						case "132":
							break;
						case "133":
							break;
						case "602":
							物品属性_追加升天三内息行心 += num;
							break;
						case "701":
						case "603":
							物品属性_追加升天四长虹贯天 += num;
							break;
						case "600":
							物品属性_追加升天一行风弄舞 += num;
							break;
						case "601":
							物品属性_追加升天二天魔护体 += num;
							break;
						case "660":
							物品属性_梅嫉妒的化身 += num;
							break;
						case "702":
						case "604":
							物品属性_追加升天四哀鸿遍野 += num;
							break;
						case "661":
							物品属性_梅愤怒爆发 += num;
							break;
						case "276":
							物品属性_追加剑移花接木 += num;
							物品属性_追加谭移花接木 += num;
							break;
						case "(int)sbyte.MaxValue":
							break;
						case "274":
							物品属性_追加刀狂风万破 += num;
							物品属性_追加剑狂风万破 += num;
							物品属性_追加枪狂风万破 += num;
							物品属性_追加弓狂风万破 += num;
							物品属性_追加韩狂风万破 += num;
							物品属性_追加谭狂风万破 += num;
							break;
						case "277":
							物品属性_追加谭纵横无双 += num;
							break;
						case "269":
							break;
						case "273":
							物品属性_追加谭招式新法 += num;
							break;
						case "268":
							break;
						case "272":
							物品属性_追加谭新_连环飞舞 += num;
							break;
						case "271":
							物品属性_追加剑百变神行 += num;
							物品属性_追加谭百变神行 += num;
							物品属性_追加韩百变神行 += num;
							物品属性_梅百变神行 += num;
							物品属性_追加升天一百变神行 += num;
							break;
						case "270":
							物品属性_追加剑长虹贯日 += num;
							物品属性_追加谭长虹贯日 += num;
							break;
						case "260":
							物品属性_追加刀流光乱舞 += num;
							物品属性_追加韩流光乱舞 += num;
							break;
						case "261":
							break;
						case "278":
							物品属性_追加剑回柳身法 += num;
							物品属性_追加谭回柳身法 += num;
							break;
						case "263":
							break;
						case "279":
							物品属性_追加剑怒海狂澜 += num;
							物品属性_追加谭怒海狂澜 += num;
							break;
						case "391":
							物品属性_追加升天二三潭映月 += num;
							break;
						case "262":
							break;
						case "390":
							物品属性_追加升天一飞花点翠 += num;
							break;
						case "265":
							break;
						case "264":
							break;
						case "392":
							物品属性_追加升天三子夜秋歌 += num;
							break;
						case "267":
							break;
						case "319":
							break;
						case "394":
							物品属性_追加升天四悬丝诊脉 += num;
							break;
						case "266":
							break;
						case "318":
							物品属性_梅吸血进击 += num;
							break;
						case "557":
							物品属性_拳师会心一击 += num;
							break;
						case "559":
							物品属性_拳师磨杵成针 += num;
							break;
						case "556":
							物品属性_拳师水火一体 += num;
							break;
						case "554":
							物品属性_拳师金刚不坏 += num;
							break;
						case "311":
							物品属性_追加升天二穷途末路 += num;
							break;
						case "368":
							break;
						case "310":
							物品属性_追加升天一遁出逆境 += num;
							break;
						case "369":
							break;
						case "364":
							break;
						case "312":
							物品属性_追加刀梵音破镜 += num;
							break;
						case "323":
						case "333":
						case "313":
						case "666":
							物品属性_追加升天四红月狂风 += num;
							break;
						case "388":
							break;
						case "379":
							break;
						case "365":
							break;
						case "324":
						case "334":
						case "314":
						case "665":
							物品属性_追加升天四毒蛇出洞 += num;
							break;
						case "389":
							break;
						case "378":
							break;
						case "366":
							break;
						case "317":
							break;
						case "386":
							物品属性_追加剑百变神行 += num;
							物品属性_追加谭百变神行 += num;
							物品属性_追加韩百变神行 += num;
							物品属性_梅百变神行 += num;
							物品属性_追加升天一百变神行 += num;
							break;
						case "377":
							break;
						case "367":
							break;
						case "387":
							物品属性_追加升天一狂风天意 += num;
							break;
						case "384":
							物品属性_追加升天一正本培源 += num;
							break;
						case "376":
							break;
						case "360":
							break;
						case "375":
							break;
						case "361":
							break;
						case "362":
							break;
						case "385":
							物品属性_追加升天一运气疗伤 += num;
							break;
						case "382":
							物品属性_追加升天一金钟罡气 += num;
							break;
						case "344":
						case "374":
						case "326":
							物品属性_追加升天四烈日炎炎 += num;
							break;
						case "343":
						case "353":
						case "373":
						case "393":
						case "327":
						case "613":
							物品属性_追加升天四满月狂风 += num;
							break;
						case "363":
							break;
						case "078":
							物品属性_追加刺连消带打 += num;
							break;
						case "079":
							物品属性_追加刺剑刃乱舞 += num;
							break;
						case "383":
							物品属性_追加升天一运气行心 += num;
							break;
						case "380":
							物品属性_追加升天一力劈华山 += num;
							break;
						case "372":
							物品属性_追加刺以怒还怒 += num;
							break;
						case "381":
							物品属性_追加升天一长虹贯日 += num;
							break;
						case "371":
							物品属性_追加升天二顺水推舟 += num;
							break;
						case "068":
							break;
						case "069":
							break;
						case "370":
							物品属性_追加升天一夜魔缠身 += num;
							break;
						case "071":
							物品属性_追加刺三花聚顶 += num;
							break;
						case "070":
							物品属性_追加刺荆轲之怒 += num;
							break;
						case "073":
							物品属性_追加刺一招残杀 += num;
							break;
						case "072":
							物品属性_追加刀连环飞舞 += num;
							物品属性_追加剑连环飞舞 += num;
							物品属性_追加枪连环飞舞 += num;
							物品属性_追加刺连环飞舞 += num;
							物品属性_卢连环飞舞 += num;
							break;
						case "074":
							物品属性_追加刺心神凝聚 += num;
							物品属性_追加弓心神凝聚 += num;
							break;
						case "063":
							break;
						case "075":
							物品属性_追加刺致手绝命 += num;
							break;
						case "058":
							物品属性_追加升天一护身气甲 += num;
							break;
						case "062":
							break;
						case "059":
							物品属性_追加医九天真气 += num;
							break;
						case "061":
							break;
						case "076":
							物品属性_追加刺先发制人 += num;
							break;
						case "170":
							物品属性_追加升天三无情打击 += num;
							break;
						case "056":
							物品属性_追加医吸星大法 += num;
							break;
						case "060":
							break;
						case "057":
							物品属性_追加刀真武绝击 += num;
							物品属性_追加韩真武绝击 += num;
							物品属性_追加医真武绝击 += num;
							物品属性_卢真武绝击 += num;
							物品属性_神女真武绝击 += num;
							break;
						case "067":
							break;
						case "077":
							物品属性_追加刺千株万手 += num;
							break;
						case "054":
							物品属性_追加医妙手回春 += num;
							物品属性_神女妙手回春 += num;
							break;
						case "456":
							物品属性_追加医妙手回春 += num;
							物品属性_神女妙手回春 += num;
							break;
						case "066":
							break;
						case "055":
							物品属性_追加医长功攻击 += num;
							物品属性_神女长功击力 += num;
							break;
						case "457":
							物品属性_追加医长功攻击 += num;
							物品属性_神女长功击力 += num;
							break;
						case "458":
							物品属性_神女黑花集中 += num;
							break;
						case "065":
							break;
						case "052":
							物品属性_追加医体血倍增 += num;
							break;
						case "064":
							物品属性_追加刀狂风万破 += num;
							物品属性_追加剑狂风万破 += num;
							物品属性_追加枪狂风万破 += num;
							物品属性_追加弓狂风万破 += num;
							物品属性_追加韩狂风万破 += num;
							物品属性_追加谭狂风万破 += num;
							物品属性_拳师狂风万破 += num;
							物品属性_卢狂风万破 += num;
							break;
						case "050":
							物品属性_追加医运气行心 += num;
							物品属性_神女运气行心 += num;
							break;
						case "053":
							物品属性_神女洗髓易筋 += num;
							物品属性_追加医洗髓易经 += num;
							break;
						case "454":
							物品属性_神女洗髓易筋 += num;
							物品属性_追加医洗髓易经 += num;
							break;
						case "455":
							物品属性_神女黑花漫开 += num;
							break;
						case "000":
							物品属性_全部气功等级增加 += num;
							break;
						case "150":
							物品属性_追加升天二万物回春 += num;
							break;
						case "051":
							物品属性_追加医太极心法 += num;
							物品属性_神女太极心法 += num;
							break;
						case "180":
							物品属性_追加琴潇湘雨夜 += num;
							break;
						case "654":
							物品属性_梅玄武神功 += num;
							break;
						case "657":
							物品属性_梅玄武强击 += num;
							break;
						case "656":
							物品属性_梅玄武的指点 += num;
							break;
						case "653":
							物品属性_追加剑百变神行 += num;
							物品属性_追加谭百变神行 += num;
							物品属性_追加韩百变神行 += num;
							物品属性_梅百变神行 += num;
							物品属性_追加升天一百变神行 += num;
							break;
						case "651":
							物品属性_梅障力运用 += num;
							break;
						case "650":
							物品属性_梅障力激活 += num;
							break;
						case "680":
							物品属性_追加升天五惊天动地 += num;
							break;
						case "315":
							物品属性_追加升天三杀人鬼 += num;
							break;
						case "664":
							物品属性_追加升天三技冠群雄 += num;
							break;
						case "612":
							物品属性_追加升天三神力保护 += num;
							break;
						case "325":
							物品属性_追加升天二玄武诅咒 += num;
							break;
						case "316":
							物品属性_追加升天一玄武雷电 += num;
							break;
						case "662":
							物品属性_追加升天一陵劲淬砺 += num;
							break;
						case "610":
							物品属性_追加升天一愤怒调节 += num;
							break;
						case "663":
							物品属性_追加升天二杀星光符 += num;
							break;
						case "611":
							物品属性_追加升天二蛊毒解除 += num;
							break;
						case "667":
						case "668":
						case "669":
						case "670":
						case "671":
						case "672":
						case "673":
						case "674":
						case "675":
						case "676":
						case "677":
						case "678":
						case "615":
							物品属性_追加升天五致残 += num;
							break;
						case "679":
							物品属性_追加升天五龙魂附体 += num;
							break;
						case "681":
							物品属性_追加升天五灭世狂舞 += num;
							break;
						case "682":
							物品属性_追加升天五千里一击 += num;
							break;
						case "683":
							物品属性_追加升天五形移妖相 += num;
							break;
						case "684":
							物品属性_追加升天五一招杀神 += num;
							break;
						case "685":
							物品属性_追加升天五龙爪纤指手 += num;
							break;
						case "688":
							物品属性_追加升天五不死之躯 += num;
							break;
						case "686":
							物品属性_追加升天五天魔之力 += num;
							break;
						case "687":
							物品属性_追加升天五惊涛骇浪 += num;
							break;
						case "689":
							物品属性_追加升天五魔魂之力 += num;
							break;
						case "690":
							物品属性_追加升天五破空坠星 += num;
							break;
						case "616":
							物品属性_追加升天五尸毒爆发 += num;
							break;
						}
					}
					break;
				}
				case 9:
					物品属性_升级成功率 += num;
					break;
				case 10:
					物品属性_追加伤害值 += num;
					break;
				case 11:
					try
					{
						switch (num)
						{
						case 85:
							num += World.wf85;
							break;
						case 68:
							num += World.wf68;
							break;
						case 70:
							num += World.wf70;
							break;
						case 72:
							num += World.wf72;
							break;
						case 74:
							num += World.wf74;
							break;
						case 76:
							num += World.wf76;
							break;
						case 78:
							num += World.wf78;
							break;
						case 80:
							num += World.wf80;
							break;
						case 120:
							num += World.wf120;
							break;
						case 118:
							num += World.wf118;
							break;
						case 116:
							num += World.wf116;
							break;
						case 114:
							num += World.wf114;
							break;
						case 112:
							num += World.wf112;
							break;
						case 110:
							num += World.wf110;
							break;
						case 100:
							num += World.wf100;
							break;
						case 98:
							num += World.wf98;
							break;
						case 96:
							num += World.wf96;
							break;
						case 95:
							num += World.wf95;
							break;
						case 94:
							num += World.wf94;
							break;
						case 92:
							num += World.wf92;
							break;
						case 90:
							num += World.wf90;
							break;
						}
						物品属性_武功防御力增加New += num;
						物品属性_武功防御力增加 += num;
					}
					catch
					{
					}
					break;
				case 12:
					物品属性_获得金钱增加 += num;
					break;
				case 13:
					物品属性_死亡损失经验减少 += num;
					break;
				case 15:
					物品属性_经验获得增加 += num;
					break;
				case 14:
					break;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到基本属性 出错：" + ex);
			}
		}

		private int 得到首饰强化增加障力恢复量(int level, int 强化阶段)
		{
			switch (level)
			{
			case 60:
				switch (强化阶段)
				{
				case 1:
					return 14;
				case 2:
					return 19;
				case 3:
					return 25;
				case 4:
					return 30;
				case 5:
					return 36;
				case 6:
					return 43;
				case 7:
					return 49;
				case 8:
					return 61;
				case 9:
					return 64;
				case 10:
					return 76;
				}
				break;
			case 80:
				switch (强化阶段)
				{
				case 1:
					return 16;
				case 2:
					return 21;
				case 3:
					return 27;
				case 4:
					return 33;
				case 5:
					return 40;
				case 6:
					return 47;
				case 7:
					return 55;
				case 8:
					return 67;
				case 9:
					return 71;
				case 10:
					return 84;
				}
				break;
			case 100:
				switch (强化阶段)
				{
				case 1:
					return 18;
				case 2:
					return 24;
				case 3:
					return 31;
				case 4:
					return 38;
				case 5:
					return 45;
				case 6:
					return 53;
				case 7:
					return 61;
				case 8:
					return 76;
				case 9:
					return 80;
				case 10:
					return 95;
				}
				break;
			case 115:
				switch (强化阶段)
				{
				case 1:
					return 19;
				case 2:
					return 26;
				case 3:
					return 33;
				case 4:
					return 40;
				case 5:
					return 48;
				case 6:
					return 57;
				case 7:
					return 66;
				case 8:
					return 81;
				case 9:
					return 85;
				case 10:
					return 101;
				}
				break;
			case 120:
				switch (强化阶段)
				{
				case 1:
					return 8;
				case 2:
					return 17;
				case 3:
					return 27;
				case 4:
					return 38;
				case 5:
					return 0;
				case 6:
					return 63;
				case 7:
					return 77;
				case 8:
					return 92;
				case 9:
					return 108;
				case 10:
					return 125;
				}
				break;
			case 130:
				switch (强化阶段)
				{
				case 1:
					return 10;
				case 2:
					return 21;
				case 3:
					return 33;
				case 4:
					return 46;
				case 5:
					return 60;
				case 6:
					return 75;
				case 7:
					return 91;
				case 8:
					return 108;
				case 9:
					return 126;
				case 10:
					return 145;
				}
				break;
			case 140:
				switch (强化阶段)
				{
				case 1:
					return 13;
				case 2:
					return 27;
				case 3:
					return 42;
				case 4:
					return 58;
				case 5:
					return 75;
				case 6:
					return 93;
				case 7:
					return 112;
				case 8:
					return 132;
				case 9:
					return 153;
				case 10:
					return 175;
				}
				break;
			case 150:
				switch (强化阶段)
				{
				case 1:
					return 16;
				case 2:
					return 33;
				case 3:
					return 51;
				case 4:
					return 70;
				case 5:
					return 90;
				case 6:
					return 111;
				case 7:
					return 133;
				case 8:
					return 156;
				case 9:
					return 180;
				case 10:
					return 205;
				}
				break;
			case 160:
				switch (强化阶段)
				{
				case 1:
					return 19;
				case 2:
					return 39;
				case 3:
					return 60;
				case 4:
					return 82;
				case 5:
					return 105;
				case 6:
					return 129;
				case 7:
					return 154;
				case 8:
					return 180;
				case 9:
					return 207;
				case 10:
					return 235;
				}
				break;
			}
			return 0;
		}

		private int 得到物品障力(ItmeClass Itme, int 强化阶段)
		{
			switch (FLD_RESIDE2)
			{
			case 1:
			{
				int num4 = 0;
				int num5 = 物品属性强 + (int)物品属性_追加强化;
				if (Itme.FLD_LEVEL <= 80)
				{
					num4 = 5;
				}
				else if (Itme.FLD_LEVEL == 90)
				{
					num4 = 10;
				}
				else if (Itme.FLD_LEVEL == 100)
				{
					num4 = 20;
				}
				else if (Itme.FLD_LEVEL == 110)
				{
					num4 = 30;
				}
				else if (Itme.FLD_LEVEL == 120)
				{
					num4 = 40;
				}
				else if (Itme.FLD_LEVEL == 130)
				{
					num4 = 50;
				}
				else if (Itme.FLD_LEVEL == 140)
				{
					num4 = 60;
				}
				物品属性_障力增加 += num5 * num4;
				if (num5 > 5)
				{
					switch (num5)
					{
					case 6:
						物品属性_障力增加 += 155;
						break;
					case 7:
						物品属性_障力增加 += 195;
						break;
					case 8:
						物品属性_障力增加 += 260;
						break;
					case 9:
						物品属性_障力增加 += 375;
						break;
					case 10:
						物品属性_障力增加 += 615;
						break;
					case 11:
						物品属性_障力增加 += 905;
						break;
					case 12:
						物品属性_障力增加 += 1295;
						break;
					case 13:
						物品属性_障力增加 += 1685;
						break;
					case 14:
						物品属性_障力增加 += 2125;
						break;
					case 15:
						物品属性_障力增加 += 2565;
						break;
					case 16:
						物品属性_障力增加 += 3115;
						break;
					}
				}
				break;
			}
			case 2:
			case 5:
			{
				int num2 = 0;
				int num3 = 物品属性强 + (int)物品属性_追加强化;
				if (Itme.FLD_LEVEL <= 80)
				{
					num2 = 5;
				}
				else if (Itme.FLD_LEVEL == 90)
				{
					num2 = 7;
				}
				else if (Itme.FLD_LEVEL == 100)
				{
					num2 = 9;
				}
				else if (Itme.FLD_LEVEL == 110)
				{
					num2 = 11;
				}
				else if (Itme.FLD_LEVEL == 120)
				{
					num2 = 13;
				}
				else if (Itme.FLD_LEVEL == 130)
				{
					num2 = 15;
				}
				else if (Itme.FLD_LEVEL == 140)
				{
					num2 = 17;
				}
				else if (Itme.FLD_LEVEL == 150)
				{
					num2 = 22;
				}
				物品属性_障力增加 += num3 * num2;
				if (num3 > 5)
				{
					switch (num3)
					{
					case 6:
						物品属性_障力增加 += 5;
						break;
					case 7:
						物品属性_障力增加 += 15;
						break;
					case 8:
						物品属性_障力增加 += 33;
						break;
					case 9:
						物品属性_障力增加 += 55;
						break;
					case 10:
						物品属性_障力增加 += 124;
						break;
					case 11:
						物品属性_障力增加 += 207;
						break;
					case 12:
						物品属性_障力增加 += 305;
						break;
					case 13:
						物品属性_障力增加 += 443;
						break;
					case 14:
						物品属性_障力增加 += 611;
						break;
					case 15:
						物品属性_障力增加 += 814;
						break;
					case 16:
						物品属性_障力增加 += 1057;
						break;
					}
				}
				break;
			}
			case 6:
			{
				int num = 0;
				if (Itme.FLD_LEVEL <= 55)
				{
					num = 1;
				}
				else if (Itme.FLD_LEVEL <= 65)
				{
					num = 2;
				}
				else if (Itme.FLD_LEVEL <= 75)
				{
					num = 3;
				}
				else if (Itme.FLD_LEVEL <= 85)
				{
					num = 5;
				}
				else if (Itme.FLD_LEVEL == 95)
				{
					num = 7;
				}
				else if (Itme.FLD_LEVEL == 105)
				{
					num = 9;
				}
				else if (Itme.FLD_LEVEL == 115)
				{
					num = 11;
				}
				else if (Itme.FLD_LEVEL == 125)
				{
					num = 13;
				}
				else if (Itme.FLD_LEVEL == 135)
				{
					num = 15;
				}
				else if (Itme.FLD_LEVEL == 145)
				{
					num = 17;
				}
				else if (Itme.FLD_LEVEL == 155)
				{
					num = 22;
				}
				物品属性_障力增加 += 物品属性强 * num;
				if (物品属性强 > 5)
				{
					switch (物品属性强)
					{
					case 6:
						物品属性_障力增加 += 5;
						break;
					case 7:
						物品属性_障力增加 += 15;
						break;
					case 8:
						物品属性_障力增加 += 33;
						break;
					case 9:
						物品属性_障力增加 += 55;
						break;
					case 10:
						物品属性_障力增加 += 124;
						break;
					case 11:
						物品属性_障力增加 += 207;
						break;
					case 12:
						物品属性_障力增加 += 305;
						break;
					case 13:
						物品属性_障力增加 += 443;
						break;
					case 14:
						物品属性_障力增加 += 611;
						break;
					case 15:
						物品属性_障力增加 += 814;
						break;
					}
				}
				break;
			}
			}
			return 0;
		}

		private void 计算武器属性(ItmeClass Itme)
		{
			try
			{
				物品攻击力 += 物品属性强 * 6;
				物品攻击力MAX += 物品属性强 * 6;
				物品攻击力New += 物品属性强 * 6;
				物品攻击力MaxNew += 物品属性强 * 6;
				if (物品属性强 <= 5)
				{
					物品武功命中 += 物品属性强;
				}
				else if (物品属性强 > 12)
				{
					物品武功命中 += 物品属性强 + 7;
				}
				else
				{
					物品武功命中 += 物品属性强 * 2 - 7;
				}
				if (物品属性强 > 5)
				{
					if (Itme.FLD_JOB_LEVEL >= 3 && 物品属性强 >= 7)
					{
						switch (物品属性强)
						{
						case 7:
							物品攻击力 += 10;
							物品攻击力MAX += 10;
							物品攻击力New += 10;
							物品攻击力MaxNew += 10;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 12;
								物品攻击力MAX += 12;
								物品攻击力New += 12;
								物品攻击力MaxNew += 12;
							}
							break;
						case 8:
							物品攻击力 += 24;
							物品攻击力MAX += 24;
							物品攻击力New += 24;
							物品攻击力MaxNew += 24;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 17;
								物品攻击力MAX += 17;
								物品攻击力New += 17;
								物品攻击力MaxNew += 17;
							}
							break;
						case 9:
							物品攻击力 += 48;
							物品攻击力MAX += 48;
							物品攻击力New += 48;
							物品攻击力MaxNew += 48;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 22;
								物品攻击力MAX += 22;
								物品攻击力New += 22;
								物品攻击力MaxNew += 22;
							}
							break;
						case 10:
							物品攻击力 += 102;
							物品攻击力MAX += 102;
							物品攻击力New += 102;
							物品攻击力MaxNew += 102;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 32;
								物品攻击力MAX += 32;
								物品攻击力New += 32;
								物品攻击力MaxNew += 32;
							}
							break;
						case 11:
							物品攻击力 += 111;
							物品攻击力MAX += 111;
							物品攻击力New += 111;
							物品攻击力MaxNew += 111;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 35;
								物品攻击力MAX += 35;
								物品攻击力New += 35;
								物品攻击力MaxNew += 35;
							}
							break;
						case 12:
							物品攻击力 += 125;
							物品攻击力MAX += 125;
							物品攻击力New += 125;
							物品攻击力MaxNew += 125;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 45;
								物品攻击力MAX += 45;
								物品攻击力New += 45;
								物品攻击力MaxNew += 45;
							}
							break;
						case 13:
							物品攻击力 += 144;
							物品攻击力MAX += 144;
							物品攻击力New += 144;
							物品攻击力MaxNew += 144;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 55;
								物品攻击力MAX += 55;
								物品攻击力New += 55;
								物品攻击力MaxNew += 55;
							}
							break;
						case 14:
							物品攻击力 += 168;
							物品攻击力MAX += 168;
							物品攻击力New += 168;
							物品攻击力MaxNew += 168;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 60;
								物品攻击力MAX += 60;
								物品攻击力New += 60;
								物品攻击力MaxNew += 60;
							}
							break;
						case 15:
							物品攻击力 += 197;
							物品攻击力MAX += 197;
							物品攻击力New += 197;
							物品攻击力MaxNew += 197;
							if (Itme.FLD_LEVEL >= 130)
							{
								物品攻击力 += 60;
								物品攻击力MAX += 60;
								物品攻击力New += 60;
								物品攻击力MaxNew += 60;
							}
							break;
						}
					}
					else
					{
						物品攻击力 += (物品属性强 - 5) * 2;
						物品攻击力MAX += (物品属性强 - 5) * 2;
						物品攻击力New += (物品属性强 - 5) * 2;
						物品攻击力MaxNew += (物品属性强 - 5) * 2;
						if (Itme.FLD_LEVEL >= 130)
						{
							物品攻击力 += 8;
							物品攻击力MAX += 8;
							物品攻击力New += 8;
							物品攻击力MaxNew += 8;
						}
					}
					if (物品属性强 >= 10 && FLD_RESIDE2 == 4)
					{
						switch (物品属性强)
						{
						case 10:
							物品属性_全部气功等级增加++;
							break;
						case 11:
							物品属性_全部气功等级增加 += 2;
							break;
						case 12:
							物品属性_全部气功等级增加 += 3;
							break;
						case 13:
							if (Itme.FLD_LEVEL >= 130)
							{
								物品属性_全部气功等级增加 += 4;
							}
							else
							{
								物品属性_全部气功等级增加 += 3;
							}
							break;
						case 14:
							if (Itme.FLD_LEVEL >= 130)
							{
								物品属性_全部气功等级增加 += 4;
							}
							else
							{
								物品属性_全部气功等级增加 += 3;
							}
							break;
						case 15:
							if (Itme.FLD_LEVEL >= 130)
							{
								物品属性_全部气功等级增加 += 4;
							}
							else
							{
								物品属性_全部气功等级增加 += 3;
							}
							break;
						}
					}
					if (物品属性强 >= 7)
					{
						ConcurrentDictionary<int, Itimesx> concurrentDictionary = new ConcurrentDictionary<int, Itimesx>();
						concurrentDictionary.TryAdd(0, 属性1);
						concurrentDictionary.TryAdd(1, 属性2);
						concurrentDictionary.TryAdd(2, 属性3);
						concurrentDictionary.TryAdd(3, 属性4);
						for (int i = 0; i < 4; i++)
						{
							if (concurrentDictionary[i].属性类型 == 0)
							{
								continue;
							}
							int 属性数量 = concurrentDictionary[i].属性数量;
							switch (concurrentDictionary[i].属性类型)
							{
							case 7:
								if (物品属性强 == 7)
								{
									if (i < 2)
									{
										物品属性_武功攻击力++;
										物品属性_武功攻击力New++;
									}
								}
								else if (物品属性强 <= 12)
								{
									物品属性_武功攻击力 += 物品属性强 - 7;
									物品属性_武功攻击力New += 物品属性强 - 7;
								}
								else if (物品属性强 <= 14)
								{
									double num3 = Math.Round((double)属性数量 / 4.0);
									物品属性_武功攻击力 += 物品属性强 - 7 + (int)num3;
									物品属性_武功攻击力New += 物品属性强 - 7 + (int)num3;
								}
								else
								{
									double num4 = Math.Round((double)属性数量 / 4.0);
									物品属性_武功攻击力 += 物品属性强 - 8 + (int)num4;
									物品属性_武功攻击力New += 物品属性强 - 8 + (int)num4;
								}
								break;
							case 8:
								if (物品属性强 >= 13)
								{
									物品属性_全部气功等级增加++;
								}
								break;
							case 10:
								if (物品属性强 == 7)
								{
									if (i < 2)
									{
										物品属性_追加伤害值++;
									}
								}
								else if (物品属性强 <= 12)
								{
									物品属性_追加伤害值 += 物品属性强 - 7;
								}
								else if (物品属性强 <= 14)
								{
									物品属性_追加伤害值 += 物品属性强 - 7 + (int)Math.Round((double)属性数量 / 4.0);
								}
								else
								{
									物品属性_追加伤害值 += 物品属性强 - 8 + (int)Math.Round((double)属性数量 / 4.0);
								}
								break;
							case 3:
								if (物品属性强 == 7)
								{
									if (i < 2)
									{
										物品属性_生命力增加++;
									}
								}
								else if (物品属性强 <= 12)
								{
									物品属性_生命力增加 += 物品属性强 - 7;
								}
								else if (物品属性强 <= 14)
								{
									物品属性_生命力增加 += 物品属性强 - 7 + (int)Math.Round((double)属性数量 / 4.0);
								}
								else
								{
									物品属性_生命力增加 += 物品属性强 - 8 + (int)Math.Round((double)属性数量 / 4.0);
								}
								break;
							case 1:
								if (物品属性强 == 7)
								{
									if (i < 2)
									{
										物品攻击力++;
										物品攻击力MAX++;
										物品攻击力New++;
										物品攻击力MaxNew++;
									}
								}
								else if (物品属性强 <= 12)
								{
									物品攻击力 += 物品属性强 - 7;
									物品攻击力MAX += 物品属性强 - 7;
									物品攻击力New += 物品属性强 - 7;
									物品攻击力MaxNew += 物品属性强 - 7;
								}
								else if (物品属性强 <= 14)
								{
									double num = Math.Round((double)属性数量 / 4.0);
									物品攻击力 += 物品属性强 - 7 + (int)num;
									物品攻击力MAX += 物品属性强 - 7 + (int)num;
									物品攻击力New += 物品属性强 - 7 + (int)num;
									物品攻击力MaxNew += 物品属性强 - 7 + (int)num;
								}
								else
								{
									double num2 = Math.Round((double)属性数量 / 4.0);
									物品攻击力 += 物品属性强 - 8 + (int)num2;
									物品攻击力MAX += 物品属性强 - 8 + (int)num2;
									物品攻击力New += 物品属性强 - 8 + (int)num2;
									物品攻击力MaxNew += 物品属性强 - 8 + (int)num2;
								}
								break;
							}
						}
						concurrentDictionary.Clear();
					}
				}
				if (Itme.FLD_LEVEL >= 130 && 物品属性强 == 5)
				{
					物品攻击力 += 2;
					物品攻击力MAX += 2;
					物品攻击力New += 2;
					物品攻击力MaxNew += 2;
				}
				int num5 = 8;
				if (FLD_FJ_觉醒 > 0)
				{
					int num6 = FLD_FJ_觉醒 * num5;
					物品攻击力 += num6;
					物品攻击力MAX += num6;
					物品攻击力New += num6;
					物品攻击力MaxNew += num6;
				}
			}
			catch
			{
			}
		}

		private void 计算衣服属性(ItmeClass Itme)
		{
			try
			{
				switch (物品属性强)
				{
				case 1:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 3;
						break;
					}
					物品防御力 += 4;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 2;
					}
					break;
				case 2:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 9;
						break;
					}
					物品防御力 += 12;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 4;
					}
					break;
				case 3:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 18;
						break;
					}
					物品防御力 += 24;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 6;
					}
					break;
				case 4:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 30;
						break;
					}
					物品防御力 += 40;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 8;
					}
					break;
				case 5:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 45;
						break;
					}
					物品防御力 += 60;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 10;
					}
					break;
				case 6:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 63;
						物品属性_生命力增加 += (物品属性强 - 5) * 5;
						break;
					}
					物品防御力 += 84;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 14;
					}
					物品属性_降低伤害值 += (物品属性强 - 5) * 5;
					break;
				case 7:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 84;
						物品属性_生命力增加 += (物品属性强 - 5) * 5;
						break;
					}
					物品防御力 += 112;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 18;
					}
					物品属性_降低伤害值 += (物品属性强 - 5) * 5;
					break;
				case 8:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 108;
						物品属性_生命力增加 += (物品属性强 - 5) * 5;
						break;
					}
					物品防御力 += 144;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 22;
					}
					物品属性_降低伤害值 += (物品属性强 - 5) * 5;
					break;
				case 9:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 135;
						物品属性_生命力增加 += (物品属性强 - 5) * 5;
						break;
					}
					物品防御力 += 180;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 26;
					}
					物品属性_降低伤害值 += 5 + (物品属性强 - 5) * 5;
					break;
				case 10:
					if (Itme.FLD_LEVEL < 60)
					{
						物品防御力 += 165;
						物品属性_生命力增加 += 5 + (物品属性强 - 5) * 5;
						break;
					}
					物品防御力 += 230;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 31;
					}
					物品属性_降低伤害值 += 5 + (物品属性强 - 5) * 5;
					break;
				case 11:
					物品防御力 += 265;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 34;
					}
					物品属性_降低伤害值 += 10 + (物品属性强 - 5) * 5;
					break;
				case 12:
					物品防御力 += 315;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 36;
					}
					物品属性_降低伤害值 += 15 + (物品属性强 - 5) * 5;
					break;
				case 13:
					物品防御力 += 365;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 44;
					}
					物品属性_降低伤害值 += 20 + (物品属性强 - 5) * 5;
					物品属性_生命力增加 += 260;
					break;
				case 14:
					物品防御力 += 415;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 52;
					}
					物品属性_降低伤害值 += 25 + (物品属性强 - 5) * 5;
					物品属性_生命力增加 += 260;
					break;
				case 15:
					物品防御力 += 465;
					if (Itme.FLD_LEVEL >= 130)
					{
						物品防御力 += 60;
					}
					物品属性_降低伤害值 += 30 + (物品属性强 - 5) * 5;
					物品属性_生命力增加 += 260;
					break;
				}
				int num = 5;
				if (FLD_FJ_觉醒 > 0)
				{
					int num2 = FLD_FJ_觉醒 * num;
					物品防御力 += num2;
				}
			}
			catch
			{
			}
		}

		private void 得到强化(string ysqh, int 触发属性提升)
		{
			try
			{
				if (!World.Itme.TryGetValue(BitConverter.ToInt32(物品ID, 0), out var value))
				{
					return;
				}
				switch (ysqh.Length)
				{
				case 8:
					物品属性阶段类型 = 0;
					物品属性阶段数 = 0;
					物品属性强类型 = int.Parse(ysqh.Substring(ysqh.Length - 8, 1));
					物品属性强 = int.Parse(ysqh.Substring(ysqh.Length - 2, 2));
					switch (物品属性强类型)
					{
					case 1:
						if (FLD_RESIDE2 == 10)
						{
							物品武功命中 += 物品属性强;
							if (value.FLD_LEVEL >= 160)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 13;
									物品攻击力MAX += 物品属性强 * 13;
									物品攻击力New += 物品属性强 * 13;
									物品攻击力MaxNew += 物品属性强 * 13;
								}
								else
								{
									物品攻击力 += 39 + (物品属性强 - 3) * 28;
									物品攻击力MAX += 39 + (物品属性强 - 3) * 28;
									物品攻击力New += 39 + (物品属性强 - 3) * 28;
									物品攻击力MaxNew += 39 + (物品属性强 - 3) * 28;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(160, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(160, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 150)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 11;
									物品攻击力MAX += 物品属性强 * 11;
									物品攻击力New += 物品属性强 * 11;
									物品攻击力MaxNew += 物品属性强 * 11;
								}
								else
								{
									物品攻击力 += 30 + (物品属性强 - 3) * 25;
									物品攻击力MAX += 30 + (物品属性强 - 3) * 25;
									物品攻击力New += 30 + (物品属性强 - 3) * 25;
									物品攻击力MaxNew += 30 + (物品属性强 - 3) * 25;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(150, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(150, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 140)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 9;
									物品攻击力MAX += 物品属性强 * 9;
									物品攻击力New += 物品属性强 * 9;
									物品攻击力MaxNew += 物品属性强 * 9;
								}
								else
								{
									物品攻击力 += 28 + (物品属性强 - 3) * 21;
									物品攻击力MAX += 28 + (物品属性强 - 3) * 21;
									物品攻击力New += 28 + (物品属性强 - 3) * 21;
									物品攻击力MaxNew += 28 + (物品属性强 - 3) * 21;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(140, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(140, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 130)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 7;
									物品攻击力MAX += 物品属性强 * 7;
									物品攻击力New += 物品属性强 * 7;
									物品攻击力MaxNew += 物品属性强 * 7;
								}
								else
								{
									物品攻击力 += 26 + (物品属性强 - 3) * 17;
									物品攻击力MAX += 26 + (物品属性强 - 3) * 17;
									物品攻击力New += 26 + (物品属性强 - 3) * 17;
									物品攻击力MaxNew += 26 + (物品属性强 - 3) * 17;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(130, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(130, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 120)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 6;
									物品攻击力MAX += 物品属性强 * 6;
									物品攻击力New += 物品属性强 * 6;
									物品攻击力MaxNew += 物品属性强 * 6;
								}
								else
								{
									物品攻击力 += 20 + (物品属性强 - 3) * 15;
									物品攻击力MAX += 20 + (物品属性强 - 3) * 15;
									物品攻击力New += 20 + (物品属性强 - 3) * 15;
									物品攻击力MaxNew += 20 + (物品属性强 - 3) * 15;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(120, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(120, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 115)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 5;
									物品攻击力MAX += 物品属性强 * 5;
									物品攻击力New += 物品属性强 * 5;
									物品攻击力MaxNew += 物品属性强 * 5;
								}
								else
								{
									物品攻击力 += 15 + (物品属性强 - 3) * 9;
									物品攻击力MAX += 15 + (物品属性强 - 3) * 9;
									物品攻击力New += 15 + (物品属性强 - 3) * 9;
									物品攻击力MaxNew += 15 + (物品属性强 - 3) * 9;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(115, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(115, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 100)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 4;
									物品攻击力MAX += 物品属性强 * 4;
									物品攻击力New += 物品属性强 * 4;
									物品攻击力MaxNew += 物品属性强 * 4;
								}
								else
								{
									物品攻击力 += 11 + (物品属性强 - 3) * 7;
									物品攻击力MAX += 11 + (物品属性强 - 3) * 7;
									物品攻击力New += 11 + (物品属性强 - 3) * 7;
									物品攻击力MaxNew += 11 + (物品属性强 - 3) * 7;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(100, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(100, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 80)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 3;
									物品攻击力MAX += 物品属性强 * 3;
									物品攻击力New += 物品属性强 * 3;
									物品攻击力MaxNew += 物品属性强 * 3;
								}
								else
								{
									物品攻击力 += 9 + (物品属性强 - 3) * 5;
									物品攻击力MAX += 9 + (物品属性强 - 3) * 5;
									物品攻击力New += 9 + (物品属性强 - 3) * 5;
									物品攻击力MaxNew += 9 + (物品属性强 - 3) * 5;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(80, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(80, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 60)
							{
								if (物品属性强 < 4)
								{
									物品攻击力 += 物品属性强 * 2;
									物品攻击力MAX += 物品属性强 * 2;
									物品攻击力New += 物品属性强 * 2;
									物品攻击力MaxNew += 物品属性强 * 2;
								}
								else
								{
									物品攻击力 += 6 + (物品属性强 - 3) * 3;
									物品攻击力MAX += 6 + (物品属性强 - 3) * 3;
									物品攻击力New += 6 + (物品属性强 - 3) * 3;
									物品攻击力MaxNew += 6 + (物品属性强 - 3) * 3;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(60, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(60, 物品属性强);
								}
							}
						}
						else
						{
							计算武器属性(value);
						}
						break;
					case 2:
						switch (FLD_RESIDE2)
						{
						case 1:
							计算衣服属性(value);
							得到物品障力(value, 物品属性强);
							break;
						case 3:
							break;
						case 4:
							break;
						case 2:
						case 5:
							switch (物品属性强)
							{
							case 1:
								物品防御力 += 3;
								break;
							case 2:
								物品防御力 += 6;
								break;
							case 3:
								物品防御力 += 9;
								break;
							case 4:
								物品防御力 += 12;
								break;
							case 5:
								物品防御力 += 15;
								break;
							case 6:
								if (value.FLD_LEVEL < 60)
								{
									物品防御力 += 18;
									物品属性_生命力增加 += (物品属性强 - 5) * 5;
								}
								else
								{
									物品防御力 += 19;
									物品属性_降低伤害值 += (物品属性强 - 5) * 5;
								}
								break;
							case 7:
								if (value.FLD_LEVEL < 60)
								{
									物品防御力 += 21;
									物品属性_生命力增加 += (物品属性强 - 5) * 5;
									break;
								}
								物品防御力 += 23;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 2;
								}
								物品属性_降低伤害值 += (物品属性强 - 5) * 5;
								break;
							case 8:
								if (value.FLD_LEVEL < 60)
								{
									物品防御力 += 27;
									物品属性_生命力增加 += (物品属性强 - 5) * 5;
									break;
								}
								物品防御力 += 29;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 5;
								}
								物品属性_降低伤害值 += (物品属性强 - 5) * 5;
								break;
							case 9:
								if (value.FLD_LEVEL < 60)
								{
									物品防御力 += 31;
									物品属性_生命力增加 += (物品属性强 - 5) * 5;
									break;
								}
								物品防御力 += 38;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 8;
								}
								物品属性_降低伤害值 += (物品属性强 - 5) * 5;
								break;
							case 10:
								if (value.FLD_LEVEL < 60)
								{
									物品防御力 += 37;
									物品属性_生命力增加 += 5 + (物品属性强 - 5) * 5;
									break;
								}
								物品防御力 += 53;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 11;
								}
								物品属性_降低伤害值 += 5 + (物品属性强 - 5) * 5;
								break;
							case 11:
								物品防御力 += 59;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 20;
								}
								物品属性_降低伤害值 += 10 + (物品属性强 - 5) * 5;
								break;
							case 12:
								物品防御力 += 65;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 29;
								}
								物品属性_降低伤害值 += 15 + (物品属性强 - 5) * 5;
								break;
							case 13:
								物品防御力 += 51;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 58;
								}
								物品属性_降低伤害值 += 20 + (物品属性强 - 5) * 5;
								物品属性_生命力增加 += 260;
								break;
							case 14:
								物品防御力 += 57;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 72;
								}
								物品属性_降低伤害值 += 25 + (物品属性强 - 5) * 5;
								物品属性_生命力增加 += 260;
								break;
							case 15:
								物品防御力 += 63;
								if (value.FLD_LEVEL >= 130)
								{
									物品防御力 += 86;
								}
								物品属性_降低伤害值 += 30 + (物品属性强 - 5) * 5;
								物品属性_生命力增加 += 260;
								break;
							}
							得到物品障力(value, 物品属性强);
							break;
						case 6:
							物品防御力 += 物品属性强 * 3;
							switch (物品属性强)
							{
							case 6:
								物品防御力 += 2;
								if (value.FLD_LEVEL >= 65)
								{
									物品属性_生命力增加 += 40;
								}
								else
								{
									物品属性_生命力增加 += 45;
								}
								break;
							case 7:
								物品防御力 += 4;
								if (value.FLD_LEVEL >= 65)
								{
									物品属性_生命力增加 += 80;
								}
								else
								{
									物品属性_生命力增加 += 90;
								}
								break;
							case 8:
								物品防御力 += 10;
								if (value.FLD_LEVEL >= 65)
								{
									物品属性_生命力增加 += 140;
								}
								else
								{
									物品属性_生命力增加 += 155;
								}
								break;
							case 9:
								物品防御力 += 22;
								if (value.FLD_LEVEL >= 65)
								{
									物品属性_生命力增加 += 200;
								}
								else
								{
									物品属性_生命力增加 += 220;
								}
								break;
							case 10:
								物品防御力 += 46;
								if (value.FLD_LEVEL >= 65)
								{
									物品属性_生命力增加 += 300;
								}
								else
								{
									物品属性_生命力增加 += 300;
								}
								break;
							case 11:
								物品防御力 += 61;
								物品属性_生命力增加 += 300;
								break;
							case 12:
								物品防御力 += 76;
								物品属性_生命力增加 += 300;
								break;
							case 13:
								物品防御力 += 71;
								物品属性_生命力增加 += 610;
								break;
							case 14:
								物品防御力 += 91;
								物品属性_生命力增加 += 610;
								break;
							case 15:
								物品防御力 += 111;
								物品属性_生命力增加 += 610;
								break;
							}
							得到物品障力(value, 物品属性强);
							break;
						case 7:
							物品武功回避 += 物品属性强;
							if (value.FLD_LEVEL >= 160)
							{
								if (物品属性强 < 4)
								{
									物品防御力 += 物品属性强 * 13;
								}
								else
								{
									物品防御力 += 39 + (物品属性强 - 3) * 28;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(160, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(160, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 150)
							{
								if (物品属性强 < 4)
								{
									物品防御力 += 物品属性强 * 11;
								}
								else
								{
									物品防御力 += 30 + (物品属性强 - 3) * 25;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(150, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(150, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 140)
							{
								if (物品属性强 < 4)
								{
									物品防御力 += 物品属性强 * 9;
								}
								else
								{
									物品防御力 += 28 + (物品属性强 - 3) * 21;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(140, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(140, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 130)
							{
								if (物品属性强 < 4)
								{
									物品防御力 += 物品属性强 * 7;
								}
								else
								{
									物品防御力 += 26 + (物品属性强 - 3) * 17;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(130, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(130, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 120)
							{
								if (物品属性强 < 4)
								{
									物品防御力 += 物品属性强 * 6;
								}
								else
								{
									物品防御力 += 20 + (物品属性强 - 3) * 15;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(120, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(120, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 115)
							{
								if (物品属性强 < 4)
								{
									物品防御力 += 物品属性强 * 5;
								}
								else
								{
									物品防御力 += 15 + (物品属性强 - 3) * 9;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(115, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(115, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 100)
							{
								if (物品属性强 < 5)
								{
									物品防御力 += 物品属性强 * 4;
								}
								else
								{
									物品防御力 += 11 + (物品属性强 - 4) * 7;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(100, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(100, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 80)
							{
								if (物品属性强 < 4)
								{
									物品防御力 += 物品属性强 * 3;
								}
								else
								{
									物品防御力 += 9 + (物品属性强 - 3) * 5;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(80, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(80, 物品属性强);
								}
							}
							else if (value.FLD_LEVEL >= 60)
							{
								if (物品属性强 < 4)
								{
									物品防御力 += 物品属性强 * 2;
								}
								else
								{
									物品防御力 += 6 + (物品属性强 - 3) * 3;
								}
								if (value.FLD_RESIDE1 == 11)
								{
									物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(60, 物品属性强);
								}
								else
								{
									物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(60, 物品属性强);
								}
							}
							break;
						case 8:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
							break;
						case 14:
							switch (物品属性强)
							{
							case 1:
							case 2:
							case 3:
							case 4:
							case 5:
								物品防御力 += 物品属性强 * 3;
								break;
							case 6:
							case 7:
							case 8:
							case 9:
								物品防御力 += 15 + (物品属性强 - 5) * 4;
								物品属性_生命力增加 += 物品属性强 - 25;
								break;
							case 10:
								物品防御力 += 37;
								物品属性_生命力增加 += 30;
								break;
							}
							break;
						}
						break;
					case 3:
						if (FLD_RESIDE2 != 8)
						{
							break;
						}
						if (value.FLD_LEVEL >= 160)
						{
							物品属性_生命力增加 += 物品属性强 * 160;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(160, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(160, 物品属性强);
							}
						}
						else if (value.FLD_LEVEL >= 150)
						{
							物品属性_生命力增加 += 物品属性强 * 130;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(150, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(150, 物品属性强);
							}
						}
						else if (value.FLD_LEVEL >= 140)
						{
							物品属性_生命力增加 += 物品属性强 * 100;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(140, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(140, 物品属性强);
							}
						}
						else if (value.FLD_LEVEL >= 130)
						{
							物品属性_生命力增加 += 物品属性强 * 80;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(130, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(130, 物品属性强);
							}
						}
						else if (value.FLD_LEVEL >= 120)
						{
							物品属性_生命力增加 += 物品属性强 * 70;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(120, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(120, 物品属性强);
							}
						}
						else if (value.FLD_LEVEL >= 115)
						{
							物品属性_生命力增加 += 物品属性强 * 50;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(115, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(115, 物品属性强);
							}
						}
						else if (value.FLD_LEVEL >= 100)
						{
							物品属性_生命力增加 += 物品属性强 * 40;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(100, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(100, 物品属性强);
							}
						}
						else if (value.FLD_LEVEL >= 80)
						{
							物品属性_生命力增加 += 物品属性强 * 15;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(80, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(80, 物品属性强);
							}
						}
						else if (value.FLD_LEVEL >= 60)
						{
							物品属性_生命力增加 += 物品属性强 * 5;
							if (value.FLD_RESIDE1 == 11)
							{
								物品属性_障力恢复量增加 += 得到首饰强化增加障力恢复量(60, 物品属性强);
							}
							else
							{
								物品属性_追加伤害值 += 得到首饰强化增加障力恢复量(60, 物品属性强);
							}
						}
						break;
					case 4:
						if (物品属性强 >= World.披风强化最大数量)
						{
							物品属性强 = World.披风强化最大数量;
						}
						if (物品属性强 > 1)
						{
							if ((物品属性强 & 1) == 1)
							{
								物品防御力 += (物品属性强 - 1) / 2 + 5;
								物品攻击力 += (物品属性强 - 1) / 2 + 5;
								物品攻击力MAX += (物品属性强 - 1) / 2 + 5;
								物品攻击力New += (物品属性强 - 1) / 2 + 5;
								物品攻击力MaxNew += (物品属性强 - 1) / 2 + 5;
								物品属性_生命力增加 += (物品属性强 - 1) / 2 * 10;
								物品属性_获得金钱增加 += (物品属性强 - 1) * 2;
								物品增加负重 += 物品属性强;
							}
							else
							{
								物品防御力 += 物品属性强 / 2 + 5;
								物品攻击力 += 物品属性强 / 2 + 5;
								物品攻击力MAX += 物品属性强 / 2 + 5;
								物品攻击力New += 物品属性强 / 2 + 5;
								物品攻击力MaxNew += 物品属性强 / 2 + 5;
								物品属性_生命力增加 += 物品属性强 / 2 * 10;
								物品属性_获得金钱增加 += 物品属性强 * 2;
								物品增加负重 += 物品属性强;
							}
							if (物品属性强 > 4)
							{
								物品武功命中 += 物品属性强 / 2;
								物品武功回避 += 物品属性强 / 2;
							}
						}
						else
						{
							物品防御力 += 5;
						}
						物品增加负重 += 物品属性强;
						break;
					case 5:
					{
						int fLD_MAGIC = FLD_MAGIC2;
						if (物品属性强类型 != 5)
						{
							break;
						}
						if (物品属性强 >= World.灵宠强化最大数量)
						{
							物品属性强 = World.灵宠强化最大数量;
						}
						if (物品属性强 > 1)
						{
							if (value.FLD_PID == 1000001170)
							{
								物品对怪防御力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 2 + 10;
								物品对怪攻击力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 2 + 10;
								物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 10;
							}
							else if (value.FLD_PID == 1000001171)
							{
								物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.785) + 9;
								物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.785) + 9;
								物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 8;
							}
							else if (value.FLD_PID == 1000001172)
							{
								物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.089 + 5.5);
								物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.089 + 5.5);
								物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 1;
							}
							else if (value.FLD_PID == 1000001173)
							{
								物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.196) + 6;
								物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.196) + 6;
								物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 2;
							}
							else if (value.FLD_PID == 1000001174)
							{
								物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.785) + 9;
								物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.785) + 9;
								物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10;
							}
							else if (value.FLD_PID == 1000001175)
							{
								物品对怪防御力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.0) + 5;
								物品对怪攻击力 += (int)((Math.Ceiling((double)物品属性强 / 2.0) - 1.0) * 1.0) + 5;
								物品属性_生命力增加 = (int)Math.Floor((double)物品属性强 / 2.0) * 10 + 6;
							}
							switch (fLD_MAGIC)
							{
							case 0:
								物品防御力 += (int)Math.Ceiling((double)物品属性强 / 2.0) + 4;
								物品攻击力 += (int)Math.Ceiling((double)物品属性强 / 2.0) + 4;
								物品攻击力New += (int)Math.Ceiling((double)物品属性强 / 2.0) + 4;
								break;
							case 1:
								物品防御力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 1.1875) + 5;
								物品攻击力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 1.1875) + 5;
								物品攻击力New += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 1.1875) + 5;
								物品对怪防御力 *= 2;
								物品对怪攻击力 *= 2;
								break;
							case 2:
								物品防御力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 1.5 + 5.5);
								物品攻击力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 1.5 + 5.5);
								物品攻击力New += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 1.5 + 5.5);
								物品对怪防御力 *= 4;
								物品对怪攻击力 *= 4;
								break;
							case 3:
								物品防御力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 2.0) + 8;
								物品攻击力 += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 2.0) + 8;
								物品攻击力New += (int)(Math.Ceiling((double)物品属性强 / 2.0) * 2.0) + 8;
								物品对怪防御力 *= 8;
								物品对怪攻击力 *= 8;
								break;
							}
						}
						else if (物品属性强 == 1)
						{
							int num3 = 5;
							int num4 = 10;
							switch (fLD_MAGIC)
							{
							case 1:
								num3 += 6;
								num4 += 20;
								break;
							case 2:
								num3 += 7;
								num4 += 40;
								break;
							case 3:
								num3 += 10;
								num4 += 80;
								break;
							}
							物品防御力 += num3;
							物品攻击力 += num3;
							物品攻击力New += num3;
							物品对怪防御力 += num4;
							物品对怪攻击力 += num4;
						}
						break;
					}
					}
					break;
				case 9:
					物品属性阶段类型 = 0;
					物品属性阶段数 = 0;
					物品属性强类型 = int.Parse(ysqh.Substring(ysqh.Length - 9, 1));
					物品属性强 = int.Parse(ysqh.Substring(ysqh.Length - 3, 3));
					if (物品属性强类型 != 4)
					{
						break;
					}
					if (物品属性强 >= World.披风强化最大数量)
					{
						物品属性强 = World.披风强化最大数量;
					}
					if (物品属性强 > 1)
					{
						if ((物品属性强 & 1) == 1)
						{
							物品防御力 += (物品属性强 - 1) / 2 + 5;
							物品攻击力 += (物品属性强 - 1) / 2 + 5;
							物品攻击力MAX += (物品属性强 - 1) / 2 + 5;
							物品攻击力New += (物品属性强 - 1) / 2 + 5;
							物品攻击力MaxNew += (物品属性强 - 1) / 2 + 5;
							物品属性_生命力增加 += (物品属性强 - 1) / 2 * 10 + 550;
							物品属性_获得金钱增加 += (物品属性强 - 1) * 2;
							物品增加负重 += 物品属性强;
						}
						else
						{
							物品防御力 += 物品属性强 / 2 + 5;
							物品攻击力 += 物品属性强 / 2 + 5;
							物品攻击力MAX += 物品属性强 / 2 + 5;
							物品攻击力New += 物品属性强 / 2 + 5;
							物品攻击力MaxNew += 物品属性强 / 2 + 5;
							物品属性_生命力增加 += 物品属性强 / 2 * 10 + 550;
							物品属性_获得金钱增加 += 物品属性强 * 2;
							物品增加负重 += 物品属性强;
						}
						if (物品属性强 > 4)
						{
							物品武功命中 += 物品属性强 / 2;
							物品武功回避 += 物品属性强 / 2;
						}
					}
					else
					{
						物品防御力 += 5;
					}
					物品增加负重 += 物品属性强;
					break;
				case 10:
					物品属性阶段类型 = int.Parse(ysqh.Substring(ysqh.Length - 4, 1));
					物品属性阶段数 = int.Parse(ysqh.Substring(ysqh.Length - 3, 1)) + 1;
					物品属性强类型 = int.Parse(ysqh.Substring(ysqh.Length - 8, 1));
					物品属性强 = int.Parse(ysqh.Substring(ysqh.Length - 2, 2));
					if (物品属性强类型 == 1)
					{
						if (value.FLD_RESIDE2 != 4)
						{
							break;
						}
						计算武器属性(value);
						if (物品属性强 > 5 && 物品属性阶段类型 != 0)
						{
							物品属性阶段数 += 物品属性强 - 5;
						}
						int num = 1;
						if (触发属性提升 == 2)
						{
							num = 2;
						}
						if (物品属性阶段类型 != 0 && 物品属性阶段数 > 0)
						{
							switch (物品属性阶段类型)
							{
							case 1:
								物品属性_降低百分比防御 = (double)物品属性阶段数 * 0.005 * (double)num;
								物品属性_对怪伤害 = (double)物品属性阶段数 * 0.005 * (double)num;
								break;
							case 2:
								物品属性_初始化愤怒概率百分比 = 物品属性阶段数 * num;
								break;
							case 3:
								物品属性_增加百分比命中 += (double)物品属性阶段数 * 0.01 * (double)num;
								break;
							case 4:
								物品属性_武功攻击力 += (int)((double)物品属性阶段数 * 0.5) * num;
								物品属性_武功攻击力New += (int)((double)物品属性阶段数 * 0.5) * num;
								break;
							case 5:
								物品属性_追加伤害值 += 物品属性阶段数 * 3 * num;
								break;
							case 6:
								物品属性_追加中毒几率百分比 += (double)物品属性阶段数 * 0.01 * (double)num;
								物品攻击力 += 物品属性阶段数 * 3 * num;
								物品攻击力MAX += 物品属性阶段数 * 3 * num;
								物品攻击力New += 物品属性阶段数 * 3 * num;
								物品攻击力MaxNew += 物品属性阶段数 * 3 * num;
								break;
							}
						}
					}
					else
					{
						if (物品属性强类型 != 2 || value.FLD_RESIDE2 != 1)
						{
							break;
						}
						计算衣服属性(value);
						得到物品障力(value, 物品属性强);
						int num2 = 1;
						if (触发属性提升 == 1)
						{
							num2 = 2;
						}
						if (物品属性阶段类型 != 0 && 物品属性阶段数 > 0)
						{
							switch (物品属性阶段类型)
							{
							case 1:
								物品属性_降低百分比攻击 = (double)物品属性阶段数 * 0.005 * (double)num2;
								物品属性_对怪伤害 = (double)物品属性阶段数 * 0.005 * (double)num2;
								break;
							case 2:
								物品属性_愤怒值增加 = 物品属性阶段数 * num2;
								break;
							case 3:
								物品属性_增加百分比回避 += (double)物品属性阶段数 * 0.01 * (double)num2;
								break;
							case 4:
								物品属性_武功防御力增加 += 物品属性阶段数 * 8 * num2;
								break;
							case 5:
								物品防御力 += 物品属性阶段数 * 3 * num2;
								break;
							case 6:
								物品属性_追加中毒几率百分比 += (double)物品属性阶段数 * 0.01 * (double)num2;
								break;
							}
						}
					}
					break;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "得到强化 出错：" + ex);
			}
		}
	}
}
