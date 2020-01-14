using System;
using System.IO;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SiiFramework.Extensions
{
    public class WebDriverFactory
    {
        public IWebDriver GetWebDriver(string browserName, L logger)
        {
            switch (browserName.ToEnum<Browser>())
            {
                case Browser.Chrome:
                    var chromeDriver = new ChromeDriver(TestSettings.FullPath);
                    return new WebDriverListener(chromeDriver, logger);
                case Browser.Firefox:
                    var firefoxDriver = new FirefoxDriver(TestSettings.FullPath);
                    return new WebDriverListener(firefoxDriver, logger);
                default:
                    throw new ArgumentOutOfRangeException(nameof(TestSettings.BrowserName), TestSettings.BrowserName,
                        null);
            }
        }

        public RemoteWebDriver GetRemoteDriver(string gridUrl)
        {
            switch (TestSettings.BrowserName.ToEnum<Browser>())
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