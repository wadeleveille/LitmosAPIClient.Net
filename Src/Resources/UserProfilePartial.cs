using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Litmos.API.Resources
{
    [DataContract(Name = "User", Namespace = "")]
    public class UserProfilePartial
    {
        [DataMember(Name = "Id", Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "UserName", Order = 1)]
        public string UserName { get; set; }

        [DataMember(Name = "FirstName", Order = 2)]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName", Order = 3)]
        public string LastName { get; set; }
    }
}
