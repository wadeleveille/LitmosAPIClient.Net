using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Litmos.API.Resources
{
    [CollectionDataContract(Name = "Teams", Namespace = "")]
    public class TeamList : ListResource<TeamPartial> { }
}
