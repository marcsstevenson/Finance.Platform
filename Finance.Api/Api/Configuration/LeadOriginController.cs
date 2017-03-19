using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.Configuration;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Configuration
{
    public class LeadOriginController : BaseController
    {
        public LeadOriginController()
        {
        }

        public LeadOriginController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public List<LeadOriginDto> GetAll()
        {
            return this.LeadOriginService.GetAll();
        }

        [HttpGet]
        public LeadOriginDto Get(Guid id)
        {
            return this.LeadOriginService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(LeadOriginDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.LeadOriginService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.LeadOriginService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}
