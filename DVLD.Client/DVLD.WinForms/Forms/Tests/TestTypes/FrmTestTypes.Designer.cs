namespace DVLD.WinForms.Forms.Tests.TestTypes
{
    partial class FrmTestTypes
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
            lblRecords = new Label();
            label3 = new Label();
            dgvTypes = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editAplicationTypesToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            btnClose = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvTypes).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblRecords
            // 
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecords.ForeColor = Color.Firebrick;
            lblRecords.Location = new Point(126, 525);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(19, 20);
            lblRecords.TabIndex = 30;
            lblRecords.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 525);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 29;
            label3.Text = "# Records: ";
            // 
            // dgvTypes
            // 
            dgvTypes.AllowUserToAddRows = false;
            dgvTypes.AllowUserToDeleteRows = false;
            dgvTypes.AllowUserToOrderColumns = true;
            dgvTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTypes.ContextMenuStrip = contextMenuStrip1;
            dgvTypes.Location = new Point(12, 268);
            dgvTypes.Name = "dgvTypes";
            dgvTypes.ReadOnly = true;
            dgvTypes.Size = new Size(799, 226);
            dgvTypes.TabIndex = 28;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editAplicationTypesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(197, 64);
            // 
            // editAplicationTypesToolStripMenuItem
            // 
            editAplicationTypesToolStripMenuItem.Image = Properties.Resources.edit;
            editAplicationTypesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editAplicationTypesToolStripMenuItem.Name = "editAplicationTypesToolStripMenuItem";
            editAplicationTypesToolStripMenuItem.Size = new Size(196, 38);
            editAplicationTypesToolStripMenuItem.Text = "Edit Test Types";
            editAplicationTypesToolStripMenuItem.Click += editAplicationTypesToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(267, 217);
            label1.Name = "label1";
            label1.Size = new Size(289, 33);
            label1.TabIndex = 26;
            label1.Text = "Manage Test Types";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(699, 515);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 31;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.test_config;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(284, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 176);
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // FrmTestTypes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 570);
            Controls.Add(lblRecords);
            Controls.Add(label3);
            Controls.Add(dgvTypes);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmTestTypes";
            Text = "List Test Types";
            Load += FrmTestTypes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTypes).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRecords;
        private Label label3;
        private DataGridView dgvTypes;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editAplicationTypesToolStripMenuItem;
        private Label label1;
        private Button btnClose;
        private PictureBox pictureBox1;
    }
}