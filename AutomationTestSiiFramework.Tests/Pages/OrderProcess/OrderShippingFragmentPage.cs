using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderShippingFragmentPage : BasePage
    {
        public OrderShippingFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement ConFirmDeliveryOptionElement => Driver.WaitAndFind(By.Name("confirmDeliveryOption"));

        public OrderPaymentMethodFragmentPage FillShippingMethod()
        {
            Driver.ClickOnElement(ConFirmDeliveryOptionElement);
            return new OrderPaymentMethodFragmentPage(Driver);
        }
    }
}