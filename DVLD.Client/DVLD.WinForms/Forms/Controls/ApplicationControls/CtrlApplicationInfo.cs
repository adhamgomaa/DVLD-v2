using DVLD.DTOs.Applications;
using DVLD.DTOs.ApplicationTypes;
using DVLD.DTOs.LicenseClass;
using DVLD.DTOs.LocalLicense;
using DVLD.DTOs.People;
using DVLD.DTOs.Users;
using DVLD.Shared.Enums;
using DVLD.WinForms.Forms.Licenses;
using DVLD.WinForms.Forms.People;
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

namespace DVLD.WinForms.Forms.Controls.ApplicationControls
{
    public partial class CtrlApplicationInfo : UserControl
    {
        private int _ApplicationId = -1;
        private int _localId = -1;
        AppStatusEnum status = AppStatusEnum.New;
        GetLocalLicenseDto? localLicense = new();
        GetPersonDto? person = new();
        //LocalLicenseApiService localLicenseService = new();
        public CtrlApplicationInfo()
        {
            InitializeComponent();
        }

        private void _ResetApplicationInfo()
        {
            lblDrivingAppID.Text = "[???]";
            lblClass.Text = "[???]";
            lblTest.Text = "[???]";
            lblAppId.Text = "[???]";
            lblStatus.Text = "[???]";
            lblType.Text = "[???]";
            lblFees.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblDate.Text = "[???]";
            lblSDate.Text = "[???]";
            lblCreate.Text = "[???]";
        }

        private async Task _LoadApplicationInfo()
        {
            _ApplicationId = localLicense!.AppId;
            GetAppDto? app = await new ApplicationApiService().GetAppByIdAsync(_ApplicationId);
            LicenseClassDto? licenseClass = await new LicenseClassApiService().GetLicenseClassByIdAsync(localLicense.ClassId);
            lblDrivingAppID.Text = localLicense.LocalId.ToString();
            lblClass.Text = licenseClass!.ClassName;
            lblTest.Text = await new LocalLicenseApiService().GetPassedTestCountAsync(localLicense.LocalId) + "/3";
            lblAppId.Text = _ApplicationId.ToString();
            status = app!.AppStatus;
            switch (status)
            {
                case AppStatusEnum.New:
                    lblStatus.Text = "New";
                    break;
                case AppStatusEnum.Cancelled:
                    lblStatus.Text = "Cancelled";
                    break;
                default:
                    lblStatus.Text = "Completed";
                    LinkLicense.Enabled = true;
                    break;
            }
            lblFees.Text = app.Fees.ToString();
            TypesDto? type = await new ApplicationTypeApiService().GetTypeByIdAsync(app.Type);
            lblType.Text = type!.Title;
            person = await new PersonApiService().GetPersonByIdAsync(app.PersonId);
            string fullName = person!.FName + " " + person.SecName + " " + person.ThName + " " + person.LName;
            lblApplicant.Text = fullName;
            lblDate.Text = app.AppDate.ToShortDateString();
            lblSDate.Text = app.StatusDate.ToShortDateString();
            GetUserDto? user = await new UserApiService().GetUserInfoByIdAsync(app.UserId);
            lblCreate.Text = user!.UserName;
        }

        public async Task LoadApplicationInfo(int localId)
        {
            localLicense = await new LocalLicenseApiService().GetLocalLicenseByIdAsync(localId);
            if (localLicense != null)
            {
                _localId = localId;
            await _LoadApplicationInfo();
            }
            else
            {
                _ResetApplicationInfo();
                MessageBox.Show("There is no Local License Application with ID = " + localId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void LinkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int licenseId = await new LicenseApiService().GetLicenseIdByLocalIdAsync(_localId);
            FrmDriverLicenseInfo licenseInfo = new(licenseId);
            licenseInfo.ShowDialog();
        }

        private void LinkPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonInfo personInfo = new(person!.PersonId);
            personInfo.ShowDialog();
        }
    }
}
