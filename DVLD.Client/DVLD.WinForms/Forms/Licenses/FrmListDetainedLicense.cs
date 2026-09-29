using DVLD.DTOs.DetainLicense;
using DVLD.DTOs.Licenses;
using DVLD.DTOs.People;
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
    public partial class FrmListDetainedLicense : Form
    {
        List<DetainLicenseDto> _allLicenses = new();
        DetainLicenseApiService _detainLicense = new();
        public FrmListDetainedLicense()
        {
            InitializeComponent();
        }

        private async Task _LoadLicenseData()
        {
            _allLicenses = await _detainLicense.GetAllDetainLicensesAsync() ?? [];
            dgvDetain.DataSource = _allLicenses;
            lblRecords.Text = dgvDetain.RowCount.ToString();
        }

        private void _LoadFiltersInBox()
        {
            cbFilter.Items.Add("none");
            foreach (DataGridViewColumn Col in dgvDetain.Columns)
            {
                if (Col.HeaderText == "DetainDate" || Col.HeaderText == "ReleaseDate")
                    cbFilter.Items.Add(Col.HeaderText);
            }
            cbFilter.SelectedIndex = 0;
        }

        private async void FrmListDetainedLicense_Load(object sender, EventArgs e)
        {
            await _LoadLicenseData();
            _LoadFiltersInBox();
        }

        private void ApplyFilters()
        {
            string selectedColumn = cbFilter.SelectedItem?.ToString() ?? "";
            string keyword = tbFilter.Text.Trim();

            IEnumerable<DetainLicenseDto>? query = _allLicenses;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvDetain.DataSource = _allLicenses;
                return;
            }

            query = query?.Where(p =>
                GetColumnValue(p, selectedColumn)
                    .Contains(keyword, StringComparison.OrdinalIgnoreCase));

            dgvDetain.DataSource = query?.ToList();
        }

        private static string GetColumnValue(DetainLicenseDto license, string column)
        {
            return column switch
            {
                "DetainId" => license.DetainId.ToString(),
                "NationalNo" => license.NationalNo,
                "FullName" => license.FullName,
                "DetainFees" => license.DetainFees.ToString(),
                "IsReleased" => license.IsReleased.ToString(),
                "LicenseId" => license.LicenseId.ToString(),
                "ReleaseAppId" => license.ReleaseAppId.ToString(),
                _ => ""
            };
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private async void btnRelease_Click(object sender, EventArgs e)
        {
            FrmReleaseLicense releaseLicense = new();
            releaseLicense.ShowDialog();
            await _LoadLicenseData();
        }

        private async void btnDetain_Click(object sender, EventArgs e)
        {
            FrmDetainLicense detainLicense = new();
            detainLicense.ShowDialog();
            await _LoadLicenseData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetPersonDto? person = await new PersonApiService().GetPersonByNationalNumberAsync((string)dgvDetain.CurrentRow.Cells[6].Value);
            FrmPersonInfo personInfo = new(person!.PersonId);
            personInfo.ShowDialog();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDriverLicenseInfo licenseInfo = new((int)dgvDetain.CurrentRow.Cells[1].Value);
            licenseInfo.ShowDialog();
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetLicenseDto? license = await new LicenseApiService().GetLicenseByIdAsync((int)dgvDetain.CurrentRow.Cells[1].Value);
            FrmLicenseHistory licenseHistory = new(license!.DriverID);
            licenseHistory.ShowDialog();
        }

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReleaseLicense releaseLicense = new((int)dgvDetain.CurrentRow.Cells[1].Value);
            releaseLicense.ShowDialog();
            await _LoadLicenseData();
        }

        private void dgvDetain_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            toolStripMenuItem1.Enabled = !(bool)dgvDetain.CurrentRow.Cells[3].Value;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = (cbFilter.Text != "none");
        }
    }
}
