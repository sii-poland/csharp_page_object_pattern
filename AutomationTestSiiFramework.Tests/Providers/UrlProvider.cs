using System;
using AutomationTestSiiFramework.Helpers;

namespace AutomationTestSiiFramework.Tests.Providers
{
    public class UrlProvider
    {
        private static Uri BaseUrl => new Uri(TestSettings.ConfigurationJson.ShopAppUrl);
        public static Uri Home => BaseUrl;
        public static Uri Cart => new Uri(BaseUrl, "cart?action=show");
    }
}