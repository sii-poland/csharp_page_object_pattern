using OpenQA.Selenium;
using SiiFramework.Base;
using SiiFramework.Extensions;

namespace SiiFramework.ExampleTest.TheInternet.LoginForm
{
    public class SecureAreaPage : BasePage
    {
        private By LogoutButton => By.CssSelector(".icon-signout");
        private By SuccessMessage => By.CssSelector(".success");
        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }

        public SecureAreaPage Logout()
        {
            driver.ClickOnElement(LogoutButton);
            return this;
        }

        public string GetSuccessMessage()
        {
            return driver.WaitAndFind(SuccessMessage).Text.Replace("\r\n", "");
        }
    }
}
