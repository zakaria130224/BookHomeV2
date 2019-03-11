using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Infrastructure.EnterpriseDbContext;
using EnterpriseSolution.Infrastructure.Repository;
using Microsoft.Reporting.WebForms;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnterpriseSolution.WebService.Reports
{
    public partial class DailyTransactionReport : System.Web.UI.Page
    {
        private readonly ReportRepository reportRepository;
        
        public DailyTransactionReport()
        {
            reportRepository = new ReportRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IEnumerable<SqlParameter> parameter = null;
                var records = reportRepository.GetStoredProcedureRecords("DailyTransactionList", parameter);
                DailyTransactionReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/DailyTransactionReport.rdlc");
                DailyTransactionReportViewer.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("DailyTransactionDataSet", records.Tables[0]);
                DailyTransactionReportViewer.LocalReport.DataSources.Add(rdc);
                DailyTransactionReportViewer.LocalReport.Refresh();
                DailyTransactionReportViewer.DataBind();
            }
        }
    }
}