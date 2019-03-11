app.controller('UserRoleCtrl', function (userRoleService, $route, $routeParams, $location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout) {


    //List of all user Role
    userRoleService.GetListOfUserRole().then(function (data) {
        $scope.listOfUserRole = data;
    });

    $scope.OpenEditRoleModal = function (roleId) {
       // console.log(user);
        userRoleService.GetUserRoleById(roleId).then(function (data) {
            $scope.userRoleDetiles = data;
            console.log($scope.userRoleDetiles);
        });
    };

    $scope.updateUserRole = function (userRoleDetiles) {
        userRoleService.UpdateUserRole(userRoleDetiles);
    };

    $scope.saveUserRole = function (userRole) {
        userRoleService.InsertUserRole(userRole);
    };


});

