using System;
using System.Collections;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.Model;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUI.Forms
{
    public partial class FrmExchangeRate : Form
    {
        private ExchangeRateService _ExchangeRateService;

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
                var exchangeRate = new ExchangeRate
                                       {
                                           ExchangeDateTime = dtpExchangeDate.Value,
                                           ExchangeValue = float.Parse(txtExchangeRate.Text),
                                           FromCurrencyID = Int32.Parse(cbbFromCurrency.SelectedValue.ToString()),
                                           ToCurrencyID = Int32.Parse(cbbToCurrency.SelectedValue.ToString())
                                       };

                _ExchangeRateService.InsertExchangeRate(exchangeRate);
                Close();
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmExchangeRate_Load(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(global::PharmaStock.Properties.Resources.PermissionEXCRAT))
            //    Application.Exit();

            txtExchangeRate.Focus();

            _ExchangeRateService = ServiceFactory.GenerateServiceInstance().GenerateExchangeRateService();

            IList currencyList = _ExchangeRateService.GetCurrencies();
            cbbFromCurrency.DataSource = currencyList;
            cbbFromCurrency.DisplayMember = Currency.CONST_CURRENCY_NAME;
            cbbFromCurrency.ValueMember = Currency.CONST_CURRENCY_ID;
            cbbFromCurrency.SelectedValue = 1;

            currencyList = _ExchangeRateService.GetCurrencies();
            cbbToCurrency.DataSource = currencyList;
            cbbToCurrency.DisplayMember = Currency.CONST_CURRENCY_NAME;
            cbbToCurrency.ValueMember = Currency.CONST_CURRENCY_ID;
            cbbToCurrency.SelectedValue = 2;
        }
    }
}