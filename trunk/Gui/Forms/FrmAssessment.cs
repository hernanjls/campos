using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using EzPos.GUI.DataSets;
using EzPos.GUI.Reports;
using EzPos.Model;
using EzPos.Service;

namespace EzPos.GUI
{
    public partial class FrmAssessment : Form
    {
        public FrmAssessment()
        {
            InitializeComponent();
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (tbcAssessment.SelectedTab.Name)
            {
                case "tbpAdministrator":
                    refreshReportAdmin();
                    break;
                case "tbpCashier":
                    refreshReportCashier();
                    break;
                case "tbpStock":
                    if (rdbStock.Checked)
                        refreshReportStock();
                    else if (rdbOutOfStock.Checked)
                        refreshReportStockCriticalQty();
                    else
                        refreshReportStockCriticalExpire();
                    break;
                default:
                    if (rdbAllPO.Checked)
                        refreshReportPO();
                    else if (rdbPaidPO.Checked)
                        refreshReportPaidPO();
                    else
                        refreshReportUnPaidPO();
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void refreshReportAdmin()
        {
            ReportService reportService = ServiceFactory.GenerateServiceInstance().GenerateReportService();
            IList assessmentList = reportService.GetAssessments(dtpStartAdmin.Value.ToString("MM/dd/yyyy"),
                                                                dtpStopAdmin.Value.ToString("MM/dd/yyyy"));

            DataSet dtsAssessment = new DtsAssessment();
            PropertyInfo[] PropertyInfos = typeof (Assessment).GetProperties();
            foreach (object objInstance in assessmentList)
            {
                DataRow dataRow = dtsAssessment.Tables[0].NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsAssessment.Tables[0].Rows.Add(dataRow);
            }

            var rptAssessment = new RptAssessmentAdmin();
            rptAssessment.SetDataSource(dtsAssessment);
            crvAssessment.ReportSource = rptAssessment;
        }

        private void refreshReportCashier()
        {
            ReportService reportService = ServiceFactory.GenerateServiceInstance().GenerateReportService();
            IList assessmentList = reportService.GetAssessments(dtpStartCashier.Value.ToString("MM/dd/yyyy"),
                                                                dtpStopCashier.Value.ToString("MM/dd/yyyy"));

            DataSet dtsAssessment = new DtsAssessment();
            PropertyInfo[] PropertyInfos = typeof (Assessment).GetProperties();
            foreach (object objInstance in assessmentList)
            {
                DataRow dataRow = dtsAssessment.Tables[0].NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsAssessment.Tables[0].Rows.Add(dataRow);
            }

            var rptAssessment = new RptAssessmentCashier();
            rptAssessment.SetDataSource(dtsAssessment);
            crvAssessment.ReportSource = rptAssessment;
        }

        private void refreshReportStock()
        {
            ReportService reportService = ServiceFactory.GenerateServiceInstance().GenerateReportService();
            IList assessmentList = reportService.GetAssessmentsStock();

            DataSet dtsAssessment = new DtsAssessment();
            PropertyInfo[] PropertyInfos = typeof (Product).GetProperties();
            foreach (object objInstance in assessmentList)
            {
                DataRow dataRow = dtsAssessment.Tables[1].NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsAssessment.Tables[1].Rows.Add(dataRow);
            }

            var rptAssessment = new RptStock();
            rptAssessment.SetDataSource(dtsAssessment);
            crvAssessment.ReportSource = rptAssessment;
        }

        private void refreshReportStockCriticalQty()
        {
            ReportService reportService = ServiceFactory.GenerateServiceInstance().GenerateReportService();
            IList assessmentList = reportService.GetAssessmentsStockCriticalQty();

            DataSet dtsAssessment = new DtsAssessment();
            PropertyInfo[] PropertyInfos = typeof (Product).GetProperties();
            foreach (object objInstance in assessmentList)
            {
                DataRow dataRow = dtsAssessment.Tables[1].NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsAssessment.Tables[1].Rows.Add(dataRow);
            }

            var rptAssessment = new RptStock();
            rptAssessment.SetDataSource(dtsAssessment);
            crvAssessment.ReportSource = rptAssessment;
        }

        private void refreshReportStockCriticalExpire()
        {
            ReportService reportService = ServiceFactory.GenerateServiceInstance().GenerateReportService();
            IList assessmentList = reportService.GetAssessmentsStockCriticalExpire();

            DataSet dtsAssessment = new DtsAssessment();
            PropertyInfo[] PropertyInfos = typeof (Product).GetProperties();
            foreach (object objInstance in assessmentList)
            {
                DataRow dataRow = dtsAssessment.Tables[1].NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsAssessment.Tables[1].Rows.Add(dataRow);
            }

            var rptAssessment = new RptStockExpire();
            rptAssessment.SetDataSource(dtsAssessment);
            crvAssessment.ReportSource = rptAssessment;
        }

        private void refreshReportPO()
        {
            PurchaseOrderService purchaseOrderService =
                ServiceFactory.GenerateServiceInstance().GeneratePurchaseOrderService();
            IList assessmentList = purchaseOrderService.GetPurchaseOrdersReporting();

            DataSet dtsAssessment = new DtsAssessment();
            PropertyInfo[] PropertyInfos = typeof (PurchaseOrderReport).GetProperties();
            foreach (object objInstance in assessmentList)
            {
                DataRow dataRow;
                dataRow = dtsAssessment.Tables[2].NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsAssessment.Tables[2].Rows.Add(dataRow);
            }

            var rptAssessment = new RptPurchaseOrder();
            rptAssessment.SetDataSource(dtsAssessment);
            crvAssessment.ReportSource = rptAssessment;
        }

        private void refreshReportPaidPO()
        {
            PurchaseOrderService purchaseOrderService =
                ServiceFactory.GenerateServiceInstance().GeneratePurchaseOrderService();
            IList assessmentList = purchaseOrderService.GetPaidPurchaseOrdersReporting();

            DataSet dtsAssessment = new DtsAssessment();
            PropertyInfo[] PropertyInfos = typeof (PurchaseOrderReport).GetProperties();
            foreach (object objInstance in assessmentList)
            {
                DataRow dataRow;
                dataRow = dtsAssessment.Tables[2].NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsAssessment.Tables[2].Rows.Add(dataRow);
            }

            var rptAssessment = new RptPurchaseOrder();
            rptAssessment.SetDataSource(dtsAssessment);
            crvAssessment.ReportSource = rptAssessment;
        }

        private void refreshReportUnPaidPO()
        {
            PurchaseOrderService purchaseOrderService =
                ServiceFactory.GenerateServiceInstance().GeneratePurchaseOrderService();
            IList assessmentList = purchaseOrderService.GetUnpaidPurchaseOrdersReporting();

            DataSet dtsAssessment = new DtsAssessment();
            PropertyInfo[] PropertyInfos = typeof (PurchaseOrderReport).GetProperties();
            foreach (object objInstance in assessmentList)
            {
                DataRow dataRow;
                dataRow = dtsAssessment.Tables[2].NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                dtsAssessment.Tables[2].Rows.Add(dataRow);
            }

            var rptAssessment = new RptPurchaseOrder();
            rptAssessment.SetDataSource(dtsAssessment);
            crvAssessment.ReportSource = rptAssessment;
        }
    }
}