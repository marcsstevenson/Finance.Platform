using System.Configuration;
using Finance.Repository.EfCore.Context;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers
{
    [Route("api/Configuration")]
    public class ConfigurationController : Controller
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