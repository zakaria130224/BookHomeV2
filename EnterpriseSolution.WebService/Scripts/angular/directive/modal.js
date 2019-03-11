app.directive('appModal',
    function () {
        return {
            templateUrl: '/ThemeMochup/Modal',
            controller: 'modalController'
        }
    });
app.controller("modalController",
    function ($rootScope) {
      $rootScope.showModal = false;

    });

app.factory("modalService",
    function ($rootScope) {
        var redirectUrl;
        return {
            create: function (title, description) {
                $rootScope.showModal = true;
                $rootScope.modal = {
                    title : title,
                    description : description
                }
            },
            showModal : function() {
                return true;
            }
            ,
            hideModal: function () {
                return false;
            }
        }
    });