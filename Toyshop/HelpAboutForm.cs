using System;
using System.Windows.Forms;

namespace Toyshop
{
    public partial class HelpAboutForm : Form
    {
        public HelpAboutForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
