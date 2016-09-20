using Finance.Logic.Applications;
using Finance.Repository.EfCore.IoC;
using Generic.Framework.Interfaces.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Repository.Test.Base
{
    [TestClass]
    public abstract class BaseTest
    {
        protected IPersistanceFactory PersistanceFactory = BootstrapperBase.GetPersistanceFactory();

        private CustomerApplicationService _customerApplicationService;

        public CustomerApplicationService CustomerApplicationService
            => _customerApplicationService
            ?? (_customerApplicationService = new CustomerApplicationService(this.PersistanceFactory));

        [TestInitialize]
        public void Initialise()
        {
            //As needed
        }
    }
}
