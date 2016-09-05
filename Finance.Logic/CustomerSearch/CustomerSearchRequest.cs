using Finance.Logic.Shared;

namespace Finance.Logic.CustomerSearch
{
    public class CustomerSearchRequest : PagedSearchRequest
    {
        //public string NameContains { get; set; }

        //public string NumberContains { get; set; }

        //public string CellContains { get; set; }

        //public string DriversLicenceNumberContains { get; set; }

        public string SearchTerm { get; set; }
    }
}
