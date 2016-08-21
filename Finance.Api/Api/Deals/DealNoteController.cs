using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.Deals;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Deals
{
    //[Produces("application/json")]
    [Route("api/DealNote")]
    public class DealNoteController : BaseController
    {
        public DealNoteController()
        {
        }

        public DealNoteController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        [Route("api/DealNote/GetForDeal")]
        public List<DealNoteDto> GetForDeal(Guid customerId)
        {
            return this.DealNoteService.GetForDeal(customerId);
        }

        [HttpGet]
        public DealNoteDto Get(Guid id)
        {
            return this.DealNoteService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(DealNoteDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.DealNoteService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.DealNoteService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}