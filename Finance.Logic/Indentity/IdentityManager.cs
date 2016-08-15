using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Finance.Logic.Indentity
{
    public class IdentityManager : IIdentityManager
    {
//        private readonly FynditContext _context;

        public UserManager<PartyIdentityUser> UserManager { get; set; }

        public RoleManager<IdentityRole> RoleManager { get; set; }

        public IdentityManager(UserManager<PartyIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
        }

        public bool CreateUser(PartyIdentityUser user, string password)
        {
            var idResult = UserManager.Create(user, password);
            return idResult.Succeeded;
        }

        public IdentityResult CreateUserWithResult(PartyIdentityUser user, string password)
        {
            return UserManager.Create(user, password);
        }

        public ClaimsIdentity CreateIdentity(PartyIdentityUser user, string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            return UserManager.CreateIdentity(user, authenticationType);
        }

        public PartyIdentityUser FindById(string id)
        {
            return UserManager.FindById(id);
        }

        public PartyIdentityUser FindByName(string name)
        {
            return UserManager.FindByName(name);
        }

        public void UpdateUser(PartyIdentityUser user)
        {
            UserManager.Update(user);
        }

//        public IQueryable<PartyIdentityUser> GetUsersQueryable()
//        {
//            var users = this.UserManager.Get.Users
//                .AsQueryable()
//                .Include(i => i.Roles);
//            return users;
//        }

        public bool RemovePassword(string id)
        {
            var idResult = UserManager.RemovePassword(id);
            return idResult.Succeeded;
        }

        public bool AddPassword(string id, string password)
        {
            var idResult = UserManager.AddPassword(id, password);
            return idResult.Succeeded;
        }
        
        public bool AddUserToRole(string userId, string roleName)
        {
            var result = UserManager.AddToRole(userId, roleName);
            UserManager.UpdateSecurityStamp(userId);
            return result.Succeeded;
        }

        public IdentityResult AddUserToRoleWithResult(string userId, string roleName)
        {
            var result = UserManager.AddToRole(userId, roleName);
            UserManager.UpdateSecurityStamp(userId);
            return result;
        }

        public bool RemoveUserFromRole(string userId, string roleName)
        {
            var idResult = UserManager.RemoveFromRole(userId, roleName);
            UserManager.UpdateSecurityStamp(userId);
            return idResult.Succeeded;
        }

        public bool RemoveUserFromRoleById(string userId, string roleId)
        {
            var role = RoleManager.FindById(roleId);
            var idResult = UserManager.RemoveFromRole(userId, role.Name);
            UserManager.UpdateSecurityStamp(userId);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            var user = UserManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                this.RemoveUserFromRoleById(userId, role.RoleId);
            }
            UserManager.UpdateSecurityStamp(userId);
        }

        public IList<string> GetRoleNames(string userId)
        {
            return UserManager.GetRoles(userId);
        }
        
        public bool RoleExists(string name)
        {
            return RoleManager.RoleExists(name);
        }
        
        public bool CreateRole(string name)
        {
            var idResult = RoleManager.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }
        
        public ICollection<IdentityRole> GetRoles()
        {
            return this.RoleManager.Roles.ToList();
        }

    }
}