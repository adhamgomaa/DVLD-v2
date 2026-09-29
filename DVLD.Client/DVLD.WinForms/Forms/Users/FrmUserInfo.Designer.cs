namespace DVLD.WinForms.Forms.Users
{
    partial class FrmUserInfo
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
            lblAddEdit = new Label();
            ctrlUserInfo1 = new Controls.UsersControls.CtrlUserInfo();
            SuspendLayout();
            // 
            // lblAddEdit
            // 
            lblAddEdit.AutoSize = true;
            lblAddEdit.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddEdit.ForeColor = Color.Firebrick;
            lblAddEdit.Location = new Point(359, 30);
            lblAddEdit.Margin = new Padding(4, 0, 4, 0);
            lblAddEdit.Name = "lblAddEdit";
            lblAddEdit.Size = new Size(187, 33);
            lblAddEdit.TabIndex = 4;
            lblAddEdit.Text = "User Details";
            // 
            // ctrlUserInfo1
            // 
            ctrlUserInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlUserInfo1.Location = new Point(6, 75);
            ctrlUserInfo1.Name = "ctrlUserInfo1";
            ctrlUserInfo1.Size = new Size(892, 449);
            ctrlUserInfo1.TabIndex = 5;
            // 
            // FrmUserInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 527);
            Controls.Add(ctrlUserInfo1);
            Controls.Add(lblAddEdit);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmUserInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Details";
            Load += FrmUserInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAddEdit;
        private Controls.UsersControls.CtrlUserInfo ctrlUserInfo1;
    }
}