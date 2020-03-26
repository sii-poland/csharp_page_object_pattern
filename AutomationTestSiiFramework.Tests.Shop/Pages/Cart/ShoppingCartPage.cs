using System.Collections.Generic;
using System.Linq;
using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using AutomationTestSiiFramework.Tests.Shop.Extensions;
using AutomationTestSiiFramework.Tests.Shop.Models.Order;
using AutomationTestSiiFramework.Tests.Shop.Pages.OrderProcess;
using AutomationTestSiiFramework.Tests.Shop.Providers;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Shop.Pages.Cart
{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement ProceedToCheckoutButton =>
            Driver.WaitAndFind(By.CssSelector(".cart-summary .btn-primary"));

        private IWebElement TotalOrderCostElement =>
            Driver.WaitAndFind(By.CssSelector("#cart-subtotal-products .value"));

        private IEnumerable<IWebElement> CartItemsElements =>
            Driver.FindElementsGraterThenZero(By.CssSelector(".cart-item"));

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