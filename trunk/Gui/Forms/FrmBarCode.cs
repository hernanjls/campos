using System;
using System.Collections;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.Model;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUI
{
    public partial class FrmBarCode : Form
    {
        private IList _ProductList;
        private PurchaseOrderService _PurchaseOrderService;

        public FrmBarCode()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmBarCode_Load(object sender, EventArgs e)
        {
            if (_PurchaseOrderService == null)
                _PurchaseOrderService = ServiceFactory.GenerateServiceInstance().GeneratePurchaseOrderService();

            ProductService productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
            _ProductList = productService.GetProducts();
            ProductID.DataSource = _ProductList;
            if (_ProductList.Count != 0)
            {
                ProductID.DisplayMember = Product.CONST_PRODUCT_DISPLAY_NAME;
                ProductID.ValueMember = Product.CONST_PRODUCT_ID;
            }

            PopulateList();
        }

        private void PopulateList()
        {
            IList purchaseItemList = _PurchaseOrderService.GetPurchaseItemsWithCustomizedBarCode();
            dgvPurchaseItemBarCode.DataSource = CommonService.IListToDataTable(typeof (PurchaseItem), purchaseItemList);

            int nbrTotalCol = dgvPurchaseItemBarCode.Columns.Count;
            for (int colIndex = 0; colIndex < nbrTotalCol; colIndex++)
            {
                if (dgvPurchaseItemBarCode.Columns[colIndex].Name.Equals("ProductID"))
                    continue;
                if (dgvPurchaseItemBarCode.Columns[colIndex].Name.Equals("BarCodeValue"))
                    continue;
                if (dgvPurchaseItemBarCode.Columns[colIndex].Name.Equals("Quantity"))
                    continue;

                dgvPurchaseItemBarCode.Columns.RemoveAt(colIndex);
                colIndex = 0;
                nbrTotalCol = dgvPurchaseItemBarCode.Columns.Count;
            }
        }

        private void dgvLaboratory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseItemBarCode.CurrentRow == null)
                return;

            if (dgvPurchaseItemBarCode.CurrentRow.IsNewRow)
                return;

            if (dgvPurchaseItemBarCode.CurrentRow.Cells["ProductID"].Value is DBNull)
                return;

            if (dgvPurchaseItemBarCode.CurrentRow.Cells["ProductID"].Value == null)
                return;

            if (dgvPurchaseItemBarCode.CurrentRow.Cells["BarCodeValue"].Value is DBNull)
                return;

            if (dgvPurchaseItemBarCode.CurrentRow.Cells["BarCodeValue"].Value == null)
                return;

            try
            {
                int selectedProductID =
                    Int32.Parse(dgvPurchaseItemBarCode.CurrentRow.Cells["ProductID"].Value.ToString());
                string productDisplayName = string.Empty;
                foreach (Product product in _ProductList)
                {
                    if (product.ProductID == selectedProductID)
                    {
                        productDisplayName = product.DisplayName;
                        break;
                    }
                }

                if (productDisplayName.Length == 0)
                    return;

                PrintBarCode(
                    dgvPurchaseItemBarCode.CurrentRow.Cells["BarCodeValue"].Value.ToString(),
                    productDisplayName);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private static void PrintBarCode(string barCodeValue, string productDisplayName)
        {
            //Print
            var barCodePrintHandler = new BarCodePrintHandler();
            barCodePrintHandler.ProductDisplayName = productDisplayName;
            barCodePrintHandler.BarCodeValue = barCodeValue;
            //barCodePrintHandler.QtyPrint = qtyPrint;
            barCodePrintHandler.InializePrinting();
        }
    }
}