using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Litmos.API.Resources
{
    [DataContract(Name = "User", Namespace="")]
    public class UserProfile
    {
        #region Constructors

        public UserProfile()
        {
        }

        /// <summary>
        /// New user with minimum fields required. 
        /// </summary>
        public UserProfile(string userName, string firstName, string lastName)
        {
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;

            // Check if userName is an email address. If not then set flag
            Regex r = new Regex(@"^\s*([a-zA-Z0-9_\-\.\+']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)\s*$");
            this.IsCustomUsername = !r.IsMatch(this.UserName);
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

        [DataMember(Name = "IsCustomUsername", Order = 15)]
        public bool IsCustomUsername { get; set; }

        [DataMember(Name = "Password", Order = 16)]
        public string Password { get; set; }

        [DataMember(Name = "SkipFirstLogin", Order = 17)]
        public bool SkipFirstLogin { get; set; }

        [DataMember(Name = "TimeZone", Order = 18)]
        public string TimeZone { get; set; }

        [DataMember(Name = "SalesforceId", Order = 19)]
        public string SalesforceId { get; set; }

        [DataMember(Name = "OriginalId", Order = 20)]
        public int OriginalId { get; set; }

        [DataMember(Name = "Street1", Order = 21)]
        public string Street1 { get; set; }

        [DataMember(Name = "Street2", Order = 22)]
        public string Street2 { get; set; }

        [DataMember(Name = "City", Order = 23)]
        public string City { get; set; }

        [DataMember(Name = "State", Order = 24)]
        public string State { get; set; }

        [DataMember(Name = "PostalCode", Order = 25)]
        public string PostalCode { get; set; }

        [DataMember(Name = "Country", Order = 26)]
        public string Country { get; set; }

        [DataMember(Name = "CompanyName", Order = 27)]
        public string CompanyName { get; set; }

        [DataMember(Name = "JobTitle", Order = 28)]
        public string JobTitle { get; set; }

        [DataMember(Name = "CustomField1", Order = 29)]
        public string CustomField1 { get; set; }

        [DataMember(Name = "CustomField2", Order = 30)]
        public string CustomField2 { get; set; }

        [DataMember(Name = "CustomField3", Order = 31)]
        public string CustomField3 { get; set; }

        [DataMember(Name = "Culture", Order = 32)]
        public string Culture { get; set; }

        #endregion
    }
}
