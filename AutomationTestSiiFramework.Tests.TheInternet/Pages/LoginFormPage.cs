using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using AutomationTestSiiFramework.Tests.TheInternet.Providers;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.TheInternet.Pages
{
    public class LoginFormPage : BasePage
    {
        public LoginFormPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UsernameField => Driver.WaitAndFind(By.CssSelector("#username"));
        private IWebElement PasswordField => Driver.WaitAndFind(By.CssSelector("#password"));
        private IWebElement LoginButton => Driver.WaitAndFind(By.CssSelector(".fa-sign-in"));

        public LoginFormPage Go()
        {
            Driver.Navigate().GoToUrl(UrlProvider.Login);
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