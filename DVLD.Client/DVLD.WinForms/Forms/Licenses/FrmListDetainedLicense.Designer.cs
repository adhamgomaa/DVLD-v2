namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmListDetainedLicense
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
            btnRelease = new Button();
            label3 = new Label();
            tbFilter = new TextBox();
            cbFilter = new ComboBox();
            label2 = new Label();
            dgvDetain = new DataGridView();
            contextMenuStrip2 = new ContextMenuStrip(components);
            showDetailsToolStripMenuItem = new ToolStripMenuItem();
            addPersonToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem1 = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            btnClose = new Button();
            btnDetain = new Button();
            label1 = new Label();
            lblRecords = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetain).BeginInit();
            contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnRelease
            // 
            btnRelease.Image = Properties.Resources.id_unlock;
            btnRelease.Location = new Point(1035, 290);
            btnRelease.Name = "btnRelease";
            btnRelease.Size = new Size(63, 40);
            btnRelease.TabIndex = 44;
            btnRelease.UseVisualStyleBackColor = true;
            btnRelease.Click += btnRelease_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 581);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 40;
            label3.Text = "# Records: ";
            // 
            // tbFilter
            // 
            tbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFilter.Location = new Point(298, 297);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new Size(151, 26);
            tbFilter.TabIndex = 38;
            tbFilter.Visible = false;
            tbFilter.TextChanged += tbFilter_TextChanged;
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(109, 295);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(171, 28);
            cbFilter.TabIndex = 37;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 298);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 36;
            label2.Text = "Filter By:";
            // 
            // dgvDetain
            // 
            dgvDetain.AllowUserToAddRows = false;
            dgvDetain.AllowUserToDeleteRows = false;
            dgvDetain.AllowUserToOrderColumns = true;
            dgvDetain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvDetain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetain.ContextMenuStrip = contextMenuStrip2;
            dgvDetain.Location = new Point(12, 344);
            dgvDetain.Name = "dgvDetain";
            dgvDetain.ReadOnly = true;
            dgvDetain.Size = new Size(1174, 220);
            dgvDetain.TabIndex = 35;
            dgvDetain.RowContextMenuStripNeeded += dgvDetain_RowContextMenuStripNeeded;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { showDetailsToolStripMenuItem, addPersonToolStripMenuItem, editToolStripMenuItem, toolStripSeparator1, toolStripMenuItem1 });
            contextMenuStrip2.Name = "contextMenuStrip1";
            contextMenuStrip2.Size = new Size(242, 162);
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Image = Properties.Resources.view_details_big;
            showDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(241, 38);
            showDetailsToolStripMenuItem.Text = "Show Person Details";
            showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click;
            // 
            // addPersonToolStripMenuItem
            // 
            addPersonToolStripMenuItem.Image = Properties.Resources.id_search;
            addPersonToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addPersonToolStripMenuItem.Name = "addPersonToolStripMenuItem";
            addPersonToolStripMenuItem.Size = new Size(241, 38);
            addPersonToolStripMenuItem.Text = "Show License Details";
            addPersonToolStripMenuItem.Click += addPersonToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.user_id_clock;
            editToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(241, 38);
            editToolStripMenuItem.Text = "Show Person License History";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(238, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Image = Properties.Resources.id_unlock;
            toolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(241, 38);
            toolStripMenuItem1.Text = "Release Detained License";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.id_lock;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(511, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(176, 164);
            pictureBox1.TabIndex = 33;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(298, 295);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(97, 28);
            comboBox1.TabIndex = 43;
            comboBox1.Visible = false;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(1072, 570);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 42;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDetain
            // 
            btnDetain.Image = Properties.Resources.id_lock;
            btnDetain.Location = new Point(1118, 290);
            btnDetain.Name = "btnDetain";
            btnDetain.Size = new Size(63, 40);
            btnDetain.TabIndex = 39;
            btnDetain.UseVisualStyleBackColor = true;
            btnDetain.Click += btnDetain_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(434, 203);
            label1.Name = "label1";
            label1.Size = new Size(331, 33);
            label1.TabIndex = 34;
            label1.Text = "List Detained Licenses";
            // 
            // lblRecords
            // 
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecords.ForeColor = Color.Firebrick;
            lblRecords.Location = new Point(138, 581);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(19, 20);
            lblRecords.TabIndex = 41;
            lblRecords.Text = "0";
            // 
            // FrmListDetainedLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 624);
            Controls.Add(btnRelease);
            Controls.Add(label3);
            Controls.Add(tbFilter);
            Controls.Add(cbFilter);
            Controls.Add(label2);
            Controls.Add(dgvDetain);
            Controls.Add(pictureBox1);
            Controls.Add(comboBox1);
            Controls.Add(btnClose);
            Controls.Add(btnDetain);
            Controls.Add(label1);
            Controls.Add(lblRecords);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmListDetainedLicense";
            StartPosition = FormStartPosition.CenterParent;
            Text = "List Detained License";
            Load += FrmListDetainedLicense_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetain).EndInit();
            contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRelease;
        private Label label3;
        private TextBox tbFilter;
        private ComboBox cbFilter;
        private Label label2;
        private DataGridView dgvDetain;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem showDetailsToolStripMenuItem;
        private ToolStripMenuItem addPersonToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem1;
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private Button btnClose;
        private Button btnDetain;
        private Label label1;
        private Label lblRecords;
    }
}