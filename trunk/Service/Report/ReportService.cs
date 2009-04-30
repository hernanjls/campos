using System;
using System.Collections;
using EzPos.DataAccess;

namespace EzPos.Service
{
    public class ReportService
    {
        private readonly ReportDataAccess _ReportDataAccess;

        public ReportService(ReportDataAccess reportDataAccess)
        {
            _ReportDataAccess = reportDataAccess;
        }

        public virtual IList GetAssessments()
        {
            return _ReportDataAccess.GetAssessments();
        }

        public virtual IList GetAssessments(string startDate, string stopDate)
        {
            if (startDate == null)
                throw new ArgumentNullException("startDate", "Start Date");

            if (stopDate == null)
                throw new ArgumentNullException("stopDate", "Stop Date");

            return _ReportDataAccess.GetAssessments(startDate, stopDate);
        }

        public virtual IList GetAssessmentsStock()
        {
            return _ReportDataAccess.GetAssessmentsStock();
        }

        public virtual IList GetAssessmentsStockCriticalQty()
        {
            return _ReportDataAccess.GetAssessmentsStockCriticalQty();
        }

        public virtual IList GetAssessmentsStockCriticalExpire()
        {
            return _ReportDataAccess.GetAssessmentsStockCriticalExpire();
        }
    }
}