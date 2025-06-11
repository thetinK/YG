using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RxjhServer
{
	public class Form3 : Form
	{
		private Button button1;

		private Label label1;

		public Form3()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "本程序为学习C#网络通讯知识以及C#语言编程技术之用，\r\n请勿用于商业用途或一切非法活动，如有用于商业用途，\r\n程序开发者不能保证程序没有BUG，也不能保证您的利" +
    "益\r\n能得到充分保障，更不可用于非法用途，否则由此造成的\r\n一切后果与程序开发者无关，如您使用本程序代表您已知悉\r\n上述声明。";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "使用声明-源多多资源网-yuandd.Net";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
