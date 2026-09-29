namespace DVLD.WinForms.Forms.Controls.LicensesControls
{
    partial class CtrlLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvLocal = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showLicenseInfoToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lblRecordsLocal = new Label();
            label3 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            lblRecordsInt = new Label();
            dgvInt = new DataGridView();
            contextMenuStrip2 = new ContextMenuStrip(components);
            showInternationlLicenseInfoToolStripMenuItem = new ToolStripMenuItem();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLocal).BeginInit();
            contextMenuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInt).BeginInit();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLocal
            // 
            dgvLocal.AllowUserToAddRows = false;
            dgvLocal.AllowUserToDeleteRows = false;
            dgvLocal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvLocal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocal.ContextMenuStrip = contextMenuStrip1;
            dgvLocal.Location = new Point(25, 55);
            dgvLocal.Name = "dgvLocal";
            dgvLocal.ReadOnly = true;
            dgvLocal.Size = new Size(936, 150);
            dgvLocal.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showLicenseInfoToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(186, 42);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            showLicenseInfoToolStripMenuItem.Image = Properties.Resources.id_search;
            showLicenseInfoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            showLicenseInfoToolStripMenuItem.Size = new Size(196, 38);
            showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            showLicenseInfoToolStripMenuItem.Click += showLicenseInfoToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tabControl1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(5, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1015, 318);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(15, 37);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(997, 279);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblRecordsLocal);
            tabPage1.Controls.Add(dgvLocal);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(989, 246);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Local";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblRecordsLocal
            // 
            lblRecordsLocal.AutoSize = true;
            lblRecordsLocal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordsLocal.ForeColor = Color.Firebrick;
            lblRecordsLocal.Location = new Point(141, 219);
            lblRecordsLocal.Name = "lblRecordsLocal";
            lblRecordsLocal.Size = new Size(19, 20);
            lblRecordsLocal.TabIndex = 20;
            lblRecordsLocal.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 219);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 19;
            label3.Text = "# Records: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 26);
            label1.Name = "label1";
            label1.Size = new Size(194, 20);
            label1.TabIndex = 0;
            label1.Text = "Local Licenses History:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lblRecordsInt);
            tabPage2.Controls.Add(dgvInt);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label5);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(989, 246);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "International";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblRecordsInt
            // 
            lblRecordsInt.AutoSize = true;
            lblRecordsInt.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordsInt.ForeColor = Color.Firebrick;
            lblRecordsInt.Location = new Point(144, 218);
            lblRecordsInt.Name = "lblRecordsInt";
            lblRecordsInt.Size = new Size(19, 20);
            lblRecordsInt.TabIndex = 24;
            lblRecordsInt.Text = "0";
            // 
            // dgvInt
            // 
            dgvInt.AllowUserToAddRows = false;
            dgvInt.AllowUserToDeleteRows = false;
            dgvInt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvInt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInt.ContextMenuStrip = contextMenuStrip2;
            dgvInt.Location = new Point(28, 53);
            dgvInt.Name = "dgvInt";
            dgvInt.ReadOnly = true;
            dgvInt.Size = new Size(936, 150);
            dgvInt.TabIndex = 22;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { showInternationlLicenseInfoToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(250, 64);
            // 
            // showInternationlLicenseInfoToolStripMenuItem
            // 
            showInternationlLicenseInfoToolStripMenuItem.Image = Properties.Resources.id_search;
            showInternationlLicenseInfoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showInternationlLicenseInfoToolStripMenuItem.Name = "showInternationlLicenseInfoToolStripMenuItem";
            showInternationlLicenseInfoToolStripMenuItem.Size = new Size(249, 38);
            showInternationlLicenseInfoToolStripMenuItem.Text = "Show Internationl License Info";
            showInternationlLicenseInfoToolStripMenuItem.Click += showInternationlLicenseInfoToolStripMenuItem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(38, 218);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 23;
            label4.Text = "# Records: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 23);
            label5.Name = "label5";
            label5.Size = new Size(253, 20);
            label5.TabIndex = 21;
            label5.Text = "International Licenses History:";
            // 
            // CtrlLicense
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CtrlLicense";
            Size = new Size(1025, 325);
            ((System.ComponentModel.ISupportInitialize)dgvLocal).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInt).EndInit();
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLocal;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private GroupBox groupBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label lblRecordsLocal;
        private Label label3;
        private Label label1;
        private TabPage tabPage2;
        private Label lblRecordsInt;
        private DataGridView dgvInt;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem showInternationlLicenseInfoToolStripMenuItem;
        private Label label4;
        private Label label5;
    }
}
