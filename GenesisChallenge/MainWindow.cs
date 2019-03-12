using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using GenesisChallenge.Entities;
using GenesisChallenge.ExtensionMethods;
using GenesisChallenge.Repository;

namespace GenesisChallenge
{
    public partial class MainWindow : Form
    {
        /// <summary>
        ///     Our repository interface
        /// </summary>
        private readonly ICustomerRepository _repository;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(ICustomerRepository repository)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _repository = repository;
            LoadGridRecords();
        }

        private async void LoadGridRecords()
        {
            try
            {
                OrdersGridControl.DataSource = await _repository.GetCustomerOrdersAsync();
                // since the component has no idea of what is going to receive, we have to map and setup all by hand
                // hide some columns
                OrderGridView.Columns[nameof(CustomerOrder.FirstName)].Visible = false;
                OrderGridView.Columns[nameof(CustomerOrder.LastName)].Visible = false;
                OrderGridView.Columns[nameof(CustomerOrder.Id)].Visible = false;
                OrderGridView.Columns[nameof(CustomerOrder.OrderId)].Visible = false;

                // apply some formats
                OrderGridView.Columns[nameof(CustomerOrder.OrderDate)].DisplayFormat.FormatType = FormatType.DateTime;
                OrderGridView.Columns[nameof(CustomerOrder.OrderDate)].DisplayFormat.FormatString =
                    ConfigurationManager.AppSettings["DateFormat"];

                OrderGridView.Columns[nameof(CustomerOrder.OrderValue)].DisplayFormat.FormatType = FormatType.Numeric;
                OrderGridView.Columns[nameof(CustomerOrder.OrderValue)].DisplayFormat.FormatString =
                    ConfigurationManager.AppSettings["CurrencyFormat"];

                // no edit on the columns
                foreach (GridColumn gridColumn in OrderGridView.Columns) gridColumn.OptionsColumn.AllowEdit = false;

                // add button
                GridColumn unbColumn = OrderGridView.Columns.AddField("ShowCustomerDetail");
                unbColumn.VisibleIndex = OrderGridView.Columns.Count;
                unbColumn.OptionsFilter.AllowFilter = false;
                unbColumn.OptionsColumn.ShowCaption = false;
                unbColumn.OptionsColumn.AllowSort = DefaultBoolean.False;
                unbColumn.UnboundType = UnboundColumnType.Decimal;
                RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit
                {
                    TextEditStyle = TextEditStyles.HideTextEditor
                };
                edit.ButtonClick += ShowCustomerDetailClick;
                edit.Buttons[0].Caption = "View Detail";
                edit.Buttons[0].Kind = ButtonPredefines.Glyph;
                OrderGridView.Columns["ShowCustomerDetail"].ColumnEdit = edit;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error no fetching data: {e.Message}");
            }
        }

        private async void ShowCustomerDetailClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                CustomerOrder obj = ((CustomerOrder) OrderGridView.GetRow(OrderGridView.FocusedRowHandle));

                // we call the editor cloning the object as we only want to update the record after we have updated the database (for heavy data sources)
                // or in the end of the method, we could just reload the grid's data source
                CustomerDetail dlg =
                    new CustomerDetail(obj.Clone())
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PersistenceResult result = await _repository.SaveCustomerInfoAsync(dlg.CustomerOrder);
                    if (result.Success)
                    {
                        // In this case we have a simple situation, just replace
                        obj.FirstName = dlg.CustomerOrder.FirstName;
                        obj.LastName = dlg.CustomerOrder.LastName;
                        OrderGridView.UpdateCurrentRow();
                        MessageBox.Show("Record successfully saved!");
                    }
                    else
                    {
                        MessageBox.Show("An error has occurred when trying dto save the record");
                    }
                }
                dlg = null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}