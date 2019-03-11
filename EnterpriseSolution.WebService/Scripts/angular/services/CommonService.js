app.factory("CommonService", function ($http, Flash, toastr, $route) {

    return {
        GetDataModel: function (method,url) {
            var promise = $http({
                method: method,
                url: url
            }).then(function (response) {
                console.log(response);
                if (response.data.success === true) {
                    return response.data.data;
                } else {
                    //Flash.create('danger', response.data.errorMessage, 'custom-class');
                    toastr.error(response.data.errorMessage, 'Error');
                }
            });
            return promise;
        }
    }
});