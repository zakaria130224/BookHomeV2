'use strict';

app.controller('LoginCtrl', function ($scope, $routeParams, LoginService, $http, $rootScope, toastr,Flash, BasedApiUrl, $timeout, HelperService) {

    var baseUrl = BasedApiUrl.ApiBaseUrl();
    $scope.responseData = "";
    $scope.userName = "";
    $scope.accessToken = "";
    $scope.refreshToken = "";
    $scope.userId;
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

        //console.info('User Login Info: ' + JSON.stringify(userLogin));

        var promiselogin = LoginService.login(userLogin, baseUrl);

        promiselogin.then(function (resp) {
            localStorage.setItem('UserInfo', JSON.stringify(resp.data.data));
            if (resp.data.success === true && HelperService.ConvertToDateTimeString(resp.data.data.LastPasswordChangeDate).length > 0) {

                localStorage.setItem('UserId', resp.data.data.Id);
                LoginService.setupLoggedinUser(resp);
            }
            else if (resp.data.success === true && HelperService.ConvertToDateTimeString(resp.data.data.LastPasswordChangeDate).length < 1) {
                localStorage.setItem('UserId', resp.data.data.Id);
                window.location.href = "/Login/ChangePassword";
            }
            else {
                toastr.error(resp.data.errorMessage, 'Log in Info!');
            }
        }, function (err) {
            $scope.responseData = err.data.ExceptionMessage;
            toastr.error($scope.responseData, 'Log in Info!');
        });

    };

    $scope.logout = function () {
        LoginService.logout();
    };
});
app.controller('PassChangeCtrl', function ($scope, $routeParams, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout) {

    $scope.newPassword = '';
    $scope.oldPassword = '';

    $scope.error = '';
    $scope.ChangePassword = function () {
        if ($scope.newPassword === $scope.ConfirmnewPassword) {
            LoginService.UpdateUserPassword(localStorage.getItem("UserId"), $scope.newPassword, $scope.oldPassword);
        } else {
            //Flash.create('danger', "Password doesn't match!", 'custom-class');
            toastr.error("Password doesn't match!", 'Log in Info!');
        }

    };
});