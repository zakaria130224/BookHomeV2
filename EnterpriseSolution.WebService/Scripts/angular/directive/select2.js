(function () {
    "use strict";
    var module = angular.module('ui.select2', []);

    module.value('uiSelect2Config', {});

    module.directive('uiSelect2', [
        'uiSelect2Config', '$timeout', '$compile', '$parse', '$q', '$rootScope', '$templateCache',
        function (uiSelect2Config, $timeout, $compile, $parse, $q, $rootScope, $templateCache) {
            var options = {};
            if (uiSelect2Config) {
                angular.extend(options, uiSelect2Config);
            }
            return {
                require: '?ngModel',
                link: function (scope, element, attrs, ngModel) {
                    element.removeClass('form-control');
                    if (isMobileBrowser()) {
                        fixFastClose();
                    }
                    // instance-specific options
                    var opts = setupOptions();
                    setupAttributeAndClassSynchronization();
                    setupCleanupOnDestroy();

                    if (attrs.isOpen) {
                        setupIsOpenBinding();
                    }

                    if (attrs.query) {
                        setupQueryHandler();
                    } else {
                        scheduleResyncAfterEveryDigest();
                    }

                    element.select2(opts);
                    return;


                    //Privates

                    //This fixes a bug on some android browsers where select closes immediately after opening
                    function fixFastClose() {
                        var abstractSelect2 = window.Select2['class'].abstract.prototype;
                        if (abstractSelect2.fixed) {
                            return;
                        }
                        abstractSelect2.fixed = true;
                        var existingOpen = abstractSelect2.open;
                        var existingClose = abstractSelect2.close;
                        var lastOpened = new Date().getTime();

                        abstractSelect2.open = function () {
                            lastOpened = new Date().getTime();
                            return existingOpen.apply(this, arguments);
                        };

                        abstractSelect2.close = function () {
                            var currentTime = new Date().getTime();
                            var timeSinceOpen = currentTime - lastOpened;
                            if (timeSinceOpen > 1000) {
                                return existingClose.apply(this, arguments);
                            }
                            return undefined;
                        };
                    }

                    function setupOptions() {
                        var opts = angular.extend({}, options, scope.$eval(attrs.uiSelect2));
                        opts.shouldFocusInput = shouldFocusInput;
                        setupFormatter(opts);
                        return opts;
                    }

                    function getTemplateHtml() {
                        if (attrs.optionTemplate) {
                            return scope.$eval(attrs.optionTemplate);
                        }
                        if (attrs.optionTemplateUrl) {
                            return $templateCache.get(attrs.optionTemplateUrl);
                        }

                    }

                    function setupFormatter(opts) {
                        if (!attrs.optionTemplate && !attrs.optionTemplateUrl) {
                            return;
                        }
                        var templateHtml = getTemplateHtml();
                        var templateNode = angular.element("<div>" + templateHtml + "</div>");
                        var compiledTemplate = $compile(templateNode);
                        opts.formatResult = function (data) {
                            var tempScope = scope.$new();
                            tempScope.$option = data;
                            var template = null;
                            compiledTemplate(tempScope, function (clone) {
                                template = clone.children();

                            });
                            scope.$digest();
                            return template;

                        }

                    }

                    function scheduleResyncAfterEveryDigest() {
                        //After every digest make sure that select2's value is in sync
                        var scheduledValue = false;
                        scope.$watch(function () {
                            //Only schedule once per digest cycle regardles of times watch is called;
                            if (!scheduledValue) {
                                scheduledValue = true;
                                $timeout(function () {
                                    element.select2('val', element.val());
                                    scheduledValue = false;
                                }, 0, false);
                            }
                        });
                    }

                    function shouldFocusInput(instance) {
                        // Attempt to detect touch devices
                        var supportsTouchEvents = (('ontouchstart' in window) || (navigator.msMaxTouchPoints > 0));

                        // Only devices which support touch events should be special cased
                        if (!supportsTouchEvents) {
                            return true;
                        }

                        if (isMobileBrowser()) {
                            return false;
                        } // Don't focus (show virtual keyboard) on mobile devices

                        // Never focus the input if search is disabled
                        if (instance.opts.minimumResultsForSearch < 0) {
                            return false;
                        }

                        return true;
                    }

                    function isMobileBrowser() {
                        /// <summary>
                        /// Based on: http://detectmobilebrowsers.com/
                        /// added the following: |ipad|playbook|silk|tablet pc
                        /// </summary>
                        var a = navigator.userAgent || navigator.vendor || window.opera;
                        return /(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|tablet pc|hiptop|iemobile|ip(hone|od)|playbook|ipad|iris|kindle|silk|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(a)
                            || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4));
                    }


                    function setupIsOpenBinding() {
                        var isOpen = false;
                        var isOpenExpression = $parse(attrs.isOpen);
                        scope.$watch(isOpenExpression, function (value) {
                            if (value && !isOpen) {
                                $timeout(function () {
                                    isOpen = true;
                                    element.select2('open');
                                }, 0, false);

                            }
                            if (!value && isOpen) {
                                $timeout(function () {
                                    element.select2('close');
                                    isOpen = false;
                                    element.select2('close');
                                }, 0, false);
                            }
                        });

                        element.on('select2-open.select2', function () {
                            scope.$apply(function () {
                                isOpen = true;
                                isOpenExpression.assign(scope, true);
                            });
                        });

                        element.on('select2-close.select2', function () {
                            scope.$apply(function () {
                                isOpen = false;
                                isOpenExpression.assign(scope, false);
                            });
                        });
                    }


                    function setupCleanupOnDestroy() {
                        element.on("$destroy", function () {
                            element.select2("destroy");
                            element.off('.select2');
                        });
                    }


                    function setupAttributeAndClassSynchronization() {
                        attrs.$observe('disabled', function (value) {
                            element.select2('enable', !value);
                        });

                        attrs.$observe('readonly', function (value) {
                            element.select2('readonly', !!value);
                        });

                        // Update valid and dirty statuses
                        if (ngModel) {
                            ngModel.$parsers.push(function (value) {
                                var div = element.select2("container");
                                div
                                    .toggleClass('ng-invalid', !ngModel.$valid)
                                    .toggleClass('ng-valid', ngModel.$valid)
                                    .toggleClass('ng-invalid-required', !ngModel.$valid)
                                    .toggleClass('ng-valid-required', ngModel.$valid)
                                    .toggleClass('ng-dirty', ngModel.$dirty)
                                    .toggleClass('ng-pristine', ngModel.$pristine);
                                return value;
                            });
                        }
                    }


                    function setupQueryHandler() {
                        var queryResults = [];
                        ngModel.$parsers.unshift(function (value) {
                            var result = queryResults[value];
                            return result;
                        });

                        ngModel.$formatters.push(function (value) {
                            if (value) {
                                var label = scope.$eval(attrs.queryLabel, {
                                    option: value
                                });
                                element.select2('data', {
                                    text: label
                                });
                            }
                        });

                        opts.query = function (query) {
                            if (query.page === 1) {
                                queryResults = [];
                            }

                            var queryOptions = {
                                term: query.term,
                                page: query.page,
                                context: query.context
                            };
                            var resultPromiseOrObject = scope.$eval(attrs.query, {
                                query: queryOptions
                            });

                            $q.when(resultPromiseOrObject).then(function (result) {
                                var select2Results = [];
                                var i = queryResults.length;

                                angular.forEach(result.results, function (option) {
                                    var context = {
                                        option: option
                                    };
                                    var label = scope.$eval(attrs.queryLabel, context);
                                    select2Results.push({
                                        id: i,
                                        text: label
                                    });
                                    i++;
                                });

                                queryResults = queryResults.concat(result.results);
                                query.callback({
                                    results: select2Results,
                                    more: result.more
                                });
                            });
                        };
                    }

                }
            };
        }
    ]);
})();