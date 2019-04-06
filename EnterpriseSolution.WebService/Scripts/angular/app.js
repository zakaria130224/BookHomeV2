'use strict';

var app = angular.module('EnterpriseSolution', ['naif.base64','720kb.datepicker', 'ui.select2', 'ngIdle', 'ngRoute', 'flash', 'datatables', 'angular-loading-bar', 'toastr', 'treeGrid', "angucomplete", "cp.ngConfirm", "ng.ckeditor", 'angular-table'])
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
            .when('/bookcategory',
                {
                    templateUrl: '/BookCategory/Index',
                    controller: "BookCategoryController"
            })
            .when('/author',
                {
                    templateUrl: '/Author/Index',
                    controller: "AuthorController"
            })
            .when('/book',
                {
                    templateUrl: '/Book/Index',
                    controller: "BookController"
            })
            .when('/report',
                {
                    templateUrl: '/Report/Index',
                    controller: "DashboardCtrl"
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
