using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlExpense : UserControl
    {
        private CommonService _CommonService;
        private BindingList<Expense> _ExpenseList;
        private ExpenseService _ExpenseService;

        public CtrlExpense()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
        }

        public ExpenseService ExpenseService
        {
            set { _ExpenseService = value; }
        }

        private void dgvExpense_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FrmExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void btnNew_Click(object sender, EventArgs e)
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
            string briefMsg, detailMsg;

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
                _ExpenseService.ExpenseManagement(_ExpenseList[dgvExpense.CurrentRow.Index],
                                                  Resources.OperationRequestDelete);

                _ExpenseList.RemoveAt(dgvExpense.CurrentRow.Index);
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
            if (_CommonService == null)
                _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
            if (_ExpenseService == null)
                _ExpenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
            
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

                IListToBindingList(_ExpenseService.GetExpenses());
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
                if (_ExpenseList == null)
                    _ExpenseList = new BindingList<Expense>();

                dgvExpense.DataSource = _ExpenseList;
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
                throw new ArgumentNullException("expenseList", "Expense List");

            if (_ExpenseList == null)
                return;

            _ExpenseList.Clear();
            foreach (Expense expense in expenseList)
                _ExpenseList.Add(expense);

            UpdateResultInfo();
            EnableActionButton();
        }

        private void EnableActionButton()
        {
            btnDelete.Enabled = _ExpenseList.Count != 0;

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
                    frmExpense.Expense = _ExpenseList[dgvExpense.CurrentRow.Index];

                if (frmExpense.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        if (operationRequest.Equals(Resources.OperationRequestInsert))
                            _ExpenseList.Add(frmExpense.Expense);

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
        }

        private void dgvExpense_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            var objList = _CommonService.GetAppParametersByType(
                Int32.Parse(Resources.AppParamExpense, AppContext.CultureInfo));

            if (cmbExpenseType.InvokeRequired)
            {
                SafeCrossCallBackDelegate safeCrossCallBackDelegate = UpdateControlContent;
                Invoke(safeCrossCallBackDelegate);
            }
            else
                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbExpenseType, objList, Int32.Parse(Resources.AppParamExpense, AppContext.CultureInfo), false);
        }

        private void UpdateResultInfo()
        {
            var resultNum = 0;
            if (_ExpenseList != null)
                resultNum = _ExpenseList.Count;

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
            if (_ExpenseService == null)
                _ExpenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
            var searchCriteria = 
                new List<string>
                {
                    "ExpenseDate BETWEEN CONVERT(DATETIME, '" +
                    dtpStartDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    "', 103) AND CONVERT(DATETIME, '" +
                    dtpStopDate.Value.ToString("dd/MM/yyyy", AppContext.CultureInfo) +
                    "', 103)"
                };
            var expenseList = _ExpenseService.GetExpenses(searchCriteria);
            IListToBindingList(expenseList);
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}