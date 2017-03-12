using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;

namespace Finance.Logic.Crm
{
    public class Dealership : Entity, IIsEnabled, IName, IEmail, IPhone, ICell, IFax, IBankAccount
    {
        [Required]
        public bool IsEnabled { get; set; } = true;

        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// The name of the main contact at this dealership
        /// </summary>
        public string ContactName { get; set; }

        public string Website { get; set; }
        public string Email { get; set; }

        // Phone number fields
        public string PhoneNumber { get; set; }

        // Cell number fields
        public string MobileNumber { get; set; }

        // Fax number fields
        public string FaxNumber { get; set; }

        //Bank account details
        public string BankingCompany { get; set; }
        public string BankAccountName { get; set; }
        public string BankBranchName { get; set; }
        public string BankAccountNumber { get; set; }
        
        #region 1:M Relationships

        public IList<CustomerNote> CustomerNotes { get; set; }

        public IList<DealershipStreetAddress> DealershipStreetAddresses { get; set; }

        #endregion
    }
}
