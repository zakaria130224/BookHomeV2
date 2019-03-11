app.controller('BranchCtrl', function (branceService, $route, $routeParams, $location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout) {


    //List of all branches
    branceService.GetAllBranches().then(function (data) {
        $scope.listOfBranch = data;
        console.log($scope.listOfBranch);
    });
    $scope.saveBranch = function (branchInfo) {
        branceService.InsertBranches(branchInfo);
    }

    $scope.OpenEditBranchModal = function (branchId) {
        // console.log(user);
        branceService.GetBrancheById(branchId).then(function (data) {
            $scope.branchDetiles = data;
            console.log($scope.branchDetiles);
        });
    };

    $scope.UpdateBranch = function (branchDetiles) {
        branceService.UpdateBranches(branchDetiles);
    };
   

});
