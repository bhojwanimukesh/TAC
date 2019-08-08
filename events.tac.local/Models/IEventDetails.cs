using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;

namespace events.tac.local.Models
{
    [SitecoreType]
    public interface IEventDetails
    {
        [SitecoreField]
        IEnumerable<IComment> Comments { get; set; }
    }
}
