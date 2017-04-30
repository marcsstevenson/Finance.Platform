using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Finance.Logic.Deals;
using Finance.Logic.Shared;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Applications.PersonalApplications
{
    public class PersonalApplicationSearchService
    {
        private IPersistanceFactory _persistanceFactory;
        private IRepository<PersonalApplication> _repositoryPersonalApplication;

        private IRepository<PersonalApplication> PersonalApplicationRepository
            => _repositoryPersonalApplication ?? (_repositoryPersonalApplication = _persistanceFactory.BuildEntityRepository<PersonalApplication>());

        public PersonalApplicationSearchService(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }

        public PersonalApplicationSearchResponse Search(PersonalApplicationSearchRequest request)
        {
            var query = this.PersonalApplicationRepository.AllQueryable();
            Expression<Func<PersonalApplication, string>> orderByKeySelector = null;
            Expression<Func<PersonalApplication, string>> thenByByKeySelector = null;

            var totalResultCount = query.Count();
            
            switch (request.OrderBy.Trim())
            {
                case nameof(PersonalApplicationSearchResponseItem.Number):
                    orderByKeySelector = i => i.Number;
                    break;
                case nameof(PersonalApplicationSearchResponseItem.StatusDescription):
                    orderByKeySelector = i => i.Status.ToString();
                    break;
                case "Name":
                    orderByKeySelector = i => i.FirstName;
                    thenByByKeySelector = i => i.LastName;
                    break;
                case nameof(PersonalApplicationSearchResponseItem.MobilePhoneNumber):
                    orderByKeySelector = i => i.MobilePhoneNumber;
                    break;
                case nameof(PersonalApplicationSearchResponseItem.PersonalEmail):
                    orderByKeySelector = i => i.PersonalEmail;
                    break;
                case nameof(PersonalApplicationSearchResponseItem.DateCreated):
                    orderByKeySelector = i => i.DateCreated.ToString();
                    break;
                case nameof(PersonalApplicationSearchResponseItem.DateModified):
                    orderByKeySelector = i => i.DateModified.ToString();
                    break;
                default:
                    break;
            }

            if (orderByKeySelector != null)
            {
                if (thenByByKeySelector == null)
                    query = request.OrderByAscending ? 
                        query.OrderBy(orderByKeySelector) : 
                        query.OrderByDescending(orderByKeySelector);
                else
                    query = request.OrderByAscending ? 
                        query.OrderBy(orderByKeySelector).ThenBy(thenByByKeySelector) : 
                        query.OrderByDescending(orderByKeySelector).ThenByDescending(thenByByKeySelector);
            }

            //Has filter options changed and the current page need to be reset?
            if (request.CurrentPage > (int)(totalResultCount / request.PageSize) + 1)
                request.CurrentPage = 1;

            //Filter
            if (!string.IsNullOrEmpty(request.SearchTerm))
                query = query.Where(i =>
                    i.Number.Contains(request.SearchTerm)
                    ||
                    ((i.FirstName == null ? "" : i.FirstName) + " " + (i.LastName == null ? "" : i.LastName)).Contains(request.SearchTerm)
                    ||
                    (i.MobilePhoneNumber != null && i.MobilePhoneNumber.Contains(request.SearchTerm))
                    ||
                    (i.PersonalEmail != null && i.PersonalEmail.Contains(request.SearchTerm))
                );

            if (request.StatusFilters != null && request.StatusFilters.Any())
                query = query.Where(i => request.StatusFilters.Contains(i.Status));
            
           var searchResults = query.Select(i => new PersonalApplicationSearchResponseItem
            {
                Id = i.Id,
                Number = i.Number,
                Status = i.Status,
                FirstName = i.FirstName,
                PreferredName = i.PreferredName,
                LastName = i.LastName,
                MobilePhoneNumber = i.MobilePhoneNumber,
                PersonalEmail = i.PersonalEmail,
                DateCreated = i.DateCreated,
                DateModified = i.DateModified
            })
                .Skip(request.PageSize * (request.CurrentPage - 1))
                .Take(request.PageSize).ToList();
            
            var response = new PersonalApplicationSearchResponse
            {
                SearchResults = searchResults,
                CurrentPage = request.CurrentPage,
                TotalResultCount = totalResultCount
            };

            response.SetTotalPageCount(request.PageSize);

            return response;
        }
    }
}