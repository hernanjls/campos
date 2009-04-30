using System;
using System.Threading;
using System.Windows.Forms;
using EzPos.Model.Common;
using EzPos.Service;
using EzPos.Service.Common;
using EzPos.Service.Expense;

namespace EzPos.GUI.Forms
{
    public partial class FrmSplash : Form
    {
        public static ApplicationContext _ApplicationContext;
        private CommonService _CommonService;
        private CustomerService _CustomerService;
        private ProductService _ProductService;
        private SaleOrderService _SaleOrderService;
        private ExpenseService _ExpenseService;
        private UserService _UserService;

        public FrmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            ThreadStart threadStart = RetrieveConfiguration;
            var thread = new Thread(threadStart) {Priority = ThreadPriority.Lowest};
            thread.Start();
        }

        private void RetrieveConfiguration()
        {
            string briefMsg, detailMsg;
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
                    _CommonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
                    pgbService.Value += 15;
                    _SaleOrderService = ServiceFactory.GenerateServiceInstance().GenerateSaleOrderService();
                    pgbService.Value += 15;
                    _ProductService = ServiceFactory.GenerateServiceInstance().GenerateProductService();
                    pgbService.Value += 15;

                    _CustomerService = ServiceFactory.GenerateServiceInstance().GenerateCustomerService();
                    pgbService.Value += 20;
                    _ExpenseService = ServiceFactory.GenerateServiceInstance().GenerateExpenseService();
                    pgbService.Value += 20;
                    _UserService = ServiceFactory.GenerateServiceInstance().GenerateUserService();

                    //Connecting to database                    
                    pgbGlobalConfig.Value += 50;
                    _CommonService.InitializeGlobalConfiguration();
                    pgbGlobalConfig.Value += 50;

                    //Initializing workspace
                    pgbInitialization.Value += 30;
                    _CommonService.InitializeWorkSpace();
                    pgbInitialization.Value += 30;
                    if (AppContext.Counter == null)
                    {
                        briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                        detailMsg = Properties.Resources.MsgCounterNotInitialize;
                        using (var frmMessageBox = new FrmMessageBox())
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
                        frmLogIn.UserService = _UserService;                        
                        if (frmLogIn.ShowDialog(this) == DialogResult.OK)
                        {
                            Visible = true;

                            var frmMain = new FrmMain();
                            _ApplicationContext.MainForm = frmMain;

                            frmMain.CommonService = _CommonService;
                            frmMain.SaleOrderService = _SaleOrderService;
                            frmMain.ProductService = _ProductService;
                            frmMain.CustomerService = _CustomerService;
                            frmMain.ExpenseService = _ExpenseService;
                            frmMain.UserService = _UserService;

                            _CommonService.InitializeCustomizedConfiguration(frmLogIn.User);
                            pgbCustomizedConfig.Value += 20;

                            ////////_CommonService.InsertOperationLog(
                            ////////    AppContext.User.UserID,
                            ////////    int.Parse(Resources.OperationLogIn));

                            Close();
                            frmMain.Show();
                        }
                        else
                            _ApplicationContext.ExitThread();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.InnerException.ToString());
                briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                detailMsg = Properties.Resources.MsgConnectionLost;
                using (var frmMessageBox = new FrmMessageBox())
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
                _ApplicationContext = new ApplicationContext(frmSplash);
                Application.Run(_ApplicationContext);
            }
            catch (Exception)
            {
                var briefMsg = "អំពីការចូលទៅក្នុងប្រព័ន្ឋ";
                var detailMsg = Properties.Resources.MsgConnectionLost;
                using (var frmMessageBox = new FrmMessageBox())
                {
                    frmMessageBox.BriefMsgStr = briefMsg;
                    frmMessageBox.DetailMsgStr = detailMsg;
                    frmMessageBox.IsCanceledOnly = true;
                    frmMessageBox.ShowDialog();
                }
            }
        }

        #region Nested type: SafeCrossCallBackDelegate

        private delegate void SafeCrossCallBackDelegate();

        #endregion
    }
}