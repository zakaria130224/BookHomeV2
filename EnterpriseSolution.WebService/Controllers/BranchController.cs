using EnterpriseSolution.Core.DataModel;
using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Services;
using EnterpriseSolution.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSolution.WebService.Controllers
{
    [CompressOutput]
    public class BranchController : Controller
    {
        private IBranchService branchService;
        private SessionDataModel session;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;

            session = (SessionDataModel)System.Web.HttpContext.Current.Session[Constants.SessionKeys.SessionUser];
        }

        // GET: List of user details
        [HttpGet]
        public JsonResult GetAllBranches()
        {
            try
            {
                var result = branchService.GetAllBranches();

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetBrancheById(long Id)
        {
            try
            {
                var result = branchService.GetBrancheById(Id);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //Insert User Information Into Database Table
        public JsonResult InsertBranches(Branches branchInfo)
        {
            try
            {
                var result = branchService.InsertBranches(branchInfo);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateBranches(Branches branchInfo)
        {
            try
            {
                var result = branchService.UpdateBranches(branchInfo);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}