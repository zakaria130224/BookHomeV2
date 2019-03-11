app.directive('numbersOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^0-9]/g, '');

                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                return undefined;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});

app.directive('decimalNumber', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^0-9.]/g, '');

                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                return undefined;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});
app.directive('commaseparator', function ($filter) {
    'use strict';
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            if (!ctrl) {
                return;
            }
            ctrl.$formatters.unshift(function () {
                return $filter('number')(ctrl.$modelValue);
            });
            ctrl.$parsers.unshift(function (viewValue) {
                var plainNumber = viewValue.replace(/[\,\.\-\+]/g, ''),
                    b = $filter('number')(plainNumber);
                elem.val(b);
                return plainNumber;
            });
        }
    };
});  

app.directive('voucherSupplierPaymentFooter', function ($templateRequest, $compile) {
    return {
        restrict: 'E',
        link: function ($scope, $element, attr) {
            // Load the html through $templateRequest
            $templateRequest('/Voucher/VoucherSupplierPaymentFooter/').then(function (html) {
                // Convert the html to an actual DOM node
                var template = angular.element(html);
                // Append it to the directive element
                $element.append(template);
                // And let Angular $compile it
                $compile(template)($scope);
            });
        }
    }
});

/*
 * The 'modal' directive creates a common modal and uses custom parameters to distinguish one modal from another.
 * This is helpful to avoid code repetation.
 * 
 * Parameters:
 * -----------
 *  uniqueId: This is the model name which should be created in the controller. Here the controller is the one which map to a view in which the modal directive is used.
    modalTitle: Assign modal title from the view.
    modalLabel: Assign modal label from the view.
    modalData: Assign modal message data variable from the view.
    submitButtonName: Assign name of the submit button
    submitButtonStyle: Assign style of the submit button
    notifyParent: After click on submit it will purform the desired function which is declared in 'notifyParent' and its implementation is in the controller.
 * **/
app.directive('modal', function ($templateRequest, $compile) {
    return {
        restrict: 'E',
        scope: {
            uniqueId: '=',
            modalTitle: '@',
            modalLabel: '@',
            modalData: '=',
            submitButtonName: '@',
            submitButtonStyle: '@',
            notifyParent: '&method'
        },
        link: function ($scope, $element, attr) {
            $templateRequest('/Common/Modal/').then(function (html) {
                var template = angular.element(html);
                $element.append(template);
                $compile(template)($scope);
            });
        },
        transclude: true,
        controller: function ($scope) {
            //$scope.uniqueId = 'pop';

            $scope.NotifyParent = function () {
                //Making scroll bar visible
                $('body.modal-open').css('overflow', '');
                $('.modal-open').css('overflow', '');
                $('body.modal-open').css('overflow', 'visible !important');
                $('.modal-open').css('overflow', 'visible');

                $scope.notifyParent();
            }
        }
    }
});

app.directive('deleteModal', function ($templateRequest, $compile) {
    return {
        restrict: 'E',
        scope: {
            uniqueId: '=',
            deleteTitle: '@',
            deleteLabel: '@',
            notifyParent: '&method'
        },
        link: function ($scope, $element, attr) {
            $templateRequest('/Common/DeleteModal/').then(function (html) {
                var template = angular.element(html);
                $element.append(template);
                $compile(template)($scope);
            });
        },
        transclude: true,
        controller: function ($scope) {
            $scope.NotifyParent = function () {
                //Making scroll bar visible
                $('body.modal-open').css('overflow', '');
                $('.modal-open').css('overflow', '');
                $('body.modal-open').css('overflow', 'visible !important');
                $('.modal-open').css('overflow', 'visible');

                $scope.notifyParent();
            }
        }
    }
});

app.directive('sessionOutModal', function ($templateRequest, $compile) {
    return {
        restrict: 'E',
        scope: {
            uniqueId: '=',
            countDown: '=',
            notifyParent: '&method'
        },
        link: function ($scope, $element, attr) {
            $templateRequest('/Common/SessionOutModal').then(function (html) {
                var template = angular.element(html);
                $element.append(template);
                $compile(template)($scope);
            });
        },
        transclude: true,
        controller: function ($scope) {
            $scope.NotifyParent = function () {
                //Making scroll bar visible
                $('body.modal-open').css('overflow', '');
                $('.modal-open').css('overflow', '');
                $('body.modal-open').css('overflow', 'visible !important');
                $('.modal-open').css('overflow', 'visible');

                $scope.notifyParent();
            }
        }
    }
});

