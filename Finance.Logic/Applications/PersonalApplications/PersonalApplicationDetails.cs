using System.Collections.Generic;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplicationDetails
    {
        public dynamic JsonData { get; set; }
        public List<PersonalApplicationFormItem> Forms { get; set; }
        //public List<NameValue> StatusOptions { get; set; }
    }
}
