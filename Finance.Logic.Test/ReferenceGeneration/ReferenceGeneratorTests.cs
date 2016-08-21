using Finance.Logic.Crm;
using Finance.Logic.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Logic.Test.ReferenceGeneration
{
    [TestClass]
    public class ReferenceGeneratorTests
    {
        [TestMethod]
        public void CustomerDtoShallConstrucWithoutException()
        {
            //Exercise
            var reference = ReferenceGenerator.Generate("CU", 3, 4);
            
            //Verify
            Assert.AreEqual("CU0003", reference);
        }
    }
}
