using DVLD.DTOs.TestTypes;
using DVLD.Shared.Enums;
using DVLD.WinForms.Forms.Apps.ApplicationTypes;
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

namespace DVLD.WinForms.Forms.Tests.TestTypes
{
    public partial class FrmTestTypes : Form
    {
        TestTypeApiService _typeService = new();
        List<TestTypesDto> _allTypes = new();
        public FrmTestTypes()
        {
            InitializeComponent();
        }

        private async Task _LoadTypesData()
        {
            _allTypes = await _typeService.GetAllTypesAsync() ?? [];
            dgvTypes.DataSource = _allTypes;
            lblRecords.Text = dgvTypes.RowCount.ToString();
        }

        private async void FrmTestTypes_Load(object sender, EventArgs e)
        {
            await _LoadTypesData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void editAplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateTest updateType = new((TestTypeEnum)dgvTypes.CurrentRow.Cells[0].Value);
            updateType.ShowDialog();
            await _LoadTypesData();
        }
    }
}
