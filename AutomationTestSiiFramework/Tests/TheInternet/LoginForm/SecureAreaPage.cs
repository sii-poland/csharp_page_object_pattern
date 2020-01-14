using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.TheInternet.LoginForm
{
    public class SecureAreaPage : BasePage
    {
        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }

        private By LogoutButton => By.CssSelector(".icon-signout");
        private By SuccessMessage => By.CssSelector(".success");
        private By InvalidPasswordMessage => By.CssSelector(".error");

        public SecureAreaPage Logout()
        {
            driver.ClickOnElement(LogoutButton);
            return this;
        }

        public string GetSuccessLoginMessage()
        {
            return driver.WaitAndFind(SuccessMessage).Text.Replace("\r\n", "");
        }

        public string GetInvalidPasswordMessage()
        {
            return driver.WaitAndFind(InvalidPasswordMessage).Text.Replace("\r\n", "");
        }
    }
}