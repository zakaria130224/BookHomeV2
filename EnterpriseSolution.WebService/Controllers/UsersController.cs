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
    public class UsersController : Controller
    {
        IUserDetailsService userDetailsService;
        INotificationService notificationService;
        //private IDashboardService dashboardService;
        private SessionDataModel session;
        private IPrefixesService prefixesService;
        private IBranchService branchService;

        public UsersController(IUserDetailsService userDetailsService, INotificationService notificationService, IPrefixesService prefixesService, IBranchService branchService)
        {
            this.userDetailsService = userDetailsService;
            this.notificationService = notificationService;
            this.prefixesService = prefixesService;
            this.branchService = branchService;
            //this.dashboardService = dashboardService;

            //Logged in user details
            session = (SessionDataModel)System.Web.HttpContext.Current.Session[Constants.SessionKeys.SessionUser];
        }

        // GET: List of user details
        public JsonResult GetListOfUserDetails()
        {
            try
            {
                var result = userDetailsService.GetListOfUserDetails();
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetListBranches()
        {
            try
            {
                var result = branchService.GetAllBranches().Where(x=>x.IsActive==true);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: List of user details
        public JsonResult GetUserId()
        {
            try
            {
                var result = prefixesService.GetPrefixes(Constants.Prefix.UserId).Prefix;
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: List of user details
        public JsonResult GetListOfUserRole()
        {
            try
            {
                var result = userDetailsService.GetListOfUserRoles().Where(x => x.IsActive == true);
                    
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //Insert User Information Into Database Table
        public JsonResult InsertUserInfo(Users user)
        {
            try
            {
                //user.Password = Constants.GetSecurePassword(user.UserId);
                var result = userDetailsService.Insert(user);

                //send an email to user with user name and password 
                //notificationService.SendNotificationEmail(result.Email, Constants.NewUser, result.Id.ToString());

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateUser(Users user)
        {
            try
            {
                //user.Password = Constants.GetSecurePassword(user.UserId);
                var result = userDetailsService.UpdateUser(user);

                //send an email to user with user name and password 
                //notificationService.SendNotificationEmail(result.Email, Constants.NewUser, result.Id.ToString());

                return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateUserPassword(long usersId, string newPassword, string oldPassword)
        {
            try
            {
                //user.Password = Constants.GetSecurePassword(user.UserId);
               
                var result = userDetailsService.UpdateUserPassword( usersId,  newPassword, oldPassword);
                if(result!=null)
                {
                    return Json(new { data = result, success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, errorMessage ="Old Password doesn't matched!" }, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteUser(long userId)
        {
            try
            {
                userDetailsService.DeleteUser(userId);

                return Json(new { data = true, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult GetDashboardDataModel(string glCode)
        //{
        //    try
        //    {
        //        var result = dashboardService.GetDashboardDataModel(glCode);

        //        return Json(new { success = true, data = result}, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public JsonResult GetUserById(long Id)
        {
            try
            {
                var result = userDetailsService.GetUserById(Id);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}