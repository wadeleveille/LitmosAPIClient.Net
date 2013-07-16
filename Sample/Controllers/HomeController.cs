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
            RequestFactory factory = new RequestFactory(baseUri, request.ApiKey, request.Source);

            switch (request.RequestType)
            {
                case "USERS": // Get a List of Users
                    // Get
                    var listUsers = factory.ListUsers(Request.Form["Filter"]);

                    // Format Response
                    request.ResponseBody = GetUserList(listUsers);
                    break;

                case "USER": // Get a User
                    // Get
                    var singleUser = factory.GetUser(Request.Form["UserId"]);

                    // Format Response
                    request.ResponseBody = GetUser(singleUser);
                    break;

                case "CREATE_USER": // Create a User

                    UserProfile createUser = new UserProfile(Request.Form["UserName"], Request.Form["FirstName"], Request.Form["LastName"]);

                    // Create
                    var newUser = factory.CreateUser(createUser);

                    // Format Response
                    request.ResponseBody = GetUser(newUser);
                    break;

                case "UPDATE_USER": // Update a User

                    // Get User
                    var updateUser = factory.GetUser(Request.Form["UserId"]);

                    // Update User Properties
                    if (updateUser != null)
                    {
                        updateUser.Id = Request.Form["UserId"];
                        updateUser.FirstName = Request.Form["FirstName"];
                        updateUser.LastName = Request.Form["LastName"];

                        // Update 
                        updateUser = factory.UpdateUser(Request.Form["UserId"], updateUser);
                    }
                    break;

                case "TEAMS": // Get a List of Teams
                    request.ResponseBody = GetTeamList(factory.ListTeams(Request.Form["Filter"]));
                    break;

                case "SUBTEAMS": // Get a List of sub Teams
                    // Get
                    var subTeams = factory.ListTeams(Request.Form["TeamId"], Request.Form["Filter"]);

                    // Format Response
                    request.ResponseBody = GetTeamList(subTeams);
                    break;

                case "ADD_TEAMUSERS": // Get a List of Teams
                    
                    var users = new UserList();

                    users.Add(new UserProfilePartial(){
                        Id = Request.Form["UserId"]
                    });

                    var userTeamSuccess = factory.AddUsersToTeam(Request.Form["TeamId"], users);

                    // Format Response
                    request.ResponseBody = userTeamSuccess ? "Users added to team!" : "Users to team FAILED";
                    break;

                case "TEAMUSERS": // Get a List of Users
                    // Get
                    var listTeamUsers = factory.ListTeamUsers(Request.Form["TeamId"]);

                    // Format Response
                    request.ResponseBody = GetUserList(listTeamUsers);
                    break;

                case "PROMOTE_LEADER":
                    var promoteLeader = factory.PromoteTeamLeader(Request.Form["TeamId"], Request.Form["UserId"]);

                    // Format Response
                    request.ResponseBody = promoteLeader ? "Users promoted to team leader!" : "Users to team FAILED";
                    break;

                case "DEMOTE_LEADER":
                    var demoteTeamLeader = factory.DemoteTeamLeader(Request.Form["TeamId"], Request.Form["UserId"]);

                    // Format Response
                    request.ResponseBody = demoteTeamLeader ? "Users demoted from team leader!" : "Users to team FAILED";
                    break;

                case "COURSES": // Get a List of Courses
                    // Get
                    var listCourses = factory.ListCourses();

                    // Format Response
                    request.ResponseBody = GetCourseList(listCourses);
                    break;

                case "USER_COURSES": // Get a List of Courses
                    // Get
                    var listUserCourses = factory.ListUserCourses(Request.Form["UserId"]);

                    // Format Response
                    request.ResponseBody = GetUserCourseList(listUserCourses);
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

        /// <summary>
        /// Convert message body to list of courses
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public string GetCourseList(object body)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var u in (CourseList)body)
            {
                sb.AppendFormat("Id: {0} - Name: {1} - Description: {2}<br/>", u.Id, u.Name, u.Description);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convert message body to list of courses assigned to user
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public string GetUserCourseList(object body)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var u in (UserCourseList)body)
            {
                sb.AppendFormat("Id: {0} - Name: {1} - Complete: {2} - Date Complete: {3}<br/>", u.Id, u.Name, u.Complete, u.DateCompleted);
            }
            return sb.ToString();
        }
    }
}
