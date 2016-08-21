using System;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Finance.Logic.FinanceCompanies;
using Finance.Logic.Internal;
using Generic.Framework.Interfaces.Entity;
using Generic.Framework.UnitOfWork;

namespace Finance.Logic.Shared
{
    public abstract class BaseService : IDisposable
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IPersistanceFactory PersistanceFactory;

        protected BaseService(IPersistanceFactory persistanceFactory)
        {
            UnitOfWork = persistanceFactory.BuildUnitOfWork();
            PersistanceFactory = persistanceFactory;
        }
        
        #region On demand repository objects

        private IEntityRepository<Customer> _repositoryCustomer;
        protected IEntityRepository<Customer> RepositoryCustomer
            => _repositoryCustomer ?? (_repositoryCustomer = PersistanceFactory.BuildEntityRepository<Customer>());
        
        private IEntityRepository<CustomerNote> _repositoryCustomerNote;
        protected IEntityRepository<CustomerNote> RepositoryCustomerNote
            => _repositoryCustomerNote ?? (_repositoryCustomerNote = PersistanceFactory.BuildEntityRepository<CustomerNote>());
        
        private IEntityRepository<Deal> _repositoryDeal;
        protected IEntityRepository<Deal> RepositoryDeal
            => _repositoryDeal ?? (_repositoryDeal = PersistanceFactory.BuildEntityRepository<Deal>());

        private IEntityRepository<DealNote> _repositoryDealNote;
        protected IEntityRepository<DealNote> RepositoryDealNote
            => _repositoryDealNote ?? (_repositoryDealNote = PersistanceFactory.BuildEntityRepository<DealNote>());

        private IEntityRepository<Dealership> _repositoryDealership;
        protected IEntityRepository<Dealership> RepositoryDealership
            => _repositoryDealership ?? (_repositoryDealership = PersistanceFactory.BuildEntityRepository<Dealership>());

        private IEntityRepository<DealershipNote> _repositoryDealershipNote;
        protected IEntityRepository<DealershipNote> RepositoryDealershipNote
            => _repositoryDealershipNote ?? (_repositoryDealershipNote = PersistanceFactory.BuildEntityRepository<DealershipNote>());

        private IEntityRepository<FinanceCompany> _repositoryFinanceCompany;
        protected IEntityRepository<FinanceCompany> RepositoryFinanceCompany
            => _repositoryFinanceCompany ?? (_repositoryFinanceCompany = PersistanceFactory.BuildEntityRepository<FinanceCompany>());

        private IEntityRepository<FinanceCompanyNote> _repositoryFinanceCompanyNote;
        protected IEntityRepository<FinanceCompanyNote> RepositoryFinanceCompanyNote
            => _repositoryFinanceCompanyNote ?? (_repositoryFinanceCompanyNote = PersistanceFactory.BuildEntityRepository<FinanceCompanyNote>());

        private IEntityRepository<StaffMember> _repositoryStaffMember;
        protected IEntityRepository<StaffMember> RepositoryStaffMember
            => _repositoryStaffMember ?? (_repositoryStaffMember = PersistanceFactory.BuildEntityRepository<StaffMember>());

        #endregion

        // Flag: Has Dispose already been called? 
        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                UnitOfWork.Dispose();
            }

            _disposed = true;
        }
    }
}