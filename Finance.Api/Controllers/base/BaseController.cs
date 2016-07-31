using Finance.Logic.Crm;
using Generic.Framework.Interfaces.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers
{
    public abstract class BaseController : Controller
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