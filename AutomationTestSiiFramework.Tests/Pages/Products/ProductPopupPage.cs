using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
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

        public bool IsDisplayed
        {
            get
            {
                try
                {
                    return _parent.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            }
        }

        public void WaitForPopupToDisappear()
        {
            Driver.Wait().Until(c => !IsDisplayed);
        }

        public ShoppingCartPage ProceedToCheckout()
        {
            Driver.ClickOnElement(ProceedToCheckoutButton);
            WaitForPopupToDisappear();
            return new ShoppingCartPage(Driver);
        }

        public ProductDetailsPage ContinueShopping()
        {
            Driver.ClickOnElement(ContinueShoppingButton);
            WaitForPopupToDisappear();
            return new ProductDetailsPage(Driver);
        }
    }
}