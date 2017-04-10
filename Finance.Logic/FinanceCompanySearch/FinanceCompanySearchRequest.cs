using Finance.Logic.Shared;

namespace Finance.Logic.FinanceCompanySearch
{
    public class FinanceCompanySearchRequest : PagedSearchRequest
    {
        public string SearchTerm { get; set; }
    }
}
