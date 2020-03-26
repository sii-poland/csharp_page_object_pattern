using System.Globalization;

namespace AutomationTestSiiFramework.Tests.Shop.Extensions
{
    public static class StringExtensions
    {
        public static decimal ToPrice(this string text)
        {
            return decimal.Parse(text, NumberStyles.Currency, new NumberFormatInfo
            {
                CurrencyDecimalSeparator = ".",
                CurrencyGroupSeparator = ",",
                CurrencySymbol = "$"
            });
        }
    }
}