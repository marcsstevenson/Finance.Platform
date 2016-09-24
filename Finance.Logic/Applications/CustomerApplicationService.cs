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

namespace Finance.Logic.Applications
{
    public class CustomerApplicationService : GenericService<CustomerApplication>
    {
        private CounterStoreService _counterStoreService;

        public CounterStoreService CounterStoreService
            => _counterStoreService ?? (_counterStoreService = new CounterStoreService(this.PersistanceFactory));

        public CustomerApplicationService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        private IQueryable<CustomerApplication> GetCustomerApplicationQuery()
        {
            return this.RepositoryCustomerApplication
                .AllQueryable()
                .Include(i => i.Applicant.CurrentAddress)
                .Include(i => i.Applicant.PreviousAddress)
                .Include(i => i.Applicant.NearestRelativeAddress)
                .Include(i => i.Spouce.CurrentAddress)
                .Include(i => i.Spouce.PreviousAddress)
                .Include(i => i.Spouce.NearestRelativeAddress);
        }

        public CustomerApplicationDto Get(Guid id)
        {
            var entity = this.GetCustomerApplicationQuery()
                .FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new CustomerApplicationDto(entity);
        }

        public PersonalEntityDto GetApplicant(Guid customerApplicationId)
        {
            var entity = this.GetCustomerApplicationQuery()
                .Where(i => i.Id == customerApplicationId)
                .Select(i => i.Applicant)
                .FirstOrDefault();
            return entity == null ? null : new PersonalEntityDto(entity);
        }

        public List<CustomerApplicationDto> GetAll()
        {
            return this.RepositoryCustomerApplication.AllList().Select(i => new CustomerApplicationDto(i)).ToList();
        }

        /// <summary>
        /// Save the applicant on an existing Customer Application
        /// </summary>
        public CommitResult SaveApplicant(Guid customerApplicationId, PersonalEntityDto dto)
        {
            var commitAction = CommitAction.None;
            CustomerApplication customerApplication = null;
            bool isNew = false;
            PersonalEntity entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                customerApplication = dto.Id.HasValue
                    ? this.RepositoryCustomerApplication.FirstOrDefault(i => i.Id == dto.Id)
                    : null;
                
                //Create a new object if needed
                if (customerApplication == null)
                    return;

                //Create a new object if needed
                if (customerApplication.Applicant == null)
                {
                    //Create new
                    entity = dto.ToEntity();
                    isNew = true;
                }
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                //Set the PersonalEntities
                if (isNew)
                {
                    customerApplication.Applicant = entity;
                    RepositoryCustomerApplication.Update(customerApplication);
                    RepositoryPersonalEntity.Add(entity);
                }
                else
                    RepositoryPersonalEntity.Update(entity);
                
                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }

        public CommitResult Save(CustomerApplicationDto dto)
        {
            var commitAction = CommitAction.None;
            CustomerApplication entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryCustomerApplication.FirstOrDefault(i => i.Id == dto.Id)
                    : null;
                
                //Create a new object if needed
                if (entity == null)
                {
                    entity = dto.ToEntity();
                    
                    //Get a customer number. We need the current count for this
                    var currentCount = CounterStoreService.GetCurrentCounterCustomer();
                    entity.Number = ReferenceGenerator.GetNextCustomerApplicationNumber(currentCount + 1);
                    CounterStoreService.IntcrementCounterCustomer_InSession();
                }
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);

                //Set the PersonalEntities
                var saveResponceApplicant = PersonalEntityService.Save(this.RepositoryPersonalEntity, this.RepositoryStreetAddress, dto.Applicant);
                if (saveResponceApplicant.Item1 != CommitAction.None)
                    entity.Applicant = saveResponceApplicant.Item2;

                var saveResponceSpouce = PersonalEntityService.Save(this.RepositoryPersonalEntity, this.RepositoryStreetAddress, dto.Spouce);
                if (saveResponceSpouce.Item1 != CommitAction.None)
                    entity.Spouce = saveResponceSpouce.Item2;
                
                commitAction = RepositoryCustomerApplication.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}