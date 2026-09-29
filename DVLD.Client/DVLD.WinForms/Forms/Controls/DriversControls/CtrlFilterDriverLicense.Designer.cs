namespace DVLD.WinForms.Forms.Controls.DriversControls
{
    partial class CtrlFilterDriverLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbFilter = new GroupBox();
            label1 = new Label();
            btnAdd = new Button();
            tbFilter = new TextBox();
            ctrlDriverLicenseInfo1 = new CtrlDriverLicenseInfo();
            gbFilter.SuspendLayout();
            SuspendLayout();
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(label1);
            gbFilter.Controls.Add(btnAdd);
            gbFilter.Controls.Add(tbFilter);
            gbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbFilter.Location = new Point(3, 3);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(460, 95);
            gbFilter.TabIndex = 2;
            gbFilter.TabStop = false;
            gbFilter.Text = "Filter";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 44);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 60;
            label1.Text = "License ID:";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.id_search;
            btnAdd.Location = new Point(358, 34);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(83, 40);
            btnAdd.TabIndex = 59;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbFilter
            // 
            tbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFilter.Location = new Point(152, 41);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new Size(184, 26);
            tbFilter.TabIndex = 58;
            tbFilter.KeyPress += tbFilter_KeyPress;
            // 
            // ctrlDriverLicenseInfo1
            // 
            ctrlDriverLicenseInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlDriverLicenseInfo1.Location = new Point(5, 111);
            ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            ctrlDriverLicenseInfo1.Size = new Size(900, 359);
            ctrlDriverLicenseInfo1.TabIndex = 3;
            // 
            // CtrlFilterDriverLicense
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ctrlDriverLicenseInfo1);
            Controls.Add(gbFilter);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CtrlFilterDriverLicense";
            Size = new Size(911, 472);
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public GroupBox gbFilter;
        private Label label1;
        public Button btnAdd;
        public TextBox tbFilter;
        private CtrlDriverLicenseInfo ctrlDriverLicenseInfo1;
    }
}
