using Finance.Logic.Shared;

namespace Finance.Logic.Configuration
{
    public class LeadOriginSearchRequest : PagedSearchRequest
    {
        public string SearchTerm { get; set; }
    }
}
