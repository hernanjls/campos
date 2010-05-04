using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Model.Payments;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Payment;

namespace EzPos.GUIs.Forms
{
    public partial class FrmOutstandingPayment : Form
    {
        private CommonService _CommonService;
        private PaymentService _PaymentService;
        private UserService _UserService;
        private SaleOrderReport _SaleOrderReport;

        private BindingList<Payment> _PaymentList;
        private float _PaymentAmount;
        private DateTime _LastPaymentDate;
        private Payment _Payment;

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion

        public FrmOutstandingPayment()
        {
            _PaymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();
            InitializeComponent();
        }

        public string SalesOrderInfo
        {
            set
            {
                lblSalesOrderInfo.Text = value;
            }
        }        

        public SaleOrderReport SaleOrderReport
        {
            set
            {
                _SaleOrderReport = value;
            }
        }

        public int CustomerId { get; set; }

        private void FrmSaleOrderSearch_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                if (_PaymentService == null)
                    _PaymentService = ServiceFactory.GenerateServiceInstance().GeneratePaymentService();

                if (_UserService == null)
                    _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

                InitializePaymentList();

                RetrievePaymentHandler();

                ThreadStart threadStart = UpdateControlContent;
                var thread =
                    new Thread(threadStart)
                    {
                        Priority = ThreadPriority.Lowest
                    };
                thread.Start();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void RetrievePaymentHandler()
        {
            try
            {
                var searchCriteria =
                    new List<string>
                            {
                                "SalesOrderId|" + _SaleOrderReport.SalesOrderId
                            };

                IListToBindingList(_PaymentService.GetPayments(searchCriteria));

                var searchInfo = String.Format(
                    "ការ​ស្វែងរក​របស់​អ្នក​ផ្ដល់​លទ្ឋផល​ចំនួន {0}",
                    _PaymentList.Count);
                lblSearchInfo.Text = searchInfo;
                SetVisibleControls(false);
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

        private void InitializePaymentList()
        {
            try
            {
                if (_PaymentList == null)
                    _PaymentList = new BindingList<Payment>();

                dgvPaymentOutstanding.DataSource = _PaymentList;

                //dgvPaymentOutstanding.Columns["SaleOrderNumber"].DisplayIndex = 0;
                //dgvPaymentOutstanding.Columns["SaleOrderDate"].DisplayIndex = 1;
                //dgvPaymentOutstanding.Columns["CustomerName"].DisplayIndex = 2;
                //dgvPaymentOutstanding.Columns["CashierName"].DisplayIndex = 3;
                //dgvPaymentOutstanding.Columns["AmountSoldInt"].DisplayIndex = 4;
                //dgvPaymentOutstanding.Columns["AmountPaidInt"].DisplayIndex = 5;
                //dgvPaymentOutstanding.Columns["AmountReturnInt"].DisplayIndex = 6;
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void IListToBindingList(IList paymentList)
        {
            if (paymentList == null)
                throw new ArgumentNullException("paymentList", string.Empty);

            try
            {
                _PaymentList.Clear();
                _PaymentAmount = 0;
                foreach (Payment payment in paymentList)
                {
                    _PaymentList.Add(payment);
                    _PaymentAmount += payment.PaymentAmount;
                    _LastPaymentDate = (DateTime)payment.PaymentDate;
                }

                SetPaymentInfo();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_9;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_2;
        }

        private void SetVisibleControls(bool isVisible)
        {
            pnlPaymentInfo.Visible = !isVisible;

            lblSearchInfo.Visible = isVisible;
            dgvPaymentOutstanding.Visible = isVisible;

            btnPaymentDetail.Text = !pnlPaymentInfo.Visible ? "សង្ខេប" : "លំអិត";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _Payment = 
                    new Payment
                    {
                        CashierId = ((Int32) cmbUser.SelectedValue),
                        PaymentAmount = (string.IsNullOrEmpty(txtPaymentAmount.Text) ? 0 : float.Parse(txtPaymentAmount.Text)),
                        PaymentDate = DateTime.Now,
                        Remark = txtRemark.Text,
                        SalesOrderId = _SaleOrderReport.SalesOrderId
                    };

                _PaymentService.ManagePayment(
                    Resources.OperationRequestInsert,
                    _Payment);

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void SetPaymentInfo()
        {
            lblPaymentInfo.Text =
                "បានទទួល: $" + _PaymentAmount.ToString("N", AppContext.CultureInfo) + "\n" +
                "នៅខ្វះ: $" + (_SaleOrderReport.AmountSoldInt - _PaymentAmount).ToString("N", AppContext.CultureInfo) + "\n" +
                "ថ្ងៃទទួល: " + _LastPaymentDate.ToShortDateString() + "\n";
        }

        private void btnPaymentDetail_Click(object sender, EventArgs e)
        {
            SetVisibleControls(pnlPaymentInfo.Visible);
        }

        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;
            if (cmbUser.InvokeRequired)
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbUser.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                txtPaymentDate.Text = DateTime.Now.ToShortDateString();

                var userList = _UserService.GetUsers();

                cmbUser.DataSource = userList;
                cmbUser.DisplayMember = User.CONST_USER_LOG_IN_NAME;
                cmbUser.ValueMember = User.CONST_USER_ID;
                if (AppContext.User != null)
                    cmbUser.SelectedValue = AppContext.User.UserID;
            }
        }

        private void btnPaymentDetail_MouseEnter(object sender, EventArgs e)
        {
            btnPaymentDetail.BackgroundImage = Resources.background_9;
        }

        private void btnPaymentDetail_MouseLeave(object sender, EventArgs e)
        {
            btnPaymentDetail.BackgroundImage = Resources.background_2;
        }
    }
}