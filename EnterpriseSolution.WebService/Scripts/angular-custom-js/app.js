'use strict';

var enterprise = angular.module('EnterpriseSolution', ['ngRoute', 'datatables', 'ngAnimate'])
    .config(function ($routeProvider) {

        $routeProvider
            .when('/login',
            {
                action: "login"
            })
            .when('/home',
            {
                action: "home"
            })
            .when('/testRouting',
            {
                templateUrl: '/ThemeMochup/TestRouting'
            })
            .when('/Assets',
            {
                templateUrl: '/Application/Assets',
                controller: "AssetCaptureCtrl"
            })
            .when('/mockDashboard',
            {
                template: '/ThemeMochup/Dashboard'
            })
            .otherwise(
            {
                redirectTo: '/home'
            });
    });
    