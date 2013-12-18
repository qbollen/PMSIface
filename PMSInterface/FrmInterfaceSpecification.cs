using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PMSInterface
{
    public partial class FrmInterfaceSpecification : Form
    {
        private string currSpec;
        SqlHelper sqlHelper = new SqlHelper();
        public FrmInterfaceSpecification()
        {
            InitializeComponent();
        }

        #region 自定义方法
        private Dictionary<string, string> GetContent()
        {
            string prefix = this.txtPR.Text.Trim().ToUpper();
            string kr = this.txtKR.Text.Trim().ToUpper();
            if (kr == string.Empty)
                return null;
            string kg = this.txtKG.Text.Trim().ToUpper();
            if (kg == string.Empty)
                return null;
            string kd = this.txtKD.Text.Trim().ToUpper();
            if (kd == string.Empty)
                return null;
            string ws = this.txtWS.Text.Trim().ToUpper();
            string kc = this.txtKC.Text.Trim().ToUpper();
            if (kc == string.Empty)
                return null;
            string rn = this.txtRN.Text.Trim().ToUpper();
            if (rn == string.Empty)
                return null;
            string cd = this.txtCD.Text.Trim().ToUpper();
            string nk = this.txtNK.Text.Trim().ToUpper();
            string dk = this.txtDK.Text.Trim().ToUpper();
            string kt = this.txtKT.Text.Trim().ToUpper();
            string gn = this.txtGN.Text.Trim().ToUpper();
            string ad = this.txtAD.Text.Trim().ToUpper();
            if (ad == string.Empty)
                return null;
            string dd = this.txtDD.Text.Trim().ToUpper();
            if (dd == string.Empty)
                return null;
            string ct = this.txtCT.Text.Trim().ToUpper();
            string sql = "select CheckOutType from Interface";
            sqlHelper.CurrConn = Utils.DbType.Local;
            string checkOutType = sqlHelper.ExecuteScalar(sql, null).ToString();
            if (checkOutType == "interface" && ct == string.Empty)
                return null;
            string suffix = this.txtSU.Text.Trim().ToUpper();
            string separator = this.txtSeparator.Text.Trim().ToUpper();
            if (separator == string.Empty)
                return null;
            string date = this.txtDate.Text.Trim();
            if (date == string.Empty)
                return null;
            string time = this.txtTime.Text.Trim();
            if (time == string.Empty)
                return null;
            string success = this.txtSuccess.Text.Trim().ToUpper();
            string failure = this.txtFailure.Text.Trim().ToUpper();
            string fileName = this.txtFileName.Text.Trim().ToUpper();
            if (fileName == string.Empty)
                return null;

            Dictionary<string, string> content = new Dictionary<string, string>();
            content.Add("PR",prefix);
            content.Add("KR",kr);
            content.Add("KG",kg);
            content.Add("KD",kd);
            content.Add("WS",ws);
            content.Add("KC",kc);
            content.Add("RN",rn);
            content.Add("CD",cd);
            content.Add("NK",nk);
            content.Add("DK",dk);
            content.Add("KT",kt);
            content.Add("GN",gn);
            content.Add("AD",ad);
            content.Add("DD",dd);
            content.Add("CT",ct);
            content.Add("SU",suffix);
            content.Add("Separator",separator);
            content.Add("Date",date);
            content.Add("Time",time);
            content.Add("Success",success);
            content.Add("Failure",failure);
            content.Add("FileName",fileName);

            return content;
        }

        private IList<string> LoadSpec()
        {
            IList<string> list = new List<string>();
            try
            {
                string[] files = Directory.GetFiles("Spec");
                foreach (string fileName in files)
                {
                    list.Add(Path.GetFileNameWithoutExtension(fileName));
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            return list;
        }

        private void SetAvailableSpec()
        {
            IList<string> files = LoadSpec();
            if (files == null)
                return;
            this.cmbAvaSpec.Items.Clear();
            foreach (string file in files)
            {
                this.cmbAvaSpec.Items.Add(file);
            }
        }

        private void SetEditable(bool edit)
        {
            (from v in this.groupMap.Controls.OfType<TextBox>()
             select v).ToList().ForEach(textBox => textBox.ReadOnly = !edit);
            this.btnSave.Visible = edit;
            this.btnReset.Visible = edit;
            this.btnNew.Enabled = !edit;
            this.btnEdit.Visible = !edit;
            this.btnDel.Visible = !edit;
        }

        private void Reset()
        {
            (from v in this.groupMap.Controls.OfType<TextBox>()
             select v).ToList().ForEach(textBox => textBox.Text = "");
        }

        private bool LoadContent(bool isMap = false)
        {
            string specName;
            Dictionary<string, string> content = MyXml.GetInstructMap(out specName);
            if (specName == null)
            {
                return false;
            }

            currSpec = specName;
            this.cmbAvaSpec.Text = specName;
            this.lblCurrSpec.Text ="[ " + specName + " ]";
        
            if (content == null)
            {
                MessageBox.Show("Xml transform error.","hint",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            if (isMap)
            {
                FrmMain.InstructMap = content;
            }
            foreach (string key in content.Keys)
            {
                (from v in this.groupMap.Controls.OfType<TextBox>()
                 where v.Name.EndsWith(key)
                 select v).Single(textBox => { 
                     if (textBox == null) return false; 
                     textBox.Text = content[key]; 
                     return true; 
                 });                                                
            }
            this.txtFileName.Text = specName;

            return true;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> content = GetContent();
            if (content == null)
            {
                MessageBox.Show("Key content cannot empty.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                MyXml.NewMap(content["FileName"] + ".xml",content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Error: " + ex.Message, "hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Save Success.","hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetEditable(false);

            SetAvailableSpec();
            LoadContent();
        }

        private void FrmInterfaceSpecification_Load(object sender, EventArgs e)
        {
            string path = "Spec/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            SetEditable(false);
            SetAvailableSpec();
            if (!LoadContent())
                return;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetEditable(true);
            Reset();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string spec = this.cmbAvaSpec.Text;
            if (spec == string.Empty)
                return;
            MyXml.SetSpec(spec);
            SetEditable(false);
            if (!LoadContent(true))
                return;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditable(true);
            this.txtFileName.ReadOnly = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string spec = this.cmbAvaSpec.Text;
            if (spec == string.Empty)
                return;

            if (spec == currSpec)
            {
                MessageBox.Show("Can't delete the current specification","hint",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure delete? [" + spec + "]", "hint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
                File.Delete("Spec/" + this.cmbAvaSpec.Text + ".xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error. " + ex.Message,"hint",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Delete success.","hint",MessageBoxButtons.OK,MessageBoxIcon.Information);
            SetAvailableSpec();
            LoadContent();
        }

    }
}
