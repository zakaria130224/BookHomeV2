app.factory('savingProcessService', function ($timeout,$http,$location) {
    return {
        GetProcessList: function (prev, next) {
            var processList = [

             {
                 'Id': 1,
                 'Name': 'Asset Capture',
                 'Class':'inactive',
                 'Prev': prev,
                 'Next': next
             },
              {
                  'Id': 2,
                  'Name': 'Events',
                  'Prev': prev,
                  'Class': 'inactive',
                  'Next': next
              },
               {
                   'Id': 3,
                   'Name': 'Linkage Details',
                   'Prev': prev,
                   'Next': next,
                   'Class': 'inactive',
               },
                {
                    'Id': 4,
                    'Name': 'Setp 4',
                    'Class': 'inactive',
                    'Prev': prev,
                    'Next': next
                },
                 {
                     'Id': 5,
                     'Name': 'Fields',
                     'Class': 'inactive',
                     'Prev': prev,
                     'Next': next
                 }




            ];
            return processList;
        },

        GetEventsProcessList: function (prev, next) {
            var processList = [

             {
                 'Id': 1,
                 'Name': 'Account Entries',
                 'Class': 'inactive',
                 'Prev': prev,
                 'Next': next
             },
              {
                  'Id': 2,
                  'Name': 'Overrides',
                  'Prev': prev,
                  'Class': 'inactive',
                  'Next': next
              },
               {
                   'Id': 3,
                   'Name': 'Messages',
                   'Prev': prev,
                   'Next': next,
                   'Class': 'inactive',
               }
              




            ];
            return processList;
        },

        Next: function (link) {
            var waitForRender = function () {
                if ($http.pendingRequests.length > 0) {
                    $timeout(waitForRender);
                } else {
                    $location.path(link);
                }
            };
            $timeout(waitForRender);
        },
        Prev: function (link) {
            var waitForRender = function () {
                if ($http.pendingRequests.length > 0) {
                    $timeout(waitForRender);
                } else {
                    $location.path(link);
                }
            };
            $timeout(waitForRender);
        }
    }


});