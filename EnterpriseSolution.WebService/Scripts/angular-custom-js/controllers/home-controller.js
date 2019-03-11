(function (ng, app) {

    "use strict";

    app.controller("HomeController", ['$http', '$filter', 'DTOptionsBuilder', 'DTColumnBuilder',
    function ($http, $filter, DTOptionsBuilder, DTColumnBuilder, $scope, requestContext, _)
    {
        // --- Define Controller Methods. ------------------- //
        alert('HomeController Calling...');

        // ...


        // --- Define Scope Methods. ------------------------ //


        // ...


        // --- Define Controller Variables. ----------------- //


        // Get the render context local to this controller (and relevant params).
        var renderContext = requestContext.getRenderContext("home");


        // --- Define Scope Variables. ---------------------- //


        // The subview indicates which view is going to be rendered on the page.
        $scope.subview = renderContext.getNextSection();

        // Get the current year for copyright output.
        $scope.copyrightYear = (new Date()).getFullYear();


        // --- Bind To Scope Events. ------------------------ //


        // I handle changes to the request context.
        $scope.$on(
            "requestContextChanged",
            function () {

                // Make sure this change is relevant to this controller.
                if (!renderContext.isChangeRelevant()) {

                    return;

                }

                // Update the view that is being rendered.
                $scope.subview = renderContext.getNextSection();

            }
        );


        // --- Initialize. ---------------------------------- //
        $scope.dtColumns = [
            DTColumnBuilder.newColumn("ID", "ID").withOption('name', 'ID'),
            DTColumnBuilder.newColumn("FirstName", "First Name").withOption('name', 'FirstName'),
            DTColumnBuilder.newColumn("LastName", "Last Name").withOption('name', 'LasttName'),
            DTColumnBuilder.newColumn("Gender", "Gender").withOption('name', 'Gender'),
            DTColumnBuilder.newColumn("Salary", "Salary").withOption('name', 'Salary'),
            DTColumnBuilder.newColumn("DOJ", "Date of Join")
                .withOption('name', 'DOJ').renderWith(function (data, type) {
                    var dt = data.replace("/Date(", "").replace(")/", "");
                    return $filter('date')(dt, 'dd/MM/yyyy'); //date filter
                })
        ];

        $scope.dtOptions = DTOptionsBuilder.newOptions().withOption('ajax', {
            dataSrc: "data",
            url: "/home/getEmployeeListAll/",
            type: "POST"
        })
            .withOption('processing', true)
            .withOption('serverSide', true)
            .withPaginationType('full_numbers')
            .withDisplayLength(10)
            .withOption('aaSorting', [0, 'asc'])
            //.withOption('scrollX', '100%')
            //.withOption('scrollY', '300px')
            .withOption('scrollCollapse', false)

        // ...


    }]);

})(angular, enterprise);

//'use strict';

//app.controller('homeController', ['$scope', '$http', '$filter', 'DTOptionsBuilder', 'DTColumnBuilder',
//    function ($scope, $http, $filter, DTOptionsBuilder, DTColumnBuilder) {

//        $scope.dtColumns = [
//            DTColumnBuilder.newColumn("ID", "ID").withOption('name', 'ID'),
//            DTColumnBuilder.newColumn("FirstName", "First Name").withOption('name', 'FirstName'),
//            DTColumnBuilder.newColumn("LastName", "Last Name").withOption('name', 'LasttName'),
//            DTColumnBuilder.newColumn("Gender", "Gender").withOption('name', 'Gender'),
//            DTColumnBuilder.newColumn("Salary", "Salary").withOption('name', 'Salary'),
//            DTColumnBuilder.newColumn("DOJ", "Date of Join")
//                .withOption('name', 'DOJ').renderWith(function (data, type) {
//                    var dt = data.replace("/Date(", "").replace(")/", "");
//                    return $filter('date')(dt, 'dd/MM/yyyy'); //date filter
//                })
//        ];

//        $scope.dtOptions = DTOptionsBuilder.newOptions().withOption('ajax', {
//            dataSrc: "data",
//            url: "/home/getEmployeeListAll/",
//            type: "POST"
//        })
//            .withOption('processing', true)
//            .withOption('serverSide', true)
//            .withPaginationType('full_numbers')
//            .withDisplayLength(10)
//            .withOption('aaSorting', [0, 'asc'])
//            //.withOption('scrollX', '100%')
//            //.withOption('scrollY', '300px')
//            .withOption('scrollCollapse', false)

//    }]);