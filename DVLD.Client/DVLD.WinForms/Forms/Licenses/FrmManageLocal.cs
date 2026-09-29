using DVLD.DTOs.Applications;
using DVLD.DTOs.Licenses;
using DVLD.DTOs.LocalLicense;
using DVLD.DTOs.People;
using DVLD.Shared.Enums;
using DVLD.WinForms.Forms.Tests;
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
    public partial class FrmManageLocal : Form
    {
        LocalLicenseApiService _localLicenseService = new();
        List<LocalLicenseDto> _allLocals = new();
        public FrmManageLocal()
        {
            InitializeComponent();
        }

        private async Task _LoadLocalsData()
        {
            _allLocals = await _localLicenseService.GetAllLocalLicenseAsync() ?? [];
            dgvApp.DataSource = _allLocals;
            lblRecords.Text = dgvApp.RowCount.ToString();
        }

        private void _LoadFiltersInBox()
        {
            cbFilter.Items.Add("none");
            foreach (DataGridViewColumn Col in dgvApp.Columns)
            {
                cbFilter.Items.Add(Col.HeaderText);
            }
            cbFilter.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            string selectedColumn = cbFilter.SelectedItem?.ToString() ?? "";
            string keyword = tbFilter.Text.Trim();

            IEnumerable<LocalLicenseDto>? query = _allLocals;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvApp.DataSource = _allLocals;
                return;
            }

            if (selectedColumn == "AppDate")
            {
                if (DateTime.TryParse(keyword, out DateTime date))
                {
                    query = query?.Where(p => p.AppDate.Date == date.Date);
                }
                else
                {
                    query = [];
                }
            }
            else
            {
                query = query?.Where(p =>
                    GetColumnValue(p, selectedColumn)
                        .Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }

            dgvApp.DataSource = query?.ToList();
        }

        private static string GetColumnValue(LocalLicenseDto license, string column)
        {
            return column switch
            {
                "AppId" => license.AppId.ToString(),
                "ClassName" => license.ClassName,
                "FullName" => license.FullName,
                "NationalNo" => license.NationalNo,
                "PassedTest" => license.PassedTest.ToString(),
                "Status" => license.Status,
                _ => ""
            };
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem?.ToString() ?? "";
            if (selectedColumn == "AppId" || selectedColumn == "PassedTest")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = (cbFilter.Text != "none");
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private async void FrmManageLocal_Load(object sender, EventArgs e)
        {
            await _LoadLocalsData();
            _LoadFiltersInBox();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            FrmNewLocal newLocal = new();
            newLocal.ShowDialog();
            await _LoadLocalsData();
        }

        private async void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await _localLicenseService.CancelLocalLicenseAsync((int)dgvApp.CurrentRow.Cells[0].Value);
                if (result)
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadLocalsData();
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dgvApp_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            int LocalDrivingLicenseAppID = (int)dgvApp.CurrentRow.Cells[0].Value;
            GetLocalLicenseDto localDrivingLicenseApp = await _localLicenseService.GetLocalLicenseByIdAsync(LocalDrivingLicenseAppID) ?? new GetLocalLicenseDto();

            int totalTestsPass = (int)dgvApp.CurrentRow.Cells[5].Value;

            bool LicenseExist = await _localLicenseService.GetActiveLicenseAsync(localDrivingLicenseApp);
            GetAppDto app = await new ApplicationApiService().GetAppByIdAsync(localDrivingLicenseApp.AppId) ?? new GetAppDto();

            editApplicationToolStripMenuItem.Enabled = !LicenseExist && app.AppStatus == AppStatusEnum.New;
            deleteApplicationToolStripMenuItem.Enabled = app.AppStatus == AppStatusEnum.New;
            cancelApplicationToolStripMenuItem.Enabled = app.AppStatus == AppStatusEnum.New;

            bool PassedVisionTest = await _localLicenseService.DosePassTestTypeAsync(LocalDrivingLicenseAppID, TestTypeEnum.VisionTest);
            bool PassedWrittenTest = await _localLicenseService.DosePassTestTypeAsync(LocalDrivingLicenseAppID, TestTypeEnum.WrittenTest);
            bool PassedStreetTest = await _localLicenseService.DosePassTestTypeAsync(LocalDrivingLicenseAppID, TestTypeEnum.StreetTest);

            sechduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && app.AppStatus == AppStatusEnum.New;
            if (sechduleTestsToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                visionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must passed the vision test and not passed the written test before.
                sechduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule street test, Person must passed the vision and written test and not passed the street test before.
                sechduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (totalTestsPass == 3) && !LicenseExist;
            showLicenseToolStripMenuItem.Enabled = LicenseExist && (totalTestsPass == 3);
        }

        private async void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTests visionTest = new(TestTypeEnum.VisionTest, (int)dgvApp.CurrentRow.Cells[0].Value);
            visionTest.ShowDialog();
            await _LoadLocalsData();
        }

        private async void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTests writtenTest = new(TestTypeEnum.WrittenTest, (int)dgvApp.CurrentRow.Cells[0].Value);
            writtenTest.ShowDialog();
            await _LoadLocalsData();
        }

        private async void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTests streetTest = new(TestTypeEnum.StreetTest, (int)dgvApp.CurrentRow.Cells[0].Value);
            streetTest.ShowDialog();
            await _LoadLocalsData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIssueLicense issueLicense = new((int)dgvApp.CurrentRow.Cells[0].Value);
            issueLicense.ShowDialog();
            await _LoadLocalsData();
        }

        private async void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseId = await new LicenseApiService().GetLicenseIdByLocalIdAsync((int)dgvApp.CurrentRow.Cells[0].Value);
            FrmDriverLicenseInfo licenseInfo = new(licenseId);
            licenseInfo.ShowDialog();
        }

        private async void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licensId = await new LicenseApiService().GetLicenseIdByNationalNumberAsync((string)dgvApp.CurrentRow.Cells[2].Value);
            GetLicenseDto? license = await new LicenseApiService().GetLicenseByIdAsync(licensId);
            if (license != null)
            {
                FrmLicenseHistory licenseHistory = new(license.DriverID);
                licenseHistory.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is no License for this person", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowLocalApplication localApplication = new((int)dgvApp.CurrentRow.Cells[0].Value);
            localApplication.ShowDialog();
        }

        private async void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewLocal newLocal = new((int)dgvApp.CurrentRow.Cells[0].Value);
            newLocal.ShowDialog();
            await _LoadLocalsData();
        }

        private async void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GetLocalLicenseDto localLicense = await _localLicenseService.GetLocalLicenseByIdAsync((int)dgvApp.CurrentRow.Cells[0].Value) ?? new GetLocalLicenseDto();
                bool result = await _localLicenseService.DeleteLocalLicenseAsync(localLicense.LocalId, localLicense.AppId);
                if (result)
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadLocalsData();
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
