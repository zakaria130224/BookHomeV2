using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSolution.WebService.Controllers
{
    public class CommonController : Controller
    {
        [CompressOutput]
        public ActionResult Modal()
        {
            return View();
        }

        [CompressOutput]
        public ActionResult DeleteModal()
        {
            return View();
        }

        [CompressOutput]
        public ActionResult DynamicDataTable()
        {
            return View();
        }

        [CompressOutput]
        public ActionResult SessionOutModal()
        {
            return View();
        }

        [CompressOutput]
        public ActionResult JournalView()
        {
            return View();
        }
    }
}