using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.GUI.Forms;
using EzPos.Model;
using EzPos.Model.Common;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using GenericDataGridView;

namespace EzPos.GUI
{
    /// <summary>
    /// Summary description for FrmPurchaseOrder.
    /// </summary>
    public class FrmPurchaseOrder : FrmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly Container components;

        private BarCodeService _BarCodeService;
        private PurchaseOrder _CurrentPurchaseOrder;

        private bool _IsModified;
        private bool _IsModifiedPurchaseItem;
        private ProductService _ProductService;
        private IList _PurchaseItemList;
        private BindingList<object> _PurchaseOrderBindingList;
        private PurchaseOrderService _PurchaseOrderService;
        private bool _SkipAllowed;
        private DataGridViewTextBoxColumn BarCodeValue;
        private ComboBox cbbCurrency;
        private ComboBox cbbPaymentTerm;
        private ComboBox cbbStatus;
        private ComboBox cbbSupplier;
        private DataGridViewComboBoxColumn cbbSupplierID;
        private DataGridViewComboBoxColumn CellID;
        private Button cmdCancel;
        private Button cmdDeletePurchaseOrder;
        private Button cmdNewPurchaseOrder;
        private Button cmdReset;
        private Button cmdSave;
        private Button cmdSearchPurchaseOrder;
        private ExtendedDataGridView.CalendarColumn DateExpire;
        private ExtendedDataGridView.CalendarColumn DateIn;
        private DataGridView dgvPurchaseHistory;
        private DateTimePicker dtpDeliveryDate;
        private DateTimePicker dtpPaymentDate;
        private DateTimePicker dtpPurchaseOrderDate;
        private DataGridViewTextBoxColumn FKPurchaseOrder;
        private GroupBox grbLine_1;
        private GroupBox grbLine_2;
        private GroupBox grbPurchaseOrderInfo;
        private Label lblAmountCurrency;
        private Label lblAmountPaid;
        private Label lblAmountStandard;
        private Label lblCurrency;
        private Label lblDeliveryDate;
        private Label lblDiscount;
        private Label lblExchangeRate;
        private Label lblPaymentDate;
        private Label lblPaymentTerm;
        private Label lblPurchaseOrderDate;
        private Label lblPurchaseOrderNumber;
        private Label lblRemark;
        private Label lblStatus;
        private Label lblSupplier;
        private Label lblTotal;
        private ListBox lsbPurchaseOrder;
        private DataGridViewComboBoxColumn ProductID;
        private DataGridViewComboBoxColumn ProductUnitID;
        private DataGridViewTextBoxColumn PurchaseItemID;
        private DataGridViewTextBoxColumn PurchaseOrderID;
        private DataGridViewTextBoxColumn Quantity;
        private RichTextBox rtbRemark;
        private DataGridViewTextBoxColumn SubTotal;
        private TextBox txtAmountCurrency;
        private TextBox txtAmountPaid;
        private TextBox txtAmountStandard;
        private TextBox txtDiscount;
        private TextBox txtExchangeRate;
        private TextBox txtOperationInfo;
        private TextBox txtPurchaseOrderNumber;
        private TextBox txtPurchaseOrderSearch;
        private TextBox txtTotal;
        private DataGridViewTextBoxColumn UnitPrice;

        public FrmPurchaseOrder()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void FrmPurchaseOrder_Load(object sender, EventArgs e)
        {
            if (txtPurchaseOrderSearch.CanFocus)
                txtPurchaseOrderSearch.Focus();

            try
            {
                _PurchaseOrderService = ServiceFactory.GenerateServiceInstance().GeneratePurchaseOrderService();
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                ExchangeRateService exchangeRateService =
                    ServiceFactory.GenerateServiceInstance().GenerateExchangeRateService();
                IList objList = exchangeRateService.GetCurrencies();
                objList.RemoveAt(0);
                cbbCurrency.DataSource = objList;
                cbbCurrency.ValueMember = Currency.CONST_CURRENCY_ID;
                cbbCurrency.DisplayMember = Currency.CONST_CURRENCY_NAME;

                objList = exchangeRateService.GetPaymentTerms();
                objList.RemoveAt(0);
                cbbPaymentTerm.DataSource = objList;
                cbbPaymentTerm.ValueMember = PaymentTerm.CONST_PAYMENT_TERM_ID;
                cbbPaymentTerm.DisplayMember = PaymentTerm.CONST_PAYMENT_TERM_NAME;

                objList = _PurchaseOrderService.GetPurchaseOrderStatus();
                objList.RemoveAt(0);
                cbbStatus.DataSource = objList;
                cbbStatus.ValueMember = PurchaseOrderStatus.CONST_PURCHASE_ORDER_STATUS_ID;
                cbbStatus.DisplayMember = PurchaseOrderStatus.CONST_PURCHASE_ORDER_STATUS_NAME;

                SupplierService supplierService = ServiceFactory.GenerateServiceInstance().GenerateSupplierService();
                IList supplierList = supplierService.GetSuppliers();
                cbbSupplier.DataSource = supplierList;
                cbbSupplier.ValueMember = Supplier.CONST_SUPPLIER_ID;
                cbbSupplier.DisplayMember = Supplier.CONST_SUPPLIER_NAME;

                if (ProductID.DataSource == null)
                {
                    objList = _ProductService.GetProducts();
                    objList.RemoveAt(0);
                    ProductID.DataSource = objList;
                    ProductID.DisplayMember = Product.CONST_PRODUCT_NAME;
                    ProductID.ValueMember = Product.CONST_PRODUCT_ID;
                }

                if (ProductUnitID.DataSource == null)
                {
                    objList = _ProductService.GetProductUnits();
                    ProductUnitID.DataSource = objList;
                    ProductUnitID.DisplayMember = ProductUnit.CONST_UNIT_NAME;
                    ProductUnitID.ValueMember = ProductUnit.CONST_UNIT_ID;
                }

                if (CellID.DataSource == null)
                {
                    CellID.DataSource = _ProductService.GetLocations();
                    CellID.DisplayMember = ProductLocation.CONST_CELL_NAME;
                    CellID.ValueMember = ProductLocation.CONST_CELL_ID;
                }

                PopulatePurchaseOrderList();
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
            lblHeader.Text = "Purchase management";
            cmd5.Enabled = false;
        }

        private void lsbPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SkipAllowed)
            {
                _SkipAllowed = false;
                return;
            }

            //If there is anything changed
            if (_IsModified)
            {
                if (!MessageBoxHandler.ConfirmMessage("Operation.Request.Cancel", ""))
                {
                    _SkipAllowed = true;
                    lsbPurchaseOrder.SelectedValue = _CurrentPurchaseOrder.PurchaseOrderID;
                    return;
                }
            }

            if ((lsbPurchaseOrder.DisplayMember == "") || (lsbPurchaseOrder.ValueMember == ""))
                return;

            if (lsbPurchaseOrder.SelectedIndex == -1)
            {
                _CurrentPurchaseOrder = new PurchaseOrder();
                cmdDeletePurchaseOrder.Enabled = false;
                ResetPurchaseInfo();
                return;
            }

