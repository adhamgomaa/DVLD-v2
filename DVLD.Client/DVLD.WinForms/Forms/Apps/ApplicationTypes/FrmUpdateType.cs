using DVLD.DTOs.ApplicationTypes;
using DVLD.Shared.Enums;
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

namespace DVLD.WinForms.Forms.Apps.ApplicationTypes
{
    public partial class FrmUpdateType : Form
    {
        private AppTypeEnum _TypeID = AppTypeEnum.NewLocalDrivingLicense;
        ApplicationTypeApiService _typeService = new();
        TypesDto _type = new();
        public FrmUpdateType(AppTypeEnum typeId)
        {
            InitializeComponent();
            _TypeID = typeId;
        }

        private async Task _loadData()
        {
            _type = await _typeService.GetTypeByIdAsync(_TypeID) ?? new TypesDto();
            lblTypeID.Text = _TypeID.ToString();
            txtTitle.Text = _type.Title;
            txtFees.Text = _type.Fees.ToString();
        }

        private void Box_Validating(TextBox box, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(box.Text))
            {
                e.Cancel = true;
                box.Focus();
                errorProvider1.SetError(box, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(box, "");
            }
        }

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            Box_Validating((TextBox)sender, e);
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateAppTypeDto updateType = new()
            {
                Fees = Convert.ToDecimal(txtFees.Text),
                Title = txtTitle.Text
            };
            bool result = await _typeService.UpdateAppTypeAsync(_TypeID, updateType);
            if (result)
            {
                MessageBox.Show("Type Updated Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void FrmUpdateType_Load(object sender, EventArgs e)
        {
            await _loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
