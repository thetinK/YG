using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class Form2 : Form
	{
		private ListView listView2;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader8;

		private ColumnHeader columnHeader10;

		private ColumnHeader columnHeader11;

		private ColumnHeader columnHeader12;

		private ColumnHeader columnHeader14;

		private ColumnHeader columnHeader13;

		private ColumnHeader columnHeader15;

		private ColumnHeader columnHeader16;

		private ColumnHeader columnHeader17;

		public Form2()
		{
			InitializeComponent();
		}

		public static void FlushAll1()
		{
			int num = 0;
			MainForm.WriteLine(100, "删除人物数据开始");
			DataTable dBToDataTable = DBA.GetDBToDataTable("select * from TBL_XWWL_Char");
			if (dBToDataTable != null)
			{
				MainForm.WriteLine(100, "共有人物数据" + dBToDataTable.Rows.Count);
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					if ((int)DBA.GetDBValue_3(string.Format("select count(*) from TBL_ACCOUNT where FLD_ID='{0}'", dBToDataTable.Rows[i]["FLD_ID"]), "rxjhaccount") >= 1)
					{
						continue;
					}
					num++;
					MainForm.WriteLine(100, "删除人物[" + dBToDataTable.Rows[i]["FLD_ID"].ToString() + "] [" + dBToDataTable.Rows[i]["FLD_NAME"]?.ToString() + "]");
					DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_Char WHERE FLD_NAME ='{0}'", dBToDataTable.Rows[i]["FLD_NAME"].ToString()));
					DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_warehouse WHERE FLD_NAME ='{0}'", dBToDataTable.Rows[i]["FLD_NAME"].ToString()));
					DataTable dBToDataTable2 = DBA.GetDBToDataTable(string.Format("select * from TBL_XWWL_GuildMember WHERE FLD_NAME ='{0}'", dBToDataTable.Rows[i]["FLD_NAME"].ToString()));
					if (dBToDataTable2 != null)
					{
						if (dBToDataTable2.Rows.Count > 0)
						{
							if (dBToDataTable2.Rows[0]["leve"].ToString() == "6")
							{
								MainForm.WriteLine(100, "删除帮派" + dBToDataTable2.Rows[0]["G_Name"]);
								DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_Guild WHERE G_Name ='{0}'", dBToDataTable2.Rows[0]["G_Name"].ToString()));
								DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_GuildMember WHERE G_Name ='{0}'", dBToDataTable2.Rows[0]["G_Name"].ToString()));
							}
							else
							{
								DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_GuildMember WHERE FLD_NAME ='{0}'", dBToDataTable.Rows[i]["FLD_NAME"].ToString()));
							}
						}
						dBToDataTable2.Dispose();
					}
					dBToDataTable2.Dispose();
				}
				dBToDataTable.Dispose();
			}
			MainForm.WriteLine(100, "删除人物数据完成" + num);
		}

		public static void FlushAll2()
		{
			int num = 0;
			MainForm.WriteLine(100, "删除人物仓库数据开始");
			DataTable dBToDataTable = DBA.GetDBToDataTable("select * from TBL_XWWL_warehouse");
			if (dBToDataTable != null)
			{
				MainForm.WriteLine(100, "共有人物数据" + dBToDataTable.Rows.Count);
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					DataTable dBToDataTable2 = DBA.GetDBToDataTable(string.Format("select * from TBL_XWWL_Char where FLD_NAME='{0}'", dBToDataTable.Rows[i]["FLD_NAME"]));
					if (dBToDataTable2.Rows.Count < 1)
					{
						num++;
						MainForm.WriteLine(100, "删除人物仓库[" + dBToDataTable.Rows[i]["FLD_ID"].ToString() + "] [" + dBToDataTable.Rows[i]["FLD_NAME"]?.ToString() + "]");
						DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_warehouse WHERE FLD_ID='{0}'and FLD_NAME ='{1}'", dBToDataTable.Rows[i]["FLD_ID"].ToString(), dBToDataTable.Rows[i]["FLD_NAME"].ToString()));
					}
					else if (dBToDataTable2.Rows[0]["FLD_ID"].ToString() != dBToDataTable.Rows[i]["FLD_ID"].ToString())
					{
						num++;
						MainForm.WriteLine(100, "删除人物仓库[" + dBToDataTable.Rows[i]["FLD_ID"].ToString() + "] [" + dBToDataTable.Rows[i]["FLD_NAME"]?.ToString() + "]");
						DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_warehouse WHERE FLD_ID='{0}'and FLD_NAME ='{1}'", dBToDataTable.Rows[i]["FLD_ID"].ToString(), dBToDataTable.Rows[i]["FLD_NAME"].ToString()));
					}
					dBToDataTable2.Dispose();
				}
				dBToDataTable.Dispose();
			}
			MainForm.WriteLine(100, "删除人物仓库数据完成" + num);
		}

		public static void FlushAll3()
		{
			int num = 0;
			MainForm.WriteLine(100, "删除宗合仓库开始");
			DataTable dBToDataTable = DBA.GetDBToDataTable("select * from TBL_XWWL_PublicWarehouse");
			if (dBToDataTable != null)
			{
				MainForm.WriteLine(100, "共有宗合仓库数据" + dBToDataTable.Rows.Count);
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					if ((int)DBA.GetDBValue_3(string.Format("select count(*) from TBL_ACCOUNT where FLD_ID='{0}'", dBToDataTable.Rows[i]["FLD_ID"]), "rxjhaccount") < 1)
					{
						num++;
						MainForm.WriteLine(100, "删除宗合仓库[" + dBToDataTable.Rows[i]["FLD_ID"].ToString() + "]");
						DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_PublicWarehouse WHERE FLD_ID ='{0}'", dBToDataTable.Rows[i]["FLD_ID"].ToString()));
					}
				}
				dBToDataTable.Dispose();
			}
			MainForm.WriteLine(100, "删除宗合仓库完成" + num);
		}

		public static void FlushAll4()
		{
			int num = 0;
			MainForm.WriteLine(100, "删除帮派数据开始");
			DataTable dBToDataTable = DBA.GetDBToDataTable("select * from TBL_XWWL_Guild");
			if (dBToDataTable != null)
			{
				MainForm.WriteLine(100, "共有人物数据" + dBToDataTable.Rows.Count);
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					DataTable dBToDataTable2 = DBA.GetDBToDataTable(string.Format("select * from TBL_XWWL_Char where FLD_NAME='{0}'", dBToDataTable.Rows[i]["G_Master"]));
					if (dBToDataTable2.Rows.Count < 1)
					{
						num++;
						MainForm.WriteLine(100, "删除帮派[" + dBToDataTable.Rows[i]["G_Name"].ToString() + "] [" + dBToDataTable.Rows[i]["G_Master"]?.ToString() + "]");
						DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_Guild WHERE G_Name ='{0}'", dBToDataTable.Rows[i]["G_Name"].ToString()));
						DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_GuildMember WHERE G_Name ='{0}'", dBToDataTable.Rows[i]["G_Name"].ToString()));
					}
					dBToDataTable2.Dispose();
				}
				dBToDataTable.Dispose();
			}
			MainForm.WriteLine(100, "删除帮派数据完成" + num);
			FlushAll5();
		}

		public static void FlushAll5()
		{
			int num = 0;
			MainForm.WriteLine(100, "删除帮派数据开始");
			DataTable dBToDataTable = DBA.GetDBToDataTable("select * from TBL_XWWL_GuildMember");
			if (dBToDataTable != null)
			{
				MainForm.WriteLine(100, "共有帮派数据" + dBToDataTable.Rows.Count);
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					DataTable dBToDataTable2 = DBA.GetDBToDataTable(string.Format("select * from TBL_XWWL_Char where FLD_NAME='{0}'", dBToDataTable.Rows[i]["FLD_NAME"]));
					if (dBToDataTable2.Rows.Count < 1)
					{
						num++;
						if (dBToDataTable.Rows[0]["leve"].ToString() == "6")
						{
							MainForm.WriteLine(100, "删除帮派" + dBToDataTable.Rows[i]["G_Name"]);
							DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_Guild WHERE G_Name ='{0}'", dBToDataTable.Rows[0]["G_Name"].ToString()));
							DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_GuildMember WHERE G_Name ='{0}'", dBToDataTable.Rows[0]["G_Name"].ToString()));
						}
						else
						{
							MainForm.WriteLine(100, "删除帮派" + dBToDataTable.Rows[i]["G_Name"]?.ToString() + " " + dBToDataTable.Rows[i]["FLD_NAME"].ToString());
							DBA.ExeSqlCommand(string.Format("DELETE FROM TBL_XWWL_GuildMember WHERE FLD_NAME ='{0}'", dBToDataTable.Rows[i]["FLD_NAME"].ToString()));
						}
					}
					dBToDataTable2.Dispose();
				}
				dBToDataTable.Dispose();
			}
			MainForm.WriteLine(100, "删除帮派数据完成" + num);
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			listView2.ListViewItemSorter = new ListViewColumnSorter();
			listView2.ColumnClick += ListViewHelper.ListView_ColumnClick;
			foreach (地面物品类 value in World.ItemTemp.Values)
			{
				try
				{
					string[] array = new string[17];
					try
					{
						array[0] = BitConverter.ToInt64(value.物品.物品全局ID, 0).ToString();
						array[1] = BitConverter.ToInt32(value.物品.物品ID, 0).ToString();
						array[2] = value.物品.得到物品名称();
						array[3] = value.Rxjh_Map.ToString();
						array[4] = value.Rxjh_X.ToString();
						array[5] = value.Rxjh_Y.ToString();
						array[6] = value.物品.FLD_MAGIC0.ToString();
						array[7] = value.物品.FLD_MAGIC1.ToString();
						array[8] = value.物品.FLD_MAGIC2.ToString();
						array[9] = value.物品.FLD_MAGIC3.ToString();
						array[10] = value.物品.FLD_MAGIC4.ToString();
						array[11] = value.物品优先权.UserName;
					}
					catch
					{
						array[0] = BitConverter.ToInt64(value.物品.物品全局ID, 0).ToString();
						string[] array3 = array;
						string text = (array3[1] = BitConverter.ToInt32(value.物品.物品ID, 0).ToString());
						array[2] = value.物品.得到物品名称();
						string[] array4 = array;
						string text2 = (array4[3] = value.Rxjh_Map.ToString());
						string[] array5 = array;
						string text3 = (array5[4] = value.Rxjh_X.ToString());
						string[] array6 = array;
						string text4 = (array6[5] = value.Rxjh_Y.ToString());
						string[] array7 = array;
						string text5 = (array7[6] = value.物品.FLD_MAGIC0.ToString());
						string[] array8 = array;
						string text6 = (array8[7] = value.物品.FLD_MAGIC1.ToString());
						string[] array9 = array;
						string text7 = (array9[8] = value.物品.FLD_MAGIC2.ToString());
						string[] array10 = array;
						string text8 = (array10[9] = value.物品.FLD_MAGIC3.ToString());
						string[] array2 = array;
						string text9 = (array2[10] = value.物品.FLD_MAGIC4.ToString());
					}
					listView2.Items.Insert(listView2.Items.Count, new ListViewItem(array));
				}
				catch
				{
				}
			}
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader14,
            this.columnHeader13,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(833, 419);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "全局ID";
            this.columnHeader2.Width = 65;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "物品ID";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 79;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "物品名";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 98;
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
            this.columnHeader12.Text = "属性0";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "属性1";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "属性2";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "属性3";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "属性4";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "优先";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 56;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 419);
            this.Controls.Add(this.listView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地面物品-源多多资源网-yuandd.Net";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

		}
	}
}
