using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Authentication;
using Core;
using Database;
using Network.TCP;
using UI.Helpers;

namespace UI
{
	public class userlist : Form
	{
		private Dictionary<string, playerS> Players = new Dictionary<string, playerS>(4000);

		private IContainer components;

		private SplitContainer splitContainer1;

		private ListView listView1;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private Button button1;

		private TextBox textBox1;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem 踢IDToolStripMenuItem;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private ToolStripMenuItem 封号ToolStripMenuItem;

		private ToolStripMenuItem 天ToolStripMenuItem;

		private ToolStripMenuItem 天ToolStripMenuItem1;

		private ToolStripMenuItem 天ToolStripMenuItem2;

		private ToolStripMenuItem 月ToolStripMenuItem;

		private ToolStripMenuItem 永久ToolStripMenuItem;

		private ColumnHeader columnHeader8;

		private TextBox textBox2;

		private Button button2;

		private ToolStripMenuItem 封IPToolStripMenuItem;

		private ToolStripMenuItem 封绑定帐号ToolStripMenuItem;

		private ColumnHeader columnHeader9;

		private ToolStripMenuItem 加入限制ToolStripMenuItem;

		private ToolStripMenuItem 降低爆率ToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem32;

		private ToolStripMenuItem toolStripMenuItem33;

		private ToolStripMenuItem toolStripMenuItem34;

		private ToolStripMenuItem toolStripMenuItem35;

		private ToolStripMenuItem toolStripMenuItem36;

		private ToolStripMenuItem toolStripMenuItem37;

		private ToolStripMenuItem toolStripMenuItem38;

		private ToolStripMenuItem toolStripMenuItem39;

		private ToolStripMenuItem toolStripMenuItem40;

		private ToolStripMenuItem toolStripMenuItem41;

		private ToolStripMenuItem 降低经验ToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem22;

		private ToolStripMenuItem toolStripMenuItem23;

		private ToolStripMenuItem toolStripMenuItem24;

		private ToolStripMenuItem toolStripMenuItem25;

		private ToolStripMenuItem toolStripMenuItem26;

		private ToolStripMenuItem toolStripMenuItem27;

		private ToolStripMenuItem toolStripMenuItem28;

		private ToolStripMenuItem toolStripMenuItem29;

		private ToolStripMenuItem toolStripMenuItem30;

		private ToolStripMenuItem toolStripMenuItem31;

		private ToolStripMenuItem 降低金钱ToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem12;

		private ToolStripMenuItem toolStripMenuItem13;

		private ToolStripMenuItem toolStripMenuItem14;

		private ToolStripMenuItem toolStripMenuItem15;

		private ToolStripMenuItem toolStripMenuItem16;

		private ToolStripMenuItem toolStripMenuItem17;

		private ToolStripMenuItem toolStripMenuItem18;

		private ToolStripMenuItem toolStripMenuItem19;

		private ToolStripMenuItem toolStripMenuItem20;

		private ToolStripMenuItem toolStripMenuItem21;

		private ToolStripMenuItem 降低历练ToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem toolStripMenuItem3;

		private ToolStripMenuItem toolStripMenuItem4;

		private ToolStripMenuItem toolStripMenuItem5;

		private ToolStripMenuItem toolStripMenuItem6;

		private ToolStripMenuItem toolStripMenuItem7;

		private ToolStripMenuItem toolStripMenuItem8;

		private ToolStripMenuItem toolStripMenuItem9;

		private ToolStripMenuItem toolStripMenuItem10;

		private ToolStripMenuItem toolStripMenuItem11;

		private ColumnHeader columnHeader10;

		private ColumnHeader columnHeader11;

		private ToolStripMenuItem 启动teamViewerToolStripMenuItem;

		private ToolStripMenuItem 关闭登陆器ToolStripMenuItem;

		private ToolStripMenuItem 关闭客户端ToolStripMenuItem;

		private ToolStripMenuItem 禁用自动登陆ToolStripMenuItem;

		private ToolStripMenuItem 关机ToolStripMenuItem;

		private ToolStripMenuItem 重启ToolStripMenuItem;

		private ToolStripMenuItem 停止挂机ToolStripMenuItem;

