using System;
using System.Collections.Generic;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Crm;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Controllers
{
    /// <summary>
    /// This controller is used for creating testing data
    /// </summary>
    [Route("api/DataPopulation")]
    public class DataPopulationController : BaseController
    {
        public DataPopulationController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
            //IHostingEnvironment env,
            //if (env.IsProduction())
            //    throw new AccessViolationException("Testing data shall not be used in production");
        }
        
        public List<CustomerDto> Get(int count = 10)
        {
            return Customer(count);
        }

        [Route("api/DataPopulation/Customer")]
        [HttpGet]
        public List<CustomerDto> Customer(int count = 10)
        {
            var customerDtos = new List<CustomerDto>();

            for (int i = 0; i < count; i++)
            {
                var customerDto = new CustomerDto()
                {
                    FirstName = "First" + i,
                    LastName = "Last" + i,
                    DateOfBirth = Clock.Now()
                };

                this.CustomerService.Save(customerDto);

                customerDtos.Add(customerDto);
            }

            return customerDtos;
        }
    }
}