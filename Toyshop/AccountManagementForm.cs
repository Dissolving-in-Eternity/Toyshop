using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class AccountManagementForm : Form
    {
        public AccountManagementForm()
        {
            InitializeComponent();
        }

        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
            ReloadUsers();
        }

        public void ReloadUsers()
        {
            List<string> users = AccountManager.GetRegisteredActiveUsers();
            tablePanel.Controls.Clear();
            tablePanel.RowCount = users.Count + 1;
            this.Height = 110 + users.Count * 20;   //Magic

            for (int i = 0; i < users.Count; i++)
            {
                Label lab = new Label();
                lab.Text = users[i];
                lab.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                lab.Margin = new Padding(0);
                tablePanel.Controls.Add(lab);

                Button btn = new Button();
                btn.Text = "Set password";
                btn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                btn.Margin = new Padding(0);
                btn.Click += SetPass_Click;
                tablePanel.Controls.Add(btn);

                btn = new Button();
                btn.Text = "Delete user";
                btn.Anchor = AnchorStyles.None;
                btn.Margin = new Padding(0);
                btn.Click += DeleteUser_Click; ;
                tablePanel.Controls.Add(btn);
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            var position = tablePanel.GetPositionFromControl(sender as Button);
            string login = (tablePanel.GetControlFromPosition(0, position.Row) as Label).Text;
            if (MessageBox.Show($"Delete user \"{login}\"?", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (AccountManager.DeleteAccount(login))
                    ReloadUsers();
                else
                    MessageBox.Show("You can not delete current user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetPass_Click(object sender, EventArgs e)
        {
            var position = tablePanel.GetPositionFromControl(sender as Button);
            string login = (tablePanel.GetControlFromPosition(0, position.Row) as Label).Text;
            ChangePasswordForm form = new ChangePasswordForm(login);
            form.ShowDialog(this);
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            RegisterUserForm form = new RegisterUserForm(this);
            form.ShowDialog(this);
        }
    }
}
