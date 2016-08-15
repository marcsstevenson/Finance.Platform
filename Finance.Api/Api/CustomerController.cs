using System;
using System.Collections.Generic;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Crm;
using Generic.Framework.Interfaces.Entity;
namespace Finance.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
            var test = persistanceFactory;
        }

        //[Route("api/Customer/GetAll")]
        public List<CustomerDto> GetAll()
        {
            return this.CustomerService.GetAll();
        }

        //public CustomerDto Get(Guid id)
        //{
        //    return this.CustomerService.Get(id);
        //}


        //public IList<Customer> Get()
        //{
        //    var repoCustomer = _persistanceFactory.BuildEntityRepository<Customer>();

        //    CommitAction commitAction = CommitAction.None;

        //    IUnitOfWork UnitOfWork = _persistanceFactory.BuildUnitOfWork();
        //    Customer customer = null;

        //    var commitResult = UnitOfWork.Commit(() =>
        //    {
        //        customer = new Customer();

        //        commitAction = repoCustomer.Save(customer);
        //    });

        //    //Add the result to the commit actions
        //    commitResult.CommitActions.Add(customer, commitAction);

        //    if (commitResult.HasError)
        //    {
        //        var error = commitResult.ErrorMessage;
        //    }

        //    var customers = repoCustomer.AllList();

        //    return customers;
        //}
    }
}