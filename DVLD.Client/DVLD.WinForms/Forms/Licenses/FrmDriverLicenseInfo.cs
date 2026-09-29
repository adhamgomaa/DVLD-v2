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
    public partial class FrmDriverLicenseInfo : Form
    {
        private int _LicenseId = -1;
        public FrmDriverLicenseInfo(int licenseId)
        {
            InitializeComponent();
            _LicenseId = licenseId;
        }

        private async void FrmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
           await ctrlDriverLicenseInfo1.LoadLicenseData(_LicenseId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
