using AutoMapper;
using AutoMapper.Configuration;
using Finance.Logic.Crm;
using Finance.Logic.Mappings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Logic.Test.Mapping
{
    [TestClass]
    public class CustomerDtoMapping
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void CustomerDtoShallConstrucWithoutException()
        {
            //Setup
            Customer entity = new Customer() { FirstName = "Bob" };

            //Exercise
            var dto = new CustomerDto(entity);

            //Mapper.Map(entity, this);

            //Verify
            Assert.AreEqual(entity.FirstName, dto.FirstName);
        }

        [TestMethod]
        public void ToEntityShallCallWithoutException()
        {
            //Setup

            CustomerDto dto = new CustomerDto()
            {
                FirstName = "Bob"
            };

            //Exercise

            var entity = new Customer();

            dto.UpdateEntity(entity);

            //Verify
            Assert.AreEqual(entity.FirstName, dto.FirstName);
        }
    }
}
