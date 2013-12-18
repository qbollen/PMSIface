using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMSInterface
{
    public partial class FrmLock : Form
    {
        public FrmLock()
        {
            InitializeComponent();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (UserManager.VerifyMd5Hash(this.txtPwd.Text.Trim(),PMSInterface.Program._password))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("The password is incorrect.","hint",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.txtPwd.Text = string.Empty;
                this.txtPwd.Focus();
                return;
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnLock_Click(null, null);
            }
        }
    }
}
