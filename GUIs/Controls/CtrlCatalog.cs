using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUI;
using EzPos.GUIs.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Utility;

namespace EzPos.Control
{
    public partial class CtrlCatalog : UserControl
    {
        private readonly List<BarCode> _BarCodeList = new List<BarCode>();
        private CommonService _CommonService;
        private BindingList<Product> _ProductList;
        private ProductService _ProductService;

        public CtrlCatalog()
        {
            InitializeComponent();
        }

        public ProductService ProductService
        {
            set { _ProductService = value; }
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
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
                var searchCriteria = new List<string>
                                         {
                                             "ParameterTypeID IN (" +
                                             Resources.AppParamCategory + ", " +
                                             Resources.AppParamMark + "," +
                                             Resources.AppParamColor + ")"
                                         };
                var objectList = _CommonService.GetAppParameters(searchCriteria);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbCategory,
                    objectList,
                    Int32.Parse(Resources.AppParamCategory, AppContext.CultureInfo),
                    false);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbMark,
                    objectList,
                    Int32.Parse(Resources.AppParamMark, AppContext.CultureInfo),
                    false);

                _CommonService.PopAppParamExtendedCombobox(
                    ref cmbColor,
                    objectList,
                    Int32.Parse(Resources.AppParamColor, AppContext.CultureInfo),
                    false);

