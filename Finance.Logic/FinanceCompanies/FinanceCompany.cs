using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Finance.Logic.Crm;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;

namespace Finance.Logic.FinanceCompanies
{
    public class FinanceCompany : Entity, IName
    {
        [Required]
        public string Name { get; set; }

        public TierFunder TierFunder { get; set; }
        
        #region 1:M Relationship

        public virtual IList<AccountManager> AccountManagers { get; set; }

        public IList<FinanceCompanyNote> FinanceCompanyNotes { get; set; }

        #endregion
    }
}
