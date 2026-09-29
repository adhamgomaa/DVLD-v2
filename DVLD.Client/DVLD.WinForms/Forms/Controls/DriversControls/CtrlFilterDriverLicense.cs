using DVLD.DTOs.Licenses;
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

namespace DVLD.WinForms.Forms.Controls.DriversControls
{
    public partial class CtrlFilterDriverLicense : UserControl
    {
        public event Action<int>? OnLicenseSelected;
        protected virtual void LicenseSelected(int licenseId)
        {
            OnLicenseSelected?.Invoke(licenseId);
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseId = -1;

        public int LicenseID
        {
            get
            {
                return ctrlDriverLicenseInfo1.LicenseID;
            }
        }

        public CtrlFilterDriverLicense()
        {
            InitializeComponent();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)13)
                btnAdd.PerformClick();
        }

        public async Task LoadLicenseInfo(int LicenseId)
        {
            tbFilter.Text = LicenseId.ToString();
            _LicenseId = LicenseId;
            if (!await ctrlDriverLicenseInfo1.LoadLicenseData(LicenseId))
                _LicenseId = -1;
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(_LicenseId);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbFilter.Text.Trim().Length > 0)
            {
                _LicenseId = int.Parse(tbFilter.Text.Trim());
                await LoadLicenseInfo(_LicenseId);
            }
        }

        public void txtLicenseIDFoucs()
        {
            tbFilter.Focus();
        }
    }
}
