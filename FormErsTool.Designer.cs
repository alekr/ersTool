namespace erstool
{
    partial class FormErsTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormErsTool));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboSite = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.butLaunchSSH = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.butNagios = new System.Windows.Forms.ToolStripButton();
            this.butSplunk = new System.Windows.Forms.ToolStripButton();
            this.butNetscaler = new System.Windows.Forms.ToolStripButton();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageHosts = new System.Windows.Forms.TabPage();
            this.hostList = new erstool.hostList();
            this.tabPageVSs = new System.Windows.Forms.TabPage();
            this.virtServList = new erstool.virtServList();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportListAscsvFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyManagementAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyApplicationIPAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyHostNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyCurrentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCurrentListWithTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.launchNagiosUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchSplunkUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchLoadBalancerUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageHosts.SuspendLayout();
            this.tabPageVSs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SlateGray;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.comboSite,
            this.toolStripSeparator2,
            this.butLaunchSSH,
            this.toolStripSeparator1,
            this.butNagios,
            this.butSplunk,
            this.butNetscaler});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(945, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ActiveLinkColor = System.Drawing.Color.Transparent;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 52);
            this.toolStripLabel1.Text = "   Site:";
            // 
            // comboSite
            // 
            this.comboSite.AutoSize = false;
            this.comboSite.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.comboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSite.ForeColor = System.Drawing.Color.White;
            this.comboSite.Items.AddRange(new object[] {
            "Harrogate",
            "Reading"});
            this.comboSite.Name = "comboSite";
            this.comboSite.Size = new System.Drawing.Size(161, 29);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // butLaunchSSH
            // 
            this.butLaunchSSH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butLaunchSSH.Image = global::erstool.Properties.Resources.putty;
            this.butLaunchSSH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butLaunchSSH.Name = "butLaunchSSH";
            this.butLaunchSSH.Size = new System.Drawing.Size(52, 52);
            this.butLaunchSSH.Text = "PUTTY";
            this.butLaunchSSH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.butLaunchSSH.ToolTipText = "Launch SSH Sesion with Selected Host";
            this.butLaunchSSH.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // butNagios
            // 
            this.butNagios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butNagios.Image = global::erstool.Properties.Resources.nagios;
            this.butNagios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butNagios.Name = "butNagios";
            this.butNagios.Size = new System.Drawing.Size(52, 52);
            this.butNagios.Text = "Nagios";
            this.butNagios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.butNagios.ToolTipText = "Launch Nagios UI (Ctrl+Shift+N)";
            this.butNagios.Click += new System.EventHandler(this.OnLaunchNagios);
            // 
            // butSplunk
            // 
            this.butSplunk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butSplunk.Image = global::erstool.Properties.Resources.splunk;
            this.butSplunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butSplunk.Name = "butSplunk";
            this.butSplunk.Size = new System.Drawing.Size(52, 52);
            this.butSplunk.Text = "Splunk";
            this.butSplunk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.butSplunk.ToolTipText = "Launch Splunk UI (Ctrl+Shift+S)";
            this.butSplunk.Click += new System.EventHandler(this.OnLaunchSplunk);
            // 
            // butNetscaler
            // 
            this.butNetscaler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butNetscaler.Image = global::erstool.Properties.Resources.netscaler;
            this.butNetscaler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butNetscaler.Name = "butNetscaler";
            this.butNetscaler.Size = new System.Drawing.Size(52, 52);
            this.butNetscaler.Text = "Netscaler";
            this.butNetscaler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.butNetscaler.ToolTipText = "Launch Load Balancer UI (Ctrl+Shift+L)";
            this.butNetscaler.Click += new System.EventHandler(this.OnLaunchLoadBalancer);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageHosts);
            this.tabControlMain.Controls.Add(this.tabPageVSs);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(96, 24);
            this.tabControlMain.Location = new System.Drawing.Point(0, 79);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(945, 479);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlMain_DrawItem);
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageHosts
            // 
            this.tabPageHosts.Controls.Add(this.hostList);
            this.tabPageHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageHosts.Location = new System.Drawing.Point(4, 28);
            this.tabPageHosts.Name = "tabPageHosts";
            this.tabPageHosts.Padding = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.tabPageHosts.Size = new System.Drawing.Size(937, 447);
            this.tabPageHosts.TabIndex = 0;
            this.tabPageHosts.Text = "  Hosts";
            this.tabPageHosts.UseVisualStyleBackColor = true;
            // 
            // hostList
            // 
            this.hostList.Configuration = null;
            this.hostList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostList.HostsFile = "";
            this.hostList.Location = new System.Drawing.Point(3, 3);
            this.hostList.Name = "hostList";
            this.hostList.Size = new System.Drawing.Size(928, 441);
            this.hostList.TabIndex = 0;
            this.hostList.ItemDoubleClick += new erstool.hostList.ItemDoubleClickDelegate(this.hostList_ItemDoubleClick);
            // 
            // tabPageVSs
            // 
            this.tabPageVSs.BackColor = System.Drawing.Color.Transparent;
            this.tabPageVSs.Controls.Add(this.virtServList);
            this.tabPageVSs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageVSs.Location = new System.Drawing.Point(4, 28);
            this.tabPageVSs.Name = "tabPageVSs";
            this.tabPageVSs.Size = new System.Drawing.Size(937, 447);
            this.tabPageVSs.TabIndex = 1;
            this.tabPageVSs.Text = "  Virtual Servers   ";
            // 
            // virtServList
            // 
            this.virtServList.Configuration = null;
            this.virtServList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtServList.Location = new System.Drawing.Point(0, 0);
            this.virtServList.Name = "virtServList";
            this.virtServList.ServersFile = "";
            this.virtServList.Size = new System.Drawing.Size(937, 447);
            this.virtServList.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportListAscsvFileToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exportListAscsvFileToolStripMenuItem
            // 
            this.exportListAscsvFileToolStripMenuItem.Name = "exportListAscsvFileToolStripMenuItem";
            this.exportListAscsvFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.exportListAscsvFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exportListAscsvFileToolStripMenuItem.Text = "Save List As ...";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyManagementAddressToolStripMenuItem,
            this.copyApplicationIPAddressToolStripMenuItem,
            this.copyHostNameToolStripMenuItem,
            this.toolStripMenuItem3,
            this.copyCurrentListToolStripMenuItem,
            this.copyCurrentListWithTabsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyManagementAddressToolStripMenuItem
            // 
            this.copyManagementAddressToolStripMenuItem.Name = "copyManagementAddressToolStripMenuItem";
            this.copyManagementAddressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.copyManagementAddressToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.copyManagementAddressToolStripMenuItem.Text = "Copy Management IP Address";
            this.copyManagementAddressToolStripMenuItem.Click += new System.EventHandler(this.copyManagementAddressToolStripMenuItem_Click);
            // 
            // copyApplicationIPAddressToolStripMenuItem
            // 
            this.copyApplicationIPAddressToolStripMenuItem.Name = "copyApplicationIPAddressToolStripMenuItem";
            this.copyApplicationIPAddressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.copyApplicationIPAddressToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.copyApplicationIPAddressToolStripMenuItem.Text = "Copy Application IP Address";
            this.copyApplicationIPAddressToolStripMenuItem.Click += new System.EventHandler(this.copyApplicationIPAddressToolStripMenuItem_Click);
            // 
            // copyHostNameToolStripMenuItem
            // 
            this.copyHostNameToolStripMenuItem.Name = "copyHostNameToolStripMenuItem";
            this.copyHostNameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.copyHostNameToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.copyHostNameToolStripMenuItem.Text = "Copy Host Name";
            this.copyHostNameToolStripMenuItem.Click += new System.EventHandler(this.copyHostNameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(280, 6);
            // 
            // copyCurrentListToolStripMenuItem
            // 
            this.copyCurrentListToolStripMenuItem.Name = "copyCurrentListToolStripMenuItem";
            this.copyCurrentListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.copyCurrentListToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.copyCurrentListToolStripMenuItem.Text = "Copy Current List with Commas";
            this.copyCurrentListToolStripMenuItem.Click += new System.EventHandler(this.copyCurrentListToolStripMenuItem_Click);
            // 
            // copyCurrentListWithTabsToolStripMenuItem
            // 
            this.copyCurrentListWithTabsToolStripMenuItem.Name = "copyCurrentListWithTabsToolStripMenuItem";
            this.copyCurrentListWithTabsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.copyCurrentListWithTabsToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.copyCurrentListWithTabsToolStripMenuItem.Text = "Copy Current List with Tabs";
            this.copyCurrentListWithTabsToolStripMenuItem.Click += new System.EventHandler(this.copyCurrentListWithTabsToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findHostsToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // findHostsToolStripMenuItem
            // 
            this.findHostsToolStripMenuItem.Name = "findHostsToolStripMenuItem";
            this.findHostsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findHostsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.findHostsToolStripMenuItem.Text = "Find ....";
            this.findHostsToolStripMenuItem.Click += new System.EventHandler(this.findHostsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.launchNagiosUIToolStripMenuItem,
            this.launchSplunkUIToolStripMenuItem,
            this.launchLoadBalancerUIToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(273, 6);
            // 
            // launchNagiosUIToolStripMenuItem
            // 
            this.launchNagiosUIToolStripMenuItem.Name = "launchNagiosUIToolStripMenuItem";
            this.launchNagiosUIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.launchNagiosUIToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.launchNagiosUIToolStripMenuItem.Text = "Launch Nagios UI";
            this.launchNagiosUIToolStripMenuItem.Click += new System.EventHandler(this.OnLaunchNagios);
            // 
            // launchSplunkUIToolStripMenuItem
            // 
            this.launchSplunkUIToolStripMenuItem.Name = "launchSplunkUIToolStripMenuItem";
            this.launchSplunkUIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.launchSplunkUIToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.launchSplunkUIToolStripMenuItem.Text = "Launch Splunk UI";
            this.launchSplunkUIToolStripMenuItem.Click += new System.EventHandler(this.OnLaunchSplunk);
            // 
            // launchLoadBalancerUIToolStripMenuItem
            // 
            this.launchLoadBalancerUIToolStripMenuItem.Name = "launchLoadBalancerUIToolStripMenuItem";
            this.launchLoadBalancerUIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.launchLoadBalancerUIToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.launchLoadBalancerUIToolStripMenuItem.Text = "Launch Load Balancer UI";
            this.launchLoadBalancerUIToolStripMenuItem.Click += new System.EventHandler(this.OnLaunchLoadBalancer);
            // 
            // FormErsTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 558);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormErsTool";
            this.Text = "NHS e-RS Infrastructure Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormErsTool_FormClosing);
            this.Load += new System.EventHandler(this.FormErsTool_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageHosts.ResumeLayout(false);
            this.tabPageVSs.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butLaunchSSH;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageHosts;
        private hostList hostList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyManagementAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyApplicationIPAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyHostNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findHostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton butNagios;
        private System.Windows.Forms.ToolStripButton butSplunk;
        private System.Windows.Forms.ToolStripButton butNetscaler;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem launchNagiosUIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchSplunkUIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchLoadBalancerUIToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox comboSite;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TabPage tabPageVSs;
        private virtServList virtServList;
        private System.Windows.Forms.ToolStripMenuItem exportListAscsvFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem copyCurrentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCurrentListWithTabsToolStripMenuItem;
    }
}

