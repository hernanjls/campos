using System;
using System.Windows.Forms;

namespace EzPos.GUI
{
    public partial class FrmQtyAdjustment : Form
    {
        public float _PurchasedQty;
        public string _PurchasedQtyStr;

        public FrmQtyAdjustment()
        {
            InitializeComponent();
        }

        public string PurchasedQtyStr
        {
            get { return _PurchasedQtyStr; }
            set { _PurchasedQtyStr = value; }
        }

        public float PurchasedQty
        {
            get { return _PurchasedQty; }
            set { _PurchasedQty = value; }
        }

        private void FrmQtyAdjustment_Load(object sender, EventArgs e)
        {
            txtCurrentQty.Text = _PurchasedQtyStr;
        }

        private void FrmQtyAdjustment_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    int seperatorIndex = txtQtyAdjusted.Text.IndexOf("/");
                    if (seperatorIndex != -1)
                    {
                        float firstOperand, secondOperand;
                        firstOperand = float.Parse(txtQtyAdjusted.Text.Substring(
                                                       0, seperatorIndex));
                        secondOperand = float.Parse(txtQtyAdjusted.Text.Substring(
                                                        seperatorIndex + 1,
                                                        txtQtyAdjusted.Text.Length - seperatorIndex - 1));

                        _PurchasedQty = firstOperand/secondOperand;
                    }
                    else
                        _PurchasedQty = float.Parse(txtQtyAdjusted.Text);
                    _PurchasedQtyStr = txtQtyAdjusted.Text;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                e.Cancel = true;
            }
        }

        private void FrmQtyAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Return:
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        private void txtQtyAdjusted_KeyDown(object sender, KeyEventArgs e)
        {
            FrmQtyAdjustment_KeyDown(sender, e);
        }
    }
}