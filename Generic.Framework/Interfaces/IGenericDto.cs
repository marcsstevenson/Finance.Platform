using System;
using Generic.Framework.Interfaces.Entity;

namespace Generic.Framework.Interfaces
{
    public interface IGenericDto<E> : IGuidNullableId, ITracksTime where E : IEntity
    {
        E ToEntity();
        void UpdateEntity(E entity);
    }
}