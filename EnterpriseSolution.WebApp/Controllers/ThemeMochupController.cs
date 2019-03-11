using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSolution.WebApp.Controllers
{
    public class ThemeMochupController : Controller
    {
        // GET: ThemeMochup
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult TestRouting()
        {
            return View();
        }

        public ActionResult Modal()
        {
            return View();
        }

    }
}