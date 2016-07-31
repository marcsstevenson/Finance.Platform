using System;
using System.Collections.Generic;
using Finance.Logic.Crm;
using Generic.Framework.Interfaces.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/Company")]
    public class CompanyController : BaseController
    {
        public CompanyController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;

        }

        public List<CustomerDto> GetAll()
        {
            return this.CustomerService.GetAll();
        }

        public CustomerDto Get(Guid id)
        {
            return this.CustomerService.Get(id);
        }
    }
}