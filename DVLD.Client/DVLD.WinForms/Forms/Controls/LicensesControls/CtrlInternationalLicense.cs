using DVLD.DTOs.Drivers;
using DVLD.DTOs.InternationalLicense;
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

namespace DVLD.WinForms.Forms.Controls.LicensesControls
{
    public partial class CtrlInternationalLicense : UserControl
    {
        private int _InternationalLicenseID = -1;
        //InternationalLicenseApiService internationalLicenseService = new();
        InternationalLicenseDto? internationalLicense = new();
        public CtrlInternationalLicense()
        {
            InitializeComponent();
        }

        private async Task _LoadLicenseData()
        {
            _InternationalLicenseID = internationalLicense!.InternationalID;
            lblIntID.Text = _InternationalLicenseID.ToString();
            lblId.Text = internationalLicense.LocalLicenseID.ToString();
            GetDriverDto? driver = await new DriverApiService().GetDriverByIdAsync(internationalLicense.DriverID);
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
            lblIssueDate.Text = internationalLicense.IssueDate.ToString("dd/MMM/yyyy");
            lblExipration.Text = internationalLicense.ExpirationDate.ToString("dd/MMM/yyyy");
            lblBirth.Text = person.Date.ToString("dd/MMM/yyyy");
            lblDriverId.Text = internationalLicense.DriverID.ToString();
            lblActive.Text = internationalLicense.IsActive ? "Yes" : "No";
            lblApplication.Text = internationalLicense.AppID.ToString();
            if (person.ImagePath != "")
            {
                if (File.Exists(person.ImagePath))
                    pbPerson.Load(person.ImagePath);
            }
        }

        public async Task<bool> LoadLicenseData(int LicenseId)
        {
            internationalLicense = await new InternationalLicenseApiService().GetInternationalLicenseByIdAsync(LicenseId);
            if (internationalLicense != null)
            {
                await _LoadLicenseData();
                return true;
            }
            return false;
        }
    }
}
