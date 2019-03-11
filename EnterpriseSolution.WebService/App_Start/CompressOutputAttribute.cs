using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace EnterpriseSolution.WebService
{
    public class CompressOutputAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var result = filterContext.Result;
            if (!(result is ViewResult))
                return;

            HttpRequestBase request = filterContext.HttpContext.Request;
            string acceptEncoding = request.Headers["Accept-Encoding"];
            if (string.IsNullOrEmpty(acceptEncoding))
                return;

            acceptEncoding = acceptEncoding.ToUpperInvariant();

            HttpResponseBase response = filterContext.HttpContext.Response;
            if (acceptEncoding.Contains("GZIP"))
            {
                // we want to use gzip 1st
                response.AppendHeader("Content-encoding", "gzip");
                //Add DeflateStream to the pipeline in order to compress response on the fly 
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
            }
            else if (acceptEncoding.Contains("DEFLATE"))
            {
                //If client accepts deflate, we'll always return compressed content 
                response.AppendHeader("Content-encoding", "deflate");
                //Add DeflateStream to the pipeline in order to compress response on the fly 
                response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
            }
        }
    }
}