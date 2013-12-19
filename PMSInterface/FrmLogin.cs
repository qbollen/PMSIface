using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PMSInterface
{
    public partial class FrmLogin : Form
    {
        private SqlHelper sqlHelper = new SqlHelper();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reset()
        {
            this.txtUserName.Text = string.Empty;
            this.txtPwd.Text = string.Empty;
            this.txtUserName.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text.Trim().ToUpper();
            string password = this.txtPwd.Text.Trim();

            //if (userName == string.Empty || password == string.Empty)
            //{
            //    MessageBox.Show("User name and password cannot be empty!");
            //    reset();
            //    return;
            //}

            //验证密码
            string sql = @"SELECT password FROM Account WHERE UserName=@UserName";

            OleDbParameter[] parms = new OleDbParameter[]
                                     {
                                         new OleDbParameter("@UserName",OleDbType.VarWChar)
                                     };
            parms[0].Value = userName;

            sqlHelper.CurrConn = Utils.DbType.Local;
            object result = sqlHelper.ExecuteScalar(sql, parms);
            if (result == null)
            {
                MessageBox.Show("User name or password error!");
                reset();
                return;
            }

            string hashPwd  = result.ToString();

            if (UserManager.VerifyMd5Hash(password,hashPwd))
            {
                PMSInterface.Program._username = userName;
                PMSInterface.Program._password = hashPwd;
                sql = "update Account set LoginTime=@LoginTime where UserName=@UserName";
                parms = new OleDbParameter[]
                {
                    new OleDbParameter("@LoginTime",OleDbType.VarWChar),
                    new OleDbParameter("@UserName",OleDbType.VarWChar)
                };
                parms[0].Value = DateTime.Now;
                parms[1].Value = userName;
                sqlHelper.ExecuteNonQuery(sql, parms);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("User name or password error!");
                reset();
                return;
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtPwd.Focus();
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnOk_Click(null, null);
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            textEffect((TextBox)sender, false, false);
        }

        private void textEffect(TextBox textBox, bool focus, bool IsPwd)
        {
            string content = string.Empty;
            if (IsPwd)
            {
                content = "please enter password.";
            }
            else
            {
                content = "please enter user name.";
            }

            if (textBox.Text != string.Empty && textBox.Text != content)
            {
               return;
            }

            if (focus)
            {
                if (IsPwd)
                {
                    textBox.PasswordChar = '*';
                }

                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
            }
            else
            {
                if (IsPwd)
                {
                    textBox.PasswordChar = '\0';
                }
                textBox.Text = content;
                textBox.ForeColor = Color.Silver;
            }

        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            textEffect((TextBox)sender, true, false);
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            textEffect((TextBox)sender, true, true);
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            textEffect((TextBox)sender, false, true);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            textEffect(this.txtUserName, false, false);
            textEffect(this.txtPwd, false, true);
        }


    }
}
