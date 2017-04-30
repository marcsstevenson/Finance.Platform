using System.Collections.Generic;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Applications.PersonalApplications;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Applications.PersonalApplications
{
    [Route("api/PersonalApplicationStatus")]
    public class PersonalApplicationStatusController : BaseController
    {
        public PersonalApplicationStatusController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public List<PersonalApplicationStatusOption> Get()
        {
            return this.PersonalApplicationService.GetPersonalApplicaitionStatusOptions();
        }
    }
}