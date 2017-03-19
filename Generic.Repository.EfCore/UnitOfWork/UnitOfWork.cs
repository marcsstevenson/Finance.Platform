using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Generic.Framework.Helpers;
using Generic.Framework.UnitOfWork;
using Generic.Repository.Ef.Helpers;

namespace Generic.Repository.Ef.UnitOfWork
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected ObjectContext ObjectContext
        {
            get { return _dbContext.GetObjectContext(); }
        }


        public CommitResult Commit(Action action)
        {
            try
            {
                action();

                ObjectContext.SaveChanges();

                return new CommitResult();
            }
            catch (Exception e)
            {
                return new CommitResult(e);
            }
        }

        public new void Dispose()
        {
            _dbContext.Dispose();
            base.Dispose();
        }
    }
}
