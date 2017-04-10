using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.FinanceCompanySearch;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.FinanceCompanies
{
    //[Produces("application/json")]
    [Route("api/FinanceCompanySearch")]
    public class FinanceCompanySearchController : BaseController
    {
        private FinanceCompanySearchService _serviceDealSearch;
        protected FinanceCompanySearchService FinanceCompanySearchService => _serviceDealSearch ?? (_serviceDealSearch = new FinanceCompanySearchService(_persistanceFactory));

        public FinanceCompanySearchController()
        {
        }

        public FinanceCompanySearchController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }
        
        [HttpGet]
        public FinanceCompanySearchResponse Test()
        {
            var request = new FinanceCompanySearchRequest
            {
                SearchTerm = "rst",
                PageSize = 3,
                CurrentPage = 1,
                OrderBy = "Number"
            };

            return this.FinanceCompanySearchService.Search(request);
        }
        
        [HttpPost]
        public FinanceCompanySearchResponse Post(FinanceCompanySearchRequest request)
        {
            return this.FinanceCompanySearchService.Search(request);
        }
    }
}