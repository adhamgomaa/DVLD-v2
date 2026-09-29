namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmShowIntLicense
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
            btnClose = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ctrlInternationalLicense1 = new Controls.LicensesControls.CtrlInternationalLicense();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(775, 477);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(126, 40);
            btnClose.TabIndex = 40;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(228, 154);
            label1.Name = "label1";
            label1.Size = new Size(460, 33);
            label1.TabIndex = 39;
            label1.Text = "Driver International License Info";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.id_search;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(355, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(207, 124);
            pictureBox1.TabIndex = 38;
            pictureBox1.TabStop = false;
            // 
            // ctrlInternationalLicense1
            // 
            ctrlInternationalLicense1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlInternationalLicense1.Location = new Point(0, 194);
            ctrlInternationalLicense1.Name = "ctrlInternationalLicense1";
            ctrlInternationalLicense1.Size = new Size(913, 276);
            ctrlInternationalLicense1.TabIndex = 41;
            // 
            // FrmShowIntLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 525);
            Controls.Add(ctrlInternationalLicense1);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmShowIntLicense";
            StartPosition = FormStartPosition.CenterParent;
            Text = "International Driver Info";
            Load += FrmShowIntLicense_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Label label1;
        private PictureBox pictureBox1;
        private Controls.LicensesControls.CtrlInternationalLicense ctrlInternationalLicense1;
    }
}