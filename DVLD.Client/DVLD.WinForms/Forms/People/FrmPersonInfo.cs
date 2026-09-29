using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Forms.People
{
    public partial class FrmPersonInfo : Form
    {
        private int _personId = -1;
        public FrmPersonInfo(int personId)
        {
            InitializeComponent();
            _personId = personId;
        }

        private async void FrmPersonInfo_Load(object sender, EventArgs e)
        {
            await ctrlPersonInfo1.LoadPersonInfo(_personId);
        }
    }
}
