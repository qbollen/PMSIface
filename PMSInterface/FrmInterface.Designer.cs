namespace PMSInterface
{
    partial class FrmInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInterface));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIfPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtKeyPort = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpCustomize = new System.Windows.Forms.DateTimePicker();
            this.rbInterface = new System.Windows.Forms.RadioButton();
            this.rbCustomize = new System.Windows.Forms.RadioButton();
            this.rb24 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudAutoContent = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.chkAutoConnect = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoContent)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIfPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Location = new System.Drawing.Point(26, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PMS Interface";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Please enter Interface Port .\r\n(e.g. 5009)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Please enter Interface IP .\r\n(e.g. 192.168.1.8)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address:";
            // 
            // txtIfPort
            // 
            this.txtIfPort.Location = new System.Drawing.Point(92, 149);
            this.txtIfPort.Name = "txtIfPort";
            this.txtIfPort.Size = new System.Drawing.Size(153, 20);
            this.txtIfPort.TabIndex = 1;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(92, 69);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(153, 20);
            this.txtIP.TabIndex = 0;
            // 
            // txtKeyPort
            // 
            this.txtKeyPort.Location = new System.Drawing.Point(92, 77);
            this.txtKeyPort.Name = "txtKeyPort";
            this.txtKeyPort.Size = new System.Drawing.Size(153, 20);
            this.txtKeyPort.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtKeyPort);
            this.groupBox2.Location = new System.Drawing.Point(26, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 126);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key Service";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "Please enter ORBITA key service port.\r\n(e.g. 6008)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port:";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(419, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(531, 402);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpCustomize);
            this.groupBox3.Controls.Add(this.rbInterface);
            this.groupBox3.Controls.Add(this.rbCustomize);
            this.groupBox3.Controls.Add(this.rb24);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(340, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 194);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Check-Out Time";
            // 
            // dtpCustomize
            // 
            this.dtpCustomize.CustomFormat = "HH:mm:ss";
            this.dtpCustomize.Enabled = false;
            this.dtpCustomize.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCustomize.Location = new System.Drawing.Point(120, 112);
            this.dtpCustomize.Name = "dtpCustomize";
            this.dtpCustomize.ShowUpDown = true;
            this.dtpCustomize.Size = new System.Drawing.Size(100, 20);
            this.dtpCustomize.TabIndex = 2;
            this.dtpCustomize.Value = new System.DateTime(2013, 4, 2, 10, 48, 27, 0);
            // 
            // rbInterface
            // 
            this.rbInterface.AutoSize = true;
            this.rbInterface.Location = new System.Drawing.Point(35, 135);
            this.rbInterface.Name = "rbInterface";
            this.rbInterface.Size = new System.Drawing.Size(74, 17);
            this.rbInterface.TabIndex = 1;
            this.rbInterface.TabStop = true;
            this.rbInterface.Text = "From PMS";
            this.rbInterface.UseVisualStyleBackColor = true;
            this.rbInterface.CheckedChanged += new System.EventHandler(this.rb24_CheckedChanged);
            // 
            // rbCustomize
            // 
            this.rbCustomize.AutoSize = true;
            this.rbCustomize.Location = new System.Drawing.Point(35, 112);
            this.rbCustomize.Name = "rbCustomize";
            this.rbCustomize.Size = new System.Drawing.Size(73, 17);
            this.rbCustomize.TabIndex = 1;
            this.rbCustomize.TabStop = true;
            this.rbCustomize.Text = "Customize";
            this.rbCustomize.UseVisualStyleBackColor = true;
            this.rbCustomize.CheckedChanged += new System.EventHandler(this.rb24_CheckedChanged);
            // 
            // rb24
            // 
            this.rb24.AutoSize = true;
            this.rb24.Location = new System.Drawing.Point(35, 89);
            this.rb24.Name = "rb24";
            this.rb24.Size = new System.Drawing.Size(63, 17);
            this.rb24.TabIndex = 1;
            this.rb24.TabStop = true;
            this.rb24.Text = "24 Hour";
            this.rb24.UseVisualStyleBackColor = true;
            this.rb24.CheckedChanged += new System.EventHandler(this.rb24_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 39);
            this.label7.TabIndex = 0;
            this.label7.Text = "Please enter the default check-out time .Guest card\r\nexpires after this time on t" +
    "he check-out day.\r\n(e.g. 12:00)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudAutoContent);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.chkAutoConnect);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(340, 249);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(287, 126);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // nudAutoContent
            // 
            this.nudAutoContent.Enabled = false;
            this.nudAutoContent.Location = new System.Drawing.Point(35, 74);
            this.nudAutoContent.Name = "nudAutoContent";
            this.nudAutoContent.Size = new System.Drawing.Size(102, 20);
            this.nudAutoContent.TabIndex = 8;
            this.nudAutoContent.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "(S)";
            // 
            // chkAutoConnect
            // 
            this.chkAutoConnect.AutoSize = true;
            this.chkAutoConnect.Location = new System.Drawing.Point(12, -1);
            this.chkAutoConnect.Name = "chkAutoConnect";
            this.chkAutoConnect.Size = new System.Drawing.Size(91, 17);
            this.chkAutoConnect.TabIndex = 0;
            this.chkAutoConnect.Text = "Auto Connect";
            this.chkAutoConnect.UseVisualStyleBackColor = true;
            this.chkAutoConnect.CheckedChanged += new System.EventHandler(this.chkAutoConnect_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Time of try connecting to the pms server.";
            // 
            // FrmInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 458);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface";
            this.Load += new System.EventHandler(this.FrmInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIfPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtKeyPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbInterface;
        private System.Windows.Forms.RadioButton rbCustomize;
        private System.Windows.Forms.RadioButton rb24;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkAutoConnect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudAutoContent;
        private System.Windows.Forms.DateTimePicker dtpCustomize;
    }
}