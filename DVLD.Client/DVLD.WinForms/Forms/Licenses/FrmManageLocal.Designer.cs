namespace DVLD.WinForms.Forms.Licenses
{
    partial class FrmManageLocal
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
            pictureBox2 = new PictureBox();
            btnClose = new Button();
            pictureBox1 = new PictureBox();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            showLicenseToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            issueDrivingLicenseFirstTimeToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            sechduleStreetTestToolStripMenuItem = new ToolStripMenuItem();
            sechduleWrittenTestToolStripMenuItem = new ToolStripMenuItem();
            visionTestToolStripMenuItem = new ToolStripMenuItem();
            sechduleTestsToolStripMenuItem = new ToolStripMenuItem();
            btnAdd = new Button();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            deleteApplicationToolStripMenuItem = new ToolStripMenuItem();
            editApplicationToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            showApplicationDetailsToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cancelApplicationToolStripMenuItem = new ToolStripMenuItem();
            lblRecords = new Label();
            label3 = new Label();
            tbFilter = new TextBox();
            cbFilter = new ComboBox();
            label2 = new Label();
            dgvApp = new DataGridView();
            lblAddEdit = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApp).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.home__1_;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(471, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 58);
            pictureBox2.TabIndex = 77;
            pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.close;
            btnClose.Location = new Point(1075, 641);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 40);
            btnClose.TabIndex = 76;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.order_config__1_;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(471, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 196);
            pictureBox1.TabIndex = 68;
            pictureBox1.TabStop = false;
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Image = Properties.Resources.user_id_clock;
            showPersonLicenseHistoryToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(261, 38);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(258, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            showLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Image = Properties.Resources.id_search;
            showLicenseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            showLicenseToolStripMenuItem.Size = new Size(261, 38);
            showLicenseToolStripMenuItem.Text = "Show License";
            showLicenseToolStripMenuItem.Click += showLicenseToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(258, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Image = Properties.Resources.id_up;
            issueDrivingLicenseFirstTimeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new Size(261, 38);
            issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            issueDrivingLicenseFirstTimeToolStripMenuItem.Click += issueDrivingLicenseFirstTimeToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(258, 6);
            // 
            // sechduleStreetTestToolStripMenuItem
            // 
            sechduleStreetTestToolStripMenuItem.Enabled = false;
            sechduleStreetTestToolStripMenuItem.Image = Properties.Resources.cars;
            sechduleStreetTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sechduleStreetTestToolStripMenuItem.Name = "sechduleStreetTestToolStripMenuItem";
            sechduleStreetTestToolStripMenuItem.Size = new Size(203, 38);
            sechduleStreetTestToolStripMenuItem.Text = "Sechdule Street Test";
            sechduleStreetTestToolStripMenuItem.Click += sechduleStreetTestToolStripMenuItem_Click;
            // 
            // sechduleWrittenTestToolStripMenuItem
            // 
            sechduleWrittenTestToolStripMenuItem.Enabled = false;
            sechduleWrittenTestToolStripMenuItem.Image = Properties.Resources.exam;
            sechduleWrittenTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sechduleWrittenTestToolStripMenuItem.Name = "sechduleWrittenTestToolStripMenuItem";
            sechduleWrittenTestToolStripMenuItem.Size = new Size(203, 38);
            sechduleWrittenTestToolStripMenuItem.Text = "Sechdule Written Test";
            sechduleWrittenTestToolStripMenuItem.Click += sechduleWrittenTestToolStripMenuItem_Click;
            // 
            // visionTestToolStripMenuItem
            // 
            visionTestToolStripMenuItem.Image = Properties.Resources.eye;
            visionTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            visionTestToolStripMenuItem.Size = new Size(203, 38);
            visionTestToolStripMenuItem.Text = "Sechdule Vision Test";
            visionTestToolStripMenuItem.Click += visionTestToolStripMenuItem_Click;
            // 
            // sechduleTestsToolStripMenuItem
            // 
            sechduleTestsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { visionTestToolStripMenuItem, sechduleWrittenTestToolStripMenuItem, sechduleStreetTestToolStripMenuItem });
            sechduleTestsToolStripMenuItem.Image = Properties.Resources.test_clock;
            sechduleTestsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sechduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            sechduleTestsToolStripMenuItem.Size = new Size(261, 38);
            sechduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.order_add;
            btnAdd.Location = new Point(1121, 297);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(63, 40);
            btnAdd.TabIndex = 73;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(258, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(258, 6);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            deleteApplicationToolStripMenuItem.Image = Properties.Resources.delete_row;
            deleteApplicationToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            deleteApplicationToolStripMenuItem.Size = new Size(261, 38);
            deleteApplicationToolStripMenuItem.Text = "Delete Application";
            deleteApplicationToolStripMenuItem.Click += deleteApplicationToolStripMenuItem_Click;
            // 
            // editApplicationToolStripMenuItem
            // 
            editApplicationToolStripMenuItem.Image = Properties.Resources.edit;
            editApplicationToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            editApplicationToolStripMenuItem.Size = new Size(261, 38);
            editApplicationToolStripMenuItem.Text = "Edit Application";
            editApplicationToolStripMenuItem.Click += editApplicationToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(258, 6);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            showApplicationDetailsToolStripMenuItem.Image = Properties.Resources.view_details_big;
            showApplicationDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            showApplicationDetailsToolStripMenuItem.Size = new Size(261, 38);
            showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            showApplicationDetailsToolStripMenuItem.Click += showApplicationDetailsToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showApplicationDetailsToolStripMenuItem, toolStripSeparator1, editApplicationToolStripMenuItem, deleteApplicationToolStripMenuItem, toolStripSeparator2, cancelApplicationToolStripMenuItem, toolStripSeparator3, sechduleTestsToolStripMenuItem, toolStripSeparator4, issueDrivingLicenseFirstTimeToolStripMenuItem, toolStripSeparator5, showLicenseToolStripMenuItem, toolStripSeparator6, showPersonLicenseHistoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(262, 366);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            cancelApplicationToolStripMenuItem.Image = Properties.Resources.order_cancel;
            cancelApplicationToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            cancelApplicationToolStripMenuItem.Size = new Size(261, 38);
            cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            cancelApplicationToolStripMenuItem.Click += cancelApplicationToolStripMenuItem_Click;
            // 
            // lblRecords
            // 
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecords.ForeColor = Color.Firebrick;
            lblRecords.Location = new Point(122, 651);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(19, 20);
            lblRecords.TabIndex = 75;
            lblRecords.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 651);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 74;
            label3.Text = "# Records: ";
            // 
            // tbFilter
            // 
            tbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFilter.Location = new Point(290, 316);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new Size(151, 26);
            tbFilter.TabIndex = 72;
            tbFilter.Visible = false;
            tbFilter.TextChanged += tbFilter_TextChanged;
            tbFilter.KeyPress += tbFilter_KeyPress;
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(101, 314);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(171, 28);
            cbFilter.TabIndex = 71;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 317);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 70;
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
            dgvApp.Location = new Point(7, 358);
            dgvApp.Name = "dgvApp";
            dgvApp.ReadOnly = true;
            dgvApp.Size = new Size(1187, 266);
            dgvApp.TabIndex = 69;
            dgvApp.RowContextMenuStripNeeded += dgvApp_RowContextMenuStripNeeded;
            // 
            // lblAddEdit
            // 
            lblAddEdit.AutoSize = true;
            lblAddEdit.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddEdit.ForeColor = Color.Firebrick;
            lblAddEdit.Location = new Point(359, 236);
            lblAddEdit.Margin = new Padding(4, 0, 4, 0);
            lblAddEdit.Name = "lblAddEdit";
            lblAddEdit.Size = new Size(478, 33);
            lblAddEdit.TabIndex = 67;
            lblAddEdit.Text = "Local Driving License Application";
            // 
            // FrmManageLocal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 692);
            Controls.Add(pictureBox2);
            Controls.Add(btnClose);
            Controls.Add(pictureBox1);
            Controls.Add(btnAdd);
            Controls.Add(lblRecords);
            Controls.Add(label3);
            Controls.Add(tbFilter);
            Controls.Add(cbFilter);
            Controls.Add(label2);
            Controls.Add(dgvApp);
            Controls.Add(lblAddEdit);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmManageLocal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Local Driving License Application";
            Load += FrmManageLocal_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvApp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Button btnClose;
        private PictureBox pictureBox1;
        private ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem showLicenseToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem sechduleStreetTestToolStripMenuItem;
        private ToolStripMenuItem sechduleWrittenTestToolStripMenuItem;
        private ToolStripMenuItem visionTestToolStripMenuItem;
        private ToolStripMenuItem sechduleTestsToolStripMenuItem;
        private Button btnAdd;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private ToolStripMenuItem editApplicationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private Label lblRecords;
        private Label label3;
        private TextBox tbFilter;
        private ComboBox cbFilter;
        private Label label2;
        private DataGridView dgvApp;
        private Label lblAddEdit;
    }
}