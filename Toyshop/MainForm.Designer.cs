namespace Toyshop
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCatalogMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTablesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editTablesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editConnectionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsAdminMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsSellerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.windowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.windowPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpAboutHappyTreeFriendsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.accountMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.accountManageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.accountLogoutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMenu,
            this.editMenu,
            this.reportsAdminMenu,
            this.reportsSellerMenu,
            this.reportsMenu,
            this.windowMenu,
            this.windowPositionToolStripMenuItem,
            this.accountMenu,
            this.helpMenu,
            this.exitToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.MdiWindowListItem = this.windowMenu;
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(804, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCatalogMenu,
            this.viewTablesMenu});
            this.viewMenu.Image = ((System.Drawing.Image)(resources.GetObject("viewMenu.Image")));
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(60, 20);
            this.viewMenu.Text = "View";
            // 
            // viewCatalogMenu
            // 
            this.viewCatalogMenu.Image = ((System.Drawing.Image)(resources.GetObject("viewCatalogMenu.Image")));
            this.viewCatalogMenu.Name = "viewCatalogMenu";
            this.viewCatalogMenu.Size = new System.Drawing.Size(115, 22);
            this.viewCatalogMenu.Text = "Catalog";
            this.viewCatalogMenu.Click += new System.EventHandler(this.catalogToolStripMenuItem_Click);
            // 
            // viewTablesMenu
            // 
            this.viewTablesMenu.Image = ((System.Drawing.Image)(resources.GetObject("viewTablesMenu.Image")));
            this.viewTablesMenu.Name = "viewTablesMenu";
            this.viewTablesMenu.Size = new System.Drawing.Size(115, 22);
            this.viewTablesMenu.Text = "Tables";
            this.viewTablesMenu.Click += new System.EventHandler(this.viewTablesMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTablesMenu,
            this.editConnectionsMenu});
            this.editMenu.Image = ((System.Drawing.Image)(resources.GetObject("editMenu.Image")));
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(55, 20);
            this.editMenu.Text = "Edit";
            this.editMenu.Visible = false;
            // 
            // editTablesMenu
            // 
            this.editTablesMenu.Image = ((System.Drawing.Image)(resources.GetObject("editTablesMenu.Image")));
            this.editTablesMenu.Name = "editTablesMenu";
            this.editTablesMenu.Size = new System.Drawing.Size(141, 22);
            this.editTablesMenu.Text = "Tables";
            this.editTablesMenu.Click += new System.EventHandler(this.editTablesMenu_Click);
            // 
            // editConnectionsMenu
            // 
            this.editConnectionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("editConnectionsMenu.Image")));
            this.editConnectionsMenu.Name = "editConnectionsMenu";
            this.editConnectionsMenu.Size = new System.Drawing.Size(141, 22);
            this.editConnectionsMenu.Text = "Connections";
            this.editConnectionsMenu.Click += new System.EventHandler(this.editConnectionsMenu_Click);
            // 
            // reportsAdminMenu
            // 
            this.reportsAdminMenu.Image = ((System.Drawing.Image)(resources.GetObject("reportsAdminMenu.Image")));
            this.reportsAdminMenu.Name = "reportsAdminMenu";
            this.reportsAdminMenu.Size = new System.Drawing.Size(75, 20);
            this.reportsAdminMenu.Text = "Reports";
            this.reportsAdminMenu.Visible = false;
            this.reportsAdminMenu.Click += new System.EventHandler(this.reportsAdminToolStripMenuItem_Click);
            // 
            // reportsSellerMenu
            // 
            this.reportsSellerMenu.Image = ((System.Drawing.Image)(resources.GetObject("reportsSellerMenu.Image")));
            this.reportsSellerMenu.Name = "reportsSellerMenu";
            this.reportsSellerMenu.Size = new System.Drawing.Size(75, 20);
            this.reportsSellerMenu.Text = "Reports";
            this.reportsSellerMenu.Click += new System.EventHandler(this.reportsSellerToolStripMenuItem_Click);
            // 
            // reportsMenu
            // 
            this.reportsMenu.Image = ((System.Drawing.Image)(resources.GetObject("reportsMenu.Image")));
            this.reportsMenu.Name = "reportsMenu";
            this.reportsMenu.Size = new System.Drawing.Size(105, 20);
            this.reportsMenu.Text = "Reports (Old)";
            this.reportsMenu.Visible = false;
            this.reportsMenu.Click += new System.EventHandler(this.reportsMenu_Click);
            // 
            // windowMenu
            // 
            this.windowMenu.Image = ((System.Drawing.Image)(resources.GetObject("windowMenu.Image")));
            this.windowMenu.Name = "windowMenu";
            this.windowMenu.Size = new System.Drawing.Size(79, 20);
            this.windowMenu.Text = "Window";
            // 
            // windowPositionToolStripMenuItem
            // 
            this.windowPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.horizontallyToolStripMenuItem,
            this.verticallyToolStripMenuItem});
            this.windowPositionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("windowPositionToolStripMenuItem.Image")));
            this.windowPositionToolStripMenuItem.Name = "windowPositionToolStripMenuItem";
            this.windowPositionToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.windowPositionToolStripMenuItem.Text = "Windows Position";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // horizontallyToolStripMenuItem
            // 
            this.horizontallyToolStripMenuItem.Name = "horizontallyToolStripMenuItem";
            this.horizontallyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.horizontallyToolStripMenuItem.Text = "Horizontally";
            this.horizontallyToolStripMenuItem.Click += new System.EventHandler(this.horizontallyToolStripMenuItem_Click);
            // 
            // verticallyToolStripMenuItem
            // 
            this.verticallyToolStripMenuItem.Name = "verticallyToolStripMenuItem";
            this.verticallyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.verticallyToolStripMenuItem.Text = "Vertically";
            this.verticallyToolStripMenuItem.Click += new System.EventHandler(this.verticallyToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutHappyTreeFriendsMenu});
            this.helpMenu.Image = ((System.Drawing.Image)(resources.GetObject("helpMenu.Image")));
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(60, 20);
            this.helpMenu.Text = "Help";
            // 
            // helpAboutHappyTreeFriendsMenu
            // 
            this.helpAboutHappyTreeFriendsMenu.Image = ((System.Drawing.Image)(resources.GetObject("helpAboutHappyTreeFriendsMenu.Image")));
            this.helpAboutHappyTreeFriendsMenu.Name = "helpAboutHappyTreeFriendsMenu";
            this.helpAboutHappyTreeFriendsMenu.Size = new System.Drawing.Size(212, 22);
            this.helpAboutHappyTreeFriendsMenu.Text = "About Happy Tree Friends";
            this.helpAboutHappyTreeFriendsMenu.Click += new System.EventHandler(this.helpAboutHappyTreeFriendsMenu_Click);
            // 
            // accountMenu
            // 
            this.accountMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountManageMenu,
            this.accountLogoutMenu});
            this.accountMenu.Image = global::Toyshop.Properties.Resources.Personal;
            this.accountMenu.Name = "accountMenu";
            this.accountMenu.Size = new System.Drawing.Size(80, 20);
            this.accountMenu.Text = "Account";
            // 
            // accountManageMenu
            // 
            this.accountManageMenu.Image = global::Toyshop.Properties.Resources.Live_Messenger;
            this.accountManageMenu.Name = "accountManageMenu";
            this.accountManageMenu.Size = new System.Drawing.Size(168, 22);
            this.accountManageMenu.Text = "Manage accounts";
            this.accountManageMenu.Visible = false;
            this.accountManageMenu.Click += new System.EventHandler(this.accountManageMenu_Click);
            // 
            // accountLogoutMenu
            // 
            this.accountLogoutMenu.Image = global::Toyshop.Properties.Resources.Power___Switch_User;
            this.accountLogoutMenu.Name = "accountLogoutMenu";
            this.accountLogoutMenu.Size = new System.Drawing.Size(168, 22);
            this.accountLogoutMenu.Text = "Log out";
            this.accountLogoutMenu.Click += new System.EventHandler(this.accountLogoutMenu_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Toyshop.Properties.Resources.back_800p;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(804, 478);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Happy Tree Friends";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem viewTablesMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem editTablesMenu;
        private System.Windows.Forms.ToolStripMenuItem editConnectionsMenu;
        private System.Windows.Forms.ToolStripMenuItem reportsMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem helpAboutHappyTreeFriendsMenu;
        private System.Windows.Forms.ToolStripMenuItem windowMenu;
        private System.Windows.Forms.ToolStripMenuItem windowPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCatalogMenu;
        private System.Windows.Forms.ToolStripMenuItem accountMenu;
        private System.Windows.Forms.ToolStripMenuItem accountManageMenu;
        private System.Windows.Forms.ToolStripMenuItem accountLogoutMenu;
        private System.Windows.Forms.ToolStripMenuItem reportsSellerMenu;
        private System.Windows.Forms.ToolStripMenuItem reportsAdminMenu;
    }
}

