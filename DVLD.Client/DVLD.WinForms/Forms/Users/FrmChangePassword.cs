using DVLD.DTOs.Users;
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

namespace DVLD.WinForms.Forms.Users
{
    public partial class FrmChangePassword : Form
    {
        private int _userId = -1;
        LoginUserDto currentUser = new();
        UserApiService _userService = new();
        public FrmChangePassword(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async void FrmChangePassword_Load(object sender, EventArgs e)
        {
            await ctrlUserInfo1.LoadUserInfo(_userId);
            currentUser = await _userService.GetUserByIdAsync(_userId) ?? new LoginUserDto();
        }

        private void Box_Validating(TextBox box, CancelEventArgs e)
        {
            if (box == txtCurrent)
            {
                if (Encryption.Hashing(txtCurrent.Text) != currentUser.Password)
                {
                    e.Cancel = true;
                    box.Focus();
                    errorProvider1.SetError(box, "Should you match with User password!!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(box, "");
                }
            }
            if (box == txtCPass)
            {
                if (txtCPass.Text != txtPass.Text)
                {
                    e.Cancel = true;
                    box.Focus();
                    errorProvider1.SetError(box, "Should you match with new password!!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(box, "");
                }
            }
        }

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            Box_Validating((TextBox)sender, e);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateUserDto updateUser = new()
            {
                UserName = currentUser.UserName,
                IsActive = currentUser.IsActive,
                PersonId = currentUser.PersonId,
                Password = txtCPass.Text
            };
            bool result = await _userService.UpdateUserAsync(_userId, updateUser);
            if (result)
            {
                MessageBox.Show("Password Updated Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
