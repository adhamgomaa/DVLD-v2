using DVLD.DTOs.People;
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
    public partial class FrmListUsers : Form
    {
        UserApiService _userService = new();
        List<UserInfoDto> _allUsers = new();
        public FrmListUsers()
        {
            InitializeComponent();
        }

        private async Task _LoadUsersData()
        {
            _allUsers = await _userService.GetAllUserAsync() ?? [];
            dgvUsers.DataSource = _allUsers;
            lblRecords.Text = dgvUsers.RowCount.ToString();
        }

        private void _LoadFiltersInBox()
        {
            cbFilter.Items.Add("none");
            foreach (DataGridViewColumn Col in dgvUsers.Columns)
            {
                cbFilter.Items.Add(Col.HeaderText);
            }
            cbFilter.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            string selectedColumn = cbFilter.SelectedItem?.ToString() ?? "";
            string keyword = tbFilter.Text.Trim();

            IEnumerable<UserInfoDto>? query = _allUsers;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvUsers.DataSource = _allUsers;
                return;
            }
            query = query?.Where(p => GetColumnValue(p, selectedColumn).Contains(keyword, StringComparison.OrdinalIgnoreCase));
            dgvUsers.DataSource = query?.ToList();
        }

        private static string GetColumnValue(UserInfoDto user, string column)
        {
            return column switch
            {
                "UserId" => user.UserId.ToString(),
                "UserName" => user.UserName,
                "FullName" => user.FullName,
                "IsActive" => user.IsActive.ToString(),
                "PersonId" => user.PersonId.ToString(),
                _ => ""
            };
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = (cbFilter.Text != "none");
        }

        private async void FrmListUsers_Load(object sender, EventArgs e)
        {
            await _LoadUsersData();
            _LoadFiltersInBox();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddEditUsers addUsers = new();
            addUsers.ShowDialog();
            await _LoadUsersData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserInfo userInfo = new((int)dgvUsers.CurrentRow.Cells[0].Value);
            userInfo.ShowDialog();
        }

        private async void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditUsers addUsers = new();
            addUsers.ShowDialog();
            await _LoadUsersData();
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditUsers EditUsers = new((int)dgvUsers.CurrentRow.Cells[0].Value);
            EditUsers.ShowDialog();
            await _LoadUsersData();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure remove User ID = {(int)dgvUsers.CurrentRow.Cells[0].Value}", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bool result = await _userService.DeleteUserAsync((int)dgvUsers.CurrentRow.Cells[0].Value);
                if (result)
                {
                    MessageBox.Show("User Deleted Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadUsersData();
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChangePassword changePassword = new((int)dgvUsers.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showDetailsToolStripMenuItem_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
