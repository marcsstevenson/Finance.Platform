using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public FinanceCompanyDetails Get(Guid id)
        {
            var entity = this.RepositoryFinanceCompany
                .AllQueryable()
                .Include(i => i.AccountManagers)
                .FirstOrDefault(i => i.Id == id);

            if (entity == null)
                return null;
            
            var financeCompanyDetailsDto = new FinanceCompanyDetails
            {
                FinanceCompany = new FinanceCompanyDto(entity),
                //We can manage more than one but will make it only one for now
                AccountManager = new AccountManagerDto(entity.AccountManagers.FirstOrDefault())
            };
            
            return financeCompanyDetailsDto;
        }

        public List<FinanceCompanyDto> GetAll()
        {
            return this.RepositoryFinanceCompany.AllList().Select(i => new FinanceCompanyDto(i)).ToList();
        }

        public CommitResult Save(FinanceCompanyUpdate financeCompanyUpdate)
        {
            if(financeCompanyUpdate?.FinanceCompany == null || financeCompanyUpdate.AccountManager == null)
                return new CommitResult(null, CommitAction.None);

            var dto = financeCompanyUpdate.FinanceCompany;
            var accountManagerDto = financeCompanyUpdate.AccountManager;

            var commitActionFinanceCompany = CommitAction.None;
            CommitActionItem commitActionItemAccountManager = null;
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

                commitActionFinanceCompany = RepositoryFinanceCompany.Save(entity);

                commitActionItemAccountManager = AccountManagerService.Save_InSession(this.RepositoryAccountManager,
                    accountManagerDto, entity);
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitActionFinanceCompany);

            if(commitActionItemAccountManager != null)
            commitResult.CommitActions.Add(commitActionItemAccountManager.Entity
                , commitActionItemAccountManager.CommitAction);

            return commitResult;
        }
    }
}