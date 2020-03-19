using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderShippingFragmentPage : BasePage
    {
        public OrderShippingFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private static By ConFirmDeliveryOption => By.Name("confirmDeliveryOption");

        public OrderPaymentMethodFragmentPage FillShippingMethod()
        {
            Driver.ClickOnElement(ConFirmDeliveryOption);
            return new OrderPaymentMethodFragmentPage(Driver);
        }
    }
}