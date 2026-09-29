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
    public partial class FrmShowLocalApplication : Form
    {
        private int _LocalId = -1;
        public FrmShowLocalApplication(int localId)
        {
            InitializeComponent();
            _LocalId = localId;
        }

        private async void FrmShowLocalApplication_Load(object sender, EventArgs e)
        {
            await ctrlApplicationInfo1.LoadApplicationInfo(_LocalId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
