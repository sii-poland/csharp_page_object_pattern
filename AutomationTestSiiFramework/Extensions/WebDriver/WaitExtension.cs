using System;
using AutomationTestSiiFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationTestSiiFramework.Extensions.WebDriver
{
    public static class WaitExtension
    {
        public static WebDriverWait Wait(this IWebDriver driver)
        {
            return new WebDriverWait(driver,
                TimeSpan.FromSeconds(Configuration.WebDriver.DefaultTimeout));
        }

        public static void WaitForClickable(this IWebDriver driver, By by)
        {
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitForClickable(this IWebDriver driver, IWebElement element)
        {
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}