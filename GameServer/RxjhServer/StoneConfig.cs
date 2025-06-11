using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class StoneConfig : Form
	{
		private Label label22;

		private Label label21;

		private Label label20;

		private Label label19;

		private Label label18;

		private Label label17;

		private Label label16;

		private Label label15;

		private TextBox textBox12;

		private Button button1;

		private TextBox textBox13;

		private TextBox textBox14;

		private TextBox textBox15;

		private TextBox textBox16;

		private TextBox textBox17;

		private TextBox textBox18;

		private TextBox textBox19;

		private GroupBox groupBox2;

		private Label label1;

		private TextBox textBox2;

		private TextBox textBox1;

		private Label label2;

		private TextBox textBox3;

		private Label label3;

		private TextBox textBox44;

		private Label label44;

		private TextBox textBox33;

		private TextBox textBox34;

		private Label label32;

		private Label label33;

		private TextBox textBox10;

		private TextBox textBox11;

		private Label label10;

		private Label label11;

		private TextBox textBox8;

		private TextBox textBox9;

		private Label label8;

		private Label label9;

		private TextBox textBox6;

		private TextBox textBox7;

		private Label label6;

		private Label label7;

		private TextBox textBox4;

		private TextBox textBox5;

		private Label label4;

		private Label label5;

		private TextBox textBox26;

		private TextBox textBox27;

		private Label label26;

		private Label label27;

		private TextBox textBox28;

		private TextBox textBox29;

		private Label label28;

		private Label label29;

		private TextBox textBox30;

		private TextBox textBox31;

		private Label label30;

		private Label label31;

		private TextBox textBox20;

		private TextBox textBox21;

		private Label label12;

		private Label label13;

		private TextBox textBox22;

		private TextBox textBox23;

		private Label label14;

		private Label label23;

		private TextBox textBox24;

		private TextBox textBox25;

		private Label label24;

		private Label label25;

		public StoneConfig()
		{
			InitializeComponent();
		}

		private void 设置()
		{
			World.wf100 = int.Parse(textBox1.Text);
			World.wf95 = int.Parse(textBox3.Text);
			World.wf90 = int.Parse(textBox2.Text);
			World.wf85 = int.Parse(textBox12.Text);
			World.wf80 = int.Parse(textBox13.Text);
			World.wf78 = int.Parse(textBox14.Text);
			World.wf76 = int.Parse(textBox15.Text);
			World.wf74 = int.Parse(textBox16.Text);
			World.wf72 = int.Parse(textBox17.Text);
			World.wf70 = int.Parse(textBox18.Text);
			World.wf68 = int.Parse(textBox19.Text);
			World.wg35 = int.Parse(textBox5.Text);
			World.wg34 = int.Parse(textBox4.Text);
			World.wg33 = int.Parse(textBox7.Text);
			World.wg32 = int.Parse(textBox6.Text);
			World.wg31 = int.Parse(textBox9.Text);
			World.wg30 = int.Parse(textBox8.Text);
			World.wg29 = int.Parse(textBox11.Text);
			World.wg28 = int.Parse(textBox10.Text);
			World.wg27 = int.Parse(textBox44.Text);
			World.wg26 = int.Parse(textBox34.Text);
			World.wg25 = int.Parse(textBox33.Text);
			World.g25 = int.Parse(textBox25.Text);
			World.g24 = int.Parse(textBox24.Text);
			World.g23 = int.Parse(textBox23.Text);
			World.g22 = int.Parse(textBox22.Text);
			World.g21 = int.Parse(textBox21.Text);
			World.g20 = int.Parse(textBox20.Text);
			World.f15 = int.Parse(textBox31.Text);
			World.f14 = int.Parse(textBox30.Text);
			World.f13 = int.Parse(textBox29.Text);
			World.f12 = int.Parse(textBox28.Text);
			World.f11 = int.Parse(textBox27.Text);
			World.f10 = int.Parse(textBox26.Text);
		}

		private int 写数据(int type, int value, int 增减)
		{
			string sqlCommand = $"UPDATE TBL_XWWL_STONE SET FLD_增减={增减} WHERE FLD_TYPE={type} and FLD_VALUE={value}";
			try
			{
				if (DBA.ExeSqlCommand(sqlCommand, "PublicDb") == -1)
				{
					int num = (int)MessageBox.Show("写入表错误0, 请检查|" + type + "|" + value + "|" + 增减);
					return -1;
				}
			}
			catch
			{
				int num2 = (int)MessageBox.Show("写入表错误1, 请检查|" + type + "|" + value + "|" + 增减);
			}
			return -1;
		}

		private void 写入()
		{
			写数据(11, 100, int.Parse(textBox1.Text));
			Thread.Sleep(2);
			写数据(11, 95, int.Parse(textBox3.Text));
			Thread.Sleep(2);
			写数据(11, 90, int.Parse(textBox2.Text));
			Thread.Sleep(2);
			写数据(11, 85, int.Parse(textBox12.Text));
			Thread.Sleep(2);
			写数据(11, 80, int.Parse(textBox13.Text));
			Thread.Sleep(2);
			写数据(11, 78, int.Parse(textBox14.Text));
			Thread.Sleep(2);
			写数据(11, 76, int.Parse(textBox15.Text));
			Thread.Sleep(2);
			写数据(11, 74, int.Parse(textBox16.Text));
			Thread.Sleep(2);
			写数据(11, 72, int.Parse(textBox17.Text));
			Thread.Sleep(2);
			写数据(11, 70, int.Parse(textBox18.Text));
			Thread.Sleep(2);
			写数据(11, 68, int.Parse(textBox19.Text));
			Thread.Sleep(2);
			写数据(7, 35, int.Parse(textBox5.Text));
			Thread.Sleep(2);
			写数据(7, 34, int.Parse(textBox4.Text));
			Thread.Sleep(2);
			写数据(7, 33, int.Parse(textBox7.Text));
			Thread.Sleep(2);
			写数据(7, 32, int.Parse(textBox6.Text));
			Thread.Sleep(2);
			写数据(7, 31, int.Parse(textBox9.Text));
			Thread.Sleep(2);
			写数据(7, 30, int.Parse(textBox8.Text));
			Thread.Sleep(2);
			写数据(7, 29, int.Parse(textBox11.Text));
			Thread.Sleep(2);
			写数据(7, 28, int.Parse(textBox10.Text));
			Thread.Sleep(2);
			写数据(7, 27, int.Parse(textBox44.Text));
			Thread.Sleep(2);
			写数据(7, 26, int.Parse(textBox34.Text));
			Thread.Sleep(2);
			写数据(7, 25, int.Parse(textBox33.Text));
			Thread.Sleep(2);
			写数据(1, 25, int.Parse(textBox25.Text));
			Thread.Sleep(2);
			写数据(1, 24, int.Parse(textBox24.Text));
			Thread.Sleep(2);
			写数据(1, 23, int.Parse(textBox23.Text));
			Thread.Sleep(2);
			写数据(1, 22, int.Parse(textBox22.Text));
			Thread.Sleep(2);
			写数据(1, 21, int.Parse(textBox21.Text));
			Thread.Sleep(2);
			写数据(1, 20, int.Parse(textBox20.Text));
			Thread.Sleep(2);
			写数据(2, 15, int.Parse(textBox31.Text));
			Thread.Sleep(2);
			写数据(2, 14, int.Parse(textBox30.Text));
			Thread.Sleep(2);
			写数据(2, 13, int.Parse(textBox29.Text));
			Thread.Sleep(2);
			写数据(2, 12, int.Parse(textBox28.Text));
			Thread.Sleep(2);
			写数据(2, 11, int.Parse(textBox27.Text));
			Thread.Sleep(2);
			写数据(2, 10, int.Parse(textBox26.Text));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				设置();
				写入();
				Close();
			}
			catch
			{
				int num = (int)MessageBox.Show("输入错误, 请检查!");
			}
		}

		private void 读取()
		{
			textBox1.Text = World.wf100.ToString();
			textBox3.Text = World.wf95.ToString();
			textBox2.Text = World.wf90.ToString();
			textBox12.Text = World.wf85.ToString();
			textBox13.Text = World.wf80.ToString();
			textBox14.Text = World.wf78.ToString();
			textBox15.Text = World.wf76.ToString();
			textBox16.Text = World.wf74.ToString();
			textBox17.Text = World.wf72.ToString();
			textBox18.Text = World.wf70.ToString();
			textBox19.Text = World.wf68.ToString();
			textBox5.Text = World.wg35.ToString();
			textBox4.Text = World.wg34.ToString();
			textBox7.Text = World.wg33.ToString();
			textBox6.Text = World.wg32.ToString();
			textBox9.Text = World.wg31.ToString();
			textBox8.Text = World.wg30.ToString();
			textBox11.Text = World.wg29.ToString();
			textBox10.Text = World.wg28.ToString();
			textBox44.Text = World.wg27.ToString();
			textBox34.Text = World.wg26.ToString();
			textBox33.Text = World.wg25.ToString();
			textBox25.Text = World.g25.ToString();
			textBox24.Text = World.g24.ToString();
			textBox23.Text = World.g23.ToString();
			textBox22.Text = World.g22.ToString();
			textBox21.Text = World.g21.ToString();
			textBox20.Text = World.g20.ToString();
			textBox31.Text = World.f15.ToString();
			textBox30.Text = World.f14.ToString();
			textBox29.Text = World.f13.ToString();
			textBox28.Text = World.f12.ToString();
			textBox27.Text = World.f11.ToString();
			textBox26.Text = World.f10.ToString();
		}

		private void StoneConfig_Load(object sender, EventArgs e)
		{
			读取();
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoneConfig));
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(23, 103);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 11;
            this.label22.Text = "WF85";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 12;
            this.label21.Text = "WF80";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 153);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 13;
            this.label20.Text = "WF78";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 178);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 14;
            this.label19.Text = "WF76";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 203);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 15;
            this.label18.Text = "WF74";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 228);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 16;
            this.label17.Text = "WF72";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 253);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 17;
            this.label16.Text = "WF70";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 278);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 18;
            this.label15.Text = "WF68";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(58, 100);
            this.textBox12.MaxLength = 3;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(50, 21);
            this.textBox12.TabIndex = 19;
            this.textBox12.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 29);
            this.button1.TabIndex = 53;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(58, 125);
            this.textBox13.MaxLength = 3;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(50, 21);
            this.textBox13.TabIndex = 54;
            this.textBox13.Text = "0";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(58, 150);
            this.textBox14.MaxLength = 3;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(50, 21);
            this.textBox14.TabIndex = 55;
            this.textBox14.Text = "0";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(58, 175);
            this.textBox15.MaxLength = 3;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(50, 21);
            this.textBox15.TabIndex = 56;
            this.textBox15.Text = "0";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(58, 200);
            this.textBox16.MaxLength = 3;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(50, 21);
            this.textBox16.TabIndex = 57;
            this.textBox16.Text = "0";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(58, 225);
            this.textBox17.MaxLength = 3;
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(50, 21);
            this.textBox17.TabIndex = 58;
            this.textBox17.Text = "0";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(58, 250);
            this.textBox18.MaxLength = 3;
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(50, 21);
            this.textBox18.TabIndex = 59;
            this.textBox18.Text = "0";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(58, 275);
            this.textBox19.MaxLength = 3;
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(50, 21);
            this.textBox19.TabIndex = 60;
            this.textBox19.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox26);
            this.groupBox2.Controls.Add(this.textBox27);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.textBox28);
            this.groupBox2.Controls.Add(this.textBox29);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.textBox30);
            this.groupBox2.Controls.Add(this.textBox31);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.textBox20);
            this.groupBox2.Controls.Add(this.textBox21);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.textBox22);
            this.groupBox2.Controls.Add(this.textBox23);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.textBox24);
            this.groupBox2.Controls.Add(this.textBox25);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.textBox44);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.textBox33);
            this.groupBox2.Controls.Add(this.textBox34);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox19);
            this.groupBox2.Controls.Add(this.textBox18);
            this.groupBox2.Controls.Add(this.textBox17);
            this.groupBox2.Controls.Add(this.textBox16);
            this.groupBox2.Controls.Add(this.textBox15);
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.textBox13);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 362);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(279, 300);
            this.textBox26.MaxLength = 3;
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(50, 21);
            this.textBox26.TabIndex = 142;
            this.textBox26.Text = "0";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(279, 275);
            this.textBox27.MaxLength = 3;
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(50, 21);
            this.textBox27.TabIndex = 141;
            this.textBox27.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(244, 303);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(23, 12);
            this.label26.TabIndex = 140;
            this.label26.Text = "F10";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(244, 278);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(23, 12);
            this.label27.TabIndex = 139;
            this.label27.Text = "F11";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(279, 250);
            this.textBox28.MaxLength = 3;
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(50, 21);
            this.textBox28.TabIndex = 138;
            this.textBox28.Text = "0";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(279, 225);
            this.textBox29.MaxLength = 3;
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(50, 21);
            this.textBox29.TabIndex = 137;
            this.textBox29.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(244, 253);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 12);
            this.label28.TabIndex = 136;
            this.label28.Text = "F12";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(244, 228);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 12);
            this.label29.TabIndex = 135;
            this.label29.Text = "F13";
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(279, 200);
            this.textBox30.MaxLength = 3;
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(50, 21);
            this.textBox30.TabIndex = 134;
            this.textBox30.Text = "0";
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(279, 175);
            this.textBox31.MaxLength = 3;
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(50, 21);
            this.textBox31.TabIndex = 133;
            this.textBox31.Text = "0";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(244, 203);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(23, 12);
            this.label30.TabIndex = 132;
            this.label30.Text = "F14";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(244, 178);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 12);
            this.label31.TabIndex = 131;
            this.label31.Text = "F15";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(279, 150);
            this.textBox20.MaxLength = 3;
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(50, 21);
            this.textBox20.TabIndex = 130;
            this.textBox20.Text = "0";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(279, 125);
            this.textBox21.MaxLength = 3;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(50, 21);
            this.textBox21.TabIndex = 129;
            this.textBox21.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(244, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 128;
            this.label12.Text = "G20";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(244, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 127;
            this.label13.Text = "G21";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(279, 100);
            this.textBox22.MaxLength = 3;
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(50, 21);
            this.textBox22.TabIndex = 126;
            this.textBox22.Text = "0";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(279, 75);
            this.textBox23.MaxLength = 3;
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(50, 21);
            this.textBox23.TabIndex = 125;
            this.textBox23.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(244, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 12);
            this.label14.TabIndex = 124;
            this.label14.Text = "G22";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(244, 78);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(23, 12);
            this.label23.TabIndex = 123;
            this.label23.Text = "G23";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(279, 50);
            this.textBox24.MaxLength = 3;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(50, 21);
            this.textBox24.TabIndex = 122;
            this.textBox24.Text = "0";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(279, 25);
            this.textBox25.MaxLength = 3;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(50, 21);
            this.textBox25.TabIndex = 121;
            this.textBox25.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(244, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(23, 12);
            this.label24.TabIndex = 120;
            this.label24.Text = "G24";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(244, 28);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(23, 12);
            this.label25.TabIndex = 119;
            this.label25.Text = "G25";
            // 
            // textBox44
            // 
            this.textBox44.Location = new System.Drawing.Point(168, 225);
            this.textBox44.MaxLength = 3;
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new System.Drawing.Size(50, 21);
            this.textBox44.TabIndex = 118;
            this.textBox44.Text = "0";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(133, 228);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(29, 12);
            this.label44.TabIndex = 116;
            this.label44.Text = "WG27";
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(168, 275);
            this.textBox33.MaxLength = 3;
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(50, 21);
            this.textBox33.TabIndex = 99;
            this.textBox33.Text = "0";
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(168, 250);
            this.textBox34.MaxLength = 3;
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(50, 21);
            this.textBox34.TabIndex = 98;
            this.textBox34.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(133, 278);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 12);
            this.label32.TabIndex = 97;
            this.label32.Text = "WG25";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(133, 253);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 96;
            this.label33.Text = "WG26";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(168, 200);
            this.textBox10.MaxLength = 3;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(50, 21);
            this.textBox10.TabIndex = 95;
            this.textBox10.Text = "0";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(168, 175);
            this.textBox11.MaxLength = 3;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(50, 21);
            this.textBox11.TabIndex = 94;
            this.textBox11.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(133, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 93;
            this.label10.Text = "WG28";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(133, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 92;
            this.label11.Text = "WG29";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(168, 150);
            this.textBox8.MaxLength = 3;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(50, 21);
            this.textBox8.TabIndex = 91;
            this.textBox8.Text = "0";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(168, 125);
            this.textBox9.MaxLength = 3;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(50, 21);
            this.textBox9.TabIndex = 90;
            this.textBox9.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 89;
            this.label8.Text = "WG30";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(133, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 88;
            this.label9.Text = "WG31";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(168, 100);
            this.textBox6.MaxLength = 3;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(50, 21);
            this.textBox6.TabIndex = 87;
            this.textBox6.Text = "0";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(168, 75);
            this.textBox7.MaxLength = 3;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(50, 21);
            this.textBox7.TabIndex = 86;
            this.textBox7.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 85;
            this.label6.Text = "WG32";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 84;
            this.label7.Text = "WG33";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(168, 50);
            this.textBox4.MaxLength = 3;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(50, 21);
            this.textBox4.TabIndex = 83;
            this.textBox4.Text = "0";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(168, 25);
            this.textBox5.MaxLength = 3;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(50, 21);
            this.textBox5.TabIndex = 82;
            this.textBox5.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "WG34";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 80;
            this.label5.Text = "WG35";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(58, 50);
            this.textBox3.MaxLength = 3;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(50, 21);
            this.textBox3.TabIndex = 79;
            this.textBox3.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 78;
            this.label3.Text = "WF95";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(58, 75);
            this.textBox2.MaxLength = 3;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(50, 21);
            this.textBox2.TabIndex = 77;
            this.textBox2.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 25);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 21);
            this.textBox1.TabIndex = 76;
            this.textBox1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 75;
            this.label2.Text = "WF90";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 74;
            this.label1.Text = "WF100";
            // 
            // StoneConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 386);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StoneConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "石头设置-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.StoneConfig_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
