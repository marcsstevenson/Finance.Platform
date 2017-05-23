using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Reporting.Models;
using Finance.Logic.Shared;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Reporting
{
    public class FinanceCompanyProfitReportService : BaseService
    {
        public FinanceCompanyProfitReportService(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {

        }

        public List<FinanceCompanyProfitReportResult> RunReport(DateTime? startDate, DateTime? endDate)
        {
            var response = new List<FinanceCompanyProfitReportResult>();
            var queryable = this.RepositoryDeal.AllQueryable();

            if (startDate.HasValue)
            {
                startDate = startDate.Value.Date; //We want the start of the day
                queryable = queryable.Where(i => i.DateCreated >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                endDate = endDate.Value.Date.AddDays(1); //We want the day to be inclusive
                queryable = queryable.Where(i => i.DateCreated <= endDate);
            }

            var allResults = queryable.Select(i => new FinanceCompanyProfitReportResult
            {
                FinanceCompanyId = i.FinanceCompany.Id,
                FinanceCompanyName = i.FinanceCompany.Name,
                FinanceVolume = i.FinanceVolume,
                DealershipCommission = i.DealershipCommission,
                Commission = i.Commission,
                DocumentationFee = i.DocumentationFee,
                GuaranteedAssetProtection = i.GuaranteedAssetProtection,
                Insurance = i.Insurance,
                MechanicalBreakDownInsurance = i.MechanicalBreakDownInsurance,
                Other = i.Other,
                PaymentProtectionInsurance = i.PaymentProtectionInsurance
            }).ToList();

            var distinctFinanceCompanyIds = allResults.Select(i => i.FinanceCompanyId).Distinct().ToList();

            foreach (var distinctFinanceCompanyId in distinctFinanceCompanyIds)
            {
                var filteredResults = allResults.Where(i => i.FinanceCompanyId == distinctFinanceCompanyId).ToList();
                string dealershipName = allResults.First(i => i.FinanceCompanyId == distinctFinanceCompanyId).FinanceCompanyName;
                
                response.Add(Build(distinctFinanceCompanyId, dealershipName, false, filteredResults));
            }

            //Order by FinanceCompanyName
            response = response.OrderBy(i => i.FinanceCompanyName).ToList();

            //Add a total value
            response.Add(Build(null, "Total", true, allResults));

            return response;
        }

        private static FinanceCompanyProfitReportResult Build(Guid? dealershipId, string dealershipName, bool isTotal,
            List<FinanceCompanyProfitReportResult> filteredResults)
        {
            return new FinanceCompanyProfitReportResult
            {
                FinanceCompanyId = dealershipId,
                FinanceCompanyName = dealershipName,
                FinanceVolume = filteredResults.Sum(i => i.FinanceVolume),
                Commission = filteredResults.Sum(i => i.Commission),
                DocumentationFee = filteredResults.Sum(i => i.DocumentationFee),
                PaymentProtectionInsurance = filteredResults.Sum(i => i.PaymentProtectionInsurance),
                GuaranteedAssetProtection = filteredResults.Sum(i => i.GuaranteedAssetProtection),
                MechanicalBreakDownInsurance = filteredResults.Sum(i => i.MechanicalBreakDownInsurance),
                Insurance = filteredResults.Sum(i => i.Insurance),
                Other = filteredResults.Sum(i => i.Other),
                DealershipCommission = filteredResults.Sum(i => i.DealershipCommission),
                IsTotal = isTotal
            };
        }
    }
}
