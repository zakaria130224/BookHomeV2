app.factory('AssetDetailService',
    function ($http, BasedApiUrl, httpService) {
        return {
            GetAssetDetails: function () {
                var promise = httpService.Get("AssetDetailsApi/GetAssetDetails")
                    .then(function (data) {
                        return data;
                    });

                return promise;
            },
            Save: function (data) {

                var baseUrl = BasedApiUrl.ApiBaseUrl();
                var resp = $http({
                    url: baseUrl + "AssetDetailsApi/AddAssetDetails",
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
            Update: function (data) {
                var baseUrl = BasedApiUrl.ApiBaseUrl();
                var resp = $http({
                    url: baseUrl + "AssetDetailsApi/UpdateAssetDetails",
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
            Delete: function (data) {
                var baseUrl = BasedApiUrl.ApiBaseUrl();
                var resp = $http({
                    url: baseUrl + "AssetDetailsApi/DeleteAssetDetails",
                    method: "DELETE",
                    data: data,
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                })
                   .then(function (response) {

                       return response.data;
                   });
                return resp;
            }
        }
    });