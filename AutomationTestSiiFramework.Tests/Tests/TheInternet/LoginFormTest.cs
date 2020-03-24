using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Tests.Tests.TheInternet.LoginForm;
using FluentAssertions;
using NUnit.Framework;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginFormTest : BaseTest
    {
        [Test]
        public void LoginAuth_PutCorrectCredentials_SeeValidationAboutLoggedToTheSystem()
        {
            new LoginFormPage(Driver)
                .Go()
                .FillLoginForm("tomsmith", "SuperSecretPassword!")
                .Submit()
                .SuccessMessage
                .Should().Contain("You logged into a secure area!");
            new SecureAreaPage(Driver).Logout();
        }

        [Test]
        public void LoginAuth_PutInvalidCredentials_SeeValidationAboutNoAccessToSite()
        {
            new LoginFormPage(Driver)
                .Go()
                .FillLoginForm("tomsmith", "invalid_password")
                .Submit()
                .InvalidPasswordMessage
                .Should().Contain("Your password is invalid!");
        }
    }
}