using System.Web.Http;
using Finance.Logic.Crm;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.@base
{
    public abstract class BaseController : ApiController
    {
        protected IPersistanceFactory _persistanceFactory;

        private CustomerService _serviceCustomer;
        protected CustomerService CustomerService => _serviceCustomer ?? (_serviceCustomer = new CustomerService(_persistanceFactory));

        private DealershipService _serviceDealership;
        protected DealershipService DealershipService => _serviceDealership ?? (_serviceDealership = new DealershipService(_persistanceFactory));

        protected BaseController(
            IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;

        }
    }
}
