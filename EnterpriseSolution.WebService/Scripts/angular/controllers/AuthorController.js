app.controller('AuthorController', function (CommonService,$route, $routeParams, $location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout, BookCategoryService) {
    console.log("Inside AuthorController");
    CommonService.Get('/Author/GetAll').then(function (data) {
        $scope.listOfModel = data;
        //console.log(data);
    });

    $scope.Save = function (model) {
        CommonService.InsertOrUpdate('/Author/Insert',model);
    };
    $scope.Update = function (model) {
        CommonService.InsertOrUpdate('/Author/Update', model);
    };

    $scope.OpenEditModal = function (Id) {
        CommonService.Get('/Author/GetById?id=' + Id).then(function (data) {
            data.DateOfBirth = new Date(parseInt(data.DateOfBirth.substr(6)));
            data.DateOfDeath = new Date(parseInt(data.DateOfDeath.substr(6)));
            $scope.Model = data;
            console.log(data);
        });
    };
    $scope.OpenSaveModal = function () {
        $scope.Model = null;
    };
    //$scope.Delete = function () {
    //    CommonService.InsertOrUpdate('/Author/Update', model);
    //};
});