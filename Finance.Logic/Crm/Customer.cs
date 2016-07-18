﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Crm
{
    public class Customer : Entity, IPerson, IEmail, IPhone, ICell, IFax, IBankAccount
    {
        public Gender? Gender { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public string DriversLicenceNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The customer's visible reference - unique
        /// </summary>
        /// <example>CU0008798</example>
        [Required]
        public int Number { get; set; }

        public string Email { get; set; }

        // Phone number fields
        public string PhoneCountry { get; set; }
        public string PhoneArea { get; set; }
        public string PhoneNumber { get; set; }
        
        // Cell number fields
        public string CellCountry { get; set; }
        public string CellArea { get; set; }
        public string CellNumber { get; set; }

        // Fax number fields
        public string FaxCountry { get; set; }
        public string FaxArea { get; set; }
        public string FaxNumber { get; set; }

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

        #endregion
    }
}
