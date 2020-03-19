using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderPaymentMethodFragmentPage : BasePage
    {
        public OrderPaymentMethodFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement OrderWithObligationToPayButton =>
            Driver.FindElement(By.CssSelector("#payment-confirmation button"));

        private IWebElement TermsOfService => Driver.FindElement(By.CssSelector("#conditions-to-approve label"));
        private IWebElement PayByBankWire => Driver.FindElement(By.CssSelector("#payment-option-2"));
        private IWebElement PayByCheck => Driver.FindElement(By.CssSelector("#payment-option-1"));

        public OrderPaymentMethodFragmentPage FillPaymentMethod(string method)
        {
            Driver.Click(method == "Pay by Check" ? PayByCheck : PayByBankWire);
            return this;
        }

        public OrderPaymentMethodFragmentPage AcceptTermsOfService()
        {
            Driver.ClickOnElement(TermsOfService);
            return this;
        }

        public OrderConfirmationPage OrderWithObligationToPay()
        {
            Driver.ClickOnElement(OrderWithObligationToPayButton);
            return new OrderConfirmationPage(Driver);
        }
    }
}