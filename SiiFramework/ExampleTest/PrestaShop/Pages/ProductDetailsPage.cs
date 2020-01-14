using OpenQA.Selenium;
using SiiFramework.Base;
using SiiFramework.ExampleTest.PrestaShop.Data;
using SiiFramework.Extensions;

namespace SiiFramework.ExampleTest.PrestaShop.Pages
{
 
    public class ProductDetailsPage : BasePage
    {
        
        private By SizeDropdown => By.CssSelector("#group_1");
        private By QuantityDropdown => By.CssSelector("#quantity_wanted");
        private By AddToCartButton => By.CssSelector(".add-to-cart");
        private IWebElement ProductPrice => driver.FindElement(By.CssSelector(".product-price span:nth-child(1)"));
        private IWebElement ProductName => driver.FindElement(By.CssSelector("h1"));
        private IWebElement ProductDescription => driver.FindElement(By.CssSelector(".product-description p"));
        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public ProductDetailsPage SetSize(string size)
        {
            driver.SelectByText(SizeDropdown, size);
            return this;
        }

        public ProductDetailsPage SetQuantity(int quantity)
        {
            driver.SelectByText(QuantityDropdown,quantity.ToString());
            return this;
        }

        public void AddToCart()
        {
            driver.ClickOnElement(AddToCartButton);
        }

        public Product GetProduct()
        {

            var product = new Product(ProductName.Text, ProductPrice.Text, ProductDescription.Text);
            return product;
        }
    }
}
