using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class NpcList : Form
	{
		private static ConcurrentDictionary<int, NpcClass> List = new ConcurrentDictionary<int, NpcClass>();

		private static List<int> mapLis = new List<int>();

		private ComboBox comboBox1;

		private Label label1;

		private Button button1;

		private GroupBox groupBox1;

		private TextBox textBox18;

		private Label label19;

		private TextBox textBox17;

		private Label label18;

		private TextBox textBox16;

		private Label label17;

		private TextBox textBox15;

		private Label label16;

		private TextBox textBox14;

		private Label label15;

		private TextBox textBox13;

		private Label label14;

		private TextBox textBox12;

		private Label label13;

		private TextBox textBox11;

		private Label label12;

		private TextBox textBox10;

		private Label label11;

		private TextBox textBox9;

		private Label label10;

		private TextBox textBox8;

		private Label label9;

		private TextBox textBox7;

		private Label label8;

		private TextBox textBox6;

		private Label label7;

		private TextBox textBox5;

		private Label label6;

		private TextBox textBox4;

		private Label label5;

		private TextBox textBox3;

		private Label label4;

		private TextBox textBox2;

		private Label label3;

		private TextBox textBox1;

		private Label label2;

		private Label label20;

		private ComboBox comboBox2;

		public NpcList()
		{
			InitializeComponent();
		}

		private void NpcList_Load(object sender, EventArgs e)
		{
			try
			{
				mapLis = new List<int>();
				List = new ConcurrentDictionary<int, NpcClass>();
				comboBox1.Items.Clear();
				comboBox2.Items.Clear();
				comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
				comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
				foreach (string value in World.Maplist.Values)
				{
					comboBox2.Items.Add(value);
				}
				foreach (NpcClass value2 in World.NpcList.Values)
				{
					try
					{
						List.TryAdd(value2.FLD_PID, value2);
						comboBox1.Items.Add(value2.Name);
					}
					catch
					{
						int num = (int)MessageBox.Show(value2.FLD_INDEX + "|" + value2.Name);
					}
				}
			}
			catch (Exception ex)
			{
				int num2 = (int)MessageBox.Show(ex.Message);
			}
		}

		private NpcClass 得到NPC(string name)
		{
			foreach (NpcClass value in List.Values)
			{
				if (value.Name == name)
				{
					return value;
				}
			}
			return null;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (comboBox2.SelectedItem.ToString().Contains("九泉之下"))
				{
					comboBox1.Items.Clear();
					foreach (NpcClass value in World.NpcList.Values)
					{
						try
						{
							if (value.Rxjh_Map >= 23001 && value.Rxjh_Map <= 24000)
							{
								comboBox1.Items.Add(value.Name);
							}
						}
						catch
						{
							int num = (int)MessageBox.Show(value.FLD_INDEX + "|" + value.Name);
						}
					}
					if (comboBox1.Items.Count <= 0)
					{
						comboBox1.Text = string.Empty;
						comboBox1.Items.Clear();
						int num2 = (int)MessageBox.Show("此地图没有怪物");
					}
					else
					{
						comboBox1.SelectedItem = comboBox1.Items[0];
					}
					return;
				}
				int num3 = 0;
				foreach (KeyValuePair<int, string> item in World.Maplist)
				{
					if (item.Value == comboBox2.SelectedItem.ToString())
					{
						num3 = item.Key;
					}
				}
				if (num3 != 0)
				{
					comboBox1.Items.Clear();
					foreach (NpcClass value2 in World.NpcList.Values)
					{
						try
						{
							if (value2.Rxjh_Map == num3)
							{
								comboBox1.Items.Add(value2.Name);
							}
						}
						catch
						{
							int num4 = (int)MessageBox.Show(value2.FLD_INDEX + "|" + value2.Name);
						}
					}
					if (comboBox1.Items.Count <= 0)
					{
						comboBox1.Text = string.Empty;
						comboBox1.Items.Clear();
						int num5 = (int)MessageBox.Show("此地图没有怪物");
					}
					else
					{
						comboBox1.SelectedItem = comboBox1.Items[0];
					}
				}
				else
				{
					int num6 = (int)MessageBox.Show("无此地图");
				}
			}
			catch (Exception ex)
			{
				int num7 = (int)MessageBox.Show("错误:" + ex.Message);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				NpcClass npcClass = 得到NPC(comboBox1.SelectedItem.ToString());
				string empty = string.Empty;
				if (npcClass != null)
				{
					textBox1.Text = npcClass.FLD_INDEX.ToString();
					this.textBox2.Text = npcClass.FLD_PID.ToString();
					this.textBox3.Text = npcClass.X.ToString();
					this.textBox4.Text = npcClass.Z.ToString();
					this.textBox5.Text = npcClass.Y.ToString();
					this.textBox6.Text = npcClass.Name;
					this.textBox7.Text = npcClass.FLD_FACE1.ToString();
					this.textBox8.Text = npcClass.FLD_FACE2.ToString();
					textBox9.Text = npcClass.Rxjh_Map.ToString();
					textBox10.Text = npcClass.Level.ToString();
					TextBox textBox = textBox11;
					string text21 = (textBox.Text = ((!World.MonSter.TryGetValue(npcClass.FLD_PID, out var value)) ? npcClass.Rxjh_HP.ToString() : value.Rxjh_HP.ToString()));
					string text15 = text21;
					string text16 = text15;
					TextBox textBox2 = textBox12;
					text21 = (textBox2.Text = npcClass.FLD_AT.ToString());
					text15 = text21;
					string text17 = text15;
					TextBox textBox3 = textBox13;
					text21 = (textBox3.Text = npcClass.FLD_DF.ToString());
					text15 = text21;
					string text18 = text15;
					TextBox textBox4 = textBox14;
					text21 = (textBox4.Text = npcClass.IsNpc.ToString());
					text15 = text21;
					string text19 = text15;
					TextBox textBox5 = textBox15;
					text21 = (textBox5.Text = npcClass.FLD_NEWTIME.ToString());
					text15 = text21;
					string text11 = text15;
					TextBox textBox6 = textBox16;
					text21 = (textBox6.Text = npcClass.Rxjh_Exp.ToString());
					text15 = text21;
					string text12 = text15;
					TextBox textBox7 = textBox17;
					text21 = (textBox7.Text = npcClass.FLD_AUTO.ToString());
					text15 = text21;
					string text13 = text15;
					TextBox textBox8 = textBox18;
					text21 = (textBox8.Text = npcClass.FLD_BOSS.ToString());
					text15 = text21;
					string text14 = text15;
				}
			}
			catch (Exception ex)
			{
				int num = (int)MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (comboBox1.Text.Length != 0 && textBox1.Text.Length != 0 && textBox9.Text.Length != 0 && textBox2.Text.Length != 0 && textBox10.Text.Length != 0 && textBox11.Text.Length != 0 && textBox12.Text.Length != 0 && textBox13.Text.Length != 0 && textBox16.Text.Length != 0 && textBox17.Text.Length != 0 && textBox18.Text.Length != 0)
				{
					更新NPC数据(int.Parse(textBox9.Text), int.Parse(textBox2.Text), int.Parse(textBox10.Text), int.Parse(textBox11.Text), int.Parse(textBox12.Text), int.Parse(textBox13.Text), int.Parse(textBox16.Text), int.Parse(textBox17.Text), int.Parse(textBox18.Text));
				}
			}
			catch (Exception ex)
			{
				int num = (int)MessageBox.Show(ex.Message);
			}
		}

		private void 更新NPC数据(int MID, int PID, int LEVEL, int HP, int AT, int DF, int EXP, int AUTO, int BOSS)
		{
			try
			{
				bool flag = false;
				MapClass value2;
				if (MID >= 23000 && MID <= 24000)
				{
					for (int i = 23000; i < 24001; i++)
					{
						if (!World.Map.TryGetValue(i, out var value))
						{
							continue;
						}
						foreach (NpcClass value3 in value.npcTemplate.Values)
						{
							if (value3.FLD_PID == PID)
							{
								value3.Level = LEVEL;
								value3.Max_Rxjh_HP = HP;
								value3.Rxjh_HP = HP;
								value3.FLD_AT = AT;
								value3.FLD_DF = DF;
								value3.Rxjh_Exp = EXP;
								value3.FLD_AUTO = AUTO;
								value3.FLD_BOSS = BOSS;
								flag = true;
							}
						}
					}
				}
				else if (World.Map.TryGetValue(MID, out value2))
				{
					foreach (NpcClass value4 in value2.npcTemplate.Values)
					{
						if (value4.FLD_PID == PID)
						{
							value4.Level = LEVEL;
							value4.Max_Rxjh_HP = HP;
							value4.Rxjh_HP = HP;
							value4.FLD_AT = AT;
							value4.FLD_DF = DF;
							value4.Rxjh_Exp = EXP;
							value4.FLD_AUTO = AUTO;
							value4.FLD_BOSS = BOSS;
							flag = true;
						}
					}
				}
				if (flag)
				{
					if (DBA.ExeSqlCommand(string.Format("UPDATE TBL_XWWL_MONSTER SET FLD_LEVEL={1}, FLD_HP={2}, FLD_AT={3}, FLD_DF={4}, FLD_EXP={5}, FLD_AUTO={6}, FLD_BOSS={7} WHERE FLD_PID={0}", PID, LEVEL, HP, AT, DF, EXP, AUTO, BOSS), "PublicDb") != -1)
					{
						int num = (int)MessageBox.Show("更新成功");
					}
				}
				else
				{
					int num2 = (int)MessageBox.Show("更新失败, 请检查怪物是否存在");
				}
			}
			catch (Exception ex)
			{
				int num3 = (int)MessageBox.Show(ex.Message);
			}
		}

		private void NpcList_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (mapLis != null)
			{
				mapLis.Clear();
				mapLis = null;
			}
			if (List != null)
			{
				List.Clear();
				List = null;
			}
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcList));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(172, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(114, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.textBox17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.textBox16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBox14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 289);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "详细";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(213, 245);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(90, 21);
            this.textBox18.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(178, 248);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 34;
            this.label19.Text = "BOSS:";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(213, 218);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(90, 21);
            this.textBox17.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(178, 221);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 32;
            this.label18.Text = "AUTO:";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(213, 191);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(90, 21);
            this.textBox16.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(184, 194);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 30;
            this.label17.Text = "EXP:";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(213, 164);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(90, 21);
            this.textBox15.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(178, 167);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 12);
            this.label16.TabIndex = 28;
            this.label16.Text = "TIME:";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(213, 137);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(90, 21);
            this.textBox14.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(184, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 26;
            this.label15.Text = "NPC:";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(213, 110);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(90, 21);
            this.textBox13.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(190, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "DF:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(213, 83);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(90, 21);
            this.textBox12.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(190, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "AT:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(213, 56);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(90, 21);
            this.textBox11.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(190, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "HP:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(213, 29);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(90, 21);
            this.textBox10.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(172, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "LEVEL:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(57, 245);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(90, 21);
            this.textBox9.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "MID:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(57, 218);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(90, 21);
            this.textBox8.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "FACE2:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(57, 191);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(90, 21);
            this.textBox7.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "FACE1:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(57, 164);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(90, 21);
            this.textBox6.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "NAME:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(57, 137);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(90, 21);
            this.textBox5.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Y:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(57, 110);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(90, 21);
            this.textBox4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Z:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(57, 83);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(90, 21);
            this.textBox3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "X:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(57, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(90, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "PID:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "INDEX:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 14);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 12);
            this.label20.TabIndex = 36;
            this.label20.Text = "地图:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(35, 11);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(101, 20);
            this.comboBox2.TabIndex = 36;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // NpcList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 341);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NpcList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NpcList-源多多资源网-yuandd.Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NpcList_FormClosing);
            this.Load += new System.EventHandler(this.NpcList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
