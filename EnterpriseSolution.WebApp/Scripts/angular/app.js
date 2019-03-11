'use strict';

var app = angular.module('EnterpriseSolution', ['ngRoute', 'flash','datatables','angular-loading-bar'])
    .config(function ($routeProvider) {

        $routeProvider
            .when('/',
            {
                template: '<h2 align="center" >User Construction </h2>',

            })
            .when('/testRouting',
            {
                templateUrl: '/ThemeMochup/TestRouting'
            })
            .when('/assets',
            {
                templateUrl: '/Application/Assets',
                controller: "AssetCaptureCtrl"
            })
            .when('/assets/assetcapture',
            {
                templateUrl: '/Application/AddAssets',
                controller: "AddAssetCtrl"
            })
            .when('/assets/manageAssets/:state',
            {
                templateUrl: '/Application/ManageAssets',
                controller: "ManageAssetsCtrl"

            })
              .when('/assets/manageAssets',
            {
                templateUrl: '/Application/ManageAssets',
                controller: "ManageAssetsCtrl"

            })
         
             .when('/assets/manageEvents',
            {
                templateUrl: '/Application/ManageEvents',
                controller: "ManageEventsCtrl"

            })


        .otherwise(
        {
            redirectTo: '/assets'
        });
    });