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
    [Route("api/CustomerNote")]
    public class CustomerNoteController : BaseController
    {
        public CustomerNoteController()
        {
        }

        public CustomerNoteController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        [Route("api/CustomerNote/GetForCustomer")]
        public List<CustomerNoteDto> GetForCustomer(Guid customerId)
        {
            return this.CustomerNoteService.GetForCustomer(customerId);
        }

        [HttpGet]
        public CustomerNoteDto Get(Guid id)
        {
            return this.CustomerNoteService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(CustomerNoteDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.CustomerNoteService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.CustomerNoteService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}