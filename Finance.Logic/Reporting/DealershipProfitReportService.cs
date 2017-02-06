using System;
using System.Collections.Generic;
using System.Linq;
using Finance.Logic.Reporting.Models;
using Finance.Logic.Shared;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Logic.Reporting
{
    public class DealershipProfitReportService : BaseService
    {
        public DealershipProfitReportService(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {

        }

        public List<DealershipProfitReportResult> RunReport(DateTime? startDate, DateTime? endDate)
        {
            var response = new List<DealershipProfitReportResult>();
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

            var allResults = queryable.Select(i => new DealershipProfitReportResult
            {
                DealershipId = i.Source.Id,
                DealershipName = i.Source.Name,
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

            var distinctDealershipIds = allResults.Select(i => i.DealershipId).Distinct().ToList();

            foreach (var distinctDealershipId in distinctDealershipIds)
            {
                var filteredResults = allResults.Where(i => i.DealershipId == distinctDealershipId).ToList();
                string dealershipName = allResults.First(i => i.DealershipId == distinctDealershipId).DealershipName;
                
                response.Add(Build(distinctDealershipId, dealershipName, false, filteredResults));
            }

            //Order by DealershipName
            response = response.OrderBy(i => i.DealershipName).ToList();

            //Add a total value
            response.Add(Build(null, "Total", true, allResults));

            return response;
        }

        private static DealershipProfitReportResult Build(Guid? dealershipId, string dealershipName, bool isTotal,
            List<DealershipProfitReportResult> filteredResults)
        {
            return new DealershipProfitReportResult
            {
                DealershipId = dealershipId,
                DealershipName = dealershipName,
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
