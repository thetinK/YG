using RxjhServer.DbClss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RxjhServer
{
	public class GMGJ : Form
	{
		private string _username;

		private string _Player_Level;

		private string _Player_Job;

		private string _Player_Zx;

		private string _Player_Job_leve;

		private ComboBox cmbItem;

		private ComboBox cmbItemType;

		private ListBox lsItems;

		private string _转生次数;

		private string _Player_Sex;

		private string _人物经验;

		private IContainer components;

		private GroupBox groupBox1;

		private Button button1;

		private TextBox username_textBox;

		private Label label4;

		private Label label3;

		private Label label2;

		private Label label1;

		private ComboBox comboBox12;

		private ComboBox comboBox11;

		private ListBox listBox3;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripStatusLabel tishi;

		private Label label5;

		private ComboBox comboBox19;

		private TextBox textBox68;

		private TextBox textBox67;

		private TextBox textBox66;

		private TextBox textBox65;

		private TextBox textBox64;

		private TextBox textBox63;

		private ComboBox comboBox18;

		private ComboBox comboBox17;

		private ComboBox comboBox16;

		private ComboBox comboBox15;

		private ComboBox comboBox14;

		private ComboBox comboBox13;

		private Label label46;

		private Label label45;

		private Label label44;

		private Label label43;

		private Label label42;

		private Label label41;

		private Label label7;

		private GroupBox groupBox2;

		private Button button2;

		private Label label9;

		private TextBox textBox2;

		private Button button5;

		private Button button4;

		private Button button3;

		private Button button6;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private Label label8;

		private Button button11;

		private Button button10;

		private Button button9;

		private Button button8;

		private Button button7;

		private TextBox textBox7;

		private TextBox textBox6;

		private TextBox textBox5;

		private TextBox textBox4;

		private Button button13;

		private Button button12;

		private Label label14;

		private Button button18;

		private Button button17;

		private Button button16;

		private Button button15;

		private Button button14;

		private TextBox textBox3;

		private Button button19;

		private TextBox textBox8;

		private Label label6;

		private Button button20;

		private Button button32;

		private Button button31;

		private Button button30;

		private Button button29;

		private Button button28;

		private Button button27;

		private Button button26;

		private Button button25;

		private Button button24;

		private Button button23;

		private Button button22;

		private Button button21;

		private Button button34;

		private Button button33;

		private Button button35;

		private TextBox textBox9;

		private Label label15;

		private TextBox textBox10;

		private Label label16;

		private ComboBox comboBox1;

		private Button button37;

		private Button button36;

		private Button button39;

		private Button button38;

		private TextBox textBox12;

		private Label label18;

		private TextBox textBox11;

		private Label label17;

		private TextBox textBox13;

		private Label label19;

		private ComboBox comboBox3;

		private Label label22;

		private Button button41;

		private TextBox textBox14;

		private TextBox txtQueryStr;

		private Button btnQueryName;

		private Label label21;

		public string username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
			}
		}

		public string PlayerLevel
		{
			get
			{
				return _Player_Level;
			}
			set
			{
				_Player_Level = value;
			}
		}

		public string PlayerJob
		{
			get
			{
				return _Player_Job;
			}
			set
			{
				_Player_Job = value;
			}
		}

		public string PlayerZx
		{
			get
			{
				return _Player_Zx;
			}
			set
			{
				_Player_Zx = value;
			}
		}

		public string PlayerJobLevel
		{
			get
			{
				return _Player_Job_leve;
			}
			set
			{
				_Player_Job_leve = value;
			}
		}

		public string RebirthCount
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

		public string PlayerSex
		{
			get
			{
				return _Player_Sex;
			}
			set
			{
				_Player_Sex = value;
			}
		}

		public string PlayerExperience
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

		public GMGJ()
		{
			InitializeComponent();
			username_textBox.Text = username;
			textBox6.Text = PlayerLevel;
			textBox8.Text = PlayerJob;
			textBox4.Text = PlayerZx;
			textBox5.Text = PlayerJobLevel;
			textBox7.Text = RebirthCount;
			textBox3.Text = PlayerSex;
			textBox9.Text = PlayerExperience;
			tishi.Text = "请认真仔细填写，确认后即可生效！";
			comboBox13.Text = "无";
			comboBox14.Text = "无";
			comboBox15.Text = "无";
			comboBox16.Text = "无";
			comboBox17.Text = "无";
			comboBox18.Text = "无";
			comboBox1.Text = "无";
			comboBox19.Text = "不绑";
			comboBox3.Text = "进化";
		}

		private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = "";
			switch (comboBox11.Text)
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
			case "召唤书/碎片":
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
			case "礼包":
				text = "20";
				break;
			case "气功书":
				text = "19";
				break;
			case "技能书":
				text = "1792";
				break;
			case "其他":
				text = "0";
				break;
			}
			listBox3.Items.Clear();
			comboBox12.Items.Clear();
			DataTable dBToDataTable = DBA.GetDBToDataTable("select * from TBL_XWWL_ITEM where FLD_RESIDE2='" + text + "'", "PublicDb");
			for (int i = 0; i < dBToDataTable.Rows.Count; i++)
			{
				listBox3.Items.Add(dBToDataTable.Rows[i]["FLD_NAME"].ToString());
				comboBox12.Items.Add(dBToDataTable.Rows[i]["FLD_PID"].ToString());
			}
		}

		private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboBox12.SelectedIndex = listBox3.SelectedIndex;
		}

        private int GetAttributeValue(string attributeName, int value)
        {
            try
            {
                var baseValues = new Dictionary<string, int>
                {
                    ["Medicine Quantity"] = 2000000000,
                    ["Refine Blue Red"] = 2010000000,
                    ["Refine Additional Life"] = 1020000000,
                    ["Attack Increase"] = 10000000,
                    ["Defense Increase"] = 20000000,
                    ["Life Increase"] = 30000000,
                    ["Internal Power Increase"] = 40000000,
                    ["Hit Rate Increase"] = 50000000,
                    ["Dodge Rate Increase"] = 60000000,
                    ["Martial Attack Power % Increase"] = 70000000,
                    ["All Qigong Level Increase"] = 80000000,
                    ["Upgrade Success Rate % Increase"] = 90000000,
                    ["Additional Damage Value"] = 100000000,
                    ["Martial Defense Increase"] = 110000000,
                    ["Money Gain % Increase"] = 120000000,
                    ["Death Experience Loss Reduction %"] = 130000000,
                    ["Experience Value Increase %"] = 150000000
                };

                return baseValues.ContainsKey(attributeName)
                    ? baseValues[attributeName] + value
                    : 0;
            }
            catch
            {
                return 0;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
		{
			username_textBox.Text = username;
		}

		private void textBox3_MouseClick(object sender, MouseEventArgs e)
		{
			textBox3.Text = PlayerSex;
		}

		private void textBox4_MouseClick(object sender, MouseEventArgs e)
		{
			textBox4.Text = PlayerZx;
		}

		private void textBox5_MouseClick(object sender, MouseEventArgs e)
		{
			textBox5.Text = PlayerJobLevel;
		}

		private void textBox6_MouseClick(object sender, MouseEventArgs e)
		{
			textBox6.Text = PlayerLevel;
		}

		private void textBox7_MouseClick(object sender, MouseEventArgs e)
		{
			textBox7.Text = RebirthCount;
		}

		private void textBox8_MouseClick(object sender, MouseEventArgs e)
		{
			textBox8.Text = PlayerJob;
		}

		private void textBox9_MouseClick(object sender, MouseEventArgs e)
		{
			textBox9.Text = PlayerExperience;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int 使用天数 = 0;
			int 绑定 = 0;
			int 进化 = 0;
			int 中级附魂 = 0;
			int 初级附魂 = 0;
			string text = comboBox13.Text;
			bool flag = false;
			bool flag3 = false;
			if (1 == 0)
			{
			}
			int num6 = text switch
			{
				"石头属性" => int.Parse(textBox63.Text), 
				"药品个数" => 2000000000 + int.Parse(textBox63.Text), 
				"灵宠强化" => 190000000 + int.Parse(textBox63.Text), 
				"披风强化" => 40000000 + int.Parse(textBox63.Text), 
				"首饰耳环强化" => 30000000 + int.Parse(textBox63.Text), 
				"防具(项链)强化" => 20000000 + int.Parse(textBox63.Text), 
				"武器(戒指)强化" => 10000000 + int.Parse(textBox63.Text), 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			int num = num6;
			bool flag4 = false;
			int num2 = num;
			bool flag2 = false;
			int num3 = num2;
			int num4 = int.Parse(textBox64.Text) * 100;
			switch (comboBox14.Text)
			{
			case "毒":
				num3 += 1000006000 + num4;
				break;
			case "外":
				num3 += 1000005000 + num4;
				break;
			case "内":
				num3 += 1000004000 + num4;
				break;
			case "风":
				num3 += 1000003000 + num4;
				break;
			case "水":
				num3 += 1000002000 + num4;
				break;
			case "火":
				num3 += 1000001000 + num4;
				break;
			}
			int 物品属性 = GetAttributeValue(comboBox15.Text, int.Parse(textBox65.Text));
			int 物品属性2 = GetAttributeValue(comboBox16.Text, int.Parse(textBox66.Text));
			int 物品属性3 = GetAttributeValue(comboBox17.Text, int.Parse(textBox67.Text));
			int 物品属性4 = GetAttributeValue(comboBox18.Text, int.Parse(textBox68.Text));
			if (comboBox1.Text == "初级中级天数各2位")
			{
				if (textBox10.Text.Length >= 6)
				{
					初级附魂 = int.Parse(textBox10.Text.Substring(0, 2));
					中级附魂 = int.Parse(textBox10.Text.Substring(2, 2));
					使用天数 = int.Parse(textBox10.Text.Substring(4, 2));
				}
				else if (textBox10.Text.Length == 5)
				{
					初级附魂 = int.Parse(textBox10.Text.Substring(0, 1));
					中级附魂 = int.Parse(textBox10.Text.Substring(1, 2));
					使用天数 = int.Parse(textBox10.Text.Substring(3, 2));
				}
				else if (textBox10.Text.Length == 4)
				{
					初级附魂 = int.Parse(textBox10.Text.Substring(0, 1));
					中级附魂 = int.Parse(textBox10.Text.Substring(1, 2));
					使用天数 = int.Parse(textBox10.Text.Substring(3, 1));
				}
				else if (textBox10.Text.Length == 3)
				{
					初级附魂 = int.Parse(textBox10.Text.Substring(0, 1));
					中级附魂 = 0;
					使用天数 = int.Parse(textBox10.Text.Substring(1, 2));
				}
				else
				{
					初级附魂 = int.Parse(textBox10.Text);
					中级附魂 = 0;
					使用天数 = 0;
				}
			}
			if (comboBox19.Text == "不绑")
			{
				绑定 = 0;
			}
			else if (comboBox19.Text == "绑定")
			{
				绑定 = 1;
			}
			else if (comboBox19.Text == "进化1")
			{
				进化 = 1;
			}
			else if (comboBox19.Text == "进化1+绑定")
			{
				进化 = 1;
				绑定 = 1;
			}
			else if (comboBox19.Text == "进化2")
			{
				进化 = 2;
			}
			else if (comboBox19.Text == "进化2+绑定")
			{
				进化 = 2;
				绑定 = 1;
			}
			if (comboBox12.Text == string.Empty)
			{
				tishi.Text = "请选择物品ID";
				return;
			}
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				int num5 = players.得到包裹空位(players);
				if (num5 == -1)
				{
					tishi.Text = "该玩家没有空位了,请通知玩家清理背包后再尝试";
					return;
				}
				players.AddItemWithProperties(int.Parse(comboBox12.Text), num5, 1, num3, 物品属性, 物品属性2, 物品属性3, 物品属性4, 初级附魂, 中级附魂, 进化, 绑定, 使用天数);
				players.系统提示("获得 " + ItmeClass.得到物品名称(int.Parse(comboBox12.Text)), 10, "GM提示");
				tishi.Text = "玩家后台已经将物品成功刷入玩家[" + players.UserName + "]背包中";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int int_ = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.检察元宝数据1(int_, 1);
				players.SaveGemData();
				players.系统提示("获得" + int_ + "个元宝", 50, "");
				tishi.Text = "玩家后台刷取增加元宝成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SaveGemData();
		}

		private void button3_Click(object sender, EventArgs e)
		{
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			long num = long.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.Player_Money += num;
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得游戏币" + num + "个", 50, "");
				tishi.Text = "玩家后台刷取增加金币成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.称号积分 += num;
				players.SavePlayerData();
				players.系统提示("恭喜您获得增加：" + num + "宝石", 50, "");
				tishi.Text = "玩家后台增加宝石成功";
			}
			else
			{
				tishi.Text = "刷取属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SavePlayerData();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.Player_ExpErience += num;
				players.更新经验和历练();
				players.SavePlayerData();
				tishi.Text = "玩家后台刷取增加历练成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.更新武功和状态();
			players.更新经验和历练();
			players.SavePlayerData();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.Player_WuXun += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				players.系统提示("获得武勋" + num, 50, "");
				tishi.Text = "玩家后台刷取增加武勋成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.SavePlayerData();
		}

		private void label12_Click(object sender, EventArgs e)
		{
		}

		private void button12_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				players.系统提示("获得攻击" + num, 50, "");
				tishi.Text = "玩家后台刷取增加攻击成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.SavePlayerData();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得防御" + num, 50, "");
				tishi.Text = "玩家后台刷取增加防御成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.FLD_人物_追加_武功防御力 += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得武功防御" + num, 50, "");
				tishi.Text = "玩家后台刷取增加武功防御成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得生命" + num, 50, "");
				tishi.Text = "玩家后台刷取增加生命成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得内功" + num, 50, "");
				tishi.Text = "玩家后台刷取增加内功成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button17_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得命中" + num, 50, "");
				tishi.Text = "玩家后台刷取增加命中成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得回避" + num, 50, "");
				tishi.Text = "玩家后台刷取增加回避成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox8.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				switch (num)
				{
				case 1:
					players.Player_Job = 1;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[刀客],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 2:
					players.Player_Job = 2;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[剑客],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 3:
					players.Player_Job = 3;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[枪客],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 4:
					players.Player_Job = 4;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[弓手],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 5:
					players.Player_Job = 5;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[医生],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 6:
					players.Player_Job = 6;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[刺客],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 7:
					players.Player_Job = 7;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[乐师],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 8:
					players.Player_Job = 8;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[韩飞官],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 9:
					players.Player_Job = 9;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为谭花灵],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 10:
					players.Player_Job = 10;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[格斗家],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 11:
					players.Player_Job = 11;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[梅柳真],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 12:
					players.Player_Job = 12;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[卢风郎],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				case 13:
					players.Player_Job = 13;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[东陵神女],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取职业修改成功";
					break;
				}
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.SavePlayerData();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox3.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				switch (num)
				{
				case 1:
					players.Player_Sex = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.SavePlayerData();
					players.系统提示("您已经成功修改性别为：" + num + ",请小退后重上!", 50, "");
					tishi.Text = "玩家后台刷取性别修改成功";
					break;
				case 2:
					players.Player_Sex = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.SavePlayerData();
					players.系统提示("您已经成功修改性别为：" + num + ",请小退后重上!", 50, "");
					tishi.Text = "玩家后台刷取性别修改成功";
					break;
				}
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox4.Text);
			int num2 = 1;
			int num3 = 2;
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				if (num == num2)
				{
					players.Player_Zx = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[正/派],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取正邪修改成功";
				}
				else if (num == num3)
				{
					players.Player_Zx = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.SavePlayerData();
					players.系统提示("成功修改职业为[邪/派],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取正邪修改成功";
				}
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox5.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				switch (num)
				{
				case 1:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.SavePlayerData();
					players.更新气功();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 2:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.更新气功();
					players.SavePlayerData();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 3:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.SavePlayerData();
					players.更新气功();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 4:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.更新气功();
					players.SavePlayerData();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 5:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.更新气功();
					players.SavePlayerData();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 6:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.更新气功();
					players.SavePlayerData();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 7:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.更新气功();
					players.SavePlayerData();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 8:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.更新气功();
					players.SavePlayerData();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 9:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.更新气功();
					players.SavePlayerData();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				case 10:
					players.Player_Job_leve = num;
					players.计算人物基本数据3();
					players.更新HP_MP_SP();
					players.更新武功和状态();
					players.更新经验和历练();
					players.更新金钱和负重();
					players.更新气功();
					players.SavePlayerData();
					players.系统提示("您已成功修改为[" + num + "转],请小退后重上!", 9, "GM提示");
					tishi.Text = "玩家后台刷取转职修改成功";
					break;
				}
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
			players.更新气功();
		}

		private void button10_Click_1(object sender, EventArgs e)
		{
			int player_Level = int.Parse(textBox6.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.Player_Level = player_Level;
				players.计算人物基本数据3();
				players.人物经验 = 0L;
				players.升级后的提示(1);
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("您已成功修改为[" + player_Level + "级],请小退后重上!", 9, "GM提示");
				tishi.Text = "玩家后台刷取等级修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.人物经验 = 0L;
			players.升级后的提示(1);
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
			players.更新广播人物数据();
			players.更新气功();
		}

		private void button21_Click(object sender, EventArgs e)
		{
			long num = long.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.Player_Money -= num;
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("被系统扣除" + num + "游戏币", 50, "");
				tishi.Text = "玩家后台刷取减少金币成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.称号积分 -= num;
				players.SavePlayerData();
				players.系统提示("恭喜您获得减少：" + num + "宝石", 50, "");
				tishi.Text = "玩家后台减少宝石成功";
			}
			else
			{
				tishi.Text = "刷取属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SavePlayerData();
		}

		private void button23_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.Player_ExpErience -= num;
				players.更新经验和历练();
				players.SavePlayerData();
				players.系统提示("被系统扣除" + num + "历练", 50, "");
				tishi.Text = "玩家后台刷取减少历练成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.更新武功和状态();
			players.更新经验和历练();
			players.SavePlayerData();
		}

		private void button24_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.Player_WuXun -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.SavePlayerData();
				players.系统提示("被系统扣除" + num + "武勋", 50, "");
				tishi.Text = "玩家后台刷取减少武勋成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.SavePlayerData();
		}

		private void button25_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.CheckTreasureGems();
				players.FLD_RXPIONT -= num;
				players.SaveGemData();
				players.系统提示("被系统扣除" + num + "个元宝", 50, "");
				tishi.Text = "玩家后台刷取减少元宝成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SaveGemData();
		}

		private void button26_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("被系统减少攻击" + num, 50, "");
				tishi.Text = "玩家后台刷取减少攻击成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
		}

		private void button27_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("被系统减少防御" + num, 50, "");
				tishi.Text = "玩家后台刷取减少防御成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
		}

		private void button28_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.FLD_人物_追加_武功防御力 -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("被系统减少武功防御" + num, 50, "");
				tishi.Text = "玩家后台刷取减少武功防御成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
		}

		private void button29_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("被系统减少生命" + num, 50, "");
				tishi.Text = "玩家后台刷取减少生命成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button30_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("被系统减少内功" + num, 50, "");
				tishi.Text = "玩家后台刷取减少内功成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button31_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("被系统减少命中" + num, 50, "");
				tishi.Text = "玩家后台刷取减少命中成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button32_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("被系统减少回避" + num, 50, "");
				tishi.Text = "玩家后台刷取减少回避成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button33_Click(object sender, EventArgs e)
		{
			int int_ = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.检察元宝积分数据1(int_, 1);
				players.SaveGemData();
				players.系统提示("获得" + int_ + "钻石", 50, "");
				tishi.Text = "玩家后台刷取增加钻石成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SaveGemData();
		}

		private void button34_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.FLD_RXPIONTX -= num;
				players.SaveGemData();
				players.系统提示("被系统扣除" + num + "钻石", 50, "");
				tishi.Text = "玩家后台刷取减少钻石成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SaveGemData();
		}

		private void button35_Click(object sender, EventArgs e)
		{
			long num = long.Parse(textBox9.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.人物经验 = num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得经验值：" + num + ",请小退后重上!", 50, "");
				tishi.Text = "玩家后台刷取等级修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
			players.计算人物基本数据3();
			players.更新HP_MP_SP();
			players.更新武功和状态();
			players.更新经验和历练();
			players.更新金钱和负重();
			players.SavePlayerData();
			players.更新广播人物数据();
			players.更新气功();
		}

		private void button36_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.玫瑰称号积分 += num;
				players.SavePlayerData();
				players.系统提示("恭喜您获得增加：" + num + "爱情度", 50, "");
				tishi.Text = "玩家后台添加爱情度成功";
			}
			else
			{
				tishi.Text = "刷取属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SavePlayerData();
		}

		private void button37_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox2.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.玫瑰称号积分 -= num;
				players.SavePlayerData();
				players.系统提示("您被系统减少：" + num + "爱情度", 50, "");
				tishi.Text = "玩家后台减少爱情度成功";
			}
			else
			{
				tishi.Text = "刷取属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.SavePlayerData();
		}

		private void button38_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox11.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				if (World.AllConnectedPlayers.TryGetValue(players.人物全服ID, out var _))
				{
					DateTime now = DateTime.Now;
					now = DateTime.Now.AddDays(num);
					players.FLD_VIP = 1;
					players.FLD_VIPTIM = now;
					players.系统提示("恭喜您获得" + num + "天的VIP！", 9, "系统提示");
					players.系统提示("你的VIP结束时间是:" + players.FLD_VIPTIM.ToString("yyyy年MM月dd日 hh时mm分"), 9, "系统提示");
					players.系统提示("续时成功,你的VIP结束时间是:" + players.FLD_VIPTIM.ToString("yyyy年MM月dd日 hh时mm分"), 9, "系统提示");
					players.SavePlayerData();
					players.保存会员数据();
				}
				tishi.Text = "玩家后台刷会员成功";
			}
			else
			{
				tishi.Text = "刷取属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.保存会员数据();
			players.SavePlayerData();
		}

		private void button39_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox12.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				if (World.AllConnectedPlayers.TryGetValue(players.人物全服ID, out var _))
				{
					DateTime now = DateTime.Now;
					now = DateTime.Now.AddDays(num);
					players.FLD_QCVIP = 1;
					players.FLD_QCVIPTIM = now;
					players.系统提示("您被系统设为：" + num + "天八彩会员!", 50, "");
					players.系统提示("你的八彩VIP结束时间是:" + players.FLD_QCVIPTIM.ToString("yyyy年MM月dd日 hh时mm分"), 9, "系统提示");
					players.系统提示("续时成功,你的八彩VIP结束时间是:" + players.FLD_QCVIPTIM.ToString("yyyy年MM月dd日 hh时mm分"), 9, "系统提示");
					players.SavePlayerData();
					players.保存八彩数据();
				}
				tishi.Text = "玩家后台刷会员成功";
			}
			else
			{
				tishi.Text = "刷取属性时玩家必须在线,请检查该玩家是否在线状态";
			}
			players.保存八彩数据();
			players.SavePlayerData();
		}

		private void GMGJ_Load(object sender, EventArgs e)
		{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GMGJ));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQueryName = new System.Windows.Forms.Button();
            this.txtQueryStr = new System.Windows.Forms.TextBox();
            this.button41 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button37 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button35 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox19 = new System.Windows.Forms.ComboBox();
            this.textBox68 = new System.Windows.Forms.TextBox();
            this.textBox67 = new System.Windows.Forms.TextBox();
            this.textBox66 = new System.Windows.Forms.TextBox();
            this.textBox65 = new System.Windows.Forms.TextBox();
            this.textBox64 = new System.Windows.Forms.TextBox();
            this.textBox63 = new System.Windows.Forms.TextBox();
            this.comboBox18 = new System.Windows.Forms.ComboBox();
            this.comboBox17 = new System.Windows.Forms.ComboBox();
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tishi = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btnQueryName);
            this.groupBox1.Controls.Add(this.txtQueryStr);
            this.groupBox1.Controls.Add(this.button41);
            this.groupBox1.Controls.Add(this.textBox14);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button39);
            this.groupBox1.Controls.Add(this.button38);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.button35);
            this.groupBox1.Controls.Add(this.button20);
            this.groupBox1.Controls.Add(this.button19);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox19);
            this.groupBox1.Controls.Add(this.textBox68);
            this.groupBox1.Controls.Add(this.textBox67);
            this.groupBox1.Controls.Add(this.textBox66);
            this.groupBox1.Controls.Add(this.textBox65);
            this.groupBox1.Controls.Add(this.textBox64);
            this.groupBox1.Controls.Add(this.textBox63);
            this.groupBox1.Controls.Add(this.comboBox18);
            this.groupBox1.Controls.Add(this.comboBox17);
            this.groupBox1.Controls.Add(this.comboBox16);
            this.groupBox1.Controls.Add(this.comboBox15);
            this.groupBox1.Controls.Add(this.comboBox14);
            this.groupBox1.Controls.Add(this.comboBox13);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.username_textBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox12);
            this.groupBox1.Controls.Add(this.comboBox11);
            this.groupBox1.Controls.Add(this.listBox3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(18, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1120, 799);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "物品修改/添加:";
            // 
            // btnQueryName
            // 
            this.btnQueryName.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnQueryName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQueryName.Location = new System.Drawing.Point(815, 25);
            this.btnQueryName.Name = "btnQueryName";
            this.btnQueryName.Size = new System.Drawing.Size(107, 27);
            this.btnQueryName.TabIndex = 190;
            this.btnQueryName.Text = "物品名搜索";
            this.btnQueryName.UseVisualStyleBackColor = false;
            this.btnQueryName.Click += new System.EventHandler(this.btnQueryName_Click_1);
            // 
            // txtQueryStr
            // 
            this.txtQueryStr.BackColor = System.Drawing.SystemColors.Info;
            this.txtQueryStr.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueryStr.Location = new System.Drawing.Point(705, 29);
            this.txtQueryStr.Name = "txtQueryStr";
            this.txtQueryStr.Size = new System.Drawing.Size(104, 21);
            this.txtQueryStr.TabIndex = 187;
            this.txtQueryStr.TextChanged += new System.EventHandler(this.txtQueryStr_TextChanged);
            // 
            // button41
            // 
            this.button41.BackColor = System.Drawing.SystemColors.Window;
            this.button41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button41.Location = new System.Drawing.Point(267, 708);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(126, 30);
            this.button41.TabIndex = 178;
            this.button41.Text = "称号5000";
            this.button41.UseVisualStyleBackColor = false;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.White;
            this.textBox14.Location = new System.Drawing.Point(125, 712);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(123, 26);
            this.textBox14.TabIndex = 177;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label22.Location = new System.Drawing.Point(19, 716);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 19);
            this.label22.TabIndex = 176;
            this.label22.Text = "会员称号:";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "进化1",
            "进化2"});
            this.comboBox3.Location = new System.Drawing.Point(792, 338);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(75, 24);
            this.comboBox3.TabIndex = 175;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label19.Location = new System.Drawing.Point(705, 343);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 14);
            this.label19.TabIndex = 174;
            this.label19.Text = "是否进化:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label21.Location = new System.Drawing.Point(38, 337);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(183, 14);
            this.label21.TabIndex = 173;
            this.label21.Text = "角色正邪: 1为正 / 2为邪";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.button37);
            this.groupBox2.Controls.Add(this.button36);
            this.groupBox2.Controls.Add(this.button34);
            this.groupBox2.Controls.Add(this.button33);
            this.groupBox2.Controls.Add(this.button32);
            this.groupBox2.Controls.Add(this.button31);
            this.groupBox2.Controls.Add(this.button30);
            this.groupBox2.Controls.Add(this.button29);
            this.groupBox2.Controls.Add(this.button28);
            this.groupBox2.Controls.Add(this.button27);
            this.groupBox2.Controls.Add(this.button26);
            this.groupBox2.Controls.Add(this.button25);
            this.groupBox2.Controls.Add(this.button24);
            this.groupBox2.Controls.Add(this.button23);
            this.groupBox2.Controls.Add(this.button22);
            this.groupBox2.Controls.Add(this.button21);
            this.groupBox2.Controls.Add(this.button18);
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.groupBox2.Location = new System.Drawing.Point(699, 453);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 334);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "属性修改";
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.SystemColors.Window;
            this.button37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button37.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button37.Location = new System.Drawing.Point(299, 106);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(89, 30);
            this.button37.TabIndex = 157;
            this.button37.Text = "减少玫瑰";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.SystemColors.Window;
            this.button36.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button36.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button36.Location = new System.Drawing.Point(204, 106);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(89, 30);
            this.button36.TabIndex = 156;
            this.button36.Text = "增加玫瑰";
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.SystemColors.Window;
            this.button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button34.Location = new System.Drawing.Point(299, 70);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(89, 30);
            this.button34.TabIndex = 155;
            this.button34.Text = "减少钻石";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.SystemColors.Window;
            this.button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button33.Location = new System.Drawing.Point(204, 70);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(89, 30);
            this.button33.TabIndex = 154;
            this.button33.Text = "增加钻石";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.SystemColors.Window;
            this.button32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button32.ForeColor = System.Drawing.Color.Teal;
            this.button32.Location = new System.Drawing.Point(299, 248);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(89, 30);
            this.button32.TabIndex = 153;
            this.button32.Text = "减少回避";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.SystemColors.Window;
            this.button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button31.Location = new System.Drawing.Point(109, 248);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(89, 30);
            this.button31.TabIndex = 152;
            this.button31.Text = "减少命中";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.SystemColors.Window;
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.button30.Location = new System.Drawing.Point(299, 212);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(89, 30);
            this.button30.TabIndex = 151;
            this.button30.Text = "减少内功";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.SystemColors.Window;
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button29.ForeColor = System.Drawing.Color.Red;
            this.button29.Location = new System.Drawing.Point(109, 212);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(89, 30);
            this.button29.TabIndex = 150;
            this.button29.Text = "减少生命";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.SystemColors.Window;
            this.button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button28.Location = new System.Drawing.Point(299, 284);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(89, 30);
            this.button28.TabIndex = 149;
            this.button28.Text = "减少武防";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.SystemColors.Window;
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button27.Location = new System.Drawing.Point(299, 142);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(89, 30);
            this.button27.TabIndex = 148;
            this.button27.Text = "减少防御";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.SystemColors.Window;
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button26.Location = new System.Drawing.Point(109, 142);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(89, 30);
            this.button26.TabIndex = 147;
            this.button26.Text = "减少攻击";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.SystemColors.Window;
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button25.ForeColor = System.Drawing.Color.Fuchsia;
            this.button25.Location = new System.Drawing.Point(109, 70);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(89, 30);
            this.button25.TabIndex = 146;
            this.button25.Text = "减少元宝";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.SystemColors.Window;
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button24.Location = new System.Drawing.Point(299, 177);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(89, 30);
            this.button24.TabIndex = 145;
            this.button24.Text = "减少武勋";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.SystemColors.Window;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button23.Location = new System.Drawing.Point(109, 176);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(89, 30);
            this.button23.TabIndex = 144;
            this.button23.Text = "减少历练";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.SystemColors.Window;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button22.Location = new System.Drawing.Point(109, 284);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(89, 30);
            this.button22.TabIndex = 143;
            this.button22.Text = "减少宝石";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.SystemColors.Window;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button21.Location = new System.Drawing.Point(109, 106);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(89, 30);
            this.button21.TabIndex = 142;
            this.button21.Text = "减少金币";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.SystemColors.Window;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.ForeColor = System.Drawing.Color.Teal;
            this.button18.Location = new System.Drawing.Point(204, 248);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(89, 30);
            this.button18.TabIndex = 141;
            this.button18.Text = "增加回避";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.SystemColors.Window;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button17.Location = new System.Drawing.Point(14, 248);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(89, 30);
            this.button17.TabIndex = 140;
            this.button17.Text = "增加命中";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.SystemColors.Window;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.button16.Location = new System.Drawing.Point(204, 212);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(89, 30);
            this.button16.TabIndex = 139;
            this.button16.Text = "增加内功";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.SystemColors.Window;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.ForeColor = System.Drawing.Color.Red;
            this.button15.Location = new System.Drawing.Point(14, 212);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(89, 30);
            this.button15.TabIndex = 138;
            this.button15.Text = "增加生命";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.SystemColors.Window;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button14.Location = new System.Drawing.Point(204, 284);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(89, 30);
            this.button14.TabIndex = 137;
            this.button14.Text = "增加武防";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.Window;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button13.Location = new System.Drawing.Point(204, 142);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(89, 30);
            this.button13.TabIndex = 136;
            this.button13.Text = "增加防御";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.Window;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button12.Location = new System.Drawing.Point(14, 142);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(89, 30);
            this.button12.TabIndex = 135;
            this.button12.Text = "增加攻击";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Window;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button6.Location = new System.Drawing.Point(204, 176);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 30);
            this.button6.TabIndex = 134;
            this.button6.Text = "增加武勋";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Window;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button5.Location = new System.Drawing.Point(14, 176);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 30);
            this.button5.TabIndex = 133;
            this.button5.Text = "增加历练";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Window;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button4.Location = new System.Drawing.Point(14, 284);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 30);
            this.button4.TabIndex = 132;
            this.button4.Text = "增加宝石";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(14, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 30);
            this.button3.TabIndex = 131;
            this.button3.Text = "增加金币";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(55, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 130;
            this.label9.Text = "数量:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(109, 27);
            this.textBox2.MaxLength = 68888;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(279, 26);
            this.textBox2.TabIndex = 127;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Fuchsia;
            this.button2.Location = new System.Drawing.Point(14, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 30);
            this.button2.TabIndex = 126;
            this.button2.Text = "增加元宝";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button39
            // 
            this.button39.BackColor = System.Drawing.SystemColors.Window;
            this.button39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button39.ForeColor = System.Drawing.Color.Lime;
            this.button39.Location = new System.Drawing.Point(267, 665);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(126, 30);
            this.button39.TabIndex = 162;
            this.button39.Text = "增加八彩";
            this.button39.UseVisualStyleBackColor = false;
            this.button39.Click += new System.EventHandler(this.button39_Click);
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.SystemColors.Window;
            this.button38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button38.ForeColor = System.Drawing.Color.Red;
            this.button38.Location = new System.Drawing.Point(267, 620);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(126, 31);
            this.button38.TabIndex = 161;
            this.button38.Text = "增加VIP会员";
            this.button38.UseVisualStyleBackColor = false;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.White;
            this.textBox12.Location = new System.Drawing.Point(125, 669);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(123, 26);
            this.textBox12.TabIndex = 156;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.Lime;
            this.label18.Location = new System.Drawing.Point(19, 670);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 19);
            this.label18.TabIndex = 155;
            this.label18.Text = "八彩提示:";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.White;
            this.textBox11.Location = new System.Drawing.Point(125, 623);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(123, 26);
            this.textBox11.TabIndex = 154;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(41, 626);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 16);
            this.label17.TabIndex = 153;
            this.label17.Text = "VIP会员:";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Window;
            this.textBox10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox10.ForeColor = System.Drawing.Color.Orange;
            this.textBox10.Location = new System.Drawing.Point(998, 273);
            this.textBox10.MaxLength = 7;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(75, 26);
            this.textBox10.TabIndex = 152;
            this.textBox10.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label16.Location = new System.Drawing.Point(705, 280);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 14);
            this.label16.TabIndex = 151;
            this.label16.Text = "第五属性:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.ForeColor = System.Drawing.Color.Green;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "无",
            "觉醒"});
            this.comboBox1.Location = new System.Drawing.Point(792, 275);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 24);
            this.comboBox1.TabIndex = 150;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(125, 539);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(123, 26);
            this.textBox9.TabIndex = 149;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label15.Location = new System.Drawing.Point(34, 542);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 16);
            this.label15.TabIndex = 148;
            this.label15.Text = "玩家经验:";
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.SystemColors.Window;
            this.button35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button35.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button35.Location = new System.Drawing.Point(267, 539);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(126, 26);
            this.button35.TabIndex = 147;
            this.button35.Text = "修改经验";
            this.button35.UseVisualStyleBackColor = false;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.SystemColors.Window;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button20.ForeColor = System.Drawing.Color.Olive;
            this.button20.Location = new System.Drawing.Point(340, 497);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(53, 26);
            this.button20.TabIndex = 146;
            this.button20.Text = "减少";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click_1);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.SystemColors.Window;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button19.ForeColor = System.Drawing.Color.Olive;
            this.button19.Location = new System.Drawing.Point(267, 295);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(126, 26);
            this.button19.TabIndex = 145;
            this.button19.Text = "修改职业";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.White;
            this.textBox8.Location = new System.Drawing.Point(125, 295);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(123, 26);
            this.textBox8.TabIndex = 144;
            this.textBox8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox8_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Olive;
            this.label6.Location = new System.Drawing.Point(34, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 143;
            this.label6.Text = "玩家职业:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(125, 581);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(123, 26);
            this.textBox3.TabIndex = 142;
            this.textBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox3_MouseClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Silver;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(14, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(234, 42);
            this.label14.TabIndex = 141;
            this.label14.Text = "提示：玩家必须是在线状态.\r\n\r\n    先填写玩家名字再进行更改。";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.Window;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button11.ForeColor = System.Drawing.Color.Olive;
            this.button11.Location = new System.Drawing.Point(270, 497);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(53, 26);
            this.button11.TabIndex = 140;
            this.button11.Text = "增加";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.Window;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button10.Location = new System.Drawing.Point(267, 453);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(126, 26);
            this.button10.TabIndex = 139;
            this.button10.Text = "修改等级";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.Window;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button9.ForeColor = System.Drawing.Color.Teal;
            this.button9.Location = new System.Drawing.Point(267, 411);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(126, 26);
            this.button9.TabIndex = 138;
            this.button9.Text = "修改转职";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Window;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button8.ForeColor = System.Drawing.Color.Gray;
            this.button8.Location = new System.Drawing.Point(267, 368);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(126, 26);
            this.button8.TabIndex = 137;
            this.button8.Text = "修改正邪";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Window;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button7.Location = new System.Drawing.Point(267, 578);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 29);
            this.button7.TabIndex = 136;
            this.button7.Text = "修改性别";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.Location = new System.Drawing.Point(125, 497);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(123, 26);
            this.textBox7.TabIndex = 135;
            this.textBox7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox7_MouseClick);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(125, 453);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(123, 26);
            this.textBox6.TabIndex = 134;
            this.textBox6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox6_MouseClick);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(125, 411);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(123, 26);
            this.textBox5.TabIndex = 133;
            this.textBox5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox5_MouseClick);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(125, 368);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(123, 26);
            this.textBox4.TabIndex = 132;
            this.textBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox4_MouseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Olive;
            this.label13.Location = new System.Drawing.Point(34, 500);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 16);
            this.label13.TabIndex = 130;
            this.label13.Text = "转生次数:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(34, 456);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 16);
            this.label12.TabIndex = 129;
            this.label12.Text = "玩家等级:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Teal;
            this.label11.Location = new System.Drawing.Point(34, 414);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 16);
            this.label11.TabIndex = 128;
            this.label11.Text = "玩家转职:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(34, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 16);
            this.label10.TabIndex = 127;
            this.label10.Text = "玩家正邪:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label8.Location = new System.Drawing.Point(34, 584);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 126;
            this.label8.Text = "玩家性别:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(779, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 42);
            this.label7.TabIndex = 125;
            this.label7.Text = "提示：强化最高99999、属性最高10、\r\n\r\n      其他四个属性最高7个9";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(705, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 124;
            this.label5.Text = "是否绑定:";
            // 
            // comboBox19
            // 
            this.comboBox19.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox19.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox19.ForeColor = System.Drawing.Color.DarkRed;
            this.comboBox19.FormattingEnabled = true;
            this.comboBox19.Items.AddRange(new object[] {
            "不绑",
            "绑定",
            "进化1",
            "进化1+绑定",
            "进化2",
            "进化2+绑定"});
            this.comboBox19.Location = new System.Drawing.Point(792, 305);
            this.comboBox19.Name = "comboBox19";
            this.comboBox19.Size = new System.Drawing.Size(75, 24);
            this.comboBox19.TabIndex = 123;
            // 
            // textBox68
            // 
            this.textBox68.BackColor = System.Drawing.SystemColors.Window;
            this.textBox68.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox68.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.textBox68.Location = new System.Drawing.Point(998, 243);
            this.textBox68.MaxLength = 7;
            this.textBox68.Name = "textBox68";
            this.textBox68.Size = new System.Drawing.Size(75, 26);
            this.textBox68.TabIndex = 122;
            this.textBox68.Text = "0";
            // 
            // textBox67
            // 
            this.textBox67.BackColor = System.Drawing.SystemColors.Window;
            this.textBox67.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox67.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.textBox67.Location = new System.Drawing.Point(998, 213);
            this.textBox67.MaxLength = 7;
            this.textBox67.Name = "textBox67";
            this.textBox67.Size = new System.Drawing.Size(75, 26);
            this.textBox67.TabIndex = 121;
            this.textBox67.Text = "0";
            // 
            // textBox66
            // 
            this.textBox66.BackColor = System.Drawing.SystemColors.Window;
            this.textBox66.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox66.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.textBox66.Location = new System.Drawing.Point(998, 183);
            this.textBox66.MaxLength = 7;
            this.textBox66.Name = "textBox66";
            this.textBox66.Size = new System.Drawing.Size(75, 26);
            this.textBox66.TabIndex = 120;
            this.textBox66.Text = "0";
            // 
            // textBox65
            // 
            this.textBox65.BackColor = System.Drawing.SystemColors.Window;
            this.textBox65.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox65.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.textBox65.Location = new System.Drawing.Point(998, 151);
            this.textBox65.MaxLength = 7;
            this.textBox65.Name = "textBox65";
            this.textBox65.Size = new System.Drawing.Size(75, 26);
            this.textBox65.TabIndex = 119;
            this.textBox65.Text = "0";
            // 
            // textBox64
            // 
            this.textBox64.BackColor = System.Drawing.SystemColors.Window;
            this.textBox64.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox64.Location = new System.Drawing.Point(998, 120);
            this.textBox64.MaxLength = 7;
            this.textBox64.Name = "textBox64";
            this.textBox64.Size = new System.Drawing.Size(75, 26);
            this.textBox64.TabIndex = 118;
            this.textBox64.Text = "0";
            // 
            // textBox63
            // 
            this.textBox63.BackColor = System.Drawing.SystemColors.Window;
            this.textBox63.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox63.Location = new System.Drawing.Point(998, 92);
            this.textBox63.MaxLength = 7;
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new System.Drawing.Size(75, 26);
            this.textBox63.TabIndex = 117;
            this.textBox63.Text = "0";
            // 
            // comboBox18
            // 
            this.comboBox18.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.comboBox18.FormattingEnabled = true;
            this.comboBox18.Items.AddRange(new object[] {
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
            this.comboBox18.Location = new System.Drawing.Point(792, 245);
            this.comboBox18.MaxDropDownItems = 18;
            this.comboBox18.Name = "comboBox18";
            this.comboBox18.Size = new System.Drawing.Size(200, 24);
            this.comboBox18.TabIndex = 116;
            // 
            // comboBox17
            // 
            this.comboBox17.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.comboBox17.FormattingEnabled = true;
            this.comboBox17.Items.AddRange(new object[] {
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
            this.comboBox17.Location = new System.Drawing.Point(792, 215);
            this.comboBox17.MaxDropDownItems = 18;
            this.comboBox17.Name = "comboBox17";
            this.comboBox17.Size = new System.Drawing.Size(200, 24);
            this.comboBox17.TabIndex = 115;
            // 
            // comboBox16
            // 
            this.comboBox16.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.comboBox16.FormattingEnabled = true;
            this.comboBox16.Items.AddRange(new object[] {
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
            this.comboBox16.Location = new System.Drawing.Point(792, 185);
            this.comboBox16.MaxDropDownItems = 18;
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(200, 24);
            this.comboBox16.TabIndex = 114;
            // 
            // comboBox15
            // 
            this.comboBox15.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.comboBox15.FormattingEnabled = true;
            this.comboBox15.Items.AddRange(new object[] {
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
            this.comboBox15.Location = new System.Drawing.Point(792, 153);
            this.comboBox15.MaxDropDownItems = 18;
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(200, 24);
            this.comboBox15.TabIndex = 113;
            // 
            // comboBox14
            // 
            this.comboBox14.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Items.AddRange(new object[] {
            "无",
            "火",
            "水",
            "风",
            "内",
            "外",
            "毒"});
            this.comboBox14.Location = new System.Drawing.Point(792, 122);
            this.comboBox14.MaxDropDownItems = 18;
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(200, 24);
            this.comboBox14.TabIndex = 112;
            // 
            // comboBox13
            // 
            this.comboBox13.BackColor = System.Drawing.SystemColors.Info;
            this.comboBox13.DisplayMember = "1";
            this.comboBox13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.Items.AddRange(new object[] {
            "无",
            "武器(戒指)强化",
            "防具(项链)强化",
            "首饰耳环强化",
            "披风强化",
            "灵宠强化",
            "药品个数",
            "石头属性"});
            this.comboBox13.Location = new System.Drawing.Point(792, 94);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(200, 24);
            this.comboBox13.TabIndex = 111;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.ForeColor = System.Drawing.Color.Purple;
            this.label46.Location = new System.Drawing.Point(705, 250);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(75, 14);
            this.label46.TabIndex = 110;
            this.label46.Text = "第四属性:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.ForeColor = System.Drawing.Color.Navy;
            this.label45.Location = new System.Drawing.Point(705, 220);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(75, 14);
            this.label45.TabIndex = 109;
            this.label45.Text = "第三属性:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.ForeColor = System.Drawing.Color.Teal;
            this.label44.Location = new System.Drawing.Point(705, 190);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(75, 14);
            this.label44.TabIndex = 108;
            this.label44.Text = "第二属性:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.ForeColor = System.Drawing.Color.Green;
            this.label43.Location = new System.Drawing.Point(705, 158);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(75, 14);
            this.label43.TabIndex = 107;
            this.label43.Text = "第一属性:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.ForeColor = System.Drawing.Color.Olive;
            this.label42.Location = new System.Drawing.Point(705, 127);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(75, 14);
            this.label42.TabIndex = 106;
            this.label42.Text = "附生属性:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label41.Location = new System.Drawing.Point(705, 97);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(75, 14);
            this.label41.TabIndex = 105;
            this.label41.Text = "属性类型:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Honeydew;
            this.button1.Location = new System.Drawing.Point(808, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 38);
            this.button1.TabIndex = 71;
            this.button1.Text = "确定添加物品";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.username_textBox.BackColor = System.Drawing.Color.White;
            this.username_textBox.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.username_textBox.Location = new System.Drawing.Point(148, 136);
            this.username_textBox.Name = "textBox1";
            this.username_textBox.Size = new System.Drawing.Size(253, 41);
            this.username_textBox.TabIndex = 70;
            this.username_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(19, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 69;
            this.label4.Text = "玩家姓名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(307, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 14);
            this.label3.TabIndex = 68;
            this.label3.Text = "可直接查找物品ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 42);
            this.label2.TabIndex = 67;
            this.label2.Text = "角色职业:\r\n\r\n1刀.2剑.3枪.4弓.5医.6刺.7乐.8韩.9谭.10格.11梅.12卢.13东";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(368, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 14);
            this.label1.TabIndex = 66;
            this.label1.Text = "物品分类:";
            // 
            // comboBox12
            // 
            this.comboBox12.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox12.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Location = new System.Drawing.Point(449, 53);
            this.comboBox12.MaxDropDownItems = 37;
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(250, 27);
            this.comboBox12.TabIndex = 181;
            this.comboBox12.SelectedIndexChanged += new System.EventHandler(this.comboBox12_SelectedIndexChanged);
            // 
            // comboBox11
            // 
            this.comboBox11.BackColor = System.Drawing.Color.White;
            this.comboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox11.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Items.AddRange(new object[] {
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
            "召唤书/碎片",
            "石头类",
            "幸运符",
            "盒子/箱子",
            "礼包",
            "气功书",
            "技能书",
            "其他"});
            this.comboBox11.Location = new System.Drawing.Point(449, 25);
            this.comboBox11.MaxDropDownItems = 20;
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(250, 27);
            this.comboBox11.TabIndex = 64;
            this.comboBox11.SelectedIndexChanged += new System.EventHandler(this.comboBox11_SelectedIndexChanged);
            // 
            // listBox3
            // 
            this.listBox3.BackColor = System.Drawing.Color.White;
            this.listBox3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(449, 83);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(250, 704);
            this.listBox3.TabIndex = 63;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.White;
            this.textBox13.Location = new System.Drawing.Point(125, 664);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(123, 21);
            this.textBox13.TabIndex = 171;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tishi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 817);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1150, 22);
            this.statusStrip1.TabIndex = 64;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(140, 17);
            this.toolStripStatusLabel1.Text = "属性信息修改成功提示：";
            // 
            // tishi
            // 
            this.tishi.ForeColor = System.Drawing.Color.Red;
            this.tishi.Name = "tishi";
            this.tishi.Size = new System.Drawing.Size(0, 17);
            // 
            // GMGJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1150, 839);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GMGJ";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "在线GM工具-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.GMGJ_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SearchItem();
		}

		private void SearchItem(string Args = "")
		{
			string text = "";
			switch (comboBox12.Text)
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
			listBox3.Items.Clear();
			comboBox12.Items.Clear();
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
				listBox3.Items.Add(item);
				comboBox12.Items.Add(item2);
			}
		}

		private void lsItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboBox12.SelectedIndex = listBox3.SelectedIndex;
		}

		private void button20_Click_1(object sender, EventArgs e)
		{
			int num = int.Parse(textBox7.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.转生次数 -= num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("您已成功减少：" + num + "次转生。", 50, "");
				tishi.Text = "玩家后台刷取转生次数修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox7.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.转生次数 += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("您已成功增加转生：" + num + "次。", 50, "");
				tishi.Text = "玩家后台刷取转生次数修改成功";
			}
			else
			{
				tishi.Text = "变更职业的时候玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void button41_Click(object sender, EventArgs e)
		{
			int num = int.Parse(textBox14.Text);
			Players players = World.检查玩家name(username_textBox.Text);
			if (players != null)
			{
				players.累计充值 += num;
				players.计算人物基本数据3();
				players.更新HP_MP_SP();
				players.更新武功和状态();
				players.更新经验和历练();
				players.更新金钱和负重();
				players.SavePlayerData();
				players.系统提示("获得" + num + "VIP", 50, "");
				tishi.Text = "玩家后台刷取增加称号VIP成功";
			}
			else
			{
				tishi.Text = "刷取物品属性时玩家必须在线,请检查该玩家是否在线状态";
			}
		}

		private void textBox13_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox15_TextChanged(object sender, EventArgs e)
		{
		}

		private void btnQueryName_Click(object sender, EventArgs e)
		{
		}

		private void btnQueryName_Click_1(object sender, EventArgs e)
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

		private void txtQueryStr_TextChanged(object sender, EventArgs e)
		{
		}

		private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void lsItems_SelectedIndexChanged_1(object sender, EventArgs e)
		{
		}
	}
}
