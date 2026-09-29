using DVLD.DTOs.Countries;
using DVLD.DTOs.People;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Forms.People
{
    public partial class FrmAddEditPerson : Form
    {
        PersonApiService _personService = new();
        CountryApiService _countryService = new();
        GetPersonDto? person = new();

        private int _PersonId = -1;

        public delegate Task SendPersonData();
        public event SendPersonData? personData;

        public delegate Task SendPersonDataToUserData(int personId);
        public event SendPersonDataToUserData? Person;
        public FrmAddEditPerson()
        {
            InitializeComponent();
        }
        public FrmAddEditPerson(int personId)
        {
            InitializeComponent();
            _PersonId = personId;
        }

        private async Task _LoadCountryNameInBox()
        {
            List<CountriesDto>? countries = await _countryService.GetAllCountriesAsync();
            foreach (var country in countries!)
            {
                cbCountry.Items.Add(country.CountryName);
            }
        }

        private async Task ResetDefualtValues()
        {
            await _LoadCountryNameInBox();
            if (_PersonId == -1)
            {
                lblAddEdit.Text = "Add Person";
            }
            else
                lblAddEdit.Text = "Edit Person";

            if (rbMale.Checked)
            {
                pbPerson.Image = Resources.Male_512;
            }
            else
            {
                pbPerson.Image = Resources.Female_512;
            }
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            dateTimePicker1.MinDate = DateTime.Today.AddYears(-100);
            cbCountry.SelectedIndex = 9;
        }

        private async Task EditPerson()
        {
            person = await _personService.GetPersonByIdAsync(_PersonId);
            if (person == null)
            {
                MessageBox.Show("This person is no longer present.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            CountriesDto? country = await _countryService.GetCountryByIdAsync(person.NationaltyId);
            lblPersonId.Text = _PersonId.ToString();
            txtFirst.Text = person.FName;
            txtSecond.Text = person.SecName;
            txtThird.Text = person.ThName;
            txtLast.Text = person.LName;
            txtNationalNo.Text = person.NationalNo;
            if (person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            txtEmail.Text = person.Email;
            txtPhone.Text = person.Phone;
            txtAddres.Text = person.Address;
            dateTimePicker1.Value = person.Date;
            cbCountry.SelectedIndex = cbCountry.FindString(country!.CountryName);
            if (person.ImagePath != null)
            {
                pbPerson.ImageLocation = person.ImagePath;
                linkLabel2.Visible = true;
            }
            else
            {
                if (rbMale.Checked)
                {
                    pbPerson.Image = Resources.Male_512;
                }
                else
                {
                    pbPerson.Image = Resources.Female_512;
                }
                linkLabel2.Visible = false;
            }
        }

        private async void FrmAddEditPerson_Load(object sender, EventArgs e)
        {
            await ResetDefualtValues();
            if (_PersonId != -1)
                await EditPerson();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPerson.ImageLocation == null)
                pbPerson.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPerson.ImageLocation == null)
                pbPerson.Image = Resources.Female_512;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Choose a picture";
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "Image files|*.jpg;*.png;*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPerson.Load(openFileDialog1.FileName);
                linkLabel2.Visible = true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPerson.ImageLocation = null;
            if (rbMale.Checked)
            {
                pbPerson.Image = Resources.Male_512;
            }
            else
            {
                pbPerson.Image = Resources.Female_512;
            }
            linkLabel2.Visible = false;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void Box_Validating(TextBox box, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(box.Text.Trim()) && box != txtEmail)
            {
                errorProvider1.SetError(box, "Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(box, "");
                e.Cancel = false;
            }
            if (box == txtEmail && !string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!IsValidEmail(txtEmail.Text.Trim()))
                {
                    errorProvider1.SetError(box, "Invalid email, include an '@' in the email address");
                    e.Cancel = true;
                }
            }
        }

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            Box_Validating((TextBox)sender, e);
        }

        private bool HandlePersonImage()
        {
            if (pbPerson.ImageLocation != person!.ImagePath)
            {
                if (person.ImagePath != "")
                {
                    try
                    {
                        if (person.ImagePath != null)
                            File.Delete(person.ImagePath);
                    }
                    catch (IOException)
                    {

                    }
                }
                if (pbPerson.ImageLocation != null)
                {
                    string SourceFile = pbPerson.ImageLocation.ToString();
                    if (Utilization.CopyImageToProjectImagesFolder(ref SourceFile))
                    {
                        pbPerson.ImageLocation = SourceFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private async Task SaveData()
        {
            person!.FName = txtFirst.Text.Trim();
            person.SecName = txtSecond.Text.Trim();
            if (string.IsNullOrEmpty(txtThird.Text.Trim()))
                person.ThName = "";
            else
                person.ThName = txtThird.Text.Trim();
            person.LName = txtLast.Text.Trim();
            person.NationalNo = txtNationalNo.Text.Trim();
            if (rbMale.Checked)
                person.Gendor = 0;
            else
                person.Gendor = 1;
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                person.Email = "";
            else
                person.Email = txtEmail.Text.Trim();
            person.Address = txtAddres.Text.Trim();
            person.Date = dateTimePicker1.Value;
            person.Phone = txtPhone.Text.Trim();
            CountriesDto? country = await _countryService.GetCountryByCountryNameAsync(cbCountry.Text);
            person.NationaltyId = country!.CountryId;
            if (linkLabel2.Visible == true)
            {
                person.ImagePath = pbPerson.ImageLocation;
            }
            else
                person.ImagePath = "";
        }

        private async Task AddPerson()
        {
            CreatePersonDto createPerson = new()
            {
                FName = person!.FName,
                SecName = person.SecName,
                ThName = person.ThName,
                LName = person.LName,
                NationalNo = person.NationalNo,
                Gendor = person.Gendor,
                Email = person.Email,
                Address = person.Address,
                Date = person.Date,
                Phone = person.Phone,
                NationaltyId = person.NationaltyId,
                ImagePath = person.ImagePath
            };

            bool result = await _personService.AddPersonAsync(createPerson);
            if (!result)
                MessageBox.Show("Error Adding Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Person Added Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task UpdatePerson()
        {
            UpdatePersonDto updatePerson = new()
            {
                FName = person!.FName,
                SecName = person.SecName,
                ThName = person.ThName,
                LName = person.LName,
                NationalNo = person.NationalNo,
                Gendor = person.Gendor,
                Email = person.Email,
                Address = person.Address,
                Date = person.Date,
                Phone = person.Phone,
                NationaltyId = person.NationaltyId,
                ImagePath = person.ImagePath
            };

            bool result = await _personService.UpdatePersonAsync(_PersonId, updatePerson);
            if (!result)
                MessageBox.Show("Error Updating Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Person Updated Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!HandlePersonImage())
                return;

            await SaveData();
            if (_PersonId == -1)
                await AddPerson();
            else
                await UpdatePerson();

            person = await _personService.GetPersonByNationalNumberAsync(person!.NationalNo);

            if(personData != null)
            {
                foreach (SendPersonData handler in personData.GetInvocationList().Cast<SendPersonData>())
                    await handler();
            }
            Person?.Invoke(person!.PersonId);
            this.Close();
        }
    }
}
