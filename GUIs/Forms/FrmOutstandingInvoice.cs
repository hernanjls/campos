using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Forms
{
    public partial class FrmOutstandingInvoice : Form
    {
        private CommonService _CommonService;
        private BindingList<SaleOrderReport> _SaleOrderReportList;
        //private string _SONumber = string.Empty;

        public FrmOutstandingInvoice()
        {
            InitializeComponent();
        }

        //public string SONumber
        //{
        //    get { return _SONumber; }
        //}

        public int CustomerId { get; set; }

        private void FrmSaleOrderSearch_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                InitializeSaleOrderReportList();

                RetrieveDataHandler();

                //ThreadStart threadStart = UpdateControlContent;
                //var thread = 
                //    new Thread(threadStart)
                //    {
                //        Priority = ThreadPriority.Lowest
                //    };
                //thread.Start();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void RetrieveDataHandler()
        {
            try
            {
                var searchCriteria =
                    new List<string>
                            {
                                "CustomerID|" + CustomerId,
                                "AmountReturnInt < 0"
                            };

                var saleOrderService =
                    ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
                IListToBindingList(
                    saleOrderService.GetSaleOrders(searchCriteria));

                var searchInfo = String.Format(
                    "ការ​ស្វែងរក​របស់​អ្នក​ផ្ដល់​លទ្ឋផល​ចំនួន {0}",
                    _SaleOrderReportList.Count);
                lblSearchInfo.Text = searchInfo;
                //SetVisibleControls(false);
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }            
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        private void InitializeSaleOrderReportList()
        {
            try
            {
                if (_SaleOrderReportList == null)
                    _SaleOrderReportList = new BindingList<SaleOrderReport>();

                dgvInvoiceOutstanding.DataSource = _SaleOrderReportList;

                dgvInvoiceOutstanding.Columns["SaleOrderNumber"].DisplayIndex = 0;
                dgvInvoiceOutstanding.Columns["SaleOrderDate"].DisplayIndex = 1;
                dgvInvoiceOutstanding.Columns["CustomerName"].DisplayIndex = 2;
                dgvInvoiceOutstanding.Columns["CashierName"].DisplayIndex = 3;
                dgvInvoiceOutstanding.Columns["AmountSoldInt"].DisplayIndex = 4;
                dgvInvoiceOutstanding.Columns["AmountPaidInt"].DisplayIndex = 5;
                dgvInvoiceOutstanding.Columns["AmountReturnInt"].DisplayIndex = 6;
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void IListToBindingList(IList saleOrderReportList)
        {
            if (saleOrderReportList == null)
                throw new ArgumentNullException("saleOrderReportList", "Sale Order List");

            try
            {
                _SaleOrderReportList.Clear();
                foreach (SaleOrderReport saleOrderReport in saleOrderReportList)
                    _SaleOrderReportList.Add(saleOrderReport);
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvSearchResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e == null)
            //    return;

            //if (_SaleOrderReportList.Count == 0)
            //    return;

            //_SONumber = (_SaleOrderReportList[e.RowIndex]).SaleOrderNumber;
            //DialogResult = DialogResult.OK;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under construction");
        }

        private void tsmIndividual_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under construction");
        }

        private void dgvSearchResult_MouseClick(object sender, MouseEventArgs e)
        {
            if(dgvInvoiceOutstanding.CurrentRow == null)
                return;

            //dgvInvoiceOutstanding.ContextMenu = cmsOutstandingInvoice.ContextMenu;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    //ImportIndividualCatalog();
                    break;
                case MouseButtons.Right:
                        cmsOutstandingInvoice.Show(dgvInvoiceOutstanding, e.X, e.Y);
                    break;
            }
        }
    }
}