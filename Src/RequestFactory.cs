using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Litmos.API.Resources;

namespace Litmos.API
{
    public class RequestFactory : RESTClient
    {
        /// <summary>
        /// Litmos API Endpoints
        /// </summary>
        private static class Endpoints
        {
            // Courses
            public const string COURSES = "/courses";

            // Users
            public const string USERS = "/users?search={0}";
            public const string USER = "/users/{0}";

            // User Courses
            public const string USER_COURSES = "/users/{0}/courses";

            // Teams
            public const string TEAMS = "/teams?search={0}";
            public const string TEAM = "/teams/{0}";
            public const string TEAM_USERS = "/teams/{0}/users";
            public const string TEAM_LEADER = "/teams/{0}/leaders/{1}";
            public const string TEAM_LEADERS = "/teams/{0}/leaders";
            public const string SUB_TEAMS = "/teams/{0}/teams?search={1}";
        }

        public RequestFactory(string baseUri, string apiKey, string source)
            : base(baseUri, apiKey, source)
        {}

        /// <summary>
        /// Get a list of users
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public UserList ListUsers(string filter)
        {            
            // Create
            var rs = this.Get<UserList>(string.Format(Endpoints.USERS, filter));

            // Format Response
            return (UserList)rs.Body;
        }

        /// <summary>
        /// Get a user
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public UserProfile GetUser(string id)
        {
            // Create
            var rs = this.Get<UserProfile>(string.Format(Endpoints.USER, id));

            // Format Response
            return (UserProfile)rs.Body;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserProfile CreateUser(UserProfile user)
        {
            // Create
            var rs = this.Post<UserProfile>(Endpoints.USERS, user);

            // Format Response
            return (UserProfile)rs.Body;
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserProfile UpdateUser(string id, UserProfile user)
        {
            // Update
            var rs = this.Put(string.Format(Endpoints.USER, id), user);

            // Format Response
            return (UserProfile)rs.Body;
        }

        /// <summary>
        /// Add users to a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool AddUsersToTeam(string teamId, UserList users)
        {
            // Add users
            var teamUsers = this.Post(string.Format(Endpoints.TEAM_USERS, teamId), users);

            return (teamUsers.StatusCode == "201");
        }

        /// <summary>
        /// Show users in a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public UserList ListTeamUsers(string teamId)
        {
            // Create
            var rs = this.Get<UserList>(string.Format(Endpoints.TEAM_USERS, teamId));

            // Format Response
            return (UserList)rs.Body;
        }

        /// <summary>
        /// Get teams
        /// </summary>
        /// <returns></returns>
        public TeamList ListTeams(string filter)
        {
            // Create
            var rs = this.Get<TeamList>(string.Format(Endpoints.TEAMS, filter));

            // Format Response
            return (TeamList)rs.Body;
        }

        /// <summary>
        /// Get sub teams
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public TeamList ListTeams(string teamId, string filter)
        {
            // Create
            var rs = this.Get<TeamList>(string.Format(Endpoints.SUB_TEAMS, teamId, filter));

            // Format Response
            return (TeamList)rs.Body;
        }

        public bool PromoteTeamLeader(string teamId, string userId)
        {
            // Update
            var promote = this.Put(string.Format(Endpoints.TEAM_LEADER, teamId, userId), null);

            // Format Response
            return (promote.StatusCode == "200");
        }

        public bool DemoteTeamLeader(string teamId, string userId)
        {
            // Update
            var promote = this.Delete(string.Format(Endpoints.TEAM_LEADER, teamId, userId));

            // Format Response
            return (promote.StatusCode == "200");
        }

        /// <summary>
        /// Get a list of courses
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public CourseList ListCourses()
        {
            // Create
            var rs = this.Get<CourseList>(Endpoints.COURSES);

            // Format Response
            return (CourseList)rs.Body;
        }

        /// <summary>
        /// Get a list of courses assigned to user
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public UserCourseList ListUserCourses(string userId)
        {
            // Create
            var rs = this.Get<UserCourseList>(string.Format(Endpoints.USER_COURSES, userId));

            // Format Response
            return (UserCourseList)rs.Body;
        }
    }
}
