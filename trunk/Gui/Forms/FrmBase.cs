using System;
using System.Windows.Forms;
using EzPos.GUI.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;

namespace EzPos.GUI.Forms
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmd1_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionRCDSAL))
                return;

            var frmSaleOrder = new FrmSaleOrder();
            frmSaleOrder.Show();
            Close();
        }

        private void cmd2_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionPRDMNG))
                return;

            var frmProduct = new FrmProduct();
            frmProduct.Show();
            Close();
        }

        private void cmd3_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionUSRMNG))
                return;

            var frmUser = new FrmUser();
            frmUser.Show();
            Close();
        }

        private void cmd4_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionCUSMNG))
                return;

            var frmCustomer = new FrmCustomer();
            frmCustomer.Show();
            Close();
        }

        private void cmd5_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionPCOMNG))
                return;

            var frmPurchaseOrder = new FrmPurchaseOrder();
            frmPurchaseOrder.Show();
            Close();
        }

        private void cmdAdvancedOption_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionAVNOPT))
                return;

            var frmAvancedOption = new FrmAvancedOption();
            frmAvancedOption.Show();
            Close();
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            SetHeaderInfo();
        }

        private void SetHeaderInfo()
        {
            var headerStr = DateTime.Now.ToLongDateString() + "   " +
                               "\n" +
                               DateTime.Now.ToLongTimeString() + "   ";
            if (UserContext._User != null)
                headerStr += "\n" + UserContext._User.UserName + "   ";
            if (UserContext._Counter != null)
                headerStr += " - " + UserContext._Counter.CounterName + "   ";
            lblHeaderInfo.Text = headerStr;
        }
    }
}