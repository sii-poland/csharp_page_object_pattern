using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.PrestaShop.Data;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages
{
    public class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        private By SizeDropdown => By.CssSelector("#group_1");
        private By QuantityDropdown => By.CssSelector("#quantity_wanted");
        private By AddToCartButton => By.CssSelector(".add-to-cart");
        private IWebElement ProductPrice => driver.FindElement(By.CssSelector(".product-price span:nth-child(1)"));
        public IWebElement ProductName => driver.FindElement(By.CssSelector("h1"));
        public IWebElement ProductDescription => driver.FindElement(By.CssSelector(".product-description p"));
        public By ProceedToCheckoutButton => By.CssSelector(".modal-body .col-md-7 div div a i");

        public ProductDetailsPage SetSize(string size)
        {
            driver.SelectByText(SizeDropdown, size);
            return this;
        }

        public ProductDetailsPage SetQuantity(int quantity)
        {
            driver.SendKeysWithWait(QuantityDropdown, quantity.ToString());
            return this;
        }

        public ProductDetailsPage AddToCart()
        {
            driver.ClickOnElement(AddToCartButton);
            return this;
        }

        public Product GetProduct()
        {
            return new Product(ProductName.Text, ProductPrice.Text, ProductDescription.Text);
        }

        public ShoppingCartPage ClickOnProceedToCheckout()
        {
            driver.ClickOnElement(ProceedToCheckoutButton);
            return new ShoppingCartPage(driver);
        }
    }
}