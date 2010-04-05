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

namespace EzPos.GUIs.Forms
{
    public partial class FrmCatalog : Form
    {
        private CommonService _CommonService;
        private float _DefaultUnitPriceOut;
        private bool _IsFromSale;
        private bool _IsModified;
        private Product _Product;
        private ProductService _ProductService;
        private BindingList<Product> _ProductList;

        public FrmCatalog()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
        }

        public ProductService ProductService
        {
            set { _ProductService = value; }
        }

        public Product Product
        {
            get { return _Product; }
            set { _Product = value; }
        }

        public bool IsFromSale
        {
            get { return _IsFromSale; }
            set { _IsFromSale = value; }
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            _IsModified = modifyStatus;
            btnSave.Enabled = modifyStatus;
        }

        private void FrmProductAdvance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_IsFromSale)
                return;

            if ((DialogResult == DialogResult.Cancel) && (_IsModified))
            {
                const string briefMsg = "អំពីការបោះបង់";
                var detailMsg = Resources.MsgOperationRequestCancel;
                using (var frmMessageBox = new ExtendedMessageBox())
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

            if (!_IsModified)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
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

        private void cmbCategory_Enter(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndexChanged += ModificationHandler;
            cmbCategory.TextChanged += ModificationHandler;
        }

        private void cmbMark_Enter(object sender, EventArgs e)
        {
            cmbMark.SelectedIndexChanged += ModificationHandler;
            cmbMark.TextChanged += ModificationHandler;
        }

        private void cmbColor_Enter(object sender, EventArgs e)
        {
            cmbColor.SelectedIndexChanged += ModificationHandler;
            cmbColor.TextChanged += ModificationHandler;
        }

        private void txtUPIn_Enter(object sender, EventArgs e)
        {
            txtUPIn.TextChanged += ModificationHandler;
        }

        private void txtExtraPercentage_Enter(object sender, EventArgs e)
        {
            txtExtraPercentage.TextChanged += ModificationHandler;
        }

        private void txtUPOut_Enter(object sender, EventArgs e)
        {
            txtUPOut.TextChanged += ModificationHandler;
        }

        private void txtDiscount_Enter(object sender, EventArgs e)
        {
            txtDiscount.TextChanged += ModificationHandler;
        }

        private void txtPhotoPath_TextChanged(object sender, EventArgs e)
        {
            ModificationHandler(sender, e);
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndexChanged -= ModificationHandler;
            cmbCategory.TextChanged -= ModificationHandler;
        }

        private void cmbMark_Leave(object sender, EventArgs e)
        {
            cmbMark.SelectedIndexChanged -= ModificationHandler;
            cmbMark.TextChanged -= ModificationHandler;
        }

        private void cmbColor_Leave(object sender, EventArgs e)
        {
            cmbColor.SelectedIndexChanged -= ModificationHandler;
            cmbColor.TextChanged -= ModificationHandler;
        }

        private void txtUPIn_Leave(object sender, EventArgs e)
        {
            txtUPIn.TextChanged -= ModificationHandler;
            try
            {
                txtUPIn.Text = float.Parse(txtUPIn.Text).ToString("N", AppContext.CultureInfo);
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void txtExtraPercentage_Leave(object sender, EventArgs e)
        {
            txtExtraPercentage.TextChanged -= ModificationHandler;
        }

        private void txtUPOut_Leave(object sender, EventArgs e)
        {
            if (txtUPOut.Text.Length == 0)
                txtUPOut.Text = "0.00";

            txtUPOut.TextChanged -= ModificationHandler;
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Length == 0)
                txtDiscount.Text = "0.00";

            txtDiscount.TextChanged -= ModificationHandler;
        }

        private void txtQtyInStock_Leave(object sender, EventArgs e)
        {
            txtQtyInStock.TextChanged -= ModificationHandler;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            if (_CommonService == null)
                _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

            if (!UserService.AllowToPerform(Resources.PermissionViewAllProductInfo))
            {
                txtUPIn.Visible = false;
                txtExtraPercentage.Visible = false;
            }

            if (!UserService.AllowToPerform(Resources.PermissionModifyProductQuantity))
                txtQtyInStock.Enabled = false;

            _DefaultUnitPriceOut = 0;

            var searchCriteria = new List<string>
                                     {
                                         "ParameterTypeID IN (" +
                                         Resources.AppParamCategory + ", " +
                                         Resources.AppParamMark + ", " +
                                         Resources.AppParamColor + ", " +
                                         Resources.AppParamSize + ")"
                                     };
            var objectList = _CommonService.GetAppParameters(searchCriteria);

            _CommonService.PopAppParamExtendedCombobox(
                ref cmbCategory, objectList, int.Parse(Resources.AppParamCategory), true);
            cmbCategory.SelectedValue = 364;

            _CommonService.PopAppParamExtendedCombobox(
                ref cmbMark, objectList, int.Parse(Resources.AppParamMark), true);

            _CommonService.PopAppParamExtendedCombobox(
                ref cmbColor, objectList, int.Parse(Resources.AppParamColor), true);

            _CommonService.PopAppParamExtendedCombobox(
                ref cmbSize, objectList, int.Parse(Resources.AppParamSize), true);

            _ProductList = new BindingList<Product>();
            cmbProduct.DataSource = _ProductList;
            cmbProduct.DisplayMember = Product.CONST_FOREIGN_CODE;
            cmbProduct.ValueMember = Product.CONST_PRODUCT_ID;
            cmbProduct.SelectedIndex = -1;

            SetProductInfo(_Product);

            if (_IsFromSale)
            {
                SetEnableToComponents(false);
                return;
            }

            txtPhotoPath.TextChanged += txtPhotoPath_TextChanged;
        }

        private void SetProductInfo(Product product)
        {
            if (product == null)
                return;

            //txtForeignCode.Enabled = product.ProductID == 0;
            txtForeignCode.Text = product.ForeignCode;
            lblProductName.Text = product.ProductName + "\r" + product.ProductCode;
            cmbCategory.SelectedValue = product.CategoryID;
            cmbMark.SelectedValue = product.MarkID;
            cmbColor.SelectedValue = product.ColorID;
            cmbSize.SelectedValue = product.SizeID;
            txtUPIn.Text = product.UnitPriceIn.ToString("N", AppContext.CultureInfo);
            txtExtraPercentage.Text = product.ExtraPercentage.ToString("N0", AppContext.CultureInfo);
            txtDiscount.Text = product.DiscountPercentage.ToString("N0", AppContext.CultureInfo);
            txtUPOut.Text = product.UnitPriceOut.ToString("N", AppContext.CultureInfo);
            _DefaultUnitPriceOut = product.UnitPriceOut;
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

            if (_Product == null) 
                return;

            if (!String.IsNullOrEmpty(_Product.ProductCode))
                lblProductName.Text += "\r" +
                                       _Product.ProductCode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cmbCategory.SelectedIndex == -1) || (cmbMark.SelectedIndex == -1)
                    || (cmbColor.SelectedIndex == -1) || (cmbSize.SelectedIndex == -1))
                {
                    const string briefMsg = "អំពីពត៌មាន";
                    var detailMsg = Resources.MsgInvalidData;
                    using (var frmMessageBox = new ExtendedMessageBox())
                    {
                        frmMessageBox.BriefMsgStr = briefMsg;
                        frmMessageBox.DetailMsgStr = detailMsg;
                        frmMessageBox.IsCanceledOnly = true;
                        frmMessageBox.ShowDialog(this);
                        return;
                    }
                }

                if (_Product == null)
                    _Product = new Product();

                //if (!string.IsNullOrEmpty(txtForeignCode.Text))
                //    _Product.ProductCode = StringHelper.Right("000000000" + txtForeignCode.Text, 9);
                _Product.CategoryID = int.Parse(cmbCategory.SelectedValue.ToString());
                _Product.CategoryStr = cmbCategory.Text;
                _Product.MarkID = int.Parse(cmbMark.SelectedValue.ToString());
                _Product.MarkStr = cmbMark.Text;
                _Product.ColorID = int.Parse(cmbColor.SelectedValue.ToString());
                _Product.ColorStr = cmbColor.Text;
                _Product.SizeID = Int32.Parse(cmbSize.SelectedValue.ToString());
                _Product.SizeStr = cmbSize.Text;
                _Product.ProductName = _Product.CategoryStr + " \\ " + _Product.MarkStr + " \\ " + _Product.ColorStr;
                _Product.UnitPriceIn = float.Parse(txtUPIn.Text);
                _Product.ExtraPercentage = float.Parse(txtExtraPercentage.Text);
                _Product.UnitPriceOut = float.Parse(txtUPOut.Text);
                _Product.DiscountPercentage = float.Parse(txtDiscount.Text);
                _Product.QtyInStock = float.Parse(txtQtyInStock.Text);
                _Product.ForeignCode = txtForeignCode.Text;
                if (txtPhotoPath.Text.Length == 0)
                {
                    _Product.PhotoPath = _Product.PhotoPath;
                    _Product.ProductPic = Resources.NoImage;
                }
                else
                {
                    var fileInfo = new FileInfo(txtPhotoPath.Text);
                    if (fileInfo.Exists)
                    {
                        _Product.PhotoPath = txtPhotoPath.Text;
                        _Product.ProductPic = Image.FromFile(_Product.PhotoPath);
                    }
                    else
                        _Product.ProductPic = Resources.NoImage;
                }

                if (_ProductService == null)
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                _Product.Description = string.Empty;
                _Product.DisplayName = _Product.ProductName + "\r" +
                                       "Size: " + _Product.SizeStr + "\r" +
                                       "Code: " + _Product.ProductCode;
                if (!string.IsNullOrEmpty(_Product.ForeignCode))
                    _Product.DisplayName += " (" + _Product.ForeignCode + ")";

                if (!_IsFromSale)
                {
                    if (_Product.ProductID != 0)
                        _ProductService.ManageProduct(
                            _Product,
                            Resources.OperationRequestUpdate);
                    else
                        _ProductService.ManageProduct(
                            _Product,
                            Resources.OperationRequestInsert);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void CalculateProductCost(bool waitStatus)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUPIn.Text))
                    txtUPIn.Text = "0";
                if (string.IsNullOrEmpty(txtExtraPercentage.Text))
                    txtExtraPercentage.Text = "0";
                if (string.IsNullOrEmpty(txtDiscount.Text))
                    txtDiscount.Text = "0";
                if (string.IsNullOrEmpty(txtUPOut.Text))
                    txtUPOut.Text = "0.00";

                float discountPercentage;
                float unitPriceOut;
                if (waitStatus)
                {
                    unitPriceOut = float.Parse(txtUPOut.Text);
                    discountPercentage = 100 - ((100*unitPriceOut)/_DefaultUnitPriceOut);
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
                    txtUPOut.Text = Math.Round(unitPriceOut, 0).ToString("N", AppContext.CultureInfo);
                    _DefaultUnitPriceOut = float.Parse(txtUPOut.Text);
                }
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void txtQtyInStock_Enter(object sender, EventArgs e)
        {
            txtQtyInStock.TextChanged += ModificationHandler;
        }

        private void ptbProduct_MouseClick(object sender, MouseEventArgs e)
        {
            if (_IsFromSale)
                return;

            if (e == null)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    ImportIndividualCatalog();
                    break;
                case MouseButtons.Right:
                    if (_Product == null)
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
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                if (_ProductService == null)
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                _ProductService.ImportGroupCatalog(
                    folderBrowserDialog.SelectedPath,
                    Int32.Parse(cmbCategory.SelectedValue.ToString()),
                    cmbCategory.Text,
                    Int32.Parse(cmbMark.SelectedValue.ToString()),
                    cmbMark.Text,
                    Int32.Parse(cmbColor.SelectedValue.ToString()),
                    cmbColor.Text,
                    Int32.Parse(cmbSize.SelectedValue.ToString()),
                    cmbSize.Text);

                _IsModified = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void tsmIndividual_Click(object sender, EventArgs e)
        {
            ImportIndividualCatalog();
        }

        private void tsmAll_Click(object sender, EventArgs e)
        {
            ImportAllCatalogs();
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_9;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = Resources.background_2;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
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

        private void tmsGroup_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Pictures|*.bmp;*.gif;*.jpg|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() != DialogResult.OK) 
                    return;

                if (openFileDialog.FileNames.Length == 0)
                    return;

                const string briefMsg = "អំពីការលុប";
                var detailMsg = Resources.MsgOperationImportGroupCatalog;
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                if (_ProductService == null)
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                _ProductService.ImportGroupCatalog(
                    openFileDialog.FileNames,
                    Int32.Parse(cmbCategory.SelectedValue.ToString()),
                    cmbCategory.Text,
                    Int32.Parse(cmbMark.SelectedValue.ToString()),
                    cmbMark.Text,
                    Int32.Parse(cmbColor.SelectedValue.ToString()),
                    cmbColor.Text,
                    Int32.Parse(cmbSize.SelectedValue.ToString()),
                    cmbSize.Text);

                _IsModified = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            if (_Product == null)
                return;

            try
            {
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

                briefMsg = "អំពីការសង";
                detailMsg = "សូម​មេត្តា​ចុច​លើ​ប៊ូតុង យល់​ព្រម ដើម្បី​បញ្ជាក់​ពី​ការ​ដកចេញពីឃ្លាំង​។";
                using (var frmMessageBox = new ExtendedMessageBox())
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
                        if (_ProductService == null)
                            _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                        IList listProduct2Export = new List<Product>();
                        if (_Product != null)
                            listProduct2Export.Add(_Product);

                        _ProductService.ExportProductToXml(
                            listProduct2Export,
                            folderBrowserDialog.SelectedPath,
                            "ProductList.xml");

                        if (_Product != null)
                        {
                            var productAdjustment = new ProductAdjustment
                                                        {
                                                            ProductID = _Product.ProductID,
                                                            QtyInStock = _Product.QtyInStock,
                                                            QtyAdjusted = ((-1)*_Product.QtyInStock),
                                                            FKProduct = _Product
                                                        };

                            if (_ProductService == null)
                                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
                            _ProductService.ProductAdjustmentManagement(
                                Resources.OperationRequestInsert,
                                productAdjustment);
                        }

                        _IsModified = true;
                        DialogResult = DialogResult.OK;
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

        private void btnAdjustment_MouseEnter(object sender, EventArgs e)
        {
            btnAdjustment.BackgroundImage = Resources.background_9;
        }

        private void btnAdjustment_MouseLeave(object sender, EventArgs e)
        {
            btnAdjustment.BackgroundImage = Resources.background_2;
        }

        private void txtUPOut_Validating(object sender, CancelEventArgs e)
        {
            _DefaultUnitPriceOut = float.Parse(txtUPOut.Text);
        }

        private void cmbSize_Enter(object sender, EventArgs e)
        {
            cmbSize.SelectedIndexChanged += ModificationHandler;
            cmbSize.TextChanged += ModificationHandler;
        }

        private void cmbSize_Leave(object sender, EventArgs e)
        {
            cmbSize.SelectedIndexChanged -= ModificationHandler;
            cmbSize.TextChanged -= ModificationHandler;
        }

        private void tsmImport_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionImportExportProduct))
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

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.ShowNewFolderButton = false;
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) 
                    return;

                const string briefMsg = "អំពីការលុប";
                var detailMsg = Resources.MsgOperationImportGroupCatalog;
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                        return;
                }

                if (_ProductService == null)
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                _ProductService.ImportProductFromXml(
                    folderBrowserDialog.SelectedPath,
                    "ProductList.xml");

                _IsModified = true;
                DialogResult = DialogResult.OK;
            }
        }

        private void txtProductCode_Enter(object sender, EventArgs e)
        {
            txtForeignCode.TextChanged += ModificationHandler;
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            txtForeignCode.TextChanged -= ModificationHandler;
            string detailMsg;
            if (!_ProductService.IsValidatedProductCode(txtForeignCode.Text, out detailMsg))
            {
                const string briefMsg = "អំពីពត៌មាន";
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    return;
                }
            }
            DoProductFetching(txtForeignCode.Text, true);
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
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
                using (var frmMessageBox = new ExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    if (frmMessageBox.ShowDialog(this) != DialogResult.OK)
                    {
                        txtForeignCode.Text = string.Empty;
                        return;
                    }
                }

                _Product = product;
                SetProductInfo(_Product);
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void DoProductFetching(string foreignCode, bool isAllowed)
        {
            if (String.IsNullOrEmpty(foreignCode))
                return;

            foreignCode = foreignCode.Replace("+", "");
            foreignCode = foreignCode.Replace("-", "");
            cmbProduct.SelectedIndex = -1;
            //var selectedIndex = cmbProduct.FindStringExact(
            //    StringHelper.Right("000000000" + foreignCode, 9));
            var selectedIndex = cmbProduct.FindStringExact(foreignCode);
            cmbProduct.SelectedIndex = selectedIndex;
            if ((selectedIndex != -1) || (!isAllowed)) 
                return;

            var strCriteria = 
                new List<string>
                {
                    "ForeignCode|" + foreignCode,
                    "QtyInStock > 0",
                    "ProductID <> " + _Product.ProductID
                };
            var productList = _ProductService.GetObjects(strCriteria);
            if (productList.Count == 0) 
                return;

            foreach (Product product in productList)
                _ProductList.Add(product);

            DoProductFetching(foreignCode, false);
        }
    }
}