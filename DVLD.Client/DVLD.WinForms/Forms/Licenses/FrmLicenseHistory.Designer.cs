namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmLicenseHistory
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
            label1 = new Label();
            btnClose = new Button();
            pictureBox1 = new PictureBox();
            ctrlFilterPersonInfo1 = new Controls.PeopleControls.CtrlFilterPersonInfo();
            ctrlLicense1 = new Controls.LicensesControls.CtrlLicense();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(405, 10);
            label1.Name = "label1";
            label1.Size = new Size(231, 33);
            label1.TabIndex = 39;
            label1.Text = "License History";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(903, 766);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(126, 40);
            btnClose.TabIndex = 41;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.user_id_clock;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(12, 123);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 211);
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // ctrlFilterPersonInfo1
            // 
            ctrlFilterPersonInfo1.FilterEnabled = true;
            ctrlFilterPersonInfo1.Font = new Font("Microsoft Sans Serif", 8.25F);
            ctrlFilterPersonInfo1.Location = new Point(139, 44);
            ctrlFilterPersonInfo1.Name = "ctrlFilterPersonInfo1";
            ctrlFilterPersonInfo1.ShowAddPerson = true;
            ctrlFilterPersonInfo1.Size = new Size(901, 405);
            ctrlFilterPersonInfo1.TabIndex = 42;
            ctrlFilterPersonInfo1.OnPersonSelected += ctrlFilterPersonInfo1_OnPersonSelected;
            // 
            // ctrlLicense1
            // 
            ctrlLicense1.Font = new Font("Microsoft Sans Serif", 8.25F);
            ctrlLicense1.Location = new Point(0, 442);
            ctrlLicense1.Name = "ctrlLicense1";
            ctrlLicense1.Size = new Size(1039, 323);
            ctrlLicense1.TabIndex = 43;
            // 
            // FrmLicenseHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 816);
            Controls.Add(ctrlLicense1);
            Controls.Add(ctrlFilterPersonInfo1);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmLicenseHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "License History";
            Load += FrmLicenseHistory_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnClose;
        private PictureBox pictureBox1;
        private Controls.PeopleControls.CtrlFilterPersonInfo ctrlFilterPersonInfo1;
        private Controls.LicensesControls.CtrlLicense ctrlLicense1;
    }
}