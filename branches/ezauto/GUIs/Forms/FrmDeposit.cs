using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.SaleOrder;

namespace EzPos.GUIs.Forms
{
    public partial class FrmDeposit : Form
    {
        private CommonService _commonService;
        private DepositService _depositService;
        private SaleOrderService _saleOrderService;
        private BindingList<Deposit> _depositList;
        private IList _depositItemList;
        private Deposit _deposit;

        public FrmDeposit()
        {
            InitializeComponent();
        }

        public int CustomerId { get; set; }

        private void FrmDeposit_Load(object sender, EventArgs e)
        {
            try
            {
                if (_commonService == null)
                    _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                if (_depositService == null)
                    _depositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();

                if (_saleOrderService == null)
                    _saleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();

                InitializeDepositList();

                RetrieveDataHandler();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
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
                        "CustomerId|" + CustomerId,
                        "AmountPaidInt < AmountSoldInt",
                        "DepositNumber NOT IN (SELECT ReferenceNum FROM TDeposits WHERE ReferenceNum IS NOT NULL)"
                    };

                IListToBindingList(
                    _depositService.GetDeposits(searchCriteria));

                var searchInfo = String.Format(
                    "ការ​ស្វែងរក​របស់​អ្នក​ផ្ដល់​លទ្ឋផល​ចំនួន {0}",
                    _depositList.Count);
                lblSearchInfo.Text = searchInfo;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }            
        }

