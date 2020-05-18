using System;
using AutomationTestSiiFramework.Models;
using LLibrary;
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
        public WebDriverListener GetWebDriver(WebDriverConfiguration driverConfig, L logger)
        {
            return driverConfig.BrowserType == BrowserType.Local
                ? GetLocalWebDriver(driverConfig, logger)
                : GetRemoteDriver(driverConfig, logger);
        }

        private WebDriverListener GetLocalWebDriver(WebDriverConfiguration driverConfig, L logger)
        {
            switch (driverConfig.BrowserName)
            {
                case Browser.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeDriver = new ChromeDriver(WebDriverSettings.ChromeOptions(driverConfig));
                    return new WebDriverListener(chromeDriver, logger);
                case Browser.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    var firefoxDriver = new FirefoxDriver(WebDriverSettings.FirefoxOptions(driverConfig));
                    return new WebDriverListener(firefoxDriver, logger);
                case Browser.InternetExplorer:
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    var ieDriver = new InternetExplorerDriver(WebDriverSettings.InternetExplorerOptions());
                    return new WebDriverListener(ieDriver, logger);
                case Browser.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    var edgeDriver = new EdgeDriver(WebDriverSettings.EdgeOptions());
                    return new WebDriverListener(edgeDriver, logger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(Configuration.WebDriver.BrowserName),
                        Configuration.WebDriver.BrowserName,
                        null);
            }
        }

        private WebDriverListener GetRemoteDriver(WebDriverConfiguration driverConfig, L logger)
        {
            switch (driverConfig.BrowserName)
            {
                case Browser.Chrome:
                    return new WebDriverListener(new RemoteWebDriver(new Uri(driverConfig.GridUrl),
                        WebDriverSettings.ChromeOptionsForRemote(driverConfig)), logger);

                case Browser.Firefox:
                    return new WebDriverListener(new RemoteWebDriver(new Uri(driverConfig.GridUrl),
                        WebDriverSettings.FirefoxOptions(driverConfig)), logger);

                case Browser.InternetExplorer:
                    return new WebDriverListener(new RemoteWebDriver(new Uri(driverConfig.GridUrl),
                        WebDriverSettings.InternetExplorerOptions()), logger);

                case Browser.Edge:
                    return new WebDriverListener(new RemoteWebDriver(new Uri(driverConfig.GridUrl),
                        WebDriverSettings.EdgeOptions()), logger);

                default:
                    throw new ArgumentOutOfRangeException(nameof(Configuration.WebDriver.BrowserName),
                        Configuration.WebDriver.BrowserName,
                        null);
            }
        }
    }
}