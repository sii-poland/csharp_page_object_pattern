using NUnit.Framework;
using OpenQA.Selenium;
using Shouldly;
using SiiFramework.Base;
using SiiFramework.ExampleTest.TheInternet.LoginForm;

namespace SiiFramework.ExampleTest.TheInternet
{
    [TestFixture]
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
