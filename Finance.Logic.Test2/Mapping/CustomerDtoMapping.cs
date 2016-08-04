using Finance.Logic.Crm;
using Xunit;

namespace Finance.Logic.Test.Mapping
{
    public class CustomerDtoMapping
    {
        [Fact]
        public void CustomerDtoShallConstrucWithoutException()
        {
            //Setup
            Customer entity = new Customer() {FirstName = "Bob"};

            //Exercise
            var dto = new CustomerDto(entity);

            //Verify
            Assert.Equal(entity.FirstName, dto.FirstName);
        }
    }

}