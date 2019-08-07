using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events.tac.local.Models
{
    [SitecoreType]
    public interface IComment
    {
        [SitecoreField]
        string Name { get; set; }

        [SitecoreField]
        DateTime Date { get; set; }

        [SitecoreField]
        string Description { get; set; }
    }
}
