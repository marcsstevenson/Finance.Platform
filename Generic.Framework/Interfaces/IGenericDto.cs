using System;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Interfaces
{
    public interface IGenericDto<E> : IGuidNullableId, ITracksTimeNullable where E : IEntity
    {
        E ToEntity();
        void UpdateEntity(E entity);
    }
}