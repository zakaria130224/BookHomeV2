'use strict';
app.service('LoginService', function ($http,Flash, $timeout) {

    this.login = function (userlogin, baseUrl) {
        //alert(baseUrl);
        var resp = $http({
            url: baseUrl + "LoginApi?userName=" + userlogin.userName + "&password=" + userlogin.password,
            method: "GET",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        });
        return resp;
    };

    this.logout = function() {
        sessionStorage.removeItem('accessToken');
        localStorage.clear();
        localStorage.setItem('logged_in', false);
        window.location.href = '/Account/Login';
    }
    this.setupLoggedinUser = function (resp) {

        sessionStorage.setItem('accessToken', resp.data.substring(1, resp.data.length - 1));
        localStorage.setItem('logged_in', true);
        Flash.create('success', 'Logged in successfully!', 'custom-class');
       
        $timeout(function () {
            window.location.href = '/Application/Insight';
        }, 2000);

    }

});