using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Finance.Logic.Shared;

namespace Finance.Logic.Applications
{
    public class CustomerApplication : BaseApplication
    {
        public bool VehicleUsePersonal { get; set; }
        public bool VehicleUseBusiness { get; set; }
        public bool VehicleUseSoleTrader { get; set; }
        public bool VehicleUseLimitedLiability { get; set; }

        /// <summary>
        /// Applicant details
        /// </summary>
        [Required]
        public PersonalEntity Applicant { get; set; }

        /// <summary>
        /// Spouce information 
        /// </summary>
        public PersonalEntity Spouce { get; set; }

        /// <summary>
        /// The date that the application was signed
        /// </summary>
        public DateTime? DateSigned { get; set; }

        #region 1:M Relationships

        public IList<CustomerApplicationNote> CustomerApplicationNotes { get; set; }
        
        public IList<CustomerAppliationFinancial> CustomerAppliationFinancials { get; set; }
        
        #endregion
    }
}