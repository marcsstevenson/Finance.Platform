using Finance.Logic.Crm;
using Generic.Framework.Interfaces.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IPersistanceFactory _persistanceFactory;

        private CustomerService _customerService;
        protected CustomerService CustomerService => _customerService ?? (_customerService = new CustomerService(_persistanceFactory));

        protected BaseController(
            IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;

        }
    }
}