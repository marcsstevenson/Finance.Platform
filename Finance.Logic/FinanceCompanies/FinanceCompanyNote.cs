using System.ComponentModel.DataAnnotations;
using Finance.Logic.Deals;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.FinanceCompanies
{
    public class FinanceCompanyNote : Entity
    {
        [Required]
        public string Note { get; set; }

        [Required]
        public FinanceCompany FinanceCompany { get; set; }

        /// <summary>
        /// The name of the person who entered this note
        /// </summary>
        /// <remarks>Can be a staff member, dealership or eventually a customer</remarks>
        public string EnteredBy { get; set; }
    }
}
