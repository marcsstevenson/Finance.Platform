using System.Web.Mvc;
using Finance.Logic.CustomerSearch;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Controllers
{
    [AllowAnonymous]
    public class CustomerSearchTestController : Controller
    {
        private IPersistanceFactory _persistanceFactory;

        public CustomerSearchTestController()
        {
        }

        public CustomerSearchTestController(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }

        private CustomerSearchService _serviceCustomerSearch;
        protected CustomerSearchService CustomerSearchService => _serviceCustomerSearch ?? (_serviceCustomerSearch = new CustomerSearchService(_persistanceFactory));
        
        public JsonResult Index()
        {
            var data = this.CustomerSearchService.Search(new CustomerSearchRequest { OrderBy = "Name" });

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
