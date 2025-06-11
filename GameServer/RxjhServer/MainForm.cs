using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using ClassLibrary;
using NLua;
using RxjhServer.bbg;
using RxjhServer.DbClss;
using RxjhServer.HelperTools;
using RxjhServer.Network;
using RxjhServer.RxjhTool;
using Utilities;




namespace RxjhServer
{
	public class MainForm : Form
	{
		private static readonly List<LogEntry> logEntries = new List<LogEntry>();

		private static int displayHeight = 300;

		private System.Timers.Timer lionRoarTimer = new System.Timers.Timer(21000.0);

		private readonly DateTime startTime = DateTime.Now;

		private int counter = 2;

		private System.Timers.Timer autoReconnectTimer;

		private System.Timers.Timer ipCheckTimer;

		private int autoAnnouncementIndex;

		private static World world;

		private Thread mainThread;

		private static Thread timerThread;

		private RxjhServer.Network.Listener _networkListener;

		private bool isRunning;

		private StatusBar statusBar1;

		private StatusBarPanel statusBarPanel1;

		private StatusBarPanel statusBarPanel2;

		private MainMenu mainMenu1;

		private MenuItem menuItem1;

		private MenuItem menuStopMainService;

		private MenuItem menuItem3;

		private MenuItem menuItem4;

		private MenuItem menuItem5;

		private MenuItem menuItem6;

		private MenuItem menuItem7;

		private ImageList imageList1;

		private MenuItem menuItem8;

		private MenuItem menuItem9;

		private MenuItem menuItem10;

		private MenuItem menuItem11;

		private MenuItem menuItem12;

		private MenuItem menuItem13;

		private MenuItem menuItem14;

		private StatusBarPanel statusBarPanel3;

		private MenuItem menuItem15;

		private MenuItem menuItem16;

		private MenuItem menuItem17;

		private StatusBarPanel statusBarPanel4;

		private MenuItem menuItem18;

		private MenuItem menuItem19;

		private MenuItem menuItem20;

		private FlickerFreePanel GraphPanel;

		private System.Windows.Forms.Timer timer1;

		private MenuItem menuItem21;

		private MenuItem menuItem22;

		private MenuItem menuItem23;

		private ToolStrip toolStrip1;

		private ToolStripTextBox toolStripTextBox1;

		private ToolStripButton toolStripButton1;

		private ToolStripTextBox toolStripTextBox2;

		private ToolStripComboBox toolStripComboBox1;

		private ToolStripButton toolStripButton2;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton toolStripButton3;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton toolStripButton4;

		private MenuItem menuItem25;

		private MenuItem menuItem26;

		private ToolStripComboBox toolStripComboBox2;

		private MenuItem menuItem27;

		private MenuItem menuItem28;

		private MenuItem menuItem29;

		private MenuItem menuItem30;

		private MenuItem menuItem32;

		private MenuItem menuItem37;

		private MenuItem menuItem38;

		private MenuItem menuItem39;

		private MenuItem menuItem40;

		private MenuItem menuItem42;

		private MenuItem menuItem43;

		private MenuItem menuItem44;

		private MenuItem menuItem45;

		private MenuItem menuItem24;

		private MenuItem menuItem49;

		private MenuItem menuItem50;

		private MenuItem menuItem52;

		private MenuItem menuItem46;

		private MenuItem menuItem48;

		private MenuItem menuItem53;

		private MenuItem menuItem54;

		private MenuItem menuItem55;

		private MenuItem menuItem47;

		private MenuItem menuItem56;

		private MenuItem menuItem58;

		private MenuItem menuItem31;

		private MenuItem menuItem60;

		private MenuItem menuItem61;

		private MenuItem menuItem62;

		private MenuItem menuItem63;

		private MenuItem menuItem51;

		private MenuItem menuItem59;

		private MenuItem menuItem64;

		private MenuItem menuItem65;

		private MenuItem menuItem66;

		private MenuItem menuItem41;

		private MenuItem menuItem57;

		private MenuItem menuItem68;

		private MenuItem menuItem69;

		private MenuItem menuItem70;

		private MenuItem menuItem71;

		private MenuItem menuItem72;

		private MenuItem menuItem73;

		private MenuItem menuItem74;

		private MenuItem menuItem75;

		private MenuItem menuItem76;

		private MenuItem menuItem77;

		private MenuItem menuItem78;

		private MenuItem menuItem79;

		private MenuItem menuItem80;

		private MenuItem menuItem81;

		private MenuItem menuItem82;

		private MenuItem menuItem83;

		private MenuItem menuItem84;

		private MenuItem menuItem85;

		private MenuItem menuItem86;

		private MenuItem menuItem87;

		private MenuItem menuItem88;

		private MenuItem menuItem89;

		private MenuItem menuItem67;

		private MenuItem menuItem90;

		private MenuItem menuItem91;

		private MenuItem menuItem92;

		private MenuItem menuItem93;

		private MenuItem menuItem94;

		private MenuItem menuItem95;

		private MenuItem menuItem96;

		private MenuItem menuItem98;

		private MenuItem menuItem99;

		private MenuItem menuItem100;

		private MenuItem menuItem101;

		private MenuItem menuItem102;

		private MenuItem menuItem103;

		private MenuItem menuItem104;

		private MenuItem menuItem105;

		private MenuItem menuItem106;

		private MenuItem menuItem107;

		private MenuItem menuItem108;

		private MenuItem menuItem36;

		private MenuItem menuItem33;

		private IContainer components;

