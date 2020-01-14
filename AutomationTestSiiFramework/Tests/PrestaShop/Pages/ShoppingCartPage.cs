using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.PrestaShop.Pages.OrderProcess;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages
{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        private By PrimaryButton => By.CssSelector(".btn-primary");

        public OrderPersonalInformationFragmentPage ConfirmProceedToCheckout()
        {
            driver.ClickOnTextFromList(PrimaryButton, "Proceed to checkout");
            return new OrderPersonalInformationFragmentPage(driver);
        }
    }
}