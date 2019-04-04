using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EnterpriseSolution.WebService.Controllers
{
    public class ReportController : Controller
    {
        private readonly IAuthorService authorService;
        public ReportController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }
        // GET: Report
        public ActionResult Index()
        {
            IEnumerable<Author> authors = authorService.GetAll();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);
            reportViewer.BorderWidth = 0;
            reportViewer.PageCountMode = new PageCountMode();
            reportViewer.LocalReport.ReportPath = Request.MapPath("~/Reports/RDLC/ReportTest.rdlc");
           // reportViewer.LocalReport.SetParameters(GetReportParameter(objTOCommonParams));

            ReportDataSource A = new ReportDataSource("BookHomeDataset", authors);
            reportViewer.LocalReport.DataSources.Add(A);
            ViewBag.ReportViewer = reportViewer;
            return View();
        }
    }
}