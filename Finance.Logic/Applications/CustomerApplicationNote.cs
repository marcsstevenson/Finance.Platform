using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Applications
{
    public class CustomerApplicationNote : Entity
    {
        [Required]
        public string Note { get; set; }

        [Required]
        public CustomerApplication CustomerApplication { get; set; }

        /// <summary>
        /// The name of the person who entered this note
        /// </summary>
        /// <remarks>Can be a staff member, dealership or eventually a customer</remarks>
        public string EnteredBy { get; set; }
    }
}
