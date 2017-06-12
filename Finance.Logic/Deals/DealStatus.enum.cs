using System.ComponentModel;

namespace Finance.Logic.Deals
{
    /// <summary>
    /// The status of a deal
    /// </summary>
    public enum DealStatus
    {

        [Description("Pending Sign Up")]
        PendingSignUp = 2,

        [Description("Pending Payout")]
        PendingPayout = 3,

        [Description("Settled /Paid")]
        SettledPaid = 4,

        [Description("Settled Awaiting Commission")]
        SettledAwaitingCommission = 5,
    }
}
