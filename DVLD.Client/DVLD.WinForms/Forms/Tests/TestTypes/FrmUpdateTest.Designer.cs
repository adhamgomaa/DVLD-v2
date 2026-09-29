namespace DVLD.WinForms.Forms.Tests.TestTypes
{
    partial class FrmUpdateTest
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
            txtDesc = new TextBox();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            btnSave = new Button();
            btnClose = new Button();
            lblTypeID = new Label();
            label2 = new Label();
            txtFees = new TextBox();
            txtTitle = new TextBox();
            label6 = new Label();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(176, 188);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(244, 79);
            txtDesc.TabIndex = 99;
            txtDesc.Tag = "1";
            txtDesc.Validating += txtBox_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 190);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 97;
            label3.Text = "Description:";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.cover_page;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(131, 192);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 20);
            pictureBox3.TabIndex = 98;
            pictureBox3.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(398, 368);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 40);
            btnSave.TabIndex = 96;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(273, 368);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 95;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTypeID
            // 
            lblTypeID.AutoSize = true;
            lblTypeID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTypeID.Location = new Point(127, 84);
            lblTypeID.Name = "lblTypeID";
            lblTypeID.Size = new Size(44, 20);
            lblTypeID.TabIndex = 94;
            lblTypeID.Text = "[???]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(86, 84);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 93;
            label2.Text = "ID:";
            // 
            // txtFees
            // 
            txtFees.Location = new Point(177, 299);
            txtFees.Name = "txtFees";
            txtFees.Size = new Size(115, 23);
            txtFees.TabIndex = 92;
            txtFees.Tag = "1";
            txtFees.KeyPress += txtFees_KeyPress;
            txtFees.Validating += txtBox_Validating;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(177, 135);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(244, 23);
            txtTitle.TabIndex = 91;
            txtTitle.Tag = "1";
            txtTitle.Validating += txtBox_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(65, 301);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 88;
            label6.Text = "Fees:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(71, 137);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 87;
            label4.Text = "Title:";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.tax;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(129, 304);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 20);
            pictureBox2.TabIndex = 90;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.cover_page;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(133, 138);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 20);
            pictureBox1.TabIndex = 89;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(132, 19);
            label1.Name = "label1";
            label1.Size = new Size(262, 33);
            label1.TabIndex = 86;
            label1.Text = "Update Test Type";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmUpdateTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 427);
            Controls.Add(txtDesc);
            Controls.Add(label3);
            Controls.Add(pictureBox3);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(lblTypeID);
            Controls.Add(label2);
            Controls.Add(txtFees);
            Controls.Add(txtTitle);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmUpdateTest";
            Text = "Update Test Type";
            Load += FrmUpdateTest_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDesc;
        private Label label3;
        private PictureBox pictureBox3;
        private Button btnSave;
        private Button btnClose;
        private Label lblTypeID;
        private Label label2;
        private TextBox txtFees;
        private TextBox txtTitle;
        private Label label6;
        private Label label4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label1;
        private ErrorProvider errorProvider1;
    }
}