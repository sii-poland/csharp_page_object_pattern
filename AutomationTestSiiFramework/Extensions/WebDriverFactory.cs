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

        public IWebDriver GetWebDriver(L logger)
        {
            switch (Browser)
            {
                case Browser.Chrome:
                    var chromeDriver = new ChromeDriver(TestSettings.DriverPath);
                    return new WebDriverListener(chromeDriver, logger);
                case Browser.Firefox:
                    var firefoxDriver = new FirefoxDriver(TestSettings.DriverPath);
                    return new WebDriverListener(firefoxDriver, logger);
                case Browser.InternetExplorer:
                    return new InternetExplorerDriver();
                case Browser.Edge:
                    return new EdgeDriver();
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
                    var chromeOptions = new ChromeOptions();
                    return new RemoteWebDriver(new Uri(GridUrl), chromeOptions);
                case Browser.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    return new RemoteWebDriver(new Uri(GridUrl), firefoxOptions);
                case Browser.InternetExplorer:
                    var ieOptions = new InternetExplorerOptions();
                    return new RemoteWebDriver(new Uri(GridUrl), ieOptions);
                case Browser.Edge:
                    var edgeOptions = new EdgeOptions();
                    return new RemoteWebDriver(new Uri(GridUrl), edgeOptions);
                default:
                    return null;
            }
        }
    }
}