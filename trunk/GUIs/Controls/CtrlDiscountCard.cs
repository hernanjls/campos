using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUI;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Utility;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlDiscountCard : UserControl
    {
        private CommonService _CommonService;
        private CustomerService _CustomerService;
        private BindingList<object> _DiscountCardList;

        public CtrlDiscountCard()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
        }

        public CustomerService CustomerService
        {
            set { _CustomerService = value; }
        }

        private void CtrlDiscountCard_Load(object sender, EventArgs e)
        {
            if (_CommonService == null)
                _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
            if (_CustomerService == null)
                _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();


            try
            {
                if (!UserService.AllowToPerform(Resources.PermissionViewCartResultInfo))
                {
                    lblResultInfo.Visible = false;
                }
                if (_CustomerService == null)
                    _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();

                InitialDiscountCardList();

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart) {IsBackground = true};
                thread.Start();

                var objList = _CustomerService.GetCustomers();
                cmbCustomer.CustomizedDataBinding(
                    objList,
                    Customer.CONST_CUSTOMER_NAME,
                    Customer.CONST_CUSTOMER_ID,
                    false);

                var customerList = new List<Customer>();
                foreach (Customer customer in objList)
                    customerList.Add(customer);

                cmbCustomerHidden.CustomizedDataBinding(
                    customerList,
                    Customer.CONST_CUSTOMER_NAME,
                    Customer.CONST_CUSTOMER_ID,
                    false);

                btnSearch_Click(sender, e);
                //IListToBindingList(
                //    _CustomerService.GetDiscountCards());
                //dgvDiscountCard.Refresh();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvDiscountCard_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FrmExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void InitialDiscountCardList()
        {
            try
            {
                if (_DiscountCardList == null)
                    _DiscountCardList = new BindingList<object>();

                dgvDiscountCard.DataSource = _DiscountCardList;

                dgvDiscountCard.Columns["PrintCheck"].DisplayIndex = 0;
                dgvDiscountCard.Columns["CardNumber"].DisplayIndex = 1;
                dgvDiscountCard.Columns["DiscountCardTypeID"].DisplayIndex = 2;
                dgvDiscountCard.Columns["DiscountPercentage"].DisplayIndex = 3;
                dgvDiscountCard.Columns["CustomerStr"].DisplayIndex = 4;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvDiscountCard_SelectionChanged(object sender, EventArgs e)
        {
            SetDiscountCardInfo();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (cmbDiscountType.SelectedValue == null)
                return;

            if (txtNumCard.Text.Length == 0)
                return;

            try
            {
                if (!UserService.AllowToPerform(Resources.PermissionAddCard))
                {
                    const string briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                    var detailMsg = Resources.MsgUserPermissionDeny;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                var discountCardTypeID = Int32.Parse(cmbDiscountType.SelectedValue.ToString(), AppContext.CultureInfo);
                var discountCardTypeStr = ((AppParameter) cmbDiscountType.SelectedItem).ParameterLabel;
                var discountPercentage =
                    float.Parse(((AppParameter) cmbDiscountType.SelectedItem).ParameterValue, AppContext.CultureInfo);

                var nbrDiscountCard = Int32.Parse(txtNumCard.Text, AppContext.CultureInfo);
                for (var counter = 0; counter < nbrDiscountCard; counter++)
                {
                    var discountCard = new DiscountCard
                                           {
                                               DiscountCardTypeID = discountCardTypeID,
                                               DiscountCardTypeStr = discountCardTypeStr,
                                               DiscountPercentage = discountPercentage,
                                               ExpireDate = DateTime.Now,
                                               AllowDiscount = 1
                                           };
                    _CustomerService.DiscountCardManagement(
                        discountCard,
                        Resources.OperationRequestInsert);

                    _DiscountCardList.Add(discountCard);
                }
                dgvDiscountCard.Refresh();
                SetDiscountCardInfo();
                UpdateResultInfo();
                EnableActionButton();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string briefMsg, detailMsg;

            if (!UserService.AllowToPerform(Resources.PermissionDeleteCard))
            {
                briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }

                //ExtendedMessageBox.InformMessage(Resources.MsgUserPermissionDeny);
                //return;
            }

            //if (!ExtendedMessageBox.ConfirmMessage(
            //        "MsgOperationRequestDelete",
            //        "\n\n" + dgvDiscountCard.CurrentRow.Cells["CardNumber"].Value))
            //    return;

            //string briefMsg, detailMsg;
            briefMsg = "អំពីការលុប";
            detailMsg = Resources.MsgOperationRequestDelete + "\n" +
                        dgvDiscountCard.CurrentRow.Cells["CardNumber"].Value + " ?";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                _CustomerService.DiscountCardManagement(
                    (DiscountCard) _DiscountCardList[dgvDiscountCard.CurrentRow.Index],
                    Resources.OperationRequestDelete);

                _DiscountCardList.RemoveAt(dgvDiscountCard.CurrentRow.Index);
                dgvDiscountCard.Refresh();
                UpdateResultInfo();
                EnableActionButton();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var cardList = new List<BarCode>();
            for (int counter = 0; counter < _DiscountCardList.Count; counter++)
            {
                if (rdbPrintSelected.Checked)
                {
                    if (dgvDiscountCard.Rows[counter].Cells["PrintCheck"].Value == null)
                        continue;

                    if (!bool.Parse(dgvDiscountCard.Rows[counter].Cells["PrintCheck"].Value.ToString()))
                        continue;
                }

                var barCode = new BarCode
                                  {
                                      BarCodeValue = ((DiscountCard) _DiscountCardList[counter]).CardNumber,
                                      DisplayStr = ""
                                  };
                cardList.Add(barCode);
            }
            PrintDiscountCard.InializePrinting(cardList);
        }

        private void chbUsed_CheckedChanged(object sender, EventArgs e)
        {
            chbNonUsed.Checked = !chbUsed.Checked;
            //if ((!chbUsed.Checked) && (!chbNonUsed.Checked))
            //    chbUsed.Checked = true;
            //btnSearch_Click(sender, e);
        }

        private void chbNonUsed_CheckedChanged(object sender, EventArgs e)
        {
            chbUsed.Checked = !chbNonUsed.Checked;
            //if ((!chbNonUsed.Checked) && (!chbUsed.Checked))
            //    chbNonUsed.Checked = true;
            //btnSearch_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchCriteria = new List<string>();
            if (txtCardNum.Text.Length != 0)
                searchCriteria.Add("CardNumber|" + StringHelper.Right("000000000" + txtCardNum.Text, 9));

            if (cmbDCardType.SelectedIndex != -1)
                searchCriteria.Add("DiscountCardTypeID|" + cmbDCardType.SelectedValue);

            if (cmbCustomer.SelectedIndex != -1)
                searchCriteria.Add("CustomerID|" + cmbCustomer.SelectedValue);

            if (!chbUsed.Checked)
                searchCriteria.Add("CustomerID = 0");
            else if (!chbNonUsed.Checked)
                searchCriteria.Add("CustomerID > 0");

            IListToBindingList(
                _CustomerService.GetDiscountCards(searchCriteria));
            dgvDiscountCard.Refresh();
        }

        private void IListToBindingList(IList dCardList)
        {
            if (dCardList == null)
                throw new ArgumentNullException("dCardList", "Card List");

            if (_DiscountCardList == null)
                return;

            _DiscountCardList.Clear();
            foreach (DiscountCard discountCard in dCardList)
            {
                if (discountCard.CustomerID != 0)
                {
                    cmbCustomerHidden.SelectedValue = discountCard.CustomerID;
                    discountCard.CustomerStr = cmbCustomerHidden.Text;
                }
                _DiscountCardList.Add(discountCard);
            }
            UpdateResultInfo();
            EnableActionButton();
        }

        private void SetFocusToDCardList()
        {
            if (dgvDiscountCard.CanFocus)
                dgvDiscountCard.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCardNum.Text = string.Empty;
            cmbDCardType.SelectedIndex = -1;
            cmbCustomer.SelectedIndex = -1;
            chbUsed.Checked = true;
            chbNonUsed.Checked = true;
            btnSearch_Click(sender, e);
        }

        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;

            if ((cmbDCardType.InvokeRequired) || (cmbDiscountType.InvokeRequired) || (dgvDiscountCard.InvokeRequired))
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbDCardType.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                IList objList = _CommonService.GetAppParametersByType(
                    Int32.Parse(Resources.AppParamDiscountType, AppContext.CultureInfo));

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbDCardType, objList, Int32.Parse(Resources.AppParamDiscountType, AppContext.CultureInfo),
                    false);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbDiscountType, objList, Int32.Parse(Resources.AppParamDiscountType, AppContext.CultureInfo),
                    false);
            }
        }

        private void EnableActionButton()
        {
            if (_DiscountCardList.Count == 0)
            {
                btnReturnCard.Enabled = false;
                btnDelete.Enabled = false;
                btnPrint.Enabled = false;
            }
            else
            {
                btnReturnCard.Enabled = true;
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
            }
            SetFocusToDCardList();
        }

        private void SetDiscountCardInfo()
        {
            if ((_DiscountCardList.Count == 0) || (dgvDiscountCard.CurrentRow == null))
            {
                lblCardSelect.Text = "";
                return;
            }

            var discountCard = (DiscountCard) _DiscountCardList[dgvDiscountCard.CurrentRow.Index];
            if (discountCard == null)
                return;

            lblCardSelect.Text = discountCard.CardNumber;
            btnReturnCard.Enabled = !(discountCard.CustomerID == 0);
        }

        private void UpdateResultInfo()
        {
            int resultNum = 0;
            if (_DiscountCardList != null)
                resultNum = _DiscountCardList.Count;

            string strResultInfo = string.Format(
                "ការសែ្វងរករបស់អ្នកផ្តល់លទ្ឋផលចំនួន {0}",
                resultNum.ToString("N0", AppContext.CultureInfo));
            lblResultInfo.Text = strResultInfo;
        }

        private void btnNew_MouseEnter(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_9;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Resources.background_9;
        }

        private void btnPrint_MouseEnter(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = Resources.background_9;
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = null;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = null;
        }

        private void btnPrint_MouseLeave(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = null;
        }

        private void btnReturnCard_Click(object sender, EventArgs e)
        {
            var discountCard =
                (DiscountCard) _DiscountCardList[dgvDiscountCard.CurrentRow.Index];

            if (discountCard.CustomerID == 0)
                return;

            string briefMsg, detailMsg;

            if (!UserService.AllowToPerform(Resources.PermissionGetBackCard))
            {
                briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
                detailMsg = Resources.MsgUserPermissionDeny;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            briefMsg = "អំពីការដកហូតប័ណ្ណបញ្ចុះតំលៃ";
            detailMsg = Resources.MsgOperationRequestGetBackCard +
                        discountCard.CustomerStr + " ។";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                discountCard.CustomerID = 0;
                discountCard.CustomerStr = "";
                _CustomerService.DiscountCardManagement(
                    discountCard,
                    Resources.OperationRequestUpdate);

                btnReturnCard.Enabled = false;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnReturnCard_MouseEnter(object sender, EventArgs e)
        {
            btnReturnCard.BackgroundImage = Resources.background_9;
        }

        private void btnReturnCard_MouseLeave(object sender, EventArgs e)
        {
            btnReturnCard.BackgroundImage = null;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}