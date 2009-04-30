using System;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.Model.Common;

namespace EzPos.GUI
{
    public partial class FrmPayment : Form
    {
        private float _AmountPaidInUsd;
        private string _AmountReturn;
        private float _TotalAmountInUsd;

        public FrmPayment()
        {
            InitializeComponent();
        }

        public float TotalAmountInUsd
        {
            get { return _TotalAmountInUsd; }
            set { _TotalAmountInUsd = value; }
        }

        public float TotalAmountInRiel { get; set; }

        public float AmountPaidInUsd
        {
            get { return _AmountPaidInUsd; }
            set { _AmountPaidInUsd = value; }
        }

        public string AmountReturn
        {
            get { return _AmountReturn; }
        }

        private void FrmPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult != DialogResult.OK)
                    return;

                PaymentManagement();
                float amountReturnRiel = float.Parse(txtAmountReturnRiel.Text);
                if (amountReturnRiel < 0)
                {
                    if (((-1)*amountReturnRiel) >= 100)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Paid amount < Amount to be paid");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void FrmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Enter:
                    if (txtAmountPaidUsd.Text.Length == 0)
                        txtAmountPaidUsd.Focus();

                    if (txtAmountPaidRiel.Text.Length == 0)
                        txtAmountPaidRiel.Focus();

                    //Close form in case of ok
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    break;
            }
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            txtExchangeRate.Text = Math.Round(AppContext.ExchangeRate.ExchangeValue, 2).ToString();
            txtTotalAmountUsd.Text = Math.Round(_TotalAmountInUsd, 2).ToString();
            txtTotalAmountRiel.Text = Math.Round(AppContext.ExchangeRate.ExchangeValue*_TotalAmountInUsd, 2).ToString();
        }

        private void txtAmountPaidUsd_Leave(object sender, EventArgs e)
        {
            if (txtAmountPaidUsd.Text == null)
                txtAmountPaidUsd.Text = "0";

            if (txtAmountPaidUsd.Text.Length == 0)
                txtAmountPaidUsd.Text = "0";

            PaymentManagement();
        }

        private void TxtAmountPaidRiel_Leave(object sender, EventArgs e)
        {
            if (txtAmountPaidRiel.Text == null)
                txtAmountPaidRiel.Text = "0";

            if (txtAmountPaidRiel.Text.Length == 0)
                txtAmountPaidRiel.Text = "0";

            PaymentManagement();
        }

        private void PaymentManagement()
        {
            try
            {
                float exchangeRate;
                _AmountPaidInUsd = float.Parse(txtAmountPaidUsd.Text);
                exchangeRate = float.Parse(txtExchangeRate.Text);

                _AmountPaidInUsd += float.Parse(txtAmountPaidRiel.Text)/exchangeRate;
                txtAmountReturnUsd.Text = Math.Round(_AmountPaidInUsd - _TotalAmountInUsd, 2).ToString();
                txtAmountReturnRiel.Text = Math.Round((_AmountPaidInUsd - _TotalAmountInUsd)*exchangeRate, 2).ToString();
                _AmountReturn = txtAmountReturnUsd.Text;
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }
    }
}