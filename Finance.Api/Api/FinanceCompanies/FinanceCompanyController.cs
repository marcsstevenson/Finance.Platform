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
    [Route("api/FinanceCompany")]
    public class FinanceCompanyController : BaseController
    {
        public FinanceCompanyController()
        {
        }

        public FinanceCompanyController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
        }

        [HttpGet]
        public List<FinanceCompanyDto> GetAll()
        {
            return this.FinanceCompanyService.GetAll();
        }

        [HttpGet]
        public FinanceCompanyDto Get(Guid id)
        {
            return this.FinanceCompanyService.Get(id);
        }

        [HttpPost]
        public HttpResponseMessage Save(FinanceCompanyDto dto, AccountManagerDto accountManagerDto = null)
        {
            if (dto == null) return Request.NullParameterResponse();

            if (!ModelState.IsValid)
                return Request.InvalidModelStateResponse(ModelState);

            var commitResult = this.FinanceCompanyService.Save(dto, accountManagerDto);
            return commitResult.ToHttpResponseMessage(this.Request);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var commitResult = this.FinanceCompanyService.Delete(id);
            return commitResult.ToHttpResponseMessage(this.Request);
        }
    }
}