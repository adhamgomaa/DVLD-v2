using DVLD.DTOs.ApplicationTypes;
using DVLD.Shared.Enums;
using DVLD.WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Forms.Apps.ApplicationTypes
{
    public partial class FrmAppsTypes : Form
    {
        ApplicationTypeApiService _typeService = new();
        List<TypesDto> _allTypes = new();
        public FrmAppsTypes()
        {
            InitializeComponent();
        }

        private async Task _LoadTypesData()
        {
            _allTypes = await _typeService.GetAllTypesAsync() ?? [];
            dgvTypes.DataSource = _allTypes;
            lblRecords.Text = dgvTypes.RowCount.ToString();
        }

        private async void FrmAppsTypes_Load(object sender, EventArgs e)
        {
            await _LoadTypesData();
        }

        private async void editAplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateType updateType = new((AppTypeEnum)dgvTypes.CurrentRow.Cells[0].Value);
            updateType.ShowDialog();
            await _LoadTypesData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
