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
    public class AccountManagerService : GenericService<AccountManager>
    {
        public AccountManagerService(IPersistanceFactory persistanceFactory)
            : base(persistanceFactory)
        { }

        public AccountManagerDto Get(Guid id)
        {
            var entity = this.RepositoryAccountManager.FirstOrDefault(i => i.Id == id);
            return entity == null ? null : new AccountManagerDto(entity);
        }

        public List<AccountManagerDto> GetAll()
        {
            return this.RepositoryAccountManager.AllList().Select(i => new AccountManagerDto(i)).ToList();
        }

        public CommitResult Save(AccountManagerDto dto)
        {
            var commitAction = CommitAction.None;
            AccountManager entity = null;

            var commitResult = UnitOfWork.Commit(() =>
            {
                entity = dto.Id.HasValue
                    ? this.RepositoryAccountManager.FirstOrDefault(i => i.Id == dto.Id)
                    : null;
                
                //Create a new object if needed
                if (entity == null)
                    entity = dto.ToEntity();
                else
                    //Update for any changes
                    dto.UpdateEntity(entity);
                
                commitAction = RepositoryAccountManager.Save(entity);

                //Set the track date fields on the view model
                dto.UpdateTracksTime(entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }
    }
}