using System;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace AutomationTestSiiFramework.Extensions
{
    public class WebDriverFactory
    {
        private static string GridUrl => TestSettings.ConfigurationJson.GridUrl;
        private static Browser Browser => TestSettings.ConfigurationJson.BrowserName.ToEnum<Browser>();
        private static int DefaultTimeout => TestSettings.ConfigurationJson.DefaultTimeout;

        public IWebDriver GetWebDriver(L logger)
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    var chromeDriver = new ChromeDriver(TestSettings.DriverPath, WebdriverSettings.ChromeOptions());
                    return new WebDriverListener(chromeDriver, logger);
                case Browser.Firefox:
                    var firefoxDriver = new FirefoxDriver(WebdriverSettings.GetFirefoxService(), WebdriverSettings.FirefoxOptions(), TimeSpan.FromSeconds(DefaultTimeout));
                    return new WebDriverListener(firefoxDriver, logger);
                case Browser.InternetExplorer:
                    return new InternetExplorerDriver(TestSettings.DriverPath, WebdriverSettings.InternetExplorerOptions(), TimeSpan.FromSeconds(DefaultTimeout));
                case Browser.Edge:
                    return new EdgeDriver(WebdriverSettings.GetEdgeDriverService(), WebdriverSettings.EdgeOptions(), TimeSpan.FromSeconds(DefaultTimeout));
                default:
                    throw new ArgumentOutOfRangeException(nameof(TestSettings.ConfigurationJson.BrowserName),
                        TestSettings.ConfigurationJson.BrowserName,
                        null);
            }
        }

        public RemoteWebDriver GetRemoteDriver()
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    return new RemoteWebDriver(new Uri(GridUrl), WebdriverSettings.ChromeOptions());
                case Browser.Firefox:
                    return new RemoteWebDriver(new Uri(GridUrl), WebdriverSettings.FirefoxOptions());
                case Browser.InternetExplorer:
                    return new RemoteWebDriver(new Uri(GridUrl), WebdriverSettings.InternetExplorerOptions());
                case Browser.Edge:
                    return new RemoteWebDriver(new Uri(GridUrl), WebdriverSettings.EdgeOptions());
                default:
                    return null;
            }
        }
    }
}