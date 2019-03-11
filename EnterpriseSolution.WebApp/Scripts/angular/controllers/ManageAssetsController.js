app.controller('ManageAssetsCtrl', function ($routeParams, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout, AssetDetailService, savingProcessService) {
    angular.element('#navTab1').addClass('active');

    if ($routeParams.state === "saving") {
        $scope.savingProcess = true;
    }

    $scope.eventsTab = function(tabName) {
        if (tabName === 'navTab1' || $scope.screen === 'events') {
           angular.element('.active').removeClass('active');
           angular.element('#navTab1').addClass('active');
           angular.element('#navTabContent1').addClass('active');
           angular.element('#navTabContent1').addClass('in');
        }
        //else if (tabName === 'navTab2') {
        //    angular.element('.active').removeClass('active');
        //    angular.element('#' + tabName).addClass('active');
        //    angular.element('#navTabContent2').addClass('active');
        //    angular.element('#navTabContent2').addClass('in');

        //    AssetDetailService.GetAssetDetails()
        //        .then(function (data) {
        //            scope.assetDetailsList = data;
        //        });
        //}  //else if (tabName === 'navTab2') {
        //    angular.element('.active').removeClass('active');
        //    angular.element('#' + tabName).addClass('active');
        //    angular.element('#navTabContent2').addClass('active');
        //    angular.element('#navTabContent2').addClass('in');

        //    AssetDetailService.GetAssetDetails()
        //        .then(function (data) {
        //            scope.assetDetailsList = data;
        //        });
        //}
        else if (tabName === 'navTab3') {
            angular.element('.active').removeClass('active');
            angular.element('#' + tabName).addClass('active');
            angular.element('#navTabContent3').addClass('active');
            angular.element('#navTabContent3').addClass('in');
        }
        else if (tabName === 'navTab4') {
            angular.element('.active').removeClass('active');
            angular.element('#' + tabName).addClass('active');
            angular.element('#navTabContent4').addClass('active');
            angular.element('#navTabContent4').addClass('in');
        }
        else if (tabName === 'navTab5') {
            angular.element('.active').removeClass('active');
            angular.element('#' + tabName).addClass('active');
            angular.element('#navTabContent5').addClass('active');
            angular.element('#navTabContent5').addClass('in');
        }
        else if (tabName === 'navTab6') {
            angular.element('.active').removeClass('active');
            angular.element('#' + tabName).addClass('active');
            angular.element('#navTabContent6').addClass('active');
            angular.element('#navTabContent6').addClass('in');
        }
        else if (tabName === 'navTab7') {
            angular.element('.active').removeClass('active');
            angular.element('#' + tabName).addClass('active');
            angular.element('#navTabContent7').addClass('active');
            angular.element('#navTabContent7').addClass('in');
        }
        else if (tabName === 'navTab8') {
            angular.element('.active').removeClass('active');
            angular.element('#' + tabName).addClass('active');
            angular.element('#navTabContent8').addClass('active');
            angular.element('#navTabContent8').addClass('in');
        }
        else if (tabName === 'navTab9') {
            angular.element('.active').removeClass('active');
            angular.element('#' + tabName).addClass('active');
            angular.element('#navTabContent9').addClass('active');
            angular.element('#navTabContent9').addClass('in');
        }
      
    }
 
    //next option
    $scope.processList = savingProcessService.GetProcessList("/assets/assetcapture", "/assets/manageEvents");
    $scope.Next = function (link) {
        savingProcessService.Next(link);
    }
    $scope.Prev = function (link) {
        alert(link);
        savingProcessService.Prev(link);
    }
    $scope.processList[1].Class = "active";

    $scope.EventsList = [
       {
           EventNumber: "2",
           EventCode: 'Capt',
           Description: "Capitilazation of fixed Asset",
           EventDate: "2015-01-05",
           AuthrizationStatus: "Unauthrised",
           MakerId: "Mosaddik_3421",
         
       },
       {
           EventNumber: "2",
           EventCode: 'Capt',
           Description: "Capitilazation of fixed Asset",
           EventDate: "2015-01-05",
           AuthrizationStatus: "Unauthrised",
           MakerId: "Mosaddik_3421",
         
       },
    
    ];

    $scope.linkedDetailsList = [
         {
             ExpenseProcessing: 12440923,
             ContractRefference: 'ContractRefference',
             VendorCode: '324545',
             ContractAmount: '123tk',
             LinkedAmount: 40,
         },

        {
            ExpenseProcessing: 98852343,
            ContractRefference: 'ContractRefference',
            VendorCode: '324545231',
            ContractAmount: '432tk',
            LinkedAmount: 2000,
        }

       

    ];

    
  


});





