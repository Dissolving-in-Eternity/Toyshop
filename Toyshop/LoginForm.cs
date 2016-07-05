using System;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (AccountManager.Login(cmbLogin.Text, txbPassword.Text.GetHashCode()))
            {
                MainForm mainForm = new MainForm(this);
                mainForm.InitializeMenuWithAccountRights();
                mainForm.Show();
                Hide();
            }
            else
            {
                txbPassword.Text = string.Empty;
                txbPassword.Focus();
                MessageBox.Show("Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            cmbLogin.Items.Clear();
            cmbLogin.Items.AddRange(AccountManager.GetRegisteredActiveUsers().ToArray());
            cmbLogin.SelectedIndex = 0;
            txbPassword.Select();
        }

        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            LoadUsers();
            txbPassword.Text = string.Empty;
        }

        private void cmbLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbPassword.Text = string.Empty;
            txbPassword.Focus();
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(btnLogin, new EventArgs());
        }
    }
}
