using DVLD.DTOs.Drivers;
using DVLD.WinForms.Services;
using DVLD.WinForms.Forms.Controls.LicensesControls;
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
    public partial class FrmLicenseHistory : Form
    {
        private int _driverId = -1;

        public FrmLicenseHistory()
        {
            InitializeComponent();
        }
        public FrmLicenseHistory(int driverId)
        {
            InitializeComponent();
            _driverId = driverId;
        }

        private async void FrmLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_driverId != -1)
            {
                GetDriverDto? driver = await new DriverApiService().GetDriverByIdAsync(_driverId);
                if (driver == null)
                {
                    MessageBox.Show("There is no driver with Id = " + _driverId, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                await ctrlFilterPersonInfo1.LoadPersonInfo(driver.PersonID);
                ctrlFilterPersonInfo1.FilterEnabled = false;
                await ctrlLicense1.LoadData(_driverId);
            }
            else
            {
                ctrlFilterPersonInfo1.FilterEnabled = true;
                ctrlFilterPersonInfo1.FilterFoucs();
            }
        }

        private async void ctrlFilterPersonInfo1_OnPersonSelected(int obj)
        {
            int _personId = obj;
            if (_personId != -1)
            {
                GetDriverDto? driver = await new DriverApiService().GetDriverIdByPersonIdAsync(_personId);
                if (driver != null)
                {
                    await ctrlLicense1.LoadData(driver.DriverID);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
