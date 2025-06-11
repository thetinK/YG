using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RxjhServer
{
	public class RegisterForm : Form
	{
		private Label label1;

		private TextBox textBox1;

		private TextBox textBox2;

		private Label label2;

		private Label label3;

		private TextBox textBox3;

		private Button button1;

		private readonly Ini ini = new Ini(Application.StartupPath + "\\config\\config.ini");

		public RegisterForm()
		{
			InitializeComponent();
			textBox1.Text = Aes.GetMachineCode();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if ((Aes.Decrypt("QWEDCVBGHYTRDSGHJKGFD123568GFFSA", textBox2.Text)?.StartsWith(Aes.GetMachineCode()) ?? false) && (Aes.Decrypt("dfgiuyt1235whgfyjlkmnhttrtiudsfa", textBox3.Text)?.StartsWith(Aes.GetMachineCode()) ?? false))
			{
				ini.SetString("Key1", textBox2.Text);
				ini.SetString("Key2", textBox3.Text);
				Hide();
				new MainForm().ShowDialog();
				Close();
			}
			else
			{
				MessageBox.Show("注册码不正确");
			}
		}

		public bool qdyzcod()
		{
			try
			{
				if ((Aes.Decrypt("QWEDCVBGHYTRDSGHJKGFD123568GFFSA", World.Key1)?.StartsWith(Aes.GetMachineCode()) ?? false) && (Aes.Decrypt("dfgiuyt1235whgfyjlkmnhttrtiudsfa", World.Key2)?.StartsWith(Aes.GetMachineCode()) ?? false))
				{
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 26);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 21);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(66, 72);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(333, 63);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "注册码1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "注册码2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(66, 158);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(333, 63);
            this.textBox3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(178, 246);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "激活";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 282);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册码激活-源多多资源网-yuandd.Net";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
