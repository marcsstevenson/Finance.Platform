using System;
using Finance.Logic.Crm;
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

        private IEntityRepository<Dealership> _repositoryDealership;

        protected IEntityRepository<Dealership> RepositoryDealership
            => _repositoryDealership ?? (_repositoryDealership = PersistanceFactory.BuildEntityRepository<Dealership>());

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