using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Api.Helpers;
using Finance.Logic.FinanceCompanies;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.FinanceCompanies
{
    //[Produces("application/json")]
    [Route("api/FinanceCompanyNote")]
    public class FinanceCompanyNoteController : BaseController
    {
        public FinanceCompanyNoteController()
        {
        }

        public FinanceCompanyNoteController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        [Route("api/FinanceCompanyNote/GetForFinanceCompany")]
        public List<FinanceCompanyNoteDto> GetForFinanceCompany(Guid customerId)
        {
            return this.FinanceCompanyNoteService.GetForFinanceCompany(customerId);
        }

        [HttpGet]
        public FinanceCompanyNoteDto Get(Guid id)
        {
            return this.FinanceCompanyNoteService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(FinanceCompanyNoteDto dto)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.FinanceCompanyNoteService.Save(dto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.FinanceCompanyNoteService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}