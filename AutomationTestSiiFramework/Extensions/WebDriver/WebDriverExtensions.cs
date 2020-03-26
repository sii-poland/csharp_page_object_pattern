using System;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Extensions.WebDriver
{
    public static class WebDriverExtensions
    {
        public static void Open(this IWebDriver driver, Uri url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void Open(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}