using DVLD.DTOs.Drivers;
using DVLD.WinForms.Forms.Licenses;
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

namespace DVLD.WinForms.Forms.Drivers
{
    public partial class FrmListDrivers : Form
    {
        DriverApiService _driverService = new();
        List<DriverDto> _allDrivers = new();
        public FrmListDrivers()
        {
            InitializeComponent();
        }

        private async Task _LoadDriversData()
        {
            _allDrivers = await _driverService.GetAllDriversAsync() ?? [];
            dgvDrivers.DataSource = _allDrivers;
            lblRecords.Text = dgvDrivers.RowCount.ToString();
        }

        private void _LoadFiltersInBox()
        {
            cbFilter.Items.Add("none");
            foreach (DataGridViewColumn Col in dgvDrivers.Columns)
            {
                if (Col.HeaderText == "Date")
                    continue;
                cbFilter.Items.Add(Col.HeaderText);
            }
            cbFilter.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            string selectedColumn = cbFilter.SelectedItem?.ToString() ?? "";
            string keyword = tbFilter.Text.Trim();

            IEnumerable<DriverDto>? query = _allDrivers;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvDrivers.DataSource = _allDrivers;
                return;
            }
            query = query?.Where(p => GetColumnValue(p, selectedColumn).Contains(keyword, StringComparison.OrdinalIgnoreCase));
            dgvDrivers.DataSource = query?.ToList();
        }

        private static string GetColumnValue(DriverDto driver, string column)
        {
            return column switch
            {
                "DriverId" => driver.DriverId.ToString(),
                "PersonId" => driver.PersonId.ToString(),
                "NationalNo" => driver.NationalNo,
                "FullName" => driver.FullName,
                "ActiveLicense" => driver.ActiveLicense.ToString(),
                _ => string.Empty,
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

        private async void FrmListDrivers_Load(object sender, EventArgs e)
        {
            await _LoadDriversData();
            _LoadFiltersInBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonInfo personInfo = new((int)dgvDrivers.CurrentRow.Cells[1].Value);
            personInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenseHistory licenseHistory = new((int)dgvDrivers.CurrentRow.Cells[0].Value);
            licenseHistory.ShowDialog();
        }
    }
}
