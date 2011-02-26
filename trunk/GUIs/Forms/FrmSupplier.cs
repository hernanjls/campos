using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Forms
{
    public partial class FrmSupplier : Form
    {
        private CommonService _CommonService;
        private Supplier _Supplier;
        private SupplierService _SupplierService;
        private bool _IsModified;

        public FrmSupplier()
        {
            InitializeComponent();
        }

        public Supplier Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }

        public SupplierService SupplierService
        {
            get { return _SupplierService; }
            set { _SupplierService = value; }
        }

        public CommonService CommonService
        {
            get { return _CommonService; }
            set { _CommonService = value; }
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            _IsModified = modifyStatus;
            btnSave.Enabled = modifyStatus;
        }

        private void ModificationHandler(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void cmbCountry_Enter(object sender, EventArgs e)
        {
            cmbCountry.SelectedIndexChanged += ModificationHandler;
        }

        private void cmbCountry_Leave(object sender, EventArgs e)
        {
            cmbCountry.SelectedIndexChanged -= ModificationHandler;
            cmbCountry.TextChanged -= ModificationHandler;
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            if (_SupplierService == null)
                _SupplierService = ServiceFactory.GenerateServiceInstance().GenerateSupplierService();

            if (_CommonService == null)
                _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

            ThreadStart threadStart = UpdateControlContent;
            var thread = new Thread(threadStart);
            thread.Start();
        }

        private void SetSupplierInfo()
        {
            if (_Supplier == null)
                return;

            try
            {
                if (_Supplier == null)
                    return;

                txtSupplierName.Text = _Supplier.SupplierName;
                txtPhoneNumber.Text = _Supplier.PhoneNumber;
                txtFaxNumber.Text = _Supplier.FaxNumber;
                txtEmailAddress.Text = _Supplier.EmailAddress;
                txtWebsite.Text = _Supplier.Website;
                cmbCountry.SelectedValue = _Supplier.CountryId;
                txtBankInfo.Text = _Supplier.BankInformation;
                txtAddress.Text = _Supplier.Address;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSupplierName.Text))
                {
                    const string briefMsg = "អំពីពត៌មាន";
                    var detailMsg = Resources.MsgInvalidData;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                if (cmbCountry.SelectedIndex == -1)
                {
                    const string briefMsg = "អំពីពត៌មាន";
                    var detailMsg = Resources.MsgInvalidData;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                if (_Supplier == null)
                    _Supplier = new Supplier();

                _Supplier.SupplierName = txtSupplierName.Text;
                _Supplier.PhoneNumber = txtPhoneNumber.Text;
                _Supplier.FaxNumber = txtFaxNumber.Text;
                _Supplier.EmailAddress = txtEmailAddress.Text;
                _Supplier.Website = txtWebsite.Text;
                _Supplier.CountryId = Int32.Parse(cmbCountry.SelectedValue.ToString());
                _Supplier.CountryStr = cmbCountry.Text;
                _Supplier.BankInformation = txtBankInfo.Text;
                _Supplier.Address = txtAddress.Text;

                if (_Supplier.SupplierId != 0)
                    _SupplierService.SupplierManagement(
                        _Supplier,
                        Resources.OperationRequestUpdate);
                else
                    _SupplierService.SupplierManagement(
                        _Supplier,
                        Resources.OperationRequestInsert);

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void UpdateControlContent()
        {
            if (_SupplierService == null)
                _SupplierService = ServiceFactory.GenerateServiceInstance().GenerateSupplierService();

            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;
            if (cmbCountry.InvokeRequired)
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbCountry.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = new List<string>
                                         {
                                             "ParameterTypeID IN (" + Resources.AppParamCountry + ")"
                                         };
                var objList = _CommonService.GetAppParameters(searchCriteria);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbCountry, objList, int.Parse(Resources.AppParamCountry), true);

                SetSupplierInfo();
                SetModifydStatus(false);
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            txtAddress.TextChanged += ModificationHandler;
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.TextChanged -= ModificationHandler;
        }

        private void FrmSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((DialogResult == DialogResult.Cancel) && (_IsModified))
            {
                const string briefMsg = "អំពីការបោះបង់";
                var detailMsg = Resources.MsgOperationRequestCancel;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if (!_IsModified)
            {
                DialogResult = DialogResult.Cancel;
                return;
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

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion

        private void txtSupplierName_Enter(object sender, EventArgs e)
        {
            txtSupplierName.TextChanged += ModificationHandler;
        }

        private void txtSupplierName_Leave(object sender, EventArgs e)
        {
            txtSupplierName.TextChanged -= ModificationHandler;
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged += ModificationHandler;
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            txtPhoneNumber.TextChanged -= ModificationHandler;
        }

        private void txtFaxNumber_Enter(object sender, EventArgs e)
        {
            txtFaxNumber.TextChanged += ModificationHandler;
        }

        private void txtFaxNumber_Leave(object sender, EventArgs e)
        {
            txtFaxNumber.TextChanged -= ModificationHandler;
        }

        private void txtEmailAddress_Enter(object sender, EventArgs e)
        {
            txtEmailAddress.TextChanged += ModificationHandler;
        }

        private void txtEmailAddress_Leave(object sender, EventArgs e)
        {
            txtEmailAddress.TextChanged -= ModificationHandler;
        }

        private void txtWebsite_Enter(object sender, EventArgs e)
        {
            txtWebsite.TextChanged += ModificationHandler;
        }

        private void txtWebsite_Leave(object sender, EventArgs e)
        {
            txtWebsite.TextChanged -= ModificationHandler;
        }

        private void txtBankInfo_Enter(object sender, EventArgs e)
        {
            txtBankInfo.TextChanged += ModificationHandler;
        }

        private void txtBankInfo_Leave(object sender, EventArgs e)
        {
            txtBankInfo.TextChanged -= ModificationHandler;
        }
    }
}