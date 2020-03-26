namespace AutomationTestSiiFramework.Tests.TheInternet.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveNewLines(this string text)
        {
            return text.Replace("\r\n", "");
        }
    }
}