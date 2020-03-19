using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet.LoginForm
{
    public class SecureAreaPage : BasePage
    {
        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement LogoutButton => Driver.FindElement(By.CssSelector(".icon-signo0ut"));
        private IWebElement SuccessMessageElement => Driver.FindElement(By.CssSelector(".success"));
        private IWebElement InvalidPasswordMessageElement => Driver.FindElement(By.CssSelector(".error"));

        public string SuccessMessage => SuccessMessageElement.Text.RemoveNewLines();
        public string InvalidPasswordMessage => InvalidPasswordMessageElement.Text.RemoveNewLines();

        public SecureAreaPage Logout()
        {
            Driver.ClickOnElement(LogoutButton);
            return this;
        }
    }
}