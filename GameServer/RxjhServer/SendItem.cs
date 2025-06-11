using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using RxjhServer.DbClss;
using RxjhServer.HelperTools;
using RxjhServer.Network;

namespace RxjhServer
{
	public class SendItem : Form
	{
		private Players Player;

		private readonly object AsyncLock = new object();

		private static readonly ConcurrentDictionary<int, NpcClass> List = new ConcurrentDictionary<int, NpcClass>();

		private int FLD_MAP = 0;

		private int FLD_PID = 0;

		private string FLD_Name = "未知";

		private Label label1;

		private TextBox textBox2;

		private CheckBox checkBox1;

		private ComboBox comboBox1;

		private ComboBox comboBox2;

		private ComboBox comboBox3;

		private Button button13;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private GroupBox groupBox3;

		private Button button8;

		private TextBox textBox27;

		private Label label27;

		private Label label24;

		private ListBox listBox1;

		private Button button9;

		private Button button11;

		private TextBox textBox16;

		private ListBox listBox2;

		private TextBox textBox17;

		private Button button10;

		private TextBox textBox18;

		private Label label26;

		private TextBox textBox19;

		private Label label25;

		private TextBox textBox20;

		private TextBox textBox21;

		private Label label23;

		private TextBox textBox22;

		private Label label22;

		private TextBox textBox23;

		private Label label21;

		private TextBox textBox24;

		private Label label18;

		private TextBox textBox25;

		private Label label17;

		private TextBox textBox26;

		private Label label19;

		private Label label16;

		private Label label20;

		private TabPage tabPage2;

		private GroupBox groupBox2;

		private Button button7;

		private TextBox textBox14;

		private Label label13;

		private Button button6;

		private TextBox textBox12;

		private Label label12;

		private Button button5;

		private Button button4;

		private Button button3;

		private Button button2;

		private Label label2;

		private TextBox textBox3;

		private TextBox textBox11;

		private Label label4;

		private Label label7;

		private TextBox textBox4;

		private TextBox textBox5;

		private Label label5;

		private TabPage tabPage3;

		private GroupBox groupBox1;

		private Label label15;

		private TextBox textBox15;

		private TextBox textBox13;

		private Label label40;

		private Button button1;

		private Label label3;

		private TextBox textBox1;

		private ListBox listBox3;

		private ComboBox comboBox11;

		private Label label14;

		private Label label6;

		private TextBox textBox6;

		private Label label11;

		private TextBox textBox7;

		private Label label10;

		private TextBox textBox8;

		private Label label9;

		private TextBox textBox9;

		private Label label8;

		private TextBox textBox10;

		private Label label29;

		private Button button12;

		private Button button14;

		private TextBox textBox28;

		private Label label28;

		private Button button15;

		private Button button17;

		private Label label31;

		private TextBox textBox30;

		private Button button16;

		private Label label30;

		private TextBox textBox29;

		private Button button18;

		private Label label32;

		private TextBox textBox31;

		private Button button19;

		private Label label33;

		private Label label34;

		private Button button20;

		private TextBox textBox33;

		private Button button21;

		private TextBox textBox34;

		private Label label35;

		private Button button22;

		private Button button23;

		private Button button24;

		private TextBox textBox35;

		private Label label36;

		private TextBox textBox32;

		public SendItem()
		{
			InitializeComponent();
		}

		public bool SetUser(string UserName)
		{
			Player = World.检查玩家name(UserName);
			if (Player != null)
			{
				return true;
			}
			return false;
		}

		public void SetUserName(string UserName)
		{
		}

		private void SendItem_Load(object sender, EventArgs e)
		{
			Player = null;
			textBox1.Text = "1";
			textBox6.Text = "0";
			textBox7.Text = "0";
			textBox8.Text = "0";
			textBox9.Text = "0";
			textBox10.Text = "0";
			comboBox1.Items.Clear();
			comboBox2.Items.Clear();
			comboBox3.Items.Clear();
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
			try
			{
				foreach (string value in World.Maplist.Values)
				{
					comboBox2.Items.Add(value);
				}
				foreach (DropClass item in World.Drop)
				{
					comboBox3.Items.Add(item.FLD_NAME);
				}
			}
			catch
			{
			}
		}

		private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
		{
			string str = "";
			switch (comboBox11.Text)
			{
			case "武器":
				str = "4";
				break;
			case "衣服":
				str = "1";
				break;
			case "护手":
				str = "2";
				break;
			case "鞋子":
				str = "5";
				break;
			case "内甲":
				str = "6";
				break;
			case "项链":
				str = "7";
				break;
			case "耳环":
				str = "8";
				break;
			case "戒指":
				str = "10";
				break;
			case "披风":
				str = "12";
				break;
			case "弓箭":
				str = "13";
				break;
			case "门甲":
				str = "14";
				break;
			case "宝宝":
				str = "15";
				break;
			case "其他":
				str = "0";
				break;
			case "石头":
				str = "16";
				break;
			}
			listBox3.Items.Clear();
			string sqlCommand = "select * from TBL_XWWL_ITEM where FLD_RESIDE2='" + str + "'";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "PublicDb");
			for (int i = 0; i < dBToDataTable.Rows.Count; i++)
			{
				listBox3.Items.Add(dBToDataTable.Rows[i]["FLD_NAME"].ToString());
			}
			dBToDataTable.Dispose();
		}