        private void BtnCancelMouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void BtnCancelMouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        private void InitializeDepositList()
        {
            try
            {
                if (_depositList == null)
                    _depositList = new BindingList<Deposit>();

                dgvDeposit.DataSource = _depositList;

                dgvDeposit.Columns["DepositNumber"].DisplayIndex = 0;
                dgvDeposit.Columns["DepositDate"].DisplayIndex = 1;
                dgvDeposit.Columns["CashierName"].DisplayIndex = 2;
                dgvDeposit.Columns["AmountSoldInt"].DisplayIndex = 3;
                dgvDeposit.Columns["AmountPaidInt"].DisplayIndex = 4;
                dgvDeposit.Columns["AmountReturnInt"].DisplayIndex = 5;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void IListToBindingList(IList depositList)
        {
            if (depositList == null)
                throw new ArgumentNullException("depositList", Resources.MsgEmptyBindingList);

            try
            {
                _depositList.Clear();
                foreach (Deposit deposit in depositList)
                    _depositList.Add(deposit);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DgvSearchResultCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e == null)
            //    return;

            //if(dgvDeposit.CurrentRow == null)
            //    return;

            //var saleOrderReport = _DepositList[e.RowIndex];
            //if(saleOrderReport == null)
            //    return;

            //Visible = false;
            //using(var frmOutstandingPayment = new FrmOutstandingPayment())
            //{
            //    //frmOutstandingPayment.SaleOrderReport = saleOrderReport;
            //    //frmOutstandingPayment.SalesOrderInfo =
            //    //    "វិក័យប័ត្រ: " + saleOrderReport.SaleOrderNumber + "\n" +
            //    //    "សរុប: $" + saleOrderReport.AmountSoldInt.ToString("N", AppContext.CultureInfo) + "\n" +
            //    //    "ថ្ងៃលក់: " + saleOrderReport.SaleOrderDate.ToShortDateString() + "\n";

            //    //if (frmOutstandingPayment.ShowDialog(this) == DialogResult.OK)
            //    //{
                    
            //    //}
            //    Visible = true;
            //}
        }

        private void BtnPrintClick(object sender, EventArgs e)
        {
            if (_depositList == null)
                return;

            if (_depositList.Count == 0)
                return;

            if (dgvDeposit.CurrentRow == null)
                return;

            _deposit = _depositList[dgvDeposit.CurrentRow.Index];
            if (_deposit == null)
                return;

            _depositItemList = _depositService.GetDepositItems(_deposit.DepositId);
            var saleItemList = _saleOrderService.GetSaleItems(_depositItemList);

            var printInvoice = new PrintInvoice();
            printInvoice.ExcelInvoicePrintingHandler(
                AppContext.Counter.ReceiptPrinter,
                Application.StartupPath + @"\" + Resources.ConstDepositExcelFile,
                string.Empty,
                _deposit.FKCustomer.CustomerName,
                _deposit.FKCustomer.CustomerName,
                _deposit.DepositNumber,
                (DateTime)_deposit.DepositDate,
                _deposit.Discount,
                _deposit.AmountPaidInt,
                0,
                saleItemList,
                true);
        }

        private void BtnPrintMouseEnter(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = Resources.background_9;
        }

        private void BtnPrintMouseLeave(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = Resources.background_2;
        }

        private void BtnDetailDepositMouseEnter(object sender, EventArgs e)
        {
            btnCancelDeposit.BackgroundImage = Resources.background_9;
        }

        private void BtnDetailDepositMouseLeave(object sender, EventArgs e)
        {
            btnCancelDeposit.BackgroundImage = Resources.background_2;
        }

        private void BtnDeliverMouseEnter(object sender, EventArgs e)
        {
            btnDeliver.BackgroundImage = Resources.background_9;
        }

        private void BtnDeliverMouseLeave(object sender, EventArgs e)
        {
            btnDeliver.BackgroundImage = Resources.background_2;
        }

        private void BtnDeliverClick(object sender, EventArgs e)
        {
            try
            {
                if (_depositList == null)
                    return;

                if (_depositList.Count == 0)
                    return;

                if (dgvDeposit.CurrentRow == null)
                    return;

                _deposit = _depositList[dgvDeposit.CurrentRow.Index];
                if (_deposit == null)
                    return;

                var briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                var detailMsg = Resources.MsgUserPermissionDeny;
                if (!UserService.AllowToPerform(Resources.PermissionEditDeposit))
                {
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                var saleOrder = _saleOrderService.GetSaleOrder(_deposit);
                if (saleOrder == null)
                    return;

                briefMsg = "អំពីការប្រគល់របស់";
                detailMsg = Resources.MsgConfirmDeliverProduct;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if(frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                _depositItemList = _depositService.GetDepositItems(_deposit.DepositId);
                var saleItemList = _saleOrderService.GetSaleItems(_depositItemList);

                _saleOrderService.RecordSaleOrder(
                    saleItemList,
                    saleOrder.AmountSoldInt,
                    saleOrder.AmountSoldInt - saleOrder.AmountPaidInt,
                    0,
                    0,
                    saleOrder.FKCustomer,
                    false,
                    _deposit.DepositNumber,
                    saleOrder.Discount,
                    _deposit.AmountPaidInt,
                    true);

                _deposit.AmountPaidInt += (_deposit.AmountSoldInt - _deposit.AmountPaidInt);
                _deposit.AmountReturnInt = 0f;
                _deposit.AmountReturnRiel = 0f;
                _deposit.UpdateDate = DateTime.Now;                
                _depositService.UpdateDeposit(_deposit);

                var paymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();
                var payment =
                    new Model.Payments.Payment
                    {
                        PaymentDate = _deposit.DepositDate,
                        PaymentAmount = _deposit.AmountPaidInt,
                        SalesOrderId = _deposit.DepositId,
                        CashierId = _deposit.CashierId
                    };
                paymentService.ManagePayment(Resources.OperationRequestInsert, payment);

                RetrieveDataHandler();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(Resources.MsgCaptionUnknownError, exception.Message);
            }
        }

        private void BtnCancelDepositClick(object sender, EventArgs e)
        {
            var briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
            var detailMsg = Resources.MsgUserPermissionDeny;
            if (!UserService.AllowToPerform(Resources.PermissionCancelDeposit))
            {
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            if (_depositList == null)
                return;

            if (_depositList.Count == 0)
                return;

            if (dgvDeposit.CurrentRow == null)
                return;

            _deposit = _depositList[dgvDeposit.CurrentRow.Index];
            if (_deposit == null)
                return;

            _depositItemList = new List<DepositItem>();
            //_DepositService.GetDepositItems(_Deposit.DepositId);

            //if (_Deposit == null)
            //    return;

            //if (_DepositItemList.Count == 0)
            //    return;

            briefMsg = "អំពីការបោះបង់";
            detailMsg = "សូម​មេត្តា​ចុច​លើ​ប៊ូតុង យល់​ព្រម ដើម្បី​បញ្ជាក់​ពី​ការ​ប្រគល់​សង​។";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            _deposit.DepositDate = DateTime.Now;
            _deposit = _depositService.RecordDeposit(
                _depositItemList,
                _deposit.AmountSoldInt,
                _deposit.AmountPaidInt,
                0,
                _deposit.FKCustomer,
                _deposit.DepositNumber,
                _deposit.Discount,
                true);

            var paymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();
            var payment =
                new Model.Payments.Payment
                {
                    PaymentDate = _deposit.DepositDate,
                    PaymentAmount = _deposit.AmountPaidInt,
                    SalesOrderId = _deposit.DepositId,
                    CashierId = _deposit.CashierId
                };
            paymentService.ManagePayment(Resources.OperationRequestInsert, payment);

            RetrieveDataHandler();
        }
    }
}