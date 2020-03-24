using System;
using AutomationTestSiiFramework.Extensions;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet
{
    public class UrlProvider
    {
        private static Uri BaseUrl => new Uri(TestSettings.ConfigurationJson.InternetAppUrl);
        public static Uri Home => BaseUrl;
        public static Uri Login => new Uri(BaseUrl, "login");
    }
}