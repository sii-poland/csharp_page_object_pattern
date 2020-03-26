using AutomationTestSiiFramework.Helpers;
using LLibrary;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Base
{
    [TestFixture]
    // [AllureNUnit]
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var logger = new L();
            Driver = new WebDriverFactory().GetWebDriver(logger);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        protected IWebDriver Driver { get; set; }
    }
}