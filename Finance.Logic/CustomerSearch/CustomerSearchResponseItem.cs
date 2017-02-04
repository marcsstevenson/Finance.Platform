using System;
using Generic.Framework.Enumerations;

namespace Finance.Logic.CustomerSearch
{
    public class CustomerSearchResponseItem
    {
        public Guid Id { get; set; }

        public Gender Gender { get; set; }
        
        public string Number { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string DriversLicenceNumber { get; set; }

        public string MobileNumber { get; set; }

        /// <summary>
        /// The Id of the last deal - if any
        /// </summary>
        public Guid? LastDealId { get; set; }

        /// <summary>
        /// The number of the last deal - if any
        /// </summary>
        public string LastDealNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
