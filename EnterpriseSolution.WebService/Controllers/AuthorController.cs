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
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }
        // GET: Author
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var result = authorService.GetAll();

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Insert(Author Author)
        {
            try
            {
                var result = authorService.Insert(Author);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Update(Author Author)
        {
            try
            {
                var result = authorService.Update(Author);

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
                var result = authorService.Get(Id);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(Author Author)
        {
            try
            {
                var result = authorService.Delete(Author);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}