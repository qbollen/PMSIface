using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Utils;
namespace PMSInterface
{
    public partial class FrmRegister : Form
    {
        private SqlHelper sqlHelper = new SqlHelper();
        private Safe safe = new Safe();
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string msg = "If you have any questions,please contact us in the following ways:\r\n"
            + "TEL: +86-0755-83218909\r\n"
            + "Email: service@orbitatech.com\r\n"
            + "WebSite: www.orbitatech.com\r\n";
            MessageBox.Show(msg,"Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string regNo = this.txtRegNo.Text.Trim();
            if (regNo == "Registered")
            {
                Close();
                return;
            }
            try
            {              
                DateTime dateTime = safe.GetDateTimeFromDecrypt(false, regNo);
                if (dateTime < DateTime.Now)
                {
                    MessageBox.Show("Registe No invalid", "hint", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }

                string sql = "update Registe set RegisteNo='" + regNo + "'";
                sqlHelper.CurrConn = Utils.DbType.Local;
                sqlHelper.ExecuteNonQuery(sql, null);
                FrmMain.Registe = dateTime;
                FrmMain.Valid = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Update registe no error", "hint", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {         
            DateTime dateTime = safe.GetDateTimeFromDecrypt(true);
            if (dateTime >= DateTime.Now)
            {
                this.txtRegNo.Text = "Registered";
                this.txtRegNo.ForeColor = Color.Silver;
                this.txtRegNo.Font = new Font(this.txtRegNo.Font, this.txtRegNo.Font.Style | FontStyle.Italic);
            }
            else
            {
                this.txtRegNo.Text = "Invalid";
                setFont();
            }
        }

        private void setFont()
        {
            this.txtRegNo.ForeColor = Color.Black;
            this.txtRegNo.Font = new Font(this.txtRegNo.Font.FontFamily, this.txtRegNo.Font.Size,FontStyle.Regular);
        }

        private void txtRegNo_TextChanged(object sender, EventArgs e)
        {
            setFont();
        }
    }
}
