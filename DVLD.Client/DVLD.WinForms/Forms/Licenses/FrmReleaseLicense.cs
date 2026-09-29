using DVLD.DTOs.Applications;
using DVLD.DTOs.ApplicationTypes;
using DVLD.DTOs.DetainLicense;
using DVLD.DTOs.Drivers;
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
    public partial class FrmReleaseLicense : Form
    {
        private int _licenseId = -1;
        GetDetainDto detainLicense = new();

        public FrmReleaseLicense()
        {
            InitializeComponent();
        }

        public FrmReleaseLicense(int licenseId)
        {
            InitializeComponent();
            _licenseId = licenseId;
        }

        private async Task LoadData()
        {
            await ctrlFilterDriverLicense1.LoadLicenseInfo(_licenseId);
            ctrlFilterDriverLicense1.FilterEnabled = false;
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
            bool result = await new DetainLicenseApiService().IsLicenseDetainedAsync(_licenseId);
            if (!result)
            {
                MessageBox.Show($"Selected License isn't Detained, choose another one.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            GetDetainDto detainLicense = await new DetainLicenseApiService().GetDetainLicenseByIdAsync(_licenseId) ?? new GetDetainDto();
            lblLicense.Text = _licenseId.ToString();
            lblCreate.Text = detainLicense.UserID.ToString();
            lblDetainID.Text = detainLicense.DetainID.ToString();
            lblFees.Text = detainLicense.Fees.ToString();
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.ReleaseDetainedDrivingLicense);
            lblAppFees.Text = type!.Fees.ToString();
            lblTotalFees.Text = Convert.ToString(Convert.ToDecimal(lblFees.Text) + Convert.ToDecimal(lblAppFees.Text));
            lblDetainDate.Text = detainLicense.DetainDate.ToString("dd/MMM/yyyy");
            linkLabel1.Enabled = (_licenseId != -1);
            btnSave.Enabled = true;
        }

        private async void FrmReleaseLicense_Load(object sender, EventArgs e)
        {
            if (_licenseId != -1)
                await LoadData();
        }

        public async Task SaveData()
        {
            GetLicenseDto? licenseDto = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync(licenseDto!.AppID);
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.ReleaseDetainedDrivingLicense);
            ReleaseLicenseDto? releaseLicense = new()
            {
                PersonId = app!.PersonId,
                AppStatus = AppStatusEnum.Completed,
                Type = AppTypeEnum.ReleaseDetainedDrivingLicense,
                StatusDate = DateTime.Now,
                ReleaseByUserId = CurrentUser.User!.UserId,
                Fees = type!.Fees
            };
            releaseLicense = await new DetainLicenseApiService().ReleaseLicenseAsync(_licenseId, releaseLicense);
            if (releaseLicense != null)
            {
                lblReleaseId.Text = releaseLicense!.ReleaseAppId.ToString();
                MessageBox.Show("License Relesed Successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                ctrlFilterDriverLicense1.FilterEnabled = false;
                linkLabel2.Enabled = true;
            }
            else
                MessageBox.Show("Faild to realese the detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Release this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                await SaveData();
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetLicenseDto? licenseDto = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            FrmLicenseHistory licenseHistory = new(licenseDto!.DriverID);
            licenseHistory.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDriverLicenseInfo licenseInfo = new(ctrlFilterDriverLicense1.LicenseID);
            licenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
