using Finance.Logic.Shared;

namespace Finance.Logic.DealSearch
{
    public class DealSearchRequest : PagedSearchRequest
    {
        public string SearchTerm { get; set; }
    }
}
