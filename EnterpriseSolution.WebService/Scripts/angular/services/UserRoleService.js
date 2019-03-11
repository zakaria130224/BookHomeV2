app.factory("userRoleService", function ($http, Flash, toastr, $route) {
    return {
        GetListOfUserRole: function () {
            console.log('I am here :)');
            var promise = $http({
                method: 'GET',
                url: '/UserRole/GetListOfUserRole'
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

        GetUserRoleById: function (roleId) {
           
            var promise = $http({
                method: 'GET',
                url: '/UserRole/GetUserRoleById?id=' + roleId,
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

        InsertUserRole: function (userRole) {
            $http({
                method: 'POST',
                url: '/UserRole/InsertUserRole',
                data: {
                    userRole: userRole
                }
            }).then(function successCallback(response) {
                //Flash.create('success', "User Information Successfully Saved!", 'custom-class');
                toastr.success('User Information Successfully Saved!', 'Success');
                $route.reload();
            }, function errorCallback(response) {

            });

        },

        UpdateUserRole: function (userRoleDetiles) {
            $http({
                method: 'POST',
                url: '/UserRole/UpdateUserRole',
                data: { userRole: userRoleDetiles }
            }).then(function successCallback(response) {
                $route.reload();
                //Flash.create('success', "User Information Successfully Updated!", 'custom-class');
                toastr.success('User Information Successfully Updated!', 'Success');
            }, function errorCallback(response) {
                //Flash.create('error', response, 'custom-class');
                toastr.error(response.data.errorMessage, 'Error');
            });
        },

      
       
    }
});