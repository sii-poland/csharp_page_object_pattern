using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Extensions;
using AutomationTestSiiFramework.Tests.Models.Order;
using AutomationTestSiiFramework.Tests.Pages.Products;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages
{
    public class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement SizeDropdownElement => Driver.FindElement(By.CssSelector("#group_1"));
        private IWebElement QuantityDropdownElement => Driver.FindElement(By.CssSelector("#quantity_wanted"));
        private IWebElement ProductPriceElement => Driver.FindElement(By.CssSelector("span[itemprop='price']"));
        private IWebElement ProductNameElement => Driver.FindElement(By.CssSelector("h1"));
        private IWebElement AddToCartButton => Driver.FindElement(By.CssSelector(".add-to-cart"));

        public string Name => ProductNameElement.Text;
        public int Quantity => int.Parse(QuantityDropdownElement.GetValue());
        public decimal Price => ProductPriceElement.Text.ToPrice();

        public ProductDetailsPage SetSize(string size)
        {
            Driver.SelectByText(SizeDropdownElement, size);
            return this;
        }

        public ProductDetailsPage SetQuantity(int quantity)
        {
            Driver.SendKeysWithWait(QuantityDropdownElement, quantity.ToString());
            return this;
        }

        public ProductPopupPage AddToCart()
        {
            Driver.ClickOnElement(AddToCartButton);
            return new ProductPopupPage(Driver);
        }

        public ProductPopupPage AddToCart(OrderDetails expectedOrder)
        {
            expectedOrder.Add(new OrderLine
            {
                Product = new Product(Name, Price),
                Quantity = Quantity,
                TotalPrice = Price * Quantity
            });
            return AddToCart();
        }

        public Product ToProduct()
        {
            return new Product(Name, Price);
        }
    }
}