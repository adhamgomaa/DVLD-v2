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

namespace DVLD.WinForms.Forms.Controls.UsersControls
{
    public partial class CtrlUserInfo : UserControl
    {
        private int _userId = -1;
        GetUserDto? _user = new();
        //UserApiService _userService = new();
        private void _ResetUserInfo()
        {
            _userId = -1;
            lblUserId.Text = "[???]";
            lblUserName.Text = "[???]";
            lblActive.Text = "[???]";
        }
        public CtrlUserInfo()
        {
            InitializeComponent();
        }

        private async Task _LoadUserInfo()
        {
            await ctrlPersonInfo1.LoadPersonInfo(_user!.PersonId);
            _userId = _user.UserId;
            lblUserId.Text = _userId.ToString();
            lblUserName.Text = _user.UserName;
            if (_user.IsActive)
                lblActive.Text = "Yes";
            else
                lblActive.Text = "No";
        }

        public async Task LoadUserInfo(int userId)
        {
            _user = await new UserApiService().GetUserInfoByIdAsync(userId);
            if (_user == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No user with User ID = " + userId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
               await _LoadUserInfo();
        }
    }
}
