using System;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Crm
{
    public class CustomerService : BaseService
    {
        public CustomerService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public CommitResult SaveCustomer(CustomerDto customerDto)
        {
            var commitAction = CommitAction.None;
            Customer entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = customerDto.Id.HasValue
                    ? this.RepositoryCustomer.FirstOrDefault(i => i.Id == customerDto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                    entity = customerDto.ToEntity();
                else
                    //Update for any changes
                    customerDto.UpdateEntity(entity);
                
                commitAction = RepositoryCustomer.Save(entity);

                //Set the track date fields on the view model
                customerDto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}