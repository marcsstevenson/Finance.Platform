using System.ComponentModel;

namespace Finance.Logic.Deals
{
    /// <summary>
    /// The status of a deal
    /// </summary>
    public enum DealStatus
    {
        [Description("Settled /Paid")]
        SettledPaid = 0,

        [Description("Settled Awaiting Commission")]
        SettledAwaitingCommission = 1,

        [Description("Pending Sign Up")]
        PendingSignUp = 2,

        [Description("Pending Payout")]
        PendingPayout = 3
    }
}
