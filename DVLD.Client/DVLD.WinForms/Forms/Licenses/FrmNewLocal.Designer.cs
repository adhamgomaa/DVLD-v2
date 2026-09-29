namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmNewLocal
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
            lblAddEdit = new Label();
            tabPage1 = new TabPage();
            ctrlFilterPersonInfo1 = new Controls.PeopleControls.CtrlFilterPersonInfo();
            btnNext = new Button();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            lblCreate = new Label();
            lblFees = new Label();
            cbClass = new ComboBox();
            lblAppDate = new Label();
            label3 = new Label();
            pictureBox4 = new PictureBox();
            label2 = new Label();
            lblAppID = new Label();
            label1 = new Label();
            label6 = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnSave = new Button();
            errorProvider1 = new ErrorProvider(components);
            btnClose = new Button();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblAddEdit
            // 
            lblAddEdit.AutoSize = true;
            lblAddEdit.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddEdit.ForeColor = Color.Firebrick;
            lblAddEdit.Location = new Point(212, 17);
            lblAddEdit.Margin = new Padding(4, 0, 4, 0);
            lblAddEdit.Name = "lblAddEdit";
            lblAddEdit.Size = new Size(548, 33);
            lblAddEdit.TabIndex = 59;
            lblAddEdit.Text = "New Local Driving License Application";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ctrlFilterPersonInfo1);
            tabPage1.Controls.Add(btnNext);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(924, 479);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Personal Info";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlFilterPersonInfo1
            // 
            ctrlFilterPersonInfo1.FilterEnabled = true;
            ctrlFilterPersonInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlFilterPersonInfo1.Location = new Point(12, 13);
            ctrlFilterPersonInfo1.Name = "ctrlFilterPersonInfo1";
            ctrlFilterPersonInfo1.ShowAddPerson = true;
            ctrlFilterPersonInfo1.Size = new Size(902, 406);
            ctrlFilterPersonInfo1.TabIndex = 63;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Image = Properties.Resources.arrow_right;
            btnNext.Location = new Point(771, 425);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(124, 40);
            btnNext.TabIndex = 55;
            btnNext.Text = "Next";
            btnNext.TextAlign = ContentAlignment.MiddleRight;
            btnNext.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(9, 64);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(932, 507);
            tabControl1.TabIndex = 60;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lblCreate);
            tabPage2.Controls.Add(lblFees);
            tabPage2.Controls.Add(cbClass);
            tabPage2.Controls.Add(lblAppDate);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(pictureBox4);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(lblAppID);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(pictureBox3);
            tabPage2.Controls.Add(pictureBox2);
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(924, 479);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Application Info";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCreate
            // 
            lblCreate.AutoSize = true;
            lblCreate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreate.Location = new Point(333, 267);
            lblCreate.Name = "lblCreate";
            lblCreate.Size = new Size(44, 20);
            lblCreate.TabIndex = 61;
            lblCreate.Text = "[???]";
            // 
            // lblFees
            // 
            lblFees.AutoSize = true;
            lblFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFees.Location = new Point(333, 216);
            lblFees.Name = "lblFees";
            lblFees.Size = new Size(44, 20);
            lblFees.TabIndex = 60;
            lblFees.Text = "[???]";
            // 
            // cbClass
            // 
            cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClass.FormattingEnabled = true;
            cbClass.Location = new Point(330, 162);
            cbClass.Name = "cbClass";
            cbClass.Size = new Size(264, 23);
            cbClass.TabIndex = 59;
            // 
            // lblAppDate
            // 
            lblAppDate.AutoSize = true;
            lblAppDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAppDate.Location = new Point(333, 117);
            lblAppDate.Name = "lblAppDate";
            lblAppDate.Size = new Size(44, 20);
            lblAppDate.TabIndex = 58;
            lblAppDate.Text = "[???]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(111, 268);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 55;
            label3.Text = "Created By:";
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.patient_boy__1_;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(279, 264);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 20);
            pictureBox4.TabIndex = 56;
            pictureBox4.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(111, 218);
            label2.Name = "label2";
            label2.Size = new Size(148, 20);
            label2.TabIndex = 51;
            label2.Text = "Application Fees:";
            // 
            // lblAppID
            // 
            lblAppID.AutoSize = true;
            lblAppID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAppID.Location = new Point(275, 67);
            lblAppID.Name = "lblAppID";
            lblAppID.Size = new Size(44, 20);
            lblAppID.TabIndex = 50;
            lblAppID.Text = "[???]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(111, 68);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 49;
            label1.Text = "D.L.Application ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(111, 168);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 44;
            label6.Text = "License Class:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(111, 118);
            label4.Name = "label4";
            label4.Size = new Size(147, 20);
            label4.TabIndex = 43;
            label4.Text = "Application Date:";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.tax;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(279, 214);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 20);
            pictureBox3.TabIndex = 52;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.id__1_;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(279, 164);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 20);
            pictureBox2.TabIndex = 46;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.calendar_week;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(279, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 20);
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(818, 576);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 40);
            btnSave.TabIndex = 62;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(693, 576);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 61;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmNewLocal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 633);
            Controls.Add(lblAddEdit);
            Controls.Add(tabControl1);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmNewLocal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Local Driving License Application";
            Load += FrmNewLocal_Load;
            tabPage1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAddEdit;
        private TabPage tabPage1;
        private Button btnNext;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private Label lblCreate;
        private Label lblFees;
        private ComboBox cbClass;
        private Label lblAppDate;
        private Label label3;
        private PictureBox pictureBox4;
        private Label label2;
        private Label lblAppID;
        private Label label1;
        private Label label6;
        private Label label4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnSave;
        private ErrorProvider errorProvider1;
        private Button btnClose;
        private Controls.PeopleControls.CtrlFilterPersonInfo ctrlFilterPersonInfo1;
    }
}