using Sitecore.Configuration;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Net;
using System.Web;

namespace events.tac.local.Business.Request
{
    public class Set404StatusCode : HttpRequestBase
    {
        protected override void Execute(HttpRequestArgs args)
        {
            // retain 500 response if previously set
            if (HttpContext.Current.Response.StatusCode >= 500 || args.Context.Request.RawUrl == "/")
                return;

            // return if request does not end with value set in ItemNotFoundUrl, i.e. successful page
            if (!args.Context.Request.Url.LocalPath.EndsWith(Settings.ItemNotFoundUrl, StringComparison.InvariantCultureIgnoreCase))
                return;

            LogWarning("Page Not Found: " + args.Context.Request.RawUrl + ", current status: " + HttpContext.Current.Response.StatusCode);
            HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.NotFound;
            HttpContext.Current.Response.StatusDescription = "Page not found";
        }

        private void LogWarning(string message, params string[] args)
        {
            Sitecore.Diagnostics.Log.Warn(string.Format(message, args), this);
        }
    }

}