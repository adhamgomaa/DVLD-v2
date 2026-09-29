using DVLD.DTOs.Drivers;
using DVLD.DTOs.LicenseClass;
using DVLD.DTOs.Licenses;
using DVLD.DTOs.People;
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

namespace DVLD.WinForms.Forms.Controls.DriversControls
{
    public partial class CtrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        //LicenseApiService licenseService = new();
        GetLicenseDto? _License = new();

        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }
        public CtrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private async Task _LoadLicenseData()
        {
            _LicenseID = _License!.LicenseID;
            LicenseClassDto? licenseClass = await new LicenseClassApiService().GetLicenseClassByIdAsync(_License.ClassID);
            lblClass.Text = licenseClass!.ClassName;
            lblId.Text = _LicenseID.ToString();
            GetDriverDto? driver = await new DriverApiService().GetDriverByIdAsync(_License.DriverID);
            GetPersonDto? person = await new PersonApiService().GetPersonByIdAsync(driver!.PersonID);
            string fullName = person!.FName + " " + person.SecName + " " + person.ThName + " " + person.LName;
            lblName.Text = fullName;
            lblNationalNo.Text = person.NationalNo;
            if (person.Gendor == 0)
            {
                lblGendor.Text = "Male";
                pbGendor.BackgroundImage = Resources.patient_boy__1_;
                pbPerson.Image = Resources.Male_512;
            }
            else
            {
                lblGendor.Text = "Female";
                pbGendor.BackgroundImage = Resources.user_female;
                pbPerson.Image = Resources.Female_512;
            }
            lblIssueDate.Text = _License.IssueDate.ToString("dd/MMM/yyyy");
            lblExipration.Text = _License.ExpiredDate.ToString("dd/MMM/yyyy");
            lblBirth.Text = person.Date.ToString("dd/MMM/yyyy");
            lblReason.Text = new LicenseApiService().GetIssueReasonText(_License.IssueReason);
            lblDriverId.Text = _License.DriverID.ToString();
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblActive.Text = _License.IsActive ? "Yes" : "No";
            bool result = await new DetainLicenseApiService().IsLicenseDetainedAsync(_LicenseID);
            lblDetain.Text = result ? "Yes" : "No";
            if (person.ImagePath != "")
            {
                if (File.Exists(person.ImagePath))
                    pbPerson.Load(person.ImagePath);
            }
        }

        public async Task<bool> LoadLicenseData(int LicenseId)
        {
            _License = await new LicenseApiService().GetLicenseByIdAsync(LicenseId);
            if (_License != null)
            {
                await _LoadLicenseData();
                return true;
            }
            return false;
        }
    }
}
