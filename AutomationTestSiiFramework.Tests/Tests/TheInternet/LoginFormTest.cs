using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Tests.Tests.TheInternet.LoginForm;
using FluentAssertions;
using NUnit.Framework;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class LoginFormTest : BaseTest
    {
        [Test]
        public void LoginAuth_PutCorrectCredentials_SeeValidationAboutLoggedToTheSystem()
        {
            var loginFormPage = new LoginFormPage(Driver);
            loginFormPage
                .Go("/login")
                .FillLoginForm("tomsmith", "SuperSecretPassword!")
                .Submit()
                .SuccessMessage
                .Should().Be("You logged into a secure area!×");
            new SecureAreaPage(Driver).Logout();
        }

        [Test]
        public void LoginAuth_PutInvalidCredentials_SeeValidationAboutNoAccessToSite()
        {
            var loginFormPage = new LoginFormPage(Driver);
            loginFormPage
                .Go("/login")
                .FillLoginForm("tomsmith", "invalid_password")
                .Submit()
                .InvalidPasswordMessage
                .Should().Be("Your password is invalid!×");
        }
    }
}