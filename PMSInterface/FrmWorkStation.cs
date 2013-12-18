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
    public partial class FrmWorkStation : Form
    {
        private static FrmWorkStation _instance;

        private FrmWorkStation()
        {
            InitializeComponent();       
        }

        private void FrmWorkStation_Load(object sender, EventArgs e)
        {

        }

        public static FrmWorkStation getFrmWorkstation()
        {
            if (_instance == null)
            {
                _instance = new FrmWorkStation();
            }
            return _instance;
        }

        private void FrmWorkStation_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void FrmWorkStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!FrmMain.IsClose)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        delegate void AddCallback(Workstation workstation);
        public void add(Workstation workstation)
        {

            if (this.listViewWorkstation.InvokeRequired)
            {
                AddCallback d = new AddCallback(safeAdd);
                this.Invoke(d, new object[] { workstation });
            }
            else
            {
                safeAdd(workstation);
            }
        }

        public void safeAdd(Workstation workstation)
        {
            ListViewItem item = new ListViewItem("Connected", 0);
            item.SubItems.Add(workstation.KeyCoder);
            item.SubItems.Add(workstation.WorkstationName);
            item.SubItems.Add(DateTime.Now.ToString());
            this.listViewWorkstation.Items.Add(item);
        }

        delegate void DelCallback(string keycoder);
        public void SafeDel(string keycoder)
        {
            if (this.listViewWorkstation.InvokeRequired)
            {
                DelCallback d = new DelCallback(SafeDel);
                this.Invoke(d, new object[] { keycoder });
            }
            else
            {
                int pos = -1;
                for (int i = 0; i < this.listViewWorkstation.Items.Count; i++)
                {
                    for (int j = 0; j < this.listViewWorkstation.Items[i].SubItems.Count; j++)
                    {
                        if (this.listViewWorkstation.Items[i].SubItems[j].Text == keycoder)
                        {
                            pos = i;
                            break;
                        }
                    }

                    if (pos != -1)
                    {
                        break;
                    }
                }
                this.listViewWorkstation.Items[pos].Remove();
            }
        }
    }


}
