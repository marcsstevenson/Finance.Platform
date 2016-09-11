using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Finance.Logic.Shared;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.CustomerSearch
{
    public class CustomerSearchService
    {
        private IPersistanceFactory _persistanceFactory;
        private IRepository<Customer> _repositoryCustomer;

        private IRepository<Customer> CustomerRepository
            => _repositoryCustomer ?? (_repositoryCustomer = _persistanceFactory.BuildEntityRepository<Customer>());

        public CustomerSearchService(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }

        public CustomerSearchResponse Search(CustomerSearchRequest request)
        {
            var query = this.CustomerRepository.AllQueryable();
            Expression<Func<Customer, string>> orderByKeySelector = null;
            Expression<Func<Customer, string>> thenByByKeySelector = null;

            var totalResultCount = query.Count();

            //Include the last deal
            query = query.Include(i => i.LastDeal);

            switch (request.OrderBy.Trim())
            {
                case nameof(Customer.Number):
                    orderByKeySelector = i => i.Number;
                    break;
                case "Name":
                    orderByKeySelector = i => i.FirstName;
                    thenByByKeySelector = i => i.LastName;
                    break;
                case "Cell":
                    orderByKeySelector = i => i.CellNumber;
                    break;
                case nameof(Customer.DriversLicenceNumber):
                    orderByKeySelector = i => i.DriversLicenceNumber;
                    break;
                case nameof(Customer.Gender):
                    orderByKeySelector = i => i.Gender.ToString();
                    break;
                case nameof(Customer.LastDeal) + nameof(Deal.Number):
                    orderByKeySelector = i => nameof(Customer.LastDeal) + nameof(Deal.Number);
                    break;
                case nameof(Customer.DateCreated):
                    orderByKeySelector = i => i.DateCreated.ToString();
                    break;
                case nameof(Customer.DateModified):
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
                    (i.FirstName + " " + i.LastName).Contains(request.SearchTerm)
                    ||
                    i.Number.Contains(request.SearchTerm)
                    ||
                    i.CellNumber.Contains(request.SearchTerm)
                    ||
                    i.DriversLicenceNumber.Contains(request.SearchTerm)
                    ||
                    (i.LastDeal != null && i.LastDeal.Number.Contains(request.SearchTerm)
                    ||
                    i.Email.Contains(request.SearchTerm))
                );

            //if (!string.IsNullOrEmpty(request.NumberContains))
            //    query = query.Where(i => i.Number.Contains(request.NumberContains));

            //if (!string.IsNullOrEmpty(request.CellContains))
            //    query = query.Where(i => (i.CellArea + i.CellNumber).Contains(request.CellContains));

            //if (!string.IsNullOrEmpty(request.NumberContains))
            //    query = query.Where(i => i.DriversLicenceNumber.Contains(request.DriversLicenceNumberContains));
            
            var searchResults = query.Select(i => new CustomerSearchResponseItem
            {
                Id = i.Id,
                Number = i.Number,
                FirstName = i.FirstName,
                LastName = i.LastName,
                DriversLicenceNumber = i.DriversLicenceNumber,
                LastDealId = i.LastDeal == null ? null : (Guid?)i.LastDeal.Id,
                LastDealNumber = i.LastDeal == null ? null : i.LastDeal.Number,
                DateCreated = i.DateCreated,
                DateModified = i.DateModified
            })
            .Skip(request.PageSize * (request.CurrentPage - 1))
            .Take(request.PageSize).ToList();
            
            var response = new CustomerSearchResponse
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