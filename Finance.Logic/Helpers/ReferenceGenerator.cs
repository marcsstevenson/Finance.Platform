using System;

namespace Finance.Logic.Helpers
{
    public static class ReferenceGenerator
    {
        public static string GetNextCustomerNumber(int currentCount)
        {
            return Generate("CU", currentCount + 1, 7);
        }

        public static string GetNextDealNumber(int currentCount)
        {
            return Generate("DE", currentCount + 1, 7);
        }

        public static string Generate(string prefix, int nextNumber, int minimumDigits)
        {
            if (prefix == null)
                throw new ArgumentNullException(nameof(prefix));

            if (nextNumber < 0)
                throw new InvalidOperationException("nextNumber <= 0");

            if (minimumDigits < 0)
                throw new InvalidOperationException("minimumDigits <= 0");

            string digitsFormatter = new string('0', minimumDigits);
            string digits = string.Format("{0:" + digitsFormatter + "}", nextNumber);
            return $"{prefix}{digits}";
        }
    }
}
