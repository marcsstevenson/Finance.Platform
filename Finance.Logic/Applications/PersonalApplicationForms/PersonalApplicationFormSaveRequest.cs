using System;
using System.ComponentModel.DataAnnotations;
using Finance.Logic.Interfaces;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Applications.PersonalApplicationForms
{
    public class PersonalApplicationFormSaveRequest : IGuidNullableId, IForm
    {
        public Guid? Id { get; set; }

        [Required]
        public string SchemaVersion { get; set; }

        [Required]
        public string JsonData { get; set; }

        [Required]
        public string FormType { get; set; }

        [Required]
        public Guid PersonalApplicationId { get; set; }
    }
}
