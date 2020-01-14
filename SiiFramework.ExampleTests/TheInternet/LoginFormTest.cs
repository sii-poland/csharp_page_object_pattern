using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using Shouldly;
using SiiFramework.Base;
using SiiFramework.ExampleTests.TheInternet.LoginForm;

namespace SiiFramework.ExampleTests.TheInternet
{
    [TestFixture]
    [AllureNUnit]
    class LoginFormTest : BaseTest
    {
        [Test]
        public void LoginAuth_Check_Foo()
        {
            var driver = Container.GetInstance<IWebDriver>();
            var loginFormPage = new LoginFormPage(driver);
            loginFormPage
                .Go()
                .FillLoginForm("tomsmith", "SuperSecretPassword!")
                .Submit()
                .GetSuccessMessage()
                .ShouldBe("You logged into a secure area!×");
        }
    }
}
