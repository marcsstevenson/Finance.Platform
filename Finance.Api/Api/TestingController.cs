using System;
using System.Linq;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api
{
    [AllowAnonymous]
    public class TestingController : BaseController
    {
        public TestingController()
        {
        }

        public TestingController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        //[HttpGet]
        //public bool CreateMappings()
        //{
        //    Logic.Mappings.AutoMapperConfiguration.CreateMappings();

        //    return true;
        //}

        [HttpGet]
        [Route("api/Testing/" + nameof(CreateTestCustomer))]
        public dynamic CreateTestCustomer()
        {
            try
            {
                var dto = new CustomerDto() { FirstName = "Test", LastName = "Customer" };

                var commitResult = this.CustomerService.Save(dto);
                
                return commitResult.Success;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("api/Testing/" + nameof(CreateBadDeal))]
        public dynamic CreateBadDeal()
        {
            try
            {
                var firstCustomer = this.CustomerService.GetAll().FirstOrDefault();

                if (firstCustomer?.Id == null)
                    return "No customer to use";

                var dto = new DealDto()
                {
                    CustomerId = firstCustomer.Id.Value,
                };

                var commitResult = this.DealService.Save(dto);
                
                return commitResult.Success;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}