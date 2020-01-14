using OpenQA.Selenium;
using SiiFramework.Base;
using SiiFramework.Extensions;

namespace SiiFramework.ExampleTest.TheInternet.LoginForm
{
    public class LoginFormPage : BasePage
    {
        By UsernameField => By.CssSelector("#username");
        By PasswordField => By.CssSelector("#password");
        By LoginButton => By.CssSelector(".fa-sign-in");
        public LoginFormPage(IWebDriver driver) : base(driver)
        {
        }

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
