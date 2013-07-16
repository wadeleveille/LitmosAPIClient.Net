<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LitmosRESTClientSample.Models.ApiTestRequest>" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

<table style="width:100%;">
    <tr>
        <td valign="top" style="width:40%">
        <h2>Request</h2>
       <%using(Html.BeginForm("ProcessRequest","Home")){ %> 
<table>
    <tr>
        <th>ApiKey:</th>
        <td><% =Html.TextBox("ApiKey",Model.ApiKey) %></td>
    </tr>
    <tr>
        <th>Source:</th>
        <td><% =Html.TextBox("Source",Model.Source) %></td>
    </tr>
    <tr>
        <td></td>
        <td>&nbsp;</td>
    </tr>    
    <tr>
        <th>Type:</th>
        <td>
            <select id="RequestType" name="RequestType">
                <option value="USERS">Get Users</option>
                <option value="USER">Get User</option>             
                <option value="CREATE_USER">Create User</option>                   
                <option value="UPDATE_USER">Update User</option>                    
                <option value="TEAMS">Get Teams</option>  
                <option value="SUBTEAMS">Get Sub Teams</option>  
                <option value="TEAMUSERS">Get Team Users</option>  
                <option value="ADD_TEAMUSERS">Add User to Team</option> 
                <option value="PROMOTE_LEADER">Promote Teamleader</option>
                <option value="DEMOTE_LEADER">Demote Teamleader</option>
                <option value="COURSES">Get Courses</option>                                                    
                <option value="USER_COURSES">Get Courses Assigned to User</option>                                                    
            </select>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>&nbsp;</td>
    </tr>    
    <tr>
        <td></td>
        <td>For get and update</td>
    </tr>    
    <tr>
        <th>Search Filter:</th>
        <td>
            <% =Html.TextBox("Filter") %>
        </td>
    </tr>
    <tr>
        <th>UserId:</th>
        <td>
            <% =Html.TextBox("UserId") %>
        </td>
    </tr>
    <tr>
        <th>TeamId:</th>
        <td>
            <% =Html.TextBox("TeamId") %>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>&nbsp;</td>
    </tr>         
    <tr>
        <td></td>
        <td>For update and create</td>
    </tr>      
    <tr>
        <th>First Name:</th>
        <td>
            <% =Html.TextBox("FirstName") %>
        </td>
    </tr>
    <tr>
        <th>Last Name:</th>
        <td>
            <% =Html.TextBox("LastName") %>
        </td>
    </tr>
    <tr>
        <th>User Name:</th>
        <td>
            <% =Html.TextBox("UserName") %>
        </td>
    </tr>                 
    <tr>
        <td></td>
        <td>&nbsp;</td>
    </tr>  
    <tr>
        <td></td>
        <td><input type="submit" value="Process Request" /></td>
    </tr>             
</table> 
<%} %>     
        </td>
        <td valign="top">
        <h2>Response</h2>
        <h3><% =Html.Encode(Model.ResponseStatusCode) %> - <% =Html.Encode(Model.ResponseDescription) %></h3>
        <div id="responseBody" style="border:solid 1px #ccc;"><% = Model.ResponseBody %></div>
        </td>
    </tr>
</table>
<script type="text/javascript">
    
</script>
</asp:Content>
