using System.ComponentModel;

namespace Finance.Logic.FinanceCompanies
{
    /// <summary>
    /// The status of a deal
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
