using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        public string OrderSubtotal =>
            driver.WaitAndFind(By.CssSelector("#order-items tr:nth-child(1) td:nth-child(2)")).Text;
    }
}