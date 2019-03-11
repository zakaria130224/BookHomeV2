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
    public class UserRoleController : Controller
    {
        IUserRoleService userRoleService;
        private SessionDataModel session;

        public UserRoleController(IUserRoleService userRoleService)
        {
            this.userRoleService = userRoleService;

            //Logged in user details
            session = (SessionDataModel)System.Web.HttpContext.Current.Session[Constants.SessionKeys.SessionUser];
        }

        // GET: List of user details
        [HttpGet]
        public JsonResult GetListOfUserRole()
        {
            try
            {
                var result = userRoleService.GetListOfUserRole();

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUserRoleById(long Id)
        {
            try
            {
                var result = userRoleService.GetUserRoleById(Id);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //Insert User Information Into Database Table
        public JsonResult InsertUserRole(UserRoles userRole)
        {
            try
            {
                var result = userRoleService.Insert(userRole);
              
                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateUserRole(UserRoles userRole)
        {
            try
            {
                var result = userRoleService.UpdateUserRole(userRole);

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}