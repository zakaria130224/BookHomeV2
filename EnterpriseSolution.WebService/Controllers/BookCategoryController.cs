using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Infrastructure.EnterpriseDbContext;
using EnterpriseSolution.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSolution.WebService.Controllers
{
    public class BookCategoryController : Controller
    {
        //DatabaseContext context;
        private readonly BookCategoryService bookCategoryService;
        public BookCategoryController(BookCategoryService bookCategoryService)
        {
            //this.context = context;
            this.bookCategoryService = bookCategoryService;
        }
        // GET: BookCategory
        public ActionResult Index()
        {
            return View();
        }

        // GET: List of user details
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var result = bookCategoryService.GetAll();

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Insert(BookCategory BookCategory)
        {
            try
            {
                var result = bookCategoryService.Insert(BookCategory);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Update(BookCategory BookCategory)
        {
            try
            {
                var result = bookCategoryService.Update(BookCategory);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetById(long Id)
        {
            try
            {
                var result = bookCategoryService.GetById(Id);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}