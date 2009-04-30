using System;
using System.Data;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUI
{
    public partial class FrmProductCategory : Form
    {
        private bool _IsModified;
        private DataTable _ProductCategories;
        private ProductService _ProductService;

        public FrmProductCategory()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProductCategory_Load(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(global::PharmaStock.Properties.Resources.PermissionPRDCAT))
            //    Application.Exit();

            SetModifiedStatus(false);

            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            _ProductCategories = CommonService.IListToDataTable(typeof (ProductCategory),
                                                                _ProductService.GetCategories());
            dgvCategory.DataSource = _ProductCategories;
        }

        private void dgvCategory_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(false);
        }

        private void dgvCategory_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModified)
                return;

            if (dgvCategory.Rows[e.RowIndex].Cells["CategoryName"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                var productCategory = new ProductCategory();
                string requestCode;

                if (dgvCategory.Rows[e.RowIndex].Cells["CategoryID"].Value is DBNull)
                    requestCode = Resources.OperationRequestInsert;
                else
                {
                    requestCode = Resources.OperationRequestUpdate;
                    productCategory.CategoryID =
                        Int32.Parse(dgvCategory.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString());
                }
                productCategory.CategoryName = dgvCategory.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();

                _ProductService.ProductCategoryManagement(productCategory, requestCode);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void dgvCategory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        private void dgvCategory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(true);
        }

        private void SetModifiedStatus(bool modifiedStatus)
        {
            _IsModified = modifiedStatus;
        }
    }
}