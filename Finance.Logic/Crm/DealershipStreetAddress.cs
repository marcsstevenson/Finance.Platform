using System.ComponentModel.DataAnnotations;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Crm
{
    public class DealershipStreetAddress : Entity, IStreetAddress
    {
        [Required]
        public Dealership Dealership { get; set; }

        public string Region { get; set; }
        public string Name { get; set; }
        //public string ContactPhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public bool IsDefault { get; set; }
        public string Type { get; set; }
        public string OtherInformation { get; set; }
    }
}
