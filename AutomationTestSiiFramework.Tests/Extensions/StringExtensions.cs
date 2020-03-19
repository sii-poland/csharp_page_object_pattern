using System.Globalization;

namespace AutomationTestSiiFramework.Tests.Extensions
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

        public static string RemoveNewLines(this string text)
        {
            return text.Replace("\r\n", "");
        }
    }
}