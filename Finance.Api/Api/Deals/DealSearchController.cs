using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.DealSearch;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Crm
{
    //[Produces("application/json")]
    [Route("api/DealSearch")]
    public class DealSearchController : BaseController
    {
        private DealSearchService _serviceDealSearch;
        protected DealSearchService DealSearchService => _serviceDealSearch ?? (_serviceDealSearch = new DealSearchService(_persistanceFactory));

        public DealSearchController()
        {
        }

        public DealSearchController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }
        
        [HttpGet]
        public DealSearchResponse Test()
        {
            var request = new DealSearchRequest
            {
                SearchTerm = "rst",
                PageSize = 3,
                CurrentPage = 1,
                OrderBy = "Number"
            };

            return this.DealSearchService.Search(request);
        }
        
        [HttpPost]
        public DealSearchResponse Post(DealSearchRequest request)
        {
            return this.DealSearchService.Search(request);
        }
    }
}