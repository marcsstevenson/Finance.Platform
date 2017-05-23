using System;
using System.Collections.Generic;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Reporting;
using Finance.Logic.Reporting.Models;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Reporting
{
    [Route("api/FinanceCompanyProfitReport")]
    public class FinanceCompanyProfitReportController : BaseController
    {
        private FinanceCompanyProfitReportService _financeCompanyProfitReportService;
        protected FinanceCompanyProfitReportService FinanceCompanyProfitReportService => 
            _financeCompanyProfitReportService ?? (_financeCompanyProfitReportService = new FinanceCompanyProfitReportService(_persistanceFactory));

        public FinanceCompanyProfitReportController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
            
        }
        
        [HttpGet]
        public List<FinanceCompanyProfitReportResult> RunReport(int monthValue, int yearValue)
        {
            var startDate = new DateTime(yearValue, monthValue, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return this.FinanceCompanyProfitReportService.RunReport(startDate, endDate);
        }
    }
}