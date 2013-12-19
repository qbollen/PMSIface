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
    public partial class FrmUsers : Form
    {
        private SqlHelper sqlHelper = new SqlHelper();

        CmdFlag cmdFlag;

        public FrmUsers()
        {
            InitializeComponent();
            cmdFlag = CmdFlag.Null;
        }

        private void refreshGrid()
        {
            try
            {
                string sql = @"SELECT * FROM Account";
                DataTable table = sqlHelper.ExecuteDataSet(sql, null).Tables[0];
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void reset()
        {
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtRePassword.Text = string.Empty;
            this.txtOldPassword.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmdFlag = CmdFlag.Add;            
            EnableEdit(true);
            reset();
            EnableSave(true);
            this.plOld.Visible = false;
        }

        private void FrmWorkStation_Load(object sender, EventArgs e)
        {
            refreshGrid();
            getCurrentRowData();
            EnableEdit(false);
            EnableSave(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmdFlag = CmdFlag.Edit;           
            EnableEdit(true);
            EnableSave(true);
            this.txtUserName.ReadOnly = true;
        }


        private void btnDiscard_Click(object sender, EventArgs e)
        {
            cmdFlag = CmdFlag.Null;
            getCurrentRowData();
            EnableEdit(false);
            EnableSave(false);
           
        }

        private void getCurrentRowData()
        {
            DataGridViewRow dgrow;
            if ((dgrow = this.dataGridView1.CurrentRow) != null)
            {
                this.txtUserName.Text = dgrow.Cells["UserName"].Value.ToString();
                this.txtPassword.Text = string.Empty;
                this.txtRePassword.Text = string.Empty;
                this.txtOldPassword.Text = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text.Trim().ToUpper();
            string password = this.txtPassword.Text.Trim();
            string repassword = this.txtRePassword.Text.Trim();
            string oldPassword = this.txtOldPassword.Text.Trim();
            string sql = string.Empty;
            OleDbParameter[] parms = null;

            if (userName == string.Empty /*|| password == string.Empty || repassword == string.Empty*/)
            {
                MessageBox.Show("User name cannot be empty.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != repassword)
            {
                MessageBox.Show("The two passwords differ.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                password = UserManager.GetMd5Hash(password);
                switch (cmdFlag)
                {
                    case CmdFlag.Add:
                        sql = @"select UserName from Account where UserName=@UserName";
                        parms = new OleDbParameter[]
                    {
                        new OleDbParameter("@UserName",OleDbType.VarWChar)
                    };
                        parms[0].Value = userName;
                        if (sqlHelper.ExecuteScalar(sql, parms) != null)
                        {
                            MessageBox.Show("User name already exists.", "hint", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                        sql = "insert into Account ([UserName],[Password]) values (@UserName,@Password)";
                        parms = new OleDbParameter[]
                    {
                            new OleDbParameter("@UserName",OleDbType.VarWChar),
                            new OleDbParameter("@Password",OleDbType.VarWChar),
                    };
                        parms[0].Value = userName;
                        parms[1].Value = password;
                        // reset();
                        sqlHelper.ExecuteNonQuery(sql, parms);
                        break;
                    case CmdFlag.Edit:
                        sql = "select password from Account where UserName=@UserName";
                        parms = new OleDbParameter[]
                    {
                            new OleDbParameter("@UserName",OleDbType.VarWChar),
                    };
                        parms[0].Value = userName;

                        string hashPwd = sqlHelper.ExecuteScalar(sql, parms).ToString();

                        if (!UserManager.VerifyMd5Hash(oldPassword, hashPwd))
                        {
                            MessageBox.Show("Old password error.", "hint", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        sql = @"UPDATE Account SET [Password]=@Password " +
                            "WHERE UserName=@UserName";
                        parms = new OleDbParameter[]
                    {
                        new OleDbParameter("@Password",OleDbType.VarWChar),
                        new OleDbParameter("@UserName",OleDbType.VarWChar),
                    };
                        parms[0].Value = password;
                        parms[1].Value = userName;

                        sqlHelper.ExecuteNonQuery(sql, parms);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            refreshGrid();
            EnableEdit(false);
            EnableSave(false);            
            cmdFlag = CmdFlag.Null;
            MessageBox.Show("Data has been modified.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void EnableSave(bool bSave)
        {
            this.btnAdd.Enabled = !bSave;
            this.btnEdit.Visible = !bSave;
            this.btnDelete.Visible = !bSave;
            this.btnSave.Visible = bSave;
            this.btnDiscard.Visible = bSave;
            this.plOld.Visible = !this.btnEdit.Visible;
        }

        private void EnableEdit(bool bEdit)
        {   
            this.txtUserName.ReadOnly = !bEdit;
            this.txtPassword.ReadOnly = !bEdit;
            this.txtRePassword.ReadOnly = !bEdit;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            getCurrentRowData();
            string msg = "Are you sure to delete the selected record?";
            if(MessageBox.Show(msg,"hint",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            string userName = this.txtUserName.Text;
            string sql = @"DELETE FROM Account WHERE UserName=@UserName";
            OleDbParameter[] parms = new OleDbParameter[]
            {
                new OleDbParameter("@UserName",OleDbType.VarWChar)
            };
            parms[0].Value = userName;

            try
            {
                sqlHelper.ExecuteNonQuery(sql, parms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            refreshGrid();

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
              

            if (cmdFlag == CmdFlag.Null)
            {
                getCurrentRowData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }

    public enum CmdFlag
    {
        Null = 0,
        Add = 1,
        Edit = 2,
        Delete = 3,
        Save = 4,
        Discard = 5
    }

    
}
