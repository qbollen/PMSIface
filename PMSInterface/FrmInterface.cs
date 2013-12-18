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
    public partial class FrmInterface : Form
    {
        SqlHelper sqlHelper = new SqlHelper();
        private string checkOutType;

        public FrmInterface()
        {
            InitializeComponent();
            checkOutType = string.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string ip = this.txtIP.Text.Trim();
            string ifport = this.txtIfPort.Text.Trim();
            string keyport = this.txtKeyPort.Text.Trim();
            string lCheckOutType = checkOutType;
            string checkOutTime = this.dtpCustomize.Text;
            bool autoConnect = this.chkAutoConnect.Checked;
            decimal connectTime = this.nudAutoContent.Value;

            if (ip == string.Empty || ifport == string.Empty || keyport == string.Empty
                || checkOutType == string.Empty)
            {
                MessageBox.Show("Key content cannot be empty.","hint",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = string.Empty;
                sql = @"SELECT * FROM Interface";

                int cnt = sqlHelper.ExecuteDataSet(sql, null).Tables[0].Rows.Count;
                OleDbParameter[] parms = null;
                if (cnt == 0)
                {
                    sql = @"INSERT INTO Interface (IP,ifPort,keyPort,CheckOutType,CheckOutTime,AutoConnect,ConnectTime)" +
                        " VALUES (@IP,@ifPort,@keyPort,@CheckOutType,@CheckOutTime,@AutoConnect,@ConnectTime)";
                }
                else
                {
                    sql = @"UPDATE Interface SET IP=@IP,ifPort=@ifPort,keyPort=@keyPort," +
                        "CheckOutType=@CheckOutType,CheckOutTime=@CheckOutTime,AutoConnect=@AutoConnect,ConnectTime=@ConnectTime";
                }

                parms = new OleDbParameter[]
                {
                    new OleDbParameter("@IP",OleDbType.VarWChar),
                    new OleDbParameter("@ifPort",OleDbType.VarWChar),
                    new OleDbParameter("@keyPort",OleDbType.VarWChar),
                    new OleDbParameter("@CheckOutType",OleDbType.VarWChar),
                    new OleDbParameter("@CheckOutTime",OleDbType.VarWChar),
                    new OleDbParameter("@AutoConnect",OleDbType.Boolean),
                    new OleDbParameter("@ConnectTime",OleDbType.Decimal)
                };

                parms[0].Value = ip;
                parms[1].Value = ifport;
                parms[2].Value = keyport;
                parms[3].Value = lCheckOutType;
                parms[4].Value = checkOutTime;
                parms[5].Value = autoConnect;
                parms[6].Value = connectTime;

                sqlHelper.ExecuteNonQuery(sql, parms);

                FrmMain.CheckOutType = lCheckOutType;
                FrmMain.CheckOutTime = checkOutTime;
                FrmMain.IsAutoConn = autoConnect;
                FrmMain.AutoConnTime = connectTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Data has been modified.","hint",MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (FrmMain.CurrConnSta == ConnSta.NoPort)
            {
                FrmMain.CurrConnSta = ConnSta.Ready;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInterface_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Interface";
            DataSet ds = sqlHelper.ExecuteDataSet(sql, null);
            DataTable table = ds.Tables[0];
            if (table.Rows.Count > 0)
            {
                this.txtIP.Text = table.Rows[0]["IP"].ToString();
                this.txtIfPort.Text = table.Rows[0]["IfPort"].ToString();
                this.txtKeyPort.Text = table.Rows[0]["keyPort"].ToString();
                string checkOutType = table.Rows[0]["CheckOutType"].ToString();
                string checkOutTime = table.Rows[0]["CheckOutTime"].ToString();
                switch (checkOutType)
                {
                    case "24":
                        this.rb24.Checked = true;
                        break;
                    case "interface":
                        this.rbInterface.Checked = true;
                        break;
                    default:
                        this.rbCustomize.Checked = true;
                        break;
                }
                this.dtpCustomize.Text = checkOutTime == string.Empty ? "12:00" : checkOutTime;
                this.chkAutoConnect.Checked = Convert.ToBoolean(table.Rows[0]["AutoConnect"]);
                this.nudAutoContent.Value = Convert.ToDecimal(table.Rows[0]["ConnectTime"]);

            }
        }

        private void rb24_CheckedChanged(object sender, EventArgs e)
        {
            setCheckOutTimeType((RadioButton)sender);
        }

        private void setCheckOutTimeType(RadioButton rb)
        {
            switch (rb.Name)
            {
                case "rb24":
                    checkOutType = "24";
                    dtpCustomize.Enabled = false;
                    break;
                case "rbCustomize":
                    checkOutType = "customize";
                    dtpCustomize.Enabled = true;
                    break;
                case "rbInterface":
                    checkOutType = "interface";
                    dtpCustomize.Enabled = false;
                    break;
            }
        }

        private void chkAutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoConnect.Checked)
            {
                this.nudAutoContent.Enabled = true;
            }
            else
            {
                this.nudAutoContent.Enabled = false;
            }
        }

    }
}
