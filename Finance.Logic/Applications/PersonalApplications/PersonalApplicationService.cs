using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Finance.Logic.Counting;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Finance.Logic.GenericClasses;
using Finance.Logic.Helpers;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;
using Newtonsoft.Json;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplicationService : GenericService<PersonalApplication>
    {
        private CounterStoreService _counterStoreService;

        public CounterStoreService CounterStoreService
            => _counterStoreService ?? (_counterStoreService = new CounterStoreService(this.PersistanceFactory));

        public PersonalApplicationService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        private IQueryable<PersonalApplication> GetPersonalApplicationQuery()
        {
            return this.RepositoryPersonalApplication
                .AllQueryable();
        }

        public PersonalApplicationDetails GetPersonalApplicationDetails(Guid id)
        {
            var queryResult = this.GetPersonalApplicationQuery()
                .Include(i => i.Customer)
                .Include(i => i.Deal)
                .Where(i => i.Id == id)
                .Select(i => 
                new {
                    i.JsonData
                    , CustomerId = i.Customer == null ? null : (Guid?)i.Customer.Id
                    , DealId = i.Deal == null ? null : (Guid?)i.Deal.Id
                })
                .FirstOrDefault();

            if (queryResult == null) return null;

            var forms = this.RepositoryPersonalApplicationForm
                .AllQueryable()
                .Where(i => i.PersonalApplication.Id == id)
                .OrderBy(i => i.DateCreated)
                .Select(i => new PersonalApplicationFormItem
                {
                    Id = i.Id, FormType = i.FormType
                }).ToList();

            dynamic deserialized = JsonConvert.DeserializeObject(queryResult.JsonData);

            deserialized.Id = id; //Set the id
            
            return new PersonalApplicationDetails
            {
                CustomerId = queryResult.CustomerId,
                DealId = queryResult.DealId,
                JsonData = deserialized,
                Forms = forms
            };
        }

        public List<PersonalApplicationStatusOption> GetPersonalApplicaitionStatusOptions()
        {
            var intValueDescriptions = new List<PersonalApplicationStatusOption>();

            foreach (var status in EnumHelper.EnumToList<PersonalApplicationStatus>())
            {
                intValueDescriptions.Add(new PersonalApplicationStatusOption
                {
                    Value = (int)status,
                    Description = status.GetDescription(),
                    IsDefault = status == PersonalApplicationStatus.Received
                });
            }

            return intValueDescriptions;
        }

        public CommitResult Save(PersonalApplicationSaveRequest saveRequest)
        {
            var commitAction = CommitAction.None;
            PersonalApplication entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = saveRequest.Id.HasValue
                    ? this.RepositoryPersonalApplication
                        .AllQueryable()
                        .Include(i=>i.Customer)
                        .Include(i => i.Deal)
                        .FirstOrDefault(i => i.Id == saveRequest.Id)
                    
                    : null;

                //Create a new object if needed
                if (entity == null)
                {
                    entity = new PersonalApplication();
                    
                    //Get a number. We need the current count for this
                    var currentCount = CounterStoreService.GetCurrentCounterPersonalApplication();

                    entity.Number = ReferenceGenerator.GetNextPersonalApplicationNumber(currentCount);
                    CounterStoreService.IntcrementCounterPersonalApplication_InSession();
                }

                var customerSaveRequired = false;

                //Create a new customer if needed
                if (new List<PersonalApplicationStatus>
                {
                    PersonalApplicationStatus.Completed,
                    PersonalApplicationStatus.Submitted,
                    PersonalApplicationStatus.Approved,
                    PersonalApplicationStatus.Declined
                }.Contains(saveRequest.Status))
                {
                    var customerDtoDto = new CustomerDto
                    {
                        FirstName = saveRequest.FirstName,
                        LastName = saveRequest.LastName,
                        MiddleName = saveRequest.MiddleName,

                        //Ugh, yes, naming convension inconsistencies born out of customer changes
                        MobileNumber = saveRequest.MobilePhoneNumber,
                        PhoneNumber = saveRequest.HomePhoneNumber,
                        Email = saveRequest.PersonalEmail
                    };

                    //Ensure that there is a customer
                    if (entity.Customer == null)
                        entity.Customer = CustomerService.MintNewCustomer_InSession(CounterStoreService, customerDtoDto);
                    else
                        customerDtoDto.UpdateEntity(entity.Customer);

                    customerSaveRequired = true;
                }

                //Create a new deal if needed
                if (new List<PersonalApplicationStatus>
                {
                    PersonalApplicationStatus.Approved
                }.Contains(saveRequest.Status))
                {
                    var dealDtoDto = new DealDto
                    {
                        DealStatus = DealStatus.SettledPaid
                    };

                    //Ensure that there is a deal
                    if (entity.Deal == null)
                    {
                        entity.Deal = DealService.MintNewDeal_InSession(CounterStoreService, dealDtoDto, entity.Customer);
                        commitAction = RepositoryDeal.Save(entity.Deal);
                    }
                    //(we only create, no update needed)
                }

                //Save the customer later as minting a new deal can alter it
                if(customerSaveRequired)
                    commitAction = RepositoryCustomer.Save(entity.Customer);

                //Update for any changes
                entity.Status = saveRequest.Status;
                entity.JsonData = saveRequest.JsonData;
                entity.SchemaVersion = saveRequest.SchemaVersion;

                entity.FirstName = saveRequest.FirstName;
                entity.PreferredName = saveRequest.PreferredName;
                entity.MiddleName = saveRequest.MiddleName;
                entity.LastName = saveRequest.LastName;
                entity.MobilePhoneNumber = saveRequest.MobilePhoneNumber;
                entity.HomePhoneNumber = saveRequest.HomePhoneNumber;
                entity.LicenceNumberSa = saveRequest.LicenceNumberSa;
                entity.PersonalEmail = saveRequest.PersonalEmail;
                entity.BusinessEmail = saveRequest.BusinessEmail;

                commitAction = RepositoryPersonalApplication.Save(entity);
            });
            
            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            //We want to send back the number also
            commitResult.Data.Add("Number", entity.Number);

            return commitResult;
        }
    }
}