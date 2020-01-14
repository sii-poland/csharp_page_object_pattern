using System.Linq;
using OpenQA.Selenium;

namespace SiiFramework.Extensions
{
    public static class ClickExtension
    {
        public static void ClickOnElement(this IWebDriver driver, By by)
        {
            driver.WaitForClickable(by);
            driver.FindElement(by).Click();
        }

        public static void ClickOnTextFromList(this IWebDriver driver, By by, string text)
        {
            driver.Wait().Until(x => x.FindElements(by).First().Text == text);
            driver.FindElements(by).First(x => x.Text == text).Click();
        }
    }
}