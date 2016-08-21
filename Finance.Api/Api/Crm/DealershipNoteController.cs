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
    [Route("api/DealershipNote")]
    public class DealershipNoteController : BaseController
    {
        public DealershipNoteController()
        {
        }

        public DealershipNoteController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        [Route("api/DealershipNote/GetForDealership")]
        public List<DealershipNoteDto> GetForDealership(Guid customerId)
        {
            return this.DealershipNoteService.GetForDealership(customerId);
        }

        [HttpGet]
        public DealershipNoteDto Get(Guid id)
        {
            return this.DealershipNoteService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(DealershipNoteDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.DealershipNoteService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.DealershipNoteService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}