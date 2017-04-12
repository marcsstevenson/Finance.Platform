using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Counting;
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
            var jsonData = this.GetPersonalApplicationQuery()
                .Where(i => i.Id == id)
                .Select(i => i.JsonData)
                .FirstOrDefault();

            var forms = this.RepositoryPersonalApplicationForm
                .AllQueryable()
                .Where(i => i.PersonalApplication.Id == id)
                .OrderBy(i => i.DateCreated)
                .Select(i => new PersonalApplicationFormItem
                {
                    Id = i.Id, FormType = i.FormType
                }).ToList();

            dynamic deserialized = JsonConvert.DeserializeObject(jsonData);

            deserialized.Id = id; //Set the id
            
            return new PersonalApplicationDetails
            {
                JsonData = deserialized,
                Forms = forms
            };
        }

        //public List<NameValue> GetPersonalApplicaitionStatusOptions()
        //{
        //    //TODO when we know this list
        //    return new List<NameValue>();
        //}

        public CommitResult Save(PersonalApplicationSaveRequest saveRequest)
        {
            var commitAction = CommitAction.None;
            PersonalApplication entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = saveRequest.Id.HasValue
                    ? this.RepositoryPersonalApplication.FirstOrDefault(i => i.Id == saveRequest.Id)
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
                
                //Update for any changes
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