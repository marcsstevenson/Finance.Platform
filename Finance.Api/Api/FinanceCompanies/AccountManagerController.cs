//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Web.Http;
//using Finance.Api.Api.@base;
//using Finance.Api.Helpers;
//using Finance.Logic.FinanceCompanies;
//using Generic.Framework.Interfaces.Entity;

//namespace Finance.Api.Api.FinanceCompanies
//{
//    //[Produces("application/json")]
//    [Route("api/AccountManager")]
//    public class AccountManagerController : BaseController
//    {
//        public AccountManagerController()
//        {
//        }

//        public AccountManagerController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
//        {
//        }

//        [HttpGet]
//        public List<AccountManagerDto> GetAll()
//        {
//            return this.AccountManagerService.GetAll();
//        }

//        [HttpGet]
//        public AccountManagerDto Get(Guid id)
//        {
//            return this.AccountManagerService.Get(id);
//        }

//        [HttpPost]
//        public HttpResponseMessage Save(AccountManagerDto dto)
//        {
//            if (dto == null) return Request.NullParameterResponse();

//            if (!ModelState.IsValid)
//                return Request.InvalidModelStateResponse(ModelState);

//            var commitResult = this.AccountManagerService.Save(dto);
//            return commitResult.ToHttpResponseMessage(this.Request);
//        }

//        [HttpDelete]
//        public HttpResponseMessage Delete(Guid id)
//        {
//            var commitResult = this.AccountManagerService.Delete(id);
//            return commitResult.ToHttpResponseMessage(this.Request);
//        }
//    }
//}