namespace DVLD.WinForms.Forms.Users
{
    partial class FrmAddEditUsers
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
            components = new System.ComponentModel.Container();
            btnClose = new Button();
            errorProvider1 = new ErrorProvider(components);
            btnSave = new Button();
            cbActive = new CheckBox();
            txtCPass = new TextBox();
            label2 = new Label();
            lblUserID = new Label();
            label1 = new Label();
            btnNext = new Button();
            tabPage1 = new TabPage();
            txtPass = new TextBox();
            txtUsername = new TextBox();
            label6 = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            lblAddEdit = new Label();
            ctrlFilterPersonInfo1 = new Controls.PeopleControls.CtrlFilterPersonInfo();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(668, 610);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 57;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(793, 610);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 40);
            btnSave.TabIndex = 58;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cbActive
            // 
            cbActive.AutoSize = true;
            cbActive.Location = new Point(279, 266);
            cbActive.Name = "cbActive";
            cbActive.Size = new Size(70, 19);
            cbActive.TabIndex = 54;
            cbActive.Text = "Is Active";
            cbActive.UseVisualStyleBackColor = true;
            // 
            // txtCPass
            // 
            txtCPass.Location = new Point(334, 205);
            txtCPass.Name = "txtCPass";
            txtCPass.Size = new Size(167, 23);
            txtCPass.TabIndex = 53;
            txtCPass.Tag = "1";
            txtCPass.UseSystemPasswordChar = true;
            txtCPass.Validating += txtBox_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(111, 215);
            label2.Name = "label2";
            label2.Size = new Size(158, 20);
            label2.TabIndex = 51;
            label2.Text = "Confirm Password:";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserID.Location = new Point(188, 67);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(44, 20);
            lblUserID.TabIndex = 50;
            lblUserID.Text = "[???]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(111, 68);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 49;
            label1.Text = "UserID:";
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Image = Properties.Resources.arrow_right;
            btnNext.Location = new Point(774, 416);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(124, 40);
            btnNext.TabIndex = 55;
            btnNext.Text = "Next";
            btnNext.TextAlign = ContentAlignment.MiddleRight;
            btnNext.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ctrlFilterPersonInfo1);
            tabPage1.Controls.Add(btnNext);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(911, 470);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Personal Info";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(334, 158);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(167, 23);
            txtPass.TabIndex = 48;
            txtPass.Tag = "1";
            txtPass.UseSystemPasswordChar = true;
            txtPass.Validating += txtBox_Validating;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(334, 111);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(167, 23);
            txtUsername.TabIndex = 47;
            txtUsername.Tag = "1";
            txtUsername.Validating += txtBox_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(111, 166);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 44;
            label6.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(111, 117);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 43;
            label4.Text = "UserName:";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.password;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(276, 212);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 20);
            pictureBox3.TabIndex = 52;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.password;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(276, 163);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 20);
            pictureBox2.TabIndex = 46;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.user;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(276, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 20);
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 105);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(919, 498);
            tabControl1.TabIndex = 56;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cbActive);
            tabPage2.Controls.Add(txtCPass);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(lblUserID);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(txtPass);
            tabPage2.Controls.Add(txtUsername);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(pictureBox3);
            tabPage2.Controls.Add(pictureBox2);
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(911, 470);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Login Info";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblAddEdit
            // 
            lblAddEdit.AutoSize = true;
            lblAddEdit.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddEdit.ForeColor = Color.Firebrick;
            lblAddEdit.Location = new Point(385, 27);
            lblAddEdit.Margin = new Padding(4, 0, 4, 0);
            lblAddEdit.Name = "lblAddEdit";
            lblAddEdit.Size = new Size(144, 33);
            lblAddEdit.TabIndex = 55;
            lblAddEdit.Text = "Add User";
            // 
            // ctrlFilterPersonInfo1
            // 
            ctrlFilterPersonInfo1.FilterEnabled = true;
            ctrlFilterPersonInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlFilterPersonInfo1.Location = new Point(9, 8);
            ctrlFilterPersonInfo1.Name = "ctrlFilterPersonInfo1";
            ctrlFilterPersonInfo1.ShowAddPerson = true;
            ctrlFilterPersonInfo1.Size = new Size(893, 402);
            ctrlFilterPersonInfo1.TabIndex = 56;
            // 
            // FrmAddEditUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 677);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(tabControl1);
            Controls.Add(lblAddEdit);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmAddEditUsers";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Users";
            Load += FrmAddEditUsers_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private ErrorProvider errorProvider1;
        private Button btnSave;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnNext;
        private TabPage tabPage2;
        private CheckBox cbActive;
        private TextBox txtCPass;
        private Label label2;
        private Label lblUserID;
        private Label label1;
        private TextBox txtPass;
        private TextBox txtUsername;
        private Label label6;
        private Label label4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblAddEdit;
        private Controls.PeopleControls.CtrlFilterPersonInfo ctrlFilterPersonInfo1;
    }
}