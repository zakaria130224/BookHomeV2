app.factory("branceService", function ($http, Flash, toastr, $route) {
    return {
        GetAllBranches: function () {
            console.log('I am here :)');
            var promise = $http({
                method: 'GET',
                url: '/Branch/GetAllBranches'
            }).then(function successCallback(response) {
                if (response.data.success === true) {
                    return response.data.data;
                } else {
                    //Flash.create('danger', response.data.errorMessage, 'custom-class');
                    toastr.error(response.data.errorMessage, 'Error');
                    return {};
                }
            });
            return promise;
        },
        GetBrancheById: function (userId) {
            var promise = $http({
                method: 'GET',
                url: '/Branch/GetBrancheById?id=' + userId,
            }).then(function successCallback(response) {
                if (response.data.success === true) {
                    return response.data.data;
                } else {
                    //Flash.create('danger', response.data.errorMessage, 'custom-class');
                    toastr.error(response.data.errorMessage, 'Error');
                }
            }, function errorCallback(response) {
                //Flash.create('danger', response.data.errorMessage);
                toastr.error(response.data.errorMessage, 'Error');
            });
            return promise;
        },
        InsertBranches: function (branchInfo) {
            $http({
                method: 'POST',
                url: '/Branch/InsertBranches',
                data: {
                    branchInfo: branchInfo
                }
            }).then(function successCallback(response) {
                //Flash.create('success', "User Information Successfully Saved!", 'custom-class');
                toastr.success('User Information Successfully Saved!', 'Success');
                $route.reload();
            }, function errorCallback(response) {

            });

        },

        UpdateBranches: function (branchInfo) {
            $http({
                method: 'POST',
                url: '/Branch/UpdateBranches',
                data: branchInfo
            }).then(function successCallback(response) {
                $route.reload();
                //Flash.create('success', "User Information Successfully Updated!", 'custom-class');
                toastr.success('User Information Successfully Updated!', 'Success');
            }, function errorCallback(response) {
                //Flash.create('error', response, 'custom-class');
                toastr.error(response, 'Error');
            });
        }
    }
});