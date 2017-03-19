using System;
using System.Linq;
using System.Linq.Expressions;
using Generic.Framework.Interfaces.Entity;
using Finance.Logic.Shared;

namespace Finance.Logic.Configuration
{
    public class LeadOriginSearchService
    {
        private IPersistanceFactory _persistanceFactory;
        private IRepository<LeadOrigin> _repositoryDeal;

        private IRepository<LeadOrigin> DealRepository
            => _repositoryDeal ?? (_repositoryDeal = _persistanceFactory.BuildEntityRepository<LeadOrigin>());

        public LeadOriginSearchService(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }

        public LeadOriginSearchResponse Search(LeadOriginSearchRequest request)
        {
            var query = DealRepository.AllQueryable();
            Expression<Func<LeadOrigin, string>> orderByKeySelector = null;
            Expression<Func<LeadOrigin, string>> thenByKeySelector = null;

            var totalResultCount = query.Count();

            SetOrderSelector(request, ref orderByKeySelector, ref thenByKeySelector);

            AddOrderToQuery(request, ref query, ref orderByKeySelector, ref thenByKeySelector);

            BuildQuery(request, ref query);

            if (request.CurrentPage > totalResultCount / request.PageSize + 1)
                request.CurrentPage = 1;

            var searchResults = query.Select(i => new LeadOriginSearchResponseItem
            {
                Id = i.Id,
                Name = i.Name,
                IsDefault = i.IsDefault
            })
            .Skip(request.PageSize * (request.CurrentPage - 1))
            .Take(request.PageSize).ToList();

            var response = new LeadOriginSearchResponse
            {
                SearchResults =searchResults,
                CurrentPage = request.CurrentPage,
                TotalResultCount = totalResultCount
            };

            response.SetTotalPageCount(request.PageSize);

            return response;
        }

        private void SetOrderSelector(LeadOriginSearchRequest request, 
            ref Expression<Func<LeadOrigin, string>> orderByKeySelector,
            ref Expression<Func<LeadOrigin, string>> thenByKeySelector)
        {
            switch (request.OrderBy.Trim())
            {
                case nameof(LeadOrigin.Name):
                    orderByKeySelector = i => i.Name;
                    break;
                case nameof(LeadOrigin.IsDefault):
                    orderByKeySelector = i => i.IsDefault.ToString();
                    break;

                default:
                    break;
            }
        }

        private void AddOrderToQuery(LeadOriginSearchRequest request, 
            ref IQueryable<LeadOrigin> query,
            ref Expression<Func<LeadOrigin, string>> orderByKeySelector,
            ref Expression<Func<LeadOrigin, string>> thenByKeySelector)
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

        private void BuildQuery(LeadOriginSearchRequest request, ref IQueryable<LeadOrigin> query)
        {
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(i =>
                i.Name.Contains(request.SearchTerm)
                );
            }
        }

    }
}
