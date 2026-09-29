using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Forms.Users
{
    public partial class FrmUserInfo : Form
    {
        private int _userId = -1;
        public FrmUserInfo(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private async void FrmUserInfo_Load(object sender, EventArgs e)
        {
            await ctrlUserInfo1.LoadUserInfo(_userId);
        }
    }
}
