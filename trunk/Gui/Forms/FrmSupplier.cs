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
    public partial class FrmSupplier : Form
    {
        private bool _IsModified;
        private DataTable _Suppliers;
        private SupplierService _SupplierService;

        public FrmSupplier()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(global::PharmaStock.Properties.Resources.PermissionSUPMNG))
            //    Application.Exit();

            SetModifiedStatus(false);

            if (_SupplierService == null)
                _SupplierService = ServiceFactory.GenerateServiceInstance().GenerateSupplierService();

            _Suppliers = CommonService.IListToDataTable(typeof (Supplier), _SupplierService.GetSuppliers());

            dgvSupplier.DataSource = _Suppliers;
        }

        private void SetModifiedStatus(bool modifiedStatus)
        {
            _IsModified = modifiedStatus;
        }

        private void dgvSupplier_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(true);
        }

        private void dgvSupplier_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModified)
                return;

            if (dgvSupplier.Rows[e.RowIndex].Cells["SupplierName"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                var supplier = new Supplier();
                string requestCode;

                if (dgvSupplier.Rows[e.RowIndex].Cells["SupplierID"].Value is DBNull)
                    requestCode = Resources.OperationRequestInsert;
                else
                {
                    requestCode = Resources.OperationRequestUpdate;
                    supplier.SupplierID = Int32.Parse(dgvSupplier.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());
                }
                supplier.SupplierName = dgvSupplier.Rows[e.RowIndex].Cells["SupplierName"].Value.ToString();
                supplier.Address = dgvSupplier.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                supplier.Telephone = dgvSupplier.Rows[e.RowIndex].Cells["Telephone"].Value.ToString();
                supplier.Email = dgvSupplier.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                supplier.Website = dgvSupplier.Rows[e.RowIndex].Cells["Website"].Value.ToString();

                _SupplierService.SupplierManagement(supplier, requestCode);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void dgvSupplier_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(false);
        }

        private void dgvSupplier_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }
    }
}