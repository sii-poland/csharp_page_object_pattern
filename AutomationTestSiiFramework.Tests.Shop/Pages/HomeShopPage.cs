using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using AutomationTestSiiFramework.Tests.Shop.Pages.Products;
using AutomationTestSiiFramework.Tests.Shop.Providers;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Shop.Pages
{
    public class HomeShopPage : BasePage
    {
        public readonly ProductsGridPage ProductsGrid;

        public HomeShopPage(IWebDriver driver) : base(driver)
        {
            ProductsGrid = new ProductsGridPage(Driver);
        }

        public HomeShopPage Go()
        {
            Driver.Open(UrlProvider.Home);
            return this;
        }
    }
}