            SetPurchaseInfo(true);
        }

        private void SetPurchaseInfo(bool refreshPurchaseHistory)
        {
            if (lsbPurchaseOrder.SelectedItem != null)
                _CurrentPurchaseOrder = (PurchaseOrder) lsbPurchaseOrder.SelectedItem;

            txtPurchaseOrderNumber.Text = _CurrentPurchaseOrder.PurchaseOrderNumber;
            dtpPurchaseOrderDate.Value = (DateTime) _CurrentPurchaseOrder.PurchaseOrderDate;
            dtpDeliveryDate.Value = (DateTime) _CurrentPurchaseOrder.DeliveryDate;
            dtpPaymentDate.Value = (DateTime) _CurrentPurchaseOrder.PaymentDate;
            cbbCurrency.SelectedValue = _CurrentPurchaseOrder.CurrencyID;
            txtExchangeRate.Text = _CurrentPurchaseOrder.ExchangeRate.ToString();
            txtAmountCurrency.Text = _CurrentPurchaseOrder.AmountCurrency.ToString();
            txtAmountStandard.Text = _CurrentPurchaseOrder.AmountStandard.ToString();
            cbbStatus.SelectedValue = _CurrentPurchaseOrder.StatusID;
            txtAmountPaid.Text = _CurrentPurchaseOrder.AmountPaid.ToString();
            rtbRemark.Text = _CurrentPurchaseOrder.Description;
            txtDiscount.Text = _CurrentPurchaseOrder.Discount.ToString();
            cbbPaymentTerm.SelectedValue = _CurrentPurchaseOrder.PaymentTermID;
            cbbSupplier.SelectedValue = _CurrentPurchaseOrder.SupplierID;
            txtTotal.Text =
                Math.Round(
                    _CurrentPurchaseOrder.AmountStandard -
                    (_CurrentPurchaseOrder.AmountStandard*(_CurrentPurchaseOrder.Discount/100)), 2).ToString();

            _IsModified = false;
            cmdDeletePurchaseOrder.Enabled = true;
            cmdNewPurchaseOrder.Enabled = true;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;
            cmdReset.Enabled = false;

            if (refreshPurchaseHistory)
                SetPurchaseHistory();
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtPurchaseOrderSearch.Text.Length != 0)
            {
                lsbPurchaseOrder.SelectedIndex = lsbPurchaseOrder.FindString(txtPurchaseOrderSearch.Text);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_IsModified)
                {
                    // Pre save
                    if (cbbSupplier.SelectedValue == null)
                    {
                        MessageBox.Show("Supplier");
                        return;
                    }

                    if (cbbCurrency.SelectedValue != null)
                        _CurrentPurchaseOrder.CurrencyID = Int32.Parse(cbbCurrency.SelectedValue.ToString());
                    _CurrentPurchaseOrder.ExchangeRate = float.Parse(txtExchangeRate.Text);
                    _CurrentPurchaseOrder.PurchaseOrderDate = dtpPurchaseOrderDate.Value;
                    _CurrentPurchaseOrder.DeliveryDate = dtpDeliveryDate.Value;
                    _CurrentPurchaseOrder.PaymentDate = dtpPaymentDate.Value;

                    if (cbbSupplier.SelectedValue != null)
                        _CurrentPurchaseOrder.SupplierID = Int32.Parse(cbbSupplier.SelectedValue.ToString());
                    if (cbbStatus.SelectedValue != null)
                        _CurrentPurchaseOrder.StatusID = Int32.Parse(cbbStatus.SelectedValue.ToString());
                    if (cbbPaymentTerm.SelectedValue != null)
                        _CurrentPurchaseOrder.PaymentTermID = Int32.Parse(cbbPaymentTerm.SelectedValue.ToString());
                    _CurrentPurchaseOrder.Description = rtbRemark.Text;

                    _CurrentPurchaseOrder.AmountCurrency =
                        AppContext._ExchangeRate != null
                            ?
                                float.Parse(txtAmountCurrency.Text)*AppContext._ExchangeRate.ExchangeValue
                            :
                                float.Parse(txtAmountCurrency.Text);
                    _CurrentPurchaseOrder.AmountStandard = float.Parse(txtAmountStandard.Text);
                    _CurrentPurchaseOrder.Discount = float.Parse(txtDiscount.Text);
                    _CurrentPurchaseOrder.AmountPaid = float.Parse(txtAmountPaid.Text);

                    SetModifydStatus(false);
                    // Saving
                    if (_CurrentPurchaseOrder.PurchaseOrderID == 0)
                    {
                        _PurchaseOrderService.PurchaseOrderManagement(_CurrentPurchaseOrder, _PurchaseItemList,
                                                                      Resources.OperationRequestInsert);
                        _PurchaseOrderBindingList.Add(_CurrentPurchaseOrder);
                    }
                    else
                    {
                        _PurchaseOrderService.PurchaseOrderManagement(_CurrentPurchaseOrder, _PurchaseItemList,
                                                                      Resources.OperationRequestUpdate);
                        _SkipAllowed = true;
                        _PurchaseOrderBindingList[lsbPurchaseOrder.SelectedIndex] = _CurrentPurchaseOrder;
                    }

                    // Post save
                    cmdCancel_Click(sender, e);
                }
            }
            catch (Exception exception)
            {
                SetModifydStatus(true);
                MessageBoxHandler.UnknownErrorMessage(Resources.MessageCaptionUnknownError, exception.Message);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ResetPurchaseInfo();
        }

        private void cmdNewPurchaseOrder_Click(object sender, EventArgs e)
        {
            lsbPurchaseOrder.SelectedIndex = -1;
            lsbPurchaseOrder.Enabled = false;
            cmdNewPurchaseOrder.Enabled = false;
            cmdReset.Enabled = true;
            cmdSave.Enabled = true;
            cmdCancel.Enabled = true;
            _IsModified = true;

            ResetPurchaseInfo();
        }

        private void cmdDeleteProduct_Click(object sender, EventArgs e)
        {
            if (lsbPurchaseOrder.SelectedIndex == -1)
                return;

            if (!MessageBoxHandler.ConfirmMessage("Operation.Request.Delete",
                                                  _CurrentPurchaseOrder.PurchaseOrderNumber))
                return;

            object objResult =
                _PurchaseOrderService.PurchaseOrderManagement(
                    _CurrentPurchaseOrder, _PurchaseItemList,
                    Resources.OperationRequestDelete);
            if (objResult != null)
            {
                MessageBoxHandler.UnknownErrorMessage(
                    Resources.MessageCaptionUnknownError,
                    objResult.ToString());
                return;
            }

            _PurchaseOrderBindingList.Remove(_CurrentPurchaseOrder);
            if (lsbPurchaseOrder.SelectedIndex == 0)
            {
                lsbPurchaseOrder.SelectedIndex = -1;
                SetModifydStatus(false);
                if (_PurchaseOrderBindingList.Count != 0)
                    lsbPurchaseOrder.SelectedIndex = 0;
            }
            else
                lsbPurchaseOrder.SelectedIndex = lsbPurchaseOrder.SelectedIndex - 1;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (_IsModified)
            {
                if (MessageBoxHandler.ConfirmMessage("Operation.Request.Cancel", ""))
                {
                    _IsModified = false;
                    lsbPurchaseOrder.Enabled = true;
                    if (lsbPurchaseOrder.SelectedIndex == -1)
                        lsbPurchaseOrder.SelectedIndex = 0;
                    else
                        lsbPurchaseOrder_SelectedIndexChanged(sender, e);
                }
                else
                    return;
            }
            lsbPurchaseOrder.Enabled = true;
            cmdNewPurchaseOrder.Enabled = true;
            cmdDeletePurchaseOrder.Enabled = true;
            cmdReset.Enabled = false;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            if (_CurrentPurchaseOrder == null)
                return;
            _IsModified = modifyStatus;
            cmdSave.Enabled = _IsModified;
            cmdCancel.Enabled = _IsModified;
            cmdNewPurchaseOrder.Enabled = !_IsModified;
            cmdDeletePurchaseOrder.Enabled = !_IsModified;
        }

        private void SetPurchaseModifiedStatus(bool modifyStatus)
        {
            _IsModifiedPurchaseItem = modifyStatus;
        }

        private void rtbRemark_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void ResetPurchaseInfo()
        {
            txtPurchaseOrderNumber.Text = "AutoNumber";
            dtpDeliveryDate.Value = DateTime.Now;
            dtpPaymentDate.Value = DateTime.Now;
            dtpPurchaseOrderDate.Value = DateTime.Now;
            txtExchangeRate.Text =
                AppContext._ExchangeRate != null
                    ?
                        AppContext._ExchangeRate.ExchangeValue.ToString("N2")
                    :
                        "0.00";
            rtbRemark.Text = "";
            cbbStatus.SelectedIndex = -1;
            cbbSupplier.SelectedIndex = 0;
            cbbCurrency.SelectedIndex = -1;
            cbbPaymentTerm.SelectedIndex = -1;

            txtAmountCurrency.Text = "0.0";
            txtAmountStandard.Text = "0.0";
            txtDiscount.Text = "0.0";
            txtTotal.Text = "0.0";
            txtAmountPaid.Text = "0.00";
            SetPurchaseHistory();
        }

        private void rtbRemark_Enter(object sender, EventArgs e)
        {
            rtbRemark.TextChanged += rtbRemark_TextChanged;
        }

        private void rtbRemark_Leave(object sender, EventArgs e)
        {
            rtbRemark.TextChanged -= rtbRemark_TextChanged;
        }

        private void SetPurchaseHistory()
        {
            if (_CurrentPurchaseOrder == null)
                return;

            _PurchaseItemList =
                CommonService.IListToBindingList(
                    _PurchaseOrderService.GetPurchaseItems(_CurrentPurchaseOrder.PurchaseOrderID));
            dgvPurchaseHistory.DataSource = CommonService.IListToDataTable(typeof (PurchaseItem), _PurchaseItemList);

            dgvPurchaseHistory.Columns.Remove("QtyOut");

            dgvPurchaseHistory.Columns["BarCodeValue"].DisplayIndex = 0;
            dgvPurchaseHistory.Columns["ProductID"].DisplayIndex = 1;
            dgvPurchaseHistory.Columns["Quantity"].DisplayIndex = 2;
            dgvPurchaseHistory.Columns["ProductUnitID"].DisplayIndex = 3;
            dgvPurchaseHistory.Columns["UnitPrice"].DisplayIndex = 4;
            dgvPurchaseHistory.Columns["SubTotal"].DisplayIndex = 5;
            dgvPurchaseHistory.Columns["CellID"].DisplayIndex = 6;
            dgvPurchaseHistory.Columns["DateIn"].DisplayIndex = 7;
            dgvPurchaseHistory.Columns["DateExpire"].DisplayIndex = 8;

            SetPurchaseModifiedStatus(false);
        }

        private void dgvPurchaseHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        private void PopulatePurchaseOrderList()
        {
            _PurchaseOrderBindingList = CommonService.IListToBindingList(_PurchaseOrderService.GetPurchaseOrders());
            lsbPurchaseOrder.ValueMember = PurchaseOrder.CONST_PURCHASE_ORDER_ID;
            lsbPurchaseOrder.DisplayMember = PurchaseOrder.CONST_PURCHASE_ORDER_NUMBER;
            lsbPurchaseOrder.DataSource = _PurchaseOrderBindingList;
        }

        private void dgvPurchaseHistory_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (_IsModifiedPurchaseItem)
                UpdatePurchaseOrderAmount();
        }

        private void dgvPurchaseHistory_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModifiedPurchaseItem)
                return;

            if (dgvPurchaseHistory.Rows[e.RowIndex].Cells["ProductID"].Value is DBNull)
                e.Cancel = true;

            if (dgvPurchaseHistory.Rows[e.RowIndex].Cells["BarCodeValue"].Value is DBNull)
            {
                if (!MessageBoxHandler.ConfirmMessage("Message.Barcode.Null", ""))
                    e.Cancel = true;
                else
                {
                    if (_BarCodeService == null)
                        _BarCodeService = ServiceFactory.GenerateServiceInstance().GenerateBarCodeService();

                    BarCode barCode = _BarCodeService.AddBarCode();
                    dgvPurchaseHistory.Rows[e.RowIndex].Cells["BarCodeValue"].Value = barCode.BarCodeValue;
                }
            }

            if (dgvPurchaseHistory.Rows[e.RowIndex].Cells["CellID"].Value is DBNull)
                e.Cancel = true;

            if (dgvPurchaseHistory.Rows[e.RowIndex].Cells["DateIn"].Value is DBNull)
                e.Cancel = true;

            if (dgvPurchaseHistory.Rows[e.RowIndex].Cells["ProductUnitID"].Value is DBNull)
                e.Cancel = true;

            if (dgvPurchaseHistory.Rows[e.RowIndex].Cells["Quantity"].Value is DBNull)
                e.Cancel = true;

            if (dgvPurchaseHistory.Rows[e.RowIndex].Cells["UnitPrice"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                PurchaseItem purchaseItem;
                if (dgvPurchaseHistory.Rows[e.RowIndex].Cells["PurchaseItemID"].Value is DBNull)
                {
                    purchaseItem = new PurchaseItem();
                    _PurchaseItemList.Add(purchaseItem);
                }
                else
                {
                    purchaseItem = (PurchaseItem) _PurchaseItemList[e.RowIndex];
                }
                purchaseItem.ProductID =
                    Int32.Parse(dgvPurchaseHistory.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());
                purchaseItem.BarCodeValue = dgvPurchaseHistory.Rows[e.RowIndex].Cells["BarCodeValue"].Value.ToString();
                purchaseItem.CellID = Int32.Parse(dgvPurchaseHistory.Rows[e.RowIndex].Cells["CellID"].Value.ToString());
                purchaseItem.DateExpire =
                    DateTime.Parse(dgvPurchaseHistory.Rows[e.RowIndex].Cells["DateExpire"].Value.ToString());
                purchaseItem.DateIn =
                    DateTime.Parse(dgvPurchaseHistory.Rows[e.RowIndex].Cells["DateIn"].Value.ToString());
                purchaseItem.ProductUnitID =
                    Int32.Parse(dgvPurchaseHistory.Rows[e.RowIndex].Cells["ProductUnitID"].Value.ToString());
                purchaseItem.Quantity =
                    float.Parse(dgvPurchaseHistory.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                purchaseItem.UnitPrice =
                    float.Parse(dgvPurchaseHistory.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString());
                purchaseItem.SubTotal =
                    float.Parse(Math.Round(purchaseItem.Quantity*purchaseItem.UnitPrice, 2).ToString());
                dgvPurchaseHistory.Rows[e.RowIndex].Cells["SubTotal"].Value = purchaseItem.SubTotal.ToString();

                SetPurchaseModifiedStatus(false);
                SetModifydStatus(true);

                UpdatePurchaseOrderAmount();
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void dgvPurchaseHistory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPurchaseHistory.DataSource == null)
                return;

            if (dgvPurchaseHistory.CurrentRow.IsNewRow)
                return;

            if (dgvPurchaseHistory.CurrentRow.ReadOnly)
                return;

            SetPurchaseModifiedStatus(true);
        }

        private void dgvPurchaseHistory_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            SetPurchaseModifiedStatus(false);
        }

        private void dgvPurchaseHistory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dgvPurchaseHistory.CurrentRow.Cells["DateIn"].Value = DateTime.Today;
        }

        private void dgvPurchaseHistory_Leave(object sender, EventArgs e)
        {
            if ((dgvPurchaseHistory.CurrentRow.Cells["ProductID"].Value is DBNull) ||
                (dgvPurchaseHistory.CurrentRow.Cells["BarCodeValue"].Value is DBNull) ||
                (dgvPurchaseHistory.CurrentRow.Cells["CellID"].Value is DBNull) ||
                (dgvPurchaseHistory.CurrentRow.Cells["DateIn"].Value is DBNull) ||
                (dgvPurchaseHistory.CurrentRow.Cells["ProductUnitID"].Value is DBNull) ||
                (dgvPurchaseHistory.CurrentRow.Cells["Quantity"].Value is DBNull) ||
                (dgvPurchaseHistory.CurrentRow.Cells["UnitPrice"].Value is DBNull))
                SetPurchaseModifiedStatus(false);
        }

        private void dgvPurchaseHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPurchaseHistory.CurrentRow == null)
                return;

            if (dgvPurchaseHistory.CurrentRow.Cells["PurchaseItemID"].Value == null)
                dgvPurchaseHistory.CurrentRow.ReadOnly = false;
            else if (dgvPurchaseHistory.CurrentRow.Cells["PurchaseItemID"].Value is DBNull)
                dgvPurchaseHistory.CurrentRow.ReadOnly = false;
            else
                dgvPurchaseHistory.CurrentRow.ReadOnly = true;
        }

        private void cbbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCurrency.SelectedIndex == -1)
                return;

            lblAmountCurrency.Text = "ទឹកប្រាក់សរុបជា " + ((Currency) cbbCurrency.SelectedItem).CurrencySymbol;
        }

        private void UpdatePurchaseOrderAmount()
        {
            double discount = 0, amountCurrency = 0, amountStandard = 0;
            double amountGrandTotal, exchangeRate = 0;

            try
            {
                if (_PurchaseItemList.Count == 0)
                    return;

                if (txtDiscount.Text.Length != 0)
                    discount = double.Parse(txtDiscount.Text);

                if (txtExchangeRate.Text.Length != 0)
                    exchangeRate = double.Parse(txtExchangeRate.Text);

                foreach (PurchaseItem purchaseItem in _PurchaseItemList)
                    amountStandard += purchaseItem.Quantity*purchaseItem.UnitPrice;

                amountCurrency = amountStandard*(exchangeRate == 0 ? 1 : exchangeRate);
                amountGrandTotal = Math.Round(amountStandard - ((amountStandard*discount)/100), 2);

                txtAmountCurrency.Text = Math.Round(amountCurrency, 2).ToString("N2");
                txtAmountStandard.Text = Math.Round(amountStandard, 2).ToString("N2");
                txtTotal.Text = amountGrandTotal.ToString("N2");
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            txtDiscount.TextChanged -= txtDiscount_TextChanged;

            if (_IsModified)
                UpdatePurchaseOrderAmount();
        }

        private void txtDiscount_Enter(object sender, EventArgs e)
        {
            txtDiscount.TextChanged += txtDiscount_TextChanged;
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void txtPurchaseOrderNumber_Leave(object sender, EventArgs e)
        {
            txtPurchaseOrderNumber.Leave -= ModificationHandler;
        }

        private void txtPurchaseOrderNumber_Enter(object sender, EventArgs e)
        {
            txtPurchaseOrderNumber.Enter += ModificationHandler;
        }

        private void txtExchangeRate_Leave(object sender, EventArgs e)
        {
            txtExchangeRate.Leave -= ModificationHandler;
        }

        private void txtExchangeRate_Enter(object sender, EventArgs e)
        {
            txtExchangeRate.Enter += ModificationHandler;
        }

        private void cbbCurrency_Leave(object sender, EventArgs e)
        {
            cbbCurrency.SelectedIndexChanged -= ModificationHandler;
        }

        private void cbbCurrency_Enter(object sender, EventArgs e)
        {
            cbbCurrency.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbSupplier_Enter(object sender, EventArgs e)
        {
            cbbSupplier.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbSupplier_Leave(object sender, EventArgs e)
        {
            cbbSupplier.SelectedIndexChanged -= ModificationHandler;
        }

        private void cbbStatus_Leave(object sender, EventArgs e)
        {
            cbbStatus.SelectedIndexChanged -= ModificationHandler;
        }

        private void cbbStatus_Enter(object sender, EventArgs e)
        {
            cbbStatus.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbPaymentTerm_Enter(object sender, EventArgs e)
        {
            cbbPaymentTerm.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbPaymentTerm_Leave(object sender, EventArgs e)
        {
            cbbPaymentTerm.SelectedIndexChanged -= ModificationHandler;
        }

        private void dtpPurchaseOrderDate_Enter(object sender, EventArgs e)
        {
            dtpPurchaseOrderDate.ValueChanged += ModificationHandler;
        }

        private void dtpPurchaseOrderDate_Leave(object sender, EventArgs e)
        {
            dtpPurchaseOrderDate.ValueChanged -= ModificationHandler;
        }

        private void dtpDeliveryDate_Enter(object sender, EventArgs e)
        {
            dtpDeliveryDate.ValueChanged += ModificationHandler;
        }

        private void dtpDeliveryDate_Leave(object sender, EventArgs e)
        {
            dtpDeliveryDate.ValueChanged -= ModificationHandler;
        }

        private void dtpPaymentDate_Enter(object sender, EventArgs e)
        {
            dtpPaymentDate.ValueChanged += ModificationHandler;
        }

        private void dtpPaymentDate_Leave(object sender, EventArgs e)
        {
            dtpPaymentDate.ValueChanged -= ModificationHandler;
        }

        private void ModificationHandler(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void dgvPurchaseHistory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPurchaseHistory.CurrentCell.OwningColumn.Name == "BarCodeValue")
            {
                if (dgvPurchaseHistory.CurrentRow.Cells["BarCodeValue"].Value is DBNull)
                    return;

                if (dgvPurchaseHistory.CurrentRow.Cells["BarCodeValue"].Value == null)
                    return;

                string barCodeValue = dgvPurchaseHistory.CurrentRow.Cells["BarCodeValue"].Value.ToString();
                if (barCodeValue.Length == 0)
                    return;
                if (!(dgvPurchaseHistory.CurrentRow.Cells["ProductID"].Value is DBNull))
                    return;

                if (!String.IsNullOrEmpty(dgvPurchaseHistory.CurrentRow.Cells["ProductID"].Value.ToString()))
                    return;

                IList productList = _ProductService.GetProductsFromPurchaseHistory(barCodeValue);
                if (productList.Count == 0)
                    return;

                dgvPurchaseHistory.CurrentRow.Cells["ProductID"].Value =
                    ((PurchaseItem) productList[0]).ProductID;

                dgvPurchaseHistory.CurrentRow.Cells["ProductUnitID"].Value =
                    ((PurchaseItem) productList[0]).ProductUnitID;

                dgvPurchaseHistory.CurrentRow.Cells["UnitPrice"].Value =
                    ((PurchaseItem) productList[0]).UnitPrice;

                dgvPurchaseHistory.CurrentRow.Cells["DateExpire"].Value =
                    ((PurchaseItem) productList[0]).DateExpire;
            }
            else if (dgvPurchaseHistory.CurrentCell.OwningColumn.Name == "ProductID")
            {
                if (dgvPurchaseHistory.CurrentRow.Cells["ProductID"].Value is DBNull)
                    return;

                if (dgvPurchaseHistory.CurrentRow.Cells["ProductID"].Value == null)
                    return;

                if (!(dgvPurchaseHistory.CurrentRow.Cells["BarCodeValue"].Value is DBNull))
                    return;

                if (!String.IsNullOrEmpty(dgvPurchaseHistory.CurrentRow.Cells["BarCodeValue"].Value.ToString()))
                    return;

                int productID = Int32.Parse(dgvPurchaseHistory.CurrentRow.Cells["ProductID"].Value.ToString());

                IList productList = _ProductService.GetProductsFromPurchaseHistory(productID);
                if (productList.Count == 0)
                    return;

                dgvPurchaseHistory.CurrentRow.Cells["BarCodeValue"].Value =
                    ((PurchaseItem) productList[0]).BarCodeValue;

                dgvPurchaseHistory.CurrentRow.Cells["ProductUnitID"].Value =
                    ((PurchaseItem) productList[0]).ProductUnitID;

                dgvPurchaseHistory.CurrentRow.Cells["UnitPrice"].Value =
                    ((PurchaseItem) productList[0]).UnitPrice;

                dgvPurchaseHistory.CurrentRow.Cells["DateExpire"].Value =
                    ((PurchaseItem) productList[0]).DateExpire;
            }

            if (dgvPurchaseHistory.CurrentRow.Cells["DateExpire"].Value is DBNull)
                dgvPurchaseHistory.CurrentRow.Cells["DateExpire"].Value = DateTime.Today.AddMonths(1);

            if (dgvPurchaseHistory.CurrentRow.Cells["DateExpire"].Value == null)
                dgvPurchaseHistory.CurrentRow.Cells["DateExpire"].Value = DateTime.Today.AddMonths(1);
        }

        private void txtAmountPaid_Enter(object sender, EventArgs e)
        {
            txtAmountPaid.TextChanged += txtDiscount_TextChanged;
        }

        private void txtAmountPaid_Leave(object sender, EventArgs e)
        {
            txtAmountPaid.TextChanged -= txtDiscount_TextChanged;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSearchPurchaseOrder = new System.Windows.Forms.Button();
            this.cmdDeletePurchaseOrder = new System.Windows.Forms.Button();
            this.cmdNewPurchaseOrder = new System.Windows.Forms.Button();
            this.txtPurchaseOrderSearch = new System.Windows.Forms.TextBox();
            this.lsbPurchaseOrder = new System.Windows.Forms.ListBox();
            this.grbPurchaseOrderInfo = new System.Windows.Forms.GroupBox();
            this.lblAmountStandard = new System.Windows.Forms.Label();
            this.txtAmountStandard = new System.Windows.Forms.TextBox();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblAmountCurrency = new System.Windows.Forms.Label();
            this.txtAmountCurrency = new System.Windows.Forms.TextBox();
            this.lblPaymentTerm = new System.Windows.Forms.Label();
            this.cbbPaymentTerm = new System.Windows.Forms.ComboBox();
            this.dgvPurchaseHistory = new System.Windows.Forms.DataGridView();
            this.PurchaseItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BarCodeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductUnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DateIn = new GenericDataGridView.ExtendedDataGridView.CalendarColumn();
            this.DateExpire = new GenericDataGridView.ExtendedDataGridView.CalendarColumn();
            this.FKPurchaseOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbSupplierID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cbbSupplier = new System.Windows.Forms.ComboBox();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.dtpPurchaseOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblPurchaseOrderDate = new System.Windows.Forms.Label();
            this.grbLine_2 = new System.Windows.Forms.GroupBox();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cbbCurrency = new System.Windows.Forms.ComboBox();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.rtbRemark = new System.Windows.Forms.RichTextBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblPurchaseOrderNumber = new System.Windows.Forms.Label();
            this.txtPurchaseOrderNumber = new System.Windows.Forms.TextBox();
            this.txtOperationInfo = new System.Windows.Forms.TextBox();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbPurchaseOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvPurchaseHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.txtOperationInfo);
            this.pnlBody.Controls.Add(this.grbPurchaseOrderInfo);
            this.pnlBody.Controls.Add(this.cmdSearchPurchaseOrder);
            this.pnlBody.Controls.Add(this.cmdDeletePurchaseOrder);
            this.pnlBody.Controls.Add(this.cmdNewPurchaseOrder);
            this.pnlBody.Controls.Add(this.txtPurchaseOrderSearch);
            this.pnlBody.Controls.Add(this.lsbPurchaseOrder);
            this.pnlBody.Size = new System.Drawing.Size(1016, 584);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(1016, 75);
            // 
            // cmdSearchPurchaseOrder
            // 
            this.cmdSearchPurchaseOrder.Font = new System.Drawing.Font("Trebuchet MS", 9.75F,
                                                                       System.Drawing.FontStyle.Bold,
                                                                       System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdSearchPurchaseOrder.Image = Resources.Search32;
            this.cmdSearchPurchaseOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearchPurchaseOrder.Location = new System.Drawing.Point(209, 9);
            this.cmdSearchPurchaseOrder.Name = "cmdSearchPurchaseOrder";
            this.cmdSearchPurchaseOrder.Size = new System.Drawing.Size(89, 28);
            this.cmdSearchPurchaseOrder.TabIndex = 1;
            this.cmdSearchPurchaseOrder.Text = "&Search";
            this.cmdSearchPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearchPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // cmdDeletePurchaseOrder
            // 
            this.cmdDeletePurchaseOrder.Font = new System.Drawing.Font("Trebuchet MS", 9.75F,
                                                                       System.Drawing.FontStyle.Bold,
                                                                       System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdDeletePurchaseOrder.Image = Resources.Delete32;
            this.cmdDeletePurchaseOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeletePurchaseOrder.Location = new System.Drawing.Point(209, 582);
            this.cmdDeletePurchaseOrder.Name = "cmdDeletePurchaseOrder";
            this.cmdDeletePurchaseOrder.Size = new System.Drawing.Size(89, 28);
            this.cmdDeletePurchaseOrder.TabIndex = 4;
            this.cmdDeletePurchaseOrder.Text = "&Delete";
            this.cmdDeletePurchaseOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDeletePurchaseOrder.UseVisualStyleBackColor = true;
            this.cmdDeletePurchaseOrder.Click += new System.EventHandler(this.cmdDeleteProduct_Click);
            // 
            // cmdNewPurchaseOrder
            // 
            this.cmdNewPurchaseOrder.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                    System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdNewPurchaseOrder.Location = new System.Drawing.Point(118, 582);
            this.cmdNewPurchaseOrder.Name = "cmdNewPurchaseOrder";
            this.cmdNewPurchaseOrder.Size = new System.Drawing.Size(89, 28);
            this.cmdNewPurchaseOrder.TabIndex = 3;
            this.cmdNewPurchaseOrder.Text = "&New";
            this.cmdNewPurchaseOrder.UseVisualStyleBackColor = true;
            this.cmdNewPurchaseOrder.Click += new System.EventHandler(this.cmdNewPurchaseOrder_Click);
            // 
            // txtPurchaseOrderSearch
            // 
            this.txtPurchaseOrderSearch.Font = new System.Drawing.Font("Trebuchet MS", 9.75F,
                                                                       System.Drawing.FontStyle.Bold,
                                                                       System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPurchaseOrderSearch.Location = new System.Drawing.Point(14, 14);
            this.txtPurchaseOrderSearch.Name = "txtPurchaseOrderSearch";
            this.txtPurchaseOrderSearch.Size = new System.Drawing.Size(189, 23);
            this.txtPurchaseOrderSearch.TabIndex = 0;
            this.txtPurchaseOrderSearch.TextChanged += new System.EventHandler(this.txtProductSearch_TextChanged);
            // 
            // lsbPurchaseOrder
            // 
            this.lsbPurchaseOrder.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lsbPurchaseOrder.FormattingEnabled = true;
            this.lsbPurchaseOrder.HorizontalScrollbar = true;
            this.lsbPurchaseOrder.ItemHeight = 22;
            this.lsbPurchaseOrder.Location = new System.Drawing.Point(14, 43);
            this.lsbPurchaseOrder.Name = "lsbPurchaseOrder";
            this.lsbPurchaseOrder.Size = new System.Drawing.Size(284, 532);
            this.lsbPurchaseOrder.TabIndex = 2;
            this.lsbPurchaseOrder.SelectedIndexChanged +=
                new System.EventHandler(this.lsbPurchaseOrder_SelectedIndexChanged);
            // 
            // grbPurchaseOrderInfo
            // 
            this.grbPurchaseOrderInfo.Controls.Add(this.lblAmountStandard);
            this.grbPurchaseOrderInfo.Controls.Add(this.txtAmountStandard);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblAmountPaid);
            this.grbPurchaseOrderInfo.Controls.Add(this.txtAmountPaid);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblTotal);
            this.grbPurchaseOrderInfo.Controls.Add(this.txtTotal);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblAmountCurrency);
            this.grbPurchaseOrderInfo.Controls.Add(this.txtAmountCurrency);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblPaymentTerm);
            this.grbPurchaseOrderInfo.Controls.Add(this.cbbPaymentTerm);
            this.grbPurchaseOrderInfo.Controls.Add(this.dgvPurchaseHistory);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblStatus);
            this.grbPurchaseOrderInfo.Controls.Add(this.cbbStatus);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblDiscount);
            this.grbPurchaseOrderInfo.Controls.Add(this.txtDiscount);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblSupplier);
            this.grbPurchaseOrderInfo.Controls.Add(this.cbbSupplier);
            this.grbPurchaseOrderInfo.Controls.Add(this.dtpPaymentDate);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblPaymentDate);
            this.grbPurchaseOrderInfo.Controls.Add(this.dtpDeliveryDate);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblDeliveryDate);
            this.grbPurchaseOrderInfo.Controls.Add(this.dtpPurchaseOrderDate);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblPurchaseOrderDate);
            this.grbPurchaseOrderInfo.Controls.Add(this.grbLine_2);
            this.grbPurchaseOrderInfo.Controls.Add(this.grbLine_1);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblCurrency);
            this.grbPurchaseOrderInfo.Controls.Add(this.cbbCurrency);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblExchangeRate);
            this.grbPurchaseOrderInfo.Controls.Add(this.txtExchangeRate);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblRemark);
            this.grbPurchaseOrderInfo.Controls.Add(this.rtbRemark);
            this.grbPurchaseOrderInfo.Controls.Add(this.cmdReset);
            this.grbPurchaseOrderInfo.Controls.Add(this.cmdCancel);
            this.grbPurchaseOrderInfo.Controls.Add(this.cmdSave);
            this.grbPurchaseOrderInfo.Controls.Add(this.lblPurchaseOrderNumber);
            this.grbPurchaseOrderInfo.Controls.Add(this.txtPurchaseOrderNumber);
            this.grbPurchaseOrderInfo.Font = new System.Drawing.Font("Khmer OS System", 12F,
                                                                     System.Drawing.FontStyle.Bold,
                                                                     System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.grbPurchaseOrderInfo.Location = new System.Drawing.Point(311, 3);
            this.grbPurchaseOrderInfo.Name = "grbPurchaseOrderInfo";
            this.grbPurchaseOrderInfo.Size = new System.Drawing.Size(700, 572);
            this.grbPurchaseOrderInfo.TabIndex = 5;
            this.grbPurchaseOrderInfo.TabStop = false;
            this.grbPurchaseOrderInfo.Text = "ពត៍មានអំពីការបញ្ជាទិញ";
            // 
            // lblAmountStandard
            // 
            this.lblAmountStandard.AutoSize = true;
            this.lblAmountStandard.Font = new System.Drawing.Font("Khmer OS System", 9.75F,
                                                                  System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblAmountStandard.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmountStandard.Location = new System.Drawing.Point(48, 478);
            this.lblAmountStandard.Name = "lblAmountStandard";
            this.lblAmountStandard.Size = new System.Drawing.Size(127, 24);
            this.lblAmountStandard.TabIndex = 25;
            this.lblAmountStandard.Text = "ទឹកប្រាក់សរុបជា $";
            this.lblAmountStandard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmountStandard
            // 
            this.txtAmountStandard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountStandard.Enabled = false;
            this.txtAmountStandard.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtAmountStandard.Location = new System.Drawing.Point(177, 476);
            this.txtAmountStandard.Name = "txtAmountStandard";
            this.txtAmountStandard.Size = new System.Drawing.Size(150, 23);
            this.txtAmountStandard.TabIndex = 26;
            this.txtAmountStandard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblAmountPaid.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmountPaid.Location = new System.Drawing.Point(354, 501);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(181, 24);
            this.lblAmountPaid.TabIndex = 32;
            this.lblAmountPaid.Text = "ទឹកប្រាក់ដែលបានសងជា $";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountPaid.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtAmountPaid.Location = new System.Drawing.Point(537, 502);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(150, 23);
            this.txtAmountPaid.TabIndex = 33;
            this.txtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPaid.Leave += new System.EventHandler(this.txtAmountPaid_Leave);
            this.txtAmountPaid.Enter += new System.EventHandler(this.txtAmountPaid_Enter);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotal.Location = new System.Drawing.Point(342, 478);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(193, 24);
            this.lblTotal.TabIndex = 30;
            this.lblTotal.Text = "ទឹកប្រាក់សរុបចុងក្រោយជា $";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtTotal.Location = new System.Drawing.Point(537, 476);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(150, 23);
            this.txtTotal.TabIndex = 31;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountCurrency
            // 
            this.lblAmountCurrency.AutoSize = true;
            this.lblAmountCurrency.Font = new System.Drawing.Font("Khmer OS System", 9.75F,
                                                                  System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblAmountCurrency.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmountCurrency.Location = new System.Drawing.Point(49, 451);
            this.lblAmountCurrency.Name = "lblAmountCurrency";
            this.lblAmountCurrency.Size = new System.Drawing.Size(114, 24);
            this.lblAmountCurrency.TabIndex = 23;
            this.lblAmountCurrency.Text = "ទឹកប្រាក់សរុបជា";
            this.lblAmountCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmountCurrency
            // 
            this.txtAmountCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountCurrency.Enabled = false;
            this.txtAmountCurrency.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtAmountCurrency.Location = new System.Drawing.Point(177, 450);
            this.txtAmountCurrency.Name = "txtAmountCurrency";
            this.txtAmountCurrency.Size = new System.Drawing.Size(150, 23);
            this.txtAmountCurrency.TabIndex = 24;
            this.txtAmountCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPaymentTerm
            // 
            this.lblPaymentTerm.AutoSize = true;
            this.lblPaymentTerm.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPaymentTerm.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPaymentTerm.Location = new System.Drawing.Point(10, 168);
            this.lblPaymentTerm.Name = "lblPaymentTerm";
            this.lblPaymentTerm.Size = new System.Drawing.Size(121, 24);
            this.lblPaymentTerm.TabIndex = 16;
            this.lblPaymentTerm.Text = "របៀបទូទាត់ប្រាក់";
            // 
            // cbbPaymentTerm
            // 
            this.cbbPaymentTerm.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbPaymentTerm.FormattingEnabled = true;
            this.cbbPaymentTerm.Location = new System.Drawing.Point(136, 168);
            this.cbbPaymentTerm.Name = "cbbPaymentTerm";
            this.cbbPaymentTerm.Size = new System.Drawing.Size(205, 24);
            this.cbbPaymentTerm.TabIndex = 17;
            this.cbbPaymentTerm.Leave += new System.EventHandler(this.cbbPaymentTerm_Leave);
            this.cbbPaymentTerm.Enter += new System.EventHandler(this.cbbPaymentTerm_Enter);
            // 
            // dgvPurchaseHistory
            // 
            this.dgvPurchaseHistory.AllowUserToResizeColumns = false;
            this.dgvPurchaseHistory.AllowUserToResizeRows = false;
            this.dgvPurchaseHistory.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPurchaseHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseHistory.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                                                         {
                                                             this.PurchaseItemID,
                                                             this.PurchaseOrderID,
                                                             this.ProductID,
                                                             this.BarCodeValue,
                                                             this.Quantity,
                                                             this.ProductUnitID,
                                                             this.UnitPrice,
                                                             this.SubTotal,
                                                             this.CellID,
                                                             this.DateIn,
                                                             this.DateExpire,
                                                             this.FKPurchaseOrder,
                                                             this.cbbSupplierID
                                                         });
            this.dgvPurchaseHistory.Location = new System.Drawing.Point(16, 209);
            this.dgvPurchaseHistory.Name = "dgvPurchaseHistory";
            this.dgvPurchaseHistory.RowHeadersVisible = false;
            this.dgvPurchaseHistory.RowHeadersWidth = 25;
            this.dgvPurchaseHistory.RowHeadersWidthSizeMode =
                System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPurchaseHistory.RowTemplate.Height = 35;
            this.dgvPurchaseHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseHistory.ShowCellToolTips = false;
            this.dgvPurchaseHistory.Size = new System.Drawing.Size(672, 225);
            this.dgvPurchaseHistory.TabIndex = 21;
            this.dgvPurchaseHistory.VirtualMode = true;
            this.dgvPurchaseHistory.CellValueChanged +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseHistory_CellValueChanged);
            this.dgvPurchaseHistory.CellBeginEdit +=
                new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPurchaseHistory_CellBeginEdit);
            this.dgvPurchaseHistory.RowValidating +=
                new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPurchaseHistory_RowValidating);
            this.dgvPurchaseHistory.CancelRowEdit +=
                new System.Windows.Forms.QuestionEventHandler(this.dgvPurchaseHistory_CancelRowEdit);
            this.dgvPurchaseHistory.Leave += new System.EventHandler(this.dgvPurchaseHistory_Leave);
            this.dgvPurchaseHistory.CellEndEdit +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseHistory_CellEndEdit);
            this.dgvPurchaseHistory.RowValidated +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseHistory_RowValidated);
            this.dgvPurchaseHistory.DataError +=
                new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPurchaseHistory_DataError);
            this.dgvPurchaseHistory.SelectionChanged += new System.EventHandler(this.dgvPurchaseHistory_SelectionChanged);
            // 
            // PurchaseItemID
            // 
            this.PurchaseItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PurchaseItemID.DataPropertyName = "PurchaseItemID";
            this.PurchaseItemID.HeaderText = "PurchaseItemID";
            this.PurchaseItemID.Name = "PurchaseItemID";
            this.PurchaseItemID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PurchaseItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PurchaseItemID.Visible = false;
            // 
            // PurchaseOrderID
            // 
            this.PurchaseOrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PurchaseOrderID.DataPropertyName = "PurchaseOrderID";
            this.PurchaseOrderID.HeaderText = "PurchaseOrderID";
            this.PurchaseOrderID.Name = "PurchaseOrderID";
            this.PurchaseOrderID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PurchaseOrderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PurchaseOrderID.Visible = false;
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductID.DataPropertyName = "ProductID";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.ProductID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProductID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ProductID.HeaderText = "ឈ្មោះផលិតផល";
            this.ProductID.Name = "ProductID";
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductID.Width = 300;
            // 
            // BarCodeValue
            // 
            this.BarCodeValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BarCodeValue.DataPropertyName = "BarCodeValue";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.BarCodeValue.DefaultCellStyle = dataGridViewCellStyle3;
            this.BarCodeValue.HeaderText = "លេខបារកូដ";
            this.BarCodeValue.Name = "BarCodeValue";
            this.BarCodeValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BarCodeValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BarCodeValue.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.Quantity.HeaderText = "បរិមាណ";
            this.Quantity.Name = "Quantity";
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Quantity.Width = 80;
            // 
            // ProductUnitID
            // 
            this.ProductUnitID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductUnitID.DataPropertyName = "ProductUnitID";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.ProductUnitID.DefaultCellStyle = dataGridViewCellStyle5;
            this.ProductUnitID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ProductUnitID.HeaderText = "ឯកតា";
            this.ProductUnitID.Name = "ProductUnitID";
            this.ProductUnitID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // UnitPrice
            // 
            this.UnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = "0";
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.UnitPrice.HeaderText = "តំលៃឯកតា";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SubTotal.DataPropertyName = "SubTotal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N3";
            dataGridViewCellStyle7.NullValue = null;
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle7;
            this.SubTotal.HeaderText = "សរុប";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SubTotal.Width = 130;
            // 
            // CellID
            // 
            this.CellID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CellID.DataPropertyName = "CellID";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.CellID.DefaultCellStyle = dataGridViewCellStyle8;
            this.CellID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CellID.HeaderText = "ទីតាំង";
            this.CellID.Name = "CellID";
            this.CellID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CellID.Width = 110;
            // 
            // DateIn
            // 
            this.DateIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateIn.DataPropertyName = "DateIn";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.Format = "d";
            this.DateIn.DefaultCellStyle = dataGridViewCellStyle9;
            this.DateIn.HeaderText = "ថ្ងៃទិញចូល";
            this.DateIn.Name = "DateIn";
            this.DateIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DateIn.Width = 110;
            // 
            // DateExpire
            // 
            this.DateExpire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateExpire.DataPropertyName = "DateExpire";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.Format = "d";
            this.DateExpire.DefaultCellStyle = dataGridViewCellStyle10;
            this.DateExpire.HeaderText = "ថ្ងៃផុតកំណត់";
            this.DateExpire.Name = "DateExpire";
            this.DateExpire.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DateExpire.Width = 110;
            // 
            // FKPurchaseOrder
            // 
            this.FKPurchaseOrder.DataPropertyName = "FKPurchaseOrder";
            this.FKPurchaseOrder.HeaderText = "FKPurchaseOrder";
            this.FKPurchaseOrder.Name = "FKPurchaseOrder";
            this.FKPurchaseOrder.Visible = false;
            // 
            // cbbSupplierID
            // 
            this.cbbSupplierID.DataPropertyName = "SupplierID";
            this.cbbSupplierID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.cbbSupplierID.HeaderText = "SupplierID";
            this.cbbSupplierID.Name = "cbbSupplierID";
            this.cbbSupplierID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbbSupplierID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cbbSupplierID.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblStatus.Location = new System.Drawing.Point(10, 142);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 24);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "ស្ថានភាព";
            // 
            // cbbStatus
            // 
            this.cbbStatus.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Location = new System.Drawing.Point(136, 142);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(205, 24);
            this.cbbStatus.TabIndex = 15;
            this.cbbStatus.Leave += new System.EventHandler(this.cbbStatus_Leave);
            this.cbbStatus.Enter += new System.EventHandler(this.cbbStatus_Enter);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDiscount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDiscount.Location = new System.Drawing.Point(439, 452);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(96, 24);
            this.lblDiscount.TabIndex = 26;
            this.lblDiscount.Text = "បញ្ចុះតំលៃ %";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtDiscount.Location = new System.Drawing.Point(537, 450);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(150, 23);
            this.txtDiscount.TabIndex = 27;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            this.txtDiscount.Enter += new System.EventHandler(this.txtDiscount_Enter);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblSupplier.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSupplier.Location = new System.Drawing.Point(10, 116);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(76, 24);
            this.lblSupplier.TabIndex = 12;
            this.lblSupplier.Text = "អ្នកផ្គត់ផ្គង់";
            // 
            // cbbSupplier
            // 
            this.cbbSupplier.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbSupplier.FormattingEnabled = true;
            this.cbbSupplier.Location = new System.Drawing.Point(136, 116);
            this.cbbSupplier.Name = "cbbSupplier";
            this.cbbSupplier.Size = new System.Drawing.Size(205, 24);
            this.cbbSupplier.TabIndex = 13;
            this.cbbSupplier.Leave += new System.EventHandler(this.cbbSupplier_Leave);
            this.cbbSupplier.Enter += new System.EventHandler(this.cbbSupplier_Enter);
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CalendarFont = new System.Drawing.Font("Trebuchet MS", 12F,
                                                                       System.Drawing.FontStyle.Bold,
                                                                       System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dtpPaymentDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaymentDate.Location = new System.Drawing.Point(481, 81);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(205, 23);
            this.dtpPaymentDate.TabIndex = 11;
            this.dtpPaymentDate.Leave += new System.EventHandler(this.dtpPaymentDate_Leave);
            this.dtpPaymentDate.Enter += new System.EventHandler(this.dtpPaymentDate_Enter);
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPaymentDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPaymentDate.Location = new System.Drawing.Point(375, 79);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(98, 24);
            this.lblPaymentDate.TabIndex = 10;
            this.lblPaymentDate.Text = "ថ្ងៃទូទាត់ប្រាក់";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.CalendarFont = new System.Drawing.Font("Trebuchet MS", 12F,
                                                                        System.Drawing.FontStyle.Bold,
                                                                        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dtpDeliveryDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(481, 55);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(205, 23);
            this.dtpDeliveryDate.TabIndex = 9;
            this.dtpDeliveryDate.Leave += new System.EventHandler(this.dtpDeliveryDate_Leave);
            this.dtpDeliveryDate.Enter += new System.EventHandler(this.dtpDeliveryDate_Enter);
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDeliveryDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDeliveryDate.Location = new System.Drawing.Point(374, 55);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(103, 24);
            this.lblDeliveryDate.TabIndex = 8;
            this.lblDeliveryDate.Text = "ថ្ងៃបញ្ជូនទំនិញ";
            // 
            // dtpPurchaseOrderDate
            // 
            this.dtpPurchaseOrderDate.CalendarFont = new System.Drawing.Font("Trebuchet MS", 12F,
                                                                             System.Drawing.FontStyle.Bold,
                                                                             System.Drawing.GraphicsUnit.Point,
                                                                             ((byte) (0)));
            this.dtpPurchaseOrderDate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F,
                                                                     System.Drawing.FontStyle.Bold,
                                                                     System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.dtpPurchaseOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseOrderDate.Location = new System.Drawing.Point(481, 30);
            this.dtpPurchaseOrderDate.Name = "dtpPurchaseOrderDate";
            this.dtpPurchaseOrderDate.Size = new System.Drawing.Size(205, 23);
            this.dtpPurchaseOrderDate.TabIndex = 7;
            this.dtpPurchaseOrderDate.Leave += new System.EventHandler(this.dtpPurchaseOrderDate_Leave);
            this.dtpPurchaseOrderDate.Enter += new System.EventHandler(this.dtpPurchaseOrderDate_Enter);
            // 
            // lblPurchaseOrderDate
            // 
            this.lblPurchaseOrderDate.AutoSize = true;
            this.lblPurchaseOrderDate.Font = new System.Drawing.Font("Khmer OS System", 9.75F,
                                                                     System.Drawing.FontStyle.Bold,
                                                                     System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPurchaseOrderDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPurchaseOrderDate.Location = new System.Drawing.Point(375, 31);
            this.lblPurchaseOrderDate.Name = "lblPurchaseOrderDate";
            this.lblPurchaseOrderDate.Size = new System.Drawing.Size(86, 24);
            this.lblPurchaseOrderDate.TabIndex = 6;
            this.lblPurchaseOrderDate.Text = "ថ្ងៃបញ្ជាទិញ";
            // 
            // grbLine_2
            // 
            this.grbLine_2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_2.Location = new System.Drawing.Point(13, 440);
            this.grbLine_2.Name = "grbLine_2";
            this.grbLine_2.Size = new System.Drawing.Size(675, 2);
            this.grbLine_2.TabIndex = 22;
            this.grbLine_2.TabStop = false;
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(13, 202);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(675, 2);
            this.grbLine_1.TabIndex = 20;
            this.grbLine_1.TabStop = false;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCurrency.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCurrency.Location = new System.Drawing.Point(12, 58);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(60, 24);
            this.lblCurrency.TabIndex = 2;
            this.lblCurrency.Text = "រូបិយវត្ថុ";
            // 
            // cbbCurrency
            // 
            this.cbbCurrency.Enabled = false;
            this.cbbCurrency.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbCurrency.FormattingEnabled = true;
            this.cbbCurrency.Location = new System.Drawing.Point(136, 55);
            this.cbbCurrency.Name = "cbbCurrency";
            this.cbbCurrency.Size = new System.Drawing.Size(205, 24);
            this.cbbCurrency.TabIndex = 3;
            this.cbbCurrency.SelectedIndexChanged += new System.EventHandler(this.cbbCurrency_SelectedIndexChanged);
            this.cbbCurrency.Leave += new System.EventHandler(this.cbbCurrency_Leave);
            this.cbbCurrency.Enter += new System.EventHandler(this.cbbCurrency_Enter);
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblExchangeRate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblExchangeRate.Location = new System.Drawing.Point(10, 82);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(93, 24);
            this.lblExchangeRate.TabIndex = 4;
            this.lblExchangeRate.Text = "អត្រាប្ដូរប្រាក់";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Enabled = false;
            this.txtExchangeRate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtExchangeRate.Location = new System.Drawing.Point(136, 81);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(205, 23);
            this.txtExchangeRate.TabIndex = 5;
            this.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExchangeRate.Leave += new System.EventHandler(this.txtExchangeRate_Leave);
            this.txtExchangeRate.Enter += new System.EventHandler(this.txtExchangeRate_Enter);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblRemark.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRemark.Location = new System.Drawing.Point(374, 117);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(101, 24);
            this.lblRemark.TabIndex = 18;
            this.lblRemark.Text = "កំណត់សំគាល់";
            // 
            // rtbRemark
            // 
            this.rtbRemark.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rtbRemark.Location = new System.Drawing.Point(481, 116);
            this.rtbRemark.Name = "rtbRemark";
            this.rtbRemark.Size = new System.Drawing.Size(205, 75);
            this.rtbRemark.TabIndex = 19;
            this.rtbRemark.Text = "";
            this.rtbRemark.Enter += new System.EventHandler(this.rtbRemark_Enter);
            this.rtbRemark.Leave += new System.EventHandler(this.rtbRemark_Leave);
            this.rtbRemark.TextChanged += new System.EventHandler(this.rtbRemark_TextChanged);
            // 
            // cmdReset
            // 
            this.cmdReset.Enabled = false;
            this.cmdReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdReset.Location = new System.Drawing.Point(415, 533);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(89, 28);
            this.cmdReset.TabIndex = 34;
            this.cmdReset.Text = "&Reset";
            this.cmdReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Enabled = false;
            this.cmdCancel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdCancel.Image = Resources.Cancel32;
            this.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancel.Location = new System.Drawing.Point(599, 533);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(89, 28);
            this.cmdCancel.TabIndex = 36;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdSave.Image = Resources.OK32;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(507, 533);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 28);
            this.cmdSave.TabIndex = 35;
            this.cmdSave.Text = "&Save   ";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblPurchaseOrderNumber
            // 
            this.lblPurchaseOrderNumber.AutoSize = true;
            this.lblPurchaseOrderNumber.Font = new System.Drawing.Font("Khmer OS System", 9.75F,
                                                                       System.Drawing.FontStyle.Bold,
                                                                       System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPurchaseOrderNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPurchaseOrderNumber.Location = new System.Drawing.Point(10, 31);
            this.lblPurchaseOrderNumber.Name = "lblPurchaseOrderNumber";
            this.lblPurchaseOrderNumber.Size = new System.Drawing.Size(75, 24);
            this.lblPurchaseOrderNumber.TabIndex = 0;
            this.lblPurchaseOrderNumber.Text = "លេខបញ្ជា";
            // 
            // txtPurchaseOrderNumber
            // 
            this.txtPurchaseOrderNumber.Enabled = false;
            this.txtPurchaseOrderNumber.Font = new System.Drawing.Font("Trebuchet MS", 9.75F,
                                                                       System.Drawing.FontStyle.Bold,
                                                                       System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPurchaseOrderNumber.Location = new System.Drawing.Point(136, 30);
            this.txtPurchaseOrderNumber.Name = "txtPurchaseOrderNumber";
            this.txtPurchaseOrderNumber.Size = new System.Drawing.Size(205, 23);
            this.txtPurchaseOrderNumber.TabIndex = 1;
            this.txtPurchaseOrderNumber.Leave += new System.EventHandler(this.txtPurchaseOrderNumber_Leave);
            this.txtPurchaseOrderNumber.Enter += new System.EventHandler(this.txtPurchaseOrderNumber_Enter);
            // 
            // txtOperationInfo
            // 
            this.txtOperationInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOperationInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOperationInfo.Enabled = false;
            this.txtOperationInfo.Font = new System.Drawing.Font("Khmer OS System", 9.75F,
                                                                 System.Drawing.FontStyle.Regular,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtOperationInfo.Location = new System.Drawing.Point(311, 582);
            this.txtOperationInfo.Name = "txtOperationInfo";
            this.txtOperationInfo.ReadOnly = true;
            this.txtOperationInfo.Size = new System.Drawing.Size(699, 24);
            this.txtOperationInfo.TabIndex = 61;
            this.txtOperationInfo.TabStop = false;
            this.txtOperationInfo.Text = " ការថតទុកប្រព្រឹត្តទៅដោយជោគជ័យ";
            // 
            // FrmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmPurchaseOrder";
            this.Text = ".: Product :.";
            this.Load += new System.EventHandler(this.FrmPurchaseOrder_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grbPurchaseOrderInfo.ResumeLayout(false);
            this.grbPurchaseOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvPurchaseHistory)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}