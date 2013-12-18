namespace PMSInterface
{
    partial class FrmWorkStation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkStation));
            this.listViewWorkstation = new System.Windows.Forms.ListView();
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KeyCoder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Workstation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewWorkstation
            // 
            this.listViewWorkstation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Status,
            this.KeyCoder,
            this.Workstation,
            this.Time});
            this.listViewWorkstation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewWorkstation.Location = new System.Drawing.Point(0, 0);
            this.listViewWorkstation.Name = "listViewWorkstation";
            this.listViewWorkstation.Size = new System.Drawing.Size(770, 508);
            this.listViewWorkstation.SmallImageList = this.imageList1;
            this.listViewWorkstation.TabIndex = 0;
            this.listViewWorkstation.UseCompatibleStateImageBehavior = false;
            this.listViewWorkstation.View = System.Windows.Forms.View.Details;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 100;
            // 
            // KeyCoder
            // 
            this.KeyCoder.Text = "Key Coder";
            this.KeyCoder.Width = 150;
            // 
            // Workstation
            // 
            this.Workstation.Text = "Workstation";
            this.Workstation.Width = 300;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Go.png");
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 200;
            // 
            // FrmWorkStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 508);
            this.Controls.Add(this.listViewWorkstation);
            this.Name = "FrmWorkStation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conntected Workstation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorkStation_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmWorkStation_FormClosed);
            this.Load += new System.EventHandler(this.FrmWorkStation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader KeyCoder;
        private System.Windows.Forms.ColumnHeader Workstation;
        private System.Windows.Forms.ColumnHeader Status;
        public System.Windows.Forms.ListView listViewWorkstation;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader Time;

    }
}