'use strict';

app.controller('LoginCtrl', function ($scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout) {
    
    var baseUrl = BasedApiUrl.ApiBaseUrl();
    $scope.responseData = "";
    $scope.userName = "";
    $scope.accessToken = "";
    $scope.refreshToken = "";
    
    $scope.redirect = function () {
        window.location.href = '/account/login';
    };

    //Function to Login. This will generate Token 
    $scope.login = function () {
        //This is the information to pass for token based authentication
       
        var userLogin = {
            userName: $scope.UserName,
            password: $scope.Password
        };

        var promiselogin = LoginService.login(userLogin, baseUrl);

        promiselogin.then(function (resp) {
            LoginService.setupLoggedinUser(resp);
        }, function (err) {
            //alert($scope.UserName + ', ' + $scope.Password);
            console.log(err);
            $scope.responseData = err.data.ExceptionMessage;
            Flash.create('danger', $scope.responseData, 'custom-class');
        });

    };

    $scope.logout = function () {

        LoginService.logout();


    };
});