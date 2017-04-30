using System;
using System.Collections.Generic;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplicationDetails
    {
        public Guid? CustomerId { get; set; }

        public Guid? DealId { get; set; }

        public dynamic JsonData { get; set; }

        public List<PersonalApplicationFormItem> Forms { get; set; }
    }
}
