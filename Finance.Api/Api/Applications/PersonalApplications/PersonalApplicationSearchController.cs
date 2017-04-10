using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Applications.PersonalApplications;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Applications.PersonalApplications
{
    //[Produces("application/json")]
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
        
        [HttpGet]
        public PersonalApplicationSearchResponse Test()
        {
            var request = new PersonalApplicationSearchRequest
            {
                SearchTerm = "rst",
                PageSize = 3,
                CurrentPage = 2,
                OrderBy = "Name"
            };

            return this.PersonalApplicationSearchService.Search(request);
        }
        
        [HttpPost]
        public PersonalApplicationSearchResponse Post(PersonalApplicationSearchRequest request)
        {
            return this.PersonalApplicationSearchService.Search(request);
        }
    }
}