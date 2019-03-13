using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using GenesisChallenge.Entities;
using GenesisChallenge.ExtensionMethods;
using GenesisChallenge.Repository;

namespace GenesisChallenge
{
    public partial class MainWindow : Form
    {
        /// <summary>
        ///     Our repository interface dependency injection
        /// </summary>
        private readonly ICustomerRepository _repository;

        private int _currentPage;

        private bool _loadingRecords;

        private int _numberOfRecords;

        private string _sortColumn = nameof(CustomerOrder.ReferenceNumber);

        private ColumnSortOrder _sortDirection = ColumnSortOrder.Ascending;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(ICustomerRepository repository)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _repository = repository;
            SetControlsInitialValues();
        }

        /// <summary>
        ///     Calc for the total pages
        /// </summary>
        private int TotalPages => (_numberOfRecords + PageSize - 1) / PageSize;

        /// <summary>
        ///     Page size access
        /// </summary>
        private int PageSize => (int) cbxPageSize.SelectedItem;

        /// <summary>
        ///     Options for the pager sizes
        /// </summary>
        private List<int> _pagerOptions => new List<int> {2, 15, 25};

        /// <summary>
        ///     Wrap the first load
        /// </summary>
        private void SetControlsInitialValues()
        {
            cbxPageSize.DataSource = _pagerOptions;
            cbxPageSize.SelectedIndex = 1;
            UpdatePagesInfo();
            btnPrevious.Enabled = false;
            LoadGridRecords();
            cbxPageSize.SelectedIndexChanged += cbxPageSize_SelectedIndexChanged;
        }

        /// <summary>
        ///     Pager buttons
        /// </summary>
        private void UpdateNavigationButtonsState()
        {
            btnPrevious.Enabled = _currentPage > 0;
            btnNext.Enabled = _currentPage < TotalPages - 1 && TotalPages > 1;
        }

        /// <summary>
        ///     Fetch the records
        /// </summary>
        private async void LoadGridRecords()
        {
            try
            {
                _loadingRecords = true;
                ShowLoadingPanel();

                // invoke the repository
                QueryResult<CustomerOrder> result = await _repository.GetCustomerOrdersAsync(_currentPage * PageSize,
                    PageSize, _sortColumn,
                    _sortDirection == ColumnSortOrder.Ascending ? SortDirection.Ascending : SortDirection.Descending);
                OrdersGridControl.DataSource = result.Records;
                _numberOfRecords = result.NumberOfRecords;
                ArrangeGridViewColumns();
                UpdatePagesInfo();
                UpdateNavigationButtonsState();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error no fetching data: {e.Message}");
            }
            finally
            {
                _loadingRecords = false;
                HideLoadingPanel();
            }
        }

        private void ArrangeGridViewColumns()
        {
            if (OrdersGridControl.DataSource != null)
            {
                OrderGridView.PopulateColumns();

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
                foreach (GridColumn gridColumn in OrderGridView.Columns)
                {
                    if (TotalPages > 1)
                        gridColumn.SortMode = ColumnSortMode.Custom;
                    gridColumn.OptionsColumn.AllowEdit = false;
                }

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

                OrderGridView.Columns[_sortColumn].SortOrder = _sortDirection;
            }
        }

        /// <summary>
        ///     Shows the loading panel
        /// </summary>
        private void ShowLoadingPanel()
        {
            OrdersGridControl.Enabled = false;
            Control parent = progressPanel1.Parent;
            progressPanel1.Location = new Point(parent.Bounds.X + parent.Bounds.Width / 2 - progressPanel1.Width / 2,
                parent.Bounds.Y + parent.Bounds.Height / 2 - progressPanel1.Height / 2);
            progressPanel1.Visible = true;
        }

        /// <summary>
        ///     Hides the loading panel
        /// </summary>
        private void HideLoadingPanel()
        {
            progressPanel1.Visible = false;
            OrdersGridControl.Enabled = true;
        }

        /// <summary>
        ///     Updates the pages label info
        /// </summary>
        private void UpdatePagesInfo()
        {
            lblPages.Text = "Pages: ";
            if (_numberOfRecords > 0)
                lblPages.Text += $"{_currentPage + 1} / {TotalPages}";
            else
                lblPages.Text += "0";
        }

        /// <summary>
        ///     Opens the popup for the customer edition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ShowCustomerDetailClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                ShowLoadingPanel();
                CustomerOrder obj = (CustomerOrder)OrderGridView.GetRow(OrderGridView.FocusedRowHandle);

                // we call the editor cloning the object as we only want to update the record after we have updated the database (for heavy data sources)
                // or in the end of the method, we could just reload the grid's data source
                CustomerDetail dlg =
                    new CustomerDetail(obj.Clone())
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };

                // ok?
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // invoke repository
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
            finally
            {
                HideLoadingPanel();
            }
        }

        private void OrderGridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            e.Handled = true;
            if (e.Column.FieldName != "ShowCustomerDetail" &&
                (_sortColumn != e.Column.FieldName ||
                 _sortColumn == e.Column.FieldName && _sortDirection != e.SortOrder)
            )
            {
                if (_sortColumn != e.Column.FieldName)
                    _sortDirection = ColumnSortOrder.Ascending;
                else if (_sortColumn == e.Column.FieldName && _sortDirection != e.SortOrder)
                    _sortDirection = e.SortOrder;

                _sortColumn = e.Column.FieldName;
                _loadingRecords = true;
                LoadGridRecords();
            }
        }
        
        private void cbxPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loadingRecords)
            {
                _currentPage = 0;
                LoadGridRecords();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _currentPage--;
            LoadGridRecords();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPage++;
            LoadGridRecords();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}