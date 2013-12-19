using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PMSInterface
{
    public partial class FrmRoomConfigure : Form
    {
        Params myParam = new Params();
        SqlHelper sqlHelper = new SqlHelper();
        private bool isVerify = true;
        public FrmRoomConfigure()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string fileName = this.txtDatabasePath.Text.Trim();
            if (fileName == string.Empty)
            {
                MessageBox.Show("Path cannot be empty", "hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (File.Exists(fileName))
                {
                    isVerify = true;
                    myParam.Db_Room = fileName;
                }
                else
                {
                    isVerify = false;
                    MessageBox.Show("Verify failure.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"hint",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Verify OK!","hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.txtDatabasePath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Pls verify database path.", "hint", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!isVerify)
            {
                MessageBox.Show("Verification is not successful", "hint", MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
                return;
            }

            LoadData();
        }

        private void FrmRoomConfigure_Load(object sender, EventArgs e)
        {
            this.txtDatabasePath.Text = myParam.Db_Room;
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            string buildingName = this.cmbBuilding.Text;
            string floorName = this.cmbFloor.Text;
            string sql;
            try
            {
                if (buildingName == string.Empty && floorName == string.Empty)
                {
                    this.cmbBuilding.Items.Clear();
                    this.cmbFloor.Items.Clear();

                    sqlHelper.CurrConn = Utils.DbType.Remote;
                    sql = "select building_name,floor_name from room";
                    EnumerableRowCollection<DataRow> rows = sqlHelper.ExecuteDataSet(sql, null, null).Tables[0].AsEnumerable();
                    (from v in rows
                     group v by v.Field<string>("building_name") into g
                     select g.Key).ToList().ForEach(building => this.cmbBuilding.Items.Add(building));

                    (from v in rows
                     group v by v.Field<string>("floor_name") into g
                     select g.Key).ToList().ForEach(floor => this.cmbFloor.Items.Add(floor));

                    sql = "select * from room";
                }
                else
                {
                    string condition = " where ";
                    string condition1 = string.Empty;
                    string condition2 = string.Empty;
                    if (buildingName != string.Empty)
                    {
                        condition1 = "building_name='" + buildingName + "'";                       
                        
                    }
                    else
                    {
                        condition1 = string.Empty;
                    }

                    if (floorName != string.Empty)
                    {
                        condition2 = (condition1 != string.Empty ? " and " : "") + "floor_name='" + floorName + "'";
                    }
                    else
                    {
                        condition2 = string.Empty;
                    }

                    condition = condition + condition1 + condition2;

                    sql = "select * from room" + condition;

                }

                DataTable table = sqlHelper.ExecuteDataSet(sql, null, null).Tables[0];
                this.dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load data error: " + ex.Message, "hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
