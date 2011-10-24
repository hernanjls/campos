using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EzPos.GUI;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Product;
using EzPos.Service.SaleOrder;
using EzPos.Utility;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlSale : UserControl
    {
        private CommonService _commonService;
        private CustomerService _customerService;
        private float _exchangeRate;
        private BindingList<Product> _productList;
        private ProductService _productService;
        private BindingList<SaleItem> _saleItemBindingList;
        private SaleOrder _saleOrder;
        private Deposit _deposit;
        private SaleOrderService _saleOrderService;
        private DepositService _depositService;
        private float _totalAmountInt;
        private bool _returnEnabled;
        private bool _depositEnabled;

        public CtrlSale()
        {
            InitializeComponent();
        }

        public ProductService ProductService
        {
            set { _productService = value; }
        }

        public CustomerService CustomerService
        {
            set { _customerService = value; }
        }

        public SaleOrderService SaleOrderService
        {
            set { _saleOrderService = value; }
        }

        public DepositService DepositService
        {
            set { _depositService = value; }
        }

        private void CtrlSale_Load(object sender, EventArgs e)
        {
            try
            {
                if (_commonService == null)
                    _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
                if (_productService == null)
                    _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
                if (_customerService == null)
                    _customerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
                if (_saleOrderService == null)
                    _saleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
                if (_depositService == null)
                    _depositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();

                if (!UserService.AllowToPerform(Resources.PermissionProductAdjustment))
                    btnProductAdjustment.Visible = false;

                //if (!UserService.AllowToPerform(Resources.PermissionViewSalesResultInfo))
                //{
                   // lblResultInfo.Visible = false;
                //}
                //Initialization
                _productList = new BindingList<Product>();
                cmbProduct.DataSource = _productList;
                cmbProduct.DisplayMember = Product.CONST_PRODUCT_CODE;
                cmbProduct.ValueMember = Product.CONST_PRODUCT_ID;
                cmbProduct.SelectedIndex = -1;

                if (AppContext.ExchangeRate != null)
                    _exchangeRate = AppContext.ExchangeRate.ExchangeValue;

                InitializeSaleItemList();
                ResetProductInfo();
                ScanFocusHandler();

                _depositEnabled = CommonService.IsIntegratedModule(Resources.ModDeposit);
                _saleItemBindingList.ListChanged += SaleItemBindingListChanged;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void CmbProductSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(cmbProduct.DisplayMember)) ||
                (String.IsNullOrEmpty(cmbProduct.ValueMember)) ||
                (cmbProduct.SelectedIndex == -1))
                return;

            try
            {
                var product = (Product) cmbProduct.SelectedItem;
                if (product == null)
                    return;

                if (product.QtyInStock <= 0)
                    return;

                SetProductInfo(product);

                var foundFlag = false;
                var selectedIndex = 0;
                dgvSaleItem.SelectionChanged -= DgvSaleItemSelectionChanged;
                foreach (var saleItem in _saleItemBindingList)
                {
                    if (product.ProductID == saleItem.ProductID)
                    {
                        foundFlag = true;
                        if (product.QtyInStock == saleItem.QtySold)
                            ScanFocusHandler();
                        else
                        {
                            saleItem.QtySold += 1;
                            saleItem.SubTotal = float.Parse(
                                (saleItem.QtySold*product.UnitPriceOut).ToString("N", AppContext.CultureInfo),
                                AppContext.CultureInfo);
                        }
                        break;
                    }
                    selectedIndex += 1;
                }

                if (!foundFlag)
                {
                    var saleItem =
                        CreateSaleItem(product, 1, product.DiscountPercentage);
                    _saleItemBindingList.Add(saleItem);
                }

                dgvSaleItem.Refresh();
                UpdateSelectedIndex(selectedIndex);
                dgvSaleItem.SelectionChanged += DgvSaleItemSelectionChanged;
                CalculateSale();
                ScanFocusHandler();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void SetProductInfo(Product product)
        {
            lblProductName.Text = product.ProductName + @" \ " + product.ColorStr;
            lblPrice.Text = Resources.ConstPrefixDollar + product.UnitPriceOut.ToString("N", AppContext.CultureInfo);
            lblReference.Text = product.ProductCode;
            if ((product.ProductPic == null) || (String.IsNullOrEmpty(product.PhotoPath)))
                ptbDisplay.Image = Resources.NoImage;
            else
            {
                var fileInfo = new FileInfo(product.PhotoPath);
                if (fileInfo.Exists)
                    ptbDisplay.ImageLocation = product.PhotoPath;
                else
                    ptbDisplay.Image = Resources.NoImage;
            }
        }

        private SaleItem CreateSaleItem(Product product, int qtySold, float discount)
        {
            var saleItem = 
                new SaleItem
                {
                    ProductName = product.ProductName,
                    ProductID = product.ProductID,
                    QtySold = qtySold,
                    UnitPriceIn = product.UnitPriceIn,
                    ProductDisplayName = 
                        string.IsNullOrEmpty(product.Description) ? 
                        product.ProductName + "\r" + product.ProductCode : 
                        product.Description + "\r" + product.ProductCode
                };
            
            if (!string.IsNullOrEmpty(product.ForeignCode))
                saleItem.ProductDisplayName += " (" + product.ForeignCode + ")";

            var unitPriceIn =
                float.Parse(Math.Round(product.UnitPriceIn, 3).ToString("N3", AppContext.CultureInfo),
                            AppContext.CultureInfo);

            var publicUnitPriceOut =
                unitPriceIn + ((unitPriceIn * product.ExtraPercentage) / 100);

            saleItem.UnitPriceOut =
                float.Parse(
                    publicUnitPriceOut.ToString("N", AppContext.CultureInfo),
                    AppContext.CultureInfo);            
            //publicUnitPriceOut =
            //    publicUnitPriceOut -
            //    ((publicUnitPriceOut * product.DiscountPercentage) / 100);
            publicUnitPriceOut =
                publicUnitPriceOut -
                ((publicUnitPriceOut * discount) / 100);

            if (publicUnitPriceOut == product.UnitPriceIn)
                publicUnitPriceOut = product.UnitPriceOut;

            //publicUnitPriceOut =
            //    float.Parse(Math.Round(publicUnitPriceOut, 0).ToString("N", AppContext.CultureInfo),
            //                AppContext.CultureInfo);
            publicUnitPriceOut =
                float.Parse(
                    publicUnitPriceOut.ToString("N", AppContext.CultureInfo),
                    AppContext.CultureInfo);

            //float.Parse(Math.Round(saleItem.PublicUPOut, 0).ToString("N", AppContext.CultureInfo),
            //            AppContext.CultureInfo);
            saleItem.PublicUPOut = publicUnitPriceOut;            
            saleItem.Discount = discount;
            saleItem.SubTotal =
                saleItem.QtySold * publicUnitPriceOut;

            if (string.IsNullOrEmpty(product.PhotoPath))
                saleItem.ProdPicture = Resources.NoImage;
            else
            {
                var fileInfo = new FileInfo(product.PhotoPath);
                saleItem.ProdPicture = fileInfo.Exists ? Image.FromFile(product.PhotoPath) : Resources.NoImage;
            }
            cmbProduct.SelectedIndex = -1;
            saleItem.FKProduct = product;
            return saleItem;
        }

        private void UpdateSelectedIndex(int selectedIndex)
        {
            if (_saleItemBindingList == null)
                ResetProductInfo();

            if (_saleItemBindingList != null)
            {
                if (_saleItemBindingList.Count == 0)
                    ResetProductInfo();

                if (selectedIndex < 0)
                {
                    if (_saleItemBindingList.Count == 1)
                    {
                        ResetProductInfo();
                        return;
                    }
                    selectedIndex = 0;
                }

                if (selectedIndex == _saleItemBindingList.Count)
                    return;
            }

            dgvSaleItem.Rows[selectedIndex].Selected = true;

            if (selectedIndex < dgvSaleItem.FirstDisplayedScrollingRowIndex)
                dgvSaleItem.FirstDisplayedScrollingRowIndex = selectedIndex;
            else if ((selectedIndex - dgvSaleItem.FirstDisplayedScrollingRowIndex) < 0)
                dgvSaleItem.FirstDisplayedScrollingRowIndex -= 1;
            else
            {
                if (selectedIndex >=
                    (dgvSaleItem.DisplayedRowCount(true) + dgvSaleItem.FirstDisplayedScrollingRowIndex - 1))
                {
                    if (_saleItemBindingList != null)
                        if ((selectedIndex - dgvSaleItem.DisplayedRowCount(true) + 2) >=
                            _saleItemBindingList.Count)
                            return;

                    dgvSaleItem.FirstDisplayedScrollingRowIndex =
                        selectedIndex - dgvSaleItem.DisplayedRowCount(true) + 2;
                }
            }
        }

        private void CalculateSale()
        {
            _totalAmountInt = 0;
            float totalPurchasedQty = 0;
            foreach (var saleItem in _saleItemBindingList)
            {
                var unitPriceIn =
                    float.Parse(Math.Round(saleItem.UnitPriceIn, 3).ToString("N3", AppContext.CultureInfo), AppContext.CultureInfo);
                //var unitPriceIn = saleItem.UnitPriceIn;

                //if (saleItem.FKProduct.ExtraPercentage == 0)
                //    unitPriceOut =
                //        saleItem.UnitPriceOut;
                //else
                //{
                var unitPriceOut =
                    unitPriceIn +
                    ((unitPriceIn * saleItem.FKProduct.ExtraPercentage) / 100);

                unitPriceOut =
                    unitPriceOut - ((unitPriceOut * saleItem.Discount) / 100);
                //}

                unitPriceOut =
                    float.Parse(Math.Round(unitPriceOut, 2).ToString("N3", AppContext.CultureInfo),
                                AppContext.CultureInfo);

                _totalAmountInt += saleItem.QtySold * unitPriceOut;
                totalPurchasedQty += saleItem.QtySold;
            }

            lblTotalAmountInt.Text = Resources.ConstPrefixDollar + _totalAmountInt.ToString("N", AppContext.CultureInfo);
            lblTotalAmountNat.Text = Resources.ConstPrefixRiel + (_totalAmountInt * _exchangeRate).ToString("N", AppContext.CultureInfo);
            if (_saleOrder != null)
            {
                var tmpTotalAmountInt = _totalAmountInt;
                tmpTotalAmountInt -= ((tmpTotalAmountInt*_saleOrder.Discount)/100);
                lblFinalAmount.Text = Resources.ConstPrefixDollar + tmpTotalAmountInt.ToString("N", AppContext.CultureInfo);
                lblAmountPaid.Text = Resources.ConstPrefixDollar + tmpTotalAmountInt.ToString("N", AppContext.CultureInfo);
                lblAmountReturn.Text = Resources.ConstAmountZeroDollarTwoDigits;
            }
            SetPurchasedInfo(totalPurchasedQty);
        }

        private void ScanFocusHandler()
        {
            txtHidden.Text = string.Empty;
            if (txtHidden.CanFocus)
                txtHidden.Focus();

            cmbProduct.SelectedIndex = -1;
        }

        private void InitializeSaleItemList()
        {
            if (_saleItemBindingList == null)
                _saleItemBindingList = new SaleItemBindingList<SaleItem>();

            AdjustColumOrder();
            dgvSaleItem.DataSource = _saleItemBindingList;
        }

        private void TxtHiddenKeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;

            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        CancelSale();
                        break;
                    case Keys.Delete:
                        if (_saleItemBindingList.Count == 0)
                            return;
                        UpdateSaleItem(Resources.OperationRequestDelete,
                                       dgvSaleItem.SelectedRows[0].Index);
                        break;
                    case Keys.Add:
                        if (!btnValid.Enabled)
                            return;

                        if (_saleItemBindingList.Count == 0)
                            return;
                        UpdateSaleItem(Resources.OperationRequestInsert,
                                       dgvSaleItem.SelectedRows[0].Index);
                        break;
                    case Keys.Subtract:
                        if (!btnValid.Enabled)
                            return;

                        if (_saleItemBindingList.Count == 0)
                            return;
                        UpdateSaleItem(Resources.OperationRequestUpdate,
                                       dgvSaleItem.SelectedRows[0].Index);
                        break;
                    case Keys.Up:
                        if (_saleItemBindingList.Count == 0)
                            return;
                        UpdateSelectedIndex(dgvSaleItem.SelectedRows[0].Index - 1);
                        break;
                    case Keys.Down:
                        if (_saleItemBindingList.Count == 0)
                            return;
                        UpdateSelectedIndex(dgvSaleItem.SelectedRows[0].Index + 1);
                        break;
                    case Keys.Return:
                        DoProductFetching(txtHidden.Text, true);
                        break;
                    case Keys.F1:
                        Visible = false;
                        using (var frmProductList = new FrmProductSearch())
                        {
                            if(frmProductList.ShowDialog(this) == DialogResult.OK)
                            {
                                var product = frmProductList.Product;
                                if(product != null)
                                {
                                    if (product.QtyInStock != 0)
                                    {
                                        _productList.Add(product);
                                        DoProductFetching(product.ProductCode, true);
                                    }
                                    else
                                    {
                                        txtHidden.Text = string.Empty;
                                        const string briefMsg = "អំពីផលិតផល";
                                        var detailMsg = Resources.MsgOperationRequestProductNotFound;
                                        using (var frmMessageBox = new FrmExtendedMessageBox())
                                        {
                                            frmMessageBox.BriefMsgStr = briefMsg;
                                            frmMessageBox.DetailMsgStr = detailMsg;
                                            frmMessageBox.IsCanceledOnly = true;
                                            frmMessageBox.ShowDialog(this);
                                        }                                        
                                    }
                                }
                            }
                            Visible = true;
                        }
                        break;
                    case Keys.F2:
                        if(dgvSaleItem.CurrentRow == null)
                            return;

                        var selectedIndex =
                            dgvSaleItem.SelectedRows[0].Index;
                        var saleItem = _saleItemBindingList[selectedIndex];
                        if (saleItem == null)
                            return;
                        
                        Visible = false;
                        using (var frmSaleQty = new FrmSaleQty())
                        {
                            frmSaleQty.SaleItem = saleItem;
                            if (frmSaleQty.ShowDialog(this) == DialogResult.OK)
                            {
                                saleItem = frmSaleQty.SaleItem;
                                _saleItemBindingList[selectedIndex] = saleItem;

                                var product = saleItem.FKProduct;
                                saleItem.Discount = product.DiscountPercentage;

                                var publicUnitPriceOut =
                                    product.UnitPriceIn + ((product.UnitPriceIn * product.ExtraPercentage) / 100);

                                publicUnitPriceOut =
                                    publicUnitPriceOut -
                                    ((publicUnitPriceOut * product.DiscountPercentage) / 100);

                                if (publicUnitPriceOut == product.UnitPriceIn)
                                    publicUnitPriceOut = product.UnitPriceOut;

                                publicUnitPriceOut =
                                    float.Parse(
                                        publicUnitPriceOut.ToString("N", AppContext.CultureInfo),
                                        AppContext.CultureInfo);
                                saleItem.PublicUPOut = publicUnitPriceOut;
                                saleItem.UnitPriceOut =
                                    product.UnitPriceIn +
                                    ((product.UnitPriceIn * product.ExtraPercentage) / 100);
                                saleItem.UnitPriceOut =
                                    float.Parse(
                                        saleItem.UnitPriceOut.ToString("N", AppContext.CultureInfo),
                                        AppContext.CultureInfo);
                                saleItem.SubTotal = saleItem.QtySold * publicUnitPriceOut;
                                dgvSaleItem.Refresh();
                                CalculateSale();
                            }

                            Visible = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void UpdateSaleItem(string requestType, int selectedIndex)
        {
            ScanFocusHandler();
            if (requestType == Resources.OperationRequestDelete)
            {
                UpdateSelectedIndex(selectedIndex - 1);
                _saleItemBindingList.RemoveAt(selectedIndex);
            }
            else
            {
                var saleItem = _saleItemBindingList[selectedIndex];
                if (requestType == Resources.OperationRequestInsert)
                {
                    if (_productList.Any(product => (product.ProductID == saleItem.ProductID) && (product.QtyInStock == saleItem.QtySold)))
                        return;

                    saleItem.QtySold += 1;
                }
                else
                {
                    if (saleItem.QtySold != 1)
                        saleItem.QtySold -= 1;
                }
                saleItem.SubTotal = saleItem.QtySold*saleItem.UnitPriceOut;
            }
            dgvSaleItem.Refresh();
            CalculateSale();
        }

        private void CancelSale()
        {
            _saleOrder = null;
            _saleItemBindingList.Clear();
            _returnEnabled = false;

            ResetProductInfo();
//            ResetProductPrice();
            ResetCustomerInfo();
            DoActivateControls(true);
            //ReturnHandler(_returnEnabled = false);
            ScanFocusHandler();
        }

        private void ResetProductInfo()
        {
            lblInvoiceNum.Text = string.Empty;
            lblProductName.Text = string.Empty;
            lblPrice.Text = string.Empty;
            lblReference.Text = string.Empty;
            ptbDisplay.Image = null;
            lblTotalAmountInt.Text = Resources.ConstAmountZeroDollarTwoDigits;
            lblTotalAmountNat.Text = Resources.ConstAmountZeroRielTwoDigits;
            lblFinalAmount.Text = Resources.ConstAmountZeroDollarTwoDigits;
            lblAmountPaid.Text = Resources.ConstAmountZeroDollarTwoDigits;
            lblAmountReturn.Text = Resources.ConstAmountZeroDollarTwoDigits;
            SetPurchasedInfo(0);
        }

        private void DgvSaleItemSelectionChanged(object sender, EventArgs e)
        {
            if (_saleItemBindingList == null)
                return;

            if (_saleItemBindingList.Count == 0)
                return;

            if (dgvSaleItem.CurrentRow != null)
            {
                if (_saleItemBindingList[dgvSaleItem.CurrentRow.Index].FKProduct != null)
                {
                    SetProductInfo(
                        _saleItemBindingList[dgvSaleItem.SelectedRows[0].Index].FKProduct);
                }
                else
                {
                    cmbProduct.SelectedIndexChanged -= CmbProductSelectedIndexChanged;
                    foreach (var product in
                        _productList.Where(product => product.ProductID == Int32.Parse(dgvSaleItem.Rows[dgvSaleItem.SelectedRows[0].Index].Cells["ProductID"].Value.ToString(), AppContext.CultureInfo)))
                    {
                        SetProductInfo(product);
                        cmbProduct.SelectedIndex = -1;
                        break;
                    }
                    cmbProduct.SelectedIndexChanged += CmbProductSelectedIndexChanged;
                }
            }

            ScanFocusHandler();
        }

        private void DgvSaleItemDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FrmExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            CancelSale();
        }

        private void BtnValidClick(object sender, EventArgs e)
        {
            ScanFocusHandler();
            if (_saleItemBindingList.Count == 0)
                return;

            try
            {
                if ((_returnEnabled) || (btnValid.Text.Equals(Resources.ConstSalePrint)))
                {
                    InvoicePrinting(
                        _saleOrder.FKCustomer,
                        _saleOrder.SaleOrderNumber,
                        (DateTime)_saleOrder.SaleOrderDate,
                        _saleOrder.Discount,
                        0,
                        _saleOrder.AmountPaidInt,
                        _saleOrder.AmountReturnInt,
                        false);                                        
                }
                else
                {
                    Visible = false;
                    using (var frmPayment = new FrmPayment())
                    {
                        frmPayment.CommonService = _commonService;
                        frmPayment.CustomerService = _customerService;
                        frmPayment.TotalAmountInt = _totalAmountInt;
                        if (frmPayment.ShowDialog(this) == DialogResult.OK)
                        {
                            Visible = true;
                            var discountPercentage = frmPayment.Customer.FKDiscountCard.DiscountPercentage;
                            _saleOrder = _saleOrderService.RecordSaleOrder(
                                _saleItemBindingList,
                                _totalAmountInt,
                                frmPayment.AmountPaidInt,
                                frmPayment.AmountPaidRiel,
                                frmPayment.AmountPaidInt - (_totalAmountInt - ((_totalAmountInt * discountPercentage) / 100)),
                                frmPayment.Customer,
                                false,
                                string.Empty,
                                frmPayment.Customer.FKDiscountCard.DiscountPercentage,
                                0,
                                false);

                            if (_saleOrder == null)
                                return;

                            DoActivateControls(false);
                            SetCustomerInfo(frmPayment.Customer);
                            SetInvoiceInfo(
                                _saleOrder.SaleOrderNumber,
                                _saleOrder.AmountSoldInt,
                                _saleOrder.AmountPaidInt,
                                _saleOrder.AmountPaidRiel,
                                _saleOrder.AmountReturnInt);
                            InvoicePrinting(
                                _saleOrder.FKCustomer,
                                _saleOrder.SaleOrderNumber,
                                (DateTime)_saleOrder.SaleOrderDate,
                                _saleOrder.Discount,
                                0,
                                _saleOrder.AmountPaidInt,
                                _saleOrder.AmountReturnInt,
                                false);

                            LocalStockHandler();

                            var frmThank = new FrmThank();
                            frmThank.ShowDialog(this);
                        }
                        Visible = true;
                    }                
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void InvoicePrinting(
            Customer customer, 
            string invoiceNumber, 
            DateTime invoiceDate, 
            float discountPercentage,
            float depositAmount,
            float paidAmount,
            float returnAmount,
            bool isDeposit)
        {
            bool issueReceipt;
            var issueReceiptStr = AppContext.IssueReceipt;
            bool.TryParse(issueReceiptStr, out issueReceipt);
            if(!issueReceipt)
                return;

            var receiptTemplate = AppContext.ReceiptTemplate;
            if (string.IsNullOrEmpty(receiptTemplate))
                receiptTemplate = Resources.ConstReceiptTemplate1;

            if (receiptTemplate.Equals(Resources.ConstReceiptTemplate1))
            {
                //Print
                double amountSold = paidAmount - returnAmount;
                //amountSold = amountSold/(1 - discountPercentage/100);

                var printReceipt = new PrintReceipt
                {
                    InvoiceNumber = invoiceNumber,
                    Cashier = AppContext.User.LogInName,
                    PrintDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm", AppContext.CultureInfo),
                    Counter = AppContext.Counter.CounterName,
                    CustomerInfo =
                        ((string.IsNullOrEmpty(customer.CustomerName)
                              ? string.Empty
                              : customer.CustomerName) +
                         (string.IsNullOrEmpty(customer.PhoneNumber)
                              ? string.Empty
                              : " | " + customer.PhoneNumber)),
                    AmountSold =
                        amountSold.ToString("N", AppContext.CultureInfo),
                    AmountPaid =
                        (paidAmount).ToString("N",
                                                           AppContext.
                                                               CultureInfo),
                    AmountReturn = returnAmount.ToString("N", AppContext.CultureInfo),
                    Discount = (discountPercentage + " %"),
                    //AmountSubTotal =
                    //    ((saleOrder.AmountSoldInt * 100) / (100 - discountPercentage)).ToString("N",
                    //                                                                        AppContext
                    //                                                                            .
                    //                                                                            CultureInfo),
                    AmountSubTotal =
                        (((paidAmount - returnAmount) * 100) / (100 - discountPercentage)).ToString("N",
                                                                                            AppContext
                                                                                                .
                                                                                                CultureInfo),
                    BindingListObj = _saleItemBindingList
                };

                printReceipt.InializeReceiptPrinting();                
                //var fileName = Resources.ConstReceiptExcelFile;
                //printReceipt.PrintReceiptHandler(
                //    Application.StartupPath + @"\" + fileName,
                //    string.Empty);                
            }
            else
            {
                var fileName = isDeposit ? Resources.ConstDepositExcelFile : Resources.ConstSaleExcelFile;

                //Print
                var printInvoice = new PrintInvoice();
                printInvoice.ExcelInvoicePrintingHandler(
                    AppContext.Counter.ReceiptPrinter,
                    Application.StartupPath + @"\" + fileName,
                    string.Empty,
                    customer.CustomerName,
                    customer.Address,
                    invoiceNumber,
                    invoiceDate,
                    discountPercentage,
                    depositAmount,
                    paidAmount,
                    _saleItemBindingList,
                    isDeposit);                
            }
        }

        private void DgvSaleItemCellClick(object sender, DataGridViewCellEventArgs e)
        {
            ScanFocusHandler();

            if (_saleItemBindingList == null)
                return;

            if (_saleItemBindingList.Count == 0)
                return;

            if (dgvSaleItem.CurrentCell.ColumnIndex == 0)
                UpdateSaleItem(Resources.OperationRequestDelete,
                               dgvSaleItem.SelectedRows[0].Index);
        }

        private void BtnDepositClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAddDeposit))
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

            ScanFocusHandler();           

            if (_saleItemBindingList.Count == 0)
                return;

            Visible = false;
            try
            {
                using (var frmPayment = new FrmPayment())
                {
                    frmPayment.CommonService = _commonService;
                    frmPayment.CustomerService = _customerService;
                    frmPayment.TotalAmountInt = _totalAmountInt;
                    frmPayment.IsDeposit = true;
                    if (frmPayment.ShowDialog(this) == DialogResult.OK)
                    {
                        Visible = true;
                        var depositItemList = _depositService.GetDepositItems(_saleItemBindingList);

                        _deposit = _depositService.RecordDeposit(
                            depositItemList,
                            _totalAmountInt,
                            frmPayment.AmountPaidInt,
                            frmPayment.AmountPaidRiel,
                            frmPayment.Customer,
                            string.Empty,
                            frmPayment.Customer.FKDiscountCard.DiscountPercentage,
                            false);

                        if (_deposit == null)
                            return;

                        DoActivateControls(false);
                        SetCustomerInfo(frmPayment.Customer);
                        SetInvoiceInfo(
                            _deposit.DepositNumber,
                            _deposit.AmountSoldInt,
                            _deposit.AmountPaidInt,
                            _deposit.AmountPaidRiel,
                            _deposit.AmountReturnInt);
                        InvoicePrinting(
                            _deposit.FKCustomer,
                            _deposit.DepositNumber,
                            (DateTime)_deposit.DepositDate,
                            _deposit.Discount,
                            _deposit.AmountPaidInt,
                            0,
                            0,
                            true);

                        LocalStockHandler();

                        var frmThank = new FrmThank();
                        frmThank.ShowDialog(this);
                    }
                    Visible = true;
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void BtnValidMouseEnter(object sender, EventArgs e)
        {
            btnValid.BackgroundImage = Resources.background_9;
        }

        private void BtnValidMouseLeave(object sender, EventArgs e)
        {
            btnValid.BackgroundImage = null;
        }

        private void BtnCancelMouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void BtnCancelMouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = null;
        }

        private void BtnReturnMouseEnter(object sender, EventArgs e)
        {
            btnDeposit.BackgroundImage = Resources.background_9;
        }

        private void BtnReturnMouseLeave(object sender, EventArgs e)
        {
            btnDeposit.BackgroundImage = null;
        }

        private void BtnSearchSaleOrderMouseEnter(object sender, EventArgs e)
        {
            btnSearchSaleOrder.BackgroundImage = Resources.background_9;
        }

        private void BtnSearchSaleOrderMouseLeave(object sender, EventArgs e)
        {
            btnSearchSaleOrder.BackgroundImage = null;
        }

        private void AdjustColumOrder()
        {
            if (dgvSaleItem == null) 
                return;

            dgvSaleItem.Columns["DelColumn"].DisplayIndex = 0;
            dgvSaleItem.Columns["ProdPicture"].DisplayIndex = 1;
            dgvSaleItem.Columns["ProductNameCol"].DisplayIndex = 2;
            dgvSaleItem.Columns["QtySold"].DisplayIndex = 4;
            dgvSaleItem.Columns["PublicUPOut"].DisplayIndex = 9;
            dgvSaleItem.Columns["Discount"].DisplayIndex = 10;
            dgvSaleItem.Columns["SubTotal"].DisplayIndex = 11;
        }

        private void BtnSearchSaleOrderClick(object sender, EventArgs e)
        {
            ScanFocusHandler();
            try
            {
                if (!_returnEnabled)
                {
                    Visible = false;
                    using (var frmSaleSearch = new FrmSaleSearch())
                    {
                        if (frmSaleSearch.ShowDialog(this) == DialogResult.OK)
                        {                            
                            var saleOrderNumber = frmSaleSearch.SearchSoNumber;
                            var indexOf = saleOrderNumber.IndexOf(" (");
                            if(indexOf > 0)
                                saleOrderNumber = StringHelper.Left(saleOrderNumber, indexOf);

                            var searchCriteria = new List<string> { "SaleOrderNumber|" + saleOrderNumber };
                            var saleOrderList = _saleOrderService.GetSaleOrders(searchCriteria);
                            if (saleOrderList.Count == 0)
                            {
                                Visible = true;
                                return;
                            }

                            _saleOrder = (SaleOrder)saleOrderList[0];
                            if (_saleOrder == null)
                            {
                                Visible = true;
                                return;
                            }

                            dgvSaleItem.SelectionChanged += DgvSaleItemSelectionChanged;
                            IListToBindingList(
                                _saleOrderService.GetSaleItems(_saleOrder.SaleOrderId));
                            _saleOrder.FKCustomer.DiscountPercentage = _saleOrder.Discount;
                            SetCustomerInfo(_saleOrder.FKCustomer);
                            CalculateSale();
                            SetInvoiceInfo(
                                _saleOrder.SaleOrderNumber,
                                _saleOrder.AmountSoldInt,
                                _saleOrder.AmountPaidInt,
                                _saleOrder.AmountPaidRiel,
                                _saleOrder.AmountReturnInt);

                            ////If invoice has already been voided
                            //searchCriteria = new List<string> {"ReferenceNum|" + _saleOrder.SaleOrderNumber};
                            //saleOrderList = _saleOrderService.GetSaleOrders(searchCriteria);

                            //if (saleOrderList.Count != 0)
                            //{
                            //    _returnEnabled = false;
                            //    SaleItemBindingListChanged(null, null);
                            //}
                            //else
                            //{
                                DoActivateControls(false);
                                ReturnHandler(_returnEnabled = true);
                            //}
                        }
                        Visible = true;
                    }
                }
                else
                {
                    string briefMsg, detailMsg;
                    if (!UserService.AllowToPerform(Resources.PermissionReturnProduct))
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

                    if (_saleOrder == null)
                        return;

                    if (_saleItemBindingList.Count == 0)
                        return;

                    briefMsg = "អំពីការសង";
                    detailMsg = "សូម​មេត្តា​ចុច​លើ​ប៊ូតុង យល់​ព្រម ដើម្បី​បញ្ជាក់​ពី​ការ​ប្រគល់​សង​។";
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                            return;
                    }

                    _saleOrder = _saleOrderService.RecordSaleOrder(
                        _saleItemBindingList,
                        _totalAmountInt,
                        _totalAmountInt,
                        _totalAmountInt * AppContext.ExchangeRate.ExchangeValue,
                        0,
                        _saleOrder.FKCustomer,
                        true,
                        _saleOrder.SaleOrderNumber,
                        _saleOrder.Discount,
                        0,
                        false);
                    
                    ReturnHandler(_returnEnabled = false);
                    SetInvoiceInfo(
                        _saleOrder.SaleOrderNumber,
                        _saleOrder.AmountSoldInt,
                        _saleOrder.AmountPaidInt,
                        _saleOrder.AmountPaidRiel,
                        _saleOrder.AmountReturnInt);

                    dgvSaleItem.Refresh();
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }                
        }

        private void SetCustomerInfo(Customer customer)
        {
            var strCustomerInfo = customer.CustomerName;
            if (customer.FKDiscountCard == null)
            {
                var dCardList = _customerService.GetDiscountCardsByCustomer(customer.CustomerID);
                if (dCardList != null)
                {
                    if (dCardList.Count != 0)
                        customer.FKDiscountCard = dCardList[0] as DiscountCard;
                    else
                        customer.FKDiscountCard = new DiscountCard();
                }

                if (customer.FKDiscountCard != null)
                {
                    customer.FKDiscountCard.DiscountPercentage = customer.DiscountPercentage;
                    customer.DiscountCardNumber = customer.FKDiscountCard.CardNumber;
                    customer.DiscountCardType = customer.FKDiscountCard.DiscountCardTypeStr;
                }
            }

            if (customer.FKDiscountCard != null)
                strCustomerInfo += "\n" +
                                   customer.FKDiscountCard.CardNumber + "\n" +
                                   customer.FKDiscountCard.DiscountPercentage.ToString("N0", AppContext.CultureInfo) +
                                   " %";

            lblCustomer.Text = strCustomerInfo;
        }

        private void SetInvoiceInfo(string invoiceNumber, IFormattable amountSoldInt, float amountPaidInt, float amountPaidRiel, IFormattable amountReturnInt)
        {
            lblInvoiceNum.Text = invoiceNumber;
            lblFinalAmount.Text =
                Resources.ConstPrefixDollar + amountSoldInt.ToString("N", AppContext.CultureInfo);
            lblAmountPaid.Text =
                Resources.ConstPrefixDollar + (amountPaidInt + (amountPaidRiel * _exchangeRate)).ToString("N", AppContext.CultureInfo);
            lblAmountReturn.Text =
                Resources.ConstPrefixDollar + amountReturnInt.ToString("N", AppContext.CultureInfo);
        }

        private void DoProductFetching(string productCode, bool isAllowed)
        {
            if (String.IsNullOrEmpty(productCode))
                return;

            cmbProduct.SelectedIndex = -1;
            var selectedIndex = cmbProduct.FindStringExact(
                StringHelper.Right("000000000" + productCode, 9));

            //Switch to foreign code
            if(selectedIndex == -1)
            {
                cmbProduct.SelectedIndexChanged -= CmbProductSelectedIndexChanged;
                cmbProduct.DisplayMember = Product.CONST_FOREIGN_CODE;

                selectedIndex = cmbProduct.FindStringExact(productCode);
                
                //Switch to product code
                cmbProduct.DisplayMember = Product.CONST_PRODUCT_CODE;
                cmbProduct.SelectedIndex = -1;
                cmbProduct.SelectedIndexChanged += CmbProductSelectedIndexChanged;
            }
            cmbProduct.SelectedIndex = selectedIndex;

            if ((selectedIndex != -1) || (!isAllowed)) 
                return;

            var strCriteria =
                new List<string>
                {
                    "(ProductCode = '" + 
                    StringHelper.Right("000000000" + productCode, 9) + 
                    "' OR ForeignCode = '" + productCode + "')",
                    "QtyInStock > 0"
                };

            var productList = _productService.GetObjects(strCriteria);
            if (productList.Count != 0)
            {
                if(productList.Count > 1)
                {
                    Visible = false;
                    using (var frmProductList = new FrmProductSearch())
                    {
                        frmProductList.CodeProduct = productCode;
                        if (frmProductList.ShowDialog(this) == DialogResult.OK)
                        {
                            var product = frmProductList.Product;
                            if (product != null)
                            {
                                _productList.Add(product);
                                DoProductFetching(product.ProductCode, true);
                            }
                        }
                        Visible = true;
                    }
                    return;
                }

                foreach (Product product in productList)
                    _productList.Add(product);

                DoProductFetching(productCode, false);
            }
            else
            {
                txtHidden.Text = string.Empty;
                const string briefMsg = "អំពីផលិតផល";
                var detailMsg = Resources.MsgOperationRequestProductNotFound;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }
        }

        private void ResetCustomerInfo()
        {
            lblCustomer.Text = string.Empty;
        }

        private void DoActivateControls(bool isActivated)
        {
            btnValid.Text = !isActivated ? Resources.ConstSalePrint : Resources.ConstSalePay;
        }

        private void SetPurchasedInfo(IFormattable totalQtyPurchased)
        {
            lblPurchaseInfo.Text =
                Resources.ConstPurchaseInfoPrefix + totalQtyPurchased.ToString("N0", AppContext.CultureInfo);
        }

        private void IListToBindingList(IList saleItemList)
        {
            if (saleItemList == null)
                throw new ArgumentNullException("saleItemList", Resources.MsgInvalidData);

            try
            {
                _saleItemBindingList.Clear();
                foreach (SaleItem saleItem in saleItemList)
                {
                    var product = saleItem.FKProduct;
                    product.UnitPriceOut = saleItem.UnitPriceOut;
                    _saleItemBindingList.Add(
                        CreateSaleItem(
                            product,
                            saleItem.QtySold,
                            saleItem.Discount));
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DgvSaleItemCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_saleOrder != null)
                return;

            if (_saleItemBindingList == null)
                return;

            if (_saleItemBindingList.Count == 0)
                return;

            using (var frmCatalog = new FrmCatalog())
            {
                frmCatalog.IsFromSale = true;
                frmCatalog.Product =
                    _saleItemBindingList[dgvSaleItem.SelectedRows[0].Index].FKProduct;

                if (frmCatalog.ShowDialog(this) == DialogResult.OK)
                {
                    var selectedIndex =
                        dgvSaleItem.SelectedRows[0].Index;
                    var saleItem = _saleItemBindingList[selectedIndex];
                    var product = frmCatalog.Product;

                    saleItem.Discount = product.DiscountPercentage;

                    var publicUnitPriceOut = 
                        product.UnitPriceIn + ((product.UnitPriceIn*product.ExtraPercentage) / 100);

                    publicUnitPriceOut =
                        publicUnitPriceOut -
                        ((publicUnitPriceOut * product.DiscountPercentage) / 100);

                    if (publicUnitPriceOut == product.UnitPriceIn)
                        publicUnitPriceOut = product.UnitPriceOut;

                    //publicUnitPriceOut =
                    //    float.Parse(Math.Round(publicUnitPriceOut, 0).ToString("N", AppContext.CultureInfo),
                    //                AppContext.CultureInfo);
                    publicUnitPriceOut =
                        float.Parse(
                            publicUnitPriceOut.ToString("N", AppContext.CultureInfo), 
                            AppContext.CultureInfo);
                    saleItem.PublicUPOut = publicUnitPriceOut;
                    //saleItem.UnitPriceOut = product.UnitPriceOut;
                    saleItem.UnitPriceOut = 
                        product.UnitPriceIn + ((product.UnitPriceIn * product.ExtraPercentage) / 100);
                    saleItem.UnitPriceOut =
                        float.Parse(
                            saleItem.UnitPriceOut.ToString("N", AppContext.CultureInfo),
                            AppContext.CultureInfo);
                    //saleItem.SubTotal = saleItem.QtySold * saleItem.UnitPriceOut;
                    saleItem.SubTotal = saleItem.QtySold * publicUnitPriceOut;
                    dgvSaleItem.Refresh();
                    CalculateSale();
                }
            }
            ScanFocusHandler();
        }

        private void BtnProductAdjustmentMouseEnter(object sender, EventArgs e)
        {
            btnProductAdjustment.BackgroundImage = Resources.background_9;
        }

        private void BtnProductAdjustmentMouseLeave(object sender, EventArgs e)
        {
            btnProductAdjustment.BackgroundImage = Resources.background_2;
        }

        private void BtnProductAdjustmentClick(object sender, EventArgs e)
        {
            ScanFocusHandler();
            string briefMsg, detailMsg;
            if (!UserService.AllowToPerform(Resources.PermissionProductAdjustment))
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

            if (_saleItemBindingList == null)
                return;

            if (_saleItemBindingList.Count == 0)
                return;

            briefMsg = "អំពីការសង";
            detailMsg = "សូម​មេត្តា​ចុច​លើ​ប៊ូតុង យល់​ព្រម ដើម្បី​បញ្ជាក់​ពី​ការ​ដកចេញពីឃ្លាំង​។";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.ShowNewFolderButton = false;
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (_productService == null)
                            _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                        IList listProduct2Export = new List<Product>();
                        foreach (var saleItem in _saleItemBindingList)
                        {
                            var product = saleItem.FKProduct;
                            //Save QtyInStock of product
                            saleItem.FKProduct.PublicQty = saleItem.FKProduct.QtyInStock.ToString("N2",
                                                                                                  AppContext.CultureInfo);
                            product.QtyInStock = saleItem.QtySold;
                            listProduct2Export.Add(product);
                        }

                        _productService.ExportProductToXml(
                            listProduct2Export,
                            folderBrowserDialog.SelectedPath,
                            "ProductList.xml");

                        foreach (var saleItem in _saleItemBindingList.Where(saleItem => saleItem != null))
                        {
                            //Restore QtyInStock of product                            
                            saleItem.FKProduct.QtyInStock = float.Parse(saleItem.FKProduct.PublicQty);
                            //saleItem.QtySold = saleItem.FKProduct.QtyInStock;
                            saleItem.UnitPriceIn = 0;
                            saleItem.UnitPriceOut = 0;
                            saleItem.PublicUPOut = 0;
                            saleItem.SubTotal = 0;
                        }

                        dgvSaleItem.Refresh();
                        CalculateSale();
                        _productService.ProductAdjustmentManagement(
                            Resources.OperationRequestInsert,
                            _saleItemBindingList);
                        DoActivateControls(false);
                    }
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void CtrlSale_KeyDown(object sender, KeyEventArgs e)
        {
            TxtHiddenKeyDown(sender, e);
        }

        private void TxtHiddenLeave(object sender, EventArgs e)
        {
            if (txtHidden.CanFocus)
                txtHidden.Focus();
        }

        private void ReturnHandler(bool enableStatus)
        {
            btnSearchSaleOrder.Text = enableStatus ? Resources.ConstSaleReturn : Resources.ConstSaleSearch;
            btnValid.Text = !enableStatus ? Resources.ConstSalePay : Resources.ConstSalePrint;

            btnProductAdjustment.Enabled = !enableStatus;
            btnDeposit.Enabled = !enableStatus;
            btnSearchSaleOrder.Enabled = enableStatus;
        }

        private void SaleItemBindingListChanged(object sender, ListChangedEventArgs e)
        {
            var isEnabled = _saleItemBindingList.Count != 0;
            if (sender == null)
                isEnabled = false;

            if (_returnEnabled && isEnabled)
                return;

            btnProductAdjustment.Enabled = isEnabled;
            btnValid.Enabled = isEnabled;
            btnDeposit.Enabled = isEnabled && _depositEnabled;
            btnCancel.Enabled = isEnabled;
            btnSearchSaleOrder.Enabled = !isEnabled;

            if (isEnabled) 
                return;

            _returnEnabled = false;
            btnSearchSaleOrder.Text = Resources.ConstSaleSearch;
        }

        private void LocalStockHandler()
        {
            if(_saleItemBindingList == null)
                return;

            foreach (var saleItem in _saleItemBindingList.Where(saleItem => saleItem != null).Where(saleItem => saleItem.FKProduct != null))
            {
                if(saleItem == null)
                    continue;

                if(saleItem.FKProduct == null)
                    continue;

                var product = saleItem.FKProduct;
                product.QtyInStock -= saleItem.QtySold;
                product.QtySold += saleItem.QtySold;
            }            
        }
    }
}