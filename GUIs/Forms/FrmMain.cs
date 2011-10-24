using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EzPos.GUIs.Components;
using EzPos.GUIs.Controls;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Product;
using EzPos.Service.SaleOrder;

namespace EzPos.GUIs.Forms
{
    public partial class FrmMain : Form
    {
        private CommonService _commonService;
        private CustomerService _customerService;
        private SupplierService _supplierService;
        private ExpenseService _expenseService;
        private ProductService _productService;
        private SaleOrderService _saleOrderService;
        private UserControl _userControl;
        private UserService _userService;

        public FrmMain()
        {
            InitializeComponent();
        }

        public CommonService CommonService
        {
            set { _commonService = value; }
        }

        public SaleOrderService SaleOrderService
        {
            set { _saleOrderService = value; }
        }

        public ProductService ProductService
        {
            set { _productService = value; }
        }

        public CustomerService CustomerService
        {
            set { _customerService = value; }
        }

        public SupplierService SupplierService
        {
            set { _supplierService = value; }
        }

        public ExpenseService ExpenseService
        {
            set { _expenseService = value; }
        }

        public UserService UserService
        {
            set { _userService = value; }
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
                BtnSaleOrderClick(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionProduct))
            {
                BtnProductClick(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionCustomer))
            {
                BtnCustomerClick(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionCard))
            {
                BtnDiscountCardClick(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionExpense))
            {
                BtnExpenseClick(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionReport))
            {
                BtnReportClick(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionUser))
            {
                BtnUserClick(sender, e);
                return;
            }

            if (UserService.AllowToPerform(Resources.PermissionConfig))
            {
                BtnConfigurationClick(sender, e);
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

        private void TmrRefreshTick(object sender, EventArgs e)
        {
            UpdateDateInfo();
        }

        private void BtnQuitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSaleOrderClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionSaleOrder))
                return;

            SetDisableToButton("btnSaleOrder");

            var ctrlSale = 
                new CtrlSale
                {
                    ProductService = _productService,
                    SaleOrderService = _saleOrderService,
                    CustomerService = _customerService
                };

            InsertBodyControl(ctrlSale);
        }

        private void BtnProductClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionProduct))
                return;

            SetDisableToButton("btnProduct");

            var ctrlCatalog = 
                new CtrlCatalog
                {
                    ProductService = _productService, 
                    CommonService = _commonService
                };

            InsertBodyControl(ctrlCatalog);
        }

        private void SetDisableToButton(string btnName)
        {
            foreach (var button in from Control button in pnlFooter.Controls
                                       where button.GetType() == typeof (ExtendedButton)
                                       where button.Name != "btnQuit"
                                       select button)
            {
                button.Enabled = button.Name != btnName;
            }
        }

        private void InsertBodyControl(UserControl usrControl)
        {
            foreach (UserControl userControl in pnlBody.Controls)
                userControl.Dispose();

            _userControl = usrControl;
            _userControl.AutoScaleMode = AutoScaleMode.Dpi;
            _userControl.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(_userControl);
        }

        private void BtnCustomerClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionCustomer))
                return;

            SetDisableToButton("btnCustomer");

            var ctrlCustomer = new CtrlCustomer {CustomerService = _customerService, CommonService = _commonService};

            InsertBodyControl(ctrlCustomer);
        }

        private void BtnDiscountCardClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionCard))
                return;

            SetDisableToButton("btnDiscountCard");

            var ctrlDiscountCard = 
                new CtrlDiscountCard
                {
                    CustomerService = _customerService,
                    CommonService = _commonService
                };

            InsertBodyControl(ctrlDiscountCard);
        }

        private void BtnConfigurationClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionConfig))
                return;
            SetDisableToButton("btnConfiguration");
            InsertBodyControl(new CtrlAppParam());
        }

        private void BtnReportClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionReport))
                return;

            SetDisableToButton("btnReport");

            var ctrlReport = new CtrlReport();

            InsertBodyControl(ctrlReport);
        }

        private void BtnUserClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionUser))
                return;

            SetDisableToButton("btnUser");

            var ctrlUser = new CtrlUser {CommonService = _commonService, UserService = _userService};

            InsertBodyControl(ctrlUser);
        }

        private void BtnExpenseClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionExpense))
                return;

            SetDisableToButton("btnExpense");

            var ctrlExpense = 
                new CtrlExpense
                {
                    CommonService = _commonService, 
                    ExpenseService = _expenseService
                };

            InsertBodyControl(ctrlExpense);
        }

        private void BtnSupplierClick(object sender, EventArgs e)
        {
            if (!UserService.AllowToPerform(Resources.PermissionSupplier))
                return;

            SetDisableToButton("btnSupplier");

            var ctrlSupplier = 
                new CtrlSupplier
                {
                    SupplierService = _supplierService,
                    CommonService = _commonService
                };

            InsertBodyControl(ctrlSupplier);
        }
    }
}