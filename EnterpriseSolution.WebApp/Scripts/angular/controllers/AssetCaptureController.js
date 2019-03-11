app.controller('AssetCaptureCtrl', function (AssetCaptureService,$scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout) {

    AssetCaptureService.GetAllAssetCapture()
        .then(function (data) {
            $scope.AssetsList = data;
            console.log(data);
        });


});


app.controller('AddAssetCtrl', function ($location, $scope, LoginService, $http, $rootScope, Flash, BasedApiUrl, $timeout, AssetCaptureService,savingProcessService) {


    $scope.AssetActive = "active";
    $scope.DepresetionActive = "";
    $scope.IsAssetTabActive = true;
    var baseUrl = BasedApiUrl.ApiBaseUrl();

    $scope.processList = savingProcessService.GetProcessList(null, '/assets/manageAssets/saving');
    $scope.processList[0].Class = 'active';
   

    $scope.Next = function (link) {
       
        if ($scope.asset != null) {
            $scope.asset.ProductCode = $scope.assetDataModel.SystemGenarateProductCode;
            $scope.asset.ContractReference = $scope.assetDataModel.SystemGenarateContractRefference;
            $scope.asset.SourceReference = $scope.assetDataModel.SystemGenarateContractRefference;
            $scope.asset.UserReference = $scope.assetDataModel.SystemGenarateUserReffence;
            $scope.asset.SourceCode = $scope.assetDataModel.SourceCode;
            console.log($scope.asset);
            AssetCaptureService.Save($scope.asset);
            savingProcessService.Next(link);
        } else {
            alert("Please fill the form");
        }
       
        
        
    }



    AssetCaptureService.GetDropDownData().then(function (data) {
        $scope.assetDataModel = data;
    });

    $scope.assetCapture = function (id) {
       
        
        //1. go to next window
        $scope.name = true;
     
       



    }
    $scope.tabClick = function (status) {
        if (status === "asset") {
            $scope.AssetActive = "active";
            $scope.DepresetionActive = "";
            $scope.IsAssetTabActive = true;
        } else {
            $scope.AssetActive = "";
            $scope.DepresetionActive = "active";
            $scope.IsAssetTabActive = false;
        }

    }


   

});

