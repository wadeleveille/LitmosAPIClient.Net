using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Litmos.API.Resources
{
    [CollectionDataContract(Name = "Users", Namespace = "")]
    public class UserList : ListResource<UserProfilePartial> { }
}
