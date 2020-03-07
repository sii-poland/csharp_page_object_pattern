using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderShippingFragmentPage : BasePage
    {
        private static By ConFirmDeliveryOption => By.Name("confirmDeliveryOption");
        public OrderShippingFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        public OrderPaymentMethodFragmentPage FillShippingMethod()
        {
            driver.ClickOnElement(ConFirmDeliveryOption);
            return new OrderPaymentMethodFragmentPage(driver);
        }
    }
}