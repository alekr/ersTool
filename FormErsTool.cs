using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace erstool
{
    public partial class FormErsTool : Form
    {
        private ErsToolConfiguration config = null;
        private FormSettings formSettings = null;

        public FormErsTool()
        {
            InitializeComponent();
        }

        private void FormErsTool_Load(object sender, EventArgs e)
        {
            config = new ErsToolConfiguration();
            comboSite.SelectedIndex = config.Site;

            hostList.Configuration = config;
            virtServList.Configuration = config;

            formSettings = new FormSettings();
            formSettings.Configuration = config;

            ConfigUI();
            LoadHosts();

            hostList.Focus();

            //tabControlMain.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        private void ConfigUI()
        {
            string mainWindowSize = erstool.Properties.Settings.Default.MainWindowSize;
            string[] items = mainWindowSize.Split(new char[] { ',' });
            if (items.Length != 4)
                return;

            this.Left = Convert.ToInt32(items[0]);
            this.Top = Convert.ToInt32(items[1]);
            this.Width = Convert.ToInt32(items[2]);
            this.Height = Convert.ToInt32(items[3]);
        }

        private void LoadHosts()
        {
            hostList.HostsFile = "hosts.tsv";
            virtServList.ServersFile = "lbvs.tsv";
        }

        private void FormErsTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            hostList.SaveSettings();
            virtServList.SaveSettings();
            SaveUIParameters();
        }

        private void SaveUIParameters()
        {
            string mainWindowSize = this.Left.ToString() + "," + 
                                    this.Top.ToString() + "," + 
                                    this.Width.ToString() + "," + 
                                    this.Height.ToString();

            erstool.Properties.Settings.Default.Upgrade();
            erstool.Properties.Settings.Default.MainWindowSize = mainWindowSize;
            erstool.Properties.Settings.Default.Save();
        }

        private void copyManagementAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
                Clipboard.SetText(hostList.ManagementIpAddress);
        }

        private void copyApplicationIPAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
                Clipboard.SetText(hostList.ApplicationIpAddress);
            else
                Clipboard.SetText(virtServList.ApplicationIpAddress);
        }

        private void copyHostNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
                Clipboard.SetText(hostList.HostName);
            else
                Clipboard.SetText(virtServList.ServerName);
        }

        private void findHostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
            {
                hostList.Focus();
                hostList.FocusOnSearchBox();
            }
            else
            {
                virtServList.Focus();
                virtServList.FocusOnSearchBox();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formSettings.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LaunchSSHSessionWithSelectedHost();
        }

        private void LaunchSSHSessionWithSelectedHost()
        {
            if (tabControlMain.SelectedIndex != 0)
                return;

            String putty = config.PuttyPath.Trim();
            String user = config.SSHUser.Trim();
            String host = hostList.ManagementIpAddress;

#if false
            if ((putty == null) || (putty == String.Empty) || (user == null) || (user == String.Empty))
            {
                MessageBox.Show("Please specify the PUTTY path and the SSH username in the Settings.");
                return;
            }
#else
            if (String.IsNullOrEmpty(putty))
            {
                MessageBox.Show("Please specify the PUTTY path in the Settings.");
                return;
            }
#endif

            if ((host == null) || (host == String.Empty))
            {
                MessageBox.Show("Please select a host.");
                return;
            }
            // copy password to Clipboard if one is provided
            if (String.IsNullOrEmpty(config.SSHPassword) == false)
                Clipboard.SetText(config.SSHPassword);

            String executable = "\"" + putty + "\"";
            String arguments = " -ssh " + host;

            if (String.IsNullOrEmpty(user) == false)
            {
                arguments += " -l " + user;

                if (String.IsNullOrEmpty(config.SSHPassword) == false)
                    arguments += " -pw " + config.SSHPassword;
            }
#if false
            //String arguments = " -ssh " + host + " -l " + user + " -pw " + config.SSHPassword;
            //String arguments = " -ssh " + user + "@" + host + " -pw " + config.SSHPassword;
            //String arguments = " -ssh " + host + " -load " + "TechOps_PROD_REPO -pw " + config.SSHPassword;
            //String arguments = " -ssh " + host + " -load " + "Green -pw " + config.SSHPassword;
#endif

            System.Diagnostics.Process.Start(executable, arguments);
        }

        private void hostList_ItemDoubleClick(object sender)
        {
            LaunchSSHSessionWithSelectedHost();
        }

        private void OnLaunchSplunk(object sender, EventArgs e)
        {
//            System.Diagnostics.Process.Start("IExplore.exe", "192.168.0.23");
            if (comboSite.SelectedIndex == 1)
                System.Diagnostics.Process.Start("http://192.168.0.23/");
            else
                System.Diagnostics.Process.Start("http://192.168.16.23/");
        }

        private void OnLaunchLoadBalancer(object sender, EventArgs e)
        {
//            System.Diagnostics.Process.Start("IExplore.exe", "192.168.0.57");
            Clipboard.SetText("hoMEIk8PipT");
            if (comboSite.SelectedIndex == 1)
                System.Diagnostics.Process.Start("http://192.168.0.57/");
            else
                System.Diagnostics.Process.Start("http://192.168.16.57/");
        }

        private void OnLaunchNagios(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("IExplore.exe", "192.168.0.22/nagios");
            if (comboSite.SelectedIndex == 1)
                System.Diagnostics.Process.Start("http://192.168.0.22/nagios");
            else
                System.Diagnostics.Process.Start("http://192.168.16.22/nagios");
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            copyManagementAddressToolStripMenuItem.Enabled = tabControlMain.SelectedIndex == 0;
        }

        private void copyCurrentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
                Clipboard.SetText(hostList.CurrentList);
            else
                Clipboard.SetText(virtServList.CurrentList);
        }

        private void copyCurrentListWithTabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
                Clipboard.SetText(hostList.CurrentListWithTabs);
            else
                Clipboard.SetText(virtServList.CurrentListWithTabs);
        }

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            // This event is called once for each tab button in your tab control

            // First paint the background with a color based on the current tab

            // e.Index is the index of the tab in the TabPages collection.
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.SaddleBrown), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.SeaGreen), e.Bounds);
                    break;
                default:
                    break;
            }

            // Then draw the current tab button text 
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(tabControlMain.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
        }
    }
}
