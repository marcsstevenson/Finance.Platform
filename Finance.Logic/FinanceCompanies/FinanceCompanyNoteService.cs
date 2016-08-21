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
    public class FinanceCompanyNoteService : GenericService<FinanceCompanyNote>
    {
        public FinanceCompanyNoteService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public FinanceCompanyNoteDto Get(Guid id)
        {
            var entity = this.RepositoryFinanceCompanyNote.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new FinanceCompanyNoteDto(entity);
        }

        public List<FinanceCompanyNoteDto> GetForFinanceCompany(Guid financeCompanyId)
        {
            //var test = this.RepositoryFinanceCompanyNote.Where(i => i.FinanceCompany.Id == customerId).ToList();

            return this.RepositoryFinanceCompanyNote.Where(i => i.FinanceCompany.Id == financeCompanyId).ToList().Select(i => new FinanceCompanyNoteDto(i)).ToList();
        }

        public CommitResult Save(FinanceCompanyNoteDto dto)
        {
            var commitAction = CommitAction.None;
            FinanceCompanyNote entity = null;
            
            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryFinanceCompanyNote.FirstOrDefault(i => i.Id == dto.Id)
                    : null;

                //Create a new object if needed
                if (entity == null)
                {
                    entity = dto.ToEntity();

                    //Link the FinanceCompany - required and unalterable
                    entity.FinanceCompany = this.RepositoryFinanceCompany.FirstOrDefault(i => i.Id == dto.FinanceCompanyId);
                }
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryFinanceCompanyNote.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}