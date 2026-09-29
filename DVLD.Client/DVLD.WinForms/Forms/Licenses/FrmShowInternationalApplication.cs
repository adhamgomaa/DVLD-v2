using DVLD.DTOs.Applications;
using DVLD.DTOs.DetainLicense;
using DVLD.DTOs.InternationalLicense;
using DVLD.DTOs.Licenses;
using DVLD.WinForms.Forms.People;
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
    public partial class FrmShowInternationalApplication : Form
    {
        List<InternationalLicenseDto> _allLicenses = new();
        InternationalLicenseApiService _licenseService = new();
        public FrmShowInternationalApplication()
        {
            InitializeComponent();
        }

        private async Task _LoadLicenseData()
        {
            _allLicenses = await _licenseService.GetAllInternationalLicenseAsync() ?? [];
            dgvApp.DataSource = _allLicenses;
            lblRecords.Text = dgvApp.RowCount.ToString();
        }

        private void _LoadFiltersInBox()
        {
            cbFilter.Items.Add("none");
            foreach (DataGridViewColumn Col in dgvApp.Columns)
            {
                if (Col.HeaderText == "IssueDate" || Col.HeaderText == "ExpirationDate")
                    cbFilter.Items.Add(Col.HeaderText);
            }
            cbFilter.SelectedIndex = 0;
        }

        private async void FrmShowInternationalApplication_Load(object sender, EventArgs e)
        {
            await _LoadLicenseData();
            _LoadFiltersInBox();
        }

        private void ApplyFilters()
        {
            string selectedColumn = cbFilter.SelectedItem?.ToString() ?? "";
            string keyword = tbFilter.Text.Trim();

            IEnumerable<InternationalLicenseDto>? query = _allLicenses;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvApp.DataSource = _allLicenses;
                return;
            }

            query = query?.Where(p =>
                GetColumnValue(p, selectedColumn)
                    .Contains(keyword, StringComparison.OrdinalIgnoreCase));

            dgvApp.DataSource = query?.ToList();
        }

        private static string GetColumnValue(InternationalLicenseDto license, string column)
        {
            return column switch
            {
                "InternationalID" => license.InternationalID.ToString(),
                "LocalLicenseID" => license.LocalLicenseID.ToString(),
                "DriverID" => license.DriverID.ToString(),
                "AppID" => license.AppID.ToString(),
                "IsActive" => license.IsActive.ToString(),
                "UserID" => license.UserID.ToString(),
                _ => ""
            };
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = (cbFilter.Text != "none");
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            FrmNewInternational newInternational = new();
            newInternational.ShowDialog();
            await _LoadLicenseData();
        }

        private async void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync((int)dgvApp.CurrentRow.Cells[1].Value);
            FrmPersonInfo personInfo = new(app!.PersonId);
            personInfo.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowIntLicense showIntLicense = new((int)dgvApp.CurrentRow.Cells[0].Value);
            showIntLicense.ShowDialog();
        }

        private async void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetLicenseDto? license = await new LicenseApiService().GetLicenseByIdAsync((int)dgvApp.CurrentRow.Cells[2].Value);
            FrmLicenseHistory licenseHistory = new(license!.DriverID);
            licenseHistory.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
