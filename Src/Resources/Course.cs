using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Litmos.API.Resources
{
    [DataContract(Name = "Course", Namespace = "")]
    public class Course
    {
        #region Constructors

        public Course()
        {
        }

        #endregion

        #region Public Properties

        [DataMember(Name = "Id", Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "Code", Order = 1)]
        public string Code { get; set; }

        [DataMember(Name = "Name", Order = 2)]
        public string Name { get; set; }

        [DataMember(Name = "Active", Order = 3)]
        public bool Active { get; set; }

        [DataMember(Name = "ForSale", Order = 4)]
        public bool ForSale { get; set; }

        [DataMember(Name = "OriginalId", Order = 5)]
        public int OriginalId { get; set; }

        [DataMember(Name = "Description", Order = 6)]
        public string Description { get; set; }

        [DataMember(Name = "EcommerceShortDescription", Order = 7)]
        public string EcommerceShortDescription { get; set; }

        [DataMember(Name = "EcommerceLongDescription", Order = 8)]
        public string EcommerceLongDescription { get; set; }

        #endregion
    }
}
