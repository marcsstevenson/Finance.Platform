using System;
using Generic.Framework.Helpers;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplicationSearchResponseItem
    {
        public Guid Id { get; set; }
        
        public string Number { get; set; }

        public PersonalApplicationStatus Status { get; set; }
        public string StatusDescription {
            get { return this.Status.GetDescription(); }
            set { } //This is just for serialisation
        }

        public string FirstName { get; set; }
        public string PreferredName { get; set; }
        public string LastName { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string PersonalEmail { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
