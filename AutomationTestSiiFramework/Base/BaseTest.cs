using AutomationTestSiiFramework.Extensions;
using LLibrary;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SimpleInjector;

namespace AutomationTestSiiFramework.Base
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Container = new Container();
            var driverFactory = new WebDriverFactory();
            var logger = new L();
            var driver = TestSettings.ConfigurationJson.BrowserType == "local"
                ? driverFactory.GetWebDriver(TestSettings.ConfigurationJson.BrowserName, logger)
                : driverFactory.GetRemoteDriver(TestSettings.ConfigurationJson.BrowserName,
                    TestSettings.ConfigurationJson.GridUrl);
            Container.RegisterInstance(driver);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            var driver = Container.GetInstance<IWebDriver>();
            driver.Quit();
        }

        protected Container Container;
    }
}