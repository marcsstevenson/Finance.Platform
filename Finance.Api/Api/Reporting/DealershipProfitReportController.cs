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
    [AllowAnonymous]
    public class DealershipProfitReportController : BaseController
    {
        private DealershipProfitReportService _dealershipProfitReportService;
        protected DealershipProfitReportService DealershipProfitReportService => 
            _dealershipProfitReportService ?? (_dealershipProfitReportService = new DealershipProfitReportService(_persistanceFactory));

        public DealershipProfitReportController(IPersistanceFactory persistanceFactory) : base(persistanceFactory)
        {
            
        }
        
        [HttpGet]
        public List<DealershipProfitReportResult> RunReport(DateTime? startDate, DateTime? endDate)
        {
            return this.DealershipProfitReportService.RunReport(startDate, endDate);
        }
    }
}