using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.GUI.Forms;
using EzPos.Model;
using EzPos.Model.Common;
using EzPos.Service;

namespace EzPos.GUI
{
    /// <summary>
    /// Summary description for FrmSaleOrder.
    /// </summary>
    public class FrmSaleOrder : FrmBase
    {
        //Customized variable
        private readonly Container components;
        private bool _IsModifiedSaleItem, _PritFlag;
        private ProductService _ProductService;
        private BindingList<SaleItem> _SaleItemBindingList;
        private SaleOrder _SaleOrder;
        private SaleOrderService _SaleOrderService;
        private float _TotalAmountInUsd;
        private DataGridViewTextBoxColumn BarCodeValue;
        private ComboBox cbbProduct;
        private ComboBox cbbProductAvailable;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridView dgvSaleItem;
        private GroupBox grbLine_2;
        private GroupBox grbSaleInfo;
        private Label lblAmountTotalDollar;
        private Label lblAmountTotalRiel;
        private Label lblExchangeRate;
        private Label lblPaidAmount;
        private Label lblPaidAmountRiel;
        private Label lblReturnAmount;
        private Label lblReturnAmountRiel;
        private Label lblSONumber;
        private DataGridViewTextBoxColumn OrderID;
        private DataGridViewTextBoxColumn Product_Name;
        private DataGridViewTextBoxColumn ProductID;
        private DataGridViewTextBoxColumn QtyOut;
        private DataGridViewTextBoxColumn QtyOutStr;
        private DataGridViewTextBoxColumn SaleItemID;
        private DataGridViewTextBoxColumn SubTotal;
        private TextBox txtAmountTotalDollar;
        private TextBox txtAmountTotalRiel;
        private TextBox txtExchangeRate;
        private TextBox txtPaidAmount;
        private TextBox txtPaidAmountRiel;
        private TextBox txtProductScanned;
        private TextBox txtReturnAmount;
        private TextBox txtReturnAmountRiel;
        private TextBox txtSONumber;
        private DataGridViewComboBoxColumn UnitID;
        private DataGridViewTextBoxColumn UnitPriceIn;
        private DataGridViewTextBoxColumn UnitPriceOut;

        public FrmSaleOrder()
        {
            InitializeComponent();
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

        private void FrmSaleOrder_Load(object sender, EventArgs e)
        {
            try
            {
                txtExchangeRate.Text = AppContext.ExchangeRate.ExchangeValue.ToString("N2");

                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                IList objList = _ProductService.GetProductUnits();
                UnitID.DisplayMember = ProductUnit.CONST_UNIT_NAME;
                UnitID.ValueMember = ProductUnit.CONST_UNIT_ID;
                UnitID.DataSource = objList;

                objList = _ProductService.GetProducts();
                cbbProduct.DataSource = objList;
                cbbProduct.DisplayMember = Product.CONST_PRODUCT_DISPLAY_NAME;
                cbbProduct.ValueMember = Product.CONST_PRODUCT_ID;

                InitializeSaleItemList();

                objList = _ProductService.GetAvailableProductsDetail();
                cbbProductAvailable.DataSource = objList;
                if (objList.Count != 0)
                {
                    cbbProductAvailable.DisplayMember = PurchaseItem.CONST_BAR_CODE_VALUE;
                    cbbProductAvailable.ValueMember = PurchaseItem.CONST_PURCHASE_ITEM_ID;
                }

                SetPurchasedAmounts();
                setFocusToScanHandler();
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
            lblHeader.Text = "SalesOrder management";
            cmd1.Enabled = false;
        }

        private void InitializeSaleItemList()
        {
            if (_SaleItemBindingList == null)
                _SaleItemBindingList = new BindingList<SaleItem>();

            dgvSaleItem.DataSource = _SaleItemBindingList;
            if (dgvSaleItem != null)
            {
                dgvSaleItem.Columns["Product_Name"].DisplayIndex = 0;
                dgvSaleItem.Columns["BarCodeValue"].DisplayIndex = 1;
                dgvSaleItem.Columns["UnitID"].DisplayIndex = 2;
                dgvSaleItem.Columns["QtyOutStr"].DisplayIndex = 3;
                dgvSaleItem.Columns["UnitPriceOut"].DisplayIndex = 4;
                dgvSaleItem.Columns["SubTotal"].DisplayIndex = 5;

                dgvSaleItem.Columns.Remove("FKProduct");
                dgvSaleItem.Columns.Remove("FKSaleOrder");
            }
        }

        private void dgvSaleItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        private void setFocusToScanHandler()
        {
            if (txtProductScanned.CanFocus)
                txtProductScanned.Focus();

            txtProductScanned.Text = "";
            cbbProductAvailable.SelectedIndex = -1;

            if (dgvSaleItem.CurrentCell != null)
                dgvSaleItem.CurrentCell.Selected = false;
        }

        private void cbbProductAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbbProductAvailable.DisplayMember != "") && (cbbProductAvailable.ValueMember != ""))
            {
                if (cbbProductAvailable.SelectedIndex == -1)
                    return;

                try
                {
                    var purchaseItem = (PurchaseItem) cbbProductAvailable.SelectedItem;

                    if (purchaseItem == null)
                        return;

                    if (_SaleItemBindingList == null)
                        return;

                    bool foundFlag = false;

                    //Short list
                    foreach (SaleItem saleItem in _SaleItemBindingList)
                    {
                        if (purchaseItem.ProductID != saleItem.ProductID)
                            continue;

                        foundFlag = true;
                        saleItem.QtyOut += 1;
                        saleItem.QtyOutStr = saleItem.QtyOut.ToString();
                        saleItem.SubTotal = float.Parse(Math.Round(saleItem.QtyOut*saleItem.UnitPriceOut, 2).ToString());
                    }

                    if (!foundFlag)
                    {
                        cbbProduct.SelectedValue = purchaseItem.ProductID;
                        SaleItem saleItemShort = CreateSaleItem(purchaseItem);
                        for (int itemIndex = 0; itemIndex < _SaleItemBindingList.Count; itemIndex ++)
                        {
                            if (_SaleItemBindingList[itemIndex].ProductID == 0)
                            {
                                _SaleItemBindingList.RemoveAt(itemIndex);
                                break;
                            }
                        }
                        _SaleItemBindingList.Add(saleItemShort);
                    }

                    SetPurchasedAmounts();
                    dgvSaleItem.Refresh();
                    //dgvSaleItem.CurrentCell.Selected = false;
                    dgvSaleItem.Enabled = true;
                    setFocusToScanHandler();
                }
                catch (Exception exception)
                {
                    MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
                }
            }
        }

