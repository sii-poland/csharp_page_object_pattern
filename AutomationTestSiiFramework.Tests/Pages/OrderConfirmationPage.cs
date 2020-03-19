using AutomationTestSiiFramework.Base;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement OrderSubtotalElement =>
            Driver.FindElement(By.CssSelector("#order-items tr:nth-child(1) td:nth-child(2)"));

        public string OrderSubtotal => OrderSubtotalElement.Text;
    }
}