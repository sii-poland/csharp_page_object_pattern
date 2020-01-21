using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderPaymentMethodFragmentPage : BasePage
    {
        private static By OrderWithObligationToPayButton => By.CssSelector("#payment-confirmation button");
        private static By TermsOfService => By.CssSelector("#conditions-to-approve label");
        private static By PayByBankWire => By.CssSelector("#payment-option-2");
        private static By PayByCheck => By.CssSelector("#payment-option-1");
        public OrderPaymentMethodFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        public OrderPaymentMethodFragmentPage FillPaymentMethod(string method)
        {
            driver.Click(method == "Pay by Check" ? PayByCheck : PayByBankWire);
            return this;
        }

        public OrderPaymentMethodFragmentPage AcceptTermsOfService()
        {
            driver.Click(TermsOfService);
            return this;
        }

        public OrderConfirmationPage OrderWithObligationToPay()
        {
            driver.ClickOnElement(OrderWithObligationToPayButton);
            return new OrderConfirmationPage(driver);
        }
    }
}