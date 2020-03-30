using System;
using AutomationTestSiiFramework.Helpers;

namespace AutomationTestSiiFramework.Tests.TheInternet.Providers
{
    public class UrlProvider
    {
        private static Uri BaseUrl => new Uri(Configuration.Environment.ApplicationUrl);
        public static Uri Login => new Uri(BaseUrl, "login");
    }
}