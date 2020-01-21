using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet.LoginForm
{
    public class SecureAreaPage : BasePage
    {
        private static By LogoutButton => By.CssSelector(".icon-signout");
        private static By SuccessMessage => By.CssSelector(".success");
        private static By InvalidPasswordMessage => By.CssSelector(".error");

        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }

        public SecureAreaPage Logout()
        {
            driver.ClickOnElement(LogoutButton);
            return this;
        }

        public string GetSuccessLoginMessage() => driver.WaitAndFind(SuccessMessage).Text.Replace("\r\n", "");
        public string GetInvalidPasswordMessage() => driver.WaitAndFind(InvalidPasswordMessage).Text.Replace("\r\n", "");
    }
}