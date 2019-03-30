app.factory("BookCategoryService", function ($http, Flash, toastr, $route) {
    return {
        GetAll: function () {

            var promise = $http({
                method: 'GET',
                url: '/BookCategory/GetAll'
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
        GetById: function (Id) {
            var promise = $http({
                method: 'GET',
                url: '/BookCategory/GetById?id=' + Id
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
        Insert: function (BookCategory) {
            $http({
                method: 'POST',
                url: '/BookCategory/Insert',
                data: {
                    BookCategory: BookCategory
                }
            }).then(function successCallback(response) {
                //Flash.create('success', "User Information Successfully Saved!", 'custom-class');
                toastr.success('User Information Successfully Saved!', 'Success');
                $route.reload();
            }, function errorCallback(response) {

            });

        },
        Update: function (BookCategory) {
            $http({
                method: 'POST',
                url: '/BookCategory/Update',
                data: {
                    BookCategory: BookCategory
                }
            }).then(function successCallback(response) {
                //Flash.create('success', "User Information Successfully Saved!", 'custom-class');
                toastr.success('User Information Successfully Saved!', 'Success');
                $route.reload();
            }, function errorCallback(response) {

            });

        }

    };
});