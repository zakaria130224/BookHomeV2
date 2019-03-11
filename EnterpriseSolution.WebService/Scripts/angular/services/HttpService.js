app.factory('httpService',
    function ($http, BasedApiUrl) {
        return {
            Post: function (url, data) {

                var baseUrl = BasedApiUrl.ApiBaseUrl();

                var resp = $http({
                    url: baseUrl + url,
                    method: "POST",
                    data: data,
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                })
                    .then(function (response) {

                        return response.data;
                    });
                return resp;
            },
            Get: function (url) {

                var baseUrl = BasedApiUrl.ApiBaseUrl();

                var resp = $http({
                    url: baseUrl + url,
                    method: "GET",
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                })
                    .then(function (response) {

                        return response.data;
                    });
                return resp;
            },
            Put: function (url, data) {

                var baseUrl = BasedApiUrl.ApiBaseUrl();

                var resp = $http({
                    url: baseUrl + url,
                    method: "PUT",
                    data: data,
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                })
                    .then(function (response) {

                        return response.data;
                    });
                return resp;
            },
            
        }
    });