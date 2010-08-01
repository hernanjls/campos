using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EzPos.GUI;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Utility;

namespace EzPos.GUIs.Controls
{
    public partial class CtrlSale : UserControl
    {
        private CommonService _CommonService;
        private CustomerService _CustomerService;
        private float _ExchangeRate;
        private BindingList<Product> _ProductList;
        private ProductService _ProductService;
        private BindingList<SaleItem> _SaleItemBindingList;
        private SaleOrder _SaleOrder;
        private Deposit _Deposit;
        private SaleOrderService _SaleOrderService;
        private DepositService _DepositService;
        private float _TotalAmountInt;
        private bool _ReturnEnabled;
        private bool _DepositEnabled;

        public CtrlSale()
        {
            InitializeComponent();
        }

        public ProductService ProductService
        {
            set { _ProductService = value; }
        }

        public CustomerService CustomerService
        {
            set { _CustomerService = value; }
        }

        public SaleOrderService SaleOrderService
        {
            set { _SaleOrderService = value; }
        }

        public DepositService DepositService
        {
            set { _DepositService = value; }
        }

        private void CtrlSale_Load(object sender, EventArgs e)
        {
            try
            {
                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
                if (_ProductService == null)
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
                if (_CustomerService == null)
                    _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
                if (_SaleOrderService == null)
                    _SaleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
                if (_DepositService == null)
                    _DepositService = ServiceFactory.GenerateServiceInstance().GenerateDepositService();

                if (!UserService.AllowToPerform(Resources.PermissionProductAdjustment))
                    btnProductAdjustment.Visible = false;

                //Initialization
                _ProductList = new BindingList<Product>();
                cmbProduct.DataSource = _ProductList;
                cmbProduct.DisplayMember = Product.CONST_PRODUCT_CODE;
                cmbProduct.ValueMember = Product.CONST_PRODUCT_ID;
                cmbProduct.SelectedIndex = -1;

                if (AppContext.ExchangeRate != null)
                    _ExchangeRate = AppContext.ExchangeRate.ExchangeValue;

                InitializeSaleItemList();
                ResetProductInfo();
                ScanFocusHandler();

                _DepositEnabled = CommonService.IsIntegratedModule(Resources.ModDeposit);
                btnDeposit.Enabled = _DepositEnabled;
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
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
                SetProductInfo(product);

                var foundFlag = false;
                var selectedIndex = 0;
                dgvSaleItem.SelectionChanged -= DgvSaleItemSelectionChanged;
                foreach (var saleItem in _SaleItemBindingList)
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
                    _SaleItemBindingList.Add(saleItem);
                }

                dgvSaleItem.Refresh();
                UpdateSelectedIndex(selectedIndex);
                dgvSaleItem.SelectionChanged += DgvSaleItemSelectionChanged;
                CalculateSale();
                ScanFocusHandler();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void SetProductInfo(Product product)
        {
            lblProductName.Text = product.ProductName + @" \ " + product.ColorStr;
            lblPrice.Text = "$ " + product.UnitPriceOut.ToString("N", AppContext.CultureInfo);
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
                    ProductDisplayName = 
                        (product.ProductName + "\r" + product.ProductCode),
                    ProductID = product.ProductID,
                    QtySold = qtySold,
                    UnitPriceIn = product.UnitPriceIn
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
            if (_SaleItemBindingList == null)
                ResetProductInfo();

            if (_SaleItemBindingList != null)
            {
                if (_SaleItemBindingList.Count == 0)
                    ResetProductInfo();

                if (selectedIndex < 0)
                {
                    if (_SaleItemBindingList.Count == 1)
                    {
                        ResetProductInfo();
                        return;
                    }
                    selectedIndex = 0;
                }

                if (selectedIndex == _SaleItemBindingList.Count)
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
                    if (_SaleItemBindingList != null)
                        if ((selectedIndex - dgvSaleItem.DisplayedRowCount(true) + 2) >=
                            _SaleItemBindingList.Count)
                            return;

                    dgvSaleItem.FirstDisplayedScrollingRowIndex =
                        selectedIndex - dgvSaleItem.DisplayedRowCount(true) + 2;
                }
            }
        }

        private void CalculateSale()
        {
            _TotalAmountInt = 0;
            float totalPurchasedQty = 0;
            foreach (var saleItem in _SaleItemBindingList)
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

                _TotalAmountInt += saleItem.QtySold * unitPriceOut;
                totalPurchasedQty += saleItem.QtySold;
            }

