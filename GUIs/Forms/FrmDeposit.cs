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
    public partial class FrmDeposit : Form
    {
        private CommonService _CommonService;
        private DepositService _DepositService;
        private SaleOrderService _SaleOrderService;
        private BindingList<Deposit> _DepositList;
        private IList _DepositItemList;
        private Deposit _Deposit;

        public FrmDeposit()
        {
            InitializeComponent();
        }

        public int CustomerId { get; set; }

        private void FrmDeposit_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                if (_DepositService == null)
                    _DepositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();

                if (_SaleOrderService == null)
                    _SaleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();

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
                    _DepositService.GetDeposits(searchCriteria));

                var searchInfo = String.Format(
                    "ការ​ស្វែងរក​របស់​អ្នក​ផ្ដល់​លទ្ឋផល​ចំនួន {0}",
                    _DepositList.Count);
                lblSearchInfo.Text = searchInfo;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
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

        private void InitializeDepositList()
        {
            try
            {
                if (_DepositList == null)
                    _DepositList = new BindingList<Deposit>();

                dgvDeposit.DataSource = _DepositList;

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
                throw new ArgumentNullException("depositList", "Deposit");

            try
            {
                _DepositList.Clear();
                foreach (Deposit deposit in depositList)
                    _DepositList.Add(deposit);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvSearchResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_DepositList == null)
                return;

            if (_DepositList.Count == 0)
                return;

            if (dgvDeposit.CurrentRow == null)
                return;

            _Deposit = _DepositList[dgvDeposit.CurrentRow.Index];
            if (_Deposit == null)
                return;

            _DepositItemList = _DepositService.GetDepositItems(_Deposit.DepositId);
            var saleItemList = _SaleOrderService.GetSaleItems(_DepositItemList);

            var printInvoice = new PrintInvoice();
            printInvoice.ExcelInvoicePrintingHandler(
                AppContext.Counter.ReceiptPrinter,
                Application.StartupPath + @"\" + Resources.ConstDepositExcelFile,
                string.Empty,
                _Deposit.FKCustomer.CustomerName,
                _Deposit.FKCustomer.CustomerName,
                _Deposit.DepositNumber,
                (DateTime)_Deposit.DepositDate,
                _Deposit.Discount,
                _Deposit.AmountPaidInt,
                0,
                saleItemList,
                true);
        }

        private void btnPrint_MouseEnter(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = Resources.background_9;
        }

        private void btnPrint_MouseLeave(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = Resources.background_2;
        }

        private void btnDetailDeposit_MouseEnter(object sender, EventArgs e)
        {
            btnCancelDeposit.BackgroundImage = Resources.background_9;
        }

        private void btnDetailDeposit_MouseLeave(object sender, EventArgs e)
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
                if (_DepositList == null)
                    return;

                if (_DepositList.Count == 0)
                    return;

                if (dgvDeposit.CurrentRow == null)
                    return;

                _Deposit = _DepositList[dgvDeposit.CurrentRow.Index];
                if (_Deposit == null)
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

                var saleOrder = _SaleOrderService.GetSaleOrder(_Deposit);
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

                _DepositItemList = _DepositService.GetDepositItems(_Deposit.DepositId);
                var saleItemList = _SaleOrderService.GetSaleItems(_DepositItemList);

                _SaleOrderService.RecordSaleOrder(
                    saleItemList,
                    saleOrder.AmountSoldInt,
                    saleOrder.AmountSoldInt - saleOrder.AmountPaidInt,
                    0,
                    0,
                    saleOrder.FKCustomer,
                    false,
                    _Deposit.DepositNumber,
                    saleOrder.Discount,
                    _Deposit.AmountPaidInt,
                    true);

                _Deposit.AmountPaidInt += (_Deposit.AmountSoldInt - _Deposit.AmountPaidInt);
                _Deposit.AmountReturnInt = 0f;
                _Deposit.AmountReturnRiel = 0f;
                _Deposit.UpdateDate = DateTime.Now;                
                _DepositService.UpdateDeposit(_Deposit);

                var paymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();
                var payment =
                    new Model.Payments.Payment
                    {
                        PaymentDate = _Deposit.DepositDate,
                        PaymentAmount = _Deposit.AmountPaidInt,
                        SalesOrderId = _Deposit.DepositId,
                        CashierId = _Deposit.CashierId
                    };
                paymentService.ManagePayment(Resources.OperationRequestInsert, payment);

                RetrieveDataHandler();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(Resources.MsgCaptionUnknownError, exception.Message);
            }
        }

        private void btnCancelDeposit_Click(object sender, EventArgs e)
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

            if (_DepositList == null)
                return;

            if (_DepositList.Count == 0)
                return;

            if (dgvDeposit.CurrentRow == null)
                return;

            _Deposit = _DepositList[dgvDeposit.CurrentRow.Index];
            if (_Deposit == null)
                return;

            _DepositItemList = new List<DepositItem>();
            //_DepositService.GetDepositItems(_Deposit.DepositId);

            if (_Deposit == null)
                return;

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

            _Deposit.DepositDate = DateTime.Now;
            _Deposit = _DepositService.RecordDeposit(
                _DepositItemList,
                _Deposit.AmountSoldInt,
                _Deposit.AmountPaidInt,
                0,
                _Deposit.FKCustomer,
                _Deposit.DepositNumber,
                _Deposit.Discount,
                true);

            var paymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();
            var payment =
                new Model.Payments.Payment
                {
                    PaymentDate = _Deposit.DepositDate,
                    PaymentAmount = _Deposit.AmountPaidInt,
                    SalesOrderId = _Deposit.DepositId,
                    CashierId = _Deposit.CashierId
                };
            paymentService.ManagePayment(Resources.OperationRequestInsert, payment);

            RetrieveDataHandler();
        }
    }
}