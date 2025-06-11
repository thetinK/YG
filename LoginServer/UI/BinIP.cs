using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
	public class BinIP : Form
	{
		private IContainer components;

		private ListView listView1;

		private ColumnHeader columnHeader2;

		private Button button1;

		private MaskedTextBox maskedTextBox1;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem 删除ToolStripMenuItem;

		public BinIP()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void BinIP_Load(object sender, EventArgs e)
		{
			bind2();
		}

		public void bind()
		{
		}

		public void bind2()
		{
		}

		private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
			components = new Container();
			listView1 = new ListView();
			columnHeader2 = new ColumnHeader();
			button1 = new Button();
			maskedTextBox1 = new MaskedTextBox();
			contextMenuStrip1 = new ContextMenuStrip(components);
			删除ToolStripMenuItem = new ToolStripMenuItem();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			listView1.Columns.AddRange(new ColumnHeader[1] { columnHeader2 });
			listView1.ContextMenuStrip = contextMenuStrip1;
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.Location = new Point(8, 8);
			listView1.Name = "listView1";
			listView1.Size = new Size(222, 284);
			listView1.TabIndex = 3;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			columnHeader2.Text = "IP";
			columnHeader2.Width = 166;
			button1.Location = new Point(155, 300);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 4;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new EventHandler(button1_Click);
			maskedTextBox1.Location = new Point(8, 302);
			maskedTextBox1.Name = "maskedTextBox1";
			maskedTextBox1.Size = new Size(139, 21);
			maskedTextBox1.TabIndex = 5;
			contextMenuStrip1.Items.AddRange(new ToolStripItem[1] { 删除ToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(153, 48);
			删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			删除ToolStripMenuItem.Size = new Size(152, 22);
			删除ToolStripMenuItem.Text = "删除";
			删除ToolStripMenuItem.Click += new EventHandler(删除ToolStripMenuItem_Click);
			AutoScaleDimensions = new SizeF(6f, 12f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(242, 335);
			Controls.Add(maskedTextBox1);
			Controls.Add(button1);
			Controls.Add(listView1);
			Name = "BinIP";
			Text = "BinIP";
			Load += new EventHandler(BinIP_Load);
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
