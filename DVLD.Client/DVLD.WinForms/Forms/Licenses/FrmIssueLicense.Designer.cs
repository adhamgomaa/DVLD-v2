namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmIssueLicense
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
            btnClose = new Button();
            txtNotes = new TextBox();
            label7 = new Label();
            ctrlApplicationInfo1 = new Controls.ApplicationControls.CtrlApplicationInfo();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.id_up;
            btnSave.Location = new Point(623, 528);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 40);
            btnSave.TabIndex = 80;
            btnSave.Text = "Issue";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(478, 528);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 40);
            btnClose.TabIndex = 81;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(87, 414);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(672, 103);
            txtNotes.TabIndex = 79;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 414);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 78;
            label7.Text = "Notes:";
            // 
            // ctrlApplicationInfo1
            // 
            ctrlApplicationInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlApplicationInfo1.Location = new Point(0, 0);
            ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            ctrlApplicationInfo1.Size = new Size(774, 408);
            ctrlApplicationInfo1.TabIndex = 82;
            // 
            // FrmIssueLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 583);
            Controls.Add(ctrlApplicationInfo1);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(txtNotes);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmIssueLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Issue Driver License For The First Time";
            Load += FrmIssueLicense_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnClose;
        private TextBox txtNotes;
        private Label label7;
        private Controls.ApplicationControls.CtrlApplicationInfo ctrlApplicationInfo1;
    }
}