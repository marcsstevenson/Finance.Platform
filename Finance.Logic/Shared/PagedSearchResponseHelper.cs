using System;

namespace Finance.Logic.Shared
{
    public static class PagedSearchResponseHelper
    {
        public static void SetTotalPageCount<T>(this PagedSearchResponse<T> pagedSearchResponse, int pageSize)
        {
            pagedSearchResponse.TotalPageCount = pagedSearchResponse.TotalResultCount == 0 ? 1 : (int)Math.Ceiling((double)pagedSearchResponse.TotalResultCount / pageSize);
        }
    }
}
