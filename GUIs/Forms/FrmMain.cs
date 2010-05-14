using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUIs.Controls;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;

namespace EzPos.GUIs.Forms
{
    public partial class FrmMain : Form
    {
        private CommonService _CommonService;
        private CustomerService _CustomerService;
        private SupplierService _SupplierService;
        private ExpenseService _ExpenseService;
        private ProductService _ProductService;
        private SaleOrderService _SaleOrderService;
        private UserControl _UserControl;
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

        public SupplierService SupplierService
        {
            set { _SupplierService = value; }
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
                var remotePath = AppContext.ServerPhotoPath;
                var localPath = AppContext.Counter.ProductPhotoNetworkPath;

                CommonService.DoSynchronizePhoto(remotePath, localPath);
            }
            catch (Exception exception)
            {
                CommonService.RecordLog(exception.Message, Application.StartupPath);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ThreadStart threadStart = SynchronizePicture;
            var thread = new Thread(threadStart) {Priority = ThreadPriority.Lowest};
            thread.Start();

            lblProductName.Text = AppContext.ShopName;

            UpdateDateInfo();
            if (UserService.AllowToPerform(Resources.PermissionSaleOrder))
            {
                btnSaleOrder_Click(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionProduct))
            {
                btnProduct_Click(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionCustomer))
            {
                btnCustomer_Click(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionCard))
            {
                btnDiscountCard_Click(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionExpense))
            {
                btnExpense_Click(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionReport))
            {
                btnReport_Click(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionUser))
            {
                btnUser_Click(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionConfig))
            {
                btnConfiguration_Click(sender, e);
                return;
            }
        }

        private void UpdateDateInfo()
        {
            lblDateInfo.Text = 
                DateTime.Now.ToShortDateString() +
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
            if (!UserService.AllowToPerform(Resources.PermissionSaleOrder))
                return;

            SetDisableToButton("btnSaleOrder");

            var ctrlSale = 
                new CtrlSale
                {
                    ProductService = _ProductService,
                    SaleOrderService = _SaleOrderService,
                    CustomerService = _CustomerService
                };

            InsertBodyControl(ctrlSale);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionProduct))
                return;

            SetDisableToButton("btnProduct");

            var ctrlCatalog = 
                new CtrlCatalog
                {
                    ProductService = _ProductService, 
                    CommonService = _CommonService
                };

            InsertBodyControl(ctrlCatalog);
        }

        private void SetDisableToButton(string btnName)
        {
            foreach (Control button in pnlFooter.Controls)
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
            if (!UserService.AllowToPerform(Resources.PermissionCustomer))
                return;

            SetDisableToButton("btnCustomer");

            var ctrlCustomer = new CtrlCustomer {CustomerService = _CustomerService, CommonService = _CommonService};

            InsertBodyControl(ctrlCustomer);
        }

        private void btnDiscountCard_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionCard))
                return;

            SetDisableToButton("btnDiscountCard");

            var ctrlDiscountCard = 
                new CtrlDiscountCard
                {
                    CustomerService = _CustomerService,
                    CommonService = _CommonService
                };

            InsertBodyControl(ctrlDiscountCard);
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionConfig))
                return;
            SetDisableToButton("btnConfiguration");
            InsertBodyControl(new CtrlAppParam());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionReport))
                return;

            SetDisableToButton("btnReport");

            var ctrlReport = new CtrlReport();
            //var ctrlReport = new CtrlReportTest();

            InsertBodyControl(ctrlReport);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionUser))
                return;

            SetDisableToButton("btnUser");

            var ctrlUser = new CtrlUser {CommonService = _CommonService, UserService = _UserService};

            InsertBodyControl(ctrlUser);
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionExpense))
                return;

            SetDisableToButton("btnExpense");

            var ctrlExpense = 
                new CtrlExpense
                {
                    CommonService = _CommonService, 
                    ExpenseService = _ExpenseService
                };

            InsertBodyControl(ctrlExpense);
        }

        private void btnSaleOrder_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnSaleOrder, Resources.background_9);
        }

        private void btnProduct_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnProduct, Resources.background_9);
        }

        private void btnUser_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnUser, Resources.background_9);
        }

        private void btnCustomer_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnCustomer, Resources.background_9);
        }

        private void btnDiscountCard_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnDiscountCard, Resources.background_9);
        }

        private void btnConfiguration_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnConfiguration, Resources.background_9);
        }

        private void btnReport_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnReport, Resources.background_9);
        }

        private void btnExpense_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnExpense, Resources.background_9);
        }

        private void btnSaleOrder_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnSaleOrder, Resources.background_2);
        }

        private void btnProduct_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnProduct, Resources.background_2);
        }

        private void btnUser_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnUser, Resources.background_2);
        }

        private void btnCustomer_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnCustomer, Resources.background_2);
        }

        private void btnDiscountCard_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnDiscountCard, Resources.background_2);
        }

        private void btnConfiguration_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnConfiguration, Resources.background_2);
        }

        private void btnReport_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnReport, Resources.background_2);
        }

        private void btnExpense_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnExpense, Resources.background_2);
        }

        private static void SetBackGroundImage(Control button, Image backgroundImage)
        {
            button.BackgroundImage = backgroundImage;
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionSupplier))
                return;

            SetDisableToButton("btnSupplier");

            var ctrlSupplier = 
                new CtrlSupplier
                {
                    SupplierService = _SupplierService,
                    CommonService = _CommonService
                };

            InsertBodyControl(ctrlSupplier);
        }

        private void btnSupplier_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundImage(btnSupplier, Resources.background_9);
        }

        private void btnSupplier_MouseLeave(object sender, EventArgs e)
        {
            SetBackGroundImage(btnSupplier, Resources.background_2);
        }
    }
}