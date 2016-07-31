using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Crm
{
    public class CustomerService : GenericService<Customer>
    {
        public CustomerService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public CustomerDto Get(Guid id)
        {
            var entity = this.RepositoryCustomer.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new CustomerDto(entity);
        }

        public List<CustomerDto> GetAll()
        {
            return this.RepositoryCustomer.AllList().Select(i => new CustomerDto(i)).ToList();
        }

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