                IListToBindingList(
                    _ProductService.GetCatalogs(chbInstockOnly.Checked));
            }
        }

        private void CtrlCatalog_Load(object sender, EventArgs e)
        {
            try
            {
                if (_ProductService == null)
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                if (!UserService.AllowToPerform(Resources.PermissionViewAllProductInfo))
                {
                    UPInLbl.Visible = false;
                    extraPercentageLbl.Visible = false;
                }

                InitializeProductList();

                ThreadStart threadStart = UpdateControlContent;
                var thread = new Thread(threadStart) {IsBackground = true};
                thread.Start();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvProduct_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ExtendedMessageBox.UnknownErrorMessage(
                Resources.MsgCaptionUnknownError,
                e.Exception.Message);
        }

        private void InitializeProductList()
        {
            try
            {
                if (_ProductList == null)
                    _ProductList = new BindingList<Product>();

                dgvProduct.DataSource = _ProductList;
                dgvProduct.Columns["PrintCheck"].DisplayIndex = 0;
                dgvProduct.Columns["PublicQty"].DisplayIndex = 1;
                dgvProduct.Columns["ProductPic"].DisplayIndex = 2;
                dgvProduct.Columns["DisplayName"].DisplayIndex = 3;
                dgvProduct.Columns["Description"].DisplayIndex = 4;
                dgvProduct.Columns["QtyInStock"].DisplayIndex = 5;
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            SetProductInfo();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAddProduct))
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
            ProductManagement(Resources.OperationRequestInsert);
        }

        private void ProductManagement(IEquatable<string> operationRequest)
        {
            try
            {
                using (var frmCatalog = new FrmCatalog())
                {
                    float preQtyInStock = 0;
                    if (_ProductList.Count != 0)
                        preQtyInStock = (_ProductList[dgvProduct.CurrentRow.Index]).QtyInStock;
                    if (operationRequest.Equals(Resources.OperationRequestUpdate))
                        frmCatalog.Product = _ProductList[dgvProduct.CurrentRow.Index];

                    if (frmCatalog.ShowDialog(this) == DialogResult.OK)
                    {
                        try
                        {
                            if (frmCatalog.Product == null)
                            {
                                IListToBindingList(
                                    _ProductService.GetCatalogs(chbInstockOnly.Checked));
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
                                        for (int counter = 0; counter < _ProductList.Count; counter++)
                                        {
                                            if (_ProductList[counter].ProductID == frmCatalog.Product.ProductID)
                                                _ProductList.RemoveAt(counter);
                                        }
                                    }
                                }
                                else
                                {
                                    if (frmCatalog.Product.QtyInStock == 0)
                                        _ProductList.Add(frmCatalog.Product);
                                }
                            }
                            dgvProduct.Refresh();
                            SetProductInfo();

                            UpdateResultInfo();
                            EnableActionButton();
                        }
                        catch (Exception exception)
                        {
                            ExtendedMessageBox.UnknownErrorMessage(
                                Resources.MsgCaptionUnknownError,
                                exception.Message);
                        }
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

        private void dgvProduct_DoubleClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionEditProduct))
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

            ProductManagement(Resources.OperationRequestUpdate);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string briefMsg, detailMsg;
            if (!UserService.AllowToPerform(Resources.PermissionDeleteProduct))
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
                //ExtendedMessageBox.InformMessage(Resources.MsgUserPermissionDeny);
                //return;
            }

            //string briefMsg, detailMsg;
            briefMsg = "អំពីការលុប";
            detailMsg = Resources.MsgOperationRequestDelete + "\n" +
                        dgvProduct.CurrentRow.Cells["DisplayName"].Value + " ?";
            using (var frmMessageBox = new ExtendedMessageBox())
            {
                frmMessageBox.BriefMsgStr = briefMsg;
                frmMessageBox.DetailMsgStr = detailMsg;
                if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            try
            {
                _ProductService.ManageProduct(_ProductList[dgvProduct.CurrentRow.Index],
                                             Resources.OperationRequestDelete);

                _ProductList.RemoveAt(dgvProduct.CurrentRow.Index);
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

        private void cmdSearchProduct_Click(object sender, EventArgs e)
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
                    searchCriteria.Add("ProductCode|" + StringHelper.Right("000000000" + txtProductCode.Text, 9));

                _ProductList.Clear();
                IListToBindingList(
                    _ProductService.GetCatalogs(searchCriteria, chbInstockOnly.Checked));
                SetFocusToProductList();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            cmbMark.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            txtProductCode.Text = string.Empty;
            cmdSearchProduct_Click(sender, e);
            SetFocusToProductList();
        }

        private void IListToBindingList(IList productList)
        {
            if (productList == null)
                throw new ArgumentNullException("productList", "Product List");

            if (_ProductList == null)
                return;

            try
            {
                _ProductList.Clear();
                foreach (Product product in productList)
                {
                    foreach (var barCode in _BarCodeList)
                    {
                        if (product.ProductCode != barCode.BarCodeValue) 
                            continue;

                        product.PrintCheck = true;
                        product.PublicQty = barCode.AdditionalStr;
                        break;
                    }
                    _ProductList.Add(product);
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
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void chbDisplayPicture_CheckedChanged(object sender, EventArgs e)
        {
            cmdSearchProduct_Click(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UserService.AllowToPerform(Resources.PermissionPrintProductCode))
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

                if (rdbProduct.Checked)
                {
                    DoPrintProduct();
                    return;
                }
                
                if (rdbPrintAll.Checked)
                {
                    _BarCodeList.Clear();
                    for (int counter = 0; counter < _ProductList.Count; counter++)
                    {
                        for (int qtyCounter = 0; qtyCounter < (_ProductList[counter]).QtyInStock; qtyCounter++)
                        {
                            var barCode = new BarCode
                                              {
                                                  BarCodeValue = (_ProductList[counter]).ProductCode,
                                                  DisplayStr =
                                                      (_ProductList[counter]).UnitPriceOut.ToString("N",
                                                                                                    AppContext.
                                                                                                        CultureInfo)
                                              };
                            _BarCodeList.Add(barCode);
                        }
                        (_ProductList[counter]).PrintCheck = true;
                        (_ProductList[counter]).PublicQty =
                            (_ProductList[counter]).QtyInStock +
                            " / " +
                            (_ProductList[counter]).QtyInStock;
                    }
                    dgvProduct.Refresh();
                }

                PrintBarCode.InializePrinting(_BarCodeList);
                SetFocusToProductList();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void SetFocusToProductList()
        {
            if (dgvProduct.CanFocus)
                dgvProduct.Focus();
        }

        private void chbInstockOnly_CheckedChanged(object sender, EventArgs e)
        {
            cmdSearchProduct_Click(sender, e);
        }

        private void EnableActionButton()
        {
            if (_ProductList.Count == 0)
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
            if ((_ProductList.Count == 0) || (dgvProduct.CurrentRow == null))
            {
                ptbProduct.Image = Resources.NoImage;
                UPInLbl.Text = "$ 0.00";
                extraPercentageLbl.Text = "0 %";
                discountLbl.Text = "0 %";
                UPOutLbl.Text = "$ 0.00";
                return;
            }

            Product product = _ProductList[dgvProduct.CurrentRow.Index];
            if (product == null)
                return;

            if (StringHelper.Length(product.PhotoPath) == 0)
                ptbProduct.Image = Resources.NoImage;
            else
                ptbProduct.ImageLocation = product.PhotoPath;
            UPInLbl.Text = "$ " + product.UnitPriceIn.ToString("N", AppContext.CultureInfo);
            extraPercentageLbl.Text = product.ExtraPercentage.ToString("N0", AppContext.CultureInfo) + " %";
            discountLbl.Text = product.DiscountPercentage.ToString("N0", AppContext.CultureInfo) + " %";
            UPOutLbl.Text = "$ " + product.UnitPriceOut.ToString("N", AppContext.CultureInfo);

            UpdatePrintProduct(product);
        }

        private void UpdatePrintProduct(Product product)
        {
            if (product == null)
                return;

            if (_BarCodeList == null)
                return;

            foreach (BarCode barCode in _BarCodeList)
            {
                if (barCode.BarCodeValue == product.ProductCode)
                    barCode.DisplayStr = product.UnitPriceOut.ToString("N", AppContext.CultureInfo);
            }
        }

        private void UpdateResultInfo()
        {
            int resultNum = 0;
            float totalProdNum = 0;
            if (_ProductList != null)
            {
                foreach (Product product in _ProductList)
                    totalProdNum += product.QtyInStock;
                resultNum = _ProductList.Count;
            }

            string strResultInfo = string.Format(
                "ការសែ្វងរករបស់អ្នកផ្តល់លទ្ឋផលចំនួន {0} រូបត្រូវជា {1} ផលិតផល",
                resultNum.ToString("N0", AppContext.CultureInfo),
                totalProdNum.ToString("N0", AppContext.CultureInfo));
            lblResultInfo.Text = strResultInfo;
            rdbPrintAll.Text = "កូដទាំងអស់ (" +
                               totalProdNum.ToString("N0", AppContext.CultureInfo) + ")";
        }

        private void btnPrint_MouseEnter(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = Resources.background_9;
        }

        private void btnNew_MouseEnter(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = Resources.background_9;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = Resources.background_9;
        }

        private void btnPrint_MouseLeave(object sender, EventArgs e)
        {
            btnPrint.BackgroundImage = null;
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = null;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = null;
        }

        private void dgvProduct_Scroll(object sender, ScrollEventArgs e)
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
                    int tmpIndex = startIndex;
                    startIndex = stopIndex;
                    stopIndex = tmpIndex;

                    for (int counter = startIndex + numPicture; counter < stopIndex + numPicture; counter++)
                    {
                        if (counter < _ProductList.Count)
                            _ProductList[counter].ProductPic = null;
                    }

                    for (int counter = startIndex; counter < startIndex + numPicture; counter++)
                        SetProductPicture(_ProductList[counter]);
                }
                else
                {
                    for (int counter = startIndex; counter < stopIndex; counter++)
                    {
                        _ProductList[counter].ProductPic = null;
                        if (counter >= numPicture)
                            break;
                    }

                    for (int counter = stopIndex; counter < stopIndex + numPicture; counter++)
                        SetProductPicture(_ProductList[counter]);
                }
                dgvProduct.Refresh();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private static void SetProductPicture(Product product)
        {
            if (product.ProductPic != null)
                return;

            if (!String.IsNullOrEmpty(product.PhotoPath))
            {
                var fileInfo = new FileInfo(product.PhotoPath);
                product.ProductPic = fileInfo.Exists ? new Bitmap(product.PhotoPath) : Resources.NoImage;
            }
            else
                product.ProductPic = Resources.NoImage;
        }

        private void UpdateSelectedProduct(Product curProduct, float preQtyInStock)
        {
            if (curProduct == null)
                throw new ArgumentNullException("curProduct", "Current Product");

            float tmpCounter = 0;
            try
            {
                bool isIncremented;
                if ((curProduct.QtyInStock - preQtyInStock) < 0)
                {
                    isIncremented = false;
                    for (var counter = 0; counter < _BarCodeList.Count; counter++)
                    {
                        if (curProduct.ProductCode != _BarCodeList[counter].BarCodeValue) 
                            continue;

                        if (_BarCodeList.Count >= preQtyInStock)
                            _BarCodeList.RemoveAt(counter);
                        else
                            tmpCounter += 1;

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
                        var barCode = new BarCode
                                          {
                                              BarCodeValue = curProduct.ProductCode,
                                              DisplayStr = curProduct.UnitPriceOut.ToString("N", AppContext.CultureInfo)
                                          };
                        _BarCodeList.Add(barCode);
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
                        if (printedQty > _BarCodeList.Count)
                            printedQty = _BarCodeList.Count;
                    }

                    curProduct.PublicQty =
                        printedQty + " / " + curProduct.QtyInStock;
                }

                rdbPrintSelected.Text = "កូដជ្រើសរើស (" + _BarCodeList.Count.ToString(
                                                              "N0", AppContext.CultureInfo) + ")";
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null)
                return;

            if (dgvProduct.Columns[e.ColumnIndex].Name != "PrintCheck")
                return;

            if (dgvProduct.CurrentRow == null)
                return;

            int qtyInStock = Int32.Parse(dgvProduct.CurrentRow.Cells["QtyInStock"].Value.ToString());
            if (!_ProductList[dgvProduct.CurrentRow.Index].PrintCheck)
                DoPreBarCodePrinting(
                    0,
                    qtyInStock,
                    qtyInStock,
                    true,
                    true);
            else
            {
                string tmpQty =
                    dgvProduct.CurrentRow.Cells["PublicQty"].Value.ToString();
                if (String.IsNullOrEmpty(tmpQty))
                    return;

                float printedQty = float.Parse(tmpQty.Split('/')[0]);
                DoPreBarCodePrinting(
                    printedQty,
                    printedQty,
                    qtyInStock,
                    false,
                    true);
            }
        }

        private void dgvProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;

            if (_ProductList.Count == 0)
                return;

            try
            {
                if ((e.KeyCode == Keys.Add) || (e.KeyCode == Keys.Subtract))
                {
                    if (!_ProductList[dgvProduct.CurrentRow.Index].PrintCheck)
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
                    var totalQty = _ProductList[dgvProduct.CurrentRow.Index].QtyInStock;
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
                        case Keys.Subtract:
                            if (printedQty > 1)
                                DoPreBarCodePrinting(
                                    printedQty,
                                    1,
                                    totalQty,
                                    false,
                                    false);
                            break;
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
                            if (selectedIndex < (_ProductList.Count - 1))
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
                ExtendedMessageBox.UnknownErrorMessage(
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
            if (requestPrinting)
            {
                currentPrintedQty += requestedQty;
                for (var qtyCounter = 0; qtyCounter < requestedQty; qtyCounter++)
                {
                    var barCode = new BarCode
                                      {
                                          BarCodeValue = _ProductList[dgvProduct.CurrentRow.Index].ProductCode,
                                          DisplayStr = _ProductList[dgvProduct.CurrentRow.Index].UnitPriceOut.ToString(
                                              "N",
                                              AppContext.CultureInfo),
                                          AdditionalStr = (currentPrintedQty.ToString("N0") +
                                                           " / " +
                                                           totalQty.ToString("N0"))
                                      };

                    if (_BarCodeList.IndexOf(barCode) == -1)
                        _BarCodeList.Add(barCode);
                }
            }
            else
            {
                currentPrintedQty -= requestedQty;
                float tmpQty = requestedQty;
                for (int counter = 0; counter < _BarCodeList.Count; counter++)
                {
                    if (dgvProduct.CurrentRow.Cells["ProductCode"].Value.ToString() ==
                        _BarCodeList[counter].BarCodeValue)
                    {
                        if (tmpQty != 0)
                        {
                            _BarCodeList.RemoveAt(counter);
                            tmpQty -= 1;
                            counter -= 1;
                        }
                        else if (currentPrintedQty != 0)
                            _BarCodeList[counter].AdditionalStr =
                                currentPrintedQty.ToString("N0") +
                                " / " +
                                totalQty.ToString("N0");
                        else
                            _BarCodeList[counter].AdditionalStr = string.Empty;
                    }
                }
            }

            if (currentPrintedQty != 0)
                _ProductList[dgvProduct.CurrentRow.Index].PublicQty =
                    currentPrintedQty.ToString("N0") +
                    " / " +
                    totalQty.ToString("N0");
            else
                _ProductList[dgvProduct.CurrentRow.Index].PublicQty = string.Empty;

            if (setPrintingStatus)
                _ProductList[dgvProduct.CurrentRow.Index].PrintCheck = requestPrinting;
            rdbPrintSelected.Text = "កូដជ្រើសរើស (" + _BarCodeList.Count.ToString(
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
                    using (var frmMessageBox = new ExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                PrintProduct.InializePrinting(_ProductList);
                SetFocusToProductList();
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
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