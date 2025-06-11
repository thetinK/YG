using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using RxjhServer.DbClss;

namespace RxjhServer
{
	public class 游戏公告 : Form
	{
		private readonly IContainer icontainer_0;

		private Label label118;

		private TextBox textBox_0;

		private Label label117;

		private TextBox textBox_1;

		private Button button42;

		private Button button41;

		private Button button40;

		private Button button39;

		private ListBox listBox_0;

		private Label label116;

		private Label label1;

		private TextBox textBox1;

		private DateTimePicker dateTimePicker1;

		public 游戏公告()
		{
			icontainer_0 = null;
			InitializeComponent();
		}

		private void button39_Click(object sender, EventArgs e)
		{
			method_0();
		}

		private void method_0()
		{
			try
			{
				string sqlCommand = "select * from tbl_xwwl_gg";
				DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "PublicDb");
				listBox_0.Items.Clear();
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					listBox_0.Items.Add(dBToDataTable.Rows[i]["txt"].ToString());
				}
				dBToDataTable.Dispose();
			}
			catch
			{
			}
		}

		private void button40_Click(object sender, EventArgs e)
		{
			if (textBox_1.Text.Length == 0)
			{
				MessageBox.Show("公告内容不可以为空");
				return;
			}
			string sqlCommand = "INSERT into TBL_XWWL_Gg(ID, txt, type)values(" + textBox1.Text + ", '" + textBox_1.Text + "', " + textBox_0.Text + ")";
			DBA.ExeSqlCommand(sqlCommand, "PublicDb");
			method_0();
		}

		private void button41_Click(object sender, EventArgs e)
		{
			if (listBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("请选择要删除的公告");
				return;
			}
			string sqlCommand = "DELETE TBL_XWWL_GG WHERE TXT='" + textBox_1.Text + "'";
			DBA.ExeSqlCommand(sqlCommand, "PublicDb");
			method_0();
		}

		private void button42_Click(object sender, EventArgs e)
		{
			string sqlCommand = "update TBL_XWWL_GG SET txt='" + textBox_1.Text + "', type='" + textBox_0.Text + "' where txt='" + listBox_0.Text + "' AND TYPE='" + textBox_0.Text + "'";
			DBA.ExeSqlCommand(sqlCommand, "PublicDb");
			method_0();
		}

		private void textBox_1_TextChanged(object sender, EventArgs e)
		{
		}

		private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			string sqlCommand = "select * from tbl_xwwl_gg where txt='" + listBox_0.Text + "'";
			DataTable dBToDataTable = DBA.GetDBToDataTable(sqlCommand, "PublicDb");
			textBox_0.Text = dBToDataTable.Rows[0]["type"].ToString();
			textBox_1.Text = listBox_0.Text;
			dBToDataTable.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(游戏公告));
            this.label118 = new System.Windows.Forms.Label();
            this.textBox_0 = new System.Windows.Forms.TextBox();
            this.label117 = new System.Windows.Forms.Label();
            this.textBox_1 = new System.Windows.Forms.TextBox();
            this.button42 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.listBox_0 = new System.Windows.Forms.ListBox();
            this.label116 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(229, 14);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(53, 12);
            this.label118.TabIndex = 19;
            this.label118.Text = "公告内容";
            // 
            // textBox_0
            // 
            this.textBox_0.Location = new System.Drawing.Point(173, 149);
            this.textBox_0.Name = "textBox_0";
            this.textBox_0.Size = new System.Drawing.Size(44, 21);
            this.textBox_0.TabIndex = 18;
            this.textBox_0.Text = "0";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(138, 154);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(29, 12);
            this.label117.TabIndex = 17;
            this.label117.Text = "类型";
            // 
            // textBox_1
            // 
            this.textBox_1.Location = new System.Drawing.Point(219, 33);
            this.textBox_1.Multiline = true;
            this.textBox_1.Name = "textBox_1";
            this.textBox_1.Size = new System.Drawing.Size(373, 168);
            this.textBox_1.TabIndex = 16;
            this.textBox_1.TextChanged += new System.EventHandler(this.textBox_1_TextChanged);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(138, 116);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(75, 23);
            this.button42.TabIndex = 15;
            this.button42.Text = "修改";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Click += new System.EventHandler(this.button42_Click);
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(138, 87);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(75, 23);
            this.button41.TabIndex = 14;
            this.button41.Text = "删除";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(138, 58);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(75, 23);
            this.button40.TabIndex = 13;
            this.button40.Text = "添加";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.button40_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(138, 29);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(75, 23);
            this.button39.TabIndex = 12;
            this.button39.Text = "查看";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.button39_Click);
            // 
            // listBox_0
            // 
            this.listBox_0.FormattingEnabled = true;
            this.listBox_0.ItemHeight = 12;
            this.listBox_0.Location = new System.Drawing.Point(12, 31);
            this.listBox_0.Name = "listBox_0";
            this.listBox_0.Size = new System.Drawing.Size(120, 172);
            this.listBox_0.TabIndex = 11;
            this.listBox_0.SelectedIndexChanged += new System.EventHandler(this.listBox_0_SelectedIndexChanged);
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(14, 14);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(53, 12);
            this.label116.TabIndex = 10;
            this.label116.Text = "公告列表";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(288, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 179);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(44, 21);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "0";
            // 
            // 游戏公告
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 233);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label118);
            this.Controls.Add(this.textBox_0);
            this.Controls.Add(this.label117);
            this.Controls.Add(this.textBox_1);
            this.Controls.Add(this.button42);
            this.Controls.Add(this.button41);
            this.Controls.Add(this.button40);
            this.Controls.Add(this.button39);
            this.Controls.Add(this.listBox_0);
            this.Controls.Add(this.label116);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "游戏公告";
            this.Text = "游戏公告-源多多资源网-yuandd.Net";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
