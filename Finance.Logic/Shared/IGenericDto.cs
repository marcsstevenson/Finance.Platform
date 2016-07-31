using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Shared
{
    public interface IGenericDto<E> where E : IEntity
    {
        //void Populate(E e);
        E ToEntity();
        void UpdateEntity(E entity);
    }
}