using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class Move : Form
	{
		private readonly IContainer icontainer_0;

		private GroupBox groupBox1;

		private Button button1;

		private Label label3;

		private Label label2;

		private Label label1;

		private NumericUpDown numericUpDown3;

		private NumericUpDown numericUpDown2;

		private NumericUpDown numericUpDown1;

		private GroupBox groupBox2;

		private NumericUpDown numericUpDown4;

		private NumericUpDown numericUpDown5;

		private NumericUpDown numericUpDown6;

		private Label label4;

		private Label label5;

		private Label ajTpidKifm;

		private NumericUpDown numericUpDown7;

		private Label label7;

		private CheckBox checkBox1;

		private GroupBox groupBox3;

		private NumericUpDown numericUpDown8;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripStatusLabel tishi;

		private NumericUpDown numericUpDown9;

		private Label label8;

		private GroupBox groupBox4;

		private NumericUpDown numericUpDown10;

		private GroupBox groupBox5;

		private NumericUpDown numericUpDown11;

		private Label label11;

		private Label NnAphShyEh;

		private CheckBox checkBox2;

		private CheckBox checkBox3;

		private Label label9;

		public Move()
		{
			icontainer_0 = null;
			InitializeComponent();
		}

		private void numericUpDown8_ValueChanged(object sender, EventArgs e)
		{
			if (!button1.Enabled)
			{
				button1.Enabled = true;
			}
		}

		private void Move_Load(object sender, EventArgs e)
		{
			try
			{
				if (World.是否开启实时坐标显示 == 1)
				{
					checkBox1.Checked = true;
				}
				else
				{
					checkBox1.Checked = false;
				}
				if (World.开启实时坐标检测 == 1)
				{
					checkBox2.Checked = true;
				}
				else
				{
					checkBox2.Checked = false;
				}
				if (World.移动坐标异常后反弹 == 1)
				{
					checkBox3.Checked = true;
				}
				else
				{
					checkBox3.Checked = false;
				}
				numericUpDown6.Value = decimal.Parse(World.宠物普通走.ToString());
				numericUpDown1.Value = decimal.Parse(World.普通走.ToString());
				numericUpDown2.Value = decimal.Parse(World.轻功一.ToString());
				numericUpDown3.Value = decimal.Parse(World.轻功二.ToString());
				numericUpDown9.Value = decimal.Parse(World.轻功三.ToString());
				numericUpDown5.Value = decimal.Parse(World.韩轻功一.ToString());
				numericUpDown4.Value = decimal.Parse(World.韩轻功二.ToString());
				numericUpDown7.Value = decimal.Parse(World.韩轻功三.ToString());
				numericUpDown11.Value = decimal.Parse(World.韩轻功四.ToString());
				numericUpDown8.Value = decimal.Parse(World.实时检测距离.ToString());
				numericUpDown10.Value = decimal.Parse(World.实时移动时间.ToString());
			}
			catch
			{
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				World.普通走 = float.Parse(numericUpDown1.Value.ToString());
				World.轻功一 = float.Parse(numericUpDown2.Value.ToString());
				World.轻功二 = float.Parse(numericUpDown3.Value.ToString());
				World.轻功三 = float.Parse(numericUpDown9.Value.ToString());
				World.实时移动时间 = int.Parse(numericUpDown10.Value.ToString());
				World.宠物普通走 = float.Parse(numericUpDown6.Value.ToString());
				World.韩轻功一 = float.Parse(numericUpDown5.Value.ToString());
				World.韩轻功二 = float.Parse(numericUpDown4.Value.ToString());
				World.韩轻功三 = float.Parse(numericUpDown7.Value.ToString());
				World.韩轻功四 = float.Parse(numericUpDown11.Value.ToString());
				World.实时检测距离 = int.Parse(numericUpDown8.Value.ToString());
				if (checkBox1.Checked)
				{
					Config.IniWriteValue("GameServer", "是否开启实时坐标显示", "1");
					World.是否开启实时坐标显示 = 1;
				}
				else
				{
					Config.IniWriteValue("GameServer", "是否开启实时坐标显示", "0");
					World.是否开启实时坐标显示 = 0;
				}
				if (checkBox2.Checked)
				{
					World.开启实时坐标检测 = 1;
					Config.IniWriteValue("GameServer", "开启实时坐标检测", "1");
				}
				else
				{
					World.开启实时坐标检测 = 0;
					Config.IniWriteValue("GameServer", "开启实时坐标检测", "0");
				}
				if (checkBox3.Checked)
				{
					World.移动坐标异常后反弹 = 1;
					Config.IniWriteValue("GameServer", "移动坐标异常后反弹", "1");
				}
				else
				{
					World.移动坐标异常后反弹 = 0;
					Config.IniWriteValue("GameServer", "移动坐标异常后反弹", "0");
				}
				Config.IniWriteValue("GameServer", "普通走", numericUpDown1.Value.ToString());
				Config.IniWriteValue("GameServer", "轻功一", numericUpDown2.Value.ToString());
				Config.IniWriteValue("GameServer", "轻功二", numericUpDown3.Value.ToString());
				Config.IniWriteValue("GameServer", "轻功三", numericUpDown9.Value.ToString());
				Config.IniWriteValue("GameServer", "实时移动时间", numericUpDown10.Value.ToString());
				Config.IniWriteValue("GameServer", "实时检测距离", numericUpDown8.Value.ToString());
				Config.IniWriteValue("GameServer", "宠物普通走", numericUpDown6.Value.ToString());
				Config.IniWriteValue("GameServer", "韩轻功一", numericUpDown5.Value.ToString());
				Config.IniWriteValue("GameServer", "韩轻功二", numericUpDown4.Value.ToString());
				Config.IniWriteValue("GameServer", "韩轻功三", numericUpDown7.Value.ToString());
				Config.IniWriteValue("GameServer", "韩轻功四", numericUpDown11.Value.ToString());
				tishi.Text = "保存加载成功！";
			}
			catch
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Move));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ajTpidKifm = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tishi = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.NnAphShyEh = new System.Windows.Forms.Label();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人物移动参数";
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.DecimalPlaces = 2;
            this.numericUpDown9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown9.Location = new System.Drawing.Point(64, 118);
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown9.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "草上飞";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 2;
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown3.Location = new System.Drawing.Point(63, 88);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown3.TabIndex = 6;
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown2.Location = new System.Drawing.Point(64, 56);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(64, 22);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "普通跑";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "15轻功";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "60轻功";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(459, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "保存并加载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(286, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 48);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坐骑移动参数";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.DecimalPlaces = 2;
            this.numericUpDown6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown6.Location = new System.Drawing.Point(65, 17);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown6.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "移动速度";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.DecimalPlaces = 2;
            this.numericUpDown7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown7.Location = new System.Drawing.Point(53, 75);
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown7.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "轻功三";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 2;
            this.numericUpDown4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown4.Location = new System.Drawing.Point(53, 43);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown4.TabIndex = 6;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 2;
            this.numericUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown5.Location = new System.Drawing.Point(54, 11);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown5.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "轻功一";
            // 
            // ajTpidKifm
            // 
            this.ajTpidKifm.AutoSize = true;
            this.ajTpidKifm.Location = new System.Drawing.Point(5, 48);
            this.ajTpidKifm.Name = "ajTpidKifm";
            this.ajTpidKifm.Size = new System.Drawing.Size(41, 12);
            this.ajTpidKifm.TabIndex = 0;
            this.ajTpidKifm.Text = "轻功二";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(291, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "开启坐标显示";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.numericUpDown8);
            this.groupBox3.Location = new System.Drawing.Point(149, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 48);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "实时检测距离";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "距离";
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown8.Location = new System.Drawing.Point(49, 20);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(49, 21);
            this.numericUpDown8.TabIndex = 0;
            this.numericUpDown8.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tishi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(574, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "提示：";
            // 
            // tishi
            // 
            this.tishi.ForeColor = System.Drawing.Color.Red;
            this.tishi.Name = "tishi";
            this.tishi.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.NnAphShyEh);
            this.groupBox4.Controls.Add(this.numericUpDown10);
            this.groupBox4.Location = new System.Drawing.Point(12, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(130, 48);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "实时计算时间";
            // 
            // NnAphShyEh
            // 
            this.NnAphShyEh.AutoSize = true;
            this.NnAphShyEh.Location = new System.Drawing.Point(6, 26);
            this.NnAphShyEh.Name = "NnAphShyEh";
            this.NnAphShyEh.Size = new System.Drawing.Size(29, 12);
            this.NnAphShyEh.TabIndex = 1;
            this.NnAphShyEh.Text = "时间";
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown10.Location = new System.Drawing.Point(48, 20);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(49, 21);
            this.numericUpDown10.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numericUpDown11);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.numericUpDown7);
            this.groupBox5.Controls.Add(this.ajTpidKifm);
            this.groupBox5.Controls.Add(this.numericUpDown5);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.numericUpDown4);
            this.groupBox5.Location = new System.Drawing.Point(202, 99);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(175, 164);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "韩移动参数";
            // 
            // numericUpDown11
            // 
            this.numericUpDown11.DecimalPlaces = 2;
            this.numericUpDown11.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown11.Location = new System.Drawing.Point(54, 113);
            this.numericUpDown11.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown11.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "轻功四";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(16, 12);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(120, 16);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "开启实时坐标检测";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(150, 12);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(132, 16);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "移动坐标异常后反弹";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 331);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Move";
            this.Text = "Move-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.Move_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
			{
				World.开启实时坐标检测 = 1;
				Config.IniWriteValue("GameServer", "开启实时坐标检测", "1");
			}
			else
			{
				World.开启实时坐标检测 = 0;
				Config.IniWriteValue("GameServer", "开启实时坐标检测", "0");
			}
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked)
			{
				World.移动坐标异常后反弹 = 1;
				Config.IniWriteValue("GameServer", "移动坐标异常后反弹", "1");
			}
			else
			{
				World.移动坐标异常后反弹 = 0;
				Config.IniWriteValue("GameServer", "移动坐标异常后反弹", "0");
			}
		}
	}
}
