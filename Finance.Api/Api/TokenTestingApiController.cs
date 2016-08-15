using System.Web.Http;
using Finance.Api.Api.@base;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api
{
    [Authorize] 
    public class TokenTestingApiController : BaseController
    {
        public TokenTestingApiController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        
        }
        
        [HttpGet]
        public string TestAuthentication()
        {
            return "Goodness"; //We made it this far so we must be authenticated
        }
    }
}