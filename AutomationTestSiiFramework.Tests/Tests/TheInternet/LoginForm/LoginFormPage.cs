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

        public By UsernameField => By.CssSelector("#username");
        public By PasswordField => By.CssSelector("#password");
        public By LoginButton => By.CssSelector(".fa-sign-in");

        public LoginFormPage Go(string path)
        {
            driver.Navigate().GoToUrl($"{TestSettings.InternetAppUrl}{path}");
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