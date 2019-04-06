app.controller('BookController', function (CommonService, $route, $routeParams, $location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout, $window) {
    console.log("Inside BookController");
    CommonService.Get('/Book/GetAll').then(function (data) {
        init();
        $scope.listOfModel = data;
        //console.log(data);
    });
    init = function () {
        CommonService.Get('/Author/GetAll').then(function (data) {
            $scope.Authors = data;
            //console.log(data);
        });
        CommonService.Get('/BookCategory/GetAll').then(function (data) {
            $scope.Categories = data;
            //console.log(data);
        });
    };
    $scope.OpenSaveModal = function () {
        init();
        $scope.Model = null;
    };
    $scope.Save = function (model) {
        //CommonService.InsertOrUpdate('/Author/Insert', model);
        model.Image = model.Image.base64;
        CommonService.InsertOrUpdate('/Book/Insert', model);
       
        //console.log(model);
    };
    $scope.OpenEditModal = function (Id) {
        CommonService.Get('/Book/GetById?id=' + Id).then(function (data) {
            $scope.ImagePreview = data.Image;
            $scope.Model = data;
            //console.log(data);
        });
    };
    $scope.Update = function (model) {
        model.Image = model.Image.base64;
        CommonService.InsertOrUpdate('/Book/Update', model);
    };
    $scope.preview = function () {
        $scope.ImagePreview = $scope.Model.Image.base64;
    };

});