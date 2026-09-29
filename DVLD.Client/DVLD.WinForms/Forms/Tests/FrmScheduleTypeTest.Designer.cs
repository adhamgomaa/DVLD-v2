namespace DVLD.WinForms.Forms.Tests
{
    partial class FrmScheduleTypeTest
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
            ctrlScheduleTest1 = new Controls.TestsControls.CtrlScheduleTest();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(248, 681);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 67;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlScheduleTest1
            // 
            ctrlScheduleTest1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlScheduleTest1.Location = new Point(0, 0);
            ctrlScheduleTest1.Name = "ctrlScheduleTest1";
            ctrlScheduleTest1.Size = new Size(599, 667);
            ctrlScheduleTest1.TabIndex = 68;
            ctrlScheduleTest1.TestTypeID = Shared.Enums.TestTypeEnum.VisionTest;
            // 
            // FrmScheduleTypeTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 730);
            Controls.Add(ctrlScheduleTest1);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmScheduleTypeTest";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Schedule Test";
            Load += FrmScheduleTypeTest_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
        private Controls.TestsControls.CtrlScheduleTest ctrlScheduleTest1;
    }
}