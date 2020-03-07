using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestSiiFramework.Extensions
{
    public static class SelectExtension
    {
        public static void SelectByText(this IWebDriver driver, By by, string text)
        {
            driver.WaitForClickable(by);
            var selectElement = new SelectElement(driver.FindElement(by));
            selectElement.SelectByText(text);
        }
    }
}