using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement OrderSubtotalElement =>
            Driver.WaitAndFind(By.CssSelector("#order-items tr:nth-child(1) td:nth-child(2)"));

        public string OrderSubtotal => OrderSubtotalElement.Text;
    }
}