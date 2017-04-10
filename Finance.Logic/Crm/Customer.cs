using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Finance.Logic.Applications.PersonalApplications;
using Finance.Logic.Deals;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Crm
{
    public class Customer : Entity, IPerson, IEmail, IBankAccount, ICell, IPhone, IFax
    {
        public Gender? Gender { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PreferredName { get; set; }

        public string DriversLicenceNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// The customer's visible reference - unique
        /// </summary>
        /// <example>CU0008798</example>
        [Required]
        public string Number { get; set; }

        public string Email { get; set; }

        // Phone number fields
        public string PhoneNumber { get; set; }
        
        // Cell number fields
        public string MobileNumber { get; set; }

        // Fax number fields
        public string FaxNumber { get; set; }

        public string WorkNumber { get; set; }

        public string SkypeName { get; set; }

        public string Website { get; set; }

        //Bank account details
        public string BankingCompany { get; set; }
        public string BankAccountName { get; set; }
        public string BankBranchName { get; set; }
        public string BankAccountNumber { get; set; }

        #region 1:M Relationships

        public IList<CustomerNote> CustomerNotes { get; set; }

        public IList<CustomerStreetAddress> CustomerStreetAddresses { get; set; }

        public IList<Deal> Deals { get; set; }

        public IList<PersonalApplication> PersonalApplications { get; set; }

        /// <summary>
        /// The last deal for his customer - if any
        /// </summary>
        public Deal LastDeal { get; set; }

        #endregion
    }
}
