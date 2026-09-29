using DVLD.DTOs.Applications;
using DVLD.DTOs.ApplicationTypes;
using DVLD.DTOs.LicenseClass;
using DVLD.DTOs.LocalLicense;
using DVLD.DTOs.People;
using DVLD.DTOs.TestAppointment;
using DVLD.DTOs.TestTypes;
using DVLD.Shared.Enums;
using DVLD.WinForms.Helpers;
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
using System.Xml.Linq;

namespace DVLD.WinForms.Forms.Controls.TestsControls
{
    public partial class CtrlScheduleTest : UserControl
    {
        private TestTypeEnum _TestTypeID = TestTypeEnum.VisionTest;
        enum enCreationMode { FirstTime, RetakeTest }
        private enCreationMode _creationMode = enCreationMode.FirstTime;
        private int _TestAppointmentID = -1;
        private int _LocalLicenseID = -1;
        GetAppointmentDto? _appointment = new();
        GetLocalLicenseDto? _localLicense = new();
        //TestAppointmentApiService _appointmentService = new();
        //LocalLicenseApiService _localLicenseService = new();
        public TestTypeEnum TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case TestTypeEnum.VisionTest:
                        {
                            gbAppointmentTest.Text = "Vision Test";
                            pictureBox1.Image = Resources.eye;
                            break;
                        }
                    case TestTypeEnum.WrittenTest:
                        {
                            gbAppointmentTest.Text = "Written Test";
                            pictureBox1.Image = Resources.exam;
                            break;
                        }
                    case TestTypeEnum.StreetTest:
                        {
                            gbAppointmentTest.Text = "Street Test";
                            pictureBox1.Image = Resources.cars;
                            break;
                        }
                }
            }
        }
        public CtrlScheduleTest()
        {
            InitializeComponent();
        }

        private async Task<bool> _LoadTestAppointmentData()
        {
            _appointment = await new TestAppointmentApiService().GetAppointmentByIdAsync(_TestAppointmentID);
            if (_appointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _appointment.Fees.ToString();
            dateTimePicker1.MinDate = _appointment.Date;
            dateTimePicker1.Value = _appointment.Date;
            if (_appointment.RetakeApplicationId == -1)
            {
                lblRAppId.Text = "N/A";
                lblAppFees.Text = "0";
            }
            else
            {
                gbRetake.Enabled = true;
                lblTest.Text = "Retake Schedule Test";
                GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync(_appointment.RetakeApplicationId);
                lblAppFees.Text = app!.Fees.ToString();
                lblRAppId.Text = _appointment.RetakeApplicationId.ToString();
            }
            return true;
        }

        private async Task<bool> _HandleActiveTestAppointment()
        {
            bool result = await new LocalLicenseApiService().IsThereAnActiveTestAsync(_LocalLicenseID, TestTypeID);
            if (_TestAppointmentID == -1 && result)
            {
                btnSave.Enabled = false;
                dateTimePicker1.Enabled = false;
                lblLocked.Visible = true;
                lblLocked.Text = "Person Already have an active appointment for this test";
                return false;
            }
            lblLocked.Visible = false;
            return true;
        }

        private bool _HandleAppointmentLocked()
        {
            if (_appointment!.IsLocked)
            {
                lblLocked.Visible = true;
                lblLocked.Text = "Person already sat for the test, appointment loacked.";
                btnSave.Enabled = false;
                dateTimePicker1.Enabled = false;
                return false;
            }
            lblLocked.Visible = false;
            return true;
        }

        private async Task<bool> _HandlePrviousTest()
        {
            switch (_TestTypeID)
            {
                case TestTypeEnum.VisionTest:
                    lblLocked.Visible = false;
                    return true;
                case TestTypeEnum.WrittenTest:
                    {
                        bool resultVision = await new LocalLicenseApiService().DosePassTestTypeAsync(_LocalLicenseID, TestTypeEnum.VisionTest);
                        if (!resultVision)
                        {
                            lblLocked.Visible = true;
                            lblLocked.Text = "Cannot Schedule, Vision Test should be passed first";
                            btnSave.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lblLocked.Visible = false;
                            btnSave.Enabled = true;
                            dateTimePicker1.Enabled = true;
                        }
                        return true;
                    }
                case TestTypeEnum.StreetTest:
                    bool resultWrite = await new LocalLicenseApiService().DosePassTestTypeAsync(_LocalLicenseID, TestTypeEnum.WrittenTest);
                    if (!resultWrite)
                    {
                        lblLocked.Visible = true;
                        lblLocked.Text = "Cannot Schedule, Written Test should be passed first";
                        btnSave.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblLocked.Visible = false;
                        btnSave.Enabled = true;
                        dateTimePicker1.Enabled = true;
                    }
                    return true;
            }
            return true;
        }

        private async Task LoadData()
        {
            bool result = await new LocalLicenseApiService().DoseAttendTestTypeAsync(_LocalLicenseID, TestTypeID);
            if (result)
                _creationMode = enCreationMode.RetakeTest;
            else
                _creationMode = enCreationMode.FirstTime;

            if (_creationMode == enCreationMode.RetakeTest)
            {
                TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.RetakeTest);
                lblAppFees.Text = type!.Fees.ToString();
                gbRetake.Enabled = true;
                lblTest.Text = "Retake Schedule Test";
                lblRAppId.Text = "0";
                _appointment = await new TestAppointmentApiService().GetLastAppointmentAsync(_LocalLicenseID, _TestTypeID);
                dateTimePicker1.MinDate = _appointment!.Date.AddDays(1);
            }
            else
            {
                gbRetake.Enabled = false;
                lblRAppId.Text = "N/A";
                lblTest.Text = "Schedule Test";
                lblAppFees.Text = "0";
                dateTimePicker1.MinDate = DateTime.Now;
            }

            lblDrivingAppID.Text = _LocalLicenseID.ToString();
            LicenseClassDto? licenseClass = await new LicenseClassApiService().GetLicenseClassByIdAsync(_localLicense!.ClassId);
            lblClass.Text = licenseClass!.ClassName;
            GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync(_localLicense.AppId);
            GetPersonDto? person = await new PersonApiService().GetPersonByIdAsync(app!.PersonId);
            string fullName = person!.FName + " " + person.SecName + " " + person.ThName + " " + person.LName;
            lblName.Text = fullName;
            lblTrial.Text = (await new LocalLicenseApiService().GetTotalTrailsPerTestAsync(_LocalLicenseID, TestTypeID)).ToString();
            TestTypesDto? testType = await new TestTypeApiService().GetTypeByIdAsync(TestTypeID);
            lblFees.Text = testType!.Fees.ToString();
            lblRAppId.Text = "N/A";

            if (_TestAppointmentID == -1)
            {
                _appointment = new();
            }
            else
            {
                if (!await _LoadTestAppointmentData())
                    return;
            }

            lblTotal.Text = (Convert.ToDecimal(lblFees.Text) + Convert.ToDecimal(lblAppFees.Text)).ToString();
        }

        public async Task LoadTest(int LocalDrivingLicenseID, int appointmentID = -1)
        {
            _LocalLicenseID = LocalDrivingLicenseID;
            _TestAppointmentID = appointmentID;
            _localLicense = await new LocalLicenseApiService().GetLocalLicenseByIdAsync(LocalDrivingLicenseID);
            if (_localLicense == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + LocalDrivingLicenseID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            await LoadData();

            if (!await _HandleActiveTestAppointment())
                return;
            if (!_HandleAppointmentLocked())
                return;
            if (!await _HandlePrviousTest())
                return;
        }

        private async Task<bool> _HandleRetakeApp()
        {
            if (_TestAppointmentID == -1 && _creationMode == enCreationMode.RetakeTest)
            {
                GetAppDto? tempApp = await new ApplicationApiService().GetAppByIdAsync(_localLicense!.AppId);
                TypesDto? tempType = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.RetakeTest);
                CreateAppDto createApp = new()
                {
                    PersonId = tempApp!.PersonId,
                    Type = AppTypeEnum.RetakeTest,
                    AppStatus = AppStatusEnum.Completed,
                    StatusDate = DateTime.Now,
                    Fees = tempType!.Fees,
                    UserId = CurrentUser.User!.UserId
                };
                GetAppDto? result = await new ApplicationApiService().AddAppAsync(createApp);
                if (result != null)
                {
                    _appointment!.RetakeApplicationId = result.AppID;
                }
                else
                {
                    _appointment!.RetakeApplicationId = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private async Task CreateAppointment()
        {
            CreateAppointmentDto createAppointment = new()
            {
                TestTypeId = TestTypeID,
                LocalId = _localLicense!.LocalId,
                Fees = Convert.ToDecimal(lblFees.Text),
                Date = dateTimePicker1.Value,
                UserId = CurrentUser.User!.UserId,
                RetakeApplicationId = _appointment!.RetakeApplicationId
            };
            bool result = await new TestAppointmentApiService().AddAppointmentAsync(createAppointment);
            if (result)
            {
                MessageBox.Show("Appointment Created Successfully.", "Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Appointment Is not created Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         private async Task UpdateAppointment()
        {
            UpdateAppointmentDto updateAppointment = new()
            {
                TestTypeId = TestTypeID,
                LocalId = _localLicense!.LocalId,
                Fees = Convert.ToDecimal(lblFees.Text),
                Date = dateTimePicker1.Value,
                UserId = CurrentUser.User!.UserId,
            };
            bool result = await new TestAppointmentApiService().UpdateAppointmentAsync(_TestAppointmentID, updateAppointment);
            if (result)
            {
                MessageBox.Show("Appointment Updated Successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Appointment Is not updated Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!await _HandleRetakeApp())
                return;
            if (_TestAppointmentID == -1)
                await CreateAppointment();
            else
                await UpdateAppointment();
        }
    }
}
