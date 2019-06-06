using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DataAccess.PrimaryTypes;

namespace CenturyFinCorpApp.UsrCtrl
{
    public partial class uclAddMember : UserControl
    {
        public uclAddMember()
        {
            InitializeComponent();

           


            //cmbDivision.DataSource = Zonal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            PartyMember pm = new PartyMember()
            {
                Name = txtName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim()
            };

            if(pm.PhoneNumber.StartsWith("+") == false)
            {
                pm.PhoneNumber = pm.PhoneNumber.Insert(0, "+91");
            }

            var result = PartyMember.AddPartyMember(pm);

            if (result)
                lblMessage.Text = $"{pm.PhoneNumber} added successfully";
            else
                lblMessage.Text = $"{pm.PhoneNumber} already exist";


            txtName.Clear();
            txtPhone.Clear();
            txtName.Focus();

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnAdd.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
