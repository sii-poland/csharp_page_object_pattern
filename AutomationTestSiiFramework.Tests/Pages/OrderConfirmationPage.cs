using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public string OrderSubtotal =>
            driver.WaitAndFind(By.CssSelector("#order-items tr:nth-child(1) td:nth-child(2)")).Text;
        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }
    }
}