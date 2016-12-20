using System;

namespace Generic.Framework.Interfaces
{
    public interface ITracksTimeNullable
    {
        DateTime? DateCreated { get; set; }

        DateTime? DateModified { get; set; }
    }
}