using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages
{
    public class HomeShopPage : BasePage
    {
        private static By ProductTitle = By.CssSelector(".product-title");

        public HomeShopPage(IWebDriver driver) : base(driver)
        {
        }

        public ProductDetailsPage ChooseProductByName(string name)
        {
            driver.ClickOnElement(driver.GetElementByDefineTextFromList(ProductTitle, name));
            return new ProductDetailsPage(driver);
        }

        public HomeShopPage Go(string url)
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}