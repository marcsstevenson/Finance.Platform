using System.ComponentModel.DataAnnotations;
using Finance.Logic.Applications.PersonalApplications;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Applications.PersonalApplicationNotes
{
    public class PersonalApplicationNote : Entity
    {
        [Required]
        public string Note { get; set; }

        [Required]
        public PersonalApplication PersonalApplication { get; set; }

        /// <summary>
        /// The name of the person who entered this note
        /// </summary>
        /// <remarks>Can be a staff member, dealership or eventually a customer</remarks>
        public string EnteredBy { get; set; }
    }
}
