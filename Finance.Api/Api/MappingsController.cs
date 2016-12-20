using System;
using System.Web.Http;
using Finance.Logic.Crm;

namespace Finance.Api.Api
{
    [AllowAnonymous]
    public class MappingsController : ApiController
    {
        [HttpGet]
        public bool CreateMappings()
        {
            Logic.Mappings.AutoMapperConfiguration.CreateMappings();

            return true;
        }

        [HttpGet]
        [Route(nameof(TestMappings))]
        public dynamic TestMappings()
        {
            try
            {
                var customer = new Customer()
                {
                    FirstName = "Test",
                    LastName = "Customer"
                };

                var customerDto = new CustomerDto(customer);

                return customerDto;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}