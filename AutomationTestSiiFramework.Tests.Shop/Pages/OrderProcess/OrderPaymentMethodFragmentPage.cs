using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Shop.Pages.OrderProcess
{
    public class OrderPaymentMethodFragmentPage : BasePage
    {
        public OrderPaymentMethodFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement OrderWithObligationToPayButton =>
            Driver.WaitAndFind(By.CssSelector("#payment-confirmation button"));

        private IWebElement TermsOfServiceElement => Driver.WaitAndFind(By.CssSelector("#conditions-to-approve label"));

        private IWebElement PayByBankWireElement =>
            Driver.WaitAndFind(By.CssSelector("#payment-option-2-container .custom-radio"));

        private IWebElement PayByCheckElement =>
            Driver.WaitAndFind(By.CssSelector("#payment-option-1-container .custom-radio"));

        public OrderPaymentMethodFragmentPage FillPaymentMethod(string method)
        {
            Driver.Click(method == "Pay by Check" ? PayByCheckElement : PayByBankWireElement);
            return this;
        }

        public OrderPaymentMethodFragmentPage AcceptTermsOfService()
        {
            Driver.ClickOnElement(TermsOfServiceElement);
            return this;
        }

        public OrderConfirmationPage OrderWithObligationToPay()
        {
            Driver.ClickOnElement(OrderWithObligationToPayButton);
            return new OrderConfirmationPage(Driver);
        }
    }
}