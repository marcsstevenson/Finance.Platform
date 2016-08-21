using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.Crm;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Crm
{
    //[Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController()
        {
        }

        public CustomerController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public List<CustomerDto> GetAll()
        {
            return this.CustomerService.GetAll();
        }

        [HttpGet]
        public CustomerDto Get(Guid id)
        {
            return this.CustomerService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(CustomerDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.CustomerService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.CustomerService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}