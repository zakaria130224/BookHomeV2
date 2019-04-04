app.factory("CommonService", function ($http, Flash, toastr, $route) {

    return {
        Get: function (url) {
            var promise = $http({
                method: 'GET',
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
        },
        InsertOrUpdate: function (url,Model) {
            $http({
                method: 'POST',
                url: url,
                data: Model
            }).then(function successCallback(response) {
                toastr.success('User Information Successfully Saved!', 'Success');
                $route.reload();
            }, function errorCallback(response) {

            });

        },
        Delete: function (url, Model) {
            $http({
                method: 'POST',
                url: url,
                data: Model
            }).then(function successCallback(response) {
                toastr.warning('User Information Successfully Saved!', 'Success');
                $route.reload();
            }, function errorCallback(response) {

            });

        }

    }
});