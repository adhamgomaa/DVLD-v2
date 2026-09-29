namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmDriverLicenseInfo
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
            pictureBox1 = new PictureBox();
            btnClose = new Button();
            ctrlDriverLicenseInfo1 = new Controls.DriversControls.CtrlDriverLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(322, 152);
            label1.Name = "label1";
            label1.Size = new Size(278, 33);
            label1.TabIndex = 36;
            label1.Text = "Driver License Info";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.id_search;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(358, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 124);
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(787, 561);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(126, 40);
            btnClose.TabIndex = 34;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlDriverLicenseInfo1
            // 
            ctrlDriverLicenseInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlDriverLicenseInfo1.Location = new Point(9, 194);
            ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            ctrlDriverLicenseInfo1.Size = new Size(904, 363);
            ctrlDriverLicenseInfo1.TabIndex = 37;
            // 
            // FrmDriverLicenseInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 611);
            Controls.Add(ctrlDriverLicenseInfo1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmDriverLicenseInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "License Info";
            Load += FrmDriverLicenseInfo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Button btnClose;
        private Controls.DriversControls.CtrlDriverLicenseInfo ctrlDriverLicenseInfo1;
    }
}