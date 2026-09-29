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
    public partial class FrmShowIntLicense : Form
    {
        private int _LicenseID = -1;
        public FrmShowIntLicense(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID;
        }

        private async void FrmShowIntLicense_Load(object sender, EventArgs e)
        {
           await ctrlInternationalLicense1.LoadLicenseData(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
