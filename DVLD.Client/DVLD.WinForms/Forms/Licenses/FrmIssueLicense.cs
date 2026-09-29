using DVLD.DTOs.Applications;
using DVLD.DTOs.Drivers;
using DVLD.DTOs.LicenseClass;
using DVLD.DTOs.Licenses;
using DVLD.DTOs.LocalLicense;
using DVLD.Shared.Enums;
using DVLD.WinForms.Services;
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

namespace DVLD.WinForms.Forms.Licenses
{
    public partial class FrmIssueLicense : Form
    {
        private int _LocalId = -1;
        LocalLicenseApiService _localService = new();
        GetLocalLicenseDto _localLicense = new();
        public FrmIssueLicense(int localId)
        {
            InitializeComponent();
            _LocalId = localId;
        }

        private async void FrmIssueLicense_Load(object sender, EventArgs e)
        {
            _localLicense = await _localService.GetLocalLicenseByIdAsync(_LocalId) ?? new GetLocalLicenseDto();
            if (_localLicense == null)
            {
                MessageBox.Show($"No application with ID = {_localLicense}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            bool passed = await _localService.IsPassedAllTestsAsync(_LocalId);
            if (!passed)
            {
                MessageBox.Show($"This person should pass all tests first", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            bool activeLicense = await _localService.GetActiveLicenseAsync(_localLicense);
            if (activeLicense)
            {
                MessageBox.Show($"This person has an active license already", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            await ctrlApplicationInfo1.LoadApplicationInfo(_LocalId);
        }

        private async Task<int> IssueLicenseForFirstTime(int localId, string notes, int userId)
        {
            int driverId = -1;
            GetDriverDto? driver = new();
            GetAppDto app = await new ApplicationApiService().GetAppByIdAsync(_localLicense.AppId) ?? new GetAppDto();
            bool isDriver = await new DriverApiService().IsPersonDriverAsync(app.PersonId);
            if (!isDriver)
            {
                CreateDriverDto createDriver = new()
                {
                    PersonID = app.PersonId,
                    UserID = userId,
                };
                driver = await new DriverApiService().AddDriverAsync(createDriver);
                if (driver != null)
                    driverId = driver.DriverID;
                else
                    return -1;
            }
            else
            {
                driver = await new DriverApiService().GetDriverIdByPersonIdAsync(app.PersonId);
                if (driver != null)
                    driverId = driver.DriverID;
            }

            LicenseClassDto licenseClass = await new LicenseClassApiService().GetLicenseClassByIdAsync(_localLicense.ClassId) ?? new LicenseClassDto();
            CreateLicenseDto createLicense = new()
            {
                AppID = app.AppID,
                IsActive = true,
                ClassID = _localLicense.ClassId,
                DriverID = driverId,
                ExpiredDate = DateTime.Now.AddYears(licenseClass.Length),
                IssueReason = IssueReasonEnum.FirstTime,
                Fees = licenseClass.Fees,
                Notes = notes,
                UserID = userId
            };
            GetLicenseDto? license = await new LicenseApiService().AddLicenseAsync(createLicense);
            if (license != null)
                return license.LicenseID;
            else
                return -1;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int licenseId = await IssueLicenseForFirstTime(_localLicense.LocalId, txtNotes.Text.Trim(), CurrentUser.User!.UserId);
            if (licenseId != -1)
            {

                MessageBox.Show($"License issued successfully with License ID = {licenseId}", "Succeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
