app.controller('AdministrationCtrl', function (userService, userRoleService, branceService, $route, $routeParams, $location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout) {


    //Delete Voucher
    $scope.DeleteVoucher = function (Id) {
        voucherService.DeleteVoucher(Id);
    }

    //Reversed Voucher
    $scope.ReversedVoucher = function (Id) {
        voucherService.ReversedVoucher(Id);
    }

    //Authorized Voucher
    $scope.AuthorizedVoucher = function (Id) {
        voucherService.AuthorizedVoucher(Id);
    }


    ////Get Suppliers
    //voucherService.GetAllSuppier()
    //    .then(function (data) {
    //        $scope.supplierList = data;
    //    });

    ////Get Voucher Status
    //voucherService.GetPaymentStatusList()
    //    .then(function (data) {
    //        $scope.voucherStatusList = data;
    //    });

});

app.filter("formatDate", function () {
    var re = /\/Date\(([0-9]*)\)\//;
    return function (x) {
        var m = x.match(re);
        if (m) return new Date(parseInt(m[1]));
        else return null;
    };
});


