using System.Collections.Generic;
using System.Linq;
using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Extensions;
using AutomationTestSiiFramework.Tests.Models.Order;
using AutomationTestSiiFramework.Tests.Pages.OrderProcess;
using AutomationTestSiiFramework.Tests.Providers;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.Cart
{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement ProceedToCheckoutButton =>
            Driver.FindElement(By.XPath("//a[contains(text(),'Proceed to checkout')]"));

        private IWebElement TotalOrderCostElement =>
            Driver.FindElement(By.CssSelector("#cart-subtotal-products .value"));

        private IEnumerable<IWebElement> CartItemsElements => Driver.FindElements(By.CssSelector(".cart-item"));
        public List<CartItemPage> CartItems => CartItemsElements.Select(c => new CartItemPage(c, Driver)).ToList();
        public decimal TotalOrderCost => TotalOrderCostElement.Text.ToPrice();


        public OrderPersonalInformationFragmentPage ConfirmProceedToCheckout()
        {
            Driver.ClickOnElement(ProceedToCheckoutButton);
            return new OrderPersonalInformationFragmentPage(Driver);
        }

        public OrderDetails ToOrder()
        {
            return new OrderDetails
            {
                Items = CartItems.Select(c => c.ToOrderLine()).ToList(),
                TotalOrderCost = TotalOrderCost
            };
        }

        public ShoppingCartPage Go()
        {
            Driver.Open(UrlProvider.Cart);
            return this;
        }
    }
}