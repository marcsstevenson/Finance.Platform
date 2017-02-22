using Finance.Logic.Applications;
using Finance.Logic.FinanceCompanies;
using Finance.Repository.EfCore.IoC;
using Generic.Framework.Interfaces.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Repository.Test.Base
{
    [TestClass]
    public abstract class BaseTest
    {
        protected IPersistanceFactory PersistanceFactory = BootstrapperBase.GetPersistanceFactory();


        //private AccountManagerService _serviceAccountManager;
        //protected AccountManagerService AccountManagerService => _serviceAccountManager ?? (_serviceAccountManager = new AccountManagerService(this.PersistanceFactory));

        private CustomerApplicationService _customerApplicationService;
        public CustomerApplicationService CustomerApplicationService
            => _customerApplicationService
            ?? (_customerApplicationService = new CustomerApplicationService(this.PersistanceFactory));

        private FinanceCompanyService _serviceFinanceCompany;
        protected FinanceCompanyService FinanceCompanyService => _serviceFinanceCompany ?? (_serviceFinanceCompany = new FinanceCompanyService(PersistanceFactory));

        [TestInitialize]
        public void Initialise()
        {
            //As needed
        }
    }
}
