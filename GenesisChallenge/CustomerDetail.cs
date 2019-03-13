using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using GenesisChallenge.Entities;

namespace GenesisChallenge
{
    public partial class CustomerDetail : Form
    {
        public CustomerDetail()
        {
            InitializeComponent();
        }

        public CustomerDetail(CustomerOrder customer)
        {
            InitializeComponent();
            // set variables and formats
            CustomerOrder = customer;
            txtEditFirstName.EditValue = customer.FirstName;
            txtEditLastName.EditValue = customer.LastName;
            lblReference.Text = customer.ReferenceNumber;
            lblOrderDate.Text = customer.OrderDate.ToString(ConfigurationManager.AppSettings["DateFormat"]);
            lblOrderValue.Text = customer.OrderValue.ToString(ConfigurationManager.AppSettings["CurrencyFormat"]);
        }

        /// <summary>
        ///     Just to hold the customer info
        /// </summary>
        public CustomerOrder CustomerOrder { get; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///     Control validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEditFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditFirstName.Text))
                e.Cancel = true;
            else
                CustomerOrder.FirstName = txtEditFirstName.Text;
        }

        /// <summary>
        ///     Control validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEditLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditLastName.Text))
                e.Cancel = true;
            else
                CustomerOrder.LastName = txtEditLastName.Text;
        }
    }
}