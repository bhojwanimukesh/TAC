using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events.tac.local.Models
{
    [SitecoreType]
    public interface IEventDetails
    {
        [SitecoreField]
        IEnumerable<IComment> Comments { get; set; }
    }
}
