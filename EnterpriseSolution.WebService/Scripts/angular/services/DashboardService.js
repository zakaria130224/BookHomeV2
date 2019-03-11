app.factory("dashboardService", function ($http, Flash, toastr, $route) {
    return {
        firstLoggedIn: true,
        GetUserList: function () {
            var promise = $http({
                method: 'GET',
                url: '/Users/GetListOfUserDetails'
            }).then(function successCallback(response) {

                return response.data.data;

            }, function errorCallback(response) {

            });
            return promise;
        },
        GetUserRoleList: function () {
            var promise = $http({
                method: 'GET',
                url: '/Users/GetListOfUserRole'
            }).then(function successCallback(response) {
                return response.data.data;
            }, function errorCallback(response) {
                
            });
            return promise;
        },
        InsertUserInfo: function (user) {
            $http({
                method: 'POST',
                url: '/Users/InsertUserInfo',
                data: user
            }).then(function successCallback(response) {
                //Flash.create('success', "User Information Successfully Saved!", 'custom-class');
                toastr.success('User Information Successfully Saved', 'Success');
                $route.reload();
            }, function errorCallback(response) {

            });

        },
        UpdateUserInfo: function (user) {
            $http({
                method: 'POST',
                url: '/Users/UpdateUserInfo',
                data: user
            }).then(function successCallback(response) {
                $route.reload();
                //Flash.create('success', "User Information Successfully Updated!", 'custom-class');
                toastr.success('User Information Successfully Updated!', 'Success');
            }, function errorCallback(response) {
                //Flash.create('error', response, 'custom-class');
                toastr.error(response.data.errorMessage, 'Error');
            });
        },
        DeleteUser: function (userId) {
            $http({
                method: 'POST',
                url: '/Users/DeleteUser',
                data: { userId: userId }
            }).then(function successCallback(response) {
                $route.reload();
                //Flash.create('success', "User Successfully Deleted!", 'custom-class');
                toastr.success('User Successfully Deleted!', 'Success');
            }, function errorCallback(response) {
                //Flash.create('error', response, 'custom-class');
                toastr.error(response.data.errorMessage, 'Error');
            });
        },
        GetDashboardDataModel: function (glCode) {
            var promise = $http({
                method: 'GET',
                url: '/Users/GetDashboardDataModel?glCode=' + glCode
            }).then(function successCallback(response) {
                return response.data.data;
            }, function errorCallback(response) {

            });
            return promise;
        },
        CalculateDepreciation: function () {
            var promise = $http({
                method: 'GET',
                url: '/Assets/CalculateDepreciation'
            }).then(function (response) {
                if (response.data.success === true) {
                    return response.data.data;
                } else {
                    console.log(response.data.errorMessage);
                }
            });
            return promise;
        }
    }
});