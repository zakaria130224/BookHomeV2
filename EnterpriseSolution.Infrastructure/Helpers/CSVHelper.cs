using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace EnterpriseSolution.Infrastructure.Helpers
{
    public class CSVHelper
    {
        /// <summary>
        /// Exports a CSV by writing to the current HttpResponse
        /// </summary>
        /// <param name="csv">The CSV data as a string</param>
        /// <param name="filename">The filename for the exported file</param>
        public static void ExportCsv(string csv, string fileName)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.csv", fileName));//string.Format("attachment; filename={0}.csv", filename)
                HttpContext.Current.Response.ContentType = "text/csv";
                HttpContext.Current.Response.AddHeader("Pragma", "public");
                HttpContext.Current.Response.Output.Write(csv);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception e)
            {
                string error = e.GetBaseException().Message;
            }
        }

        public static HttpResponseMessage ExportAsCsv(string csv, string fileName)
        {

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(csv);
            writer.Flush();
            stream.Position = 0;

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };

            return result;
        }
    }
}