using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Finance.Logic.Counting;
using Finance.Logic.Crm;
using Finance.Logic.Helpers;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Deals
{
    public class DealService : GenericService<Deal>
    {
        private CounterStoreService _counterStoreService;

        public CounterStoreService CounterStoreService
            => _counterStoreService ?? (_counterStoreService = new CounterStoreService(this.PersistanceFactory));

        public DealService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        private IQueryable<Deal> GetBaseQuery()
        {
            return this.RepositoryDeal
                .AllQueryable()
                .Include(i => i.Customer)
                .Include(i => i.AssignedTo)
                .Include(i => i.FinanceCompany)
                .Include(i => i.Source);
        }

        public List<DealDto> GetAll()
        {
            return this.GetBaseQuery()
                .Select(DealDto.GetentityToDtoFunc())
                .ToList();
        }

        public DealDto Get(Guid id)
        {
            return this.GetBaseQuery()
                .Select(DealDto.GetentityToDtoFunc())
                .FirstOrDefault(i => i.Id == id);
        }

        public List<DealDto> GetForCustomer(Guid customerId)
        {
            var query = this.RepositoryDeal.AllQueryable().Where(i => i.Customer.Id == customerId);

            query = query.Include(i => i.Customer);

            return query.ToList().Select(i => new DealDto(i)).ToList();
        }

        public CommitResult Save(DealDto dto)
        {
            var commitAction = CommitAction.None;
            Deal entity = null;

            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryDeal.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                {
                    //Link the customer - required and unalterable
                    var customer = this.RepositoryCustomer.FirstOrDefault(i => i.Id == dto.CustomerId);

                    entity = MintNewDeal_InSession(this.CounterStoreService, dto, customer);
                }
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);

                //Link in the 1:M properties
                entity.AssignedTo = dto.AssignedToId.HasValue ?
                    this.RepositoryStaffMember.FirstOrDefault(i => i.Id == dto.AssignedToId) :
                    null;

                entity.FinanceCompany = dto.FinanceCompanyId.HasValue ?
                    this.RepositoryFinanceCompany.FirstOrDefault(i => i.Id == dto.FinanceCompanyId) :
                    null;

                entity.Source = dto.SourceDealershipId.HasValue ?
                    this.RepositoryDealership.FirstOrDefault(i => i.Id == dto.SourceDealershipId) :
                    null;

                commitAction = RepositoryDeal.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }

        public static Deal MintNewDeal_InSession(CounterStoreService counterStoreService
            , DealDto dto, Customer customer)
        {
            var entity = dto.ToEntity();

            //Set the customer
            entity.Customer = customer;

            //Set the last deal
            entity.Customer.LastDeal = entity;

            //Get a customer number. We need the current count for this
            var currentCount = counterStoreService.GetCurrentCounterDeal();
            entity.Number = ReferenceGenerator.GetNextDealNumber(currentCount + 1);
            counterStoreService.IntcrementCounterDeal_InSession();

            return entity;
        }

        public new CommitResult Delete(Guid id)
        {
            var entity = this.RepositoryGeneric
                .AllQueryable()
                .Include(i => i.Customer)
                .FirstOrDefault(i => i.Id == id);

            var commitAction = CommitAction.None;

            if (entity == null)
                return new CommitResult();

            var commitResult = UnitOfWork.Commit(() =>
            {
                if (entity.Customer != null)
                {
                    entity.Customer.LastDeal = null;
                    this.RepositoryCustomer.Update(entity.Customer);
                }
                
                this.RepositoryGeneric.Delete(entity);
                commitAction = CommitAction.Delete;
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}