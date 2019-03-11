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
    public partial class WriteOffOfFixedAsset : System.Web.UI.Page
    {
        private readonly ReportRepository reportRepository;

        public WriteOffOfFixedAsset()
        {
            reportRepository = new ReportRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IEnumerable<SqlParameter> parameter = null;
                var records = reportRepository.GetStoredProcedureRecords("WriteOffOfFixedAsset", parameter);
                WriteOffOfFixedAssetReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/WriteOffOfFixedAssetReport.rdlc");
                WriteOffOfFixedAssetReportViewer.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("WriteOffOfFixedAssetDataSet", records.Tables[0]);
                WriteOffOfFixedAssetReportViewer.LocalReport.DataSources.Add(rdc);
                WriteOffOfFixedAssetReportViewer.LocalReport.Refresh();
                WriteOffOfFixedAssetReportViewer.DataBind();
            }
        }
    }
}