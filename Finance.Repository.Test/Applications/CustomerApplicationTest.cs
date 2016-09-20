using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Applications;
using Finance.Logic.Shared;
using Finance.Repository.Test.Base;
using Generic.Framework.Enumerations;
using Generic.Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Repository.Test.Applications
{
    [TestClass]
    public class CustomerApplicationTest : BaseTest
    {
        public List<Guid> ToDelete = new List<Guid>();
            
        [TestMethod]
        public void ANullResultShallBeObtained()
        {
            var test = this.CustomerApplicationService.Get(new Guid("BD293B08-1C80-4512-9158-8D7DA0CCFB92"));

            Assert.IsNull(test);
        }

        [TestMethod]
        public void CustomerApplicationShallErrorWithoutApplicant()
        {
            //Setup
            var dto = new CustomerApplicationDto();

            //Exercise
            var commitResult = this.CustomerApplicationService.Save(dto);

            //Verify
            Assert.IsNotNull(commitResult.Error);
        }


        [TestMethod]
        public void EmptyCustomerApplicationWithApplicantShallBeSavedWithEmptyData()
        {
            //Setup
            var dto = new CustomerApplicationDto
            {
                Applicant = new PersonalEntityDto()
            };

            //Exercise
            var commitResult = this.CustomerApplicationService.Save(dto);

            //Verify
            Assert.AreEqual(CommitAction.Add, commitResult.CommitActions.First().Value);

            //Cleanup
            ToDelete.Add(commitResult.CommitActions.First().Key.Id);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            foreach (var id in ToDelete)
                this.CustomerApplicationService.Delete(id);
        }
    }
}
