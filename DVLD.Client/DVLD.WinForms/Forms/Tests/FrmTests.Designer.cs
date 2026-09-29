namespace DVLD.WinForms.Forms.Tests
{
    partial class FrmTests
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
            dgvAppointment = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            takeTestToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            lblTitle = new Label();
            btnClose = new Button();
            lblRecords = new Label();
            label3 = new Label();
            btnAdd = new Button();
            pictureBox1 = new PictureBox();
            ctrlApplicationInfo1 = new Controls.ApplicationControls.CtrlApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvAppointment
            // 
            dgvAppointment.AllowUserToAddRows = false;
            dgvAppointment.AllowUserToDeleteRows = false;
            dgvAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointment.ContextMenuStrip = contextMenuStrip1;
            dgvAppointment.Location = new Point(16, 663);
            dgvAppointment.Name = "dgvAppointment";
            dgvAppointment.ReadOnly = true;
            dgvAppointment.Size = new Size(749, 135);
            dgvAppointment.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, takeTestToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(197, 102);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.edit;
            editToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(196, 38);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // takeTestToolStripMenuItem
            // 
            takeTestToolStripMenuItem.Image = Properties.Resources.exam;
            takeTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            takeTestToolStripMenuItem.Size = new Size(196, 38);
            takeTestToolStripMenuItem.Text = "Take Test";
            takeTestToolStripMenuItem.Click += takeTestToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 622);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 14;
            label2.Text = "Appointments:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Firebrick;
            lblTitle.Location = new Point(191, 158);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(370, 33);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "Vision Test Appointments";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(656, 812);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 19;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblRecords
            // 
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecords.ForeColor = Color.Firebrick;
            lblRecords.Location = new Point(128, 822);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(19, 20);
            lblRecords.TabIndex = 18;
            lblRecords.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 822);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 17;
            label3.Text = "# Records: ";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.calendar_add;
            btnAdd.Location = new Point(702, 612);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(63, 40);
            btnAdd.TabIndex = 15;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources.eye;
            pictureBox1.Location = new Point(276, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(201, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // ctrlApplicationInfo1
            // 
            ctrlApplicationInfo1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlApplicationInfo1.Location = new Point(0, 200);
            ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            ctrlApplicationInfo1.Size = new Size(775, 406);
            ctrlApplicationInfo1.TabIndex = 20;
            // 
            // FrmTests
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 863);
            Controls.Add(ctrlApplicationInfo1);
            Controls.Add(dgvAppointment);
            Controls.Add(label2);
            Controls.Add(lblTitle);
            Controls.Add(btnClose);
            Controls.Add(lblRecords);
            Controls.Add(label3);
            Controls.Add(btnAdd);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmTests";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Test Appointments";
            Load += FrmTests_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAppointment).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAppointment;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem takeTestToolStripMenuItem;
        private Label label2;
        private Label lblTitle;
        private Button btnClose;
        private Label lblRecords;
        private Label label3;
        private Button btnAdd;
        private PictureBox pictureBox1;
        private Controls.ApplicationControls.CtrlApplicationInfo ctrlApplicationInfo1;
    }
}