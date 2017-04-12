using System;
using System.Linq;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;
using Newtonsoft.Json;

namespace Finance.Logic.Applications.PersonalApplicationForms
{
    public class PersonalApplicationFormService : GenericService<PersonalApplicationForm>
    {
        public PersonalApplicationFormService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        private IQueryable<PersonalApplicationForm> GetPersonalApplicationFormQuery()
        {
            return this.RepositoryPersonalApplicationForm
                .AllQueryable();
        }

        public dynamic GetJsonData(Guid id)
        {
            var jsonData = this.GetPersonalApplicationFormQuery()
                .Where(i => i.Id == id)
                .Select(i => i.JsonData)
                .FirstOrDefault();

            dynamic deserialized = JsonConvert.DeserializeObject(jsonData);

            deserialized.Id = id; //Set the id
            
            return deserialized;
        }

        public CommitResult Save(PersonalApplicationFormSaveRequest saveRequest)
        {
            var commitAction = CommitAction.None;
            PersonalApplicationForm entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = saveRequest.Id.HasValue
                    ? this.RepositoryPersonalApplicationForm.FirstOrDefault(i => i.Id == saveRequest.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                {
                    entity = new PersonalApplicationForm
                    {
                        //We must have a linked PersonalApplication
                        PersonalApplication =
                            this.RepositoryPersonalApplication.FirstOrDefault(
                                i => i.Id == saveRequest.PersonalApplicationId)
                    };
                    
                    if(entity.PersonalApplication == null)
                        throw new ArgumentException("There is no personal application for Id: " + saveRequest.PersonalApplicationId);

                    entity.FormType = saveRequest.FormType;
                }
                
                //Update for any changes
                entity.JsonData = saveRequest.JsonData;
                entity.SchemaVersion = saveRequest.SchemaVersion;

                commitAction = RepositoryPersonalApplicationForm.Save(entity);
            });
            
            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);
            
            return commitResult;
        }
    }
}