using System.Collections.Generic;
using Finance.Logic.Shared;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplicationSearchRequest : PagedSearchRequest
    {
        /// <summary>
        /// If the search results will be filtered by status. Null is no filter.
        /// </summary>
        public List<PersonalApplicationStatus> StatusFilters { get; set; }

        public string SearchTerm { get; set; }
    }
}
