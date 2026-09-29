using DVLD.WinForms.Forms.People;
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
    public partial class CtrlFilterPersonInfo : UserControl
    {
        public event Action<int>? OnPersonSelected;
        protected virtual void personSelected(int personId)
        {
            OnPersonSelected?.Invoke(personId);
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                button1.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        public int PersonId
        {
            get
            {
                return ctrlPersonInfo1.PersonId;
            }
        }

        public void FilterFoucs()
        {
            tbFilter.Focus();
        }

        private void _LoadFiltersInBox()
        {
            cbFilter.Items.Add("National No.");
            cbFilter.Items.Add("Person ID");
            cbFilter.SelectedIndex = 0;
        }
        public CtrlFilterPersonInfo()
        {
            InitializeComponent();
        }

        public async Task LoadPersonInfo(int personId)
        {
            tbFilter.Text = personId.ToString();
            cbFilter.SelectedIndex = 1;
            await FindNow();
        }

        private async Task FindNow()
        {
            switch (cbFilter.Text)
            {
                case "Person ID":
                    await ctrlPersonInfo1.LoadPersonInfo(int.Parse(tbFilter.Text));
                    break;
                case "National No.":
                    await ctrlPersonInfo1.LoadPersonInfo(tbFilter.Text);
                    break;
                default:
                    break;
            }
            if (OnPersonSelected != null && FilterEnabled)
                personSelected(PersonId);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await FindNow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson addEditPerson = new();
            addEditPerson.Person += LoadPersonInfo;
            addEditPerson.ShowDialog();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnAdd.PerformClick();

            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CtrlFilterPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadFiltersInBox();
        }
    }
}
