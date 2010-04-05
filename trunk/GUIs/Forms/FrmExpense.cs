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
    public partial class FrmExpense : Form
    {
        private CommonService _CommonService;
        private Expense _Expense;
        private ExpenseService _ExpenseService;
        private bool _IsModified;

        public FrmExpense()
        {
            InitializeComponent();
        }

        public Expense Expense
        {
            get { return _Expense; }
            set { _Expense = value; }
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

        private void cmbCategory_Enter(object sender, EventArgs e)
        {
            cmbExpenseType.SelectedIndexChanged += ModificationHandler;
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            cmbExpenseType.SelectedIndexChanged -= ModificationHandler;
            cmbExpenseType.TextChanged -= ModificationHandler;
        }

        private void FrmExpense_Load(object sender, EventArgs e)
        {
            if (_ExpenseService == null)
                _ExpenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();

            if (_CommonService == null)
                _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

            ThreadStart threadStart = UpdateControlContent;
            var thread = new Thread(threadStart);
            thread.Start();
        }

        private void SetExpenseInfo()
        {
            if (_Expense == null)
                return;

            try
            {
                if (_Expense == null)
                    return;

                cmbExpenseType.SelectedValue = _Expense.ExpenseTypeID;
                dtpExpenseDate.Value = (DateTime) _Expense.ExpenseDate;
                txtDescription.Text = _Expense.Description;
                txtExpenseAmountRiel.Text = _Expense.ExpenseAmountRiel.ToString("N");
                txtExpenseAmountInt.Text = _Expense.ExpenseAmountInt.ToString("N");
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbExpenseType.SelectedIndex == -1)
                {
                    const string briefMsg = "អំពីពត៌មាន";
                    var detailMsg = Resources.MsgInvalidData;
                    using (var frmMessageBox = new ExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                if (_Expense == null)
                    _Expense = new Expense();

                _Expense.ExpenseTypeID = int.Parse(cmbExpenseType.SelectedValue.ToString());
                _Expense.ExpenseTypeStr = cmbExpenseType.Text;
                _Expense.ExpenseDate = dtpExpenseDate.Value.Date;
                _Expense.Description = txtDescription.Text;
                _Expense.ExpenseAmountRiel = float.Parse(txtExpenseAmountRiel.Text);
                _Expense.ExpenseAmountInt = float.Parse(txtExpenseAmountInt.Text);
                _Expense.ExchangeRate = AppContext.ExchangeRate.ExchangeValue;

                if (_Expense.ExpenseID != 0)
                    _ExpenseService.ExpenseManagement(
                        _Expense,
                        Resources.OperationRequestUpdate);
                else
                    _ExpenseService.ExpenseManagement(
                        _Expense,
                        Resources.OperationRequestInsert);

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void UpdateControlContent()
        {
            if (_ExpenseService == null)
                _ExpenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();

            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;
            if (cmbExpenseType.InvokeRequired)
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbExpenseType.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = new List<string> {"ParameterTypeID IN (22)"};
                var objList = _CommonService.GetAppParameters(searchCriteria);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbExpenseType, objList, int.Parse(Resources.AppParamExpense), true);

                SetExpenseInfo();
                SetModifydStatus(false);
            }
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            txtDescription.TextChanged += ModificationHandler;
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtDescription.TextChanged -= ModificationHandler;
        }

        private void txtExpenseAmountRiel_Enter(object sender, EventArgs e)
        {
            txtExpenseAmountRiel.TextChanged += ModificationHandler;
        }

        private void txtExpenseAmountRiel_Leave(object sender, EventArgs e)
        {
            txtExpenseAmountRiel.TextChanged -= ModificationHandler;
            try
            {
                txtExpenseAmountRiel.Text = float.Parse(txtExpenseAmountRiel.Text).ToString("N");
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void txtExpenseAmountInt_Enter(object sender, EventArgs e)
        {
            txtExpenseAmountInt.TextChanged += ModificationHandler;
        }

        private void txtExpenseAmountInt_Leave(object sender, EventArgs e)
        {
            txtExpenseAmountInt.TextChanged -= ModificationHandler;
            try
            {
                txtExpenseAmountInt.Text = float.Parse(txtExpenseAmountInt.Text).ToString("N");
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void FrmExpense_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((DialogResult == DialogResult.Cancel) && (_IsModified))
            {
                const string briefMsg = "អំពីការបោះបង់";
                var detailMsg = Resources.MsgOperationRequestCancel;
                using (var frmMessageBox = new ExtendedMessageBox())
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

        private void dtpExpenseDate_Enter(object sender, EventArgs e)
        {
            dtpExpenseDate.ValueChanged += ModificationHandler;
        }

        private void dtpExpenseDate_Leave(object sender, EventArgs e)
        {
            dtpExpenseDate.ValueChanged -= ModificationHandler;
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}