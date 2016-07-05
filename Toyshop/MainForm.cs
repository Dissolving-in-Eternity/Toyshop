using System;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class MainForm : Form
    {
        LoginForm loginForm;
        bool exitAppOnClose = true;    // MORE CRUTCHES FOR THE CRUTCH GOD

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text += " @ logged in as " + AccountManager.Name;
        }
            
        public MainForm(LoginForm form)
        {
            InitializeComponent();
            loginForm = form;
        }

        public void InitializeMenuWithAccountRights()
        {
            AccountManager.AccountType rights = AccountManager.GetRights();
            if (rights == AccountManager.AccountType.ADMIN)
            {
                editMenu.Visible = true;
                reportsMenu.Visible = false;
                reportsAdminMenu.Visible = true;
                reportsSellerMenu.Visible = false;
                accountManageMenu.Visible = true;
            }
            else if(rights == AccountManager.AccountType.USER)
            {
                editMenu.Visible = false;
                reportsMenu.Visible = false;
                reportsAdminMenu.Visible = false;
                reportsSellerMenu.Visible = true;
                accountManageMenu.Visible = false;
            }
        }

        #region Menu Response


        private void catalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCatalogForm newMDIChild = new ViewCatalogForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void viewTablesMenu_Click(object sender, EventArgs e)
        {
            ViewTablesForm newMDIChild = new ViewTablesForm();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void editTablesMenu_Click(object sender, EventArgs e)
        {
            EditTablesForm newMDIChild = new EditTablesForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void editConnectionsMenu_Click(object sender, EventArgs e)
        {
            EditConnectionsForm newMDIChild = new EditConnectionsForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void reportsMenu_Click(object sender, EventArgs e)
        {
            ReportsAdvancedForm newMDIChild = new ReportsAdvancedForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }   


        private void reportsAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsAdminForm newMDIChild = new ReportsAdminForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void reportsSellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsSellerForm newMDIChild = new ReportsSellerForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void helpAboutHappyTreeFriendsMenu_Click(object sender, EventArgs e)
        {
            HelpAboutForm newMDIChild = new HelpAboutForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void accountManageMenu_Click(object sender, EventArgs e)
        {
            AccountManagementForm form = new AccountManagementForm();
            form.MdiParent = this;
            form.Show();
        }
        private void accountLogoutMenu_Click(object sender, EventArgs e)
        {
            exitAppOnClose = false;
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitAppOnClose)
                Application.Exit();
            else
                loginForm.Show();
        }
    }
}
