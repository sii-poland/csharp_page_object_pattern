using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages.OrderProcess
{
    public class OrderShippingFragmentPage : BasePage
    {
        public OrderShippingFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        public By ConFirmDeliveryOption => By.Name("confirmDeliveryOption");

        public OrderPaymentMethodFragmentPage FillShippingMethod()
        {
            driver.ClickOnElement(ConFirmDeliveryOption);
            return new OrderPaymentMethodFragmentPage(driver);
        }
    }
}