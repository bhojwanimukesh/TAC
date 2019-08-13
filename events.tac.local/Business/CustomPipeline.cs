using System;
using Sitecore.Data.Items;
using Sitecore.Pipelines;

namespace events.tac.local.Business
{
    public class CustomPipelineArgs : PipelineArgs
    {
        public bool Valid { get; set; }

        public new string Message { get; set; }

        public Item Item { get; set; }

        public CustomPipelineArgs(Item item)
        {
            Item = item;
        }
    }

    public interface ICustomPipelineProcessor
    {
        void Process(CustomPipelineArgs args);
    }
    public class DateSet : ICustomPipelineProcessor
    {
        public void Process(CustomPipelineArgs args)
        {
            if (args.Item["date"] == string.Empty)
            {
                args.Valid = false;
                args.Message = "Date has not been set";
            }
        }
    }

    public class TextSet : ICustomPipelineProcessor
    {
        public void Process(CustomPipelineArgs args)
        {
            if (args.Item["text"] == string.Empty)
            {
                args.Valid = false;
                args.Message = "Text has not been set";
            }
        }
    }
}