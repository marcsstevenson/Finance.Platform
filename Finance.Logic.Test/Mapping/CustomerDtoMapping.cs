using Finance.Logic.Crm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Logic.Test.Mapping
{
    [TestClass]
    public class CustomerDtoMapping
    {
        [TestMethod]
        public void CustomerDtoShallConstrucWithoutException()
        {
            //Setup
            Customer entity = new Customer() { FirstName = "Bob" };

            //Exercise
            var dto = new CustomerDto(entity);

            //Verify
            Assert.AreEqual(entity.FirstName, dto.FirstName);
        }
    }
}
