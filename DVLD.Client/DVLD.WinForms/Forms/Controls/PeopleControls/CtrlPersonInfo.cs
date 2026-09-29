using DVLD.DTOs.Countries;
using DVLD.DTOs.People;
using DVLD.WinForms.Forms.People;
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

namespace DVLD.WinForms.Forms.Controls.PeopleControls
{
    public partial class CtrlPersonInfo : UserControl
    {
        private int _PersonId = -1;
        //PersonApiService _personService = new();
        GetPersonDto? _person = new();
        public int PersonId
        {
            get { return _PersonId; }
        }
        public CtrlPersonInfo()
        {
            InitializeComponent();
        }

        private void _ResetPersonInfo()
        {
            _PersonId = -1;
            lblPersonId.Text = "[???]";
            lblName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            pbGendor.BackgroundImage = Resources.patient_boy__1_;
            lblGendor.Text = "Male";
            lblEmail.Text = "[???]";
            lblAddress.Text = "[???]";
            lblDate.Text = "[???]";
            lblPhone.Text = "[???]";
            lblCountry.Text = "[???]";
            pbPerson.Image = Resources.Male_512;
            linkLabel1.Enabled = false;
        }

        private async Task _LoadPersonInfo()
        {
            linkLabel1.Enabled = true;
            _PersonId = _person!.PersonId;
            lblPersonId.Text = _PersonId.ToString();
            string fullName = _person!.FName + " " + _person.SecName + " " + _person.ThName + " " + _person.LName;
            lblName.Text = fullName;
            lblNationalNo.Text = _person.NationalNo;
            if (_person.Gendor == 0)
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
            lblEmail.Text = _person.Email;
            lblAddress.Text = _person.Address;
            lblDate.Text = _person.Date.ToShortDateString();
            lblPhone.Text = _person.Phone;
            CountriesDto? country = await new CountryApiService().GetCountryByIdAsync(_person.NationaltyId);
            lblCountry.Text = country!.CountryName;

            if (_person.ImagePath != "")
            {
                if (File.Exists(_person.ImagePath))
                    pbPerson.ImageLocation = _person.ImagePath;
            }
        }

        public async Task LoadPersonInfo(int id)
        {
            _person = await new PersonApiService().GetPersonByIdAsync(id);
            if (_person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No person with Person ID = " + id, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                await _LoadPersonInfo();
        }

        public async Task LoadPersonInfo(string nationalNo)
        {
            _person = await new PersonApiService().GetPersonByNationalNumberAsync(nationalNo);
            if (_person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No person with National Number = " + nationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                await _LoadPersonInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditPerson editPerson = new(_PersonId);
            editPerson.Person += LoadPersonInfo;
            editPerson.ShowDialog();
        }
    }
}
