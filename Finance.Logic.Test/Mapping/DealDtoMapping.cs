using Finance.Logic.Deals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Logic.Test.Mapping
{
    [TestClass]
    public class DealDtoMapping
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void DealDtoShallConstrucWithoutException()
        {
            //Setup
            Deal entity = new Deal() { Commission = 1};

            //Exercise
            var dto = new DealDto(entity);

            //Mapper.Map(entity, this);

            //Verify
            Assert.AreEqual(entity.Commission, dto.Commission);
        }

        [TestMethod]
        public void ToEntityShallCallWithoutException()
        {
            //Setup

            DealDto dto = new DealDto()
            {
                Commission = 1
            };

            //Exercise

            var entity = new Deal();

            dto.UpdateEntity(entity);

            //Verify
            Assert.AreEqual(entity.Commission, dto.Commission);
        }
    }
}
