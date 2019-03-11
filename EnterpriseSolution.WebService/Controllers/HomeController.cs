using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersRepository usersRepository;

       // private readonly IEmployeesRepository employeesRepository;

        public HomeController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;

            this.employeesRepository = employeesRepository;
        }

        [CompressOutput]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Home()
        {

            return PartialView("~/Views/Home/Home.cshtml");
        }

        [HttpGet]
        public ActionResult Login()
        {

            return PartialView("~/Views/accounts/login.cshtml");
        }

        [CompressOutput]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult getEmployeeListAll()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            int PageSize = length != null ? Convert.ToInt32(length) : 0;
            int Skip = start != null ? Convert.ToInt32(start) : 0;
            int RecordsTotal = 0;

            var rslt = employeesRepository.GetAll();
            if (!string.IsNullOrEmpty(searchValue))
            {
                rslt = rslt.Where(a =>
                 a.ID.ToString().Contains(searchValue) ||
                 a.FirstName.Contains(searchValue) ||
                 a.LastName.Contains(searchValue) ||
                 a.Gender.Contains(searchValue) ||
                 a.Salary.ToString().Contains(searchValue)
                 ).ToList();
            }

            //sorting
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                if (sortColumnDir == "asc")
                    rslt = rslt.OrderBy(s => s.GetType().GetProperty(sortColumn).GetValue(s)).ToList();
                else
                    rslt = rslt.OrderByDescending(s => s.GetType().GetProperty(sortColumn).GetValue(s)).ToList();
            }

            RecordsTotal = rslt.Count();

            var empList = rslt.Skip(Skip).Take(PageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = RecordsTotal, recordsTotal = RecordsTotal, data = empList });
        }

        [CompressOutput]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
