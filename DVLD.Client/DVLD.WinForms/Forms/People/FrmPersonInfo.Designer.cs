namespace DVLD.WinForms.Forms.People
{
    partial class FrmPersonInfo
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
            ctrlPersonInfo1 = new Controls.PeopleControls.CtrlPersonInfo();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(353, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(205, 31);
            label1.TabIndex = 1;
            label1.Text = "Person Details";
            // 
            // ctrlPersonInfo1
            // 
            ctrlPersonInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlPersonInfo1.Location = new Point(7, 61);
            ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            ctrlPersonInfo1.Size = new Size(896, 360);
            ctrlPersonInfo1.TabIndex = 2;
            // 
            // FrmPersonInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 380);
            Controls.Add(ctrlPersonInfo1);
            Controls.Add(label1);
            Name = "FrmPersonInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Person Details";
            Load += FrmPersonInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Controls.PeopleControls.CtrlPersonInfo ctrlPersonInfo1;
    }
}