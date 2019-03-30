using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSolution.Core.DataModel;
using IplanSaasWebApp.Models;
using EnterpriseSolution.Core.Shared;
using System.IO;
using System.Net.Http;
using System.Net;

namespace EnterpriseSolution.WebService.Controllers
{
    [CompressOutput]
    public class ApplicationController : Controller
    {
        private SessionDataModel session;

        public ApplicationController()
        {

            HttpRequest req = System.Web.HttpContext.Current.Request;
            string browserName = req.Browser.Browser;
            //string hostName = Dns.GetHostName();
            string ipAddress = Dns.GetHostByName(Dns.GetHostName().ToString()).AddressList[0].ToString();
            //Logged in user details
            session = (SessionDataModel)System.Web.HttpContext.Current.Session[Constants.SessionKeys.SessionUser];

            ViewBag.browserName = browserName;
            ViewBag.ipAddress = ipAddress;
        }

        // GET: Insight
        [CompressOutput]
        public ActionResult Insight()
        {
            if (session == null)
                return RedirectToAction("Index", "Home");
            ViewBag.LoggedInUserName = session.UserName;
            return View();
        }

        // GET: Dashboard
        [CompressOutput]
        public ActionResult Dashboard()
        {

            if (session == null)
                return RedirectToAction("Login", "Login");

            return View();
        }


        [CompressOutput]
        public ActionResult Toaster()
        {
            return View();
        }


        #region Administration
        [CompressOutput]
        public ActionResult Users()
        {
            return View();
        }

        [CompressOutput]
        public ActionResult Roles()
        {
            return View();
        }

        [CompressOutput]
        public ActionResult Branches()
        {
            return View();
        }

        [CompressOutput]
        public ActionResult Department()
        {
            return View();
        }


        #endregion
        [CompressOutput]
        public ActionResult NavBar()
        {
            var navbarItems = new List<Navbar>();

            navbarItems.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Application", action = "dashboard", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });

            navbarItems.Add(new Navbar { Id = 10, nameOption = "Administration", imageClass = "fa fa-sitemap fa-fw", status = true, isParent = true, parentId = 0 });
            navbarItems.Add(new Navbar { Id = 11, nameOption = "Users", controller = "Application", action = "users", status = true, isParent = false, parentId = 10 });
            navbarItems.Add(new Navbar { Id = 12, nameOption = "Roles", controller = "Application", action = "roles", status = true, isParent = false, parentId = 10 });
            navbarItems.Add(new Navbar { Id = 13, nameOption = "Branch", controller = "Application", action = "branches", status = true, isParent = false, parentId = 10 });
            navbarItems.Add(new Navbar { Id = 20, nameOption = "Book Setting", imageClass = "fa fa-book fa-fw", status = true, isParent = true, parentId = 0 });
            navbarItems.Add(new Navbar { Id = 21, nameOption = "Category", controller = "BookCategory", action = "bookcategory", status = true, isParent = false, parentId = 20 });
            navbarItems.Add(new Navbar { Id = 22, nameOption = "Authors", controller = "Author", action = "author", status = true, isParent = false, parentId = 20 });
            navbarItems.Add(new Navbar { Id = 23, nameOption = "Books", controller = "Book", action = "book", status = true, isParent = false, parentId = 20 });
            return PartialView(navbarItems.ToList());
        }


        [HttpPost]
        public JsonResult UploadFile(Object obj) //TODO: Has to complete the UploadFile action of ActionController
        {
            try
            {
                //var test = Request;
                var file = Request.Files[0];

                if (file.ContentLength > 0)
                {
                    var fileName = file.FileName;
                    var serverPath = Server.MapPath("~/UploadedFiles");
                    var filePath = Path.Combine(serverPath, fileName);
                    file.SaveAs(filePath);
                }

                return Json(new { success = true, data = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}