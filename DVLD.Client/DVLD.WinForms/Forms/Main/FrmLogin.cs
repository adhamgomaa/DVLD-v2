using DVLD.DTOs.Users;
using DVLD.WinForms.Helpers;
using DVLD.WinForms.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Forms.Main
{
    public partial class FrmLogin : Form
    {
        readonly string keyPath = @"HKEY_CURRENT_USER\Software\DVLD";
        readonly string valueUsername = "UserName";
        readonly string valuePassword = "Password";
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async Task CheckLogin()
        {
            UserApiService service = new();
            LoginRequestDto requestDTO = new()
            {
                UserName = txtUsername.Text,
                Password = txtPass.Text
            };

            LoginUserDto? loggedUser = await service.LoginAsync(requestDTO);
            if (loggedUser != null)
            {
                if (loggedUser.IsActive)
                {
                    CurrentUser.User = loggedUser;
                    FrmMain home = new();
                    home.Show();
                    this.Hide();
                    home.FormClosed += (s, arg) =>
                    {
                        if (home.Logout)
                            this.Show();
                        else
                            Application.Exit();
                    };
                }
                else
                {
                    MessageBox.Show("Your account is deactivated, please contact your admin", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Invalid Username/Password", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetValueInRegistry(string username, string password)
        {
            string path = @"Software\DVLD";
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    using RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                    using RegistryKey key = basekey.OpenSubKey(path, true)!;
                    if (key != null)
                    {
                        key.DeleteValue(valueUsername);
                        key.DeleteValue(valuePassword);
                    }
                }
                else
                {
                    Registry.SetValue(keyPath, valueUsername, username, RegistryValueKind.String);
                    Registry.SetValue(keyPath, valuePassword, password, RegistryValueKind.String);
                }
            }
            catch (Exception)
            {

            }
        }

        private bool GetUsernameAndPass(ref string? username, ref string? password)
        {
            try
            {
                username = Registry.GetValue(keyPath, valueUsername, null) as string;
                password = Registry.GetValue(keyPath, valuePassword, null) as string;
                return username != null && password != null;
            }
            catch (Exception)
            {
            }
            return false;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPass.Text;
            if (cbRemember.Checked)
            {
                SetValueInRegistry(username, password);
            }
            else
            {
                SetValueInRegistry("", "");
            }
            await CheckLogin();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string? username = "";
            string? password = "";
            if (GetUsernameAndPass(ref username, ref password))
            {
                txtUsername.Text = username;
                txtPass.Text = password;
                cbRemember.Checked = true;
            }
        }
    }
}
