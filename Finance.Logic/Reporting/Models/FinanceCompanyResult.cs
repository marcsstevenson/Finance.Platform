using System;

namespace Finance.Logic.Reporting.Models
{
    public class FinanceCompanyProfitReportResult
    {
        public bool IsTotal { get; set; }
        public Guid? FinanceCompanyId { get; set; }
        public string FinanceCompanyName { get; set; }
        public decimal FinanceVolume { get; set; }
        public decimal Commission { get; set; }
        public decimal DocumentationFee { get; set; }
        public decimal PaymentProtectionInsurance { get; set; }
        public decimal GuaranteedAssetProtection { get; set; }
        public decimal MechanicalBreakDownInsurance { get; set; }
        public decimal Insurance { get; set; }
        public decimal Other { get; set; }
        public decimal DealershipCommission { get; set; }
    }
}
