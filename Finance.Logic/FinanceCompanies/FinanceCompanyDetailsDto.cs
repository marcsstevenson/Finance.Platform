using System.Collections.Generic;

namespace Finance.Logic.FinanceCompanies
{
    public class FinanceCompanyDetailsDto
    {
        public FinanceCompanyDto FinanceCompanyDto { get; set; }
        public IList<AccountManagerDto> AccountManagers { get; set; }
    }
}
