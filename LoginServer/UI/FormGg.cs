using Core;
using Network.Clients;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
	public class FormGg : Form
	{
		private ComboBox comboBox1;

		private TextBox textBox1;

		private Button button1;

		public FormGg()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (comboBox1.Text == "System Announcement")
			{
				SendAnnouncement(0, textBox1.Text);
			}
			else if (comboBox1.Text == "System Scrolling Announcement")
			{
				SendAnnouncement(1, textBox1.Text);
			}
			else if (comboBox1.Text == "System Notice")
			{
				SendAnnouncement(2, textBox1.Text);
			}
		}

		public void SendAnnouncement(int id, string txt)
		{
			foreach (SockClient value in World.ConnectedServers.Values)
			{
				value.Send("Send Announcement|" + id + "|" + txt);
			}
		}

		private void InitializeComponent()
		{
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "System Announcement",
            "System Scrolling Announcement",
            "System Notice"});
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] {
            "System Announcement",
            "System Scrolling Announcement",
            "System Notice"});
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(92, 20);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "System Announcement";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 38);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(292, 151);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(217, 9);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(button1_Click);
            // 
            // FormGg
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 201);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            MaximizeBox = false;
            Name = "FormGg";
            Text = "Announcement Form";
            ResumeLayout(false);
            PerformLayout();

		}
	}
}
