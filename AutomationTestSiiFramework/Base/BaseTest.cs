using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Helpers;
using LLibrary;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Base
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var driverConfig = Configuration.WebDriver;
            var logger = new L();
            Driver = new WebDriverFactory().GetWebDriver(driverConfig, logger);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.SaveScreenshot("Screenshot after test");
            Driver.Quit();
        }

        protected IWebDriver Driver { get; set; }
    }
}