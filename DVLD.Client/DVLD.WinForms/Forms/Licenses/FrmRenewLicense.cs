using DVLD.DTOs.Applications;
using DVLD.DTOs.ApplicationTypes;
using DVLD.DTOs.DetainLicense;
using DVLD.DTOs.LicenseClass;
using DVLD.DTOs.Licenses;
using DVLD.Shared.Enums;
using DVLD.WinForms.Helpers;
using DVLD.WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Forms.Licenses
{
    public partial class FrmRenewLicense : Form
    {
        private int _licenseId = -1;
        public FrmRenewLicense()
        {
            InitializeComponent();
        }

        private async Task _LoadData()
        {
            ctrlFilterDriverLicense1.txtLicenseIDFoucs();
            lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = lblAppDate.Text;
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.RenewDrivingLicense);
            lblAppFees.Text = type!.Fees.ToString();
            lblCreate.Text = CurrentUser.User!.UserName;
        }

        private async void FrmRenewLicense_Load(object sender, EventArgs e)
        {
            await _LoadData();
        }

        private async void ctrlFilterDriverLicense1_OnLicenseSelected(int obj)
        {
            _licenseId = obj;
            if (_licenseId == -1)
            {
                MessageBox.Show($"Selected License isn't found", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            lblOldLicenseID.Text = _licenseId.ToString();
            linkLabel1.Enabled = (_licenseId != -1);
            GetLicenseDto? license = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            LicenseClassDto? licenseClass = await new LicenseClassApiService().GetLicenseClassByIdAsync(license!.ClassID);
            int validityLength = licenseClass!.Length;
            lblExpiration.Text = DateTime.Now.AddYears(validityLength).ToString("dd/MMM/yyyy");
            lblLicenseFees.Text = licenseClass.Fees.ToString();
            lblFees.Text = Convert.ToString(Convert.ToDecimal(lblLicenseFees.Text) + Convert.ToDecimal(lblAppFees.Text));

            if (license.ExpiredDate > DateTime.Now)
            {
                MessageBox.Show($"Selected License isn't yet expired, it will expire on {license.ExpiredDate.ToString("dd/MMM/yyyy")}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (!license.IsActive)
            {
                MessageBox.Show($"Selected License isn't active", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            btnSave.Enabled = true;
        }

        public async Task RenewLicense()
        {

            GetLicenseDto? licenseDto = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync(licenseDto!.AppID);
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.RenewDrivingLicense);
            LicenseClassDto? licenseClass = await new LicenseClassApiService().GetLicenseClassByIdAsync(licenseDto.ClassID);
            if (!licenseDto.IsActive || licenseDto.ExpiredDate > DateTime.Now)
            {
                return;
            }
            CreateAppDto createApplication = new()
            {
                PersonId = app!.PersonId,
                Type = AppTypeEnum.RenewDrivingLicense,
                AppStatus = AppStatusEnum.Completed,
                StatusDate = DateTime.Now,
                Fees = type!.Fees,
                UserId = CurrentUser.User!.UserId
            };
            GetAppDto? renewApp = await new ApplicationApiService().AddAppAsync(createApplication);
            if (renewApp == null)
            {
                MessageBox.Show("Faild to create the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CreateLicenseDto createLicense = new()
            {
                AppID = renewApp.AppID,
                IsActive = true,
                ClassID = licenseDto.ClassID,
                DriverID = licenseDto.DriverID,
                ExpiredDate = DateTime.Now.AddYears(licenseClass!.Length),
                IssueReason = IssueReasonEnum.Renew,
                Notes = txtNotes.Text.Trim(),
                UserID = CurrentUser.User!.UserId,
                Fees = licenseClass.Fees
            };
            GetLicenseDto? newLicense = await new LicenseApiService().AddLicenseAsync(createLicense);
            if (newLicense != null)
            {
                await new LicenseApiService().DeactiveLicenseAsync(_licenseId);
                lblRenewAppID.Text = newLicense.AppID.ToString();
                lblRenewLicense.Text = newLicense.LicenseID.ToString();
                MessageBox.Show($"License Renewd Successfuly With ID = {lblRenewLicense.Text} ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                ctrlFilterDriverLicense1.FilterEnabled = false;
                linkLabel2.Enabled = true;
            }
            else
                MessageBox.Show("Faild to renew this License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                await RenewLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDriverLicenseInfo licenseInfo = new(ctrlFilterDriverLicense1.LicenseID);
            licenseInfo.ShowDialog();
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetLicenseDto? licenseDto = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            FrmLicenseHistory licenseHistory = new(licenseDto!.DriverID);
            licenseHistory.ShowDialog();
        }
    }
}
