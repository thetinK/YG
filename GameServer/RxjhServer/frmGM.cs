using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class frmGM : Form
	{
		private IContainer components = null;

		private GroupBox groupBox1;

		private TextBox txtY;

		private TextBox txtX;

		private Label label23;

		private TextBox txtMonserId;

		private Label label22;

		private Label label21;

		private ComboBox cmbMap;

		private Button btnAddNpc;

		private GroupBox groupBox2;

		private Button btnReduceTime;

		private Button btnAddTime;

		private Button btnReduceInteg;

		private Button btnAddInteg;

		private Button btnReduceHB;

		private Button btnReduceMZ;

		private Button btnReduceMP;

		private Button btnReduceHP;

		private Button btnReduceWF;

		private Button btnReduceDF;

		private Button btnReduceAT;

		private Button btnReducePoint;

		private Button btnReduceWX;

		private Button btnReduceLL;

		private Button btnReduceExp;

		private Button btnReduceMoney;

		private Button btnAddHB;

		private Button btnAddMZ;

		private Button btnAddMP;

		private Button btnAddHP;

		private Button btnAddWF;

		private Button btnAddDF;

		private Button btnAddAT;

		private Button btnAddWX;

		private Button btnAddExp;

		private Label label9;

		private Button btnAddLL;

		private TextBox textBox2;

		private Button btnAddMoney;

		private Button btnAddPoint;

		private Button button41;

		private Label label14;

		private TextBox textBox13;

		private Label label19;

		private Button button40;

		private Button button39;

		private Button button38;

		private TextBox textBox14;

		private Label label20;

		private TextBox textBox12;

		private Label label18;

		private TextBox txtVip;

		private Label label17;

		private TextBox txtSX5;

		private Label label16;

		private ComboBox cmbSX5;

		private TextBox txtExp;

		private Label label15;

		private Button btnChangeExp;

		private Button btnCutZSCS;

		private Button btnChangeJob;

		private Label label6;

		private Button btnAddZSCS;

		private Button btnChangeLv;

		private Button btnChangeZZ;

		private Button btnChangeZx;

		private Button btnChangeSex;

		private Label label2;

		private TextBox txtZSCS;

		private TextBox txtLv;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private Label label8;

		private Label label5;

		private ComboBox cmbBD;

		private TextBox txtSX4;

		private TextBox txtSX3;

		private TextBox txtSX2;

		private TextBox txtSX1;

		private TextBox txtSX;

		private TextBox txtIntensify;

		private ComboBox cmbSX4;

		private ComboBox cmbSX3;

		private ComboBox cmbSX2;

		private ComboBox cmbSX1;

		private ComboBox cmbSX;

		private ComboBox cmbIntensify;

		private Label label46;

		private Label label45;

		private Label label44;

		private Label label43;

		private Label label42;

		private Label label41;

		private Button btnAddItem;

		private Label label4;

		private Label label3;

		private Label label1;

		private ComboBox cmbItem;

		private ComboBox cmbItemType;

		private ListBox lsItems;

		private TextBox txtUserName;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel tishi;

		private ComboBox cmbJob;

		private ComboBox cmbZX;

		private ComboBox cmbZZ;

		private ComboBox cmbSex;

		private TextBox txtQueryStr;

		private Button btnQueryName;

		private Button button1;

		private TextBox txtSt;

		private Button btnBaoWuping;

		private Label label24;

		private TextBox txtGWName_Item;

		private Button btnOpen;

		private Label label25;

		private TextBox txtItemName_Open;

		private CheckBox checkBox1;

		public frmGM()
		{
			InitializeComponent();
		}

		private void btnChangeJob_Click(object sender, EventArgs e)
		{
			int selectedIndex = cmbJob.SelectedIndex;
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_Job = selectedIndex;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				players.保存人物数据存储过程();
				players.系统提示("成功修改职业为 (" + cmbJob.Text + ") 小退重上生效!", 21, "GM提示");
				tishi.Text = "玩家后台刷取职业修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnChangeZx_Click(object sender, EventArgs e)
		{
			int selectedIndex = cmbZX.SelectedIndex;
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_Zx = selectedIndex;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.保存人物数据存储过程();
				players.系统提示("成功修改为（" + cmbZX.Text + "）小退重上生效!", 21, "GM提示");
				tishi.Text = "玩家后台刷取正邪修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnChangeLv_Click(object sender, EventArgs e)
		{
			int player_Level = int.Parse(txtLv.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_Level = player_Level;
				players.人物经验 = 0L;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.保存人物数据存储过程();
				players.更新广播人物数据();
				players.更新气功();
				players.系统提示("成功修改等级为:" + player_Level + "级", 21, "GM提示");
				tishi.Text = "玩家后台刷取等级修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnChangeZZ_Click(object sender, EventArgs e)
		{
			int selectedIndex = cmbZZ.SelectedIndex;
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_Job_leve = selectedIndex;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.更新气功();
				players.保存人物数据存储过程();
				players.系统提示("转职成功修改为（" + selectedIndex + "转）小退重上生效!", 21, "GM提示");
				tishi.Text = "玩家后台刷取转职修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnChangeSex_Click(object sender, EventArgs e)
		{
			int selectedIndex = cmbSex.SelectedIndex;
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_Sex = selectedIndex;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.保存人物数据存储过程();
				players.系统提示("您已经成功修改性别为" + cmbSex.Text + ",请小退后重上!", 21, "GM提示");
				tishi.Text = "玩家后台刷取性别修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnChangeExp_Click(object sender, EventArgs e)
		{
			long 人物经验 = long.Parse(txtExp.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.人物经验 = 人物经验;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.保存人物数据存储过程();
				players.更新广播人物数据();
				players.更新气功();
				players.系统提示("获得" + 人物经验 + "经验值", 21, "GM提示");
				tishi.Text = "玩家后台刷取等级修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddZSCS_Click(object sender, EventArgs e)
		{
		}

		private void btnCutZSCS_Click(object sender, EventArgs e)
		{
		}

		private void button38_Click(object sender, EventArgs e)
		{
			int num = int.Parse(txtVip.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				if (World.AllConnectedPlayers.TryGetValue(players.人物全服ID, out var _))
				{
					DateTime now = DateTime.Now;
					now = DateTime.Now.AddDays(num);
					players.FLD_VIP = 1;
					players.FLD_VIPTIM = now;
					players.系统提示("恭喜您获得" + num + "天的VIP！", 21, "GM提示");
					players.系统提示("你的VIP到期时间是:" + players.FLD_VIPTIM.ToString("yyyy年MM月dd日 hh时mm分"), 9, "GM提示");
					players.系统提示("续时成功,你的VIP到期时间是:" + players.FLD_VIPTIM.ToString("yyyy年MM月dd日 hh时mm分"), 9, "GM提示");
					players.SavePlayerData();
					players.保存会员数据();
				}
				tishi.Text = "玩家后台刷会员成功";
			}
			else
			{
				tishi.Text = "刷取属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SearchItem();
		}

		private void SearchItem(string Args = "")
		{
			string text = "";
			switch (cmbItemType.Text)
			{
			case "武器":
				text = "4";
				break;
			case "衣服":
				text = "1";
				break;
			case "护手":
				text = "2";
				break;
			case "鞋子":
				text = "5";
				break;
			case "内甲":
				text = "6";
				break;
			case "项链":
				text = "7";
				break;
			case "耳环":
				text = "8";
				break;
			case "戒指":
				text = "10";
				break;
			case "男/女披风":
				text = "12";
				break;
			case "门派战甲":
				text = "14";
				break;
			case "灵兽召唤符":
				text = "15";
				break;
			case "召唤书/弓箭":
				text = "13";
				break;
			case "石头类":
				text = "16";
				break;
			case "幸运符":
				text = "18";
				break;
			case "盒子/箱子":
				text = "17";
				break;
			case "其他":
				text = "0";
				break;
			case "未知":
				text = "20";
				break;
			}
			lsItems.Items.Clear();
			cmbItem.Items.Clear();
			string string_ = "select * from TBL_XWWL_ITEM where FLD_RESIDE2='" + text + "'";
			if (!string.IsNullOrEmpty(Args))
			{
				string_ = "select * from TBL_XWWL_ITEM where FLD_RESIDE2='" + text + "' AND FLD_NAME LIKE '%" + Args + "%'";
			}
			DataTable dBToDataTable = DBA.GetDBToDataTable(string_, "PublicDb");
			for (int i = 0; i < dBToDataTable.Rows.Count; i++)
			{
				string item = dBToDataTable.Rows[i]["FLD_NAME"].ToString();
				string item2 = dBToDataTable.Rows[i]["FLD_PID"].ToString();
				lsItems.Items.Add(item);
				cmbItem.Items.Add(item2);
			}
		}

		private void lsItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmbItem.SelectedIndex = lsItems.SelectedIndex;
		}

		private void btnAddItem_Click(object sender, EventArgs e)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			string text = cmbIntensify.Text;
			bool flag = false;
			if (1 == 0)
			{
			}
			int num9 = text switch
			{
				"武器强化" => 10000000 + int.Parse(txtIntensify.Text), 
				"防具强化" => 20000000 + int.Parse(txtIntensify.Text), 
				"药品个数" => 2000000000 + int.Parse(txtIntensify.Text), 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			int num6 = num9;
			bool flag2 = false;
			num = num6;
			int num7 = 0;
			num7 = int.Parse(txtSX.Text) * 100;
			switch (cmbSX.Text)
			{
			case "火":
				num += 1000001000 + num7;
				break;
			case "水":
				num += 1000002000 + num7;
				break;
			case "风":
				num += 1000003000 + num7;
				break;
			case "内":
				num += 1000004000 + num7;
				break;
			case "外":
				num += 1000005000 + num7;
				break;
			case "毒":
				num += 1000006000 + num7;
				break;
			}
			num2 = 属性选择(cmbSX1.Text, int.Parse(txtSX1.Text));
			num3 = 属性选择(cmbSX2.Text, int.Parse(txtSX2.Text));
			num4 = 属性选择(cmbSX3.Text, int.Parse(txtSX3.Text));
			num5 = 属性选择(cmbSX4.Text, int.Parse(txtSX4.Text));
			属性选择(cmbSX5.Text, int.Parse(txtSX5.Text));
			int 初级附魂 = ((!(cmbBD.Text == "不绑")) ? 1 : 0);
			if (cmbItem.Text == string.Empty)
			{
				tishi.Text = "请选择物品ID";
				return;
			}
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				int num8 = players.得到包裹空位(players);
				if (num8 == -1)
				{
					tishi.Text = "该玩家没有空位了,请通知玩家清理背包后再尝试";
					return;
				}
				players.AddItemWithProperties(int.Parse(cmbItem.Text), num8, 1, num, num2, num3, num4, num5, 初级附魂, 0, 0, 0, 0);
				players.系统提示("获得 " + ItmeClass.得到物品名称(int.Parse(cmbItem.Text)), 21, "GM提示");
				tishi.Text = "玩家后台已经将物品成功刷入玩家[" + players.UserName + "]背包中";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private int 属性选择(string txt, int sx)
		{
			try
			{
				bool flag = false;
				if (1 == 0)
				{
				}
				int num = txt switch
				{
					"药品数量" => 2000000000 + sx, 
					"精炼蓝红" => 2010000000 + sx, 
					"精炼追加生命" => 1020000000 + sx, 
					"攻击增加" => 10000000 + sx, 
					"防御增加" => 20000000 + sx, 
					"生命增加" => 30000000 + sx, 
					"内功增加" => 40000000 + sx, 
					"命中率增加" => 50000000 + sx, 
					"回避率增加" => 60000000 + sx, 
					"武功攻击力%增加" => 70000000 + sx, 
					"全部气功等级增加" => 80000000 + sx, 
					"升级成功率%增加" => 90000000 + sx, 
					"追加伤害值" => 100000000 + sx, 
					"武功防御力增加" => 110000000 + sx, 
					"获得金钱%增加" => 120000000 + sx, 
					"死亡损失经验减少%" => 130000000 + sx, 
					"经验值增加%" => 150000000 + sx, 
					_ => 0, 
				};
				if (1 == 0)
				{
				}
				int result = num;
				bool flag2 = false;
				return result;
			}
			catch
			{
				return 0;
			}
		}

		private void btnAddNpc_Click(object sender, EventArgs e)
		{
			string text = cmbMap.Text;
			string string_ = "select * from TBL_地图列表 where FLD_NAME='" + text + "'";
			DataTable dBToDataTable = DBA.GetDBToDataTable(string_, "PublicDb");
			int num = int.Parse(dBToDataTable.Rows[0]["FLD_MID"].ToString());
		}

		private void btnAddPoint_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.检察元宝数据(num, 1, "后台");
				players.SaveGemData();
				players.系统提示("获得" + num + "元宝", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加元宝成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SaveGemData();
		}

		private void btnReducePoint_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.检察元宝数据1(-num, 1);
				players.SaveGemData();
				players.系统提示("系统扣除" + num + "元宝", 21, "GM提示");
				tishi.Text = "玩家后台刷取减少元宝成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SaveGemData();
		}

		private void btnAddInteg_Click(object sender, EventArgs e)
		{
			long num = long.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.SaveGemData();
				players.系统提示("获得" + num + "积分", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加积分成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SaveGemData();
		}

		private void btnReduceInteg_Click(object sender, EventArgs e)
		{
			long num = long.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.SaveGemData();
				players.系统提示("系统扣除" + num + "积分", 21, "GM提示");
				tishi.Text = "玩家后台刷取减少积分成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SaveGemData();
		}

		private void btnAddMoney_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_Money += num;
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "两游戏币", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加金币成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceMoney_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_Money -= num;
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "两游戏币", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加金币成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddWX_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_WuXun += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				players.系统提示("获得" + num + "武勋", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加武勋成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceWX_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_WuXun -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				players.系统提示("获得" + num + "武勋", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加武勋成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddDF_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_装备_追加_防御 += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "防御", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加防御成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceDF_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_装备_追加_防御 -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "防御", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加防御成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddAT_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_装备_追加_攻击 += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				players.系统提示("获得" + num + "攻击", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加攻击成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceAT_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_装备_追加_攻击 -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				players.系统提示("获得" + num + "攻击", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加攻击成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddWF_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_人物_武功防御力增加百分比 += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "武功防御", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加武功防御成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceWF_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_人物_武功防御力增加百分比 -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "武功防御", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加武功防御成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddHB_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "回避", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加回避成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceHB_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "回避", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加回避成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddHP_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_装备_追加_HP += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "生命", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加生命成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceHP_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_装备_追加_HP -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "生命", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加生命成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddMZ_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "命中", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加命中成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceMZ_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "命中", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加命中成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddLL_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_ExpErience += num;
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				tishi.Text = "玩家后台刷取增加历练成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceLL_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.Player_ExpErience -= num;
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				tishi.Text = "玩家后台刷取增加历练成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddMP_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_装备_追加_MP += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "内功", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加内功成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceMP_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.FLD_装备_追加_MP -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "内功", 21, "GM提示");
				tishi.Text = "玩家后台刷取增加内功成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddExp_Click(object sender, EventArgs e)
		{
			long num = long.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.人物经验 += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				tishi.Text = "玩家后台刷取增加经验成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnReduceExp_Click(object sender, EventArgs e)
		{
			long num = long.Parse(textBox2.Text);
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				players.人物经验 -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				tishi.Text = "玩家后台刷取增加经验成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void btnAddTime_Click(object sender, EventArgs e)
		{
		}

		private void btnReduceTime_Click(object sender, EventArgs e)
		{
		}

		private void btnQueryName_Click(object sender, EventArgs e)
		{
			string text = txtQueryStr.Text;
			if (!string.IsNullOrEmpty(text))
			{
				SearchItem(text);
			}
			else
			{
				SearchItem();
			}
		}

		private void frmGM_Load(object sender, EventArgs e)
		{
			cmbMap.Items.Clear();
			string string_ = "select * from TBL_XWWL_MAP";
			DataTable dBToDataTable = DBA.GetDBToDataTable(string_, "PublicDb");
			foreach (DataRow row in dBToDataTable.Rows)
			{
				cmbMap.Items.Add(row["FLD_NAME"]);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				int num = players.得到包裹空位(players);
				if (num == -1)
				{
					tishi.Text = "该玩家没有空位了,请通知玩家清理背包后再尝试";
					return;
				}
				players.AddItemWithProperties(int.Parse(cmbItem.Text), num, 1, int.Parse(txtSt.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0);
				players.系统提示("获得 " + ItmeClass.得到物品名称(int.Parse(cmbItem.Text)), 21, "GM提示");
				tishi.Text = "玩家后台已经将物品成功刷入玩家[" + players.UserName + "]背包中";
			}
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			Players players = World.检查玩家name(txtUserName.Text);
			if (players != null)
			{
				int num = players.得到包裹空位(players);
				if (num == -1)
				{
					tishi.Text = "该玩家没有空位了,请通知";
					return;
				}
				players.AddItemWithProperties(int.Parse(cmbItem.Text), num, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
				tishi.Text = "已经成功刷入玩家[" + players.UserName + "]背包中";
				string text = "恭喜玩家[" + txtUserName.Text + "]打开[" + txtItemName_Open.Text + "]获得[" + lsItems.Text + "]";
				World.conn.发送("掉落全线提示|" + text + "|" + World.ServerID + "线开箱");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGM));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.txtItemName_Open = new System.Windows.Forms.TextBox();
            this.btnBaoWuping = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtGWName_Item = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSt = new System.Windows.Forms.TextBox();
            this.btnQueryName = new System.Windows.Forms.Button();
            this.txtQueryStr = new System.Windows.Forms.TextBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.cmbZZ = new System.Windows.Forms.ComboBox();
            this.cmbZX = new System.Windows.Forms.ComboBox();
            this.cmbJob = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tishi = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtMonserId = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbMap = new System.Windows.Forms.ComboBox();
            this.btnAddNpc = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReduceTime = new System.Windows.Forms.Button();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.btnReduceInteg = new System.Windows.Forms.Button();
            this.btnAddInteg = new System.Windows.Forms.Button();
            this.btnReduceHB = new System.Windows.Forms.Button();
            this.btnReduceMZ = new System.Windows.Forms.Button();
            this.btnReduceMP = new System.Windows.Forms.Button();
            this.btnReduceHP = new System.Windows.Forms.Button();
            this.btnReduceWF = new System.Windows.Forms.Button();
            this.btnReduceDF = new System.Windows.Forms.Button();
            this.btnReduceAT = new System.Windows.Forms.Button();
            this.btnReducePoint = new System.Windows.Forms.Button();
            this.btnReduceWX = new System.Windows.Forms.Button();
            this.btnReduceLL = new System.Windows.Forms.Button();
            this.btnReduceExp = new System.Windows.Forms.Button();
            this.btnReduceMoney = new System.Windows.Forms.Button();
            this.btnAddHB = new System.Windows.Forms.Button();
            this.btnAddMZ = new System.Windows.Forms.Button();
            this.btnAddMP = new System.Windows.Forms.Button();
            this.btnAddHP = new System.Windows.Forms.Button();
            this.btnAddWF = new System.Windows.Forms.Button();
            this.btnAddDF = new System.Windows.Forms.Button();
            this.btnAddAT = new System.Windows.Forms.Button();
            this.btnAddWX = new System.Windows.Forms.Button();
            this.btnAddExp = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddLL = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnAddMoney = new System.Windows.Forms.Button();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button40 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtVip = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSX5 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbSX5 = new System.Windows.Forms.ComboBox();
            this.txtExp = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnChangeExp = new System.Windows.Forms.Button();
            this.btnCutZSCS = new System.Windows.Forms.Button();
            this.btnChangeJob = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddZSCS = new System.Windows.Forms.Button();
            this.btnChangeLv = new System.Windows.Forms.Button();
            this.btnChangeZZ = new System.Windows.Forms.Button();
            this.btnChangeZx = new System.Windows.Forms.Button();
            this.btnChangeSex = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtZSCS = new System.Windows.Forms.TextBox();
            this.txtLv = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBD = new System.Windows.Forms.ComboBox();
            this.txtSX4 = new System.Windows.Forms.TextBox();
            this.txtSX3 = new System.Windows.Forms.TextBox();
            this.txtSX2 = new System.Windows.Forms.TextBox();
            this.txtSX1 = new System.Windows.Forms.TextBox();
            this.txtSX = new System.Windows.Forms.TextBox();
            this.txtIntensify = new System.Windows.Forms.TextBox();
            this.cmbSX4 = new System.Windows.Forms.ComboBox();
            this.cmbSX3 = new System.Windows.Forms.ComboBox();
            this.cmbSX2 = new System.Windows.Forms.ComboBox();
            this.cmbSX1 = new System.Windows.Forms.ComboBox();
            this.cmbSX = new System.Windows.Forms.ComboBox();
            this.cmbIntensify = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.lsItems = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.txtItemName_Open);
            this.groupBox1.Controls.Add(this.btnBaoWuping);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.txtGWName_Item);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtSt);
            this.groupBox1.Controls.Add(this.btnQueryName);
            this.groupBox1.Controls.Add(this.txtQueryStr);
            this.groupBox1.Controls.Add(this.cmbSex);
            this.groupBox1.Controls.Add(this.cmbZZ);
            this.groupBox1.Controls.Add(this.cmbZX);
            this.groupBox1.Controls.Add(this.cmbJob);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtMonserId);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cmbMap);
            this.groupBox1.Controls.Add(this.btnAddNpc);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button41);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.button40);
            this.groupBox1.Controls.Add(this.button39);
            this.groupBox1.Controls.Add(this.button38);
            this.groupBox1.Controls.Add(this.textBox14);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtVip);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtSX5);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cmbSX5);
            this.groupBox1.Controls.Add(this.txtExp);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnChangeExp);
            this.groupBox1.Controls.Add(this.btnCutZSCS);
            this.groupBox1.Controls.Add(this.btnChangeJob);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnAddZSCS);
            this.groupBox1.Controls.Add(this.btnChangeLv);
            this.groupBox1.Controls.Add(this.btnChangeZZ);
            this.groupBox1.Controls.Add(this.btnChangeZx);
            this.groupBox1.Controls.Add(this.btnChangeSex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtZSCS);
            this.groupBox1.Controls.Add(this.txtLv);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbBD);
            this.groupBox1.Controls.Add(this.txtSX4);
            this.groupBox1.Controls.Add(this.txtSX3);
            this.groupBox1.Controls.Add(this.txtSX2);
            this.groupBox1.Controls.Add(this.txtSX1);
            this.groupBox1.Controls.Add(this.txtSX);
            this.groupBox1.Controls.Add(this.txtIntensify);
            this.groupBox1.Controls.Add(this.cmbSX4);
            this.groupBox1.Controls.Add(this.cmbSX3);
            this.groupBox1.Controls.Add(this.cmbSX2);
            this.groupBox1.Controls.Add(this.cmbSX1);
            this.groupBox1.Controls.Add(this.cmbSX);
            this.groupBox1.Controls.Add(this.cmbIntensify);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.btnAddItem);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbItem);
            this.groupBox1.Controls.Add(this.cmbItemType);
            this.groupBox1.Controls.Add(this.lsItems);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1213, 802);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "物品属性修改/添加";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1018, 106);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 203;
            this.checkBox1.Text = "通知到群";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpen.Location = new System.Drawing.Point(980, 261);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(182, 27);
            this.btnOpen.TabIndex = 202;
            this.btnOpen.Text = "模拟开盒";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(933, 230);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 12);
            this.label25.TabIndex = 201;
            this.label25.Text = "盒子名称:";
            // 
            // txtItemName_Open
            // 
            this.txtItemName_Open.BackColor = System.Drawing.SystemColors.Info;
            this.txtItemName_Open.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemName_Open.Location = new System.Drawing.Point(998, 224);
            this.txtItemName_Open.Name = "txtItemName_Open";
            this.txtItemName_Open.Size = new System.Drawing.Size(182, 21);
            this.txtItemName_Open.TabIndex = 200;
            // 
            // btnBaoWuping
            // 
            this.btnBaoWuping.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnBaoWuping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoWuping.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBaoWuping.Location = new System.Drawing.Point(3, 20);
            this.btnBaoWuping.Name = "btnBaoWuping";
            this.btnBaoWuping.Size = new System.Drawing.Size(97, 25);
            this.btnBaoWuping.TabIndex = 204;
            this.btnBaoWuping.UseVisualStyleBackColor = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(933, 142);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 12);
            this.label24.TabIndex = 196;
            this.label24.Text = "怪物名称:";
            // 
            // txtGWName_Item
            // 
            this.txtGWName_Item.BackColor = System.Drawing.SystemColors.Info;
            this.txtGWName_Item.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGWName_Item.Location = new System.Drawing.Point(998, 136);
            this.txtGWName_Item.Name = "txtGWName_Item";
            this.txtGWName_Item.Size = new System.Drawing.Size(182, 21);
            this.txtGWName_Item.TabIndex = 195;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(680, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 27);
            this.button1.TabIndex = 189;
            this.button1.Text = "刷石头";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSt
            // 
            this.txtSt.BackColor = System.Drawing.SystemColors.Info;
            this.txtSt.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSt.Location = new System.Drawing.Point(558, 59);
            this.txtSt.Name = "txtSt";
            this.txtSt.Size = new System.Drawing.Size(104, 21);
            this.txtSt.TabIndex = 188;
            // 
            // btnQueryName
            // 
            this.btnQueryName.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnQueryName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQueryName.Location = new System.Drawing.Point(680, 27);
            this.btnQueryName.Name = "btnQueryName";
            this.btnQueryName.Size = new System.Drawing.Size(107, 27);
            this.btnQueryName.TabIndex = 187;
            this.btnQueryName.Text = "物品名搜索";
            this.btnQueryName.UseVisualStyleBackColor = false;
            this.btnQueryName.Click += new System.EventHandler(this.btnQueryName_Click);
            // 
            // txtQueryStr
            // 
            this.txtQueryStr.BackColor = System.Drawing.SystemColors.Info;
            this.txtQueryStr.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueryStr.Location = new System.Drawing.Point(558, 32);
            this.txtQueryStr.Name = "txtQueryStr";
            this.txtQueryStr.Size = new System.Drawing.Size(104, 21);
            this.txtQueryStr.TabIndex = 186;
            this.txtQueryStr.TextChanged += new System.EventHandler(this.txtQueryStr_TextChanged);
            // 
            // cmbSex
            // 
            this.cmbSex.AutoCompleteCustomSource.AddRange(new string[] {
            "男",
            "女"});
            this.cmbSex.BackColor = System.Drawing.Color.White;
            this.cmbSex.DisplayMember = "1";
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSex.ForeColor = System.Drawing.Color.Navy;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "0转",
            "1转",
            "2转",
            "3转",
            "4转",
            "5转"});
            this.cmbSex.Location = new System.Drawing.Point(73, 444);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(145, 20);
            this.cmbSex.TabIndex = 185;
            // 
            // cmbZZ
            // 
            this.cmbZZ.BackColor = System.Drawing.Color.White;
            this.cmbZZ.DisplayMember = "1";
            this.cmbZZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZZ.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbZZ.ForeColor = System.Drawing.Color.Navy;
            this.cmbZZ.FormattingEnabled = true;
            this.cmbZZ.Items.AddRange(new object[] {
            "0转",
            "1转",
            "2转",
            "3转",
            "4转",
            "5转"});
            this.cmbZZ.Location = new System.Drawing.Point(73, 388);
            this.cmbZZ.Name = "cmbZZ";
            this.cmbZZ.Size = new System.Drawing.Size(145, 20);
            this.cmbZZ.TabIndex = 184;
            // 
            // cmbZX
            // 
            this.cmbZX.BackColor = System.Drawing.Color.White;
            this.cmbZX.DisplayMember = "1";
            this.cmbZX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZX.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbZX.ForeColor = System.Drawing.Color.Navy;
            this.cmbZX.FormattingEnabled = true;
            this.cmbZX.Items.AddRange(new object[] {
            "无",
            "正派",
            "邪派"});
            this.cmbZX.Location = new System.Drawing.Point(73, 333);
            this.cmbZX.Name = "cmbZX";
            this.cmbZX.Size = new System.Drawing.Size(145, 20);
            this.cmbZX.TabIndex = 183;
            // 
            // cmbJob
            // 
            this.cmbJob.BackColor = System.Drawing.Color.White;
            this.cmbJob.DisplayMember = "1";
            this.cmbJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJob.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbJob.ForeColor = System.Drawing.Color.Navy;
            this.cmbJob.FormattingEnabled = true;
            this.cmbJob.Items.AddRange(new object[] {
            "无",
            "刀客",
            "剑客",
            "枪客",
            "弓手",
            "医生"});
            this.cmbJob.Location = new System.Drawing.Point(73, 307);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.Size = new System.Drawing.Size(145, 20);
            this.cmbJob.TabIndex = 182;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tishi});
            this.statusStrip1.Location = new System.Drawing.Point(3, 777);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1207, 22);
            this.statusStrip1.TabIndex = 181;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tishi
            // 
            this.tishi.ForeColor = System.Drawing.Color.Red;
            this.tishi.Name = "tishi";
            this.tishi.Size = new System.Drawing.Size(0, 17);
            // 
            // txtY
            // 
            this.txtY.BackColor = System.Drawing.SystemColors.Info;
            this.txtY.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtY.Location = new System.Drawing.Point(833, 379);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(45, 21);
            this.txtY.TabIndex = 180;
            // 
            // txtX
            // 
            this.txtX.BackColor = System.Drawing.SystemColors.Info;
            this.txtX.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtX.Location = new System.Drawing.Point(781, 379);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(45, 21);
            this.txtX.TabIndex = 179;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label23.Location = new System.Drawing.Point(740, 385);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 12);
            this.label23.TabIndex = 178;
            this.label23.Text = "坐标:";
            // 
            // txtMonserId
            // 
            this.txtMonserId.BackColor = System.Drawing.SystemColors.Info;
            this.txtMonserId.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMonserId.Location = new System.Drawing.Point(606, 382);
            this.txtMonserId.Name = "txtMonserId";
            this.txtMonserId.Size = new System.Drawing.Size(105, 21);
            this.txtMonserId.TabIndex = 177;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(554, 388);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 12);
            this.label22.TabIndex = 176;
            this.label22.Text = "怪物ID:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label21.Location = new System.Drawing.Point(565, 430);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 12);
            this.label21.TabIndex = 175;
            this.label21.Text = "地图:";
            // 
            // cmbMap
            // 
            this.cmbMap.BackColor = System.Drawing.SystemColors.Info;
            this.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMap.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMap.ForeColor = System.Drawing.Color.Purple;
            this.cmbMap.FormattingEnabled = true;
            this.cmbMap.ItemHeight = 16;
            this.cmbMap.Location = new System.Drawing.Point(606, 423);
            this.cmbMap.MaxDropDownItems = 40;
            this.cmbMap.Name = "cmbMap";
            this.cmbMap.Size = new System.Drawing.Size(202, 24);
            this.cmbMap.TabIndex = 174;
            // 
            // btnAddNpc
            // 
            this.btnAddNpc.BackColor = System.Drawing.Color.Lime;
            this.btnAddNpc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNpc.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddNpc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNpc.Location = new System.Drawing.Point(827, 415);
            this.btnAddNpc.Name = "btnAddNpc";
            this.btnAddNpc.Size = new System.Drawing.Size(64, 36);
            this.btnAddNpc.TabIndex = 173;
            this.btnAddNpc.Text = "刷怪";
            this.btnAddNpc.UseVisualStyleBackColor = false;
            this.btnAddNpc.Click += new System.EventHandler(this.btnAddNpc_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.btnReduceTime);
            this.groupBox2.Controls.Add(this.btnAddTime);
            this.groupBox2.Controls.Add(this.btnReduceInteg);
            this.groupBox2.Controls.Add(this.btnAddInteg);
            this.groupBox2.Controls.Add(this.btnReduceHB);
            this.groupBox2.Controls.Add(this.btnReduceMZ);
            this.groupBox2.Controls.Add(this.btnReduceMP);
            this.groupBox2.Controls.Add(this.btnReduceHP);
            this.groupBox2.Controls.Add(this.btnReduceWF);
            this.groupBox2.Controls.Add(this.btnReduceDF);
            this.groupBox2.Controls.Add(this.btnReduceAT);
            this.groupBox2.Controls.Add(this.btnReducePoint);
            this.groupBox2.Controls.Add(this.btnReduceWX);
            this.groupBox2.Controls.Add(this.btnReduceLL);
            this.groupBox2.Controls.Add(this.btnReduceExp);
            this.groupBox2.Controls.Add(this.btnReduceMoney);
            this.groupBox2.Controls.Add(this.btnAddHB);
            this.groupBox2.Controls.Add(this.btnAddMZ);
            this.groupBox2.Controls.Add(this.btnAddMP);
            this.groupBox2.Controls.Add(this.btnAddHP);
            this.groupBox2.Controls.Add(this.btnAddWF);
            this.groupBox2.Controls.Add(this.btnAddDF);
            this.groupBox2.Controls.Add(this.btnAddAT);
            this.groupBox2.Controls.Add(this.btnAddWX);
            this.groupBox2.Controls.Add(this.btnAddExp);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnAddLL);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.btnAddMoney);
            this.groupBox2.Controls.Add(this.btnAddPoint);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox2.Location = new System.Drawing.Point(579, 458);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 298);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "属性修改";
            // 
            // btnReduceTime
            // 
            this.btnReduceTime.BackColor = System.Drawing.SystemColors.Window;
            this.btnReduceTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceTime.ForeColor = System.Drawing.Color.Magenta;
            this.btnReduceTime.Location = new System.Drawing.Point(235, 262);
            this.btnReduceTime.Name = "btnReduceTime";
            this.btnReduceTime.Size = new System.Drawing.Size(64, 29);
            this.btnReduceTime.TabIndex = 157;
            this.btnReduceTime.Text = "减少时间";
            this.btnReduceTime.UseVisualStyleBackColor = false;
            this.btnReduceTime.Click += new System.EventHandler(this.btnReduceTime_Click);
            // 
            // btnAddTime
            // 
            this.btnAddTime.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTime.ForeColor = System.Drawing.Color.Magenta;
            this.btnAddTime.Location = new System.Drawing.Point(163, 262);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(66, 29);
            this.btnAddTime.TabIndex = 156;
            this.btnAddTime.Text = "增加时间";
            this.btnAddTime.UseVisualStyleBackColor = false;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // btnReduceInteg
            // 
            this.btnReduceInteg.BackColor = System.Drawing.Color.YellowGreen;
            this.btnReduceInteg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceInteg.ForeColor = System.Drawing.Color.Black;
            this.btnReduceInteg.Location = new System.Drawing.Point(233, 56);
            this.btnReduceInteg.Name = "btnReduceInteg";
            this.btnReduceInteg.Size = new System.Drawing.Size(66, 31);
            this.btnReduceInteg.TabIndex = 155;
            this.btnReduceInteg.Text = "减少积分";
            this.btnReduceInteg.UseVisualStyleBackColor = false;
            this.btnReduceInteg.Click += new System.EventHandler(this.btnReduceInteg_Click);
            // 
            // btnAddInteg
            // 
            this.btnAddInteg.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAddInteg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInteg.ForeColor = System.Drawing.Color.Black;
            this.btnAddInteg.Location = new System.Drawing.Point(163, 56);
            this.btnAddInteg.Name = "btnAddInteg";
            this.btnAddInteg.Size = new System.Drawing.Size(66, 31);
            this.btnAddInteg.TabIndex = 154;
            this.btnAddInteg.Text = "增加积分";
            this.btnAddInteg.UseVisualStyleBackColor = false;
            this.btnAddInteg.Click += new System.EventHandler(this.btnAddInteg_Click);
            // 
            // btnReduceHB
            // 
            this.btnReduceHB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnReduceHB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceHB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnReduceHB.Location = new System.Drawing.Point(235, 161);
            this.btnReduceHB.Name = "btnReduceHB";
            this.btnReduceHB.Size = new System.Drawing.Size(64, 29);
            this.btnReduceHB.TabIndex = 153;
            this.btnReduceHB.Text = "减少回避";
            this.btnReduceHB.UseVisualStyleBackColor = false;
            this.btnReduceHB.Click += new System.EventHandler(this.btnReduceHB_Click);
            // 
            // btnReduceMZ
            // 
            this.btnReduceMZ.BackColor = System.Drawing.SystemColors.Window;
            this.btnReduceMZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceMZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnReduceMZ.Location = new System.Drawing.Point(235, 195);
            this.btnReduceMZ.Name = "btnReduceMZ";
            this.btnReduceMZ.Size = new System.Drawing.Size(64, 29);
            this.btnReduceMZ.TabIndex = 152;
            this.btnReduceMZ.Text = "减少命中";
            this.btnReduceMZ.UseVisualStyleBackColor = false;
            this.btnReduceMZ.Click += new System.EventHandler(this.btnReduceMZ_Click);
            // 
            // btnReduceMP
            // 
            this.btnReduceMP.BackColor = System.Drawing.SystemColors.Window;
            this.btnReduceMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceMP.Location = new System.Drawing.Point(235, 230);
            this.btnReduceMP.Name = "btnReduceMP";
            this.btnReduceMP.Size = new System.Drawing.Size(64, 28);
            this.btnReduceMP.TabIndex = 151;
            this.btnReduceMP.Text = "减少内功";
            this.btnReduceMP.UseVisualStyleBackColor = false;
            this.btnReduceMP.Click += new System.EventHandler(this.btnReduceMP_Click);
            // 
            // btnReduceHP
            // 
            this.btnReduceHP.BackColor = System.Drawing.SystemColors.Window;
            this.btnReduceHP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceHP.ForeColor = System.Drawing.Color.Red;
            this.btnReduceHP.Location = new System.Drawing.Point(86, 195);
            this.btnReduceHP.Name = "btnReduceHP";
            this.btnReduceHP.Size = new System.Drawing.Size(71, 29);
            this.btnReduceHP.TabIndex = 150;
            this.btnReduceHP.Text = "减少生命";
            this.btnReduceHP.UseVisualStyleBackColor = false;
            this.btnReduceHP.Click += new System.EventHandler(this.btnReduceHP_Click);
            // 
            // btnReduceWF
            // 
            this.btnReduceWF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReduceWF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceWF.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnReduceWF.Location = new System.Drawing.Point(86, 161);
            this.btnReduceWF.Name = "btnReduceWF";
            this.btnReduceWF.Size = new System.Drawing.Size(71, 29);
            this.btnReduceWF.TabIndex = 149;
            this.btnReduceWF.Text = "减少武防";
            this.btnReduceWF.UseVisualStyleBackColor = false;
            this.btnReduceWF.Click += new System.EventHandler(this.btnReduceWF_Click);
            // 
            // btnReduceDF
            // 
            this.btnReduceDF.BackColor = System.Drawing.Color.Silver;
            this.btnReduceDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceDF.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnReduceDF.Location = new System.Drawing.Point(86, 128);
            this.btnReduceDF.Name = "btnReduceDF";
            this.btnReduceDF.Size = new System.Drawing.Size(71, 29);
            this.btnReduceDF.TabIndex = 148;
            this.btnReduceDF.Text = "减少防御";
            this.btnReduceDF.UseVisualStyleBackColor = false;
            this.btnReduceDF.Click += new System.EventHandler(this.btnReduceDF_Click);
            // 
            // btnReduceAT
            // 
            this.btnReduceAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReduceAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReduceAT.Location = new System.Drawing.Point(235, 128);
            this.btnReduceAT.Name = "btnReduceAT";
            this.btnReduceAT.Size = new System.Drawing.Size(64, 28);
            this.btnReduceAT.TabIndex = 147;
            this.btnReduceAT.Text = "减少攻击";
            this.btnReduceAT.UseVisualStyleBackColor = false;
            this.btnReduceAT.Click += new System.EventHandler(this.btnReduceAT_Click);
            // 
            // btnReducePoint
            // 
            this.btnReducePoint.BackColor = System.Drawing.Color.SpringGreen;
            this.btnReducePoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReducePoint.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnReducePoint.Location = new System.Drawing.Point(86, 56);
            this.btnReducePoint.Name = "btnReducePoint";
            this.btnReducePoint.Size = new System.Drawing.Size(71, 31);
            this.btnReducePoint.TabIndex = 146;
            this.btnReducePoint.Text = "减少元宝";
            this.btnReducePoint.UseVisualStyleBackColor = false;
            this.btnReducePoint.Click += new System.EventHandler(this.btnReducePoint_Click);
            // 
            // btnReduceWX
            // 
            this.btnReduceWX.BackColor = System.Drawing.Color.Blue;
            this.btnReduceWX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceWX.ForeColor = System.Drawing.Color.Crimson;
            this.btnReduceWX.Location = new System.Drawing.Point(233, 93);
            this.btnReduceWX.Name = "btnReduceWX";
            this.btnReduceWX.Size = new System.Drawing.Size(66, 30);
            this.btnReduceWX.TabIndex = 145;
            this.btnReduceWX.Text = "减少武勋";
            this.btnReduceWX.UseVisualStyleBackColor = false;
            this.btnReduceWX.Click += new System.EventHandler(this.btnReduceWX_Click);
            // 
            // btnReduceLL
            // 
            this.btnReduceLL.BackColor = System.Drawing.SystemColors.Window;
            this.btnReduceLL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceLL.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnReduceLL.Location = new System.Drawing.Point(86, 229);
            this.btnReduceLL.Name = "btnReduceLL";
            this.btnReduceLL.Size = new System.Drawing.Size(71, 28);
            this.btnReduceLL.TabIndex = 144;
            this.btnReduceLL.Text = "减少历练";
            this.btnReduceLL.UseVisualStyleBackColor = false;
            this.btnReduceLL.Click += new System.EventHandler(this.btnReduceLL_Click);
            // 
            // btnReduceExp
            // 
            this.btnReduceExp.BackColor = System.Drawing.SystemColors.Window;
            this.btnReduceExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceExp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnReduceExp.Location = new System.Drawing.Point(88, 262);
            this.btnReduceExp.Name = "btnReduceExp";
            this.btnReduceExp.Size = new System.Drawing.Size(69, 29);
            this.btnReduceExp.TabIndex = 143;
            this.btnReduceExp.Text = "减少经验";
            this.btnReduceExp.UseVisualStyleBackColor = false;
            this.btnReduceExp.Click += new System.EventHandler(this.btnReduceExp_Click);
            // 
            // btnReduceMoney
            // 
            this.btnReduceMoney.BackColor = System.Drawing.Color.Navy;
            this.btnReduceMoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReduceMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReduceMoney.Location = new System.Drawing.Point(86, 93);
            this.btnReduceMoney.Name = "btnReduceMoney";
            this.btnReduceMoney.Size = new System.Drawing.Size(71, 29);
            this.btnReduceMoney.TabIndex = 142;
            this.btnReduceMoney.Text = "减少金币";
            this.btnReduceMoney.UseVisualStyleBackColor = false;
            this.btnReduceMoney.Click += new System.EventHandler(this.btnReduceMoney_Click);
            // 
            // btnAddHB
            // 
            this.btnAddHB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddHB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddHB.Location = new System.Drawing.Point(163, 161);
            this.btnAddHB.Name = "btnAddHB";
            this.btnAddHB.Size = new System.Drawing.Size(66, 29);
            this.btnAddHB.TabIndex = 141;
            this.btnAddHB.Text = "增加回避";
            this.btnAddHB.UseVisualStyleBackColor = false;
            this.btnAddHB.Click += new System.EventHandler(this.btnAddHB_Click);
            // 
            // btnAddMZ
            // 
            this.btnAddMZ.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddMZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddMZ.Location = new System.Drawing.Point(163, 195);
            this.btnAddMZ.Name = "btnAddMZ";
            this.btnAddMZ.Size = new System.Drawing.Size(66, 29);
            this.btnAddMZ.TabIndex = 140;
            this.btnAddMZ.Text = "增加命中";
            this.btnAddMZ.UseVisualStyleBackColor = false;
            this.btnAddMZ.Click += new System.EventHandler(this.btnAddMZ_Click);
            // 
            // btnAddMP
            // 
            this.btnAddMP.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMP.Location = new System.Drawing.Point(163, 230);
            this.btnAddMP.Name = "btnAddMP";
            this.btnAddMP.Size = new System.Drawing.Size(66, 27);
            this.btnAddMP.TabIndex = 139;
            this.btnAddMP.Text = "增加内功";
            this.btnAddMP.UseVisualStyleBackColor = false;
            this.btnAddMP.Click += new System.EventHandler(this.btnAddMP_Click);
            // 
            // btnAddHP
            // 
            this.btnAddHP.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddHP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHP.ForeColor = System.Drawing.Color.Red;
            this.btnAddHP.Location = new System.Drawing.Point(8, 195);
            this.btnAddHP.Name = "btnAddHP";
            this.btnAddHP.Size = new System.Drawing.Size(72, 29);
            this.btnAddHP.TabIndex = 138;
            this.btnAddHP.Text = "增加生命";
            this.btnAddHP.UseVisualStyleBackColor = false;
            this.btnAddHP.Click += new System.EventHandler(this.btnAddHP_Click);
            // 
            // btnAddWF
            // 
            this.btnAddWF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddWF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWF.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAddWF.Location = new System.Drawing.Point(8, 161);
            this.btnAddWF.Name = "btnAddWF";
            this.btnAddWF.Size = new System.Drawing.Size(72, 29);
            this.btnAddWF.TabIndex = 137;
            this.btnAddWF.Text = "增加武防";
            this.btnAddWF.UseVisualStyleBackColor = false;
            this.btnAddWF.Click += new System.EventHandler(this.btnAddWF_Click);
            // 
            // btnAddDF
            // 
            this.btnAddDF.BackColor = System.Drawing.Color.Silver;
            this.btnAddDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDF.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnAddDF.Location = new System.Drawing.Point(8, 128);
            this.btnAddDF.Name = "btnAddDF";
            this.btnAddDF.Size = new System.Drawing.Size(72, 29);
            this.btnAddDF.TabIndex = 136;
            this.btnAddDF.Text = "增加防御";
            this.btnAddDF.UseVisualStyleBackColor = false;
            this.btnAddDF.Click += new System.EventHandler(this.btnAddDF_Click);
            // 
            // btnAddAT
            // 
            this.btnAddAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAddAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddAT.Location = new System.Drawing.Point(163, 128);
            this.btnAddAT.Name = "btnAddAT";
            this.btnAddAT.Size = new System.Drawing.Size(66, 28);
            this.btnAddAT.TabIndex = 135;
            this.btnAddAT.Text = "增加攻击";
            this.btnAddAT.UseVisualStyleBackColor = false;
            this.btnAddAT.Click += new System.EventHandler(this.btnAddAT_Click);
            // 
            // btnAddWX
            // 
            this.btnAddWX.BackColor = System.Drawing.Color.MediumBlue;
            this.btnAddWX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWX.ForeColor = System.Drawing.Color.Crimson;
            this.btnAddWX.Location = new System.Drawing.Point(161, 94);
            this.btnAddWX.Name = "btnAddWX";
            this.btnAddWX.Size = new System.Drawing.Size(66, 29);
            this.btnAddWX.TabIndex = 134;
            this.btnAddWX.Text = "增加武勋";
            this.btnAddWX.UseVisualStyleBackColor = false;
            this.btnAddWX.Click += new System.EventHandler(this.btnAddWX_Click);
            // 
            // btnAddExp
            // 
            this.btnAddExp.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnAddExp.Location = new System.Drawing.Point(8, 262);
            this.btnAddExp.Name = "btnAddExp";
            this.btnAddExp.Size = new System.Drawing.Size(72, 29);
            this.btnAddExp.TabIndex = 132;
            this.btnAddExp.Text = "增加经验";
            this.btnAddExp.UseVisualStyleBackColor = false;
            this.btnAddExp.Click += new System.EventHandler(this.btnAddExp_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 14);
            this.label9.TabIndex = 130;
            this.label9.Text = "增减数量:";
            // 
            // btnAddLL
            // 
            this.btnAddLL.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddLL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLL.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddLL.Location = new System.Drawing.Point(8, 229);
            this.btnAddLL.Name = "btnAddLL";
            this.btnAddLL.Size = new System.Drawing.Size(72, 28);
            this.btnAddLL.TabIndex = 133;
            this.btnAddLL.Text = "增加历练";
            this.btnAddLL.UseVisualStyleBackColor = false;
            this.btnAddLL.Click += new System.EventHandler(this.btnAddLL_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            this.textBox2.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(86, 15);
            this.textBox2.MaxLength = 68888;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(213, 29);
            this.textBox2.TabIndex = 127;
            // 
            // btnAddMoney
            // 
            this.btnAddMoney.BackColor = System.Drawing.Color.Navy;
            this.btnAddMoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddMoney.Location = new System.Drawing.Point(8, 93);
            this.btnAddMoney.Name = "btnAddMoney";
            this.btnAddMoney.Size = new System.Drawing.Size(72, 29);
            this.btnAddMoney.TabIndex = 131;
            this.btnAddMoney.Text = "增加金币";
            this.btnAddMoney.UseVisualStyleBackColor = false;
            this.btnAddMoney.Click += new System.EventHandler(this.btnAddMoney_Click);
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.BackColor = System.Drawing.Color.SpringGreen;
            this.btnAddPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPoint.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnAddPoint.Location = new System.Drawing.Point(8, 56);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(72, 31);
            this.btnAddPoint.TabIndex = 126;
            this.btnAddPoint.Text = "增加元宝";
            this.btnAddPoint.UseVisualStyleBackColor = false;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // button41
            // 
            this.button41.BackColor = System.Drawing.Color.Cornsilk;
            this.button41.Enabled = false;
            this.button41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button41.Location = new System.Drawing.Point(224, 644);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(93, 22);
            this.button41.TabIndex = 172;
            this.button41.Text = "个人七彩";
            this.button41.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.PapayaWhip;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label14.Location = new System.Drawing.Point(11, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(315, 48);
            this.label14.TabIndex = 141;
            this.label14.Text = "提示：刷取物品/属性时玩家必须在线,\r\n\r\n    请认真仔细填写，确认后即可生效！";
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.Info;
            this.textBox13.Location = new System.Drawing.Point(73, 644);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(145, 21);
            this.textBox13.TabIndex = 171;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(8, 647);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 12);
            this.label19.TabIndex = 170;
            this.label19.Text = "个人七彩:";
            // 
            // button40
            // 
            this.button40.BackColor = System.Drawing.Color.YellowGreen;
            this.button40.Enabled = false;
            this.button40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button40.Location = new System.Drawing.Point(224, 681);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(93, 22);
            this.button40.TabIndex = 163;
            this.button40.Text = "修改PK等级";
            this.button40.UseVisualStyleBackColor = false;
            // 
            // button39
            // 
            this.button39.BackColor = System.Drawing.Color.PowderBlue;
            this.button39.Enabled = false;
            this.button39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button39.Location = new System.Drawing.Point(224, 605);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(93, 22);
            this.button39.TabIndex = 162;
            this.button39.Text = "全体七彩";
            this.button39.UseVisualStyleBackColor = false;
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button38.Location = new System.Drawing.Point(224, 559);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(93, 22);
            this.button38.TabIndex = 161;
            this.button38.Text = "增加会员";
            this.button38.UseVisualStyleBackColor = false;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.SystemColors.Info;
            this.textBox14.Location = new System.Drawing.Point(73, 681);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(145, 21);
            this.textBox14.TabIndex = 158;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(11, 682);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 14);
            this.label20.TabIndex = 157;
            this.label20.Text = "PK等级:";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Info;
            this.textBox12.Location = new System.Drawing.Point(73, 605);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(145, 21);
            this.textBox12.TabIndex = 156;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 608);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 155;
            this.label18.Text = "全体七彩:";
            // 
            // txtVip
            // 
            this.txtVip.BackColor = System.Drawing.SystemColors.Info;
            this.txtVip.Location = new System.Drawing.Point(73, 559);
            this.txtVip.Name = "txtVip";
            this.txtVip.Size = new System.Drawing.Size(145, 21);
            this.txtVip.TabIndex = 154;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 562);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 153;
            this.label17.Text = "普通会员:";
            // 
            // txtSX5
            // 
            this.txtSX5.BackColor = System.Drawing.SystemColors.Window;
            this.txtSX5.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSX5.ForeColor = System.Drawing.Color.Blue;
            this.txtSX5.Location = new System.Drawing.Point(824, 261);
            this.txtSX5.MaxLength = 7;
            this.txtSX5.Name = "txtSX5";
            this.txtSX5.Size = new System.Drawing.Size(67, 21);
            this.txtSX5.TabIndex = 152;
            this.txtSX5.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Brown;
            this.label16.Location = new System.Drawing.Point(565, 265);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 151;
            this.label16.Text = "第五属性:";
            // 
            // cmbSX5
            // 
            this.cmbSX5.BackColor = System.Drawing.Color.White;
            this.cmbSX5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSX5.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSX5.FormattingEnabled = true;
            this.cmbSX5.Items.AddRange(new object[] {
            "无",
            "觉醒"});
            this.cmbSX5.Location = new System.Drawing.Point(630, 262);
            this.cmbSX5.Name = "cmbSX5";
            this.cmbSX5.Size = new System.Drawing.Size(188, 20);
            this.cmbSX5.TabIndex = 150;
            // 
            // txtExp
            // 
            this.txtExp.BackColor = System.Drawing.SystemColors.Info;
            this.txtExp.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExp.Location = new System.Drawing.Point(73, 415);
            this.txtExp.Name = "txtExp";
            this.txtExp.Size = new System.Drawing.Size(145, 21);
            this.txtExp.TabIndex = 149;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 418);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 148;
            this.label15.Text = "经验:";
            // 
            // btnChangeExp
            // 
            this.btnChangeExp.BackColor = System.Drawing.Color.Aqua;
            this.btnChangeExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeExp.Location = new System.Drawing.Point(224, 415);
            this.btnChangeExp.Name = "btnChangeExp";
            this.btnChangeExp.Size = new System.Drawing.Size(93, 22);
            this.btnChangeExp.TabIndex = 147;
            this.btnChangeExp.Text = "修改经验";
            this.btnChangeExp.UseVisualStyleBackColor = false;
            this.btnChangeExp.Click += new System.EventHandler(this.btnChangeExp_Click);
            // 
            // btnCutZSCS
            // 
            this.btnCutZSCS.BackColor = System.Drawing.SystemColors.Window;
            this.btnCutZSCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCutZSCS.ForeColor = System.Drawing.Color.Crimson;
            this.btnCutZSCS.Location = new System.Drawing.Point(270, 512);
            this.btnCutZSCS.Name = "btnCutZSCS";
            this.btnCutZSCS.Size = new System.Drawing.Size(47, 22);
            this.btnCutZSCS.TabIndex = 146;
            this.btnCutZSCS.Text = "减少";
            this.btnCutZSCS.UseVisualStyleBackColor = false;
            this.btnCutZSCS.Click += new System.EventHandler(this.btnCutZSCS_Click);
            // 
            // btnChangeJob
            // 
            this.btnChangeJob.BackColor = System.Drawing.Color.SpringGreen;
            this.btnChangeJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeJob.Font = new System.Drawing.Font("宋体", 9F);
            this.btnChangeJob.Location = new System.Drawing.Point(224, 307);
            this.btnChangeJob.Name = "btnChangeJob";
            this.btnChangeJob.Size = new System.Drawing.Size(93, 22);
            this.btnChangeJob.TabIndex = 145;
            this.btnChangeJob.Text = "修改职业";
            this.btnChangeJob.UseVisualStyleBackColor = false;
            this.btnChangeJob.Click += new System.EventHandler(this.btnChangeJob_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(32, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 143;
            this.label6.Text = "职业:";
            // 
            // btnAddZSCS
            // 
            this.btnAddZSCS.BackColor = System.Drawing.SystemColors.Window;
            this.btnAddZSCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddZSCS.ForeColor = System.Drawing.Color.Crimson;
            this.btnAddZSCS.Location = new System.Drawing.Point(224, 512);
            this.btnAddZSCS.Name = "btnAddZSCS";
            this.btnAddZSCS.Size = new System.Drawing.Size(40, 22);
            this.btnAddZSCS.TabIndex = 140;
            this.btnAddZSCS.Text = "增加";
            this.btnAddZSCS.UseVisualStyleBackColor = false;
            this.btnAddZSCS.Click += new System.EventHandler(this.btnAddZSCS_Click);
            // 
            // btnChangeLv
            // 
            this.btnChangeLv.BackColor = System.Drawing.Color.Violet;
            this.btnChangeLv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeLv.Location = new System.Drawing.Point(224, 360);
            this.btnChangeLv.Name = "btnChangeLv";
            this.btnChangeLv.Size = new System.Drawing.Size(93, 22);
            this.btnChangeLv.TabIndex = 139;
            this.btnChangeLv.Text = "修改等级";
            this.btnChangeLv.UseVisualStyleBackColor = false;
            this.btnChangeLv.Click += new System.EventHandler(this.btnChangeLv_Click);
            // 
            // btnChangeZZ
            // 
            this.btnChangeZZ.BackColor = System.Drawing.Color.Yellow;
            this.btnChangeZZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeZZ.Location = new System.Drawing.Point(224, 388);
            this.btnChangeZZ.Name = "btnChangeZZ";
            this.btnChangeZZ.Size = new System.Drawing.Size(93, 22);
            this.btnChangeZZ.TabIndex = 138;
            this.btnChangeZZ.Text = "修改转职";
            this.btnChangeZZ.UseVisualStyleBackColor = false;
            this.btnChangeZZ.Click += new System.EventHandler(this.btnChangeZZ_Click);
            // 
            // btnChangeZx
            // 
            this.btnChangeZx.BackColor = System.Drawing.Color.Wheat;
            this.btnChangeZx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeZx.Location = new System.Drawing.Point(224, 333);
            this.btnChangeZx.Name = "btnChangeZx";
            this.btnChangeZx.Size = new System.Drawing.Size(93, 22);
            this.btnChangeZx.TabIndex = 137;
            this.btnChangeZx.Text = "修改正邪";
            this.btnChangeZx.UseVisualStyleBackColor = false;
            this.btnChangeZx.Click += new System.EventHandler(this.btnChangeZx_Click);
            // 
            // btnChangeSex
            // 
            this.btnChangeSex.BackColor = System.Drawing.Color.Coral;
            this.btnChangeSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeSex.Location = new System.Drawing.Point(224, 442);
            this.btnChangeSex.Name = "btnChangeSex";
            this.btnChangeSex.Size = new System.Drawing.Size(93, 22);
            this.btnChangeSex.TabIndex = 136;
            this.btnChangeSex.Text = "修改性别";
            this.btnChangeSex.UseVisualStyleBackColor = false;
            this.btnChangeSex.Click += new System.EventHandler(this.btnChangeSex_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.OliveDrab;
            this.label2.Location = new System.Drawing.Point(12, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "职业: 1刀/2剑/3枪/4弓/5医  1正/2邪";
            // 
            // txtZSCS
            // 
            this.txtZSCS.BackColor = System.Drawing.SystemColors.Info;
            this.txtZSCS.Location = new System.Drawing.Point(73, 512);
            this.txtZSCS.Name = "txtZSCS";
            this.txtZSCS.Size = new System.Drawing.Size(145, 21);
            this.txtZSCS.TabIndex = 135;
            // 
            // txtLv
            // 
            this.txtLv.BackColor = System.Drawing.SystemColors.Info;
            this.txtLv.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLv.Location = new System.Drawing.Point(73, 360);
            this.txtLv.Name = "txtLv";
            this.txtLv.Size = new System.Drawing.Size(145, 21);
            this.txtLv.TabIndex = 134;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 515);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 130;
            this.label13.Text = "转生次数:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 129;
            this.label12.Text = "等级:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 391);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 128;
            this.label11.Text = "转职:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 127;
            this.label10.Text = "正邪:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(32, 447);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 126;
            this.label8.Text = "性别:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(565, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 124;
            this.label5.Text = "是否绑定:";
            // 
            // cmbBD
            // 
            this.cmbBD.BackColor = System.Drawing.Color.White;
            this.cmbBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBD.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBD.FormattingEnabled = true;
            this.cmbBD.Items.AddRange(new object[] {
            "不绑",
            "绑定"});
            this.cmbBD.Location = new System.Drawing.Point(630, 288);
            this.cmbBD.Name = "cmbBD";
            this.cmbBD.Size = new System.Drawing.Size(81, 20);
            this.cmbBD.TabIndex = 123;
            // 
            // txtSX4
            // 
            this.txtSX4.BackColor = System.Drawing.SystemColors.Window;
            this.txtSX4.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSX4.ForeColor = System.Drawing.Color.Blue;
            this.txtSX4.Location = new System.Drawing.Point(824, 235);
            this.txtSX4.MaxLength = 7;
            this.txtSX4.Name = "txtSX4";
            this.txtSX4.Size = new System.Drawing.Size(67, 21);
            this.txtSX4.TabIndex = 122;
            this.txtSX4.Text = "0";
            // 
            // txtSX3
            // 
            this.txtSX3.BackColor = System.Drawing.SystemColors.Window;
            this.txtSX3.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSX3.ForeColor = System.Drawing.Color.Blue;
            this.txtSX3.Location = new System.Drawing.Point(824, 211);
            this.txtSX3.MaxLength = 7;
            this.txtSX3.Name = "txtSX3";
            this.txtSX3.Size = new System.Drawing.Size(67, 21);
            this.txtSX3.TabIndex = 121;
            this.txtSX3.Text = "0";
            // 
            // txtSX2
            // 
            this.txtSX2.BackColor = System.Drawing.SystemColors.Window;
            this.txtSX2.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSX2.ForeColor = System.Drawing.Color.Blue;
            this.txtSX2.Location = new System.Drawing.Point(824, 185);
            this.txtSX2.MaxLength = 7;
            this.txtSX2.Name = "txtSX2";
            this.txtSX2.Size = new System.Drawing.Size(67, 21);
            this.txtSX2.TabIndex = 120;
            this.txtSX2.Text = "0";
            // 
            // txtSX1
            // 
            this.txtSX1.BackColor = System.Drawing.SystemColors.Window;
            this.txtSX1.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSX1.ForeColor = System.Drawing.Color.Blue;
            this.txtSX1.Location = new System.Drawing.Point(824, 159);
            this.txtSX1.MaxLength = 7;
            this.txtSX1.Name = "txtSX1";
            this.txtSX1.Size = new System.Drawing.Size(67, 21);
            this.txtSX1.TabIndex = 119;
            this.txtSX1.Text = "0";
            // 
            // txtSX
            // 
            this.txtSX.BackColor = System.Drawing.SystemColors.Window;
            this.txtSX.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSX.ForeColor = System.Drawing.Color.Blue;
            this.txtSX.Location = new System.Drawing.Point(824, 133);
            this.txtSX.MaxLength = 7;
            this.txtSX.Name = "txtSX";
            this.txtSX.Size = new System.Drawing.Size(67, 21);
            this.txtSX.TabIndex = 118;
            this.txtSX.Text = "0";
            // 
            // txtIntensify
            // 
            this.txtIntensify.BackColor = System.Drawing.SystemColors.Window;
            this.txtIntensify.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIntensify.ForeColor = System.Drawing.Color.Blue;
            this.txtIntensify.Location = new System.Drawing.Point(824, 107);
            this.txtIntensify.MaxLength = 7;
            this.txtIntensify.Name = "txtIntensify";
            this.txtIntensify.Size = new System.Drawing.Size(67, 21);
            this.txtIntensify.TabIndex = 117;
            this.txtIntensify.Text = "0";
            // 
            // cmbSX4
            // 
            this.cmbSX4.BackColor = System.Drawing.Color.White;
            this.cmbSX4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSX4.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSX4.FormattingEnabled = true;
            this.cmbSX4.Items.AddRange(new object[] {
            "无",
            "攻击增加",
            "防御增加",
            "生命增加",
            "内功增加",
            "命中率增加",
            "回避率增加",
            "武功攻击力%增加",
            "全部气功等级增加",
            "升级成功率%增加",
            "追加伤害值",
            "武功防御力增加",
            "获得金钱%增加",
            "死亡损失经验减少%",
            "经验值增加%",
            "精炼追加生命",
            "精炼蓝红",
            "药品数量"});
            this.cmbSX4.Location = new System.Drawing.Point(630, 236);
            this.cmbSX4.MaxDropDownItems = 18;
            this.cmbSX4.Name = "cmbSX4";
            this.cmbSX4.Size = new System.Drawing.Size(188, 20);
            this.cmbSX4.TabIndex = 116;
            // 
            // cmbSX3
            // 
            this.cmbSX3.BackColor = System.Drawing.Color.White;
            this.cmbSX3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSX3.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSX3.FormattingEnabled = true;
            this.cmbSX3.Items.AddRange(new object[] {
            "无",
            "攻击增加",
            "防御增加",
            "生命增加",
            "内功增加",
            "命中率增加",
            "回避率增加",
            "武功攻击力%增加",
            "全部气功等级增加",
            "升级成功率%增加",
            "追加伤害值",
            "武功防御力增加",
            "获得金钱%增加",
            "死亡损失经验减少%",
            "经验值增加%",
            "精炼追加生命",
            "精炼蓝红",
            "药品数量"});
            this.cmbSX3.Location = new System.Drawing.Point(630, 211);
            this.cmbSX3.MaxDropDownItems = 18;
            this.cmbSX3.Name = "cmbSX3";
            this.cmbSX3.Size = new System.Drawing.Size(188, 20);
            this.cmbSX3.TabIndex = 115;
            // 
            // cmbSX2
            // 
            this.cmbSX2.BackColor = System.Drawing.Color.White;
            this.cmbSX2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSX2.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSX2.FormattingEnabled = true;
            this.cmbSX2.Items.AddRange(new object[] {
            "无",
            "攻击增加",
            "防御增加",
            "生命增加",
            "内功增加",
            "命中率增加",
            "回避率增加",
            "武功攻击力%增加",
            "全部气功等级增加",
            "升级成功率%增加",
            "追加伤害值",
            "武功防御力增加",
            "获得金钱%增加",
            "死亡损失经验减少%",
            "经验值增加%",
            "精炼追加生命",
            "精炼蓝红",
            "药品数量"});
            this.cmbSX2.Location = new System.Drawing.Point(630, 185);
            this.cmbSX2.MaxDropDownItems = 18;
            this.cmbSX2.Name = "cmbSX2";
            this.cmbSX2.Size = new System.Drawing.Size(188, 20);
            this.cmbSX2.TabIndex = 114;
            // 
            // cmbSX1
            // 
            this.cmbSX1.BackColor = System.Drawing.Color.White;
            this.cmbSX1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSX1.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSX1.FormattingEnabled = true;
            this.cmbSX1.Items.AddRange(new object[] {
            "无",
            "攻击增加",
            "防御增加",
            "生命增加",
            "内功增加",
            "命中率增加",
            "回避率增加",
            "武功攻击力%增加",
            "全部气功等级增加",
            "升级成功率%增加",
            "追加伤害值",
            "武功防御力增加",
            "获得金钱%增加",
            "死亡损失经验减少%",
            "经验值增加%",
            "精炼追加生命",
            "精炼蓝红",
            "药品数量"});
            this.cmbSX1.Location = new System.Drawing.Point(630, 159);
            this.cmbSX1.MaxDropDownItems = 18;
            this.cmbSX1.Name = "cmbSX1";
            this.cmbSX1.Size = new System.Drawing.Size(188, 20);
            this.cmbSX1.TabIndex = 113;
            // 
            // cmbSX
            // 
            this.cmbSX.BackColor = System.Drawing.Color.White;
            this.cmbSX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSX.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSX.FormattingEnabled = true;
            this.cmbSX.Items.AddRange(new object[] {
            "无",
            "火",
            "水",
            "风",
            "内",
            "外",
            "毒"});
            this.cmbSX.Location = new System.Drawing.Point(630, 133);
            this.cmbSX.Name = "cmbSX";
            this.cmbSX.Size = new System.Drawing.Size(188, 20);
            this.cmbSX.TabIndex = 112;
            // 
            // cmbIntensify
            // 
            this.cmbIntensify.BackColor = System.Drawing.Color.White;
            this.cmbIntensify.DisplayMember = "1";
            this.cmbIntensify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIntensify.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbIntensify.ForeColor = System.Drawing.Color.Navy;
            this.cmbIntensify.FormattingEnabled = true;
            this.cmbIntensify.Items.AddRange(new object[] {
            "无",
            "武器强化",
            "防具强化",
            "药品个数"});
            this.cmbIntensify.Location = new System.Drawing.Point(630, 107);
            this.cmbIntensify.Name = "cmbIntensify";
            this.cmbIntensify.Size = new System.Drawing.Size(188, 20);
            this.cmbIntensify.TabIndex = 111;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label46.Location = new System.Drawing.Point(565, 239);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 12);
            this.label46.TabIndex = 110;
            this.label46.Text = "第四属性:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.Color.DarkCyan;
            this.label45.Location = new System.Drawing.Point(565, 214);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(59, 12);
            this.label45.TabIndex = 109;
            this.label45.Text = "第三属性:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label44.Location = new System.Drawing.Point(565, 188);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(59, 12);
            this.label44.TabIndex = 108;
            this.label44.Text = "第二属性:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.Olive;
            this.label43.Location = new System.Drawing.Point(565, 162);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(59, 12);
            this.label43.TabIndex = 107;
            this.label43.Text = "第一属性:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label42.Location = new System.Drawing.Point(565, 136);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(59, 12);
            this.label42.TabIndex = 106;
            this.label42.Text = "附生属性:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.Red;
            this.label41.Location = new System.Drawing.Point(565, 110);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(59, 12);
            this.label41.TabIndex = 105;
            this.label41.Text = "属性类型:";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.Lime;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddItem.Location = new System.Drawing.Point(630, 321);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(212, 36);
            this.btnAddItem.TabIndex = 71;
            this.btnAddItem.Text = "确认添加物品";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserName.Font = new System.Drawing.Font("新宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserName.Location = new System.Drawing.Point(14, 112);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(303, 41);
            this.txtUserName.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(9, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 29);
            this.label4.TabIndex = 69;
            this.label4.Text = "玩家姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(191, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 14);
            this.label3.TabIndex = 68;
            this.label3.Text = "可直接选择物品ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(208, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "选择物品分类:";
            // 
            // cmbItem
            // 
            this.cmbItem.BackColor = System.Drawing.SystemColors.Info;
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbItem.ForeColor = System.Drawing.Color.Purple;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.ItemHeight = 16;
            this.cmbItem.Location = new System.Drawing.Point(333, 51);
            this.cmbItem.MaxDropDownItems = 40;
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(215, 24);
            this.cmbItem.TabIndex = 65;
            // 
            // cmbItemType
            // 
            this.cmbItemType.BackColor = System.Drawing.SystemColors.Info;
            this.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemType.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbItemType.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.Items.AddRange(new object[] {
            "武器",
            "衣服",
            "护手",
            "鞋子",
            "内甲",
            "耳环",
            "项链",
            "戒指",
            "男/女披风",
            "门派战甲",
            "灵兽召唤符",
            "召唤书/弓箭",
            "石头类",
            "幸运符",
            "盒子/箱子",
            "其他",
            "未知"});
            this.cmbItemType.Location = new System.Drawing.Point(333, 26);
            this.cmbItemType.MaxDropDownItems = 20;
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(215, 24);
            this.cmbItemType.TabIndex = 64;
            this.cmbItemType.SelectedIndexChanged += new System.EventHandler(this.cmbItemType_SelectedIndexChanged);
            // 
            // lsItems
            // 
            this.lsItems.BackColor = System.Drawing.SystemColors.Info;
            this.lsItems.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsItems.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lsItems.FormattingEnabled = true;
            this.lsItems.ItemHeight = 16;
            this.lsItems.Location = new System.Drawing.Point(333, 76);
            this.lsItems.Name = "lsItems";
            this.lsItems.Size = new System.Drawing.Size(215, 692);
            this.lsItems.TabIndex = 63;
            this.lsItems.SelectedIndexChanged += new System.EventHandler(this.lsItems_SelectedIndexChanged);
            // 
            // frmGM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 802);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGM";
            this.Text = "frmGM-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.frmGM_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		private void txtQueryStr_TextChanged(object sender, EventArgs e)
		{
		}
	}
}
