'use strict';

app.service('LoginService', function ($http, Flash, toastr, $timeout) {
    var firstLogin = false;

    this.getLoginState = function () {
        return firstLogin;
    };

    this.setLogInState = function (state) {
        console.log('calling set login state');
        console.log(state);
        firstLogin = state;
    };

    this.login = function (userlogin, baseUrl) {
        var loginUrl = "Login/MakeLogin?userName=" + userlogin.userName + "&password=" + userlogin.password;

        var resp = $http({
            url: loginUrl,
            method: "GET",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        });

        return resp;
    };

    this.routeToChangePassword = function (Id) {
        window.location.href = "/Login/ChangePassword?Id=" + Id;
    };

    this.logout = function () {
        sessionStorage.removeItem('accessToken');
        localStorage.clear();
        localStorage.setItem('logged_in', false);
        localStorage.setItem('first_log_in', false);
        this.setLogInState(false);
        window.location.href = '/';
    };

    this.setupLoggedinUser = function (resp) {
        //sessionStorage.setItem('accessToken', resp.data.substring(1, resp.data.length - 1));
        localStorage.setItem('logged_in', true);
        localStorage.setItem('first_log_in', true);

        this.setLogInState(true);

        //Flash.create('success', 'Logged in successfully!', 'custom-class');
        //toastr.success('Logged in successfully!', 'Success');
        $timeout(function () {
            window.location.href = '/Application/Insight/Dashboard';
        }, 0);
    };

    this.UpdateUserPassword = function (usersId, newPassword, oldPassword) {
        $http({
            method: 'POST',
            url: '/Users/UpdateUserPassword',
            data: {
                usersId: usersId,
                newPassword: newPassword,
                oldPassword: oldPassword
            }
        }).then(function successCallback(response) {
            if (response.data.success === true) {
                localStorage.clear();
                toastr.success('Password is successfully Changed!', 'Log in Info!');
                //Flash.create('success', 'Password is successfully Changed!', 'custom-class');
                //$timeout(function () {
                //    window.location.href = '/';
                //}, 1000);

            } else {
                //Flash.create('danger', response.data.errorMessage);
                toastr.error(response.data.errorMessage, 'Log in Info!');
            }
        }, function errorCallback(response) {
            //Flash.create('error', response, 'custom-class');
            toastr.error(response, 'error');
        });
    };
});