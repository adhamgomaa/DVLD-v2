namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmShowInternationalApplication
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
            tbFilter = new TextBox();
            cbFilter = new ComboBox();
            label2 = new Label();
            dgvApp = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showApplicationDetailsToolStripMenuItem = new ToolStripMenuItem();
            showLicenseToolStripMenuItem = new ToolStripMenuItem();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            comboBox1 = new ComboBox();
            btnClose = new Button();
            pictureBox2 = new PictureBox();
            btnAdd = new Button();
            pictureBox1 = new PictureBox();
            lblAddEdit = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvApp).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblRecords
            // 
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecords.ForeColor = Color.Firebrick;
            lblRecords.Location = new Point(121, 649);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(19, 20);
            lblRecords.TabIndex = 87;
            lblRecords.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 649);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 86;
            label3.Text = "# Records: ";
            // 
            // tbFilter
            // 
            tbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFilter.Location = new Point(289, 314);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new Size(151, 26);
            tbFilter.TabIndex = 84;
            tbFilter.Visible = false;
            tbFilter.TextChanged += tbFilter_TextChanged;
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(100, 312);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(171, 28);
            cbFilter.TabIndex = 83;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 315);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 82;
            label2.Text = "Filter By:";
            // 
            // dgvApp
            // 
            dgvApp.AllowUserToAddRows = false;
            dgvApp.AllowUserToDeleteRows = false;
            dgvApp.AllowUserToOrderColumns = true;
            dgvApp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvApp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApp.ContextMenuStrip = contextMenuStrip1;
            dgvApp.Location = new Point(6, 356);
            dgvApp.Name = "dgvApp";
            dgvApp.ReadOnly = true;
            dgvApp.Size = new Size(1093, 266);
            dgvApp.TabIndex = 81;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showApplicationDetailsToolStripMenuItem, showLicenseToolStripMenuItem, showPersonLicenseHistoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(242, 118);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            showApplicationDetailsToolStripMenuItem.Image = Properties.Resources.view_details_big;
            showApplicationDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            showApplicationDetailsToolStripMenuItem.Size = new Size(241, 38);
            showApplicationDetailsToolStripMenuItem.Text = "Show Person Details";
            showApplicationDetailsToolStripMenuItem.Click += showApplicationDetailsToolStripMenuItem_Click;
            // 
            // showLicenseToolStripMenuItem
            // 
            showLicenseToolStripMenuItem.Image = Properties.Resources.id_search;
            showLicenseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            showLicenseToolStripMenuItem.Size = new Size(241, 38);
            showLicenseToolStripMenuItem.Text = "Show License Details";
            showLicenseToolStripMenuItem.Click += showLicenseToolStripMenuItem_Click;
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Image = Properties.Resources.user_id_clock;
            showPersonLicenseHistoryToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(241, 38);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(289, 312);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(97, 28);
            comboBox1.TabIndex = 90;
            comboBox1.Visible = false;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(990, 639);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 88;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.world;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(421, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 58);
            pictureBox2.TabIndex = 89;
            pictureBox2.TabStop = false;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.order_add;
            btnAdd.Location = new Point(1029, 305);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(63, 40);
            btnAdd.TabIndex = 85;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.order_config__1_;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(421, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 196);
            pictureBox1.TabIndex = 80;
            pictureBox1.TabStop = false;
            // 
            // lblAddEdit
            // 
            lblAddEdit.AutoSize = true;
            lblAddEdit.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddEdit.ForeColor = Color.Firebrick;
            lblAddEdit.Location = new Point(316, 234);
            lblAddEdit.Margin = new Padding(4, 0, 4, 0);
            lblAddEdit.Name = "lblAddEdit";
            lblAddEdit.Size = new Size(468, 33);
            lblAddEdit.TabIndex = 79;
            lblAddEdit.Text = "International License Application";
            // 
            // FrmShowInternationalApplication
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 688);
            Controls.Add(lblRecords);
            Controls.Add(label3);
            Controls.Add(tbFilter);
            Controls.Add(cbFilter);
            Controls.Add(label2);
            Controls.Add(dgvApp);
            Controls.Add(comboBox1);
            Controls.Add(btnClose);
            Controls.Add(pictureBox2);
            Controls.Add(btnAdd);
            Controls.Add(pictureBox1);
            Controls.Add(lblAddEdit);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmShowInternationalApplication";
            StartPosition = FormStartPosition.CenterParent;
            Text = "List International License Application";
            Load += FrmShowInternationalApplication_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApp).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRecords;
        private Label label3;
        private TextBox tbFilter;
        private ComboBox cbFilter;
        private Label label2;
        private DataGridView dgvApp;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private ToolStripMenuItem showLicenseToolStripMenuItem;
        private ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private ComboBox comboBox1;
        private Button btnClose;
        private PictureBox pictureBox2;
        private Button btnAdd;
        private PictureBox pictureBox1;
        private Label lblAddEdit;
    }
}