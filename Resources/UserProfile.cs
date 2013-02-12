using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Litmos.API.Resources
{
    [DataContract(Name = "User", Namespace="")]
    public class UserProfile
    {
        #region Constructors

        public UserProfile()
        {
        }

        #endregion

        #region Public Properties

        [DataMember(Name = "Id", Order = 0)]
        public string Id { get; set; }


        [DataMember(Name = "UserName", Order = 1)]
        public string UserName { get; set; }

        [DataMember(Name = "FirstName", Order = 2)]
        public string FirstName  { get; set; }

        [DataMember(Name = "LastName", Order = 3)]
        public string LastName { get; set; }

        [DataMember(Name = "FullName", Order = 4)]
        public string FullName  { get; set; }

        [DataMember(Name = "Email", Order = 5)]
        public string Email { get; set; }

        [DataMember(Name = "AccessLevel", Order = 7)]
        public string AccessLevel { get; set; }

        [DataMember(Name = "DisableMessages", Order = 8)]
        public bool DisableMessages { get; set; }

        [DataMember(Name = "Active", Order = 9)]
        public bool Active { get; set; }

        [DataMember(Name = "Skype", Order = 10)]
        public string Skype { get; set; }

        [DataMember(Name = "PhoneWork", Order = 11)]
        public string PhoneWork { get; set; }

        [DataMember(Name = "PhoneMobile", Order = 12)]
        public string PhoneMobile { get; set; }

        [DataMember(Name = "LastLogin", Order = 13)]
        public string LastLogin  { get; set; }

        [DataMember(Name = "LoginKey", Order = 14)]
        public string LoginKey  { get; set; }

        #endregion
    }
}
