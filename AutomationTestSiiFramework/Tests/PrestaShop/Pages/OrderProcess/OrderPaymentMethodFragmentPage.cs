using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages.OrderProcess
{
    public class OrderPaymentMethodFragmentPage : BasePage
    {
        public OrderPaymentMethodFragmentPage(IWebDriver driver) : base(driver)
        {
        }


        public By OrderWithObligationToPayButton => By.CssSelector("#payment-confirmation button");

        public By TermsOfService => By.CssSelector("#conditions-to-approve label");
        public By PayByBankWire => By.CssSelector("#payment-option-2");

        public By PayByCheck => By.CssSelector("#payment-option-1");


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