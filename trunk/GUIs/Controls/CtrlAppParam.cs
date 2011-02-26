using System;
using System.Collections;
using System.Windows.Forms;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Utility;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlAppParam : UserControl
    {
        private IList _AppParamList;
        private CommonService _CommonService;
        private bool _IsModified;

        public CtrlAppParam()
        {
            InitializeComponent();
        }

        public ListBox LstProduct
        {
            get { return lsbAppParam; }
        }

        private void CtrBase_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                IList objectList = _CommonService.GetAppParameterTypes();
                lsbAppParam.DisplayMember = AppParameterType.CONST_PARAMETER_LABEL;
                lsbAppParam.ValueMember = AppParameterType.CONST_PARAMETER_ID;
                lsbAppParam.DataSource = objectList;

                _IsModified = false;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError, exception.Message);
            }
        }

        private void lsbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lsbAppParam.SelectedIndex == -1) || (StringHelper.Length(lsbAppParam.DisplayMember) == 0) ||
                (StringHelper.Length(lsbAppParam.ValueMember) == 0))
                return;

            try
            {
                //Will change later
                if (Int32.Parse(lsbAppParam.SelectedValue.ToString(), AppContext.CultureInfo) == 21)
                {
                    using (var frmExchangeRate = new FrmExchangeRate())
                    {
                        frmExchangeRate.ShowDialog(this);
                        return;
                    }
                }

                _AppParamList =
                    _CommonService.GetAppParametersByType(
                        Int32.Parse(lsbAppParam.SelectedValue.ToString(), AppContext.CultureInfo));
                dgvAppParameter.DataSource = CommonService.IListToDataTable(typeof (AppParameter), _AppParamList);

                cmbAppParamValue.DataSource = _AppParamList;
                if (StringHelper.Length(cmbAppParamValue.DisplayMember) == 0)
                    cmbAppParamValue.DisplayMember = AppParameter.CONST_PARAMETER_VALUE;
                if (StringHelper.Length(cmbAppParamValue.ValueMember) == 0)
                    cmbAppParamValue.ValueMember = AppParameter.CONST_PARAMETER_ID;

                if (_AppParamList.Count != 0)
                {
                    cmbAppParamValue.SelectedIndex = _AppParamList.Count - 1;
                    dgvAppParameter.Columns["ParameterTypeID"].Visible = false;
                    dgvAppParameter.Columns["ParameterLabel"].DisplayIndex = 0;
                    dgvAppParameter.Columns["ParameterCode"].DisplayIndex = 1;
                    dgvAppParameter.Columns["ParameterValue"].DisplayIndex = 2;
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError, exception.Message);
            }
        }

        private void dgvAppParameter_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModified)
                return;

            if (dgvAppParameter.Rows[e.RowIndex].Cells["ParameterLabel"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                AppParameter appParameter;
                if (dgvAppParameter.Rows[e.RowIndex].Cells["ParameterID"].Value is DBNull)
                {
                    appParameter = new AppParameter();
                    _AppParamList.Add(appParameter);
                }
                else
                    appParameter = _AppParamList[e.RowIndex] as AppParameter;

                if (appParameter == null)
                {
                    e.Cancel = true;
                    return;
                }

                appParameter.ParameterLabel = dgvAppParameter.Rows[e.RowIndex].Cells["ParameterLabel"].Value.ToString();
                appParameter.ParameterValue = dgvAppParameter.Rows[e.RowIndex].Cells["ParameterValue"].Value.ToString();

                appParameter.ParameterCode = dgvAppParameter.Rows[e.RowIndex].Cells["ParameterCode"].Value == null ? "" : dgvAppParameter.Rows[e.RowIndex].Cells["ParameterCode"].Value.ToString();
                appParameter.ParameterTypeID = Int32.Parse(LstProduct.SelectedValue.ToString(), AppContext.CultureInfo);

                SetModifyStatus(false);

                if (appParameter.ParameterID == 0)
                {
                    //appParameter.ParameterValue = _CommonService
                    //    .GenerateAppParamValue(cmbAppParamValue.Text);
                    //dgvAppParameter.Rows[e.RowIndex].Cells["ParameterValue"].Value = appParameter.ParameterValue;

                    AppParamManagement(appParameter,
                                       Resources.OperationRequestInsert);

                    _AppParamList = _CommonService
                        .GetAppParametersByType(
                        Int32.Parse(lsbAppParam.SelectedValue.ToString(), AppContext.CultureInfo));
                    cmbAppParamValue.DataSource = _AppParamList;
                    if (StringHelper.Length(cmbAppParamValue.DisplayMember) == 0)
                        cmbAppParamValue.DisplayMember = AppParameter.CONST_PARAMETER_VALUE;
                    if (StringHelper.Length(cmbAppParamValue.ValueMember) == 0)
                        cmbAppParamValue.ValueMember = AppParameter.CONST_PARAMETER_ID;
                    cmbAppParamValue.SelectedIndex = _AppParamList.Count - 1;
                }
                else
                    AppParamManagement(appParameter,
                                       Resources.OperationRequestUpdate);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void SetModifyStatus(bool modifiedStatus)
        {
            _IsModified = modifiedStatus;
        }

        private void AppParamManagement(AppParameter appParameter, string operationRequest)
        {
            try
            {
                _CommonService.AppParameterManagement(appParameter, operationRequest);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvAppParameter_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FrmExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void dgvAppParameter_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppParameter.DataSource == null)
                return;

            if (dgvAppParameter.CurrentRow.IsNewRow)
                return;

            if (dgvAppParameter.CurrentRow.ReadOnly)
                return;

            SetModifyStatus(true);
        }

        private void dgvAppParameter_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            SetModifyStatus(false);
        }

        private void dgvAppParameter_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string briefMsg, detailMsg;
            if (!UserService.AllowToPerform(Resources.PermissionDeleteConfig))
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

            var appParameter = (AppParameter) _AppParamList[e.Row.Index];
            briefMsg = "អំពីការលុប";
            detailMsg = Resources.MsgOperationRequestDelete + "\n" +
                        appParameter.ParameterLabel + " ?";
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

            //if (!ExtendedMessageBox.ConfirmMessage(Resources.MsgOperationRequestDelete, appParameter.ParameterLabel))
            //{
            //    e.Cancel = true;
            //    return;
            //}

            AppParamManagement(appParameter, Resources.OperationRequestDelete);

            _AppParamList = _CommonService
                .GetAppParametersByType(Int32.Parse(lsbAppParam.SelectedValue.ToString(), AppContext.CultureInfo));
            cmbAppParamValue.DataSource = _AppParamList;
            if (StringHelper.Length(cmbAppParamValue.DisplayMember) == 0)
                cmbAppParamValue.DisplayMember = AppParameter.CONST_PARAMETER_VALUE;
            if (StringHelper.Length(cmbAppParamValue.ValueMember) == 0)
                cmbAppParamValue.ValueMember = AppParameter.CONST_PARAMETER_ID;
            cmbAppParamValue.SelectedIndex = _AppParamList.Count - 1;
        }

        private void dgvAppParameter_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetModifyStatus(false);
        }
    }
}