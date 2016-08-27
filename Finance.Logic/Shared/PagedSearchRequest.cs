namespace Finance.Logic.Shared
{
    public abstract class PagedSearchRequest
    {
        public int PageSize { get; set; } = 50;
        public int CurrentPage { get; set; } = 1;
        public string OrderBy { get; set; }
        public bool OrderByAscending { get; set; } = true;
    }
}
