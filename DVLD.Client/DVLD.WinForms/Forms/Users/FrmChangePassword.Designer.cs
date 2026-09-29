namespace DVLD.WinForms.Forms.Users
{
    partial class FrmChangePassword
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
            btnSave = new Button();
            btnClose = new Button();
            txtCurrent = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txtCPass = new TextBox();
            label2 = new Label();
            txtPass = new TextBox();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            ctrlUserInfo1 = new Controls.UsersControls.CtrlUserInfo();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(772, 688);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 40);
            btnSave.TabIndex = 75;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(648, 688);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(115, 40);
            btnClose.TabIndex = 74;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtCurrent
            // 
            txtCurrent.Location = new Point(262, 491);
            txtCurrent.Name = "txtCurrent";
            txtCurrent.Size = new Size(167, 23);
            txtCurrent.TabIndex = 73;
            txtCurrent.Tag = "1";
            txtCurrent.UseSystemPasswordChar = true;
            txtCurrent.Validating += txtBox_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 495);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 71;
            label1.Text = "Current Password:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.password;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(204, 495);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 20);
            pictureBox1.TabIndex = 72;
            pictureBox1.TabStop = false;
            // 
            // txtCPass
            // 
            txtCPass.Location = new Point(262, 598);
            txtCPass.Name = "txtCPass";
            txtCPass.Size = new Size(167, 23);
            txtCPass.TabIndex = 70;
            txtCPass.Tag = "1";
            txtCPass.UseSystemPasswordChar = true;
            txtCPass.Validating += txtBox_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 599);
            label2.Name = "label2";
            label2.Size = new Size(158, 20);
            label2.TabIndex = 68;
            label2.Text = "Confirm Password:";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(262, 547);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(167, 23);
            txtPass.TabIndex = 67;
            txtPass.Tag = "";
            txtPass.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(49, 549);
            label6.Name = "label6";
            label6.Size = new Size(130, 20);
            label6.TabIndex = 65;
            label6.Text = "New Password:";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.password;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(204, 601);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 20);
            pictureBox3.TabIndex = 69;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.password;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(204, 550);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 20);
            pictureBox2.TabIndex = 66;
            pictureBox2.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrlUserInfo1
            // 
            ctrlUserInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlUserInfo1.Location = new Point(9, 3);
            ctrlUserInfo1.Name = "ctrlUserInfo1";
            ctrlUserInfo1.Size = new Size(892, 449);
            ctrlUserInfo1.TabIndex = 76;
            // 
            // FrmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 740);
            Controls.Add(ctrlUserInfo1);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(txtCurrent);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(txtCPass);
            Controls.Add(label2);
            Controls.Add(txtPass);
            Controls.Add(label6);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Password";
            Load += FrmChangePassword_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnClose;
        private TextBox txtCurrent;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txtCPass;
        private Label label2;
        private TextBox txtPass;
        private Label label6;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private ErrorProvider errorProvider1;
        private Controls.UsersControls.CtrlUserInfo ctrlUserInfo1;
    }
}