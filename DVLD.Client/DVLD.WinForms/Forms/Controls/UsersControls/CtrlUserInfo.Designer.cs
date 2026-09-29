namespace DVLD.WinForms.Forms.Controls.UsersControls
{
    partial class CtrlUserInfo
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
            groupBox1 = new GroupBox();
            lblActive = new Label();
            label5 = new Label();
            lblUserName = new Label();
            label3 = new Label();
            lblUserId = new Label();
            label1 = new Label();
            ctrlPersonInfo1 = new PeopleControls.CtrlPersonInfo();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblActive);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblUserName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblUserId);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 321);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(892, 128);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login Information";
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Location = new Point(712, 54);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(44, 20);
            lblActive.TabIndex = 7;
            lblActive.Text = "[???]";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(613, 54);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 6;
            label5.Text = "Is Active:";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(473, 54);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(44, 20);
            lblUserName.TabIndex = 5;
            lblUserName.Text = "[???]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(365, 54);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 4;
            label3.Text = "Username:";
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(237, 53);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(44, 20);
            lblUserId.TabIndex = 3;
            lblUserId.Text = "[???]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(151, 54);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 2;
            label1.Text = "User ID:";
            // 
            // ctrlPersonInfo1
            // 
            ctrlPersonInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlPersonInfo1.Location = new Point(1, 0);
            ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            ctrlPersonInfo1.Size = new Size(890, 312);
            ctrlPersonInfo1.TabIndex = 3;
            // 
            // CtrlUserInfo
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ctrlPersonInfo1);
            Controls.Add(groupBox1);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CtrlUserInfo";
            Size = new Size(892, 449);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblActive;
        private Label label5;
        private Label lblUserName;
        private Label label3;
        private Label lblUserId;
        private Label label1;
        private PeopleControls.CtrlPersonInfo ctrlPersonInfo1;
    }
}
