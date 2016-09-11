using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Internal
{
    public class StaffMember : Entity, IEmail
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }
    }
}