		public MainForm()
		{
			InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuStopMainService = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.menuItem72 = new System.Windows.Forms.MenuItem();
            this.menuItem84 = new System.Windows.Forms.MenuItem();
            this.menuItem85 = new System.Windows.Forms.MenuItem();
            this.menuItem86 = new System.Windows.Forms.MenuItem();
            this.menuItem87 = new System.Windows.Forms.MenuItem();
            this.menuItem88 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuItem98 = new System.Windows.Forms.MenuItem();
            this.menuItem99 = new System.Windows.Forms.MenuItem();
            this.menuItem100 = new System.Windows.Forms.MenuItem();
            this.menuItem101 = new System.Windows.Forms.MenuItem();
            this.menuItem102 = new System.Windows.Forms.MenuItem();
            this.menuItem103 = new System.Windows.Forms.MenuItem();
            this.menuItem104 = new System.Windows.Forms.MenuItem();
            this.menuItem105 = new System.Windows.Forms.MenuItem();
            this.menuItem106 = new System.Windows.Forms.MenuItem();
            this.menuItem107 = new System.Windows.Forms.MenuItem();
            this.menuItem108 = new System.Windows.Forms.MenuItem();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem54 = new System.Windows.Forms.MenuItem();
            this.menuItem55 = new System.Windows.Forms.MenuItem();
            this.menuItem47 = new System.Windows.Forms.MenuItem();
            this.menuItem60 = new System.Windows.Forms.MenuItem();
            this.menuItem61 = new System.Windows.Forms.MenuItem();
            this.menuItem62 = new System.Windows.Forms.MenuItem();
            this.menuItem63 = new System.Windows.Forms.MenuItem();
            this.menuItem65 = new System.Windows.Forms.MenuItem();
            this.menuItem66 = new System.Windows.Forms.MenuItem();
            this.menuItem70 = new System.Windows.Forms.MenuItem();
            this.menuItem71 = new System.Windows.Forms.MenuItem();
            this.menuItem79 = new System.Windows.Forms.MenuItem();
            this.menuItem81 = new System.Windows.Forms.MenuItem();
            this.menuItem92 = new System.Windows.Forms.MenuItem();
            this.menuItem96 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem50 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem52 = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this.menuItem53 = new System.Windows.Forms.MenuItem();
            this.menuItem41 = new System.Windows.Forms.MenuItem();
            this.menuItem57 = new System.Windows.Forms.MenuItem();
            this.menuItem68 = new System.Windows.Forms.MenuItem();
            this.menuItem80 = new System.Windows.Forms.MenuItem();
            this.menuItem82 = new System.Windows.Forms.MenuItem();
            this.menuItem83 = new System.Windows.Forms.MenuItem();
            this.menuItem89 = new System.Windows.Forms.MenuItem();
            this.menuItem93 = new System.Windows.Forms.MenuItem();
            this.menuItem95 = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem69 = new System.Windows.Forms.MenuItem();
            this.menuItem73 = new System.Windows.Forms.MenuItem();
            this.menuItem74 = new System.Windows.Forms.MenuItem();
            this.menuItem76 = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem56 = new System.Windows.Forms.MenuItem();
            this.menuItem58 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.menuItem59 = new System.Windows.Forms.MenuItem();
            this.menuItem64 = new System.Windows.Forms.MenuItem();
            this.menuItem75 = new System.Windows.Forms.MenuItem();
            this.menuItem67 = new System.Windows.Forms.MenuItem();
            this.menuItem90 = new System.Windows.Forms.MenuItem();
            this.menuItem91 = new System.Windows.Forms.MenuItem();
            this.menuItem77 = new System.Windows.Forms.MenuItem();
            this.menuItem78 = new System.Windows.Forms.MenuItem();
            this.menuItem94 = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.GraphPanel = new RxjhServer.FlickerFreePanel();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 398);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(919, 20);
            this.statusBar1.TabIndex = 6;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "连接 1000 在线 1000";
            this.statusBarPanel1.Width = 300;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 160;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 180;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Text = "statusBarPanel4";
            this.statusBarPanel4.Width = 120;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4,
            this.menuItem6,
            this.menuItem40,
            this.menuItem56,
            this.menuItem77,
            this.menuItem94});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem32,
            this.menuItem3,
            this.menuStopMainService,
            this.menuItem29,
            this.menuItem17,
            this.menuItem31,
            this.menuItem72,
            this.menuItem84,
            this.menuItem85,
            this.menuItem86,
            this.menuItem87,
            this.menuItem88});
            this.menuItem1.Text = "服务";
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 0;
            this.menuItem32.Text = "开始登陆服务";
            this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "停止登陆服务";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuStopMainService
            // 
            this.menuStopMainService.Index = 2;
            this.menuStopMainService.Text = "停止主服务";
            this.menuStopMainService.Click += new System.EventHandler(this.StopMainService_Click);
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 3;
            this.menuItem29.Text = "线程停止";
            this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 4;
            this.menuItem17.Text = "存档人物";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 5;
            this.menuItem31.Text = "存档所有";
            this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click_1);
            // 
            // menuItem72
            // 
            this.menuItem72.Index = 6;
            this.menuItem72.Text = "开启下雪场景";
            this.menuItem72.Click += new System.EventHandler(this.menuItem72_Click);
            // 
            // menuItem84
            // 
            this.menuItem84.Index = 7;
            this.menuItem84.Text = "开启账号锁安全码";
            this.menuItem84.Click += new System.EventHandler(this.menuItem84_Click);
            // 
            // menuItem85
            // 
            this.menuItem85.Index = 8;
            this.menuItem85.Text = "开启攻击错误提示";
            this.menuItem85.Click += new System.EventHandler(this.menuItem85_Click);
            // 
            // menuItem86
            // 
            this.menuItem86.Index = 9;
            this.menuItem86.Text = "开启公告掉落提示";
            this.menuItem86.Click += new System.EventHandler(this.menuItem86_Click);
            // 
            // menuItem87
            // 
            this.menuItem87.Index = 10;
            this.menuItem87.Text = "开启多开提示信息";
            this.menuItem87.Click += new System.EventHandler(this.menuItem87_Click);
            // 
            // menuItem88
            // 
            this.menuItem88.Index = 11;
            this.menuItem88.Text = "开启其他错误提示";
            this.menuItem88.Click += new System.EventHandler(this.menuItem88_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem27,
            this.menuItem37,
            this.menuItem20,
            this.menuItem38,
            this.menuItem19,
            this.menuItem15,
            this.menuItem18,
            this.menuItem21,
            this.menuItem26,
            this.menuItem98,
            this.menuItem48,
            this.menuItem54,
            this.menuItem55,
            this.menuItem47,
            this.menuItem60,
            this.menuItem61,
            this.menuItem62,
            this.menuItem63,
            this.menuItem65,
            this.menuItem66,
            this.menuItem70,
            this.menuItem71,
            this.menuItem79,
            this.menuItem81,
            this.menuItem92,
            this.menuItem96});
            this.menuItem4.Text = "控制";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "用户";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 1;
            this.menuItem27.Text = "组队";
            this.menuItem27.Click += new System.EventHandler(this.menuItem27_Click);
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 2;
            this.menuItem37.Text = "地面物品";
            this.menuItem37.Click += new System.EventHandler(this.menuItem37_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Checked = true;
            this.menuItem20.Index = 3;
            this.menuItem20.Text = "显示记录";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 4;
            this.menuItem38.Text = "显示掉落";
            this.menuItem38.Click += new System.EventHandler(this.menuItem38_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 5;
            this.menuItem19.Text = "记录日志";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 6;
            this.menuItem15.Text = "记录封包";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 7;
            this.menuItem18.Text = "验证服务器";
            this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Checked = true;
            this.menuItem21.Index = 8;
            this.menuItem21.Text = "查复制";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 9;
            this.menuItem26.Text = "查SQL";
            this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
            // 
            // menuItem98
            // 
            this.menuItem98.Index = 10;
            this.menuItem98.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem99,
            this.menuItem100,
            this.menuItem101,
            this.menuItem102,
            this.menuItem103,
            this.menuItem104,
            this.menuItem105,
            this.menuItem106,
            this.menuItem107,
            this.menuItem108});
            this.menuItem98.Text = "数据清理";
            // 
            // menuItem99
            // 
            this.menuItem99.Index = 0;
            this.menuItem99.Text = "清理人物杀人次数";
            this.menuItem99.Click += new System.EventHandler(this.menuItem99_Click);
            // 
            // menuItem100
            // 
            this.menuItem100.Index = 1;
            this.menuItem100.Text = "清空玫瑰花榜(重置)";
            this.menuItem100.Click += new System.EventHandler(this.menuItem100_Click);
            // 
            // menuItem101
            // 
            this.menuItem101.Index = 2;
            this.menuItem101.Text = "清理人物贡献";
            this.menuItem101.Click += new System.EventHandler(this.menuItem101_Click);
            // 
            // menuItem102
            // 
            this.menuItem102.Index = 3;
            this.menuItem102.Text = "删除所有人物数据";
            this.menuItem102.Click += new System.EventHandler(this.menuItem102_Click);
            // 
            // menuItem103
            // 
            this.menuItem103.Index = 4;
            this.menuItem103.Text = "删除账号数据";
            this.menuItem103.Click += new System.EventHandler(this.menuItem103_Click);
            // 
            // menuItem104
            // 
            this.menuItem104.Index = 5;
            this.menuItem104.Text = "删除个人仓库";
            this.menuItem104.Click += new System.EventHandler(this.menuItem104_Click);
            // 
            // menuItem105
            // 
            this.menuItem105.Index = 6;
            this.menuItem105.Text = "删除综合仓库(全部清理)";
            // 
            // menuItem106
            // 
            this.menuItem106.Index = 7;
            this.menuItem106.Text = "删除帮派数据";
            // 
            // menuItem107
            // 
            this.menuItem107.Index = 8;
            this.menuItem107.Text = "删除日志记录";
            // 
            // menuItem108
            // 
            this.menuItem108.Index = 9;
            this.menuItem108.Text = "清空所有数据，清理需要谨慎！";
            this.menuItem108.Click += new System.EventHandler(this.menuItem108_Click);
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 11;
            this.menuItem48.Text = "Npc控制";
            this.menuItem48.Click += new System.EventHandler(this.menuItem48_Click);
            // 
            // menuItem54
            // 
            this.menuItem54.Index = 12;
            this.menuItem54.Text = "开启修炼地图";
            this.menuItem54.Click += new System.EventHandler(this.menuItem54_Click);
            // 
            // menuItem55
            // 
            this.menuItem55.Index = 13;
            this.menuItem55.Text = "石头控制";
            this.menuItem55.Click += new System.EventHandler(this.menuItem55_Click);
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 14;
            this.menuItem47.Text = "气功控制";
            this.menuItem47.Click += new System.EventHandler(this.menuItem47_Click);
            // 
            // menuItem60
            // 
            this.menuItem60.Index = 15;
            this.menuItem60.Text = "开启仙魔大战";
            this.menuItem60.Click += new System.EventHandler(this.menuItem60_Click);
            // 
            // menuItem61
            // 
            this.menuItem61.Index = 16;
            this.menuItem61.Text = "开启攻城战(天魔)";
            this.menuItem61.Click += new System.EventHandler(this.menuItem61_Click);
            // 
            // menuItem62
            // 
            this.menuItem62.Index = 17;
            this.menuItem62.Text = "开启帮战";
            this.menuItem62.Click += new System.EventHandler(this.menuItem62_Click);
            // 
            // menuItem63
            // 
            this.menuItem63.Index = 18;
            this.menuItem63.Text = "开启武林血战";
            this.menuItem63.Click += new System.EventHandler(this.menuItem63_Click);
            // 
            // menuItem65
            // 
            this.menuItem65.Index = 19;
            this.menuItem65.Text = "开启异口同声";
            this.menuItem65.Click += new System.EventHandler(this.menuItem65_Click);
            // 
            // menuItem66
            // 
            this.menuItem66.Index = 20;
            this.menuItem66.Text = "开启全服双倍";
            this.menuItem66.Click += new System.EventHandler(this.menuItem66_Click);
            // 
            // menuItem70
            // 
            this.menuItem70.Index = 21;
            this.menuItem70.Text = "开启boss攻城";
            this.menuItem70.Click += new System.EventHandler(this.menuItem70_Click);
            // 
            // menuItem71
            // 
            this.menuItem71.Index = 22;
            this.menuItem71.Text = "开启世界BOSS";
            this.menuItem71.Click += new System.EventHandler(this.menuItem71_Click);
            // 
            // menuItem79
            // 
            this.menuItem79.Index = 23;
            this.menuItem79.Text = "开启势力战";
            this.menuItem79.Click += new System.EventHandler(this.menuItem79_Click);
            // 
            // menuItem81
            // 
            this.menuItem81.Index = 24;
            this.menuItem81.Text = "开启野外BOSS";
            this.menuItem81.Click += new System.EventHandler(this.menuItem81_Click);
            // 
            // menuItem92
            // 
            this.menuItem92.Index = 25;
            this.menuItem92.Text = "开启比武泡点";
            this.menuItem92.Click += new System.EventHandler(this.menuItem92_Click);
            // 
            // menuItem96
            // 
            this.menuItem96.Index = 26;
            this.menuItem96.Text = "开启下雪";
            this.menuItem96.Click += new System.EventHandler(this.menuItem96_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem30,
            this.menuItem28,
            this.menuItem8,
            this.menuItem22,
            this.menuItem23,
            this.menuItem9,
            this.menuItem25,
            this.menuItem10,
            this.menuItem11,
            this.menuItem12,
            this.menuItem13,
            this.menuItem50,
            this.menuItem14,
            this.menuItem16,
            this.menuItem39,
            this.menuItem42,
            this.menuItem43,
            this.menuItem44,
            this.menuItem45,
            this.menuItem24,
            this.menuItem52,
            this.menuItem46,
            this.menuItem53,
            this.menuItem41,
            this.menuItem57,
            this.menuItem68,
            this.menuItem80,
            this.menuItem82,
            this.menuItem83,
            this.menuItem89,
            this.menuItem93,
            this.menuItem95,
            this.menuItem33});
            this.menuItem6.Text = "重读";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "重读全部配置";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 1;
            this.menuItem30.Text = "重读武功数据";
            this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 2;
            this.menuItem28.Text = "重读过滤";
            this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.Text = "重读NPC[危险]";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 4;
            this.menuItem22.Text = "重读怪物数据";
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 5;
            this.menuItem23.Text = "重读BOSS物品掉落";
            this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 6;
            this.menuItem9.Text = "重读物品掉落";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 7;
            this.menuItem25.Text = "重读高手怪物品掉落";
            this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 8;
            this.menuItem10.Text = "重读开箱";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 9;
            this.menuItem11.Text = "重读物品";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 10;
            this.menuItem12.Text = "重读NPC商店";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 11;
            this.menuItem13.Text = "重读传送点";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem50
            // 
            this.menuItem50.Index = 12;
            this.menuItem50.Text = "重读自定义移动数据";
            this.menuItem50.Click += new System.EventHandler(this.menuItem50_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 13;
            this.menuItem14.Text = "重读自动公告";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 14;
            this.menuItem16.Text = "重读配置文件";
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 15;
            this.menuItem39.Text = "重读脚本";
            this.menuItem39.Click += new System.EventHandler(this.menuItem39_Click);
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 16;
            this.menuItem42.Text = "重读制作列表";
            this.menuItem42.Click += new System.EventHandler(this.menuItem42_Click);
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 17;
            this.menuItem43.Text = "重读百宝阁数据";
            this.menuItem43.Click += new System.EventHandler(this.menuItem43_Click);
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 18;
            this.menuItem44.Text = "重读套装数据";
            this.menuItem44.Click += new System.EventHandler(this.menuItem44_Click);
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 19;
            this.menuItem45.Text = "重读等级奖励";
            this.menuItem45.Click += new System.EventHandler(this.menuItem45_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 20;
            this.menuItem24.Text = "重读物品兑换";
            this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
            // 
            // menuItem52
            // 
            this.menuItem52.Index = 21;
            this.menuItem52.Text = "重读任务数据";
            this.menuItem52.Click += new System.EventHandler(this.menuItem52_Click);
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 22;
            this.menuItem46.Text = "重读气功加成比率";
            this.menuItem46.Click += new System.EventHandler(this.menuItem46_Click);
            // 
            // menuItem53
            // 
            this.menuItem53.Index = 23;
            this.menuItem53.Text = "重读石头设置";
            this.menuItem53.Click += new System.EventHandler(this.menuItem53_Click);
            // 
            // menuItem41
            // 
            this.menuItem41.Index = 24;
            this.menuItem41.Text = "重读装备洗髓";
            this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click_1);
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 25;
            this.menuItem57.Text = "重读披风收录加成";
            this.menuItem57.Click += new System.EventHandler(this.menuItem57_Click);
            // 
            // menuItem68
            // 
            this.menuItem68.Index = 26;
            this.menuItem68.Text = "重读英雄武器";
            this.menuItem68.Click += new System.EventHandler(this.menuItem68_Click);
            // 
            // menuItem80
            // 
            this.menuItem80.Index = 27;
            this.menuItem80.Text = "重读boss攻城";
            this.menuItem80.Click += new System.EventHandler(this.menuItem80_Click);
            // 
            // menuItem82
            // 
            this.menuItem82.Index = 28;
            this.menuItem82.Text = "重读伏魔洞副本";
            this.menuItem82.Click += new System.EventHandler(this.menuItem82_Click);
            // 
            // menuItem83
            // 
            this.menuItem83.Index = 29;
            this.menuItem83.Text = "重读物品回收";
            this.menuItem83.Click += new System.EventHandler(this.menuItem83_Click);
            // 
            // menuItem89
            // 
            this.menuItem89.Index = 30;
            this.menuItem89.Text = "重读累计充值礼包";
            this.menuItem89.Click += new System.EventHandler(this.menuItem89_Click);
            // 
            // menuItem93
            // 
            this.menuItem93.Index = 31;
            this.menuItem93.Text = "重读比武泡点奖励";
            this.menuItem93.Click += new System.EventHandler(this.menuItem93_Click);
            // 
            // menuItem95
            // 
            this.menuItem95.Index = 32;
            this.menuItem95.Text = "重读人物经验条";
            this.menuItem95.Click += new System.EventHandler(this.menuItem95_Click);
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 33;
            this.menuItem33.Text = "重读安全区";
            this.menuItem33.Click += new System.EventHandler(this.menuItem33_Click_1);
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 3;
            this.menuItem40.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem49,
            this.menuItem69,
            this.menuItem73,
            this.menuItem74,
            this.menuItem76,
            this.menuItem36});
            this.menuItem40.Text = "工具";
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 0;
            this.menuItem49.Text = "YBI编辑器";
            this.menuItem49.Click += new System.EventHandler(this.menuItem49_Click);
            // 
            // menuItem69
            // 
            this.menuItem69.Index = 1;
            this.menuItem69.Text = "在线GM工具";
            this.menuItem69.Click += new System.EventHandler(this.menuItem69_Click);
            // 
            // menuItem73
            // 
            this.menuItem73.Index = 2;
            this.menuItem73.Text = "自动修改公告";
            this.menuItem73.Click += new System.EventHandler(this.menuItem73_Click);
            // 
            // menuItem74
            // 
            this.menuItem74.Index = 3;
            this.menuItem74.Text = "实时移动参数";
            this.menuItem74.Click += new System.EventHandler(this.menuItem74_Click);
            // 
            // menuItem76
            // 
            this.menuItem76.Index = 4;
            this.menuItem76.Text = "全体换线移动";
            this.menuItem76.Click += new System.EventHandler(this.menuItem76_Click);
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 5;
            this.menuItem36.Text = "更新荣誉/花榜数据";
            this.menuItem36.Click += new System.EventHandler(this.UpdateHonorRankings_Click);
            // 
            // menuItem56
            // 
            this.menuItem56.Index = 4;
            this.menuItem56.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem58,
            this.menuItem51,
            this.menuItem59,
            this.menuItem64,
            this.menuItem75,
            this.menuItem67,
            this.menuItem90,
            this.menuItem91});
            this.menuItem56.Text = "设置";
            // 
            // menuItem58
            // 
            this.menuItem58.Index = 0;
            this.menuItem58.Text = "防CC设置";
            this.menuItem58.Click += new System.EventHandler(this.menuItem58_Click);
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 1;
            this.menuItem51.Text = "清理游戏记录";
            this.menuItem51.Click += new System.EventHandler(this.menuItem51_Click_2);
            // 
            // menuItem59
            // 
            this.menuItem59.Index = 2;
            this.menuItem59.Text = "清理分区数据";
            this.menuItem59.Click += new System.EventHandler(this.menuItem59_Click_1);
            // 
            // menuItem64
            // 
            this.menuItem64.Index = 3;
            this.menuItem64.Text = "清理分区账号";
            this.menuItem64.Click += new System.EventHandler(this.menuItem64_Click_1);
            // 
            // menuItem75
            // 
            this.menuItem75.Index = 4;
            this.menuItem75.Text = "清理其他数据";
            this.menuItem75.Click += new System.EventHandler(this.menuItem75_Click);
            // 
            // menuItem67
            // 
            this.menuItem67.Index = 5;
            this.menuItem67.Text = "清理30天未登录账号";
            this.menuItem67.Click += new System.EventHandler(this.menuItem67_Click);
            // 
            // menuItem90
            // 
            this.menuItem90.Index = 6;
            this.menuItem90.Text = "清理60天未登录账号";
            this.menuItem90.Click += new System.EventHandler(this.menuItem90_Click);
            // 
            // menuItem91
            // 
            this.menuItem91.Index = 7;
            this.menuItem91.Text = "清理90天未登录账号";
            this.menuItem91.Click += new System.EventHandler(this.menuItem91_Click);
            // 
            // menuItem77
            // 
            this.menuItem77.Index = 5;
            this.menuItem77.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem78});
            this.menuItem77.Text = "关于本软件";
            // 
            // menuItem78
            // 
            this.menuItem78.Index = 0;
            this.menuItem78.Text = "授权协议";
            this.menuItem78.Click += new System.EventHandler(this.menuItem78_Click);
            // 
            // menuItem94
            // 
            this.menuItem94.Index = 6;
            this.menuItem94.Text = "GM在线工具";
            this.menuItem94.Click += new System.EventHandler(this.menuItem94_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripComboBox2,
            this.toolStripButton1,
            this.toolStripTextBox2,
            this.toolStripComboBox1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(165, 25);
            this.toolStripTextBox1.Text = resources.GetString("toolStripTextBox1.Text");
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.DropDownWidth = 75;
            this.toolStripComboBox2.IntegralHeight = false;
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "正常",
            "加密"});
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBox2.Text = "正常";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton1.Text = "发送";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(83, 25);
            this.toolStripTextBox2.Text = "空";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "10",
            "9"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBox1.Text = "10";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton2.Text = "发送";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton3.Text = "发送人数";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 22);
            this.toolStripButton4.Text = "查";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // GraphPanel
            // 
            this.GraphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphPanel.BackColor = System.Drawing.Color.White;
            this.GraphPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GraphPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphPanel.Location = new System.Drawing.Point(0, 26);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(919, 418);
            this.GraphPanel.TabIndex = 0;
            this.GraphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(919, 418);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.GraphPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "源多多资源网-yuandd.Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form1_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				RegisterForm registerForm = new RegisterForm();
				World.Key1 = Config.IniReadValue("GameServer", "Key1").Trim();
				World.Key2 = Config.IniReadValue("GameServer", "Key2").Trim();
				IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
				int num = 0;
				IPAddress[] addressList = hostEntry.AddressList;
				IPAddress[] array = addressList;
				IPAddress[] array2 = array;
				foreach (IPAddress iPAddress in array2)
				{
					if (!(iPAddress.ToString() == "127.0.0.1"))
					{
						num++;
					}
				}
				if (num == hostEntry.AddressList.Length)
				{
				}
				timerThread = new Thread(new Timer.TimerThread().TimerMain)
				{
					Name = "Timer Thread"
				};
				timerThread.Start();
				world = new World();
				world.SetConfig();
				world.SetConfig2();
				if (World.检查数据库配置())
				{
					world.加载物品回收();
					world.SetMonSter();
					world.SetNpc();
					world.SetDrop();
					world.Set_GSDrop();
					world.SetBossDrop();
					world.SetOpen();
					world.Set套装();
					world.SetBbgItem();
					world.加载百宝阁抽奖();
					world.SetLever();
					world.SetWxLever();
					world.SetKONGFU();
					world.SetItme();
					world.LoadShopData();
					world.SetMover();
					world.Set公告();
					world.Set等级奖励();
					world.Set物品兑换();
					world.Set移动();
					world.Set制药物品();
					world.Set安全区();
					world.安全地图区域();
					world.SetKill();
					world.SetJianc();
					world.Set升天气功();
					world.LoadCraftingItems();
					world.SetScript();
					world.Set任务数据新();
					world.SetQG();
					world.Set石头属性();
					world.Set比武泡点奖励();
					world.充值排行();
					world.LoadGuildHonorRankings();
					world.荣誉势力排行();
					world.荣誉武林排行();
					world.荣誉讨伐排行();
					world.boss攻城怪物();
					world.boss伏魔洞怪物();
					world.LoadGuildWarData();
					World.conn = new Connect();
					World.conn.Sestup();
					_networkListener = new RxjhServer.Network.Listener((ushort)World.GameServerPort);
					AuthServer authServer = new AuthServer(World.百宝阁服务器IP, World.百宝阁服务器端口);
					Text = Text + "_" + World.ServerName + "_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
					mainThread = new Thread(FlushAll)
					{
						Name = "FlushAll",
						Priority = ThreadPriority.Lowest
					};
					mainThread.Start();
					World.CurrentGameServerPort = World.GameServerPort;
					Timer.DelayCall(TimeSpan.FromMilliseconds(360000.0), TimeSpan.FromMilliseconds(360000.0), HandleAutoAnnouncementEvent);
					Timer.DelayCall(TimeSpan.FromMilliseconds(World.荣誉排行榜更新时间), TimeSpan.FromMilliseconds(World.荣誉排行榜更新时间), UpdateHonorRankings);
					lionRoarTimer = new System.Timers.Timer(21000.0);
					lionRoarTimer.Elapsed += HandleLionRoarEvent;
					lionRoarTimer.AutoReset = true;
					lionRoarTimer.Enabled = true;
					autoReconnectTimer = new System.Timers.Timer(World.AutoReconnectInterval * 1000);
					autoReconnectTimer.Elapsed += HandleAutoReconnectEvent;
					autoReconnectTimer.AutoReset = true;
					autoReconnectTimer.Enabled = true;
					ipCheckTimer = new System.Timers.Timer(60000.0);
					ipCheckTimer.Elapsed += HandleIpCheckEvent;
					ipCheckTimer.AutoReset = true;
					ipCheckTimer.Enabled = true;
					Connsend.Send(World.sql, World.ServerName);
					Thread1();
				}
			}
			catch (Exception ex)
			{
				WriteLine(1, "Form1_Load 错误" + ex.Message);
			}
		}

		public void UpdateHonorRankings()
		{
			if (World.JlMsg == 1)
			{
				WriteLine(0, "刷新荣誉事件");
			}
			World.UpdateAllRankingData();
			world.充值排行();
			world.LoadGuildHonorRankings();
			world.荣誉势力排行();
			world.荣誉武林排行();
			world.荣誉讨伐排行();
			WriteLine(2, "刷新荣誉排行数据完成");
		}

		private void HandleAutoReconnectEvent(object source, ElapsedEventArgs e)
		{
			autoReconnectTimer.Interval = World.AutoReconnectInterval * 1000;
			if (!World.MainSocket)
			{
				menuStopMainService.Text = "停止主服务";
				if (_networkListener != null)
				{
					_networkListener.Stop();
					_networkListener = null;
				}
				int num = new Random().Next(10, 200);
				_networkListener = new RxjhServer.Network.Listener((ushort)(World.GameServerPort + num));
			}
		}

		private void HandleIpCheckEvent(object source, ElapsedEventArgs e)
		{
			try
			{
				World.PrivateTeams.Clear();
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (!World.PrivateTeams.ContainsKey(value.Client.ToString()) && !value.Client.挂机)
					{
						World.PrivateTeams.Add(value.Client.ToString(), value);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void menuItem32_Click(object sender, EventArgs e)
		{
			if (World.conn != null)
			{
				World.conn.Dispose();
				World.conn = null;
			}
			World.conn = new Connect();
			World.conn.Sestup();
		}

		private void StopMainService_Click(object sender, EventArgs e)
		{
			if (_networkListener != null)
			{
				menuStopMainService.Text = "Start Main Service";
                _networkListener.Stop();
				_networkListener = null;
			}
			else
			{
				menuStopMainService.Text = "Stop Main Service";
                int randomPortOffset = new Random().Next(10, 200);
				World.CurrentGameServerPort = World.GameServerPort + randomPortOffset;
				_networkListener = new RxjhServer.Network.Listener((ushort)World.CurrentGameServerPort);
			}
		}

		private void menuItem3_Click(object sender, EventArgs e)
		{
			World.conn.Dispose();
			List<Players> list = new List<Players>();
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				list.Add(value);
			}
			foreach (Players item in list)
			{
				try
				{
					if (item.Client != null)
					{
						item.Client.Dispose();
					}
				}
				catch (Exception ex)
				{
					WriteLine(1, "保存人物的数据 错误" + ex.Message);
				}
			}
			list.Clear();
		}

		private void HandleLionRoarEvent(object source, ElapsedEventArgs e)
		{
			World.Process狮子吼Queue();
		}

		private static void Thread1()
		{
			try
			{
				LuaFunction function = World.脚本.pLuaVM.GetFunction("OpenItmeTrigGer");
				if (function != null)
				{
					object[] args = new object[4] { 0, 100, 0, 1 };
					object[] array = function.Call(args);
				}
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (World.SqlPool.Count > 0)
				{
					if (MessageBox.Show("数据列队还没有完成 " + World.SqlPool.Count, "数据列队还没有完成", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
					{
						isRunning = true;
						timerThread.Abort();
						mainThread.Abort();
						if (_networkListener != null)
						{
							_networkListener.Dispose();
							_networkListener = null;
						}
					}
					else
					{
						e.Cancel = true;
					}
				}
				else if (World.AllConnectedPlayers.Count > 0)
				{
					if (MessageBox.Show("有人物在线 " + World.AllConnectedPlayers.Count, "还有人物在线", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
					{
						isRunning = true;
						timerThread.Abort();
						mainThread.Abort();
						if (_networkListener != null)
						{
							_networkListener.Dispose();
							_networkListener = null;
						}
					}
					else
					{
						e.Cancel = true;
					}
				}
				else
				{
					isRunning = true;
					timerThread.Abort();
					mainThread.Abort();
					ClassDllImport.FreeLib();
					if (_networkListener != null)
					{
						_networkListener.Dispose();
						_networkListener = null;
					}
				}
			}
			catch
			{
			}
		}

		private void FlushAll()
		{
			try
			{
				while (!isRunning)
				{
					if (World.AutoPortSwitching && World.ConnectionList.Count - World.AllConnectedPlayers.Count > World.MaxAllowedConnections)
					{
						if (_networkListener != null)
						{
							_networkListener.Stop();
							_networkListener = null;
						}
						Random random = new Random();
						World.CurrentGameServerPort = World.GameServerPort + random.Next(10, 200);
						_networkListener = new RxjhServer.Network.Listener((ushort)World.CurrentGameServerPort);
					}
					Timer.Slice();
					Thread.Sleep(1);
					World.ProcessSqlQueue();
				}
			}
			catch (Exception)
			{
				if (!isRunning)
				{
					Timer.DelayCall(TimeSpan.FromMilliseconds(360000.0), TimeSpan.FromMilliseconds(360000.0), HandleAutoAnnouncementEvent);
					mainThread = new Thread(FlushAll)
					{
						Name = "FlushAll"
					};
					mainThread.Start();
				}
			}
		}

		public void HandleAutoAnnouncementEvent()
		{
			PerformUserLoginCheck();
			if (World.公告.Count > 0)
			{
				AnnouncementClass AnnouncementClass2 = World.公告[autoAnnouncementIndex];
				BroadcastAnnouncement(AnnouncementClass2.msg, AnnouncementClass2.type);
				autoAnnouncementIndex++;
				if (autoAnnouncementIndex >= World.公告.Count)
				{
					autoAnnouncementIndex = 0;
				}
			}
			if (World.AutoSave == 1)
			{
				menuItem17.PerformClick();
			}
			try
			{
				if (World.AllConnectedPlayers.Count > World.ConnectionList.Count)
				{
					Queue queue = Queue.Synchronized(new Queue());
					foreach (Players value2 in World.AllConnectedPlayers.Values)
					{
						queue.Enqueue(value2);
					}
					while (queue.Count > 0)
					{
						Players players = (Players)queue.Dequeue();
						if (!World.ConnectionList.TryGetValue(players.人物全服ID, out var _))
						{
							World.AllConnectedPlayers.Remove(players.人物全服ID);
						}
					}
					if (World.AllConnectedPlayers.Count > World.ConnectionList.Count)
					{
						World.conn.Dispose();
						menuItem3.PerformClick();
						World.AutoSave = 0;
					}
				}
				if (World.是否开启王龙 == 1)
				{
					foreach (Players value3 in World.AllConnectedPlayers.Values)
					{
						if (value3.人物坐标_地图 >= 23002 && value3.人物坐标_地图 <= 23050)
						{
							byte[] array = Converter.hexStringToByte("AA5516002C01121708000000000000000000000000000000558D55AA");
							Buffer.BlockCopy(BitConverter.GetBytes(World.王龙的金币), 0, array, 10, 8);
							if (value3.Client != null)
							{
								value3.Client.Send(array, array.Length);
							}
						}
					}
				}
				if (World.物品记录 == 1)
				{
					DBA.ExeSqlCommand("DELETE FROM 物品记录 WHERE DateDiff(dd, 时间, getdate())>" + World.记录保存天数);
				}
				if (World.登陆记录 == 1)
				{
					DBA.ExeSqlCommand("DELETE FROM 登陆记录 WHERE DateDiff(dd, 时间, getdate())>" + World.记录保存天数);
				}
				if (World.掉落记录 == 1)
				{
					DBA.ExeSqlCommand("DELETE FROM 掉落记录 WHERE DateDiff(dd, FLD_TIME, getdate())>" + World.记录保存天数);
				}
				if (World.开盒记录 == 1)
				{
					DBA.ExeSqlCommand("DELETE FROM 开盒记录 WHERE DateDiff(dd, FLD_TIME, getdate())>" + World.记录保存天数);
				}
				if (World.进化记录 == 1)
				{
					DBA.ExeSqlCommand("DELETE FROM 进化记录 WHERE DateDiff(dd, FLD_TIME, getdate())>" + World.记录保存天数);
				}
				if (World.商店记录 == 1)
				{
					DBA.ExeSqlCommand("DELETE FROM 商店记录 WHERE DateDiff(dd, FLD_TIME, getdate())>" + World.记录保存天数);
				}
				if (World.药品记录 == 1)
				{
					DBA.ExeSqlCommand("DELETE FROM 药品记录 WHERE DateDiff(dd, FLD_TIME, getdate())>" + World.记录保存天数);
				}
				if (World.传书记录 == 1)
				{
					DBA.ExeSqlCommand("DELETE FROM TBL_传书系统 WHERE DateDiff(dd, 传书时间, getdate())>" + World.传书保存天数);
				}
				World.MaxOnline = int.Parse(Config.IniReadValue("GameServer", "最大在线").Trim());
				World.conn.发送("更新服务器配置|" + World.ServerID + "|" + World.MaxOnline);
				World.week = (int)DateTime.Now.DayOfWeek;
			}
			catch
			{
			}
		}

		private void BroadcastAnnouncement(string txt, int type)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (!value.Client.挂机 && value != null)
					{
						if (type == 0)
						{
							value.系统公告(txt);
						}
						else
						{
							value.系统滚动公告(txt);
						}
					}
				}
			}
			catch (Exception ex)
			{
				WriteLine(1, "公告 错误" + ex.Message);
			}
		}

		private void timer1_Tick(object source, EventArgs e)
		{
			GraphPanel.Invalidate();
			statusBarPanel1.Text = "连接:" + World.ConnectionList.Count + " 在线:" + World.AllConnectedPlayers.Count + " 商店:" + World.OfflineCount + " 假人:" + World.OfflineBots + " 云挂机:" + World.CloudAfkCount;
			StatusBarPanel statusBarPanel = this.statusBarPanel2;
			string str = World.ItemTemp.Count.ToString();
			string str2 = MapClass.GetNpcConn().ToString();
			string text21 = (statusBarPanel.Text = "地图物品:" + str + " 怪物:" + str2);
			string text12 = text21;
			string text13 = text12;
			double ReceiveSpeed = World.ReceiveSpeed;
			double SendSpeed = World.SendSpeed;
			double BroadcastSendSpeed = World.BroadcastSendSpeed;
			string text14 = ((!(ReceiveSpeed >= 1024.0)) ? (Math.Round(ReceiveSpeed, 0) + "B") : (Math.Round(World.ReceiveSpeed / 1024.0, 0) + "K"));
			string text15 = text14;
			string text16 = ((!(SendSpeed >= 1024.0)) ? (Math.Round(SendSpeed, 0) + "B") : (Math.Round(World.SendSpeed / 1024.0, 0) + "K"));
			string text17 = text16;
			if (BroadcastSendSpeed >= 1024.0)
			{
				string text18 = Math.Round(World.BroadcastSendSpeed / 1024.0, 0) + "K";
			}
			else
			{
				string text19 = Math.Round(BroadcastSendSpeed, 0) + "B";
			}
			statusBarPanel3.Text = "收:" + text15 + "/s 发:" + text17 + "/s 包:" + Converter.Hexstring.Count;
			World.ReceiveSpeed = 0.0;
			World.SendSpeed = 0.0;
			World.BroadcastSendSpeed = 0.0;
			TimeSpan timeSpan = DateTime.Now.Subtract(startTime);
			StatusBarPanel statusBarPanel2 = statusBarPanel4;
			text21 = (statusBarPanel2.Text = timeSpan.Days + "天" + timeSpan.Hours + "时" + timeSpan.Minutes + "分" + timeSpan.Seconds + "秒");
			text12 = text21;
			string text11 = text12;
		}

		private void menuItem29_Click(object sender, EventArgs e)
		{
			if (!isRunning)
			{
				isRunning = true;
				timerThread.Abort();
				mainThread.Abort();
				return;
			}
			mainThread = new Thread(FlushAll)
			{
				Name = "FlushAll"
			};
			mainThread.Start();
			timerThread = new Thread(new Timer.TimerThread().TimerMain)
			{
				Name = "Timer Thread"
			};
			timerThread.Start();
		}

		private void menuItem5_Click(object sender, EventArgs e)
		{
			int num = (int)new UserList().ShowDialog();
		}

		private void menuItem27_Click(object sender, EventArgs e)
		{
			int num = (int)new FormUser组队().ShowDialog();
		}

		private void menuItem7_Click(object sender, EventArgs e)
		{
			world.SetDrop();
			world.SetOpen();
			world.Set套装();
			world.SetBbgItem();
			world.加载百宝阁抽奖();
			world.SetLever();
			world.SetKONGFU();
			world.SetItme();
			world.LoadShopData();
			world.SetMover();
			world.安全地图区域();
			world.Set公告();
			world.Set等级奖励();
			world.Set物品兑换();
			world.Set石头属性();
			world.Set移动();
			world.Set比武泡点奖励();
		}

		private void menuItem8_Click(object sender, EventArgs e)
		{
			Queue queue = Queue.Synchronized(new Queue());
			foreach (MapClass value in World.Map.Values)
			{
				foreach (NpcClass value2 in value.npcTemplate.Values)
				{
					queue.Enqueue(value2);
				}
			}
			while (queue.Count > 0)
			{
				((NpcClass)queue.Dequeue()).Dispose();
			}
			world.SetNpc();
		}

		private void menuItem9_Click(object sender, EventArgs e)
		{
			world.SetDrop();
		}

		private void menuItem10_Click(object sender, EventArgs e)
		{
			world.SetOpen();
		}

		private void menuItem11_Click(object sender, EventArgs e)
		{
			world.SetItme();
		}

		private void menuItem12_Click(object sender, EventArgs e)
		{
			world.LoadShopData();
		}

		private void menuItem13_Click(object sender, EventArgs e)
		{
			world.SetMover();
		}

		private void menuItem14_Click(object sender, EventArgs e)
		{
			world.Set公告();
		}

		private void menuItem15_Click(object sender, EventArgs e)
		{
			if (menuItem15.Checked)
			{
				menuItem15.Checked = false;
				World.Log = 0;
			}
			else
			{
				menuItem15.Checked = true;
				World.Log = 1;
			}
		}

		private void menuItem26_Click(object sender, EventArgs e)
		{
			if (menuItem26.Checked)
			{
				menuItem26.Checked = false;
				World.JlMsg = 0;
			}
			else
			{
				menuItem26.Checked = true;
				World.JlMsg = 1;
			}
		}

		private void menuItem16_Click(object sender, EventArgs e)
		{
			world.SetConfig();
			World.MaxOnline = int.Parse(Config.IniReadValue("GameServer", "最大在线").Trim());
			World.conn.发送("更新服务器配置|" + World.ServerID + "|" + World.MaxOnline);
			WriteLine(2, "重新加载服务器配置文件完成");
		}

		private void menuItem17_Click(object sender, EventArgs e)
		{
			List<Players> list = new List<Players>();
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				list.Add(value);
			}
			foreach (Players item in list)
			{
				try
				{
					item.SavePlayerData();
				}
				catch (Exception ex)
				{
					WriteLine(1, "保存人物的数据 错误" + ex.Message);
				}
			}
			list.Clear();
			WriteLine(8, "保存人物的数据 完成");
		}

		private void menuItem18_Click(object sender, EventArgs e)
		{
			if (menuItem18.Checked)
			{
				menuItem18.Checked = false;
				World.验证服务器log = 0;
			}
			else
			{
				menuItem18.Checked = true;
				World.验证服务器log = 1;
			}
		}

		private void menuItem19_Click(object sender, EventArgs e)
		{
			if (menuItem19.Checked)
			{
				menuItem19.Checked = false;
				World.jllog = 0;
			}
			else
			{
				menuItem19.Checked = true;
				World.jllog = 1;
			}
		}

		private void menuItem20_Click(object sender, EventArgs e)
		{
			if (menuItem20.Checked)
			{
				menuItem20.Checked = false;
				World.AlWorldlog = false;
			}
			else
			{
				menuItem20.Checked = true;
				World.AlWorldlog = true;
			}
		}

		private void menuItem21_Click(object sender, EventArgs e)
		{
			try
			{
				if (menuItem21.Checked)
				{
					menuItem21.Checked = false;
					World.AllItmelog = 0;
				}
				else
				{
					menuItem21.Checked = true;
					World.AllItmelog = 1;
				}
			}
			catch (Exception ex)
			{
				WriteLine(1, "查物品错误 错误" + ex.Message);
			}
		}

		private void menuItem22_Click(object sender, EventArgs e)
		{
			world.SetMonSter();
		}

		private void menuItem23_Click(object sender, EventArgs e)
		{
			world.SetBossDrop();
		}

		private void menuItem25_Click(object sender, EventArgs e)
		{
			world.Set_GSDrop();
		}

		private void menuItem28_Click(object sender, EventArgs e)
		{
			world.SetKill();
			world.SetJianc();
		}

		private void menuItem30_Click(object sender, EventArgs e)
		{
			world.SetKONGFU();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			try
			{
				byte[] array = Converter.hexStringToByte2(toolStripTextBox1.Text);
				foreach (NetState value in World.ConnectionList.Values)
				{
					if (value != null)
					{
						if (toolStripComboBox2.Text == "正常")
						{
							Buffer.BlockCopy(BitConverter.GetBytes(value.WorldId), 0, array, 5, 2);
							value.Send单包(array, array.Length);
						}
						else
						{
							value.Send多包(array, array.Length);
						}
					}
				}
			}
			catch
			{
			}
			counter++;
		}

		public void Send单包(byte[] toSendBuff, int len)
		{
			byte[] array = new byte[BitConverter.ToInt16(toSendBuff, 9) + 7];
			Buffer.BlockCopy(toSendBuff, 5, array, 0, array.Length);
			Send封装发送(array, array.Length);
		}

		private void Send封装发送(byte[] toSendBuff, int length)
		{
			byte[] array = new byte[length + 15];
			array[0] = 170;
			array[1] = 85;
			Buffer.BlockCopy(BitConverter.GetBytes(length + 9), 0, array, 2, 2);
			Buffer.BlockCopy(toSendBuff, 0, array, 5, length);
			array[array.Length - 2] = 85;
			array[array.Length - 1] = 170;
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value?.系统提示(toolStripTextBox2.Text, int.Parse(toolStripComboBox1.SelectedItem.ToString()), "系统信息");
				}
			}
			catch
			{
			}
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			PerformUserLoginCheck();
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (MapClass value in World.Map.Values)
				{
					foreach (NpcClass value2 in value.npcTemplate.Values)
					{
						value2.getbl();
					}
				}
				foreach (TeamClass value3 in World.Teams.Values)
				{
					WriteLine(2, "组队:" + value3.组队id + " 人物：" + value3.组队列表.Count);
					foreach (Players value4 in value3.组队列表.Values)
					{
						WriteLine(2, "组队员:" + value4.Userid + " 人物：" + value4.UserName);
					}
				}
				foreach (Players value5 in World.AllConnectedPlayers.Values)
				{
				}
				foreach (object item in World.locklist3)
				{
					WriteLine(2, item.ToString());
				}
			}
			catch (Exception ex)
			{
				WriteLine(1, ex.ToString());
			}
			GC.Collect();
		}

		public void PerformUserLoginCheck()
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (NetState value3 in World.ConnectionList.Values)
				{
					if (value3.换线中)
					{
						continue;
					}
					string value = "NULL";
					int value4 = 0;
					if (value3.挂机)
					{
						value4 = 1;
					}
					else if (value3.假人)
					{
						value4 = 2;
					}
					int value5 = 0;
					string value6 = string.Empty;
					string value7 = string.Empty;
					int value8 = 0;
					string value9 = string.Empty;
					string value10 = string.Empty;
					int value11 = 0;
					int value2 = 0;
					Players players = World.检查玩家世界ID(value3.WorldId);
					if (players != null)
					{
						value = players.UserName;
						value5 = players.原服务器序号;
						value6 = players.原服务器IP;
						value7 = players.原服务器端口.ToString();
						value8 = players.原服务器ID;
						value9 = players.银币广场服务器IP;
						value10 = players.银币广场服务器端口.ToString();
						value2 = players.Player_Job;
						if (players.FLD_VIP == 1)
						{
							value11 = 1;
						}
					}
					stringBuilder.Append(value3.Player.Userid);
					stringBuilder.Append("-");
					stringBuilder.Append(value3.ToString());
					stringBuilder.Append("-");
					stringBuilder.Append(value3.绑定帐号);
					stringBuilder.Append("-");
					stringBuilder.Append(value4);
					stringBuilder.Append("-");
					stringBuilder.Append(value);
					stringBuilder.Append("-");
					stringBuilder.Append(value5);
					stringBuilder.Append("-");
					stringBuilder.Append(value6);
					stringBuilder.Append("-");
					stringBuilder.Append(value7);
					stringBuilder.Append("-");
					stringBuilder.Append(value8);
					stringBuilder.Append("-");
					stringBuilder.Append(value9);
					stringBuilder.Append("-");
					stringBuilder.Append(value10);
					stringBuilder.Append("-");
					stringBuilder.Append(value3.WorldId);
					stringBuilder.Append("-");
					stringBuilder.Append(value11);
					stringBuilder.Append("-");
					stringBuilder.Append(value2);
					stringBuilder.Append(",");
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
				}
				World.conn.发送("复查用户登陆|" + stringBuilder);
				if (World.AutGC != 0)
				{
					GC.Collect();
				}
			}
			catch (Exception ex)
			{
				WriteLine(1, "复查用户登陆 错误" + ex.Message);
			}
		}

		private void GraphPanel_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Graphics graphics = e.Graphics;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.PixelOffsetMode = PixelOffsetMode.None;
				string s = "连接:" + World.ConnectionList.Count + "/" + World.MaxOnline + " 总在线:" + World.IpList.Count + " 真实IP:" + World.PrivateTeams.Count + " 主Socket:" + World.MainSocket + " SocketState:" + World.SocketState + " 组队:" + World.Teams.Count + " 离线队列:" + World.DisposedQueue.Count + " 数据库队列:" + World.SqlPool.Count + " 狮子列队:" + World.LionRoarList.Count + " 源多多资源网:yuandd.Net";
				graphics.DrawString(s, Control.DefaultFont, Brushes.Black, new Point(20, 5));
				int num = 0;
				foreach (LogEntry item in logEntries)
				{
					switch (item.type)
					{
					default:
						graphics.DrawString(item.Txt, Control.DefaultFont, Brushes.Black, new Point(5, num += 17));
						break;
					case 0:
						graphics.DrawString(item.Txt, Control.DefaultFont, Brushes.Black, new Point(5, num += 17));
						break;
					case 1:
						graphics.DrawString(item.Txt, Control.DefaultFont, Brushes.Red, new Point(5, num += 17));
						break;
					case 2:
						graphics.DrawString(item.Txt, Control.DefaultFont, Brushes.Black, new Point(5, num += 17));
						break;
					case 3:
						graphics.DrawString(item.Txt, Control.DefaultFont, Brushes.Green, new Point(5, num += 17));
						break;
					case 4:
						graphics.DrawString(item.Txt, Control.DefaultFont, Brushes.Teal, new Point(5, num += 17));
						break;
					case 5:
						graphics.DrawString(item.Txt, Control.DefaultFont, Brushes.DodgerBlue, new Point(5, num += 17));
						break;
					case 6:
						graphics.DrawString(item.Txt, Control.DefaultFont, Brushes.Blue, new Point(5, num += 17));
						break;
					}
				}
			}
			catch
			{
			}
		}

		public static void WriteLine(int type, string txtt)
		{
			int num = displayHeight / 18;
			lock (logEntries)
			{
				switch (type)
				{
				case 9:
					logo.zhtfTxtLog(txtt);
					return;
				case 100:
				{
					logo.FileTxtLog(txtt);
					logEntries.Add(new LogEntry(type, DateTime.Now.ToString() + " " + txtt));
					int count = logEntries.Count;
					if (num <= 0)
					{
						num = 20;
					}
					if (count > num)
					{
						for (int i = 0; i < count - num; i++)
						{
							logEntries.RemoveAt(0);
						}
					}
					return;
				}
				case 101:
				{
					logo.WGTxtLog(txtt);
					logEntries.Add(new LogEntry(type, DateTime.Now.ToString() + " " + txtt));
					int count2 = logEntries.Count;
					if (num <= 0)
					{
						num = 20;
					}
					if (count2 > num)
					{
						for (int j = 0; j < count2 - num; j++)
						{
							logEntries.RemoveAt(0);
						}
					}
					return;
				}
				}
				if (!World.AlWorldlog)
				{
					return;
				}
				if (World.jllog == 1)
				{
					switch (type)
					{
					case 1:
						logo.FileTxtLog(txtt);
						break;
					case 2:
						logo.FileCQTxtLog(txtt);
						break;
					case 3:
						logo.FileLoninTxtLog(txtt);
						break;
					case 4:
						logo.FileDropItmeTxtLog(txtt);
						break;
					case 5:
						logo.FileItmeTxtLog(txtt);
						break;
					case 6:
						logo.FileBugTxtLog(txtt);
						break;
					case 7:
						logo.FilePakTxtLog(txtt);
						break;
					case 8:
						logo.SeveTxtLog(txtt);
						break;
					}
				}
				switch (type)
				{
				case 99:
					logo.FileTxtLog(txtt);
					break;
				case 88:
					logo.pzTxtLog(txtt);
					break;
				case 77:
					logo.cfzTxtLog(txtt);
					break;
				}
				logEntries.Add(new LogEntry(type, DateTime.Now.ToString() + " " + txtt));
				int count3 = logEntries.Count;
				if (num <= 0)
				{
					num = 20;
				}
				if (count3 > num)
				{
					for (int k = 0; k < count3 - num; k++)
					{
						logEntries.RemoveAt(0);
					}
				}
			}
		}

		private void menuItem33_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(Form2.FlushAll1)
			{
				Name = "Timer Thread"
			};
			thread.Start();
		}

		private void menuItem34_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(Form2.FlushAll2)
			{
				Name = "Timer Thread"
			};
			thread.Start();
		}

		private void menuItem35_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(Form2.FlushAll3)
			{
				Name = "Timer Thread"
			};
			thread.Start();
		}

		private void menuItem36_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(Form2.FlushAll4)
			{
				Name = "Timer Thread"
			};
			thread.Start();
		}

		private void Form1_Layout(object sender, LayoutEventArgs e)
		{
			if (GraphPanel.Height != 0)
			{
				displayHeight = GraphPanel.Height;
			}
		}

		private void menuItem37_Click(object sender, EventArgs e)
		{
			int num = (int)new Form2().ShowDialog();
		}

		private void menuItem38_Click(object sender, EventArgs e)
		{
			if (menuItem38.Checked)
			{
				menuItem38.Checked = false;
				World.Droplog = false;
			}
			else
			{
				menuItem38.Checked = true;
				World.Droplog = true;
			}
		}

		private void menuItem39_Click(object sender, EventArgs e)
		{
			world.SetScript();
		}

		private void menuItem41_Click(object sender, EventArgs e)
		{
		}

		private void menuItem42_Click(object sender, EventArgs e)
		{
			world.LoadCraftingItems();
		}

		private void menuItem43_Click(object sender, EventArgs e)
		{
			world.SetBbgItem();
			world.加载百宝阁抽奖();
		}

		private void menuItem44_Click(object sender, EventArgs e)
		{
			world.Set套装();
		}

		private void menuItem45_Click(object sender, EventArgs e)
		{
			world.Set等级奖励();
		}

		private void menuItem24_Click(object sender, EventArgs e)
		{
			world.Set物品兑换();
		}

		private void menuItem49_Click(object sender, EventArgs e)
		{
			int num = (int)new YbiForm().ShowDialog();
		}

		private void menuItem50_Click(object sender, EventArgs e)
		{
			world.Set移动();
		}

		private void menuItem52_Click(object sender, EventArgs e)
		{
			world.Set任务数据新();
		}

		private void menuItem46_Click(object sender, EventArgs e)
		{
			world.SetQG();
			world.Set升天气功();
		}

		private void menuItem48_Click(object sender, EventArgs e)
		{
			new NpcList().Show();
		}

		private void menuItem53_Click(object sender, EventArgs e)
		{
			world.Set石头属性();
		}

		private void menuItem54_Click(object sender, EventArgs e)
		{
			if (World.修炼之地开启ID == 0)
			{
				World.修炼之地开启ID = 1;
				World.GlobalNotification("系统提示", 6, "修炼地区开启, 修炼时间为2小时。");
				WriteLine(1, "修炼之地开启！");
				menuItem54.Text = "结束修炼之地";
			}
			else
			{
				World.修炼之地开启ID = 0;
				World.GlobalNotification("系统提示", 6, "修炼时间结束。");
				WriteLine(1, "修炼之地结束！");
				menuItem54.Text = "开始修炼之地";
			}
		}

		private void menuItem55_Click(object sender, EventArgs e)
		{
			new StoneConfig().Show();
		}

		private void menuItem47_Click(object sender, EventArgs e)
		{
			new SkillContrl().Show();
		}

		private void menuItem58_Click(object sender, EventArgs e)
		{
			int num = (int)new BinIP().ShowDialog();
		}

		private void menuItem31_Click_1(object sender, EventArgs e)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.Client != null)
					{
						value.SavePlayerData();
						value.保存个人仓库存储过程();
						value.保存综合仓库存储过程();
						value.保存宠物仓库存储过程();
						value.保存灵兽仓库存储过程();
					}
				}
			}
			catch (Exception ex)
			{
				WriteLine(1, "保存人物的数据出错|" + ex.Message);
			}
			WriteLine(6, "保存人物所有数据完成");
		}

		private void menuItem60_Click(object sender, EventArgs e)
		{
			if (World.ImmortalDemonWar == null)
			{
				World.ImmortalDemonWar = new 仙魔大战Class();
				WriteLine(2, "仙魔大战开始啦再次点击关闭仙魔大战");
				menuItem60.Text = "结束仙魔大战";
			}
			else
			{
				World.ImmortalDemonWar.Dispose();
				WriteLine(2, "仙魔大战结束啦再次点击开启仙魔大战");
				menuItem60.Text = "开始仙魔大战";
			}
		}

		private void menuItem61_Click(object sender, EventArgs e)
		{
			if (World.SiegeWar == null)
			{
				World.SiegeWar = new 攻城Class();
				WriteLine(2, "单线攻城战开启成功");
				menuItem61.Text = "结束攻城战";
			}
			else
			{
				World.SiegeWar.Dispose();
				WriteLine(2, "单线攻城战结束");
				menuItem61.Text = "开启攻城战";
			}
		}

		private void menuItem62_Click(object sender, EventArgs e)
		{
			if (World.GuildWar == null)
			{
				World.是否开启门战系统 = 1;
				World.胜利帮派ID = 0;
				World.GuildWar = new 帮派战_门战();
				WriteLine(2, "帮战开始成功");
				menuItem62.Text = "结束帮战";
			}
			else
			{
				World.是否开启门战系统 = 0;
				World.GuildWar.Dispose();
				World.GuildWar = null;
				WriteLine(2, "帮战结束成功");
				menuItem62.Text = "开启帮战";
			}
		}

		private void menuItem63_Click(object sender, EventArgs e)
		{
			try
			{
				if (World.MartialBloodBattleProgress == 0)
				{
					if (World.PersonalBloodBattle != null)
					{
						World.PersonalBloodBattle.Dispose();
						World.PersonalBloodBattle = null;
					}
					World.PersonalBloodBattle = new 武林血战();
					WriteLine(1, "武林血战开始！");
					menuItem63.Text = "结束武林血战";
				}
				else if (MessageBox.Show("个人血战正在进行中确定要结束么？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (World.PersonalBloodBattle != null)
					{
						World.PersonalBloodBattle.Dispose();
						World.PersonalBloodBattle = null;
					}
					WriteLine(1, "武林血战结束！");
					menuItem63.Text = "开始武林血战";
				}
			}
			catch (Exception)
			{
			}
		}

		private void menuItem51_Click_2(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定要删除记录数据吗..", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				string sqlCommand = "DELETE FROM 百宝记录";
				string sqlCommand5 = "DELETE FROM 掉落记录";
				string sqlCommand6 = "DELETE FROM 登陆记录";
				string sqlCommand7 = "DELETE FROM 合成记录";
				string sqlCommand8 = "DELETE FROM 商店记录";
				string sqlCommand9 = "DELETE FROM 物品记录";
				string sqlCommand10 = "DELETE FROM 药品记录";
				string sqlCommand11 = "DELETE FROM 元宝记录";
				string sqlCommand12 = "DELETE FROM 开盒记录";
				string sqlCommand2 = "DELETE FROM 进化记录";
				string sqlCommand3 = "DELETE FROM 卡号记录";
				string sqlCommand4 = "DELETE FROM TBL_传书系统";
				DBA.ExeSqlCommand(sqlCommand, "GameServer");
				DBA.ExeSqlCommand(sqlCommand5, "GameServer");
				DBA.ExeSqlCommand(sqlCommand6, "GameServer");
				DBA.ExeSqlCommand(sqlCommand7, "GameServer");
				DBA.ExeSqlCommand(sqlCommand8, "GameServer");
				DBA.ExeSqlCommand(sqlCommand9, "GameServer");
				DBA.ExeSqlCommand(sqlCommand10, "GameServer");
				DBA.ExeSqlCommand(sqlCommand11, "GameServer");
				DBA.ExeSqlCommand(sqlCommand12, "GameServer");
				DBA.ExeSqlCommand(sqlCommand2, "GameServer");
				DBA.ExeSqlCommand(sqlCommand3, "GameServer");
				DBA.ExeSqlCommand(sqlCommand4, "GameServer");
				WriteLine(2, "数据库全部记录表清楚完成");
			}
		}

		private void menuItem59_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定要删除" + World.ZoneNumber + "人物吗..", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				string sqlCommand = string.Format("DELETE FROM EventTop where 分区信息='" + World.ZoneNumber + "'");
				string sqlCommand3 = string.Format("DELETE FROM TBL_XWWL_Char where FLD_FQID='" + World.ZoneNumber + "'");
				string sqlCommand4 = string.Format("DELETE FROM TBL_玫瑰花排行榜 where FLD_FQ='" + World.ZoneNumber + "'");
				string sqlCommand5 = string.Format("DELETE FROM TBL_荣誉系统 where FLD_FQ='" + World.ZoneNumber + "'");
				string sqlCommand6 = string.Format("DELETE FROM 攻城城主 where 分区信息='" + World.ZoneNumber + "'");
				string sqlCommand7 = string.Format("DELETE FROM 门战胜利门派 where 分区信息='" + World.ZoneNumber + "'");
				string sqlCommand8 = string.Format("DELETE FROM 荣誉门派排行 where FLD_FQ='" + World.ZoneNumber + "'");
				string sqlCommand9 = string.Format("DELETE FROM 荣誉势力排行 where FLD_FQ='" + World.ZoneNumber + "'");
				string sqlCommand10 = string.Format("DELETE FROM 荣誉讨伐排行 where FLD_FQ='" + World.ZoneNumber + "'");
				string sqlCommand2 = string.Format("DELETE FROM 荣誉武林排行 where FLD_FQ='" + World.ZoneNumber + "'");
				DBA.ExeSqlCommand(sqlCommand, "GameServer");
				DBA.ExeSqlCommand(sqlCommand3, "GameServer");
				DBA.ExeSqlCommand(sqlCommand4, "GameServer");
				DBA.ExeSqlCommand(sqlCommand5, "GameServer");
				DBA.ExeSqlCommand(sqlCommand6, "GameServer");
				DBA.ExeSqlCommand(sqlCommand7, "GameServer");
				DBA.ExeSqlCommand(sqlCommand8, "GameServer");
				DBA.ExeSqlCommand(sqlCommand9, "GameServer");
				DBA.ExeSqlCommand(sqlCommand10, "GameServer");
				DBA.ExeSqlCommand(sqlCommand2, "GameServer");
				WriteLine(2, "所有分区数据库清楚完成");
			}
		}

		private void menuItem64_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定要删除" + World.ZoneNumber + "账号吗..", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				string sqlCommand = string.Format("DELETE FROM TBL_ACCOUNT where FLD_FQ='" + World.ZoneNumber + "' and 是否假人=0");
				DBA.ExeSqlCommand(sqlCommand, "rxjhaccount");
				WriteLine(2, "所有分区账号库清楚完成");
			}
		}

		private void menuItem65_Click(object sender, EventArgs e)
		{
			if (World.EnableUnisonSpeech == null)
			{
				World.EnableUnisonSpeech = new 异口同声();
				WriteLine(2, "异口同声开启完成");
				menuItem65.Text = "结束异口同声";
			}
			else
			{
				World.EnableUnisonSpeech.Dispose();
				World.EnableUnisonSpeech = null;
				WriteLine(2, "异口同声结束完成");
				menuItem65.Text = "开启异口同声";
			}
		}

		private void menuItem66_Click(object sender, EventArgs e)
		{
			if (World.EnableServerWideExp == null)
			{
				World.EnableServerWideExp = new 全服经验();
				World.发送公告("全服双倍已经开启, 请各位大侠做好准备");
				WriteLine(2, "双倍经验开始");
				menuItem66.Text = "结束全服双倍";
			}
			else
			{
				World.EnableServerWideExp.Dispose();
				World.EnableServerWideExp = null;
				WriteLine(2, "双倍经验结束");
				menuItem66.Text = "开启全服双倍";
			}
		}

		private void menuItem41_Click_1(object sender, EventArgs e)
		{
			world.加载装备洗髓();
			WriteLine(2, "装备洗髓加载完成");
		}

		private void menuItem57_Click(object sender, EventArgs e)
		{
			world.加载披风收录();
			WriteLine(2, "披风收录加载完成");
		}

		private void menuItem68_Click(object sender, EventArgs e)
		{
			world.加载英雄职业武器();
			WriteLine(2, "英雄职业武器加载完成");
		}

		private void menuItem69_Click(object sender, EventArgs e)
		{
			GMGJ gMGJ = new GMGJ();
			gMGJ.StartPosition = FormStartPosition.CenterParent;
			gMGJ.ShowDialog();
		}

		private void menuItem70_Click(object sender, EventArgs e)
		{
			if (World.BossSiege == null)
			{
				World.BossSiege = new boss攻城();
				WriteLine(2, "boss开始");
				menuItem70.Text = "结束boss攻城";
			}
			else
			{
				World.BossSiege.Dispose();
				World.BossSiege = null;
				WriteLine(2, "boss结束");
				menuItem70.Text = "开启boss攻城";
			}
		}

		private void menuItem71_Click(object sender, EventArgs e)
		{
			if (World.WorldBoss == null)
			{
				World.WorldBoss = new 世界BOSS();
				WriteLine(2, "世界boss 开始");
				menuItem71.Text = "结束世界boss ";
			}
			else
			{
				World.WorldBoss.Dispose();
				World.WorldBoss = null;
				WriteLine(2, "世界boss 结束");
				menuItem71.Text = "开启世界boss ";
			}
		}

		private void menuItem72_Click(object sender, EventArgs e)
		{
			if (menuItem72.Checked)
			{
				menuItem72.Checked = false;
				World.开启下雪场景 = 0;
			}
			else
			{
				menuItem72.Checked = true;
				World.开启下雪场景 = 1;
			}
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				value.更新服务器时间和场景();
			}
		}

		private void menuItem73_Click(object sender, EventArgs e)
		{
			游戏公告 游戏公告2 = new 游戏公告
			{
				StartPosition = FormStartPosition.CenterParent
			};
			游戏公告2.ShowDialog();
		}

		private void menuItem74_Click(object sender, EventArgs e)
		{
			Move move = new Move
			{
				StartPosition = FormStartPosition.CenterParent
			};
			move.ShowDialog();
		}

		private void menuItem75_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定要删除记录数据吗..", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				string sqlCommand = "DELETE FROM TBL_XWWL_Cw";
				string sqlCommand6 = "DELETE FROM TBL_XWWL_CWarehouse";
				string sqlCommand7 = "DELETE FROM TBL_XWWL_Guild";
				string sqlCommand8 = "DELETE FROM TBL_XWWL_GuildMember";
				string sqlCommand9 = "DELETE FROM TBL_XWWL_PublicWarehouse";
				string sqlCommand10 = "DELETE FROM TBL_XWWL_Warehouse";
				string sqlCommand11 = "DELETE FROM TBL_师徒数据";
				string sqlCommand12 = "DELETE FROM TBL_仙魔大战";
				string sqlCommand13 = "DELETE FROM EventTop";
				string sqlCommand2 = "DELETE FROM TBL_XWWL_LSarehouse";
				string sqlCommand3 = "DELETE FROM TBL_XWWL_PKLog";
				string sqlCommand4 = "DELETE FROM TBL_XWWL_PVP";
				string sqlCommand5 = "DELETE FROM 卡号记录";
				DBA.ExeSqlCommand(sqlCommand, "GameServer");
				DBA.ExeSqlCommand(sqlCommand6, "GameServer");
				DBA.ExeSqlCommand(sqlCommand7, "GameServer");
				DBA.ExeSqlCommand(sqlCommand8, "GameServer");
				DBA.ExeSqlCommand(sqlCommand9, "GameServer");
				DBA.ExeSqlCommand(sqlCommand10, "GameServer");
				DBA.ExeSqlCommand(sqlCommand11, "GameServer");
				DBA.ExeSqlCommand(sqlCommand12, "GameServer");
				DBA.ExeSqlCommand(sqlCommand13, "GameServer");
				DBA.ExeSqlCommand(sqlCommand2, "GameServer");
				DBA.ExeSqlCommand(sqlCommand3, "GameServer");
				DBA.ExeSqlCommand(sqlCommand4, "GameServer");
				DBA.ExeSqlCommand(sqlCommand5, "GameServer");
				WriteLine(2, "数据库其他记录清楚完成");
			}
		}

		private void menuItem76_Click(object sender, EventArgs e)
		{
			全体跨线 全体跨线2 = new 全体跨线
			{
				StartPosition = FormStartPosition.CenterParent
			};
			全体跨线2.ShowDialog();
		}

		private void menuItem78_Click(object sender, EventArgs e)
		{
			Form3 form = new Form3
			{
				StartPosition = FormStartPosition.CenterParent
			};
			form.ShowDialog();
		}

		private void menuItem79_Click(object sender, EventArgs e)
		{
			if (World.eve == null)
			{
				World.势力战参加最低转职 = 2;
				World.势力战参加最高转职 = 10;
				World.势力战类型 = 0;
				World.eve = new EventClass();
				WriteLine(2, "势力战开始啦再次点击关闭势力战");
				menuItem79.Checked = true;
			}
			else
			{
				World.eve.Dispose();
				World.eve = null;
				WriteLine(2, "势力战结束啦再次点击开启势力战");
				menuItem79.Checked = false;
			}
		}

		private void menuItem80_Click(object sender, EventArgs e)
		{
			world.boss攻城怪物();
		}

		private void menuItem81_Click(object sender, EventArgs e)
		{
			if (World.FieldBoss == null)
			{
				World.FieldBoss = new 野外BOSS();
				WriteLine(2, "野外boss 开始");
				menuItem81.Text = "结束野外boss ";
			}
			else
			{
				World.FieldBoss.Dispose();
				World.FieldBoss = null;
				WriteLine(2, "野外boss 结束");
				menuItem81.Text = "开启野外boss ";
			}
		}

		private void menuItem82_Click(object sender, EventArgs e)
		{
			world.boss伏魔洞怪物();
		}

		private void menuItem83_Click(object sender, EventArgs e)
		{
			world.加载物品回收();
		}

		private void menuItem84_Click(object sender, EventArgs e)
		{
			if (menuItem84.Checked)
			{
				menuItem84.Checked = false;
				World.是否开启安全码 = 0;
			}
			else
			{
				menuItem84.Checked = true;
				World.是否开启安全码 = 1;
			}
		}

		private void menuItem85_Click(object sender, EventArgs e)
		{
			if (menuItem85.Checked)
			{
				menuItem85.Checked = false;
				World.是否开启票红字 = 0;
			}
			else
			{
				menuItem85.Checked = true;
				World.是否开启票红字 = 1;
			}
		}

		private void menuItem86_Click(object sender, EventArgs e)
		{
			if (menuItem86.Checked)
			{
				menuItem86.Checked = false;
				World.是否开启公告掉落提示 = 0;
			}
			else
			{
				menuItem86.Checked = true;
				World.是否开启公告掉落提示 = 1;
			}
		}

		private void menuItem87_Click(object sender, EventArgs e)
		{
			if (menuItem87.Checked)
			{
				menuItem87.Checked = false;
				World.是否开启多开提示 = 0;
			}
			else
			{
				menuItem87.Checked = true;
				World.是否开启多开提示 = 1;
			}
		}

		private void menuItem88_Click(object sender, EventArgs e)
		{
			if (menuItem88.Checked)
			{
				menuItem88.Checked = false;
				World.是否开启票红字2 = 0;
			}
			else
			{
				menuItem88.Checked = true;
				World.是否开启票红字2 = 1;
			}
		}

		private void menuItem89_Click(object sender, EventArgs e)
		{
			world.加载累计充值礼包();
			WriteLine(2, "累计充值礼包加载完成");
		}

		private void menuItem91_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定要删除" + World.ZoneNumber + "分区90天未登陆账号吗..", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				string sqlCommand = string.Format("DELETE FROM TBL_ACCOUNT where FLD_FQ='" + World.ZoneNumber + "'and 是否假人=0 and DateDiff(dd, FLD_LASTLOGINTIME, getdate())>90");
				DBA.ExeSqlCommand(sqlCommand, "rxjhaccount");
				WriteLine(55, "90天未登陆分区账号库清楚完成");
			}
		}

		private void menuItem90_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定要删除" + World.ZoneNumber + "分区60天未登陆账号吗..", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				string sqlCommand = string.Format("DELETE FROM TBL_ACCOUNT where FLD_FQ='" + World.ZoneNumber + "'and 是否假人=0 and DateDiff(dd, FLD_LASTLOGINTIME, getdate())>60");
				DBA.ExeSqlCommand(sqlCommand, "rxjhaccount");
				WriteLine(55, "60天未登陆分区账号库清楚完成");
			}
		}

		private void menuItem67_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("确定要删除" + World.ZoneNumber + "分区30天未登陆账号吗..", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
			{
				string sqlCommand = string.Format("DELETE FROM TBL_ACCOUNT where FLD_FQ='" + World.ZoneNumber + "'and 是否假人=0 and DateDiff(dd, FLD_LASTLOGINTIME, getdate())>30");
				DBA.ExeSqlCommand(sqlCommand, "rxjhaccount");
				WriteLine(55, "30天未登陆分区账号库清楚完成");
			}
		}

		private void menuItem92_Click(object sender, EventArgs e)
		{
			if (World.ArenaIdling == null)
			{
				World.ArenaIdling = new 比武泡点系统();
				WriteLine(2, "比武泡点 开始");
			}
			else
			{
				World.ArenaIdling.Dispose();
				World.ArenaIdling = null;
				WriteLine(2, "比武泡点 结束");
			}
		}

		private void menuItem93_Click(object sender, EventArgs e)
		{
			world.Set比武泡点奖励();
		}

		private void menuItem94_Click(object sender, EventArgs e)
		{
			GMGJ gMGJ = new GMGJ();
			gMGJ.StartPosition = FormStartPosition.CenterParent;
			gMGJ.ShowDialog();
		}

		private void menuItem95_Click(object sender, EventArgs e)
		{
			world.SetLever();
		}

		private void menuItem96_Click(object sender, EventArgs e)
		{
			if (menuItem96.Checked)
			{
				menuItem96.Checked = false;
				World.开启下雪场景 = 0;
			}
			else
			{
				menuItem96.Checked = true;
				World.开启下雪场景 = 1;
			}
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				value.更新服务器时间和场景();
			}
		}

		private void menuItem99_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "确定要清理所有杀人/被杀次数吗？清理后不可恢复", "确定删除吗？", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				if (value != null)
				{
					value.杀人次数 = 0;
					value.被杀次数 = 0;
					value.SavePlayerData();
				}
			}
			string string_ = "UPDATE TBL_XWWL_Char SET 杀人次数=0";
			string string_2 = "UPDATE TBL_XWWL_Char SET 被杀次数=0";
			DBA.ExeSqlCommand(string_);
			DBA.ExeSqlCommand(string_2);
			WriteLine(0, "清理人物杀人/被杀次数完成");
		}

		private void menuItem100_Click(object sender, EventArgs e)
		{
			DBA.ExeSqlCommand("DELETE FROM TBL_XWWL_RoseTop");
			WriteLine(2, "花榜数据清理完成");
		}

		private void menuItem101_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "确定要删除所有用户贡献数据吗？删除后不可恢复", "确定删除吗？", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}
			foreach (Players value in World.AllConnectedPlayers.Values)
			{
				if (value != null)
				{
					value.门派贡献度 = 0;
					value.SavePlayerData();
				}
			}
			string string_ = "UPDATE TBL_XWWL_Char SET 门派贡献度=0";
			DBA.ExeSqlCommand(string_);
			WriteLine(0, "清理人物贡献完成");
		}

		private void menuItem102_Click(object sender, EventArgs e)
		{
			string string_ = "DELETE FROM TBL_XWWL_Cw";
			string string_12 = "DELETE FROM TBL_XWWL_CWarehouse";
			string string_23 = "DELETE FROM TBL_XWWL_Guild";
			string string_26 = "DELETE FROM TBL_XWWL_GuildMember";
			string string_27 = "DELETE FROM TBL_XWWL_PKLog";
			string string_28 = "DELETE FROM TBL_XWWL_PublicWarehouse";
			string string_29 = "DELETE FROM TBL_XWWL_RoseTop";
			string string_30 = "DELETE FROM TBL_XWWL_Warehouse";
			string string_31 = "DELETE FROM TBL_传书系统";
			string string_2 = "DELETE FROM TBL_荣誉系统";
			string string_3 = "DELETE FROM 百宝记录";
			string string_4 = "DELETE FROM 帮战赌注";
			string string_5 = "DELETE FROM 登陆记录";
			string string_6 = "DELETE FROM 荣誉门派排行";
			string string_7 = "DELETE FROM 物品记录";
			string string_8 = "DELETE FROM 比武泡点Top";
			string string_9 = "DELETE FROM 掉落记录";
			string string_10 = "DELETE FROM 攻城城主";
			string string_11 = "DELETE FROM 合成记录";
			string string_13 = "DELETE FROM 进化记录";
			string string_14 = "DELETE FROM 卡号记录";
			string string_15 = "DELETE FROM 开盒记录";
			string string_16 = "DELETE FROM 门战胜利门派";
			string string_17 = "DELETE FROM 荣誉势力排行";
			string string_18 = "DELETE FROM 荣誉讨伐排行";
			string string_19 = "DELETE FROM 荣誉武林排行";
			string string_20 = "DELETE FROM 商店记录";
			string string_21 = "DELETE FROM 物品记录";
			string string_22 = "DELETE FROM 仙魔大战Top";
			string string_24 = "DELETE FROM 药品记录";
			string string_25 = "DELETE FROM 元宝记录";
			DBA.ExeSqlCommand("DELETE FROM EventTop", "GameServer");
			DBA.ExeSqlCommand("DELETE FROM TBL_XWWL_Char", "GameServer");
			DBA.ExeSqlCommand(string_, "GameServer");
			DBA.ExeSqlCommand(string_12, "GameServer");
			DBA.ExeSqlCommand(string_23, "GameServer");
			DBA.ExeSqlCommand(string_26, "GameServer");
			DBA.ExeSqlCommand(string_27, "GameServer");
			DBA.ExeSqlCommand(string_28, "GameServer");
			DBA.ExeSqlCommand(string_29, "GameServer");
			DBA.ExeSqlCommand(string_30, "GameServer");
			DBA.ExeSqlCommand(string_31, "GameServer");
			DBA.ExeSqlCommand(string_2, "GameServer");
			DBA.ExeSqlCommand(string_3, "GameServer");
			DBA.ExeSqlCommand(string_4, "GameServer");
			DBA.ExeSqlCommand(string_5, "GameServer");
			DBA.ExeSqlCommand(string_6, "GameServer");
			DBA.ExeSqlCommand(string_7, "GameServer");
			DBA.ExeSqlCommand(string_8, "GameServer");
			DBA.ExeSqlCommand(string_9, "GameServer");
			DBA.ExeSqlCommand(string_10, "GameServer");
			DBA.ExeSqlCommand(string_11, "GameServer");
			DBA.ExeSqlCommand(string_13, "GameServer");
			DBA.ExeSqlCommand(string_14, "GameServer");
			DBA.ExeSqlCommand(string_15, "GameServer");
			DBA.ExeSqlCommand(string_16, "GameServer");
			DBA.ExeSqlCommand(string_17, "GameServer");
			DBA.ExeSqlCommand(string_18, "GameServer");
			DBA.ExeSqlCommand(string_19, "GameServer");
			DBA.ExeSqlCommand(string_20, "GameServer");
			DBA.ExeSqlCommand(string_21, "GameServer");
			DBA.ExeSqlCommand(string_22, "GameServer");
			DBA.ExeSqlCommand(string_24, "GameServer");
			DBA.ExeSqlCommand(string_25, "GameServer");
			WriteLine(2, "所有人物数据都已经清理完成");
		}

		private void menuItem103_Click(object sender, EventArgs e)
		{
			DBA.ExeSqlCommand("DELETE FROM TBL_ACCOUNT", "rxjhaccount");
			WriteLine(2, "所有账号数据都已经清理完成");
		}

		private void menuItem104_Click(object sender, EventArgs e)
		{
		}

		private void menuItem108_Click(object sender, EventArgs e)
		{
			DBA.ExeSqlCommand("DELETE FROM TBL_ACCOUNT", "rxjhaccount");
			string string_ = "DELETE FROM TBL_XWWL_Cw";
			string string_12 = "DELETE FROM TBL_XWWL_CWarehouse";
			string string_23 = "DELETE FROM TBL_XWWL_Guild";
			string string_26 = "DELETE FROM TBL_XWWL_GuildMember";
			string string_27 = "DELETE FROM TBL_XWWL_PKLog";
			string string_28 = "DELETE FROM TBL_XWWL_PublicWarehouse";
			string string_29 = "DELETE FROM TBL_XWWL_RoseTop";
			string string_30 = "DELETE FROM TBL_XWWL_Warehouse";
			string string_31 = "DELETE FROM TBL_传书系统";
			string string_2 = "DELETE FROM TBL_荣誉系统";
			string string_3 = "DELETE FROM 百宝记录";
			string string_4 = "DELETE FROM 帮战赌注";
			string string_5 = "DELETE FROM 登陆记录";
			string string_6 = "DELETE FROM 荣誉门派排行";
			string string_7 = "DELETE FROM 物品记录";
			string string_8 = "DELETE FROM 比武泡点Top";
			string string_9 = "DELETE FROM 掉落记录";
			string string_10 = "DELETE FROM 攻城城主";
			string string_11 = "DELETE FROM 合成记录";
			string string_13 = "DELETE FROM 进化记录";
			string string_14 = "DELETE FROM 卡号记录";
			string string_15 = "DELETE FROM 开盒记录";
			string string_16 = "DELETE FROM 门战胜利门派";
			string string_17 = "DELETE FROM 荣誉势力排行";
			string string_18 = "DELETE FROM 荣誉讨伐排行";
			string string_19 = "DELETE FROM 荣誉武林排行";
			string string_20 = "DELETE FROM 商店记录";
			string string_21 = "DELETE FROM 物品记录";
			string string_22 = "DELETE FROM 仙魔大战Top";
			string string_24 = "DELETE FROM 药品记录";
			string string_25 = "DELETE FROM 元宝记录";
			DBA.ExeSqlCommand("DELETE FROM EventTop", "GameServer");
			DBA.ExeSqlCommand("DELETE FROM TBL_XWWL_Char", "GameServer");
			DBA.ExeSqlCommand(string_, "GameServer");
			DBA.ExeSqlCommand(string_12, "GameServer");
			DBA.ExeSqlCommand(string_23, "GameServer");
			DBA.ExeSqlCommand(string_26, "GameServer");
			DBA.ExeSqlCommand(string_27, "GameServer");
			DBA.ExeSqlCommand(string_28, "GameServer");
			DBA.ExeSqlCommand(string_29, "GameServer");
			DBA.ExeSqlCommand(string_30, "GameServer");
			DBA.ExeSqlCommand(string_31, "GameServer");
			DBA.ExeSqlCommand(string_2, "GameServer");
			DBA.ExeSqlCommand(string_3, "GameServer");
			DBA.ExeSqlCommand(string_4, "GameServer");
			DBA.ExeSqlCommand(string_5, "GameServer");
			DBA.ExeSqlCommand(string_6, "GameServer");
			DBA.ExeSqlCommand(string_7, "GameServer");
			DBA.ExeSqlCommand(string_8, "GameServer");
			DBA.ExeSqlCommand(string_9, "GameServer");
			DBA.ExeSqlCommand(string_10, "GameServer");
			DBA.ExeSqlCommand(string_11, "GameServer");
			DBA.ExeSqlCommand(string_13, "GameServer");
			DBA.ExeSqlCommand(string_14, "GameServer");
			DBA.ExeSqlCommand(string_15, "GameServer");
			DBA.ExeSqlCommand(string_16, "GameServer");
			DBA.ExeSqlCommand(string_17, "GameServer");
			DBA.ExeSqlCommand(string_18, "GameServer");
			DBA.ExeSqlCommand(string_19, "GameServer");
			DBA.ExeSqlCommand(string_20, "GameServer");
			DBA.ExeSqlCommand(string_21, "GameServer");
			DBA.ExeSqlCommand(string_22, "GameServer");
			DBA.ExeSqlCommand(string_24, "GameServer");
			DBA.ExeSqlCommand(string_25, "GameServer");
			WriteLine(2, "所有账号数据人物数据都已经清理完成");
		}

		private void UpdateHonorRankings_Click(object sender, EventArgs e)
		{
			World.UpdateAllRankingData();
			world.LoadGuildHonorRankings();
			WriteLine(2, "加载荣誉势力/花榜排名数据完成");
		}

		private void menuItem33_Click_1(object sender, EventArgs e)
		{
			world.安全地图区域();
		}
	}
}
