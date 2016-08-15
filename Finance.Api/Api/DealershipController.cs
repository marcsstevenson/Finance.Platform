using System;
using System.Collections.Generic;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Crm;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/Dealership")]
    public class DealershipController : BaseController
    {
        public DealershipController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
            var test = persistanceFactory;
        }

        //[Route("api/Dealership/GetAll")]
        public List<DealershipDto> GetAll()
        {
            return this.DealershipService.GetAll();
        }

        //public DealershipDto Get(Guid id)
        //{
        //    return this.DealershipService.Get(id);
        //}


        //public IList<Dealership> Get()
        //{
        //    var repoDealership = _persistanceFactory.BuildEntityRepository<Dealership>();

        //    CommitAction commitAction = CommitAction.None;

        //    IUnitOfWork UnitOfWork = _persistanceFactory.BuildUnitOfWork();
        //    Dealership customer = null;

        //    var commitResult = UnitOfWork.Commit(() =>
        //    {
        //        customer = new Dealership();

        //        commitAction = repoDealership.Save(customer);
        //    });

        //    //Add the result to the commit actions
        //    commitResult.CommitActions.Add(customer, commitAction);

        //    if (commitResult.HasError)
        //    {
        //        var error = commitResult.ErrorMessage;
        //    }

        //    var customers = repoDealership.AllList();

        //    return customers;
        //}
    }
}