namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmReleaseLicense
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
            linkLabel2 = new LinkLabel();
            btnSave = new Button();
            linkLabel1 = new LinkLabel();
            lblReleaseId = new Label();
            label12 = new Label();
            lblTotalFees = new Label();
            pictureBox2 = new PictureBox();
            label8 = new Label();
            lblAppFees = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label5 = new Label();
            lblFees = new Label();
            pictureBox8 = new PictureBox();
            label10 = new Label();
            pictureBox3 = new PictureBox();
            lblLicense = new Label();
            label9 = new Label();
            lblCreate = new Label();
            pictureBox10 = new PictureBox();
            lblDetainDate = new Label();
            pictureBox5 = new PictureBox();
            label7 = new Label();
            lblDetainID = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label21 = new Label();
            btnClose = new Button();
            ctrlFilterDriverLicense1 = new Controls.DriversControls.CtrlFilterDriverLicense();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Enabled = false;
            linkLabel2.Location = new Point(202, 730);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(102, 15);
            linkLabel2.TabIndex = 103;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Show License Info";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.id_unlock;
            btnSave.Location = new Point(764, 720);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 40);
            btnSave.TabIndex = 104;
            btnSave.Text = "Release";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Enabled = false;
            linkLabel1.Location = new Point(18, 730);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(124, 15);
            linkLabel1.TabIndex = 102;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Show Licenses History";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // lblReleaseId
            // 
            lblReleaseId.AutoSize = true;
            lblReleaseId.Location = new Point(643, 151);
            lblReleaseId.Name = "lblReleaseId";
            lblReleaseId.Size = new Size(30, 15);
            lblReleaseId.TabIndex = 70;
            lblReleaseId.Text = "[???]";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(496, 151);
            label12.Name = "label12";
            label12.Size = new Size(141, 20);
            label12.TabIndex = 69;
            label12.Text = "Release App ID:";
            // 
            // lblTotalFees
            // 
            lblTotalFees.AutoSize = true;
            lblTotalFees.Location = new Point(219, 149);
            lblTotalFees.Name = "lblTotalFees";
            lblTotalFees.Size = new Size(30, 15);
            lblTotalFees.TabIndex = 68;
            lblTotalFees.Text = "[???]";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.tax;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(180, 151);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 20);
            pictureBox2.TabIndex = 67;
            pictureBox2.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(27, 151);
            label8.Name = "label8";
            label8.Size = new Size(99, 20);
            label8.TabIndex = 66;
            label8.Text = "Total Fees:";
            // 
            // lblAppFees
            // 
            lblAppFees.AutoSize = true;
            lblAppFees.Location = new Point(219, 110);
            lblAppFees.Name = "lblAppFees";
            lblAppFees.Size = new Size(30, 15);
            lblAppFees.TabIndex = 65;
            lblAppFees.Text = "[???]";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.tax;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(180, 112);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 20);
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(265, 7);
            label1.Name = "label1";
            label1.Size = new Size(379, 33);
            label1.TabIndex = 100;
            label1.Text = "Release Detained License";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 112);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 63;
            label5.Text = "Application Fees:";
            // 
            // lblFees
            // 
            lblFees.AutoSize = true;
            lblFees.Location = new Point(693, 112);
            lblFees.Name = "lblFees";
            lblFees.Size = new Size(30, 15);
            lblFees.TabIndex = 62;
            lblFees.Text = "[???]";
            // 
            // pictureBox8
            // 
            pictureBox8.BackgroundImage = Properties.Resources.tax;
            pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox8.Location = new Point(650, 112);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(30, 20);
            pictureBox8.TabIndex = 61;
            pictureBox8.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(496, 112);
            label10.Name = "label10";
            label10.Size = new Size(94, 20);
            label10.TabIndex = 59;
            label10.Text = "Fine Fees:";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.id__1_;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(650, 34);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 20);
            pictureBox3.TabIndex = 55;
            pictureBox3.TabStop = false;
            // 
            // lblLicense
            // 
            lblLicense.AutoSize = true;
            lblLicense.Location = new Point(693, 33);
            lblLicense.Name = "lblLicense";
            lblLicense.Size = new Size(30, 15);
            lblLicense.TabIndex = 51;
            lblLicense.Text = "[???]";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(496, 34);
            label9.Name = "label9";
            label9.Size = new Size(100, 20);
            label9.TabIndex = 50;
            label9.Text = "License ID:";
            // 
            // lblCreate
            // 
            lblCreate.AutoSize = true;
            lblCreate.Location = new Point(693, 72);
            lblCreate.Name = "lblCreate";
            lblCreate.Size = new Size(30, 15);
            lblCreate.TabIndex = 46;
            lblCreate.Text = "[???]";
            // 
            // pictureBox10
            // 
            pictureBox10.BackgroundImage = Properties.Resources.user;
            pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox10.Location = new Point(650, 73);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(30, 20);
            pictureBox10.TabIndex = 45;
            pictureBox10.TabStop = false;
            // 
            // lblDetainDate
            // 
            lblDetainDate.AutoSize = true;
            lblDetainDate.Location = new Point(219, 71);
            lblDetainDate.Name = "lblDetainDate";
            lblDetainDate.Size = new Size(30, 15);
            lblDetainDate.TabIndex = 30;
            lblDetainDate.Text = "[???]";
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = Properties.Resources.calendar_week;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(180, 73);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 20);
            pictureBox5.TabIndex = 29;
            pictureBox5.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(27, 73);
            label7.Name = "label7";
            label7.Size = new Size(111, 20);
            label7.TabIndex = 28;
            label7.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            lblDetainID.AutoSize = true;
            lblDetainID.Location = new Point(173, 34);
            lblDetainID.Name = "lblDetainID";
            lblDetainID.Size = new Size(30, 15);
            lblDetainID.TabIndex = 23;
            lblDetainID.Text = "[???]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 34);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 22;
            label2.Text = "Detain ID:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblReleaseId);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(lblTotalFees);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(lblAppFees);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblFees);
            groupBox1.Controls.Add(pictureBox8);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(pictureBox3);
            groupBox1.Controls.Add(lblLicense);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblCreate);
            groupBox1.Controls.Add(pictureBox10);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(lblDetainDate);
            groupBox1.Controls.Add(pictureBox5);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblDetainID);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(10, 521);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(893, 189);
            groupBox1.TabIndex = 101;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detain Info";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(496, 73);
            label21.Name = "label21";
            label21.Size = new Size(103, 20);
            label21.TabIndex = 44;
            label21.Text = "Created By:";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(619, 720);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 40);
            btnClose.TabIndex = 105;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlFilterDriverLicense1
            // 
            ctrlFilterDriverLicense1.FilterEnabled = true;
            ctrlFilterDriverLicense1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlFilterDriverLicense1.Location = new Point(0, 44);
            ctrlFilterDriverLicense1.Margin = new Padding(2);
            ctrlFilterDriverLicense1.Name = "ctrlFilterDriverLicense1";
            ctrlFilterDriverLicense1.Size = new Size(912, 477);
            ctrlFilterDriverLicense1.TabIndex = 106;
            ctrlFilterDriverLicense1.OnLicenseSelected += ctrlFilterDriverLicense1_OnLicenseSelected;
            // 
            // FrmReleaseLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 766);
            Controls.Add(ctrlFilterDriverLicense1);
            Controls.Add(linkLabel2);
            Controls.Add(btnSave);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmReleaseLicense";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Release Detained License";
            Load += FrmReleaseLicense_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkLabel2;
        private Button btnSave;
        private LinkLabel linkLabel1;
        private Label lblReleaseId;
        private Label label12;
        private Label lblTotalFees;
        private PictureBox pictureBox2;
        private Label label8;
        private Label lblAppFees;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label5;
        private Label lblFees;
        private PictureBox pictureBox8;
        private Label label10;
        private PictureBox pictureBox3;
        private Label lblLicense;
        private Label label9;
        private Label lblCreate;
        private PictureBox pictureBox10;
        private Label lblDetainDate;
        private PictureBox pictureBox5;
        private Label label7;
        private Label lblDetainID;
        private Label label2;
        private GroupBox groupBox1;
        private Label label21;
        private Button btnClose;
        private Controls.DriversControls.CtrlFilterDriverLicense ctrlFilterDriverLicense1;
    }
}