		private ToolStripMenuItem 开始挂机ToolStripMenuItem;

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
            components = new Container();
            splitContainer1 = new SplitContainer();
            listView1 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            踢IDToolStripMenuItem = new ToolStripMenuItem();
            封号ToolStripMenuItem = new ToolStripMenuItem();
            天ToolStripMenuItem = new ToolStripMenuItem();
            天ToolStripMenuItem1 = new ToolStripMenuItem();
            天ToolStripMenuItem2 = new ToolStripMenuItem();
            月ToolStripMenuItem = new ToolStripMenuItem();
            永久ToolStripMenuItem = new ToolStripMenuItem();
            封IPToolStripMenuItem = new ToolStripMenuItem();
            封绑定帐号ToolStripMenuItem = new ToolStripMenuItem();
            加入限制ToolStripMenuItem = new ToolStripMenuItem();
            降低爆率ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem32 = new ToolStripMenuItem();
            toolStripMenuItem33 = new ToolStripMenuItem();
            toolStripMenuItem34 = new ToolStripMenuItem();
            toolStripMenuItem35 = new ToolStripMenuItem();
            toolStripMenuItem36 = new ToolStripMenuItem();
            toolStripMenuItem37 = new ToolStripMenuItem();
            toolStripMenuItem38 = new ToolStripMenuItem();
            toolStripMenuItem39 = new ToolStripMenuItem();
            toolStripMenuItem40 = new ToolStripMenuItem();
            toolStripMenuItem41 = new ToolStripMenuItem();
            降低经验ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem22 = new ToolStripMenuItem();
            toolStripMenuItem23 = new ToolStripMenuItem();
            toolStripMenuItem24 = new ToolStripMenuItem();
            toolStripMenuItem25 = new ToolStripMenuItem();
            toolStripMenuItem26 = new ToolStripMenuItem();
            toolStripMenuItem27 = new ToolStripMenuItem();
            toolStripMenuItem28 = new ToolStripMenuItem();
            toolStripMenuItem29 = new ToolStripMenuItem();
            toolStripMenuItem30 = new ToolStripMenuItem();
            toolStripMenuItem31 = new ToolStripMenuItem();
            降低金钱ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem12 = new ToolStripMenuItem();
            toolStripMenuItem13 = new ToolStripMenuItem();
            toolStripMenuItem14 = new ToolStripMenuItem();
            toolStripMenuItem15 = new ToolStripMenuItem();
            toolStripMenuItem16 = new ToolStripMenuItem();
            toolStripMenuItem17 = new ToolStripMenuItem();
            toolStripMenuItem18 = new ToolStripMenuItem();
            toolStripMenuItem19 = new ToolStripMenuItem();
            toolStripMenuItem20 = new ToolStripMenuItem();
            toolStripMenuItem21 = new ToolStripMenuItem();
            降低历练ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            启动teamViewerToolStripMenuItem = new ToolStripMenuItem();
            关闭登陆器ToolStripMenuItem = new ToolStripMenuItem();
            关闭客户端ToolStripMenuItem = new ToolStripMenuItem();
            禁用自动登陆ToolStripMenuItem = new ToolStripMenuItem();
            关机ToolStripMenuItem = new ToolStripMenuItem();
            重启ToolStripMenuItem = new ToolStripMenuItem();
            停止挂机ToolStripMenuItem = new ToolStripMenuItem();
            开始挂机ToolStripMenuItem = new ToolStripMenuItem();
            textBox2 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBox2);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Size = new Size(1352, 410);
            splitContainer1.SplitterDistance = 1130;
            splitContainer1.TabIndex = 4;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] {
            columnHeader5,
            columnHeader9,
            columnHeader1,
            columnHeader7,
            columnHeader8,
            columnHeader6,
            columnHeader2,
            columnHeader3,
            columnHeader4,
            columnHeader10,
            columnHeader11});
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.HideSelection = false;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(1130, 410);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "id";
            columnHeader5.Width = 95;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "人物";
            columnHeader9.Width = 139;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "用户IP";
            columnHeader1.Width = 124;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "绑定帐号";
            columnHeader7.Width = 124;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "人物状态";
            columnHeader8.Width = 72;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "地区";
            columnHeader6.Width = 104;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "所在服务器";
            columnHeader2.Width = 72;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "在线时长";
            columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "conn";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "VIP";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "职业";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
            踢IDToolStripMenuItem,
            封号ToolStripMenuItem,
            封IPToolStripMenuItem,
            封绑定帐号ToolStripMenuItem,
            加入限制ToolStripMenuItem,
            启动teamViewerToolStripMenuItem,
            关闭登陆器ToolStripMenuItem,
            关闭客户端ToolStripMenuItem,
            禁用自动登陆ToolStripMenuItem,
            关机ToolStripMenuItem,
            重启ToolStripMenuItem,
            停止挂机ToolStripMenuItem,
            开始挂机ToolStripMenuItem});
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(149, 290);
            // 
            // 踢IDToolStripMenuItem
            // 
            踢IDToolStripMenuItem.Name = "踢IDToolStripMenuItem";
            踢IDToolStripMenuItem.Size = new Size(148, 22);
            踢IDToolStripMenuItem.Text = "踢ID";
            踢IDToolStripMenuItem.Click += new EventHandler(踢IDToolStripMenuItem_Click);
            // 
            // 封号ToolStripMenuItem
            // 
            封号ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            天ToolStripMenuItem,
            天ToolStripMenuItem1,
            天ToolStripMenuItem2,
            月ToolStripMenuItem,
            永久ToolStripMenuItem});
            封号ToolStripMenuItem.Name = "封号ToolStripMenuItem";
            封号ToolStripMenuItem.Size = new Size(148, 22);
            封号ToolStripMenuItem.Text = "封ID";
            // 
            // 天ToolStripMenuItem
            // 
            天ToolStripMenuItem.Name = "天ToolStripMenuItem";
            天ToolStripMenuItem.Size = new Size(100, 22);
            天ToolStripMenuItem.Text = "1天";
            天ToolStripMenuItem.Click += new EventHandler(天ToolStripMenuItem_Click);
            // 
            // 天ToolStripMenuItem1
            // 
            天ToolStripMenuItem1.Name = "天ToolStripMenuItem1";
            天ToolStripMenuItem1.Size = new Size(100, 22);
            天ToolStripMenuItem1.Text = "3天";
            天ToolStripMenuItem1.Click += new EventHandler(天ToolStripMenuItem1_Click);
            // 
            // 天ToolStripMenuItem2
            // 
            天ToolStripMenuItem2.Name = "天ToolStripMenuItem2";
            天ToolStripMenuItem2.Size = new Size(100, 22);
            天ToolStripMenuItem2.Text = "7天";
            天ToolStripMenuItem2.Click += new EventHandler(天ToolStripMenuItem2_Click);
            // 
            // 月ToolStripMenuItem
            // 
            月ToolStripMenuItem.Name = "月ToolStripMenuItem";
            月ToolStripMenuItem.Size = new Size(100, 22);
            月ToolStripMenuItem.Text = "1月";
            月ToolStripMenuItem.Click += new EventHandler(月ToolStripMenuItem_Click);
            // 
            // 永久ToolStripMenuItem
            // 
            永久ToolStripMenuItem.Name = "永久ToolStripMenuItem";
            永久ToolStripMenuItem.Size = new Size(100, 22);
            永久ToolStripMenuItem.Text = "永久";
            永久ToolStripMenuItem.Click += new EventHandler(永久ToolStripMenuItem_Click);
            // 
            // 封IPToolStripMenuItem
            // 
            封IPToolStripMenuItem.Name = "封IPToolStripMenuItem";
            封IPToolStripMenuItem.Size = new Size(148, 22);
            封IPToolStripMenuItem.Text = "封IP";
            封IPToolStripMenuItem.Click += new EventHandler(封IPToolStripMenuItem_Click);
            // 
            // 封绑定帐号ToolStripMenuItem
            // 
            封绑定帐号ToolStripMenuItem.Name = "封绑定帐号ToolStripMenuItem";
            封绑定帐号ToolStripMenuItem.Size = new Size(148, 22);
            封绑定帐号ToolStripMenuItem.Text = "封绑定帐号";
            封绑定帐号ToolStripMenuItem.Click += new EventHandler(封绑定帐号ToolStripMenuItem_Click);
            // 
            // 加入限制ToolStripMenuItem
            // 
            加入限制ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            降低爆率ToolStripMenuItem,
            降低经验ToolStripMenuItem,
            降低金钱ToolStripMenuItem,
            降低历练ToolStripMenuItem});
            加入限制ToolStripMenuItem.Name = "加入限制ToolStripMenuItem";
            加入限制ToolStripMenuItem.Size = new Size(148, 22);
            加入限制ToolStripMenuItem.Text = "加入限制";
            // 
            // 降低爆率ToolStripMenuItem
            // 
            降低爆率ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            toolStripMenuItem32,
            toolStripMenuItem33,
            toolStripMenuItem34,
            toolStripMenuItem35,
            toolStripMenuItem36,
            toolStripMenuItem37,
            toolStripMenuItem38,
            toolStripMenuItem39,
            toolStripMenuItem40,
            toolStripMenuItem41});
            降低爆率ToolStripMenuItem.Name = "降低爆率ToolStripMenuItem";
            降低爆率ToolStripMenuItem.Size = new Size(124, 22);
            降低爆率ToolStripMenuItem.Text = "降低爆率";
            // 
            // toolStripMenuItem32
            // 
            toolStripMenuItem32.Name = "toolStripMenuItem32";
            toolStripMenuItem32.Size = new Size(101, 22);
            toolStripMenuItem32.Text = "解除";
            toolStripMenuItem32.Click += new EventHandler(toolStripMenuItem32_Click);
            // 
            // toolStripMenuItem33
            // 
            toolStripMenuItem33.Name = "toolStripMenuItem33";
            toolStripMenuItem33.Size = new Size(101, 22);
            toolStripMenuItem33.Text = "10%";
            toolStripMenuItem33.Click += new EventHandler(toolStripMenuItem33_Click);
            // 
            // toolStripMenuItem34
            // 
            toolStripMenuItem34.Name = "toolStripMenuItem34";
            toolStripMenuItem34.Size = new Size(101, 22);
            toolStripMenuItem34.Text = "20%";
            toolStripMenuItem34.Click += new EventHandler(toolStripMenuItem34_Click);
            // 
            // toolStripMenuItem35
            // 
            toolStripMenuItem35.Name = "toolStripMenuItem35";
            toolStripMenuItem35.Size = new Size(101, 22);
            toolStripMenuItem35.Text = "30%";
            toolStripMenuItem35.Click += new EventHandler(toolStripMenuItem35_Click);
            // 
            // toolStripMenuItem36
            // 
            toolStripMenuItem36.Name = "toolStripMenuItem36";
            toolStripMenuItem36.Size = new Size(101, 22);
            toolStripMenuItem36.Text = "40%";
            toolStripMenuItem36.Click += new EventHandler(toolStripMenuItem36_Click);
            // 
            // toolStripMenuItem37
            // 
            toolStripMenuItem37.Name = "toolStripMenuItem37";
            toolStripMenuItem37.Size = new Size(101, 22);
            toolStripMenuItem37.Text = "50%";
            toolStripMenuItem37.Click += new EventHandler(toolStripMenuItem37_Click);
            // 
            // toolStripMenuItem38
            // 
            toolStripMenuItem38.Name = "toolStripMenuItem38";
            toolStripMenuItem38.Size = new Size(101, 22);
            toolStripMenuItem38.Text = "60%";
            toolStripMenuItem38.Click += new EventHandler(toolStripMenuItem38_Click);
            // 
            // toolStripMenuItem39
            // 
            toolStripMenuItem39.Name = "toolStripMenuItem39";
            toolStripMenuItem39.Size = new Size(101, 22);
            toolStripMenuItem39.Text = "70%";
            toolStripMenuItem39.Click += new EventHandler(toolStripMenuItem39_Click);
            // 
            // toolStripMenuItem40
            // 
            toolStripMenuItem40.Name = "toolStripMenuItem40";
            toolStripMenuItem40.Size = new Size(101, 22);
            toolStripMenuItem40.Text = "80%";
            toolStripMenuItem40.Click += new EventHandler(toolStripMenuItem40_Click);
            // 
            // toolStripMenuItem41
            // 
            toolStripMenuItem41.Name = "toolStripMenuItem41";
            toolStripMenuItem41.Size = new Size(101, 22);
            toolStripMenuItem41.Text = "90%";
            toolStripMenuItem41.Click += new EventHandler(toolStripMenuItem41_Click);
            // 
            // 降低经验ToolStripMenuItem
            // 
            降低经验ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            toolStripMenuItem22,
            toolStripMenuItem23,
            toolStripMenuItem24,
            toolStripMenuItem25,
            toolStripMenuItem26,
            toolStripMenuItem27,
            toolStripMenuItem28,
            toolStripMenuItem29,
            toolStripMenuItem30,
            toolStripMenuItem31});
            降低经验ToolStripMenuItem.Name = "降低经验ToolStripMenuItem";
            降低经验ToolStripMenuItem.Size = new Size(124, 22);
            降低经验ToolStripMenuItem.Text = "降低经验";
            // 
            // toolStripMenuItem22
            // 
            toolStripMenuItem22.Name = "toolStripMenuItem22";
            toolStripMenuItem22.Size = new Size(101, 22);
            toolStripMenuItem22.Text = "解除";
            toolStripMenuItem22.Click += new EventHandler(toolStripMenuItem22_Click);
            // 
            // toolStripMenuItem23
            // 
            toolStripMenuItem23.Name = "toolStripMenuItem23";
            toolStripMenuItem23.Size = new Size(101, 22);
            toolStripMenuItem23.Text = "10%";
            toolStripMenuItem23.Click += new EventHandler(toolStripMenuItem23_Click);
            // 
            // toolStripMenuItem24
            // 
            toolStripMenuItem24.Name = "toolStripMenuItem24";
            toolStripMenuItem24.Size = new Size(101, 22);
            toolStripMenuItem24.Text = "20%";
            toolStripMenuItem24.Click += new EventHandler(toolStripMenuItem24_Click);
            // 
            // toolStripMenuItem25
            // 
            toolStripMenuItem25.Name = "toolStripMenuItem25";
            toolStripMenuItem25.Size = new Size(101, 22);
            toolStripMenuItem25.Text = "30%";
            toolStripMenuItem25.Click += new EventHandler(toolStripMenuItem25_Click);
            // 
            // toolStripMenuItem26
            // 
            toolStripMenuItem26.Name = "toolStripMenuItem26";
            toolStripMenuItem26.Size = new Size(101, 22);
            toolStripMenuItem26.Text = "40%";
            toolStripMenuItem26.Click += new EventHandler(toolStripMenuItem26_Click);
            // 
            // toolStripMenuItem27
            // 
            toolStripMenuItem27.Name = "toolStripMenuItem27";
            toolStripMenuItem27.Size = new Size(101, 22);
            toolStripMenuItem27.Text = "50%";
            toolStripMenuItem27.Click += new EventHandler(toolStripMenuItem27_Click);
            // 
            // toolStripMenuItem28
            // 
            toolStripMenuItem28.Name = "toolStripMenuItem28";
            toolStripMenuItem28.Size = new Size(101, 22);
            toolStripMenuItem28.Text = "60%";
            toolStripMenuItem28.Click += new EventHandler(toolStripMenuItem28_Click);
            // 
            // toolStripMenuItem29
            // 
            toolStripMenuItem29.Name = "toolStripMenuItem29";
            toolStripMenuItem29.Size = new Size(101, 22);
            toolStripMenuItem29.Text = "70%";
            toolStripMenuItem29.Click += new EventHandler(toolStripMenuItem29_Click);
            // 
            // toolStripMenuItem30
            // 
            toolStripMenuItem30.Name = "toolStripMenuItem30";
            toolStripMenuItem30.Size = new Size(101, 22);
            toolStripMenuItem30.Text = "80%";
            toolStripMenuItem30.Click += new EventHandler(toolStripMenuItem30_Click);
            // 
            // toolStripMenuItem31
            // 
            toolStripMenuItem31.Name = "toolStripMenuItem31";
            toolStripMenuItem31.Size = new Size(101, 22);
            toolStripMenuItem31.Text = "90%";
            toolStripMenuItem31.Click += new EventHandler(toolStripMenuItem31_Click);
            // 
            // 降低金钱ToolStripMenuItem
            // 
            降低金钱ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            toolStripMenuItem12,
            toolStripMenuItem13,
            toolStripMenuItem14,
            toolStripMenuItem15,
            toolStripMenuItem16,
            toolStripMenuItem17,
            toolStripMenuItem18,
            toolStripMenuItem19,
            toolStripMenuItem20,
            toolStripMenuItem21});
            降低金钱ToolStripMenuItem.Name = "降低金钱ToolStripMenuItem";
            降低金钱ToolStripMenuItem.Size = new Size(124, 22);
            降低金钱ToolStripMenuItem.Text = "降低金钱";
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.Size = new Size(101, 22);
            toolStripMenuItem12.Text = "解除";
            toolStripMenuItem12.Click += new EventHandler(toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.Size = new Size(101, 22);
            toolStripMenuItem13.Text = "10%";
            toolStripMenuItem13.Click += new EventHandler(toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem14
            // 
            toolStripMenuItem14.Name = "toolStripMenuItem14";
            toolStripMenuItem14.Size = new Size(101, 22);
            toolStripMenuItem14.Text = "20%";
            toolStripMenuItem14.Click += new EventHandler(toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem15
            // 
            toolStripMenuItem15.Name = "toolStripMenuItem15";
            toolStripMenuItem15.Size = new Size(101, 22);
            toolStripMenuItem15.Text = "30%";
            toolStripMenuItem15.Click += new EventHandler(toolStripMenuItem15_Click);
            // 
            // toolStripMenuItem16
            // 
            toolStripMenuItem16.Name = "toolStripMenuItem16";
            toolStripMenuItem16.Size = new Size(101, 22);
            toolStripMenuItem16.Text = "40%";
            toolStripMenuItem16.Click += new EventHandler(toolStripMenuItem16_Click);
            // 
            // toolStripMenuItem17
            // 
            toolStripMenuItem17.Name = "toolStripMenuItem17";
            toolStripMenuItem17.Size = new Size(101, 22);
            toolStripMenuItem17.Text = "50%";
            toolStripMenuItem17.Click += new EventHandler(toolStripMenuItem17_Click);
            // 
            // toolStripMenuItem18
            // 
            toolStripMenuItem18.Name = "toolStripMenuItem18";
            toolStripMenuItem18.Size = new Size(101, 22);
            toolStripMenuItem18.Text = "60%";
            toolStripMenuItem18.Click += new EventHandler(toolStripMenuItem18_Click);
            // 
            // toolStripMenuItem19
            // 
            toolStripMenuItem19.Name = "toolStripMenuItem19";
            toolStripMenuItem19.Size = new Size(101, 22);
            toolStripMenuItem19.Text = "70%";
            toolStripMenuItem19.Click += new EventHandler(toolStripMenuItem19_Click);
            // 
            // toolStripMenuItem20
            // 
            toolStripMenuItem20.Name = "toolStripMenuItem20";
            toolStripMenuItem20.Size = new Size(101, 22);
            toolStripMenuItem20.Text = "80%";
            toolStripMenuItem20.Click += new EventHandler(toolStripMenuItem20_Click);
            // 
            // toolStripMenuItem21
            // 
            toolStripMenuItem21.Name = "toolStripMenuItem21";
            toolStripMenuItem21.Size = new Size(101, 22);
            toolStripMenuItem21.Text = "90%";
            toolStripMenuItem21.Click += new EventHandler(toolStripMenuItem21_Click);
            // 
            // 降低历练ToolStripMenuItem
            // 
            降低历练ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            toolStripMenuItem2,
            toolStripMenuItem3,
            toolStripMenuItem4,
            toolStripMenuItem5,
            toolStripMenuItem6,
            toolStripMenuItem7,
            toolStripMenuItem8,
            toolStripMenuItem9,
            toolStripMenuItem10,
            toolStripMenuItem11});
            降低历练ToolStripMenuItem.Name = "降低历练ToolStripMenuItem";
            降低历练ToolStripMenuItem.Size = new Size(124, 22);
            降低历练ToolStripMenuItem.Text = "降低历练";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(101, 22);
            toolStripMenuItem2.Text = "解除";
            toolStripMenuItem2.Click += new EventHandler(toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(101, 22);
            toolStripMenuItem3.Text = "10%";
            toolStripMenuItem3.Click += new EventHandler(toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(101, 22);
            toolStripMenuItem4.Text = "20%";
            toolStripMenuItem4.Click += new EventHandler(toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(101, 22);
            toolStripMenuItem5.Text = "30%";
            toolStripMenuItem5.Click += new EventHandler(toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(101, 22);
            toolStripMenuItem6.Text = "40%";
            toolStripMenuItem6.Click += new EventHandler(toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(101, 22);
            toolStripMenuItem7.Text = "50%";
            toolStripMenuItem7.Click += new EventHandler(toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(101, 22);
            toolStripMenuItem8.Text = "60%";
            toolStripMenuItem8.Click += new EventHandler(toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(101, 22);
            toolStripMenuItem9.Text = "70%";
            toolStripMenuItem9.Click += new EventHandler(toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(101, 22);
            toolStripMenuItem10.Text = "80%";
            toolStripMenuItem10.Click += new EventHandler(toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Size = new Size(101, 22);
            toolStripMenuItem11.Text = "90%";
            toolStripMenuItem11.Click += new EventHandler(toolStripMenuItem11_Click);
            // 
            // 启动teamViewerToolStripMenuItem
            // 
            启动teamViewerToolStripMenuItem.Name = "启动teamViewerToolStripMenuItem";
            启动teamViewerToolStripMenuItem.Size = new Size(148, 22);
            启动teamViewerToolStripMenuItem.Text = "teamViewer";
            启动teamViewerToolStripMenuItem.Click += new EventHandler(启动teamViewerToolStripMenuItem_Click);
            // 
            // 关闭登陆器ToolStripMenuItem
            // 
            关闭登陆器ToolStripMenuItem.Name = "关闭登陆器ToolStripMenuItem";
            关闭登陆器ToolStripMenuItem.Size = new Size(148, 22);
            关闭登陆器ToolStripMenuItem.Text = "关闭登陆器";
            关闭登陆器ToolStripMenuItem.Click += new EventHandler(关闭登陆器ToolStripMenuItem_Click);
            // 
            // 关闭客户端ToolStripMenuItem
            // 
            关闭客户端ToolStripMenuItem.Name = "关闭客户端ToolStripMenuItem";
            关闭客户端ToolStripMenuItem.Size = new Size(148, 22);
            关闭客户端ToolStripMenuItem.Text = "关闭客户端";
            关闭客户端ToolStripMenuItem.Click += new EventHandler(关闭客户端ToolStripMenuItem_Click);
            // 
            // 禁用自动登陆ToolStripMenuItem
            // 
            禁用自动登陆ToolStripMenuItem.Name = "禁用自动登陆ToolStripMenuItem";
            禁用自动登陆ToolStripMenuItem.Size = new Size(148, 22);
            禁用自动登陆ToolStripMenuItem.Text = "禁用自动登陆";
            禁用自动登陆ToolStripMenuItem.Click += new EventHandler(禁用自动登陆ToolStripMenuItem_Click);
            // 
            // 关机ToolStripMenuItem
            // 
            关机ToolStripMenuItem.Name = "关机ToolStripMenuItem";
            关机ToolStripMenuItem.Size = new Size(148, 22);
            关机ToolStripMenuItem.Text = "关机";
            关机ToolStripMenuItem.Click += new EventHandler(关机ToolStripMenuItem_Click);
            // 
            // 重启ToolStripMenuItem
            // 
            重启ToolStripMenuItem.Name = "重启ToolStripMenuItem";
            重启ToolStripMenuItem.Size = new Size(148, 22);
            重启ToolStripMenuItem.Text = "重启";
            重启ToolStripMenuItem.Click += new EventHandler(重启ToolStripMenuItem_Click);
            // 
            // 停止挂机ToolStripMenuItem
            // 
            停止挂机ToolStripMenuItem.Name = "停止挂机ToolStripMenuItem";
            停止挂机ToolStripMenuItem.Size = new Size(148, 22);
            停止挂机ToolStripMenuItem.Text = "停止挂机";
            停止挂机ToolStripMenuItem.Click += new EventHandler(停止挂机ToolStripMenuItem_Click);
            // 
            // 开始挂机ToolStripMenuItem
            // 
            开始挂机ToolStripMenuItem.Name = "开始挂机ToolStripMenuItem";
            开始挂机ToolStripMenuItem.Size = new Size(148, 22);
            开始挂机ToolStripMenuItem.Text = "开始挂机";
            开始挂机ToolStripMenuItem.Click += new EventHandler(开始挂机ToolStripMenuItem_Click);
            // 
            // textBox2
            // 
            textBox2.Location = new Point(11, 64);
            textBox2.MaxLength = 1;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(112, 21);
            textBox2.TabIndex = 3;
            textBox2.Text = "3";
            // 
            // button2
            // 
            button2.Location = new Point(129, 62);
            button2.Name = "button2";
            button2.Size = new Size(74, 23);
            button2.TabIndex = 2;
            button2.Text = "查绑定数";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new EventHandler(button2_Click);
            // 
            // button1
            // 
            button1.Location = new Point(129, 33);
            button1.Name = "button1";
            button1.Size = new Size(74, 23);
            button1.TabIndex = 1;
            button1.Text = "查询帐号";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(button1_Click);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(112, 21);
            textBox1.TabIndex = 0;
            // 
            // userlist
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1352, 410);
            Controls.Add(splitContainer1);
            Name = "userlist";
            Text = "userlist-源多多资源网-yuandd.Net";
            Load += new EventHandler(userlist_Load);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);

		}

		public userlist()
		{
			InitializeComponent();
		}

		private void userlist_Load(object sender, EventArgs e)
		{
			try
			{
				listView1.ListViewItemSorter = new ListViewColumnSorter();
				listView1.ColumnClick += ListViewHelper.ListView_ColumnClick;
				foreach (playerS item in (IEnumerable<playerS>)World.Players.Values)
				{
					string 状态 = string.Empty;
					if (item.OfflineAutoFarm == "0")
					{
						状态 = "在线";
					}
					else if (item.OfflineAutoFarm == "1")
					{
						状态 = "挂店";
					}
					else if (item.OfflineAutoFarm == "2")
					{
						状态 = "假人";
					}
					else if (item.OfflineAutoFarm == "3")
					{
						状态 = "云挂机";
					}
					if (item != null)
					{
						string[] array = new string[13]
						{
							item.UserId.ToString(),
							item.UserName,
							item.UserIp,
							item.BoundAccount,
							状态,
							RxjhClass.GetUserIpadds(item.UserIp),
							item.ServerID + "线",
							item.OnlineTime.ToString().Remove(item.OnlineTime.ToString().Length - 8, 8),
							item.Connection.ToString(),
							!(item.GoldSymbol  == "0") ? "有" : "无",
							null,
							null,
							null
						};
						if (item.Profession  == "0")
						{
							array[10] = "0";
						}
						else if (item.Profession  == "1")
						{
							array[10] = "刀";
						}
						else if (item.Profession  == "2")
						{
							array[10] = "剑";
						}
						else if (item.Profession  == "3")
						{
							array[10] = "枪";
						}
						else if (item.Profession  == "4")
						{
							array[10] = "弓";
						}
						else if (item.Profession  == "5")
						{
							array[10] = "医";
						}
						else if (item.Profession  == "6")
						{
							array[10] = "刺";
						}
						else if (item.Profession  == "7")
						{
							array[10] = "琴";
						}
						else if (item.Profession  == "8")
						{
							array[10] = "韩";
						}
						else if (item.Profession  == "9")
						{
							array[10] = "谭";
						}
						else if (item.Profession  == "10")
						{
							array[10] = "拳";
						}
						else if (item.Profession  == "11")
						{
							array[10] = "梅";
						}
						else if (item.Profession  == "12")
						{
							array[10] = "卢";
						}
						else if (item.Profession  == "13")
						{
							array[10] = "神";
						}
						listView1.Items.Insert(listView1.Items.Count, new ListViewItem(array));
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			if (World.Players.TryGetValue(textBox1.Text, out var value))
			{
				string 状态 = string.Empty;
				if (value.OfflineAutoFarm == "0")
				{
					状态 = "在线";
				}
				else if (value.OfflineAutoFarm == "1")
				{
					状态 = "挂店";
				}
				else if (value.OfflineAutoFarm == "2")
				{
					状态 = "假人";
				}
				else if (value.OfflineAutoFarm == "3")
				{
					状态 = "云挂机";
				}
				string 职业 = string.Empty;
				if (value.Profession  == "0")
				{
					职业 = "0";
				}
				else if (value.Profession  == "1")
				{
					职业 = "刀";
				}
				else if (value.Profession  == "2")
				{
					职业 = "剑";
				}
				else if (value.Profession  == "3")
				{
					职业 = "枪";
				}
				else if (value.Profession  == "4")
				{
					职业 = "弓";
				}
				else if (value.Profession  == "5")
				{
					职业 = "医";
				}
				else if (value.Profession  == "6")
				{
					职业 = "刺";
				}
				else if (value.Profession  == "7")
				{
					职业 = "琴";
				}
				else if (value.Profession  == "8")
				{
					职业 = "韩";
				}
				else if (value.Profession  == "9")
				{
					职业 = "谭";
				}
				else if (value.Profession  == "10")
				{
					职业 = "拳";
				}
				else if (value.Profession  == "11")
				{
					职业 = "梅";
				}
				else if (value.Profession  == "12")
				{
					职业 = "卢";
				}
				else if (value.Profession  == "13")
				{
					职业 = "神";
				}
				string VIP = string.Empty;
				if (value.GoldSymbol  == "0")
				{
					VIP = "无";
				}
				else if (value.GoldSymbol  == "1")
				{
					VIP = "有";
				}
				string[] array = new string[11]
				{
					value.UserId.ToString(),
					value.UserName,
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
				NetState netState = World.GetAccountData(int.Parse(value.WorldID));
				array[2] = netState == null ? value.UserIp : netState.ToString();
				array[3] = value.BoundAccount;
				array[4] = 状态;
				array[5] = RxjhClass.GetUserIpadds(value.UserIp);
				array[6] = value.ServerID + "线";
				string obj = value.OnlineTime.ToString();
				int startIndex = value.OnlineTime.ToString().Length - 8;
				array[7] = obj.Remove(startIndex, 8);
				array[8] = value.Connection.ToString();
				array[9] = VIP;
				array[10] = 职业;
				listView1.Items.Insert(listView1.Items.Count, new ListViewItem(array));
			}
		}

		private void 踢IDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				string text = listView1.SelectedItems[0].SubItems[0].Text;
				playerS playerS2 = World.QueryPlayer(text);
				if (playerS2 != null)
				{
					World.LogoutPlayer(text);
					World.KickPlayerFromServer(playerS2.ServerID, playerS2.WorldID);
					playerS2.npcTimer.Dispose();
					RxjhClass.SetUserIdONLINE(text);
				}
			}
		}

		private void 天ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			string text = listView1.SelectedItems[0].SubItems[0].Text;
			playerS playerS2 = World.QueryPlayer(text);
			if (playerS2 != null)
			{
				lock (World.Players)
				{
					World.Players.Remove(text);
				}
				World.KickPlayerFromServer(playerS2.ServerID, playerS2.WorldID);
				playerS2.npcTimer.Dispose();
			}
			DBA.ExeSqlCommand("UPDATE TBL_ACCOUNT SET FLD_ZT=24 WHERE FLD_ID='" + text + "'", "rxjhaccount");
		}

		private void 天ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			string text = listView1.SelectedItems[0].SubItems[0].Text;
			playerS playerS2 = World.QueryPlayer(text);
			if (playerS2 != null)
			{
				lock (World.Players)
				{
					World.Players.Remove(text);
				}
				World.KickPlayerFromServer(playerS2.ServerID, playerS2.WorldID);
				playerS2.npcTimer.Dispose();
			}
			DBA.ExeSqlCommand("UPDATE TBL_ACCOUNT SET FLD_ZT=72 WHERE FLD_ID='" + text + "'", "rxjhaccount");
		}

		private void 天ToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			string text = listView1.SelectedItems[0].SubItems[0].Text;
			playerS playerS2 = World.QueryPlayer(text);
			if (playerS2 != null)
			{
				lock (World.Players)
				{
					World.Players.Remove(text);
				}
				World.KickPlayerFromServer(playerS2.ServerID, playerS2.WorldID);
				playerS2.npcTimer.Dispose();
			}
			DBA.ExeSqlCommand("UPDATE TBL_ACCOUNT SET FLD_ZT=168 WHERE FLD_ID='" + text + "'", "rxjhaccount");
		}

		private void 月ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			string text = listView1.SelectedItems[0].SubItems[0].Text;
			playerS playerS2 = World.QueryPlayer(text);
			if (playerS2 != null)
			{
				lock (World.Players)
				{
					World.Players.Remove(text);
				}
				World.KickPlayerFromServer(playerS2.ServerID, playerS2.WorldID);
				playerS2.npcTimer.Dispose();
			}
			DBA.ExeSqlCommand("UPDATE TBL_ACCOUNT SET FLD_ZT=720 WHERE FLD_ID='" + text + "'", "rxjhaccount");
		}

		private void 永久ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			string text = listView1.SelectedItems[0].SubItems[0].Text;
			playerS playerS2 = World.QueryPlayer(text);
			if (playerS2 != null)
			{
				lock (World.Players)
				{
					World.Players.Remove(text);
				}
				World.KickPlayerFromServer(playerS2.ServerID, playerS2.WorldID);
				playerS2.npcTimer.Dispose();
			}
			DBA.ExeSqlCommand("UPDATE TBL_ACCOUNT SET FLD_ZT=99999 WHERE FLD_ID='" + text + "'", "rxjhaccount");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				int num = int.Parse(textBox2.Text);
				listView1.Items.Clear();
				Players.Clear();
				foreach (playerS item in (IEnumerable<playerS>)World.Players.Values)
				{
					if (查数量(item.BoundAccount) >= num)
					{
						Players.Add(item.UserId, item);
					}
				}
				if (Players.Count <= 0)
				{
					return;
				}
				foreach (playerS value in Players.Values)
				{
					string 状态 = string.Empty;
					if (value.OfflineAutoFarm == "0")
					{
						状态 = "在线";
					}
					else if (value.OfflineAutoFarm == "1")
					{
						状态 = "挂店";
					}
					else if (value.OfflineAutoFarm == "2")
					{
						状态 = "假人";
					}
					else if (value.OfflineAutoFarm == "3")
					{
						状态 = "云挂机";
					}
					string 职业 = string.Empty;
					if (value.Profession  == "0")
					{
						职业 = "0";
					}
					else if (value.Profession  == "1")
					{
						职业 = "刀";
					}
					else if (value.Profession  == "2")
					{
						职业 = "剑";
					}
					else if (value.Profession  == "3")
					{
						职业 = "枪";
					}
					else if (value.Profession  == "4")
					{
						职业 = "弓";
					}
					else if (value.Profession  == "5")
					{
						职业 = "医";
					}
					else if (value.Profession  == "6")
					{
						职业 = "刺";
					}
					else if (value.Profession  == "7")
					{
						职业 = "琴";
					}
					else if (value.Profession  == "8")
					{
						职业 = "韩";
					}
					else if (value.Profession  == "9")
					{
						职业 = "谭";
					}
					else if (value.Profession  == "10")
					{
						职业 = "拳";
					}
					else if (value.Profession  == "11")
					{
						职业 = "梅";
					}
					else if (value.Profession  == "12")
					{
						职业 = "卢";
					}
					else if (value.Profession  == "13")
					{
						职业 = "神";
					}
					string VIP = string.Empty;
					if (value.GoldSymbol  == "0")
					{
						VIP = "无";
					}
					else if (value.GoldSymbol  == "1")
					{
						VIP = "有";
					}
					string[] obj = new string[11]
					{
						value.UserId.ToString(),
						value.UserName,
						value.UserIp,
						value.BoundAccount,
						状态,
						RxjhClass.GetUserIpadds(value.UserIp),
						value.ServerID + "线",
						null,
						null,
						null,
						null
					};
					string text = value.OnlineTime.ToString();
					int startIndex = value.OnlineTime.ToString().Length - 8;
					obj[7] = text.Remove(startIndex, 8);
					obj[8] = value.Connection.ToString();
					obj[9] = VIP;
					obj[10] = 职业;
					string[] array = obj;
					listView1.Items.Insert(listView1.Items.Count, new ListViewItem(array));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("查询错误 " + ex.Message);
			}
		}

		private int 查数量(string 绑定帐号)
		{
			int num = 0;
			foreach (playerS item in (IEnumerable<playerS>)World.Players.Values)
			{
				if (RxjhClass.IsEquals(item.BoundAccount, 绑定帐号))
				{
					num++;
				}
			}
			return num;
		}

		private void 封IPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			string text = listView1.SelectedItems[0].SubItems[0].Text;
			playerS playerS2 = World.QueryPlayer(text);
			if (playerS2 != null)
			{
				if (RxjhClass.GetUserIP(playerS2.UserIp) == 0)
				{
					DBA.ExeSqlCommand("INSERT INTO TBL_BANED (FLD_BANEDIP) VALUES ('" + playerS2.UserIp + "')", "rxjhaccount");
				}
				lock (World.Players)
				{
					World.Players.Remove(text);
				}
				World.KickPlayerFromServer(playerS2.ServerID, playerS2.WorldID);
				playerS2.npcTimer.Dispose();
			}
		}

		private void 封绑定帐号ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			string text = listView1.SelectedItems[0].SubItems[0].Text;
			playerS playerS2 = World.QueryPlayer(text);
			if (playerS2 != null)
			{
				if (RxjhClass.GetUserNIP(playerS2.BoundAccount) == 0)
				{
					DBA.ExeSqlCommand("INSERT INTO TBL_BANED (FLD_BANEDNIP) VALUES ('" + playerS2.BoundAccount + "')", "rxjhaccount");
				}
				lock (World.Players)
				{
					World.Players.Remove(text);
				}
				World.KickPlayerFromServer(playerS2.ServerID, playerS2.WorldID);
				playerS2.npcTimer.Dispose();
			}
		}

		private void toolStripMenuItem32_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 0);
				}
			}
		}

		private void toolStripMenuItem33_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 10);
				}
			}
		}

		private void toolStripMenuItem34_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 20);
				}
			}
		}

		private void toolStripMenuItem35_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 30);
				}
			}
		}

		private void toolStripMenuItem36_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 40);
				}
			}
		}

		private void toolStripMenuItem37_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 50);
				}
			}
		}

		private void toolStripMenuItem38_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 60);
				}
			}
		}

		private void toolStripMenuItem39_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 70);
				}
			}
		}

		private void toolStripMenuItem40_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 80);
				}
			}
		}

		private void toolStripMenuItem41_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 0, 90);
				}
			}
		}

		private void toolStripMenuItem22_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 0);
				}
			}
		}

		private void toolStripMenuItem23_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 10);
				}
			}
		}

		private void toolStripMenuItem24_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 20);
				}
			}
		}

		private void toolStripMenuItem25_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 30);
				}
			}
		}

		private void toolStripMenuItem26_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 40);
				}
			}
		}

		private void toolStripMenuItem27_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 50);
				}
			}
		}

		private void toolStripMenuItem28_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 60);
				}
			}
		}

		private void toolStripMenuItem29_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 70);
				}
			}
		}

		private void toolStripMenuItem30_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 80);
				}
			}
		}

		private void toolStripMenuItem31_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 1, 90);
				}
			}
		}

		private void toolStripMenuItem12_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 0);
				}
			}
		}

		private void toolStripMenuItem13_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 10);
				}
			}
		}

		private void toolStripMenuItem14_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 20);
				}
			}
		}

		private void toolStripMenuItem15_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 30);
				}
			}
		}

		private void toolStripMenuItem16_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 40);
				}
			}
		}

		private void toolStripMenuItem17_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 50);
				}
			}
		}

		private void toolStripMenuItem18_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 60);
				}
			}
		}

		private void toolStripMenuItem19_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 70);
				}
			}
		}

		private void toolStripMenuItem20_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 80);
				}
			}
		}

		private void toolStripMenuItem21_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 2, 90);
				}
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 0);
				}
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 10);
				}
			}
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 20);
				}
			}
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 30);
				}
			}
		}

		private void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 40);
				}
			}
		}

		private void toolStripMenuItem7_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 50);
				}
			}
		}

		private void toolStripMenuItem8_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 60);
				}
			}
		}

		private void toolStripMenuItem9_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 70);
				}
			}
		}

		private void toolStripMenuItem10_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 80);
				}
			}
		}

		private void toolStripMenuItem11_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					World.AddUserRestriction(playerS2.ServerID, playerS2.WorldID, 3, 90);
				}
			}
		}

		private void 启动teamViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					OpClient(playerS2.ServerID, playerS2.WorldID, "6");
				}
			}
		}

		private void OpClient(string ServerID, string WorldID, string OpCode)
		{
			World.OpClient(ServerID, WorldID, OpCode);
		}

		private void 关闭登陆器ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					OpClient(playerS2.ServerID, playerS2.WorldID, "2");
				}
			}
		}

		private void 关闭客户端ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					OpClient(playerS2.ServerID, playerS2.WorldID, "0");
				}
			}
		}

		private void 禁用自动登陆ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					OpClient(playerS2.ServerID, playerS2.WorldID, "1");
				}
			}
		}

		private void 关机ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					OpClient(playerS2.ServerID, playerS2.WorldID, "4");
				}
			}
		}

		private void 重启ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					OpClient(playerS2.ServerID, playerS2.WorldID, "5");
				}
			}
		}

		private void 停止挂机ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					OpClient(playerS2.ServerID, playerS2.WorldID, "3");
				}
			}
		}

		private void 开始挂机ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				playerS playerS2 = World.QueryPlayer(listView1.SelectedItems[0].SubItems[0].Text);
				if (playerS2 != null)
				{
					OpClient(playerS2.ServerID, playerS2.WorldID, "7");
				}
			}
		}
	}
}
