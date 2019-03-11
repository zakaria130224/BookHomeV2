'use strict';

var app = angular.module('EnterpriseSolution', ['720kb.datepicker', 'ui.select2', 'ngIdle', 'ngRoute', 'flash', 'datatables', 'angular-loading-bar', 'toastr', 'treeGrid', "angucomplete", "cp.ngConfirm", "ng.ckeditor", 'angular-table'])
    .config(function ($routeProvider, $locationProvider, IdleProvider, KeepaliveProvider) {

        $locationProvider.html5Mode(true);

        // configure Idle settings
        IdleProvider.idle(10*60); // in seconds
        IdleProvider.timeout(20); // in seconds
        KeepaliveProvider.interval(2); // in seconds

        $routeProvider
            .when('/dashboard', {
                templateUrl: '/Application/Dashboard',
                controller: "DashboardCtrl"
            })
            .when('/users', {
                templateUrl: '/Application/Users',
                controller: "UserCtrl"
            })
            .when('/roles', {
                templateUrl: '/Application/Roles',
                controller: "UserRoleCtrl"
            })
            .when('/branches',
            {
                templateUrl: '/Application/Branches',
                controller: "BranchCtrl"
            })
            .when('/department',
                {
                    templateUrl: '/Application/Department',
                    controller: "DepartmentController"
            })
            .when('/location',
                {
                    templateUrl: '/Application/Location',
                    controller: "LocationController"
                })
            .when('/assets', {
                templateUrl: '/Application/Assets',
                controller: "AssetCtrl"
            })
            .when('/assets/assetcapture', {
                templateUrl: '/Application/AddAssets',
                controller: "AddAssetCtrl"
            })
            .when('/assets/assetdetails/:id', {
                templateUrl: '/Application/ActionDetails',
                controller: "AssetDetails",
            })
            .when('/assets/assetlinkagedetails/:id', {
                templateUrl: '/Application/ActionLinkageDetails',
                controller: "AssetDetails"
            })
            .when('/assets/amendment/:id', {
                templateUrl: '/Application/ActionAmendment',
                controller: "AssetDetails"
            })
            .when('/assets/assetcapture/:id', {
                templateUrl: '/Application/AddAssets',
                controller: "AddAssetCtrl"
            })
            /*
             * After adding asset information we should come in addlinkage page
             * **/
            .when('/assets/addlinkage', {
                templateUrl: '/Assets/AddLinkage',
                controller: "LinkageCaptureController"
            })
            .when('/assets/manageAssets/:state/:id', {
                templateUrl: '/Application/ManageAssets',
                controller: "ManageAssetsCtrl"
            })
            .when('/assets/manageAssets', {
                templateUrl: '/Application/ManageAssets',
                controller: "ManageAssetsCtrl"

            })
            .when('/assets/manageEvents/:assetId/:event', {
                templateUrl: '/Application/ManageEvents',
                controller: "ManageEventsCtrl"
            })
            //Asset sell section starts here
            .when('/assetsales', {
                templateUrl: '/Assets/AssetSales',
                controller: "AssetSalesController"
            })
            .when('/assetsalesdetails/:id', {
                templateUrl: '/Assets/AssetSellDetails',
                controller: 'AssetSalesDetailsController'
            })
            //Reports section starts here
            .when('/dailytransactionlist', {
                templateUrl: '/Report/DailyTransactionList',
                controller: ''
            })
            .when('/fixedassetspurchasedagainstexpensebill', {
                templateUrl: '/Report/FixedAssetsPurchasedAgainstExpenseBill',
                controller: ''
            })
            .when('/saleoffixedasset', {
                templateUrl: '/Report/SaleOfFixedAsset',
                controller: ''
            })
            .when('/writeoffoffixedasset', {
                templateUrl: '/Report/WriteOffOfFixedAsset',
                controller: ''
            })
            //Upload section starts here
            .when('/upload', {
                templateUrl: '/Application/Upload',
                controller: 'UploadController'
            })
            //Assets Upload
            .when('/assetsupload', {
                templateUrl: '/Upload/AssetsUpload',
                controller: 'AssetsUploadController'
            })
            //Asset Category upload
            .when('/assetcategoryupload', {
                templateUrl: '/Upload/AssetCategoryUpload',
                controller: 'AssetCategoryUploadController'
            })
            //Depreciation Config Upload
            .when('/depreciationconfigupload', {
                templateUrl: '/Upload/DepreciationConfigUpload',
                controller: 'DepreciationConfigUploadController'
            })
            //GlType Upload
            .when('/gltypeupload', {
                templateUrl: '/Upload/GlTypeUpload',
                controller: 'GlTypeUploadController'
            })
            .when('/glaccountsupload', {
                templateUrl: '/Upload/GlAccountsUpload',
                controller: 'GlAccountsUploadController'
            })
            /*
             * Voucher part starts from here
             * **/
            .when('/voucher', //This is where the vouchers list is shown
            {
                templateUrl: '/Voucher/Voucher',
                controller: "VoucherController"
            })
            .when('/voucher/supplierpayment', { //This is where I add the voucher
                templateUrl: '/Voucher/VoucherSupplierPayment',
                controller: 'VoucherSupplierPaymentController'
            })
            .when('/voucherdetails/:id', //In future I will not need this. This is redundent
            {
                templateUrl: '/Voucher/VoucherDetails',
                controller: "VoucherDetailsController"
            })
            .when('/voucher/supplierpaymentdetails/:id', { //This is where individual voucher details are shown
                templateUrl: '/Voucher/VoucherSupplierPaymentDetails',
                controller: 'VoucherSupplierPaymentDetailsController'
            })

            //Others Payment
            .when('/otherpaymentslist', {
                templateUrl: '/OtherPayments/OtherPaymentsList',
                controller: "OtherPaymentsController"
            })
            .when('/otherpayments/add', {
                templateUrl: '/OtherPayments/OtherPaymentsAdd',
                controller: "OtherPaymentsAddController"
            })
            .when('/otherpayments/details/:id', {
                templateUrl: '/OtherPayments/OtherPaymentsDetails',
                controller: "OtherPaymentsDetailsController"
            })
            .when('/supplier', {
                templateUrl: '/Supplier/Supplier',
                controller: "SupplierController"
            })
            .when('/supplierdetails/:id', {
                templateUrl: '/Supplier/SupplierDetails',
                controller: "SupplierDetailsController"
            })
            //Asset Write off routing
            .when('/assetWriteOff', {
                templateUrl: '/AssetWriteOff/AssetWriteOff',
                controller: "AssetWriteOffController"
            })
            //Setting routes starts
            .when('/glmapping', {
                templateUrl: '/Application/GLMapping',
                controller: 'SettingsGLMappingController'
            })
            .when('/glmappingadd', {
                templateUrl: '/Application/GLMappingAdd',
                controller: 'SettingsGlMappingAddController'
            })
            .when('/glmappingdetails/:moduleid/:screenid/:actionid', {
                templateUrl: '/Application/GlMappingDetails',
                controller: 'SettingsGlMappingDetailsController'
            })
            .when('/modules', {
                templateUrl: '/Application/Modules',
                controller: 'SettingsModulesController'
            })
            .when('/screens', {
                templateUrl: '/Application/Screens',
                controller: 'SettingsScreensController'
            })
            .when('/actions', {
                templateUrl: '/Application/Actions',
                controller: 'SettingsActionsController'
            })
            .when('/managegl', {
                templateUrl: '/Application/ManageGL',
                controller: 'SettingsManageGLController'
            })
            .when('/screenfieldsmap', {
                templateUrl: '/Application/ScreenFieldsMap',
                controller: 'ScreenFieldsMapController'
            })
            .when('/depreciationaccountmap', {
                templateUrl: '/Application/DepreciationAccountMap',
                controller: 'SettingsDepreciationMappingController'
            })
            //Sales Routing starts
            .when('/sales', {
                templateUrl: '/Sales/Sales',
                controller: 'SalesController'
            })
            .when('/sales/add', {
                templateUrl: '/Sales/SalesAdd',
                controller: 'SalesAddController'
            })
            .when('/sales/details/:id', {
                templateUrl: '/Sales/SalesDetails',
                controller: 'SalesDetailsController'
            })
            //Other Sales
            .when('/othersaleslist', {
                templateUrl: '/OtherSales/OtherSalesList',
                controller: "OtherSalesController"
            })
            .when('/othersales/add', {
                templateUrl: '/OtherSales/OtherSalesAdd',
                controller: "OtherSalesAddController"
            })
            .when('/othersales/details/:id', {
                templateUrl: '/OtherSales/OtherSalesDetails',
                controller: "OtherSalesDetailsController"
            })
            //Single Entry
            .when('/singleentrylist', {
                templateUrl: '/SingleEntry/SingleEntryList',
                controller: 'SingleEntryListController'
            })
            .when('/singleentry/add', {
                templateUrl: '/SingleEntry/SingleEntryAdd',
                controller: 'SingleEntryAddController'
            })
            .when('/singleentry/details/:id', {
                templateUrl: '/SingleEntry/SingleEntryDetails',
                controller: 'SingleEntryDetailsController'
            })
            //Procurement
            .when('/workorders', {
                templateUrl: '/Procurement/WorkOrders',
                controller: 'WorkOrderController'
            })
            .when('/workorders/workorderdetails/:id', {
                templateUrl: '/Procurement/WorkOrderDetails',
                controller: 'WorkOrderDetailsController'
            })
            .when('/workorders/workorderpreview/:id', {
                templateUrl: '/Procurement/WorkOrderPreview',
                controller: 'WorkOrderDetailsController'
            })
            //Setting routes ends  

            //Trial Balance
            .when('/trialbalance', {
                templateUrl: '/TrialBalance/Index',
                controller: 'TrialBalanceController'
            })
            .when('/ledger/details/:glcode', {
                templateUrl: '/TrialBalance/LedgerDetails',
                controller: 'LedgerDetailsController'
            })
            .when('/journal/details/:refno', {
                templateUrl: '/TrialBalance/JournalDetails',
                controller: 'JournalDetailsontroller'
            })

            //Loan Accounting Added By: Zakaria
            .when('/loanentry', {
                templateUrl: '/LoanEntry/LoanEntryHome',
                controller: 'LoanEntryHomeController'
            })
            .when('/loanentry/add', {
                templateUrl: '/LoanEntry/LoanEntryAdd',
                controller: 'LoanEntryAddController'
            })
            .when('/loanentry/details/:id', {
                templateUrl: '/LoanEntry/LoanEntryDetails',
                controller: 'LoanEntryDetailsController'
            })
            //Loan Installments Added By: Zakaria 03.11.18
            .when('/loaninstallment', {
                templateUrl: '/LoanInstallmentEntry/LoanInstallmentHome',
                controller: 'LoanInstallmentHomeController'
            })
            .when('/loaninstallment/add', {
                templateUrl: '/LoanInstallmentEntry/LoanInstallmentAdd',
                controller: 'LoanInstallmentAddController'
            })
            .when('/loaninstallment/details/:id', {
                templateUrl: '/LoanInstallmentEntry/LoanInstallmentDetails',
                controller: 'LoanInstallmentDetailsController'
            })

            //Payroll Common Setup
            .when('/employeegroup', {
                templateUrl: '/PayrollCommonSetupView/EmployeeGroupHome',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/designation', {
                templateUrl: '/PayrollCommonSetupView/DesignationHome',
                controller: 'DesignationController'
            })
            .when('/shift', {
                templateUrl: '/PayrollCommonSetupView/ShiftHome',
                controller: 'ShiftController'
            })
            .when('/team', {
                templateUrl: '/PayrollCommonSetupView/TeamHome',
                controller: 'TeamController'
            })
            .when('/weekend', {
                templateUrl: '/PayrollCommonSetupView/WeekendHome',
                controller: 'WeekendController'
            })
            .when('/teamweekend', {
                templateUrl: '/PayrollCommonSetupView/TeamWeekend',
                controller: 'TeamWeekendController'
            })
            .when('/holiyday', {
                templateUrl: '/PayrollCommonSetupView/HolidayHome',
                controller: 'HolidayHomeController'
            })
            .when('/holiyday/details/:id', {
                templateUrl: '/PayrollCommonSetupView/HolidayDetails',
                controller: 'HolidyDetailsController'
            })
            .when('/leavecategory', {
                templateUrl: '/PayrollCommonSetupView/LeaveCategoryHome',
                controller: 'LeaveCategoryController'
            })
            .when('/leavepolicy', {
                templateUrl: '/PayrollCommonSetupView/LeavePolicyHome',
                controller: 'LeavePolicyController'
            })
            .when('/overtimepolicy', {
                templateUrl: '/PayrollCommonSetupView/OvertimePolicyHome',
                controller: 'OvertimePolicyController'
            })
            .when('/fixedsalaryelement', {
                templateUrl: '/PayrollCommonSetupView/FixedSalaryElementHome',
                controller: 'FixedSalaryController'
            })
            .when('/fundsetup', {
                templateUrl: '/PayrollCommonSetupView/FundSetupHome',
                controller: 'FundSetupController'
            })
            .when('/incrementpolicy', {
                templateUrl: '/PayrollCommonSetupView/IncrementPolicyHome',
                controller: 'IncrementPolicyController'
            })
            .when('/incrementdistribution', {
                templateUrl: '/PayrollCommonSetupView/IncrementDistributionHome',
                controller: 'IncrementDistributionHomeController'
            })
            .when('/incrementdistribution/add', {
                templateUrl: '/PayrollCommonSetupView/IncrementDistributionAdd',
                controller: 'IncrementDistributionAddController'
            })
            .when('/incrementdistribution/details/:id', {
                templateUrl: '/PayrollCommonSetupView/IncrementDistributionDetails',
                controller: 'IncrementDistributionDetailsController'
            })
            .when('/lateabsentpenalty', {
                templateUrl: '/PayrollCommonSetupView/LateAbsentPenaltyHome',
                controller: 'LateAbsentPenaltyController'
            })
            .when('/bonuspolicy', {
                templateUrl: '/PayrollCommonSetupView/BonusPolicyHome',
                controller: 'BonusPolicyController'
            })
            .when('/glsetup', {
                templateUrl: '/PayrollCommonSetupView/GLSetupHome',
                controller: 'GLSetupController'
            })
            //Payroll Listup
            .when('/shiftlistup', {
                templateUrl: '/PayrollListupView/ShiftListUp',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/overtimelistup', {
                templateUrl: '/PayrollListupView/OvertimeListUp',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/incrementlistup', {
                templateUrl: '/PayrollListupView/IncrementListUp',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/promotionlistup', {
                templateUrl: '/PayrollListupView/PromosionListUp',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/liabilitylistup', {
                templateUrl: '/PayrollListupView/EmployeeLiablilityListUp',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/facilitylistup', {
                templateUrl: '/PayrollListupView/SingleEmployeeFacilityListUp',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/facilitylistup/add', {
                templateUrl: '/PayrollListupView/SingleEmployeeFacilityListUpAdd',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/facilitylistup/details/:id', {
                templateUrl: '/PayrollListupView/SingleEmployeeFacilityListUpDetails',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/teamlistup', {
                templateUrl: '/PayrollListupView/TeamListUp',
                controller: 'EmployeeGroupHomeController'
            })
            //Payroll Employee
            .when('/employees', {
                templateUrl: '/PayrollEmployeeView/EmployeeHome',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/employees/add', {
                templateUrl: '/PayrollEmployeeView/EmployeeAdd',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/employees/details/:id', {
                templateUrl: '/PayrollEmployeeView/EmployeeDetails',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/shiftroaster', {
                templateUrl: '/PayrollManagementView/ShiftRoasterHome',
                    controller: 'EmployeeGroupHomeController'
            })
            .when('/shiftroaster/details/:id', {
                templateUrl: '/PayrollManagementView/ShiftRoasterDetails',
                controller: 'EmployeeGroupHomeController'
            })
            .when('/payslip', {
                templateUrl: '/PayrollSalaryView/PaySlipHome',
                controller: 'EmployeeGroupHomeController'
            })
            .otherwise({
                redirectTo: '/dashboard'
            });
       
    });
//Config Toaster
app.config(function (toastrConfig) {
    angular.extend(toastrConfig, {
        allowHtml: false,
        closeButton: true,
        closeHtml: '<button>&times;</button>',
        extendedTimeOut: 1000,
        iconClasses: {
            error: 'toast-error',
            info: 'toast-info',
            success: 'toast-success',
            warning: 'toast-warning'
        },
        messageClass: 'toast-message',
        onHidden: null,
        onShown: null,
        onTap: null,
        progressBar: false,
        tapToDismiss: true,
        templates: {
            toast: 'directives/toast/toast.html',
            progressbar: 'directives/progressbar/progressbar.html'
        },
        timeOut: 2000,
        titleClass: 'toast-title',
        toastClass: 'toast'
    });
});

app.config(function (toastrConfig) {
    angular.extend(toastrConfig, {
        autoDismiss: false,
        containerId: 'toast-container',
        maxOpened: 0,
        newestOnTop: true,
        positionClass: 'toast-top-right',
        preventDuplicates: false,
        preventOpenDuplicates: false,
        target: 'body'
    });
});

app.run(function (Idle) {
    // start watching when the app runs. also starts the Keepalive service by default.
    Idle.watch();
});
