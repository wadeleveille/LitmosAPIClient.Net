using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Litmos.API.Resources
{
    [DataContract(Name = "Course", Namespace = "")]
    public class UserCourse
    {
        #region Constructors

        public UserCourse()
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

        [DataMember(Name = "Complete", Order = 4)]
        public bool Complete { get; set; }

        [DataMember(Name = "PercentageComplete", Order = 5)]
        public double PercentageComplete { get; set; }

        [DataMember(Name = "DateCompleted", Order = 6)]
        public DateTime? DateCompleted { get; set; }

        [DataMember(Name = "UpToDate", Order = 7)]
        public bool UpToDate { get; set; }

        #endregion
    }
}
