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
    public partial class FrmCommunicationLog : Form
    {
        private static FrmCommunicationLog _instance;
        private FrmCommunicationLog()
        {
            InitializeComponent();
        }

        public static FrmCommunicationLog getCommunicationLog()
        {
            if (_instance == null)
            {
                _instance = new FrmCommunicationLog();
            }
            return _instance;
        }

        private void FrmCommunicationLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!FrmMain.IsClose)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        delegate void AddCallBack(string content);
        public void safeAdd(string content)
        {
            if (this.txtLog.InvokeRequired)
            {
                AddCallBack d = new AddCallBack(safeAdd);
                this.Invoke(d, new object[] { content });
            }
            else
            {
                if (this.txtLog.Lines.Length > 100)
                {
                    this.txtLog.Clear();
                }
                this.txtLog.AppendText(content + "\r\n");
            }
        }

        private void FrmCommunicationLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtLog.Clear();
        }
    }
}
