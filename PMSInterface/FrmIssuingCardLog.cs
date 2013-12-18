using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PMSInterface
{
    public partial class FrmIssuingCardLog : Form
    {
        private SqlHelper sqlHelper = new SqlHelper();
        public FrmIssuingCardLog()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string roomNumber = this.txtRoomNumber.Text.Trim();
            string keyCoder = this.txtKeyCoder.Text.Trim();
            string from = string.Format("{0:yyyy-MM-dd}",this.dtpFrom.Value) + " 00:00:00";
            string to = string.Format("{0:yyyy-MM-dd}",this.dtpTo.Value) + " 23:59:59";
            string condition, condition1, condition2;
            string sql = "select * from IssueRec";
            if (!this.chkAll.Checked)
            {
                condition = " where OperateTime>=#" + from + "# and OperateTime<=#" + to + "#";
                if (roomNumber != string.Empty)
                {
                    condition1 = " and RoomNumber='" + roomNumber + "'";
                }
                else
                {
                    condition1 = string.Empty;
                }

                if (keyCoder != string.Empty)
                {
                    condition2 = " and KeyCoder='" + keyCoder + "'";
                }
                else
                {
                    condition2 = string.Empty;
                }

                condition = condition + condition1 + condition2;
                sql = sql + condition;                    
            }

            try
            {
                sqlHelper.CurrConn = Utils.DbType.Local;
                DataTable table = sqlHelper.ExecuteDataSet(sql, null, null).Tables[0];
                this.dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update grid data error: " + ex.Message,"hint",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            bool select = this.chkAll.Checked;
            switch (select)
            {
                case true:
                    setEnable(false);
                    break;
                case false:
                    setEnable(true);
                    break;
                default:
                    break;
            }
        }

        private void setEnable(bool val)
        {
            this.txtRoomNumber.Enabled = val;
            this.txtKeyCoder.Enabled = val;
            this.dtpFrom.Enabled = val;
            this.dtpTo.Enabled = val;
        }

        private void FrmIssuingCardLog_Load(object sender, EventArgs e)
        {
            this.dtpFrom.Value = DateTime.Now.Date.AddDays(-31);
            this.dtpTo.Value = DateTime.Now;
        }
    }
}
