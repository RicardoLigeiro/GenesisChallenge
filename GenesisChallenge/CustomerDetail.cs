using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenesisChallenge.Entities;

namespace GenesisChallenge
{
    public partial class CustomerDetail : Form
    {
        public CustomerOrder CustomerOrder { get; private set; }

        public CustomerDetail()
        {
            InitializeComponent();
        }

        public CustomerDetail(CustomerOrder customer)
        {
            InitializeComponent();
            CustomerOrder = customer;
            txtEditFirstName.EditValue = customer.FirstName;
            txtEditLastName.EditValue = customer.LastName;
            lblReference.Text = customer.ReferenceNumber;
            lblOrderDate.Text = customer.OrderDate.ToString(ConfigurationManager.AppSettings["DateFormat"]);
            lblOrderValue.Text = customer.OrderValue.ToString(ConfigurationManager.AppSettings["CurrencyFormat"]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtEditFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditFirstName.Text))
            {
                e.Cancel = true;
            }
            else
            {
                CustomerOrder.FirstName = txtEditFirstName.Text;
            }
        }

        private void txtEditLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditLastName.Text))
            {
                e.Cancel = true;
            }
            else
            {
                CustomerOrder.LastName = txtEditLastName.Text;
            }
        }
    }
}
