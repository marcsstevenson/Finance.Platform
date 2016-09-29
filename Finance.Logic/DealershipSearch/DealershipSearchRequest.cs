using Finance.Logic.Shared;

namespace Finance.Logic.DealershipSearch
{
    public class DealershipSearchRequest : PagedSearchRequest
    {
        public string SearchTerm { get; set; }
    }
}
