using System.Web.Http;
using Finance.Logic.Applications;
using Finance.Logic.Configuration;
using Finance.Logic.Crm;
using Finance.Logic.Deals;
using Finance.Logic.FinanceCompanies;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.@base
{
    public abstract class BaseController : ApiController
    {
        protected IPersistanceFactory _persistanceFactory;

        //private AccountManagerService _serviceAccountManager;
        //protected AccountManagerService AccountManagerService => _serviceAccountManager ?? (_serviceAccountManager = new AccountManagerService(_persistanceFactory));

        private AppliationFinancialOptionService _serviceAppliationFinancialOption;
        protected AppliationFinancialOptionService AppliationFinancialOptionService => _serviceAppliationFinancialOption ?? (_serviceAppliationFinancialOption = new AppliationFinancialOptionService(_persistanceFactory));

        private CustomerApplicationService _serviceCustomerApplication;
        protected CustomerApplicationService CustomerApplicationService => _serviceCustomerApplication ?? (_serviceCustomerApplication = new CustomerApplicationService(_persistanceFactory));

        private CustomerService _serviceCustomer;
        protected CustomerService CustomerService => _serviceCustomer ?? (_serviceCustomer = new CustomerService(_persistanceFactory));

        private CustomerNoteService _serviceCustomerNote;
        protected CustomerNoteService CustomerNoteService => _serviceCustomerNote ?? (_serviceCustomerNote = new CustomerNoteService(_persistanceFactory));

        private DealService _serviceDeal;
        protected DealService DealService => _serviceDeal ?? (_serviceDeal = new DealService(_persistanceFactory));

        private DealNoteService _serviceDealNote;
        protected DealNoteService DealNoteService => _serviceDealNote ?? (_serviceDealNote = new DealNoteService(_persistanceFactory));

        private DealershipService _serviceDealership;
        protected DealershipService DealershipService => _serviceDealership ?? (_serviceDealership = new DealershipService(_persistanceFactory));

        private DealershipNoteService _serviceDealershipNote;
        protected DealershipNoteService DealershipNoteService => _serviceDealershipNote ?? (_serviceDealershipNote = new DealershipNoteService(_persistanceFactory));

        private FinanceCompanyService _serviceFinanceCompany;
        protected FinanceCompanyService FinanceCompanyService => _serviceFinanceCompany ?? (_serviceFinanceCompany = new FinanceCompanyService(_persistanceFactory));

        private FinanceCompanyNoteService _serviceFinanceCompanyNote;
        protected FinanceCompanyNoteService FinanceCompanyNoteService => _serviceFinanceCompanyNote ?? (_serviceFinanceCompanyNote = new FinanceCompanyNoteService(_persistanceFactory));

        private LeadOriginService _serviceLeadOrigin;
        protected LeadOriginService LeadOriginService => _serviceLeadOrigin ?? (_serviceLeadOrigin = new LeadOriginService(_persistanceFactory));

        protected BaseController()
        {
        }

        protected BaseController(
            IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;

        }
    }
}
