using DVLD.DTOs.Applications;
using DVLD.DTOs.ApplicationTypes;
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
    public partial class FrmReplacementLicense : Form
    {
        private int _licenseId = -1;
        public FrmReplacementLicense()
        {
            InitializeComponent();
        }

        private async Task _LoadData()
        {
            ctrlFilterDriverLicense1.txtLicenseIDFoucs();
            rbDamaged.Checked = true;
            lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(_GetApplicationTypeID());
            lblAppFees.Text = type!.Fees.ToString();
            lblCreate.Text = CurrentUser.User!.UserName;
        }

        private AppTypeEnum _GetApplicationTypeID()
        {
            if (rbDamaged.Checked)
                return AppTypeEnum.ReplacementForDamagedLicense;
            else
                return AppTypeEnum.ReplacementForLostLicense;
        }

        private async void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(_GetApplicationTypeID());
            lblAppFees.Text = type!.Fees.ToString();
            if (rbDamaged.Checked)
            {
                this.Text = "Replacement For Damaged License";
            }
            else
            {
                this.Text = "Replacement For Lost License";
            }
            label1.Text = this.Text;
        }

        public async Task ReplaceLicense()
        {

            GetLicenseDto? licenseDto = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync(licenseDto!.AppID);
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(_GetApplicationTypeID());
            if (!licenseDto.IsActive)
            {
                return;
            }
            CreateAppDto createApplication = new()
            {
                PersonId = app!.PersonId,
                Type = _GetApplicationTypeID(),
                AppStatus = AppStatusEnum.Completed,
                StatusDate = DateTime.Now,
                Fees = type!.Fees,
                UserId = CurrentUser.User!.UserId
            };
            GetAppDto? replaceApp = await new ApplicationApiService().AddAppAsync(createApplication);
            if (replaceApp == null)
            {
                MessageBox.Show("Faild to create the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CreateLicenseDto createLicense = new()
            {
                AppID = replaceApp.AppID,
                IsActive = true,
                ClassID = licenseDto.ClassID,
                DriverID = licenseDto.DriverID,
                ExpiredDate = licenseDto.ExpiredDate,
                IssueReason = _GetApplicationTypeID() == AppTypeEnum.ReplacementForDamagedLicense ? IssueReasonEnum.Damaged : IssueReasonEnum.Lost,
                Notes = licenseDto.Notes,
                UserID = CurrentUser.User!.UserId,
                Fees = 0
            };
            GetLicenseDto? replaceLicense = await new LicenseApiService().AddLicenseAsync(createLicense);
            if (replaceLicense != null)
            {
                await new LicenseApiService().DeactiveLicenseAsync(_licenseId);
                lblReplacedAppID.Text = replaceLicense.AppID.ToString();
                lblReplacedLicense.Text = replaceLicense.LicenseID.ToString();
                MessageBox.Show($"License Replaced Successfuly With ID = {lblReplacedLicense.Text} ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                gbReplacment.Enabled = false;
                ctrlFilterDriverLicense1.FilterEnabled = false;
                linkLabel2.Enabled = true;
            }
            else
                MessageBox.Show("Faild to Replace this License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue a Replacement the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                await ReplaceLicense();
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
            bool isDetain = await new DetainLicenseApiService().IsLicenseDetainedAsync(_licenseId);
            if (isDetain)
            {
                MessageBox.Show($"Selected License is Derained, you should Release this License First", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            GetLicenseDto? license = await new LicenseApiService().GetLicenseByIdAsync(_licenseId);
            if (!license!.IsActive)
            {
                MessageBox.Show($"Selected License isn't active", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            btnSave.Enabled = true;
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

        private async void FrmReplacementLicense_Load(object sender, EventArgs e)
        {
            await _LoadData();
        }
    }
}
