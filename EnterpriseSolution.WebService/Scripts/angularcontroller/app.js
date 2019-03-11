var app = angular.module('EnterpriseSolution', ['datatables'])
    .controller('homeController', ['$scope', '$http', '$filter', 'DTOptionsBuilder', 'DTColumnBuilder',

        function ($scope, $http, $filter, DTOptionsBuilder, DTColumnBuilder) {

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

        }]);