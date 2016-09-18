using System.ComponentModel.DataAnnotations;
using Finance.Logic.Shared;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Applications
{
    public class CustomerApplication : BaseApplication
    {
        public bool VehicleUsePersonal { get; set; }
        public bool VehicleUseBusiness { get; set; }
        public bool VehicleUseSoleTrader { get; set; }
        public bool VehicleUseLimitedLiability { get; set; }

        [Required]
        public PersonalEntity Applicant { get; set; }

        public PersonalEntity Spouce { get; set; }
    }
}