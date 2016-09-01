using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Deals
{
    //[Produces("application/json")]
    [Route("api/Deal")]
    public class DealController : BaseController
    {
        public DealController()
        {
        }

        public DealController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        [Route("api/Deal/GetForCustomer")]
        public List<DealDto> GetForCustomer(Guid customerId)
        {
            return this.DealService.GetForCustomer(customerId);
        }

        [HttpGet]
        public List<DealDto> GetAll()
        {
            return this.DealService.GetAll();
        }

        [HttpGet]
        public DealDto Get(Guid id)
        {
            return this.DealService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(DealDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.DealService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.DealService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}