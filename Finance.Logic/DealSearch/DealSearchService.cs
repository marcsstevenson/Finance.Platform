using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Generic.Framework.Interfaces.Entity;
using Finance.Logic.Shared;
using Finance.Logic.Deals;

namespace Finance.Logic.DealSearch
{
    public class DealSearchService
    {
        private IPersistanceFactory _persistanceFactory;
        private IRepository<Deal> _repositoryDeal;

        private IRepository<Deal> DealRepository
            => _repositoryDeal ?? (_repositoryDeal = _persistanceFactory.BuildEntityRepository<Deal>());

        public DealSearchService(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }

        public DealSearchResponse Search(DealSearchRequest request)
        {
            var query = DealRepository.AllQueryable();
            Expression<Func<Deal, string>> orderByKeySelector = null;
            Expression<Func<Deal, string>> thenByKeySelector = null;

            var totalResultCount = query.Count();

            query = query.Include(i => i.Customer);

            SetOrderSelector(request, orderByKeySelector, thenByKeySelector);

            AddOrderToQuery(request, query, orderByKeySelector, thenByKeySelector);

            BuildQuery(request, query);

            if (request.CurrentPage > totalResultCount / request.PageSize + 1)
                request.CurrentPage = 1;

            var searchResults = query.Select(i => new DealSearchResponseItem
            {
                Id = i.Id,
                Number = i.Number,
                DealStatus = i.DealStatus,
                DateCreated = i.DateCreated,
                DateModified = i.DateModified
            })
            .Skip(request.PageSize * (request.CurrentPage - 1))
            .Take(request.PageSize).ToList();

            var response = new DealSearchResponse
            {
                SearchResults =searchResults,
                CurrentPage = request.CurrentPage,
                TotalPageCount = totalResultCount
            };

            response.SetTotalPageCount(request.PageSize);

            return response;

        }

        private void SetOrderSelector(DealSearchRequest request, 
            Expression<Func<Deal, string>> orderByKeySelector,
            Expression<Func<Deal, string>> thenByKeySelector)
        {
            switch (request.OrderBy.Trim())
            {
                case nameof(Deal.Number):
                    orderByKeySelector = i => i.Number;
                    break;
                case nameof(Deal.DealStatus):
                    orderByKeySelector = i => nameof(i.DealStatus);
                    break;

                case "CustomerName":
                    orderByKeySelector = i => i.Customer.FirstName;
                    thenByKeySelector = i => i.Customer.LastName;
                    break;

                default:
                    break;
            }
        }

        private void AddOrderToQuery(DealSearchRequest request, 
            IQueryable<Deal> query,
            Expression<Func<Deal, string>> orderByKeySelector,
            Expression<Func<Deal, string>> thenByKeySelector)
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

        private void BuildQuery(DealSearchRequest request, IQueryable<Deal> query)
        {
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(i =>
                i.Number.Contains(request.SearchTerm) ||
                (i.Customer.FirstName + " " + i.Customer.LastName).Contains(request.SearchTerm) ||
                nameof(i.DealStatus) == request.SearchTerm
                );
            }
        }

    }
}
