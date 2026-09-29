namespace DVLD.WinForms.Forms.Tests
{
    partial class FrmTakeTest
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
            lblMessage = new Label();
            textBox1 = new TextBox();
            label7 = new Label();
            rbFail = new RadioButton();
            rbPass = new RadioButton();
            label5 = new Label();
            btnSave = new Button();
            btnClose = new Button();
            ctrlScheduledTest1 = new Controls.TestsControls.CtrlScheduledTest();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.Firebrick;
            lblMessage.Location = new Point(234, 532);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(230, 20);
            lblMessage.TabIndex = 83;
            lblMessage.Text = "You can't change the result";
            lblMessage.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(102, 566);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(367, 81);
            textBox1.TabIndex = 82;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(30, 566);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 81;
            label7.Text = "Notes:";
            // 
            // rbFail
            // 
            rbFail.AutoSize = true;
            rbFail.Location = new Point(171, 530);
            rbFail.Name = "rbFail";
            rbFail.Size = new Size(43, 19);
            rbFail.TabIndex = 80;
            rbFail.TabStop = true;
            rbFail.Text = "Fail";
            rbFail.UseVisualStyleBackColor = true;
            // 
            // rbPass
            // 
            rbPass.AutoSize = true;
            rbPass.Location = new Point(102, 530);
            rbPass.Name = "rbPass";
            rbPass.Size = new Size(48, 19);
            rbPass.TabIndex = 79;
            rbPass.TabStop = true;
            rbPass.Text = "Pass";
            rbPass.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 532);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 78;
            label5.Text = "Result:";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(331, 665);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 40);
            btnSave.TabIndex = 76;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(186, 665);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 40);
            btnClose.TabIndex = 77;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlScheduledTest1
            // 
            ctrlScheduledTest1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlScheduledTest1.Location = new Point(0, 0);
            ctrlScheduledTest1.Name = "ctrlScheduledTest1";
            ctrlScheduledTest1.Size = new Size(483, 511);
            ctrlScheduledTest1.TabIndex = 84;
            ctrlScheduledTest1.TestTypeID = Shared.Enums.TestTypeEnum.VisionTest;
            // 
            // FrmTakeTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 718);
            Controls.Add(ctrlScheduledTest1);
            Controls.Add(lblMessage);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(rbFail);
            Controls.Add(rbPass);
            Controls.Add(label5);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmTakeTest";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Take Test";
            Load += FrmTakeTest_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private TextBox textBox1;
        private Label label7;
        private RadioButton rbFail;
        private RadioButton rbPass;
        private Label label5;
        private Button btnSave;
        private Button btnClose;
        private Controls.TestsControls.CtrlScheduledTest ctrlScheduledTest1;
    }
}