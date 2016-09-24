using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.Applications;
using Finance.Logic.Shared;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Applications
{
    [Route("api/CustomerApplicationApplicant")]
    public class CustomerApplicationApplicantController : BaseController
    {
        public CustomerApplicationApplicantController()
        {
        }

        public CustomerApplicationApplicantController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }
        
        [HttpGet]
        public PersonalEntityDto Get(Guid customerApplicationId)
        {
            return this.CustomerApplicationService.GetApplicant(customerApplicationId);
        }

        [HttpPost]
        public HttpResponseMessage Save(Guid customerApplicationId, PersonalEntityDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.CustomerApplicationService.SaveApplicant(customerApplicationId, dto);
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