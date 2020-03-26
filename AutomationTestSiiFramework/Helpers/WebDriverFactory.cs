using System;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Models;
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
        private static Browser Browser => Configuration.WebDriver.BrowserName.ToEnum<Browser>();
        private static BrowserType BrowserType => Configuration.WebDriver.BrowserType.ToEnum<BrowserType>();

        public IWebDriver GetWebDriver(L logger)
        {
            return BrowserType == BrowserType.Local ? GetLocalWebDriver(logger) : GetRemoteDriver();
        }

        private IWebDriver GetLocalWebDriver(L logger)
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    var chromeDriver =
                        new ChromeDriver(Configuration.DriverPath, WebDriverSettings.ChromeOptions());
                    return new WebDriverListener(chromeDriver, logger);
                case Browser.Firefox:
                    var firefoxDriver = new FirefoxDriver(WebDriverSettings.GetFirefoxService(),
                        WebDriverSettings.FirefoxOptions());
                    return new WebDriverListener(firefoxDriver, logger);
                case Browser.InternetExplorer:
                    var ieDriver = new InternetExplorerDriver(Configuration.DriverPath,
                        WebDriverSettings.InternetExplorerOptions());
                    return new WebDriverListener(ieDriver, logger);
                case Browser.Edge:
                    var edgeDriver = new EdgeDriver(WebDriverSettings.GetEdgeDriverService(),
                        WebDriverSettings.EdgeOptions());
                    return new WebDriverListener(edgeDriver, logger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(Configuration.WebDriver.BrowserName),
                        Configuration.WebDriver.BrowserName,
                        null);
            }
        }

        private RemoteWebDriver GetRemoteDriver()
        {
            var gridUrl = Configuration.WebDriver.GridUrl;
            switch (Browser)
            {
                case Browser.Chrome:
                    return new RemoteWebDriver(new Uri(gridUrl), WebDriverSettings.ChromeOptions());
                case Browser.Firefox:
                    return new RemoteWebDriver(new Uri(gridUrl), WebDriverSettings.FirefoxOptions());
                case Browser.InternetExplorer:
                    return new RemoteWebDriver(new Uri(gridUrl), WebDriverSettings.InternetExplorerOptions());
                case Browser.Edge:
                    return new RemoteWebDriver(new Uri(gridUrl), WebDriverSettings.EdgeOptions());
                default:
                    throw new ArgumentOutOfRangeException(nameof(Configuration.WebDriver.BrowserName),
                        Configuration.WebDriver.BrowserName,
                        null);
            }
        }
    }
}