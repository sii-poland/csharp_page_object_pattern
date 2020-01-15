using System.IO;
using AutomationTestSiiFramework.Extensions;
using LLibrary;
using Microsoft.Extensions.Configuration;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SimpleInjector;

namespace AutomationTestSiiFramework.Base
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTest
    {
        protected Container Container;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            TestSettings.BrowserName = config["browserName"];
            TestSettings.BrowserType = config["browserType"];
            TestSettings.GridUrl = config["gridUrl"];
            TestSettings.ShopAppUrl = config["ShopAppUrl"];
            TestSettings.InternetAppUrl = config["InternetAppUrl"];
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
    }
}