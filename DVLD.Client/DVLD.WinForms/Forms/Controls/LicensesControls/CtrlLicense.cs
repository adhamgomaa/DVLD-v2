using DVLD.DTOs.InternationalLicense;
using DVLD.DTOs.Licenses;
using DVLD.WinForms.Forms.Licenses;
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

namespace DVLD.WinForms.Forms.Controls.LicensesControls
{
    public partial class CtrlLicense : UserControl
    {
        public CtrlLicense()
        {
            InitializeComponent();
        }

        private async Task LoadDataOnDgvInternational(int driverId)
        {
            List<InternationalHistoryDto>? list = await new InternationalLicenseApiService().GetAllInternationalLicenseHistoryAsync(driverId);
            dgvInt.DataSource = list;
            lblRecordsInt.Text = dgvInt.RowCount.ToString();
        }

        private async Task LoadDataOnDgvLocal(int driverId)
        {
            List<LicenseHistoryDto>? list = await new LicenseApiService().GetAllLicensesAsync(driverId);
            dgvLocal.DataSource = list;
            lblRecordsLocal.Text = dgvLocal.RowCount.ToString();
        }

        public async Task LoadData(int driverId)
        {
            await LoadDataOnDgvLocal(driverId);
            await LoadDataOnDgvInternational(driverId);
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDriverLicenseInfo licenseInfo = new((int)dgvLocal.CurrentRow.Cells[0].Value);
            licenseInfo.ShowDialog();
        }

        private void showInternationlLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowIntLicense intLicense = new((int)dgvInt.CurrentRow.Cells[0].Value);
            intLicense.ShowDialog();
        }
    }
}
