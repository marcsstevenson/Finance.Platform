using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Generic.Framework.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Finance.Logic.Indentity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class PartyIdentityUser : IdentityUser, ITracksTime
    {
        public PartyIdentityUser()
        {

        }
        
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<PartyIdentityUser> manager, string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
