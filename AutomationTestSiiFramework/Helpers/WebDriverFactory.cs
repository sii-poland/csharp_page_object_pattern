using System;
using AutomationTestSiiFramework.Models;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationTestSiiFramework.Helpers
{
    public class WebDriverFactory
    {
        public IWebDriver GetWebDriver(WebDriverConfiguration driverConfig, L logger)
        {
            return driverConfig.BrowserType == BrowserType.Local
                ? GetLocalWebDriver(driverConfig, logger)
                : GetRemoteDriver(driverConfig);
        }

        private IWebDriver GetLocalWebDriver(WebDriverConfiguration driverConfig, L logger)
        {
            switch (driverConfig.BrowserName)
            {
                case Browser.Chrome:
                    new DriverManager ().SetUpDriver (new ChromeConfig ());
                    var chromeDriver = new ChromeDriver(WebDriverSettings.ChromeOptions(driverConfig));
                    return new WebDriverListener(chromeDriver, logger);
                case Browser.Firefox:
                    new DriverManager ().SetUpDriver (new FirefoxConfig());
                    var firefoxDriver = new FirefoxDriver(WebDriverSettings.FirefoxOptions(driverConfig));
                    return new WebDriverListener(firefoxDriver, logger);
                case Browser.InternetExplorer:
                    new DriverManager ().SetUpDriver (new InternetExplorerConfig());
                    var ieDriver = new InternetExplorerDriver(WebDriverSettings.InternetExplorerOptions());
                    return new WebDriverListener(ieDriver, logger);
                case Browser.Edge:
                    new DriverManager ().SetUpDriver (new EdgeConfig());
                    var edgeDriver = new EdgeDriver(WebDriverSettings.EdgeOptions());
                    return new WebDriverListener(edgeDriver, logger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(Configuration.WebDriver.BrowserName),
                        Configuration.WebDriver.BrowserName,
                        null);
            }
        }

        private RemoteWebDriver GetRemoteDriver(WebDriverConfiguration driverConfig)
        {
            switch (driverConfig.BrowserName)
            {
                case Browser.Chrome:
                    return new RemoteWebDriver(new Uri(driverConfig.GridUrl),
                        WebDriverSettings.ChromeOptionsForRemote(driverConfig));
                case Browser.Firefox:
                    return new RemoteWebDriver(new Uri(driverConfig.GridUrl),
                        WebDriverSettings.FirefoxOptions(driverConfig));
                case Browser.InternetExplorer:
                    return new RemoteWebDriver(new Uri(driverConfig.GridUrl),
                        WebDriverSettings.InternetExplorerOptions());
                case Browser.Edge:
                    return new RemoteWebDriver(new Uri(driverConfig.GridUrl),
                        WebDriverSettings.EdgeOptions());
                default:
                    throw new ArgumentOutOfRangeException(nameof(Configuration.WebDriver.BrowserName),
                        Configuration.WebDriver.BrowserName,
                        null);
            }
        }
    }
}