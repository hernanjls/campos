using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Model.Common;
using EzPos.Model.Supplier;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Supplier;
using EzPos.Service.User;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlSupplier : UserControl
    {
        private CommonService _CommonService;
        private SupplierService _SupplierService;
        private BindingList<Supplier> _SupplierList;

        public CtrlSupplier()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
        }

        public SupplierService SupplierService
        {
            set { _SupplierService = value; }
        }

        private void CtrlSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
                if (_SupplierService == null)
                    _SupplierService = ServiceFactory.GenerateServiceInstance().GenerateSupplierService();
                if (!UserService.AllowToPerform(Resources.PermissionViewSuppResultInfo))
                {
                    lblResultInfo.Visible = false;
                }
                InitialSupplierList();

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart) {IsBackground = true};
                thread.Start();

                //IList objList = _SupplierService.GetSuppliers();
                //cmbCustomer.CustomizedDataBinding(
                //    objList,
                //    Customer.CONST_CUSTOMER_NAME,
                //    Customer.CONST_CUSTOMER_Id,
                //    false);

                //var customerList = new List<Customer>();
                //foreach (Customer customer in objList)
                //    customerList.Add(customer);

                //cmbCustomerHidden.CustomizedDataBinding(
                //    customerList,
                //    Customer.CONST_CUSTOMER_NAME,
                //    Customer.CONST_CUSTOMER_Id,
                //    false);

                //btnSearch_Click(sender, e);
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

        private void InitialSupplierList()
        {
            try
            {
                if (_SupplierList == null)
                    _SupplierList = new BindingList<Supplier>();

                dgvSupplier.DataSource = _SupplierList;

                dgvSupplier.Columns["SupplierName"].DisplayIndex = 0;
                dgvSupplier.Columns["PhoneNumber"].DisplayIndex = 1;
                dgvSupplier.Columns["FaxNumber"].DisplayIndex = 2;
                dgvSupplier.Columns["CountryStr"].DisplayIndex = 3;
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
            SetSupplierInfo();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAddSupplier))
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

            SupplierManagement(Resources.OperationRequestInsert);
        }

        //private void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    string briefMsg, detailMsg;

        //    if (!UserService.AllowToPerform(Resources.PermissionDeleteCustomer))
        //    {
        //        briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
        //        detailMsg = Resources.MsgUserPermissionDeny;
        //        using (var frmMessageBox = new ExtendedMessageBox())
        //        {
        //            frmMessageBox.BriefMsgStr = briefMsg;
        //            frmMessageBox.DetailMsgStr = detailMsg;
        //            frmMessageBox.IsCanceledOnly = true;
        //            frmMessageBox.ShowDialog(this);
        //            return;
        //        }
        //    }

        //    SetFocusToSupplierList();

        //    //string briefMsg, detailMsg;
        //    briefMsg = "អំពីការលុប";
        //    detailMsg = Resources.MsgOperationRequestDelete + "\n" +
        //                dgvSupplier.CurrentRow.Cells["CustomerName"].Value + " ?";
        //    using (var frmMessageBox = new ExtendedMessageBox())
        //    {
        //        frmMessageBox.BriefMsgStr = briefMsg;
        //        frmMessageBox.DetailMsgStr = detailMsg;
        //        if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
        //            return;
        //    }

        //    try
        //    {
        //        _SupplierService.SupplierManagement(
        //            _SupplierList[dgvSupplier.CurrentRow.Index],
        //            Resources.OperationRequestDelete);

        //        ThreadStart threadStart = UpdateControlContent;
        //        var thread = new Thread(threadStart);
        //        thread.Start();

        //        _SupplierList.RemoveAt(dgvSupplier.CurrentRow.Index);
        //        dgvSupplier.Refresh();

        //        UpdateResultInfo();
        //        EnableActionButton();
        //    }
        //    catch (Exception exception)
        //    {
        //        ExtendedMessageBox.UnknownErrorMessage(
        //            Resources.MsgCaptionUnknownError,
        //            exception.Message);
        //    }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchCriteria = new List<string>();
            if (txtSupplierName.Text.Length != 0)
                searchCriteria.Add("SupplierName LIKE '%" + txtSupplierName.Text + "%'");

            if (cmbCountry.SelectedIndex != -1)
                searchCriteria.Add("CountryId|" + cmbCountry.SelectedValue);

            IListToBindingList(
                _SupplierService.GetSuppliers(searchCriteria));
            dgvSupplier.Refresh();
        }

        private void IListToBindingList(IList supplierList)
        {
            if (supplierList == null)
                throw new ArgumentNullException("supplierList", "Supplier list");

            if (_SupplierList == null)
                return;

            _SupplierList.Clear();
            foreach (Supplier supplier in supplierList)
                _SupplierList.Add(supplier);

            UpdateResultInfo();
            EnableActionButton();
        }

        private void SetFocusToSupplierList()
        {
            if (dgvSupplier.CanFocus)
                dgvSupplier.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSupplierName.Text = string.Empty;
            cmbCountry.SelectedIndex = -1;
            btnSearch_Click(sender, e);
        }

        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;

            if (cmbCountry.InvokeRequired)
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbCountry.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = new List<string>
                                         {
                                             "ParameterTypeId IN (" + Resources.AppParamCountry + ")"
                                         };
                var objList = _CommonService.GetAppParameters(searchCriteria);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbCountry, 
                    objList, 
                    int.Parse(Resources.AppParamCountry), 
                    false);

                btnSearch_Click(null, null);
            }
        }

        private void EnableActionButton()
        {
            btnDelete.Enabled = _SupplierList.Count != 0;
            SetFocusToSupplierList();
        }

        private void SetSupplierInfo()
        {
            if ((_SupplierList.Count == 0) || (dgvSupplier.CurrentRow == null))
            {
                addressLbl.Text = string.Empty;
                bankInfoLbl.Text = string.Empty;
                return;
            }

            var supplier = _SupplierList[dgvSupplier.CurrentRow.Index];
            if (supplier == null)
                return;

            addressLbl.Text = supplier.Address;
            bankInfoLbl.Text = supplier.BankInformation;
        }

        private void UpdateResultInfo()
        {
            int resultNum = 0;
            if (_SupplierList != null)
                resultNum = _SupplierList.Count;

            string strResultInfo = string.Format(
                "ការសែ្វងរករបស់អ្នកផ្តល់លទ្ឋផលចំនួន {0}",
                resultNum.ToString("N0", AppContext.CultureInfo));
            lblResultInfo.Text = strResultInfo;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string briefMsg, detailMsg;

            if (!UserService.AllowToPerform(Resources.PermissionDeleteSupplier))
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

            SetFocusToSupplierList();

            detailMsg = string.Empty;
            briefMsg = "អំពីការលុប";
            if (dgvSupplier.CurrentRow != null)
                detailMsg = 
                    Resources.MsgOperationRequestDelete + 
                    "\n" +
                    dgvSupplier.CurrentRow.Cells["SupplierName"].Value + " ?";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                if (dgvSupplier.CurrentRow != null)
                    _SupplierService.SupplierManagement(
                        _SupplierList[dgvSupplier.CurrentRow.Index],
                        Resources.OperationRequestDelete);

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart);
                thread.Start();

                if (dgvSupplier.CurrentRow != null) 
                    _SupplierList.RemoveAt(dgvSupplier.CurrentRow.Index);
                dgvSupplier.Refresh();

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

        private void btnNew_MouseEnter(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_9;
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = null;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Resources.background_9;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = null;
        }

        private void SupplierManagement(IEquatable<string> operationRequest)
        {
            using (var frmSupplier = new FrmSupplier())
            {
                frmSupplier.CommonService = _CommonService;
                frmSupplier.SupplierService = _SupplierService;

                if (operationRequest.Equals(Resources.OperationRequestUpdate))
                    if (dgvSupplier.CurrentRow != null)
                        frmSupplier.Supplier = _SupplierList[dgvSupplier.CurrentRow.Index];

                if (frmSupplier.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        ThreadStart threadStart = UpdateControlContent;
                        var thread = new Thread(threadStart);
                        thread.Start();

                        if (operationRequest.Equals(Resources.OperationRequestInsert))
                            _SupplierList.Add(frmSupplier.Supplier);

                        dgvSupplier.Refresh();
                        SetSupplierInfo();
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
            }

            SetFocusToSupplierList();
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionEditSupplier))
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

            SupplierManagement(Resources.OperationRequestUpdate);
        }
    }
}