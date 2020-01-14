using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SiiFramework.Extensions
{
    public static class WaitExtension
    {
        public static WebDriverWait Wait(this IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(TestSettings.DefaultTimeout));
        }

        public static void WaitForClickable(this IWebDriver driver, By by)
        {
            driver.Wait().Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitForDefineTextInElement(this IWebDriver driver, By by, string text)
        {
            driver.Wait().Until(x => x.FindElement(by).Text == text);
        }
    }
}