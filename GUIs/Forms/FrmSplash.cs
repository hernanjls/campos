using System;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Product;
using EzPos.Service.SaleOrder;

namespace EzPos.GUIs.Forms
{
    public partial class FrmSplash : Form
    {
        public static ApplicationContext ApplicationContext;
        private CommonService _commonService;
        private CustomerService _customerService;
        private SupplierService _supplierService;
        private ExpenseService _expenseService;
        private ProductService _productService;
        private SaleOrderService _saleOrderService;
        private UserService _userService;

        public FrmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            //var deadLine = new DateTime(2010, 6, 30);
            //if (DateTime.Now.CompareTo(deadLine) >= 0)
            //{
            //    const string briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
            //    var detailMsg = Resources.MsgTrialPeriodExpire;
            //    using (var frmMessageBox = new ExtendedMessageBox())
            //    {
            //        frmMessageBox.BriefMsgStr = briefMsg;
            //        frmMessageBox.DetailMsgStr = detailMsg;
            //        frmMessageBox.IsCanceledOnly = true;
            //        frmMessageBox.ShowDialog(this);
            //        Close();
            //        return;
            //    }
            //}

            ThreadStart threadStart = RetrieveConfiguration;
            var thread = new Thread(threadStart)
                             {
                                 Priority = ThreadPriority.Lowest
                             };
            thread.Start();

            //ThreadStart crystalReportThreadStart = PreLoadCrystalReport;
            //var crystalReportThread = new Thread(crystalReportThreadStart)
            //                              {
            //                                  Priority = ThreadPriority.Lowest
            //                              };
            //crystalReportThread.Start();
        }

        private void RetrieveConfiguration()
        {
            try
            {
                SafeCrossCallBackDelegate safeCrossCallBackDelegate = null;

                if (pnlBody_Right.InvokeRequired)
                    safeCrossCallBackDelegate = RetrieveConfiguration;

                if (pnlBody_Right.InvokeRequired)
                    Invoke(safeCrossCallBackDelegate);
                else
                {
                    Thread.Sleep(100);

                    //Loading Service
                    pgbService.Value += 15;
                    _commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
                    pgbService.Value += 15;
                    _saleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
                    pgbService.Value += 15;
                    _productService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
                    pgbService.Value += 15;
                    _customerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
                    pgbService.Value += 15;
                    _supplierService = ServiceFactory.GenerateServiceInstance().GenerateSupplierService();
                    pgbService.Value += 15;
                    _expenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
                    pgbService.Value += 10;
                    _userService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

                    //Connecting to database                    
                    pgbGlobalConfig.Value += 50;
                    _commonService.InitializeGlobalConfiguration();
                    pgbGlobalConfig.Value += 50;

                    //Initializing workspace
                    pgbInitialization.Value += 30;
                    _commonService.InitializeWorkSpace();
                    pgbInitialization.Value += 30;
                    if (AppContext.Counter == null)
                    {
                        const string briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                        var detailMsg = Resources.MsgCounterNotInitialize;
                        using (var frmMessageBox = new FrmExtendedMessageBox())
                        {
                            frmMessageBox.BriefMsgStr = briefMsg;
                            frmMessageBox.DetailMsgStr = detailMsg;
                            frmMessageBox.IsCanceledOnly = true;
                            frmMessageBox.ShowDialog(this);
                            Close();
                            return;
                        }
                    }
                    pgbInitialization.Value += 40;

                    //Loading configuration
                    pgbCustomizedConfig.Value += 80;
                    Visible = false;

                    using (var frmLogIn = new FrmLogIn())
                    {
                        frmLogIn.UserService = _userService;
                        if (frmLogIn.ShowDialog(this) == DialogResult.OK)
                        {
                            Visible = true;

                            var frmMain = new FrmMain();
                            ApplicationContext.MainForm = frmMain;

                            frmMain.CommonService = _commonService;
                            frmMain.SaleOrderService = _saleOrderService;
                            frmMain.ProductService = _productService;
                            frmMain.CustomerService = _customerService;
                            frmMain.SupplierService = _supplierService;
                            frmMain.ExpenseService = _expenseService;
                            frmMain.UserService = _userService;

                            _commonService.InitializeCustomizedConfiguration(frmLogIn.User);
                            pgbCustomizedConfig.Value += 20;

                            _commonService.InsertOperationLog(
                                AppContext.User.UserID,
                                int.Parse(Resources.OperationLogIn));

                            frmMain.Show();
                            Close();
                        }
                        else
                            ApplicationContext.ExitThread();
                    }
                }
            }
            catch (Exception exception)
            {
                const string briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                var detailMsg = Resources.MsgConnectionLost;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog(this);
                    Close();
                }
            }
        }

        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var frmSplash = new FrmSplash();

                //Keep application context
                ApplicationContext = new ApplicationContext(frmSplash);
                Application.Run(ApplicationContext);
            }
            catch (Exception)
            {
                const string briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                var detailMsg = Resources.MsgConnectionLost;
                using (var frmMessageBox = new FrmExtendedMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog();
                }
            }
        }

        //private static void PreLoadCrystalReport()
        //{
        //    //var csrEmpty = new CsrEmpty();
        //    ////csrEmpty.SetDataSource(null);
        //    //var crvReport = new CrystalReportViewer();
        //    //crvReport.ReportSource = csrEmpty;            
        //}

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}