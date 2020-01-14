using System.IO;
using AutomationTestSiiFramework.Extensions;
using LLibrary;
using Microsoft.Extensions.Configuration;
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
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            IConfiguration config = builder.Build();
            TestSettings.BrowserName = config["browserName"];
            TestSettings.BrowserType = config["browserType"];
            TestSettings.GridUrl = config["gridUrl"];
            Container = new Container();
            var driverFactory = new WebDriverFactory();
            var logger = new L();
            var driver = TestSettings.BrowserType == "local"
                ? driverFactory.GetWebDriver(TestSettings.BrowserName, logger)
                : driverFactory.GetRemoteDriver(TestSettings.BrowserName, TestSettings.GridUrl);
            Container.RegisterInstance(driver);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            var driver = Container.GetInstance<IWebDriver>();
            driver.Close();
            driver.Quit();
        }

        protected Container Container;
    }
}