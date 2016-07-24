using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Shared
{
    public interface IGenericDto<E> where E : IEntity
    {
        E ToEntity();
        void UpdateEntity(E entity);
    }
}