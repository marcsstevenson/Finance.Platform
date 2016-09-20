namespace Finance.Logic.Applications
{
    public static class AppliationFinancialTypeHelper
    {
        /// <summary>
        /// Returns if an AppliationFinancialType is considered a negative value on a balance sheet
        /// </summary>
        public static bool IsNegative(this AppliationFinancialType appliationFinancialType)
        {
            return appliationFinancialType == AppliationFinancialType.Expense ||
                   appliationFinancialType == AppliationFinancialType.Liability;
        }
    }
}