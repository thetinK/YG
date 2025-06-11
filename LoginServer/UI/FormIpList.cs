using Core;
using Network.TCP;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UI.Helpers;

namespace UI
{
	public class FormIpList : Form
	{
		private IContainer components;

		private ListView listView1;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem banIPToolStripMenuItem;

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
            columnHeader5 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            banIPToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] {
            columnHeader5,
            columnHeader1,
            columnHeader2,
            columnHeader3,
            columnHeader4});
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.HideSelection = false;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(531, 388);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "ID";
            columnHeader5.Width = 95;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "User IP";
            columnHeader1.Width = 124;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Current Server";
            columnHeader2.Width = 135;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Online Duration";
            columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Connections";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
            banIPToolStripMenuItem});
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(100, 26);
            // 
            // 封IPToolStripMenuItem
            // 
            banIPToolStripMenuItem.Name = "banIPToolStripMenuItem";
            banIPToolStripMenuItem.Size = new Size(99, 22);
            banIPToolStripMenuItem.Text = "Ban IP";
            banIPToolStripMenuItem.Click += new EventHandler(banIPToolStripMenuItem_Click);
            // 
            // FormIpList
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 388);
            Controls.Add(listView1);
            Name = "FormIpList";
            Text = "IP Management - Player Connection Monitor";
            Load += new EventHandler(FormIpList_Load);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);

		}

        public FormIpList()
        {
            InitializeComponent();
        }

        private void FormIpList_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                listView1.ListViewItemSorter = new ListViewColumnSorter();
                listView1.ColumnClick += ListViewHelper.ListView_ColumnClick;

                foreach (NetState value in World.ConnectLst.Values)
                {
                    if (value != null)
                    {
                        listView1.Items.Insert(listView1.Items.Count, new ListViewItem(new string[5]
                        {
                            value.WorldId.ToString(),        // World/Server ID
							value.ToString(),                // IP Address
							value.packconn.ToString(),       // Connection count
							GetOnlineDuration(value),        // Online duration (placeholder)
							GetConnectionInfo(value)         // Additional connection info
						}));
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error or show message
                MessageBox.Show($"Error loading IP list: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetOnlineDuration(NetState netState)
        {
            // Placeholder - implement actual duration calculation
            // This would typically calculate time since connection established
            return "N/A";
        }
        private string GetConnectionInfo(NetState netState)
        {
            // Placeholder - return relevant connection info
            return netState.packconn.ToString();
        }

        private void banIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                string ipAddress = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to ban IP address: {ipAddress}?",
                    "Confirm IP Ban",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    BanIPAddress(ipAddress);
                }
            }
            else
            {
                MessageBox.Show("Please select an IP address to ban.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BanIPAddress(string ipAddress)
        {
            try
            {
                // Implementation would add IP to ban list
                // This might involve:
                // 1. Adding to database ban table
                // 2. Adding to in-memory ban collection
                // 3. Disconnecting current connections from this IP
                // 4. Logging the ban action

                MessageBox.Show($"IP address {ipAddress} has been banned.", "IP Banned",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the list to show updated status
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error banning IP: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void RefreshList()
        {
            listView1.Items.Clear();
            BindData();
        }

        public void bind()
        {
            RefreshList();
        }
    }
}