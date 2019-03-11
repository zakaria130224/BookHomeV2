using EnterpriseSolution.Infrastructure.Repository;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnterpriseSolution.WebService.Reports
{
    public partial class FixedAssetsPurchasedAgainstExpenseBillReport : System.Web.UI.Page
    {
        private readonly ReportRepository reportRepository;

        public FixedAssetsPurchasedAgainstExpenseBillReport()
        {
            reportRepository = new ReportRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IEnumerable<SqlParameter> parameter = null;
                var records = reportRepository.GetStoredProcedureRecords("FixedAssetsPurchasedAgainstExpenseBill", parameter);
                FixedAssetsPurchasedAgainstExpenseBillReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/FixedAssetsPurchasedAgainstExpenseBillReport.rdlc");
                FixedAssetsPurchasedAgainstExpenseBillReportViewer.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("FixedAssetsPurchasedAgainstExpenseBillDataSet", records.Tables[0]);
                FixedAssetsPurchasedAgainstExpenseBillReportViewer.LocalReport.DataSources.Add(rdc);
                FixedAssetsPurchasedAgainstExpenseBillReportViewer.LocalReport.Refresh();
                FixedAssetsPurchasedAgainstExpenseBillReportViewer.DataBind();
            }
        }
    }
}