using System.Web;
using System.Web.Optimization;

namespace EnterpriseSolution.WebService
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //Default Angular JS
            #region MasterLayout CSS & JS


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/masterlayoutcss").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/smartadmin-production-plugins.min.css",
                      "~/Content/css/smartadmin-production.min.css",
                      "~/Content/css/smartadmin-skins.min.css",
                      "~/Content/css/smartadmin-rtl.min.css",
                      "~/Content/css/demo.min.css",
                      "~/Content/css/your_style.css",
                      "~/Content/css/delete-modal.css",
                      "~/Content/tree-grid/treeGrid.css",
                      "~/Content/css/dynamic.datatable.css"));

            bundles.Add(new StyleBundle("~/Content/masterlayoutangularcss").Include(
                      "~/Content/angular-toastr.css",
                      "~/Content/angular-flash/angular-flash.css",
                      "~/Content/angular-loading-bar/loading-bar.min.css",
                      "~/Content/css/angucomplete.css",
                      "~/Content/css/angular-confirm.min.css",
                      "~/Content/css/angular-datepicker.css"
                      ));



            bundles.Add(new ScriptBundle("~/bundles/masterlayoutthemejs").Include(
                "~/Scripts/js/app.config.js",
                "~/Scripts/js/smartwidgets/jarvis.widget.min.js",
                "~/Scripts/js/bootstrap/bootstrap.min.js",
                "~/Scripts/js/notification/SmartNotification.min.js",
                "~/Scripts/js/smartwidgets/jarvis.widget.min.js",
                "~/Scripts/js/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js",
                "~/Scripts/js/plugin/sparkline/jquery.sparkline.min.js",
                "~/Scripts/js/plugin/jquery-validate/jquery.validate.min.js",
                "~/Scripts/js/plugin/masked-input/jquery.maskedinput.min.js",
                "~/Scripts/js/plugin/select2/select2.min.js",
                "~/Scripts/js/plugin/bootstrap-slider/bootstrap-slider.min.js",
                "~/Scripts/js/plugin/msie-fix/jquery.mb.browser.min.js",
                "~/Scripts/js/plugin/fastclick/fastclick.min.js",
                "~/Scripts/js/app.min.js",
                "~/Scripts/js/plugin/datatables/jquery.dataTables.min.js",
                "~/Scripts/js/plugin/datatables/dataTables.bootstrap.min.js",
                "~/Scripts/js/libs/jquery-2.1.1.min.js",
                "~/Scripts/js/libs/jquery-ui-1.10.3.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/js/app.config.js",
                "~/Scripts/js/app.min.js",
                "~/Scripts/js/plugin/datatables/jquery.dataTables.min.js",
                "~/Scripts/js/plugin/datatables/dataTables.colVis.min.js",
                "~/Scripts/js/plugin/datatables/dataTables.tableTools.min.js",
                "~/Scripts/js/plugin/datatables/dataTables.bootstrap.min.js",
                "~/Scripts/js/plugin/datatable-responsive/datatables.responsive.min.js"

                ));


            bundles.Add(new ScriptBundle("~/bundles/masterlayoutngcustomdirectivesres2js").Include(
                     "~/Scripts/angular/directive/modal.js",
                    "~/Scripts/angular/directive/savingProcess.js"));

            bundles.Add(new ScriptBundle("~/bundles/masterlayoutngcustomdirectivesresjs").Include(
                   "~/Scripts/js/ng-ckeditor.min.js",
                   "~/Scripts/js/angular-idle.js",
                   "~/Scripts/angular/controllers/datepicker.js",
                   "~/Scripts/js/Select2/select2.full.min.js",
                   "~/Scripts/angular/directive/select2.js",
                   "~/Scripts/angular-toastr.js",
                     "~/Scripts/angular/directive/angular-toastr.tpls.js",
                   "~/Scripts/js/ng-datepicker.js"
                   ));
            //Angular JS
            bundles.Add(new ScriptBundle("~/bundles/masterlayoutangularjs").Include(
                     "~/Scripts/angular.min.js",
                     "~/Scripts/angular-route.min.js",
                     "~/Scripts/angular-animate.min.js",
                     "~/Scripts/angular-resource.js",
                     "~/Scripts/angular-touch.js"));

            bundles.Add(new ScriptBundle("~/bundles/masterlayoutAngularServicejs").Include(
                "~/Scripts/angular/services/basedapiurl.js",
                "~/Scripts/angular/services/loginservice.js",
                "~/Scripts/angular/services/HttpService.js",
                "~/Scripts/angular/services/UserService.js",
                "~/Scripts/angular/services/DashboardService.js",
                "~/Scripts/angular/services/HelperService.js",
                "~/Scripts/angular/services/UserRoleService.js",
                "~/Scripts/angular/services/CommonService.js"
                ));



            bundles.Add(new ScriptBundle("~/bundles/masterlayoutangularcustomcontrollerjs").Include(
                    "~/Scripts/angular/controllers/DashboardController.js",
                     "~/Scripts/angular/controllers/AdministrationController.js",
                     "~/Scripts/angular/controllers/UserRoleController.js",
                     "~/Scripts/angular/controllers/UserCntroller.js",
                     "~/Scripts/angular/controllers/MasterController.js"

                     ));
            #endregion

            #region Login Layout CSS & JS
            bundles.Add(new StyleBundle("~/Content/layoutpagecss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/css/smartadmin-production-plugins.min.css",
                      "~/Content/css/smartadmin-production.min.css",
                      "~/Content/css/smartadmin-skins.min.css",
                      "~/Content/css/smartadmin-rtl.min.css",
                      "~/Content/css/demo.min.css"));

            bundles.Add(new StyleBundle("~/Content/layoutangularcss").Include(
                      "~/Content/angular-toastr.css",
                      "~/Content/angular-flash/angular-flash-login.css",
                      "~/Content/angular-loading-bar/loading-bar.min.css",
                      "~/Content/css/angular-confirm.min.css"));

            //JS
            bundles.Add(new ScriptBundle("~/bundles/layoutjs").Include(
                     "~/Scripts/js/libs/jquery-2.1.1.min.js",
                     "~/Scripts/js/libs/jquery-ui-1.10.3.min.js",
                     "~/Scripts/bootstrap.min.js",
                     "~/Scripts/js/app.config.js",
                     "~/Scripts/js/app.min.js",
                     "~/Scripts/js/plugin/datatables/jquery.dataTables.min.js",
                     "~/Scripts/js/plugin/datatables/dataTables.colVis.min.js",
                     "~/Scripts/js/plugin/datatables/dataTables.tableTools.min.js",
                     "~/Scripts/js/plugin/datatables/dataTables.bootstrap.min.js",
                     "~/Scripts/js/plugin/datatable-responsive/datatables.responsive.min.js"));
            //Angular JS
            bundles.Add(new ScriptBundle("~/bundles/layoutangularjs").Include(
                     "~/Scripts/angular.min.js",
                     "~/Scripts/angular-route.min.js",
                     "~/Scripts/angular-animate.min.js",
                     "~/Scripts/angular-toastr.js",
                     "~/Scripts/angular/directive/angular-toastr.tpls.js",
                     "~/Scripts/angular/directive/angular-confirm.min.js",
                     "~/Scripts/loadingbar/loading-bar.js",
                     "~/Scripts/js/angular-idle.js",
                     "~/Scripts/angularjs/angular-datatables.js",
                     "~/Scripts/angular/directive/angucomplete.js",
                     "~/Scripts/js/ng-ckeditor.min.js",
                     "~/Scripts/angular/directive/angular-table/angular-table.min.js",
                     "~/Scripts/angular/directive/tree-grid/tree-grid-directive.js",
                     "~/Scripts/js/ng-datepicker.js",
                     "~/Scripts/js/Select2/select2.full.min.js",
                      "~/Scripts/angular/directive/select2.js"));

            bundles.Add(new ScriptBundle("~/bundles/layoutcustomangularjs").Include(
                     "~/Scripts/angular/app.js",
                     "~/Scripts/angular/services/basedapiurl.js",
                     "~/Scripts/angular/services/HelperService.js",
                     "~/Scripts/angular/services/loginservice.js",
                     "~/Scripts/angular/controllers/login-controller.js"));
            #endregion

            BundleTable.EnableOptimizations = true;
        }
    }
}
