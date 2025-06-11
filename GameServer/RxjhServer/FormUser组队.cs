using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RxjhServer
{
	public class FormUser组队 : Form
	{
		private ListView listView1;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader1;

		private SplitContainer splitContainer1;

		private ListView listView2;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader9;

		private ColumnHeader columnHeader7;

		private ColumnHeader columnHeader8;

		private ColumnHeader columnHeader10;

		private ColumnHeader columnHeader11;

		private ColumnHeader columnHeader12;

		private ColumnHeader columnHeader14;

		private ColumnHeader columnHeader13;

		private ColumnHeader columnHeader15;

		private ColumnHeader columnHeader16;

		private ColumnHeader columnHeader17;

		private ColumnHeader columnHeader18;

		private ColumnHeader columnHeader19;

		public FormUser组队()
		{
			InitializeComponent();
		}

		private void FormUser组队_Load(object sender, EventArgs e)
		{
			foreach (TeamClass value in World.Teams.Values)
			{
				string[] array = new string[2];
				try
				{
					array[0] = value.组队id.ToString();
					array[1] = value.组队列表.Count.ToString();
					listView1.Items.Insert(listView1.Items.Count, new ListViewItem(array));
				}
				catch
				{
				}
			}
		}

		private void listView1_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0 || !World.Teams.TryGetValue(int.Parse(listView1.SelectedItems[0].SubItems[0].Text), out var value))
			{
				return;
			}
			listView2.Items.Clear();
			foreach (Players value2 in value.组队列表.Values)
			{
				string[] array = new string[17];
				try
				{
					string[] array4 = array;
					string text = (array4[0] = value2.人物全服ID.ToString());
					array[1] = value2.Userid;
					array[2] = value2.UserName;
					string[] array5 = array;
					string text3 = (array5[3] = value2.Player_Level.ToString());
					string[] array6 = array;
					string text4 = (array6[4] = value2.人物_HP.ToString());
					if (value2.Client != null)
					{
						array[5] = value2.Client.ToString();
					}
					string[] array7 = array;
					string text5 = (array7[6] = value2.人物坐标_地图.ToString());
					array[7] = value2.人物坐标_X.ToString();
					array[8] = value2.人物坐标_Y.ToString();
					string[] array8 = array;
					string text6 = (array8[9] = value2.FLD_人物基本_攻击.ToString());
					array[10] = value2.FLD_追加百分比_攻击.ToString();
					string[] array9 = array;
					string text7 = (array9[11] = value2.FLD_人物基本_防御.ToString());
					array[12] = value2.FLD_追加百分比_防御.ToString();
					string[] array10 = array;
					string text8 = (array10[13] = value2.FLD_装备_追加_气功.ToString());
					array[14] = ((!value2.Client.假人) ? "否" : "是");
					string[] array11 = array;
					string text9 = (array11[15] = value2.FLD_装备_追加_武器_强化.ToString());
					string[] array2 = array;
					string text10 = (array2[16] = value2.FLD_装备_追加_防具_强化.ToString());
				}
				catch
				{
					array[0] = value2.人物全服ID.ToString();
					array[1] = value2.Userid;
					array[2] = value2.UserName;
					string[] array3 = array;
					string text2 = (array3[3] = value2.Player_Level.ToString());
				}
				listView2.Items.Insert(listView2.Items.Count, new ListViewItem(array));
			}
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUser组队));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(964, 186);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "名称";
            this.columnHeader5.Width = 71;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "数据";
            this.columnHeader1.Width = 90;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(964, 412);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 10;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader14,
            this.columnHeader13,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(964, 222);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "序号";
            this.columnHeader2.Width = 36;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 66;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "名字";
            this.columnHeader4.Width = 98;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "等级";
            this.columnHeader6.Width = 38;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "HP";
            this.columnHeader9.Width = 47;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "IP";
            this.columnHeader7.Width = 113;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "地图";
            this.columnHeader8.Width = 42;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "X";
            this.columnHeader10.Width = 61;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Y";
            this.columnHeader11.Width = 61;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "攻";
            this.columnHeader12.Width = 36;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "攻加";
            this.columnHeader14.Width = 41;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "防";
            this.columnHeader13.Width = 37;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "防加";
            this.columnHeader15.Width = 39;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "气";
            this.columnHeader16.Width = 39;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "ping";
            this.columnHeader17.Width = 39;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "攻强";
            this.columnHeader18.Width = 39;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "防强";
            this.columnHeader19.Width = 37;
            // 
            // FormUser组队
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 412);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUser组队";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUser组队-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.FormUser组队_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
