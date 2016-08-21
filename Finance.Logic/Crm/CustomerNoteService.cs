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
    public class CustomerNoteService : GenericService<CustomerNote>
    {
        public CustomerNoteService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public CustomerNoteDto Get(Guid id)
        {
            var entity = this.RepositoryCustomerNote.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new CustomerNoteDto(entity);
        }

        public List<CustomerNoteDto> GetForCustomer(Guid customerId)
        {
            //var test = this.RepositoryCustomerNote.Where(i => i.Customer.Id == customerId).ToList();

            return this.RepositoryCustomerNote.Where(i => i.Customer.Id == customerId).ToList().Select(i => new CustomerNoteDto(i)).ToList();
        }

        public CommitResult Save(CustomerNoteDto dto)
        {
            var commitAction = CommitAction.None;
            CustomerNote entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryCustomerNote.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                {
                    entity = dto.ToEntity();

                    //Link the customer - required and unalterable
                    entity.Customer = this.RepositoryCustomer.FirstOrDefault(i => i.Id == dto.CustomerId);
                }
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryCustomerNote.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}