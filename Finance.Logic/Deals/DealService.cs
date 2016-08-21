using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Crm;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Deals
{
    public class DealService : GenericService<Deal>
    {
        public DealService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public DealDto Get(Guid id)
        {
            var entity = this.RepositoryDeal.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new DealDto(entity);
        }

        public List<DealDto> GetForCustomer(Guid customerId)
        {
            //var test = this.RepositoryDeal.Where(i => i.Customer.Id == customerId).ToList();

            return this.RepositoryDeal.Where(i => i.Customer.Id == customerId).ToList().Select(i => new DealDto(i)).ToList();
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
                    entity = dto.ToEntity();

                    //Link the customer - required and unalterable
                    entity.Customer = this.RepositoryCustomer.FirstOrDefault(i => i.Id == dto.CustomerId);
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
    }
}