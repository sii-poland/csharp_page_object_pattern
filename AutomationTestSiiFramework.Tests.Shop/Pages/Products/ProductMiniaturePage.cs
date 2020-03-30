using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using AutomationTestSiiFramework.Tests.Shop.Extensions;
using AutomationTestSiiFramework.Tests.Shop.Models.Order;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Shop.Pages.Products
{
    public class ProductMiniaturePage : BasePage
    {
        private readonly IWebElement _parentElement;

        public ProductMiniaturePage(IWebDriver driver, IWebElement parentElement) : base(driver)
        {
            _parentElement = parentElement;
        }

        private IWebElement NameElement => _parentElement.FindElement(By.CssSelector(".product-title"));
        private IWebElement PriceElement => _parentElement.FindElement(By.CssSelector(".price"));
        private IWebElement PriceBeforeDiscountElement => _parentElement.FindElement(By.CssSelector(".regular-price"));
        private IWebElement DiscountElement => _parentElement.FindElement(By.CssSelector(".discount-percentage"));
        private IWebElement NewIndicatorElement => _parentElement.FindElement(By.CssSelector(".new"));
        private IWebElement DiscountedElement => _parentElement.FindElement(By.CssSelector(".discount-product"));
        private IWebElement QuickView => _parentElement.FindElement(By.CssSelector(".quick-view"));

        public string Name => NameElement.Text;
        public decimal Price => PriceElement.Text.ToPrice();
        public decimal PriceBeforeDiscount => PriceBeforeDiscountElement.Text.ToPrice();
        public string DiscountValue => DiscountElement.Text;

        public bool IsDiscounted
        {
            get
            {
                try
                {
                    return DiscountedElement.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public bool IsNew
        {
            get
            {
                try
                {
                    return NewIndicatorElement.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public void OpenQuickView()
        {
            Driver.MoveToElement(NameElement);
            Driver.ClickOnElement(QuickView);
        }

        public void Open()
        {
            Driver.ClickOnElement(NameElement);
        }

        public Product ToProduct()
        {
            return new Product(Name, Price);
        }
    }
}