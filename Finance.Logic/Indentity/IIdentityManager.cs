using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Finance.Logic.Indentity
{
    public interface IIdentityManager
    {
        UserManager<PartyIdentityUser> UserManager { get; set; }

        RoleManager<IdentityRole> RoleManager { get; set; }

        bool CreateUser(PartyIdentityUser user, string password);

        IdentityResult CreateUserWithResult(PartyIdentityUser user, string password);

        ClaimsIdentity CreateIdentity(PartyIdentityUser user, string authenticationType = DefaultAuthenticationTypes.ApplicationCookie);

        PartyIdentityUser FindById(string id);

        PartyIdentityUser FindByName(string name);
        
        void UpdateUser(PartyIdentityUser user);
        
//        IQueryable<PartyIdentityUser> GetUsersQueryable();

        bool RemovePassword(string id);

        bool AddPassword(string id, string password);

        bool AddUserToRole(string userId, string roleName);

        IdentityResult AddUserToRoleWithResult(string userId, string roleName);

        bool RemoveUserFromRole(string userId, string roleName);

        bool RemoveUserFromRoleById(string userId, string roleId);

        void ClearUserRoles(string userId);

        IList<string> GetRoleNames(string userId); 

        bool RoleExists(string name);

        bool CreateRole(string name);

        ICollection<IdentityRole> GetRoles();
    }
}