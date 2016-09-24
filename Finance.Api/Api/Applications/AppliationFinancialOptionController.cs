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
    [Route("api/AppliationFinancialOption")]
    public class AppliationFinancialOptionController : BaseController
    {
        public AppliationFinancialOptionController()
        {
        }

        public AppliationFinancialOptionController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public List<AppliationFinancialOptionDto> GetAll()
        {
            return this.AppliationFinancialOptionService.GetAll();
        }

        [HttpGet]
        public AppliationFinancialOptionDto Get(Guid id)
        {
            return this.AppliationFinancialOptionService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(AppliationFinancialOptionDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.AppliationFinancialOptionService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.AppliationFinancialOptionService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}