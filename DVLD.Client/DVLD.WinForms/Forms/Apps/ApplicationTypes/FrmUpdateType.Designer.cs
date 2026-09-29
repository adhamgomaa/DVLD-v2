namespace DVLD.WinForms.Forms.Apps.ApplicationTypes
{
    partial class FrmUpdateType
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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.diskette;
            btnSave.Location = new Point(294, 261);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 40);
            btnSave.TabIndex = 82;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(169, 261);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 81;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTypeID
            // 
            lblTypeID.AutoSize = true;
            lblTypeID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTypeID.Location = new Point(78, 93);
            lblTypeID.Name = "lblTypeID";
            lblTypeID.Size = new Size(44, 20);
            lblTypeID.TabIndex = 80;
            lblTypeID.Text = "[???]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 93);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 79;
            label2.Text = "ID:";
            // 
            // txtFees
            // 
            txtFees.Location = new Point(142, 187);
            txtFees.Name = "txtFees";
            txtFees.Size = new Size(115, 23);
            txtFees.TabIndex = 78;
            txtFees.Tag = "1";
            txtFees.KeyPress += txtFees_KeyPress;
            txtFees.Validating += txtBox_Validating;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(142, 140);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(244, 23);
            txtTitle.TabIndex = 77;
            txtTitle.Tag = "1";
            txtTitle.Validating += txtBox_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 191);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 74;
            label6.Text = "Fees:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(18, 142);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 73;
            label4.Text = "Title:";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.tax;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(84, 192);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 20);
            pictureBox2.TabIndex = 76;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.cover_page;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(84, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 20);
            pictureBox1.TabIndex = 75;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(30, 28);
            label1.Name = "label1";
            label1.Size = new Size(355, 33);
            label1.TabIndex = 72;
            label1.Text = "Update Application Type";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmUpdateType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 328);
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
            Name = "FrmUpdateType";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Application Type";
            Load += FrmUpdateType_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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