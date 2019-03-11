using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;

namespace EnterpriseSolution.Infrastructure.Helpers
{
    public static class Extension
    {
        public static string[] ExceptColumnsForCsvHeader = { "Id", "ErrorMessage" };
        public static string[] ExceptColumnsForCsvExport = { "Id" };

        private static string GetFileUploadCsv<T>(this List<T> list)
        {
            var sb = new StringBuilder();

            //Get the properties for type T for the headers
            PropertyInfo[] propInfos = typeof(T).GetProperties();
            for (int i = 0; i <= propInfos.Length - 1; i++)
            {
                string colName = propInfos[i].Name;

                if (!Array.Exists(ExceptColumnsForCsvHeader, element => element == colName))
                {
                    sb.Append(GetHeaderText(propInfos[i].Name));
                    sb.Append(",");
                }
            }

            var temp = sb.ToString().Substring(0, sb.ToString().Length - 1);
            return temp;
        }

        private static string GetFileExportCsv<T>(this List<T> list)//
        {
            var sb = new StringBuilder();

            //Get the properties for type T for the headers
            PropertyInfo[] propInfos = typeof(T).GetProperties();
            for (int i = 0; i <= propInfos.Length - 1; i++)
            {
                string colName = propInfos[i].Name;

                if (!Array.Exists(ExceptColumnsForCsvExport, element => element == colName))
                {
                    sb.Append(GetHeaderText(propInfos[i].Name));
                    sb.Append(",");
                }
            }

            var temp = sb.ToString().Substring(0, sb.ToString().Length - 1);
            return temp;
        }

        private static string GetDataToCsv<T>(this List<T> list)//
        {
            string finalResult = "";
            string columnValue = "";
            try
            {
                for (int i = 1; i < list.Count; i++)
                {

                    var sb = new StringBuilder();
                    PropertyInfo[] propInfos = typeof(T).GetProperties();

                    for (int j = 0; j < propInfos.Length; j++)
                    {
                        PropertyInfo propInfo = propInfos[j];
                        if (propInfo.Name != "Id") //Submitted by: Abbir. Date: 07/10/2018.
                        {
                            if (propInfo.GetValue(list[i]) == null)
                            {
                                columnValue = "";
                            }
                            else
                            {
                                columnValue = propInfo.GetValue(list[i]).ToString();
                            }
                            sb.Append(columnValue);
                            sb.Append(",");
                        }
                    }
                    var temp = sb.ToString().Substring(0, sb.ToString().Length - 1);
                    finalResult += temp + new StringBuilder().AppendLine();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return finalResult;
        }

        public static void GetSampleCsv<T>(this List<T> list, string fileName)
        {
            string csv = GetFileUploadCsv(list) + new StringBuilder().AppendLine();
            CSVHelper.ExportCsv(csv, fileName);
        }

        public static void GetExportCsv<T>(this List<T> list, string fileName)//
        {
            string csv = GetFileExportCsv(list) + new StringBuilder().AppendLine();
            csv += GetDataToCsv(list) + new StringBuilder().AppendLine();
            CSVHelper.ExportCsv(csv, fileName);
        }

        /*
         * Work of this extension is to copy one object property to another of same class
         * **/
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    { // check if the property can be set or no.
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }

            }

        }

        #region Get Header Text
        public static string GetHeaderText(string pInputHeader)
        {
            string headerText = string.Empty;
            switch (pInputHeader)
            {
                case "PartNumber":
                    headerText = "Part Number";
                    break;
                case "ProductGroup":
                    headerText = "Product Group";
                    break;
                case "StockTakeCount":
                    headerText = "Count";
                    break;
                case "ExpectedQuantity":
                    headerText = "Expected Qty";
                    break;
                case "BinCount":
                    headerText = "Bin Count";
                    break;
                case "LotOrSerial":
                    headerText = "Lot/Serial";
                    break;
                case "BarcodeNumber":
                    headerText = "Barcode Number";
                    break;
                case "BinType":
                    headerText = "Bin Type";
                    break;
                case "BasePrice":
                    headerText = "Base Price";
                    break;
                default:
                    headerText = pInputHeader;
                    break;
            }
            return headerText;
        }
        #endregion
    }
}