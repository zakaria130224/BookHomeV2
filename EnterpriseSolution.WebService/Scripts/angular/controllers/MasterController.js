app.controller('masterCtrl', function ( $route, $routeParams, $location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout, HelperService) {

    $scope.sessionOut = 'sessionOut';
    $scope.countDown = 0;

    $scope.DeclineSession = function () {

        LoginService.logout();
    }

    $scope.$on('IdleWarn', function (e, countdown) {
        $scope.countDown = countdown;
        $("#" + $scope.sessionOut).modal();
    });
    $scope.$on('IdleTimeout', function () {
        LoginService.logout();
    });


});