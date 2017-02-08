using System.ComponentModel;

namespace Finance.Logic.FinanceCompanies
{
    /// <summary>
    /// The tier of a finance company
    /// </summary>
    public enum TierFunder
    {
        [Description("Unspecified")]
        None = 0,

        [Description("First Tier Funder")]
        FirstTier = 1,

        [Description("Second Tier Funder")]
        SecondTier = 2
    }
}
