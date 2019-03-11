app.factory("userService", function ($http, Flash, toastr, $route) {
    return {
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
        GetUserById: function (userId) {
            var promise = $http({
                method: 'GET',
                url: '/Users/GetUserById?id=' + userId,
            }).then(function successCallback(response) {
                if (response.data.success === true) {
                    return response.data.data;
                } else {
                    //Flash.create('danger', response.data.errorMessage, 'custom-class');
                    toastr.error(response.data.errorMessage, 'Error');
                }
            }, function errorCallback(response) {
                //Flash.create('danger', response.data.errorMessage, 'custom-class');
                toastr.error(response.data.errorMessage, 'Error');
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

        GetUserId: function () {
            var promise = $http({
                method: 'GET',
                url: '/Users/GetUserId'
            }).then(function successCallback(response) {

                return response.data.data;

            }, function errorCallback(response) {

            });
            return promise;
        },

        GetListBranches: function () {
            var promise = $http({
                method: 'GET',
                url: '/Users/GetListBranches'
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
                toastr.success('User Information Successfully Saved!', 'Success');
                $route.reload();
            }, function errorCallback(response) {
                //Flash.create('danger', response, 'custom-class');
                toastr.error(response, 'Error');
            });

        },

        UpdateUser: function (user) {
            $http({
                method: 'POST',
                url: '/Users/UpdateUser',
                data: user
            }).then(function successCallback(response) {
                $route.reload();
                //Flash.create('success', "User Information Successfully Updated!", 'custom-class');
                toastr.success('User Information Successfully Updated!', 'Success');
            }, function errorCallback(response) {
                //Flash.create('danger', response, 'custom-class');
                toastr.error(response, 'Error');
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
                //Flash.create('danger', response, 'custom-class');
                toastr.error(response, 'Error');
            });
        }
    }
});