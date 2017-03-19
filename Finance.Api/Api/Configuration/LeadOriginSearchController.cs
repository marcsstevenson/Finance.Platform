using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Configuration;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Configuration
{
    //[Produces("application/json")]
    [Route("api/LeadOriginSearch")]
    public class LeadOriginSearchController : BaseController
    {
        private LeadOriginSearchService _serviceDealSearch;
        protected LeadOriginSearchService DealSearchService => _serviceDealSearch ?? (_serviceDealSearch = new LeadOriginSearchService(_persistanceFactory));

        public LeadOriginSearchController()
        {
        }

        public LeadOriginSearchController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }
        
        [HttpGet]
        public LeadOriginSearchResponse Test()
        {
            var request = new LeadOriginSearchRequest
            {
                SearchTerm = "rst",
                PageSize = 3,
                CurrentPage = 1,
                OrderBy = "Name"
            };

            return this.DealSearchService.Search(request);
        }
        
        [HttpPost]
        public LeadOriginSearchResponse Post(LeadOriginSearchRequest request)
        {
            return this.DealSearchService.Search(request);
        }
    }
}