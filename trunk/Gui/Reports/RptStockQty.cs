﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace EzPos.GUI.Reports
{
    public class RptStockQty : ReportClass
    {
        public override string ResourceName
        {
            get { return "RptStockQty.rpt"; }
            set
            {
                // Do nothing
            }
        }

        public override bool NewGenerator
        {
            get { return true; }
            set
            {
                // Do nothing
            }
        }

        public override string FullResourceName
        {
            get { return "EzPos.GUI.Reports.RptStockQty.rpt"; }
            set
            {
                // Do nothing
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section1
        {
            get { return ReportDefinition.Sections[0]; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section2
        {
            get { return ReportDefinition.Sections[1]; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section3
        {
            get { return ReportDefinition.Sections[2]; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section4
        {
            get { return ReportDefinition.Sections[3]; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section5
        {
            get { return ReportDefinition.Sections[4]; }
        }
    }

    [ToolboxBitmap(typeof (ExportOptions), "report.bmp")]
    public class CachedRptStockQty : System.ComponentModel.Component, ICachedReport
    {
        #region ICachedReport Members

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCacheable
        {
            get { return true; }
            set
            {
                // 
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool ShareDBLogonInfo
        {
            get { return false; }
            set
            {
                // 
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual TimeSpan CacheTimeOut
        {
            get { return CachedReportConstants.DEFAULT_TIMEOUT; }
            set
            {
                // 
            }
        }

        public virtual ReportDocument CreateReport()
        {
            var rpt = new RptStockQty();
            rpt.Site = Site;
            return rpt;
        }

        public virtual string GetCustomizedCacheKey(RequestContext request)
        {
            String key = null;
            // // The following is the code used to generate the default
            // // cache key for caching report jobs in the ASP.NET Cache.
            // // Feel free to modify this code to suit your needs.
            // // Returning key == null causes the default cache key to
            // // be generated.
            // 
            // key = RequestContext.BuildCompleteCacheKey(
            //     request,
            //     null,       // sReportFilename
            //     this.GetType(),
            //     this.ShareDBLogonInfo );
            return key;
        }

        #endregion
    }
}