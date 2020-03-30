using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using AutomationTestSiiFramework.Tests.TheInternet.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.TheInternet.Pages
{
    public class SecureAreaPage : BasePage
    {
        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement LogoutButton => Driver.WaitAndFind(By.CssSelector(".icon-signout"));
        private IWebElement SuccessMessageElement => Driver.WaitAndFind(By.CssSelector(".success"));
        private IWebElement InvalidPasswordMessageElement => Driver.WaitAndFind(By.CssSelector(".error"));

        public string SuccessMessage => SuccessMessageElement.GetAttribute("innerText").RemoveNewLines();

        public string InvalidPasswordMessage =>
            InvalidPasswordMessageElement.GetAttribute("innerText").RemoveNewLines();

        public SecureAreaPage Logout()
        {
            Driver.ClickOnElement(LogoutButton);
            return this;
        }
    }
}