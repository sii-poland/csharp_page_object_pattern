using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Pages.Cart;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.Products
{
    public class ProductPopupPage : BasePage
    {
        private readonly IWebElement _parent;

        public ProductPopupPage(IWebElement parent, IWebDriver driver) : base(driver)
        {
            _parent = parent;
        }

        private IWebElement ContinueShoppingButton => _parent.FindElement(By.CssSelector(".btn-secondary"));

        private IWebElement ProceedToCheckoutButton => _parent.FindElement(By.CssSelector(".btn-primary"));

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