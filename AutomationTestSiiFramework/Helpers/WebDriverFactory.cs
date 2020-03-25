using System;
using AutomationTestSiiFramework.Extensions;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace AutomationTestSiiFramework.Helpers
{
    public class WebDriverFactory
    {
        private static string GridUrl => TestSettings.ConfigurationJson.GridUrl;
        private static Browser Browser => TestSettings.ConfigurationJson.BrowserName.ToEnum<Browser>();

        public IWebDriver GetWebDriver(L logger)
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    var chromeDriver = new ChromeDriver(TestSettings.DriverPath, WebDriverSettings.ChromeOptions());
                    return new WebDriverListener(chromeDriver, logger);
                case Browser.Firefox:
                    var firefoxDriver = new FirefoxDriver(WebDriverSettings.GetFirefoxService(),
                        WebDriverSettings.FirefoxOptions());
                    return new WebDriverListener(firefoxDriver, logger);
                case Browser.InternetExplorer:
                    var ieDriver = new InternetExplorerDriver(TestSettings.DriverPath,
                        WebDriverSettings.InternetExplorerOptions());
                    return new WebDriverListener(ieDriver, logger);
                case Browser.Edge:
                    var edgeDriver = new EdgeDriver(WebDriverSettings.GetEdgeDriverService(),
                        WebDriverSettings.EdgeOptions());
                    return new WebDriverListener(edgeDriver, logger);
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
                    return new RemoteWebDriver(new Uri(GridUrl), WebDriverSettings.ChromeOptions());
                case Browser.Firefox:
                    return new RemoteWebDriver(new Uri(GridUrl), WebDriverSettings.FirefoxOptions());
                case Browser.InternetExplorer:
                    return new RemoteWebDriver(new Uri(GridUrl), WebDriverSettings.InternetExplorerOptions());
                case Browser.Edge:
                    return new RemoteWebDriver(new Uri(GridUrl), WebDriverSettings.EdgeOptions());
                default:
                    return null;
            }
        }
    }
}