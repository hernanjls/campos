using System;
using System.Collections;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Model.Common;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Forms
{
    public partial class FrmExchangeRate : Form
    {
        private CommonService _CommonService;

        public FrmExchangeRate()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtExchangeRate.Text == null)
                return;

            if (txtExchangeRate.Text.Length == 0)
                return;

            try
            {
                var exchangeRate = new ExchangeRate();
                exchangeRate.ExchangeDateTime = dtpExchangeDate.Value;
                exchangeRate.ExchangeValue = float.Parse(txtExchangeRate.Text);
                exchangeRate.FromCurrencyId = Int32.Parse(cbbFromCurrency.SelectedValue.ToString());
                exchangeRate.ToCurrencyId = Int32.Parse(cbbToCurrency.SelectedValue.ToString());

                _CommonService.InsertExchangeRate(exchangeRate);

                Close();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmExchangeRate_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                IList objList = _CommonService.GetAppParametersByType(
                    Int32.Parse(Resources.AppParamCurrency));

                _CommonService.PopAppParamExtendedCombobox(
                    ref cbbFromCurrency, objList, Int32.Parse(Resources.AppParamCurrency), true);
                if (((IList) cbbFromCurrency.DataSource).Count != 0)
                    cbbFromCurrency.SelectedValue = 15;

                _CommonService.PopAppParamExtendedCombobox(
                    ref cbbToCurrency, objList, Int32.Parse(Resources.AppParamCurrency), true);
                if (((IList) cbbToCurrency.DataSource).Count != 0)
                    cbbToCurrency.SelectedValue = 14;

                if (txtExchangeRate.CanFocus)
                    txtExchangeRate.Focus();
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