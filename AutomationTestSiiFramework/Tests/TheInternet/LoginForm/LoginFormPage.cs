using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.TheInternet.LoginForm
{
    public class LoginFormPage : BasePage
    {
        public LoginFormPage(IWebDriver driver) : base(driver)
        {
        }

        private By UsernameField => By.CssSelector("#username");
        private By PasswordField => By.CssSelector("#password");
        private By LoginButton => By.CssSelector(".fa-sign-in");

        public LoginFormPage Go()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
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