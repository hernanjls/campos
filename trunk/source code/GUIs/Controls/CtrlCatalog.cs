using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
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
    public partial class CtrlCatalog : UserControl
    {
        private readonly List<BarCode> _barCodeList = new List<BarCode>();
        private CommonService _commonService;
        private BindingList<Product> _productList;
        private ProductService _productService;

        public CtrlCatalog()
        {
            InitializeComponent();
        }

        public ProductService ProductService
        {
            set { _productService = value; }
        }

        public CommonService CommonService
        {
            set { _commonService = value; }
        }

        private void UpdateControlContent()
        {
            SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;

            if ((cmbCategory.InvokeRequired) || (cmbMark.InvokeRequired) || (cmbColor.InvokeRequired))
                safeCrossCallBackDelegate = UpdateControlContent;

            if (cmbCategory.InvokeRequired)
                Invoke(safeCrossCallBackDelegate);
            else
            {
                var searchCriteria = 
                    new List<string>
                    {
                        "ParameterTypeID IN (" +
                        Resources.AppParamCategory + ", " +
                        Resources.AppParamMark + "," +
                        Resources.AppParamColor + ")"
                    };
                var objectList = _commonService.GetAppParameters(searchCriteria);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbCategory,
                    objectList,
                    Int32.Parse(Resources.AppParamCategory, AppContext.CultureInfo),
                    false);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbMark,
                    objectList,
                    Int32.Parse(Resources.AppParamMark, AppContext.CultureInfo),
                    false);

                _commonService.PopAppParamExtendedCombobox(
                    ref cmbColor,
                    objectList,
                    Int32.Parse(Resources.AppParamColor, AppContext.CultureInfo),
                    false);

                IListToBindingList(
                    _productService.GetCatalogs(chbInstockOnly.Checked));
            }
        }

        private void CtrlCatalog_Load(object sender, EventArgs e)
        {
            try
            {
                if (_productService == null)
                    _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                if (_commonService == null)
                    _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                if (!UserService.AllowToPerform(Resources.PermissionViewAllProductInfo))
                {
                    UPInLbl.Visible = false;
                    extraPercentageLbl.Visible = false;
                }
                if (!UserService.AllowToPerform(Resources.PermissionViewProdResultInfo))
                {
                    lblResultInfo.Visible = false;
                    //extraPercentageLbl.Visible = false;
                }
                InitializeProductList();

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart) {IsBackground = true};
                thread.Start();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DgvProductDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FrmExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void InitializeProductList()
        {
            try
            {
                if (_productList == null)
                    _productList = new BindingList<Product>();

                dgvProduct.DataSource = _productList;
                dgvProduct.Columns["PrintCheck"].DisplayIndex = 0;
                dgvProduct.Columns["PublicQty"].DisplayIndex = 1;
                dgvProduct.Columns["ProductPic"].DisplayIndex = 2;
                dgvProduct.Columns["DisplayName"].DisplayIndex = 3;
                dgvProduct.Columns["Description"].DisplayIndex = 4;
                dgvProduct.Columns["QtyInStock"].DisplayIndex = 5;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DgvProductSelectionChanged(object sender, EventArgs e)
        {
            SetProductInfo();
        }

        private void BtnNewProductClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAddProduct))
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
            ProductManagement(Resources.OperationRequestInsert);
        }

        private void ProductManagement(IEquatable<string> operationRequest)
        {
            try
            {
                if (dgvProduct.CurrentRow == null)
                    return;

                using (var frmCatalog = new FrmCatalog())
                {
                    float preQtyInStock = 0;
                    if (_productList.Count != 0)
                        preQtyInStock = (_productList[dgvProduct.CurrentRow.Index]).QtyInStock;
                    if (operationRequest.Equals(Resources.OperationRequestUpdate))
                        frmCatalog.Product = _productList[dgvProduct.CurrentRow.Index];

                    if (frmCatalog.ShowDialog(this) == DialogResult.OK)
                    {
                        try
                        {
                            if (frmCatalog.Product == null)
                            {
                                IListToBindingList(
                                    _productService.GetCatalogs(chbInstockOnly.Checked));
                            }
                            else
                            {
                                if (operationRequest.Equals(Resources.OperationRequestUpdate))
                                {
                                    UpdateSelectedProduct(
                                        frmCatalog.Product,
                                        preQtyInStock);

                                    if (frmCatalog.Product.QtyInStock == 0)
                                    {
                                        for (var counter = 0; counter < _productList.Count; counter++)
                                        {
                                            if (_productList[counter].ProductID == frmCatalog.Product.ProductID)
                                                _productList.RemoveAt(counter);
                                        }
                                    }
                                }
                                else
                                {
                                    if (frmCatalog.Product.QtyInStock == 0)
                                        _productList.Add(frmCatalog.Product);
                                }
                            }
                            dgvProduct.Refresh();
                            SetProductInfo();

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
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DgvProductDoubleClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionEditProduct))
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

            ProductManagement(Resources.OperationRequestUpdate);
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow == null)
                return;

            string briefMsg, detailMsg;
            if (!UserService.AllowToPerform(Resources.PermissionDeleteProduct))
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

            //string briefMsg, detailMsg;
            briefMsg = "អំពីការលុប";
            detailMsg = Resources.MsgOperationRequestDelete + "\n" +
                        dgvProduct.CurrentRow.Cells["DisplayName"].Value + " ?";
            using (var frmMessageBox = new FrmExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                _productService.ManageProduct(_productList[dgvProduct.CurrentRow.Index],
                                              Resources.OperationRequestDelete);

                _productList.RemoveAt(dgvProduct.CurrentRow.Index);
                DisplayPartialPicture(
                    dgvProduct.DisplayedRowCount(true),
                    dgvProduct.FirstDisplayedScrollingRowIndex + dgvProduct.DisplayedRowCount(true),
                    dgvProduct.FirstDisplayedScrollingRowIndex,
                    ScrollEventType.SmallDecrement);

                UpdateResultInfo();
                EnableActionButton();
            }
            catch (Exception)
            {
                briefMsg = "អំពីការលុប";
                detailMsg = Resources.MsgUnknownError;
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

        private void CmdSearchProductClick(object sender, EventArgs e)
        {
            try
            {
                var searchCriteria = new List<string>();
                if (cmbCategory.SelectedIndex != -1)
                    searchCriteria.Add("CategoryID|" + cmbCategory.SelectedValue);

                if (cmbMark.SelectedIndex != -1)
                    searchCriteria.Add("MarkID|" + cmbMark.SelectedValue);

                if (cmbColor.SelectedIndex != -1)
                    searchCriteria.Add("ColorID|" + cmbColor.SelectedValue);

                if (txtProductCode.Text.Length != 0)
                {
                    searchCriteria.Add(
                        "((ProductCode LIKE '%" + txtProductCode.Text + "%') OR " +
                        "(ForeignCode LIKE '%" + txtProductCode.Text + "%'))");
                }

                _productList.Clear();
                IListToBindingList(
                    _productService.GetCatalogs(searchCriteria, chbInstockOnly.Checked));
                SetFocusToProductList();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            cmbMark.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            txtProductCode.Text = string.Empty;
            CmdSearchProductClick(sender, e);
            SetFocusToProductList();
        }

        private void IListToBindingList(IList productList)
        {
            if (productList == null)
                throw new ArgumentNullException("productList", Resources.MsgInvalidProduct);

            if (_productList == null)
                return;

            try
            {
                _productList.Clear();
                foreach (Product product in productList)
                {
                    foreach (var barCode in _barCodeList)
                    {
                        if (product.ProductCode != barCode.BarCodeValue) 
                            continue;

                        product.PrintCheck = true;
                        product.PublicQty = barCode.AdditionalStr;
                        break;
                    }
                    _productList.Add(product);
                }

                DisplayPartialPicture(
                    dgvProduct.DisplayedRowCount(true),
                    0,
                    0,
                    ScrollEventType.LargeIncrement);

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

        private void ChbDisplayPictureCheckedChanged(object sender, EventArgs e)
        {
            CmdSearchProductClick(sender, e);
        }

        private void BtnPrintClick(object sender, EventArgs e)
        {
            try
            {
                if (!UserService.AllowToPerform(Resources.PermissionPrintProductCode))
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

                if (rdbProduct.Checked)
                {
                    DoPrintProduct();
                    return;
                }
                
                if (rdbPrintAll.Checked)
                {
                    _barCodeList.Clear();
                    foreach (var t in _productList)
                    {
                        var product = t;
                        if(product == null)
                            continue;

                        for (var qtyCounter = 0; qtyCounter < product.QtyInStock; qtyCounter++)
                        {
                            //var product = _ProductList[counter];
                            var barCode = 
                                new BarCode
                                    {
                                        BarCodeValue = product.ProductCode,
                                        DisplayStr = product.CategoryStr,
                                        AdditionalStr = (product.QtyInStock.ToString("N0") + " / " + product.QtyInStock.ToString("N0")),
                                        UnitPrice = "$ " + (t).UnitPriceOut.ToString("N", AppContext.CultureInfo),
                                        Description = product.ProductName + @" \ " + product.SizeStr
                                    };

                            var foreignCode = product.ForeignCode;
                            if (!string.IsNullOrEmpty(foreignCode))
                                barCode.DisplayStr += " (" + foreignCode + ")";
                            _barCodeList.Add(barCode);
                        }

                        (t).PrintCheck = true;
                        (t).PublicQty =
                            (t).QtyInStock +
                            " / " +
                            (t).QtyInStock;
                    }
                    dgvProduct.Refresh();
                }

                var barCodeTemplate = AppContext.BarCodeTemplate;

                //var barCodePrintingTypeList =
                //    _CommonService.GetAppParametersByType(
                //        Int32.Parse(Resources.AppParamBarcodePrintingType, AppContext.CultureInfo));

                //var barCodePrintingType = string.Empty;
                //if (barCodePrintingTypeList != null)
                //{
                //    if(barCodePrintingTypeList.Count != 0)
                //    {
                //        var appParameter = (AppParameter) barCodePrintingTypeList[0];
                //        if (appParameter != null)
                //            barCodePrintingType = appParameter.ParameterValue;
                //    }
                //}

                if (string.IsNullOrEmpty(barCodeTemplate))
                    barCodeTemplate = Resources.ConstBarCodeTemplate1;

                PrintBarCode.InializePrinting(_barCodeList, barCodeTemplate);
                //var fileName = Resources.ConstBarcodeExcelFile;
                //var printBarCode = new PrintBarCode();
                //printBarCode.PrintBarcodeHandler(
                //    Application.StartupPath + @"\" + fileName,
                //    string.Empty,
                //    _barCodeList);

                SetFocusToProductList();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void SetFocusToProductList()
        {
            if (dgvProduct.CanFocus)
                dgvProduct.Focus();
        }

        private void ChbInstockOnlyCheckedChanged(object sender, EventArgs e)
        {
            CmdSearchProductClick(sender, e);
        }

        private void EnableActionButton()
        {
            if (_productList.Count == 0)
            {
                btnDelete.Enabled = false;
                btnPrint.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
            }
            SetFocusToProductList();
        }

        private void SetProductInfo()
        {
            if ((_productList.Count == 0) || (dgvProduct.CurrentRow == null))
            {
                ptbProduct.Image = Resources.NoImage;
                UPInLbl.Text = "$ 0.000";
                extraPercentageLbl.Text = "0 %";
                discountLbl.Text = "0 %";
                UPOutLbl.Text = "$ 0.000";
                return;
            }

            var product = _productList[dgvProduct.CurrentRow.Index];
            if (product == null)
                return;

            if (StringHelper.Length(product.PhotoPath) == 0)
                ptbProduct.Image = Resources.NoImage;
            else
                ptbProduct.ImageLocation = product.PhotoPath;
            UPInLbl.Text = "$ " + product.UnitPriceIn.ToString("N3", AppContext.CultureInfo);
            extraPercentageLbl.Text = product.ExtraPercentage.ToString("N0", AppContext.CultureInfo) + " %";
            discountLbl.Text = product.DiscountPercentage.ToString("N0", AppContext.CultureInfo) + " %";
            UPOutLbl.Text = "$ " + product.UnitPriceOut.ToString("N", AppContext.CultureInfo);

            UpdatePrintProduct(product);
        }

        private void UpdatePrintProduct(Product product)
        {
            if (product == null)
                return;

            if (_barCodeList == null)
                return;

            foreach (var barCode in _barCodeList.Where(barCode => barCode.BarCodeValue == product.ProductCode))
            {
                barCode.DisplayStr = product.CategoryStr;

                if (!string.IsNullOrEmpty(product.ForeignCode))
                    barCode.DisplayStr += " (" + product.ForeignCode + ")";
            }
        }

        private void UpdateResultInfo()
        {
            var resultNum = 0;
            var totalProdNum = 0f;
            var totalPriceOut = 0f;
            if (_productList != null)
            {
                foreach (var product in _productList)
                {
                    totalProdNum += product.QtyInStock;
                    totalPriceOut += (product.QtyInStock * product.UnitPriceOut);
                }
                resultNum = _productList.Count;
            }

            var strResultInfo = string.Format(
                "ការសែ្វងរករបស់អ្នកផ្តល់លទ្ឋផលចំនួន {0} រូបត្រូវជា {1} ផលិតផល",
                resultNum.ToString("N0", AppContext.CultureInfo),
                totalProdNum.ToString("N0", AppContext.CultureInfo));

            if (UserService.AllowToPerform(Resources.PermissionViewAllProductInfo))
            {
                strResultInfo += string.Format(
                    "និង {0} ដុល្លារ",
                    totalPriceOut.ToString("N", AppContext.CultureInfo));
            }

            lblResultInfo.Text = strResultInfo;
            rdbPrintAll.Text = 
                "កូដទាំងអស់ (" +
                totalProdNum.ToString("N0", AppContext.CultureInfo) + 
                ")";
        }

        private void BtnPrintMouseEnter(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = Resources.background_9;
        }

        private void BtnNewMouseEnter(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_9;
        }

        private void BtnDeleteMouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Resources.background_9;
        }

        private void BtnPrintMouseLeave(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = null;
        }

        private void BtnNewMouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = null;
        }

        private void BtnDeleteMouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = null;
        }

        private void DgvProductScroll(object sender, ScrollEventArgs e)
        {
            DisplayPartialPicture(
                dgvProduct.DisplayedRowCount(true),
                e.OldValue,
                e.NewValue,
                e.Type);
        }

        private void DisplayPartialPicture(
            int numPicture,
            int startIndex,
            int stopIndex,
            ScrollEventType scrollEventType)
        {
            try
            {
                if ((scrollEventType == ScrollEventType.SmallDecrement) ||
                    (scrollEventType == ScrollEventType.LargeDecrement))
                {
                    var tmpIndex = startIndex;
                    startIndex = stopIndex;
                    stopIndex = tmpIndex;

                    for (var counter = startIndex + numPicture; counter < stopIndex + numPicture; counter++)
                    {
                        if (counter < _productList.Count)
                            _productList[counter].ProductPic = null;
                    }

                    for (var counter = startIndex; counter < startIndex + numPicture; counter++)
                        SetProductPicture(_productList[counter]);
                }
                else
                {
                    for (var counter = startIndex; counter < stopIndex; counter++)
                    {
                        _productList[counter].ProductPic = null;
                        if (counter >= numPicture)
                            break;
                    }

                    for (var counter = stopIndex; counter < stopIndex + numPicture; counter++)
                        SetProductPicture(_productList[counter]);
                }
                dgvProduct.Refresh();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private static void SetProductPicture(Product product)
        {
            if (product.ProductPic != null)
                return;

            product.ProductPic = Resources.NoImage;
            if (String.IsNullOrEmpty(product.PhotoPath)) 
                return;

            var fileInfo = new FileInfo(product.PhotoPath);
            product.ProductPic = fileInfo.Exists ? new Bitmap(product.PhotoPath) : Resources.NoImage;

            //var fileInfo = new FileInfo(product.PhotoPath);
            //if (!fileInfo.Exists) 
            //    return;

            //var productPicture = Image.FromFile(product.PhotoPath);
            //var thumbnailPicture =
            //    productPicture.GetThumbnailImage(
            //        100,
            //        100,
            //        null,
            //        new IntPtr());

            //product.ProductPic = thumbnailPicture;
        }

        private void UpdateSelectedProduct(Product curProduct, float preQtyInStock)
        {
            if (curProduct == null)
                throw new ArgumentNullException("curProduct", Resources.MsgInvalidProduct);

            try
            {
                bool isIncremented;
                if ((curProduct.QtyInStock - preQtyInStock) < 0)
                {
                    isIncremented = false;
                    for (var counter = 0; counter < _barCodeList.Count; counter++)
                    {
                        if (curProduct.ProductCode != _barCodeList[counter].BarCodeValue) 
                            continue;

                        if (_barCodeList.Count >= preQtyInStock)
                            _barCodeList.RemoveAt(counter);

                        counter -= 1;
                        preQtyInStock -= 1;
                        if ((curProduct.QtyInStock - preQtyInStock) == 0)
                            break;
                    }
                }
                else
                {
                    isIncremented = true;
                    if (String.IsNullOrEmpty(curProduct.PublicQty))
                        return;

                    for (var counter = 0; counter < (curProduct.QtyInStock - preQtyInStock); counter++)
                    {
                        var barCode = 
                            new BarCode
                            {
                                BarCodeValue = curProduct.ProductCode,
                                DisplayStr = curProduct.CategoryStr,
                                UnitPrice = "$ " + curProduct.UnitPriceOut.ToString("N", AppContext.CultureInfo)
                            };

                        if (string.IsNullOrEmpty(curProduct.ForeignCode))
                            barCode.DisplayStr += " (" + curProduct.ForeignCode + ")";
                        _barCodeList.Add(barCode);
                    }
                }

                if (!String.IsNullOrEmpty(curProduct.PublicQty))
                {
                    var tmpQty = curProduct.PublicQty;
                    var printedQty = float.Parse(tmpQty.Split('/')[0]);

                    if (isIncremented)
                        printedQty += (curProduct.QtyInStock - preQtyInStock);
                    else
                    {
                        if (printedQty > _barCodeList.Count)
                            printedQty = _barCodeList.Count;
                    }

                    curProduct.PublicQty =
                        printedQty + " / " + curProduct.QtyInStock;
                }

                rdbPrintSelected.Text = "កូដជ្រើសរើស (" + _barCodeList.Count.ToString(
                                                              "N0", AppContext.CultureInfo) + ")";
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DgvProductCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null)
                return;

            if (dgvProduct.Columns[e.ColumnIndex].Name != "PrintCheck")
                return;

            if (dgvProduct.CurrentRow == null)
                return;

            var qtyInStock = Int32.Parse(dgvProduct.CurrentRow.Cells["QtyInStock"].Value.ToString());
            if (!_productList[dgvProduct.CurrentRow.Index].PrintCheck)
                DoPreBarCodePrinting(
                    0,
                    qtyInStock,
                    qtyInStock,
                    true,
                    true);
            else
            {
                var tmpQty =
                    dgvProduct.CurrentRow.Cells["PublicQty"].Value.ToString();
                if (String.IsNullOrEmpty(tmpQty))
                    return;

                var printedQty = float.Parse(tmpQty.Split('/')[0]);
                DoPreBarCodePrinting(
                    printedQty,
                    printedQty,
                    qtyInStock,
                    false,
                    true);
            }
        }

        private void DgvProductKeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;

            if (_productList.Count == 0)
                return;

            try
            {
                if ((e.KeyCode == Keys.Add) || (e.KeyCode == Keys.Subtract))
                {
                    if (dgvProduct.CurrentRow == null)
                        return;

                    if (!_productList[dgvProduct.CurrentRow.Index].PrintCheck)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                if (dgvProduct.CurrentRow != null)
                {
                    var tmpQty = dgvProduct.CurrentRow.Cells["PublicQty"].Value == null ? "0" : dgvProduct.CurrentRow.Cells["PublicQty"].Value.ToString();
                    if (String.IsNullOrEmpty(tmpQty))
                        return;

                    var printedQty = float.Parse(tmpQty.Split('/')[0]);
                    var totalQty = _productList[dgvProduct.CurrentRow.Index].QtyInStock;
                    int selectedIndex;
                    switch (e.KeyCode)
                    {
                        case Keys.Add:
                            if (printedQty < totalQty)
                                DoPreBarCodePrinting(
                                    printedQty,
                                    1,
                                    totalQty,
                                    true,
                                    false);
                            break;
                        //case Keys.A:
                        //    if (printedQty < totalQty)
                        //        DoPreBarCodePrinting(
                        //            printedQty,
                        //            1,
                        //            totalQty,
                        //            true,
                        //            false);
                        //    break;
                        case Keys.Subtract:
                            if (printedQty > 1)
                                DoPreBarCodePrinting(
                                    printedQty,
                                    1,
                                    totalQty,
                                    false,
                                    false);
                            break;
                        //case Keys.B:
                        //    if (printedQty > 1)
                        //        DoPreBarCodePrinting(
                        //            printedQty,
                        //            1,
                        //            totalQty,
                        //            false,
                        //            false);
                        //    break;
                        case Keys.Up:
                            selectedIndex = dgvProduct.SelectedRows[0].Index;
                            if (selectedIndex > 0)
                            {
                                selectedIndex -= 1;
                                dgvProduct.Rows[selectedIndex].Selected = true;
                            }
                            break;
                        case Keys.Down:
                            selectedIndex = dgvProduct.SelectedRows[0].Index;
                            if (selectedIndex < (_productList.Count - 1))
                            {
                                selectedIndex += 1;
                                dgvProduct.Rows[selectedIndex].Selected = true;
                            }
                            break;
                        case Keys.Escape:
                            e.Handled = true;
                            break;
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

        private void DoPreBarCodePrinting(
            float currentPrintedQty,
            float requestedQty,
            float totalQty,
            bool requestPrinting,
            bool setPrintingStatus)
        {
            if (dgvProduct.CurrentRow == null)
                return;

            if (requestPrinting)
            {                
                currentPrintedQty += requestedQty;
                var barCode = new BarCode();
                for (var qtyCounter = 0; qtyCounter < requestedQty; qtyCounter++)
                {
                    barCode =
                        new BarCode
                        {
                            BarCodeValue = _productList[dgvProduct.CurrentRow.Index].ProductCode,
                            DisplayStr =
                                _productList[dgvProduct.CurrentRow.Index].CategoryStr,
                            AdditionalStr = (currentPrintedQty.ToString("N0") + " / " + totalQty.ToString("N0")),
                            UnitPrice = "$ " + (_productList[dgvProduct.CurrentRow.Index]).UnitPriceOut.ToString("N", AppContext.CultureInfo),
                            Description = _productList[dgvProduct.CurrentRow.Index].Description
                        };

                    var foreignCode = _productList[dgvProduct.CurrentRow.Index].ForeignCode;
                    if (!string.IsNullOrEmpty(foreignCode))
                        barCode.DisplayStr += " (" + foreignCode + ")";

                    if (_barCodeList.IndexOf(barCode) == -1)
                        _barCodeList.Add(barCode);
                }

                var previousPrintedQty = currentPrintedQty - requestedQty;
                var barCodeValue = _productList[dgvProduct.CurrentRow.Index].ProductCode;
                for (var counter = 0; (counter < _barCodeList.Count) && (previousPrintedQty != 0); counter++)
                {
                    if (barCodeValue != _barCodeList[counter].BarCodeValue)
                        continue;

                    _barCodeList[counter] = barCode;
                    previousPrintedQty -= 1;
                }
            }
            else
            {
                currentPrintedQty -= requestedQty;
                var tmpQty = requestedQty;
                for (var counter = 0; counter < _barCodeList.Count; counter++)
                {
                    if (dgvProduct.CurrentRow.Cells["ProductCode"].Value.ToString() !=
                        _barCodeList[counter].BarCodeValue) 
                        continue;
                    if (tmpQty != 0)
                    {
                        _barCodeList.RemoveAt(counter);
                        tmpQty -= 1;
                        counter -= 1;
                    }
                    else if (currentPrintedQty != 0)
                        _barCodeList[counter].AdditionalStr =
                            currentPrintedQty.ToString("N0") +
                            " / " +
                            totalQty.ToString("N0");
                    else
                        _barCodeList[counter].AdditionalStr = string.Empty;
                }
            }

            if (currentPrintedQty != 0)
                _productList[dgvProduct.CurrentRow.Index].PublicQty =
                    currentPrintedQty.ToString("N0") +
                    " / " +
                    totalQty.ToString("N0");
            else
                _productList[dgvProduct.CurrentRow.Index].PublicQty = string.Empty;

            if (setPrintingStatus)
                _productList[dgvProduct.CurrentRow.Index].PrintCheck = requestPrinting;
            rdbPrintSelected.Text = "កូដជ្រើសរើស (" + _barCodeList.Count.ToString(
                                                          "N0", AppContext.CultureInfo) + ")";
            dgvProduct.Refresh();
        }

        private void DoPrintProduct()
        {
            try
            {
                if (!UserService.AllowToPerform(Resources.PermissionPrintProductCode))
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

                //Generate product to print
                var selectedProductList = new BindingList<Product>();
                foreach (var product in
                    _productList.Where(product => product != null).Where(product => product.PrintCheck))
                {
                    selectedProductList.Add(product);
                }

                PrintProduct.InializePrinting(selectedProductList);
                SetFocusToProductList();
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        //private void btnImportExport_MouseEnter(object sender, EventArgs e)
        //{
        //    btnImportExport.BackgroundImage = Resources.background_9;
        //}

        //private void btnImportExport_MouseLeave(object sender, EventArgs e)
        //{
        //    btnImportExport.BackgroundImage = null;
        //}

        //private void tsmExport_Click(object sender, EventArgs e)
        //{
        //    DoImportExportProducts(false);
        //}

        //private void tsmImport_Click(object sender, EventArgs e)
        //{
        //    DoImportExportProducts(true);
        //}

        //private void btnImportExport_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (!UserService.AllowToPerform(Resources.PermissionImportExportProduct))
        //    {
        //        string briefMsg, detailMsg;
        //        briefMsg = "អំពី​សិទ្ឋិ​ប្រើ​ប្រាស់";
        //        detailMsg = Resources.MsgUserPermissionDeny;
        //        using (ExtendedMessageBox frmMessageBox = new ExtendedMessageBox())
        //        {
        //            frmMessageBox.BriefMsgStr = briefMsg;
        //            frmMessageBox.DetailMsgStr = detailMsg;
        //            frmMessageBox.IsCanceledOnly = true;
        //            frmMessageBox.ShowDialog(this);
        //            return;
        //        }
        //    }
        //    cmsImportExport.Show(
        //        e.X + btnImportExport.Location.X + pnlBodyRight.Location.X,
        //        e.Y + btnImportExport.Location.Y + 113);
        //}

        //private void DoImportExportProducts(bool isImported)
        //{
        //    try
        //    {
        //        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
        //        {
        //            folderBrowserDialog.ShowNewFolderButton = false;
        //            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                if (_ProductService == null)
        //                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

        //                if (isImported)
        //                {
        //                    _ProductService.ImportProductFromXml(
        //                        folderBrowserDialog.SelectedPath,
        //                        "ProductList.xml");

        //                    IListToBindingList(
        //                        _ProductService.GetCatalogs(chbInstockOnly.Checked));
        //                }
        //                else
        //                {
        //                    IList listProduct2Export = new List<Product>();
        //                    foreach (Product product in _ProductList)
        //                    {
        //                        if (product.PrintCheck)
        //                            listProduct2Export.Add(product);
        //                    }

        //                    _ProductService.ExportProductToXml(
        //                        listProduct2Export,
        //                        folderBrowserDialog.SelectedPath,
        //                        "ProductList.xml");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        ExtendedMessageBox.UnknownErrorMessage(
        //            Resources.MsgCaptionUnknownError,
        //            exception.Message);
        //    }
        //}

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}