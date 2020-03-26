using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AutomationTestSiiFramework.Extensions.WebDriver
{
    public static class SendKeysWaitExtensions
    {
        public static void SendKeysWithWait(this IWebDriver driver, By by, string text)
        {
            driver.WaitForClickable(by);
            driver.ExecuteJavaScript("arguments[0].setAttribute('style', arguments[1]);", driver.FindElement(by),
                "border: 2px solid red");
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(text);
        }

        public static void SendKeysWithWait(this IWebDriver driver, IWebElement element, string text)
        {
            driver.WaitForClickable(element);
            driver.ExecuteJavaScript("arguments[0].setAttribute('style', arguments[1]);", element,
                "border: 2px solid red");
            element.Clear();
            element.SendKeys(text);
        }
    }
}