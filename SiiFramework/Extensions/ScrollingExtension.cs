using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SiiFramework.Extensions
{
    public static class ScrollingExtension
    {
        public static void MoveToElement(this IWebDriver driver, By by)
        {
            var actions = new Actions(driver);
            driver.WaitForClickable(by);
            actions.MoveToElement(driver.FindElement(by)).Build().Perform();
        }

        public static void MoveAndClick(this IWebDriver driver, By by)
        {
            driver.MoveToElement(by);
            driver.ClickOnElement(by);
        }
    }
}