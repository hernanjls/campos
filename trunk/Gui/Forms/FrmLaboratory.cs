using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using EzPos.Control;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUI
{
    public partial class FrmLaboratory : Form
    {
        private bool _IsModified;
        private DataTable _Laboratories;
        private ProductService _ProductService;

        public FrmLaboratory()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLaboratory_Load(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(global::PharmaStock.Properties.Resources.PermissionLABMNG))
            //    Application.Exit();

            SetModifiedStatus(false);

            if (_ProductService == null)
                _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();

            IList countryList = _ProductService.GetCountries();
            CountryID.DataSource = countryList;
            CountryID.DisplayMember = Country.CONST_COUNTRY_NAME;
            CountryID.ValueMember = Country.CONST_COUNTRY_ID;

            _Laboratories = CommonService.IListToDataTable(typeof (Laboratory), _ProductService.GetLaboratories());
            dgvLaboratory.DataSource = _Laboratories;
        }

        private void SetModifiedStatus(bool modifiedStatus)
        {
            _IsModified = modifiedStatus;
        }

        private void dgvLaboratory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(true);
        }

        private void dgvLaboratory_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!_IsModified)
                return;

            if (dgvLaboratory.Rows[e.RowIndex].Cells["CountryID"].Value is DBNull)
                e.Cancel = true;

            if (dgvLaboratory.Rows[e.RowIndex].Cells["LaboratoryName"].Value is DBNull)
                e.Cancel = true;

            if (e.Cancel)
                return;

            try
            {
                var laboratory = new Laboratory();
                string requestCode;

                if (dgvLaboratory.Rows[e.RowIndex].Cells["LaboratoryID"].Value is DBNull)
                    requestCode = Resources.OperationRequestInsert;
                else
                {
                    requestCode = Resources.OperationRequestUpdate;
                    laboratory.LaboratoryID =
                        Int32.Parse(dgvLaboratory.Rows[e.RowIndex].Cells["LaboratoryID"].Value.ToString());
                }
                laboratory.LaboratoryName = dgvLaboratory.Rows[e.RowIndex].Cells["LaboratoryName"].Value.ToString();
                laboratory.CountryID = Int32.Parse(dgvLaboratory.Rows[e.RowIndex].Cells["CountryID"].Value.ToString());
                laboratory.Address = dgvLaboratory.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                laboratory.Telephone = dgvLaboratory.Rows[e.RowIndex].Cells["Telephone"].Value.ToString();
                laboratory.Email = dgvLaboratory.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                laboratory.Website = dgvLaboratory.Rows[e.RowIndex].Cells["Website"].Value.ToString();

                _ProductService.LaboratoryManagement(laboratory, requestCode);
            }
            catch (Exception exception)
            {
                MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", exception.Message);
            }
        }

        private void dgvLaboratory_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SetModifiedStatus(false);
        }

        private void dgvLaboratory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBoxHandler.UnknownErrorMessage("Message.Caption.UnknownError", e.Exception.Message);
        }
    }
}