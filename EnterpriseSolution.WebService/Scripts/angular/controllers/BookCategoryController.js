app.controller('BookCategoryController', function ( $route, $routeParams, $location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout, BookCategoryService) {
    console.log("Inside Book Category");
    BookCategoryService.GetAll().then(function (data) {
        $scope.listOfModel = data;
    });
    $scope.Save = function (model) {
        BookCategoryService.Insert(model);
    };

    $scope.Update = function (model) {
        BookCategoryService.Update(model);
    };

    $scope.OpenEditModal = function (Id) {
        BookCategoryService.GetById(Id).then(function (data) {
            $scope.Model = data;
        });
    };
    $scope.OpenSaveModal = function () {
        $scope.Model = null;
    };
});



