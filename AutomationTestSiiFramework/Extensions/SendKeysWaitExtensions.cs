using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AutomationTestSiiFramework.Extensions
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
    }
}