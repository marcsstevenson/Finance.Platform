using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Logic.Shared;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Indentity
{
    public class PartyService : BaseService
    {
        public PartyService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        {

        }


        public static PartyIdentityUser BuildNewIdentityUser(string emailAddress)
        {
            var partyIdentityUser = new PartyIdentityUser
            {
                UserName = emailAddress,
                EmailConfirmed = true
            };
            partyIdentityUser.SetForCreated();
            return partyIdentityUser;
        }
    }
}
