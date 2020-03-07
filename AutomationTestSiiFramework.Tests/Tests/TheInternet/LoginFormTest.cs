using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Tests.Tests.TheInternet.LoginForm;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class LoginFormTest : BaseTest
    {
        [Test]
        public void LoginAuth_PutCorrectCredentials_SeeValidationAboutLoggedToTheSystem()
        {
            var driver = Container.GetInstance<IWebDriver>();
            var loginFormPage = new LoginFormPage(driver);
            loginFormPage
                .Go("/login")
                .FillLoginForm("tomsmith", "SuperSecretPassword!")
                .Submit()
                .GetSuccessLoginMessage()
                .Should().Be("You logged into a secure area!×");
            new SecureAreaPage(driver).Logout();
        }

        [Test]
        public void LoginAuth_PutInvalidCredentials_SeeValidationAboutNoAccessToSite()
        {
            var driver = Container.GetInstance<IWebDriver>();
            var loginFormPage = new LoginFormPage(driver);
            loginFormPage
                .Go("/login")
                .FillLoginForm("tomsmith", "invalid_password")
                .Submit()
                .GetInvalidPasswordMessage()
                .Should().Be("Your password is invalid!×");
        }
    }
}