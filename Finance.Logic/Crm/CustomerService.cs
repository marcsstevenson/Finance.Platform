using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Finance.Logic.Counting;
using Finance.Logic.Helpers;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Crm
{
    public class CustomerService : GenericService<Customer>
    {
        private CounterStoreService _counterStoreService;

        public CounterStoreService CounterStoreService
            => _counterStoreService ?? (_counterStoreService = new CounterStoreService(this.PersistanceFactory));

        public CustomerService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public CustomerDto Get(Guid id)
        {
            var dto = this.RepositoryCustomer
                .AllQueryable()
                .Include(i => i.LastDeal)
                .Select(CustomerDto.GetentityToDtoFunc())
                .FirstOrDefault(i => i.Id == id);
            return dto;
        }

        public List<CustomerDto> GetAll()
        {
            return this.RepositoryCustomer
                .AllQueryable()
                .Include(i => i.LastDeal)
                .Select(CustomerDto.GetentityToDtoFunc())
                .ToList();
        }

        public CommitResult Save(CustomerDto dto)
        {
            var commitAction = CommitAction.None;
            Customer entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryCustomer.FirstOrDefault(i => i.Id == dto.Id)
                    : null;
                
                //Create a new object if needed
                if (entity == null)
                {
                    entity = dto.ToEntity();

                    //Get a customer number. We need the current count for this
                    var currentCount = CounterStoreService.GetCurrentCounterCustomer();
                    entity.Number = ReferenceGenerator.GetNextCustomerNumber(currentCount + 1);
                    CounterStoreService.IntcrementCounterCustomer_InSession();
                }
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryCustomer.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}