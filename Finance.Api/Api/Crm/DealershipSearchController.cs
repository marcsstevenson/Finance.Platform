using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.DealershipSearch;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Crm
{
    //[Produces("application/json")]
    [Route("api/DealSearch")]
    public class DealershipSearchController : BaseController
    {
        private DealershipSearchService _serviceDealSearch;
        protected DealershipSearchService DealSearchService => _serviceDealSearch ?? (_serviceDealSearch = new DealershipSearchService(_persistanceFactory));

        public DealershipSearchController()
        {
        }

        public DealershipSearchController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }
        
        [HttpGet]
        public DealershipSearchResponse Test()
        {
            var request = new DealershipSearchRequest
            {
                SearchTerm = "rst",
                PageSize = 3,
                CurrentPage = 1,
                OrderBy = "Number"
            };

            return this.DealSearchService.Search(request);
        }
        
        [HttpPost]
        public DealershipSearchResponse Post(DealershipSearchRequest request)
        {
            return this.DealSearchService.Search(request);
        }
    }
}