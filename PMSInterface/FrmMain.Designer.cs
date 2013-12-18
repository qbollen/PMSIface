namespace PMSInterface
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSetup = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemUserManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.interfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomConfigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonLog = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemWs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.issuingCardLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRegister = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectSta = new System.Windows.Forms.Panel();
            this.lblRequest = new System.Windows.Forms.Label();
            this.lblListen = new System.Windows.Forms.Label();
            this.btnConnToPMS = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.transAreaA = new System.Windows.Forms.Panel();
            this.transRightA = new System.Windows.Forms.PictureBox();
            this.transLeftA = new System.Windows.Forms.PictureBox();
            this.transAreaB = new System.Windows.Forms.Panel();
            this.transRightB = new System.Windows.Forms.PictureBox();
            this.transLeftB = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerListen = new System.Windows.Forms.Timer(this.components);
            this.timerConnectClient = new System.Windows.Forms.Timer(this.components);
            this.timerConnectInterface = new System.Windows.Forms.Timer(this.components);
            this.timerAutoConnect = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.connectSta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.transAreaA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transRightA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transLeftA)).BeginInit();
            this.transAreaB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transRightB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transLeftB)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSetup,
            this.toolStripButtonLog,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButtonRegister,
            this.toolStripButtonAbout,
            this.toolStripSeparator2,
            this.toolStripButtonExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(921, 54);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSetup
            // 
            this.toolStripButtonSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUserManager,
            this.toolStripSeparator4,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.interfaceToolStripMenuItem,
            this.roomConfigureToolStripMenuItem});
            this.toolStripButtonSetup.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSetup.Image")));
            this.toolStripButtonSetup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetup.Name = "toolStripButtonSetup";
            this.toolStripButtonSetup.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolStripButtonSetup.Size = new System.Drawing.Size(70, 51);
            this.toolStripButtonSetup.Text = "Setup";
            this.toolStripButtonSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSetup.Click += new System.EventHandler(this.toolStripButtonSetup_Click);
            // 
            // toolStripMenuItemUserManager
            // 
            this.toolStripMenuItemUserManager.Name = "toolStripMenuItemUserManager";
            this.toolStripMenuItemUserManager.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItemUserManager.Text = "User Manager";
            this.toolStripMenuItemUserManager.Click += new System.EventHandler(this.toolStripMenuItemUserManager_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItem1.Text = "Interface Specification";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // interfaceToolStripMenuItem
            // 
            this.interfaceToolStripMenuItem.Name = "interfaceToolStripMenuItem";
            this.interfaceToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.interfaceToolStripMenuItem.Text = "Interface";
            this.interfaceToolStripMenuItem.Click += new System.EventHandler(this.interfaceToolStripMenuItem_Click);
            // 
            // roomConfigureToolStripMenuItem
            // 
            this.roomConfigureToolStripMenuItem.Name = "roomConfigureToolStripMenuItem";
            this.roomConfigureToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.roomConfigureToolStripMenuItem.Text = "Room Configure";
            this.roomConfigureToolStripMenuItem.Click += new System.EventHandler(this.roomConfigureToolStripMenuItem_Click);
            // 
            // toolStripButtonLog
            // 
            this.toolStripButtonLog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemWs,
            this.toolStripSeparator5,
            this.issuingCardLogToolStripMenuItem});
            this.toolStripButtonLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLog.Image")));
            this.toolStripButtonLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLog.Name = "toolStripButtonLog";
            this.toolStripButtonLog.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolStripButtonLog.Size = new System.Drawing.Size(65, 51);
            this.toolStripButtonLog.Text = "View";
            this.toolStripButtonLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItemWs
            // 
            this.toolStripMenuItemWs.Name = "toolStripMenuItemWs";
            this.toolStripMenuItemWs.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItemWs.Text = "Workstation";
            this.toolStripMenuItemWs.Click += new System.EventHandler(this.toolStripMenuItemWs_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(154, 6);
            // 
            // issuingCardLogToolStripMenuItem
            // 
            this.issuingCardLogToolStripMenuItem.Name = "issuingCardLogToolStripMenuItem";
            this.issuingCardLogToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.issuingCardLogToolStripMenuItem.Text = "Issuing card log";
            this.issuingCardLogToolStripMenuItem.Click += new System.EventHandler(this.issuingCardLogToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolStripButton2.Size = new System.Drawing.Size(56, 51);
            this.toolStripButton2.Text = "Lock";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripButtonRegister
            // 
            this.toolStripButtonRegister.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRegister.Image")));
            this.toolStripButtonRegister.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRegister.Name = "toolStripButtonRegister";
            this.toolStripButtonRegister.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolStripButtonRegister.Size = new System.Drawing.Size(73, 51);
            this.toolStripButtonRegister.Text = "Register";
            this.toolStripButtonRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonRegister.Click += new System.EventHandler(this.toolStripButtonRegister_Click);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
            this.toolStripButtonAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolStripButtonAbout.Size = new System.Drawing.Size(64, 51);
            this.toolStripButtonAbout.Text = "About";
            this.toolStripButtonAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExit.Image")));
            this.toolStripButtonExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.toolStripButtonExit.Size = new System.Drawing.Size(56, 51);
            this.toolStripButtonExit.Text = "Exit";
            this.toolStripButtonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(921, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.AutoSize = false;
            this.toolStripStatusLabelUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabelUser.Image")));
            this.toolStripStatusLabelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(200, 25);
            // 
            // connectSta
            // 
            this.connectSta.BackColor = System.Drawing.Color.Transparent;
            this.connectSta.Controls.Add(this.lblRequest);
            this.connectSta.Controls.Add(this.btnConnToPMS);
            this.connectSta.Controls.Add(this.label3);
            this.connectSta.Controls.Add(this.label2);
            this.connectSta.Controls.Add(this.label1);
            this.connectSta.Controls.Add(this.pictureBox4);
            this.connectSta.Controls.Add(this.pictureBox2);
            this.connectSta.Controls.Add(this.pictureBox1);
            this.connectSta.Controls.Add(this.transAreaA);
            this.connectSta.Controls.Add(this.lblListen);
            this.connectSta.Controls.Add(this.transAreaB);
            this.connectSta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connectSta.Location = new System.Drawing.Point(54, 89);
            this.connectSta.Name = "connectSta";
            this.connectSta.Size = new System.Drawing.Size(820, 290);
            this.connectSta.TabIndex = 2;
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.BackColor = System.Drawing.Color.Transparent;
            this.lblRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRequest.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblRequest.Location = new System.Drawing.Point(208, 78);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(67, 20);
            this.lblRequest.TabIndex = 34;
            this.lblRequest.Text = "Pending";
            // 
            // lblListen
            // 
            this.lblListen.AutoSize = true;
            this.lblListen.BackColor = System.Drawing.Color.Transparent;
            this.lblListen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblListen.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblListen.Location = new System.Drawing.Point(505, 78);
            this.lblListen.Name = "lblListen";
            this.lblListen.Size = new System.Drawing.Size(79, 20);
            this.lblListen.TabIndex = 32;
            this.lblListen.Text = "listening...";
            this.lblListen.Visible = false;
            // 
            // btnConnToPMS
            // 
            this.btnConnToPMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnToPMS.Location = new System.Drawing.Point(336, 200);
            this.btnConnToPMS.Name = "btnConnToPMS";
            this.btnConnToPMS.Size = new System.Drawing.Size(140, 69);
            this.btnConnToPMS.TabIndex = 31;
            this.btnConnToPMS.Text = "Connect";
            this.btnConnToPMS.UseVisualStyleBackColor = true;
            this.btnConnToPMS.Click += new System.EventHandler(this.btnConnToPMS_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(670, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Workstation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(352, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "ORBITA Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "PMS Server";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(346, 29);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(129, 129);
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(672, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(129, 129);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 129);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // transAreaA
            // 
            this.transAreaA.BackColor = System.Drawing.Color.Transparent;
            this.transAreaA.Controls.Add(this.transRightA);
            this.transAreaA.Controls.Add(this.transLeftA);
            this.transAreaA.Location = new System.Drawing.Point(149, 39);
            this.transAreaA.Name = "transAreaA";
            this.transAreaA.Size = new System.Drawing.Size(183, 100);
            this.transAreaA.TabIndex = 26;
            this.transAreaA.Visible = false;
            // 
            // transRightA
            // 
            this.transRightA.Image = ((System.Drawing.Image)(resources.GetObject("transRightA.Image")));
            this.transRightA.Location = new System.Drawing.Point(77, 34);
            this.transRightA.Name = "transRightA";
            this.transRightA.Size = new System.Drawing.Size(32, 32);
            this.transRightA.TabIndex = 1;
            this.transRightA.TabStop = false;
            // 
            // transLeftA
            // 
            this.transLeftA.Image = ((System.Drawing.Image)(resources.GetObject("transLeftA.Image")));
            this.transLeftA.Location = new System.Drawing.Point(77, 34);
            this.transLeftA.Name = "transLeftA";
            this.transLeftA.Size = new System.Drawing.Size(32, 32);
            this.transLeftA.TabIndex = 0;
            this.transLeftA.TabStop = false;
            // 
            // transAreaB
            // 
            this.transAreaB.BackColor = System.Drawing.Color.Transparent;
            this.transAreaB.Controls.Add(this.transRightB);
            this.transAreaB.Controls.Add(this.transLeftB);
            this.transAreaB.Location = new System.Drawing.Point(475, 39);
            this.transAreaB.Name = "transAreaB";
            this.transAreaB.Size = new System.Drawing.Size(183, 100);
            this.transAreaB.TabIndex = 33;
            this.transAreaB.Visible = false;
            // 
            // transRightB
            // 
            this.transRightB.Image = ((System.Drawing.Image)(resources.GetObject("transRightB.Image")));
            this.transRightB.Location = new System.Drawing.Point(77, 34);
            this.transRightB.Name = "transRightB";
            this.transRightB.Size = new System.Drawing.Size(32, 32);
            this.transRightB.TabIndex = 1;
            this.transRightB.TabStop = false;
            // 
            // transLeftB
            // 
            this.transLeftB.Image = ((System.Drawing.Image)(resources.GetObject("transLeftB.Image")));
            this.transLeftB.Location = new System.Drawing.Point(77, 34);
            this.transLeftB.Name = "transLeftB";
            this.transLeftB.Size = new System.Drawing.Size(32, 32);
            this.transLeftB.TabIndex = 0;
            this.transLeftB.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "connect.png");
            this.imageList1.Images.SetKeyName(1, "disconn128.png");
            // 
            // timerListen
            // 
            this.timerListen.Enabled = true;
            this.timerListen.Interval = 1;
            this.timerListen.Tick += new System.EventHandler(this.timerListen_Tick);
            // 
            // timerConnectClient
            // 
            this.timerConnectClient.Interval = 1;
            this.timerConnectClient.Tick += new System.EventHandler(this.timerConnectClient_Tick);
            // 
            // timerConnectInterface
            // 
            this.timerConnectInterface.Interval = 1;
            this.timerConnectInterface.Tick += new System.EventHandler(this.timerConnectInterface_Tick);
            // 
            // timerAutoConnect
            // 
            this.timerAutoConnect.Interval = 1000;
            this.timerAutoConnect.Tick += new System.EventHandler(this.timerAutoConnect_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(921, 614);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.connectSta);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " PMS Interface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.connectSta.ResumeLayout(false);
            this.connectSta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.transAreaA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transRightA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transLeftA)).EndInit();
            this.transAreaB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transRightB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transLeftB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonSetup;
        private System.Windows.Forms.ToolStripMenuItem interfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomConfigureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonLog;
        private System.Windows.Forms.ToolStripMenuItem issuingCardLogToolStripMenuItem;
        private System.Windows.Forms.Panel connectSta;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerListen;
        private System.Windows.Forms.Timer timerConnectClient;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUserManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Timer timerConnectInterface;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Timer timerAutoConnect;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblListen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel transAreaA;
        private System.Windows.Forms.PictureBox transRightA;
        private System.Windows.Forms.PictureBox transLeftA;
        private System.Windows.Forms.Panel transAreaB;
        private System.Windows.Forms.PictureBox transRightB;
        private System.Windows.Forms.PictureBox transLeftB;
        private System.Windows.Forms.Button btnConnToPMS;
    }
}