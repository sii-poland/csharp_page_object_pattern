using System.Collections.Generic;
using System.Linq;
using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Extensions.WebDriver;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.Products
{
    public class ProductsGridPage : BasePage
    {
        public ProductsGridPage(IWebDriver driver) : base(driver)
        {
        }

        private IEnumerable<IWebElement> AllProductsElements =>
            Driver.FindElementsGraterThenZero(By.CssSelector(".product-miniature"));

        public List<ProductMiniaturePage> AllProducts =>
            AllProductsElements.Select(c => new ProductMiniaturePage(Driver, c)).ToList();

        public bool HasProducts
        {
            get
            {
                try
                {
                    return AllProducts.Count > 0;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public ProductDetailsPage OpenProductByName(string name)
        {
            AllProducts.First(c => c.Name.Equals(name)).Open();
            return new ProductDetailsPage(Driver);
        }

        public ProductDetailsPage OpenRandomProduct()
        {
            AllProducts.Random().Open();
            return new ProductDetailsPage(Driver);
        }
    }
}