using System;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Shared
{
    public abstract class GenericService<E> : BaseService where E : Entity
    {
        private IEntityRepository<E> _repositoryGeneric;

        protected IEntityRepository<E> RepositoryGeneric
            => _repositoryGeneric ?? (_repositoryGeneric = PersistanceFactory.BuildEntityRepository<E>());
        
        protected GenericService(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {

        }
        
        public CommitResult Delete(Guid id)
        {
            var entity = this.RepositoryGeneric.FirstOrDefault(i => i.Id == id);
            
            var commitAction = CommitAction.None;

            if(entity == null)
                return new CommitResult();

            var commitResult = UnitOfWork.Commit(() =>
            {
                if (entity != null)
                {
                    this.RepositoryGeneric.Delete(entity);
                    commitAction = CommitAction.Delete;
                }
            });

            //Add the result to the commit actions
            commitResult.CommitActions.Add(entity, commitAction);

            return commitResult;
        }

        //public IGenericDto<E> Get<D>(Guid id) where D : class, IGenericDto<E>, new()
        //{
        //    var entity = this.RepositoryGeneric.FirstOrDefault(i => i.Id == id);

        //    if (entity == null)
        //        return null;

        //    var dto = new D();
        //    dto.Populate(entity);
        //    return dto;
        //}

    }
}