        private void dgvSaleItem_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetSaleItemModifiedStatus(false);
            setFocusToScanHandler();
        }

        private void dgvSaleItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
        }

        private void dgvSaleItem_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModifiedSaleItem)
                return;

            if ((dgvSaleItem.Rows[e.RowIndex].Cells["BarCodeValue"].Value == null) ||
                (dgvSaleItem.Rows[e.RowIndex].Cells["ProductID"].Value == null) ||
                (dgvSaleItem.Rows[e.RowIndex].Cells["UnitID"].Value == null) ||
                (dgvSaleItem.Rows[e.RowIndex].Cells["QtyOutStr"].Value == null) ||
                (dgvSaleItem.Rows[e.RowIndex].Cells["UnitPriceOut"].Value == null))
                e.Cancel = true;

            if (Int32.Parse(dgvSaleItem.Rows[e.RowIndex].Cells["ProductID"].Value.ToString()) == 0)
                e.Cancel = true;

            if (Int32.Parse(dgvSaleItem.Rows[e.RowIndex].Cells["UnitID"].Value.ToString()) == 0)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                SaleItem saleItem = _SaleItemBindingList[e.RowIndex];
                saleItem.BarCodeValue = dgvSaleItem.Rows[e.RowIndex].Cells["BarCodeValue"].Value.ToString();
                saleItem.QtyOutStr = dgvSaleItem.Rows[e.RowIndex].Cells["QtyOutStr"].Value.ToString();
                int seperatorIndex = saleItem.QtyOutStr.IndexOf("/");
                if (seperatorIndex != -1)
                {
                    float firstOperand =
                        float.Parse(
                            saleItem.QtyOutStr.Substring(
                                0,
                                seperatorIndex));

                    float secondOperand =
                        float.Parse(
                            saleItem.QtyOutStr.Substring(
                                seperatorIndex + 1,
                                saleItem.QtyOutStr.Length - seperatorIndex - 1));

                    saleItem.QtyOut = firstOperand/secondOperand;
                }
                else
                    saleItem.QtyOut = float.Parse(saleItem.QtyOutStr);

                saleItem.ProductID = Int32.Parse(dgvSaleItem.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());
                saleItem.UnitID = Int32.Parse(dgvSaleItem.Rows[e.RowIndex].Cells["UnitID"].Value.ToString());
                saleItem.UnitPriceIn = float.Parse(dgvSaleItem.Rows[e.RowIndex].Cells["UnitPriceIn"].Value.ToString());
                saleItem.UnitPriceOut = float.Parse(dgvSaleItem.Rows[e.RowIndex].Cells["UnitPriceOut"].Value.ToString());
                saleItem.SubTotal = float.Parse(Math.Round(saleItem.QtyOut*saleItem.UnitPriceOut, 2).ToString());

                if (dgvSaleItem.Rows[e.RowIndex].Cells["ProductID"].Value is DBNull)
                {
                    saleItem.OrderID = _SaleItemBindingList.Count;
                    _SaleItemBindingList.Add(saleItem);
                }
                else
                    saleItem.OrderID = Int32.Parse(dgvSaleItem.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());

                SetPurchasedAmounts();
                dgvSaleItem.Refresh();
                setFocusToScanHandler();
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void SetPurchasedAmounts()
        {
            float exchangeRate = float.Parse(txtExchangeRate.Text);
            _TotalAmountInUsd = 0;

            foreach (SaleItem item in _SaleItemBindingList)
                _TotalAmountInUsd += item.QtyOut*item.UnitPriceOut;

            _TotalAmountInUsd = float.Parse(Math.Round(_TotalAmountInUsd, 2).ToString());

            txtAmountTotalDollar.Text = _TotalAmountInUsd.ToString("N2");
            txtAmountTotalRiel.Text = (exchangeRate*_TotalAmountInUsd).ToString("N2");
            if (_SaleOrder == null)
                return;

            txtSONumber.Text = _SaleOrder.SaleOrderNumber;
            txtPaidAmount.Text = Math.Round(_SaleOrder.AmountPaid, 2).ToString("N2");
            txtPaidAmountRiel.Text = Math.Round(_SaleOrder.AmountPaid*exchangeRate, 2).ToString("N2");
            txtReturnAmount.Text = Math.Round(_SaleOrder.AmountReturn, 2).ToString("N2");
            txtReturnAmountRiel.Text = Math.Round(_SaleOrder.AmountReturn*exchangeRate, 2).ToString("N2");
        }

        private void FrmSaleOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        //Abort sale
                        if (dgvSaleItem.SelectedCells.Count != 0)
                        {
                            setFocusToScanHandler();
                            return;
                        }

                        RemoveItemSold();
                        break;
                    case Keys.F1:
                        //Record sale with printing invoice
                        if (!_PritFlag)
                            SaleRecording(true);
                        else
                            InvoicePrinting();
                        break;
                    case Keys.F2:
                        //New sale
                        PreSale(true);
                        break;
                    case Keys.F3:
                        //Previous
                        RetrieveSaleOrder("-");
                        break;
                    case Keys.F4:
                        //Next
                        RetrieveSaleOrder("+");
                        break;
                    case Keys.F5:
                        //Record sale without printing invoice
                        if (!_PritFlag)
                            SaleRecording(false);
                        break;
                    case Keys.F6:
                        //Modify purchased qty
                        ModifyPurchasedQty();
                        break;
                    case Keys.F10:
                        if (_PritFlag)
                        {
                            MessageBox.Show("The option requested is currently unavailble");
                            return;
                        }

                        if (dgvSaleItem.CurrentRow != null)
                            dgvSaleItem.CurrentRow.Selected = false;

                        using (var frmProductAvailable = new FrmProductAvailable())
                        {
                            if (frmProductAvailable.ShowDialog(this) == DialogResult.Cancel)
                                return;

                            SaleItemFetching(frmProductAvailable.SelctedProductID);
                        }
                        break;
                    case Keys.Return:
                        if (txtProductScanned.Text == null)
                            return;

                        if (txtProductScanned.Text.Length == 0)
                            return;

                        int proSelectedIndex = cbbProductAvailable.FindStringExact(txtProductScanned.Text);
                        if (proSelectedIndex != -1)
                            cbbProductAvailable.SelectedIndex = proSelectedIndex;
                        else
                        {
                            txtProductScanned.Text = "";
                            MessageBoxHandler.InformMessage("Operation.Request.Product.NotFound");
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void PreSale(bool clearFlag)
        {
            _PritFlag = false;

            //Reset current total amount
            _TotalAmountInUsd = 0;
            txtSONumber.Text = "";
            txtAmountTotalRiel.Text = "0.00";
            txtAmountTotalDollar.Text = "0.00";
            txtPaidAmount.Text = "0.00";
            txtPaidAmountRiel.Text = "0.00";
            txtReturnAmount.Text = "0.00";
            txtReturnAmountRiel.Text = "0.00";

            SetSaleItemModifiedStatus(false);
            //Clear data
            if (clearFlag)
                _SaleItemBindingList.Clear();

            if (txtProductScanned.CanFocus)
                txtProductScanned.Focus();

            IList objList = _ProductService.GetAvailableProductsDetail();
            cbbProductAvailable.DisplayMember = "";
            cbbProductAvailable.ValueMember = "";
            cbbProductAvailable.DataSource = objList;
            cbbProductAvailable.SelectedIndex = -1;
            if (objList.Count != 0)
            {
                cbbProductAvailable.DisplayMember = PurchaseItem.CONST_BAR_CODE_VALUE;
                cbbProductAvailable.ValueMember = PurchaseItem.CONST_PURCHASE_ITEM_ID;
            }

            dgvSaleItem.Enabled = false;
        }

        private SaleItem CreateSaleItem(PurchaseItem purchaseItem)
        {
            var saleItem =
                new SaleItem
                    {
                        BarCodeValue = purchaseItem.BarCodeValue,
                        ProductName = ((Product) cbbProduct.SelectedItem).ProductName,
                        FKProduct = ((Product) cbbProduct.SelectedItem),
                        OrderID = (_SaleItemBindingList.Count + 1),
                        ProductID = purchaseItem.ProductID,
                        QtyOut = 1
                    };

            saleItem.QtyOutStr = saleItem.QtyOut.ToString();
            saleItem.UnitID = purchaseItem.ProductUnitID;
            saleItem.UnitPriceIn = saleItem.FKProduct.UnitPriceIn;
            saleItem.UnitPriceOut = saleItem.FKProduct.UnitPriceOut;
            saleItem.SubTotal = saleItem.QtyOut*saleItem.UnitPriceOut;
            cbbProduct.SelectedIndex = -1;

            return saleItem;
        }

        private void dgvSaleItem_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dgvSaleItem_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            SetSaleItemModifiedStatus(false);
        }

        private void SetSaleItemModifiedStatus(bool modifyStatus)
        {
            _IsModifiedSaleItem = modifyStatus;
        }

        private void dgvSaleItem_Leave(object sender, EventArgs e)
        {
            if (dgvSaleItem.CurrentRow == null)
                return;

            if (dgvSaleItem.CurrentRow.IsNewRow)
                return;

            if ((dgvSaleItem.CurrentRow.Cells["ProductID"].Value is DBNull) ||
                (dgvSaleItem.CurrentRow.Cells["UnitID"].Value is DBNull) ||
                (dgvSaleItem.CurrentRow.Cells["BarCodeValue"].Value is DBNull) ||
                (dgvSaleItem.CurrentRow.Cells["QtyOut"].Value is DBNull) ||
                (dgvSaleItem.CurrentRow.Cells["UnitPriceOut"].Value is DBNull))
                SetSaleItemModifiedStatus(false);
            else if (Int32.Parse(dgvSaleItem.CurrentRow.Cells["ProductID"].Value.ToString()) == 0)
                SetSaleItemModifiedStatus(false);
        }

        private void dgvSaleItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetSaleItemModifiedStatus(true);
        }

        private void SaleItemFetching(int productID)
        {
            var availableProduct = (IList) cbbProductAvailable.DataSource;
            cbbProductAvailable.SelectedIndex = -1;
            foreach (PurchaseItem purchaseItem in availableProduct)
            {
                if (purchaseItem.ProductID != productID)
                    continue;

                cbbProductAvailable.SelectedValue = purchaseItem.PurchaseItemID;
                break;
            }
        }

        private void InvoicePrinting()
        {
            var invoicePrintHandler =
                new InvoicePrintHandler
                    {
                        InvoiceNumber = _SaleItemBindingList[0].FKSaleOrder.SaleOrderNumber,
                        Cashier = UserContext.User.UserName,
                        PrintDate = _SaleOrder.DateOut.ToString(),
                        Counter =
                            (UserContext.Counter == null
                                 ? string.Empty
                                 : UserContext.Counter.CounterName),
                        AmountSold =
                            Math.Round(_SaleItemBindingList[0].FKSaleOrder.AmountSold, 2).ToString(),
                        AmountPaid =
                            Math.Round((_SaleItemBindingList[0].FKSaleOrder).AmountPaid, 2).ToString(),
                        AmountReturn =
                            Math.Round(_SaleItemBindingList[0].FKSaleOrder.AmountReturn, 2).ToString(),
                        BindingListObj = _SaleItemBindingList
                    };
            //invoicePrintHandler.PrintDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            invoicePrintHandler.InializeRetailInvoicePrinting();

            //Printed
            _PritFlag = true;
        }

        private void EmptyInvoicePrinting()
        {
            //Print
            var invoicePrintHandler = new InvoicePrintHandler();
            invoicePrintHandler.InializeEmptyInvoicePrinting();

            //Printed
            _PritFlag = true;
        }

        private void SaleRecording(bool printInvoice)
        {
            if (_SaleOrderService == null)
                _SaleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();

            if (_SaleItemBindingList.Count == 0)
                return;

            using (var frmPayment = new FrmPayment())
            {
                frmPayment.TotalAmountInUsd = _TotalAmountInUsd;

                if (frmPayment.ShowDialog(this) == DialogResult.Cancel)
                    return;

                float exchangeRate = float.Parse(txtExchangeRate.Text);
                txtPaidAmount.Text = Math.Round(frmPayment.AmountPaidInUsd, 2).ToString();
                txtPaidAmountRiel.Text = Math.Round(frmPayment.AmountPaidInUsd*exchangeRate, 2).ToString();
                txtReturnAmount.Text = frmPayment.AmountReturn;
                txtReturnAmountRiel.Text = Math.Round(float.Parse(frmPayment.AmountReturn)*exchangeRate, 2).ToString();

                _SaleOrder =
                    _SaleOrderService.RecordSaleOrder(
                        _SaleItemBindingList,
                        _TotalAmountInUsd,
                        frmPayment.AmountPaidInUsd);

                if (_SaleOrder == null)
                    return;

                //Print invoice
                if (printInvoice)
                    InvoicePrinting();
                else
                    EmptyInvoicePrinting();
            }
        }

        private void dgvSaleItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null)
                return;

            if ((e.ColumnIndex == 7) || (e.ColumnIndex == 8))
            {
                dgvSaleItem_RowValidating(sender, new DataGridViewCellCancelEventArgs(e.ColumnIndex, e.RowIndex));
            }
            setFocusToScanHandler();
        }

        private void RetrieveSaleOrder(string criteria)
        {
            if (_SaleOrderService == null)
                _SaleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();

            _SaleOrder = _SaleOrder == null
                             ? _SaleOrderService.GetSaleOrder(0, criteria)
                             : _SaleOrderService.GetSaleOrder(_SaleOrder.SaleOrderID, criteria);

            if (_SaleOrder == null)
                return;

            IList saleItemsList = _SaleOrderService.GetSaleItems(_SaleOrder.SaleOrderID);
            if (saleItemsList == null)
                return;

            _SaleItemBindingList.Clear();
            foreach (SaleItem saleItem in saleItemsList)
            {
                cbbProduct.SelectedValue = saleItem.ProductID;
                if (cbbProduct.SelectedValue != null)
                    saleItem.ProductName = ((Product) cbbProduct.SelectedItem).ProductName;
                _SaleItemBindingList.Add(saleItem);
            }

            SetPurchasedAmounts();
            setFocusToScanHandler();
            _PritFlag = true;
        }

        private void RemoveItemSold()
        {
            if (_PritFlag)
                PreSale(true);

            if (_SaleItemBindingList.Count == 0)
                PreSale(true);
            else
            {
                _SaleItemBindingList.RemoveAt(_SaleItemBindingList.Count - 1);
                SetPurchasedAmounts();
            }
        }

        private void ModifyPurchasedQty()
        {
            if (_SaleItemBindingList == null)
                return;

            if (_SaleItemBindingList.Count == 0)
                return;

            using (var frmQtyAdjustment = new FrmQtyAdjustment())
            {
                frmQtyAdjustment.PurchasedQtyStr =
                    _SaleItemBindingList[_SaleItemBindingList.Count - 1].QtyOutStr;
                frmQtyAdjustment.PurchasedQty =
                    float.Parse(_SaleItemBindingList[_SaleItemBindingList.Count - 1].QtyOut.ToString());
                if (frmQtyAdjustment.ShowDialog(this) == DialogResult.Cancel)
                    return;

                _SaleItemBindingList[_SaleItemBindingList.Count - 1].QtyOutStr =
                    frmQtyAdjustment.PurchasedQtyStr;
                _SaleItemBindingList[_SaleItemBindingList.Count - 1].QtyOut =
                    frmQtyAdjustment.PurchasedQty;
                _SaleItemBindingList[_SaleItemBindingList.Count - 1].SubTotal =
                    frmQtyAdjustment.PurchasedQty*
                    _SaleItemBindingList[_SaleItemBindingList.Count - 1].UnitPriceOut;

                SetPurchasedAmounts();
                dgvSaleItem.Refresh();
                setFocusToScanHandler();
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbSaleInfo = new System.Windows.Forms.GroupBox();
            this.lblReturnAmountRiel = new System.Windows.Forms.Label();
            this.txtReturnAmountRiel = new System.Windows.Forms.TextBox();
            this.lblPaidAmountRiel = new System.Windows.Forms.Label();
            this.txtPaidAmountRiel = new System.Windows.Forms.TextBox();
            this.lblSONumber = new System.Windows.Forms.Label();
            this.txtSONumber = new System.Windows.Forms.TextBox();
            this.lblReturnAmount = new System.Windows.Forms.Label();
            this.txtReturnAmount = new System.Windows.Forms.TextBox();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.cbbProduct = new System.Windows.Forms.ComboBox();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.lblAmountTotalRiel = new System.Windows.Forms.Label();
            this.txtAmountTotalRiel = new System.Windows.Forms.TextBox();
            this.lblAmountTotalDollar = new System.Windows.Forms.Label();
            this.txtAmountTotalDollar = new System.Windows.Forms.TextBox();
            this.grbLine_2 = new System.Windows.Forms.GroupBox();
            this.cbbProductAvailable = new System.Windows.Forms.ComboBox();
            this.dgvSaleItem = new System.Windows.Forms.DataGridView();
            this.txtProductScanned = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCodeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyOutStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbSaleInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvSaleItem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grbSaleInfo);
            this.pnlBody.Font = new System.Drawing.Font("Khmer OS", 8.25F, System.Drawing.FontStyle.Regular,
                                                        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            // 
            // grbSaleInfo
            // 
            this.grbSaleInfo.Controls.Add(this.lblReturnAmountRiel);
            this.grbSaleInfo.Controls.Add(this.txtReturnAmountRiel);
            this.grbSaleInfo.Controls.Add(this.lblPaidAmountRiel);
            this.grbSaleInfo.Controls.Add(this.txtPaidAmountRiel);
            this.grbSaleInfo.Controls.Add(this.lblSONumber);
            this.grbSaleInfo.Controls.Add(this.txtSONumber);
            this.grbSaleInfo.Controls.Add(this.lblReturnAmount);
            this.grbSaleInfo.Controls.Add(this.txtReturnAmount);
            this.grbSaleInfo.Controls.Add(this.lblPaidAmount);
            this.grbSaleInfo.Controls.Add(this.txtPaidAmount);
            this.grbSaleInfo.Controls.Add(this.cbbProduct);
            this.grbSaleInfo.Controls.Add(this.lblExchangeRate);
            this.grbSaleInfo.Controls.Add(this.txtExchangeRate);
            this.grbSaleInfo.Controls.Add(this.lblAmountTotalRiel);
            this.grbSaleInfo.Controls.Add(this.txtAmountTotalRiel);
            this.grbSaleInfo.Controls.Add(this.lblAmountTotalDollar);
            this.grbSaleInfo.Controls.Add(this.txtAmountTotalDollar);
            this.grbSaleInfo.Controls.Add(this.grbLine_2);
            this.grbSaleInfo.Controls.Add(this.cbbProductAvailable);
            this.grbSaleInfo.Controls.Add(this.dgvSaleItem);
            this.grbSaleInfo.Controls.Add(this.txtProductScanned);
            this.grbSaleInfo.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.grbSaleInfo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grbSaleInfo.Location = new System.Drawing.Point(14, 3);
            this.grbSaleInfo.Name = "grbSaleInfo";
            this.grbSaleInfo.Size = new System.Drawing.Size(997, 603);
            this.grbSaleInfo.TabIndex = 1;
            this.grbSaleInfo.TabStop = false;
            this.grbSaleInfo.Text = "ពត៍មានអំពីការលក់";
            // 
            // lblReturnAmountRiel
            // 
            this.lblReturnAmountRiel.AutoSize = true;
            this.lblReturnAmountRiel.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                    System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblReturnAmountRiel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblReturnAmountRiel.Location = new System.Drawing.Point(677, 564);
            this.lblReturnAmountRiel.Name = "lblReturnAmountRiel";
            this.lblReturnAmountRiel.Size = new System.Drawing.Size(119, 27);
            this.lblReturnAmountRiel.TabIndex = 104;
            this.lblReturnAmountRiel.Text = "ទឹកប្រាក់អាប់ (R)";
            // 
            // txtReturnAmountRiel
            // 
            this.txtReturnAmountRiel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReturnAmountRiel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnAmountRiel.Enabled = false;
            this.txtReturnAmountRiel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                    System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtReturnAmountRiel.Location = new System.Drawing.Point(807, 564);
            this.txtReturnAmountRiel.Name = "txtReturnAmountRiel";
            this.txtReturnAmountRiel.ReadOnly = true;
            this.txtReturnAmountRiel.Size = new System.Drawing.Size(176, 23);
            this.txtReturnAmountRiel.TabIndex = 103;
            this.txtReturnAmountRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPaidAmountRiel
            // 
            this.lblPaidAmountRiel.AutoSize = true;
            this.lblPaidAmountRiel.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPaidAmountRiel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPaidAmountRiel.Location = new System.Drawing.Point(342, 565);
            this.lblPaidAmountRiel.Name = "lblPaidAmountRiel";
            this.lblPaidAmountRiel.Size = new System.Drawing.Size(130, 27);
            this.lblPaidAmountRiel.TabIndex = 102;
            this.lblPaidAmountRiel.Text = "ទឹកប្រាក់ទទួល (R)";
            // 
            // txtPaidAmountRiel
            // 
            this.txtPaidAmountRiel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPaidAmountRiel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaidAmountRiel.Enabled = false;
            this.txtPaidAmountRiel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPaidAmountRiel.Location = new System.Drawing.Point(472, 564);
            this.txtPaidAmountRiel.Name = "txtPaidAmountRiel";
            this.txtPaidAmountRiel.ReadOnly = true;
            this.txtPaidAmountRiel.Size = new System.Drawing.Size(176, 23);
            this.txtPaidAmountRiel.TabIndex = 101;
            this.txtPaidAmountRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSONumber
            // 
            this.lblSONumber.AutoSize = true;
            this.lblSONumber.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblSONumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSONumber.Location = new System.Drawing.Point(9, 29);
            this.lblSONumber.Name = "lblSONumber";
            this.lblSONumber.Size = new System.Drawing.Size(106, 27);
            this.lblSONumber.TabIndex = 100;
            this.lblSONumber.Text = "លេខវិក័យប័ត្រ";
            // 
            // txtSONumber
            // 
            this.txtSONumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSONumber.Enabled = false;
            this.txtSONumber.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtSONumber.Location = new System.Drawing.Point(164, 29);
            this.txtSONumber.Name = "txtSONumber";
            this.txtSONumber.ReadOnly = true;
            this.txtSONumber.Size = new System.Drawing.Size(176, 23);
            this.txtSONumber.TabIndex = 99;
            this.txtSONumber.TabStop = false;
            this.txtSONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReturnAmount
            // 
            this.lblReturnAmount.AutoSize = true;
            this.lblReturnAmount.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblReturnAmount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblReturnAmount.Location = new System.Drawing.Point(677, 535);
            this.lblReturnAmount.Name = "lblReturnAmount";
            this.lblReturnAmount.Size = new System.Drawing.Size(117, 27);
            this.lblReturnAmount.TabIndex = 98;
            this.lblReturnAmount.Text = "ទឹកប្រាក់អាប់ ($)";
            // 
            // txtReturnAmount
            // 
            this.txtReturnAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReturnAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnAmount.Enabled = false;
            this.txtReturnAmount.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtReturnAmount.Location = new System.Drawing.Point(807, 535);
            this.txtReturnAmount.Name = "txtReturnAmount";
            this.txtReturnAmount.ReadOnly = true;
            this.txtReturnAmount.Size = new System.Drawing.Size(176, 23);
            this.txtReturnAmount.TabIndex = 97;
            this.txtReturnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPaidAmount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPaidAmount.Location = new System.Drawing.Point(342, 535);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(128, 27);
            this.lblPaidAmount.TabIndex = 96;
            this.lblPaidAmount.Text = "ទឹកប្រាក់ទទួល ($)";
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaidAmount.Enabled = false;
            this.txtPaidAmount.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPaidAmount.Location = new System.Drawing.Point(472, 535);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.ReadOnly = true;
            this.txtPaidAmount.Size = new System.Drawing.Size(176, 23);
            this.txtPaidAmount.TabIndex = 95;
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbbProduct
            // 
            this.cbbProduct.FormattingEnabled = true;
            this.cbbProduct.Location = new System.Drawing.Point(647, 75);
            this.cbbProduct.Name = "cbbProduct";
            this.cbbProduct.Size = new System.Drawing.Size(165, 40);
            this.cbbProduct.TabIndex = 94;
            this.cbbProduct.Visible = false;
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblExchangeRate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblExchangeRate.Location = new System.Drawing.Point(356, 29);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(151, 27);
            this.lblExchangeRate.TabIndex = 93;
            this.lblExchangeRate.Text = "អាត្រាប្តូរប្រាក់ $ ទៅ ៛";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeRate.Enabled = false;
            this.txtExchangeRate.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtExchangeRate.Location = new System.Drawing.Point(511, 29);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.ReadOnly = true;
            this.txtExchangeRate.Size = new System.Drawing.Size(176, 23);
            this.txtExchangeRate.TabIndex = 92;
            this.txtExchangeRate.TabStop = false;
            this.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountTotalRiel
            // 
            this.lblAmountTotalRiel.AutoSize = true;
            this.lblAmountTotalRiel.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                   System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblAmountTotalRiel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmountTotalRiel.Location = new System.Drawing.Point(10, 565);
            this.lblAmountTotalRiel.Name = "lblAmountTotalRiel";
            this.lblAmountTotalRiel.Size = new System.Drawing.Size(121, 27);
            this.lblAmountTotalRiel.TabIndex = 91;
            this.lblAmountTotalRiel.Text = "ទឹកប្រាក់សរុប (៛)";
            // 
            // txtAmountTotalRiel
            // 
            this.txtAmountTotalRiel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAmountTotalRiel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountTotalRiel.Enabled = false;
            this.txtAmountTotalRiel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                   System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtAmountTotalRiel.Location = new System.Drawing.Point(135, 565);
            this.txtAmountTotalRiel.Name = "txtAmountTotalRiel";
            this.txtAmountTotalRiel.ReadOnly = true;
            this.txtAmountTotalRiel.Size = new System.Drawing.Size(176, 23);
            this.txtAmountTotalRiel.TabIndex = 90;
            this.txtAmountTotalRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountTotalDollar
            // 
            this.lblAmountTotalDollar.AutoSize = true;
            this.lblAmountTotalDollar.Font = new System.Drawing.Font("Khmer OS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                     System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblAmountTotalDollar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAmountTotalDollar.Location = new System.Drawing.Point(9, 535);
            this.lblAmountTotalDollar.Name = "lblAmountTotalDollar";
            this.lblAmountTotalDollar.Size = new System.Drawing.Size(123, 27);
            this.lblAmountTotalDollar.TabIndex = 85;
            this.lblAmountTotalDollar.Text = "ទឹកប្រាក់សរុប ($)";
            // 
            // txtAmountTotalDollar
            // 
            this.txtAmountTotalDollar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAmountTotalDollar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountTotalDollar.Enabled = false;
            this.txtAmountTotalDollar.Font = new System.Drawing.Font("Trebuchet MS", 9.75F,
                                                                     System.Drawing.FontStyle.Bold,
                                                                     System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtAmountTotalDollar.Location = new System.Drawing.Point(135, 535);
            this.txtAmountTotalDollar.Name = "txtAmountTotalDollar";
            this.txtAmountTotalDollar.ReadOnly = true;
            this.txtAmountTotalDollar.Size = new System.Drawing.Size(176, 23);
            this.txtAmountTotalDollar.TabIndex = 84;
            this.txtAmountTotalDollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbLine_2
            // 
            this.grbLine_2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_2.Location = new System.Drawing.Point(13, 521);
            this.grbLine_2.Name = "grbLine_2";
            this.grbLine_2.Size = new System.Drawing.Size(970, 2);
            this.grbLine_2.TabIndex = 83;
            this.grbLine_2.TabStop = false;
            // 
            // cbbProductAvailable
            // 
            this.cbbProductAvailable.FormattingEnabled = true;
            this.cbbProductAvailable.Location = new System.Drawing.Point(818, 75);
            this.cbbProductAvailable.Name = "cbbProductAvailable";
            this.cbbProductAvailable.Size = new System.Drawing.Size(165, 40);
            this.cbbProductAvailable.TabIndex = 1;
            this.cbbProductAvailable.Visible = false;
            this.cbbProductAvailable.SelectedIndexChanged +=
                new System.EventHandler(this.cbbProductAvailable_SelectedIndexChanged);
            // 
            // dgvSaleItem
            // 
            this.dgvSaleItem.AllowUserToAddRows = false;
            this.dgvSaleItem.AllowUserToDeleteRows = false;
            this.dgvSaleItem.AllowUserToResizeColumns = false;
            this.dgvSaleItem.AllowUserToResizeRows = false;
            this.dgvSaleItem.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSaleItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSaleItem.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                                                  {
                                                      this.UnitID,
                                                      this.ProductID,
                                                      this.Product_Name,
                                                      this.BarCodeValue,
                                                      this.SaleItemID,
                                                      this.QtyOutStr,
                                                      this.QtyOut,
                                                      this.UnitPriceIn,
                                                      this.UnitPriceOut,
                                                      this.OrderID,
                                                      this.SubTotal
                                                  });
            this.dgvSaleItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSaleItem.Location = new System.Drawing.Point(13, 59);
            this.dgvSaleItem.MultiSelect = false;
            this.dgvSaleItem.Name = "dgvSaleItem";
            this.dgvSaleItem.RowHeadersVisible = false;
            this.dgvSaleItem.RowHeadersWidth = 25;
            this.dgvSaleItem.RowHeadersWidthSizeMode =
                System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSaleItem.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSaleItem.RowTemplate.Height = 35;
            this.dgvSaleItem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSaleItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleItem.ShowCellToolTips = false;
            this.dgvSaleItem.Size = new System.Drawing.Size(970, 476);
            this.dgvSaleItem.TabIndex = 2;
            this.dgvSaleItem.TabStop = false;
            this.dgvSaleItem.VirtualMode = true;
            this.dgvSaleItem.CellValueChanged +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleItem_CellValueChanged);
            this.dgvSaleItem.CellBeginEdit +=
                new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSaleItem_CellBeginEdit);
            this.dgvSaleItem.RowValidating +=
                new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSaleItem_RowValidating);
            this.dgvSaleItem.CancelRowEdit +=
                new System.Windows.Forms.QuestionEventHandler(this.dgvSaleItem_CancelRowEdit);
            this.dgvSaleItem.Leave += new System.EventHandler(this.dgvSaleItem_Leave);
            this.dgvSaleItem.CellEndEdit +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleItem_CellEndEdit);
            this.dgvSaleItem.RowValidated +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleItem_RowValidated);
            this.dgvSaleItem.DataError +=
                new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSaleItem_DataError);
            this.dgvSaleItem.SelectionChanged += new System.EventHandler(this.dgvSaleItem_SelectionChanged);
            // 
            // txtProductScanned
            // 
            this.txtProductScanned.AcceptsTab = true;
            this.txtProductScanned.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (203)))),
                                                                             ((int) (((byte) (209)))),
                                                                             ((int) (((byte) (226)))));
            this.txtProductScanned.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductScanned.Location = new System.Drawing.Point(15, 78);
            this.txtProductScanned.Name = "txtProductScanned";
            this.txtProductScanned.Size = new System.Drawing.Size(200, 33);
            this.txtProductScanned.TabIndex = 0;
            this.txtProductScanned.TabStop = false;
            this.txtProductScanned.WordWrap = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SubTotal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle7.NullValue = "0.00";
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn9.HeaderText = "សរុប";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 110;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "OrderID";
            this.dataGridViewTextBoxColumn10.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "SubTotal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn11.HeaderText = "សរុប";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 110;
            // 
            // UnitID
            // 
            this.UnitID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitID.DataPropertyName = "UnitID";
            this.UnitID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.UnitID.HeaderText = "ឯកតា";
            this.UnitID.Name = "UnitID";
            this.UnitID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductID.Visible = false;
            this.ProductID.Width = 278;
            // 
            // Product_Name
            // 
            this.Product_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Product_Name.DataPropertyName = "ProductName";
            this.Product_Name.HeaderText = "ឈ្មោះផលិតផល";
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.ReadOnly = true;
            this.Product_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Product_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product_Name.Width = 338;
            // 
            // BarCodeValue
            // 
            this.BarCodeValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BarCodeValue.DataPropertyName = "BarCodeValue";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.BarCodeValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.BarCodeValue.HeaderText = "លេខបារកូដ";
            this.BarCodeValue.Name = "BarCodeValue";
            this.BarCodeValue.ReadOnly = true;
            this.BarCodeValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BarCodeValue.Width = 200;
            // 
            // SaleItemID
            // 
            this.SaleItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SaleItemID.DataPropertyName = "SaleItemID";
            this.SaleItemID.HeaderText = "SaleItemID";
            this.SaleItemID.Name = "SaleItemID";
            this.SaleItemID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SaleItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SaleItemID.Visible = false;
            // 
            // QtyOutStr
            // 
            this.QtyOutStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QtyOutStr.DataPropertyName = "QtyOutStr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.QtyOutStr.DefaultCellStyle = dataGridViewCellStyle3;
            this.QtyOutStr.HeaderText = "បរិមាណលក់";
            this.QtyOutStr.Name = "QtyOutStr";
            this.QtyOutStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QtyOutStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtyOutStr.Width = 110;
            // 
            // QtyOut
            // 
            this.QtyOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QtyOut.DataPropertyName = "QtyOut";
            this.QtyOut.HeaderText = "QtyOut";
            this.QtyOut.Name = "QtyOut";
            this.QtyOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QtyOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtyOut.Visible = false;
            // 
            // UnitPriceIn
            // 
            this.UnitPriceIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitPriceIn.DataPropertyName = "UnitPriceIn";
            this.UnitPriceIn.HeaderText = "UnitPriceIn";
            this.UnitPriceIn.Name = "UnitPriceIn";
            this.UnitPriceIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitPriceIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitPriceIn.Visible = false;
            // 
            // UnitPriceOut
            // 
            this.UnitPriceOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitPriceOut.DataPropertyName = "UnitPriceOut";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle4.Format = "N2";
            this.UnitPriceOut.DefaultCellStyle = dataGridViewCellStyle4;
            this.UnitPriceOut.HeaderText = "តំលៃឯកតា";
            this.UnitPriceOut.Name = "UnitPriceOut";
            this.UnitPriceOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitPriceOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitPriceOut.Width = 110;
            // 
            // OrderID
            // 
            this.OrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderID.DataPropertyName = "OrderID";
            this.OrderID.HeaderText = "OrderID";
            this.OrderID.Name = "OrderID";
            this.OrderID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderID.Visible = false;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SubTotal.DataPropertyName = "SubTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                                  System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.SubTotal.HeaderText = "សរុប";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SubTotal.Width = 110;
            // 
            // FrmSaleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmSaleOrder";
            this.Load += new System.EventHandler(this.FrmSaleOrder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaleOrder_KeyDown);
            this.pnlBody.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grbSaleInfo.ResumeLayout(false);
            this.grbSaleInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvSaleItem)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}