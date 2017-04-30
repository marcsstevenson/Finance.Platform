using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Finance.Logic.Applications.PersonalApplicationForms;
using Finance.Logic.Applications.PersonalApplicationNotes;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Finance.Logic.Interfaces;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplication : BaseApplication, IForm, IPersonalApplicationHeader
    {
        [Required]
        public string SchemaVersion { get; set; }

        [Required]
        public string JsonData { get; set; }

        /// <summary>
        /// The status of the personal application
        /// </summary>
        public PersonalApplicationStatus Status { get; set; }

        //The associated customer, if any
        public Customer Customer { get; set; }

        //The associated deal, if any
        public Deal Deal { get; set; }

        //These properties we want to search on so we pull from JsonData
        public string FirstName { get; set; }
        public string PreferredName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string LicenceNumberSa { get; set; }
        public string PersonalEmail { get; set; }
        public string BusinessEmail { get; set; }
        
        #region 1:M Relationships

        public IList<PersonalApplicationNote> PersonalApplicationNotes { get; set; }

        public IList<PersonalApplicationForm> PersonalApplicationForms { get; set; }

        #endregion
    }
}
