using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model.Common;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Expense;

namespace EzPos.GUI
{
    public partial class FrmMain : Form
    {
        private CommonService _CommonService;
        private CustomerService _CustomerService;
        private ProductService _ProductService;
        private SaleOrderService _SaleOrderService;
        private UserControl _UserControl;
        private ExpenseService _ExpenseService;
        private UserService _UserService;

        public FrmMain()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _CommonService = value; }
        }

        public SaleOrderService SaleOrderService
        {
            set { _SaleOrderService = value; }
        }

        public ProductService ProductService
        {
            set { _ProductService = value; }
        }

        public CustomerService CustomerService
        {
            set { _CustomerService = value; }
        }

        public ExpenseService ExpenseService
        {
            set { _ExpenseService = value; }
        }

        public UserService UserService
        {
            set { _UserService = value; }
        }

        private static void SynchronizePicture()
        {
            try
            {
                //string remotePath = AppContext.ServerPhotoPath;
                //string localPath = AppContext.Counter.ProductPhotoNetworkPath;

                //CommonService.DoSynchronizePhoto(remotePath, localPath);
            }
            catch (Exception exception)
            {
                //CommonService.RecordLog(exception.Message);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ThreadStart threadStart = SynchronizePicture;
            var thread = new Thread(threadStart) {Priority = ThreadPriority.Lowest};
            thread.Start();

            lblProductName.Text = AppContext.ShopName;

            UpdateDateInfo();
            //if (UserService.AllowToPerform(Resources.PermissionSaleOrder))
            //{
            //    btnSaleOrder_Click(sender, e);
            //    return;
            //}

            //if (UserService.AllowToPerform(Resources.PermissionProduct))
            //{
            //    btnProduct_Click(sender, e);
            //    return;
            //}

            //if (UserService.AllowToPerform(Resources.PermissionCustomer))
            //{
            //    btnCustomer_Click(sender, e);
            //    return;
            //}

            //if (UserService.AllowToPerform(Resources.PermissionCard))
            //{
            //    btnDiscountCard_Click(sender, e);
            //    return;
            //}

            //if (UserService.AllowToPerform(Resources.PermissionExpense))
            //{
            //    btnExpense_Click(sender, e);
            //    return;
            //}

            //if (UserService.AllowToPerform(Resources.PermissionReport))
            //{
            //    btnReport_Click(sender, e);
            //    return;
            //}

            //if (UserService.AllowToPerform(Resources.PermissionUser))
            //{
            //    btnUser_Click(sender, e);
            //    return;
            //}

            //if (UserService.AllowToPerform(Resources.PermissionConfig))
            //{
            //    btnConfiguration_Click(sender, e);
            //    return;
            //}
        }

        private void UpdateDateInfo()
        {
            lblDateInfo.Text = DateTime.Now.ToShortDateString() +
                "\n" + DateTime.Now.ToLongTimeString() +
                "\n" + AppContext.User.LogInName;
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            UpdateDateInfo();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaleOrder_Click(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(Resources.PermissionSaleOrder))
            //    return;

            //SetDisableToButton("btnSaleOrder");

            //CtrlSale ctrlSale = new CtrlSale();
            //ctrlSale.ProductService = _ProductService;
            //ctrlSale.SaleOrderService = _SaleOrderService;
            //ctrlSale.CustomerService = _CustomerService;

            //InsertBodyControl(ctrlSale);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(Resources.PermissionProduct))
            //    return;

            //SetDisableToButton("btnProduct");

            //CtrlCatalog ctrlCatalog = new CtrlCatalog();
            //ctrlCatalog.ProductService = _ProductService;
            //ctrlCatalog.CommonService = _CommonService;

            //InsertBodyControl(ctrlCatalog);
        }

        private void SetDisableToButton(string btnName)
        {
            foreach (System.Windows.Forms.Control button in pnlFooter.Controls)
            {
                if (button.GetType() != typeof (Button)) 
                    continue;

                if (button.Name == "btnQuit")
                    continue;

                button.Enabled = button.Name != btnName;
            }
        }

        private void InsertBodyControl(UserControl usrControl)
        {
            foreach (UserControl userControl in pnlBody.Controls)
                userControl.Dispose();
            _UserControl = usrControl;
            _UserControl.AutoScaleMode = AutoScaleMode.Dpi;
            _UserControl.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(_UserControl);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(Resources.PermissionCustomer))
            //    return;

            //SetDisableToButton("btnCustomer");

            //CtrlCustomer ctrlCustomer = new CtrlCustomer();
            //ctrlCustomer.CustomerService = _CustomerService;
            //ctrlCustomer.CommonService = _CommonService;

            //InsertBodyControl(new CtrlCustomer());
        }

        private void btnDiscountCard_Click(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(Resources.PermissionCard))
            //    return;

            //SetDisableToButton("btnDiscountCard");

            //CtrlDiscountCard ctrlDiscountCard = new CtrlDiscountCard();
            //ctrlDiscountCard.CustomerService = _CustomerService;
            //ctrlDiscountCard.CommonService = _CommonService;

            //InsertBodyControl(ctrlDiscountCard);
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(Resources.PermissionConfig))
            //    return;
            //SetDisableToButton("btnConfiguration");
            //InsertBodyControl(new CtrlAppParam());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(Resources.PermissionReport))
            //    return;

            //SetDisableToButton("btnReport");

            //CtrlReport ctrlReport = new CtrlReport();

            //InsertBodyControl(ctrlReport);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(Resources.PermissionUser))
            //    return;

            //SetDisableToButton("btnUser");

            //CtrlUser ctrlUser = new CtrlUser();
            //ctrlUser.CommonService = _CommonService;
            //ctrlUser.UserService = _UserService;

            //InsertBodyControl(ctrlUser);
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            //if (!UserService.AllowToPerform(Resources.PermissionExpense))
            //    return;

            //SetDisableToButton("btnExpense");

            //CtrlExpense ctrlExpense = new CtrlExpense();
            //ctrlExpense.CommonService = _CommonService;
            //ctrlExpense.ExpenseService = _ExpenseService;

            //InsertBodyControl(ctrlExpense);
        }

        private void btnSaleOrder_MouseEnter(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnSaleOrder, Resources.background_9);
        }

        private void btnProduct_MouseEnter(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnProduct, Resources.background_9);
        }

        private void btnUser_MouseEnter(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnUser, Resources.background_9);
        }

        private void btnCustomer_MouseEnter(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnCustomer, Resources.background_9);
        }

        private void btnDiscountCard_MouseEnter(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnDiscountCard, Resources.background_9);
        }

        private void btnConfiguration_MouseEnter(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnConfiguration, Resources.background_9);
        }

        private void btnReport_MouseEnter(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnReport, Resources.background_9);
        }

        private void btnExpense_MouseEnter(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnExpense, Resources.background_9);
        }

        private void btnSaleOrder_MouseLeave(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnSaleOrder, Resources.bg_mouse_enter);
        }

        private void btnProduct_MouseLeave(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnProduct, Resources.bg_mouse_enter);
        }

        private void btnUser_MouseLeave(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnUser, Resources.bg_mouse_enter);
        }

        private void btnCustomer_MouseLeave(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnCustomer, Resources.bg_mouse_enter);
        }

        private void btnDiscountCard_MouseLeave(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnDiscountCard, Resources.bg_mouse_enter);
        }

        private void btnConfiguration_MouseLeave(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnConfiguration, Resources.bg_mouse_enter);
        }

        private void btnReport_MouseLeave(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnReport, Resources.bg_mouse_enter);
        }

        private void btnExpense_MouseLeave(object sender, EventArgs e)
        {
            //SetBackGroundImage(btnExpense, Resources.bg_mouse_enter);
        }

        private static void SetBackGroundImage(System.Windows.Forms.Control button, Image backgroundImage)
        {
            button.BackgroundImage = backgroundImage;
        }
    }
}