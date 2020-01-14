using OpenQA.Selenium;
using SiiFramework.Base;
using SiiFramework.Extensions;

namespace SiiFramework.ExampleTests.PrestaShop.Pages
{
    public class HomeShopPage: BasePage
    {
        private readonly By ProductTitle = By.CssSelector(".product-title");
        public HomeShopPage(IWebDriver driver) : base(driver)
        { 
        }

        public ProductDetailsPage ChooseProductByName(string name)
        {
            driver.GetElementByDefineTextFromList(ProductTitle, name).Click();
            return new ProductDetailsPage(driver);
        }

        public HomeShopPage Go(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}
