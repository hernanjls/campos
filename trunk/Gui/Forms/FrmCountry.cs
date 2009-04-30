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
    public partial class FrmCountry : Form
    {
        private DataTable _Countries;
        private bool _IsModified;
        private ProductService _ProductService;

        public FrmCountry()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCountry_Load(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(global::PharmaStock.Properties.Resources.PermissionORGMNG))
            //    Application.Exit();

            SetModifiedStatus(false);

            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            _Countries = CommonService.IListToDataTable(typeof (Country), _ProductService.GetCountries());
            dgvCountry.DataSource = _Countries;
        }

        private void dgvCountry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }

        private void SetModifiedStatus(bool modifiedStatus)
        {
            _IsModified = modifiedStatus;
        }

        private void dgvCountry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(true);
        }

        private void dgvCountry_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(false);
        }

        private void dgvCountry_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModified)
                return;

            if (dgvCountry.Rows[e.RowIndex].Cells["CountryName"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                var country = new Country();
                string requestCode;

                if (dgvCountry.Rows[e.RowIndex].Cells["CountryID"].Value is DBNull)
                    requestCode = Resources.OperationRequestInsert;
                else
                {
                    requestCode = Resources.OperationRequestUpdate;
                    country.CountryID = Int32.Parse(dgvCountry.Rows[e.RowIndex].Cells["CountryID"].Value.ToString());
                }
                country.CountryName = dgvCountry.Rows[e.RowIndex].Cells["CountryName"].Value.ToString();

                _ProductService.CountryManagement(country, requestCode);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }
    }
}