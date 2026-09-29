using DVLD.DTOs.Tests;
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

namespace DVLD.WinForms.Forms.Tests
{
    public partial class FrmTakeTest : Form
    {
        private int _appointmentId = -1;
        TestTypeEnum _testTypeId = TestTypeEnum.VisionTest;
        TestDto _test = new();
        TestApiService _testService = new();
        public FrmTakeTest(TestTypeEnum testTypeId, int appointment)
        {
            InitializeComponent();
            _testTypeId = testTypeId;
            _appointmentId = appointment;
        }

        private async Task _loadData()
        {
            ctrlScheduledTest1.TestTypeID = _testTypeId;
            await ctrlScheduledTest1.LoadInfo(_appointmentId);
            if (_appointmentId == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
            int testId = ctrlScheduledTest1.TestID;
            if (testId != -1)
            {
                _test = await _testService.GetTestByAppointmentIdAsync(_appointmentId) ?? new TestDto();
                if (_test.Result)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                textBox1.Text = _test.Notes;
                lblMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private async void FrmTakeTest_Load(object sender, EventArgs e)
        {
            await _loadData();
        }

        private async Task AddTest()
        {
            CreateTestDto createTest = new()
            {
                AppointmentID = _appointmentId,
                Notes = textBox1.Text.Trim(),
                UserId = CurrentUser.User!.UserId,
                Result = rbPass.Checked
            };

            bool result = await _testService.AddTestAsync(createTest);
            if (!result)
                MessageBox.Show("Error Adding Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Test Added Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task UpdateTest()
        {
            UpdateTestDto updateTest = new()
            {
                AppointmentID = _appointmentId,
                Notes = textBox1.Text.Trim(),
                UserId = CurrentUser.User!.UserId,
                Result = rbPass.Checked
            };

            bool result = await _testService.UpdateTestAsync(ctrlScheduledTest1.TestID, updateTest);
            if (!result)
                MessageBox.Show("Error Updating Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Test Updated Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlScheduledTest1.TestID != -1)
                await UpdateTest();
            else
                await AddTest();
            
            btnSave.Enabled = false;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
