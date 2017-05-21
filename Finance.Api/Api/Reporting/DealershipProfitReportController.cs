using System;
using System.Collections.Generic;
using System.Web.Http;
using Finance.Api.Api.@base;
using Finance.Logic.Reporting;
using Finance.Logic.Reporting.Models;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Api.Api.Reporting
{
    [Route("api/DealershipProfitReport")]
    public class DealershipProfitReportController : BaseController
    {
        private DealershipProfitReportService _dealershipProfitReportService;
        protected DealershipProfitReportService DealershipProfitReportService => 
            _dealershipProfitReportService ?? (_dealershipProfitReportService = new DealershipProfitReportService(_persistanceFactory));

        public DealershipProfitReportController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
            
        }
        
        [HttpGet]
        public List<DealershipProfitReportResult> RunReport(int monthValue, int yearValue)
        {
            var startDate = new DateTime(yearValue, monthValue, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return this.DealershipProfitReportService.RunReport(startDate, endDate);
        }
    }
}