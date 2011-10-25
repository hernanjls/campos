using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Model.Expense;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlExpense : UserControl
    {
        private CommonService _commonService;
        private BindingList<Expense> _expenseList;
        private ExpenseService _expenseService;

        public CtrlExpense()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _commonService = value; }
        }

        public ExpenseService ExpenseService
        {
            set { _expenseService = value; }
        }

        private void DgvExpenseDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FrmExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void BtnNewClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAddExpense))
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
            ExpenseManagement(Resources.OperationRequestInsert);
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            string briefMsg, detailMsg = string.Empty;

            if (!UserService.AllowToPerform(Resources.PermissionDeleteExpense))
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

            briefMsg = "អំពីការលុប";
            if (dgvExpense.CurrentRow != null)
                detailMsg = Resources.MsgOperationRequestDelete + "\n" +
                            dgvExpense.CurrentRow.Cells["Description"].Value + " ?";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                if (dgvExpense.CurrentRow != null)
                {
                    _expenseService.ExpenseManagement(_expenseList[dgvExpense.CurrentRow.Index],
                                                      Resources.OperationRequestDelete);

                    _expenseList.RemoveAt(dgvExpense.CurrentRow.Index);
                }
                dgvExpense.Refresh();
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

        private void CtrlExpense_Load(object sender, EventArgs e)
        {
            if (_commonService == null)
                _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
            if (_expenseService == null)
                _expenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
            
            try
            {
                if (!UserService.AllowToPerform(Resources.PermissionViewExpResultInfo))
                {
                    lblResultInfo.Visible = false;
                }

                InitializeExpenseList();

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart) {IsBackground = true};
                thread.Start();

                IListToBindingList(_expenseService.GetExpenses());
                dgvExpense.Refresh();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void InitializeExpenseList()
        {
            try
            {
                if (_expenseList == null)
                    _expenseList = new BindingList<Expense>();

                dgvExpense.DataSource = _expenseList;
                dgvExpense.Columns["ExpenseDate"].DisplayIndex = 0;
                dgvExpense.Columns["ExpenseTypeStr"].DisplayIndex = 1;
                dgvExpense.Columns["Description"].DisplayIndex = 2;
                dgvExpense.Columns["ExpenseAmountInt"].DisplayIndex = 3;
                dgvExpense.Columns["ExpenseAmountRiel"].DisplayIndex = 4;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void IListToBindingList(IList expenseList)
        {
            if (expenseList == null)
                throw new ArgumentNullException("expenseList", Resources.MsgInvalidExpense);

            if (_expenseList == null)
                return;

            _expenseList.Clear();
            foreach (Expense expense in expenseList)
                _expenseList.Add(expense);

            UpdateResultInfo();
            EnableActionButton();
        }

        private void EnableActionButton()
        {
            btnDelete.Enabled = _expenseList.Count != 0;

            SetFocusToExpenseList();
        }

        private void SetFocusToExpenseList()
        {
            if (dgvExpense.CanFocus)
                dgvExpense.Focus();
        }

        private void ExpenseManagement(IEquatable<string> operationRequest)
        {
            using (var frmExpense = new FrmExpense())
            {
                if (operationRequest.Equals(Resources.OperationRequestUpdate))
                    if (dgvExpense.CurrentRow != null) frmExpense.Expense = _expenseList[dgvExpense.CurrentRow.Index];

                if (frmExpense.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    if (operationRequest.Equals(Resources.OperationRequestInsert))
                        _expenseList.Add(frmExpense.Expense);

                    dgvExpense.Refresh();
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

        private void DgvExpenseCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionEditExpense))
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
            ExpenseManagement(Resources.OperationRequestUpdate);
        }

        private void UpdateControlContent()
        {
            var objList = _commonService.GetAppParametersByType(
                Int32.Parse(Resources.AppParamExpense, AppContext.CultureInfo));

            if (cmbExpenseType.InvokeRequired)
            {
                SafeCrossCallBackDelegate safeCrossCallBackDelegate = UpdateControlContent;
                Invoke(safeCrossCallBackDelegate);
            }
            else
                _commonService.PopAppParamExtendedCombobox(
                    ref cmbExpenseType, objList, Int32.Parse(Resources.AppParamExpense, AppContext.CultureInfo), false);
        }

        private void UpdateResultInfo()
        {
            var resultNum = 0;
            if (_expenseList != null)
                resultNum = _expenseList.Count;

            var strResultInfo = string.Format(
                "ការសែ្វងរករបស់អ្នកផ្តល់លទ្ឋផលចំនួន {0}",
                resultNum.ToString("N0", AppContext.CultureInfo));
            lblResultInfo.Text = strResultInfo;
        }

        private void BtnDeleteMouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Resources.background_9;
        }

        private void BtnDeleteMouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = null;
        }

        private void BtnNewMouseEnter(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_9;
        }

        private void BtnNewMouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = null;
        }

        private void CmdSearchProductClick(object sender, EventArgs e)
        {
            if (_expenseService == null)
                _expenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
            var searchCriteria = 
                new List<string>
                {
                    "ExpenseDate BETWEEN CONVERT(DATETIME, '" +
                    dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    "', 103) AND CONVERT(DATETIME, '" +
                    dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    "', 103)"
                };
            var expenseList = _expenseService.GetExpenses(searchCriteria);
            IListToBindingList(expenseList);
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}