using System;
using System.Linq;
using System.Linq.Expressions;
using Generic.Framework.Interfaces.Entity;
using Finance.Logic.Shared;
using Finance.Logic.FinanceCompanies;

namespace Finance.Logic.FinanceCompanySearch
{
    public class FinanceCompanySearchService
    {
        private IPersistanceFactory _persistanceFactory;
        private IRepository<FinanceCompany> _repositoryDeal;

        private IRepository<FinanceCompany> DealRepository
            => _repositoryDeal ?? (_repositoryDeal = _persistanceFactory.BuildEntityRepository<FinanceCompany>());

        public FinanceCompanySearchService(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }

        public FinanceCompanySearchResponse Search(FinanceCompanySearchRequest request)
        {
            var query = DealRepository.AllQueryable();
            Expression<Func<FinanceCompany, string>> orderByKeySelector = null;
            Expression<Func<FinanceCompany, string>> thenByKeySelector = null;

            var totalResultCount = query.Count();

            SetOrderSelector(request, ref orderByKeySelector, ref thenByKeySelector);

            AddOrderToQuery(request, ref query, ref orderByKeySelector, ref thenByKeySelector);

            BuildQuery(request, ref query);

            if (request.CurrentPage > totalResultCount / request.PageSize + 1)
                request.CurrentPage = 1;

            var searchResults = query.Select(i => new FinanceCompanySearchResponseItem
            {
                Id = i.Id,
                Name = i.Name,
                DateCreated = i.DateCreated,
                DateModified = i.DateModified
            })
            .Skip(request.PageSize * (request.CurrentPage - 1))
            .Take(request.PageSize).ToList();

            var response = new FinanceCompanySearchResponse
            {
                SearchResults =searchResults,
                CurrentPage = request.CurrentPage,
                TotalResultCount = totalResultCount
            };

            response.SetTotalPageCount(request.PageSize);

            return response;
        }

        private void SetOrderSelector(FinanceCompanySearchRequest request, 
            ref Expression<Func<FinanceCompany, string>> orderByKeySelector,
            ref Expression<Func<FinanceCompany, string>> thenByKeySelector)
        {
            switch (request.OrderBy.Trim())
            {
                case nameof(FinanceCompany.Name):
                    orderByKeySelector = i => i.Name;
                    break;
                default:
                    break;
            }
        }

        private void AddOrderToQuery(FinanceCompanySearchRequest request, 
            ref IQueryable<FinanceCompany> query,
            ref Expression<Func<FinanceCompany, string>> orderByKeySelector,
            ref Expression<Func<FinanceCompany, string>> thenByKeySelector)
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

        private void BuildQuery(FinanceCompanySearchRequest request, ref IQueryable<FinanceCompany> query)
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
