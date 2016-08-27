using System.Collections.Generic;

namespace Finance.Logic.Shared
{
    public abstract class PagedSearchResponse<T>
    {
        public List<T> SearchResults { get; set; }

        public int TotalResultCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPageCount { get; set; }
    }
}
