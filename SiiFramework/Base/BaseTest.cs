using LLibrary;
using NUnit.Framework;
using OpenQA.Selenium;
using SiiFramework.Extensions;
using SimpleInjector;

namespace SiiFramework.Base
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
//            Environment.SetEnvironmentVariable(
//                AllureConstants.ALLURE_CONFIG_ENV_VARIABLE,
//                Path.Combine(Environment.CurrentDirectory, AllureConstants.CONFIG_FILENAME));
//            var config = AllureLifecycle.Instance.JsonConfiguration;
            TestSettings.BrowserName = TestContext.Parameters["browserName"] ?? "Chrome";
            TestSettings.BrowserType = TestContext.Parameters["DriverType"] ?? "local";
            TestSettings.GridUrl = TestContext.Parameters["gridUrl"];
            TestSettings.ApplicationAddress = TestContext.Parameters["applicationAddress"];
            Container = new Container();
            var driverFactory = new WebDriverFactory();
            var logger = new L();
            var driver = TestSettings.BrowserType == "local"
                ? driverFactory.GetWebDriver( "Firefox", logger)
                : driverFactory.GetRemoteDriver(TestSettings.GridUrl);
            Container.RegisterInstance(driver);

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