		private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			string sqlCommand = $"select * from TBL_XWWL_ITEM where FLD_NAME='{listBox3.SelectedItem}'";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "PublicDb");
			textBox13.Text = dBToDataTable.Rows[0]["FLD_PID"].ToString();
			dBToDataTable.Dispose();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				int num = Player.得到包裹空位(Player);
				if (num == -1)
				{
					MessageBox.Show("没有空位");
					return;
				}
				int 物品ID = int.Parse(textBox13.Text);
				int 数量 = int.Parse(textBox1.Text);
				int 物品属性 = int.Parse(textBox6.Text);
				int 物品属性2 = int.Parse(textBox7.Text);
				int 物品属性3 = int.Parse(textBox8.Text);
				int 物品属性4 = int.Parse(textBox9.Text);
				int 物品属性5 = int.Parse(textBox10.Text);
				Player.AddItemWithProperties(物品ID, num, 数量, 物品属性, 物品属性2, 物品属性3, 物品属性4, 物品属性5, 0, 0, 0, 0, 0);
				if (checkBox1.Checked && textBox15.Text != "")
				{
					string text = "恭喜玩家[" + Player.UserName + "]在[" + 坐标Class.getmapname(FLD_MAP) + "]击杀[" + FLD_Name + "]获得[" + textBox15.Text + "]";
					World.conn.发送("刷怪掉宝|" + 10 + "|" + text + "|" + World.ServerID);
				}
				MessageBox.Show("发送成功，人物:" + Player.UserName + " 物品: " + listBox3.SelectedItem);
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			NpcClass npcClass = method_0(comboBox1.SelectedItem.ToString());
			if (npcClass != null)
			{
				FLD_PID = npcClass.FLD_PID;
				FLD_Name = npcClass.Name;
			}
		}

		private NpcClass method_0(string string_0)
		{
			foreach (NpcClass value in List.Values)
			{
				if (value.Name == string_0)
				{
					return value;
				}
			}
			return null;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.Player_ExpErience += int.Parse(textBox3.Text);
					Player.更新经验和历练();
					Player.更新金钱和负重();
					MessageBox.Show("发送成功，人物当前历练:" + Player.Player_ExpErience + " 增加历练: " + int.Parse(textBox3.Text));
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.人物经验 += int.Parse(textBox4.Text);
					Player.计算人物基本数据3();
					Player.更新经验和历练();
					Player.更新金钱和负重();
					MessageBox.Show("发送成功，人物当前经验:" + Player.人物经验 + " 增加经验: " + int.Parse(textBox4.Text));
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.Player_Level = int.Parse(textBox5.Text);
					Player.人物经验 = 0L;
					Player.升级后的提示(1);
					Player.计算人物基本数据3();
					Player.更新经验和历练();
					Player.更新金钱和负重();
					MessageBox.Show("发送成功，当前等级:" + Player.Player_Level + " 增加等级: " + int.Parse(textBox5.Text));
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.Player_Money += int.Parse(textBox11.Text);
					Player.更新金钱和负重();
					MessageBox.Show("发送成功，当前金币:" + Player.Player_Money + " 增加金币: " + int.Parse(textBox11.Text));
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.CheckTreasureGems();
					Player.检察元宝数据(int.Parse(textBox12.Text), 1, "GM工具");
					Player.SaveGemData();
					MessageBox.Show("发送成功，当前元宝:" + Player.FLD_RXPIONT + " 增加元宝: " + int.Parse(textBox12.Text));
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			if (int.Parse(textBox14.Text) != 0)
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.FLD_装备_追加_合成成功率百分比 += int.Parse(textBox14.Text);
					MessageBox.Show("发送成功，当前概率:" + Player.FLD_装备_追加_合成成功率百分比);
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
				return;
			}
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				value.FLD_装备_追加_合成成功率百分比 = 0.0;
			}
			MessageBox.Show("发送成功，当前概率:" + Player.FLD_装备_追加_合成成功率百分比);
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (KeyValuePair<int, string> item in World.Maplist)
			{
				if (item.Value == comboBox2.SelectedItem.ToString())
				{
					FLD_MAP = item.Key;
				}
			}
			List.Clear();
			comboBox1.Items.Clear();
			foreach (NpcClass value in World.NpcList.Values)
			{
				try
				{
					if (value.Rxjh_Map == FLD_MAP)
					{
						List.TryAdd(value.FLD_PID, value);
						comboBox1.Items.Add(value.Name);
					}
				}
				catch
				{
					MessageBox.Show(value.FLD_PID + "|" + value.Name);
				}
			}
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (DropClass item in World.Drop)
			{
				if (item.FLD_NAME == comboBox3.SelectedItem.ToString())
				{
					textBox13.Text = item.FLD_PID.ToString();
					textBox15.Text = item.FLD_NAME;
					textBox6.Text = item.FLD_MAGIC0.ToString();
					textBox7.Text = item.FLD_MAGIC1.ToString();
					textBox8.Text = item.FLD_MAGIC2.ToString();
					textBox9.Text = item.FLD_MAGIC3.ToString();
					textBox10.Text = item.FLD_MAGIC4.ToString();
					if (item.是否开启公告 == 1)
					{
						checkBox1.Checked = true;
					}
					else
					{
						checkBox1.Checked = false;
					}
				}
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				if (Player.个人商店 == null)
				{
					label29.Text = "当前商店未开";
					return;
				}
				if (Player.个人商店 != null && !Player.个人商店.个人商店是否开启)
				{
					listBox1.Items.Clear();
					foreach (个人商店物品类 value in Player.个人商店.商店物品列表.Values)
					{
						listBox1.Items.Add(value.物品.Get物品全局ID);
					}
					label29.Text = "已上架，未开店";
					return;
				}
				listBox1.Items.Clear();
				foreach (个人商店物品类 value2 in Player.个人商店.商店物品列表.Values)
				{
					listBox1.Items.Add(value2.物品.Get物品全局ID);
				}
				label29.Text = "已开店";
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Player == null || Player.个人商店 == null || listBox1.SelectedItem == null)
			{
				return;
			}
			int num = int.Parse(listBox1.SelectedItem.ToString());
			foreach (个人商店物品类 value in Player.个人商店.商店物品列表.Values)
			{
				if (value.物品.Get物品全局ID == num)
				{
					textBox16.Text = value.物品.得到物品名称();
					textBox17.Text = value.位置.ToString();
					textBox18.Text = value.数量.ToString();
					textBox19.Text = value.价格.ToString();
					textBox20.Text = value.物品.Get物品全局ID.ToString();
					textBox21.Text = value.物品.Get物品ID.ToString();
					textBox22.Text = value.物品.FLD_MAGIC0.ToString();
					textBox23.Text = value.物品.FLD_MAGIC1.ToString();
					textBox24.Text = value.物品.FLD_MAGIC2.ToString();
					textBox25.Text = value.物品.FLD_MAGIC3.ToString();
					textBox26.Text = value.物品.FLD_MAGIC4.ToString();
				}
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				if (Player.个人商店 == null)
				{
					label29.Text = "请先开店";
					return;
				}
				if (textBox19.Text.Length <= 0)
				{
					label29.Text = "请设置单价";
					return;
				}
				if (Player.个人商店.商店物品列表.Count >= 8)
				{
					label29.Text = "商品已满物品已满";
					return;
				}
				Player.装备栏包裹[int.Parse(textBox17.Text)].锁定 = true;
				个人商店物品类 个人商店物品类2 = new 个人商店物品类
				{
					数量 = int.Parse(textBox18.Text),
					价格 = long.Parse(textBox19.Text),
					位置 = int.Parse(textBox17.Text),
					物品 = Player.装备栏包裹[int.Parse(textBox17.Text)]
				};
				Player.个人商店.商店物品列表.Add(BitConverter.ToInt64(Player.装备栏包裹[int.Parse(textBox17.Text)].物品全局ID, 0), 个人商店物品类2);
				using (发包类 发包类 = new 发包类())
				{
					发包类.Write(2);
					发包类.Write(2);
					发包类.Write8(个人商店物品类2.物品.Get物品ID);
					发包类.Write8(个人商店物品类2.物品.Get物品全局ID);
					发包类.Write2(个人商店物品类2.数量);
					发包类.Write2(个人商店物品类2.位置);
					发包类.Write8(个人商店物品类2.价格);
					发包类.Write4(个人商店物品类2.物品.FLD_MAGIC0);
					发包类.Write4(个人商店物品类2.物品.FLD_MAGIC1);
					发包类.Write4(个人商店物品类2.物品.FLD_MAGIC2);
					发包类.Write4(个人商店物品类2.物品.FLD_MAGIC3);
					发包类.Write4(个人商店物品类2.物品.FLD_MAGIC4);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_MAGIC0);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_MAGIC1);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_中级附魂);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_MAGIC2);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_MAGIC3);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_MAGIC4);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_MAGIC5);
					发包类.Write2(0);
					发包类.Write4(个人商店物品类2.物品.FLD_KSSJ);
					发包类.Write4(个人商店物品类2.物品.FLD_JSSJ);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_NJ);
					发包类.Write4(个人商店物品类2.物品.FLD_FJ_觉醒);
					发包类.Write2(0);
					发包类.Write2(个人商店物品类2.物品.FLD_FJ_进化);
					发包类.Write2(0);
					发包类.Write4(个人商店物品类2.物品.FLD_FJ_四神之力);
					发包类.Write4(0);
					发包类.Write4(0);
					发包类.Write4(0);
					if (Player.Client != null)
					{
						Player.Client.SendPak(发包类, 52480, Player.人物全服ID);
					}
				}
				if (Player.是否灵兽((int)个人商店物品类2.物品.Get物品ID))
				{
					Player.发送灵兽数据((int)个人商店物品类2.物品.Get物品全局ID);
				}
				listBox1.Items.Clear();
				foreach (个人商店物品类 value in Player.个人商店.商店物品列表.Values)
				{
					listBox1.Items.Add(value.物品.Get物品全局ID);
				}
				listBox2.Items.Clear();
				物品类[] 装备栏包裹 = Player.装备栏包裹;
				物品类[] array = 装备栏包裹;
				物品类[] array2 = array;
				foreach (物品类 物品类2 in array2)
				{
					if (!物品类2.锁定 && 物品类2.Get物品全局ID != 0)
					{
						listBox2.Items.Add(物品类2.Get物品全局ID);
					}
				}
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				listBox2.Items.Clear();
				物品类[] 装备栏包裹 = Player.装备栏包裹;
				物品类[] array = 装备栏包裹;
				物品类[] array2 = array;
				foreach (物品类 物品类2 in array2)
				{
					if (!物品类2.锁定 && 物品类2.Get物品全局ID != 0)
					{
						listBox2.Items.Add(物品类2.Get物品全局ID);
					}
				}
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Player == null || listBox2.SelectedItem == null)
			{
				return;
			}
			int num = int.Parse(listBox2.SelectedItem.ToString());
			物品类[] 装备栏包裹 = Player.装备栏包裹;
			物品类[] array = 装备栏包裹;
			物品类[] array2 = array;
			foreach (物品类 物品类2 in array2)
			{
				if (物品类2.Get物品全局ID == num)
				{
					textBox16.Text = 物品类2.得到物品名称();
					textBox17.Text = 物品类2.物品位置.ToString();
					textBox18.Text = 物品类2.Get物品数量.ToString();
					textBox20.Text = 物品类2.Get物品全局ID.ToString();
					textBox21.Text = 物品类2.Get物品ID.ToString();
					textBox22.Text = 物品类2.FLD_MAGIC0.ToString();
					textBox23.Text = 物品类2.FLD_MAGIC1.ToString();
					textBox24.Text = 物品类2.FLD_MAGIC2.ToString();
					textBox25.Text = 物品类2.FLD_MAGIC3.ToString();
					textBox26.Text = 物品类2.FLD_MAGIC4.ToString();
				}
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				if (Player.个人商店 == null)
				{
					if (textBox27.Text.Length >= 4 && textBox27.Text.Length <= 16)
					{
						Player.开店(textBox27.Text);
					}
					else
					{
						label29.Text = "店名太短或者超长了";
					}
				}
				else if (Player.个人商店 != null && !Player.个人商店.个人商店是否开启)
				{
					Player.个人商店.个人商店是否开启 = true;
					byte[] array = Converter.hexStringToByte("AA5510000000CD0002000303000000000000000055AA");
					Buffer.BlockCopy(BitConverter.GetBytes(Player.人物全服ID), 0, array, 4, 2);
					if (Player.Client != null)
					{
						Player.Client.Send(array, array.Length);
					}
					string hex = "000000000000000055AA";
					byte[] array2 = Converter.hexStringToByte("AA5522000000CA0014000100000000000000000000000600");
					byte[] array3 = Converter.hexStringToByte(hex);
					byte[] array4 = new byte[array2.Length + array3.Length + Player.个人商店.商店名.Length];
					Buffer.BlockCopy(array2, 0, array4, 0, array2.Length);
					Buffer.BlockCopy(Player.个人商店.商店名, 0, array4, 24, Player.个人商店.商店名.Length);
					Buffer.BlockCopy(array3, 0, array4, array4.Length - array3.Length, array3.Length);
					array4[2] = (byte)(28 + Player.个人商店.商店名.Length);
					array4[9] = (byte)(14 + Player.个人商店.商店名.Length);
					array4[22] = (byte)Player.个人商店.商店名.Length;
					Buffer.BlockCopy(BitConverter.GetBytes(Player.人物全服ID), 0, array4, 14, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(Player.人物全服ID), 0, array4, 18, 4);
					Buffer.BlockCopy(BitConverter.GetBytes(Player.人物全服ID), 0, array4, 4, 2);
					Player.个人商店.个人商店是否开启 = true;
					if (Player.Client != null)
					{
						Player.Client.Send(array4, array4.Length);
					}
					Player.发送当前范围广播数据(array4, array4.Length);
					label29.Text = "已开店";
				}
				else if (Player.个人商店 != null && Player.个人商店.个人商店是否开启)
				{
					DialogResult dialogResult = MessageBox.Show("确定关闭商店吗?", "关店", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.OK)
					{
						Player.关店();
						label29.Text = "已关店";
					}
				}
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox15.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					DropClass drop = GetDrop(textBox15.Text);
					掉出物品(drop, Player);
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		public static DropClass GetDrop(string leve)
		{
			try
			{
				List<DropClass> list = new List<DropClass>();
				foreach (DropClass item in World.Drop)
				{
					if (item.FLD_NAME == leve)
					{
						list.Add(item);
					}
				}
				return (list.Count == 0) ? null : list[0];
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "GetDrop出错" + ex.Message);
				return null;
			}
		}

		public byte[] 掉出物品(DropClass drop, Players yxqname)
		{
			try
			{
				using (new Lock(AsyncLock, "死亡掉落"))
				{
					long dBItmeId = RxjhClass.GetDBItmeId();
					byte[] array = new byte[World.数据库单个物品大小];
					byte[] bytes = BitConverter.GetBytes(dBItmeId);
					byte[] array2 = new byte[20];
					if (!World.Itme.TryGetValue(drop.FLD_PID, out var value))
					{
						return null;
					}
					if (value.FLD_QUESTITEM == 1)
					{
						if (yxqname != null)
						{
							int num = yxqname.得到包裹空位(yxqname);
							if (num != -1)
							{
								yxqname.增加物品(bytes, BitConverter.GetBytes(drop.FLD_PID), num, BitConverter.GetBytes(1), new byte[20]);
							}
						}
						return null;
					}
					try
					{
						if (World.Droplog)
						{
							MainForm.WriteLine(4, "物品掉落--物品名:" + drop.FLD_NAME + " 属性1[" + drop.FLD_MAGIC0 + "]属性2[" + drop.FLD_MAGIC1 + "]属性3[" + drop.FLD_MAGIC2 + "]属性4[" + drop.FLD_MAGIC3 + "]属性5[" + drop.FLD_MAGIC4 + "]");
						}
						if (drop.是否开启公告 == 1)
						{
							string text = yxqname.UserName + "玩家的队伍在[" + FLD_Name + "]处获得了[" + drop.FLD_NAME + "]。";
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
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "掉出物品1 出错 " + FLD_PID + "|" + FLD_Name + " " + ex.Message);
						return null;
					}
					地面物品类 地面物品类2;
					地面物品类 value2;
					try
					{
						地面物品类2 = new 地面物品类(array, yxqname.人物坐标_X, yxqname.人物坐标_Y, yxqname.人物坐标_Z, yxqname.人物坐标_地图, yxqname, 0);
						if (地面物品类2 == null)
						{
							MainForm.WriteLine(1, "掉出物品2 出错 " + FLD_PID + "|" + FLD_Name);
							return null;
						}
						if (!World.ItemTemp.TryGetValue(dBItmeId, out value2))
						{
							World.ItemTemp.Add(dBItmeId, 地面物品类2);
						}
					}
					catch (Exception ex2)
					{
						MainForm.WriteLine(1, "掉出物品3 出错 " + FLD_PID + "|" + FLD_Name + " " + ex2.Message);
						return null;
					}
					try
					{
						if (World.ItemTemp.TryGetValue(dBItmeId, out value2))
						{
							地面物品类2.获取范围玩家发送地面增加物品数据包();
						}
						return array;
					}
					catch (Exception ex3)
					{
						MainForm.WriteLine(1, "掉出物品4 出错 " + FLD_PID + "|" + FLD_Name + " " + ex3.Message);
						return null;
					}
				}
			}
			catch (Exception ex4)
			{
				MainForm.WriteLine(1, "掉出物品5 出错 " + FLD_PID + "|" + FLD_Name + " " + ex4.Message);
				return null;
			}
			finally
			{
				drop.FLD_MAGIC0 = drop.FLD_MAGICNew0;
				drop.FLD_MAGIC1 = drop.FLD_MAGICNew1;
				drop.FLD_MAGIC2 = drop.FLD_MAGICNew2;
				drop.FLD_MAGIC3 = drop.FLD_MAGICNew3;
				drop.FLD_MAGIC4 = drop.FLD_MAGICNew4;
			}
		}

		private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			try
			{
				int num = int.Parse(textBox17.Text);
				if (Player == null || num <= 0)
				{
					return;
				}
				for (int i = 0; i < 96; i++)
				{
					if (i == num)
					{
						Player.装备栏包裹[i].物品_byte = new byte[37];
					}
				}
				Player.初始化装备篮包裹();
				Player.系统提示("清理完毕。", 50, "系统提示");
			}
			catch
			{
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				Player.累计充值 += int.Parse(textBox28.Text);
				if (Player.累计充值 <= 0)
				{
					Player.累计充值 = 0;
				}
				Player.SavePlayerData();
				MessageBox.Show("发送成功，人物当前:" + Player.累计充值);
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				if (Player.公有药品.ContainsKey(1008000060))
				{
					Player.公有药品.TryRemove(1008000060, out var _);
					TimeSpan timeSpan = DateTime.Now.AddDays(1.0).Subtract(new DateTime(1970, 1, 1, 8, 0, 0));
					公有药品类 公有药品类2 = new 公有药品类
					{
						药品ID = 1008000060,
						时间 = (uint)timeSpan.TotalSeconds
					};
					Player.公有药品.TryAdd(公有药品类2.药品ID, 公有药品类2);
					Player.set公有物品(公有药品类2);
					Player.保存综合仓库存储过程();
				}
				else
				{
					TimeSpan timeSpan2 = DateTime.Now.AddDays(1.0).Subtract(new DateTime(1970, 1, 1, 8, 0, 0));
					公有药品类 公有药品类3 = new 公有药品类
					{
						药品ID = 1008000060,
						时间 = (uint)timeSpan2.TotalSeconds
					};
					Player.公有药品.TryAdd(公有药品类3.药品ID, 公有药品类3);
					Player.set公有物品(公有药品类3);
					Player.保存综合仓库存储过程();
				}
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.Player_Job_leve = int.Parse(textBox29.Text);
					Player.系统提示("转职修改成功, 请小退后重上!", 9, "GM提示");
					MessageBox.Show("更改成功请小腿上线");
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		private void button17_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.Player_Zx = int.Parse(textBox30.Text);
					Player.系统提示("正邪修改成功, 请小退后重上!", 9, "GM提示");
					MessageBox.Show("更改成功请小腿上线");
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				Player.Player_WuXun += int.Parse(textBox31.Text);
				if (Player.Player_WuXun <= 0)
				{
					Player.Player_WuXun = 0;
				}
				Player.更新武功和状态();
				Player.系统提示("武勋增加" + int.Parse(textBox31.Text) + ".", 9, "GM提示");
				MessageBox.Show("已经发送游戏中查看");
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.CheckTreasureGems();
					Player.CheckGemPointsData(int.Parse(textBox32.Text), 1, "GM工具");
					Player.SaveGemData();
					MessageBox.Show("已经发送游戏中查看");
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendItem));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button13 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button24 = new System.Windows.Forms.Button();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.button21 = new System.Windows.Forms.Button();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.button20 = new System.Windows.Forms.Button();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.button17 = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "发送给";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(51, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(129, 21);
            this.textBox2.TabIndex = 53;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(371, 142);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 69;
            this.checkBox1.Text = "模拟公告";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(371, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 72;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(371, 56);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 73;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(371, 110);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 74;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(371, 242);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(82, 29);
            this.button13.TabIndex = 72;
            this.button13.Text = "掉落地面";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 356);
            this.tabControl1.TabIndex = 75;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "商店";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.textBox27);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.textBox16);
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Controls.Add(this.textBox17);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Controls.Add(this.textBox18);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.textBox19);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.textBox20);
            this.groupBox3.Controls.Add(this.textBox21);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.textBox22);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.textBox23);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.textBox24);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.textBox25);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.textBox26);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Location = new System.Drawing.Point(7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 318);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "商店管理";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(346, 255);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(82, 29);
            this.button12.TabIndex = 100;
            this.button12.Text = "删除物品";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.Red;
            this.label29.Location = new System.Drawing.Point(130, 290);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 99;
            this.label29.Text = "注意";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(235, 255);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(82, 29);
            this.button8.TabIndex = 94;
            this.button8.Text = "开店";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(323, 169);
            this.textBox27.MaxLength = 16;
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(105, 21);
            this.textBox27.TabIndex = 97;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(288, 173);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 12);
            this.label27.TabIndex = 96;
            this.label27.Text = "店名";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(124, 58);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 87;
            this.label24.Text = "背包位";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(106, 292);
            this.listBox1.TabIndex = 72;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(126, 207);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(82, 29);
            this.button9.TabIndex = 72;
            this.button9.Text = "查看商店";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(346, 207);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(82, 29);
            this.button11.TabIndex = 92;
            this.button11.Text = "查看背包";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(171, 28);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(105, 21);
            this.textBox16.TabIndex = 72;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(443, 19);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(106, 292);
            this.listBox2.TabIndex = 91;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(171, 55);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(105, 21);
            this.textBox17.TabIndex = 75;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(235, 207);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(82, 29);
            this.button10.TabIndex = 90;
            this.button10.Text = "添加物品";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(171, 82);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(105, 21);
            this.textBox18.TabIndex = 76;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(130, 114);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 89;
            this.label26.Text = "单价";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(171, 111);
            this.textBox19.MaxLength = 10;
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(105, 21);
            this.textBox19.TabIndex = 77;
            this.textBox19.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox19_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(130, 87);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 88;
            this.label25.Text = "数量";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(171, 138);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(105, 21);
            this.textBox20.TabIndex = 78;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(171, 168);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(105, 21);
            this.textBox21.TabIndex = 79;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(122, 31);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 86;
            this.label23.Text = "物品名";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(323, 28);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(105, 21);
            this.textBox22.TabIndex = 80;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(124, 141);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 85;
            this.label22.Text = "全局ID";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(323, 55);
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(105, 21);
            this.textBox23.TabIndex = 81;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(124, 173);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 72;
            this.label21.Text = "物品ID";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(323, 82);
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(105, 21);
            this.textBox24.TabIndex = 82;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(282, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 74;
            this.label18.Text = "属性5";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(323, 109);
            this.textBox25.Name = "textBox25";
            this.textBox25.ReadOnly = true;
            this.textBox25.Size = new System.Drawing.Size(105, 21);
            this.textBox25.TabIndex = 83;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(282, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 12);
            this.label17.TabIndex = 72;
            this.label17.Text = "属性2";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(323, 136);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(105, 21);
            this.textBox26.TabIndex = 84;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(282, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 73;
            this.label19.Text = "属性4";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(282, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 12);
            this.label16.TabIndex = 72;
            this.label16.Text = "属性1";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(282, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 12);
            this.label20.TabIndex = 72;
            this.label20.Text = "属性3";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "属性";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button24);
            this.groupBox2.Controls.Add(this.textBox35);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.button21);
            this.groupBox2.Controls.Add(this.textBox34);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.button20);
            this.groupBox2.Controls.Add(this.textBox33);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.button19);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.textBox32);
            this.groupBox2.Controls.Add(this.button18);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.textBox31);
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.textBox30);
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.textBox29);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.textBox28);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 321);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其他操作";
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(471, 257);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(82, 29);
            this.button24.TabIndex = 120;
            this.button24.Text = "发送";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(324, 261);
            this.textBox35.MaxLength = 10;
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new System.Drawing.Size(129, 21);
            this.textBox35.TabIndex = 119;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(285, 265);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 12);
            this.label36.TabIndex = 118;
            this.label36.Text = "职业";
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(471, 217);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(82, 29);
            this.button21.TabIndex = 117;
            this.button21.Text = "发送";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(324, 221);
            this.textBox34.MaxLength = 10;
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(129, 21);
            this.textBox34.TabIndex = 116;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(285, 225);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 12);
            this.label35.TabIndex = 115;
            this.label35.Text = "伤害";
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(471, 180);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(82, 29);
            this.button20.TabIndex = 114;
            this.button20.Text = "发送";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(324, 183);
            this.textBox33.MaxLength = 10;
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(129, 21);
            this.textBox33.TabIndex = 113;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(285, 186);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 112;
            this.label34.Text = "天机";
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(471, 145);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(82, 29);
            this.button19.TabIndex = 109;
            this.button19.Text = "发送";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(285, 152);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 110;
            this.label33.Text = "钻石";
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(324, 149);
            this.textBox32.MaxLength = 10;
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(129, 21);
            this.textBox32.TabIndex = 111;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(473, 103);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(82, 29);
            this.button18.TabIndex = 106;
            this.button18.Text = "发送";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(285, 110);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 12);
            this.label32.TabIndex = 107;
            this.label32.Text = "武勋";
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(326, 107);
            this.textBox31.MaxLength = 10;
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(129, 21);
            this.textBox31.TabIndex = 108;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(473, 62);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(82, 29);
            this.button17.TabIndex = 103;
            this.button17.Text = "发送";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(285, 69);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 12);
            this.label31.TabIndex = 104;
            this.label31.Text = "正邪";
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(326, 66);
            this.textBox30.MaxLength = 10;
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(129, 21);
            this.textBox30.TabIndex = 105;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(473, 22);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(82, 29);
            this.button16.TabIndex = 100;
            this.button16.Text = "发送";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(285, 29);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 101;
            this.label30.Text = "转职";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(326, 26);
            this.textBox29.MaxLength = 10;
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(129, 21);
            this.textBox29.TabIndex = 102;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(197, 256);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(82, 29);
            this.button14.TabIndex = 99;
            this.button14.Text = "发送";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(50, 261);
            this.textBox28.MaxLength = 10;
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(129, 21);
            this.textBox28.TabIndex = 98;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 265);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 12);
            this.label28.TabIndex = 97;
            this.label28.Text = "称号";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(197, 216);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 29);
            this.button7.TabIndex = 96;
            this.button7.Text = "发送";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(50, 221);
            this.textBox14.MaxLength = 2;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(129, 21);
            this.textBox14.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 68;
            this.label13.Text = "概率";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(197, 178);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 29);
            this.button6.TabIndex = 67;
            this.button6.Text = "发送";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(50, 182);
            this.textBox12.MaxLength = 10;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(129, 21);
            this.textBox12.TabIndex = 66;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 65;
            this.label12.Text = "元宝";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(197, 138);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 29);
            this.button5.TabIndex = 64;
            this.button5.Text = "发送";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(197, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 29);
            this.button4.TabIndex = 63;
            this.button4.Text = "发送";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 29);
            this.button3.TabIndex = 62;
            this.button3.Text = "发送";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 29);
            this.button2.TabIndex = 53;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "历练";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(50, 25);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(129, 21);
            this.textBox3.TabIndex = 55;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(50, 142);
            this.textBox11.MaxLength = 10;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(129, 21);
            this.textBox11.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 56;
            this.label4.Text = "经验";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 60;
            this.label7.Text = "金币";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(50, 61);
            this.textBox4.MaxLength = 10;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(129, 21);
            this.textBox4.TabIndex = 57;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(50, 103);
            this.textBox5.MaxLength = 3;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(129, 21);
            this.textBox5.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 58;
            this.label5.Text = "等级";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(568, 330);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "物品";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.textBox15);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.listBox3);
            this.groupBox1.Controls.Add(this.comboBox11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 318);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刷装备";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(161, 226);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 71;
            this.label15.Text = "掉落物品名";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(238, 221);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(93, 21);
            this.textBox15.TabIndex = 70;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(202, 56);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(129, 21);
            this.textBox13.TabIndex = 68;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(155, 32);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(41, 12);
            this.label40.TabIndex = 39;
            this.label40.Text = "物品名";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送背包";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "数量";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(202, 256);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 21);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "0";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(16, 19);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(121, 292);
            this.listBox3.TabIndex = 38;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // comboBox11
            // 
            this.comboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Items.AddRange(new object[] {
            "衣服",
            "护手",
            "鞋子",
            "武器",
            "内甲",
            "耳环",
            "项链",
            "戒指",
            "披风",
            "门甲",
            "宝宝",
            "弓箭",
            "石头",
            "其他"});
            this.comboBox11.Location = new System.Drawing.Point(202, 29);
            this.comboBox11.MaxDropDownItems = 20;
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(129, 20);
            this.comboBox11.TabIndex = 40;
            this.comboBox11.SelectedIndexChanged += new System.EventHandler(this.comboBox11_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(155, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "物品ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 43;
            this.label6.Text = "属性1";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(202, 83);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(129, 21);
            this.textBox6.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(161, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 52;
            this.label11.Text = "属性5";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(202, 110);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(129, 21);
            this.textBox7.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(161, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 51;
            this.label10.Text = "属性4";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(202, 137);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(129, 21);
            this.textBox8.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 50;
            this.label9.Text = "属性3";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(202, 164);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(129, 21);
            this.textBox9.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(161, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 49;
            this.label8.Text = "属性2";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(202, 191);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(129, 21);
            this.textBox10.TabIndex = 48;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(211, 7);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(82, 29);
            this.button15.TabIndex = 76;
            this.button15.Text = "是否在线";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(307, 7);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(82, 29);
            this.button22.TabIndex = 77;
            this.button22.Text = "在线转假人";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(407, 7);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(82, 29);
            this.button23.TabIndex = 78;
            this.button23.Text = "离线挂店";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // SendItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 403);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendItem";
            this.Text = "发送物品-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.SendItem_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void button20_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (Player != null)
			{
				Player.升天武功点数 += int.Parse(textBox33.Text);
				if (Player.升天武功点数 <= 0)
				{
					Player.升天武功点数 = 0;
				}
				Player.更新武功和状态();
				Player.SavePlayerData();
				MessageBox.Show("发送成功，人物当前:" + Player.升天武功点数);
			}
			else
			{
				MessageBox.Show("该玩家没有在线请重新输入");
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			if (int.Parse(textBox34.Text) != 0)
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.设置固定伤害 = int.Parse(textBox34.Text);
					MessageBox.Show("发送成功，当前对怪伤害:" + Player.设置固定伤害);
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
				return;
			}
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				value.设置固定伤害 = 0;
			}
			MessageBox.Show("发送成功，当前对怪伤害:" + Player.设置固定伤害);
		}

		private void button22_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				return;
			}
			Player = World.检查玩家name(textBox2.Text);
			if (!Player.进店中)
			{
				Player.离线挂机打怪模式 = 1;
				Player.自动挂机坐标X = (int)Player.人物坐标_X;
				Player.自动挂机坐标Y = (int)Player.人物坐标_Y;
				Player.自动挂机地图 = Player.人物坐标_地图;
				Player.离线挂机武功ID = Player.得到最高武功();
				Player.Client.假人 = true;
				if (Player.交易 != null && Player.交易.交易中)
				{
					Player.关闭交易(152, 0, 6);
				}
				Player.SaveGemData();
				Player.SavePlayerData();
				Player.Client.离线挂机();
				MainForm.WriteLine(3, "玩家自动打怪坐标X :" + Player.自动挂机坐标X + " 挂机坐标Y :" + Player.自动挂机坐标Y);
			}
			else
			{
				Player.系统提示("请先退出商店才能开启智能挂!", 10, "提示");
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player.进店中)
				{
					Player.系统提示("商店打开中不能使用离线挂机。", 50, "系统提示");
					return;
				}
				if (Player.交易 != null && Player.交易.交易中)
				{
					Player.系统提示("交易中不能使用离线挂机。", 50, "系统提示");
					return;
				}
				if (World.允许挂机 == 0)
				{
					Player.系统提示("本线不允许离线挂机。", 50, "系统提示");
					return;
				}
				if (Player.组队id != 0)
				{
					Player.系统提示("组队中, 不允许离线挂机。", 50, "系统提示");
					return;
				}
				World.conn.发送("离线挂机|" + Player.Userid);
				Player.保存人物数据存储过程();
				Player.Client.Offline();
			}
		}

		private void button24_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBox2.Text))
			{
				Player = World.检查玩家name(textBox2.Text);
				if (Player != null)
				{
					Player.Player_Job = int.Parse(textBox35.Text);
					Player.系统提示("成功修改职业, 请小退后重上!", 9, "GM提示");
					MessageBox.Show("更改成功请小腿上线");
				}
				else
				{
					MessageBox.Show("该玩家没有在线请重新输入");
				}
			}
		}
	}
}
