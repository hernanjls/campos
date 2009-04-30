using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.GUI.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using GenericDataGridView;
//using System.Globalization;

namespace EzPos.GUI
{
    /// <summary>
    /// Summary description for FrmProduct.
    /// </summary>
    public class FrmProduct : FrmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly Container components;

        private Product _CurrentProduct;
        private bool _IsModified;
        private BindingList<object> _ProductBindingList;
        private ProductService _ProductService;
        private BindingList<object> _PurchaseItemList;
        private bool _SkipAllowed;
        private DataGridViewTextBoxColumn BarCodeValue;
        private ComboBox cbbCategory;
        private ComboBox cbbCountry;
        private ComboBox cbbLaboratory;
        private ComboBox cbbStore;
        private ExtendedDataGridView.CalendarColumn cdcDateOut;
        private DataGridViewComboBoxColumn CellID;
        private Button cmdCancel;

        private Button cmdDeleteProduct;
        private Button cmdNewProduct;
        private Button cmdReset;
        private Button cmdSave;
        private Button cmdSearchProduct;
        private ExtendedDataGridView.CalendarColumn DateExpire;
        private ExtendedDataGridView.CalendarColumn DateIn;
        private DataGridView dgvPurchaseHistory;
        private DataGridView dgvSaleHistory;
        private DataGridViewTextBoxColumn FKPurchaseOrder;
        private GroupBox grbLine_1;
        private GroupBox grbLine_2;
        private GroupBox grbProductInfo;
        private GroupBox grbPurchaseHistory;
        private Label lblCategory;
        private Label lblCountry;
        private Label lblDisplayName;
        private Label lblExtraPercentage;
        private Label lblLaboratory;
        private Label lblMinQty;
        private Label lblProductCode;
        private Label lblProductName;
        private Label lblQtyInStock;
        private Label lblQtyStock;
        private Label lblRemark;
        private Label lblStore;
        private Label lblUnitPriceIn;
        private Label lblUnitPriceOut;
        private ListBox lsbProduct;
        private DataGridViewTextBoxColumn ProductID;
        private DataGridViewComboBoxColumn ProductUnitID;
        private DataGridViewTextBoxColumn PurchaseItemID;
        private DataGridViewTextBoxColumn PurchaseOrderID;
        private DataGridViewTextBoxColumn QtyOutStr;
        private DataGridViewTextBoxColumn Quantity;
        private RichTextBox rtbRemark;
        private DataGridViewTextBoxColumn SaleBarCodeValue;
        private DataGridViewTextBoxColumn SaleItemID;
        private DataGridViewTextBoxColumn SaleOrderNumber;
        private DataGridViewTextBoxColumn SaleProductID;
        private DataGridViewTextBoxColumn SaleSubTotal;
        private DataGridViewTextBoxColumn SubTotal;
        private DataGridViewComboBoxColumn SupplierID;
        private TabControl tbcInOutHistory;
        private TabPage tbpInHistory;
        private TabPage tbpOutHistory;
        private TextBox txtDisplayName;
        private TextBox txtExtraPercentage;
        private TextBox txtMinQty;
        private TextBox txtOperationInfo;
        private TextBox txtProductCode;
        private TextBox txtProductName;
        private TextBox txtProductSearch;
        private TextBox txtQtyInStock;
        private TextBox txtQtySold;
        private TextBox txtUnitPriceIn;
        private TextBox txtUnitPriceOut;
        private DataGridViewComboBoxColumn UnitID;
        private DataGridViewTextBoxColumn UnitPrice;
        private DataGridViewTextBoxColumn UnitPriceOut;

        public FrmProduct()
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

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            if (txtProductSearch.CanFocus)
                txtProductSearch.Focus();

            try
            {
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                IList laboratoryList = _ProductService.GetLaboratories();
                cbbLaboratory.DataSource = laboratoryList;
                cbbLaboratory.ValueMember = Laboratory.CONST_LABORATORY_ID;
                cbbLaboratory.DisplayMember = Laboratory.CONST_LABORATORY_NAME;

                IList countryList = _ProductService.GetCountries();
                cbbCountry.DataSource = countryList;
                cbbCountry.ValueMember = Country.CONST_COUNTRY_ID;
                cbbCountry.DisplayMember = Country.CONST_COUNTRY_NAME;

                IList productCategoryList = _ProductService.GetCategories();
                cbbCategory.ValueMember = ProductCategory.CONST_CATEGORY_ID;
                cbbCategory.DisplayMember = ProductCategory.CONST_CATEGORY_NAME;
                cbbCategory.DataSource = productCategoryList;

                IList storeList = _ProductService.GetLocations();
                cbbStore.ValueMember = ProductLocation.CONST_CELL_ID;
                cbbStore.DisplayMember = ProductLocation.CONST_CELL_NAME;
                cbbStore.DataSource = storeList;

                SupplierService supplierService = ServiceFactory.GenerateServiceInstance().GenerateSupplierService();
                IList supplierList = supplierService.GetSuppliers();
                SupplierID.DataSource = supplierList;
                SupplierID.ValueMember = Supplier.CONST_SUPPLIER_ID;
                SupplierID.DisplayMember = Supplier.CONST_SUPPLIER_NAME;

                PopulateProductList();
            }
            catch (Exception exception)
            {
                txtOperationInfo.Text = "exception.Message";
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
            lblHeader.Text = "Product management";
            cmd2.Enabled = false;
        }

