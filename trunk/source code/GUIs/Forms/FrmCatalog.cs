using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Product;

namespace EzPos.GUIs.Forms
{
    public partial class FrmCatalog : Form
    {
        private CommonService _commonService;
        private float _defaultUnitPriceOut;
        private bool _isFromSale;
        private bool _isModified;
        private Product _product;
        private ProductService _productService;
        private BindingList<Product> _productList;

        public FrmCatalog()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _commonService = value; }
        }

        public ProductService ProductService
        {
            set { _productService = value; }
        }

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public bool IsFromSale
        {
            get { return _isFromSale; }
            set { _isFromSale = value; }
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            _isModified = modifyStatus;
            btnSave.Enabled = modifyStatus;
        }

        private void FrmProductAdvance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isFromSale)
                return;

            if ((DialogResult == DialogResult.Cancel) && (_isModified))
            {
                const string briefMsg = "អំពីការបោះបង់";
                var detailMsg = Resources.MsgOperationRequestCancel;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if (_isModified) 
                return;

            DialogResult = DialogResult.Cancel;
        }

        private void ModificationHandler(object sender, EventArgs e)
        {
            GenerateProductCode();

            var waitStatus = false;
            if (sender.GetType() == typeof (TextBox))
            {
                if (((TextBox) sender).Name == "txtUPOut")
                    waitStatus = true;
            }
            CalculateProductCost(waitStatus);

            SetModifydStatus(true);
        }

        private void CmbCategoryEnter(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndexChanged += ModificationHandler;
            cmbCategory.TextChanged += ModificationHandler;
        }

        private void CmbMarkEnter(object sender, EventArgs e)
        {
            cmbMark.SelectedIndexChanged += ModificationHandler;
            cmbMark.TextChanged += ModificationHandler;
        }

        private void CmbColorEnter(object sender, EventArgs e)
        {
            cmbColor.SelectedIndexChanged += ModificationHandler;
            cmbColor.TextChanged += ModificationHandler;
        }

        private void TxtUpInEnter(object sender, EventArgs e)
        {
            txtUPIn.TextChanged += ModificationHandler;
        }

        private void TxtExtraPercentageEnter(object sender, EventArgs e)
        {
            txtExtraPercentage.TextChanged += ModificationHandler;
        }

        private void TxtUpOutEnter(object sender, EventArgs e)
        {
            txtUPOut.TextChanged += ModificationHandler;
        }

        private void TxtDiscountEnter(object sender, EventArgs e)
        {
            txtDiscount.TextChanged += ModificationHandler;
        }

        private void TxtPhotoPathTextChanged(object sender, EventArgs e)
        {
            ModificationHandler(sender, e);
        }

        private void CmbCategoryLeave(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndexChanged -= ModificationHandler;
            cmbCategory.TextChanged -= ModificationHandler;
        }

        private void CmbMarkLeave(object sender, EventArgs e)
        {
            cmbMark.SelectedIndexChanged -= ModificationHandler;
            cmbMark.TextChanged -= ModificationHandler;
        }

        private void CmbColorLeave(object sender, EventArgs e)
        {
            cmbColor.SelectedIndexChanged -= ModificationHandler;
            cmbColor.TextChanged -= ModificationHandler;
        }

        private void TxtUpInLeave(object sender, EventArgs e)
        {
            txtUPIn.TextChanged -= ModificationHandler;
            try
            {
                txtUPIn.Text = float.Parse(txtUPIn.Text).ToString("N3", AppContext.CultureInfo);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void TxtExtraPercentageLeave(object sender, EventArgs e)
        {
            txtExtraPercentage.TextChanged -= ModificationHandler;
        }

        private void TxtUpOutLeave(object sender, EventArgs e)
        {
            if (txtUPOut.Text.Length == 0)
                txtUPOut.Text = "0.000";

            txtUPOut.TextChanged -= ModificationHandler;
        }

        private void TxtDiscountLeave(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Length == 0)
                txtDiscount.Text = "0.000";

            txtDiscount.TextChanged -= ModificationHandler;
        }

        private void TxtQtyInStockLeave(object sender, EventArgs e)
        {
            txtQtyInStock.TextChanged -= ModificationHandler;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            if (_productService == null)
                _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            if (_commonService == null)
                _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

            if (!UserService.AllowToPerform(Resources.PermissionViewAllProductInfo))
            {
                txtUPIn.Visible = false;
                txtExtraPercentage.Visible = false;
            }

            if (!UserService.AllowToPerform(Resources.PermissionModifyProductQuantity))
                txtQtyInStock.Enabled = false;

            _defaultUnitPriceOut = 0;

            var searchCriteria = 
                new List<string>
                {
                    "ParameterTypeID IN (" +
                    Resources.AppParamProductCodeLength + ", " +
                    Resources.AppParamCategory + ", " +
                    Resources.AppParamMark + ", " +
                    Resources.AppParamColor + ", " +
                    Resources.AppParamSize + ")"
                };
            var objectList = _commonService.GetAppParameters(searchCriteria);
            var productCodeLengthList = 
                _commonService.GetAppParametersByType(
                    objectList, 
                    Int32.Parse(Resources.AppParamProductCodeLength));
            if (productCodeLengthList.Count != 0)
            {
                var productCodeLength = productCodeLengthList[0] as AppParameter;
                if (productCodeLength != null)
                {
                    int codeLength;
                    Int32.TryParse(
                        (string.IsNullOrEmpty(productCodeLength.ParameterLabel) ?
                        string.Empty :
                        productCodeLength.ParameterLabel),
                        out codeLength);

                    txtForeignCode.MaxLength = codeLength;
                }
            }

            _commonService.PopAppParamExtendedCombobox(
                ref cmbCategory, objectList, int.Parse(Resources.AppParamCategory), true);
            cmbCategory.SelectedValue = 364;

            _commonService.PopAppParamExtendedCombobox(
                ref cmbMark, objectList, int.Parse(Resources.AppParamMark), true);

            _commonService.PopAppParamExtendedCombobox(
                ref cmbColor, objectList, int.Parse(Resources.AppParamColor), true);

            _commonService.PopAppParamExtendedCombobox(
                ref cmbSize, objectList, int.Parse(Resources.AppParamSize), true);

            _productList = new BindingList<Product>();
            cmbProduct.DataSource = _productList;
            cmbProduct.DisplayMember = Product.CONST_FOREIGN_CODE;
            cmbProduct.ValueMember = Product.CONST_PRODUCT_ID;
            cmbProduct.SelectedIndex = -1;

            SetProductInfo(_product);

            if (_isFromSale)
            {
                SetEnableToComponents(false);
                return;
            }

            txtPhotoPath.TextChanged += TxtPhotoPathTextChanged;
        }

        private void SetProductInfo(Product product)
        {
            if (product == null)
                return;

            txtForeignCode.Text = product.ForeignCode;
            lblProductName.Text = product.ProductName + "\r" + product.ProductCode;
            cmbCategory.SelectedValue = product.CategoryID;
            cmbMark.SelectedValue = product.MarkID;
            cmbColor.SelectedValue = product.ColorID;
            cmbSize.SelectedValue = product.SizeID;
            txtDescription.Text = product.Description;
            txtUPIn.Text = product.UnitPriceIn.ToString("N3", AppContext.CultureInfo);
            txtExtraPercentage.Text = product.ExtraPercentage.ToString("N0", AppContext.CultureInfo);
            txtDiscount.Text = product.DiscountPercentage.ToString("N0", AppContext.CultureInfo);
            txtUPOut.Text = product.UnitPriceOut.ToString("N", AppContext.CultureInfo);
            _defaultUnitPriceOut = product.UnitPriceOut;
            txtQtyInStock.Text = product.QtyInStock.ToString("N0", AppContext.CultureInfo);
            txtPhotoPath.Text = product.PhotoPath;
            if (product.PhotoPath == null)
                ptbProduct.Image = Resources.NoImage;
            else
                ptbProduct.ImageLocation = product.PhotoPath;
        }

        public void GenerateProductCode()
        {
            if (cmbCategory.SelectedItem == null)
                return;
            if (cmbMark.SelectedItem == null)
                return;
            if (cmbColor.SelectedItem == null)
                return;

            lblProductName.Text =
                cmbCategory.Text + @" \ " +
                cmbMark.Text;

            if (_product == null) 
                return;

            if (!String.IsNullOrEmpty(_product.ProductCode))
                lblProductName.Text += 
                    "\r" +
                    _product.ProductCode;
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if ((cmbCategory.SelectedIndex == -1) || (cmbMark.SelectedIndex == -1)
                    || (cmbColor.SelectedIndex == -1) || (cmbSize.SelectedIndex == -1))
                {
                    const string briefMsg = "អំពីពត៌មាន";
                    var detailMsg = Resources.MsgInvalidData;
                    using (var frmMessageBox = new FrmExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                if (_product == null)
                    _product = new Product();

                _product.CategoryID = int.Parse(cmbCategory.SelectedValue.ToString());
                _product.CategoryStr = cmbCategory.Text;
                _product.MarkID = int.Parse(cmbMark.SelectedValue.ToString());
                _product.MarkStr = cmbMark.Text;
                _product.ColorID = int.Parse(cmbColor.SelectedValue.ToString());
                _product.ColorStr = cmbColor.Text;
                _product.SizeID = Int32.Parse(cmbSize.SelectedValue.ToString());
                _product.SizeStr = cmbSize.Text;
                _product.ProductName = _product.CategoryStr + " \\ " + _product.MarkStr + " \\ " + _product.ColorStr;
                _product.UnitPriceIn = float.Parse(txtUPIn.Text);
                _product.ExtraPercentage = float.Parse(txtExtraPercentage.Text);
                _product.UnitPriceOut = float.Parse(txtUPOut.Text);
                _product.DiscountPercentage = float.Parse(txtDiscount.Text);
                _product.QtyInStock = float.Parse(txtQtyInStock.Text);
                _product.ForeignCode = txtForeignCode.Text;
                _product.Description = txtDescription.Text;
                if (txtPhotoPath.Text.Length == 0)
                {
                    _product.PhotoPath = _product.PhotoPath;
                    _product.ProductPic = Resources.NoImage;
                }
                else
                {
                    var fileInfo = new FileInfo(txtPhotoPath.Text);
                    if (fileInfo.Exists)
                    {
                        _product.PhotoPath = txtPhotoPath.Text;
                        _product.ProductPic = Image.FromFile(_product.PhotoPath);
                    }
                    else
                        _product.ProductPic = Resources.NoImage;
                }

                if (_productService == null)
                    _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                //_product.Description = string.Empty;
                _product.DisplayName = _product.ProductName + "\r" +
                                       "Size: " + _product.SizeStr + "\r" +
                                       "Code: " + _product.ProductCode;
                if (!string.IsNullOrEmpty(_product.ForeignCode))
                    _product.DisplayName += " (" + _product.ForeignCode + ")";

                if (!_isFromSale)
                {
                    _productService.ManageProduct(
                        _product,
                        _product.ProductID != 0 ? Resources.OperationRequestUpdate : Resources.OperationRequestInsert);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void CalculateProductCost(bool waitStatus)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUPIn.Text))
                    txtUPIn.Text = "0.000";
                if (string.IsNullOrEmpty(txtExtraPercentage.Text))
                    txtExtraPercentage.Text = "0";
                if (string.IsNullOrEmpty(txtDiscount.Text))
                    txtDiscount.Text = "0";
                if (string.IsNullOrEmpty(txtUPOut.Text))
                    txtUPOut.Text = "0.000";

                float discountPercentage;
                float unitPriceOut;
                if (waitStatus)
                {
                    unitPriceOut = float.Parse(txtUPOut.Text);
                    discountPercentage = 100 - ((100*unitPriceOut)/_defaultUnitPriceOut);
                    discountPercentage = discountPercentage < 0 ? 0 : discountPercentage;
                    txtDiscount.Text = Math.Round(discountPercentage, 0).ToString("N", AppContext.CultureInfo);
                }
                else
                {
                    var unitPriceIn = float.Parse(txtUPIn.Text);
                    var extraPercentage = float.Parse(txtExtraPercentage.Text);

                    discountPercentage = float.Parse(txtDiscount.Text);
                    unitPriceOut = unitPriceIn + ((unitPriceIn*extraPercentage)/100);
                    unitPriceOut = unitPriceOut - ((unitPriceOut*discountPercentage)/100);
                    //txtUPOut.Text = Math.Round(unitPriceOut, 0).ToString("N", AppContext.CultureInfo);
                    txtUPOut.Text = unitPriceOut.ToString("N3", AppContext.CultureInfo);
                    _defaultUnitPriceOut = float.Parse(txtUPOut.Text);
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void TxtQtyInStockEnter(object sender, EventArgs e)
        {
            txtQtyInStock.TextChanged += ModificationHandler;
        }

        private void PtbProductMouseClick(object sender, MouseEventArgs e)
        {
            if (_isFromSale)
                return;

            if (e == null)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    ImportIndividualCatalog();
                    break;
                case MouseButtons.Right:
                    if (_product == null)
                        cmsCatalog.Show(ptbProduct, e.X, e.Y);
                    break;
            }
        }

        private void ImportIndividualCatalog()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Pictures|*.bmp;*.gif;*.jpg|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() != DialogResult.OK) 
                    return;

                ptbProduct.ImageLocation = openFileDialog.FileName;
                txtPhotoPath.Text = openFileDialog.FileName;
            }
        }

        private void ImportAllCatalogs()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.ShowNewFolderButton = false;
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) 
                    return;

                const string briefMsg = "អំពីការលុប";
                var detailMsg = Resources.MsgOperationImportGroupCatalog;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                if (_productService == null)
                    _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                _productService.ImportGroupCatalog(
                    folderBrowserDialog.SelectedPath,
                    Int32.Parse(cmbCategory.SelectedValue.ToString()),
                    cmbCategory.Text,
                    Int32.Parse(cmbMark.SelectedValue.ToString()),
                    cmbMark.Text,
                    Int32.Parse(cmbColor.SelectedValue.ToString()),
                    cmbColor.Text,
                    Int32.Parse(cmbSize.SelectedValue.ToString()),
                    cmbSize.Text);

                _isModified = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void TsmIndividualClick(object sender, EventArgs e)
        {
            ImportIndividualCatalog();
        }

        private void TsmAllClick(object sender, EventArgs e)
        {
            ImportAllCatalogs();
        }

        private void SetEnableToComponents(bool enableStatus)
        {
            cmbCategory.Enabled = enableStatus;
            cmbMark.Enabled = enableStatus;
            cmbColor.Enabled = enableStatus;
            txtUPIn.Enabled = enableStatus;
            txtExtraPercentage.Enabled = enableStatus;
            txtQtyInStock.Enabled = enableStatus;
            btnAdjustment.Enabled = enableStatus;
        }

        private void TmsGroupClick(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Pictures|*.bmp;*.gif;*.jpg|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() != DialogResult.OK) 
                    return;

                if (openFileDialog.FileNames.Length == 0)
                    return;

                const string briefMsg = "អំពីការបង្កើតផលិតផល";
                var detailMsg = Resources.MsgOperationImportGroupCatalog;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                if (_productService == null)
                    _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                _productService.ImportGroupCatalog(
                    openFileDialog.FileNames,
                    Int32.Parse(cmbCategory.SelectedValue.ToString()),
                    cmbCategory.Text,
                    Int32.Parse(cmbMark.SelectedValue.ToString()),
                    cmbMark.Text,
                    Int32.Parse(cmbColor.SelectedValue.ToString()),
                    cmbColor.Text,
                    Int32.Parse(cmbSize.SelectedValue.ToString()),
                    cmbSize.Text);

                _isModified = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnAdjustmentClick(object sender, EventArgs e)
        {
            if (_product == null)
                return;

            try
            {
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

                briefMsg = "អំពីការសង";
                detailMsg = "សូម​មេត្តា​ចុច​លើ​ប៊ូតុង យល់​ព្រម ដើម្បី​បញ្ជាក់​ពី​ការ​ដកចេញពីឃ្លាំង​។";
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.ShowNewFolderButton = false;
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (_productService == null)
                            _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                        IList listProduct2Export = new List<Product> {_product};

                        _productService.ExportProductToXml(
                            listProduct2Export,
                            folderBrowserDialog.SelectedPath,
                            "ProductList.xml");

                        var productAdjustment = new ProductAdjustment
                                                    {
                                                        ProductID = _product.ProductID,
                                                        QtyInStock = _product.QtyInStock,
                                                        QtyAdjusted = ((-1)*_product.QtyInStock),
                                                        FKProduct = _product
                                                    };

                        if (_productService == null)
                            _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
                        _productService.ProductAdjustmentManagement(
                            Resources.OperationRequestInsert,
                            productAdjustment);

                        _isModified = true;
                        DialogResult = DialogResult.OK;
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

        private void TxtUpOutValidating(object sender, CancelEventArgs e)
        {
            _defaultUnitPriceOut = float.Parse(txtUPOut.Text);
        }

        private void CmbSizeEnter(object sender, EventArgs e)
        {
            cmbSize.SelectedIndexChanged += ModificationHandler;
            cmbSize.TextChanged += ModificationHandler;
        }

        private void CmbSizeLeave(object sender, EventArgs e)
        {
            cmbSize.SelectedIndexChanged -= ModificationHandler;
            cmbSize.TextChanged -= ModificationHandler;
        }

        private void TsmImportClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionImportExportProduct))
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

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.ShowNewFolderButton = false;
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) 
                    return;

                const string briefMsg = "អំពីការលុប";
                var detailMsg = Resources.MsgOperationImportGroupCatalog;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                if (_productService == null)
                    _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                _productService.ImportProductFromXml(
                    folderBrowserDialog.SelectedPath,
                    "ProductList.xml");

                _isModified = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void TxtProductCodeEnter(object sender, EventArgs e)
        {
            txtForeignCode.TextChanged += ModificationHandler;
        }

        private void TxtProductCodeLeave(object sender, EventArgs e)
        {
            txtForeignCode.TextChanged -= ModificationHandler;
            string detailMsg;
            if (!_productService.IsValidatedProductCode(txtForeignCode.Text, out detailMsg))
            {
                const string briefMsg = "អំពីពត៌មាន";
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    return;
                }
            }
            DoProductFetching(txtForeignCode.Text, true);
        }

        private void CmbProductSelectedIndexChanged(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(cmbProduct.DisplayMember)) ||
                (String.IsNullOrEmpty(cmbProduct.ValueMember)) ||
                (cmbProduct.SelectedIndex == -1))
                return;

            try
            {
                var product = (Product)cmbProduct.SelectedItem;
                if (product == null)
                    return;

                const string briefMsg = "អំពីពត៌មាន";
                var detailMsg = Resources.MsgConfirmEditExistingProduct;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    {
                        txtForeignCode.Text = string.Empty;
                        return;
                    }
                }

                _product = product;
                SetProductInfo(_product);
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DoProductFetching(string foreignCode, bool isAllowed)
        {
            if (String.IsNullOrEmpty(foreignCode))
                return;

            foreignCode = foreignCode.Replace("+", string.Empty);
            foreignCode = foreignCode.Replace("-", string.Empty);
            cmbProduct.SelectedIndex = -1;
            var selectedIndex = cmbProduct.FindStringExact(foreignCode);
            cmbProduct.SelectedIndex = selectedIndex;
            if ((selectedIndex != -1) || (!isAllowed)) 
                return;

            var strCriteria = 
                new List<string>
                {
                    "ForeignCode|" + foreignCode,
                    "QtyInStock > 0",
                    "ProductID <> " + (_product == null ? 0 : _product.ProductID)
                };
            var productList = _productService.GetObjects(strCriteria);
            if (productList.Count == 0) 
                return;

            foreach (Product product in productList)
                _productList.Add(product);

            DoProductFetching(foreignCode, false);
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            txtDescription.TextChanged += ModificationHandler;

            try
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("km-KH"));
            }
            catch (Exception)
            {
                try
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ca"));
                }
                catch (Exception)
                {
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en"));
                }
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en"));
            txtDescription.TextChanged -= ModificationHandler;
        }
    }
}