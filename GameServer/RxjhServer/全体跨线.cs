using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RxjhServer.DbClss;
using RxjhServer.HelperTools;

namespace RxjhServer
{
	public class 全体跨线 : Form
	{
		private readonly IContainer components = null;

		private GroupBox groupBox1;

		private TextBox textBox2;

		private TextBox textBox1;

		private Button button1;

		private Label label2;

		private TextBox textBox3;

		private Label label3;

		private Label label1;

		public 全体跨线()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				button1.Enabled = false;
				button1.Text = "请稍等....";
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value.离线挂机打怪模式 == 0 && value.离线打架模式 == 0)
					{
						换线(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), value);
					}
				}
				button1.Enabled = true;
				button1.Text = "全体转移";
				MessageBox.Show("所有在线玩家转移完成!!!");
			}
			catch
			{
				MessageBox.Show("换线过程中有错误请重新运行换线");
			}
		}

		public void 换线(string IP, int port, int ID, Players play)
		{
			try
			{
				play.清空辅助状态();
				play.Client.在线 = false;
				int value = 0;
				DataTable dBToDataTable = DBA.GetDBToDataTable("select * from [TBL_XWWL_Char] where FLD_NAME=@Userid", new SqlParameter[1] { SqlDBA.MakeInParam("@Userid", SqlDbType.VarChar, 30, play.UserName) });
				if (dBToDataTable != null)
				{
					value = (int)dBToDataTable.Rows[0]["FLD_INDEX"];
					dBToDataTable.Dispose();
					goto IL_00eb;
				}
				if (play.Client == null)
				{
					goto IL_00eb;
				}
				play.kickidlog("换线()获取人物出错");
				MainForm.WriteLine(1, "获取人物出错，[" + play.Userid + "][" + play.UserName + "]");
				play.OpClient(1);
				play.Client.Dispose();
				goto end_IL_0001;
				IL_00eb:
				byte[] array = Converter.hexStringToByte("AA550600E7035015000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(play.人物全服ID), 0, array, 4, 2);
				if (play.Client != null)
				{
					play.Client.Send(array, array.Length);
				}
				byte[] array2 = Converter.hexStringToByte("AA552E00E703D20028000100000000000000000000000000000000000000000000003200000000000000000000000000000055AA");
				Buffer.BlockCopy(BitConverter.GetBytes(ID), 0, array2, 14, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, array2, 18, 4);
				Buffer.BlockCopy(BitConverter.GetBytes(port), 0, array2, 30, 4);
				byte[] bytes = Encoding.Default.GetBytes(IP);
				Buffer.BlockCopy(bytes, 0, array2, 34, bytes.Length);
				World.conn.发送("用户换线通知|" + play.Userid + "|" + play.判断是否用封包登陆);
				if (play.Client != null)
				{
					play.Client.Send(array2, array2.Length);
				}
				play.SavePlayerData();
				MainForm.WriteLine(1, "用户换线通知|" + play.Userid + "|" + play.判断是否用封包登陆);
				end_IL_0001:;
			}
			catch
			{
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(全体跨线));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在线人员集体跨线";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(117, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "其他线路ID";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(117, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "全体转移";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "其他线路端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "其他线路IP";
            // 
            // 全体跨线
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 159);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "全体跨线";
            this.Text = "全体跨线-源多多资源网-yuandd.Net";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
