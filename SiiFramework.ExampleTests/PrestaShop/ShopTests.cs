using NUnit.Framework;
using OpenQA.Selenium;
using SiiFramework.Base;
using SiiFramework.ExampleTests.PrestaShop.Pages;

namespace SiiFramework.ExampleTests.PrestaShop
{
    [TestFixture]
    internal class ShopTests : BaseTest
    {
        [Test]

        [TestCase("http://5.196.7.235/", "HUMMINGBIRD TSHIRT", "L", 10)]
        [TestCase("http://5.196.7.235/", "HUMMINGBIRD TSHIRT", "L", 10)]
        [TestCase("http://5.196.7.235/", "HUMMINGBIRD TSHIRT", "L", 10)]
        [TestCase("http://5.196.7.235/", "HUMMINGBIRD TSHIRT", "L", 10)]
        public void Foo(string url, string productName, string size, int quantity)
        {
            var driver = Container.GetInstance<IWebDriver>();
            var homeShopPage = new HomeShopPage(driver);
            var product = homeShopPage.Go(url).ChooseProductByName(productName).GetProduct();
            var productDetailsPage = new ProductDetailsPage(driver);
            productDetailsPage.SetSize(size).SetQuantity(quantity).AddToCart();
        }
    }
}