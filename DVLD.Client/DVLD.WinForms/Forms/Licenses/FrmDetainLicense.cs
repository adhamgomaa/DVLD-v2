using DVLD.DTOs.Applications;
using DVLD.DTOs.ApplicationTypes;
using DVLD.DTOs.DetainLicense;
using DVLD.DTOs.Licenses;
using DVLD.Shared.Enums;
using DVLD.WinForms.Helpers;
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
    public partial class FrmDetainLicense : Form
    {
        private int _licenseID = -1;
        private int _detainLicenseID = -1;
        public FrmDetainLicense()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            ctrlFilterDriverLicense1.txtLicenseIDFoucs();
            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreate.Text = CurrentUser.User!.UserName;
        }

        private async void ctrlFilterDriverLicense1_OnLicenseSelected(int obj)
        {
            _licenseID = obj;
            if (_licenseID == -1)
            {
                MessageBox.Show($"Selected License isn't found", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            lblLicense.Text = _licenseID.ToString();
            linkLabel1.Enabled = (_licenseID != -1);
            bool result = await new DetainLicenseApiService().IsLicenseDetainedAsync(_licenseID);
            if (result)
            {
                MessageBox.Show($"Selected License is already Detained, choose another one.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
        }

        private void FrmDetainLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public async Task SaveData()
        {
            CreateDetainLicenseDto createDetain = new()
            {
                Fees = Convert.ToDecimal(txtFees.Text),
                UserID = CurrentUser.User!.UserId,
                LicenseID = _licenseID
            };
            GetDetainDto? detainLicense = await new DetainLicenseApiService().AddDetainLicenseAsync(createDetain);
            if (detainLicense != null)
            {
                _detainLicenseID = detainLicense.DetainID;
                lblDetainID.Text = _detainLicenseID.ToString();
                MessageBox.Show($"License Detain Successfuly With ID = {_detainLicenseID} ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                ctrlFilterDriverLicense1.FilterEnabled = false;
                txtFees.Enabled = false;
                linkLabel2.Enabled = true;
            }
            else
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                await SaveData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDriverLicenseInfo licenseInfo = new(ctrlFilterDriverLicense1.LicenseID);
            licenseInfo.ShowDialog();
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetLicenseDto? licenseDto = await new LicenseApiService().GetLicenseByIdAsync(_licenseID);
            FrmLicenseHistory licenseHistory = new(licenseDto!.DriverID);
            licenseHistory.ShowDialog();
        }
    }
}
