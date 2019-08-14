using Sitecore;
using Sitecore.Abstractions;
using Sitecore.Configuration;
using Sitecore.Web;
using System.Web;

namespace events.tac.local.Business.Request
{
    public class CustomExecuteRequest : global::Sitecore.Pipelines.HttpRequest.ExecuteRequest
    {
        private readonly BaseLinkManager _baseLinkManager;
        public CustomExecuteRequest(BaseSiteManager baseSiteManager, BaseItemManager baseItemManager, BaseLinkManager baseLinkManager) : base(baseSiteManager, baseItemManager)
        {
            _baseLinkManager = baseLinkManager;
        }

        protected override void PerformRedirect(string url)
        {
            if (Context.Site == null || Context.Database == null || Context.Database.Name == "core")
            {
                LogInfo("Attempting to redirect url {0}, but no Context Site or DB defined (or core db redirect attempted)", url);
                return;
            }

            // need to retrieve not found item to account for sites utilizing virtualFolder attribute
            var notFoundItem = Context.Database.GetItem(Context.Site.StartPath + Settings.ItemNotFoundUrl);

            if (notFoundItem == null)
            {
                LogInfo("No 404 item found on site: {0}", Context.Site.Name);
                return;
            }

            var notFoundUrl = _baseLinkManager.GetItemUrl(notFoundItem);

            if (string.IsNullOrWhiteSpace(notFoundUrl))
            {
                LogInfo("Found 404 item for site, but no URL returned: {0}", Context.Site.Name);
                return;
            }

            Sitecore.Diagnostics.Log.Info("Redirecting to {0}", notFoundUrl);
            if (Settings.RequestErrors.UseServerSideRedirect)
            {
                HttpContext.Current.Server.TransferRequest(notFoundUrl);
            }
            else
                WebUtil.Redirect(notFoundUrl, false);
        }

        private void LogInfo(string message, params string[] args)
        {
            Sitecore.Diagnostics.Log.Info(string.Format(message, args), this);
        }
    }

}