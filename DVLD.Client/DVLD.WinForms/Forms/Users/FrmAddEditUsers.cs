using DVLD.DTOs.Users;
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
    public partial class FrmAddEditUsers : Form
    {
        private int _userId = -1;
        LoginUserDto _user = new();
        UserApiService _userService = new();
        public FrmAddEditUsers()
        {
            InitializeComponent();
        }

        public FrmAddEditUsers(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }
        private async Task _LoadData()
        {
            _user = await _userService.GetUserByIdAsync(_userId) ?? new LoginUserDto();
            ctrlFilterPersonInfo1.FilterEnabled = false;
            await ctrlFilterPersonInfo1.LoadPersonInfo(_user.PersonId);
            lblUserID.Text = _userId.ToString();
            txtUsername.Text = _user.UserName;
            txtPass.Text = _user.Password;
            txtCPass.Text = _user.Password;
            cbActive.Checked = _user.IsActive;
        }

        private void _ResetDefaultValues()
        {
            if (_userId == -1)
            {
                lblAddEdit.Text = "Add New User";
                this.Text = "Add New User";
                ctrlFilterPersonInfo1.FilterFoucs();
                tabPage2.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                lblAddEdit.Text = "Update User";
                this.Text = "Update User";
                txtPass.Enabled = false;
                txtCPass.Enabled = false;
                tabPage2.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_userId != -1)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectTab(1);
                return;
            }
            if (ctrlFilterPersonInfo1.PersonId != -1)
            {
                bool result = await _userService.IsUserExistByPersonIdAsync(ctrlFilterPersonInfo1.PersonId);
                if (result)
                {
                    MessageBox.Show("This User is already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlFilterPersonInfo1.FilterFoucs();
                }
                else
                {
                    btnSave.Enabled = true;
                    tabPage2.Enabled = true;
                    tabControl1.SelectTab(1);
                }
            }
            else
            {
                MessageBox.Show("Please Select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFilterPersonInfo1.FilterFoucs();
            }
        }

        private async void FrmAddEditUsers_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_userId != -1)
                await _LoadData();
        }

        private async void Box_Validating(TextBox box, CancelEventArgs e)
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
            if (box == txtUsername)
            {
                GetUserDto? getUser = await _userService.GetUserByUsernameAsync(txtUsername.Text);
                if (getUser != null)
                {
                    e.Cancel = true;
                    box.Focus();
                    errorProvider1.SetError(box, "This username is already exist, please change it");
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
                    errorProvider1.SetError(box, "Required");
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

        private async Task AddUser()
        {
            CreateUserDto createUser = new()
            {
                UserName = txtUsername.Text.Trim(),
                Password = txtPass.Text.Trim(),
                IsActive = cbActive.Checked,
                PersonId = ctrlFilterPersonInfo1.PersonId
            };
            bool result = await _userService.AddUserAsync(createUser);
            if (result)
                MessageBox.Show("User Added Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error Adding User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task UpdateUser()
        {
            UpdateUserDto updateUser = new()
            {
                UserName = txtUsername.Text.Trim(),
                Password = txtPass.Text.Trim(),
                IsActive = cbActive.Checked,
                PersonId = ctrlFilterPersonInfo1.PersonId
            };
            bool result = await _userService.UpdateUserAsync(_userId, updateUser);
            if (result)
                MessageBox.Show("User Updated Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error Updating User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_userId == -1)
            {
                bool result = await _userService.IsUserExistByPersonIdAsync(ctrlFilterPersonInfo1.PersonId);
                if (result)
                {
                    MessageBox.Show("This User is already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlFilterPersonInfo1.FilterFoucs();
                    return;
                }
                await AddUser();
            }
            else
                await UpdateUser();

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
