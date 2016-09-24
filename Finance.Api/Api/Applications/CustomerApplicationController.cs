using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.Applications;
using Finance.Logic.Crm;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Applications
{
    [Route("api/CustomerApplication")]
    public class CustomerApplicationController : BaseController
    {
        public CustomerApplicationController()
        {
        }

        public CustomerApplicationController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public List<CustomerApplicationDto> GetAll()
        {
            return this.CustomerApplicationService.GetAll();
        }

        [HttpGet]
        public CustomerApplicationDto Get(Guid id)
        {
            return this.CustomerApplicationService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(CustomerApplicationDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.CustomerApplicationService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.CustomerApplicationService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}