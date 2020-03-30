using System;
using AutomationTestSiiFramework.Helpers;

namespace AutomationTestSiiFramework.Tests.Shop.Providers
{
    public class UrlProvider
    {
        private static Uri BaseUrl => new Uri(Configuration.Environment.ApplicationUrl);
        public static Uri Home => BaseUrl;
        public static Uri Cart => new Uri(BaseUrl, "cart?action=show");
    }
}