using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Litmos.API.Resources
{
    [DataContract(Name = "Team", Namespace="")]
    public class Team
    {
        #region Constructors

        public Team()
        {
        }

        #endregion

        #region Public Properties

        [DataMember(Name = "Id", Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "Description", Order = 2)]
        public string Description { get; set; }

        #endregion
    }
}