        private void lsbProduct_SelectedIndexChanged(object sender, EventArgs e)
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
                    lsbProduct.SelectedValue = _CurrentProduct.ProductID;
                    return;
                }
            }

            if ((lsbProduct.DisplayMember == "") || (lsbProduct.ValueMember == ""))
                return;

            if (lsbProduct.SelectedIndex == -1)
            {
                _CurrentProduct = new Product();
                cmdDeleteProduct.Enabled = false;
                ResetProductInfo();
                return;
            }

            SetProductInfo(true);
        }

        private void SetProductInfo(bool refreshPurchaseHistory)
        {
            _CurrentProduct = (Product) lsbProduct.SelectedItem;
            txtProductName.Text = _CurrentProduct.ProductName;
            txtProductCode.Text = _CurrentProduct.ProductCode;
            txtDisplayName.Text = _CurrentProduct.DisplayName;
            cbbLaboratory.SelectedValue = _CurrentProduct.LaboratoryID;
            cbbCountry.SelectedValue = _CurrentProduct.CountryID;
            cbbCategory.SelectedValue = _CurrentProduct.CategoryID;
            cbbStore.SelectedValue = _CurrentProduct.StoreID;
            rtbRemark.Text = _CurrentProduct.Remark;
            txtUnitPriceIn.Text = _CurrentProduct.UnitPriceIn.ToString();
            txtUnitPriceOut.Text = _CurrentProduct.UnitPriceOut.ToString();
            txtExtraPercentage.Text = _CurrentProduct.ExtraPercentage.ToString();
            txtMinQty.Text = Math.Round(_CurrentProduct.MinQty, 2).ToString();
            txtQtyInStock.Text = Math.Round(_CurrentProduct.QtyInStock, 2).ToString();
            txtQtySold.Text = Math.Round(_CurrentProduct.QtySold, 2).ToString();

            //txtMinQty.Text = _CurrentProduct.MinQty.ToString();
            //txtQtyInStock.Text = _CurrentProduct.QtyInStock.ToString();
            //txtQtySold.Text = _CurrentProduct.QtySold.ToString();

            _IsModified = false;
            cmdDeleteProduct.Enabled = true;
            cmdNewProduct.Enabled = true;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;
            cmdReset.Enabled = false;

            if (refreshPurchaseHistory)
                SetPurchaseHistory();
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtProductSearch.Text.Length != 0)
            {
                lsbProduct.SelectedIndex = lsbProduct.FindString(txtProductSearch.Text);
            }

            if (lsbProduct.SelectedIndex == -1)
            {
                FetchProduct();
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_IsModified)
                {
                    // Pre save
                    if (txtProductName.Text.Length == 0)
                    {
                        MessageBox.Show("Product name");
                        return;
                    }

                    _CurrentProduct.CategoryID = Int32.Parse(cbbCategory.SelectedValue.ToString());
                    _CurrentProduct.StoreID = Int32.Parse(cbbStore.SelectedValue.ToString());
                    _CurrentProduct.LatestLocationID = _CurrentProduct.StoreID;
                    _CurrentProduct.DisplayName = txtDisplayName.Text;
                    _CurrentProduct.ExtraPercentage = float.Parse(txtExtraPercentage.Text.Replace("%", ""));
                    _CurrentProduct.LastUpdate = DateTime.Now;
                    _CurrentProduct.MinQty = float.Parse(txtMinQty.Text);
                    _CurrentProduct.ProductCode = txtProductCode.Text;
                    _CurrentProduct.ProductName = txtProductName.Text;
                    _CurrentProduct.QtyInStock = float.Parse(txtQtyInStock.Text);
                    _CurrentProduct.QtySold = float.Parse(txtQtySold.Text);
                    _CurrentProduct.Remark = rtbRemark.Text;
                    _CurrentProduct.UnitPriceIn = float.Parse(txtUnitPriceIn.Text);
                    _CurrentProduct.UnitPriceOut = float.Parse(txtUnitPriceOut.Text);
                    if (_CurrentProduct.LastExpire.Equals(DateTime.MinValue))
                        _CurrentProduct.LastExpire = DateTime.Now.AddMonths(3);

                    SetModifydStatus(false);
                    // Saving
                    if (_CurrentProduct.ProductID == 0)
                    {
                        _ProductService.ProductManagement(_CurrentProduct,
                                                          Resources.OperationRequestInsert);
                        _ProductBindingList.Add(_CurrentProduct);
                    }
                    else
                    {
                        _ProductService.ProductManagement(_CurrentProduct,
                                                          Resources.OperationRequestUpdate);
                        _SkipAllowed = true;
                        _ProductBindingList[lsbProduct.SelectedIndex] = _CurrentProduct;
                    }

                    // Post save
                    cmdCancel_Click(sender, e);
                }
            }
            catch (Exception exception)
            {
                SetModifydStatus(true);
                txtOperationInfo.Text = "exception.Message";
                MessageBoxHandler.UnknownErrorMessage(Resources.MessageCaptionUnknownError, exception.Message);
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            ResetProductInfo();
        }

        private void cmdNewProduct_Click(object sender, EventArgs e)
        {
            lsbProduct.SelectedIndex = -1;
            lsbProduct.Enabled = false;
            cmdNewProduct.Enabled = false;
            cmdReset.Enabled = true;
            cmdSave.Enabled = true;
            cmdCancel.Enabled = true;
            _IsModified = true;

            ResetProductInfo();
        }

        private void cmdDeleteProduct_Click(object sender, EventArgs e)
        {
            if (lsbProduct.SelectedIndex == -1)
                return;

            if (!MessageBoxHandler.ConfirmMessage("Operation.Request.Delete",
                                                  _CurrentProduct.ProductName))
                return;

            object objResult = _ProductService.ProductManagement(_CurrentProduct,
                                                                 Resources.OperationRequestDelete);
            if (objResult != null)
            {
                MessageBoxHandler.UnknownErrorMessage(
                    Resources.MessageCaptionUnknownError,
                    objResult.ToString());
                return;
            }

            _ProductBindingList.Remove(_CurrentProduct);
            if (lsbProduct.SelectedIndex == 0)
            {
                lsbProduct.SelectedIndex = -1;
                SetModifydStatus(false);
                if (_ProductBindingList.Count != 0)
                    lsbProduct.SelectedIndex = 0;
            }
            else
                lsbProduct.SelectedIndex = lsbProduct.SelectedIndex - 1;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (_IsModified)
            {
                if (MessageBoxHandler.ConfirmMessage("Operation.Request.Cancel", ""))
                {
                    _IsModified = false;
                    lsbProduct.Enabled = true;
                    if (lsbProduct.SelectedIndex == -1)
                        lsbProduct.SelectedIndex = 0;
                    else
                        lsbProduct_SelectedIndexChanged(sender, e);
                }
                else
                    return;
            }
            lsbProduct.Enabled = true;
            cmdNewProduct.Enabled = true;
            cmdDeleteProduct.Enabled = true;
            cmdReset.Enabled = false;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;
        }

        private void SetModifydStatus(bool modifyStatus)
        {
            if (_CurrentProduct == null)
                return;
            _IsModified = modifyStatus;
            cmdSave.Enabled = _IsModified;
            cmdCancel.Enabled = _IsModified;
            cmdNewProduct.Enabled = !_IsModified;
            cmdDeleteProduct.Enabled = !_IsModified;
        }

        private void ModificationHandler(object sender, EventArgs e)
        {
            SetModifydStatus(true);
        }

        private void ResetProductInfo()
        {
            txtProductCode.Text = "";
            txtProductName.Text = "";
            txtDisplayName.Text = "";
            rtbRemark.Text = "";
            txtMinQty.Text = "0.0";
            txtUnitPriceIn.Text = "0.0";
            txtUnitPriceOut.Text = "0.0";
            cbbCategory.SelectedIndex = 0;
            cbbStore.SelectedIndex = 0;
            txtQtyInStock.Text = "0.0";
            txtQtySold.Text = "0.0";
            txtExtraPercentage.Text = "0.0%";
        }

        private void txtProductName_Enter(object sender, EventArgs e)
        {
            txtProductName.TextChanged += ModificationHandler;
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            txtProductName.TextChanged -= ModificationHandler;
        }

        private void txtProductCode_Enter(object sender, EventArgs e)
        {
            txtProductCode.TextChanged += ModificationHandler;
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            txtProductCode.TextChanged -= ModificationHandler;
        }

        private void txtDisplayName_Enter(object sender, EventArgs e)
        {
            //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ca"));
            txtDisplayName.TextChanged += ModificationHandler;
        }

        private void txtDisplayName_Leave(object sender, EventArgs e)
        {
            //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(Application.CurrentCulture);
            txtDisplayName.TextChanged -= ModificationHandler;
        }

        private void cbbCategory_Enter(object sender, EventArgs e)
        {
            cbbCategory.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbCategory_Leave(object sender, EventArgs e)
        {
            cbbCategory.SelectedIndexChanged -= ModificationHandler;
        }

        private void rtbRemark_Enter(object sender, EventArgs e)
        {
            rtbRemark.TextChanged += ModificationHandler;
        }

        private void rtbRemark_Leave(object sender, EventArgs e)
        {
            rtbRemark.TextChanged -= ModificationHandler;
        }

        private void txtUnitPriceOut_Enter(object sender, EventArgs e)
        {
            txtUnitPriceOut.TextChanged += ModificationHandler;
        }

        private void txtUnitPriceOut_Leave(object sender, EventArgs e)
        {
            txtUnitPriceOut.TextChanged -= ModificationHandler;
        }

        private void txtExtraPercentage_Enter(object sender, EventArgs e)
        {
            txtExtraPercentage.TextChanged += ModificationHandler;
        }

        private void txtExtraPercentage_Leave(object sender, EventArgs e)
        {
            txtExtraPercentage.TextChanged -= ModificationHandler;

            try
            {
                if (string.IsNullOrEmpty(txtExtraPercentage.Text))
                    txtExtraPercentage.Text = "0.00";
                float extraPercentage = float.Parse(txtExtraPercentage.Text);
                if (extraPercentage == _CurrentProduct.ExtraPercentage)
                    return;

                _CurrentProduct.ExtraPercentage = extraPercentage;
                float unitPriceIn = float.Parse(txtUnitPriceIn.Text);
                txtUnitPriceOut.Text =
                    Math.Round(unitPriceIn + ((unitPriceIn*extraPercentage)/100), 1).ToString("N");
            }
            catch (Exception exception)
            {
                txtOperationInfo.Text = "exception.Message";
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void txtMinQty_Enter(object sender, EventArgs e)
        {
            txtMinQty.TextChanged += ModificationHandler;
        }

        private void txtMinQty_Leave(object sender, EventArgs e)
        {
            txtMinQty.TextChanged -= ModificationHandler;
        }

        private void SetPurchaseHistory()
        {
            try
            {
                if (_CurrentProduct == null)
                    return;

                if (ProductUnitID.DataSource == null)
                {
                    ProductUnitID.DataSource = _ProductService.GetProductUnits();
                    ProductUnitID.DisplayMember = ProductUnit.CONST_UNIT_NAME;
                    ProductUnitID.ValueMember = ProductUnit.CONST_UNIT_ID;

                    UnitID.DataSource = ProductUnitID.DataSource;
                    UnitID.DisplayMember = ProductUnit.CONST_UNIT_NAME;
                    UnitID.ValueMember = ProductUnit.CONST_UNIT_ID;
                }

                if (CellID.DataSource == null)
                {
                    CellID.DataSource = _ProductService.GetLocations();
                    CellID.DisplayMember = ProductLocation.CONST_CELL_NAME;
                    CellID.ValueMember = ProductLocation.CONST_CELL_ID;
                }
                //Purchase
                _PurchaseItemList =
                    CommonService.IListToBindingList(_ProductService.GetPurchaseItemsByProduct(_CurrentProduct.ProductID));
                dgvPurchaseHistory.DataSource = CommonService.IListToDataTable(typeof (PurchaseItem), _PurchaseItemList);
                dgvPurchaseHistory.Columns.Remove("QtyOut");

                if (dgvPurchaseHistory != null)
                {
                    if (dgvPurchaseHistory != null)
                    {
                        dgvPurchaseHistory.Columns["ProductID"].DisplayIndex = 0;
                        dgvPurchaseHistory.Columns["BarCodeValue"].DisplayIndex = 1;
                        dgvPurchaseHistory.Columns["Quantity"].DisplayIndex = 2;
                        dgvPurchaseHistory.Columns["ProductUnitID"].DisplayIndex = 3;
                        dgvPurchaseHistory.Columns["UnitPrice"].DisplayIndex = 4;
                        dgvPurchaseHistory.Columns["SubTotal"].DisplayIndex = 5;
                        dgvPurchaseHistory.Columns["CellID"].DisplayIndex = 6;
                        dgvPurchaseHistory.Columns["DateIn"].DisplayIndex = 7;
                        dgvPurchaseHistory.Columns["DateExpire"].DisplayIndex = 8;
                    }
                }

                //Sale
                IList _SaleItemList =
                    CommonService.IListToBindingList(_ProductService.GetSaleItemsByProduct(_CurrentProduct.ProductID));
                dgvSaleHistory.DataSource = CommonService.IListToDataTable(typeof (SaleItem), _SaleItemList);
                dgvSaleHistory.Columns.Remove("OrderID");
                dgvSaleHistory.Columns.Remove("FKProduct");
                dgvSaleHistory.Columns.Remove("UnitPriceIn");
                dgvSaleHistory.Columns.Remove("SaleOrderID");
                dgvSaleHistory.Columns.Remove("FKSaleOrder");
                dgvSaleHistory.Columns.Remove("QtyOut");
                dgvSaleHistory.Columns.Remove("ProductName");

                if (dgvSaleHistory != null)
                {
                    dgvSaleHistory.Columns["SaleProductID"].DisplayIndex = 0;
                    dgvSaleHistory.Columns["SaleBarCodeValue"].DisplayIndex = 1;
                    dgvSaleHistory.Columns["SaleOrderNumber"].DisplayIndex = 2;
                    dgvSaleHistory.Columns["UnitID"].DisplayIndex = 3;
                    dgvSaleHistory.Columns["QtyOutStr"].DisplayIndex = 4;
                    dgvSaleHistory.Columns["UnitPriceOut"].DisplayIndex = 5;
                    dgvSaleHistory.Columns["SaleSubTotal"].DisplayIndex = 6;
                }
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void dgvPurchaseHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        private void PopulateProductList()
        {
            _ProductBindingList = CommonService.IListToBindingList(_ProductService.GetProducts());
            _ProductBindingList.RemoveAt(0);
            lsbProduct.ValueMember = Product.CONST_PRODUCT_ID;
            lsbProduct.DisplayMember = Product.CONST_PRODUCT_NAME;
            lsbProduct.DataSource = _ProductBindingList;
        }

        private void cbbLaboratory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbbLaboratory.DisplayMember != "") && (cbbLaboratory.ValueMember != ""))
                SetModifydStatus(true);
        }

        private void cbbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbbCountry.DisplayMember != "") && (cbbCountry.ValueMember != ""))
                SetModifydStatus(true);
        }

        private void cbbStore_Enter(object sender, EventArgs e)
        {
            cbbStore.SelectedIndexChanged += ModificationHandler;
        }

        private void cbbStore_Leave(object sender, EventArgs e)
        {
            cbbStore.SelectedIndexChanged -= ModificationHandler;
        }

        private void txtQtyInStock_Enter(object sender, EventArgs e)
        {
            txtQtyInStock.TextChanged += ModificationHandler;
        }

        private void txtQtyInStock_Leave(object sender, EventArgs e)
        {
            txtQtyInStock.TextChanged -= ModificationHandler;
        }

        private void FetchProduct()
        {
            string keyword = txtProductSearch.Text;
            var searchCriteria = new List<string>();
            searchCriteria.Add(
                "ProductName LIKE '%" + keyword + "%' " +
                "OR Remark LIKE '%" + keyword + "%' " +
                "OR DisplayName LIKE '%" + keyword + "%'");
            IList productList = _ProductService.GetProducts(searchCriteria);
            if (productList == null)
                return;

            if (productList.Count == 0)
                return;

            var product = productList[0] as Product;
            foreach (Product singleProduct in _ProductBindingList)
            {
                if (product != null)
                    if (singleProduct.ProductID != product.ProductID)
                        continue;

                lsbProduct.SelectedIndex = _ProductBindingList.IndexOf(singleProduct);
                break;
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
            var dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSearchProduct = new System.Windows.Forms.Button();
            this.cmdDeleteProduct = new System.Windows.Forms.Button();
            this.cmdNewProduct = new System.Windows.Forms.Button();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.lsbProduct = new System.Windows.Forms.ListBox();
            this.grbProductInfo = new System.Windows.Forms.GroupBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.cbbStore = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblLaboratory = new System.Windows.Forms.Label();
            this.cbbCountry = new System.Windows.Forms.ComboBox();
            this.cbbLaboratory = new System.Windows.Forms.ComboBox();
            this.grbLine_2 = new System.Windows.Forms.GroupBox();
            this.grbLine_1 = new System.Windows.Forms.GroupBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.lblExtraPercentage = new System.Windows.Forms.Label();
            this.txtExtraPercentage = new System.Windows.Forms.TextBox();
            this.lblQtyStock = new System.Windows.Forms.Label();
            this.txtQtySold = new System.Windows.Forms.TextBox();
            this.lblQtyInStock = new System.Windows.Forms.Label();
            this.txtQtyInStock = new System.Windows.Forms.TextBox();
            this.lblUnitPriceOut = new System.Windows.Forms.Label();
            this.txtUnitPriceOut = new System.Windows.Forms.TextBox();
            this.lblUnitPriceIn = new System.Windows.Forms.Label();
            this.txtUnitPriceIn = new System.Windows.Forms.TextBox();
            this.lblMinQty = new System.Windows.Forms.Label();
            this.txtMinQty = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.rtbRemark = new System.Windows.Forms.RichTextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.grbPurchaseHistory = new System.Windows.Forms.GroupBox();
            this.tbcInOutHistory = new System.Windows.Forms.TabControl();
            this.tbpInHistory = new System.Windows.Forms.TabPage();
            this.dgvPurchaseHistory = new System.Windows.Forms.DataGridView();
            this.tbpOutHistory = new System.Windows.Forms.TabPage();
            this.dgvSaleHistory = new System.Windows.Forms.DataGridView();
            this.txtOperationInfo = new System.Windows.Forms.TextBox();
            this.PurchaseItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCodeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateIn = new GenericDataGridView.ExtendedDataGridView.CalendarColumn();
            this.ProductUnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DateExpire = new GenericDataGridView.ExtendedDataGridView.CalendarColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKPurchaseOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SaleItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleBarCodeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPriceOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcDateOut = new GenericDataGridView.ExtendedDataGridView.CalendarColumn();
            this.UnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.QtyOutStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.grbProductInfo.SuspendLayout();
            this.grbPurchaseHistory.SuspendLayout();
            this.tbcInOutHistory.SuspendLayout();
            this.tbpInHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvPurchaseHistory)).BeginInit();
            this.tbpOutHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvSaleHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.txtOperationInfo);
            this.pnlBody.Controls.Add(this.grbPurchaseHistory);
            this.pnlBody.Controls.Add(this.grbProductInfo);
            this.pnlBody.Controls.Add(this.cmdSearchProduct);
            this.pnlBody.Controls.Add(this.cmdDeleteProduct);
            this.pnlBody.Controls.Add(this.cmdNewProduct);
            this.pnlBody.Controls.Add(this.txtProductSearch);
            this.pnlBody.Controls.Add(this.lsbProduct);
            this.pnlBody.Size = new System.Drawing.Size(1016, 584);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(1016, 75);
            // 
            // cmdSearchProduct
            // 
            this.cmdSearchProduct.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdSearchProduct.Image = Resources.Search32;
            this.cmdSearchProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSearchProduct.Location = new System.Drawing.Point(209, 9);
            this.cmdSearchProduct.Name = "cmdSearchProduct";
            this.cmdSearchProduct.Size = new System.Drawing.Size(89, 28);
            this.cmdSearchProduct.TabIndex = 1;
            this.cmdSearchProduct.Text = "&Search";
            this.cmdSearchProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearchProduct.UseVisualStyleBackColor = true;
            // 
            // cmdDeleteProduct
            // 
            this.cmdDeleteProduct.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdDeleteProduct.Image = Resources.Delete32;
            this.cmdDeleteProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDeleteProduct.Location = new System.Drawing.Point(209, 582);
            this.cmdDeleteProduct.Name = "cmdDeleteProduct";
            this.cmdDeleteProduct.Size = new System.Drawing.Size(89, 28);
            this.cmdDeleteProduct.TabIndex = 4;
            this.cmdDeleteProduct.Text = "&Delete";
            this.cmdDeleteProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDeleteProduct.UseVisualStyleBackColor = true;
            this.cmdDeleteProduct.Click += new System.EventHandler(this.cmdDeleteProduct_Click);
            // 
            // cmdNewProduct
            // 
            this.cmdNewProduct.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdNewProduct.Location = new System.Drawing.Point(118, 582);
            this.cmdNewProduct.Name = "cmdNewProduct";
            this.cmdNewProduct.Size = new System.Drawing.Size(89, 28);
            this.cmdNewProduct.TabIndex = 3;
            this.cmdNewProduct.Text = "&New";
            this.cmdNewProduct.UseVisualStyleBackColor = true;
            this.cmdNewProduct.Click += new System.EventHandler(this.cmdNewProduct_Click);
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                 System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtProductSearch.Location = new System.Drawing.Point(14, 14);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(189, 23);
            this.txtProductSearch.TabIndex = 0;
            this.txtProductSearch.TextChanged += new System.EventHandler(this.txtProductSearch_TextChanged);
            // 
            // lsbProduct
            // 
            this.lsbProduct.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lsbProduct.FormattingEnabled = true;
            this.lsbProduct.HorizontalScrollbar = true;
            this.lsbProduct.ItemHeight = 22;
            this.lsbProduct.Location = new System.Drawing.Point(14, 43);
            this.lsbProduct.Name = "lsbProduct";
            this.lsbProduct.Size = new System.Drawing.Size(284, 532);
            this.lsbProduct.Sorted = true;
            this.lsbProduct.TabIndex = 2;
            this.lsbProduct.SelectedIndexChanged += new System.EventHandler(this.lsbProduct_SelectedIndexChanged);
            // 
            // grbProductInfo
            // 
            this.grbProductInfo.Controls.Add(this.lblStore);
            this.grbProductInfo.Controls.Add(this.cbbStore);
            this.grbProductInfo.Controls.Add(this.lblCountry);
            this.grbProductInfo.Controls.Add(this.lblLaboratory);
            this.grbProductInfo.Controls.Add(this.cbbCountry);
            this.grbProductInfo.Controls.Add(this.cbbLaboratory);
            this.grbProductInfo.Controls.Add(this.grbLine_2);
            this.grbProductInfo.Controls.Add(this.grbLine_1);
            this.grbProductInfo.Controls.Add(this.lblCategory);
            this.grbProductInfo.Controls.Add(this.cbbCategory);
            this.grbProductInfo.Controls.Add(this.lblExtraPercentage);
            this.grbProductInfo.Controls.Add(this.txtExtraPercentage);
            this.grbProductInfo.Controls.Add(this.lblQtyStock);
            this.grbProductInfo.Controls.Add(this.txtQtySold);
            this.grbProductInfo.Controls.Add(this.lblQtyInStock);
            this.grbProductInfo.Controls.Add(this.txtQtyInStock);
            this.grbProductInfo.Controls.Add(this.lblUnitPriceOut);
            this.grbProductInfo.Controls.Add(this.txtUnitPriceOut);
            this.grbProductInfo.Controls.Add(this.lblUnitPriceIn);
            this.grbProductInfo.Controls.Add(this.txtUnitPriceIn);
            this.grbProductInfo.Controls.Add(this.lblMinQty);
            this.grbProductInfo.Controls.Add(this.txtMinQty);
            this.grbProductInfo.Controls.Add(this.lblRemark);
            this.grbProductInfo.Controls.Add(this.rtbRemark);
            this.grbProductInfo.Controls.Add(this.lblDisplayName);
            this.grbProductInfo.Controls.Add(this.txtDisplayName);
            this.grbProductInfo.Controls.Add(this.cmdReset);
            this.grbProductInfo.Controls.Add(this.cmdCancel);
            this.grbProductInfo.Controls.Add(this.cmdSave);
            this.grbProductInfo.Controls.Add(this.lblProductName);
            this.grbProductInfo.Controls.Add(this.txtProductName);
            this.grbProductInfo.Controls.Add(this.lblProductCode);
            this.grbProductInfo.Controls.Add(this.txtProductCode);
            this.grbProductInfo.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.grbProductInfo.Location = new System.Drawing.Point(311, 3);
            this.grbProductInfo.Name = "grbProductInfo";
            this.grbProductInfo.Size = new System.Drawing.Size(700, 298);
            this.grbProductInfo.TabIndex = 5;
            this.grbProductInfo.TabStop = false;
            this.grbProductInfo.Text = "ពត៍មានអំពីផលិតផល";
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblStore.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblStore.Location = new System.Drawing.Point(360, 83);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(48, 24);
            this.lblStore.TabIndex = 18;
            this.lblStore.Text = "ទីតាំង";
            // 
            // cbbStore
            // 
            this.cbbStore.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbStore.FormattingEnabled = true;
            this.cbbStore.Location = new System.Drawing.Point(481, 84);
            this.cbbStore.Name = "cbbStore";
            this.cbbStore.Size = new System.Drawing.Size(205, 24);
            this.cbbStore.TabIndex = 19;
            this.cbbStore.Leave += new System.EventHandler(this.cbbStore_Leave);
            this.cbbStore.Enter += new System.EventHandler(this.cbbStore_Enter);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCountry.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCountry.Location = new System.Drawing.Point(10, 103);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(60, 24);
            this.lblCountry.TabIndex = 14;
            this.lblCountry.Text = "ប្រទេស";
            // 
            // lblLaboratory
            // 
            this.lblLaboratory.AutoSize = true;
            this.lblLaboratory.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblLaboratory.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLaboratory.Location = new System.Drawing.Point(10, 76);
            this.lblLaboratory.Name = "lblLaboratory";
            this.lblLaboratory.Size = new System.Drawing.Size(98, 24);
            this.lblLaboratory.TabIndex = 12;
            this.lblLaboratory.Text = "មន្ទីរពិសោធន៏";
            // 
            // cbbCountry
            // 
            this.cbbCountry.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbCountry.FormattingEnabled = true;
            this.cbbCountry.Location = new System.Drawing.Point(136, 103);
            this.cbbCountry.Name = "cbbCountry";
            this.cbbCountry.Size = new System.Drawing.Size(205, 24);
            this.cbbCountry.TabIndex = 15;
            this.cbbCountry.SelectedIndexChanged += new System.EventHandler(this.cbbCountry_SelectedIndexChanged);
            // 
            // cbbLaboratory
            // 
            this.cbbLaboratory.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbLaboratory.FormattingEnabled = true;
            this.cbbLaboratory.Location = new System.Drawing.Point(136, 76);
            this.cbbLaboratory.Name = "cbbLaboratory";
            this.cbbLaboratory.Size = new System.Drawing.Size(205, 24);
            this.cbbLaboratory.TabIndex = 13;
            this.cbbLaboratory.SelectedIndexChanged += new System.EventHandler(this.cbbLaboratory_SelectedIndexChanged);
            // 
            // grbLine_2
            // 
            this.grbLine_2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_2.Location = new System.Drawing.Point(13, 254);
            this.grbLine_2.Name = "grbLine_2";
            this.grbLine_2.Size = new System.Drawing.Size(675, 2);
            this.grbLine_2.TabIndex = 33;
            this.grbLine_2.TabStop = false;
            // 
            // grbLine_1
            // 
            this.grbLine_1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbLine_1.Location = new System.Drawing.Point(13, 162);
            this.grbLine_1.Name = "grbLine_1";
            this.grbLine_1.Size = new System.Drawing.Size(675, 2);
            this.grbLine_1.TabIndex = 20;
            this.grbLine_1.TabStop = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCategory.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCategory.Location = new System.Drawing.Point(10, 130);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(55, 24);
            this.lblCategory.TabIndex = 16;
            this.lblCategory.Text = "ប្រភេទ";
            // 
            // cbbCategory
            // 
            this.cbbCategory.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(136, 130);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(205, 24);
            this.cbbCategory.TabIndex = 17;
            this.cbbCategory.Leave += new System.EventHandler(this.cbbCategory_Leave);
            this.cbbCategory.Enter += new System.EventHandler(this.cbbCategory_Enter);
            // 
            // lblExtraPercentage
            // 
            this.lblExtraPercentage.AutoSize = true;
            this.lblExtraPercentage.Font = new System.Drawing.Font("Khmer OS System", 9.75F,
                                                                   System.Drawing.FontStyle.Bold,
                                                                   System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblExtraPercentage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblExtraPercentage.Location = new System.Drawing.Point(10, 199);
            this.lblExtraPercentage.Name = "lblExtraPercentage";
            this.lblExtraPercentage.Size = new System.Drawing.Size(116, 24);
            this.lblExtraPercentage.TabIndex = 23;
            this.lblExtraPercentage.Text = "ភាគរយបន្ថែម %";
            // 
            // txtExtraPercentage
            // 
            this.txtExtraPercentage.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                   System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtExtraPercentage.Location = new System.Drawing.Point(136, 197);
            this.txtExtraPercentage.Name = "txtExtraPercentage";
            this.txtExtraPercentage.Size = new System.Drawing.Size(205, 23);
            this.txtExtraPercentage.TabIndex = 24;
            this.txtExtraPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtraPercentage.Leave += new System.EventHandler(this.txtExtraPercentage_Leave);
            this.txtExtraPercentage.Enter += new System.EventHandler(this.txtExtraPercentage_Enter);
            // 
            // lblQtyStock
            // 
            this.lblQtyStock.AutoSize = true;
            this.lblQtyStock.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                            System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblQtyStock.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblQtyStock.Location = new System.Drawing.Point(360, 224);
            this.lblQtyStock.Name = "lblQtyStock";
            this.lblQtyStock.Size = new System.Drawing.Size(103, 24);
            this.lblQtyStock.TabIndex = 31;
            this.lblQtyStock.Text = "ចំនូនលក់ចេញ";
            // 
            // txtQtySold
            // 
            this.txtQtySold.Enabled = false;
            this.txtQtySold.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                           System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtQtySold.Location = new System.Drawing.Point(481, 223);
            this.txtQtySold.Name = "txtQtySold";
            this.txtQtySold.Size = new System.Drawing.Size(205, 23);
            this.txtQtySold.TabIndex = 32;
            this.txtQtySold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQtyInStock
            // 
            this.lblQtyInStock.AutoSize = true;
            this.lblQtyInStock.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblQtyInStock.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblQtyInStock.Location = new System.Drawing.Point(360, 198);
            this.lblQtyInStock.Name = "lblQtyInStock";
            this.lblQtyInStock.Size = new System.Drawing.Size(97, 24);
            this.lblQtyInStock.TabIndex = 29;
            this.lblQtyInStock.Text = "ចំនូននៅសល់";
            // 
            // txtQtyInStock
            // 
            this.txtQtyInStock.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                              System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtQtyInStock.Location = new System.Drawing.Point(481, 197);
            this.txtQtyInStock.Name = "txtQtyInStock";
            this.txtQtyInStock.Size = new System.Drawing.Size(205, 23);
            this.txtQtyInStock.TabIndex = 30;
            this.txtQtyInStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyInStock.Leave += new System.EventHandler(this.txtQtyInStock_Leave);
            this.txtQtyInStock.Enter += new System.EventHandler(this.txtQtyInStock_Enter);
            // 
            // lblUnitPriceOut
            // 
            this.lblUnitPriceOut.AutoSize = true;
            this.lblUnitPriceOut.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblUnitPriceOut.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblUnitPriceOut.Location = new System.Drawing.Point(10, 225);
            this.lblUnitPriceOut.Name = "lblUnitPriceOut";
            this.lblUnitPriceOut.Size = new System.Drawing.Size(103, 24);
            this.lblUnitPriceOut.TabIndex = 25;
            this.lblUnitPriceOut.Text = "តំលៃលក់ចេញ";
            // 
            // txtUnitPriceOut
            // 
            this.txtUnitPriceOut.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtUnitPriceOut.Location = new System.Drawing.Point(136, 223);
            this.txtUnitPriceOut.Name = "txtUnitPriceOut";
            this.txtUnitPriceOut.Size = new System.Drawing.Size(205, 23);
            this.txtUnitPriceOut.TabIndex = 26;
            this.txtUnitPriceOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitPriceOut.Leave += new System.EventHandler(this.txtUnitPriceOut_Leave);
            this.txtUnitPriceOut.Enter += new System.EventHandler(this.txtUnitPriceOut_Enter);
            // 
            // lblUnitPriceIn
            // 
            this.lblUnitPriceIn.AutoSize = true;
            this.lblUnitPriceIn.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblUnitPriceIn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblUnitPriceIn.Location = new System.Drawing.Point(10, 173);
            this.lblUnitPriceIn.Name = "lblUnitPriceIn";
            this.lblUnitPriceIn.Size = new System.Drawing.Size(97, 24);
            this.lblUnitPriceIn.TabIndex = 21;
            this.lblUnitPriceIn.Text = "តំលៃទិញចូល";
            // 
            // txtUnitPriceIn
            // 
            this.txtUnitPriceIn.Enabled = false;
            this.txtUnitPriceIn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtUnitPriceIn.Location = new System.Drawing.Point(136, 171);
            this.txtUnitPriceIn.Name = "txtUnitPriceIn";
            this.txtUnitPriceIn.Size = new System.Drawing.Size(205, 23);
            this.txtUnitPriceIn.TabIndex = 22;
            this.txtUnitPriceIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMinQty
            // 
            this.lblMinQty.AutoSize = true;
            this.lblMinQty.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMinQty.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMinQty.Location = new System.Drawing.Point(360, 172);
            this.lblMinQty.Name = "lblMinQty";
            this.lblMinQty.Size = new System.Drawing.Size(104, 24);
            this.lblMinQty.TabIndex = 27;
            this.lblMinQty.Text = "ចំនួនអប្បបរិមា";
            // 
            // txtMinQty
            // 
            this.txtMinQty.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtMinQty.Location = new System.Drawing.Point(481, 171);
            this.txtMinQty.Name = "txtMinQty";
            this.txtMinQty.Size = new System.Drawing.Size(205, 23);
            this.txtMinQty.TabIndex = 28;
            this.txtMinQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinQty.Leave += new System.EventHandler(this.txtMinQty_Leave);
            this.txtMinQty.Enter += new System.EventHandler(this.txtMinQty_Enter);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblRemark.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRemark.Location = new System.Drawing.Point(360, 112);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(101, 24);
            this.lblRemark.TabIndex = 20;
            this.lblRemark.Text = "កំណត់សំគាល់";
            // 
            // rtbRemark
            // 
            this.rtbRemark.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                          System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rtbRemark.Location = new System.Drawing.Point(481, 111);
            this.rtbRemark.Name = "rtbRemark";
            this.rtbRemark.Size = new System.Drawing.Size(205, 43);
            this.rtbRemark.TabIndex = 21;
            this.rtbRemark.Text = "";
            this.rtbRemark.Enter += new System.EventHandler(this.rtbRemark_Enter);
            this.rtbRemark.Leave += new System.EventHandler(this.rtbRemark_Leave);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDisplayName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDisplayName.Location = new System.Drawing.Point(360, 53);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(77, 24);
            this.lblDisplayName.TabIndex = 10;
            this.lblDisplayName.Text = "ឈ្មោះកាត់";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtDisplayName.Location = new System.Drawing.Point(481, 50);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(205, 31);
            this.txtDisplayName.TabIndex = 11;
            this.txtDisplayName.Leave += new System.EventHandler(this.txtDisplayName_Leave);
            this.txtDisplayName.Enter += new System.EventHandler(this.txtDisplayName_Enter);
            // 
            // cmdReset
            // 
            this.cmdReset.Enabled = false;
            this.cmdReset.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdReset.Location = new System.Drawing.Point(416, 262);
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
            this.cmdCancel.Location = new System.Drawing.Point(600, 262);
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
            this.cmdSave.Enabled = false;
            this.cmdSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                        System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmdSave.Image = Resources.OK32;
            this.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.Location = new System.Drawing.Point(508, 262);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(89, 28);
            this.cmdSave.TabIndex = 35;
            this.cmdSave.Text = "&Save   ";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblProductName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblProductName.Location = new System.Drawing.Point(10, 27);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(115, 24);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "ឈ្មោះផលិតផល";
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtProductName.Location = new System.Drawing.Point(136, 24);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(552, 23);
            this.txtProductName.TabIndex = 7;
            this.txtProductName.Leave += new System.EventHandler(this.txtProductName_Leave);
            this.txtProductName.Enter += new System.EventHandler(this.txtProductName_Enter);
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Khmer OS System", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblProductCode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblProductCode.Location = new System.Drawing.Point(10, 53);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(65, 24);
            this.lblProductCode.TabIndex = 8;
            this.lblProductCode.Text = "លេខកូដ";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold,
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtProductCode.Location = new System.Drawing.Point(136, 50);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(205, 23);
            this.txtProductCode.TabIndex = 9;
            this.txtProductCode.Leave += new System.EventHandler(this.txtProductCode_Leave);
            this.txtProductCode.Enter += new System.EventHandler(this.txtProductCode_Enter);
            // 
            // grbPurchaseHistory
            // 
            this.grbPurchaseHistory.Controls.Add(this.tbcInOutHistory);
            this.grbPurchaseHistory.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold,
                                                                   System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.grbPurchaseHistory.Location = new System.Drawing.Point(311, 302);
            this.grbPurchaseHistory.Name = "grbPurchaseHistory";
            this.grbPurchaseHistory.Size = new System.Drawing.Size(700, 272);
            this.grbPurchaseHistory.TabIndex = 37;
            this.grbPurchaseHistory.TabStop = false;
            this.grbPurchaseHistory.Text = "កំណត់ហេតុទិញចូល និង លក់ចេញ";
            // 
            // tbcInOutHistory
            // 
            this.tbcInOutHistory.Controls.Add(this.tbpInHistory);
            this.tbcInOutHistory.Controls.Add(this.tbpOutHistory);
            this.tbcInOutHistory.ItemSize = new System.Drawing.Size(89, 30);
            this.tbcInOutHistory.Location = new System.Drawing.Point(14, 29);
            this.tbcInOutHistory.Name = "tbcInOutHistory";
            this.tbcInOutHistory.SelectedIndex = 0;
            this.tbcInOutHistory.Size = new System.Drawing.Size(672, 230);
            this.tbcInOutHistory.TabIndex = 38;
            // 
            // tbpInHistory
            // 
            this.tbpInHistory.Controls.Add(this.dgvPurchaseHistory);
            this.tbpInHistory.Location = new System.Drawing.Point(4, 34);
            this.tbpInHistory.Name = "tbpInHistory";
            this.tbpInHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInHistory.Size = new System.Drawing.Size(664, 192);
            this.tbpInHistory.TabIndex = 0;
            this.tbpInHistory.Text = "ទិញចូល";
            this.tbpInHistory.UseVisualStyleBackColor = true;
            // 
            // dgvPurchaseHistory
            // 
            this.dgvPurchaseHistory.AllowUserToAddRows = false;
            this.dgvPurchaseHistory.AllowUserToDeleteRows = false;
            this.dgvPurchaseHistory.AllowUserToOrderColumns = true;
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
                                                             this.UnitPrice,
                                                             this.DateIn,
                                                             this.ProductUnitID,
                                                             this.DateExpire,
                                                             this.Quantity,
                                                             this.CellID,
                                                             this.SubTotal,
                                                             this.FKPurchaseOrder,
                                                             this.SupplierID
                                                         });
            this.dgvPurchaseHistory.Location = new System.Drawing.Point(-1, -1);
            this.dgvPurchaseHistory.Name = "dgvPurchaseHistory";
            this.dgvPurchaseHistory.ReadOnly = true;
            this.dgvPurchaseHistory.RowHeadersVisible = false;
            this.dgvPurchaseHistory.RowHeadersWidth = 25;
            this.dgvPurchaseHistory.RowHeadersWidthSizeMode =
                System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPurchaseHistory.RowTemplate.Height = 35;
            this.dgvPurchaseHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseHistory.ShowCellToolTips = false;
            this.dgvPurchaseHistory.Size = new System.Drawing.Size(665, 194);
            this.dgvPurchaseHistory.TabIndex = 39;
            this.dgvPurchaseHistory.TabStop = false;
            this.dgvPurchaseHistory.VirtualMode = true;
            this.dgvPurchaseHistory.DataError +=
                new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPurchaseHistory_DataError);
            // 
            // tbpOutHistory
            // 
            this.tbpOutHistory.Controls.Add(this.dgvSaleHistory);
            this.tbpOutHistory.Location = new System.Drawing.Point(4, 34);
            this.tbpOutHistory.Name = "tbpOutHistory";
            this.tbpOutHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOutHistory.Size = new System.Drawing.Size(664, 192);
            this.tbpOutHistory.TabIndex = 1;
            this.tbpOutHistory.Text = "លក់ចេញ";
            this.tbpOutHistory.UseVisualStyleBackColor = true;
            // 
            // dgvSaleHistory
            // 
            this.dgvSaleHistory.AllowUserToAddRows = false;
            this.dgvSaleHistory.AllowUserToDeleteRows = false;
            this.dgvSaleHistory.AllowUserToOrderColumns = true;
            this.dgvSaleHistory.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSaleHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold,
                                                                   System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSaleHistory.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                                                     {
                                                         this.SaleItemID,
                                                         this.SaleProductID,
                                                         this.SaleBarCodeValue,
                                                         this.UnitPriceOut,
                                                         this.cdcDateOut,
                                                         this.UnitID,
                                                         this.QtyOutStr,
                                                         this.SaleSubTotal,
                                                         this.SaleOrderNumber
                                                     });
            this.dgvSaleHistory.Location = new System.Drawing.Point(-1, -1);
            this.dgvSaleHistory.Name = "dgvSaleHistory";
            this.dgvSaleHistory.ReadOnly = true;
            this.dgvSaleHistory.RowHeadersVisible = false;
            this.dgvSaleHistory.RowHeadersWidth = 25;
            this.dgvSaleHistory.RowHeadersWidthSizeMode =
                System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSaleHistory.RowTemplate.Height = 35;
            this.dgvSaleHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleHistory.ShowCellToolTips = false;
            this.dgvSaleHistory.Size = new System.Drawing.Size(665, 194);
            this.dgvSaleHistory.TabIndex = 40;
            this.dgvSaleHistory.TabStop = false;
            this.dgvSaleHistory.VirtualMode = true;
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
            // PurchaseItemID
            // 
            this.PurchaseItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PurchaseItemID.DataPropertyName = "PurchaseItemID";
            this.PurchaseItemID.HeaderText = "PurchaseItemID";
            this.PurchaseItemID.Name = "PurchaseItemID";
            this.PurchaseItemID.ReadOnly = true;
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
            this.PurchaseOrderID.ReadOnly = true;
            this.PurchaseOrderID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PurchaseOrderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PurchaseOrderID.Visible = false;
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductID.Visible = false;
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
            this.BarCodeValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BarCodeValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BarCodeValue.Width = 200;
            // 
            // UnitPrice
            // 
            this.UnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.UnitPrice.HeaderText = "តំលៃឯកតា";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DateIn
            // 
            this.DateIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateIn.DataPropertyName = "DateIn";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.Format = "d";
            this.DateIn.DefaultCellStyle = dataGridViewCellStyle4;
            this.DateIn.HeaderText = "ថ្ងៃទិញចូល";
            this.DateIn.Name = "DateIn";
            this.DateIn.ReadOnly = true;
            this.DateIn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DateIn.Width = 110;
            // 
            // ProductUnitID
            // 
            this.ProductUnitID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductUnitID.DataPropertyName = "ProductUnitID";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.ProductUnitID.DefaultCellStyle = dataGridViewCellStyle5;
            this.ProductUnitID.HeaderText = "ឯកតា";
            this.ProductUnitID.Name = "ProductUnitID";
            this.ProductUnitID.ReadOnly = true;
            this.ProductUnitID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DateExpire
            // 
            this.DateExpire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateExpire.DataPropertyName = "DateExpire";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.Format = "d";
            this.DateExpire.DefaultCellStyle = dataGridViewCellStyle6;
            this.DateExpire.HeaderText = "ថ្ងៃផុតកំណត់";
            this.DateExpire.Name = "DateExpire";
            this.DateExpire.ReadOnly = true;
            this.DateExpire.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DateExpire.Width = 110;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.Quantity.HeaderText = "បរិមាណ";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Quantity.Width = 80;
            // 
            // CellID
            // 
            this.CellID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CellID.DataPropertyName = "CellID";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.CellID.DefaultCellStyle = dataGridViewCellStyle8;
            this.CellID.HeaderText = "ទីតាំង";
            this.CellID.Name = "CellID";
            this.CellID.ReadOnly = true;
            this.CellID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CellID.Width = 110;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SubTotal.DataPropertyName = "SubTotal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.SubTotal.HeaderText = "សរុប";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FKPurchaseOrder
            // 
            this.FKPurchaseOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FKPurchaseOrder.DataPropertyName = "FKPurchaseOrder";
            this.FKPurchaseOrder.HeaderText = "FKPurchaseOrder";
            this.FKPurchaseOrder.Name = "FKPurchaseOrder";
            this.FKPurchaseOrder.ReadOnly = true;
            this.FKPurchaseOrder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FKPurchaseOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FKPurchaseOrder.Visible = false;
            // 
            // SupplierID
            // 
            this.SupplierID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SupplierID.DataPropertyName = "SupplierID";
            this.SupplierID.HeaderText = "អ្នកផ្គត់ផ្គង់";
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            this.SupplierID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SupplierID.Width = 200;
            // 
            // SaleItemID
            // 
            this.SaleItemID.DataPropertyName = "SaleItemID";
            this.SaleItemID.HeaderText = "SaleItemID";
            this.SaleItemID.Name = "SaleItemID";
            this.SaleItemID.ReadOnly = true;
            this.SaleItemID.Visible = false;
            // 
            // SaleProductID
            // 
            this.SaleProductID.DataPropertyName = "ProductID";
            this.SaleProductID.HeaderText = "ProductID";
            this.SaleProductID.Name = "SaleProductID";
            this.SaleProductID.ReadOnly = true;
            this.SaleProductID.Visible = false;
            // 
            // SaleBarCodeValue
            // 
            this.SaleBarCodeValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SaleBarCodeValue.DataPropertyName = "BarCodeValue";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.SaleBarCodeValue.DefaultCellStyle = dataGridViewCellStyle11;
            this.SaleBarCodeValue.HeaderText = "លេខបារកូដ";
            this.SaleBarCodeValue.Name = "SaleBarCodeValue";
            this.SaleBarCodeValue.ReadOnly = true;
            this.SaleBarCodeValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SaleBarCodeValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SaleBarCodeValue.Width = 200;
            // 
            // UnitPriceOut
            // 
            this.UnitPriceOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitPriceOut.DataPropertyName = "UnitPriceOut";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0";
            this.UnitPriceOut.DefaultCellStyle = dataGridViewCellStyle12;
            this.UnitPriceOut.HeaderText = "តំលៃឯកតា";
            this.UnitPriceOut.Name = "UnitPriceOut";
            this.UnitPriceOut.ReadOnly = true;
            this.UnitPriceOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitPriceOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cdcDateOut
            // 
            this.cdcDateOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cdcDateOut.DataPropertyName = "DateOut";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.Format = "d";
            this.cdcDateOut.DefaultCellStyle = dataGridViewCellStyle13;
            this.cdcDateOut.HeaderText = "ថ្ងៃលក់ចេញ";
            this.cdcDateOut.Name = "cdcDateOut";
            this.cdcDateOut.ReadOnly = true;
            this.cdcDateOut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cdcDateOut.Width = 110;
            // 
            // UnitID
            // 
            this.UnitID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitID.DataPropertyName = "UnitID";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.UnitID.DefaultCellStyle = dataGridViewCellStyle14;
            this.UnitID.HeaderText = "ឯកតា";
            this.UnitID.Name = "UnitID";
            this.UnitID.ReadOnly = true;
            this.UnitID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // QtyOutStr
            // 
            this.QtyOutStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QtyOutStr.DataPropertyName = "QtyOutStr";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = "0";
            this.QtyOutStr.DefaultCellStyle = dataGridViewCellStyle15;
            this.QtyOutStr.HeaderText = "បរិមាណ";
            this.QtyOutStr.Name = "QtyOutStr";
            this.QtyOutStr.ReadOnly = true;
            this.QtyOutStr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QtyOutStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QtyOutStr.Width = 80;
            // 
            // SaleSubTotal
            // 
            this.SaleSubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SaleSubTotal.DataPropertyName = "SubTotal";
            this.SaleSubTotal.HeaderText = "សរុប";
            this.SaleSubTotal.Name = "SaleSubTotal";
            this.SaleSubTotal.ReadOnly = true;
            this.SaleSubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SaleOrderNumber
            // 
            this.SaleOrderNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SaleOrderNumber.DataPropertyName = "SaleOrderNumber";
            this.SaleOrderNumber.HeaderText = "វិក័យប័ត្រ";
            this.SaleOrderNumber.Name = "SaleOrderNumber";
            this.SaleOrderNumber.ReadOnly = true;
            this.SaleOrderNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SaleOrderNumber.Width = 180;
            // 
            // FrmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmProduct";
            this.Text = ".: Product :.";
            this.Load += new System.EventHandler(this.FrmProduct_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grbProductInfo.ResumeLayout(false);
            this.grbProductInfo.PerformLayout();
            this.grbPurchaseHistory.ResumeLayout(false);
            this.tbcInOutHistory.ResumeLayout(false);
            this.tbpInHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvPurchaseHistory)).EndInit();
            this.tbpOutHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvSaleHistory)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}