app.directive('salesEntryModal', function ($templateRequest, $compile, HelperService) {
    return {
        restrict: 'E',
        scope: {
            uniqueId: '=',
            screenFields: '=',
            screenIndices: '=',
            payableAccountTitle: '=',
            collectionAccountTitle: '=',
            currency: '=',
            modalTitle: '@',
            submitButtonStyle: '@',
            submitButtonName: '@',
            notifyParent: '&method'
        },
        link: function ($scope, $element, attr) {
            $templateRequest('/Sales/SalesEntryModal/').then(function (html) {
                var template = angular.element(html);
                $element.append(template);
                $compile(template)($scope);
            });
        },
        controller: function ($scope) {
            ///Variable declaration area
            $scope.disableConFac = false;
            $scope.disableSubmitButton = true;
            $scope.payableId = 0;
            $scope.collectionId = 0;

            /**
             * If the selected currency is 'BDT' then make conversion factor 1 otherwise make 0
             * @function CheckForBDT
             * @param {int} currencyId
             */
            $scope.CheckForBDT = function (currencyId) {
                if (HelperService.IsBDT($scope.currency, currencyId)) {
                    $scope.screenFields[$scope.screenIndices.GlEntryConversionFactorIndex].Value = 1;
                    $scope.screenFields[$scope.screenIndices.AdjustmentConversionFactorIndex].Value = 1;
                    $scope.disableConFac = true;
                } else {
                    $scope.screenFields[$scope.screenIndices.GlEntryConversionFactorIndex].Value = 0;
                    $scope.screenFields[$scope.screenIndices.AdjustmentConversionFactorIndex].Value = 0;
                    $scope.disableConFac = false;
                }
            }

            /**
             * Calculate Gain or loss of foreign currency, supplier payment and excess or short supply
             * using gl and adjustment entry. Then call the parent function of the controller.
             * @function NotifyParent
             */
            $scope.NotifyParent = function () {
                //Making scroll bar visible
                $('body.modal-open').css('overflow', '');
                $('.modal-open').css('overflow', '');
                $('body.modal-open').css('overflow', 'visible !important');
                $('.modal-open').css('overflow', 'visible');

                //Common fields between payable and collection
                var glValue = Number($scope.screenFields[$scope.screenIndices.GlEntryTotalFCvalueIndex].Value);
                var glConFac = Number($scope.screenFields[$scope.screenIndices.GlEntryConversionFactorIndex].Value);
                var adjValue = Number($scope.screenFields[$scope.screenIndices.AdjustmentTotalFCvalueIndex].Value);
                var adjConFac = Number($scope.screenFields[$scope.screenIndices.AdjustmentConversionFactorIndex].Value);
                var FCGain = Number($scope.screenFields[$scope.screenIndices.ForeignCurrencyGainIndex].Value);
                var FCLoss = Number($scope.screenFields[$scope.screenIndices.ForeignCurrencyLossIndex].Value);

                var absFCDiff = 0;
                var absValDiff = 0;

                absFCDiff = Math.abs(glConFac - adjConFac);
                absValDiff = Math.abs(glValue - adjValue);

                //payable calculation
                if (typeof $scope.payableAccountTitle !== 'undefined') {

                    //Unique fields of payable
                    var gainOnSP = Number($scope.screenFields[$scope.screenIndices.GainOnSupplierPaymentIndex].Value);
                    var lossOnSP = Number($scope.screenFields[$scope.screenIndices.LossOnSupplierPaymentIndex].Value);

                    //Gain or loss of foreign currency
                    if (adjConFac > glConFac) {
                        FCGain = 0;
                        FCLoss = adjValue * absFCDiff;
                    } else if (adjConFac < glConFac) {
                        FCGain = adjValue * absFCDiff;
                        FCLoss = 0;
                    } else {
                        FCGain = 0;
                        FCLoss = 0;
                    }
                    $scope.screenFields[$scope.screenIndices.ForeignCurrencyGainIndex].Value = FCGain.toFixed(2);
                    $scope.screenFields[$scope.screenIndices.ForeignCurrencyLossIndex].Value = FCLoss.toFixed(2);

                    //Gain or loss on supplier payment
                    if (adjValue > glValue) {
                        gainOnSP = 0;
                        lossOnSP = glConFac * absValDiff;
                    } else if (adjValue < glValue) {
                        gainOnSP = glConFac * absValDiff;
                        lossOnSP = 0;
                    } else {
                        gainOnSP = 0;
                        lossOnSP = 0;
                    }
                    $scope.screenFields[$scope.screenIndices.GainOnSupplierPaymentIndex].Value = gainOnSP.toFixed(2);
                    $scope.screenFields[$scope.screenIndices.LossOnSupplierPaymentIndex].Value = lossOnSP.toFixed(2);

                } else if (typeof $scope.collectionAccountTitle != 'undefined') { //collection calculation

                    //Unique fields of collection
                    var gainOnES = Number($scope.screenFields[$scope.screenIndices.GainOnExcessSupplyIndex].Value);
                    var lossOnSS = Number($scope.screenFields[$scope.screenIndices.LossOnShortSupplyIndex].Value);

                    //Gain or loss of foreign currency
                    if (adjConFac > glConFac) {
                        FCGain = adjValue * absFCDiff;
                        FCLoss = 0;
                    } else if (adjConFac < glConFac) {
                        FCGain = 0;
                        FCLoss = adjValue * absFCDiff;
                    } else {
                        FCGain = 0;
                        FCLoss = 0;
                    }
                    $scope.screenFields[$scope.screenIndices.ForeignCurrencyGainIndex].Value = FCGain.toFixed(2);
                    $scope.screenFields[$scope.screenIndices.ForeignCurrencyLossIndex].Value = FCLoss.toFixed(2);

                    //Gain or loss on excess or short supply
                    if (adjValue > glValue) {
                        gainOnES = glConFac * absValDiff;
                        lossOnSS = 0;
                    } else if (adjValue < glValue) {
                        gainOnES = 0;
                        lossOnSS = glConFac * absValDiff;
                    } else {
                        gainOnES = 0;
                        lossOnSS = 0;
                    }
                    $scope.screenFields[$scope.screenIndices.GainOnExcessSupplyIndex].Value = gainOnES.toFixed(2);
                    $scope.screenFields[$scope.screenIndices.LossOnShortSupplyIndex].Value = lossOnSS.toFixed(2);
                } else {
                    console.log('OMG!');
                }

                //Re-initiating account field
                $scope.payableId = 0;
                $scope.collectionId = 0;

                //Calling parent function to do its work
                $scope.notifyParent();


            }

            /**
             * Clearing the modal fields on close
             * @function ClearDataFields
             */
            $scope.ClearDataFields = function () {
                HelperService.InitiateFields($scope.screenFields, $scope.screenIndices);
            };

            //Using watch for Payable and Collection Account title validation
            $scope.$watch('[payableId, collectionId]', function () {
                if ($scope.payableId > 0) {
                    $scope.disableSubmitButton = false;
                    $scope.screenFields[$scope.screenIndices.PayableAccountTitleIndex].Value = $scope.payableId;
                } else if ($scope.collectionId > 0) {
                    $scope.disableSubmitButton = false;
                    $scope.screenFields[$scope.screenIndices.CollectionAccountTitleIndex].Value = $scope.collectionId;
                } else {
                    $scope.disableSubmitButton = true;
                }
            }, true);

            //check conversion factor validation
            $scope.$watch('[screenFields[screenIndices.GlEntryConversionFactorIndex].Value, screenFields[screenIndices.AdjustmentConversionFactorIndex].Value]', function () {
                if ($scope.screenFields.length !== 0) {
                    var glCF = Number($scope.screenFields[$scope.screenIndices.GlEntryConversionFactorIndex].Value);
                    var adCF = Number($scope.screenFields[$scope.screenIndices.AdjustmentConversionFactorIndex].Value);
                    if (glCF === 0 || adCF === 0) {
                        $scope.disableSubmitButton = true;
                    } else {
                        $scope.disableSubmitButton = false;
                    }
                }
            }, true);
        }
    }
});

