'use strict';

app.service('tokenService', function ($http) {
    this.get = function () {
        var accesstoken = sessionStorage.getItem('accessToken');
        var logged_in = localStorage.getItem('logged_in').toString().trim() === 'false' ? false : true;
        var authHeaders = {};
        if (accesstoken && logged_in) {
            authHeaders.Authorization = 'Bearer ' + accesstoken;
        }

        return authHeaders;
    };
});