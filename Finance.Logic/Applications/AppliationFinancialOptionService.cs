using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Applications
{
    public class AppliationFinancialOptionService : GenericService<AppliationFinancial>
    {
        public AppliationFinancialOptionService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public AppliationFinancialOptionDto Get(Guid id)
        {
            var entity = this.RepositoryAppliationFinancialOption.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new AppliationFinancialOptionDto(entity);
        }

        public List<AppliationFinancialOptionDto> GetAll()
        {
            return this.RepositoryAppliationFinancialOption.AllList().Select(i => new AppliationFinancialOptionDto(i)).ToList();
        }

        public CommitResult Save(AppliationFinancialOptionDto dto)
        {
            var commitAction = CommitAction.None;
            AppliationFinancialOption entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryAppliationFinancialOption.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                    entity = dto.ToEntity();
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryAppliationFinancialOption.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}