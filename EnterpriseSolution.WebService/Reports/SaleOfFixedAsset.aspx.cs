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
    public partial class SaleOfFixedAsset : System.Web.UI.Page
    {
        private readonly ReportRepository reportRepository;

        public SaleOfFixedAsset()
        {
            reportRepository = new ReportRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IEnumerable<SqlParameter> parameter = null;
                var records = reportRepository.GetStoredProcedureRecords("SaleOfFixedAsset", parameter);
                SaleOfFixedAssetReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/RDLC/SaleOfFixedAssetReport.rdlc");
                SaleOfFixedAssetReportViewer.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("SaleOfFixedAssetDataSet", records.Tables[0]);
                SaleOfFixedAssetReportViewer.LocalReport.DataSources.Add(rdc);
                SaleOfFixedAssetReportViewer.LocalReport.Refresh();
                SaleOfFixedAssetReportViewer.DataBind();
            }
        }
    }
}