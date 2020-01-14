using OpenQA.Selenium;

namespace SiiFramework.Extensions
{
    public static class SendKeysWaitExtensions
    {
        public static void SendKeysWithWait(this IWebDriver driver, By by, string text)
        {
            driver.WaitForClickable(by);
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(text);
        }
    }
}