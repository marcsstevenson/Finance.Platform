using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Shared;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Helpers.Interfaces;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.FinanceCompanies
{
    public class FinanceCompanyService : GenericService<FinanceCompany>
    {
        public FinanceCompanyService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public FinanceCompanyDto Get(Guid id)
        {
            var entity = this.RepositoryFinanceCompany.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new FinanceCompanyDto(entity);
        }

        public List<FinanceCompanyDto> GetAll()
        {
            return this.RepositoryFinanceCompany.AllList().Select(i => new FinanceCompanyDto(i)).ToList();
        }

        public CommitResult Save(FinanceCompanyDto dto)
        {
            var commitAction = CommitAction.None;
            FinanceCompany entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryFinanceCompany.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                    entity = dto.ToEntity();
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryFinanceCompany.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}