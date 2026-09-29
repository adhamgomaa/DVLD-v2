namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmShowLocalApplication
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
            ctrlApplicationInfo1 = new Controls.ApplicationControls.CtrlApplicationInfo();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(629, 419);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 40);
            btnClose.TabIndex = 79;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlApplicationInfo1
            // 
            ctrlApplicationInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlApplicationInfo1.Location = new Point(0, 0);
            ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            ctrlApplicationInfo1.Size = new Size(775, 406);
            ctrlApplicationInfo1.TabIndex = 80;
            // 
            // FrmShowLocalApplication
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 471);
            Controls.Add(ctrlApplicationInfo1);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmShowLocalApplication";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Local Driving License Application Info";
            Load += FrmShowLocalApplication_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
        private Controls.ApplicationControls.CtrlApplicationInfo ctrlApplicationInfo1;
    }
}