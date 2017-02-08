using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.FinanceCompanies;
using Finance.Repository.Test.Base;
using Finance.Repository.Test.Helpers;
using Generic.Framework.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Repository.Test.FinanceCompanies
{
    [TestClass]
    public class FinanceCompanyServiceTest : BaseTest
    {
        public List<Guid> ToDeleteAccountManager = new List<Guid>();
        public List<Guid> ToDeleteFinanceCompany = new List<Guid>();
            
        [TestMethod]
        public void ANullResultShallBeObtained()
        {
            var test = this.FinanceCompanyService.Get(new Guid("BD293B08-1C80-4512-9158-8D7DA0CCFB92"));

            Assert.IsNull(test);
        }

        [TestMethod]
        public void NewFinanceCompanyShallSaveWithoutAccountManager()
        {
            //Setup
            var dto = new FinanceCompanyDto(){Name = "TestDelete"};

            //Exercise
            var saveCommitResult = this.FinanceCompanyService.Save(dto);

            //Verify
            saveCommitResult.AssertNoError();

            //Cleanup
            ToDeleteFinanceCompany.Add(saveCommitResult.CommitActions.First().Key.Id);
        }

        [TestMethod]
        public void NewFinanceCompanyShallSaveWithManager()
        {
            //Setup
            var accountManagerDto = new AccountManagerDto
            {
                FirstName = "Test", LastName = "Name", Gender = Gender.Male,
                Email = "e@mail.com"
            };

            //  ensure that we have an existing account manager
            var saveAccountManagerCommitResult = this.AccountManagerService.Save(accountManagerDto);
            saveAccountManagerCommitResult.AssertNoError();

            var financeCompanyDto = new FinanceCompanyDto
                { Name = "TestDelete", AccountManagerId = saveAccountManagerCommitResult.CommitActions.First().Key.Id};

            //Exercise
            var saveCommitResult = this.FinanceCompanyService.Save(financeCompanyDto);

            //Verify
            saveCommitResult.AssertNoError();

            //Cleanup
            ToDeleteFinanceCompany.Add(saveCommitResult.CommitActions.First().Key.Id);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            foreach (var id in ToDeleteAccountManager)
                this.AccountManagerService.Delete(id);

            foreach (var id in ToDeleteFinanceCompany)
                this.FinanceCompanyService.Delete(id);
        }
    }
}
