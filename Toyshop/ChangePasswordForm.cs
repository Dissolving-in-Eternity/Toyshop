using System;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm(string login)
        {
            InitializeComponent();
            labLogin.Text = login;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txbPassword.Text == txbConfirmPass.Text)
            {
                AccountManager.SetNewPassword(labLogin.Text, txbPassword.Text.GetHashCode());
                Close();
            }
            else
                MessageBox.Show("Passwords should match", "Confirm password", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
