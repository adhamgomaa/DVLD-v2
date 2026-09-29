namespace DVLD.WinForms.Forms.People
{
    partial class FrmAddEditPerson
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
            linkLabel2 = new LinkLabel();
            btnSave = new Button();
            btnClose = new Button();
            linkLabel1 = new LinkLabel();
            pbPerson = new PictureBox();
            cbCountry = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            txtPhone = new TextBox();
            txtAddres = new TextBox();
            txtEmail = new TextBox();
            pictureBox3 = new PictureBox();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            txtNationalNo = new TextBox();
            label7 = new Label();
            label3 = new Label();
            openFileDialog1 = new OpenFileDialog();
            label5 = new Label();
            errorProvider1 = new ErrorProvider(components);
            label2 = new Label();
            panel1 = new Panel();
            txtLast = new TextBox();
            txtThird = new TextBox();
            txtSecond = new TextBox();
            txtFirst = new TextBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            label18 = new Label();
            label16 = new Label();
            label14 = new Label();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pbGendor = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label12 = new Label();
            label10 = new Label();
            label8 = new Label();
            label6 = new Label();
            label4 = new Label();
            lblAddEdit = new Label();
            lblPersonId = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPerson).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGendor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(756, 312);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(86, 15);
            linkLabel2.TabIndex = 54;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Remove Image";
            linkLabel2.Visible = false;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(607, 338);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 40);
            btnSave.TabIndex = 53;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(483, 338);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 52;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(774, 269);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(59, 15);
            linkLabel1.TabIndex = 51;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Set Image";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pbPerson
            // 
            pbPerson.BackgroundImageLayout = ImageLayout.None;
            pbPerson.Image = Properties.Resources.Male_512;
            pbPerson.Location = new Point(731, 92);
            pbPerson.Name = "pbPerson";
            pbPerson.Size = new Size(167, 158);
            pbPerson.SizeMode = PictureBoxSizeMode.Zoom;
            pbPerson.TabIndex = 50;
            pbPerson.TabStop = false;
            // 
            // cbCountry
            // 
            cbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountry.FormattingEnabled = true;
            cbCountry.Location = new Point(555, 182);
            cbCountry.Name = "cbCountry";
            cbCountry.Size = new Size(161, 23);
            cbCountry.TabIndex = 49;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(555, 92);
            dateTimePicker1.MaxDate = new DateTime(2025, 7, 1, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(1950, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(161, 23);
            dateTimePicker1.TabIndex = 48;
            dateTimePicker1.Value = new DateTime(2007, 1, 1, 0, 0, 0, 0);
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(555, 137);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(161, 23);
            txtPhone.TabIndex = 47;
            txtPhone.Tag = "1";
            txtPhone.Validating += txtBox_Validating;
            // 
            // txtAddres
            // 
            txtAddres.Location = new Point(185, 227);
            txtAddres.Multiline = true;
            txtAddres.Name = "txtAddres";
            txtAddres.Size = new Size(531, 105);
            txtAddres.TabIndex = 46;
            txtAddres.Tag = "1";
            txtAddres.Validating += txtBox_Validating;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(185, 182);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(167, 23);
            txtEmail.TabIndex = 45;
            txtEmail.Tag = "1";
            txtEmail.Validating += txtBox_Validating;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.user_female;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(250, 141);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 20);
            pictureBox3.TabIndex = 44;
            pictureBox3.TabStop = false;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(296, 139);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(63, 19);
            rbFemale.TabIndex = 43;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Checked = true;
            rbMale.Location = new Point(173, 139);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(51, 19);
            rbMale.TabIndex = 6;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += rbMale_CheckedChanged;
            // 
            // txtNationalNo
            // 
            txtNationalNo.Location = new Point(185, 92);
            txtNationalNo.Name = "txtNationalNo";
            txtNationalNo.Size = new Size(167, 23);
            txtNationalNo.TabIndex = 42;
            txtNationalNo.Tag = "1";
            txtNationalNo.Validating += txtBox_Validating;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(794, 24);
            label7.Name = "label7";
            label7.Size = new Size(40, 20);
            label7.TabIndex = 41;
            label7.Text = "Last";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(418, 24);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 39;
            label3.Text = "Second";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(610, 24);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 40;
            label5.Text = "Third";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(248, 24);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 38;
            label2.Text = "First";
            // 
            // panel1
            // 
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(pbPerson);
            panel1.Controls.Add(cbCountry);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(txtAddres);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(rbFemale);
            panel1.Controls.Add(rbMale);
            panel1.Controls.Add(txtNationalNo);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtLast);
            panel1.Controls.Add(txtThird);
            panel1.Controls.Add(txtSecond);
            panel1.Controls.Add(txtFirst);
            panel1.Controls.Add(pictureBox8);
            panel1.Controls.Add(pictureBox7);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pbGendor);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(6, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(917, 395);
            panel1.TabIndex = 9;
            // 
            // txtLast
            // 
            txtLast.Location = new Point(731, 47);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(167, 23);
            txtLast.TabIndex = 37;
            txtLast.Tag = "1";
            txtLast.Validating += txtBox_Validating;
            // 
            // txtThird
            // 
            txtThird.Location = new Point(549, 47);
            txtThird.Name = "txtThird";
            txtThird.Size = new Size(167, 23);
            txtThird.TabIndex = 36;
            // 
            // txtSecond
            // 
            txtSecond.Location = new Point(367, 47);
            txtSecond.Name = "txtSecond";
            txtSecond.Size = new Size(167, 23);
            txtSecond.TabIndex = 35;
            txtSecond.Tag = "1";
            txtSecond.Validating += txtBox_Validating;
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(185, 47);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(167, 23);
            txtFirst.TabIndex = 34;
            txtFirst.Tag = "1";
            txtFirst.Validating += txtBox_Validating;
            // 
            // pictureBox8
            // 
            pictureBox8.BackgroundImage = Properties.Resources.world_north_america;
            pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox8.Location = new Point(519, 187);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(30, 20);
            pictureBox8.TabIndex = 33;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackgroundImage = Properties.Resources.phone;
            pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox7.Location = new Point(519, 140);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(30, 20);
            pictureBox7.TabIndex = 32;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = Properties.Resources.calendar_week;
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.Location = new Point(519, 96);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 20);
            pictureBox6.TabIndex = 31;
            pictureBox6.TabStop = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(391, 185);
            label18.Name = "label18";
            label18.Size = new Size(76, 20);
            label18.TabIndex = 30;
            label18.Text = "Country:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(391, 140);
            label16.Name = "label16";
            label16.Size = new Size(65, 20);
            label16.TabIndex = 29;
            label16.Text = "Phone:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(391, 95);
            label14.Name = "label14";
            label14.Size = new Size(120, 20);
            label14.TabIndex = 28;
            label14.Text = "Date Of Birth:";
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = Properties.Resources.home;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(127, 230);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 20);
            pictureBox5.TabIndex = 27;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.address;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(127, 185);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 20);
            pictureBox4.TabIndex = 26;
            pictureBox4.TabStop = false;
            // 
            // pbGendor
            // 
            pbGendor.BackgroundImage = Properties.Resources.patient_boy__1_;
            pbGendor.BackgroundImageLayout = ImageLayout.Zoom;
            pbGendor.Location = new Point(127, 140);
            pbGendor.Name = "pbGendor";
            pbGendor.Size = new Size(30, 20);
            pbGendor.TabIndex = 25;
            pbGendor.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.personal_card;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(127, 95);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 20);
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.user;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(127, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 20);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(8, 230);
            label12.Name = "label12";
            label12.Size = new Size(80, 20);
            label12.TabIndex = 15;
            label12.Text = "Address:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(8, 185);
            label10.Name = "label10";
            label10.Size = new Size(58, 20);
            label10.TabIndex = 14;
            label10.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(8, 140);
            label8.Name = "label8";
            label8.Size = new Size(74, 20);
            label8.TabIndex = 13;
            label8.Text = "Gendor:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(8, 95);
            label6.Name = "label6";
            label6.Size = new Size(112, 20);
            label6.TabIndex = 12;
            label6.Text = "National No.:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(8, 50);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 11;
            label4.Text = "Name:";
            // 
            // lblAddEdit
            // 
            lblAddEdit.AutoSize = true;
            lblAddEdit.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddEdit.ForeColor = Color.Firebrick;
            lblAddEdit.Location = new Point(389, 7);
            lblAddEdit.Margin = new Padding(4, 0, 4, 0);
            lblAddEdit.Name = "lblAddEdit";
            lblAddEdit.Size = new Size(176, 33);
            lblAddEdit.TabIndex = 6;
            lblAddEdit.Text = "Add Person";
            // 
            // lblPersonId
            // 
            lblPersonId.AutoSize = true;
            lblPersonId.Location = new Point(128, 58);
            lblPersonId.Name = "lblPersonId";
            lblPersonId.Size = new Size(29, 15);
            lblPersonId.TabIndex = 8;
            lblPersonId.Text = "N/A";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 58);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 7;
            label1.Text = "Person ID:";
            // 
            // FrmAddEditPerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 500);
            Controls.Add(panel1);
            Controls.Add(lblAddEdit);
            Controls.Add(lblPersonId);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmAddEditPerson";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit Person";
            Load += FrmAddEditPerson_Load;
            ((System.ComponentModel.ISupportInitialize)pbPerson).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGendor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkLabel2;
        private Button btnSave;
        private Button btnClose;
        private LinkLabel linkLabel1;
        private PictureBox pbPerson;
        private ComboBox cbCountry;
        private DateTimePicker dateTimePicker1;
        private TextBox txtPhone;
        private TextBox txtAddres;
        private TextBox txtEmail;
        private PictureBox pictureBox3;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private TextBox txtNationalNo;
        private Label label7;
        private Label label3;
        private OpenFileDialog openFileDialog1;
        private Label label5;
        private ErrorProvider errorProvider1;
        private Panel panel1;
        private Label label2;
        private TextBox txtLast;
        private TextBox txtThird;
        private TextBox txtSecond;
        private TextBox txtFirst;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private Label label18;
        private Label label16;
        private Label label14;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pbGendor;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label12;
        private Label label10;
        private Label label8;
        private Label label6;
        private Label label4;
        private Label lblAddEdit;
        private Label lblPersonId;
        private Label label1;
    }
}