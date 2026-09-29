namespace DVLD.WinForms.Forms.Main
{
    partial class FrmMain
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
            signOutToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            currentUserInfoToolStripMenuItem = new ToolStripMenuItem();
            accountSettingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            usersToolStripMenuItem = new ToolStripMenuItem();
            driverToolStripMenuItem = new ToolStripMenuItem();
            peopleToolStripMenuItem = new ToolStripMenuItem();
            manageTestTypesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            releasDetainedLicenseToolStripMenuItem1 = new ToolStripMenuItem();
            detainLicenseToolStripMenuItem1 = new ToolStripMenuItem();
            manageDetainedLicensesToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripMenuItem3 = new ToolStripMenuItem();
            internationalDrivingLicenseApplicationsToolStripMenuItem = new ToolStripMenuItem();
            localDrivingLicenseApplicationsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            retakeTestToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            releaseDetainedDrivingToolStripMenuItem = new ToolStripMenuItem();
            replacementForLostOrDamagedLicenseToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            renewDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            internationalLicenseToolStripMenuItem = new ToolStripMenuItem();
            localLicenseToolStripMenuItem = new ToolStripMenuItem();
            newDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            appToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Image = Properties.Resources.sign_out;
            signOutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(230, 38);
            signOutToolStripMenuItem.Text = "Sign Out";
            signOutToolStripMenuItem.Click += signOutToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Image = Properties.Resources.password;
            changePasswordToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(230, 38);
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // currentUserInfoToolStripMenuItem
            // 
            currentUserInfoToolStripMenuItem.Image = Properties.Resources.view_details_big;
            currentUserInfoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            currentUserInfoToolStripMenuItem.Size = new Size(230, 38);
            currentUserInfoToolStripMenuItem.Text = "Current User Info";
            currentUserInfoToolStripMenuItem.Click += currentUserInfoToolStripMenuItem_Click;
            // 
            // accountSettingsToolStripMenuItem
            // 
            accountSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { currentUserInfoToolStripMenuItem, changePasswordToolStripMenuItem, toolStripSeparator6, signOutToolStripMenuItem });
            accountSettingsToolStripMenuItem.Image = Properties.Resources.account_settings1;
            accountSettingsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            accountSettingsToolStripMenuItem.Size = new Size(199, 52);
            accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(227, 6);
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Image = Properties.Resources.activate_profile_config__1_;
            usersToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(111, 52);
            usersToolStripMenuItem.Text = "Users";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
            // 
            // driverToolStripMenuItem
            // 
            driverToolStripMenuItem.Image = Properties.Resources.driver;
            driverToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            driverToolStripMenuItem.Name = "driverToolStripMenuItem";
            driverToolStripMenuItem.Size = new Size(124, 52);
            driverToolStripMenuItem.Text = "Drivers";
            driverToolStripMenuItem.Click += driverToolStripMenuItem_Click;
            // 
            // peopleToolStripMenuItem
            // 
            peopleToolStripMenuItem.Image = Properties.Resources.users;
            peopleToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            peopleToolStripMenuItem.Size = new Size(123, 52);
            peopleToolStripMenuItem.Text = "People";
            peopleToolStripMenuItem.Click += peopleToolStripMenuItem_Click;
            // 
            // manageTestTypesToolStripMenuItem
            // 
            manageTestTypesToolStripMenuItem.Image = Properties.Resources.test_config;
            manageTestTypesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            manageTestTypesToolStripMenuItem.Size = new Size(298, 38);
            manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            manageTestTypesToolStripMenuItem.Click += manageTestTypesToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(295, 6);
            // 
            // releasDetainedLicenseToolStripMenuItem1
            // 
            releasDetainedLicenseToolStripMenuItem1.Image = Properties.Resources.id_unlock;
            releasDetainedLicenseToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            releasDetainedLicenseToolStripMenuItem1.Name = "releasDetainedLicenseToolStripMenuItem1";
            releasDetainedLicenseToolStripMenuItem1.Size = new Size(299, 38);
            releasDetainedLicenseToolStripMenuItem1.Text = "Releas Detained License";
            releasDetainedLicenseToolStripMenuItem1.Click += releasDetainedLicenseToolStripMenuItem1_Click;
            // 
            // detainLicenseToolStripMenuItem1
            // 
            detainLicenseToolStripMenuItem1.Image = Properties.Resources.id_lock1;
            detainLicenseToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            detainLicenseToolStripMenuItem1.Name = "detainLicenseToolStripMenuItem1";
            detainLicenseToolStripMenuItem1.Size = new Size(299, 38);
            detainLicenseToolStripMenuItem1.Text = "Detain License";
            detainLicenseToolStripMenuItem1.Click += detainLicenseToolStripMenuItem1_Click;
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            manageDetainedLicensesToolStripMenuItem.Image = Properties.Resources.id_lock1;
            manageDetainedLicensesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            manageDetainedLicensesToolStripMenuItem.Size = new Size(299, 38);
            manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            manageDetainedLicensesToolStripMenuItem.Click += manageDetainedLicensesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { manageDetainedLicensesToolStripMenuItem, detainLicenseToolStripMenuItem1, releasDetainedLicenseToolStripMenuItem1 });
            toolStripMenuItem4.Image = Properties.Resources.id_lock;
            toolStripMenuItem4.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(298, 38);
            toolStripMenuItem4.Text = "Detain Licenses";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(295, 6);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Image = Properties.Resources.order_info;
            toolStripMenuItem3.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(298, 38);
            toolStripMenuItem3.Text = "Manage Application Types";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // internationalDrivingLicenseApplicationsToolStripMenuItem
            // 
            internationalDrivingLicenseApplicationsToolStripMenuItem.Image = Properties.Resources.world;
            internationalDrivingLicenseApplicationsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            internationalDrivingLicenseApplicationsToolStripMenuItem.Name = "internationalDrivingLicenseApplicationsToolStripMenuItem";
            internationalDrivingLicenseApplicationsToolStripMenuItem.Size = new Size(409, 30);
            internationalDrivingLicenseApplicationsToolStripMenuItem.Text = "International Driving License Applications";
            internationalDrivingLicenseApplicationsToolStripMenuItem.Click += internationalDrivingLicenseApplicationsToolStripMenuItem_Click;
            // 
            // localDrivingLicenseApplicationsToolStripMenuItem
            // 
            localDrivingLicenseApplicationsToolStripMenuItem.Image = Properties.Resources.id__1_;
            localDrivingLicenseApplicationsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            localDrivingLicenseApplicationsToolStripMenuItem.Name = "localDrivingLicenseApplicationsToolStripMenuItem";
            localDrivingLicenseApplicationsToolStripMenuItem.Size = new Size(409, 30);
            localDrivingLicenseApplicationsToolStripMenuItem.Text = "Local Driving License Applications";
            localDrivingLicenseApplicationsToolStripMenuItem.Click += localDrivingLicenseApplicationsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { localDrivingLicenseApplicationsToolStripMenuItem, internationalDrivingLicenseApplicationsToolStripMenuItem });
            toolStripMenuItem2.Image = Properties.Resources.order_config;
            toolStripMenuItem2.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(298, 38);
            toolStripMenuItem2.Text = "Manage Applications";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(295, 6);
            // 
            // retakeTestToolStripMenuItem
            // 
            retakeTestToolStripMenuItem.Image = Properties.Resources.test_refresh;
            retakeTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            retakeTestToolStripMenuItem.Size = new Size(407, 30);
            retakeTestToolStripMenuItem.Text = "Retake Test";
            retakeTestToolStripMenuItem.Click += retakeTestToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(404, 6);
            // 
            // releaseDetainedDrivingToolStripMenuItem
            // 
            releaseDetainedDrivingToolStripMenuItem.Image = Properties.Resources.id_unlock;
            releaseDetainedDrivingToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            releaseDetainedDrivingToolStripMenuItem.Name = "releaseDetainedDrivingToolStripMenuItem";
            releaseDetainedDrivingToolStripMenuItem.Size = new Size(407, 30);
            releaseDetainedDrivingToolStripMenuItem.Text = "Release Detained Driving ";
            releaseDetainedDrivingToolStripMenuItem.Click += releaseDetainedDrivingToolStripMenuItem_Click;
            // 
            // replacementForLostOrDamagedLicenseToolStripMenuItem
            // 
            replacementForLostOrDamagedLicenseToolStripMenuItem.Image = Properties.Resources.id_close;
            replacementForLostOrDamagedLicenseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            replacementForLostOrDamagedLicenseToolStripMenuItem.Name = "replacementForLostOrDamagedLicenseToolStripMenuItem";
            replacementForLostOrDamagedLicenseToolStripMenuItem.Size = new Size(407, 30);
            replacementForLostOrDamagedLicenseToolStripMenuItem.Text = "Replacement for Lost or Damaged License";
            replacementForLostOrDamagedLicenseToolStripMenuItem.Click += replacementForLostOrDamagedLicenseToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(404, 6);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            renewDrivingLicenseToolStripMenuItem.Image = Properties.Resources.id_reload;
            renewDrivingLicenseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            renewDrivingLicenseToolStripMenuItem.Size = new Size(407, 30);
            renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            renewDrivingLicenseToolStripMenuItem.Click += renewDrivingLicenseToolStripMenuItem_Click;
            // 
            // internationalLicenseToolStripMenuItem
            // 
            internationalLicenseToolStripMenuItem.Image = Properties.Resources.world;
            internationalLicenseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            internationalLicenseToolStripMenuItem.Size = new Size(248, 30);
            internationalLicenseToolStripMenuItem.Text = "International License";
            internationalLicenseToolStripMenuItem.Click += internationalLicenseToolStripMenuItem_Click;
            // 
            // localLicenseToolStripMenuItem
            // 
            localLicenseToolStripMenuItem.Image = Properties.Resources.home__1_;
            localLicenseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            localLicenseToolStripMenuItem.Size = new Size(248, 30);
            localLicenseToolStripMenuItem.Text = "Local License";
            localLicenseToolStripMenuItem.Click += localLicenseToolStripMenuItem_Click;
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localLicenseToolStripMenuItem, internationalLicenseToolStripMenuItem });
            newDrivingLicenseToolStripMenuItem.Image = Properties.Resources.id_add;
            newDrivingLicenseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            newDrivingLicenseToolStripMenuItem.Size = new Size(407, 30);
            newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { newDrivingLicenseToolStripMenuItem, renewDrivingLicenseToolStripMenuItem, toolStripSeparator2, replacementForLostOrDamagedLicenseToolStripMenuItem, releaseDetainedDrivingToolStripMenuItem, toolStripSeparator1, retakeTestToolStripMenuItem });
            toolStripMenuItem1.Image = Properties.Resources.id;
            toolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(298, 38);
            toolStripMenuItem1.Text = "Driving Licenses Services";
            // 
            // appToolStripMenuItem
            // 
            appToolStripMenuItem.BackgroundImageLayout = ImageLayout.Zoom;
            appToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripSeparator5, toolStripMenuItem2, toolStripMenuItem3, toolStripSeparator4, toolStripMenuItem4, toolStripSeparator3, manageTestTypesToolStripMenuItem });
            appToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appToolStripMenuItem.Image = Properties.Resources.order__1_;
            appToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            appToolStripMenuItem.Name = "appToolStripMenuItem";
            appToolStripMenuItem.Size = new Size(159, 52);
            appToolStripMenuItem.Text = "Application";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { appToolStripMenuItem, peopleToolStripMenuItem, driverToolStripMenuItem, usersToolStripMenuItem, accountSettingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1254, 56);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 668);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem signOutToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private ToolStripMenuItem accountSettingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem driverToolStripMenuItem;
        private ToolStripMenuItem peopleToolStripMenuItem;
        private ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem releasDetainedLicenseToolStripMenuItem1;
        private ToolStripMenuItem detainLicenseToolStripMenuItem1;
        private ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem internationalDrivingLicenseApplicationsToolStripMenuItem;
        private ToolStripMenuItem localDrivingLicenseApplicationsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem retakeTestToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem releaseDetainedDrivingToolStripMenuItem;
        private ToolStripMenuItem replacementForLostOrDamagedLicenseToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private ToolStripMenuItem localLicenseToolStripMenuItem;
        private ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem appToolStripMenuItem;
        private MenuStrip menuStrip1;
    }
}