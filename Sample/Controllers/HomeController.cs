using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using LitmosRESTClientSample.Models;
using Litmos.API;
using Litmos.API.Resources;

namespace LitmosRESTClientSample.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index(ApiTestRequest request)
        {
            // Defaults
            request.BaseUri = ConfigurationManager.AppSettings["LitmosAPIBaseUri"].ToString();
            request.Source = "TESTHARNESS";

            return View(request);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProcessRequest(ApiTestRequest request)
        {
            // Base uri
            string baseUri = ConfigurationManager.AppSettings["LitmosAPIBaseUri"].ToString();

            RESTResponse rs = new RESTResponse();
            RESTClient client = new RESTClient(baseUri, request.ApiKey, request.Source);

            switch (request.RequestType)
            {
                case "USERS": // Get a List of Users
                    // Get
                    rs = client.Get<UserList>(RequestUri.USERS);

                    // Format Response
                    request.ResponseBody = GetUserList(rs.Body);
                    break;

                case "USER": // Get a User
                    // Get
                    rs = client.Get<UserProfile>(string.Format(RequestUri.USER, Request.Form["UserId"]));

                    // Format Response
                    request.ResponseBody = GetUser(rs.Body);
                    break;

                case "CREATE_USER": // Create a User

                    UserProfile createUser = new UserProfile(Request.Form["UserName"], Request.Form["FirstName"], Request.Form["LastName"]);

                    // Create
                    rs = client.Post<UserProfile>(RequestUri.USERS, createUser);

                    // Format Response
                    request.ResponseBody = GetUser(rs.Body);
                    break;

                case "UPDATE_USER": // Update a User

                    string userUri = string.Format(RequestUri.USER, Request.Form["UserId"]);
                    UserProfile updateUser;

                    // Get User
                    rs = client.Get<UserProfile>(userUri);

                    // Update User Properties
                    if (rs != null)
                    {
                        updateUser = (UserProfile)rs.Body;

                        updateUser.Id = Request.Form["UserId"];
                        updateUser.FirstName = Request.Form["FirstName"];
                        updateUser.LastName = Request.Form["LastName"];

                        // Update 
                        rs = client.Put(userUri, updateUser);
                    }
                    break;

                case "TEAMS": // Get a List of Teams
                    // Get
                    rs = client.Get<TeamList>(RequestUri.TEAMS);

                    // Format Response
                    request.ResponseBody = GetTeamList(rs.Body);
                    break;
            }


            if (rs != null)
            {
                request.ResponseStatusCode = rs.StatusCode;
                request.ResponseDescription = rs.StatusDescription;
            }

            return View("Index", request);
        }

        /// <summary>
        /// Convert message body to list of users
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public string GetUserList(object body)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var u in (UserList)body)
            {
                sb.AppendFormat("Id: {0} - Name: {1} {2} - UserName: {3}<br/>", u.Id, u.FirstName, u.LastName, u.UserName);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convert body to list of teams
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public string GetTeamList(object body)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var t in (TeamList)body)
            {
                sb.AppendFormat("Id: {0} - Name: {1} <br/>", t.Id, t.Name);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convert body to user string
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public string GetUser(object body)
        {
            UserProfile u = (UserProfile)body;
            
            return string.Format("Id: {0}<br/>Name: {1}<br/>UserName: {2}<br/>LoginUrl: {3}", 
                u.Id,
                u.FullName, 
                u.UserName, 
                u.LoginKey);
        }


    }
}
