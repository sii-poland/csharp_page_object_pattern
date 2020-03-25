using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTestSiiFramework.Extensions.WebDriver
{
    public static class ScrollingExtension
    {
        public static void MoveToElement(this IWebDriver driver, By by)
        {
            var actions = new Actions(driver);
            driver.WaitForClickable(by);
            actions.MoveToElement(driver.FindElement(by)).Build().Perform();
        }

        public static void MoveToElement(this IWebDriver driver, IWebElement element)
        {
            var actions = new Actions(driver);
            driver.WaitForClickable(element);
            actions.MoveToElement(element).Build().Perform();
        }

        public static void MoveAndClick(this IWebDriver driver, By by)
        {
            driver.MoveToElement(by);
            driver.ClickOnElement(by);
        }
    }
}