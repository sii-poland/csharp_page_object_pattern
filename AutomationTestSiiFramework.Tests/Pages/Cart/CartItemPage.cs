using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Extensions;
using AutomationTestSiiFramework.Tests.Models.Order;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.Cart
{
    public class CartItemPage : BasePage
    {
        private readonly IWebElement _parent;

        public CartItemPage(IWebElement parent, IWebDriver driver) : base(driver)
        {
            _parent = parent;
        }

        private IWebElement NameElement => _parent.FindElement(By.CssSelector("a[data-id_customization='0']"));
        private IWebElement PriceElement => _parent.FindElement(By.CssSelector(".current-price"));
        private IWebElement TotalPriceElement => _parent.FindElement(By.CssSelector("span.product-price strong"));
        private IWebElement QuantityElement => _parent.FindElement(By.CssSelector(".js-cart-line-product-quantity"));

        private string Name => NameElement.Text;
        private decimal Price => PriceElement.Text.ToPrice();
        private decimal TotalPrice => TotalPriceElement.Text.ToPrice();
        private int Quantity => int.Parse(QuantityElement.GetValue());


        public OrderLine ToOrderLine()
        {
            return new OrderLine
            {
                Product = new Product(Name, Price),
                Quantity = Quantity,
                TotalPrice = TotalPrice
            };
        }
    }
}