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
    public partial class FrmLocation : Form
    {
        private bool _IsModified;
        private DataTable _Locations;
        private ProductService _ProductService;

        public FrmLocation()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(global::PharmaStock.Properties.Resources.PermissionLOCMNG))
            //    Application.Exit();

            SetModifiedStatus(false);

            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            _Locations = CommonService.IListToDataTable(typeof (ProductLocation), _ProductService.GetLocations());
            dgvLocation.DataSource = _Locations;
        }

        private void SetModifiedStatus(bool modifiedStatus)
        {
            _IsModified = modifiedStatus;
        }

        private void dgvLocation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(true);
        }

        private void dgvLocation_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModified)
                return;

            if (dgvLocation.Rows[e.RowIndex].Cells["CellName"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                var productLocation = new ProductLocation();
                string requestCode;

                if (dgvLocation.Rows[e.RowIndex].Cells["CellID"].Value is DBNull)
                    requestCode = Resources.OperationRequestInsert;
                else
                {
                    requestCode = Resources.OperationRequestUpdate;
                    productLocation.CellID = Int32.Parse(dgvLocation.Rows[e.RowIndex].Cells["CellID"].Value.ToString());
                }
                productLocation.CellName = dgvLocation.Rows[e.RowIndex].Cells["CellName"].Value.ToString();
                productLocation.CabinetID = 1;

                _ProductService.LocationManagement(productLocation, requestCode);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void dgvLocation_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(false);
        }

        private void dgvLocation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }
    }
}