﻿using System;
using System.Collections.Generic;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.FinanceCompanies
{
    public class AccountManager : Entity, IPerson, IEmail, ICell, IPhone
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        
        #region 1:M Relationships

        public IList<FinanceCompany> FinanceCompanies { get; set; }

        #endregion
    }
}
