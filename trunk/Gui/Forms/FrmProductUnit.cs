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
    public partial class FrmProductUnit : Form
    {
        private bool _IsModified;
        private ProductService _ProductService;
        //private BindingList<object> _ProductUnits;
        private DataTable _ProductUnits;

        public FrmProductUnit()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProductUnit_Load(object sender, EventArgs e)
        {
            SetModifiedStatus(false);

            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            _ProductUnits = CommonService.IListToDataTable(typeof (ProductUnit), _ProductService.GetProductUnits());
            _ProductUnits.Rows.RemoveAt(0);
            dgvProductUnit.DataSource = _ProductUnits;
        }

        private void dgvProductUnit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(true);
        }

        private void SetModifiedStatus(bool modifiedStatus)
        {
            _IsModified = modifiedStatus;
        }

        private void dgvProductUnit_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModified)
                return;

            if (dgvProductUnit.Rows[e.RowIndex].Cells["UnitName"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                var productUnit = new ProductUnit();
                string requestCode;

                if (dgvProductUnit.Rows[e.RowIndex].Cells["UnitID"].Value is DBNull)
                    requestCode = Resources.OperationRequestInsert;
                else
                {
                    requestCode = Resources.OperationRequestUpdate;
                    productUnit.UnitID = Int32.Parse(dgvProductUnit.Rows[e.RowIndex].Cells["UnitID"].Value.ToString());
                }
                productUnit.UnitName = dgvProductUnit.Rows[e.RowIndex].Cells["UnitName"].Value.ToString();
                productUnit.Description = dgvProductUnit.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                _ProductService.ProductUnitManagement(productUnit, requestCode);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void dgvProductUnit_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(false);
        }

        private void dgvProductUnit_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void dgvProductUnit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        private void dgvProductUnit_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductUnit.CurrentRow == null)
                return;
        }
    }
}