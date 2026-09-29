using DVLD.Shared.Enums;
using DVLD.WinForms.Forms.Controls.TestsControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.WinForms.Forms.Tests
{
    public partial class FrmScheduleTypeTest : Form
    {
        private int _appointmentId = -1;
        private int _LocalId = -1;
        TestTypeEnum _testTypeId = TestTypeEnum.VisionTest;
        public FrmScheduleTypeTest(TestTypeEnum testTypeId, int localId, int appointment = -1)
        {
            InitializeComponent();
            _testTypeId = testTypeId;
            _LocalId = localId;
            _appointmentId = appointment;
        }

        private async void FrmScheduleTypeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _testTypeId;
            await ctrlScheduleTest1.LoadTest(_LocalId, _appointmentId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
