using DVLD.DTOs.People;
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

namespace DVLD.WinForms.Forms.People
{
    public partial class FrmListPeople : Form
    {
        PersonApiService _personService = new();
        List<PeopleDto>? _allPeople = new();
        public FrmListPeople()
        {
            InitializeComponent();
        }

        private async Task _LoadPeopleData()
        {
            _allPeople = await _personService.GetAllPeopleAsync();
            dgvPeople.DataSource = _allPeople;
            lblRecords.Text = dgvPeople.RowCount.ToString();
        }

        private void _LoadFiltersInBox()
        {
            cbFilter.Items.Add("none");
            foreach (DataGridViewColumn Col in dgvPeople.Columns)
            {
                cbFilter.Items.Add(Col.HeaderText);
            }
            cbFilter.SelectedIndex = 0;
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private async void FrmListPeople_Load(object sender, EventArgs e)
        {
            await _LoadPeopleData();
            _LoadFiltersInBox();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson addEdit = new();
            addEdit.personData += _LoadPeopleData;
            addEdit.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson addEdit = new((int)dgvPeople.CurrentRow.Cells[0].Value);
            addEdit.personData += _LoadPeopleData;
            addEdit.ShowDialog();
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure remove Person ID = {(int)dgvPeople.CurrentRow.Cells[0].Value}", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bool result = await _personService.DeletePersonAsync((int)dgvPeople.CurrentRow.Cells[0].Value);
                if (result)
                {
                    MessageBox.Show("Person Deleted Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _LoadPeopleData();
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = (cbFilter.Text != "none");
        }

        private void ApplyFilters()
        {
            string selectedColumn = cbFilter.SelectedItem?.ToString() ?? "";
            string keyword = tbFilter.Text.Trim();

            IEnumerable<PeopleDto>? query = _allPeople;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvPeople.DataSource = _allPeople;
                return;
            }

            if (selectedColumn == "Date")
            {
                if (DateTime.TryParse(keyword, out DateTime date))
                {
                    query = query?.Where(p => p.Date.Date == date.Date);
                }
                else
                {
                    query = [];
                }
            }
            else
            {
                query = query?.Where(p =>
                    GetColumnValue(p, selectedColumn)
                        .Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }

            dgvPeople.DataSource = query?.ToList();
        }

        private static string GetColumnValue(PeopleDto person, string column)
        {
            return column switch
            {
                "PersonId" => person.PersonId.ToString(),
                "NationalNo" => person.NationalNo,
                "FullName" => person.FullName,
                "Nationality" => person.Nationality,
                "Gendor" => person.Gendor,
                "Phone" => person.Phone,
                "Email" => person.Email ?? "",
                _ => ""
            };
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedColumn = cbFilter.SelectedItem?.ToString() ?? "";
            if (selectedColumn == "PersonId")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonInfo personInfo = new((int)dgvPeople.CurrentRow.Cells[0].Value);
            personInfo.ShowDialog();
        }

        private void dgvPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showDetailsToolStripMenuItem_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson addEdit = new();
            addEdit.personData += _LoadPeopleData;
            addEdit.ShowDialog();
        }
    }
}
