using DVLD.DTOs.Applications;
using DVLD.DTOs.ApplicationTypes;
using DVLD.DTOs.InternationalLicense;
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
    public partial class FrmNewInternational : Form
    {
        private int _licenseId = -1;
        private int _InternationalLicenseId = -1;

        public FrmNewInternational()
        {
            InitializeComponent();
        }

        private async Task _loadData()
        {
            ctrlFilterDriverLicense1.txtLicenseIDFoucs();
            lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = lblAppDate.Text;
            lblExpiration.Text = DateTime.Now.AddYears(1).ToString("dd/MMM/yyyy");
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.NewInternationalLicense);
            lblFees.Text = type!.Fees.ToString();
            lblCreate.Text = CurrentUser.User!.UserName;
        }

        private async void FrmNewInternational_Load(object sender, EventArgs e)
        {
            await _loadData();
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
            lblLocalLicenseID.Text = _licenseId.ToString();
            linkLabel1.Enabled = (_licenseId != -1);
            linkLabel2.Enabled = false;
            GetLicenseDto? licenseDto = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            if (licenseDto!.ClassID != 3)
            {
                MessageBox.Show($"Selected License should be class 3, choose another one.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            int activeInternationalLicenseId = await new InternationalLicenseApiService().GetActiveLicenseIdAsync(licenseDto.DriverID);
            if (activeInternationalLicenseId != -1)
            {
                MessageBox.Show($"Person already have an active international license with id = " + activeInternationalLicenseId, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                linkLabel2.Enabled = true;
                _InternationalLicenseId = activeInternationalLicenseId;
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
        }

        public async Task SaveData()
        {
            GetLicenseDto? licenseDto = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync(licenseDto!.AppID);
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.NewInternationalLicense);
            CreateInternationalLicenseDto createLicense = new()
            {
                AppStatus = AppStatusEnum.Completed,
                StatusDate = DateTime.Now,
                IsActive = true,
                LocalLicenseID = _licenseId,
                ExpirationDate = DateTime.Now.AddYears(1),
                PersonId = app!.PersonId,
                DriverID = licenseDto.DriverID,
                Type = AppTypeEnum.NewInternationalLicense,
                UserID = CurrentUser.User!.UserId,
                Fees = type!.Fees,
            };

           
            InternationalLicenseDto? newLicense = await new InternationalLicenseApiService().AddInternationalLicenseAsync(createLicense);
            if (newLicense != null)
            {
                MessageBox.Show($"International License Issued Successfuly With ID = {newLicense.InternationalID} ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _InternationalLicenseId = newLicense.InternationalID;
                lblInterLicense.Text = newLicense.InternationalID.ToString();
                btnSave.Enabled = false;
                ctrlFilterDriverLicense1.FilterEnabled = false;
                linkLabel2.Enabled = true;
            }
            else
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                await SaveData();
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
