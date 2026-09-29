namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmRenewLicense
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
            btnSave = new Button();
            txtNotes = new TextBox();
            lblFees = new Label();
            label12 = new Label();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            label10 = new Label();
            lblLicenseFees = new Label();
            label5 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            lblOldLicenseID = new Label();
            label11 = new Label();
            lblRenewLicense = new Label();
            label9 = new Label();
            lblExpiration = new Label();
            btnClose = new Button();
            linkLabel1 = new LinkLabel();
            pictureBox2 = new PictureBox();
            linkLabel2 = new LinkLabel();
            groupBox1 = new GroupBox();
            label6 = new Label();
            lblCreate = new Label();
            pictureBox10 = new PictureBox();
            label21 = new Label();
            lblAppFees = new Label();
            label15 = new Label();
            pictureBox7 = new PictureBox();
            lblIssueDate = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            lblAppDate = new Label();
            pictureBox5 = new PictureBox();
            label7 = new Label();
            lblRenewAppID = new Label();
            label2 = new Label();
            label1 = new Label();
            ctrlFilterDriverLicense1 = new Controls.DriversControls.CtrlFilterDriverLicense();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.id_reload;
            btnSave.Location = new Point(764, 799);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 40);
            btnSave.TabIndex = 88;
            btnSave.Text = "Renew";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(220, 200);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(301, 45);
            txtNotes.TabIndex = 65;
            // 
            // lblFees
            // 
            lblFees.AutoSize = true;
            lblFees.Location = new Point(710, 162);
            lblFees.Name = "lblFees";
            lblFees.Size = new Size(30, 15);
            lblFees.TabIndex = 64;
            lblFees.Text = "[???]";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(485, 166);
            label12.Name = "label12";
            label12.Size = new Size(99, 20);
            label12.TabIndex = 63;
            label12.Text = "Total Fees:";
            // 
            // pictureBox9
            // 
            pictureBox9.BackgroundImage = Properties.Resources.tax;
            pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox9.Location = new Point(671, 166);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(30, 20);
            pictureBox9.TabIndex = 62;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackgroundImage = Properties.Resources.cover_page;
            pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox8.Location = new Point(174, 200);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(30, 20);
            pictureBox8.TabIndex = 61;
            pictureBox8.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(16, 199);
            label10.Name = "label10";
            label10.Size = new Size(61, 20);
            label10.TabIndex = 59;
            label10.Text = "Notes:";
            // 
            // lblLicenseFees
            // 
            lblLicenseFees.AutoSize = true;
            lblLicenseFees.Location = new Point(216, 164);
            lblLicenseFees.Name = "lblLicenseFees";
            lblLicenseFees.Size = new Size(30, 15);
            lblLicenseFees.TabIndex = 58;
            lblLicenseFees.Text = "[???]";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 166);
            label5.Name = "label5";
            label5.Size = new Size(121, 20);
            label5.TabIndex = 57;
            label5.Text = "License Fees:";
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = Properties.Resources.tax;
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.Location = new Point(174, 167);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 20);
            pictureBox6.TabIndex = 56;
            pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.id_reload;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(671, 34);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 20);
            pictureBox3.TabIndex = 55;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.id__1_;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(671, 67);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 20);
            pictureBox4.TabIndex = 54;
            pictureBox4.TabStop = false;
            // 
            // lblOldLicenseID
            // 
            lblOldLicenseID.AutoSize = true;
            lblOldLicenseID.Location = new Point(710, 66);
            lblOldLicenseID.Name = "lblOldLicenseID";
            lblOldLicenseID.Size = new Size(30, 15);
            lblOldLicenseID.TabIndex = 53;
            lblOldLicenseID.Text = "[???]";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(485, 67);
            label11.Name = "label11";
            label11.Size = new Size(132, 20);
            label11.TabIndex = 52;
            label11.Text = "Old License ID:";
            // 
            // lblRenewLicense
            // 
            lblRenewLicense.AutoSize = true;
            lblRenewLicense.Location = new Point(710, 34);
            lblRenewLicense.Name = "lblRenewLicense";
            lblRenewLicense.Size = new Size(30, 15);
            lblRenewLicense.TabIndex = 51;
            lblRenewLicense.Text = "[???]";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(485, 34);
            label9.Name = "label9";
            label9.Size = new Size(180, 20);
            label9.TabIndex = 50;
            label9.Text = "Renewed License ID:";
            // 
            // lblExpiration
            // 
            lblExpiration.AutoSize = true;
            lblExpiration.Location = new Point(710, 98);
            lblExpiration.Name = "lblExpiration";
            lblExpiration.Size = new Size(30, 15);
            lblExpiration.TabIndex = 49;
            lblExpiration.Text = "[???]";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(619, 799);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 40);
            btnClose.TabIndex = 89;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Enabled = false;
            linkLabel1.Location = new Point(18, 809);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(124, 15);
            linkLabel1.TabIndex = 86;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Show Licenses History";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.calendar_week;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(671, 100);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 20);
            pictureBox2.TabIndex = 48;
            pictureBox2.TabStop = false;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Enabled = false;
            linkLabel2.Location = new Point(202, 809);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(129, 15);
            linkLabel2.TabIndex = 87;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Show New License Info";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNotes);
            groupBox1.Controls.Add(lblFees);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(pictureBox9);
            groupBox1.Controls.Add(pictureBox8);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(lblLicenseFees);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(pictureBox6);
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Controls.Add(pictureBox4);
            groupBox1.Controls.Add(lblOldLicenseID);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(lblRenewLicense);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblExpiration);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblCreate);
            groupBox1.Controls.Add(pictureBox10);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(lblAppFees);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(pictureBox7);
            groupBox1.Controls.Add(lblIssueDate);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblAppDate);
            groupBox1.Controls.Add(pictureBox5);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblRenewAppID);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(10, 523);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(893, 264);
            groupBox1.TabIndex = 85;
            groupBox1.TabStop = false;
            groupBox1.Text = "Application New License Info";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(485, 100);
            label6.Name = "label6";
            label6.Size = new Size(138, 20);
            label6.TabIndex = 47;
            label6.Text = "Expiration Date:";
            // 
            // lblCreate
            // 
            lblCreate.AutoSize = true;
            lblCreate.Location = new Point(710, 130);
            lblCreate.Name = "lblCreate";
            lblCreate.Size = new Size(30, 15);
            lblCreate.TabIndex = 46;
            lblCreate.Text = "[???]";
            // 
            // pictureBox10
            // 
            pictureBox10.BackgroundImage = Properties.Resources.user;
            pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox10.Location = new Point(671, 133);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(30, 20);
            pictureBox10.TabIndex = 45;
            pictureBox10.TabStop = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(485, 133);
            label21.Name = "label21";
            label21.Size = new Size(103, 20);
            label21.TabIndex = 44;
            label21.Text = "Created By:";
            // 
            // lblAppFees
            // 
            lblAppFees.AutoSize = true;
            lblAppFees.Location = new Point(216, 131);
            lblAppFees.Name = "lblAppFees";
            lblAppFees.Size = new Size(30, 15);
            lblAppFees.TabIndex = 37;
            lblAppFees.Text = "[???]";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(16, 133);
            label15.Name = "label15";
            label15.Size = new Size(148, 20);
            label15.TabIndex = 36;
            label15.Text = "Application Fees:";
            // 
            // pictureBox7
            // 
            pictureBox7.BackgroundImage = Properties.Resources.tax;
            pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox7.Location = new Point(174, 134);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(30, 20);
            pictureBox7.TabIndex = 35;
            pictureBox7.TabStop = false;
            // 
            // lblIssueDate
            // 
            lblIssueDate.AutoSize = true;
            lblIssueDate.Location = new Point(216, 98);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(30, 15);
            lblIssueDate.TabIndex = 33;
            lblIssueDate.Text = "[???]";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.calendar_week;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(174, 101);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 20);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 100);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 31;
            label4.Text = "Issue Date:";
            // 
            // lblAppDate
            // 
            lblAppDate.AutoSize = true;
            lblAppDate.Location = new Point(216, 65);
            lblAppDate.Name = "lblAppDate";
            lblAppDate.Size = new Size(30, 15);
            lblAppDate.TabIndex = 30;
            lblAppDate.Text = "[???]";
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = Properties.Resources.calendar_week;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(174, 68);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 20);
            pictureBox5.TabIndex = 29;
            pictureBox5.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(16, 67);
            label7.Name = "label7";
            label7.Size = new Size(147, 20);
            label7.TabIndex = 28;
            label7.Text = "Application Date:";
            // 
            // lblRenewAppID
            // 
            lblRenewAppID.AutoSize = true;
            lblRenewAppID.Location = new Point(167, 34);
            lblRenewAppID.Name = "lblRenewAppID";
            lblRenewAppID.Size = new Size(30, 15);
            lblRenewAppID.TabIndex = 23;
            lblRenewAppID.Text = "[???]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 34);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 22;
            label2.Text = "R.L.App ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(261, 9);
            label1.Name = "label1";
            label1.Size = new Size(390, 33);
            label1.TabIndex = 84;
            label1.Text = "Renew License Application";
            // 
            // ctrlFilterDriverLicense1
            // 
            ctrlFilterDriverLicense1.FilterEnabled = true;
            ctrlFilterDriverLicense1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlFilterDriverLicense1.Location = new Point(0, 47);
            ctrlFilterDriverLicense1.Name = "ctrlFilterDriverLicense1";
            ctrlFilterDriverLicense1.Size = new Size(914, 475);
            ctrlFilterDriverLicense1.TabIndex = 90;
            ctrlFilterDriverLicense1.OnLicenseSelected += ctrlFilterDriverLicense1_OnLicenseSelected;
            // 
            // FrmRenewLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 849);
            Controls.Add(ctrlFilterDriverLicense1);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(linkLabel1);
            Controls.Add(linkLabel2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmRenewLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Renew Local Driving License";
            Load += FrmRenewLicense_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtNotes;
        private Label lblFees;
        private Label label12;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private Label label10;
        private Label lblLicenseFees;
        private Label label5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label lblOldLicenseID;
        private Label label11;
        private Label lblRenewLicense;
        private Label label9;
        private Label lblExpiration;
        private Button btnClose;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel2;
        private GroupBox groupBox1;
        private Label label6;
        private Label lblCreate;
        private PictureBox pictureBox10;
        private Label label21;
        private Label lblAppFees;
        private Label label15;
        private PictureBox pictureBox7;
        private Label lblIssueDate;
        private PictureBox pictureBox1;
        private Label label4;
        private Label lblAppDate;
        private PictureBox pictureBox5;
        private Label label7;
        private Label lblRenewAppID;
        private Label label2;
        private Label label1;
        private Controls.DriversControls.CtrlFilterDriverLicense ctrlFilterDriverLicense1;
    }
}