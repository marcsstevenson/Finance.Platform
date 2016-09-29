using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Generic.Framework.Interfaces.Entity;
using Finance.Logic.Shared;
using Finance.Logic.Crm;

namespace Finance.Logic.DealershipSearch
{
    public class DealershipSearchService
    {
        private IPersistanceFactory _persistanceFactory;
        private IRepository<Dealership> _repositoryDeal;

        private IRepository<Dealership> DealRepository
            => _repositoryDeal ?? (_repositoryDeal = _persistanceFactory.BuildEntityRepository<Dealership>());

        public DealershipSearchService(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }

        public DealershipSearchResponse Search(DealershipSearchRequest request)
        {
            var query = DealRepository.AllQueryable();
            Expression<Func<Dealership, string>> orderByKeySelector = null;
            Expression<Func<Dealership, string>> thenByKeySelector = null;

            var totalResultCount = query.Count();

            SetOrderSelector(request, orderByKeySelector, thenByKeySelector);

            AddOrderToQuery(request, query, orderByKeySelector, thenByKeySelector);

            BuildQuery(request, query);

            if (request.CurrentPage > totalResultCount / request.PageSize + 1)
                request.CurrentPage = 1;

            var searchResults = query.Select(i => new DealershipSearchResponseItem
            {
                Id = i.Id,
                Name = i.Name,
                ContactName = i.ContactName,
                CellNumber = i.CellNumber,
                PhoneNumber = i.PhoneNumber,
                Email = i.Email
            })
            .Skip(request.PageSize * (request.CurrentPage - 1))
            .Take(request.PageSize).ToList();

            var response = new DealershipSearchResponse
            {
                SearchResults =searchResults,
                CurrentPage = request.CurrentPage,
                TotalPageCount = totalResultCount
            };

            response.SetTotalPageCount(request.PageSize);

            return response;
        }

        private void SetOrderSelector(DealershipSearchRequest request, 
            Expression<Func<Dealership, string>> orderByKeySelector,
            Expression<Func<Dealership, string>> thenByKeySelector)
        {
            switch (request.OrderBy.Trim())
            {
                case nameof(Dealership.Name):
                    orderByKeySelector = i => i.Name;
                    break;
                case nameof(Dealership.ContactName):
                    orderByKeySelector = i => i.ContactName;
                    break;
                case nameof(Dealership.PhoneNumber):
                    orderByKeySelector = i => i.PhoneNumber;
                    break;
                case nameof(Dealership.CellNumber):
                    orderByKeySelector = i => i.CellNumber;
                    break;
                case nameof(Dealership.Email):
                    orderByKeySelector = i => i.Email;
                    break;

                default:
                    break;
            }
        }

        private void AddOrderToQuery(DealershipSearchRequest request, 
            IQueryable<Dealership> query,
            Expression<Func<Dealership, string>> orderByKeySelector,
            Expression<Func<Dealership, string>> thenByKeySelector)
        {
            if (orderByKeySelector != null)
            {
                if (thenByKeySelector == null)
                {
                    query = request.OrderByAscending ?
                        query.OrderBy(orderByKeySelector) :
                        query.OrderByDescending(orderByKeySelector);
                }
                else
                {
                    query = request.OrderByAscending ?
                        query.OrderBy(orderByKeySelector).ThenBy(thenByKeySelector) :
                        query.OrderByDescending(orderByKeySelector).ThenByDescending(thenByKeySelector);
                }
            }
        }

        private void BuildQuery(DealershipSearchRequest request, IQueryable<Dealership> query)
        {
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(i =>
                i.Name.Contains(request.SearchTerm) ||
                i.ContactName.Contains(request.SearchTerm) ||
                i.PhoneNumber.Contains(request.SearchTerm) ||
                i.CellNumber.Contains(request.SearchTerm) ||
                i.Email.Contains(request.SearchTerm)
                );
            }
        }

    }
}
