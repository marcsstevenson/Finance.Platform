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

            BuildQuery(request, ref query);

            var totalResultCount = query.Count();

            query = query.Include(i => i.Customer);

            SetOrderSelector(request, ref orderByKeySelector, ref thenByKeySelector);

            AddOrderToQuery(request, ref query, ref orderByKeySelector, ref thenByKeySelector);

            if (request.CurrentPage > totalResultCount / request.PageSize + 1)
                request.CurrentPage = 1;

            var searchResults = query.Select(i => new DealSearchResponseItem
            {
                Id = i.Id,
                Number = i.Number,
                DealStatus = i.DealStatus,
                DateCreated = i.DateCreated,
                DateModified = i.DateModified,
                CustomerName = i.Customer.FirstName + " " + i.Customer.LastName
            })
            .Skip(request.PageSize * (request.CurrentPage - 1))
            .Take(request.PageSize).ToList();

            var response = new DealSearchResponse
            {
                SearchResults =searchResults,
                CurrentPage = request.CurrentPage,
                TotalResultCount = totalResultCount
            };

            response.SetTotalPageCount(request.PageSize);

            return response;

        }

        private void SetOrderSelector(DealSearchRequest request, 
            ref Expression<Func<Deal, string>> orderByKeySelector,
            ref Expression<Func<Deal, string>> thenByKeySelector)
        {
            switch (request.OrderBy.Trim())
            {
                case nameof(DealSearchResponseItem.Number):
                    orderByKeySelector = i => i.Number;
                    break;
                case nameof(DealSearchResponseItem.DealStatusDescription):
                    orderByKeySelector = i => nameof(i.DealStatus);
                    break;
                case nameof(DealSearchResponseItem.DateCreated):
                    orderByKeySelector = i => nameof(i.DateCreated);
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
            ref IQueryable<Deal> query,
            ref Expression<Func<Deal, string>> orderByKeySelector,
            ref Expression<Func<Deal, string>> thenByKeySelector)
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

        private void BuildQuery(DealSearchRequest request, ref IQueryable<Deal> query)
        {
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(i =>
                i.Customer.Number.Contains(request.SearchTerm) 
                ||
                i.Number.Contains(request.SearchTerm) 
                ||
                (i.Customer.FirstName + " " + i.Customer.LastName).Contains(request.SearchTerm) 
                //||
                //nameof(i.DealStatus) == request.SearchTerm 
                ||
                i.Customer.MobileNumber.Contains(request.SearchTerm)
                ||
                i.Customer.DriversLicenceNumber.Contains(request.SearchTerm)
                );
            }
        }

    }
}
