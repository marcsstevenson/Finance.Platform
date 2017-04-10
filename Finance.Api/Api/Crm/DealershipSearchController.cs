using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.DealershipSearch;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Crm
{
    //[Produces("application/json")]
    [Route("api/DealershipSearch")]
    public class DealershipSearchController : BaseController
    {
        private DealershipSearchService _serviceDealSearch;
        protected DealershipSearchService DealershipSearchService => _serviceDealSearch ?? (_serviceDealSearch = new DealershipSearchService(_persistanceFactory));

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

            return this.DealershipSearchService.Search(request);
        }
        
        [HttpPost]
        public DealershipSearchResponse Post(DealershipSearchRequest request)
        {
            return this.DealershipSearchService.Search(request);
        }
    }
}