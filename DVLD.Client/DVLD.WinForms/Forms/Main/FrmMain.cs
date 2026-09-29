using DVLD.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.WinForms.Forms.People;
using DVLD.WinForms.Forms.Drivers;
using DVLD.WinForms.Forms.Users;
using DVLD.WinForms.Forms.Licenses;
using DVLD.WinForms.Forms.Apps.ApplicationTypes;
using DVLD.WinForms.Forms.Tests.TestTypes;
using DVLD.DTOs.Users;

namespace DVLD.WinForms.Forms.Main
{
    public partial class FrmMain : Form
    {
        LoginUserDto currentUser = CurrentUser.User!;
        public bool Logout { get; set; } = false;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            Logout = true;
            this.Close();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListPeople listPeople = new()
            {
                MdiParent = this
            };
            listPeople.Show();
        }

        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListDrivers listDrivers = new()
            {
                MdiParent = this
            };
            listDrivers.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListUsers listUsers = new()
            {
                MdiParent = this
            };
            listUsers.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserInfo userInfo = new(currentUser.UserId)
            {
                MdiParent = this
            };
            userInfo.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword changePassword = new(currentUser.UserId)
            {
                MdiParent = this
            };
            changePassword.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewLocal newLocal = new()
            {
                MdiParent = this
            };
            newLocal.Show();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewInternational newInternational = new()
            {
                MdiParent = this
            };
            newInternational.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRenewLicense renewLicense = new()
            {
                MdiParent = this
            };
            renewLicense.Show();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReplacementLicense replacementLicense = new()
            {
                MdiParent = this
            };
            replacementLicense.Show();
        }

        private void releaseDetainedDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReleaseLicense releaseLicense = new()
            {
                MdiParent = this
            };
            releaseLicense.Show();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageLocal manageLocal = new()
            {
                MdiParent = this
            };
            manageLocal.Show();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageLocal manageLocal = new()
            {
                MdiParent = this
            };
            manageLocal.Show();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowInternationalApplication internationalApplication = new()
            {
                MdiParent = this
            };
            internationalApplication.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmAppsTypes appsTypes = new()
            {
                MdiParent = this
            };
            appsTypes.Show();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListDetainedLicense detainedLicense = new()
            {
                MdiParent = this
            };
            detainedLicense.Show();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDetainLicense detainLicense = new()
            {
                MdiParent = this
            };
            detainLicense.Show();
        }

        private void releasDetainedLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReleaseLicense releaseLicense = new()
            {
                MdiParent = this
            };
            releaseLicense.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTestTypes testTypes = new()
            {
                MdiParent = this
            };
            testTypes.Show();
        }
    }
}
