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
    public partial class FrmProductSearch : Form
    {
        private CommonService _CommonService;
        private ProductService _ProductService;
        private BindingList<Product> _ProductList;
        private string _CodeProduct;

        public FrmProductSearch()
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

        public string CodeProduct
        {
            set { _CodeProduct = value; }
        }

        public Product Product { get; private set; }

        private void ProductFetching()
        {
            if(string.IsNullOrEmpty(txtProductCode.Text))
            {
                _ProductList.Clear();
                return;
            }

            var searchCriteria = new List<string>();
            if (txtProductCode.Text.Length != 0)
            {
                searchCriteria.Add(
                    "(ProductCode LIKE '%" + txtProductCode.Text + "%') OR " +
                    "(ForeignCode LIKE '%" + txtProductCode.Text + "%')");
            }

            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            _ProductList.Clear();
            IListToBindingList(
                _ProductService.GetCatalogs(searchCriteria, true));
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            try
            {
                if (_ProductService == null)
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

                if (_CommonService == null)
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();

                InitializeProductList();

                if (!string.IsNullOrEmpty(_CodeProduct))
                {
                    txtProductCode.Text = _CodeProduct;
                    ProductFetching();
                }
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnValidate.BackgroundImage = Resources.background_9;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnValidate.BackgroundImage = Resources.background_2;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_9;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.background_2;
        }

        private void txtProductCode_Enter(object sender, EventArgs e)
        {
            //txtProductCode.TextChanged += ProductFetching;
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            //txtProductCode.TextChanged -= ProductFetching;
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

        private void IListToBindingList(IList productList)
        {
            if (productList == null)
                throw new ArgumentNullException("productList", "Product List");

            if (_ProductList == null)
            {
                btnValidate.Enabled = false;
                return;
            }

            try
            {
                _ProductList.Clear();
                foreach (Product product in productList)
                {
                    SetProductPicture(product);
                    _ProductList.Add(product);
                }

                btnValidate.Enabled = _ProductList.Count != 0;                
            }
            catch (Exception exception)
            {
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;

            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (_ProductList.Count == 0)
                            return;
                        UpdateSelectedIndex(dgvProduct.SelectedRows[0].Index - 1);
                        break;
                    case Keys.Down:
                        if (_ProductList.Count == 0)
                            return;
                        UpdateSelectedIndex(dgvProduct.SelectedRows[0].Index + 1);
                        break;
                    case Keys.Return:
                        if (!txtProductCode.Text.Equals(_CodeProduct))
                        {
                            _CodeProduct = txtProductCode.Text;
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
                ExtendedMessageBox.UnknownErrorMessage(
                    Resources.MsgCaptionUnknownError,
                    exception.Message);
            }
        }

        private void UpdateSelectedIndex(int selectedIndex)
        {
            if (_ProductList != null)
            {
                if (selectedIndex < 0)
                {
                    if (_ProductList.Count == 1)
                    {
                        return;
                    }
                    selectedIndex = 0;
                }

                if (selectedIndex == _ProductList.Count)
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
                    if (_ProductList != null)
                        if ((selectedIndex - dgvProduct.DisplayedRowCount(true) + 2) >=
                            _ProductList.Count)
                            return;

                    dgvProduct.FirstDisplayedScrollingRowIndex =
                        selectedIndex - dgvProduct.DisplayedRowCount(true) + 2;
                }
            }
        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if ((_ProductList.Count == 0) || (dgvProduct.CurrentRow == null))
            {
                Product = null;
                return;
            }            

            Product = _ProductList[dgvProduct.SelectedRows[0].Index];
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