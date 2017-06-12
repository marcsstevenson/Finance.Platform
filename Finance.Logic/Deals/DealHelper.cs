namespace Finance.Logic.Deals
{
    public static class DealHelper
    {
        public static bool StatusIsSettled(DealStatus dealStatus)
        {
            return dealStatus == DealStatus.SettledAwaitingCommission || dealStatus == DealStatus.SettledPaid;
        }
    }
}