app.directive('dynamicDataTable', function ($templateRequest, $compile) {
    return {
        restrict: 'E',
        scope: {
            tableRawData: '=',
            headers: '=',
            showActions: '=',
            headerStyle: '@',
            bodyStyle: '@',
            tableStyle: '@',
            passDeletedRowInfo: '=',
            ignoreColumn: '='
        },
        link: function ($scope, $element, attr) {
            $templateRequest('/Common/DynamicDataTable/').then(function (html) {
                var template = angular.element(html);
                $element.append(template);
                $compile(template)($scope);
            });
        },
        controller: function ($scope, $filter) {
            $scope.showTable = true;
            $scope.numOfColumns = 0;

            ///If nothing is assigned in the headers then it will be undefined
            ///For safety reason we have checked it first.
            if (typeof $scope.headers !== 'undefined') {
                if ($scope.headers.length === 0) {
                    for (var key in $scope.tableRawData[0]) {
                        if ($scope.tableRawData[0].hasOwnProperty(key)) {
                            $scope.headers.push(key);
                            $scope.numOfColumns += 1;
                        }
                    }
                } else {
                    $scope.numOfColumns = $scope.headers.length;
                }
            }

            $scope.$watch('tableRawData', function () {
                //If nothing is assigned in the tableRawData then it will be undefined
                //For safety reason we have checked it first
                if (typeof $scope.tableRawData !== 'undefined') {
                    if ($scope.tableRawData.length > 0) {
                        $scope.showTable = true;
                    } else {
                        $scope.showTable = false;
                    }
                } else {
                    $scope.showTable = false;
                }
            }, true);

            $scope.deleteRow = function (index) {
                var deletedData = $scope.tableRawData[index];
                $scope.tableRawData.splice(index, 1);
                $scope.passDeletedRowInfo = deletedData;
            };

            $scope.CheckIfNumber = function (columnIndex, data) {
                //console.info('columnIndex: ' + columnIndex);
                if (typeof $scope.ignoreColumn === 'undefined') {
                    return (!isNaN(Number(data))) ? $filter('number')(Number(data)) : data;
                }
                else if (columnIndex === $scope.ignoreColumn.columnIndex){
                    return data;
                }
                else {
                    return (!isNaN(Number(data))) ? $filter('number')(Number(data)) : data;
                }
            };
        }
    };
});

