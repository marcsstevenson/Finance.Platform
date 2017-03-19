using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Configuration
{
    public class LeadOriginService : GenericService<LeadOrigin>
    {
        public LeadOriginService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public LeadOriginDto Get(Guid id)
        {
            var entity = this.RepositoryLeadOrigin.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new LeadOriginDto(entity);
        }

        public List<LeadOriginDto> GetAll()
        {
            return this.RepositoryLeadOrigin.AllList().Select(i => new LeadOriginDto(i)).ToList();
        }

        public CommitResult Save(LeadOriginDto dto)
        {
            var commitAction = CommitAction.None;
            LeadOrigin entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryLeadOrigin.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                    entity = dto.ToEntity();
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryLeadOrigin.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            EnsureDefaultIsPopulated(dto.Id, dto.IsDefault);

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }

        public override CommitResult Delete(Guid id)
        {
            var commitResult = base.Delete(id);
            EnsureDefaultIsPopulated(null, false);
            return commitResult;
        }

        /// <summary>
        /// There needs to be a default - ensure this is the case
        /// </summary>
        public void EnsureDefaultIsPopulated(Guid? lastEdit, bool isDefaultValue)
        {
            UnitOfWork.Commit(() =>
            {
                var all = this.RepositoryLeadOrigin.AllList();
                var allIsDefault = all.Where(i => i.IsDefault).ToList();
                var countIsDefault = allIsDefault.Count;

                if(!all.Any()) return; //All hope is lost

                //Do we have one default?
                if (all.Count(i => i.IsDefault) == 1)
                    return;

                if (countIsDefault == 0)
                {
                    //Not good. Make the first default
                    var entity = all.First();

                    entity.IsDefault = true;
                    RepositoryLeadOrigin.Save(entity);
                }
                else
                {
                    //We must have more than 1
                    //  Was the last set to default?
                    if (lastEdit.HasValue && isDefaultValue)
                    {
                        //Make all others not default
                        foreach (var entity in all.Where(i => i.IsDefault && i.Id != lastEdit.Value))
                        {
                            entity.IsDefault = false;
                            RepositoryLeadOrigin.Save(entity);
                        }
                    }
                    else
                    {
                        //Make first default and others not
                        for (int i = 1; i < allIsDefault.Count; i++)
                        {
                            var entity = allIsDefault[i];
                            entity.IsDefault = false;
                            RepositoryLeadOrigin.Save(entity);
                        }
                    }
                }
            });
        }
    }
}