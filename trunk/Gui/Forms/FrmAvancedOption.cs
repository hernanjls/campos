using System;
using EzPos.Properties;
using EzPos.Service;

namespace EzPos.GUI.Forms
{
    public partial class FrmAvancedOption : FrmBase
    {
        public FrmAvancedOption()
        {
            InitializeComponent();
        }

        private void cmdProductCategory_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionPRDCAT))
                return;

            using (var frmProductCategory = new FrmProductCategory())
            {
                frmProductCategory.ShowDialog(this);
            }
        }

        private void cmdSupplier_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionSUPMNG))
                return;

            using (var frmSupplier = new FrmSupplier())
            {
                frmSupplier.ShowDialog(this);
            }
        }

        private void cmdOrigin_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionORGMNG))
                return;

            using (var frmCountry = new FrmCountry())
            {
                frmCountry.ShowDialog(this);
            }
        }

        private void cmdLaboratory_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionLABMNG))
                return;

            using (var frmLaboratory = new FrmLaboratory())
            {
                frmLaboratory.ShowDialog(this);
            }
        }

        private void cmdAvailableProduct_Click(object sender, EventArgs e)
        {
            using (var frmProductAvailable = new FrmProductAvailable())
            {
                frmProductAvailable.ShowDialog(this);
            }
        }

        private void cmdLocation_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionLOCMNG))
                return;

            using (var frmLocation = new FrmLocation())
            {
                frmLocation.ShowDialog(this);
            }
        }

        private void cmdExchangeRate_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionEXCRAT))
                return;

            using (var frmExchangeRate = new FrmExchangeRate())
            {
                frmExchangeRate.ShowDialog(this);
            }
        }

        private void cmdProductUnit_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionPRDUNT))
                return;

            using (var frmProductUnit = new FrmProductUnit())
            {
                frmProductUnit.ShowDialog(this);
            }
        }

        private void FrmAvancedOption_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Configuration";
            cmdAdvancedOption.Enabled = false;
        }

        private void cmdBarCode_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionBRCPRN))
                return;

            using (var frmBarCode = new FrmBarCode())
            {
                frmBarCode.ShowDialog(this);
            }
        }

        private void cmdReport_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionBRWRPT))
                return;

            using (var frmAssessment = new FrmAssessment())
            {
                frmAssessment.ShowDialog(this);
            }
        }
    }
}