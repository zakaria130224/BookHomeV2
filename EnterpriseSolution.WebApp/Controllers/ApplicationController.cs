using IplanSaasWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSolution.WebApp.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Insight
        public ActionResult Insight()
        {
            return View();
        }

        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        // GET: Asset
        public ActionResult Assets()
        {
            return View();
        }

        public ActionResult AddAssets()
        {
            return View();
        }
        #region  "Added By Mosaddik Bin Hafiz 8.19.2017 | Managage Nodes"

        public ActionResult ManageAssets()
        {
            return View();
        }

        public ActionResult ManageEvents()
        {
            return View();
        }

        public ActionResult Events()
        {
            return PartialView("ManageAssetsTab/Events");
        }

        public ActionResult SavingProcess()
        {
            return View();
        }

        #endregion

        public ActionResult NavBar()
        {
            var navbarItems = new List<Navbar>();
            navbarItems.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Application", action = "Dashboard", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });

            navbarItems.Add(new Navbar { Id = 2, nameOption = "Fixed Assets", imageClass = "fa fa-user fa-fw", status = true, isParent = true, parentId = 0 });
            navbarItems.Add(new Navbar { Id = 10, nameOption = "Maintenance", imageClass = "fa fa-building fa-fw", status = true, isParent = false, parentId = 2 });

            navbarItems.Add(new Navbar { Id = 20, nameOption = "Oparations", imageClass = "fa fa-building fa-fw", status = true, isParent = true, parentId = 2 });
            navbarItems.Add(new Navbar { Id = 21, nameOption = "Asset Capture", imageClass = "fa fa-fw fa-info", controller = "Application", action = "assets", status = true, isParent = false, parentId = 20 });
            navbarItems.Add(new Navbar { Id = 22, nameOption = "Asset Sale", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 20 });
            navbarItems.Add(new Navbar { Id = 23, nameOption = "Asset Transfer", imageClass = "fa fa-fw fa-info", controller = "Application", action = "lookupfieldsettings", status = true, isParent = false, parentId = 20 });
            navbarItems.Add(new Navbar { Id = 24, nameOption = "Asset Write Off", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 20 });
            navbarItems.Add(new Navbar { Id = 25, nameOption = "Contract Auth", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 20 });
            navbarItems.Add(new Navbar { Id = 26, nameOption = "Contract Region", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 20 });

            navbarItems.Add(new Navbar { Id = 30, nameOption = "View", imageClass = "fa fa-sitemap fa-fw", status = true, isParent = true, parentId = 2 });
            navbarItems.Add(new Navbar { Id = 31, nameOption = "Asset Capture", imageClass = "fa fa-fw fa-info", controller = "Application", action = "lookupfieldsettings", status = true, isParent = false, parentId = 30 });
            navbarItems.Add(new Navbar { Id = 32, nameOption = "Asset Categories", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 30 });
            navbarItems.Add(new Navbar { Id = 33, nameOption = "Asset Sale", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 30 });
            navbarItems.Add(new Navbar { Id = 34, nameOption = "Asset Transfer", imageClass = "fa fa-fw fa-info", controller = "Application", action = "lookupfieldsettings", status = true, isParent = false, parentId = 30 });
            navbarItems.Add(new Navbar { Id = 35, nameOption = "Asset Write Off", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 30 });
            navbarItems.Add(new Navbar { Id = 36, nameOption = "Asset Delivery Not Inspected", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 30 });
            navbarItems.Add(new Navbar { Id = 37, nameOption = "Asset Inspected Not Capitalized", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 30 });
            navbarItems.Add(new Navbar { Id = 38, nameOption = "Locations", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 30 });
            navbarItems.Add(new Navbar { Id = 39, nameOption = "Products", imageClass = "fa fa-fw fa-info", controller = "Application", action = "manageproducts", status = true, isParent = false, parentId = 30 });

            navbarItems.Add(new Navbar { Id = 40, nameOption = "Users & Permission", imageClass = "fa fa-sitemap fa-fw", status = true, isParent = true, parentId = 0 });
            navbarItems.Add(new Navbar { Id = 41, nameOption = "Users", controller = "Application", action = "Users", status = true, isParent = false, parentId = 40 });
            navbarItems.Add(new Navbar { Id = 42, nameOption = "Roles", controller = "Application", action = "Roles", status = true, isParent = false, parentId = 40 });

            navbarItems.Add(new Navbar { Id = 50, nameOption = "Security", imageClass = "fa fa-user fa-fw", status = true, isParent = true, parentId = 0 });
            navbarItems.Add(new Navbar { Id = 51, nameOption = "Change Password", controller = "Application", action = "securitypassword", status = true, isParent = false, parentId = 50 });
            navbarItems.Add(new Navbar { Id = 52, nameOption = "Two Factor Authentication", controller = "Application", action = "authentication", status = true, isParent = false, parentId = 50 });
            navbarItems.Add(new Navbar { Id = 53, nameOption = "Security Question", controller = "Application", action = "securityquestion", status = true, isParent = false, parentId = 50 });
            navbarItems.Add(new Navbar { Id = 54, nameOption = "Security IP Address", controller = "Application", action = "securityips", status = true, isParent = false, parentId = 50 });


            navbarItems.Add(new Navbar { Id = 60, nameOption = "Settings", imageClass = "fa fa-wrench fa-fw", status = true, isParent = true, parentId = 0 });
            navbarItems.Add(new Navbar { Id = 61, nameOption = "Preferences", controller = "Application", action = "preference", status = true, isParent = false, parentId = 60 });
            navbarItems.Add(new Navbar { Id = 62, nameOption = "Authorized Websites", controller = "Application", action = "authorizedsites", status = true, isParent = false, parentId = 60 });
            navbarItems.Add(new Navbar { Id = 63, nameOption = "Linked Accounts", controller = "Application", action = "linkedaccounts", status = true, isParent = false, parentId = 60 });
            navbarItems.Add(new Navbar { Id = 64, nameOption = "Close Account", controller = "Application", action = "closeaccount", status = true, isParent = false, parentId = 60 });

            navbarItems.Add(new Navbar { Id = 70, nameOption = "Sessions", imageClass = "fa fa-sitemap fa-fw", status = true, isParent = true, parentId = 0 });
            navbarItems.Add(new Navbar { Id = 71, nameOption = "Active Session", controller = "Application", action = "useractivesessions", status = true, isParent = false, parentId = 70 });
            navbarItems.Add(new Navbar { Id = 72, nameOption = "User Authtokens", controller = "Application", action = "userauthtoken", status = true, isParent = false, parentId = 70 });
            navbarItems.Add(new Navbar { Id = 73, nameOption = "Active History", controller = "Application", action = "useractivityhistory", status = true, isParent = false, parentId = 70 });


            return PartialView(navbarItems.ToList());



            //var navBar = new List<Models.NavBar>
            //{


            //    new Models.NavBar{Id = 1 ,Name = "Fixed Assets", Action = "#", Controller = "", IsParent = true, HasChild = true , ParentId  = 0},

            //    new Models.NavBar{Id = 10 ,Name = "Maintenance", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 1},

            //    new Models.NavBar{Id = 20 ,Name = "Oparations", Action = "#", Controller = "", IsParent = false , HasChild = true , ParentId  = 1},
            //    new Models.NavBar{Id = 21 ,Name = "Asset Capture", Action = "Assets", Controller = "Application", IsParent = false, HasChild = false , ParentId  = 20},
            //    new Models.NavBar{Id = 22 ,Name = "Asset Sale", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 20},
            //    new Models.NavBar{Id = 23 ,Name = "Asset Transfer", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 20},
            //    new Models.NavBar{Id = 24 ,Name = "Asset Write Off", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 20},
            //    new Models.NavBar{Id = 25 ,Name = "Contract Auth", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 20},
            //    new Models.NavBar{Id = 26 ,Name = "Contract Region", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 20},

            //    new Models.NavBar{Id = 30 ,Name = "View", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 1},
            //    new Models.NavBar{Id = 31 ,Name = "Asset Capture", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},
            //    new Models.NavBar{Id = 32 ,Name = "Asset Categories", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},
            //    new Models.NavBar{Id = 33 ,Name = "Asset Sale", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},
            //    new Models.NavBar{Id = 34 ,Name = "Asset Transfer", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},
            //    new Models.NavBar{Id = 35 ,Name = "Asset Write Off", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},
            //    new Models.NavBar{Id = 36 ,Name = "Asset Delivery Not Inspected", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},
            //    new Models.NavBar{Id = 37 ,Name = "Asset Inspected Not Capitalized", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},
            //    new Models.NavBar{Id = 38 ,Name = "Locations", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},
            //    new Models.NavBar{Id = 39 ,Name = "Products", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 30},

            //    new Models.NavBar{Id = 200 ,Name = "Administrator", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 0},
            //    new Models.NavBar{Id = 201 ,Name = "Users", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 200},
            //    new Models.NavBar{Id = 202 ,Name = "Roles", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 200},
            //    new Models.NavBar{Id = 203 ,Name = "Role Permission", Action = "#", Controller = "", IsParent = false, HasChild = false , ParentId  = 200},

            //};

            //ViewBag.NavBar = navBar;

            //return PartialView();
        }
    }
}