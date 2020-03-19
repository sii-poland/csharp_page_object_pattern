using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Pages.Products;
using AutomationTestSiiFramework.Tests.Providers;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages
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