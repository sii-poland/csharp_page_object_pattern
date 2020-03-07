using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet.LoginForm
{
    public class LoginFormPage : BasePage
    {
        private static By UsernameField => By.CssSelector("#username");
        private static By PasswordField => By.CssSelector("#password");
        private static By LoginButton => By.CssSelector(".fa-sign-in");

        public LoginFormPage(IWebDriver driver) : base(driver)
        {
        }

        public LoginFormPage Go(string path)
        {
            driver.Navigate().GoToUrl($"{TestSettings.ConfigurationJson.InternetAppUrl}{path}");
            return this;
        }

        public LoginFormPage FillLoginForm(string login, string password)
        {
            driver.SendKeysWithWait(UsernameField, login);
            driver.SendKeysWithWait(PasswordField, password);
            return this;
        }

        public SecureAreaPage Submit()
        {
            driver.ClickOnElement(LoginButton);
            return new SecureAreaPage(driver);
        }
    }
}