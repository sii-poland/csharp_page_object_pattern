using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Base
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected BasePage(IWebDriver driver) => this.driver = driver;
    }
}