using System.Configuration;
using System.Web.Http;
using Finance.Repository.EfCore.Context;

namespace Finance.Api.Controllers
{
    [Route("api/Configuration")]
    public class ConfigurationController : ApiController
    {
        public ConfigurationController()
        {
            
        }
        
        public dynamic GetAll()
        {
            return new
            {
                
            };
        }
    }
}