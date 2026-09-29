using DVLD.DTOs.LocalLicense;
using DVLD.DTOs.TestAppointment;
using DVLD.DTOs.Tests;
using DVLD.Shared.Enums;
using DVLD.WinForms.Properties;
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

namespace DVLD.WinForms.Forms.Tests
{
    public partial class FrmTests : Form
    {
        TestTypeEnum _testTypeId = TestTypeEnum.VisionTest;
        private int _LocalId = -1;
        GetAppointmentDto _appointment = new();
        List<AppointmentDto> _allAppointments = new();
        TestAppointmentApiService _appointmentService = new();
        public FrmTests(TestTypeEnum testTypeId, int localId)
        {
            InitializeComponent();
            _testTypeId = testTypeId;
            _LocalId = localId;
        }

        private async Task _LoadDataOnDgv()
        {
            _allAppointments = await _appointmentService.GetAllAppointmentsAsync(_LocalId, _testTypeId) ?? [];
            dgvAppointment.DataSource = _allAppointments;
            lblRecords.Text = dgvAppointment.RowCount.ToString();
        }

        private void _LoadData()
        {
            switch (_testTypeId)
            {
                case TestTypeEnum.WrittenTest:
                    pictureBox1.Image = Resources.exam;
                    lblTitle.Text = "Written Test Appointments";
                    break;
                case TestTypeEnum.StreetTest:
                    pictureBox1.Image = Resources.cars;
                    lblTitle.Text = "Street Test Appointments";
                    break;
            }
            this.Text = lblTitle.Text;
        }

        private async void FrmTests_Load(object sender, EventArgs e)
        {
            await ctrlApplicationInfo1.LoadApplicationInfo(_LocalId);
            await _LoadDataOnDgv();
            _LoadData();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            bool result = await new LocalLicenseApiService().IsThereAnActiveTestAsync(_LocalId, _testTypeId);
            if (result)
            {
                MessageBox.Show("This person Already have an active appointment for this test, you cannot add new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TestDto? lastTest = await new TestApiService().GetLastTestAsync(_LocalId, _testTypeId);
            if (lastTest == null)
            {
                FrmScheduleTypeTest test1 = new(_testTypeId, _LocalId);
                test1.ShowDialog();
                FrmTests_Load(sender, e);
                return;
            }

            if (lastTest.Result)
            {
                MessageBox.Show("This person Already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmScheduleTypeTest test2 = new(_testTypeId, _LocalId);
            test2.ShowDialog();
            FrmTests_Load(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScheduleTypeTest test = new(_testTypeId, _LocalId, (int)dgvAppointment.CurrentRow.Cells[0].Value);
            test.ShowDialog();
            FrmTests_Load(sender, e);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTakeTest takeTest = new(_testTypeId, (int)dgvAppointment.CurrentRow.Cells[0].Value);
            takeTest.ShowDialog();
            FrmTests_Load(sender, e);
        }
    }
}
