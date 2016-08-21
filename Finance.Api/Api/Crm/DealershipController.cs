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
    [Route("api/Dealership")]
    public class DealershipController : BaseController
    {
        public DealershipController()
        {
        }

        public DealershipController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public List<DealershipDto> GetAll()
        {
            return this.DealershipService.GetAll();
        }

        [HttpGet]
        public DealershipDto Get(Guid id)
        {
            return this.DealershipService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(DealershipDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.DealershipService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.DealershipService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}