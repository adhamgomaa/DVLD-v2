namespace DVLD.WinForms.Forms.Controls.PeopleControls
{
    partial class CtrlFilterPersonInfo
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
            label2 = new Label();
            cbFilter = new ComboBox();
            button1 = new Button();
            tbFilter = new TextBox();
            btnAdd = new Button();
            gbFilter = new GroupBox();
            ctrlPersonInfo1 = new CtrlPersonInfo();
            gbFilter.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 31);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 54;
            label2.Text = "Find By:";
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(109, 28);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(171, 28);
            cbFilter.TabIndex = 55;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.user__2_;
            button1.Location = new Point(546, 25);
            button1.Name = "button1";
            button1.Size = new Size(63, 40);
            button1.TabIndex = 58;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbFilter
            // 
            tbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFilter.Location = new Point(298, 30);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new Size(151, 26);
            tbFilter.TabIndex = 56;
            tbFilter.KeyPress += tbFilter_KeyPress;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.stakeholder_analysis;
            btnAdd.Location = new Point(470, 25);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(63, 40);
            btnAdd.TabIndex = 57;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(label2);
            gbFilter.Controls.Add(cbFilter);
            gbFilter.Controls.Add(button1);
            gbFilter.Controls.Add(tbFilter);
            gbFilter.Controls.Add(btnAdd);
            gbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbFilter.Location = new Point(3, 2);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(887, 76);
            gbFilter.TabIndex = 61;
            gbFilter.TabStop = false;
            gbFilter.Text = "Filter";
            // 
            // ctrlPersonInfo1
            // 
            ctrlPersonInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlPersonInfo1.Location = new Point(3, 88);
            ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            ctrlPersonInfo1.Size = new Size(890, 312);
            ctrlPersonInfo1.TabIndex = 62;
            // 
            // CtrlFilterPersonInfo
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ctrlPersonInfo1);
            Controls.Add(gbFilter);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CtrlFilterPersonInfo";
            Size = new Size(893, 402);
            Load += CtrlFilterPersonInfo_Load;
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private ComboBox cbFilter;
        private Button button1;
        public TextBox tbFilter;
        private Button btnAdd;
        private GroupBox gbFilter;
        private CtrlPersonInfo ctrlPersonInfo1;
    }
}
