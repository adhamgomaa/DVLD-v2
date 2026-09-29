using DVLD.DTOs.Applications;
using DVLD.DTOs.LicenseClass;
using DVLD.DTOs.LocalLicense;
using DVLD.DTOs.People;
using DVLD.DTOs.TestAppointment;
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

namespace DVLD.WinForms.Forms.Controls.TestsControls
{
    public partial class CtrlScheduledTest : UserControl
    {
        private TestTypeEnum _TestTypeID = TestTypeEnum.VisionTest;
        private int _LocalDrivingID = -1;
        private int _AppointmentTestID = -1;
        private int _TestID = -1;
        GetAppointmentDto? _appointment = new();
        //TestAppointmentApiService _appointmentService = new();

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

        public int TestAppointment
        {
            get { return _AppointmentTestID; }
        }

        public int TestID
        {
            get { return _TestID; }
        }
        public CtrlScheduledTest()
        {
            InitializeComponent();
        }

        private async Task LoadData()
        {
            _AppointmentTestID = _appointment!.AppointmentId;
            _TestID = await new TestAppointmentApiService().GetTestIdAsync(_AppointmentTestID);
            _LocalDrivingID = _appointment.LocalId;
            GetLocalLicenseDto? localLicense = await new LocalLicenseApiService().GetLocalLicenseByIdAsync(_LocalDrivingID);
            lblDrivingAppID.Text = _LocalDrivingID.ToString();
            LicenseClassDto? licenseClass = await new LicenseClassApiService().GetLicenseClassByIdAsync(localLicense!.ClassId);
            lblClass.Text = licenseClass!.ClassName;
            GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync(localLicense.AppId);
            GetPersonDto? person = await new PersonApiService().GetPersonByIdAsync(app!.PersonId);
            string fullName = person!.FName + " " + person.SecName + " " + person.ThName + " " + person.LName;
            lblName.Text = fullName;
            lblTrial.Text = (await new LocalLicenseApiService().GetTotalTrailsPerTestAsync(_LocalDrivingID, TestTypeID)).ToString();
            lblDate.Text = _appointment.Date.ToString("dd/MMM/yyyy");
            lblFees.Text = _appointment.Fees.ToString();
            lblTestID.Text = (TestID == -1) ? "Not Taken yet" : TestID.ToString();
        }

        public async Task LoadInfo(int appointmentId)
        {
            _appointment = await new TestAppointmentApiService().GetAppointmentByIdAsync(appointmentId);
            if (_appointment != null)
                await LoadData();
            else
            {
                MessageBox.Show("Error: No  Appointment ID = " + appointmentId.ToString(),
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _AppointmentTestID = -1;
            }
        }
    }
}
