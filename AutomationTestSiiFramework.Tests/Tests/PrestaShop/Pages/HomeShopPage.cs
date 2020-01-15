using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages
{
    public class HomeShopPage : BasePage
    {
        private readonly By _productTitle = By.CssSelector(".product-title");

        public HomeShopPage(IWebDriver driver) : base(driver)
        {
        }

        public ProductDetailsPage ChooseProductByName(string name)
        {
            driver.ClickOnElement(driver.GetElementByDefineTextFromList(_productTitle, name));
            return new ProductDetailsPage(driver);
        }

        public HomeShopPage Go(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}