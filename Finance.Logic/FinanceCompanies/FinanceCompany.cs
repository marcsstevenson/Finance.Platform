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


        #region 1:1 Relationship
        public virtual AccountManager AccountManager { get; set; }
        #endregion
    }
}
