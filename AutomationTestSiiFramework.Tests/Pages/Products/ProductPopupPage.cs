using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Pages.Cart;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.Products
{
    public class ProductPopupPage : BasePage
    {
        public ProductPopupPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement ContinueShoppingButton => Driver.FindElement(By.XPath("//button[.='Continue shopping']"));

        private IWebElement ProceedToCheckoutButton =>
            Driver.FindElement(By.XPath("//a[contains(text(),'Proceed to checkout')]"));

        public ShoppingCartPage ProceedToCheckout()
        {
            Driver.ClickOnElement(ProceedToCheckoutButton);
            return new ShoppingCartPage(Driver);
        }

        public ProductDetailsPage ContinueShopping()
        {
            Driver.ClickOnElement(ContinueShoppingButton);
            return new ProductDetailsPage(Driver);
        }
    }
}