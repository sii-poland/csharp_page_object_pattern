using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AutomationTestSiiFramework.Extensions
{
    public static class ClickExtension
    {
        public static void ClickOnElement(this IWebDriver driver, By by)
        {
            driver.WaitForClickable(by);
            driver.ExecuteJavaScript("arguments[0].setAttribute('style', arguments[1]);", driver.FindElement(by),
                "border: 2px solid red");
            driver.FindElement(by).Click();
        }

        public static void ClickOnElement(this IWebDriver driver, IWebElement element)
        {
            driver.WaitForClickable(element);
            driver.ExecuteJavaScript("arguments[0].setAttribute('style', arguments[1]);", element,
                "border: 2px solid red");
            element.Click();
        }

        public static void Click(this IWebDriver driver, By by)
        {
            driver.ExecuteJavaScript("arguments[0].setAttribute('style', arguments[1]);", driver.FindElement(by),
                "border: 2px solid red");
            driver.FindElement(by).Click();
        }

        public static void ClickOnTextFromList(this IWebDriver driver, By by, string text)
        {
            driver.ExecuteJavaScript("arguments[0].setAttribute('style', arguments[1]);", driver.FindElement(by),
                "border: 2px solid red");
            driver.Wait().Until(x => x.FindElements(by).First().Text.ToLower() == text.ToLower());
            driver.FindElements(by).First(x => x.Text.ToLower() == text.ToLower()).Click();
        }
    }
}