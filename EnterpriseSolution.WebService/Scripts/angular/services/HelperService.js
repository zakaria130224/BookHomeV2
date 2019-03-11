app.factory('HelperService', function ($http, BasedApiUrl, $rootScope, $filter) {

    //List of field keys
    var ignoreList = ['AccountTitle', 'AdjustmentHeadOrCredit', 'SelectBank', 'SalesSelectBank'];

    /**
     * Converts the Javascript date or server given JSON date into string type date.
     * 
     * @function DateFormatOfJSDate
     * @param {any} date
     */
    var DateFormatOfJSDate = function (date) {
        if (typeof date !== 'undefined') {
            return date.getUTCFullYear() + "-" + (date.getUTCMonth() + 1) + "-" + date.getUTCDate();
        } else {
            return "";
        }
    }

    /**
     * Converts the Javascript date into string type date.
     * Date format: DD/MM/YYYY
     * @param {any} date
     */
    var DateFormatOfBD = function (date) {
        if (typeof date !== 'undefined') {
            return date.getUTCDate() + "/" + (date.getUTCMonth() + 1) + "/" + date.getUTCFullYear();
        } else {
            return "";
        }
    }

    /**
     * Check if the given object is empty or not.
     * @function isEmpty
     * @param {any} obj
     */
    var isEmpty = function (obj) {
        for (var key in obj) {
            if (obj.hasOwnProperty(key))
                return false;
        }
        return true;
    }

    /**
     * Concats space seperated words into a single word.
     * @function WordWithOutSpace
     * @param {any} str
     */
    var WordWithOutSpace = function (str) {
        var res = str.split(" ");
        var temp = "";
        res.forEach(function (item) {
            temp += item;
        });
        return temp;
    }

    /**
     * Generates the short code by spliting each string into seperate words.
     * Taking each word's first character and concatenate all the chosen ones.
     * @function ShortNameGenerator
     * @param {any} str1
     * @param {any} str2
     */
    var ShortNameGenerator = function (str1, str2) {
        var res1 = str1.split(" ");
        var res2 = str2.split(" ");
        var temp = "";

        res1.forEach(function (item) {
            temp += item.charAt(0);
        });

        res2.forEach(function (item) {
            temp += item.charAt(0);
        });

        return temp;
    };

    /**
     * Checks weather GlActionMatrixId does exists in an array of 'FieldKeyValuePair' objects
     * Note: 'item' object must contain 'GlActionMatrixId'
     * @function CheckRepeat
     * @param {object} arr
     * @param {number} arg
     */
    var CheckRepeat = function (arr, arg) {
        var indexes = arr.map(function (item, index) {
            if (item.GlActionMatrixId === arg) {
                return index;
            }
        }, arg).filter(isFinite);
        return indexes;
    }

    /**
     * Concat two lists by checking null
     * @function ConcatTwoList
     * @param {object} list_1 - array list of any type
     * @param {object} list_2 - array list of ent type
     */
    var ConcatTwoList = function (list_1, list_2) {
        var list = [];

        if ((list_1 === null) && (list_2 !== null)) {
            list = list_2;
        } else if ((list_1 !== null) && (list_2 === null)) {
            list = list_1;
        } else if ((list_1 !== null) && (list_2 !== null)) {
            list = list_1.concat(list_2);
        } else {
            list = [];
        }

        return list;
    };

    /**
     * This function checks that is the selected currency is bdt or not. 
     * If it is then it returns true else false.
     * @function IsBDT
     * @param {any} currencies
     * @param {any} currencyId
     */
    var IsBDT = function (currencies, currencyId) {
        if (currencyId) {
            var index = currencies.map(function (e) { return e.Id; }).indexOf(currencyId);
            var currencyObj = currencies[index];

            if (currencyObj.CurrencyCode.toUpperCase() === 'BDT') {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    };

    /**
     * Return a list object by Id if found else return an empty object for safty.
     * Remember to check if the return type is empty or not using isEmpty function.
     * @function GetListObjectById
     * @param {any} list
     * @param {Number} Id
     */
    var GetListObjectById = function (list, Id) {
        if (typeof list !== 'undefined') {
            if (list.length !== 0) {
                return list.find(x => x.Id === Id);
            } else {
                return {};
            }
        } else {
            return {};
        }
    }

    /**
     * Return the present date in DDMMYY format
     */
    var GetPresentDateFormat = function () {
        var today = new Date();
        var day = today.getDate();
        if (day < 10) {
            day = '0' + day;
        }
        /*
         * Updated By :Zakaria 
         * Reason: If day or Month is >10 then it was a number but we need it to be a string
         */
        day = day.toString();

        var month = today.getMonth() + 1;
        if (month < 10) {
            month = '0' + month;
        }
        month = month.toString();

        var year = today.getFullYear().toString().slice(-2);
        /*
         * Updated By :Zakaria 
         * Reason: Previously It was YYMMDD
         */
        return presentDate = day + month + year;
    }


    /**
     * It generates the reference number and returns it but if 
     * the given parameter does not satisfy the criteria then it returns an empty string.
     * Remember to check if the returned string is empty or not.
     * @function GenerateReferenceNumber
     * @param {any} categoryList
     * @param {Number} categoryId
     * @param {any} subCategoryList
     * @param {Number} subCategoryId
     * @param {any} paymentStatusList
     * @param {Number} paymentId
     * @param {Number} prefix
     * @param {Number} branchCode
     */
    var GenerateReferenceNumber = function (categoryList, categoryId,
        subCategoryList, subCategoryId,
        paymentStatusList, paymentId,
        prefix, branchCode) {

        var categoryObj = GetListObjectById(categoryList, categoryId);
        var subCategoryObj = GetListObjectById(subCategoryList, subCategoryId);
        var paymentObj = GetListObjectById(paymentStatusList, paymentId);

        if (!isEmpty(categoryObj) && !isEmpty(subCategoryObj)
            && !isEmpty(paymentObj) && (prefix !== '') && (branchCode !== '')) {

            var categoryCode = categoryObj.ShortCode;
            var subCategoryCode = subCategoryObj.ShortCode;
            var paymentKey = paymentObj.StatusKey;

            var referenceNumber = branchCode + categoryCode + subCategoryCode + paymentKey.charAt(0) + GetPresentDateFormat() + prefix;
            return referenceNumber;
        } else {
            return '';
        }

    }

    /**
     * Converts the SQL date time to string format. (i.e. YYYY/MM/DD)
     * @function ConvertToDateTimeString
     * @param {Date} datetime
     */
    var ConvertToDateTimeString = function (datetime) {
        if (datetime) {
            var regexfilter = /-?\d+/;
            var dateArray = regexfilter.exec(datetime);
            if (dateArray == null)
                return "";
            var date = new Date(parseInt(dateArray[0]));
            var day = date.getDate();
            var month = date.getMonth() + 1;
            var year = date.getFullYear();
            if (day < 10) {
                day = '0' + day;
            }
            if (month < 10) {
                month = '0' + month;
            }
            //return year + "/" + month + "/" + day;
            return day + "-" + month + "-" + year;
        } else {
            return "";
        }
    };

    /**
     * Given ScreenFieldsMapDataModel array and FieldName it returns the index of the fieldName from the array
     * @function GetFieldIndexByFieldName
     * @param {object} fields
     * @param {object} fieldName
     */
    var GetFieldIndexByFieldName = function (fields, fieldName) {
        var res = fieldName.split(' ');
        var tempStr = '';

        for (var i = 0; i < res.length; i++) {
            tempStr += res[i];
        }
        tempStr = tempStr.toUpperCase();

        //var firstId = fields[0].Id;
        //var id = fields.find(x => x.Fieldkey.toUpperCase() === tempStr).Id;

        var indexArr = fields.map(function (item, index) {
            if (item.Fieldkey.toUpperCase() === tempStr) {
                return index;
            }
        }, tempStr).filter(isFinite);

        return indexArr[0];
    };

    /**
     * Creates array of 'FieldKeyValueDataModel' map objects using 'GlActionMatrixIdRecords', Currency and 
     * for single fields.
     * @function CreateKeyValueDataModels
     * @param {object} fields
     * @param {number} currencyId
     * @param {number} conversionFactor
     */
    var CreateKeyValueDataModels = function (fields, currencyId, conversionFactor) {
        var arr = [];
        var tempActionMatrixArr = [];
        var index = 0;

        for (var i = 0; i < fields.length; i++) {
            //Searching the field key in the ignore list
            index = ignoreList.indexOf(fields[i].Fieldkey);

            //If the key is not found then create the object using each matrix id.
            //Matrix ids are stored inside the vary same object that the field key is stored on.
            if (index === -1) {
                tempActionMatrixArr = [];
                tempActionMatrixArr = fields[i].GlActionMatrixIdRecords;

                for (var j = 0; j < tempActionMatrixArr.length; j++) {
                    var obj = {
                        GlActionMatrixId: tempActionMatrixArr[j],
                        Amount: Number(fields[i].Value),
                        CurrencyId: currencyId,
                        ConversionFactor: conversionFactor
                    };
                    arr.push(obj);
                }
            }
        }
        return arr;
    };

    /*
     * Added By: Zakaria 22.10.2018
     * Reason: Get Create FieldKeyValue DataModel By FieldIndex
     * 
     * */
    var CreateKeyValueDataModelsByFieldIndex = function (fields, fieldsIndex, currencyId, conversionFactor) {
        var arr = [];
        var tempActionMatrixArr = [];
        var index = 0;
        tempActionMatrixArr = fields[fieldsIndex].GlActionMatrixIdRecords;

        for (var j = 0; j < tempActionMatrixArr.length; j++) {
            var obj = {
                GlActionMatrixId: tempActionMatrixArr[j],
                Amount: Number(fields[fieldsIndex].Value),
                CurrencyId: currencyId,
                ConversionFactor: conversionFactor
            };
            arr.push(obj);
        }

        return arr;
    };
    /**
     * Generates the given fields indices according to each field's FieldKey
     * @function GenerateAllFieldIndicesByFieldKey
     * @param {object} fields
     */
    var GenerateAllFieldIndicesByFieldKey = function (fields) {
        var obj = {};
        if (typeof fields !== 'undefined') {
            for (var i = 0; i < fields.length; i++) {
                obj[fields[i].Fieldkey + 'Index'] = i;
            }
        }
        //console.log('----------------Type of OBJ------------------');
        //console.log(typeof obj);
        //console.log(obj);
        //console.log('----------------------------------');

        //Testing section
        //var testObj = {};
        //if (typeof fields != 'undefined') {
        //    for (var i = 0; i < fields.length; i++) {
        //        testObj[fields[i].Fieldkey] = fields[i];
        //    }
        //}
        //console.log('----------------Type of Test OBJ------------------');
        //console.log(typeof testObj);
        //console.log(testObj);
        //console.log('----------------------------------');
        //Testing section

        return obj;
    };

    /**
     * Initiate each Value property of field object in fields to empty string according to the indices
     * @function InitiateFields
     * @param {object} fields
     * @param {object} indices
     */
    var InitiateFields = function (fields, indices) {
        if ((typeof fields !== 'undefined') && (typeof indices !== 'undefined')) {
            for (var key in indices) {
                if (indices.hasOwnProperty(key)) {
                    fields[indices[key]].Value = '';
                }
            }
        } else {
            console.log('Given fields or indices or both are undefined');
        }
    };

    /**
     * Check the given input is a number. If not return zero else convert it to number and return it.
     * Because the number can be in a text format.
     * @param {any} number
     */
    var CheckAndGetFieldNumber = function (number) {
        return (!isNaN(Number(number))) ? Number(number) : 0;
    }

    var SortListInAscendingOrder = function (list, property) {
        if (typeof list != 'undefined' && typeof list != 'null') {
            if (Array.isArray(list)) {
                list.sort(function (a, b) {
                    return a[property] - b[property];
                });
            }
        }
        return list;
    }

    var Convert_DD_MM_YYYY_ToJsDate = function (dateString) {
        var dateParts = dateString.split("-");
        console.log(dateParts);
        var dateObject = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]); // month is 0-based
        console.log(dateObject);
        return dateObject;
    }

    var CommaSeperateNumber = function (data) {
        return (!isNaN(Number(data))) ? $filter('number')(Number(data)) : data;
    }

    return {
        ConvertToDateTimeString: ConvertToDateTimeString,
        GetFieldIndexByFieldName: GetFieldIndexByFieldName,
        CreateKeyValueDataModels: CreateKeyValueDataModels,
        GenerateAllFieldIndicesByFieldKey: GenerateAllFieldIndicesByFieldKey,
        DateFormatOfJSDate: DateFormatOfJSDate,
        isEmpty: isEmpty,
        WordWithOutSpace: WordWithOutSpace,
        ShortNameGenerator: ShortNameGenerator,
        ConcatTwoList: ConcatTwoList,
        IsBDT: IsBDT,
        GenerateReferenceNumber: GenerateReferenceNumber,
        InitiateFields: InitiateFields,
        CheckAndGetFieldNumber: CheckAndGetFieldNumber,
        GetPresentDateFormat: GetPresentDateFormat,
        DateFormatOfBD: DateFormatOfBD,
        SortListInAscendingOrder: SortListInAscendingOrder,
        Convert_DD_MM_YYYY_ToJsDate: Convert_DD_MM_YYYY_ToJsDate,
        CommaSeperateNumber: CommaSeperateNumber,
        CreateKeyValueDataModelsByFieldIndex: CreateKeyValueDataModelsByFieldIndex
    }
});