using DVLD.DTOs.Applications;
using DVLD.DTOs.ApplicationTypes;
using DVLD.DTOs.LicenseClass;
using DVLD.DTOs.LocalLicense;
using DVLD.DTOs.People;
using DVLD.DTOs.Users;
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

namespace DVLD.WinForms.Forms.Licenses
{
    public partial class FrmNewLocal : Form
    {
        private int _localId = -1;
        GetLocalLicenseDto _localLicens = new();
        LocalLicenseApiService _localService = new();
        public FrmNewLocal()
        {
            InitializeComponent();
        }

        public FrmNewLocal(int localId)
        {
            InitializeComponent();
            _localId = localId;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_localId != -1)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectTab(1);
                return;
            }

            if (ctrlFilterPersonInfo1.PersonId != -1)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectTab(1);
            }
        }

        private async Task _LoadLicenseClassData()
        {
            List<LicenseClassDto> list = await new LicenseClassApiService().GetAllLicenseClassAsync() ?? [];
            foreach (var license in list)
                cbClass.Items.Add(license.ClassName);
        }

        private async Task _ResetDefaultData()
        {
            TypesDto type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.NewLocalDrivingLicense) ?? new TypesDto();
            lblFees.Text = type.Fees.ToString();
            await _LoadLicenseClassData();

            if (_localId == -1)
            {
                lblAddEdit.Text = "New Local Driving License Application";
                tabPage2.Enabled = false;
                ctrlFilterPersonInfo1.FilterFoucs();
                lblAppDate.Text = DateTime.Now.ToShortDateString();
                lblCreate.Text = CurrentUser.User!.UserName;
                cbClass.SelectedIndex = 2;
            }
            else
            {
                lblAddEdit.Text = "Update Local Driving License Application";
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
            }
            this.Text = lblAddEdit.Text;
        }

        private async Task _LoadApplicationInfo()
        {
            ctrlFilterPersonInfo1.FilterEnabled = false;
            _localLicens = await _localService.GetLocalLicenseByIdAsync(_localId) ?? new GetLocalLicenseDto();
            GetAppDto app = await new ApplicationApiService().GetAppByIdAsync(_localLicens.AppId) ?? new GetAppDto();
            await ctrlFilterPersonInfo1.LoadPersonInfo(app.PersonId);
            lblAppDate.Text = app.AppDate.ToShortDateString();
            GetUserDto user = await new UserApiService().GetUserInfoByIdAsync(app.UserId) ?? new GetUserDto();
            lblCreate.Text = user.UserName;
            cbClass.SelectedIndex = _localLicens.ClassId - 1;
            lblAppID.Text = _localLicens.AppId.ToString();
        }

        private async void FrmNewLocal_Load(object sender, EventArgs e)
        {
            await _ResetDefaultData();
            if (_localId != -1)
                await _LoadApplicationInfo();
        }

        private async Task<bool> _IsPersonAgeMatchTheLicenseClass()
        {
            LicenseClassDto licenseClass = await new LicenseClassApiService().GetLicenseClassByClassNameAsync(cbClass.Text) ?? new LicenseClassDto();
            DateTime minAge = DateTime.Now.AddYears(-licenseClass.Age);
            GetPersonDto person = await new PersonApiService().GetPersonByIdAsync(ctrlFilterPersonInfo1.PersonId) ?? new GetPersonDto();
            if (person.Date > minAge)
                return true;
            return false;
        }

        private async Task AddLocalLicense()
        {
            TypesDto type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.NewLocalDrivingLicense) ?? new TypesDto();
            int classId = (await new LicenseClassApiService().GetLicenseClassByClassNameAsync(cbClass.Text) ?? new LicenseClassDto()).ClassId;
            CreateLocalLicenseDto createLicense = new()
            {
                PersonId = ctrlFilterPersonInfo1.PersonId,
                Type = AppTypeEnum.NewLocalDrivingLicense,
                AppStatus = AppStatusEnum.New,
                StatusDate = DateTime.Now,
                Fees = type.Fees,
                UserId = CurrentUser.User!.UserId,
                ClassId = classId
            };
            bool result = await _localService.AddLocalLicenseAsync(createLicense);
            if (!result)
                MessageBox.Show("Error Adding Local License Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Local License Application Added Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task UpdateLocalLicense()
        {
            TypesDto type = await new ApplicationTypeApiService().GetTypeByIdAsync(AppTypeEnum.NewLocalDrivingLicense) ?? new TypesDto();
            int classId = (await new LicenseClassApiService().GetLicenseClassByClassNameAsync(cbClass.Text) ?? new LicenseClassDto()).ClassId;
            UpdateLocalLicenseDto updateLicense = new()
            {
                PersonId = ctrlFilterPersonInfo1.PersonId,
                Type = AppTypeEnum.NewLocalDrivingLicense,
                AppStatus = AppStatusEnum.New,
                StatusDate = DateTime.Now,
                Fees = type.Fees,
                UserId = CurrentUser.User!.UserId,
                ClassId = classId
            };
            bool result = await _localService.UpdateLocalLicenseAsync(_localLicens.LocalId, updateLicense);
            if (!result)
                MessageBox.Show("Error Updating Local License Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Local License Application Updated Successfuly!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int classId = (await new LicenseClassApiService().GetLicenseClassByClassNameAsync(cbClass.Text) ?? new LicenseClassDto()).ClassId;
            int personId = ctrlFilterPersonInfo1.PersonId;
            if (personId == -1)
            {
                MessageBox.Show("Please choose a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool isMatch = await _IsPersonAgeMatchTheLicenseClass();
            if (isMatch)
            {
                MessageBox.Show("Choose another License Class, the selected person is under allowed of age", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool checkLicense = await _localService.CheckPersonHasSameClassAsync(personId, classId);
            if (checkLicense)
            {
                MessageBox.Show("Choose another License Class, the selected person already have an active application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_localId == -1)
                await AddLocalLicense();
            else
                await UpdateLocalLicense();

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