            lblTotalAmountInt.Text = "$ " + _TotalAmountInt.ToString("N", AppContext.CultureInfo);
            lblTotalAmountNat.Text = "R " + (_TotalAmountInt*_ExchangeRate).ToString("N", AppContext.CultureInfo);
            if (_SaleOrder != null)
            {
                var tmpTotalAmountInt = _TotalAmountInt;
                tmpTotalAmountInt -= ((tmpTotalAmountInt*_SaleOrder.Discount)/100);
                lblFinalAmount.Text = "$ " + tmpTotalAmountInt.ToString("N", AppContext.CultureInfo);
                lblAmountPaid.Text = "$ " + tmpTotalAmountInt.ToString("N", AppContext.CultureInfo);
                lblAmountReturn.Text = "$ 0.00";
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
            if (_SaleItemBindingList == null)
                _SaleItemBindingList = new SaleItemBindingList<SaleItem>();

            AdjustColumOrder();
            dgvSaleItem.DataSource = _SaleItemBindingList;
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
                        if (_SaleItemBindingList.Count == 0)
                            return;
                        UpdateSaleItem(Resources.OperationRequestDelete,
                                       dgvSaleItem.SelectedRows[0].Index);
                        break;
                    case Keys.Add:
                        if (!btnValid.Enabled)
                            return;

                        if (_SaleItemBindingList.Count == 0)
                            return;
                        UpdateSaleItem(Resources.OperationRequestInsert,
                                       dgvSaleItem.SelectedRows[0].Index);
                        break;
                    case Keys.Subtract:
                        if (!btnValid.Enabled)
                            return;

                        if (_SaleItemBindingList.Count == 0)
                            return;
                        UpdateSaleItem(Resources.OperationRequestUpdate,
                                       dgvSaleItem.SelectedRows[0].Index);
                        break;
                    case Keys.Up:
                        if (_SaleItemBindingList.Count == 0)
                            return;
                        UpdateSelectedIndex(dgvSaleItem.SelectedRows[0].Index - 1);
                        break;
                    case Keys.Down:
                        if (_SaleItemBindingList.Count == 0)
                            return;
                        UpdateSelectedIndex(dgvSaleItem.SelectedRows[0].Index + 1);
                        break;
                    case Keys.Return:
                        if (!btnValid.Enabled)
                            return;

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
                                    _ProductList.Add(product);
                                    DoProductFetching(product.ProductCode, true);
                                }
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
                ExtendedMessageBox.UnknownErrorMessage(
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
                _SaleItemBindingList.RemoveAt(selectedIndex);
            }
            else
            {
                var saleItem = _SaleItemBindingList[selectedIndex];
                if (requestType == Resources.OperationRequestInsert)
                {
                    foreach (var product in _ProductList)
                    {
                        if ((product.ProductID == saleItem.ProductID) &&
                            (product.QtyInStock == saleItem.QtySold))
                            return;
                    }
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
            _SaleOrder = null;
            _SaleItemBindingList.Clear();
            ResetProductInfo();
//            ResetProductPrice();
            ResetCustomerInfo();
            DoActivateControls(true);
            ReturnHandler(_ReturnEnabled = false);
            ScanFocusHandler();
        }

        private void ResetProductInfo()
        {
            lblInvoiceNum.Text = string.Empty;
            lblProductName.Text = string.Empty;
            lblPrice.Text = string.Empty;
            lblReference.Text = string.Empty;
            ptbDisplay.Image = null;
            lblTotalAmountInt.Text = "$ 0.00";
            lblTotalAmountNat.Text = "R 0.00";
            lblFinalAmount.Text = "$ 0.00";
            lblAmountPaid.Text = "$ 0.00";
            lblAmountReturn.Text = "$ 0.00";
            SetPurchasedInfo(0);
        }

        private void DgvSaleItemSelectionChanged(object sender, EventArgs e)
        {
            if (_SaleItemBindingList == null)
                return;

            if (_SaleItemBindingList.Count == 0)
                return;

            if (dgvSaleItem.CurrentRow != null)
            {
                if (_SaleItemBindingList[dgvSaleItem.CurrentRow.Index].FKProduct != null)
                {
                    SetProductInfo(
                        _SaleItemBindingList[dgvSaleItem.SelectedRows[0].Index].FKProduct);
                }
                else
                {
                    cmbProduct.SelectedIndexChanged -= CmbProductSelectedIndexChanged;
                    foreach (var product in _ProductList)
                    {
                        if (product.ProductID != 
                            Int32.Parse(dgvSaleItem.Rows[dgvSaleItem.SelectedRows[0].Index].Cells["ProductID"].Value.ToString(), AppContext.CultureInfo)) 
                            continue;

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
            ExtendedMessageBox.UnknownErrorMessage(
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
            if (_SaleItemBindingList.Count == 0)
                return;

            try
            {
                if (!_ReturnEnabled)
                {
                    Visible = false;
                    using (var frmPayment = new FrmPayment())
                    {
                        frmPayment.CommonService = _CommonService;
                        frmPayment.CustomerService = _CustomerService;
                        frmPayment.TotalAmountInt = _TotalAmountInt;
                        if (frmPayment.ShowDialog(this) == DialogResult.OK)
                        {
                            Visible = true;
                            var discountPercentage = frmPayment.Customer.FKDiscountCard.DiscountPercentage;
                            _SaleOrder = _SaleOrderService.RecordSaleOrder(
                                _SaleItemBindingList,
                                _TotalAmountInt,
                                frmPayment.AmountPaidInt,
                                frmPayment.AmountPaidRiel,
                                frmPayment.AmountPaidInt - (_TotalAmountInt - ((_TotalAmountInt * discountPercentage) / 100)),
                                frmPayment.Customer,
                                false,
                                string.Empty,
                                frmPayment.Customer.FKDiscountCard.DiscountPercentage,
                                0,
                                false);

                            if (_SaleOrder == null)
                                return;

                            DoActivateControls(false);
                            SetCustomerInfo(frmPayment.Customer);
                            SetInvoiceInfo(
                                _SaleOrder.SaleOrderNumber,
                                _SaleOrder.AmountSoldInt,
                                _SaleOrder.AmountPaidInt,
                                _SaleOrder.AmountPaidRiel,
                                _SaleOrder.AmountReturnInt);
                            InvoicePrinting(
                                _SaleOrder.FKCustomer,
                                _SaleOrder.SaleOrderNumber,
                                (DateTime)_SaleOrder.SaleOrderDate,
                                _SaleOrder.Discount,
                                0,
                                _SaleOrder.AmountPaidInt,
                                false);

                            var frmThank = new FrmThank();
                            frmThank.ShowDialog(this);
                        }
                        Visible = true;
                    }                
                }
                else
                {
                    InvoicePrinting(
                        _SaleOrder.FKCustomer,
                        _SaleOrder.SaleOrderNumber,
                        (DateTime)_SaleOrder.SaleOrderDate,
                        _SaleOrder.Discount,
                        0,
                        _SaleOrder.AmountPaidInt,
                        false);                    
                }
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
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
            bool isDeposit)
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
                _SaleItemBindingList,
                isDeposit);
        }

        private void DgvSaleItemCellClick(object sender, DataGridViewCellEventArgs e)
        {
            ScanFocusHandler();

            if (_SaleItemBindingList == null)
                return;

            if (_SaleItemBindingList.Count == 0)
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
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            ScanFocusHandler();           

            if (_SaleItemBindingList.Count == 0)
                return;

            Visible = false;
            try
            {
                using (var frmPayment = new FrmPayment())
                {
                    frmPayment.CommonService = _CommonService;
                    frmPayment.CustomerService = _CustomerService;
                    frmPayment.TotalAmountInt = _TotalAmountInt;
                    frmPayment.IsDeposit = true;
                    if (frmPayment.ShowDialog(this) == DialogResult.OK)
                    {
                        Visible = true;
                        var depositItemList = _DepositService.GetDepositItems(_SaleItemBindingList);

                        _Deposit = _DepositService.RecordDeposit(
                            depositItemList,
                            _TotalAmountInt,
                            frmPayment.AmountPaidInt,
                            frmPayment.AmountPaidRiel,
                            frmPayment.Customer,
                            string.Empty,
                            frmPayment.Customer.FKDiscountCard.DiscountPercentage,
                            false);

                        if (_Deposit == null)
                            return;

                        DoActivateControls(false);
                        SetCustomerInfo(frmPayment.Customer);
                        SetInvoiceInfo(
                            _Deposit.DepositNumber,
                            _Deposit.AmountSoldInt,
                            _Deposit.AmountPaidInt,
                            _Deposit.AmountPaidRiel,
                            _Deposit.AmountReturnInt);
                        InvoicePrinting(
                            _Deposit.FKCustomer,
                            _Deposit.DepositNumber,
                            (DateTime)_Deposit.DepositDate,
                            _Deposit.Discount,
                            _Deposit.AmountPaidInt,
                            0,
                            true);

                        var frmThank = new FrmThank();
                        frmThank.ShowDialog(this);
                    }
                    Visible = true;
                }
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
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
                if (!_ReturnEnabled)
                {
                    Visible = false;
                    using (var frmSaleSearch = new FrmSaleSearch())
                    {
                        if (frmSaleSearch.ShowDialog(this) == DialogResult.OK)
                        {
                            var searchCriteria = new List<string> { "SaleOrderNumber|" + frmSaleSearch.SONumber };
                            var saleOrderList = _SaleOrderService.GetSaleOrders(searchCriteria);
                            if (saleOrderList.Count == 0)
                                return;

                            _SaleOrder = (SaleOrder)saleOrderList[0];
                            if (_SaleOrder == null)
                                return;

                            dgvSaleItem.SelectionChanged += DgvSaleItemSelectionChanged;
                            IListToBindingList(
                                _SaleOrderService.GetSaleItems(_SaleOrder.SaleOrderId));
                            _SaleOrder.FKCustomer.DiscountPercentage = _SaleOrder.Discount;
                            SetCustomerInfo(_SaleOrder.FKCustomer);
                            CalculateSale();
                            SetInvoiceInfo(
                                _SaleOrder.SaleOrderNumber,
                                _SaleOrder.AmountSoldInt,
                                _SaleOrder.AmountPaidInt,
                                _SaleOrder.AmountPaidRiel,
                                _SaleOrder.AmountReturnInt);
                            DoActivateControls(false);
                            ReturnHandler(_ReturnEnabled = true);
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
                        using (var frmMessageBox = new ExtendedMessageBox())
                        {
                            frmMessageBox.BriefMsgStr = briefMsg;
                            frmMessageBox.DetailMsgStr = detailMsg;
                            frmMessageBox.IsCanceledOnly = true;
                            frmMessageBox.ShowDialog(this);
                            return;
                        }
                    }

                    if (_SaleOrder == null)
                        return;

                    if (_SaleItemBindingList.Count == 0)
                        return;

                    briefMsg = "អំពីការសង";
                    detailMsg = "សូម​មេត្តា​ចុច​លើ​ប៊ូតុង យល់​ព្រម ដើម្បី​បញ្ជាក់​ពី​ការ​ប្រគល់​សង​។";
                    using (var frmMessageBox = new ExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                            return;
                    }

                    _SaleOrder = _SaleOrderService.RecordSaleOrder(
                        _SaleItemBindingList,
                        _TotalAmountInt,
                        _TotalAmountInt,
                        _TotalAmountInt * AppContext.ExchangeRate.ExchangeValue,
                        0,
                        _SaleOrder.FKCustomer,
                        true,
                        _SaleOrder.SaleOrderNumber,
                        _SaleOrder.Discount,
                        0,
                        false);
                    
                    ReturnHandler(_ReturnEnabled = false);
                    SetInvoiceInfo(
                        _SaleOrder.SaleOrderNumber,
                        _SaleOrder.AmountSoldInt,
                        _SaleOrder.AmountPaidInt,
                        _SaleOrder.AmountPaidRiel,
                        _SaleOrder.AmountReturnInt);

                    dgvSaleItem.Refresh();
                }
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }                
        }

        private void SetCustomerInfo(Customer customer)
        {
            var strCustomerInfo = customer.CustomerName;
            if (customer.FKDiscountCard == null)
            {
                var dCardList = _CustomerService.GetDiscountCardsByCustomer(customer.CustomerID);
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
                "$ " + amountSoldInt.ToString("N", AppContext.CultureInfo);
            lblAmountPaid.Text = 
                "$ " + (amountPaidInt + (amountPaidRiel * _ExchangeRate)).ToString("N", AppContext.CultureInfo);
            lblAmountReturn.Text = 
                "$ " + amountReturnInt.ToString("N", AppContext.CultureInfo);
        }

        private void DoProductFetching(string productCode, bool isAllowed)
        {
            if (String.IsNullOrEmpty(productCode))
                return;

            //productCode = productCode.Replace("+", string.Empty);
            //productCode = productCode.Replace("-", string.Empty);
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
                //new List<string>
                //{
                //    "(ProductCode LIKE '%" + productCode + "%') OR " + 
                //    "(ForeignCode LIKE '%" + productCode + "%')",
                //    "QtyInStock > 0"
                //};
            var productList = _ProductService.GetObjects(strCriteria);
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
                                _ProductList.Add(product);
                                DoProductFetching(product.ProductCode, true);
                            }
                        }
                        Visible = true;
                    }
                    return;
                }

                foreach (Product product in productList)
                    _ProductList.Add(product);

                DoProductFetching(productCode, false);
            }
            else
            {
                txtHidden.Text = string.Empty;
                const string briefMsg = "អំពីផលិតផល";
                var detailMsg = Resources.MsgOperationRequestProductNotFound;
                using (var frmMessageBox = new ExtendedMessageBox())
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
            btnValid.Enabled = isActivated;
            btnProductAdjustment.Enabled = isActivated;
            btnDeposit.Enabled = isActivated && _DepositEnabled;
        }

        private void SetPurchasedInfo(IFormattable totalQtyPurchased)
        {
            lblPurchaseInfo.Text =
                "ចំនួនសរុបនៃផលិតផលដែលបានទិញ៖ " + totalQtyPurchased.ToString("N0", AppContext.CultureInfo);
        }

        private void IListToBindingList(IList saleItemList)
        {
            if (saleItemList == null)
                throw new ArgumentNullException("saleItemList", "Sale Item List");

            try
            {
                _SaleItemBindingList.Clear();
                foreach (SaleItem saleItem in saleItemList)
                {
                    var product = saleItem.FKProduct;
                    product.UnitPriceOut = saleItem.UnitPriceOut;
                    _SaleItemBindingList.Add(
                        CreateSaleItem(
                            product,
                            saleItem.QtySold,
                            saleItem.Discount));
                }
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DgvSaleItemCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_SaleOrder != null)
                return;

            if (_SaleItemBindingList == null)
                return;

            if (_SaleItemBindingList.Count == 0)
                return;

            using (var frmCatalog = new FrmCatalog())
            {
                frmCatalog.IsFromSale = true;
                frmCatalog.Product =
                    _SaleItemBindingList[dgvSaleItem.SelectedRows[0].Index].FKProduct;

                if (frmCatalog.ShowDialog(this) == DialogResult.OK)
                {
                    var selectedIndex =
                        dgvSaleItem.SelectedRows[0].Index;
                    var saleItem = _SaleItemBindingList[selectedIndex];
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
                        product.UnitPriceIn + 
                        ((product.UnitPriceIn * product.ExtraPercentage) / 100);
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
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    return;
                }
            }

            if (_SaleItemBindingList == null)
                return;

            if (_SaleItemBindingList.Count == 0)
                return;

            briefMsg = "អំពីការសង";
            detailMsg = "សូម​មេត្តា​ចុច​លើ​ប៊ូតុង យល់​ព្រម ដើម្បី​បញ្ជាក់​ពី​ការ​ដកចេញពីឃ្លាំង​។";
            using (var frmMessageBox = new ExtendedMessageBox())
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
                        if (_ProductService == null)
                            _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                        IList listProduct2Export = new List<Product>();
                        foreach (var saleItem in _SaleItemBindingList)
                        {
                            var product = saleItem.FKProduct;
                            //Save QtyInStock of product
                            saleItem.FKProduct.PublicQty = saleItem.FKProduct.QtyInStock.ToString("N2",
                                                                                                  AppContext.CultureInfo);
                            product.QtyInStock = saleItem.QtySold;
                            listProduct2Export.Add(product);
                        }

                        _ProductService.ExportProductToXml(
                            listProduct2Export,
                            folderBrowserDialog.SelectedPath,
                            "ProductList.xml");

                        foreach (var saleItem in _SaleItemBindingList)
                        {
                            if (saleItem == null)
                                continue;

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
                        _ProductService.ProductAdjustmentManagement(
                            Resources.OperationRequestInsert,
                            _SaleItemBindingList);
                        DoActivateControls(false);
                    }
                }
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
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
            btnSearchSaleOrder.Text = enableStatus ? "សង" : "ស្វែងរក";
            btnValid.Enabled = true;
            btnValid.Text = enableStatus ? "បោះពុម្ភ" : "គិតលុយ";
        }

        //private void ResetProductPrice()
        //{
        //    if (_ProductList == null)
        //        return;

        //    if(_ProductList.Count == 0)
        //        return;

        //    foreach(var product in _ProductList)
        //    {
        //        var publicUnitPriceOut =
        //            product.UnitPriceIn +
        //            ((product.UnitPriceIn * product.ExtraPercentage) / 100);

        //        publicUnitPriceOut =
        //            publicUnitPriceOut -
        //            ((publicUnitPriceOut * product.DiscountPercentage) / 100);

        //        product.UnitPriceOut = publicUnitPriceOut;
        //    }            
        //}
    }
}