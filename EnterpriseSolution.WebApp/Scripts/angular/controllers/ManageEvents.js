app.controller('ManageEventsCtrl', function ($scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout,savingProcessService) {
    angular.element('#eventTab1').addClass('active');

    $scope.processList = savingProcessService.GetEventsProcessList(null, "eventTab2");
    $scope.processList[0].Class = 'active';
    $scope.overRides = false;
    $scope.Next = function(nextTab) {

        if (nextTab === "eventTab2") {
          

            $scope.processList = savingProcessService.GetEventsProcessList(null, "eventTab3");
            $scope.processList[1].Class = 'active';
            activeEventTab2();

            $scope.Next = function (nextnextTab) {
                $scope.processList = savingProcessService.GetEventsProcessList(null, "eventTab3");
                $scope.processList[2].Class = 'active';
                activeEventTab3();
                $scope.Next = function() {
                    $scope.processList = savingProcessService.GetEventsProcessList(null, "eventTab3");
                }
            }

        }
    }

    $scope.AccountEntriesList = [
      {
          Event: 'BDDL',
          Branch: 'Uttora',
          Account: '1109323',
          AccountDescription: 'Account for fixed assets',
          DrCr: 'Dr',
          AmountTag: 'BDIO',
          AmountCcy: 'Taka',
          ForeignCurrencyAmount: '1000$',
          Rate: '80',
          LocalCurrencyAmount: '80000tk',
          Date: '12-04-2018',
          ValueDate: '12-04-2018',
          TxnCode: '56784'
      }
    ];

    $scope.manageEventsTab = function (tabName) {

        if (tabName === 'eventTab1') {
            activeEventTab1();
        }
        else if (tabName === 'eventTab2') {
            activeEventTab2(tabName);
        }
        else if (tabName === 'eventTab3') {
            activeEventTab3(tabName);
        }




  

    }

    
});


function activeEventTab1() {
    angular.element('.active').removeClass('active');
    angular.element('#eventTab1').addClass('active');
    angular.element('#eventTabContent1').addClass('active');
    angular.element('#eventTabContent1').addClass('in');

}

function activeEventTab2(tabName) {
    angular.element('.active').removeClass('active');
    angular.element('#eventTab2').addClass('active');
    angular.element('#eventTabContent2').addClass('active');
    angular.element('#eventTabContent2').addClass('in');

}

function activeEventTab3(tabName) {
    angular.element('.active').removeClass('active');
    angular.element('#' + tabName).addClass('active');
    angular.element('#eventTabContent3').addClass('active');
    angular.element('#eventTabContent3').addClass('in');

}