app.directive('dynamicJournalDocument', function ($templateRequest, $compile) {
    return {
        restrict: 'E',
        scope: {
            journalType: '@',
            referenceNumberLabel: '@',
            referenceNumber: '=',
            presentDate: '=',
            journalTotal: '=',
            paymentJournalRecords: '=',
            description: '=',
            accountInWords: '=',
            maker: '=',
            checker: '=',
            notifyParent: '&method'
        },
        link: function ($scope, $element, attr) {
            $templateRequest('/Common/JournalView/').then(function (html) {
                var template = angular.element(html);
                $element.append(template);
                $compile(template)($scope);
            });
        },
        controller: function ($scope) {
            $scope.NotifyParent = function () {
                $scope.notifyParent();
            }
            $scope.Print = function (divName) {
                var bodyContent = document.body.innerHTML;
                var bootstrapCssString = '<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">';
                var printContents = document.getElementById(divName).innerHTML;
                var popupWin = window.open('', '_blank', 'width=1024,height=768,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
                popupWin.document.open();
                popupWin.document.write('<html><head>' + bootstrapCssString + '</head><body onload="window.print()">' + printContents + '</body></html>');
                popupWin.document.close();
            }

            $scope.$watch('[paymentJournalRecords]', function () {
                if (typeof $scope.paymentJournalRecords !== 'undefined') {
                    //Deleting debit & credit 0 value records
                    $scope.paymentJournalRecords = $scope.paymentJournalRecords.filter(x => x.Debit !== 0 || x.Credit !== 0);

                    //Sorting the list according to decending order except the last row
                    $scope.paymentJournalRecords.sort(function (a, b) {
                        return b.Debit - a.Debit;
                    });
                }
            }, true);
        }
    }
});

/*Moveable element*/
app.directive('dragable', function () {
    return {
        restrict: 'A',
        link: function (scope, elem, attr) {
            $(elem).draggable();
        }
    }
});

/*Ignore ng-dirty*/
app.directive('ignoreDirty', [function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            ctrl.$setPristine = function () { };
            ctrl.$pristine = false;
        }
    }
}]);