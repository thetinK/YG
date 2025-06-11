using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class UserList : Form
	{
		private ListView listView1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private ColumnHeader columnHeader8;

		private ColumnHeader columnHeader9;

		private ColumnHeader columnHeader10;

		private ColumnHeader columnHeader11;

		private ColumnHeader columnHeader12;

		private ColumnHeader columnHeader13;

		private ColumnHeader columnHeader14;

		private ColumnHeader columnHeader15;

		private ColumnHeader columnHeader16;

		private ColumnHeader columnHeader17;

		private ColumnHeader columnHeader18;

		private ColumnHeader columnHeader20;

		private ContextMenu contextMenu1;

		private MenuItem menuItem1;

		private MenuItem menuItem2;

		private MenuItem menuItem3;

		private MenuItem menuItem4;

		private MenuItem menuItem5;

		private ColumnHeader columnHeader19;

		private MenuItem menuItem6;

		private MenuItem menuItem7;

		private MenuItem menuItem8;

		private MenuItem menuItem9;

		private MenuItem menuItem10;

		private MenuItem menuItem11;

		private MenuItem menuItem12;

		public UserList()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader9,
            this.columnHeader4,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader14,
            this.columnHeader11,
            this.columnHeader15,
            this.columnHeader13,
            this.columnHeader12,
            this.columnHeader16,
            this.columnHeader17});
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1201, 543);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "序号";
            this.columnHeader5.Width = 36;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名字";
            this.columnHeader2.Width = 98;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "等级";
            this.columnHeader3.Width = 38;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "HP";
            this.columnHeader9.Width = 47;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "IP";
            this.columnHeader4.Width = 113;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "绑定帐号";
            this.columnHeader18.Width = 112;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "挂机";
            this.columnHeader19.Width = 42;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "职业";
            this.columnHeader20.Width = 61;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "地图";
            this.columnHeader6.Width = 45;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "X";
            this.columnHeader7.Width = 61;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Y";
            this.columnHeader8.Width = 61;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "攻";
            this.columnHeader10.Width = 36;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "攻加";
            this.columnHeader14.Width = 41;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "防";
            this.columnHeader11.Width = 37;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "防加";
            this.columnHeader15.Width = 39;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "气";
            this.columnHeader13.Width = 39;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "假人";
            this.columnHeader12.Width = 39;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "攻强";
            this.columnHeader16.Width = 39;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "防强";
            this.columnHeader17.Width = 37;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "退人";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "退人ID";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "封IP";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem8,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11});
            this.menuItem4.Text = "封ID";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "1天";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "3天";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "7天";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 3;
            this.menuItem10.Text = "1月";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 4;
            this.menuItem11.Text = "永久";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "查数据";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "禁/解言";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = -1;
            this.menuItem12.Text = "";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // UserList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1201, 543);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserList-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.ResumeLayout(false);

		}

		private void UserList_Load(object sender, EventArgs e)
		{
			try
			{
				listView1.ListViewItemSorter = new ListViewColumnSorter();
				listView1.ColumnClick += ListViewHelper.ListView_ColumnClick;
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value == null)
					{
						continue;
					}
					string[] array = new string[20];
					try
					{
						string[] array6 = array;
						string text = (array6[0] = value.人物全服ID.ToString());
						array[1] = value.Userid;
						array[2] = value.UserName;
						string[] array7 = array;
						string text5 = (array7[3] = value.Player_Level.ToString());
						string[] array8 = array;
						string text6 = (array8[4] = value.人物_HP.ToString());
						if (value.Client != null)
						{
							array[5] = value.Client.ToString();
						}
						array[6] = value.Client.绑定帐号;
						array[7] = ((!value.Client.挂机) ? "否" : "是");
						array[8] = World.得到职业文本(value.Player_Job);
						string[] array9 = array;
						string text7 = (array9[9] = value.人物坐标_地图.ToString());
						string[] array10 = array;
						string text8 = (array10[10] = value.人物坐标_X.ToString());
						string[] array11 = array;
						string text9 = (array11[11] = value.人物坐标_Y.ToString());
						string[] array12 = array;
						string text10 = (array12[12] = value.FLD_人物基本_攻击.ToString());
						array[13] = value.FLD_追加百分比_攻击.ToString();
						string[] array13 = array;
						string text11 = (array13[14] = value.FLD_人物基本_防御.ToString());
						array[15] = value.FLD_追加百分比_防御.ToString();
						string[] array2 = array;
						string text12 = (array2[16] = value.FLD_装备_追加_气功.ToString());
						array[17] = ((!value.Client.假人) ? "否" : "是");
						string[] array3 = array;
						string text2 = (array3[18] = value.FLD_装备_追加_武器_强化.ToString());
						string[] array4 = array;
						string text3 = (array4[19] = value.FLD_装备_追加_防具_强化.ToString());
					}
					catch
					{
						array[0] = value.人物全服ID.ToString();
						array[1] = value.Userid;
						array[2] = value.UserName;
						string[] array5 = array;
						string text4 = (array5[3] = value.Player_Level.ToString());
					}
					listView1.Items.Insert(listView1.Items.Count, new ListViewItem(array));
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "人物列表出错2" + ex.Message);
			}
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			Players players = World.检查玩家name(listView1.SelectedItems[0].SubItems[2].Text);
			if (players == null)
			{
				return;
			}
			if (players.Client.挂机)
			{
				players.Client.DisposedOffline();
				World.OfflineCount--;
				if (World.OfflineCount < 0)
				{
					World.OfflineCount = 0;
				}
			}
			if (players.Client.假人)
			{
				World.假人数量--;
				if (World.假人数量 < 0)
				{
					World.假人数量 = 0;
				}
				World.CloudAfkCount--;
				if (World.CloudAfkCount < 0)
				{
					World.CloudAfkCount = 0;
				}
				players.Client.DisposedOffline();
			}
			else
			{
				players.OpClient(1);
				players.Client.Dispose();
			}
		}

		private void menuItem2_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count <= 0)
			{
				return;
			}
			Players players = World.检查玩家(listView1.SelectedItems[0].SubItems[1].Text);
			if (players == null)
			{
				return;
			}
			if (players.Client.挂机)
			{
				players.Client.DisposedOffline();
				World.OfflineCount--;
				if (World.OfflineCount < 0)
				{
					World.OfflineCount = 0;
				}
			}
			if (players.Client.假人)
			{
				World.假人数量--;
				if (World.假人数量 < 0)
				{
					World.假人数量 = 0;
				}
				World.CloudAfkCount--;
				if (World.CloudAfkCount < 0)
				{
					World.CloudAfkCount = 0;
				}
				players.Client.DisposedOffline();
			}
			else
			{
				players.OpClient(1);
				players.Client.Dispose();
			}
		}

		private void menuItem3_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				DBA.ExeSqlCommand("INSERT INTO TBL_BANED (FLD_BANEDIP, FLD_BANEDNIP) VALUES ('" + listView1.SelectedItems[0].SubItems[5].Text + "','" + listView1.SelectedItems[0].SubItems[5].Text + "')", "rxjhaccount");
			}
		}

		private void menuItem5_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				string text = listView1.SelectedItems[0].SubItems[2].Text;
				int worldid = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
				int num = (int)new UserIdList
				{
					worldid = worldid
				}.ShowDialog();
			}
		}

		private void menuItem6_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count <= 0)
				{
					return;
				}
				Players players = World.检查玩家name(listView1.SelectedItems[0].SubItems[2].Text);
				if (players != null)
				{
					if (World.禁言列表.TryGetValue(players.UserName, out var value))
					{
						World.禁言列表.TryRemove(players.UserName, out value);
					}
					else
					{
						World.禁言列表.TryAdd(players.UserName, players.Userid);
					}
				}
			}
			catch
			{
			}
		}

		private void menuItem7_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				封号(listView1.SelectedItems[0].SubItems[1].Text, 24);
			}
			string text = listView1.SelectedItems[0].SubItems[1].Text;
			Players players = World.检查玩家(text);
			if (players == null)
			{
				return;
			}
			if (players.Client.挂机)
			{
				if (players.Client != null)
				{
					players.Client.DisposedOffline();
				}
				World.OfflineCount--;
				if (World.OfflineCount < 0)
				{
					World.OfflineCount = 0;
				}
			}
			if (players.Client.假人)
			{
				World.假人数量--;
				if (World.假人数量 < 0)
				{
					World.假人数量 = 0;
				}
				World.CloudAfkCount--;
				if (World.CloudAfkCount < 0)
				{
					World.CloudAfkCount = 0;
				}
				players.Client.DisposedOffline();
			}
			else if (players.Client != null)
			{
				players.OpClient(1);
				players.Client.Dispose();
			}
		}

		private void menuItem8_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				封号(listView1.SelectedItems[0].SubItems[1].Text, 72);
			}
			string text = listView1.SelectedItems[0].SubItems[1].Text;
			Players players = World.检查玩家(text);
			if (players == null)
			{
				return;
			}
			if (players.Client.挂机)
			{
				if (players.Client != null)
				{
					players.Client.DisposedOffline();
				}
				World.OfflineCount--;
				if (World.OfflineCount < 0)
				{
					World.OfflineCount = 0;
				}
			}
			if (players.Client.假人)
			{
				World.假人数量--;
				if (World.假人数量 < 0)
				{
					World.假人数量 = 0;
				}
				World.CloudAfkCount--;
				if (World.CloudAfkCount < 0)
				{
					World.CloudAfkCount = 0;
				}
				players.Client.DisposedOffline();
			}
			else if (players.Client != null)
			{
				players.OpClient(1);
				players.Client.Dispose();
			}
		}

		private void menuItem9_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				封号(listView1.SelectedItems[0].SubItems[1].Text, 168);
			}
			string text = listView1.SelectedItems[0].SubItems[1].Text;
			Players players = World.检查玩家(text);
			if (players == null)
			{
				return;
			}
			if (players.Client.挂机)
			{
				if (players.Client != null)
				{
					players.Client.DisposedOffline();
				}
				World.OfflineCount--;
				if (World.OfflineCount < 0)
				{
					World.OfflineCount = 0;
				}
			}
			if (players.Client.假人)
			{
				World.假人数量--;
				if (World.假人数量 < 0)
				{
					World.假人数量 = 0;
				}
				World.CloudAfkCount--;
				if (World.CloudAfkCount < 0)
				{
					World.CloudAfkCount = 0;
				}
				players.Client.DisposedOffline();
			}
			else if (players.Client != null)
			{
				players.OpClient(1);
				players.Client.Dispose();
			}
		}

		private void menuItem10_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				封号(listView1.SelectedItems[0].SubItems[1].Text, 720);
			}
			string text = listView1.SelectedItems[0].SubItems[1].Text;
			Players players = World.检查玩家(text);
			if (players == null)
			{
				return;
			}
			if (players.Client.挂机)
			{
				if (players.Client != null)
				{
					players.Client.DisposedOffline();
				}
				World.OfflineCount--;
				if (World.OfflineCount < 0)
				{
					World.OfflineCount = 0;
				}
			}
			if (players.Client.假人)
			{
				World.假人数量--;
				if (World.假人数量 < 0)
				{
					World.假人数量 = 0;
				}
				World.CloudAfkCount--;
				if (World.CloudAfkCount < 0)
				{
					World.CloudAfkCount = 0;
				}
				players.Client.DisposedOffline();
			}
			else if (players.Client != null)
			{
				players.OpClient(1);
				players.Client.Dispose();
			}
		}

		private void menuItem11_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				封号(listView1.SelectedItems[0].SubItems[1].Text, 99999);
			}
			string text = listView1.SelectedItems[0].SubItems[1].Text;
			Players players = World.检查玩家(text);
			if (players == null)
			{
				return;
			}
			if (players.Client.挂机)
			{
				if (players.Client != null)
				{
					players.Client.DisposedOffline();
				}
				World.OfflineCount--;
				if (World.OfflineCount < 0)
				{
					World.OfflineCount = 0;
				}
			}
			if (players.Client.假人)
			{
				World.假人数量--;
				if (World.假人数量 < 0)
				{
					World.假人数量 = 0;
				}
				World.CloudAfkCount--;
				if (World.CloudAfkCount < 0)
				{
					World.CloudAfkCount = 0;
				}
				players.Client.DisposedOffline();
			}
			else if (players.Client != null)
			{
				players.OpClient(1);
				players.Client.Dispose();
			}
		}

		private void menuItem12_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				封号(listView1.SelectedItems[0].SubItems[1].Text, 99999);
			}
			string text = listView1.SelectedItems[0].SubItems[1].Text;
			Players players = World.检查玩家(text);
			if (players == null)
			{
				return;
			}
			if (players.Client.挂机)
			{
				if (players.Client != null)
				{
					players.Client.DisposedOffline();
				}
				World.OfflineCount--;
				if (World.OfflineCount < 0)
				{
					World.OfflineCount = 0;
				}
			}
			if (players.Client.假人)
			{
				World.假人数量--;
				if (World.假人数量 < 0)
				{
					World.假人数量 = 0;
				}
				World.CloudAfkCount--;
				if (World.CloudAfkCount < 0)
				{
					World.CloudAfkCount = 0;
				}
				players.Client.DisposedOffline();
			}
			else if (players.Client != null)
			{
				players.OpClient(1);
				players.Client.Dispose();
			}
		}

		private void 封号(string id, int hour)
		{
			DBA.ExeSqlCommand(string.Format("UPDATE TBL_ACCOUNT SET FLD_ZT={1} WHERE FLD_ID='{0}'", id, hour), "rxjhaccount");
			World.检查玩家(id)?.Client.Dispose();
		}
	}
}
