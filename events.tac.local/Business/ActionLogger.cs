using Sitecore.Data.Items;
using Sitecore.Tasks;

namespace events.tac.local.Business
{
    public class ActionLogger
    {
        public void Execute(Item[] items, CommandItem command, ScheduleItem schedule)
        {
            Sitecore.Diagnostics.Log.Info("Action Logger runs OK!", this);
        }
    }
}