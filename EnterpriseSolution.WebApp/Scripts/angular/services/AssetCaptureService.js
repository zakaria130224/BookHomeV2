app.factory('AssetCaptureService',
    function ($http,BasedApiUrl) {
        return {
            GetDropDownData : function() {

               
                var baseUrl = BasedApiUrl.ApiBaseUrl();
                var resp = $http({
                        url: baseUrl + "AssetCaptureApi/GetAssetCaptureDropDown",
                        method: "GET",
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                    })
                    .then(function (response) {

                        return response.data;
                    });
                return resp;
            },
            Save: function (data) {
                
                var baseUrl = BasedApiUrl.ApiBaseUrl();

                var resp = $http({
                    url: baseUrl + "AssetCaptureApi/SaveAssetCapture",
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
            GetAllAssetCapture: function () {

                var baseUrl = BasedApiUrl.ApiBaseUrl();

                var resp = $http({
                    url: baseUrl + "AssetCaptureApi/GetAllAssets",
                    method: "GET",
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }

                })
                     .then(function (response) {
                         return response.data;
                     });
                return resp;
            }

        }
    });