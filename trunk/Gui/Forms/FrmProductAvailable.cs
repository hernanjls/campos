using System;
using System.Collections;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.Model;
using EzPos.Service;

namespace EzPos.GUI
{
    public partial class FrmProductAvailable : Form
    {
        private ProductService _ProductService;
        private int _SelctedProductID;
        private int curIndex = -1;

        public FrmProductAvailable()
        {
            InitializeComponent();
        }

        public int SelctedProductID
        {
            get { return _SelctedProductID; }
            set { _SelctedProductID = value; }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProductAvailable_Load(object sender, EventArgs e)
        {
            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            IList objList;
            objList = _ProductService.GetProductUnits();
            LatestUnitID.DataSource = objList;
            if (objList.Count != 0)
            {
                LatestUnitID.DisplayMember = ProductUnit.CONST_UNIT_NAME;
                LatestUnitID.ValueMember = ProductUnit.CONST_UNIT_ID;
            }

            objList = _ProductService.GetLocations();
            LatestLocationID.DataSource = objList;
            if (objList.Count != 0)
            {
                LatestLocationID.DisplayMember = ProductLocation.CONST_CELL_NAME;
                LatestLocationID.ValueMember = ProductLocation.CONST_CELL_ID;
            }

            PopulateProductList();

            if (txtProductSearch.CanFocus)
                txtProductSearch.Focus();
        }

        private void dgvCategory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        public void PopulateProductList()
        {
            IList objList = _ProductService.GetAvailableProducts();
            dgvProductAvailable.DataSource = objList;

            int nbrTotalCol = dgvProductAvailable.Columns.Count;
            for (int colIndex = 0; colIndex < nbrTotalCol; colIndex++)
            {
                if (dgvProductAvailable.Columns[colIndex].Name.Equals("ProductID"))
                    continue;
                if (dgvProductAvailable.Columns[colIndex].Name.Equals("Product_Name"))
                    continue;
                if (dgvProductAvailable.Columns[colIndex].Name.Equals("QtyInStock"))
                    continue;
                if (dgvProductAvailable.Columns[colIndex].Name.Equals("LatestUnitID"))
                    continue;
                if (dgvProductAvailable.Columns[colIndex].Name.Equals("LatestLocationID"))
                    continue;

                dgvProductAvailable.Columns.RemoveAt(colIndex);
                colIndex = 0;
                nbrTotalCol = dgvProductAvailable.Columns.Count;
            }

            cmbAvailableProduct.DataSource = objList;
            if (objList.Count != 0)
            {
                cmbAvailableProduct.DisplayMember = Product.CONST_PRODUCT_NAME;
                cmbAvailableProduct.ValueMember = Product.CONST_PRODUCT_ID;
                dgvProductAvailable.CurrentRow.Selected = false;
            }
            dgvProductAvailable.Columns["ProductID"].DisplayIndex = 0;
            dgvProductAvailable.Columns["Product_Name"].DisplayIndex = 1;
            dgvProductAvailable.Columns["QtyInStock"].DisplayIndex = 2;
            dgvProductAvailable.Columns["LatestUnitID"].DisplayIndex = 3;
            dgvProductAvailable.Columns["LatestLocationID"].DisplayIndex = 4;
        }

        private void dgvProductAvailable_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProductAvailable.CurrentRow.Cells["ProductID"].Value is DBNull)
                return;

            _SelctedProductID = Int32.Parse(dgvProductAvailable.CurrentRow.Cells["ProductID"].Value.ToString());
            DialogResult = DialogResult.OK;
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtProductSearch.Text.Length != 0)
                cmbAvailableProduct.SelectedIndex = cmbAvailableProduct.FindString(txtProductSearch.Text);
            else
                cmbAvailableProduct.SelectedIndex = -1;

            curIndex = cmbAvailableProduct.SelectedIndex;
        }

        private void cmbAvailableProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbAvailableProduct.DisplayMember == "") || (cmbAvailableProduct.ValueMember == ""))
                return;

            if (cmbAvailableProduct.SelectedIndex != -1)
                dgvProductAvailable.Rows[cmbAvailableProduct.SelectedIndex].Selected = true;
            else
                dgvProductAvailable.CurrentRow.Selected = false;
        }

        private void FrmProductAvailable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
                return;
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        //Abort 
                        DialogResult = DialogResult.Cancel;
                        break;
                    case Keys.Up:
                        if (curIndex == -1)
                            break;
                        curIndex -= 1;
                        cmbAvailableProduct.SelectedIndex = curIndex;
                        txtProductSearch.TextChanged -= txtProductSearch_TextChanged;
                        if (curIndex == -1)
                            txtProductSearch.Text = "";
                        else
                            txtProductSearch.Text = ((Product) cmbAvailableProduct.SelectedItem).ProductName;
                        txtProductSearch.TextChanged += txtProductSearch_TextChanged;
                        break;
                    case Keys.Down:
                        if (curIndex == (cmbAvailableProduct.Items.Count - 1))
                            break;
                        curIndex += 1;
                        cmbAvailableProduct.SelectedIndex = curIndex;
                        txtProductSearch.TextChanged -= txtProductSearch_TextChanged;
                        txtProductSearch.Text = ((Product) cmbAvailableProduct.SelectedItem).ProductName;
                        txtProductSearch.TextChanged += txtProductSearch_TextChanged;
                        break;
                    case Keys.Enter:
                        if (curIndex == -1)
                            break;
                        dgvProductAvailable_DoubleClick(sender, e);
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

        private void txtProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
            FrmProductAvailable_KeyDown(sender, e);
        }

        private void dgvProductAvailable_KeyDown(object sender, KeyEventArgs e)
        {
            curIndex = dgvProductAvailable.CurrentRow.Index;
            FrmProductAvailable_KeyDown(sender, e);
        }
    }
}