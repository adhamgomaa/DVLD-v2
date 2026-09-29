namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmDetainLicense
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
            linkLabel2 = new LinkLabel();
            pictureBox5 = new PictureBox();
            label7 = new Label();
            lblDetainID = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            pictureBox10 = new PictureBox();
            label21 = new Label();
            lblDetainDate = new Label();
            btnClose = new Button();
            groupBox1 = new GroupBox();
            txtFees = new TextBox();
            pictureBox8 = new PictureBox();
            label10 = new Label();
            pictureBox3 = new PictureBox();
            lblLicense = new Label();
            label9 = new Label();
            lblCreate = new Label();
            label1 = new Label();
            ctrlFilterDriverLicense1 = new Controls.DriversControls.CtrlFilterDriverLicense();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.id_lock1;
            btnSave.Location = new Point(764, 683);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 40);
            btnSave.TabIndex = 96;
            btnSave.Text = "Detain";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Enabled = false;
            linkLabel2.Location = new Point(202, 693);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(102, 15);
            linkLabel2.TabIndex = 95;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Show License Info";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = Properties.Resources.calendar_week;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(151, 68);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 20);
            pictureBox5.TabIndex = 29;
            pictureBox5.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(27, 67);
            label7.Name = "label7";
            label7.Size = new Size(111, 20);
            label7.TabIndex = 28;
            label7.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            lblDetainID.AutoSize = true;
            lblDetainID.Location = new Point(144, 34);
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
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Enabled = false;
            linkLabel1.Location = new Point(18, 693);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(124, 15);
            linkLabel1.TabIndex = 94;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Show Licenses History";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox10
            // 
            pictureBox10.BackgroundImage = Properties.Resources.user;
            pictureBox10.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox10.Location = new Point(617, 68);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(30, 20);
            pictureBox10.TabIndex = 45;
            pictureBox10.TabStop = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(496, 68);
            label21.Name = "label21";
            label21.Size = new Size(103, 20);
            label21.TabIndex = 44;
            label21.Text = "Created By:";
            // 
            // lblDetainDate
            // 
            lblDetainDate.AutoSize = true;
            lblDetainDate.Location = new Point(194, 65);
            lblDetainDate.Name = "lblDetainDate";
            lblDetainDate.Size = new Size(30, 15);
            lblDetainDate.TabIndex = 30;
            lblDetainDate.Text = "[???]";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(619, 683);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 40);
            btnClose.TabIndex = 97;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtFees);
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
            groupBox1.Location = new Point(10, 527);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(893, 145);
            groupBox1.TabIndex = 93;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detain Info";
            // 
            // txtFees
            // 
            txtFees.Location = new Point(198, 99);
            txtFees.Multiline = true;
            txtFees.Name = "txtFees";
            txtFees.Size = new Size(175, 28);
            txtFees.TabIndex = 65;
            txtFees.KeyPress += txtFees_KeyPress;
            // 
            // pictureBox8
            // 
            pictureBox8.BackgroundImage = Properties.Resources.tax;
            pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox8.Location = new Point(151, 105);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(30, 20);
            pictureBox8.TabIndex = 61;
            pictureBox8.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(27, 104);
            label10.Name = "label10";
            label10.Size = new Size(94, 20);
            label10.TabIndex = 59;
            label10.Text = "Fine Fees:";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.id__1_;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(617, 34);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 20);
            pictureBox3.TabIndex = 55;
            pictureBox3.TabStop = false;
            // 
            // lblLicense
            // 
            lblLicense.AutoSize = true;
            lblLicense.Location = new Point(656, 34);
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
            lblCreate.Location = new Point(656, 66);
            lblCreate.Name = "lblCreate";
            lblCreate.Size = new Size(30, 15);
            lblCreate.TabIndex = 46;
            lblCreate.Text = "[???]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(343, 13);
            label1.Name = "label1";
            label1.Size = new Size(222, 33);
            label1.TabIndex = 92;
            label1.Text = "Detain License";
            // 
            // ctrlFilterDriverLicense1
            // 
            ctrlFilterDriverLicense1.FilterEnabled = true;
            ctrlFilterDriverLicense1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlFilterDriverLicense1.Location = new Point(3, 51);
            ctrlFilterDriverLicense1.Name = "ctrlFilterDriverLicense1";
            ctrlFilterDriverLicense1.Size = new Size(910, 479);
            ctrlFilterDriverLicense1.TabIndex = 98;
            ctrlFilterDriverLicense1.OnLicenseSelected += ctrlFilterDriverLicense1_OnLicenseSelected;
            // 
            // FrmDetainLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 737);
            Controls.Add(ctrlFilterDriverLicense1);
            Controls.Add(btnSave);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(btnClose);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmDetainLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detain License";
            Load += FrmDetainLicense_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private LinkLabel linkLabel2;
        private PictureBox pictureBox5;
        private Label label7;
        private Label lblDetainID;
        private Label label2;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox10;
        private Label label21;
        private Label lblDetainDate;
        private Button btnClose;
        private GroupBox groupBox1;
        private TextBox txtFees;
        private PictureBox pictureBox8;
        private Label label10;
        private PictureBox pictureBox3;
        private Label lblLicense;
        private Label label9;
        private Label lblCreate;
        private Label label1;
        private Controls.DriversControls.CtrlFilterDriverLicense ctrlFilterDriverLicense1;
    }
}