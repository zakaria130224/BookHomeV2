'use strict';

app.factory('GetService', function ($http, tokenService, BasedApiUrl) {
    return {
        GetData: function (url) {
            var baseUrl = BasedApiUrl.BasedApiUrl();
            var promise = $http({
                method: 'GET',
                headers: tokenService.get(),
                url: baseUrl + url
            }).then(function (response) {
                return response.data;
            });

            return promise;
        },
        GetDataAndSavetoCache: function (url) {
            var baseUrl = BasedApiUrl.BasedApiUrl();
            var promise = $http({
                method: 'GET',
                cache: true,
                headers: tokenService.get(),
                url: baseUrl + url
            }).then(function (response) {
                return response.data;
            });

            return promise;
        }
    };
});