using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestSiiFramework.Extensions.WebDriver
{
    public static class SelectExtension
    {
        public static void SelectByText(this IWebDriver driver, By by, string text)
        {
            driver.WaitForClickable(by);
            var selectElement = new SelectElement(driver.FindElement(by));
            selectElement.SelectByText(text);
        }

        public static void SelectByText(this IWebDriver driver, IWebElement element, string text)
        {
            driver.WaitForClickable(element);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }
    }
}