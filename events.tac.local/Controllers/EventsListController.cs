using events.tac.local.Business;
using Sitecore.Pipelines;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class EventsListController : Controller
    {
        private readonly EventsProvider _provider;

        public EventsListController() : this(new EventsProvider()) { }
        public EventsListController(EventsProvider provider)
        {
            _provider = provider;
        }
        public ActionResult Index(int page = 1)
        {
            //RunCustomPipeline();
            return View(_provider.GetEventsList(page - 1));
        }

        private void RunCustomPipeline()
        {
            CustomPipelineArgs pipelineArgs = new CustomPipelineArgs(Sitecore.Context.Item);
            CorePipeline.Run("CustomPipeline", pipelineArgs);
            if (!pipelineArgs.Valid && !string.IsNullOrEmpty(pipelineArgs.Message))
            {
                Sitecore.Diagnostics.Log.Error("The custom pipeline failed!", this);
                // Execute code here to deal with failed validation
            }
        }
    }
}