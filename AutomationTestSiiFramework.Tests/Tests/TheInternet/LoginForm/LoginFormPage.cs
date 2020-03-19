using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet.LoginForm
{
    public class LoginFormPage : BasePage
    {
        public LoginFormPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UsernameField => Driver.FindElement(By.CssSelector("#username"));
        private IWebElement PasswordField => Driver.FindElement(By.CssSelector("#password"));
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector(".fa-sign-in"));

        public LoginFormPage Go(string path)
        {
            Driver.Navigate().GoToUrl($"{TestSettings.ConfigurationJson.InternetAppUrl}{path}");
            return this;
        }

        public LoginFormPage FillLoginForm(string login, string password)
        {
            Driver.SendKeysWithWait(UsernameField, login);
            Driver.SendKeysWithWait(PasswordField, password);
            return this;
        }

        public SecureAreaPage Submit()
        {
            Driver.ClickOnElement(LoginButton);
            return new SecureAreaPage(Driver);
        }
    }
}