using System;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class RegisterUserForm : Form
    {
        AccountManagementForm accountForm;

        public RegisterUserForm(AccountManagementForm form)
        {
            InitializeComponent();
            accountForm = form;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(txbPassword.Text == txbConfirmPass.Text)
            {
                if (!AccountManager.CreateNewAccount(txbLogin.Text, txbPassword.Text.GetHashCode(), adminRights.Checked))
                    MessageBox.Show("User name already taken.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    accountForm.ReloadUsers();
                    Close();
                }
            }
        }
    }
}
