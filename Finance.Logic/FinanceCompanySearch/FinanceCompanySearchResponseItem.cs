using System;

namespace Finance.Logic.FinanceCompanySearch
{
    public class FinanceCompanySearchResponseItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //public string ContactName { get; set; }

        //public string PhoneNumber { get; set; }

        //public string MobileNumber { get; set; }

        //public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
