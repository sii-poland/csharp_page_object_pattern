using System;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AutomationTestSiiFramework.Extensions
{
    public class WebDriverFactory
    {
        public IWebDriver GetWebDriver(string browserName, L logger)
        {
            switch (browserName.ToEnum<Browser>())
            {
                case Browser.Chrome:
                    var chromeDriver = new ChromeDriver(TestSettings.DriverPath);
                    return new WebDriverListener(chromeDriver, logger);
                case Browser.Firefox:
                    var firefoxDriver = new FirefoxDriver(TestSettings.DriverPath);
                    return new WebDriverListener(firefoxDriver, logger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(TestSettings.ConfigurationJson.BrowserName),
                        TestSettings.ConfigurationJson.BrowserName,
                        null);
            }
        }

        public RemoteWebDriver GetRemoteDriver(string browserName, string gridUrl)
        {
            switch (browserName.ToEnum<Browser>())
            {
                case Browser.Chrome:
                    var options = new ChromeOptions();
                    return new RemoteWebDriver(new Uri(gridUrl), options);
                case Browser.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    return new RemoteWebDriver(new Uri(gridUrl), firefoxOptions);
            }

            return null;
        }
    }
}