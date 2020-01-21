using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Pages.OrderProcess;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private static By PrimaryButton => By.CssSelector(".btn-primary");
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        public OrderPersonalInformationFragmentPage ConfirmProceedToCheckout()
        {
            driver.ClickOnTextFromList(PrimaryButton, "Proceed to checkout");
            return new OrderPersonalInformationFragmentPage(driver);
        }
    }
}