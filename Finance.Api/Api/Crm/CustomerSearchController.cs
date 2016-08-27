using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Crm;
using Finance.Logic.CustomerSearch;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Crm
{
    //[Produces("application/json")]
    [Route("api/CustomerSearch")]
    public class CustomerSearchController : BaseController
    {
        private CustomerSearchService _serviceCustomerSearch;
        protected CustomerSearchService CustomerSearchService => _serviceCustomerSearch ?? (_serviceCustomerSearch = new CustomerSearchService(_persistanceFactory));

        public CustomerSearchController()
        {
        }

        public CustomerSearchController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }
        
        [HttpGet]
        public CustomerSearchResponse Test()
        {
            var request = new CustomerSearchRequest
            {
                NameContains = "rst",
                PageSize = 3,
                CurrentPage = 2,
                OrderBy = "Name"
            };

            return this.CustomerSearchService.Search(request);
        }
        
        [HttpPost]
        public CustomerSearchResponse Post(CustomerSearchRequest request)
        {
            return this.CustomerSearchService.Search(request);
        }
    }
}