app.controller('UserCtrl', function (userService, $route, $routeParams, $location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout) {


    userService.GetListBranches().then(function (data) {
        $scope.branchlist = data;
    });

    $scope.OpenEditUserModal = function (user) {
        console.log(user);
        userService.GetUserById(user).then(function (data) {
            $scope.userDetails = data;
            console.log($scope.userDetails);
        });
    };
   

    $scope.UpdateUser = function (userDetails) {
        userService.UpdateUser(userDetails);
    };

    $scope.getUserId = function () {
       // console.log('I getUserId ');
        userService.GetUserId().then(function (data) {
            
            $scope.user.UserId = data;
            console.log($scope.user.UserId);
        });
       // $scope.user.UserId = $scope.userId;
    };

    //Update Supplier Info to Supplier Table
    $scope.saveUser = function (user) {
        userService.InsertUserInfo(user);
    }

    $scope.DeleteUser = function (userId) {
        userService.DeleteUser(userId);
    };
    userService.GetUserList()
        .then(function (data) {
            $scope.listOfUserDetails = data;
        });

    //Get Asset Categories
    userService.GetUserRoleList()
        .then(function (data) {
            $scope.roleList = data;
        });


});



