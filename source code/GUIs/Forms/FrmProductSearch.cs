using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EzPos.Model.Product;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Product;

namespace EzPos.GUIs.Forms
{
    public partial class FrmProductSearch : Form
    {
        private CommonService _commonService;
        private ProductService _productService;
        private BindingList<Product> _productList;
        private string _codeProduct;

        public FrmProductSearch()
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

        public string CodeProduct
        {
            set { _codeProduct = value; }
        }

        public Product Product { get; private set; }

        private void ProductFetching()
        {
            if(string.IsNullOrEmpty(txtProductCode.Text))
            {
                _productList.Clear();
                return;
            }

            var searchCriteria = new List<string>();
            if (txtProductCode.Text.Length != 0)
            {
                searchCriteria.Add(
                    "(ProductCode LIKE '%" + txtProductCode.Text + "%') OR " +
                    "(ForeignCode LIKE '%" + txtProductCode.Text + "%')");
            }

            if (_productService == null)
                _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            _productList.Clear();
            IListToBindingList(
                _productService.GetCatalogs(searchCriteria, true));
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            try
            {
                if (_productService == null)
                    _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                if (_commonService == null)
                    _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                InitializeProductList();

                if (!string.IsNullOrEmpty(_codeProduct))
                {
                    txtProductCode.Text = _codeProduct;
                    ProductFetching();
                }
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void BtnSaveMouseEnter(object sender, EventArgs e)
        {
            btnValidate.BackgroundImage = Resources.background_9;
        }

        private void BtnSaveMouseLeave(object sender, EventArgs e)
        {
            btnValidate.BackgroundImage = Resources.background_2;
        }

        private void BtnCancelMouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void BtnCancelMouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        private void TxtProductCodeEnter(object sender, EventArgs e)
        {
            //txtProductCode.TextChanged += ProductFetching;
        }

        private void TxtProductCodeLeave(object sender, EventArgs e)
        {
            //txtProductCode.TextChanged -= ProductFetching;
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

        private void IListToBindingList(IList productList)
        {
            if (productList == null)
                throw new ArgumentNullException("productList", "Product List");

            if (_productList == null)
            {
                btnValidate.Enabled = false;
                return;
            }

            try
            {
                _productList.Clear();
                foreach (Product product in productList)
                {
                    SetProductPicture(product);
                    _productList.Add(product);
                }

                btnValidate.Enabled = _productList.Count != 0;                
            }
            catch (Exception exception)
            {
                FrmExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void TxtProductCodeKeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;

            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (_productList.Count == 0)
                            return;
                        UpdateSelectedIndex(dgvProduct.SelectedRows[0].Index - 1);
                        break;
                    case Keys.Down:
                        if (_productList.Count == 0)
                            return;
                        UpdateSelectedIndex(dgvProduct.SelectedRows[0].Index + 1);
                        break;
                    case Keys.Return:
                        if (!txtProductCode.Text.Equals(_codeProduct))
                        {
                            _codeProduct = txtProductCode.Text;
                            ProductFetching();
                            return;
                        }

                        if (!btnValidate.Enabled)
                            return;

                        DialogResult = Product != null ? DialogResult.OK : DialogResult.Cancel;
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

        private void UpdateSelectedIndex(int selectedIndex)
        {
            if (_productList != null)
            {
                if (selectedIndex < 0)
                {
                    if (_productList.Count == 1)
                    {
                        return;
                    }
                    selectedIndex = 0;
                }

                if (selectedIndex == _productList.Count)
                    return;
            }

            dgvProduct.Rows[selectedIndex].Selected = true;

            if (selectedIndex < dgvProduct.FirstDisplayedScrollingRowIndex)
                dgvProduct.FirstDisplayedScrollingRowIndex = selectedIndex;
            else if ((selectedIndex - dgvProduct.FirstDisplayedScrollingRowIndex) < 0)
                dgvProduct.FirstDisplayedScrollingRowIndex -= 1;
            else
            {
                if (selectedIndex >=
                    (dgvProduct.DisplayedRowCount(true) + dgvProduct.FirstDisplayedScrollingRowIndex - 1))
                {
                    if (_productList != null)
                        if ((selectedIndex - dgvProduct.DisplayedRowCount(true) + 2) >=
                            _productList.Count)
                            return;

                    dgvProduct.FirstDisplayedScrollingRowIndex =
                        selectedIndex - dgvProduct.DisplayedRowCount(true) + 2;
                }
            }
        }

        private void DgvProductSelectionChanged(object sender, EventArgs e)
        {
            if ((_productList.Count == 0) || (dgvProduct.CurrentRow == null))
            {
                Product = null;
                return;
            }            

            Product = _productList[dgvProduct.SelectedRows[0].Index];
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
    }
}