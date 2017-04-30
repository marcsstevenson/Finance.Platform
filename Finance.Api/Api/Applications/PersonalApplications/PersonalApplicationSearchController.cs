using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Applications.PersonalApplications;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Applications.PersonalApplications
{
    [Route("api/PersonalApplicationSearch")]
    public class PersonalApplicationSearchController : BaseController
    {
        private PersonalApplicationSearchService _servicePersonalApplicationSearch;
        protected PersonalApplicationSearchService PersonalApplicationSearchService => _servicePersonalApplicationSearch ?? (_servicePersonalApplicationSearch = new PersonalApplicationSearchService(_persistanceFactory));

        public PersonalApplicationSearchController()
        {
        }

        public PersonalApplicationSearchController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }
        
        [HttpPost]
        public PersonalApplicationSearchResponse Post(PersonalApplicationSearchRequest request)
        {
            return this.PersonalApplicationSearchService.Search(request);
        }
    }
}