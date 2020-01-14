using OpenQA.Selenium;

namespace SiiFramework.Base
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected BasePage(IWebDriver driver) => this.driver = driver;
    }
}