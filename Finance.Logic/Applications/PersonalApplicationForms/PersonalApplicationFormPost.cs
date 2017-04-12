using System;
using System.ComponentModel.DataAnnotations;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Applications.PersonalApplicationForms
{
    public class PersonalApplicationFormPost : IGuidNullableId
    {
        public Guid? Id { get; set; }

        [Required]
        public dynamic Form { get; set; }

        [Required]
        public string FormType { get; set; }

        [Required]
        public Guid PersonalApplicationId { get; set; }

        [Required]
        public string SchemaVersion { get; set; }
    }
}
