using System.ComponentModel.DataAnnotations;
using Finance.Logic.Applications.PersonalApplications;
using Finance.Logic.Interfaces;
using Generic.Framework.AbstractClasses;

namespace Finance.Logic.Applications.PersonalApplicationForms
{
    public class PersonalApplicationForm : Entity, IForm
    {
        [Required]
        public string SchemaVersion { get; set; }

        [Required]
        public string JsonData { get; set; }

        [Required]
        public string FormType { get; set; }
        
        [Required]
        public PersonalApplication PersonalApplication { get; set; }
    }
}
